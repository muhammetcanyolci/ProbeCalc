using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics.Integration;
using ProbeCalc.Core.Base;

namespace ProbeCalc.Core.Calculators
{
	public enum CapacitancePermittivity
	{
		Vacuum,
		Water,
		Glass,
		Paper,
		Teflon
	}

	/// <summary>
	/// Paralel Plaka Kapasitör (Capacitance) hesaplamalarını yapan somut motor
	/// sınıfı. ElectricalEngine'den miras alır; plakalar arası mesafe için
	/// Distance, biriken yük için (Q=CV formülüyle) Charge property'leri
	/// ata sınıftan geliyor.
	/// </summary>
	public class CapacitanceEngine : ElectricalEngine
	{
		// ====================================================================
		// Malzemelerin BAĞIL dielektrik sabitleri (K / epsilon_r) — birimsiz.
		// Gerçek epsilon = VacuumPermittivity * (bu bağıl değer).
		// Kaynak: genel fizik ders kitaplarındaki yaklaşık oda sıcaklığı değerleri.
		// ====================================================================
		private const double RelativePermittivity_Water = 80.1;
		private const double RelativePermittivity_Glass = 7.0;
		private const double RelativePermittivity_Paper = 3.5;
		private const double RelativePermittivity_Teflon = 2.1;

		// 1. GİRDİLER (INPUTS)

		// Plaka alanı (A) - m². Sıfır veya negatif olamaz (kapasitans tanımsızlaşır).
		private double _area;
		public double Area
		{
			get => _area;
			set
			{
				if (value <= 0)
				{
					ThrowIfNegativeOrZero(nameof(Area), "Plaka alanı (A)");
				}
				_area = value;
			}
		}

		// Uygulanan gerilim (V) - Volt.
		public double Voltage { get; set; }

		// Plakalar arasındaki dielektrik malzeme seçimi.
		public CapacitancePermittivity Permittivity { get; set; } = CapacitancePermittivity.Vacuum;

		// Distance (plakalar arası mesafe d) -> ElectricalEngine'den miras (>0 kontrolü orada)
		// Charge (biriken yük Q, Q=C*V ile hesaplanır) -> ElectricalEngine'den miras

		// 2. ÇIKTILAR (OUTPUTS)
		public double Capacitance { get; private set; }   // C, Farad
		public double Epsilon { get; private set; }       // Kullanılan dielektrik geçirgenlik, F/m
		public double ElectricField { get; private set; } // E, N/C (V/m)
		public double Energy { get; private set; }         // U, Joule

		// 4. HESAPLAMA MANTIĞI (CALCULATE)
		public override void Calculate()
		{
			// Seçilen malzemeye göre dielektrik geçirgenliği (epsilon) belirle
			double relativePermittivity = GetRelativePermittivity(Permittivity);
			Epsilon = VacuumPermittivity * relativePermittivity;

			// 1. Kapasitans: C = epsilon * A / d
			Capacitance = Epsilon * Area / Distance;

			// 2. Biriken Yük: Q = C * V  (Charge, ElectricalEngine'den miras)
			Charge = Capacitance * Voltage;

			// 3. Elektrik Alan: E = V / d
			ElectricField = Voltage / Distance;

			// 4. Depolanan Enerji: U = 0.5 * C * V²
			Energy = 0.5 * Capacitance * Math.Pow(Voltage, 2);

			// ADIM ADIM ÇÖZÜM RAPORUNUN HAZIRLANMASI
			SolutionSteps = "--- ARKA PLAN HESAPLAMA ADIMLARI ---\n\n";

			SolutionSteps += "1. Adım: Dielektrik Geçirgenliğin Belirlenmesi\n";
			SolutionSteps += $"   Seçilen Malzeme: {Permittivity}  (Bağıl Geçirgenlik εᵣ = {relativePermittivity:F2})\n";
			SolutionSteps += $"   ε = ε₀ * εᵣ = {VacuumPermittivity:E3} * {relativePermittivity:F2} = {Epsilon:E4} F/m\n\n";

			SolutionSteps += "2. Adım: Kapasitans (C) Hesabı\n";
			SolutionSteps += "   Kullanılan Formül: C = ε * A / d\n";
			SolutionSteps += $"   İşlem: {Epsilon:E3} * {Area:F4} / {Distance:F4} = {Capacitance:E4} Farad\n\n";

			SolutionSteps += "3. Adım: Biriken Yük (Q) Hesabı\n";
			SolutionSteps += "   Kullanılan Formül: Q = C * V\n";
			SolutionSteps += $"   İşlem: {Capacitance:E3} * {Voltage:F2} = {Charge:E4} Coulomb\n\n";

			SolutionSteps += "4. Adım: Elektrik Alan (E) Hesabı\n";
			SolutionSteps += "   Kullanılan Formül: E = V / d\n";
			SolutionSteps += $"   İşlem: {Voltage:F2} / {Distance:F4} = {ElectricField:E4} N/C\n\n";

			SolutionSteps += "5. Adım: Depolanan Enerji (U) Hesabı\n";
			SolutionSteps += "   Kullanılan Formül: U = 0.5 * C * V²\n";
			SolutionSteps += $"   İşlem: 0.5 * {Capacitance:E3} * {Voltage:F2}² = {Energy:E4} Joule\n";

			SolutionSteps += "\n--------------------------------------------------\n";
			SolutionSteps += "🎯 ÖZET SONUÇLAR:\n";
			SolutionSteps += $"   Kapasitans (C) : {Capacitance:E4} F\n";
			SolutionSteps += $"   Yük (Q)        : {Charge:E4} C\n";
			SolutionSteps += $"   Elektrik Alan  : {ElectricField:E4} N/C\n";
			SolutionSteps += $"   Enerji (U)     : {Energy:E4} J\n";

			
		}

		private static double GetRelativePermittivity(CapacitancePermittivity type)
		{
			switch (type)
			{
				case CapacitancePermittivity.Water: return RelativePermittivity_Water;
				case CapacitancePermittivity.Glass: return RelativePermittivity_Glass;
				case CapacitancePermittivity.Paper: return RelativePermittivity_Paper;
				case CapacitancePermittivity.Teflon: return RelativePermittivity_Teflon;
				default: return 1.0; // Vacuum -> bağıl geçirgenlik tanımı gereği 1
			}
		}

		protected override string GetShortResultText()
		{
			return $" Kapasitans (C) : {Capacitance:E4} F\n" +
				   $" Yük (Q)        : {Charge:E4} C\n" +
				   $" Enerji (U)     : {Energy:E4} J\n" +
				  $"   Elektrik Alan  : {ElectricField:E4} N/C\n";
		}

		public override void Reset()
		{
			base.Reset(); // Distance, Charge, SolutionSteps sıfırlanır (ElectricalEngine'den)

			_area = 0;
			Voltage = 0;
			Permittivity = CapacitancePermittivity.Vacuum;

			Capacitance = 0;
			Epsilon = 0;
			ElectricField = 0;
			Energy = 0;

		}
	}
}
