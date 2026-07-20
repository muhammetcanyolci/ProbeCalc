using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;
namespace ProbeCalc
	
{
	public static class FizikEngines
	{ //------------------------------------------1.MEKANİK ENERJİ------------------------------------
		// 1. Mekanik Enerji Dönüşümü
		// Birden fazla sonuç döndürmek için (double v2, double pe2...) yapısını kullanıyoruz.
		public static (double v2, double pe2, double ke2, double eToplam) MekanikEnerjiHesapla(double m, double h1, double v1, double h2)
		{
			const double g = 9.81; // Yerçekimi ivmesi

			// 1. Durum (Başlangıç)
			double pe1 = m * g * h1;
			double ke1 = 0.5 * m * Math.Pow(v1, 2);
			double eToplam = pe1 + ke1;

			// 2. Durum (İncelenmek İstenen Anlık Durum)
			double pe2 = m * g * h2;
			double ke2 = eToplam - pe2;

			// Gerçeklik Kontrolü: Kinetik enerji eksiye düşemez. Düşüyorsa cisim o yüksekliğe çıkamıyordur.
			if (ke2 < 0)
			{
				throw new Exception("Cismin enerjisi bu yüksekliğe çıkmak için yetersiz!");
			}

			// Hızın hesaplanması: ke2 = 0.5 * m * v2^2 formülünden v2'yi çektik
			double v2 = Math.Sqrt((2 * ke2) / m);

			// Tüm sonuçları paketleyip geri gönderiyoruz
			return (v2, pe2, ke2, eToplam);
		}
		
		//-----------------------------------------2.YAPILAN İŞ----------------------------------------
		public static double YapilanIsiHesapla(string fonksiyonMetni, double x1, double x2, int adimSayisi = 1000)
		{
			// Simpson yöntemi için adım sayısının çift olması zorunludur.
			if (adimSayisi % 2 != 0) adimSayisi++;

			double h = (x2 - x1) / adimSayisi;

			// Kullanıcının girdiği string'i matematiksel bir ifadeye çeviriyoruz
			Expression ifade = new Expression(fonksiyonMetni);

			// X yerine değer koyup sonucu hesaplayan küçük bir yardımcı fonksiyon
			double Fx(double xDegeri)
			{
				ifade.Parameters["x"] = xDegeri;
				return Convert.ToDouble(ifade.Evaluate());
			}

			// İntegral Hesaplama Algoritması (Simpson 1/3)
			double toplam = Fx(x1) + Fx(x2);

			for (int i = 1; i < adimSayisi; i += 2)
			{
				toplam += 4 * Fx(x1 + i * h);
			}
			for (int i = 2; i < adimSayisi - 1; i += 2)
			{
				toplam += 2 * Fx(x1 + i * h);
			}

			return (h / 3) * toplam;
		}
		//-----------------------------------------3.momentum-----------------------------------------------
		// 3. Momentum ve Çarpışma Analizi (1D)
		public static (double v1f, double v2f, double keKayip) CarpismayiHesapla(double m1, double v1i, double m2, double v2i, double e)
		{
			// Momentum Korunumu: m1*v1i + m2*v2i = m1*v1f + m2*v2f
			double toplamMomentum = (m1 * v1i) + (m2 * v2i);

			// Bağıl Hız Denklemi: v2f - v1f = e * (v1i - v2i)
			double bagilHizFarki = e * (v1i - v2i);

			// Denklem Çözümü:
			// v2f = bagilHizFarki + v1f
			// m1*v1f + m2*(bagilHizFarki + v1f) = toplamMomentum
			double v1f = (toplamMomentum - (m2 * bagilHizFarki)) / (m1 + m2);
			double v2f = bagilHizFarki + v1f;

			// Enerji Analizi
			double ilkKE = (0.5 * m1 * v1i * v1i) + (0.5 * m2 * v2i * v2i);
			double sonKE = (0.5 * m1 * v1f * v1f) + (0.5 * m2 * v2f * v2f);
			double keKayip = ilkKE - sonKE;

			return (v1f, v2f, keKayip);
		}
		// 4. İtme (Impulse) ve İntegral Analizi
		public static (double itme, double v2) ItmeVeSonHizHesapla(string fonksiyon, double t1, double t2, double m, double v1)
		{
			int dilimSayisi = 1000; // İntegral hassasiyeti
			double h = (t2 - t1) / dilimSayisi;

			NCalc.Expression ifade = new NCalc.Expression(fonksiyon);

			// f(t) değerini NCalc ile hesaplayan yerel fonksiyon
			double F(double t)
			{
				// Kullanıcı fonksiyona "t" de yazsa "x" de yazsa çalışsın diye ikisini de destekliyoruz
				ifade.Parameters["t"] = t;
				ifade.Parameters["x"] = t;
				return Convert.ToDouble(ifade.Evaluate());
			}

			// Yamuk Kuralı ile Belirli İntegral (J = ∫ F(t) dt)
			double toplamAlan = F(t1) + F(t2);
			for (int i = 1; i < dilimSayisi; i++)
			{
				toplamAlan += 2 * F(t1 + (i * h));
			}

			double J = (h / 2.0) * toplamAlan;

			// Momentum Eşitliği: J = m*v2 - m*v1 => v2 = (J / m) + v1
			double v2 = (J / m) + v1;

			return (J, v2);
		}

