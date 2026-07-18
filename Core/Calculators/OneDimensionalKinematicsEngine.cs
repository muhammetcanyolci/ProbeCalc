using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcUni.Core.Base;

namespace CalcUni.Core.Calculators
{
	/// <summary>
	/// 1 Boyutlu Kinematik (Doğrusal Hareket) hesaplamalarını yapan motor sınıfı.
	/// </summary>
	public class OneDimensionalKinematicsEngine : MechanicsEngine
	{
		// 1. KULLANICIDAN ALINACAK YENİ GİRDİLER
		public double Acceleration { get; set; } // İvme (a)
		public double TotalTime { get; set; }    // Toplam Hareket Süresi (t)

		// 2. TEMEL ÇIKTILAR
		public double FinalVelocity { get; private set; } // Son Hız
		public double Displacement { get; private set; }  // Yer Değiştirme (Konum)

		// 3. EĞİTİM MODÜLÜ ÇIKTISI
		public string SolutionSteps { get; private set; }

		// 4. GRAFİK İÇİN KOORDİNAT DİZİLERİ (Hem Konum hem Hız grafiği çizebilelim diye)
		public double[] TimePoints { get; private set; }
		public double[] PositionPoints { get; private set; }
		public double[] VelocityPoints { get; private set; }

		public override void Calculate()
		{
			// --- TEMEL HESAPLAMALAR ---
			FinalVelocity = InitialVelocity + (Acceleration * TotalTime);
			Displacement = (InitialVelocity * TotalTime) + (0.5 * Acceleration * Math.Pow(TotalTime, 2));

			// --- ADIM ADIM ÇÖZÜM RAPORUNUN HAZIRLANMASI ---
			SolutionSteps = "--- 1D KİNEMATİK HESAPLAMA ADIMLARI ---\n\n";

			SolutionSteps += "1. Adım: Son Hızın Bulunması (Hız - Zaman Denklemi)\n";
			SolutionSteps += "   Kullanılan Formül: Vf = V0 + (a * t)\n";
			SolutionSteps += $"   İşlem: {InitialVelocity} + ({Acceleration} * {TotalTime}) = {FinalVelocity.ToString("F2")} m/s\n\n";

			SolutionSteps += "2. Adım: Yer Değiştirmenin (Konum) Bulunması (Konum Denklemi)\n";
			SolutionSteps += "   Kullanılan Formül: Δx = (V0 * t) + (0.5 * a * t²)\n";
			SolutionSteps += $"   İşlem: ({InitialVelocity} * {TotalTime}) + (0.5 * {Acceleration} * {Math.Pow(TotalTime, 2)}) = {Displacement.ToString("F2")} metre\n";

			SolutionSteps += "\n--------------------------------------------------\n";
			SolutionSteps += "🎯 ÖZET SONUÇLAR:\n";
			SolutionSteps += $"   Son Hız (Vf)    : {FinalVelocity.ToString("F2")} m/s\n";
			SolutionSteps += $"   Yer Değiştirme  : {Displacement.ToString("F2")} metre\n";

			// --- GRAFİK İÇİN VERİLERİN ÜRETİLMESİ ---
			int pointCount = 100;
			TimePoints = new double[pointCount];
			PositionPoints = new double[pointCount];
			VelocityPoints = new double[pointCount];

			double timeStep = TotalTime / (pointCount - 1);

			for (int i = 0; i < pointCount; i++)
			{
				double t = i * timeStep;
				TimePoints[i] = t; // X ekseni her zaman 'Zaman' olacak
				PositionPoints[i] = (InitialVelocity * t) + (0.5 * Acceleration * Math.Pow(t, 2)); // Konum
				VelocityPoints[i] = InitialVelocity + (Acceleration * t); // Hız
			}
		}

		public override void Reset()
		{
			InitialVelocity = 0;
			Acceleration = 0;
			TotalTime = 0;
			FinalVelocity = 0;
			Displacement = 0;
			SolutionSteps = string.Empty;

			TimePoints = null;
			PositionPoints = null;
			VelocityPoints = null;
		}
	}
}