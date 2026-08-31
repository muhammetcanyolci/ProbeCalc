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
		/// <summary>
		/// Metni double'a çevirir. Kutu BOŞSA sessizce 0.0 döner — bu yüzden
		/// sadece "0" değeri fiziksel olarak GEÇERLİ olan alanlarda kullanın
		/// (örn. Mass >= 0 kabul eden MechanicsEngine gibi). Boş bırakılması
		/// ANLAMSIZ olan alanlarda (yarıçap, mesafe, yük vb.) bunun yerine
		/// ParseRequired kullanın — aksi halde kullanıcı alanı unuttuğunda
		/// hata almadan "0" ile sessizce yanlış bir sonuç üretilir.
		/// </summary>
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

		/// <summary>
		/// ParseSafe ile aynı çevrimi yapar, ama kutu BOŞSA "0" varsaymak yerine
		/// FormatException fırlatır. Boş bırakılması fiziksel olarak anlamsız
		/// alanlar (yarıçap, mesafe, yük, kütle vb. — 0 girilmesi sonucu
		/// bozacak/tanımsızlaştıracak her alan) için bunu kullanın.
		/// </summary>
		/// <param name="fieldLabel">
		/// Hata mesajında gösterilecek, kullanıcının tanıdığı alan adı
		/// (örn. "Yarıçap (R)"). Verilmezse genel bir mesaj kullanılır.
		/// </param>
		public static double ParseRequired(string input, string fieldLabel = null)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				throw new FormatException(fieldLabel != null
					? $"\"{fieldLabel}\" alanı boş bırakılamaz, bir değer girmelisiniz."
					: "Bu alan boş bırakılamaz, bir değer girmelisiniz.");
			}

			return ParseSafe(input);
		}
	}
}