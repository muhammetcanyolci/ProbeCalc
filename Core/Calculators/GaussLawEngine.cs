using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using ProbeCalc.Core.Base;

namespace ProbeCalc.Core.Calculators
{

	/// <summary>
	/// Desteklenen Gauss yüzeyi / yük geometrisi senaryoları.
	/// ComboBox'taki "Sistem Geometrisi" seçimiyle birebir eşleşir.
	/// </summary>
	public enum GaussGeometryType
	{
		PointCharge,        // Noktasal Yük
		InsulatingSphere,   // Yalıtkan Küre (Dolu, homojen hacim yükü)
		ConductingSphere,   // İletken Küre (Tüm yük yüzeyde)
		LineCharge,         // Çizgisel Yük (Sonsuz tel, silindirik simetri)
		InfinitePlane       // Sonsuz Düzlem (Yüzey yükü, düzlemsel simetri)
	}

	/// <summary>
	/// Gauss Yasası (Gauss's Law) hesaplamalarını yapan somut motor sınıfı.
	/// Tek bir sınıf, 5 farklı klasik Gauss yüzeyi/simetri senaryosunu
	/// GeometryType'a göre dallanarak hesaplar. ElectricalEngine'den miras alır.
	///
	/// Girdi anlamı geometriye göre değişir (SourceValue):
	///   PointCharge / InsulatingSphere / ConductingSphere -> Toplam Yük Q (C)
	///   LineCharge                                        -> Doğrusal Yoğunluk λ (C/m)
	///   InfinitePlane                                      -> Yüzey Yoğunluğu σ (C/m²)
	/// </summary>
	public class GaussLawEngine : ElectricalEngine
	{
		// ====================================================================
		// STATİK YARDIMCI METOTLAR (DOMAIN KARARLARI)
		// Bunlar Form'un bilmesi gereken değil, GEOMETRİNİN kendi kuralları.
		// TemelFizikForm sadece bu metotları çağırıp sonucu bir Control'e
		// yazar — "hangi modda R gerekir" gibi bir switch/if Form'da durmaz.
		// ====================================================================

		// R gerektirmeyen modlarda TrackBar'ın temsil ettiği varsayılan menzil (m)
		public const double DefaultObservationRangeMeters = 5.0;

		/// <summary>Bu geometri için "Toplam Yük / Yoğunluk" kutusunun yanına yazılacak etiket metni.</summary>
		public static string GetChargeLabelText(GaussGeometryType type)
		{
			switch (type)
			{
				case GaussGeometryType.LineCharge:
					return "Doğrusal Yoğunluk (λ) [μC/m]:";
				case GaussGeometryType.InfinitePlane:
					return "Yüzey Yoğunluğu (σ) [μC/m²]:";
				default: // PointCharge, InsulatingSphere, ConductingSphere
					return "Toplam Yük (Q) [μC]:";
			}
		}

		/// <summary>Bu geometri, küre yarıçapı (R) girişi gerektiriyor mu?</summary>
		public static bool RequiresSphereRadius(GaussGeometryType type)
		{
			return type == GaussGeometryType.InsulatingSphere
				|| type == GaussGeometryType.ConductingSphere;
		}

		/// <summary>
		/// TrackBar'ın kaç metreye kadar tarayacağını belirler. Küre modlarında
		/// girilen R'ye göre (R*5), diğer modlarda sabit varsayılana göre.
		/// </summary>
		public static double GetSuggestedObservationRange(GaussGeometryType type, double enteredRadius)
		{
			if (RequiresSphereRadius(type) && enteredRadius > 0)
				return enteredRadius * 5.0;

			return DefaultObservationRangeMeters;
		}

		// 1. GİRDİLER (INPUTS)

		public GaussGeometryType GeometryType { get; set; } = GaussGeometryType.PointCharge;

		// Q, λ veya σ — hangisi olduğu GeometryType'a bağlı. SI birimiyle gelir
		// (UI katmanında μC/μC-m/μC-m² gibi pratik birimlerden çevrilir).
		private double _sourceValue;
		public double SourceValue
		{
			get => _sourceValue;
			set
			{
				if (!IsChargeNonZero(value))
				{
					throw new ArgumentOutOfRangeException(nameof(SourceValue),
						"Yük / yoğunluk değeri sıfır olamaz.");
				}
				_sourceValue = value;
			}
		}

		// Küre yarıçapı (R) - sadece InsulatingSphere ve ConductingSphere için
		// zorunludur; diğer geometrilerde kullanılmaz. Bu yüzden validasyon
		// property setter'ında DEĞİL, Calculate() içinde moda göre yapılır.
		public double SphereRadius { get; set; }

		// Distance (r) -> ElectricalEngine'den miras (gözlem noktası / TrackBar konumu)

		// 2. ÇIKTILAR (OUTPUTS)
		public double ElectricFieldAtR { get; private set; }   // E(r), N/C
		public double EnclosedCharge { get; private set; }     // Q_enc, C (plane/line'da anlamsız, 0 kalır)
		public string RegionLabel { get; private set; }        // UI'daki lblGaussRegion için

