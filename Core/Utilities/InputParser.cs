using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbeCalc.Core.Utilities
{
	/// <summary>
	/// Arayüzden gelen girdileri güvenli bir şekilde matematiksel tiplere dönüştüren yardımcı sınıf.
	/// </summary>
	public static class InputParser
	{
		public static double ParseSafe(string input)
		{
			// Eğer kutu tamamen boşsa 0 döndür (Kullanıcı henüz doldurmamış olabilir)
			if (string.IsNullOrWhiteSpace(input))
				return 0.0;

			string safeInput = input.Replace('.', ',');

			// Başarıyla sayıya çevirebiliyorsa çevir ve gönder
			if (double.TryParse(safeInput, out double result))
			{
				return result;
			}

			// Eğer sayı değil de harf/geçersiz karakter girdiyse, 
			// hata fırlat ki SafeExecute bunu yakalasın ve ekrana uyarı versin!
			throw new FormatException($"Geçersiz değer girdin: \"{input}\". Lütfen sadece sayısal bir değer kullan!");
		}
	}
}
