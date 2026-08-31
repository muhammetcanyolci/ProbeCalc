using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProbeCalc.Core.Base;

namespace ProbeCalc.Core.Calculators
{

	/// <summary>
	/// Faraday'ın İndüksiyon Yasası kapsamındaki klasik senaryolar.
	/// İndüktans (öz/karşılıklı) BİLEREK burada YOK — ayrı bir konu/motor
	/// olarak ele alınacak.
	/// </summary>
	public enum FaradayMode
	{
		FixedLoopChangingField,  // Sabit Halka - Değişen Manyetik Alan (transformatör mantığı)
		MotionalEMF,             // Hareketli İletken (Raylı Çubuk)
		RotatingGenerator        // Döner Jeneratör (AC Üretici)
	}

	/// <summary>
	/// Faraday Yasası kapsamındaki 3 klasik elektromanyetik indüksiyon
	/// senaryosunu FaradayMode'a göre dallanarak hesaplayan motor sınıfı.
	/// PhysicsEngine'den doğrudan miras alır (CollisionEngine/GaussLawEngine
	/// gibi bir üst sınıfa özel bir bağımlılığı yok).
	/// </summary>
	public class FaradayEngine : PhysicsEngine
	{
		// ====================================================================
		// STATİK YARDIMCI METOTLAR (DOMAIN KARARLARI) — Form'a sızmasın diye
		// ====================================================================

		/// <summary>Panelin en üstüne, hiç değişmeyen, genel açıklama metni.</summary>
		public static string GetTopDescription()
		{
			return "Bu panel, Faraday'ın İndüksiyon Yasası kapsamında elektromanyetik " +
				   "indüklenen EMK (elektromotor kuvvet) hesaplar: sabit bir halkadan geçen " +
				   "manyetik alanın zamanla değişmesi, manyetik alan içinde hareket eden bir " +
				   "iletkenin süpürdüğü alan, ya da sabit bir alan içinde dönen bir bobinin " +
				   "ürettiği alternatif akım (AC) gerilimi. ";
		}

		/// <summary>Seçilen moda özel, TabControl sekmesi altındaki açıklama etiketine yazılacak kısa metin.</summary>
		public static string GetModeDescription(FaradayMode mode)
		{
			switch (mode)
			{
				case FaradayMode.MotionalEMF:
					return "Sabit bir manyetik alan içinde, raylar üzerinde kayan bir iletken " +
						   "çubuğun süpürdüğü alan değişimi nedeniyle oluşan EMK'yı hesaplar.";
				case FaradayMode.RotatingGenerator:
					return "Sabit bir manyetik alan içinde sabit açısal hızla dönen bir bobinin " +
						   "ürettiği alternatif (sinüzoidal) gerilimi hesaplar.";
				default: // FixedLoopChangingField
					return "Sabit duran bir halkadan geçen manyetik alanın zamanla değişmesi " +
						   "sonucu oluşan ortalama EMK'yı hesaplar (transformatör mantığı).";
			}
		}

		// NOT: Bu dosyada eskiden RequiresFixedLoopFields/RequiresMotionalFields/
		// RequiresGeneratorFields adında 3 statik metot vardı — ComboBox +
		// Enabled/Disabled tasarımı içindi. TabControl'e geçilince (her sekme
		// zaten kendi alanlarını barındırıyor) form tarafında hiç çağıran
		// kalmadığı için kaldırıldılar. İleride tekrar gerekirse GetModeDescription
		// ile aynı desende kolayca eklenebilir.

		// 1. GİRDİLER (INPUTS)

		public FaradayMode Mode { get; set; } = FaradayMode.FixedLoopChangingField;

