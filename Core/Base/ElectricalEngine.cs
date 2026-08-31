using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbeCalc.Core.Base
{
	public abstract class ElectricalEngine: PhysicsEngine
	{ // 1. FİZİKSEL SABİTLER
		// Coulomb sabiti k = 1 / (4 * pi * epsilon0)  [N*m^2 / C^2]
		protected const double CoulombConstant = 8.9875517923e9;
		// Boşluğun elektriksel geçirgenliği (epsilon0) [F/m]
		protected const double VacuumPermittivity = 8.8541878128e-12;

		// 2. ORTAK GİRDİ (INPUT)
		// Elektrik alanından etkilenen / elektrik alanı üreten yük.
		// Not: Kütle veya hız gibi büyüklüklerin aksine yükün işareti (+/-) fiziksel
		// olarak anlamlıdır (kuvvetin yönünü belirler), bu yüzden IsInputPositive
		// kontrolüne burada tabi TUTULMAZ; alt sınıflar gerekirse kendi girdilerine
		// (genlik, frekans vb.) bu kontrolü uygular.
		public double Charge { get; set; }

		/// <summary>
		/// Ata sınıftaki ortak elektriksel girdiyi (Charge) ve çözüm metnini sıfırlar.
		/// MechanicsEngine.Reset() ile aynı seviyede, ilk somut Reset() implementasyonudur.
		/// </summary>
		/// 
		// İki nokta yük (ya da yük-gözlem noktası) arasındaki mesafe (r), metre.
		// Coulomb Yasası r=0 noktasında tanımsız olduğu için MechanicsEngine'deki
		// "negatif olamaz" kontrolünün ötesinde, burada "sıfır da olamaz" kontrolü var.
		private double _distance;

		// 3. ORTAK YARDIMCI METOT
		/// <summary>
		/// MechanicsEngine'deki IsInputPositive'in elektrik karşılığı.
		/// Yükler (charge) negatif olabildiği için "pozitif mi" değil,
		/// "sıfır değil mi" kontrolü yapılır — sıfır yük fiziksel olarak anlamsızdır.
		/// </summary>
		protected bool IsChargeNonZero(double charge) => charge != 0;
		
		public double Distance
		{
			get => _distance;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException(nameof(Distance),
						"Mesafe (r) sıfırdan büyük olmalıdır. Coulomb Yasası r=0 noktasında tanımsızdır.");
				}
				_distance = value;
			}
		}
		public override void Reset()
		{
			Charge = 0;
			SolutionSteps = string.Empty;

			// Bu sınıfa özel ortak girdiyi sıfırla
			_distance = 0;
		}

	}
}
