using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProbeCalc.Core.Base;

namespace ProbeCalc.Core.Calculators
{
	public class CollisionEngine : PhysicsEngine
	{

		// 1. Girdiler: Kütleler ve Hız Vektörleri (X ve Y bileşenleri)
		public double Mass1 { get; set; }
		public double Vel1_X { get; set; }
		public double Vel1_Y { get; set; }

		public double Mass2 { get; set; }
		public double Vel2_X { get; set; }
		public double Vel2_Y { get; set; }

		public double Restitution { get; set; } = 1.0;

		// 2. Çıktılar: Son Hız Vektörleri
		public double FinalVel1_X { get; private set; }
		public double FinalVel1_Y { get; private set; }

		public double FinalVel2_X { get; private set; }
		public double FinalVel2_Y { get; private set; }

		public double EnergyLoss { get; private set; }

		// 3. Görselleştirme Dizileri (Kuş Bakışı X-Y Koordinatları)
		public double[] ChartPos_X1 { get; private set; }
		public double[] ChartPos_Y1 { get; private set; }
		public double[] ChartPos_X2 { get; private set; }
		public double[] ChartPos_Y2 { get; private set; }

		public override void Reset()
		{
			
			Mass1 = 0; Vel1_X = 0; Vel1_Y = 0;
			Mass2 = 0; Vel2_X = 0; Vel2_Y = 0;
			Restitution = 1.0;
			FinalVel1_X = 0; FinalVel1_Y = 0; FinalVel2_X = 0; FinalVel2_Y = 0;
			EnergyLoss = 0;
			ChartPos_X1 = null; ChartPos_Y1 = null; ChartPos_X2 = null; ChartPos_Y2 = null;
		}

