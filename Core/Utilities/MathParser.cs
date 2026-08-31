using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NCalc;

namespace ProbeCalc.Core.Utilities
{
	/// <summary>
	/// Kullanıcının girdiği kullanıcı dostu matematiksel metinleri (x^2, sin vs.) 
	/// C# ve NCalc'in anlayacağı formata çeviren merkezi motor.
	/// </summary>
	public static class MathParser
	{
		public static double Evaluate(string userInput, double xValue)
		{
			// 1. Girdi içindeki boşlukları temizle
			string formatted = userInput.Replace(" ", "");

			// pi sabiti - kelime olarak geçtiği her yerde güvenle değiştirilebilir.
			formatted = formatted.Replace("pi", "Pi");

			// Euler sabiti (e) — SADECE tek başına bir "e" harfiyse değiştir.
			// Aşağıdaki desen "e" harfinin
			// öncesinde/sonrasında harf-rakam-alt çizgi OLMAMASINI şart koşar.
			formatted = Regex.Replace(formatted, @"(?<![a-zA-Z0-9_])e(?![a-zA-Z0-9_])", "E");

			formatted = formatted.Replace("sin", "Sin").Replace("cos", "Cos").Replace("tan", "Tan");

			// 1. Durum: Rakam ile Harf/Açma Parantezi yan yana ise araya çarpı koy.
			// Örnek: "2x" -> "2*x" | "5sin" -> "5*sin" | "3(x+1)" -> "3*(x+1)"
			formatted = Regex.Replace(formatted, @"(\d)([a-zA-Z(])", "$1*$2");

			// 2. Durum (Ekstra Güvenlik): Kapanma parantezi ile Harf/Rakam/Açma Parantezi yan yana ise araya çarpı koy.
			// Örnek: "(x+2)3" -> "(x+2)*3" | "(x+1)(x-1)" -> "(x+1)*(x-1)"
			formatted = Regex.Replace(formatted, @"(\))([a-zA-Z0-9(])", "$1*$2");

			// REGEX SİHRİ: (3x)^2 veya (x+1)^3 gibi parantezli ifadeleri de Pow(..., ...) formatına çevirir.
			// NOT: Taban/üs kısımlarına "-?" eklendi -> "r^-2" gibi NEGATİF üsler
			// (fizikte ters-kare kanunlarının doğal yazımı, örn. k*Q*r^-2) artık
			// eşleşiyor. Eskiden bu desen sadece pozitif/harf-rakam eşleşiyordu,
			// negatif üslü ifadeler Pow()'a çevrilmeden NCalc'e ham "^" ile
			// gidiyordu (bazı NCalc sürümlerinde XOR anlamına gelebilir).
			formatted = Regex.Replace(formatted,
				@"(\([^)]+\)|-?[a-zA-Z0-9_.]+)\^(\([^)]+\)|-?[a-zA-Z0-9_.]+)",
				"Pow($1, $2)");

			// 3. NCALC'İ ÇALIŞTIRMA (Büyük/Küçük Harf Duyarlılığını Kapatarak!)
			// ExpressionOptions bir enum olduğu için burada enum bayraklarını kullanmalıyız.
			// Örneğin, yerleşik fonksiyon isimlerinde büyük/küçük harf duyarsız olmak için:
			ExpressionOptions ayarlar = ExpressionOptions.IgnoreCaseAtBuiltInFunctions | ExpressionOptions.CaseInsensitiveStringComparer;

			// 2. Ayarları motorun içine gönderiyoruz
			Expression expr = new Expression(formatted, ayarlar);
			// X parametresini içeri yolla
			expr.Parameters["x"] = xValue;

			// Sonucu hesapla ve döndür
			return Convert.ToDouble(expr.Evaluate());
		}
		/// <summary>
		/// Tek bir metin kutusundan hem sabit değer hem "x'e bağlı fonksiyon"
		/// desteği vermek isteyen her form için ortak karar mantığı. Metin
		/// içinde "x" GEÇMİYORSA sabit sayı olarak yorumlanır (constantValue
		/// doldurulur, function null kalır). GEÇİYORSA Evaluate'e bağlı bir
		/// fonksiyon üretilir (function doldurulur). Dönen bool, çağıranın
		/// (örn. sayısal integrasyon için Δt gerekip gerekmediğine karar
		/// vermesi için) "bu bir fonksiyon mu" sorusuna cevap verir.
		///
		/// NOT: Bu metot BİLEREK burada, MathParser'da duruyor — Calculators
		/// katmanındaki motorlar (örn. MagneticForceEngine) MathParser'ı hiç
		/// tanımaz, sadece hazır Func&lt;double,double&gt; alır. Metin
		/// yorumlama sorumluluğu hep Utilities katmanında kalmalı.
		/// </summary
		public static bool TryParseConstantOrFunction(string expressionText, out double constantValue, out Func<double, double> function)
		{
			constantValue = 0;
			function = null;

			if (string.IsNullOrWhiteSpace(expressionText))
				return false;

			if (expressionText.Contains("x"))
			{
				function = (t) => Evaluate(expressionText, t);
				return true;
			}

			constantValue = InputParser.ParseSafe(expressionText);
			return false;
		}
	}
}