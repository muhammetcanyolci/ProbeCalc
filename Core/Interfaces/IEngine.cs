using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcUni.Core.Interfaces
{
	internal interface IEngine
	{   /// <summary>
		/// Calculates the result of the engine's operation.
		///</summary>
		void Calculate();
		 /// <summary>
		 /// Deletes all.
		 /// </summary>
		void Reset();
	}
}
