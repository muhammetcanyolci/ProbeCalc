using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcUni.Core.Base;
using NCalc;

namespace CalcUni.Core.Calculators
{
	public class WorkEnergyEngine : MechanicsEngine
	{
		// --- 1. MOD: ENERJİNİN KORUNUMU GİRDİLERİ ---
		public double FirstHeight { get; set; }
		public double FinalHeight { get; set; }

		// --- 2. MOD: DEĞİŞKEN KUVVET GİRDİLERİ ---
		public double StartX { get; set; }
		public double EndX { get; set; }
		// Dışarıdan matematik motoru tarafından çözülmüş fonksiyon delege olarak gelir
		public Func<double, double> ForceFunction { get; set; }

		// --- ORTAK ÇIKTILAR ---
		public string SolutionSteps { get; private set; }
		public double CalculatedWork { get; private set; }

		// Grafik çizimleri için koordinat dizileri
		public double[] ChartX { get; private set; }
		public double[] ChartY_Kinetic { get; private set; }
		public double[] ChartY_Potential { get; private set; }
		public double[] ChartY_Total { get; private set; }

		public override void Calculate()
		{
			// Resetleme işlemleri
			SolutionSteps = string.Empty;

			// Eğer ForceFunction atanmışsa 2. Modu (İntegral) çalıştır
			if (ForceFunction != null)
			{
				CalculateVariableForceWork();
			}
			else // Atanmamışsa standart 1. Modu (Enerjinin Korunumu) çalıştır
			{
				CalculateEnergyConservation();
			}
		}

		// ==========================================
		// 1. MOD: Mekanik Enerjinin Korunumu Hesabı
		// ==========================================
		private void CalculateEnergyConservation()
		{
			double g = Gravity;
			double initialKinetic = 0.5 * Mass * Math.Pow(InitialVelocity, 2);
			double initialPotential = Mass * g * FirstHeight;
			double totalEnergy = initialKinetic + initialPotential;

			double finalPotential = Mass * g * FinalHeight;
			double finalKinetic = totalEnergy - finalPotential;

			// Fiziksel sınır kontrolü (Cisim o yüksekliğe çıkabilir mi?)
			if (finalKinetic < 0)
			{
				throw new InvalidOperationException("Hata: Cismin başlangıçtaki toplam enerjisi, hedef yüksekliğe çıkmak için yetersiz!");
			}

			double finalVelocity = Math.Sqrt((2 * finalKinetic) / Mass);
			CalculatedWork = initialPotential - finalPotential; // Yerçekiminin yaptığı iş

			// Çözüm adımları
			SolutionSteps = "--- ENERJİNİN KORUNUMU ADIMLARI ---\n\n";
			SolutionSteps += "1. Adım: İlk Durumdaki Enerjilerin Hesabı\n";
			SolutionSteps += $"   İlk Kinetik Enerji (Ek1) = 0.5 * m * v1² = 0.5 * {Mass} * {InitialVelocity}² = {initialKinetic.ToString("F2")} Joule\n";
			SolutionSteps += $"   İlk Potansiyel Enerji (Ep1) = m * g * h1 = {Mass} * {g} * {FirstHeight} = {initialPotential.ToString("F2")} Joule\n";
			SolutionSteps += $"   Toplam Mekanik Enerji (E_toplam) = {totalEnergy.ToString("F2")} Joule\n\n";

			SolutionSteps += "2. Adım: Hedef Noktadaki Enerjilerin Hesabı\n";
			SolutionSteps += $"   Son Potansiyel Enerji (Ep2) = m * g * h2 = {Mass} * {g} * {FinalHeight} = {finalPotential.ToString("F2")} Joule\n";
			SolutionSteps += $"   Son Kinetik Enerji (Ek2) = E_toplam - Ep2 = {finalKinetic.ToString("F2")} Joule\n\n";

			SolutionSteps += "3. Adım: Son Hız ve Yapılan İş\n";
			SolutionSteps += $"   Son Hız (v2) = √(2 * Ek2 / m) = {finalVelocity.ToString("F2")} m/s\n";
			SolutionSteps += $"   Yerçekimi Kuvvetinin Yaptığı İş (W) = Ep1 - Ep2 = {CalculatedWork.ToString("F2")} Joule\n";

			// GRAFİK VERİLERİ (Yükseklik değişimine göre Enerji Grafiği)
			int points = 100;
			ChartX = new double[points];
			ChartY_Kinetic = new double[points];
			ChartY_Potential = new double[points];
			ChartY_Total = new double[points];

			double step = (FinalHeight - FirstHeight) / (points - 1);
			for (int i = 0; i < points; i++)
			{
				double currentH = FirstHeight + (i * step);
				ChartX[i] = currentH;
				ChartY_Potential[i] = Mass * g * currentH;
				ChartY_Kinetic[i] = totalEnergy - ChartY_Potential[i];
				ChartY_Total[i] = totalEnergy;
			}
		}

		// ==========================================
		// 2. MOD: Değişken Kuvvet (Sayısal İntegral) Hesabı
		// ==========================================
		private void CalculateVariableForceWork()
		{
			// Eğer kuvvet fonksiyonu (MathParser) devreye girdiyse
			if (ForceFunction != null)
			{
				int noktaSayisi = 1000;
				double step = (EndX - StartX) / (noktaSayisi - 1); // 1000 parçaya bölüyoruz
				double totalWork = 0;

				// Grafiğe gidecek X ve Y dizilerini TERTEMİZ sıfırdan oluşturuyoruz
				ChartX = new double[noktaSayisi];
				ChartY_Total = new double[noktaSayisi];

				for (int i = 0; i < noktaSayisi; i++)
				{
					// 1. O anki X konumunu bul
					double currentX = StartX + (i * step);

					// 2. MathParser'a bu X değerini yollayıp Y (Kuvvet) değerini al
					double currentForce = ForceFunction(currentX);

					// 3. Değerleri grafikte çizilmesi için dizilere kaydet
					ChartX[i] = currentX;
					ChartY_Total[i] = currentForce;

					// 4. Riemann / Trapezoidal toplam ile İntegral (İş) alanını biriktir
					totalWork += currentForce * step;
				}

				// Döngü bitince Raporu Hazırla (Senin o harika çıktı metnin)
				SolutionSteps = "--- DEĞİŞKEN KUVVETİN YAPTIĞI İŞ ---\n" +
								"1. Adım: İntegral Tanımı\n" +
								"Yapılan iş, Kuvvet-Konum grafiğinin altında kalan alandır.\n" +
								$"W = ∫ F(x) dx | Sınırlar: [{StartX}m , {EndX}m]\n\n" +
								"2. Adım: Sayısal İntegral (Trapezoidal) Analizi\n" +
								"Fonksiyon girilen sınırlar arasında 1000 eşit parçaya bölünerek entegre edildi.\n\n" +
								$"Hesaplanan Net İş (W) = {Math.Round(totalWork, 4)} Joule";
			}
		}

		public override void Reset()
		{
			InitialVelocity = 0;
			FirstHeight = 0;
			FinalHeight = 0;
			Mass = 0;
			StartX = 0;
			EndX = 0;
			ForceFunction = null;
			CalculatedWork = 0;
			SolutionSteps = string.Empty;
			ChartX = null;
			ChartY_Kinetic = null;
			ChartY_Potential = null;
			ChartY_Total = null;
		}
	}
}