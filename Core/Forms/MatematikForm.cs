using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;
using ScottPlot;
using MathNet.Symbolics;




namespace CalcUni
{
	public partial class MatematikForm : Form
	{
		// --- FONKSİYON İZLEME DEĞİŞKENLERİ ---
		ScottPlot.Plottables.Crosshair fonkIsaretcisi;
		string aktifFonksiyon = "";
		public MatematikForm()
		{
			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
			InitializeComponent();
		}

		public void PaneliGöster(Panel gösterilecekpanel)
		{
			gösterilecekpanel.BringToFront();

		}

		private void btnLimit_Click(object sender, EventArgs e)
		{
			PaneliGöster(pnlLimit);
		}

		private void hvclikgridon_Click(object sender, EventArgs e)
		{

			// 1. Arkada gizlenmiş olan Form1'i (Ana Menüyü) bulup tekrar gösteriyoruz
			Application.OpenForms["formcalcuni"].Show();

			// 2. İşimiz bittiği için şu anki sayfayı (Havacılık) tamamen kapatıyoruz
			this.Close();
		}

		
			private void btnLimitHesapla_Click(object sender, EventArgs e)
		{
			string f_x = txtLimitF.Text;
			string tip = cmbLimitTip.SelectedItem?.ToString() ?? "Belirli Bir Sayı";

			// Sonsuz değilse ve kutuya geçerli bir sayı girilmediyse uyar
			double x0 = 0;
			if (tip.Contains("Sayı") && !double.TryParse(txtLimitX0.Text, out x0))
			{
				MessageBox.Show("Lütfen x0 için geçerli bir sayı girin!", "Uyarı");
				return;
			}

			try
			{
				// 1. Motoru Çalıştır

				var sonuc = MatematikMotoru.LimitHesapla(f_x, tip, x0);
				// 2. Analiz Panosunu Hazırla
				string analizMetni = $"--- LİMİT VE ASİMPTOT ANALİZİ ---\n\n";

				if (tip.Contains("Sayı"))
				{
					analizMetni += $"Soldan Limit (x -> {x0}-): {sonuc.solLimit:F4}\n" +
								   $"Sağdan Limit (x -> {x0}+): {sonuc.sagLimit:F4}\n\n";
				}

				if (sonuc.limitVarMi)
				{
					analizMetni += $"SONUÇ: LİMİT VARDIR.\nL = {sonuc.netLimit:F4}";
					if (tip.Contains("Sonsuz")) analizMetni += " (Yatay Asimptot)";
				}
				else
				{
					analizMetni += $"SONUÇ: LİMİT YOKTUR VEYA SONSUZA IRAKSAKTIR.\n(Sağ ve Sol limitler uyuşmuyor veya değer sonsuza gidiyor)";
				}

				lblLimitSonuc.Text = analizMetni;

				// 3. Grafiği Çiz
				GrafikMotoru.LimitGrafigiCiz(formsPlotLimit, f_x, tip, x0, sonuc.limitVarMi, sonuc.netLimit);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Matematiksel bir hata oluştu. Formülü kontrol edin (Örn: sin(x)/x)\nHata: " + ex.Message, "Hata");
			}
		
		}

		private void cmbLimitTip_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			// Sonsuz seçilirse x0 kutusunu kapat, sayı seçilirse aç
			if (cmbLimitTip.SelectedItem != null && cmbLimitTip.SelectedItem.ToString().Contains("Sonsuz"))
			{
				txtLimitX0.Enabled = false;
				txtLimitX0.Text = "∞";
			}
			else
			{
				txtLimitX0.Enabled = true;
				txtLimitX0.Text = "0"; // Varsayılan bir değer atayalım
			}
		}

		private void btnFonksiyonÇizme_Click(object sender, EventArgs e)
		{
			PaneliGöster(pnlFonksiyonÇizme);
		}

		// --- FONKSİYON İZLEME DEĞİŞKENLERİ ---

		private void btnGraphCiz_Click(object sender, EventArgs e)
		{
			// 1. Kutudaki metni al
			string hamFonk = txtGraphF.Text;

			if (double.TryParse(txtGraphXMin.Text, out double xMin) &&
				double.TryParse(txtGraphXMax.Text, out double xMax))
			{
				if (xMin >= xMax)
				{
					MessageBox.Show("Başlangıç (Min X) değeri, Bitiş (Max X) değerinden küçük olmalıdır!", "Mantık Hatası");
					return;
				}

				try
				{
					// 2. ÖNEMLİ: Grafiğe ham metni değil, temizlenmiş metni gönderiyoruz!
					// Eğer sınıf adın MatematikMotoru (büyük harfle) ise orayı düzeltmeyi unutma.
					// Çizimden hemen önce bunu ekle (Geçici olarak)
					string debugFonk = MatematikMotoru.FonksiyonuDuzenle(txtGraphF.Text);
					// MessageBox.Show("Hesaplanan Formül: " + debugFonk); // Hata gelirse burayı açıp kontrol et
					var analiz = GrafikMotoru.FonksiyonGrafigiCiz(formsPlotGraph, hamFonk, xMin, xMax, chkDerece.Checked);

					string yKesenMetni = double.IsNaN(analiz.yKesen) ? "Tanımsız (Geçmiyor)" : analiz.yKesen.ToString("F3");

					lblGraphSonuc.Text = $"--- FONKSİYON ANALİZİ ---\n\n" +
										 $"Çizim Aralığı: [{xMin}, {xMax}]\n" +
										 $"Y Eksenini Kestiği Nokta f(0): {yKesenMetni}\n" +
										 $"Bulunan Kök (X Kesen) Sayısı: {analiz.kokSayisi} adet";

					// 3. İzleyici için aktif fonksiyonu kaydet
					aktifFonksiyon = hamFonk;
					fonkIsaretcisi = formsPlotGraph.Plot.Add.Crosshair(0, 0);
					fonkIsaretcisi.IsVisible = false;
					fonkIsaretcisi.LineColor = ScottPlot.Colors.Red;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Hata: " + ex.Message, "Sözdizimi Hatası");
				}
			}
			else
			{
				MessageBox.Show("Lütfen X aralıkları için geçerli sayılar girin!", "Uyarı");
			}
		}

