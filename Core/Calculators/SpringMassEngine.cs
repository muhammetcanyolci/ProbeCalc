using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProbeCalc.Core.Base;
namespace ProbeCalc.Core.Calculators
{
	public class SpringMassEngine : MechanicsEngine
	{// --- KULLANICIDAN ALINACAK VERİLER ---
		public double Amplitude { get; set; } // Genlik (m)
		public double DampingCoefficient { get; set; } // Sönüm Katsayısı (b)
		private double _springConstant;
		public double SpringConstant
		{
			get => _springConstant;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(SpringConstant), "Hata: Yay sabiti (k) sıfır veya negatif olamaz.");
				_springConstant = value;
			}
		}

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
			if (Mass <= 0)
				throw new InvalidOperationException("Hata: Kütle sıfır veya negatif olamaz. Sistem durduruldu.");

			AngularFrequency = Math.Sqrt(SpringConstant / Mass);

			InitialEnergy = 0.5 * SpringConstant * Math.Pow(Amplitude, 2);
			FinalAmplitude = Amplitude * Math.Exp(-DampingCoefficient * TimeLimit / (2 * Mass));
			FinalEnergy = 0.5 * SpringConstant * Math.Pow(FinalAmplitude, 2);

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

			steps.AppendLine("--- YAY-KÜTLE SİSTEMİ ANALİZİ ---");
			steps.AppendLine("");

			steps.AppendLine("[ Kullanılan Temel Formüller ]");
			steps.AppendLine("-> Açısal Frekans : ω = √(k / m)");
			steps.AppendLine("-> Sistem Periyodu: T = 2π / ω");
			steps.AppendLine("-> Toplam Enerji  : E = (1/2) * k * A²");
			if (DampingCoefficient > 0)
				steps.AppendLine("-> Sönüm Genliği  : A(t) = A₀ * e^(-bt / 2m)");

			steps.AppendLine("");
			steps.AppendLine("[ Sonuçlar ve Enerji Analizi ]");
			steps.AppendLine($"-> Açısal Frekans (ω): {AngularFrequency:F3} rad/s");
			steps.AppendLine($"-> Periyot (T): {Period:F3} saniye");
			steps.AppendLine($"-> Frekans (f): {(1 / Period):F3} Hz");

			steps.AppendLine("");
			if (DampingCoefficient > 0)
			{
				steps.AppendLine($"-> Başlangıç Enerjisi: {InitialEnergy:F2} Joule");
				steps.AppendLine($"-> Kalan Son Genlik: {FinalAmplitude:F3} m");
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
			SpringConstant = 0;
			AngularFrequency = 0;
			Period = 0;
			FinalAmplitude = 0;
			InitialEnergy = 0;
			FinalEnergy = 0;
			LostEnergy = 0;
			ChartY_Position = null;
			ChartX_Time = null;
		}

		protected override string GetShortResultText()
		{
			double freqHz = 1 / Period;
			if (DampingCoefficient > 0)
				return $"[Yay] f: {freqHz:F2} Hz | ω: {AngularFrequency:F2} rad/s | Kalan Genlik: {FinalAmplitude:F3} m";
			else
				return $"[Yay] f: {freqHz:F2} Hz | ω: {AngularFrequency:F2} rad/s | T: {Period:F2} s (Sönümsüz)";
		}
	}

}
