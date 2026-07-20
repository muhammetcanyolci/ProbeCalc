using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProbeCalc.Core.Interfaces;

namespace ProbeCalc.Core.Base
{   public abstract class PhysicsEngine: IEngine
	{
	// IEngine nin kontrat methodları ( implemented members)
		public abstract void Calculate();
		public abstract void Reset();

		// Evrensel sabitler 
		protected const double Gravity = 9.80665 ;


		///<summary>
		/// Girilen sayısal değerin fiziksel olarak anlamlı (sıfır veya pozitif) olup olmadığını denetler.
		///</summary>
		////// <param name="value">Kontrol edilecek fiziksel girdi (Hız, kütle, zaman vb.)</param>
		/// <returns>Değer sıfırdan büyük veya eşitse true, negatifse false döner.</returns>
		protected bool IsInputPositive ( double value)
		{ return value >= 0; }

		// açıyı radyana dönüştürme 
		protected double DegreesToRadian( double degrees)
		{ return degrees * (Math.PI / 180.0); }
		// Her motorda ortak olan uzun çözüm metni
		
		
		
		
		public string SolutionSteps { get; protected set; }

		// Alt sınıflar kendi kısa sonucunu vermek zorunda
		protected abstract string GetShortResultText();

		// cheked ise çözüm adımlarını gösterecek.
		public string GetFinalReport(bool showDetailedSteps)
		{
			if (showDetailedSteps)
			{
				return SolutionSteps;
			}
			else
			{
				return GetShortResultText(); // Hangi motordaysak (İş, Hız vb.) onun kısa sonucunu çağırır.
			}
		}

	}
	
}
