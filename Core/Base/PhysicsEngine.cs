using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcUni.Core.Interfaces;

namespace CalcUni.Core.Base
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
	
	}
	
}
