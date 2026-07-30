using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization; // Evrensel dil formatı için eklendi

namespace ProbeCalc.Core.Utilities
{
	/// <summary>
	/// Arayüzden gelen girdileri güvenli bir şekilde matematiksel tiplere dönüştüren yardımcı sınıf.
	/// </summary>
	public static class InputParser
	{	
		public static double ParseSafe(string input)
			{
				// Eğer kutu tamamen boşsa 0 döndür
				if (string.IsNullOrWhiteSpace(input))
					return 0.0;

				// Türkçe'deki virgül kullanımını, evrensel standart olan noktaya çeviriyoruz
				string safeInput = input.Replace(',', '.');

				// İşletim sisteminin dilinden bağımsız olarak (InvariantCulture) sayıyı parse et
				if (double.TryParse(safeInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
				{
					return result;
				}

				// Hata durumu
				throw new FormatException($"Geçersiz değer girdin: \"{input}\". Lütfen sadece sayısal bir değer kullan!");
			}
		}
	}
