using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProbeCalc.Core.Base;
using ProbeCalc.Core.Utilities;
namespace ProbeCalc.Core.Calculators
{
	public class ImpulseMomentumEngine : MechanicsEngine
	{
		// 1. KURAL UYGULANDI: MathParser içeri gömülmedi, dışarıdan delege (Func) alınıyor.
		public Func<double, double> ForceFunction { get; set; }
		public Func<double, double> MassFunction { get; set; }

	
		public double StepSize { get; set; } = 0.001;

		// 2. KURAL UYGULANDI: Çizimler için standart array çıktıları
		public double[] ChartX { get; private set; }
		public double[] ChartY_Force { get; private set; }
		public double[] ChartY_Velocity { get; private set; }

		public double TotalImpulse { get; private set; }
		public double FinalVelocity { get; private set; }



		public override void Calculate()
		{
			double currentVelocity = InitialVelocity; // MechanicsEngine'den gelir
			double currentImpulse = 0;
			double currentMass = Mass; // MechanicsEngine'den gelir

			// Dinamik listeler (Döngü bitince array'e çevrilecek)
			List<double> tempX = new List<double>();
			List<double> tempForce = new List<double>();
			List<double> tempVelocity = new List<double>();

			for (double t = 0; t <= TimeLimit; t += StepSize)
			{
				// Delege fonksiyonları çağırıyoruz. Eğer fonksiyon girilmemişse (null), kütle sabit kalır, kuvvet 0 olur.
				double currentForce = ForceFunction != null ? ForceFunction(t) : 0;
				currentMass = MassFunction != null ? MassFunction(t) : Mass;


				if (currentMass <= 0)
					throw new InvalidOperationException("Hata: Kütle sıfır veya negatif olamaz.Girdiğiniz fonksiyonda zamanı 0'dan başlatınca kütle sıfır olmakta. Sistem durduruldu.");

				double currentAccel = currentForce / currentMass;

				currentVelocity += currentAccel * StepSize;
				currentImpulse += currentForce * StepSize;

				tempX.Add(t);
				tempForce.Add(currentForce);
				tempVelocity.Add(currentVelocity);
			}

			TotalImpulse = currentImpulse;
			FinalVelocity = currentVelocity;

			// Listeleri dışarıdan ChartEngine'in okuyabileceği standart Array formatına çeviriyoruz
			ChartX = tempX.ToArray();
			ChartY_Force = tempForce.ToArray();
			ChartY_Velocity = tempVelocity.ToArray();

			// 4. KURAL UYGULANDI: Yorumlanmış ve Analitik Sistem Raporu
			StringBuilder steps = new StringBuilder();
			double m0 = MassFunction != null ? MassFunction(0) : Mass;
			double massChangeRate = (currentMass - m0) / TimeLimit; // Saniyedeki kütle değişim hızı
			double avgForce = TotalImpulse / TimeLimit;             // Ortalama kuvvet

			steps.AppendLine("--- DİNAMİK SİSTEM ANALİZİ ---");
			steps.AppendLine();

			steps.AppendLine("[ Kütle Profili ]");
			if (massChangeRate < 0)
				steps.AppendLine($"-> Sistem saniyede ortalama {Math.Abs(massChangeRate):F2} kg kütle/yakıt kaybediyor.");
			else if (massChangeRate > 0)
				steps.AppendLine($"-> Sistem saniyede ortalama {massChangeRate:F2} kg kütle kazanıyor.");
			else
				steps.AppendLine("-> Sistem kütlesi süreç boyunca sabit kaldı.");

			steps.AppendLine();
			steps.AppendLine("[ Kuvvet ve İvmelenme ]");
			steps.AppendLine($"-> Süreç boyunca sisteme etki eden ortalama kuvvet: {avgForce:F2} Newton");
			steps.AppendLine($"-> Ulaşılan anlık maksimum kuvvet: {tempForce.Max():F2} Newton");

			steps.AppendLine();
			steps.AppendLine("[ Sonuç Özeti ]");
			steps.AppendLine($"-> Eğri altında kalan toplam itme (J): {TotalImpulse:F2} N.s");
			steps.AppendLine($"-> Bu itme, sistemin hızını {InitialVelocity:F2} m/s'den {FinalVelocity:F2} m/s'ye çıkardı.");

			SolutionSteps = steps.ToString();
		}
		public override void Reset()
		{
			base.Reset();
			TotalImpulse = 0;
			FinalVelocity = 0;

			ChartX = null;
			ChartY_Force = null;
			ChartY_Velocity = null;

		}
		protected override string GetShortResultText()
		{ return $"Toplam İtme: {TotalImpulse:F2} N.s | Son Hız (vf): {FinalVelocity:F2} m/s"; }
	}
}
