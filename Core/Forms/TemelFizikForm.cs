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
using MathNet.Numerics;


namespace ProbeCalc
{
	public partial class TemelFizikForm : Form

	{
		private readonly OneDimensionalKinematicsEngine kinematicsEngine = new OneDimensionalKinematicsEngine();
		private readonly WorkEnergyEngine workEnergyEngine = new WorkEnergyEngine();
		private readonly ImpulseMomentumEngine impulseEngine = new ImpulseMomentumEngine();
		private readonly CollisionEngine collisionEngine = new CollisionEngine();
		private readonly RotationalMotionEngine rotationalEngine = new RotationalMotionEngine();
		private readonly SpringMassEngine springEngine = new SpringMassEngine();
		private readonly SimplePendulumEngine pendulumEngine = new SimplePendulumEngine();
		private readonly ElectricFieldEngine _electricFieldEngine = new ElectricFieldEngine();
		private readonly ElectricForceEngine _electricForceEngine = new ElectricForceEngine();
		private readonly GaussLawEngine _gaussLawEngine = new GaussLawEngine();
		private readonly CapacitanceEngine capacitanceEngine= new CapacitanceEngine();
		
		private readonly MagneticForceEngine magneticForceEngine = new MagneticForceEngine();
		private readonly MagneticFieldEngine magneticFieldEngine = new MagneticFieldEngine();
		private readonly FaradayEngine faradayEngine = new FaradayEngine();
		private readonly InductanceEngine _inductanceEngine = new InductanceEngine();




		// Sürükleme sırasında her tick'te MessageBox patlamasın diye ayrı bayrak
		private bool _gaussInputsReady = false;