		// 5. Dönme Dinamiği ve Enerji Analizi
		public static (double I, double tork, double omega, double ke) DonmeDinamiğiHesapla(string geometri, double m, double r, double fTeget, double t)
		{
			double I = 0;

			// Geometriye göre Eylemsizlik Momenti (I) Formülleri
			if (geometri.Contains("Silindir") || geometri.Contains("Disk"))
				I = 0.5 * m * Math.Pow(r, 2);
			else if (geometri.Contains("Çember") || geometri.Contains("Halka"))
				I = m * Math.Pow(r, 2);
			else if (geometri.Contains("Küre"))
				I = (2.0 / 5.0) * m * Math.Pow(r, 2);
			else
				I = 0.5 * m * Math.Pow(r, 2); // Varsayılan (Disk)

			// Fizik 101 Kuralları
			double tork = fTeget * r;             // Tork (Tau) = F * r
			double alfa = tork / I;               // Açısal İvme (Alfa) = Tork / I
			double omega = alfa * t;              // Açısal Hız (Omega) = Alfa * t (ilk hız 0)
			double ke = 0.5 * I * Math.Pow(omega, 2); // Kinetik Enerji = 1/2 * I * w^2

			return (I, tork, omega, ke);
		}
		// 6. Basit ve Sönümlü Harmonik Hareket
		public static (double omega, double T, double f, double vMax, double aMax, double E) HarmonikHesapla(string tip, double m_L, double k_g, double A)
		{
			// Açısal Frekans (Yay için k/m, Sarkaç için g/L)
			double omega = Math.Sqrt(k_g / m_L);

			double T = 2 * Math.PI / omega; // Periyot
			double f = 1 / T;               // Frekans

			double vMax = A * omega;              // Maksimum Hız
			double aMax = A * Math.Pow(omega, 2); // Maksimum İvme

			double E = 0;
			// Toplam Enerji Hesaplaması
			if (tip.Contains("Sarkaç"))
			{
				// Basit sarkaç için küçük açılarda E ≈ 0.5 * m * g * L * theta^2
				// Not: Burada sistem kütlesini standart 1 kg kabul ederek kütle başına enerjiyi hesaplıyoruz.
				E = 0.5 * 1.0 * k_g * m_L * Math.Pow(A, 2);
			}
			else
			{
				// Yay sistemi için E = 0.5 * k * x^2
				E = 0.5 * k_g * Math.Pow(A, 2);
			}

			return (omega, T, f, vMax, aMax, E);
		}
		// 7. Elektriksel Potansiyel ve İş (İntegralli Analiz)
		public static (double deltaV, double isYapanW) ElektrikPotansiyelIntegralHesapla(string fonksiyon, double x1, double x2, double q_muC)
		{
			int dilimSayisi = 1000;
			double h = (x2 - x1) / dilimSayisi;

			NCalc.Expression ifade = new NCalc.Expression(fonksiyon);

			double E(double x)
			{
				ifade.Parameters["x"] = x;
				return Convert.ToDouble(ifade.Evaluate());
			}

			// Yamuk Kuralı ile Belirli İntegral: ∫ E(x) dx
			double toplamAlan = E(x1) + E(x2);
			for (int i = 1; i < dilimSayisi; i++)
			{
				toplamAlan += 2 * E(x1 + (i * h));
			}

			double integral = (h / 2.0) * toplamAlan;

			// Fizik Kuralları
			double deltaV = -integral; // ΔV = -∫ E(x) dx
			double q = q_muC * 1e-6;   // MikroCoulomb'u Coulomb'a çevir
			double isYapanW = q * deltaV; // W = q * ΔV

			return (deltaV, isYapanW);
		}
		// 9. Gauss Yasası ve Elektrik Akısı Analizi
		public static (double Qin, double Aki, double E) GaussHesapla(string tip, double Q_muC, double R_cisim, double r)
		{
			double e0 = 8.854e-12; // Boşluk geçirgenliği (Epsilon sıfır)
			double k = 8.987e9;    // Coulomb sabiti
			double Q = Q_muC * 1e-6; // MikroCoulomb -> Coulomb

			double Qin = 0;
			double E = 0;

			if (tip.Contains("Nokta"))
			{
				Qin = Q;
				E = (k * Qin) / (r * r);
			}
			else if (tip.Contains("Çizgi"))
			{
				// Çizgisel yükte Q_muC aslında lambda'dır (C/m). 1 metrelik kesit alıyoruz.
				Qin = Q;
				E = Qin / (2 * Math.PI * e0 * r);
			}
			else if (tip.Contains("Küre"))
			{
				if (r >= R_cisim) // Gauss yüzeyi kürenin DIŞINDA
				{
					Qin = Q;
					E = (k * Qin) / (r * r);
				}
				else // Gauss yüzeyi kürenin İÇİNDE (Hacimsel oranlama)
				{
					Qin = Q * Math.Pow(r / R_cisim, 3);
					E = (k * Q * r) / Math.Pow(R_cisim, 3);
				}
			}

			// Akı = İçerideki Yük / Epsilon Sıfır
			double Aki = Qin / e0;

			return (Qin, Aki, E);
		}
		// 10. Kapasitans, Dielektrikler ve Enerji Depolama
		public static (double C_pF, double Q_pC, double E_Vm, double U_pJ) KapasitansHesapla(double A_cm2, double d_mm, double kappa, double V)
		{
			double e0 = 8.854e-12; // Epsilon sıfır (F/m)

			// Birim dönüştürmeleri (cm² -> m², mm -> m)
			double A_m2 = A_cm2 * 1e-4;
			double d_m = d_mm * 1e-3;

			// Matematiksel Model
			double C = kappa * e0 * (A_m2 / d_m);
			double Q = C * V;
			double E = V / d_m;
			double U = 0.5 * C * Math.Pow(V, 2);

			// Sonuçları Piko (10^-12) ölçeğine büyütüp yolluyoruz
			return (C * 1e12, Q * 1e12, E, U * 1e12);
		}
		// 11. Değişken Manyetik Akı ve Faraday İndüksiyonu
		public static (double Aki, double EMF) FaradayIntegralHesapla(string fonksiyon, double L, double x1, double x2, double v)
		{
			int dilimSayisi = 1000;
			double h = (x2 - x1) / dilimSayisi;

			NCalc.Expression ifade = new NCalc.Expression(fonksiyon);

			double B(double x)
			{
				ifade.Parameters["x"] = x;
				return Convert.ToDouble(ifade.Evaluate());
			}

			// Yamuk Kuralı ile Yüzey İntegrali: ∫ B(x) dx
			double toplamAlan = B(x1) + B(x2);
			for (int i = 1; i < dilimSayisi; i++)
			{
				toplamAlan += 2 * B(x1 + (i * h));
			}

			double bIntegrali = (h / 2.0) * toplamAlan;

			// 1. Toplam Manyetik Akı (Phi = L * ∫ B(x) dx)
			double aki = L * bIntegrali;

			// 2. İndüklenen Voltaj (Motional EMF)
			// Çerçeve sabit bir hızla hareket ediyorsa, akı değişimi sağ ve sol kenardaki B alanı farkından kaynaklanır.
			double emf = -v * L * (B(x2) - B(x1));

			return (aki, emf);
		}
		// 12. RL Devresi ve İndüktans Analizi
		public static (double tau, double I_max, double U_max) RLDevresiHesapla(double V, double R, double L)
		{
			// Zaman Sabiti: Tau = L / R
			double tau = L / R;

			// Maksimum Akım (Ohm Yasası): I = V / R (Bobin düz tele dönüştüğünde)
			double I_max = V / R;

			// Depolanan Maksimum Manyetik Enerji: U = 1/2 * L * I^2
			double U_max = 0.5 * L * Math.Pow(I_max, 2);

			return (tau, I_max, U_max);
		}
		// 13. Faraday Yasası ve Jeneratör Analizi (Klasik Model)
		public static (double maxAki_Wb, double pikEMK_V) FaradayJeneratorHesapla(int N, double r_cm, double v)
		{
			// Bobin Alanı (m^2)
			double A = Math.PI * Math.Pow(r_cm / 100.0, 2);

			// Varsayılan Mıknatıs Gücü (Tesla) ve Alan Genişliği
			double B_max = 0.5;
			double w = 0.1; // Manyetik alanın bobin etrafındaki etki genişliği (metre)

			// Maksimum Akı (Mıknatıs tam bobinin merkezindeyken)
			double maxAki_Wb = B_max * A;

			// Pik Voltaj (EMK): Akının en hızlı değiştiği anlarda (girerken ve çıkarken)
			// Türevin maksimum değeri yaklaşık olarak matematiksel modelden çekilir:
			double pikEMK_V = N * maxAki_Wb * (v / w) * 0.85;

			return (maxAki_Wb, pikEMK_V);
		}
	}
}
