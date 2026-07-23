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
using ProbeCalc.Core.Base;


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
		private void btnKinematik_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlKinematik);
		}


		private void btnProjectileMotion_Click_1(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlProjectileMotion);
		}
		private void btnWorkEnergy_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlWorkEnergy);
		}
		private void btnImpulse_Click_1(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlImpulse);
		}
		private void btnCollision_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlCollision);
		}
		private void btnRotational_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlRotational);
		}

		private void btnOscilattion_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlOscillations);
		}

		private void btnElectricField_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlElectricField);
		}

		private void btnElectricGauss_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlElectricGauss);
		}

		private void btnCapacitance_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlCapacitance);
		}

		private void btnMagneticFields_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlMagneticFields);
		}

		private void btnSourcesOfMagnetic_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlSourcesOfMagnetic);
		}

		private void btnFaraday_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlFaraday);
		}

		private void btnInductance_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlInductance);
		}


		//---------------------------------------------------------------------------------------------------------------------------------------------
		private void btnHesaplaKinematik_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				// 1. MOTORU ÇAĞIR VE DEĞERLERİ VER
				OneDimensionalKinematicsEngine engine = new OneDimensionalKinematicsEngine();

				engine.InitialVelocity = InputParser.ParseSafe(txtKinInitialVelocity.Text);
				engine.Acceleration = InputParser.ParseSafe(txtKinAcceleration.Text);
				engine.TimeLimit = InputParser.ParseSafe(txtKinTotalTime.Text);

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
		//---------------------------------------------------------------------------------------------------------------------------------------------
		private void btnEgikAtıs_Click(object sender, EventArgs e)
		{
			SafeExecute
				(() =>
				{

					ProjectileMotionEngine engine = new ProjectileMotionEngine();
					engine.InitialVelocity = InputParser.ParseSafe(txtProjInitialVelocity.Text);
					engine.Angle = InputParser.ParseSafe(txtProjAngle.Text);
					engine.Calculate();
					rtbProjResults.Text = engine.GetFinalReport(chkShowSteps.Checked);
					// GRAFİĞİ ÇİZDİR!
					ChartEngine.Draw2DChart(plotProj, engine.TrajectoryX, engine.TrajectoryY, "Eğik Atış Simülasyonu", "Menzil (m)", "Yükseklik (m)");

				});
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------
		private void btnEnerjiHesapla_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				WorkEnergyEngine engine = new WorkEnergyEngine();

				
				engine.InitialVelocity= InputParser.ParseSafe(txtEnergyInitialVelocity.Text);
				engine.FirstHeight = InputParser.ParseSafe(txtEnergyFirstHeight.Text);
				engine.FinalHeight = InputParser.ParseSafe(txtEnergyFinalHeight.Text);
				engine.Mass = InputParser.ParseSafe(txtEnergyMass.Text);

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
		//---------------------------------------------------------------------------------------------------------------------------------------------
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

			
				engine.StartX = InputParser.ParseSafe(txtWorkStartX.Text);
				engine.EndX = InputParser.ParseSafe(txtWorkEndX.Text);

			
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


		//---------------------------------------------------------------------------------------------------------------------------------------------
		private void btnCalculateImpulse_Click_1(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{	
				// ImpulseMomentumEngine classından nesne üretildi
				ImpulseMomentumEngine engine = new ImpulseMomentumEngine();
				// 1. Kullanıcıdan fonksiyonları al ve 't' harflerini 'x'e çevir
				string rawForce = txtForceFuncImpulse.Text.ToLower().Replace("t", "x");
				string rawMass = txtMassFuncImpulse.Text.ToLower().Replace("t", "x");
				if (!string.IsNullOrWhiteSpace(rawForce))
					engine.ForceFunction = (x) => MathParser.Evaluate(rawForce, x);

				if (!string.IsNullOrWhiteSpace(rawMass))
					engine.MassFunction = (x) => MathParser.Evaluate(rawMass, x);
				engine.TimeLimit = InputParser.ParseSafe(txtTimeLimitImpulse.Text);
				engine.InitialVelocity = InputParser.ParseSafe(txtImpulseInitialVel.Text);
				engine.Calculate();
				// 4.Hesapla ve Raporu Al(GetFinalReport ana sınıftan gelir)

				engine.Calculate();
				rtbImpulseResults.Text = engine.GetFinalReport(chkShowSteps.Checked);
				ChartEngine.Draw2DChart(plotImpulse,
				engine.ChartX,
				engine.ChartY_Velocity,
				"Roket / Cisim Hız Grafiği",
				"Zaman (saniye)",
				"Hız (m/s)");

			});
		}
		private void btnCalculateRotational_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				RotationalMotionEngine engine = new RotationalMotionEngine();

				// 1. Verileri Okuma (Kutulardaki Text özelliklerini al)
				engine.GeometryType = cmbGeometry.SelectedItem?.ToString() ?? "İçi Dolu Silindir";
				engine.Mass = InputParser.ParseSafe(txtRotMass.Text);
				engine.Radius = InputParser.ParseSafe(txtRotRadius.Text);
				engine.AppliedForce = InputParser.ParseSafe(txtRotForce.Text);
				engine.TimeLimit = InputParser.ParseSafe(txtRotTime.Text);

				// Aerodinamik Sürtünme (Eğer kutu boşsa veya geçersizse 0 kabul et)
				double drag = 0;
				double.TryParse(txtDragCoefRot.Text, out drag);
				engine.DragCoefficient = drag;

				// 2. Hesapla ve Raporla
				engine.Calculate();
				rtbRotationalResults.Text = engine.GetFinalReport(chkShowSteps.Checked);

				// 3. Çift Eksenli Telemetri Grafiğini Çizdir
				ProbeCalc.Core.Visualization.ChartEngine.DrawRotationalTelemetryChart(
					plotRotational, // Kendi kullandığın plot kontrolünün adı
					engine.ChartX_Time,
					engine.ChartY_RPM,
					engine.ChartY_Energy
				);
			});
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
			Application.OpenForms["formProbeCalc"].Show();
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

		private void btnCalculateCollision_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				CollisionEngine engine = new CollisionEngine();

				// 1. Kutulardan vektörel değerleri al
				engine.Mass1 = InputParser.ParseSafe(txtMass1Collision.Text);
				engine.Vel1_X = InputParser.ParseSafe(txtVel1XCollision.Text);
				engine.Vel1_Y = InputParser.ParseSafe(txtVel1YCollision.Text);

				engine.Mass2 = InputParser.ParseSafe(txtMass2Collision.Text);
				engine.Vel2_X = InputParser.ParseSafe(txtVel2XCollision.Text);
				engine.Vel2_Y = InputParser.ParseSafe(txtVel2YCollision.Text);

				engine.Restitution = InputParser.ParseSafe(txtRestitution.Text);

				// 2. Motoru Çalıştır
				engine.Calculate();
				rtbCollisionResults.Text = engine.GetFinalReport(chkShowSteps.Checked);

				// 3. Görselleştir
				ProbeCalc.Core.Visualization.ChartEngine.DrawCollision2DChart(
					plotCollision,
					engine.ChartPos_X1, engine.ChartPos_Y1,
					engine.ChartPos_X2, engine.ChartPos_Y2
				);
			});
		}


	}
}