		// --- Mod 1: Sabit Halka - Değişen Alan ---
		private double _turns = 1;
		public double Turns
		{
			get => _turns;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(Turns), "Sarım sayısı (N) sıfırdan büyük olmalıdır.");
				_turns = value;
			}
		}

		private double _area;
		public double Area
		{
			get => _area;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(Area), "Alan (A) sıfırdan büyük olmalıdır.");
				_area = value;
			}
		}

		private double _angleDegrees = 0;
		public double AngleDegrees
		{
			get => _angleDegrees;
			set
			{
				if (value < 0 || value > 180)
					throw new ArgumentOutOfRangeException(nameof(AngleDegrees), "Açı (θ) 0 ile 180 derece arasında olmalıdır.");
				_angleDegrees = value;
			}
		}

		public double InitialMagneticField { get; set; }
		public double FinalMagneticField { get; set; }

		private double _deltaTime;
		public double DeltaTime
		{
			get => _deltaTime;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(DeltaTime), "Geçen süre (Δt) sıfırdan büyük olmalıdır.");
				_deltaTime = value;
			}
		}

		// --- Mod 2: Hareketli İletken (Raylı Çubuk) ---
		// Sabit manyetik alan -> ConstantMagneticField (Mod 3 ile ortak kullanılır)
		public double ConstantMagneticField { get; set; }

		private double _rodLength;
		public double RodLength
		{
			get => _rodLength;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(RodLength), "Çubuk uzunluğu (L) sıfırdan büyük olmalıdır.");
				_rodLength = value;
			}
		}

		private double _velocity;
		public double Velocity
		{
			get => _velocity;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(Velocity), "Hız (v) sıfırdan büyük olmalıdır.");
				_velocity = value;
			}
		}

		// --- Mod 3: Döner Jeneratör --- (Turns ve Area, Mod 1 ile ortak kullanılır)
		private double _frequency;
		public double Frequency
		{
			get => _frequency;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(Frequency), "Frekans (f) sıfırdan büyük olmalıdır.");
				_frequency = value;
			}
		}

		// 2. ÇIKTILAR (OUTPUTS)
		public double InitialFlux { get; private set; }
		public double FinalFlux { get; private set; }
		public double FluxChange { get; private set; }
		public double InducedEMF { get; private set; }     // Mod 1: ortalama | Mod 2: sabit | Mod 3: tepe (peak)
		public double Period { get; private set; }         // Sadece Mod 3
		public string LenzDirectionNote { get; private set; }

		// 3. GRAFİK İÇİN KOORDİNAT DİZİLERİ (her modda farklı doldurulur)
		public double[] ChartX { get; private set; }
		public double[] ChartY { get; private set; }

		// 4. HESAPLAMA MANTIĞI (CALCULATE)
		public override void Calculate()
		{
			SolutionSteps = "--- ARKA PLAN HESAPLAMA ADIMLARI (FARADAY YASASI) ---\n\n";

			switch (Mode)
			{
				case FaradayMode.MotionalEMF:
					CalculateMotionalEMF();
					break;
				case FaradayMode.RotatingGenerator:
					CalculateRotatingGenerator();
					break;
				default:
					CalculateFixedLoopChangingField();
					break;
			}

			SolutionSteps += "\n--------------------------------------------------\n";
			SolutionSteps += "🎯 ÖZET SONUÇLAR:\n";
			SolutionSteps += $"   Mod              : {GetModeDescription(Mode)}\n";
			SolutionSteps += $"   İndüklenen EMK   : {InducedEMF:E4} Volt\n";
			if (LenzDirectionNote != null)
				SolutionSteps += $"   Not              : {LenzDirectionNote}\n";
		}

		// ---- MOD 1: SABİT HALKA - DEĞİŞEN ALAN --------------------------------
		private void CalculateFixedLoopChangingField()
		{
			double thetaRad = DegreesToRadian(AngleDegrees);

			InitialFlux = InitialMagneticField * Area * Math.Cos(thetaRad);
			FinalFlux = FinalMagneticField * Area * Math.Cos(thetaRad);
			FluxChange = FinalFlux - InitialFlux;
			InducedEMF = -Turns * (FluxChange / DeltaTime);

			LenzDirectionNote = FluxChange > 0
				? "Akı ARTIYOR -> İndüklenen akım buna KARŞI koyacak yönde bir alan oluşturur."
				: FluxChange < 0
					? "Akı AZALIYOR -> İndüklenen akım bu azalmayı TELAFİ edecek yönde bir alan oluşturur."
					: "Akı değişmiyor -> İndüklenen EMK sıfırdır.";

			SolutionSteps += "1. Adım: Başlangıç ve Bitiş Manyetik Akısı\n";
			SolutionSteps += "   Kullanılan Formül: Φ = B * A * cos(θ)\n";
			SolutionSteps += $"   Φ1 = {InitialMagneticField:F3} * {Area:F4} * cos({AngleDegrees}°) = {InitialFlux:E4} Weber\n";
			SolutionSteps += $"   Φ2 = {FinalMagneticField:F3} * {Area:F4} * cos({AngleDegrees}°) = {FinalFlux:E4} Weber\n\n";

			SolutionSteps += "2. Adım: İndüklenen EMK (Faraday-Lenz Yasası)\n";
			SolutionSteps += "   Kullanılan Formül: ε = -N * (ΔΦ / Δt)\n";
			SolutionSteps += $"   İşlem: -{Turns} * (({FinalFlux:E4} - {InitialFlux:E4}) / {DeltaTime:F3}) = {InducedEMF:E4} Volt\n";

			// Grafik: Φ(t), Φ1'den Φ2'ye doğrusal
			int pointCount = 100;
			ChartX = new double[pointCount];
			ChartY = new double[pointCount];
			double timeStep = DeltaTime / (pointCount - 1);
			for (int i = 0; i < pointCount; i++)
			{
				double t = i * timeStep;
				ChartX[i] = t;
				ChartY[i] = InitialFlux + (FluxChange * (t / DeltaTime));
			}
		}

		// ---- MOD 2: HAREKETLİ İLETKEN (RAYLI ÇUBUK) ---------------------------
		private void CalculateMotionalEMF()
		{
			// ε = B * L * v
			InducedEMF = ConstantMagneticField * RodLength * Velocity;
			LenzDirectionNote = "Lenz Yasası'na göre indüklenen akım, çubuğun hareketine KARŞI koyan " +
								 "bir manyetik kuvvet (fren etkisi) oluşturur.";

			SolutionSteps += "1. Adım: Hareketli İletkende İndüklenen EMK\n";
			SolutionSteps += "   Kullanılan Formül: ε = B * L * v\n";
			SolutionSteps += $"   İşlem: {ConstantMagneticField:F3} * {RodLength:F3} * {Velocity:F3} = {InducedEMF:E4} Volt\n";

			// Grafik: EMK'nın hıza göre DOĞRUSAL değişimi (0.1v - 3v aralığında)
			int pointCount = 100;
			ChartX = new double[pointCount];
			ChartY = new double[pointCount];
			double startV = Velocity * 0.1;
			double endV = Velocity * 3.0;
			double stepV = (endV - startV) / (pointCount - 1);
			for (int i = 0; i < pointCount; i++)
			{
				double v = startV + (i * stepV);
				ChartX[i] = v;
				ChartY[i] = ConstantMagneticField * RodLength * v;
			}
		}

		// ---- MOD 3: DÖNER JENERATÖR (AC ÜRETİCİ) -------------------------------
		private void CalculateRotatingGenerator()
		{
			double angularVelocity = 2 * Math.PI * Frequency; // ω = 2πf
			Period = 1.0 / Frequency;

			// Tepe (peak) EMK: ε_max = N * B * A * ω
			InducedEMF = Turns * ConstantMagneticField * Area * angularVelocity;
			LenzDirectionNote = "Üretilen gerilim SÜREKLİ yön değiştirir (alternatif akım / AC) — " +
								 "tek bir Lenz yönü tanımlı değildir.";

			SolutionSteps += "1. Adım: Açısal Hız ve Periyot\n";
			SolutionSteps += "   ω = 2πf\n";
			SolutionSteps += $"   İşlem: 2π * {Frequency:F3} = {angularVelocity:F3} rad/s ,  T = 1/f = {Period:F4} s\n\n";

			SolutionSteps += "2. Adım: Tepe (Maksimum) EMK\n";
			SolutionSteps += "   Kullanılan Formül: ε_max = N * B * A * ω\n";
			SolutionSteps += $"   İşlem: {Turns} * {ConstantMagneticField:F3} * {Area:F4} * {angularVelocity:F3} = {InducedEMF:E4} Volt\n";

			// Grafik: ε(t) = ε_max * sin(ωt), iki tam periyot boyunca
			int pointCount = 200;
			ChartX = new double[pointCount];
			ChartY = new double[pointCount];
			double totalTime = Period * 2;
			double timeStep = totalTime / (pointCount - 1);
			for (int i = 0; i < pointCount; i++)
			{
				double t = i * timeStep;
				ChartX[i] = t;
				ChartY[i] = InducedEMF * Math.Sin(angularVelocity * t);
			}
		}

		protected override string GetShortResultText()
		{
			return $" Mod             : {GetModeDescription(Mode)}\n" +
				   $" İndüklenen EMK  : {InducedEMF:E4} Volt\n";
		}

		public override void Reset()
		{
			Mode = FaradayMode.FixedLoopChangingField;

			_turns = 1;
			_area = 0;
			_angleDegrees = 0;
			InitialMagneticField = 0;
			FinalMagneticField = 0;
			_deltaTime = 0;

			ConstantMagneticField = 0;
			_rodLength = 0;
			_velocity = 0;

			_frequency = 0;

			InitialFlux = 0;
			FinalFlux = 0;
			FluxChange = 0;
			InducedEMF = 0;
			Period = 0;
			LenzDirectionNote = null;

			ChartX = null;
			ChartY = null;

			SolutionSteps = string.Empty;
		}
	}
}
