using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MathNet.Symbolics;
namespace ProbeCalc
{


	public class MatematikMotoru
	{
		public static string FonksiyonuDuzenle(string girdi)
		{
			if (string.IsNullOrWhiteSpace(girdi)) return "0";

			// 1. Önce virgülleri noktaya çevir, sonra boşlukları ve küçük harf yap
			string temiz = girdi.Replace(",", ".").ToLower().Replace(" ", "");

			// 2. Sabitler
			temiz = temiz.Replace("π", "Pi").Replace("pi", "Pi")
						 .Replace("√", "Sqrt").Replace("sqrt", "Sqrt");

			// 3. Gizli Çarpmalar
			temiz = Regex.Replace(temiz, @"(\d)([a-z])", "$1*$2");
			temiz = Regex.Replace(temiz, @"(\d)(\()", "$1*$2");

			// 4. MASTER ÜS ALMA (Daha sağlam desen)
			// Bu desen, en içteki üslerden başlayarak dışa doğru temizler
			while (temiz.Contains("^"))
			{
				// En basit x^y yapısını veya parantezli yapıyı yakalar
				temiz = Regex.Replace(temiz, @"([a-z0-9\.]+|\(.+?\))\^([a-z0-9\.]+|\(.+?\))", "Pow($1,$2)");
			}

			// --- DEBUG: Programın arka planda neye çevirdiğini görmen için ---
			// Eğer her şey düzgün çalışınca bu satırı silebilirsin
			Console.WriteLine("Çevrilen Fonksiyon: " + temiz);

			return temiz;
		}




		// 15. Kalkülüs: Sayısal Limit ve Asimptot Analizi (Akıllı Toleranslı Güncel Versiyon)
		public static (double solLimit, double sagLimit, bool limitVarMi, double netLimit) LimitHesapla(string fonksiyon, string tip, double x0)
		{
			NCalc.Expression ifade = new NCalc.Expression(fonksiyon);

			double F(double x)
			{
				ifade.Parameters["x"] = x;
				return Convert.ToDouble(ifade.Evaluate());
			}

			double solLimit = 0, sagLimit = 0, netLimit = 0;
			bool limitVarMi = false;
			double h = 1e-6; // 0.000001 (Çok küçük bir adım)

			if (tip.Contains("Sayı"))
			{
				// Sayıya sağdan ve soldan yaklaşım
				solLimit = F(x0 - h);
				sagLimit = F(x0 + h);

				double mutlakFark = Math.Abs(sagLimit - solLimit);
				double ortalamaBuyukluk = (Math.Abs(sagLimit) + Math.Abs(solLimit)) / 2.0 + 1e-9; // 0'a bölmeyi engellemek için

				// Akıllı Tolerans: Sayılar küçükse mutlak farka (0.05) bak, devasa ise Göreli Farka (%0.1) bak.
				if (mutlakFark < 0.05 || (mutlakFark / ortalamaBuyukluk) < 0.001)
				{
					limitVarMi = true;
					netLimit = (sagLimit + solLimit) / 2.0;
				}
			}
			else if (tip.Contains("+ Sonsuz"))
			{
				// +Sonsuza giderken (Çok büyük sayılar vererek trendi izle)
				solLimit = F(1e6); // 1 Milyon
				sagLimit = F(1e7); // 10 Milyon

				double mutlakFark = Math.Abs(sagLimit - solLimit);
				double ortalamaBuyukluk = (Math.Abs(sagLimit) + Math.Abs(solLimit)) / 2.0 + 1e-9;

				if (mutlakFark < 0.05 || (mutlakFark / ortalamaBuyukluk) < 0.001)
				{
					limitVarMi = true;
					netLimit = sagLimit;
				}
			}
			else if (tip.Contains("- Sonsuz"))
			{
				// -Sonsuza giderken
				solLimit = F(-1e6);
				sagLimit = F(-1e7);

				double mutlakFark = Math.Abs(sagLimit - solLimit);
				double ortalamaBuyukluk = (Math.Abs(sagLimit) + Math.Abs(solLimit)) / 2.0 + 1e-9;

				if (mutlakFark < 0.05 || (mutlakFark / ortalamaBuyukluk) < 0.001)
				{
					limitVarMi = true;
					netLimit = sagLimit;
				}
			}

			return (solLimit, sagLimit, limitVarMi, netLimit);
		}



