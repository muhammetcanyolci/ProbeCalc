using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProbeCalc.Core.Base;

namespace ProbeCalc.Core.Calculators
{
	public enum MagneticFieldSource
	{
		LongStraightWire, // Düzgün Uzun Tel (Ampère Yasası)
		Solenoid          // Solenoid (Bobin İçi)
	}

	/// <summary>
	/// Manyetik Alan (Magnetic Field) hesaplamalarını yapan somut motor
	/// sınıfı. PhysicsEngine'den doğrudan miras alır (MagneticForceEngine
	/// gibi — elektrostatik Distance/CoulombConstant'a ihtiyacı yok, kendi
	/// manyetik sabitini kullanır).
	///
	/// MagneticForceEngine ile İLİŞKİSİ: O motor "var olan bir B alanı
	/// içindeki kuvvet"i hesaplıyordu (B kullanıcıdan geliyordu). Bu motor
	/// ise tam tersi soruyu cevaplıyor: "bu B alanını NE ÜRETİYOR" —
	/// akım taşıyan bir tel mi, yoksa bir solenoid mi. İkisi birlikte,
	/// Elektrik Alan/Kuvvet ayrımının manyetizma karşılığı.
	/// </summary>
	public class MagneticFieldEngine : ElectricalEngine
	{
		// Boşluğun manyetik geçirgenliği (μ₀) - T·m/A. Math.PI bir C# const
		// olduğu için bu ifade derleme zamanında sabitlenebiliyor.
		private const double VacuumPermeability = 4 * Math.PI * 1e-7;

		// 1. GİRDİLER (INPUTS)

		public MagneticFieldSource Source { get; set; } = MagneticFieldSource.LongStraightWire;

		// Akım (I) - Amper. Yönü fiziksel olarak anlamlı olabileceği için
		// (sağ el kuralı, alan yönünü belirler) pozitiflik kontrolüne TABİ
		// TUTULMAZ, sadece sıfır olamaz.
		private double _current;
		public double Current
		{
			get => _current;
			set
			{
				if (value == 0)
					throw new ArgumentOutOfRangeException(nameof(Current), "Akım (I) sıfır olamaz.");
				_current = value;
			}
		}