		private void formsPlotGraph_MouseLeave(object sender, EventArgs e)
		{
			if (fonkIsaretcisi != null)
			{
				fonkIsaretcisi.IsVisible = false;
				formsPlotGraph.Refresh();
			}
		}

		private void btnEvalHesapla_Click(object sender, EventArgs e)
		{
			
			string hamFonk = txtGraphF.Text; // Ana fonksiyon kutusundan al

			// 1. Kullanıcının girdiği X değerini kontrol et
			if (double.TryParse(txtEvalX.Text, out double hedefX))
			{
				try
				{
					

				}
				catch (Exception ex)
				{
					MessageBox.Show("Hesaplama Hatası: " + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Lütfen geçerli bir X değeri girin (Örn: 5 veya 3.14)");
			}
		}

		private void btnTurevHesapla_Click(object sender, EventArgs e)
		{

			// 1. Girdileri kontrol et
			string fonk = txtTurevF.Text.Replace(",", ".").Replace(" ", "").ToLower();
			if (string.IsNullOrWhiteSpace(fonk)) return;

			if (!int.TryParse(txtTurevN.Text, out int n)) n = 1;

			double? x0Val = null;
			if (double.TryParse(txtTurevX0.Text.Replace(",", "."), out double parsedX0))
			{
				x0Val = parsedX0;
			}

			try
			{
				// 2. Motoru çalıştır
				var sonuc = MatematikMotoru.SembolikTurevCoz(fonk, n, x0Val);

				// 3. Ekrana yazdır
				string rapor = $"--- ANALİZ SONUÇLARI ---\n\n{sonuc.formuller}";

				if (sonuc.sayisalSonuc.HasValue)
				{
					if (double.IsNaN(sonuc.sayisalSonuc.Value))
						rapor += $"\nf^({n})({x0Val}) = Tanımsız (Kritik Nokta)";
					else
						rapor += $"\nf^({n})({x0Val}) = {sonuc.sayisalSonuc.Value:F4}";
				}

				lblTurevSonuc.Text = rapor;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Hata: Fonksiyon formatı uygun değil.\nÖrnek: x^3 * sin(x)\nDetay: " + ex.Message);
			}
		}

		private void btnTurev_Click(object sender, EventArgs e)
		{
			PaneliGöster(pnlTurev);
		}

		private void btnIntegral_Click(object sender, EventArgs e)
		{
			PaneliGöster(pnlIntegral);
		}
		private void btnTaylor_Click(object sender, EventArgs e)
		{
			PaneliGöster(pnlTaylor);
		}

		private void btnIntegHesapla_Click(object sender, EventArgs e)
		{ 
			try
			{
				string fonk = txtIntegF.Text;
				double a = double.Parse(txtIntegA.Text.Replace(",", "."));
				double b = double.Parse(txtIntegB.Text.Replace(",", "."));
				int n = int.Parse(txtIntegN.Text);

				// Hesaplama
				double sonuc = MatematikMotoru.BelirliIntegralHesapla(fonk, a, b, n);

				// Sonucu Yazdır (LaTeX tarzı şık bir görünümle)
				lblIntegSonuc.Text = $"∫ ({fonk}) dx  ≈ {sonuc:F6}\n[Sınırlar: {a}'dan {b}'ye]";
				GrafikMotoru.FonksiyonGrafigiCiz(formsPlotIntegral, fonk, a - (b - a) * 0.5, b + (b - a) * 0.5, true);
				// public static void AlanGrafigiCiz(FormsPlot plotEkrani, string fonksiyonMetni, double x1, double x2, string xEkseniAd, string yEkseniAd, string baslik)
			}
			catch (Exception ex)
			{
				MessageBox.Show("İntegral hesaplanırken bir hata oluştu. Lütfen sınırları ve fonksiyonu kontrol edin.");
			}
		}

		

		private void btnTaylorHesapla_Click_1(object sender, EventArgs e)
		{
			try
			{
				string fonk = txtTaylorF.Text;
				double a = double.Parse(txtTaylorA.Text.Replace(",", "."));
				int n = int.Parse(txtTaylorN.Text);

				string sonuc = MatematikMotoru.TaylorSerisiUret(fonk, a, n);

				lblTaylorSonuc.Text = $"f(x) ≈ {sonuc}";
			}
			catch
			{
				MessageBox.Show("Girişleri kontrol edin. n bir tam sayı, a bir sayı olmalıdır.");
			}

		}
	}

		
	}

