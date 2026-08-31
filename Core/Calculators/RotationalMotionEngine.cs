using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProbeCalc.Core.Base;

namespace ProbeCalc.Core.Calculators
{
	public enum RotorGeometryType
	{
		SolidCylinderOrDisk, // İçi Dolu Silindir / Disk
		HoopOrRing,          // Çember / Halka
		Sphere               // Küre
	}
	public class RotationalMotionEngine :MechanicsEngine
	{
		// 1. Kullanıcı Girdileri

		public RotorGeometryType GeometryType { get; set; } = RotorGeometryType.SolidCylinderOrDisk;

		public double Radius { get; set; }          // Yarıçap (r) [m]
		public double AppliedForce { get; set; }    // Teğetsel Kuvvet (F) [N]
	    
		public double DragCoefficient { get; set; } = 0.0; // Aerodinamik Sürtünme Katsayısı (Cd)

		// 2. Çıktılar
		public double MomentOfInertia { get; private set; } // Eylemsizlik Momenti (kg.m^2)
		public double FinalAngularVelocity { get; private set; } // Son Açısal Hız (rad/s)
		public double FinalRPM { get; private set; } // Devir/Dakika
		public double FinalKineticEnergy { get; private set; } // Depolanan Enerji (Joule)
		public double TotalRevolutions { get; private set; } // Atılan Tur Sayısı

		// 3. Telemetri (Çift Eksenli) Grafiği Dizileri
		public double[] ChartX_Time { get; private set; }
		public double[] ChartY_RPM { get; private set; }
		public double[] ChartY_Energy { get; private set; }

		public override void Reset()
		{
			base.Reset();
			Radius = 0; AppliedForce = 0; TimeLimit = 0; DragCoefficient = 0;
			MomentOfInertia = 0; FinalAngularVelocity = 0; FinalRPM = 0;
			FinalKineticEnergy = 0; TotalRevolutions = 0;
			ChartX_Time = null; ChartY_RPM = null; ChartY_Energy = null;
		}

		public override void Calculate()
		{
			string iFormula = "";
			switch (GeometryType)
			{
				case RotorGeometryType.HoopOrRing:
					MomentOfInertia = Mass * Math.Pow(Radius, 2);
					iFormula = "I = m * r²";
					break;
				case RotorGeometryType.Sphere:
					MomentOfInertia = (2.0 / 5.0) * Mass * Math.Pow(Radius, 2);
					iFormula = "I = (2/5) * m * r²";
					break;
				case RotorGeometryType.SolidCylinderOrDisk:
				default:
					MomentOfInertia = 0.5 * Mass * Math.Pow(Radius, 2);
					iFormula = "I = (1/2) * m * r²";
					break;
			}

			// 2. Euler Sayısal İntegrasyonu (Gerçekçi Rotor Simülasyonu)
			double currentOmega = 0;
			double currentEnergy = 0;
			double currentTheta = 0;
			double stepSize = 0.01; // Saniyenin yüzde biri hassasiyetle hesapla

			List<double> timeList = new List<double>();
			List<double> rpmList = new List<double>();
			List<double> energyList = new List<double>();

			for (double t = 0; t <= TimeLimit; t += stepSize)
			{
				// Aerodinamik Sürtünme Torku (T_drag = Cd * w^2)
				double dragTorque = DragCoefficient * Math.Pow(currentOmega, 2);

				// Motorun Ürettiği Tork (Sabit)
				double motorTorque = AppliedForce * Radius;

				// Net Tork ve İvmelenme
				double netTorque = motorTorque - dragTorque;

				// Sürtünme motoru yenerse, ivmelenme durur ve terminal hıza kilitlenir
				if (netTorque < 0) netTorque = 0;

				double alpha = netTorque / MomentOfInertia;

				// İntegraller (Hız, Konum ve Enerji)
				currentOmega += alpha * stepSize;
				currentTheta += currentOmega * stepSize;
				currentEnergy = 0.5 * MomentOfInertia * Math.Pow(currentOmega, 2);

				// Grafik için dizilere kayıt
				timeList.Add(t);
				rpmList.Add(currentOmega * (60.0 / (2 * Math.PI))); // rad/s -> RPM Dönüşümü
				energyList.Add(currentEnergy);
			}

			// Nihai Değerleri Özelliklere Kaydet
			FinalAngularVelocity = currentOmega;
			FinalRPM = rpmList.Last();
			FinalKineticEnergy = currentEnergy;
			TotalRevolutions = currentTheta / (2 * Math.PI);

			ChartX_Time = timeList.ToArray();
			ChartY_RPM = rpmList.ToArray();
			ChartY_Energy = energyList.ToArray();

			// 3. Kullanıcıya Gösterilecek Türkçe Telemetri Raporu ve Formüller
			StringBuilder steps = new StringBuilder();
			steps.AppendLine("========================================================");
			steps.AppendLine("        ✈️ ROTOR VE AERODİNAMİK ANALİZİ ✈️       ");
			steps.AppendLine("========================================================");
			steps.AppendLine();

			steps.AppendLine("[1] KULLANILAN FİZİK FORMÜLLERİ");
			steps.AppendLine($"-> Eylemsizlik Momenti : {iFormula}");
			steps.AppendLine($"-> Üretilen Motor Torku: τ_motor = F_teğet * r");
			if (DragCoefficient > 0)
				steps.AppendLine($"-> Aerodinamik Sürtünme: τ_sürtünme = Cd * ω²");
			steps.AppendLine($"-> Açısal İvme (Euler) : α = (τ_motor - τ_sürtünme) / I");
			steps.AppendLine($"-> Kinetik Enerji      : E_k = (1/2) * I * ω²");
			steps.AppendLine();

			steps.AppendLine("[2] YAPISAL VE GEOMETRİK VERİLER");
			steps.AppendLine($"-> Seçilen Rotor Tipi    : {GeometryType}");
			steps.AppendLine($"-> Eylemsizlik Momenti(I): {MomentOfInertia:F3} kg.m²");
			steps.AppendLine($"-> Üretilen Tork (τ)     : {(AppliedForce * Radius):F2} N.m");
			if (DragCoefficient > 0)
				steps.AppendLine($"-> Atmosferik Sürtünme   : Aktif (Cd = {DragCoefficient})");
			else
				steps.AppendLine($"-> Atmosferik Sürtünme   : İdeal Ortam (Uzay Boşluğu)");

			steps.AppendLine();
			steps.AppendLine("[3] KİNEMATİK TELEMETRİ SONUÇLARI");
			steps.AppendLine($"-> Ulaşılan Maksimum Devir: {FinalRPM:F0} RPM");
			steps.AppendLine($"-> Son Açısal Hız (ω)     : {FinalAngularVelocity:F2} rad/s");
			steps.AppendLine($"-> Toplam Atılan Tur      : {TotalRevolutions:F1} tur");

			steps.AppendLine();
			steps.AppendLine("[4] ENERJİ VERİLERİ");
			steps.AppendLine($"-> Sistemde Depolanan Enerji: {FinalKineticEnergy:F2} Joule");

			SolutionSteps = steps.ToString();
		}

		protected override string GetShortResultText()
		{
			return $"{GeometryType} | Tork: {(AppliedForce * Radius):F1} N.m | Maks Devir: {FinalRPM:F0} | Enerji: {FinalKineticEnergy:F0} J";
		}
	}

}
