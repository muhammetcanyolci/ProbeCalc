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
	/// Elektrik Kuvveti (Coulomb Yasası) hesaplamalarını yapan somut motor
	/// sınıfı. İki nokta yük arasındaki çekim/itme kuvvetini hesaplar.
	/// ElectricalEngine sınıfından miras alır.
	/// </summary>
	public class ElectricForceEngine : ElectricalEngine
	{
		// 1. GİRDİLER (INPUTS)

		// Birinci yük (Q1) - Coulomb (C) cinsinden.
		private double _charge1;
		public double Charge1
		{
			get => _charge1;
			set
			{
				if (!IsChargeNonZero(value))
				{
					throw new ArgumentOutOfRangeException(nameof(Charge1),
						"Birinci yük (Q1) sıfır olamaz.");
				}
				_charge1 = value;
			}
		}

		// İkinci yük (Q2) - Coulomb (C) cinsinden.
		private double _charge2;
		public double Charge2
		{
			get => _charge2;
			set
			{
				if (!IsChargeNonZero(value))
				{
					throw new ArgumentOutOfRangeException(nameof(Charge2),
						"İkinci yük (Q2) sıfır olamaz.");
				}
				_charge2 = value;
			}
		}
		// Distance (r) -> ElectricalEngine'den miras alınıyor (>0 kontrolü orada)

		// 2. ÇIKTILAR (OUTPUTS)
		public double ElectricForce { get; private set; }   // F, N
		public string ForceNature { get; private set; }     // İtme / Çekme

		// 3. GRAFİK İÇİN KOORDİNAT DİZİLERİ
		public double[] DistanceX { get; private set; }
		public double[] ForceY { get; private set; }

		// 4. HESAPLAMA MANTIĞI (CALCULATE)
		/// <summary>
		/// Coulomb Yasası'nı kullanarak iki yük arasındaki kuvveti hesaplar.
		/// </summary>
		public override void Calculate()
		{
			// Coulomb Kuvveti Hesabı: F = k * |Q1 * Q2| / r²
			ElectricForce = CoulombConstant * Math.Abs(Charge1 * Charge2) / Math.Pow(Distance, 2);

			// İtme mi çekme mi: aynı işaret -> itme, zıt işaret -> çekme
			ForceNature = Math.Sign(Charge1) == Math.Sign(Charge2)
				? "İtme (Aynı işaretli yükler birbirini iter)"
				: "Çekme (Zıt işaretli yükler birbirini çeker)";

			// ADIM ADIM ÇÖZÜM RAPORUNUN HAZIRLANMASI
			SolutionSteps = "--- ARKA PLAN HESAPLAMA ADIMLARI ---\n\n";

			SolutionSteps += "1. Adım: Coulomb Kuvveti (F) Hesabı\n";
			SolutionSteps += $"   Kullanılan Formül: F = k * |Q1 * Q2| / r²\n";
			SolutionSteps += $"   İşlem: {CoulombConstant:E2} * |{Charge1:E2} * {Charge2:E2}| / {Distance:F2}² = {ElectricForce:E4} N\n\n";

			SolutionSteps += "2. Adım: Kuvvetin Niteliği\n";
			SolutionSteps += $"   Sonuç: {ForceNature}\n";

			SolutionSteps += "\n--------------------------------------------------\n";
			SolutionSteps += "🎯 ÖZET SONUÇLAR:\n";
			SolutionSteps += $"   Coulomb Kuvveti (F): {ElectricForce:E4} N\n";
			SolutionSteps += $"   Nitelik            : {ForceNature}\n";

			// --- GRAFİK İÇİN X VE Y KOORDİNATLARININ ÜRETİLMESİ ---
			// 0.1*r ile 3*r aralığında 100 noktalı 1/r² eğrisi
			int pointCount = 100;
			DistanceX = new double[pointCount];
			ForceY = new double[pointCount];

			double startR = Distance * 0.1;
			double endR = Distance * 3.0;
			double stepR = (endR - startR) / (pointCount - 1);

			for (int i = 0; i < pointCount; i++)
			{
				double r = startR + (i * stepR);
				DistanceX[i] = r;
				ForceY[i] = CoulombConstant * Math.Abs(Charge1 * Charge2) / Math.Pow(r, 2);
			}
		}

		protected override string GetShortResultText()
		{
			return $" Coulomb Kuvveti (F): {ElectricForce:E4} N\n Nitelik            : {ForceNature}\n";
		}

		public override void Reset()
		{
			base.Reset();

			_charge1 = 0;
			_charge2 = 0;
			ElectricForce = 0;
			ForceNature = null;

			DistanceX = null;
			ForceY = null;
		}
	}
}