		public override void Calculate()
		{
			if (Mass1 <= 0 || Mass2 <= 0)
				throw new InvalidOperationException("Hata: Kütle 0 veya negatif olamaz.");
			if (Restitution < 0 || Restitution > 1)
				throw new InvalidOperationException("Hata: Esneklik katsayısı (e) 0 ile 1 arasında olmalıdır.");

			// Çarpışma Normalini (Bağıl Hız Vektörünü) Bulma
			double relVx = Vel1_X - Vel2_X;
			double relVy = Vel1_Y - Vel2_Y;
			double relMag = Math.Sqrt(relVx * relVx + relVy * relVy);

			if (relMag == 0)
			{
				// Cisimler aynı hızda aynı yöne gidiyor, çarpışma yok.
				FinalVel1_X = Vel1_X; FinalVel1_Y = Vel1_Y;
				FinalVel2_X = Vel2_X; FinalVel2_Y = Vel2_Y;
			}
			else
			{
				// Normal Vektör Bileşenleri (nx, ny)
				double nx = relVx / relMag;
				double ny = relVy / relMag;

				// Hızları çarpışma normali üzerine iz düşürme
				double u1 = Vel1_X * nx + Vel1_Y * ny;
				double u2 = Vel2_X * nx + Vel2_Y * ny;

				// Normal doğrultusunda 1 Boyutlu Çarpışma Matematiği
				double totalMass = Mass1 + Mass2;
				double v1n = (Mass1 * u1 + Mass2 * u2 + Mass2 * Restitution * (u2 - u1)) / totalMass;
				double v2n = (Mass1 * u1 + Mass2 * u2 + Mass1 * Restitution * (u1 - u2)) / totalMass;

				// Değişen impuls değerlerini vektörlere geri ekleme
				FinalVel1_X = Vel1_X + (v1n - u1) * nx;
				FinalVel1_Y = Vel1_Y + (v1n - u1) * ny;

				FinalVel2_X = Vel2_X + (v2n - u2) * nx;
				FinalVel2_Y = Vel2_Y + (v2n - u2) * ny;
			}

			// Enerji Hesaplamaları (Skaler Büyüklükler Üzerinden)
			double v1_magSq = Vel1_X * Vel1_X + Vel1_Y * Vel1_Y;
			double v2_magSq = Vel2_X * Vel2_X + Vel2_Y * Vel2_Y;
			double v1f_magSq = FinalVel1_X * FinalVel1_X + FinalVel1_Y * FinalVel1_Y;
			double v2f_magSq = FinalVel2_X * FinalVel2_X + FinalVel2_Y * FinalVel2_Y;

			double initialKinetic = 0.5 * Mass1 * v1_magSq + 0.5 * Mass2 * v2_magSq;
			double finalKinetic = 0.5 * Mass1 * v1f_magSq + 0.5 * Mass2 * v2f_magSq;
			EnergyLoss = initialKinetic - finalKinetic;

			// Kuş Bakışı (X-Y) Görselleştirme Dizilerini Doldurma
			List<double> pX1 = new List<double>(), pY1 = new List<double>();
			List<double> pX2 = new List<double>(), pY2 = new List<double>();

			for (double t = -2.0; t <= 2.0; t += 0.05)
			{
				if (t <= 0) // Çarpışma öncesi (Orijine doğru geliş)
				{
					pX1.Add(Vel1_X * t); pY1.Add(Vel1_Y * t);
					pX2.Add(Vel2_X * t); pY2.Add(Vel2_Y * t);
				}
				else // Çarpışma sonrası (Orijinden dağılış)
				{
					pX1.Add(FinalVel1_X * t); pY1.Add(FinalVel1_Y * t);
					pX2.Add(FinalVel2_X * t); pY2.Add(FinalVel2_Y * t);
				}
			}
			ChartPos_X1 = pX1.ToArray(); ChartPos_Y1 = pY1.ToArray();
			ChartPos_X2 = pX2.ToArray(); ChartPos_Y2 = pY2.ToArray();

			// Raporlama (SolutionSteps)
			StringBuilder steps = new StringBuilder();
			steps.AppendLine("========================================================");
			steps.AppendLine("        🎯 2 BOYUTLU (VEKTÖREL) ÇARPIŞMA ANALİZİ 🎯     ");
			steps.AppendLine("========================================================");
			steps.AppendLine();
			steps.AppendLine("[1] GİRİŞ VEKTÖRLERİ (Başlangıç)");
			steps.AppendLine($"-> 1. Cisim ({Mass1} kg) : V1 = {Vel1_X:F2}i + {Vel1_Y:F2}j m/s");
			steps.AppendLine($"-> 2. Cisim ({Mass2} kg) : V2 = {Vel2_X:F2}i + {Vel2_Y:F2}j m/s");
			steps.AppendLine($"-> İlk Kinetik Enerji    : {initialKinetic:F2} Joule");
			steps.AppendLine();
			steps.AppendLine("[2] ÇIKIŞ VEKTÖRLERİ (Çarpışma Sonrası)");
			steps.AppendLine($"-> 1. Cisim Son Hız (V1'): {FinalVel1_X:F2}i + {FinalVel1_Y:F2}j m/s");
			steps.AppendLine($"-> 2. Cisim Son Hız (V2'): {FinalVel2_X:F2}i + {FinalVel2_Y:F2}j m/s");
			steps.AppendLine();
			steps.AppendLine("[3] FİZİKSEL DOĞRULAMA (Momentum Korunumu)");
			double P_initial_X = (Mass1 * Vel1_X) + (Mass2 * Vel2_X);
			double P_initial_Y = (Mass1 * Vel1_Y) + (Mass2 * Vel2_Y);
			double P_final_X = (Mass1 * FinalVel1_X) + (Mass2 * FinalVel2_X);
			double P_final_Y = (Mass1 * FinalVel1_Y) + (Mass2 * FinalVel2_Y);
			steps.AppendLine($"-> X Ekseni İlk Momentum : {P_initial_X:F2} | Son Momentum : {P_final_X:F2}");
			steps.AppendLine($"-> Y Ekseni İlk Momentum : {P_initial_Y:F2} | Son Momentum : {P_final_Y:F2}");
			steps.AppendLine($"-> Kaybolan Enerji       : {EnergyLoss:F2} Joule");

			SolutionSteps = steps.ToString();
		}

		protected override string GetShortResultText()
		{
			return $"V1': ({FinalVel1_X:F1}i, {FinalVel1_Y:F1}j) | V2': ({FinalVel2_X:F1}i, {FinalVel2_Y:F1}j) | Kayıp: {EnergyLoss:F1} J";
		}
	}


}
