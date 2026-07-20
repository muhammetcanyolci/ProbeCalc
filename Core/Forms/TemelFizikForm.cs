using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProbeCalc.Core.Calculators;
using ProbeCalc.Core.Visualization;
using NCalc;
using ScottPlot;
using ProbeCalc.Core.Utilities;
namespace ProbeCalc
{
	public partial class TemelFizikForm : Form
	{
		public TemelFizikForm()
		{




			InitializeComponent();


			// Kutuları ve listeyi manuel olarak Canlı Hesaplama motoruna bağlıyoruz
			txtKapasitansA.TextChanged += KapasitansCanliHesapla;
			txtKapasitansD.TextChanged += KapasitansCanliHesapla;
			txtKapasitansV.TextChanged += KapasitansCanliHesapla;
			cmbDielektrik.SelectedIndexChanged += KapasitansCanliHesapla;

		}
		/// <summary>
		/// Tüm hesaplama adımlarını güvenli bir try-catch çemberinde çalıştıran merkezi kalkan metodu.
		/// </summary>

		private void SafeExecute(Action calculationStep)
		{
			try
			{
				calculationStep();
			}
			catch (ArgumentOutOfRangeException ex)
			{ // Motorun içindeki o yazdığımız "Açı 90'dan büyük olamaz" gibi hatalar buraya düşer

				MessageBox.Show(ex.Message, "Fiziksel Sınır Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (FormatException)
			{
				// Kullanıcı sayı yerine "abc" gibi harfler girerse program çökmez, buraya düşer
				MessageBox.Show("Lütfen kutucuklara sadece geçerli sayısal değerler giriniz!", "Girdi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				// Ne olduğunu bilmediğimiz, öngörülemeyen diğer tüm çökme hataları için son kale
				MessageBox.Show("Beklenmeyen bir hata oluştu: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


		}





























		private void PaneliGoster(Panel gosterilecekpanel)
		{ gosterilecekpanel.BringToFront(); }



		private void temefizikForm_Load(object sender, EventArgs e)
		{

		}

		private void btnKinematik_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlKinematik);
		}


		private void btnProjectileMotion_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlProjectileMotion);
		}
		private void btnWorkEnergy_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlWorkEnergy);
		}
		private void btnMomentum_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlMomentum1);
		}
		private void btnRotational_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlRotational);
		}

		private void btnOscilattion_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlOscillations);
		}

		private void btnElectricField_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlElectricField);
		}

		private void btnElectricGauss_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlElectricGauss);
		}

		private void btnCapacitance_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlCapacitance);
		}

		private void btnMagneticFields_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlMagneticFields);
		}

		private void btnSourcesOfMagnetic_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlSourcesOfMagnetic);
		}

		private void btnFaraday_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlFaraday);
		}

		private void btnInductance_Click(object sender, EventArgs e)
		{
			PaneliGoster(pnlInductance);
		}



		private void btnHesaplaKinematik_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				// 1. MOTORU ÇAĞIR VE DEĞERLERİ VER
				OneDimensionalKinematicsEngine engine = new OneDimensionalKinematicsEngine();

				engine.InitialVelocity = Convert.ToDouble(txtKinInitialVelocity.Text);
				engine.Acceleration = Convert.ToDouble(txtKinAcceleration.Text);
				engine.TotalTime = Convert.ToDouble(txtKinTotalTime.Text);

				engine.Calculate();
				rtbKinResults.Text = engine.GetFinalReport(chkShowSteps.Checked);

				// 4. EVRENSEL GRAFİK MOTORUNU ÇAĞIR (Konum - Zaman Grafiği Çiziyoruz)
				ProbeCalc.Core.Visualization.ChartEngine.Draw2DChart(
					plotKin,
					engine.TimePoints,      // X Ekseni: Zaman (s)
					engine.PositionPoints,  // Y Ekseni: Konum (m)
					"Konum - Zaman Grafiği",
					"Zaman (Saniye)",
					"Konum (Metre)"
				);
			});


		}

		private void btnEgikAtıs_Click(object sender, EventArgs e)
		{
			SafeExecute
				(() =>
				{

					ProjectileMotionEngine engine = new ProjectileMotionEngine();
					engine.InitialVelocity = Convert.ToDouble(txtProjInitialVelocity.Text);
					engine.Angle = Convert.ToDouble(txtProjAngle.Text);
					engine.Calculate();
					rtbProjResults.Text = engine.GetFinalReport(chkShowSteps.Checked);
					// GRAFİĞİ ÇİZDİR!
					ChartEngine.Draw2DChart(plotProj, engine.TrajectoryX, engine.TrajectoryY, "Eğik Atış Simülasyonu", "Menzil (m)", "Yükseklik (m)");

				});
		}



		private void btnEnerjiHesapla_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				WorkEnergyEngine engine = new WorkEnergyEngine();

				
				engine.InitialVelocity= Convert.ToDouble(txtEnergyInitialVelocity.Text);
				engine.FirstHeight = Convert.ToDouble(txtEnergyFirstHeight.Text);
				engine.FinalHeight = Convert.ToDouble(txtEnergyFinalHeight.Text);
				engine.Mass = Convert.ToDouble(txtEnergyMass.Text);

				engine.Calculate();

				// Sonuçları yazdır
				rtbWorkEnergyResults.Text = engine.GetFinalReport(chkShowSteps.Checked);

				// Çoklu Enerji Grafiğini Çizdir!
				ProbeCalc.Core.Visualization.ChartEngine.DrawEnergyChart(
					plotWorkEnergy,
					engine.ChartX,
					engine.ChartY_Kinetic,
					engine.ChartY_Potential,
					engine.ChartY_Total
				);
			});


		}
		private void btnWorkCalculate_Click_1(object sender, EventArgs e)
		{
		
			SafeExecute(() =>
			{
				WorkEnergyEngine engine = new WorkEnergyEngine();

				// 1. Kullanıcının arayüze yazdığı "2x^3 + 5x" gibi metni TextBox'tan alıyoruz
				string rawFunction = txtWorkFunction.Text; 

				// 2. BAĞLANTIYI KURUYORUZ: Motorumuz o metni alıp x değerine göre çözecek!
				engine.ForceFunction = (x) =>
				{
					return ProbeCalc.Core.Utilities.MathParser.Evaluate(rawFunction, x);
				};

			
				engine.StartX = Convert.ToDouble(txtWorkStartX.Text);
				engine.EndX = Convert.ToDouble(txtWorkEndX.Text);

			
				engine.Calculate();

				
				rtbWorkEnergyResults.Text = engine.GetFinalReport(chkShowSteps.Checked);

				ProbeCalc.Core.Visualization.ChartEngine.Draw2DChart(
					plotWorkEnergy,
					engine.ChartX,
					engine.ChartY_Total,
					"Kuvvet - Konum Grafiği",
					"Konum (Metre)",
					"Kuvvet (Newton)"
				);
			});
		}
		






		private void btnMomentumHesapla_Click(object sender, EventArgs e)
		{
			// Kutulardaki metinleri sayıya çeviriyoruz
			if (double.TryParse(txtM1.Text, out double m1) &&
				double.TryParse(txtV1i.Text, out double v1i) &&
				double.TryParse(txtM2.Text, out double m2) &&
				double.TryParse(txtV2i.Text, out double v2i) &&
				double.TryParse(txtE.Text, out double katsayi))
			{
				// Katsayı kontrolü (0 ile 1 arası olmalı)
				if (katsayi < 0 || katsayi > 1)
				{
					MessageBox.Show("Restitüsyon katsayısı (e) 0 ile 1 arasında olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;

				}

				try
				{
					// Fizik motorundan hesabı çek
					var sonuc = FizikEngines.CarpismayiHesapla(m1, v1i, m2, v2i, katsayi);

					// Sonucu yazdır (lblMomentumSonuc adında bir Label eklemeyi unutma)
					lblMomentumSonuc.Text = $"--- ÇARPIŞMA SONUÇLARI ---\n\n" +
											$"1. Cisim Son Hız (v1f): {sonuc.v1f:F2} m/s\n" +
											$"2. Cisim Son Hız (v2f): {sonuc.v2f:F2} m/s\n" +
											$"Kaybolan Enerji (Isı): {sonuc.keKayip:F2} Joule";
					GrafikMotoru.EnerjiBarGrafigiCiz(formsPlotMomentum, m1, v1i, m2, v2i, sonuc.v1f, sonuc.v2f);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Hesaplama sırasında bir hata oluştu: " + ex.Message, "Hata");
				}
			}
			else
			{
				MessageBox.Show("Lütfen tüm kutuları geçerli sayılarla doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnItmeHesapla_Click(object sender, EventArgs e)


		{
			string fonksiyon = txtFt.Text;

			if (double.TryParse(txtT1.Text, out double t1) &&
				double.TryParse(txtT2.Text, out double t2) &&
				double.TryParse(txtItmeM.Text, out double m) &&
				double.TryParse(txtItmeV1.Text, out double v1))
			{
				if (m <= 0)
				{
					MessageBox.Show("Kütle 0'dan büyük olmalıdır!", "Hata");
					return;
				}

				try
				{
					// 1. Matmatiği çöz
					var sonuc = FizikEngines.ItmeVeSonHizHesapla(fonksiyon, t1, t2, m, v1);

					// 2. Sonucu yazdır (lblItmeSonuc adında bir Label olduğunu varsayıyorum)
					lblItmeSonuc.Text = $"--- İTME VE MOMENTUM ANALİZİ ---\n\n" +
										$"Toplam İtme (J): {sonuc.itme:F2} N·s\n" +
										$"Cismin Son Hızı: {sonuc.v2:F2} m/s";

					// 3. Çarpışma anının integralli grafiğini çiz!
					GrafikMotoru.ItmeGrafigiCiz(formsPlotMomentum, fonksiyon, t1, t2);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Fonksiyon formatı hatalı!\nMatematiksel bir hata oluştu: " + ex.Message, "Hata");
				}
			}
			else
			{
				MessageBox.Show("Lütfen tüm alanları geçerli sayılarla doldurun!", "Uyarı");
			}
		}

		private void btnDonmeHesapla_Click(object sender, EventArgs e)


		{
			// ComboBox'tan seçili metni al
			string geometri = cmbGeometri.SelectedItem?.ToString() ?? "Disk";

			// Kutu kontrolleri
			if (double.TryParse(txtDonmeM.Text, out double m) &&
				double.TryParse(txtDonmeR.Text, out double r) &&
				double.TryParse(txtDonmeF.Text, out double fTeget) &&
				double.TryParse(txtDonmeT.Text, out double t))
			{
				if (m <= 0 || r <= 0 || t <= 0)
				{
					MessageBox.Show("Kütle, yarıçap ve süre 0'dan büyük olmalıdır!", "Hata");
					return;
				}

				try
				{
					// 1. Matematiksel Analizi Yap
					var sonuc = FizikEngines.DonmeDinamiğiHesapla(geometri, m, r, fTeget, t);

					// 2. Sonuçları Ekrana Yazdır (lblDonmeSonuc adında bir Label olduğunu varsayıyorum)
					lblDonmeSonuc.Text = $"--- DÖNME DİNAMİĞİ ANALİZİ ---\n\n" +
										 $"Seçilen Şekil: {geometri}\n" +
										 $"Eylemsizlik Momenti (I): {sonuc.I:F3} kg·m²\n" +
										 $"Üretilen Tork (τ): {sonuc.tork:F2} N·m\n" +
										 $"Son Açısal Hız (ω): {sonuc.omega:F2} rad/s\n" +
										 $"Depolanan Kinetik Enerji: {sonuc.ke:F2} Joule";

					// 3. Simülasyonu Çiz!
					GrafikMotoru.DonmeGorseliCiz(formsPlotDonme, r, fTeget, sonuc.ke, geometri);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Hesaplama hatası: " + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Lütfen tüm alanları geçerli sayılarla doldurun!", "Uyarı");
			}

		}

		private void btnHarmonikHesapla_Click(object sender, EventArgs e)
		{
			string tip = cmbHarmonikTip.SelectedItem?.ToString() ?? "Yay-Kütle";

			if (double.TryParse(txtHarmonikM_L.Text, out double mL) &&
				double.TryParse(txtHarmonikK_G.Text, out double kG) &&
				double.TryParse(txtHarmonikA.Text, out double genlik))
			{
				// Sönüm değeri boş bırakıldıysa veya hatalıysa 0 kabul et (İdeal sistem)
				double sonum = double.TryParse(txtHarmonikSonum.Text, out double s) ? s : 0;

				if (mL <= 0 || kG <= 0)
				{
					MessageBox.Show("Kütle/Uzunluk ve Yay Sabiti/Yerçekimi 0'dan büyük olmalıdır!", "Hata");
					return;
				}

				try
				{
					// 1. Matematik Motoru
					var sonuc = FizikEngines.HarmonikHesapla(tip, mL, kG, genlik);

					// 2. Ekrana Yazdır
					lblHarmonikSonuc.Text = $"--- HARMONİK HAREKET ANALİZİ ---\n\n" +
											$"Sistem: {tip}\n" +
											$"Açısal Frekans (ω): {sonuc.omega:F2} rad/s\n" +
											$"Periyot (T): {sonuc.T:F2} s\n" +
											$"Frekans (f): {sonuc.f:F2} Hz\n" +
											$"Maksimum Hız: {sonuc.vMax:F2} m/s\n" +
											$"Maksimum İvme: {sonuc.aMax:F2} m/s²\n" +
											$"Toplam Enerji: {sonuc.E:F2} J";

					// 3. Grafik Motoru
					GrafikMotoru.HarmonikDalgaCiz(formsPlotHarmonik, genlik, sonuc.omega, sonum);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Hesaplama Hatası: " + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Lütfen zorunlu alanları geçerli sayılarla doldurun!", "Uyarı");
			}
		}

		private void btnElektrikIntegral_Click(object sender, EventArgs e)
		{


			string fonksiyon = txtEx.Text;

			if (double.TryParse(txtElektrikX1.Text, out double x1) &&
				double.TryParse(txtElektrikX2.Text, out double x2) &&
				double.TryParse(txtTasinanQ.Text, out double q))
			{
				try
				{
					// 1. İntegrali Çöz
					var sonuc = FizikEngines.ElektrikPotansiyelIntegralHesapla(fonksiyon, x1, x2, q);

					// 2. Ekrana Yazdır
					lblElektrikIntegralSonuc.Text = $"--- POTANSİYEL VE İŞ ANALİZİ ---\n\n" +
													$"Potansiyel Fark (ΔV): {sonuc.deltaV:F2} Volt\n" +
													$"Yapılan İş (W): {sonuc.isYapanW:E3} Joule";

					// 3. Eğrinin Altındaki Alanı Çiz
					GrafikMotoru.ElektrikIntegralGrafigiCiz(formsPlotElektrikIntegral, fonksiyon, x1, x2);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Fonksiyon formatı hatalı!\nMatematiksel bir hata oluştu: " + ex.Message, "Hata");
				}
			}
			else
			{
				MessageBox.Show("Lütfen tüm alanları geçerli sayılarla doldurun!", "Uyarı");
			}

		}

		private void tbGaussYaricap_Scroll(object sender, EventArgs e)
		{


			// TrackBar 1 ile 100 arası döner. 10'a bölerek 0.1 ile 10.0 metre arası hassas "r" değeri elde ediyoruz.
			double r = tbGaussYaricap.Value / 10.0;
			lblGaussR_Deger.Text = $"r = {r:F1} m"; // Yanındaki label'a anlık değeri yaz

			string tip = cmbGaussTip.SelectedItem?.ToString() ?? "Yalıtkan Küre";

			if (double.TryParse(txtGaussQ.Text, out double Q) &&
				double.TryParse(txtGaussR_Cisim.Text, out double R_cisim))
			{
				try
				{
					// 1. Motoru Çalıştır
					var sonuc = FizikEngines.GaussHesapla(tip, Q, R_cisim, r);

					// 2. Anlık Sonuçları Yaz
					lblGaussSonuc.Text = $"--- GAUSS YASASI ANLIK ANALİZ ---\n\n" +
										 $"Kapsanan Yük (Q_iç): {sonuc.Qin:E3} Coulomb\n" +
										 $"Toplam Akı (Φ): {sonuc.Aki:E3} N·m²/C\n" +
										 $"Elektrik Alan (E): {sonuc.E:E3} N/C";


				}
				catch (Exception ex)
				{
					lblGaussSonuc.Text = "Hata: " + ex.Message;
				}
			}

		}
		// --- KUTULARA YAZDIKÇA ÇALIŞAN CANLI HESAPLAMA MOTORU ---
		private void KapasitansCanliHesapla(object sender, EventArgs e)
		{
			if (double.TryParse(txtKapasitansA.Text, out double A_cm2) &&
				double.TryParse(txtKapasitansD.Text, out double d_mm) &&
				double.TryParse(txtKapasitansV.Text, out double V))
			{
				if (A_cm2 <= 0 || d_mm <= 0) return;

				string malzeme = cmbDielektrik.SelectedItem?.ToString() ?? "Boşluk/Hava";
				double kappa = 1.0;
				if (malzeme.Contains("Teflon")) kappa = 2.1;
				else if (malzeme.Contains("Kağıt")) kappa = 3.7;
				else if (malzeme.Contains("Cam")) kappa = 4.7;
				else if (malzeme.Contains("Su")) kappa = 80.0;

				try
				{
					var sonuc = FizikEngines.KapasitansHesapla(A_cm2, d_mm, kappa, V);

					lblKapasitansSonuc.Text = $"--- KAPASİTANS VE ENERJİ ANALİZİ ---\n\n" +
											  $"Sığa (C): {sonuc.C_pF:F2} pF\n" +
											  $"Depolanan Yük (Q): {sonuc.Q_pC:F2} pC\n" +
											  $"Elektrik Alan (E): {sonuc.E_Vm:F2} V/m\n" +
											  $"Depolanan Enerji (U): {sonuc.U_pJ:F2} pJ";


				}
				catch { }
			}
		}

		private void btnFaradayHesapla_Click(object sender, EventArgs e)
		{

			string fonksiyon = txtBx.Text;

			if (double.TryParse(txtFaradayL.Text, out double L) &&
				double.TryParse(txtFaradayX1.Text, out double x1) &&
				double.TryParse(txtFaradayX2.Text, out double x2))
			{
				// Hız (v) opsiyoneldir. Boş veya hatalıysa 0 kabul edilir.
				double v = double.TryParse(txtFaradayV.Text, out double hiz) ? hiz : 0;

				// İntegral sınırları mantıklı olmalı
				if (x1 >= x2)
				{
					MessageBox.Show("Başlangıç konumu (x1), Bitiş konumundan (x2) küçük olmalıdır!", "Hata");
					return;
				}

				try
				{
					// 1. Fizik Motoru
					var sonuc = FizikEngines.FaradayIntegralHesapla(fonksiyon, L, x1, x2, v);

					// 2. Ekrana Yazdır
					lblFaradaySonuc.Text = $"--- MANYETİK AKI VE İNDÜKSİYON ---\n\n" +
										   $"Toplam Akı (Φ_B): {sonuc.Aki:F3} Weber (Wb)\n";

					if (v != 0)
					{
						lblFaradaySonuc.Text += $"Çerçeve Hızı (v): {v:F2} m/s\n" +
												$"İndüklenen Voltaj (ε): {sonuc.EMF:F3} Volt";
					}

					// 3. Grafik Motoru
					GrafikMotoru.FaradayGrafigiCiz(formsPlotFaraday, fonksiyon, x1, x2);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Matematiksel bir hata oluştu. Lütfen B(x) alanına düzgün bir formül yazın (Örn: 2*x veya x*x).\n\nDetay: " + ex.Message, "Hata");
				}
			}
			else
			{
				MessageBox.Show("Lütfen tüm zorunlu alanlara geçerli sayılar girin!", "Uyarı");
			}
		}

		private void hvclikgridon_Click(object sender, EventArgs e)
		{
			Application.OpenForms["formcalcuni"].Show();
			this.Close();

		}


		private void btnRL_Hesapla_Click(object sender, EventArgs e)
		{
			if (double.TryParse(txtRL_V.Text, out double V) &&
				double.TryParse(txtRL_R.Text, out double R) &&
				double.TryParse(txtRL_L.Text, out double L))
			{
				if (R <= 0 || L <= 0)
				{
					MessageBox.Show("Direnç ve İndüktans 0'dan büyük olmalıdır!", "Hata");
					return;
				}

				string durum = cmbRL_Durum.SelectedItem?.ToString() ?? "Şarj";

				try
				{
					// 1. Motoru Çalıştır
					var sonuc = FizikEngines.RLDevresiHesapla(V, R, L);

					// 2. Ekrana Sayısal Verileri Yaz
					lblRL_Sonuc.Text = $"--- RL DEVRESİ ANALİZİ ---\n\n" +
									   $"Zaman Sabiti (τ): {sonuc.tau:F4} Saniye\n" +
									   $"Maksimum Akım (I_max): {sonuc.I_max:F2} Amper\n" +
									   $"Depolanan Max Enerji: {sonuc.U_max:F3} Joule";

					// 3. Eksponansiyel Grafikleri Çiz
					GrafikMotoru.RLGrafigiCiz(formsPlotRL, V, R, L, durum);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Hesaplama Hatası: " + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Lütfen alanlara geçerli sayılar girin!", "Uyarı");
			}

		}

		private void btnFaradayHesapla2_Click(object sender, EventArgs e)
		{

			if (int.TryParse(txtFaradayN.Text, out int N) &&
				double.TryParse(txtFaradayR.Text, out double r_cm) &&
				double.TryParse(txtFaradayV2.Text, out double v))
			{
				if (N <= 0 || r_cm <= 0 || v <= 0)
				{
					MessageBox.Show("Lütfen tüm değerleri sıfırdan büyük girin!", "Uyarı");
					return;
				}

				try
				{
					// 1. Fizik Motoru
					var sonuc = FizikEngines.FaradayJeneratorHesapla(N, r_cm, v);

					// 2. Analiz Panosu
					lblFaradaySonuc2.Text = $"--- JENERATÖR VE FARADAY ANALİZİ ---\n\n" +
										   $"Maksimum Akı Geçişi: {sonuc.maxAki_Wb * 1000:F2} miliWeber\n" +
										   $"Üretilen Pik Voltaj (±): {sonuc.pikEMK_V:F2} Volt";

					// 3. Grafik Motoru
					GrafikMotoru.FaradayGrafigiCiz(formsPlotFaraday2, N, r_cm, v);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Hesaplama Hatası: " + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Lütfen alanlara geçerli sayılar girin!", "Hata");
			}
		}
	}
}
