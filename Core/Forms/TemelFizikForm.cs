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
		private readonly OneDimensionalKinematicsEngine kinematicsEngine = new OneDimensionalKinematicsEngine();
		private readonly WorkEnergyEngine workEngine = new WorkEnergyEngine();
		private readonly WorkEnergyEngine energyEngine = new WorkEnergyEngine();
		private readonly ImpulseMomentumEngine impulseEngine = new ImpulseMomentumEngine();
		private readonly RotationalMotionEngine rotationalEngine = new RotationalMotionEngine();
		private readonly SpringMassEngine springEngine = new SpringMassEngine();
		private readonly SimplePendulumEngine pendulumEngine = new SimplePendulumEngine();
		private readonly ElectricFieldEngine _electricFieldEngine = new ElectricFieldEngine();
		private readonly ElectricForceEngine _electricForceEngine = new ElectricForceEngine();
		private readonly GaussLawEngine _gaussLawEngine = new GaussLawEngine();



		// Sürükleme sırasında her tick'te MessageBox patlamasın diye ayrı bayrak
		private bool _gaussInputsReady = false;



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
		private void btnMenuElectricForce_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlElectricForce);
		}


		private void btnMenuGaussLaw_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlGaussLaw);
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
				kinematicsEngine.Reset();

				kinematicsEngine.InitialVelocity = InputParser.ParseSafe(txtKinInitialVelocity.Text);
				kinematicsEngine.Acceleration = InputParser.ParseSafe(txtKinAcceleration.Text);
				kinematicsEngine.TimeLimit = InputParser.ParseSafe(txtKinTotalTime.Text);

				kinematicsEngine.Calculate();
				rtbKinResults.Text = kinematicsEngine.GetFinalReport(chkShowSteps.Checked);

				// 4. EVRENSEL GRAFİK MOTORUNU ÇAĞIR (Konum - Zaman Grafiği Çiziyoruz)
				ProbeCalc.Core.Visualization.ChartEngine.Draw2DChart(
					plotKin,
					kinematicsEngine.TimePoints,      // X Ekseni: Zaman (s)
					kinematicsEngine.PositionPoints,  // Y Ekseni: Konum (m)
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

					ProjectileMotionEngine projectileEngine = new ProjectileMotionEngine
					{
						InitialVelocity = InputParser.ParseSafe(txtProjInitialVelocity.Text),
						Angle = InputParser.ParseSafe(txtProjAngle.Text)
					};
					projectileEngine.Calculate();
					rtbProjResults.Text = projectileEngine.GetFinalReport(chkShowSteps.Checked);
					// GRAFİĞİ ÇİZDİR!
					ChartEngine.Draw2DChart(plotProj, projectileEngine.TrajectoryX, projectileEngine.TrajectoryY, "Eğik Atış Simülasyonu", "Menzil (m)", "Yükseklik (m)");

				});
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------
		private void btnEnerjiHesapla_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				energyEngine.Reset();

				energyEngine.InitialVelocity = InputParser.ParseSafe(txtEnergyInitialVelocity.Text);
				energyEngine.FirstHeight = InputParser.ParseSafe(txtEnergyFirstHeight.Text);
				energyEngine.FinalHeight = InputParser.ParseSafe(txtEnergyFinalHeight.Text);
				energyEngine.Mass = InputParser.ParseSafe(txtEnergyMass.Text);

				energyEngine.Calculate();

				// Sonuçları yazdır
				rtbWorkEnergyResults.Text = energyEngine.GetFinalReport(chkShowSteps.Checked);

				// Çoklu Enerji Grafiğini Çizdir!
				ProbeCalc.Core.Visualization.ChartEngine.DrawEnergyChart(
					plotWorkEnergy,
					energyEngine.ChartX,
					energyEngine.ChartY_Kinetic,
					energyEngine.ChartY_Potential,
					energyEngine.ChartY_Total
				);
			});


		}
		//---------------------------------------------------------------------------------------------------------------------------------------------
		private void btnWorkCalculate_Click_1(object sender, EventArgs e)
		{

			SafeExecute(() =>
			{
				workEngine.Reset();
				// 1. Kullanıcının arayüze yazdığı "2x^3 + 5x" gibi metni TextBox'tan alıyoruz
				string rawFunction = txtWorkFunction.Text;

				// 2. BAĞLANTIYI KURUYORUZ: Motorumuz o metni alıp x değerine göre çözecek!
				workEngine.ForceFunction = (x) =>
				{
					return ProbeCalc.Core.Utilities.MathParser.Evaluate(rawFunction, x);
				};


				workEngine.StartX = InputParser.ParseSafe(txtWorkStartX.Text);
				workEngine.EndX = InputParser.ParseSafe(txtWorkEndX.Text);


				workEngine.Calculate();

				rtbWorkEnergyResults.Text = workEngine.GetFinalReport(chkShowSteps.Checked);

				ProbeCalc.Core.Visualization.ChartEngine.Draw2DChart(
					plotWorkEnergy,
					workEngine.ChartX,
					workEngine.ChartY_Total,
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
				impulseEngine.Reset();

				// 1. Kullanıcıdan fonksiyonları al ve 't' harflerini 'x'e çevir
				string rawForce = txtForceFuncImpulse.Text;
				string rawMass = txtMassFuncImpulse.Text;
				if (!string.IsNullOrWhiteSpace(rawForce))
					impulseEngine.ForceFunction = (x) => MathParser.Evaluate(rawForce, x);

				if (!string.IsNullOrWhiteSpace(rawMass))
					impulseEngine.MassFunction = (x) => MathParser.Evaluate(rawMass, x);
				impulseEngine.TimeLimit = InputParser.ParseSafe(txtTimeLimitImpulse.Text);
				impulseEngine.InitialVelocity = InputParser.ParseSafe(txtImpulseInitialVel.Text);
				impulseEngine.Calculate();
				// 4.Hesapla ve Raporu Al(GetFinalReport ana sınıftan gelir)

				impulseEngine.Calculate();
				rtbImpulseResults.Text = impulseEngine.GetFinalReport(chkShowSteps.Checked);
				ChartEngine.Draw2DChart(plotImpulse,
				impulseEngine.ChartX,
				impulseEngine.ChartY_Velocity,
				"Roket / Cisim Hız Grafiği",
				"Zaman (saniye)",
				"Hız (m/s)");

			});
		}
		private void btnCalculateRotational_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				rotationalEngine.Reset();
				// 1. Verileri Okuma (Kutulardaki Text özelliklerini al)
				rotationalEngine.GeometryType = cmbGeometry.SelectedItem?.ToString() ?? "İçi Dolu Silindir";
				rotationalEngine.Mass = InputParser.ParseSafe(txtRotMass.Text);
				rotationalEngine.Radius = InputParser.ParseSafe(txtRotRadius.Text);
				rotationalEngine.AppliedForce = InputParser.ParseSafe(txtRotForce.Text);
				rotationalEngine.TimeLimit = InputParser.ParseSafe(txtRotTime.Text);

				// Aerodinamik Sürtünme (Eğer kutu boşsa veya geçersizse 0 kabul et)
				double drag = 0;
				double.TryParse(txtDragCoefRot.Text, out drag);
				rotationalEngine.DragCoefficient = drag;

				// 2. Hesapla ve Raporla
				rotationalEngine.Calculate();
				rtbRotationalResults.Text = rotationalEngine.GetFinalReport(chkShowSteps.Checked);

				// 3. Çift Eksenli Telemetri Grafiğini Çizdir
				ProbeCalc.Core.Visualization.ChartEngine.DrawRotationalTelemetryChart(
					plotRotational, // Kendi kullandığın plot kontrolünün adı
					rotationalEngine.ChartX_Time,
					rotationalEngine.ChartY_RPM,
					rotationalEngine.ChartY_Energy
				);
			});
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

		private void btnCalculateOscillation_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				// Rapor ekranını temizle
				rtbOscillationReport.Clear();

				// Hangi sekmenin açık olduğunu kontrol et (0: Yay, 1: Sarkaç)
				if (tabOscillation.SelectedIndex == 0)
				{
					RunSpringSimulation();
				}
				else if (tabOscillation.SelectedIndex == 1)
				{
					RunPendulumSimulation();
				}
			});
		}
		private void RunSpringSimulation()
		{


			// Yay kutularından verileri okuma (Tamamen İngilizce adlandırmalar)
			springEngine.Mass = InputParser.ParseSafe(txtSpringMass.Text);
			springEngine.TimeLimit = InputParser.ParseSafe(txtSpringTimeLimit.Text);
			springEngine.Amplitude = InputParser.ParseSafe(txtSpringAmplitude.Text);
			springEngine.DampingCoefficient = InputParser.ParseSafe(txtSpringDamping.Text);
			springEngine.SpringConstant = InputParser.ParseSafe(txtSpringConstant.Text);

			springEngine.Calculate();
			rtbOscillationReport.Text = springEngine.SolutionSteps;

		}
		private void RunPendulumSimulation()
		{


			// Sarkaç kutularından verileri okuma
			pendulumEngine.Mass = InputParser.ParseSafe(txtPendulumMass.Text);
			pendulumEngine.TimeLimit = InputParser.ParseSafe(txtPendulumTimeLimit.Text);
			pendulumEngine.Amplitude = InputParser.ParseSafe(txtPendulumAmplitude.Text);
			pendulumEngine.DampingCoefficient = InputParser.ParseSafe(txtPendulumDamping.Text);
			pendulumEngine.Length = InputParser.ParseSafe(txtPendulumLength.Text);
			pendulumEngine.Calculate();
			rtbOscillationReport.Text = pendulumEngine.SolutionSteps;
		}

		private void btnCalculateElectricField_Click(object sender, EventArgs e)
		{

			SafeExecute(() =>
			{
				// 1. Temizlik
				_electricFieldEngine.Reset();

				// 2. Veri Ataması
				double sourceChargeMicroC = InputParser.ParseSafe(txtEFieldSourceCharge.Text);
				double distanceMeter = InputParser.ParseSafe(txtEFieldDistance.Text);

				// Kullanıcı μC girer, motor SI (C) bekler -> dönüşüm burada, UI katmanında
				_electricFieldEngine.SourceCharge = sourceChargeMicroC * 1e-6;
				_electricFieldEngine.Distance = distanceMeter;

				// 3. İşlem
				_electricFieldEngine.Calculate();

				// 4. Çıktı — rapor
				rtbEField.Text = _electricFieldEngine.GetFinalReport(chkShowSteps.Checked);

				// 4. Çıktı — grafik (E'nin r'ye göre 1/r² azalışı)
				ChartEngine.Draw2DChart(
					plotElectricField,
					_electricFieldEngine.DistanceX,
					_electricFieldEngine.FieldY,
					"Elektrik Alan vs Uzaklık Grafiği",
					"Mesafe (r)  [m]",
					"Elektrik Alan (E)  [N/C]");
			});
		}

		private void btnCalculateEForce_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				// 1. Temizlik
				_electricForceEngine.Reset();

				// 2. Veri Ataması
				double charge1MicroC = InputParser.ParseSafe(txtEForceCharge1.Text);
				double charge2MicroC = InputParser.ParseSafe(txtEForceCharge2.Text);
				double distanceMeter = InputParser.ParseSafe(txtEForceDistance.Text);

				_electricForceEngine.Charge1 = charge1MicroC * 1e-6;
				_electricForceEngine.Charge2 = charge2MicroC * 1e-6;
				_electricForceEngine.Distance = distanceMeter;

				// 3. İşlem
				_electricForceEngine.Calculate();

				// 4. Çıktı — rapor
				rtbElectricalForce.Text =
					_electricForceEngine.GetFinalReport(chkShowSteps.Checked);

				// İtme/çekme niteliğini ayrıca bir Label'da da gösterelim (renkli, dikkat çekici)
				lblEForceNature.Text = _electricForceEngine.ForceNature;
				lblEForceNature.ForeColor = _electricForceEngine.ForceNature.StartsWith("İtme")
					? System.Drawing.Color.OrangeRed
					: System.Drawing.Color.DodgerBlue;

				// 4. Çıktı — grafik (F'nin r'ye göre 1/r² azalışı)
				ChartEngine.Draw2DChart(
					plotElectricalForce,
					_electricForceEngine.DistanceX,
					_electricForceEngine.ForceY,
					"Elektiriksel kuvvet vs uzaklık ",
					"Mesafe (r)  [m]",
					"Coulomb Kuvveti (F)  [N]");
			});
		}
		private void cmbSystemGeometry_SelectedIndexChanged(object sender, EventArgs e)
		{
			_gaussInputsReady = false;

			var geometry = (GaussGeometryType)cmbSystemGeometry.SelectedIndex;

			lblChargeOrDensity.Text = GaussLawEngine.GetChargeLabelText(geometry);
			txtSphereRadius.Enabled = GaussLawEngine.RequiresSphereRadius(geometry);
		}

		// ========================================================================
		// YARDIMCI: TrackBar'ın temsil ettiği gerçek menzili (metre) belirler.
		// Küre modlarında girilmiş R varsa R*5, yoksa/diğer modlarda sabit varsayılan.
		// ========================================================================


		// ========================================================================
		// TRACKBAR HAREKET ETTİKÇE — canlı önizleme. Hata olursa sessizce yutulur;
		// tam doğrulama sadece "Calculate" butonunda (SafeExecute içinde) yapılır.
		// ========================================================================
		private void tbGaussSurface_Scroll(object sender, EventArgs e)
		{
			var geometry = (GaussGeometryType)cmbSystemGeometry.SelectedIndex;
			double enteredRadius = 0;
			try { enteredRadius = InputParser.ParseSafe(txtSphereRadius.Text); } catch { /* henüz girilmemiş olabilir */ }

			double maxRangeMeters = GaussLawEngine.GetSuggestedObservationRange(geometry, enteredRadius);
			double r = (tbGaussSurface.Value / (double)tbGaussSurface.Maximum) * maxRangeMeters;
			if (r <= 0) r = 0.001;

			lblGaussRValue.Text = $"r = {r:F3} m";

			if (!_gaussInputsReady) return;

			try
			{
				_gaussLawEngine.Distance = r;
				_gaussLawEngine.Calculate();

				rtbGaussResult.Text = _gaussLawEngine.GetFinalReport(chkShowSteps.Checked);
				lblGaussRegion.Text = _gaussLawEngine.RegionLabel;

				ChartEngine.Draw2DChart(
					chartGaussLaw,
					_gaussLawEngine.DistanceX,
					_gaussLawEngine.FieldY,
					"Elektrik Alan vs Uzaklık Grafiği",
					"Mesafe (r)  [m]",
					"Elektrik Alan (E)  [N/C]");
			}
			catch
			{
				// Sürükleme sırasında sessizce yut
			}
		}


			 // ========================================================================
			 // HESAPLA BUTONU — tam doğrulama burada (SafeExecute içinde)
			 // ========================================================================


		private void btnCalculateGauss_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				_gaussLawEngine.Reset();

				var geometry = (GaussGeometryType)cmbSystemGeometry.SelectedIndex;
				_gaussLawEngine.GeometryType = geometry;

				double sourceValueMicro = InputParser.ParseSafe(txtTotalChargeOrDensity.Text);
				_gaussLawEngine.SourceValue = sourceValueMicro * 1e-6;

				double enteredRadius = 0;
				if (GaussLawEngine.RequiresSphereRadius(geometry))
				{
					enteredRadius = InputParser.ParseSafe(txtSphereRadius.Text);
					_gaussLawEngine.SphereRadius = enteredRadius;
				}

				double maxRangeMeters = GaussLawEngine.GetSuggestedObservationRange(geometry, enteredRadius);
				double r = (tbGaussSurface.Value / (double)tbGaussSurface.Maximum) * maxRangeMeters;
				_gaussLawEngine.Distance = r > 0 ? r : 0.001;

				_gaussLawEngine.Calculate();
				_gaussInputsReady = true;

				rtbGaussResult.Text = _gaussLawEngine.GetFinalReport(chkShowSteps.Checked);
				lblGaussRegion.Text = _gaussLawEngine.RegionLabel;
				lblGaussRValue.Text = $"r = {_gaussLawEngine.Distance:F3} m";

				ChartEngine.Draw2DChart(
					chartGaussLaw,
					_gaussLawEngine.DistanceX,
					_gaussLawEngine.FieldY,
					" Elektrik Alan vs Uzaklık Grafiği",
					"Mesafe (r)  [m]",
					"Elektrik Alan (E)  [N/C]");
			});
		}
	}
}