		public static (string formuller, double? sayisalSonuc) SembolikTurevCoz(string fonksiyon, int derece, double? x0)
		{
			try
			{
				// MathNet.Symbolics '.' ile çalışır, virgülleri noktaya çeviriyoruz
				string temizFonk = fonksiyon.Replace(",", ".");
				var ifade = SymbolicExpression.Parse(temizFonk);

				string tumAdimlar = "";
				var suankiTurev = ifade;

				for (int i = 1; i <= derece; i++)
				{
					suankiTurev = suankiTurev.Differentiate("x");

					// Polinom bittiyse (0 olduysa) dur
					if (suankiTurev.Equals(SymbolicExpression.Zero))
					{
						tumAdimlar += $"f^({i})(x) = 0 (Türev Sıfırlandı)\n";
						break;
					}

					// Sadece ilk 3 türevi ve en son istenen türevi raporlayalım (kalabalık olmasın)
					if (derece <= 4 || i == derece)
					{ // ToString() yapmadan önce cebirsel olarak sadeleştir
						tumAdimlar += $"f^({i})(x) = {suankiTurev.Expand().ToString()}\n";

					}
				}

				double? sonucDeğeri = null;
				if (x0.HasValue)
				{
					var semboller = new Dictionary<string, FloatingPoint> { { "x", x0.Value } };
					sonucDeğeri = suankiTurev.Evaluate(semboller).RealValue;
				}

				return (tumAdimlar, sonucDeğeri);
			}
			catch
			{
				throw; // Hatayı forma fırlat ki kullanıcıya mesaj çıksın
			}
		}
		public static double BelirliIntegralHesapla(string fonk, double a, double b, int n)
		{
			// Simpson kuralı için n çift sayı olmalıdır
			if (n % 2 != 0) n++;

			double h = (b - a) / n;
			double toplam = 0;

			// NCalc ile fonksiyonu değerlendirmek için bir metod
			Func<double, double> f = (x) =>
			{
				string temiz = FonksiyonuDuzenle(fonk);
				NCalc.Expression e = new NCalc.Expression(temiz);
				e.Parameters["x"] = x;
				return Convert.ToDouble(e.Evaluate());
			};

			// Simpson 1/3 Formülü: (h/3) * [f(a) + 4*f(x1) + 2*f(x2) + ... + f(b)]
			toplam = f(a) + f(b);

			for (int i = 1; i < n; i++)
			{
				double x = a + i * h;
				if (i % 2 == 0)
					toplam += 2 * f(x);
				else
					toplam += 4 * f(x);
			}

			return (h / 3) * toplam;
		}



		public static string TaylorSerisiUret(string fonksiyon, double a, int n)
		{
			try
			{
				var ifade = SymbolicExpression.Parse(fonksiyon.Replace(",", "."));
				string polinom = "";
				int terimSayaci = 0; // Alt satıra geçmek için sayaç

				string Format(double sayi) => Math.Round(sayi, 4).ToString("G", CultureInfo.InvariantCulture);
				long Faktoriyel(int k) => k <= 1 ? 1 : k * Faktoriyel(k - 1);

				for (int i = 0; i <= n; i++)
				{
					var suankiTurev = ifade;
					for (int j = 0; j < i; j++) suankiTurev = suankiTurev.Differentiate("x");

					var semboller = new Dictionary<string, FloatingPoint> { { "x", a } };
					double turevDegeri = suankiTurev.Evaluate(semboller).RealValue;

					if (Math.Abs(turevDegeri) < 1e-10) continue;

					double katsayi = turevDegeri / Faktoriyel(i);
					string katsayiStr = Format(Math.Abs(katsayi));

					// Alt satıra geçme mantığı: Her 2 terimde bir \n ekle
					if (terimSayaci > 0 && terimSayaci % 2 == 0)
					{
						polinom += "\n      "; // Yeni satıra geç ve biraz içeriden başla
					}

					string isaret = "";
					if (terimSayaci == 0) isaret = katsayi < 0 ? "-" : "";
					else isaret = katsayi < 0 ? " - " : " + ";

					string degisken = "";
					if (i > 0)
					{
						string taban = a == 0 ? "x" : (a > 0 ? $"(x - {Format(a)})" : $"(x + {Format(-a)})");
						string us = i == 1 ? "" : $"^{i}";
						degisken = (katsayiStr == "1") ? $"{taban}{us}" : $"{katsayiStr}*{taban}{us}";
					}
					else degisken = katsayiStr;

					polinom += isaret + degisken;
					terimSayaci++;
				}

				return string.IsNullOrWhiteSpace(polinom) ? "0" : polinom.Trim();
			}
			catch (Exception ex)
			{
				return "Hata: " + ex.Message;
			}
		}



	}
}