		// 3. GRAFİK İÇİN KOORDİNAT DİZİLERİ
		public double[] DistanceX { get; private set; }
		public double[] FieldY { get; private set; }

		// 4. HESAPLAMA MANTIĞI (CALCULATE)
		public override void Calculate()
		{
			SolutionSteps = "--- ARKA PLAN HESAPLAMA ADIMLARI (GAUSS YASASI) ---\n\n";

			switch (GeometryType)
			{
				case GaussGeometryType.PointCharge:
					CalculatePointCharge();
					break;
				case GaussGeometryType.InsulatingSphere:
					CalculateInsulatingSphere();
					break;
				case GaussGeometryType.ConductingSphere:
					CalculateConductingSphere();
					break;
				case GaussGeometryType.LineCharge:
					CalculateLineCharge();
					break;
				case GaussGeometryType.InfinitePlane:
					CalculateInfinitePlane();
					break;
			}

			SolutionSteps += "\n--------------------------------------------------\n";
			SolutionSteps += "🎯 ÖZET SONUÇLAR:\n";
			SolutionSteps += $"   Geometri           : {GeometryType}\n";
			SolutionSteps += $"   Bölge              : {RegionLabel}\n";
			SolutionSteps += $"   Elektrik Alan (E)  : {ElectricFieldAtR:E4} N/C\n";

			BuildChartArrays();
		}

		// ---- KÜRESEL SİMETRİ: NOKTASAL YÜK -----------------------------------
		private void CalculatePointCharge()
		{
			EnclosedCharge = SourceValue;
			ElectricFieldAtR = CoulombConstant * Math.Abs(SourceValue) / Math.Pow(Distance, 2);
			RegionLabel = "Noktasal Yük (Küresel Simetri)";

			SolutionSteps += "1. Adım: Gauss Yüzeyi — Yük merkezli, r yarıçaplı küre\n";
			SolutionSteps += "   Temel Denklem: E * (4πr²) = Q / ε₀  ->  E = k*Q/r²\n";
			SolutionSteps += $"   İşlem: {CoulombConstant:E2} * {Math.Abs(SourceValue):E2} / {Distance:F3}² = {ElectricFieldAtR:E4} N/C\n";
		}

		// ---- KÜRESEL SİMETRİ: YALITKAN KÜRE (homojen hacim yükü) -------------
		private void CalculateInsulatingSphere()
		{
			if (SphereRadius <= 0)
				throw new ArgumentOutOfRangeException(nameof(SphereRadius),
					"Yalıtkan küre için yarıçap (R) sıfırdan büyük olmalıdır.");

			bool isInside = Distance <= SphereRadius;

			if (isInside)
			{
				EnclosedCharge = SourceValue * Math.Pow(Distance / SphereRadius, 3);
				RegionLabel = "Yalıtkan Küre İçi (r ≤ R)";
				SolutionSteps += "1. Adım: r ≤ R -> Gauss yüzeyi kürenin bir kısmını kapsıyor\n";
				SolutionSteps += "   Q_enc = Q * (r/R)³  (homojen hacim yükü varsayımı)\n";
			}
			else
			{
				EnclosedCharge = SourceValue;
				RegionLabel = "Yalıtkan Küre Dışı (r > R)";
				SolutionSteps += "1. Adım: r > R -> Gauss yüzeyi kürenin tamamını kapsıyor\n";
				SolutionSteps += "   Q_enc = Q  (noktasal yük gibi davranır)\n";
			}

			ElectricFieldAtR = CoulombConstant * Math.Abs(EnclosedCharge) / Math.Pow(Distance, 2);

			SolutionSteps += $"   Q_enc = {EnclosedCharge:E4} C\n";
			SolutionSteps += "2. Adım: E = k * Q_enc / r²\n";
			SolutionSteps += $"   İşlem: {CoulombConstant:E2} * {Math.Abs(EnclosedCharge):E2} / {Distance:F3}² = {ElectricFieldAtR:E4} N/C\n";
		}

		// ---- KÜRESEL SİMETRİ: İLETKEN KÜRE (tüm yük yüzeyde) ------------------
		private void CalculateConductingSphere()
		{
			if (SphereRadius <= 0)
				throw new ArgumentOutOfRangeException(nameof(SphereRadius),
					"İletken küre için yarıçap (R) sıfırdan büyük olmalıdır.");

			bool isInside = Distance < SphereRadius;

			if (isInside)
			{
				EnclosedCharge = 0;
				ElectricFieldAtR = 0;
				RegionLabel = "İletken Küre İçi (E = 0)";
				SolutionSteps += "1. Adım: r < R -> İletkenin İÇİNDE serbest yük bulunmaz,\n";
				SolutionSteps += "   tüm yük dış yüzeye toplanmıştır -> Q_enc = 0 -> E = 0\n";
			}
			else
			{
				EnclosedCharge = SourceValue;
				ElectricFieldAtR = CoulombConstant * Math.Abs(SourceValue) / Math.Pow(Distance, 2);
				RegionLabel = "İletken Küre Dışı (r ≥ R)";
				SolutionSteps += "1. Adım: r ≥ R -> Q_enc = Q (yüzeydeki tüm yük)\n";
				SolutionSteps += "   E = k * Q / r²\n";
				SolutionSteps += $"   İşlem: {CoulombConstant:E2} * {Math.Abs(SourceValue):E2} / {Distance:F3}² = {ElectricFieldAtR:E4} N/C\n";
			}
		}

