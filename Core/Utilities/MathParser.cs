using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NCalc;

namespace ProbeCalc.Core.Utilities // Kendi klasör yapına göre burayı ayarlayabilirsin
{
	/// <summary>
	/// Kullanıcının girdiği kullanıcı dostu matematiksel metinleri (x^2, sin vs.) 
	/// C# ve NCalc'in anlayacağı formata çeviren merkezi motor.
	/// </summary>
	public static class MathParser
	{
		public static double Evaluate(string userInput, double xValue)
		{
			// 1. Girdi içindeki boşlukları temizleyelim ki hata payı azalsın
			string formatted = userInput.Replace(" ", "");

			//  pi veya e gibi sabitleri otomatik C# sabitlerine çevirebilirsin
			formatted = formatted.Replace("pi", "Pi").Replace("e", "E");
			formatted = formatted.Replace("sin", "Sin").Replace("cos", "Cos").Replace("tan", "Tan");
			// 1. Durum: Rakam ile Harf/Açma Parantezi yan yana ise araya çarpı koy.
			// Örnek: "2x" -> "2*x" | "5sin" -> "5*sin" | "3(x+1)" -> "3*(x+1)"
			formatted = Regex.Replace(formatted, @"(\d)([a-zA-Z(])", "$1*$2");

			// 2. Durum (Ekstra Güvenlik): Kapanma parantezi ile Harf/Rakam/Açma Parantezi yan yana ise araya çarpı koy.
			// Örnek: "(x+2)3" -> "(x+2)*3" | "(x+1)(x-1)" -> "(x+1)*(x-1)"
			formatted = Regex.Replace(formatted, @"(\))([a-zA-Z0-9(])", "$1*$2");
			// REGEX SİHRİ: (3x)^2 veya (x+1)^3 gibi parantezli ifadeleri de Pow(..., ...) formatına çevirir.
			formatted = Regex.Replace(formatted, @"(\([^)]+\)|[a-zA-Z0-9_.]+)\^(\([^)]+\)|[a-zA-Z0-9_.]+)", "Pow($1, $2)");
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
	}
}