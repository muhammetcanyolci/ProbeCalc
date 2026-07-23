using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbeCalc.Core.Base
{    public abstract class MechanicsEngine : PhysicsEngine
	{
		// ilk hızı kontrollü almak için( mechanic konularında ortak)
		private double _InitialVelocity;
		public double TimeLimit { get; set; }

		public double InitialVelocity
		{
			get => _InitialVelocity;
			set
			{
				if (!IsInputPositive(value))

				{ throw new ArgumentOutOfRangeException("ilk hız sıfır veya pozitif olmalıdır."); }
				_InitialVelocity = value;


			}
		}

		private double mass;
		public double Mass
		{ get => mass;
		set 
			{ if(!IsInputPositive(value))
				{ throw new ArgumentOutOfRangeException(" kütle sıfırdan küçük olamaz"); }
				mass = value;	
			}
		}
		public override void Reset()
		{
			InitialVelocity = 0;
			Mass = 0;
			SolutionSteps = string.Empty;
		}
	}
 
}
