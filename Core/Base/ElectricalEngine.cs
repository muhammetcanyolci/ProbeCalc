using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcUni.Core.Base
{
	public abstract class ElectricalEngine: PhysicsEngine
	{
		// evrensel sabitler
		protected const double EpsilonZero = 8.85418782e-12;// elektriksel geçirgenlik
		protected const double CoulombConstant = 8.9875517923e9; // coloumb sabiti 


		private double _elektricCharge;
		public double ElektricCharge
		{ get => _elektricCharge;
			set => _elektricCharge = value;
		}

	}
}