		// ---- SİLİNDİRİK SİMETRİ: ÇİZGİSEL YÜK (sonsuz tel) --------------------
		private void CalculateLineCharge()
		{
			// E = λ / (2πε₀r) = 2kλ/r
			ElectricFieldAtR = 2 * CoulombConstant * Math.Abs(SourceValue) / Distance;
			EnclosedCharge = 0; // Silindirik simetride "kapsanan yük" kavramı λ üzerinden ifade edilir, Q değil
			RegionLabel = "Çizgisel Yük (Silindirik Simetri)";

			SolutionSteps += "1. Adım: Gauss Yüzeyi — Tel eksenli, r yarıçaplı, silindirik yüzey\n";
			SolutionSteps += "   Temel Denklem: E * (2πrL) = λL / ε₀  ->  E = λ / (2πε₀r) = 2kλ/r\n";
			SolutionSteps += $"   İşlem: 2 * {CoulombConstant:E2} * {Math.Abs(SourceValue):E2} / {Distance:F3} = {ElectricFieldAtR:E4} N/C\n";
		}

		// ---- DÜZLEMSEL SİMETRİ: SONSUZ DÜZLEM ---------------------------------
		private void CalculateInfinitePlane()
		{
			// E = σ / (2ε₀) — mesafeden BAĞIMSIZ, sabit alan
			ElectricFieldAtR = Math.Abs(SourceValue) / (2 * VacuumPermittivity);
			EnclosedCharge = 0;
			RegionLabel = "Sonsuz Düzlem (Düzlemsel Simetri — E sabittir)";

			SolutionSteps += "1. Adım: Gauss Yüzeyi — Düzlemi dik kesen 'hap kutusu' (pillbox)\n";
			SolutionSteps += "   Temel Denklem: E * (2A) = σA / ε₀  ->  E = σ / (2ε₀)\n";
			SolutionSteps += $"   İşlem: {Math.Abs(SourceValue):E2} / (2 * {VacuumPermittivity:E2}) = {ElectricFieldAtR:E4} N/C\n";
			SolutionSteps += "   NOT: Bu sonuç r'den bağımsızdır — düzlemden ne kadar uzaklaşılırsa\n";
			SolutionSteps += "   uzaklaşılsın alan şiddeti değişmez.\n";
		}

		// ---- GRAFİK DİZİLERİNİN ÜRETİLMESİ -------------------------------------
		private void BuildChartArrays()
		{
			int pointCount = 200;
			DistanceX = new double[pointCount];
			FieldY = new double[pointCount];

			// Sphere modlarında R referans alınır, diğerlerinde r'nin kendisi
			double maxR = SphereRadius > 0 ? SphereRadius * 3.0 : Distance * 3.0;
			double step = maxR / (pointCount - 1);

			for (int i = 0; i < pointCount; i++)
			{
				double r = (i == 0) ? 1e-6 : i * step;
				DistanceX[i] = r;

				switch (GeometryType)
				{
					case GaussGeometryType.PointCharge:
						FieldY[i] = CoulombConstant * Math.Abs(SourceValue) / Math.Pow(r, 2);
						break;

					case GaussGeometryType.InsulatingSphere:
						FieldY[i] = r <= SphereRadius
							? CoulombConstant * Math.Abs(SourceValue * Math.Pow(r / SphereRadius, 3)) / Math.Pow(r, 2)
							: CoulombConstant * Math.Abs(SourceValue) / Math.Pow(r, 2);
						break;

					case GaussGeometryType.ConductingSphere:
						FieldY[i] = r < SphereRadius
							? 0
							: CoulombConstant * Math.Abs(SourceValue) / Math.Pow(r, 2);
						break;

					case GaussGeometryType.LineCharge:
						FieldY[i] = 2 * CoulombConstant * Math.Abs(SourceValue) / r;
						break;

					case GaussGeometryType.InfinitePlane:
						FieldY[i] = Math.Abs(SourceValue) / (2 * VacuumPermittivity); // sabit
						break;
				}
			}
		}

		protected override string GetShortResultText()
		{
			return $" Geometri          : {GeometryType}\n" +
				   $" Bölge             : {RegionLabel}\n" +
				   $" Elektrik Alan (E) : {ElectricFieldAtR:E4} N/C\n";
		}

		public override void Reset()
		{
			base.Reset();

			GeometryType = GaussGeometryType.PointCharge;
			_sourceValue = 0;
			SphereRadius = 0;

			ElectricFieldAtR = 0;
			EnclosedCharge = 0;
			RegionLabel = null;

			DistanceX = null;
			FieldY = null;
		}
	}
}