		// --- Mod 1: Düzgün Uzun Tel ---
		// Telden gözlem noktasına dik uzaklık (r) - metre.
		private double _distanceFromWire;
		public double DistanceFromWire
		{
			get => _distanceFromWire;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(DistanceFromWire), "Telden uzaklık (r) sıfırdan büyük olmalıdır.");
				_distanceFromWire = value;
			}
		}

		// --- Mod 2: Solenoid ---
		private double _totalTurns;
		public double TotalTurns
		{
			get => _totalTurns;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(TotalTurns), "Toplam sarım sayısı (N) sıfırdan büyük olmalıdır.");
				_totalTurns = value;
			}
		}

		private double _solenoidLength;
		public double SolenoidLength
		{
			get => _solenoidLength;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(SolenoidLength), "Solenoid uzunluğu (L) sıfırdan büyük olmalıdır.");
				_solenoidLength = value;
			}
		}

		// 2. ÇIKTILAR (OUTPUTS)
		public double MagneticField { get; private set; }   // B, Tesla
		public double TurnDensity { get; private set; }     // n = N/L, sadece Solenoid modunda anlamlı

		// 3. GRAFİK İÇİN KOORDİNAT DİZİLERİ
		public double[] ChartX { get; private set; }
		public double[] ChartY_Field { get; private set; }

		// 4. HESAPLAMA MANTIĞI (CALCULATE)
		public override void Calculate()
		{
			SolutionSteps = "--- ARKA PLAN HESAPLAMA ADIMLARI (MANYETİK ALAN) ---\n\n";

			if (Source == MagneticFieldSource.LongStraightWire)
				CalculateLongStraightWire();
			else
				CalculateSolenoid();

			SolutionSteps += "\n--------------------------------------------------\n";
			SolutionSteps += "🎯 ÖZET SONUÇLAR:\n";
			SolutionSteps += $"   Kaynak           : {(Source == MagneticFieldSource.LongStraightWire ? "Düzgün Uzun Tel" : "Solenoid")}\n";
			SolutionSteps += $"   Manyetik Alan (B): {MagneticField:E4} Tesla\n";
		}

		// ---- MOD 1: DÜZGÜN UZUN TEL (Ampère Yasası) ---------------------------
		private void CalculateLongStraightWire()
		{
			// B = μ₀ * I / (2π * r)
			MagneticField = VacuumPermeability * Math.Abs(Current) / (2 * Math.PI * DistanceFromWire);
			TurnDensity = 0;

			SolutionSteps += "1. Adım: Ampère Yasası ile Manyetik Alan\n";
			SolutionSteps += "   Kullanılan Formül: B = μ₀ * I / (2π * r)\n";
			SolutionSteps += $"   İşlem: {VacuumPermeability:E3} * {Math.Abs(Current):F3} / (2π * {DistanceFromWire:F3}) = {MagneticField:E4} Tesla\n\n";
			SolutionSteps += "2. Adım: Yön (Sağ El Kuralı)\n";
			SolutionSteps += "   Başparmak akım yönünü gösterirse, diğer parmaklar manyetik alan\n";
			SolutionSteps += "   çizgilerinin telin etrafındaki (dairesel) yönünü gösterir.\n";

			// Grafik: B'nin r'ye göre 1/r azalışı (0.1r - 3r aralığı)
			int pointCount = 100;
			ChartX = new double[pointCount];
			ChartY_Field = new double[pointCount];

			double startR = DistanceFromWire * 0.1;
			double endR = DistanceFromWire * 3.0;
			double stepR = (endR - startR) / (pointCount - 1);

			for (int i = 0; i < pointCount; i++)
			{
				double r = startR + (i * stepR);
				ChartX[i] = r;
				ChartY_Field[i] = VacuumPermeability * Math.Abs(Current) / (2 * Math.PI * r);
			}
		}

		// ---- MOD 2: SOLENOİD (Bobin İçi) --------------------------------------
		private void CalculateSolenoid()
		{
			TurnDensity = TotalTurns / SolenoidLength;

			// B = μ₀ * n * I  (n = N/L)
			MagneticField = VacuumPermeability * TurnDensity * Math.Abs(Current);

			SolutionSteps += "1. Adım: Sarım Yoğunluğu (n)\n";
			SolutionSteps += "   n = N / L\n";
			SolutionSteps += $"   İşlem: {TotalTurns} / {SolenoidLength:F3} = {TurnDensity:F3} sarım/metre\n\n";

			SolutionSteps += "2. Adım: Solenoid İçindeki Manyetik Alan\n";
			SolutionSteps += "   Kullanılan Formül: B = μ₀ * n * I\n";
			SolutionSteps += $"   İşlem: {VacuumPermeability:E3} * {TurnDensity:F3} * {Math.Abs(Current):F3} = {MagneticField:E4} Tesla\n\n";
			SolutionSteps += "3. Adım: Not\n";
			SolutionSteps += "   Bu sonuç, İDEAL (sonsuz uzunlukta kabul edilen) bir solenoidin\n";
			SolutionSteps += "   İÇİNDEKİ alan için geçerlidir ve eksen boyunca SABİTTİR.\n";

			// Grafik: B'nin akıma göre DOĞRUSAL artışı (0 - 3I aralığı) —
			// solenoid içi alan konumdan bağımsız olduğu için, konum yerine
			// akımla değişimi göstermek daha öğretici.
			int pointCount = 100;
			ChartX = new double[pointCount];
			ChartY_Field = new double[pointCount];

			double endI = Math.Abs(Current) * 3.0;
			double stepI = endI / (pointCount - 1);

			for (int i = 0; i < pointCount; i++)
			{
				double iVal = i * stepI;
				ChartX[i] = iVal;
				ChartY_Field[i] = VacuumPermeability * TurnDensity * iVal;
			}
		}

		protected override string GetShortResultText()
		{
			return $" Kaynak            : {(Source == MagneticFieldSource.LongStraightWire ? "Düzgün Uzun Tel" : "Solenoid")}\n" +
				   $" Manyetik Alan (B) : {MagneticField:E4} Tesla\n";
		}

		public override void Reset()
		{
			Source = MagneticFieldSource.LongStraightWire;
			_current = 0;
			_distanceFromWire = 0;
			_totalTurns = 0;
			_solenoidLength = 0;

			MagneticField = 0;
			TurnDensity = 0;

			ChartX = null;
			ChartY_Field = null;

			SolutionSteps = string.Empty;
		}
	}
}

