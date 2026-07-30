using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ProbeCalc.Core.Base;

namespace ProbeCalc.Core.Calculators
{
	internal class SimplePendulumEngine: MechanicsEngine
	{// --- KULLANICIDAN ALINACAK VERİLER ---
		public double Amplitude { get; set; } // Genlik (Radyan)
		public double DampingCoefficient { get; set; } // Sönüm Katsayısı (b)
		public double Length { get; set; } // İp Uzunluğu (L)


		// --- HESAPLANACAK SONUÇLAR ---
		public double AngularFrequency { get; private set; }
		public double Period { get; private set; }
		public double FinalAmplitude { get; private set; }

		// --- ENERJİ VERİLERİ ---
		public double InitialEnergy { get; private set; }
		public double FinalEnergy { get; private set; }
		public double LostEnergy { get; private set; }
		// --- GRAFİK VERİLERİ ---
		public double[] ChartX_Time { get; private set; }
		public double[] ChartY_Position { get; private set; }
		public override void Calculate()
		{
			if (Length <= 0)
				throw new InvalidOperationException("Hata: İp uzunluğu sıfır veya negatif olamaz.");

			// Enerji ve sönüm hesabında Mass gerektiği için onun da kontrolü şart
			if (Mass <= 0)
				throw new InvalidOperationException("Hata: Kütle sıfır veya negatif olamaz. Sistem durduruldu.");

			AngularFrequency = Math.Sqrt(Gravity / Length);

			// Başlangıç açısı (radyan) üzerinden potansiyel enerji değişimi: E = m*g*L*(1 - cos(theta))
			InitialEnergy = Mass * Gravity * Length * (1 - Math.Cos(Amplitude));

			// Sönüm etkisiyle azalan açı genliği
			FinalAmplitude = Amplitude * Math.Exp(-DampingCoefficient * TimeLimit / (2 * Mass));
			FinalEnergy = Mass * Gravity * Length * (1 - Math.Cos(FinalAmplitude));

			Period = 2 * Math.PI / AngularFrequency;
			LostEnergy = InitialEnergy - FinalEnergy;

			// --- GRAFİK İÇİN ZAMAN-KONUM SİMÜLASYONU ---
			List<double> timePoints = new List<double>();
			List<double> positionPoints = new List<double>();

			// Eğrinin pürüzsüz görünmesi için süreyi 500 hassas adıma bölüyoruz
			double stepSize = TimeLimit / 500.0;
			if (stepSize <= 0) stepSize = 0.01; // Güvenlik önlemi

			for (double t = 0; t <= TimeLimit; t += stepSize)
			{
				timePoints.Add(t);

				// x(t) = A * e^(-bt/2m) * cos(w*t)
				double currentPos = Amplitude * Math.Exp(-DampingCoefficient * t / (2 * Mass)) * Math.Cos(AngularFrequency * t);

				positionPoints.Add(currentPos);
			}

			ChartX_Time = timePoints.ToArray();
			ChartY_Position = positionPoints.ToArray();

			StringBuilder steps = new StringBuilder();

			steps.AppendLine("--- BASİT SARKAÇ SİSTEMİ ANALİZİ ---");
			steps.AppendLine("");

			steps.AppendLine("[ Kullanılan Temel Formüller ]");
			steps.AppendLine("-> Açısal Frekans : ω = √(g / L)");
			steps.AppendLine("-> Sistem Periyodu: T = 2π / ω");
			steps.AppendLine("-> Toplam Enerji  : E = m * g * L * (1 - cos(θ))");
			if (DampingCoefficient > 0)
				steps.AppendLine("-> Sönüm Genliği  : θ(t) = θ₀ * e^(-bt / 2m)");

			steps.AppendLine("");
			steps.AppendLine("[ Sonuçlar ve Enerji Analizi ]");
			steps.AppendLine($"-> Açısal Frekans (ω): {AngularFrequency:F3} rad/s");
			steps.AppendLine($"-> Periyot (T): {Period:F3} saniye");
			steps.AppendLine($"-> Frekans (f): {(1 / Period):F3} Hz");

			steps.AppendLine("");
			if (DampingCoefficient > 0)
			{
				steps.AppendLine($"-> Başlangıç Enerjisi: {InitialEnergy:F2} Joule");
				steps.AppendLine($"-> Kalan Son Genlik (Açı): {FinalAmplitude:F3} rad");
				steps.AppendLine($"-> Kalan Son Enerji: {FinalEnergy:F2} Joule");
				steps.AppendLine($"-> Kayıp Enerji (Isıya Dönüşen): {LostEnergy:F2} Joule");
			}
			else
			{
				steps.AppendLine($"-> Sönümleme yok (b = 0). Toplam Enerji ({InitialEnergy:F2} Joule) korunuyor.");
			}

			SolutionSteps = steps.ToString();
		}

		public override void Reset()
		{
			base.Reset();
			Amplitude = 0;
			DampingCoefficient = 0;
			Length = 0;
			
			AngularFrequency = 0;
			Period = 0;
			FinalAmplitude = 0;
			InitialEnergy = 0;
			FinalEnergy = 0;
			LostEnergy = 0;
			ChartX_Time = null;
			ChartY_Position = null;

		}

		protected override string GetShortResultText()
		{
			double freqHz = 1 / Period;
			if (DampingCoefficient > 0)
				return $"[Sarkaç] f: {freqHz:F2} Hz | ω: {AngularFrequency:F2} rad/s | Kalan Açı: {FinalAmplitude:F3} rad";
			else
				return $"[Sarkaç] f: {freqHz:F2} Hz | ω: {AngularFrequency:F2} rad/s | T: {Period:F2} s (Sönümsüz)";
		}
	}
}