		public TemelFizikForm()
		{




			InitializeComponent();
			

		}
		private void hvclikgridon_Click(object sender, EventArgs e)
		{
			Application.OpenForms["formProbeCalc"].Show();
			this.Close();

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
		private void btnMenuMagneticForce_Click(object sender, EventArgs e)
		{
			ShowingPanel.ShowPanel(pnlMagneticForce);
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
				workEnergyEngine.Reset();

				workEnergyEngine.InitialVelocity = InputParser.ParseSafe(txtEnergyInitialVelocity.Text);
				workEnergyEngine.FirstHeight = InputParser.ParseSafe(txtEnergyFirstHeight.Text);
				workEnergyEngine.FinalHeight = InputParser.ParseSafe(txtEnergyFinalHeight.Text);
				workEnergyEngine.Mass = InputParser.ParseSafe(txtEnergyMass.Text);

				workEnergyEngine.Calculate();

				// Sonuçları yazdır
				rtbWorkEnergyResults.Text = workEnergyEngine.GetFinalReport(chkShowSteps.Checked);

				// Çoklu Enerji Grafiğini Çizdir!
				ProbeCalc.Core.Visualization.ChartEngine.DrawEnergyChart(
					plotWorkEnergy,
					workEnergyEngine.ChartX,
					workEnergyEngine.ChartY_Kinetic,
					workEnergyEngine.ChartY_Potential,
					workEnergyEngine.ChartY_Total
				);
			});


		}
		//---------------------------------------------------------------------------------------------------------------------------------------------
		private void btnWorkCalculate_Click_1(object sender, EventArgs e)
		{

			SafeExecute(() =>
			{
				workEnergyEngine.Reset();
				// 1. Kullanıcının arayüze yazdığı "2x^3 + 5x" gibi metni TextBox'tan alıyoruz
				string rawFunction = txtWorkFunction.Text;

				// 2. BAĞLANTIYI KURUYORUZ: Motorumuz o metni alıp x değerine göre çözecek!
				workEnergyEngine.ForceFunction = (x) =>
				{
					return ProbeCalc.Core.Utilities.MathParser.Evaluate(rawFunction, x);
				};


				workEnergyEngine.StartX = InputParser.ParseSafe(txtWorkStartX.Text);
				workEnergyEngine.EndX = InputParser.ParseSafe(txtWorkEndX.Text);


				workEnergyEngine.Calculate();
				rtbWorkEnergyResults.Text = workEnergyEngine.GetFinalReport(chkShowSteps.Checked);
				ProbeCalc.Core.Visualization.ChartEngine.Draw2DChart(
					plotWorkEnergy,
					workEnergyEngine.ChartX,
					workEnergyEngine.ChartY_Total,
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
				string secim = cmbGeometry.SelectedItem?.ToString();

				switch (secim)
				{
					case "İnce Çember veya Halka":
						rotationalEngine.GeometryType = RotorGeometryType.HoopOrRing;
						break;
					case "Küre":
						rotationalEngine.GeometryType = RotorGeometryType.Sphere;
						break;
					case "İçi Dolu Silindir":
					default:
						rotationalEngine.GeometryType = RotorGeometryType.SolidCylinderOrDisk;
						break;
				}
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
		{}
		private void btnFaradayHesapla_Click(object sender, EventArgs e)
		{}
		private void btnRL_Hesapla_Click(object sender, EventArgs e)
		{}
		private void btnFaradayHesapla2_Click(object sender, EventArgs e)
		{}
		private void btnCalculateCollision_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{	// 1. Kutulardan vektörel değerleri al
				collisionEngine.Mass1 = InputParser.ParseSafe(txtMass1Collision.Text);
				collisionEngine.Vel1_X = InputParser.ParseSafe(txtVel1XCollision.Text);
				collisionEngine.Vel1_Y = InputParser.ParseSafe(txtVel1YCollision.Text);

				collisionEngine.Mass2 = InputParser.ParseSafe(txtMass2Collision.Text);
				collisionEngine.Vel2_X = InputParser.ParseSafe(txtVel2XCollision.Text);
				collisionEngine.Vel2_Y = InputParser.ParseSafe(txtVel2YCollision.Text);

				collisionEngine.Restitution = InputParser.ParseSafe(txtRestitution.Text);
				// 2. Motoru Çalıştır
				collisionEngine.Calculate();
				rtbCollisionResults.Text = collisionEngine.GetFinalReport(chkShowSteps.Checked);

				// 3. Görselleştir
				ProbeCalc.Core.Visualization.ChartEngine.DrawCollision2DChart(
					plotCollision,
					collisionEngine.ChartPos_X1, collisionEngine.ChartPos_Y1,
					collisionEngine.ChartPos_X2, collisionEngine.ChartPos_Y2
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
			springEngine.Reset();
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

			pendulumEngine.Reset();	
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
			txtSphereRadius.Enabled = GaussLawEngine.RequiresSphereRadius(geometry);}

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
			{}
		} 
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

		private void btnCapacitanceCalculate_Click(object sender, EventArgs e)
		{ SafeExecute(()=>
		{ 
			// 1. Temizlik
			capacitanceEngine.Reset();

			// 2. Veri Ataması
			// ComboBox Items'ı CapacitancePermittivity enum'uyla AYNI SIRADA
			// doldurulmalı (Designer -> Items -> Collection editöründen):
			//   0 -> Vakum   1 -> Su   2 -> Cam   3 -> Kağıt   4 -> Teflon
			capacitanceEngine.Permittivity = (CapacitancePermittivity)cmbCapacitanceMaterial.SelectedIndex;

			capacitanceEngine.Area = InputParser.ParseRequired(txtCapacitanceArea.Text, "Plaka Alanı (A)");
			capacitanceEngine.Distance = InputParser.ParseRequired(txtCapacitanceDistance.Text, "Plakalar Arası Mesafe (d)");
			capacitanceEngine.Voltage = InputParser.ParseSafe(txtCapacitanceVoltage.Text); // 0V fiziksel olarak geçerli, ParseSafe yeterli

			// 3. İşlem
			capacitanceEngine.Calculate();
			// 4. Çıktı — rapor
			rtbCapacitance.Text =
				capacitanceEngine.GetFinalReport(chkShowSteps.Checked);
		});
		}

		private void btnFaradayCalculate_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				faradayEngine.Reset();

				var mode = (FaradayMode)tabFaradayMode.SelectedIndex;
				faradayEngine.Mode = mode;

				switch (mode)
				{
					case FaradayMode.FixedLoopChangingField:
						faradayEngine.Turns = InputParser.ParseRequired(txtFL_Turns.Text, "Sarım Sayısı (N)");
						faradayEngine.Area = InputParser.ParseRequired(txtFL_Area.Text, "Alan (A)");
						faradayEngine.AngleDegrees = InputParser.ParseSafe(txtFL_Angle.Text); // boşsa 0°
						faradayEngine.InitialMagneticField = InputParser.ParseSafe(txtFL_B1.Text);
						faradayEngine.FinalMagneticField = InputParser.ParseSafe(txtFL_B2.Text);
						faradayEngine.DeltaTime = InputParser.ParseRequired(txtFL_DeltaT.Text, "Geçen Süre (Δt)");
						break;

					case FaradayMode.MotionalEMF:
						faradayEngine.ConstantMagneticField = InputParser.ParseRequired(txtME_ConstB.Text, "Manyetik Alan (B)");
						faradayEngine.RodLength = InputParser.ParseRequired(txtME_RodLength.Text, "Çubuk Uzunluğu (L)");
						faradayEngine.Velocity = InputParser.ParseRequired(txtME_Velocity.Text, "Hız (v)");
						break;

					case FaradayMode.RotatingGenerator:
						faradayEngine.Turns = InputParser.ParseRequired(txtRG_Turns.Text, "Sarım Sayısı (N)");
						faradayEngine.Area = InputParser.ParseRequired(txtRG_Area.Text, "Alan (A)");
						faradayEngine.ConstantMagneticField = InputParser.ParseRequired(txtRG_ConstB.Text, "Manyetik Alan (B)");
						faradayEngine.Frequency = InputParser.ParseRequired(txtRG_Frequency.Text, "Frekans (f)");
						break;
				}

				faradayEngine.Calculate();
				rtbFaradayResult.Text = faradayEngine.GetFinalReport(chkShowSteps.Checked);
				lblFaradayLenz.Text = faradayEngine.LenzDirectionNote;

				string xLabel = mode == FaradayMode.MotionalEMF ? "Hız (v)  [m/s]" : "Zaman (t)  [s]";
				string yLabel = mode == FaradayMode.FixedLoopChangingField ? "Manyetik Akı (Φ)  [Weber]" : "İndüklenen EMK (ε)  [Volt]";
				string title;
				if (mode == FaradayMode.MotionalEMF)
					title = "EMK - Hız Grafiği";
				else if (mode == FaradayMode.RotatingGenerator)
					title = "AC Gerilim - Zaman Grafiği (Sinüzoidal)";
				else
					title = "Manyetik Akı - Zaman Grafiği";

				ChartEngine.Draw2DChart(plotFaraday, faradayEngine.ChartX, faradayEngine.ChartY, title, xLabel, yLabel);
			});

		}

		private void btnMagForceCalculate_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				magneticForceEngine.Reset();

				var mode = (MagneticForceMode)tabMagForceMode.SelectedIndex;
				magneticForceEngine.Mode = mode;

				bool usesFunction;

				if (mode == MagneticForceMode.MovingCharge)
				{
					magneticForceEngine.Charge = InputParser.ParseRequired(txtMC_Charge.Text, "Yük (q)");

					bool vIsFunction = MathParser.TryParseConstantOrFunction(txtMC_Velocity.Text,
						out double vConst, out Func<double, double> vFunc);
					magneticForceEngine.Velocity = vConst;
					magneticForceEngine.VelocityFunction = vFunc;

					bool bIsFunction = MathParser.TryParseConstantOrFunction(txtMC_BField.Text,
						out double bConst, out Func<double, double> bFunc);
					magneticForceEngine.MagneticField = bConst;
					magneticForceEngine.MagneticFieldFunction = bFunc;

					magneticForceEngine.AngleDegrees = string.IsNullOrWhiteSpace(txtMC_Angle.Text)
						? 90
						: InputParser.ParseSafe(txtMC_Angle.Text);

					usesFunction = vIsFunction || bIsFunction;

					if (usesFunction)
					{
						magneticForceEngine.DeltaTime = InputParser.ParseRequired(txtMC_DeltaTime.Text, "Geçen Süre (Δt)");
					}
				}
				else // CurrentCarryingWire
				{
					bool iIsFunction = MathParser.TryParseConstantOrFunction(txtCW_Current.Text,
						out double iConst, out Func<double, double> iFunc);
					magneticForceEngine.Current = iConst;
					magneticForceEngine.CurrentFunction = iFunc;

					magneticForceEngine.WireLength = InputParser.ParseRequired(txtCW_WireLength.Text, "Tel Uzunluğu (L)");

					bool bIsFunction = MathParser.TryParseConstantOrFunction(txtCW_BField.Text,
						out double bConst, out Func<double, double> bFunc);
					magneticForceEngine.MagneticField = bConst;
					magneticForceEngine.MagneticFieldFunction = bFunc;

					magneticForceEngine.AngleDegrees = string.IsNullOrWhiteSpace(txtCW_Angle.Text)
						? 90
						: InputParser.ParseSafe(txtCW_Angle.Text);

					usesFunction = iIsFunction || bIsFunction;

					if (usesFunction)
					{
						magneticForceEngine.DeltaTime = InputParser.ParseRequired(txtCW_DeltaTime.Text, "Geçen Süre (Δt)");
					}
				}

				magneticForceEngine.Calculate();
				rtbMagForceResult.Text = magneticForceEngine.GetFinalReport(chkShowSteps.Checked);

				if (magneticForceEngine.IsFunctionMode)
				{
					ChartEngine.Draw2DChart(
						chartMagForce,
						magneticForceEngine.ChartX_Time,
						magneticForceEngine.ChartY_Force,
						"Manyetik Kuvvet - Zaman Grafiği",
						"Zaman (t)  [s]",
						"Kuvvet (F)  [N]");
				}
				else
				{
					chartMagForce.Plot.Clear();
					chartMagForce.Refresh();
				}
			});
		}

		private void btnMagFieldcalculate_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				magneticFieldEngine.Reset();

				var source = (MagneticFieldSource)tabMagFieldSource.SelectedIndex;
				magneticFieldEngine.Source = source;

				if (source == MagneticFieldSource.LongStraightWire)
				{
					magneticFieldEngine.Current = InputParser.ParseRequired(txtWire_Current.Text, "Akım (I)");
					magneticFieldEngine.DistanceFromWire = InputParser.ParseRequired(txtWire_Distance.Text, "Telden Uzaklık (r)");
				}
				else // Solenoid
				{
					magneticFieldEngine.Current = InputParser.ParseRequired(txtSol_Current.Text, "Akım (I)");
					magneticFieldEngine.TotalTurns = InputParser.ParseRequired(txtSol_Turns.Text, "Toplam Sarım Sayısı (N)");
					magneticFieldEngine.SolenoidLength = InputParser.ParseRequired(txtSol_Length.Text, "Solenoid Uzunluğu (L)");
				}

				magneticFieldEngine.Calculate();

				rtbMagFieldResult.Text = magneticFieldEngine.GetFinalReport(chkShowSteps.Checked);

				string xLabel = source == MagneticFieldSource.LongStraightWire ? "Telden Uzaklık (r)  [m]" : "Akım (I)  [A]";
				string title = source == MagneticFieldSource.LongStraightWire
					? "Manyetik Alan - Uzaklık Grafiği"
					: "Manyetik Alan - Akım Grafiği (Solenoid İçi)";

				ChartEngine.Draw2DChart(
					chartMagField,
					magneticFieldEngine.ChartX,
					magneticFieldEngine.ChartY_Field,
					title,
					xLabel,
					"Manyetik Alan (B)  [Tesla]");
			});
		}

		private void btnInductanceCalculate_Click(object sender, EventArgs e)
		{
			SafeExecute(() =>
			{
				_inductanceEngine.Reset();

				var mode = (InductanceMode)tabInductanceMode.SelectedIndex;
				_inductanceEngine.Mode = mode;

				if (mode == InductanceMode.SelfInductance)
				{
					_inductanceEngine.Turns1 = InputParser.ParseRequired(txtSelf_Turns.Text, "Sarım Sayısı (N)");
					_inductanceEngine.Area = InputParser.ParseRequired(txtSelf_Area.Text, "Kesit Alanı (A)");
					_inductanceEngine.Length = InputParser.ParseRequired(txtSelf_Length.Text, "Uzunluk (l)");
					_inductanceEngine.InitialCurrent = InputParser.ParseSafe(txtSelf_I1.Text);
					_inductanceEngine.FinalCurrent = InputParser.ParseSafe(txtSelf_I2.Text);
					_inductanceEngine.DeltaTime = InputParser.ParseRequired(txtSelf_DeltaT.Text, "Geçen Süre (Δt)");
				}
				else // MutualInductance
				{
					_inductanceEngine.Turns1 = InputParser.ParseRequired(txtMutual_Turns1.Text, "Sarım Sayısı (N1)");
					_inductanceEngine.Turns2 = InputParser.ParseRequired(txtMutual_Turns2.Text, "Sarım Sayısı (N2)");
					_inductanceEngine.Area = InputParser.ParseRequired(txtMutual_Area.Text, "Kesit Alanı (A)");
					_inductanceEngine.Length = InputParser.ParseRequired(txtMutual_Length.Text, "Uzunluk (l)");
					_inductanceEngine.InitialCurrent = InputParser.ParseSafe(txtMutual_I1.Text);
					_inductanceEngine.FinalCurrent = InputParser.ParseSafe(txtMutual_I2.Text);
					_inductanceEngine.DeltaTime = InputParser.ParseRequired(txtMutual_DeltaT.Text, "Geçen Süre (Δt)");
				}

				_inductanceEngine.Calculate();

				rtbInductanceResult.Text = _inductanceEngine.GetFinalReport(chkShowSteps.Checked);

				ChartEngine.Draw2DChart(
					chartInductance,
					_inductanceEngine.ChartX_Time,
					_inductanceEngine.ChartY_Current,
					"Akım - Zaman Grafiği",
					"Zaman (t)  [s]",
					"Akım (I)  [A]");
			});
		}
	}
}

