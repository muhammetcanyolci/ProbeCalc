using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;
using NCalc.Extensions;
using ScottPlot.WinForms;

namespace ProbeCalc
{
	internal class GrafikMotoru
	{
		// İstediğimiz grafiği, istediğimiz isimlerle çizdirecek genel şablon metot
		public static void AlanGrafigiCiz(FormsPlot plotEkrani, string fonksiyonMetni, double x1, double x2, string xEkseniAd, string yEkseniAd, string baslik)
		{

			// 
			try
			{
				plotEkrani.Plot.Clear();

				int noktaSayisi = 200;
				double[] xs = new double[noktaSayisi];
				double[] ys = new double[noktaSayisi];
				double[] ySifirlar = new double[noktaSayisi];

				NCalc.Expression ifade = new NCalc.Expression(fonksiyonMetni);

				double adim = (x2 - x1) / (noktaSayisi - 1);
				for (int i = 0; i < noktaSayisi; i++)
				{
					double oAnkiX = x1 + (i * adim);
					xs[i] = oAnkiX;

					ifade.Parameters["x"] = oAnkiX;
					ys[i] = InputParser.ParseSafe(ifade.Evaluate());

					ySifirlar[i] = 0;
				}

				// Boyama İşlemi
				var fill = plotEkrani.Plot.Add.FillY(xs, ys, ySifirlar);
				fill.FillColor = ScottPlot.Colors.DodgerBlue.WithOpacity(0.4);

				// Çizgi İşlemi
				var scatter = plotEkrani.Plot.Add.Scatter(xs, ys);
				scatter.LineStyle.Color = ScottPlot.Colors.DarkBlue;
				scatter.LineStyle.Width = 2;
				scatter.MarkerStyle.Size = 0;

				// Parametrelerden gelen eksen isimlerini atıyoruz
				plotEkrani.Plot.Axes.Bottom.Label.Text = xEkseniAd;
				plotEkrani.Plot.Axes.Left.Label.Text = yEkseniAd;
				plotEkrani.Plot.Axes.Title.Label.Text = baslik;

				plotEkrani.Plot.Axes.AutoScale();
				plotEkrani.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Grafik çizilirken bir hata oluştu:\n\n" + ex.Message, "Çizim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
				plotEkrani.Plot.Clear();
				plotEkrani.Refresh();
			}
		}
		public static void EnerjiBarGrafigiCiz(FormsPlot plotEkrani, double m1, double v1i, double m2, double v2i, double v1f, double v2f)
		{
			try
			{
				plotEkrani.Plot.Clear();

				// 1. Kinetik Enerjileri (Joule) Hesapla
				double ilkKE = (0.5 * m1 * v1i * v1i) + (0.5 * m2 * v2i * v2i);
				double sonKE = (0.5 * m1 * v1f * v1f) + (0.5 * m2 * v2f * v2f);

				// 2. ScottPlot 5.x Sütun (Bar) Oluşturma Mantığı
				List<ScottPlot.Bar> cubuklar = new List<ScottPlot.Bar>
		{
			new ScottPlot.Bar() { Position = 1, Value = ilkKE, FillColor = ScottPlot.Colors.SteelBlue },
			new ScottPlot.Bar() { Position = 2, Value = sonKE, FillColor = ScottPlot.Colors.IndianRed }
		};

				// Çubukları grafiğe ekle
				var barPlot = plotEkrani.Plot.Add.Bars(cubuklar);

				// 3. Eksen ve Görünüm Ayarları
				plotEkrani.Plot.Axes.Bottom.Label.Text = "Çarpışma Durumu (1: Öncesi, 2: Sonrası)";
				plotEkrani.Plot.Axes.Left.Label.Text = "Sistemdeki Toplam Kinetik Enerji [Joule]";
				plotEkrani.Plot.Axes.Title.Label.Text = "Enerji Korunumu Analizi";

				// Eksenleri sığdır (Çubuklar çok büyük veya küçük olursa ekrana sığsın)
				plotEkrani.Plot.Axes.SetLimitsX(0, 3); // X ekseni 1 ve 2 pozisyonlarını ortalasın
				plotEkrani.Plot.Axes.AutoScaleY();

				plotEkrani.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Grafik çizilirken bir hata oluştu:\n" + ex.Message, "Çizim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		// Zaman-Kuvvet (İtme) Grafiği
		public static void ItmeGrafigiCiz(FormsPlot plotEkrani, string fonksiyonMetni, double t1, double t2)
		{
			try
			{
				plotEkrani.Plot.Clear();

				int noktaSayisi = 200;
				double[] ts = new double[noktaSayisi]; // x yerine t
				double[] Fs = new double[noktaSayisi]; // y yerine F
				double[] sifirlar = new double[noktaSayisi];

				NCalc.Expression ifade = new NCalc.Expression(fonksiyonMetni);

				double adim = (t2 - t1) / (noktaSayisi - 1);
				for (int i = 0; i < noktaSayisi; i++)
				{
					double oAnkiT = t1 + (i * adim);
					ts[i] = oAnkiT;

					ifade.Parameters["t"] = oAnkiT;
					ifade.Parameters["x"] = oAnkiT;
					Fs[i] = InputParser.ParseSafe(ifade.Evaluate());

					sifirlar[i] = 0;
				}

				// Boyama ve Çizgi İşlemi (Çarpışma anını vurgulamak için kırmızı tonlar)
				var fill = plotEkrani.Plot.Add.FillY(ts, Fs, sifirlar);
				fill.FillColor = ScottPlot.Colors.Crimson.WithOpacity(0.4);

				var scatter = plotEkrani.Plot.Add.Scatter(ts, Fs);
				scatter.LineStyle.Color = ScottPlot.Colors.DarkRed;
				scatter.LineStyle.Width = 2;
				scatter.MarkerStyle.Size = 0;

				plotEkrani.Plot.Axes.Bottom.Label.Text = "Zaman (t) [Saniye]";
				plotEkrani.Plot.Axes.Left.Label.Text = "Kuvvet F(t) [Newton]";
				plotEkrani.Plot.Axes.Title.Label.Text = "İtme (Impulse) Eğrisi";

				plotEkrani.Plot.Axes.AutoScale();
				plotEkrani.Refresh();
			}
			catch
			{
				plotEkrani.Plot.Clear();
				plotEkrani.Refresh();
			}
		}

		// Rotasyonel Çark ve Enerji Görselleştirme
		// Gelişmiş Rotasyonel Çark ve Geometri Görselleştirme
		public static void DonmeGorseliCiz(FormsPlot plotEkrani, double r, double fTeget, double ke, string geometri)
		{
			try
			{
				plotEkrani.Plot.Clear();

				// Arka Plan ve Geometri Renkleri
				var renkDolu = ScottPlot.Colors.SteelBlue.WithOpacity(0.5);
				var renkBos = ScottPlot.Colors.White;
				var renkCizgi = ScottPlot.Colors.SlateGray;

				// GEOMETRİYE GÖRE ŞEKİL ÇİZİMİ
				if (geometri.Contains("Çember") || geometri.Contains("Halka"))
				{
					// İçi boş halka efekti: Büyük dolu daire, içine arka plan renginde küçük daire
					var disCember = plotEkrani.Plot.Add.Circle(0, 0, r);
					disCember.FillColor = renkDolu;
					disCember.LineColor = renkCizgi;
					disCember.LineWidth = 4;

					var icCember = plotEkrani.Plot.Add.Circle(0, 0, r * 0.8); // İç kalınlık
					icCember.FillColor = plotEkrani.Plot.FigureBackground.Color; // Arka plan rengine boya (İçi boş görünsün)
					icCember.LineColor = renkCizgi;
					icCember.LineWidth = 2;
				}
				else if (geometri.Contains("Küre"))
				{
					// Küre efekti (3D illüzyonu): Merkezden dışa doğru saydamlaşan üst üste daireler
					int katmanSayisi = 10;
					for (int i = 0; i < katmanSayisi; i++)
					{
						double guncelR = r - (r * i / katmanSayisi);
						var kureKatmani = plotEkrani.Plot.Add.Circle(0, 0, guncelR);
						// İçeri doğru gittikçe renk açılır/parlar
						kureKatmani.FillColor = ScottPlot.Colors.SteelBlue.WithOpacity(0.1 + (0.05 * i));
						kureKatmani.LineColor = ScottPlot.Colors.Transparent; // Çizgi yok, yumuşak geçiş
					}
					// En dış çerçeve
					var disCerceve = plotEkrani.Plot.Add.Circle(0, 0, r);
					disCerceve.FillColor = ScottPlot.Colors.Transparent;
					disCerceve.LineColor = renkCizgi;
					disCerceve.LineWidth = 2;
				}
				else // Varsayılan: Silindir / Disk
				{
					// Katı Disk: Düz dolgu, merkezde bir mil (nokta)
					var disk = plotEkrani.Plot.Add.Circle(0, 0, r);
					disk.FillColor = renkDolu;
					disk.LineColor = renkCizgi;
					disk.LineWidth = 3;

					// Merkez mili (Rotasyon ekseni)
					var mil = plotEkrani.Plot.Add.Circle(0, 0, r * 0.05);
					mil.FillColor = ScottPlot.Colors.Black;
				}

				// KUVVET VEKTÖRÜNÜ (OKU) DAHA ŞIK HALE GETİRME
				// Kuvvet yukarı (pozitif) veya aşağı (negatif) teğet olabilir
				double baslangicY = fTeget > 0 ? -r / 2 : r / 2;
				double bitisY = fTeget > 0 ? r / 2 : -r / 2;

				// Oku her zaman diskin sağ kenarına (x = r) teğet olarak çizelim
				var ok = plotEkrani.Plot.Add.Arrow(r, bitisY, r, baslangicY);
				ok.ArrowLineColor = ScottPlot.Colors.IndianRed;
				ok.ArrowLineWidth = 4;

				// Kuvvet miktarını okun yanına yaz
				var text = plotEkrani.Plot.Add.Text($"F = {fTeget} N", r * 1.1, 0);
				text.LabelFontColor = ScottPlot.Colors.IndianRed;
				text.LabelFontSize = 14;
				text.LabelBold = true;

				// EKSEN VE GÖRÜNÜM AYARLARI
				// Grafiği kare yap ki daireler elips gibi ezilmesin
				plotEkrani.Plot.Axes.SetLimits(-r * 1.5, r * 1.5, -r * 1.5, r * 1.5);

				// Başlık
				plotEkrani.Plot.Axes.Title.Label.Text = $"{geometri} Simülasyonu\nEnerji: {ke:F2} J | Yarıçap: {r} m";

				// Temiz görünüm
				plotEkrani.Plot.HideGrid();
				plotEkrani.Plot.Axes.Left.IsVisible = false;
				plotEkrani.Plot.Axes.Bottom.IsVisible = false;

				plotEkrani.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Çizim Hatası: " + ex.Message);
				plotEkrani.Plot.Clear();
				plotEkrani.Refresh();
			}
		
	}
		// Harmonik Dalga ve Sönüm (Damping) Grafiği
		public static void HarmonikDalgaCiz(FormsPlot plotEkrani, double A, double omega, double sonumKatsayisi)
		{
			try
			{
				plotEkrani.Plot.Clear();

				int noktaSayisi = 1000;
				double[] t = new double[noktaSayisi];
				double[] x = new double[noktaSayisi];

				// Grafikte 5 tam periyotluk bir zaman dilimini gösterelim
				double periyot = 2 * Math.PI / omega;
				double toplamZaman = periyot * 5;
				double adim = toplamZaman / noktaSayisi;

				for (int i = 0; i < noktaSayisi; i++)
				{
					t[i] = i * adim;
					// Sönümlü Konum Denklemi: x(t) = A * e^(-b*t) * cos(w*t)
					x[i] = A * Math.Exp(-sonumKatsayisi * t[i]) * Math.Cos(omega * t[i]);
				}

				// Ana Dalgayı Çiz
				var dalga = plotEkrani.Plot.Add.Scatter(t, x);
				dalga.LineStyle.Color = ScottPlot.Colors.MediumPurple;
				dalga.LineWidth = 2;
				dalga.MarkerStyle.Size = 0; // Noktaları gizle, sadece çizgi kalsın

				// Eğer Sönüm varsa, zarfları (Envelope) çiz (Dalgayı ezen hayali dış sınırlar)
				if (sonumKatsayisi > 0)
				{
					double[] ustZarf = new double[noktaSayisi];
					double[] altZarf = new double[noktaSayisi];
					for (int i = 0; i < noktaSayisi; i++)
					{
						ustZarf[i] = A * Math.Exp(-sonumKatsayisi * t[i]);
						altZarf[i] = -A * Math.Exp(-sonumKatsayisi * t[i]);
					}

					var ustCizgi = plotEkrani.Plot.Add.Scatter(t, ustZarf);
					ustCizgi.LineStyle.Pattern = ScottPlot.LinePattern.Dashed; // Kesik çizgi
					ustCizgi.LineStyle.Color = ScottPlot.Colors.Gray;
					ustCizgi.MarkerStyle.Size = 0;

					var altCizgi = plotEkrani.Plot.Add.Scatter(t, altZarf);
					altCizgi.LineStyle.Pattern = ScottPlot.LinePattern.Dashed;
					altCizgi.LineStyle.Color = ScottPlot.Colors.Gray;
					altCizgi.MarkerStyle.Size = 0;
				}

				plotEkrani.Plot.Axes.Title.Label.Text = "Konum - Zaman Eğrisi (x-t)";
				plotEkrani.Plot.Axes.Bottom.Label.Text = "Zaman (s)";
				plotEkrani.Plot.Axes.Left.Label.Text = "Uzanım (m / rad)";

				// Sıfır eksenini belirginleştir
				plotEkrani.Plot.Add.HorizontalLine(0, width: 1, color: ScottPlot.Colors.Black);
				// Grafiğin dış çerçeve rengini saydam (veya formun rengi) yap, içini beyaz bırak
				plotEkrani.Plot.FigureBackground.Color = ScottPlot.Colors.Transparent;
				plotEkrani.Plot.DataBackground.Color = ScottPlot.Colors.WhiteSmoke;
				plotEkrani.Plot.Axes.AutoScale();
				plotEkrani.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Grafik Hatası: " + ex.Message);
			}


		}
		// Elektrik Alan İntegrali ve Potansiyel Fark Grafiği
		public static void ElektrikIntegralGrafigiCiz(FormsPlot plotEkrani, string fonksiyonMetni, double x1, double x2)
		{
			try
			{
				plotEkrani.Plot.Clear();

				int noktaSayisi = 200;
				double[] xs = new double[noktaSayisi];
				double[] Es = new double[noktaSayisi];
				double[] sifirlar = new double[noktaSayisi];

				NCalc.Expression ifade = new NCalc.Expression(fonksiyonMetni);

				double adim = (x2 - x1) / (noktaSayisi - 1);
				for (int i = 0; i < noktaSayisi; i++)
				{
					double oAnkiX = x1 + (i * adim);
					xs[i] = oAnkiX;

					ifade.Parameters["x"] = oAnkiX;
					Es[i] = InputParser.ParseSafe(ifade.Evaluate());

					sifirlar[i] = 0;
				}

				// Alanı Boyama İşlemi (Elektrik potansiyeli temsil eden mavi bir alan)
				var fill = plotEkrani.Plot.Add.FillY(xs, Es, sifirlar);
				fill.FillColor = ScottPlot.Colors.RoyalBlue.WithOpacity(0.4);

				var scatter = plotEkrani.Plot.Add.Scatter(xs, Es);
				scatter.LineStyle.Color = ScottPlot.Colors.Navy;
				scatter.LineStyle.Width = 2;
				scatter.MarkerStyle.Size = 0;

				plotEkrani.Plot.Axes.Bottom.Label.Text = "Konum (x) [Metre]";
				plotEkrani.Plot.Axes.Left.Label.Text = "Elektrik Alan E(x) [N/C]";
				plotEkrani.Plot.Axes.Title.Label.Text = "Potansiyel Fark Eğrisi (İntegral Alanı)";

				plotEkrani.Plot.Axes.AutoScale();
				plotEkrani.Refresh();
			}
			catch
			{
				plotEkrani.Plot.Clear();
				plotEkrani.Refresh();
			}
		}
		// Manyetik Alan Eğrisi ve Akı (İntegral) Görselleştirmesi
		public static void FaradayGrafigiCiz(FormsPlot plotEkrani, string fonksiyonMetni, double x1, double x2)
		{
			try
			{
				plotEkrani.Plot.Clear();

				int noktaSayisi = 300;

				// Grafiği x1 ve x2'nin biraz dışına kadar çizelim ki çerçeve uzayda süzülüyor gibi görünsün
				double genislik = Math.Abs(x2 - x1);
				double cizimBaslangic = x1 - (genislik * 0.5);
				double cizimBitis = x2 + (genislik * 0.5);

				double[] xs = new double[noktaSayisi];
				double[] Bs = new double[noktaSayisi];

				NCalc.Expression ifade = new NCalc.Expression(fonksiyonMetni);

				double adim = (cizimBitis - cizimBaslangic) / (noktaSayisi - 1);
				for (int i = 0; i < noktaSayisi; i++)
				{
					double oAnkiX = cizimBaslangic + (i * adim);
					xs[i] = oAnkiX;

					ifade.Parameters["x"] = oAnkiX;
					Bs[i] = InputParser.ParseSafe(ifade.Evaluate());
				}

				// Bütün Eğriyi Çiz (Kesik Gri Çizgi)
				var anaEgri = plotEkrani.Plot.Add.Scatter(xs, Bs);
				anaEgri.LineStyle.Color = ScottPlot.Colors.Gray;
				anaEgri.LineStyle.Pattern = ScottPlot.LinePattern.Dashed;
				anaEgri.MarkerStyle.Size = 0;

				// Çerçevenin İçinde Kalan (Akı) Alanını Boya
				int boyaliNoktaSayisi = 100;
				double[] xsBoyali = new double[boyaliNoktaSayisi];
				double[] BsBoyali = new double[boyaliNoktaSayisi];
				double[] sifirlar = new double[boyaliNoktaSayisi];

				double boyaliAdim = (x2 - x1) / (boyaliNoktaSayisi - 1);
				for (int i = 0; i < boyaliNoktaSayisi; i++)
				{
					double oAnkiX = x1 + (i * boyaliAdim);
					xsBoyali[i] = oAnkiX;

					ifade.Parameters["x"] = oAnkiX;
					BsBoyali[i] = InputParser.ParseSafe(ifade.Evaluate());
					sifirlar[i] = 0;
				}

				var fill = plotEkrani.Plot.Add.FillY(xsBoyali, BsBoyali, sifirlar);
				fill.FillColor = ScottPlot.Colors.MediumSeaGreen.WithOpacity(0.5);

				var ustCizgi = plotEkrani.Plot.Add.Scatter(xsBoyali, BsBoyali);
				ustCizgi.LineStyle.Color = ScottPlot.Colors.DarkGreen;
				ustCizgi.LineStyle.Width = 3;
				ustCizgi.MarkerStyle.Size = 0;

				// Eksen Ayarları
				plotEkrani.Plot.Add.HorizontalLine(0, width: 1, color: ScottPlot.Colors.Black);
				plotEkrani.Plot.Axes.Bottom.Label.Text = "Konum (x) [Metre]";
				plotEkrani.Plot.Axes.Left.Label.Text = "Manyetik Alan B(x) [Tesla]";
				plotEkrani.Plot.Axes.Title.Label.Text = $"Manyetik Akı Dağılımı (Yeşil Alan = İntegral)";

				plotEkrani.Plot.Axes.AutoScale();
				plotEkrani.Refresh();
			}
			catch
			{
				// Geçersiz formül girildiğinde grafiği temizle
				plotEkrani.Plot.Clear();
				plotEkrani.Refresh();
			}
		}
		// RL Devresi Geçici Rejim (Transient) Grafiği
		public static void RLGrafigiCiz(FormsPlot plotEkrani, double V, double R, double L, string durum)
		{
			try
			{
				plotEkrani.Plot.Clear();

				double tau = L / R;
				double I_max = V / R;

				int noktaSayisi = 500;
				double[] ts = new double[noktaSayisi];
				double[] akimlar = new double[noktaSayisi];
				double[] voltajlar = new double[noktaSayisi];

				// Sistemi 5 Tau süresince çizelim (Sistem 5 Tau'da %99 kararlı hale gelir)
				double maxZaman = 5 * tau;
				double adim = maxZaman / (noktaSayisi - 1);

				bool sarjMi = durum.Contains("Şarj");

				for (int i = 0; i < noktaSayisi; i++)
				{
					double t = i * adim;
					ts[i] = t;

					if (sarjMi)
					{
						// Şarj: Akım yükselir, Bobin voltajı (Zıt EMK) sönümlenir
						akimlar[i] = I_max * (1 - Math.Exp(-t / tau));
						voltajlar[i] = V * Math.Exp(-t / tau);
					}
					else
					{
						// Deşarj: Akım sönümlenir, Bobin voltajı aniden eksiye inip sıfıra sönümlenir
						akimlar[i] = I_max * Math.Exp(-t / tau);
						voltajlar[i] = -V * Math.Exp(-t / tau);
					}
				}

				// 1. Akım Grafiği (Sol Eksen - Mavi)
				var akimCizgisi = plotEkrani.Plot.Add.Scatter(ts, akimlar);
				akimCizgisi.LineStyle.Color = ScottPlot.Colors.RoyalBlue;
				akimCizgisi.LineStyle.Width = 3;
				akimCizgisi.MarkerStyle.Size = 0;

				// 2. Voltaj Grafiği (Sağ Eksen - Kırmızı)
				var voltajCizgisi = plotEkrani.Plot.Add.Scatter(ts, voltajlar);
				voltajCizgisi.LineStyle.Color = ScottPlot.Colors.Crimson;
				voltajCizgisi.LineStyle.Width = 3;
				voltajCizgisi.MarkerStyle.Size = 0;
				voltajCizgisi.LineStyle.Pattern = ScottPlot.LinePattern.Dashed; // Voltajı kesik çizgi yapalım karışmasın

				// Çift Eksen (Dual-Axis) Ayarları
				plotEkrani.Plot.Axes.Left.Label.Text = "Akım I(t) [Amper]";
				plotEkrani.Plot.Axes.Left.Label.ForeColor = ScottPlot.Colors.RoyalBlue;

				plotEkrani.Plot.Axes.Right.Label.Text = "Bobin Voltajı V_L(t) [Volt]";
				plotEkrani.Plot.Axes.Right.Label.ForeColor = ScottPlot.Colors.Crimson;
				plotEkrani.Plot.Axes.Right.IsVisible = true; // Sağ ekseni görünür yap

				// Voltaj çizgisini sağ eksene bağla
				voltajCizgisi.Axes.YAxis = plotEkrani.Plot.Axes.Right;

				plotEkrani.Plot.Axes.Bottom.Label.Text = "Zaman (t) [Saniye]";
				plotEkrani.Plot.Axes.Title.Label.Text = sarjMi ? "RL Devresi - Şarj (Akımın Yükselişi)" : "RL Devresi - Deşarj (Sönümlenme)";

				plotEkrani.Plot.Add.HorizontalLine(0, width: 1, color: ScottPlot.Colors.Black); // Sıfır çizgisi

				plotEkrani.Plot.Axes.AutoScale();
				plotEkrani.Refresh();
			}
			catch { }
		}
		// Faraday Akı ve Türev (EMK) Grafiği
		public static void FaradayGrafigiCiz(FormsPlot plotEkrani, int N, double r_cm, double v)
		{
			try
			{
				plotEkrani.Plot.Clear();

				int noktaSayisi = 500;
				double[] ts = new double[noktaSayisi];
				double[] akilar = new double[noktaSayisi];
				double[] emklar = new double[noktaSayisi];

				double A = Math.PI * Math.Pow(r_cm / 100.0, 2);
				double B_max = 0.5;
				double w = 0.1;

				// Mıknatısın hızına göre simülasyon süresini otomatik ayarla (-0.5m'den +0.5m'ye)
				double tBaslangic = -0.3 / v;
				double tBitis = 0.3 / v;
				double adim = (tBitis - tBaslangic) / (noktaSayisi - 1);

				for (int i = 0; i < noktaSayisi; i++)
				{
					double t = tBaslangic + (i * adim);
					ts[i] = t;

					// Konum: x = v * t (t=0 anında mıknatıs bobinin tam ortasında)
					double x = v * t;

					// Akı Denklemi: Çan eğrisi (Gauss fonksiyonu)
					double aki = B_max * A * Math.Exp(-(x * x) / (w * w));
					akilar[i] = aki * 1000; // Ekranda düzgün görünsün diye miliWeber (mWb) yapıyoruz

					// Faraday Yasası: EMF = -N * d(Phi)/dt
					// Çan eğrisinin türevi: d(Phi)/dt = Phi * (-2 * x * v / w^2)
					double dAkidt = aki * (-2 * x * v / (w * w));
					emklar[i] = -N * dAkidt;
				}

				// 1. Akı Grafiği (Sol Eksen - Mavi)
				var akiCizgisi = plotEkrani.Plot.Add.Scatter(ts, akilar);
				akiCizgisi.LineStyle.Color = ScottPlot.Colors.RoyalBlue;
				akiCizgisi.LineStyle.Width = 3;
				akiCizgisi.MarkerStyle.Size = 0;

				// 2. Voltaj (EMK) Grafiği (Sağ Eksen - Kırmızı)
				var emkCizgisi = plotEkrani.Plot.Add.Scatter(ts, emklar);
				emkCizgisi.LineStyle.Color = ScottPlot.Colors.Crimson;
				emkCizgisi.LineStyle.Width = 3;
				emkCizgisi.MarkerStyle.Size = 0;
				emkCizgisi.LineStyle.Pattern = ScottPlot.LinePattern.Dashed; // Karışmasın diye kesik çizgi

				// Çift Eksen Ayarları (ForeColor kullanarak)
				plotEkrani.Plot.Axes.Left.Label.Text = "Manyetik Akı (Φ) [mWb]";
				plotEkrani.Plot.Axes.Left.Label.ForeColor = ScottPlot.Colors.RoyalBlue;

				plotEkrani.Plot.Axes.Right.Label.Text = "İndüklenen Voltaj (ε) [Volt]";
				plotEkrani.Plot.Axes.Right.Label.ForeColor = ScottPlot.Colors.Crimson;
				plotEkrani.Plot.Axes.Right.IsVisible = true;
				emkCizgisi.Axes.YAxis = plotEkrani.Plot.Axes.Right;

				plotEkrani.Plot.Axes.Bottom.Label.Text = "Zaman (t) [saniye] (t=0: Mıknatıs Merkezde)";
				plotEkrani.Plot.Axes.Title.Label.Text = "Mıknatıs Geçiş Simülasyonu (Akı ve Türevi)";

				plotEkrani.Plot.Add.HorizontalLine(0, width: 1, color: ScottPlot.Colors.Black); // Merkez sıfır çizgisi
				plotEkrani.Plot.Add.VerticalLine(0, width: 1, color: ScottPlot.Colors.Gray).LineStyle.Pattern = ScottPlot.LinePattern.Dashed;

				plotEkrani.Plot.Axes.AutoScale();
				plotEkrani.Refresh();
			}
			catch { }
		}
		// Kalkülüs: Limit Grafiği
		public static void LimitGrafigiCiz(FormsPlot plotEkrani, string fonksiyon, string tip, double x0, bool limitVarMi, double netLimit)
		{
			try
			{
				plotEkrani.Plot.Clear();

				int noktaSayisi = 1000;
				double[] xs = new double[noktaSayisi];
				double[] ys = new double[noktaSayisi];

				NCalc.Expression ifade = new NCalc.Expression(fonksiyon);
				double F(double x)
				{
					ifade.Parameters["x"] = x;
					double sonuc = InputParser.ParseSafe(ifade.Evaluate());
					// Eğer tam o noktada tanımsızsa (0/0), y değerini NaN (Not a Number) yap ki grafik orada kopsun
					if (double.IsInfinity(sonuc) || double.IsNaN(sonuc)) return double.NaN;
					return sonuc;
				}

				// Çizim aralığını hedefe göre belirle
				double xMin = -10, xMax = 10;
				if (tip.Contains("Sayı"))
				{
					xMin = x0 - 5; xMax = x0 + 5;
				}
				else if (tip.Contains("+ Sonsuz"))
				{
					xMin = 0; xMax = 100; // Sonsuz trendini görmek için
				}
				else if (tip.Contains("- Sonsuz"))
				{
					xMin = -100; xMax = 0;
				}

				double adim = (xMax - xMin) / (noktaSayisi - 1);
				for (int i = 0; i < noktaSayisi; i++)
				{
					xs[i] = xMin + (i * adim);
					ys[i] = F(xs[i]);
				}

				// 1. Fonksiyonu Çiz
				var fCizgisi = plotEkrani.Plot.Add.Scatter(xs, ys);
				fCizgisi.LineStyle.Color = ScottPlot.Colors.RoyalBlue;
				fCizgisi.LineStyle.Width = 3;
				fCizgisi.MarkerStyle.Size = 0;
				

				// 2. Limit Noktasını Göster
				if (limitVarMi && tip.Contains("Sayı"))
				{
					// İçi boş kırmızı yuvarlak (Çünkü fonksiyon o noktada tanımlı olmayabilir ama limiti vardır)
					var nokta = plotEkrani.Plot.Add.Marker(x0, netLimit);
					nokta.MarkerStyle.Shape = ScottPlot.MarkerShape.OpenCircle;
					nokta.MarkerStyle.Size = 12;
					nokta.MarkerStyle.LineColor = ScottPlot.Colors.Crimson;
					nokta.MarkerStyle.FillColor = ScottPlot.Colors.Transparent;

					// X ve Y eksenlerine kesik kılavuz çizgiler
					plotEkrani.Plot.Add.VerticalLine(x0, color: ScottPlot.Colors.Gray).LineStyle.Pattern = ScottPlot.LinePattern.Dashed;
					plotEkrani.Plot.Add.HorizontalLine(netLimit, color: ScottPlot.Colors.Gray).LineStyle.Pattern = ScottPlot.LinePattern.Dashed;
				}
				else if (limitVarMi && tip.Contains("Sonsuz"))
				{
					// Sonsuza giderken bir limite ulaşıyorsa bu Yatay Asimptot'tur
					var asimptot = plotEkrani.Plot.Add.HorizontalLine(netLimit, color: ScottPlot.Colors.Crimson);
					asimptot.LineStyle.Pattern = ScottPlot.LinePattern.Dashed;
					asimptot.LineStyle.Width = 2;
				}

				plotEkrani.Plot.Add.HorizontalLine(0, width: 1, color: ScottPlot.Colors.Black);
				plotEkrani.Plot.Add.VerticalLine(0, width: 1, color: ScottPlot.Colors.Black);

				plotEkrani.Plot.Axes.Title.Label.Text = $"Limit Analizi: f(x) = {fonksiyon}";
				plotEkrani.Plot.Axes.AutoScale();
				plotEkrani.Refresh();
			}
			catch { }
		}
		// Kalkülüs: Genel Fonksiyon Çizici ve Kök Tarayıcı
		// Kalkülüs: Genel Fonksiyon Çizici ve Kök Tarayıcı (Derece Destekli - NCalc 5 Uyumlu)
		public static (double yKesen, int kokSayisi) FonksiyonGrafigiCiz(FormsPlot plotEkrani, string fonksiyon, double xMin, double xMax, bool dereceModu)
		{
			// ESKİ: NCalc.Expression ifade = new NCalc.Expression(fonksiyon);
			// YENİ:
			string duzgunFonk = MatematikMotoru.FonksiyonuDuzenle(fonksiyon);
			NCalc.Expression ifade = new NCalc.Expression(duzgunFonk);
			int noktaSayisi = 2000;
			double[] xs = new double[noktaSayisi];
			double[] ys = new double[noktaSayisi];

		

			// --- NCalc AJAN KODU (Trigonometriyi Hackliyoruz - HasResult Kaldırıldı) ---
			ifade.EvaluateFunction += (name, args) =>
			{
			};
			// ---------------------------------------------------

			double F(double x)
			{
				ifade.Parameters["x"] = x;
				double sonuc = InputParser.ParseSafe(ifade.Evaluate());
				if (double.IsInfinity(sonuc) || double.IsNaN(sonuc)) return double.NaN;
				return sonuc;
			}

			double adim = (xMax - xMin) / (noktaSayisi - 1);
			int kokSayisi = 0;
			double oncekiY = F(xMin);

			try
			{
				plotEkrani.Plot.Clear();

				for (int i = 0; i < noktaSayisi; i++)
				{
					xs[i] = xMin + (i * adim);
					ys[i] = F(xs[i]);

					// Kök bulma (Eksen kesme)
					if (!double.IsNaN(ys[i]) && !double.IsNaN(oncekiY))
					{
						if ((oncekiY > 0 && ys[i] <= 0) || (oncekiY < 0 && ys[i] >= 0))
						{
							kokSayisi++;
							var kokNoktasi = plotEkrani.Plot.Add.Marker(xs[i], 0);
							kokNoktasi.MarkerStyle.Shape = ScottPlot.MarkerShape.FilledCircle;
							kokNoktasi.MarkerStyle.Size = 7;
							kokNoktasi.MarkerStyle.FillColor = ScottPlot.Colors.Crimson;
							kokNoktasi.MarkerStyle.LineColor = ScottPlot.Colors.Crimson;
						}
					}
					oncekiY = ys[i];
				}

				double yKesen = F(0);
			


				var fCizgisi = plotEkrani.Plot.Add.Scatter(xs, ys);
				fCizgisi.LineStyle.Color = ScottPlot.Colors.RoyalBlue;
				fCizgisi.LineStyle.Width = 3;
				fCizgisi.MarkerStyle.Size = 0;

				plotEkrani.Plot.Add.HorizontalLine(0, width: 1, color: ScottPlot.Colors.Black);
				plotEkrani.Plot.Add.VerticalLine(0, width: 1, color: ScottPlot.Colors.Black);

				plotEkrani.Plot.Axes.Title.Label.Text = $"Fonksiyon Grafiği: f(x) = {fonksiyon}";
				plotEkrani.Plot.Axes.AutoScale();
				plotEkrani.Refresh();

				return (yKesen, kokSayisi);
			}
			catch
			{
				plotEkrani.Plot.Clear();
				plotEkrani.Refresh();
				throw;
			}
		}


	}
}
