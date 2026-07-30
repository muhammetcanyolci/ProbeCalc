namespace ProbeCalc
{
    partial class TemelFizikForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.pnlSidebar = new System.Windows.Forms.Panel();
			this.btnMenuElectricForce = new System.Windows.Forms.Button();
			this.btnCollision = new System.Windows.Forms.Button();
			this.chkShowSteps = new System.Windows.Forms.CheckBox();
			this.hvclikgridon = new System.Windows.Forms.Button();
			this.btnInductance = new System.Windows.Forms.Button();
			this.btnFaraday = new System.Windows.Forms.Button();
			this.btnMagneticFields = new System.Windows.Forms.Button();
			this.btnCapacitance = new System.Windows.Forms.Button();
			this.btnMenuGaussLaw = new System.Windows.Forms.Button();
			this.btnMenuElectricField = new System.Windows.Forms.Button();
			this.btnOscillation = new System.Windows.Forms.Button();
			this.btnRotational = new System.Windows.Forms.Button();
			this.btnImpulse = new System.Windows.Forms.Button();
			this.btnWorkEnergy = new System.Windows.Forms.Button();
			this.btnProjectileMotion = new System.Windows.Forms.Button();
			this.btnKinematik = new System.Windows.Forms.Button();
			this.pnlKinematik = new System.Windows.Forms.Panel();
			this.plotKin = new ScottPlot.WinForms.FormsPlot();
			this.rtbKinResults = new System.Windows.Forms.RichTextBox();
			this.txtKinTotalTime = new System.Windows.Forms.TextBox();
			this.txtKinAcceleration = new System.Windows.Forms.TextBox();
			this.txtKinInitialVelocity = new System.Windows.Forms.TextBox();
			this.btnKinCalculate = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlProjectileMotion = new System.Windows.Forms.Panel();
			this.rtbProjResults = new System.Windows.Forms.RichTextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.plotProj = new ScottPlot.WinForms.FormsPlot();
			this.txtProjAngle = new System.Windows.Forms.TextBox();
			this.txtProjInitialVelocity = new System.Windows.Forms.TextBox();
			this.btnEgikAtıs = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.pnlMainFizik = new System.Windows.Forms.Panel();
			this.pnlGaussLaw = new System.Windows.Forms.Panel();
			this.lblGaussRegion = new System.Windows.Forms.Label();
			this.chartGaussLaw = new ScottPlot.WinForms.FormsPlot();
			this.rtbGaussResult = new System.Windows.Forms.RichTextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.tbGaussSurface = new System.Windows.Forms.TrackBar();
			this.cmbSystemGeometry = new System.Windows.Forms.ComboBox();
			this.lblGaussRValue = new System.Windows.Forms.Label();
			this.txtSphereRadius = new System.Windows.Forms.TextBox();
			this.txtTotalChargeOrDensity = new System.Windows.Forms.TextBox();
			this.btnCalculateGauss = new System.Windows.Forms.Button();
			this.lblChargeOrDensity = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.pnlElectricForce = new System.Windows.Forms.Panel();
			this.lblEForceNature = new System.Windows.Forms.Label();
			this.rtbElectricalForce = new System.Windows.Forms.RichTextBox();
			this.txtEForceCharge2 = new System.Windows.Forms.TextBox();
			this.txtEForceDistance = new System.Windows.Forms.TextBox();
			this.plotElectricalForce = new ScottPlot.WinForms.FormsPlot();
			this.txtEForceCharge1 = new System.Windows.Forms.TextBox();
			this.btnCalculateEForce = new System.Windows.Forms.Button();
			this.label62 = new System.Windows.Forms.Label();
			this.label63 = new System.Windows.Forms.Label();
			this.label64 = new System.Windows.Forms.Label();
			this.pnlElectricField = new System.Windows.Forms.Panel();
			this.rtbEField = new System.Windows.Forms.RichTextBox();
			this.txtEFieldDistance = new System.Windows.Forms.TextBox();
			this.plotElectricField = new ScottPlot.WinForms.FormsPlot();
			this.txtElektrikX1 = new System.Windows.Forms.TextBox();
			this.txtEFieldSourceCharge = new System.Windows.Forms.TextBox();
			this.btnCalculateElectricField = new System.Windows.Forms.Button();
			this.label29 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.pnlOscillations = new System.Windows.Forms.Panel();
			this.rtbOscillationReport = new System.Windows.Forms.RichTextBox();
			this.tabOscillation = new System.Windows.Forms.TabControl();
			this.tabSpringPage = new System.Windows.Forms.TabPage();
			this.txtSpringConstant = new System.Windows.Forms.TextBox();
			this.Genlik = new System.Windows.Forms.Label();
			this.txtSpringMass = new System.Windows.Forms.TextBox();
			this.txtSpringTimeLimit = new System.Windows.Forms.TextBox();
			this.txtSpringAmplitude = new System.Windows.Forms.TextBox();
			this.txtSpringDamping = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.tabPendulumPage = new System.Windows.Forms.TabPage();
			this.txtPendulumLength = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.txtPendulumMass = new System.Windows.Forms.TextBox();
			this.txtPendulumTimeLimit = new System.Windows.Forms.TextBox();
			this.txtPendulumAmplitude = new System.Windows.Forms.TextBox();
			this.txtPendulumDamping = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.label56 = new System.Windows.Forms.Label();
			this.btnCalculateOscillation = new System.Windows.Forms.Button();
			this.plotOscillation = new ScottPlot.WinForms.FormsPlot();
			this.pnlRotational = new System.Windows.Forms.Panel();
			this.txtDragCoefRot = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.rtbRotationalResults = new System.Windows.Forms.RichTextBox();
			this.cmbGeometry = new System.Windows.Forms.ComboBox();
			this.txtRotTime = new System.Windows.Forms.TextBox();
			this.label79 = new System.Windows.Forms.Label();
			this.txtRotForce = new System.Windows.Forms.TextBox();
			this.txtRotRadius = new System.Windows.Forms.TextBox();
			this.txtRotMass = new System.Windows.Forms.TextBox();
			this.btnCalculateRotational = new System.Windows.Forms.Button();
			this.label81 = new System.Windows.Forms.Label();
			this.label82 = new System.Windows.Forms.Label();
			this.label83 = new System.Windows.Forms.Label();
			this.plotRotational = new ScottPlot.WinForms.FormsPlot();
			this.pnlCollision = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.rtbCollisionResults = new System.Windows.Forms.RichTextBox();
			this.txtVel2YCollision = new System.Windows.Forms.TextBox();
			this.txtVel1YCollision = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.txtRestitution = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.txtVel2XCollision = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.plotCollision = new ScottPlot.WinForms.FormsPlot();
			this.txtVel1XCollision = new System.Windows.Forms.TextBox();
			this.txtMass2Collision = new System.Windows.Forms.TextBox();
			this.txtMass1Collision = new System.Windows.Forms.TextBox();
			this.btnCalculateCollision = new System.Windows.Forms.Button();
			this.label39 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.pnlImpulse = new System.Windows.Forms.Panel();
			this.rtbImpulseResults = new System.Windows.Forms.RichTextBox();
			this.txtImpulseInitialVel = new System.Windows.Forms.TextBox();
			this.label68 = new System.Windows.Forms.Label();
			this.txtTimeLimitImpulse = new System.Windows.Forms.TextBox();
			this.txtMassFuncImpulse = new System.Windows.Forms.TextBox();
			this.txtForceFuncImpulse = new System.Windows.Forms.TextBox();
			this.btnCalculateImpulse = new System.Windows.Forms.Button();
			this.label70 = new System.Windows.Forms.Label();
			this.label76 = new System.Windows.Forms.Label();
			this.label77 = new System.Windows.Forms.Label();
			this.plotImpulse = new ScottPlot.WinForms.FormsPlot();
			this.pnlWorkEnergy = new System.Windows.Forms.Panel();
			this.rtbWorkEnergyResults = new System.Windows.Forms.RichTextBox();
			this.btnWorkCalculate = new System.Windows.Forms.Button();
			this.txtWorkEndX = new System.Windows.Forms.TextBox();
			this.txtWorkStartX = new System.Windows.Forms.TextBox();
			this.txtWorkFunction = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtEnergyMass = new System.Windows.Forms.TextBox();
			this.label74 = new System.Windows.Forms.Label();
			this.plotWorkEnergy = new ScottPlot.WinForms.FormsPlot();
			this.txtEnergyFinalHeight = new System.Windows.Forms.TextBox();
			this.txtEnergyFirstHeight = new System.Windows.Forms.TextBox();
			this.txtEnergyInitialVelocity = new System.Windows.Forms.TextBox();
			this.btnEnergyCalculate = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.pnlSourcesOfMagnetic = new System.Windows.Forms.Panel();
			this.formsPlot7 = new ScottPlot.WinForms.FormsPlot();
			this.label50 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.label52 = new System.Windows.Forms.Label();
			this.textBox22 = new System.Windows.Forms.TextBox();
			this.textBox23 = new System.Windows.Forms.TextBox();
			this.textBox24 = new System.Windows.Forms.TextBox();
			this.button15 = new System.Windows.Forms.Button();
			this.label53 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.label55 = new System.Windows.Forms.Label();
			this.pnlCapacitance = new System.Windows.Forms.Panel();
			this.label20 = new System.Windows.Forms.Label();
			this.cmbDielektrik = new System.Windows.Forms.ComboBox();
			this.lblKapasitansSonuc = new System.Windows.Forms.Label();
			this.txtKapasitansV = new System.Windows.Forms.TextBox();
			this.txtKapasitansD = new System.Windows.Forms.TextBox();
			this.txtKapasitansA = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.pnlInductance = new System.Windows.Forms.Panel();
			this.cmbRL_Durum = new System.Windows.Forms.ComboBox();
			this.label23 = new System.Windows.Forms.Label();
			this.formsPlotRL = new ScottPlot.WinForms.FormsPlot();
			this.lblRL_Sonuc = new System.Windows.Forms.Label();
			this.txtRL_L = new System.Windows.Forms.TextBox();
			this.txtRL_R = new System.Windows.Forms.TextBox();
			this.txtRL_V = new System.Windows.Forms.TextBox();
			this.btnRL_Hesapla = new System.Windows.Forms.Button();
			this.label65 = new System.Windows.Forms.Label();
			this.label66 = new System.Windows.Forms.Label();
			this.label67 = new System.Windows.Forms.Label();
			this.pnlMagneticFields = new System.Windows.Forms.Panel();
			this.txtFaradayV = new System.Windows.Forms.TextBox();
			this.txtFaradayX2 = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.formsPlotFaraday = new ScottPlot.WinForms.FormsPlot();
			this.lblFaradaySonuc = new System.Windows.Forms.Label();
			this.txtFaradayX1 = new System.Windows.Forms.TextBox();
			this.txtFaradayL = new System.Windows.Forms.TextBox();
			this.txtBx = new System.Windows.Forms.TextBox();
			this.btnFaradayHesapla = new System.Windows.Forms.Button();
			this.label47 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.label49 = new System.Windows.Forms.Label();
			this.pnlFaraday = new System.Windows.Forms.Panel();
			this.formsPlotFaraday2 = new ScottPlot.WinForms.FormsPlot();
			this.lblFaradaySonuc2 = new System.Windows.Forms.Label();
			this.txtFaradayV2 = new System.Windows.Forms.TextBox();
			this.txtFaradayR = new System.Windows.Forms.TextBox();
			this.txtFaradayN = new System.Windows.Forms.TextBox();
			this.btnFaradayHesapla2 = new System.Windows.Forms.Button();
			this.label59 = new System.Windows.Forms.Label();
			this.label60 = new System.Windows.Forms.Label();
			this.label61 = new System.Windows.Forms.Label();
			this.pnlSidebar.SuspendLayout();
			this.pnlKinematik.SuspendLayout();
			this.pnlProjectileMotion.SuspendLayout();
			this.pnlMainFizik.SuspendLayout();
			this.pnlGaussLaw.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbGaussSurface)).BeginInit();
			this.pnlElectricForce.SuspendLayout();
			this.pnlElectricField.SuspendLayout();
			this.pnlOscillations.SuspendLayout();
			this.tabOscillation.SuspendLayout();
			this.tabSpringPage.SuspendLayout();
			this.tabPendulumPage.SuspendLayout();
			this.pnlRotational.SuspendLayout();
			this.pnlCollision.SuspendLayout();
			this.pnlImpulse.SuspendLayout();
			this.pnlWorkEnergy.SuspendLayout();
			this.pnlSourcesOfMagnetic.SuspendLayout();
			this.pnlCapacitance.SuspendLayout();
			this.pnlInductance.SuspendLayout();
			this.pnlMagneticFields.SuspendLayout();
			this.pnlFaraday.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(213, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "temelfizik";
			// 
			// pnlSidebar
			// 
			this.pnlSidebar.AutoScroll = true;
			this.pnlSidebar.BackColor = System.Drawing.Color.MidnightBlue;
			this.pnlSidebar.Controls.Add(this.btnMenuElectricForce);
			this.pnlSidebar.Controls.Add(this.btnCollision);
			this.pnlSidebar.Controls.Add(this.chkShowSteps);
			this.pnlSidebar.Controls.Add(this.hvclikgridon);
			this.pnlSidebar.Controls.Add(this.btnInductance);
			this.pnlSidebar.Controls.Add(this.btnFaraday);
			this.pnlSidebar.Controls.Add(this.btnMagneticFields);
			this.pnlSidebar.Controls.Add(this.btnCapacitance);
			this.pnlSidebar.Controls.Add(this.btnMenuGaussLaw);
			this.pnlSidebar.Controls.Add(this.btnMenuElectricField);
			this.pnlSidebar.Controls.Add(this.btnOscillation);
			this.pnlSidebar.Controls.Add(this.btnRotational);
			this.pnlSidebar.Controls.Add(this.btnImpulse);
			this.pnlSidebar.Controls.Add(this.btnWorkEnergy);
			this.pnlSidebar.Controls.Add(this.label1);
			this.pnlSidebar.Controls.Add(this.btnProjectileMotion);
			this.pnlSidebar.Controls.Add(this.btnKinematik);
			this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
			this.pnlSidebar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlSidebar.Name = "pnlSidebar";
			this.pnlSidebar.Size = new System.Drawing.Size(300, 753);
			this.pnlSidebar.TabIndex = 3;
			// 
			// btnMenuElectricForce
			// 
			this.btnMenuElectricForce.BackColor = System.Drawing.Color.LightPink;
			this.btnMenuElectricForce.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMenuElectricForce.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnMenuElectricForce.Location = new System.Drawing.Point(14, 577);
			this.btnMenuElectricForce.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnMenuElectricForce.Name = "btnMenuElectricForce";
			this.btnMenuElectricForce.Size = new System.Drawing.Size(263, 71);
			this.btnMenuElectricForce.TabIndex = 32;
			this.btnMenuElectricForce.Text = "ELEKTİRİK KUVVET";
			this.btnMenuElectricForce.UseVisualStyleBackColor = false;
			this.btnMenuElectricForce.Click += new System.EventHandler(this.btnMenuElectricForce_Click);
			// 
			// btnCollision
			// 
			this.btnCollision.BackColor = System.Drawing.Color.LightPink;
			this.btnCollision.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCollision.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnCollision.Location = new System.Drawing.Point(14, 321);
			this.btnCollision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCollision.Name = "btnCollision";
			this.btnCollision.Size = new System.Drawing.Size(263, 59);
			this.btnCollision.TabIndex = 31;
			this.btnCollision.Text = "ÇARPIŞMA";
			this.btnCollision.UseVisualStyleBackColor = false;
			this.btnCollision.Click += new System.EventHandler(this.btnCollision_Click);
			// 
			// chkShowSteps
			// 
			this.chkShowSteps.AutoSize = true;
			this.chkShowSteps.Location = new System.Drawing.Point(52, 533);
			this.chkShowSteps.Margin = new System.Windows.Forms.Padding(4);
			this.chkShowSteps.Name = "chkShowSteps";
			this.chkShowSteps.Size = new System.Drawing.Size(199, 20);
			this.chkShowSteps.TabIndex = 30;
			this.chkShowSteps.Text = "Hesaplama adımlarnı göster";
			this.chkShowSteps.UseVisualStyleBackColor = true;
			// 
			// hvclikgridon
			// 
			this.hvclikgridon.BackColor = System.Drawing.Color.Red;
			this.hvclikgridon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.hvclikgridon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.hvclikgridon.Location = new System.Drawing.Point(12, 15);
			this.hvclikgridon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.hvclikgridon.Name = "hvclikgridon";
			this.hvclikgridon.Size = new System.Drawing.Size(139, 41);
			this.hvclikgridon.TabIndex = 24;
			this.hvclikgridon.Text = "Geri dön";
			this.hvclikgridon.UseVisualStyleBackColor = false;
			this.hvclikgridon.Click += new System.EventHandler(this.hvclikgridon_Click);
			// 
			// btnInductance
			// 
			this.btnInductance.BackColor = System.Drawing.Color.LightPink;
			this.btnInductance.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInductance.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnInductance.Location = new System.Drawing.Point(13, 1060);
			this.btnInductance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnInductance.Name = "btnInductance";
			this.btnInductance.Size = new System.Drawing.Size(263, 59);
			this.btnInductance.TabIndex = 29;
			this.btnInductance.Text = "İNDÜKTANS";
			this.btnInductance.UseVisualStyleBackColor = false;
			this.btnInductance.Click += new System.EventHandler(this.btnInductance_Click);
			// 
			// btnFaraday
			// 
			this.btnFaraday.BackColor = System.Drawing.Color.LightPink;
			this.btnFaraday.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFaraday.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnFaraday.Location = new System.Drawing.Point(13, 997);
			this.btnFaraday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnFaraday.Name = "btnFaraday";
			this.btnFaraday.Size = new System.Drawing.Size(263, 59);
			this.btnFaraday.TabIndex = 12;
			this.btnFaraday.Text = "BOBİN FARADAY";
			this.btnFaraday.UseVisualStyleBackColor = false;
			this.btnFaraday.Click += new System.EventHandler(this.btnFaraday_Click);
			// 
			// btnMagneticFields
			// 
			this.btnMagneticFields.BackColor = System.Drawing.Color.LightPink;
			this.btnMagneticFields.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMagneticFields.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnMagneticFields.Location = new System.Drawing.Point(14, 910);
			this.btnMagneticFields.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnMagneticFields.Name = "btnMagneticFields";
			this.btnMagneticFields.Size = new System.Drawing.Size(263, 59);
			this.btnMagneticFields.TabIndex = 11;
			this.btnMagneticFields.Text = "FARADAY";
			this.btnMagneticFields.UseVisualStyleBackColor = false;
			this.btnMagneticFields.Click += new System.EventHandler(this.btnMagneticFields_Click);
			// 
			// btnCapacitance
			// 
			this.btnCapacitance.BackColor = System.Drawing.Color.LightPink;
			this.btnCapacitance.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCapacitance.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnCapacitance.Location = new System.Drawing.Point(14, 827);
			this.btnCapacitance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCapacitance.Name = "btnCapacitance";
			this.btnCapacitance.Size = new System.Drawing.Size(263, 75);
			this.btnCapacitance.TabIndex = 9;
			this.btnCapacitance.Text = "KAPASİTANS";
			this.btnCapacitance.UseVisualStyleBackColor = false;
			this.btnCapacitance.Click += new System.EventHandler(this.btnCapacitance_Click);
			// 
			// btnMenuGaussLaw
			// 
			this.btnMenuGaussLaw.BackColor = System.Drawing.Color.LightPink;
			this.btnMenuGaussLaw.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMenuGaussLaw.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnMenuGaussLaw.Location = new System.Drawing.Point(14, 759);
			this.btnMenuGaussLaw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnMenuGaussLaw.Name = "btnMenuGaussLaw";
			this.btnMenuGaussLaw.Size = new System.Drawing.Size(263, 59);
			this.btnMenuGaussLaw.TabIndex = 8;
			this.btnMenuGaussLaw.Text = "GAUSS YASASI";
			this.btnMenuGaussLaw.UseVisualStyleBackColor = false;
			// 
			// btnMenuElectricField
			// 
			this.btnMenuElectricField.BackColor = System.Drawing.Color.LightPink;
			this.btnMenuElectricField.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMenuElectricField.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnMenuElectricField.Location = new System.Drawing.Point(12, 661);
			this.btnMenuElectricField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnMenuElectricField.Name = "btnMenuElectricField";
			this.btnMenuElectricField.Size = new System.Drawing.Size(263, 71);
			this.btnMenuElectricField.TabIndex = 7;
			this.btnMenuElectricField.Text = "ELEKTİRİK ALAN";
			this.btnMenuElectricField.UseVisualStyleBackColor = false;
			this.btnMenuElectricField.Click += new System.EventHandler(this.btnElectricField_Click);
			// 
			// btnOscillation
			// 
			this.btnOscillation.BackColor = System.Drawing.Color.LightPink;
			this.btnOscillation.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOscillation.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnOscillation.Location = new System.Drawing.Point(14, 455);
			this.btnOscillation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnOscillation.Name = "btnOscillation";
			this.btnOscillation.Size = new System.Drawing.Size(263, 59);
			this.btnOscillation.TabIndex = 6;
			this.btnOscillation.Text = "SALINIM HAREKETİ";
			this.btnOscillation.UseVisualStyleBackColor = false;
			this.btnOscillation.Click += new System.EventHandler(this.btnOscilattion_Click);
			// 
			// btnRotational
			// 
			this.btnRotational.BackColor = System.Drawing.Color.LightPink;
			this.btnRotational.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRotational.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnRotational.Location = new System.Drawing.Point(12, 384);
			this.btnRotational.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnRotational.Name = "btnRotational";
			this.btnRotational.Size = new System.Drawing.Size(263, 59);
			this.btnRotational.TabIndex = 5;
			this.btnRotational.Text = "DAİRESEL HAREKET";
			this.btnRotational.UseVisualStyleBackColor = false;
			this.btnRotational.Click += new System.EventHandler(this.btnRotational_Click);
			// 
			// btnImpulse
			// 
			this.btnImpulse.BackColor = System.Drawing.Color.LightPink;
			this.btnImpulse.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnImpulse.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnImpulse.Location = new System.Drawing.Point(12, 258);
			this.btnImpulse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnImpulse.Name = "btnImpulse";
			this.btnImpulse.Size = new System.Drawing.Size(263, 59);
			this.btnImpulse.TabIndex = 4;
			this.btnImpulse.Text = "İTME";
			this.btnImpulse.UseVisualStyleBackColor = false;
			this.btnImpulse.Click += new System.EventHandler(this.btnImpulse_Click_1);
			// 
			// btnWorkEnergy
			// 
			this.btnWorkEnergy.BackColor = System.Drawing.Color.LightPink;
			this.btnWorkEnergy.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnWorkEnergy.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnWorkEnergy.Location = new System.Drawing.Point(12, 194);
			this.btnWorkEnergy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnWorkEnergy.Name = "btnWorkEnergy";
			this.btnWorkEnergy.Size = new System.Drawing.Size(263, 59);
			this.btnWorkEnergy.TabIndex = 3;
			this.btnWorkEnergy.Text = "İŞ-ENERJİ";
			this.btnWorkEnergy.UseVisualStyleBackColor = false;
			this.btnWorkEnergy.Click += new System.EventHandler(this.btnWorkEnergy_Click);
			// 
			// btnProjectileMotion
			// 
			this.btnProjectileMotion.BackColor = System.Drawing.Color.LightPink;
			this.btnProjectileMotion.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnProjectileMotion.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnProjectileMotion.Location = new System.Drawing.Point(12, 129);
			this.btnProjectileMotion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnProjectileMotion.Name = "btnProjectileMotion";
			this.btnProjectileMotion.Size = new System.Drawing.Size(263, 59);
			this.btnProjectileMotion.TabIndex = 2;
			this.btnProjectileMotion.Text = "EĞİK ATIŞ";
			this.btnProjectileMotion.UseVisualStyleBackColor = false;
			this.btnProjectileMotion.Click += new System.EventHandler(this.btnProjectileMotion_Click_1);
			// 
			// btnKinematik
			// 
			this.btnKinematik.BackColor = System.Drawing.Color.LightPink;
			this.btnKinematik.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnKinematik.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnKinematik.Location = new System.Drawing.Point(12, 64);
			this.btnKinematik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnKinematik.Name = "btnKinematik";
			this.btnKinematik.Size = new System.Drawing.Size(263, 59);
			this.btnKinematik.TabIndex = 0;
			this.btnKinematik.Text = "1D KİNEMATİK";
			this.btnKinematik.UseVisualStyleBackColor = false;
			this.btnKinematik.Click += new System.EventHandler(this.btnKinematik_Click);
			// 
			// pnlKinematik
			// 
			this.pnlKinematik.BackColor = System.Drawing.Color.SlateGray;
			this.pnlKinematik.Controls.Add(this.plotKin);
			this.pnlKinematik.Controls.Add(this.rtbKinResults);
			this.pnlKinematik.Controls.Add(this.txtKinTotalTime);
			this.pnlKinematik.Controls.Add(this.txtKinAcceleration);
			this.pnlKinematik.Controls.Add(this.txtKinInitialVelocity);
			this.pnlKinematik.Controls.Add(this.btnKinCalculate);
			this.pnlKinematik.Controls.Add(this.label4);
			this.pnlKinematik.Controls.Add(this.label3);
			this.pnlKinematik.Controls.Add(this.label2);
			this.pnlKinematik.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlKinematik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.pnlKinematik.Location = new System.Drawing.Point(0, 0);
			this.pnlKinematik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlKinematik.Name = "pnlKinematik";
			this.pnlKinematik.Size = new System.Drawing.Size(1283, 753);
			this.pnlKinematik.TabIndex = 4;
			// 
			// plotKin
			// 
			this.plotKin.BackColor = System.Drawing.Color.LavenderBlush;
			this.plotKin.Location = new System.Drawing.Point(307, 334);
			this.plotKin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.plotKin.Name = "plotKin";
			this.plotKin.Size = new System.Drawing.Size(552, 375);
			this.plotKin.TabIndex = 24;
			// 
			// rtbKinResults
			// 
			this.rtbKinResults.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.rtbKinResults.Location = new System.Drawing.Point(797, 9);
			this.rtbKinResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbKinResults.Name = "rtbKinResults";
			this.rtbKinResults.ReadOnly = true;
			this.rtbKinResults.Size = new System.Drawing.Size(484, 318);
			this.rtbKinResults.TabIndex = 23;
			this.rtbKinResults.Text = "";
			// 
			// txtKinTotalTime
			// 
			this.txtKinTotalTime.Location = new System.Drawing.Point(579, 110);
			this.txtKinTotalTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtKinTotalTime.Name = "txtKinTotalTime";
			this.txtKinTotalTime.Size = new System.Drawing.Size(131, 28);
			this.txtKinTotalTime.TabIndex = 6;
			// 
			// txtKinAcceleration
			// 
			this.txtKinAcceleration.Location = new System.Drawing.Point(579, 75);
			this.txtKinAcceleration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtKinAcceleration.Name = "txtKinAcceleration";
			this.txtKinAcceleration.Size = new System.Drawing.Size(131, 28);
			this.txtKinAcceleration.TabIndex = 5;
			// 
			// txtKinInitialVelocity
			// 
			this.txtKinInitialVelocity.Location = new System.Drawing.Point(579, 38);
			this.txtKinInitialVelocity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtKinInitialVelocity.Name = "txtKinInitialVelocity";
			this.txtKinInitialVelocity.Size = new System.Drawing.Size(131, 28);
			this.txtKinInitialVelocity.TabIndex = 4;
			// 
			// btnKinCalculate
			// 
			this.btnKinCalculate.BackColor = System.Drawing.Color.Pink;
			this.btnKinCalculate.Location = new System.Drawing.Point(375, 164);
			this.btnKinCalculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnKinCalculate.Name = "btnKinCalculate";
			this.btnKinCalculate.Size = new System.Drawing.Size(117, 34);
			this.btnKinCalculate.TabIndex = 3;
			this.btnKinCalculate.Text = "Calculate";
			this.btnKinCalculate.UseVisualStyleBackColor = false;
			this.btnKinCalculate.Click += new System.EventHandler(this.btnHesaplaKinematik_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label4.Location = new System.Drawing.Point(371, 75);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(158, 22);
			this.label4.TabIndex = 2;
			this.label4.Text = "Accelaration (a):";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label3.Location = new System.Drawing.Point(371, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 22);
			this.label3.TabIndex = 1;
			this.label3.Text = "Time(t):";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label2.Location = new System.Drawing.Point(371, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(165, 22);
			this.label2.TabIndex = 0;
			this.label2.Text = "First velocity(v0):";
			// 
			// pnlProjectileMotion
			// 
			this.pnlProjectileMotion.BackColor = System.Drawing.Color.SlateGray;
			this.pnlProjectileMotion.Controls.Add(this.rtbProjResults);
			this.pnlProjectileMotion.Controls.Add(this.label24);
			this.pnlProjectileMotion.Controls.Add(this.plotProj);
			this.pnlProjectileMotion.Controls.Add(this.txtProjAngle);
			this.pnlProjectileMotion.Controls.Add(this.txtProjInitialVelocity);
			this.pnlProjectileMotion.Controls.Add(this.btnEgikAtıs);
			this.pnlProjectileMotion.Controls.Add(this.label8);
			this.pnlProjectileMotion.Controls.Add(this.label9);
			this.pnlProjectileMotion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlProjectileMotion.Location = new System.Drawing.Point(0, 0);
			this.pnlProjectileMotion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlProjectileMotion.Name = "pnlProjectileMotion";
			this.pnlProjectileMotion.Size = new System.Drawing.Size(1283, 753);
			this.pnlProjectileMotion.TabIndex = 5;
			// 
			// rtbProjResults
			// 
			this.rtbProjResults.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.rtbProjResults.Location = new System.Drawing.Point(797, 2);
			this.rtbProjResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbProjResults.Name = "rtbProjResults";
			this.rtbProjResults.ReadOnly = true;
			this.rtbProjResults.Size = new System.Drawing.Size(484, 318);
			this.rtbProjResults.TabIndex = 22;
			this.rtbProjResults.Text = "";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(532, 11);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(58, 16);
			this.label24.TabIndex = 21;
			this.label24.Text = "Eğik atış";
			// 
			// plotProj
			// 
			this.plotProj.BackColor = System.Drawing.Color.LavenderBlush;
			this.plotProj.Location = new System.Drawing.Point(315, 321);
			this.plotProj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.plotProj.Name = "plotProj";
			this.plotProj.Size = new System.Drawing.Size(552, 375);
			this.plotProj.TabIndex = 20;
			// 
			// txtProjAngle
			// 
			this.txtProjAngle.Location = new System.Drawing.Point(605, 106);
			this.txtProjAngle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtProjAngle.Name = "txtProjAngle";
			this.txtProjAngle.Size = new System.Drawing.Size(131, 22);
			this.txtProjAngle.TabIndex = 15;
			// 
			// txtProjInitialVelocity
			// 
			this.txtProjInitialVelocity.Location = new System.Drawing.Point(605, 38);
			this.txtProjInitialVelocity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtProjInitialVelocity.Name = "txtProjInitialVelocity";
			this.txtProjInitialVelocity.Size = new System.Drawing.Size(131, 22);
			this.txtProjInitialVelocity.TabIndex = 13;
			// 
			// btnEgikAtıs
			// 
			this.btnEgikAtıs.BackColor = System.Drawing.Color.Pink;
			this.btnEgikAtıs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnEgikAtıs.Location = new System.Drawing.Point(375, 161);
			this.btnEgikAtıs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnEgikAtıs.Name = "btnEgikAtıs";
			this.btnEgikAtıs.Size = new System.Drawing.Size(117, 34);
			this.btnEgikAtıs.TabIndex = 12;
			this.btnEgikAtıs.Text = "Calculate";
			this.btnEgikAtıs.UseVisualStyleBackColor = false;
			this.btnEgikAtıs.Click += new System.EventHandler(this.btnEgikAtıs_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label8.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label8.Location = new System.Drawing.Point(371, 106);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(135, 22);
			this.label8.TabIndex = 10;
			this.label8.Text = "Fırlatma açısı ";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label9.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label9.Location = new System.Drawing.Point(371, 34);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(102, 22);
			this.label9.TabIndex = 9;
			this.label9.Text = "İlk hız(v0):";
			// 
			// pnlMainFizik
			// 
			this.pnlMainFizik.Controls.Add(this.pnlGaussLaw);
			this.pnlMainFizik.Controls.Add(this.pnlElectricForce);
			this.pnlMainFizik.Controls.Add(this.pnlElectricField);
			this.pnlMainFizik.Controls.Add(this.pnlOscillations);
			this.pnlMainFizik.Controls.Add(this.pnlRotational);
			this.pnlMainFizik.Controls.Add(this.pnlCollision);
			this.pnlMainFizik.Controls.Add(this.pnlImpulse);
			this.pnlMainFizik.Controls.Add(this.pnlProjectileMotion);
			this.pnlMainFizik.Controls.Add(this.pnlWorkEnergy);
			this.pnlMainFizik.Controls.Add(this.pnlKinematik);
			this.pnlMainFizik.Controls.Add(this.pnlSourcesOfMagnetic);
			this.pnlMainFizik.Controls.Add(this.pnlCapacitance);
			this.pnlMainFizik.Controls.Add(this.pnlInductance);
			this.pnlMainFizik.Controls.Add(this.pnlMagneticFields);
			this.pnlMainFizik.Controls.Add(this.pnlFaraday);
			this.pnlMainFizik.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMainFizik.Location = new System.Drawing.Point(0, 0);
			this.pnlMainFizik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlMainFizik.Name = "pnlMainFizik";
			this.pnlMainFizik.Size = new System.Drawing.Size(1283, 753);
			this.pnlMainFizik.TabIndex = 19;
			// 
			// pnlGaussLaw
			// 
			this.pnlGaussLaw.BackColor = System.Drawing.Color.SlateGray;
			this.pnlGaussLaw.Controls.Add(this.lblGaussRegion);
			this.pnlGaussLaw.Controls.Add(this.chartGaussLaw);
			this.pnlGaussLaw.Controls.Add(this.rtbGaussResult);
			this.pnlGaussLaw.Controls.Add(this.label19);
			this.pnlGaussLaw.Controls.Add(this.tbGaussSurface);
			this.pnlGaussLaw.Controls.Add(this.cmbSystemGeometry);
			this.pnlGaussLaw.Controls.Add(this.lblGaussRValue);
			this.pnlGaussLaw.Controls.Add(this.txtSphereRadius);
			this.pnlGaussLaw.Controls.Add(this.txtTotalChargeOrDensity);
			this.pnlGaussLaw.Controls.Add(this.btnCalculateGauss);
			this.pnlGaussLaw.Controls.Add(this.lblChargeOrDensity);
			this.pnlGaussLaw.Controls.Add(this.label36);
			this.pnlGaussLaw.Controls.Add(this.label37);
			this.pnlGaussLaw.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGaussLaw.Location = new System.Drawing.Point(0, 0);
			this.pnlGaussLaw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlGaussLaw.Name = "pnlGaussLaw";
			this.pnlGaussLaw.Size = new System.Drawing.Size(1283, 753);
			this.pnlGaussLaw.TabIndex = 32;
			this.pnlGaussLaw.TabStop = true;
			// 
			// lblGaussRegion
			// 
			this.lblGaussRegion.AutoSize = true;
			this.lblGaussRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblGaussRegion.Location = new System.Drawing.Point(837, 474);
			this.lblGaussRegion.Name = "lblGaussRegion";
			this.lblGaussRegion.Size = new System.Drawing.Size(151, 22);
			this.lblGaussRegion.TabIndex = 52;
			this.lblGaussRegion.Text = "lblGaussRegion";
			// 
			// chartGaussLaw
			// 
			this.chartGaussLaw.BackColor = System.Drawing.Color.Crimson;
			this.chartGaussLaw.Location = new System.Drawing.Point(310, 295);
			this.chartGaussLaw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chartGaussLaw.Name = "chartGaussLaw";
			this.chartGaussLaw.Size = new System.Drawing.Size(476, 326);
			this.chartGaussLaw.TabIndex = 51;
			// 
			// rtbGaussResult
			// 
			this.rtbGaussResult.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.rtbGaussResult.Location = new System.Drawing.Point(796, 139);
			this.rtbGaussResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbGaussResult.Name = "rtbGaussResult";
			this.rtbGaussResult.ReadOnly = true;
			this.rtbGaussResult.Size = new System.Drawing.Size(484, 304);
			this.rtbGaussResult.TabIndex = 50;
			this.rtbGaussResult.Text = "";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label19.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label19.Location = new System.Drawing.Point(361, 146);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(338, 22);
			this.label19.TabIndex = 22;
			this.label19.Text = "Gauss Yüzeyi Kaydırıcısı (TrackBar):";
			// 
			// tbGaussSurface
			// 
			this.tbGaussSurface.Location = new System.Drawing.Point(701, 142);
			this.tbGaussSurface.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbGaussSurface.Maximum = 100;
			this.tbGaussSurface.Minimum = 1;
			this.tbGaussSurface.Name = "tbGaussSurface";
			this.tbGaussSurface.Size = new System.Drawing.Size(104, 56);
			this.tbGaussSurface.TabIndex = 21;
			this.tbGaussSurface.Value = 1;
			// 
			// cmbSystemGeometry
			// 
			this.cmbSystemGeometry.FormattingEnabled = true;
			this.cmbSystemGeometry.Items.AddRange(new object[] {
            "Noktasal Yük",
            "",
            "Yalıtkan Küre (Dolu)",
            "",
            "İletken Küre",
            "",
            "Çizgisel Yük (Sonsuz Tel)",
            "",
            "Sonsuz Düzlem"});
			this.cmbSystemGeometry.Location = new System.Drawing.Point(671, 33);
			this.cmbSystemGeometry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmbSystemGeometry.Name = "cmbSystemGeometry";
			this.cmbSystemGeometry.Size = new System.Drawing.Size(121, 24);
			this.cmbSystemGeometry.TabIndex = 20;
			// 
			// lblGaussRValue
			// 
			this.lblGaussRValue.AutoSize = true;
			this.lblGaussRValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblGaussRValue.Location = new System.Drawing.Point(357, 193);
			this.lblGaussRValue.Name = "lblGaussRValue";
			this.lblGaussRValue.Size = new System.Drawing.Size(167, 22);
			this.lblGaussRValue.TabIndex = 17;
			this.lblGaussRValue.Text = "lblGaussR_Deger";
			// 
			// txtSphereRadius
			// 
			this.txtSphereRadius.Location = new System.Drawing.Point(680, 105);
			this.txtSphereRadius.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtSphereRadius.Name = "txtSphereRadius";
			this.txtSphereRadius.Size = new System.Drawing.Size(131, 22);
			this.txtSphereRadius.TabIndex = 15;
			// 
			// txtTotalChargeOrDensity
			// 
			this.txtTotalChargeOrDensity.Location = new System.Drawing.Point(680, 70);
			this.txtTotalChargeOrDensity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTotalChargeOrDensity.Name = "txtTotalChargeOrDensity";
			this.txtTotalChargeOrDensity.Size = new System.Drawing.Size(131, 22);
			this.txtTotalChargeOrDensity.TabIndex = 14;
			// 
			// btnCalculateGauss
			// 
			this.btnCalculateGauss.BackColor = System.Drawing.Color.Pink;
			this.btnCalculateGauss.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnCalculateGauss.Location = new System.Drawing.Point(361, 223);
			this.btnCalculateGauss.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCalculateGauss.Name = "btnCalculateGauss";
			this.btnCalculateGauss.Size = new System.Drawing.Size(117, 34);
			this.btnCalculateGauss.TabIndex = 12;
			this.btnCalculateGauss.Text = "Calculate";
			this.btnCalculateGauss.UseVisualStyleBackColor = false;
			this.btnCalculateGauss.Click += new System.EventHandler(this.btnCalculateGauss_Click);
			// 
			// lblChargeOrDensity
			// 
			this.lblChargeOrDensity.AutoSize = true;
			this.lblChargeOrDensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblChargeOrDensity.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lblChargeOrDensity.Location = new System.Drawing.Point(371, 71);
			this.lblChargeOrDensity.Name = "lblChargeOrDensity";
			this.lblChargeOrDensity.Size = new System.Drawing.Size(321, 22);
			this.lblChargeOrDensity.TabIndex = 11;
			this.lblChargeOrDensity.Text = "Toplam Yük / Yoğunluk [$\\mu C$]: ";
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label36.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label36.Location = new System.Drawing.Point(371, 106);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(306, 22);
			this.label36.TabIndex = 10;
			this.label36.Text = "(küreyse)Cismin Yarıçapı (R) [m]:";
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label37.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label37.Location = new System.Drawing.Point(371, 34);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(294, 22);
			this.label37.TabIndex = 9;
			this.label37.Text = "Sistem Geometrisi (ComboBox):";
			// 
			// pnlElectricForce
			// 
			this.pnlElectricForce.BackColor = System.Drawing.Color.SlateGray;
			this.pnlElectricForce.Controls.Add(this.lblEForceNature);
			this.pnlElectricForce.Controls.Add(this.rtbElectricalForce);
			this.pnlElectricForce.Controls.Add(this.txtEForceCharge2);
			this.pnlElectricForce.Controls.Add(this.txtEForceDistance);
			this.pnlElectricForce.Controls.Add(this.plotElectricalForce);
			this.pnlElectricForce.Controls.Add(this.txtEForceCharge1);
			this.pnlElectricForce.Controls.Add(this.btnCalculateEForce);
			this.pnlElectricForce.Controls.Add(this.label62);
			this.pnlElectricForce.Controls.Add(this.label63);
			this.pnlElectricForce.Controls.Add(this.label64);
			this.pnlElectricForce.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlElectricForce.Location = new System.Drawing.Point(0, 0);
			this.pnlElectricForce.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlElectricForce.Name = "pnlElectricForce";
			this.pnlElectricForce.Size = new System.Drawing.Size(1283, 753);
			this.pnlElectricForce.TabIndex = 32;
			this.pnlElectricForce.TabStop = true;
			// 
			// lblEForceNature
			// 
			this.lblEForceNature.AutoSize = true;
			this.lblEForceNature.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblEForceNature.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lblEForceNature.Location = new System.Drawing.Point(915, 331);
			this.lblEForceNature.Name = "lblEForceNature";
			this.lblEForceNature.Size = new System.Drawing.Size(28, 22);
			this.lblEForceNature.TabIndex = 50;
			this.lblEForceNature.Text = "...";
			// 
			// rtbElectricalForce
			// 
			this.rtbElectricalForce.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.rtbElectricalForce.Location = new System.Drawing.Point(798, 16);
			this.rtbElectricalForce.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbElectricalForce.Name = "rtbElectricalForce";
			this.rtbElectricalForce.ReadOnly = true;
			this.rtbElectricalForce.Size = new System.Drawing.Size(484, 304);
			this.rtbElectricalForce.TabIndex = 49;
			this.rtbElectricalForce.Text = "";
			// 
			// txtEForceCharge2
			// 
			this.txtEForceCharge2.Location = new System.Drawing.Point(586, 74);
			this.txtEForceCharge2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtEForceCharge2.Name = "txtEForceCharge2";
			this.txtEForceCharge2.Size = new System.Drawing.Size(131, 22);
			this.txtEForceCharge2.TabIndex = 21;
			// 
			// txtEForceDistance
			// 
			this.txtEForceDistance.Location = new System.Drawing.Point(661, 109);
			this.txtEForceDistance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtEForceDistance.Name = "txtEForceDistance";
			this.txtEForceDistance.Size = new System.Drawing.Size(131, 22);
			this.txtEForceDistance.TabIndex = 20;
			// 
			// plotElectricalForce
			// 
			this.plotElectricalForce.BackColor = System.Drawing.Color.Crimson;
			this.plotElectricalForce.Location = new System.Drawing.Point(310, 329);
			this.plotElectricalForce.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.plotElectricalForce.Name = "plotElectricalForce";
			this.plotElectricalForce.Size = new System.Drawing.Size(552, 375);
			this.plotElectricalForce.TabIndex = 19;
			// 
			// txtEForceCharge1
			// 
			this.txtEForceCharge1.Location = new System.Drawing.Point(585, 34);
			this.txtEForceCharge1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtEForceCharge1.Name = "txtEForceCharge1";
			this.txtEForceCharge1.Size = new System.Drawing.Size(131, 22);
			this.txtEForceCharge1.TabIndex = 15;
			// 
			// btnCalculateEForce
			// 
			this.btnCalculateEForce.BackColor = System.Drawing.Color.Pink;
			this.btnCalculateEForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnCalculateEForce.Location = new System.Drawing.Point(373, 222);
			this.btnCalculateEForce.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCalculateEForce.Name = "btnCalculateEForce";
			this.btnCalculateEForce.Size = new System.Drawing.Size(117, 34);
			this.btnCalculateEForce.TabIndex = 12;
			this.btnCalculateEForce.Text = "Calculate";
			this.btnCalculateEForce.UseVisualStyleBackColor = false;
			this.btnCalculateEForce.Click += new System.EventHandler(this.btnCalculateEForce_Click);
			// 
			// label62
			// 
			this.label62.AutoSize = true;
			this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label62.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label62.Location = new System.Drawing.Point(371, 71);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(172, 22);
			this.label62.TabIndex = 11;
			this.label62.Text = "\"2. Yük (Q₂) [μC]:\"";
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label63.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label63.Location = new System.Drawing.Point(371, 106);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(269, 22);
			this.label63.TabIndex = 10;
			this.label63.Text = "\"Yükler Arası Mesafe (r) [m]:\"";
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label64.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label64.Location = new System.Drawing.Point(371, 34);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(172, 22);
			this.label64.TabIndex = 9;
			this.label64.Text = "\"1. Yük (Q₁) [μC]:\"";
			// 
			// pnlElectricField
			// 
			this.pnlElectricField.BackColor = System.Drawing.Color.SlateGray;
			this.pnlElectricField.Controls.Add(this.rtbEField);
			this.pnlElectricField.Controls.Add(this.txtEFieldDistance);
			this.pnlElectricField.Controls.Add(this.plotElectricField);
			this.pnlElectricField.Controls.Add(this.txtElektrikX1);
			this.pnlElectricField.Controls.Add(this.txtEFieldSourceCharge);
			this.pnlElectricField.Controls.Add(this.btnCalculateElectricField);
			this.pnlElectricField.Controls.Add(this.label29);
			this.pnlElectricField.Controls.Add(this.label31);
			this.pnlElectricField.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlElectricField.Location = new System.Drawing.Point(0, 0);
			this.pnlElectricField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlElectricField.Name = "pnlElectricField";
			this.pnlElectricField.Size = new System.Drawing.Size(1283, 753);
			this.pnlElectricField.TabIndex = 31;
			this.pnlElectricField.TabStop = true;
			// 
			// rtbEField
			// 
			this.rtbEField.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.rtbEField.Location = new System.Drawing.Point(766, 19);
			this.rtbEField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbEField.Name = "rtbEField";
			this.rtbEField.ReadOnly = true;
			this.rtbEField.Size = new System.Drawing.Size(484, 318);
			this.rtbEField.TabIndex = 39;
			this.rtbEField.Text = "";
			// 
			// txtEFieldDistance
			// 
			this.txtEFieldDistance.Location = new System.Drawing.Point(605, 71);
			this.txtEFieldDistance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtEFieldDistance.Name = "txtEFieldDistance";
			this.txtEFieldDistance.Size = new System.Drawing.Size(131, 22);
			this.txtEFieldDistance.TabIndex = 14;
			// 
			// plotElectricField
			// 
			this.plotElectricField.BackColor = System.Drawing.Color.Crimson;
			this.plotElectricField.Location = new System.Drawing.Point(387, 331);
			this.plotElectricField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.plotElectricField.Name = "plotElectricField";
			this.plotElectricField.Size = new System.Drawing.Size(552, 375);
			this.plotElectricField.TabIndex = 19;
			// 
			// txtElektrikX1
			// 
			this.txtElektrikX1.Location = new System.Drawing.Point(605, 71);
			this.txtElektrikX1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtElektrikX1.Name = "txtElektrikX1";
			this.txtElektrikX1.Size = new System.Drawing.Size(131, 22);
			this.txtElektrikX1.TabIndex = 14;
			// 
			// txtEFieldSourceCharge
			// 
			this.txtEFieldSourceCharge.Location = new System.Drawing.Point(605, 38);
			this.txtEFieldSourceCharge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtEFieldSourceCharge.Name = "txtEFieldSourceCharge";
			this.txtEFieldSourceCharge.Size = new System.Drawing.Size(131, 22);
			this.txtEFieldSourceCharge.TabIndex = 13;
			// 
			// btnCalculateElectricField
			// 
			this.btnCalculateElectricField.BackColor = System.Drawing.Color.Pink;
			this.btnCalculateElectricField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnCalculateElectricField.Location = new System.Drawing.Point(373, 222);
			this.btnCalculateElectricField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCalculateElectricField.Name = "btnCalculateElectricField";
			this.btnCalculateElectricField.Size = new System.Drawing.Size(117, 34);
			this.btnCalculateElectricField.TabIndex = 12;
			this.btnCalculateElectricField.Text = "Calculate";
			this.btnCalculateElectricField.UseVisualStyleBackColor = false;
			this.btnCalculateElectricField.Click += new System.EventHandler(this.btnCalculateElectricField_Click);
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label29.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label29.Location = new System.Drawing.Point(371, 71);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(154, 22);
			this.label29.TabIndex = 11;
			this.label29.Text = "\"Mesafe (r) [m]:\"";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label31.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label31.Location = new System.Drawing.Point(341, 38);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(214, 22);
			this.label31.TabIndex = 9;
			this.label31.Text = "\"Kaynak Yük (Q) [μC]:\"";
			// 
			// pnlOscillations
			// 
			this.pnlOscillations.BackColor = System.Drawing.Color.SlateGray;
			this.pnlOscillations.Controls.Add(this.rtbOscillationReport);
			this.pnlOscillations.Controls.Add(this.tabOscillation);
			this.pnlOscillations.Controls.Add(this.btnCalculateOscillation);
			this.pnlOscillations.Controls.Add(this.plotOscillation);
			this.pnlOscillations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlOscillations.Location = new System.Drawing.Point(0, 0);
			this.pnlOscillations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlOscillations.Name = "pnlOscillations";
			this.pnlOscillations.Size = new System.Drawing.Size(1283, 753);
			this.pnlOscillations.TabIndex = 30;
			this.pnlOscillations.TabStop = true;
			// 
			// rtbOscillationReport
			// 
			this.rtbOscillationReport.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.rtbOscillationReport.Location = new System.Drawing.Point(766, 16);
			this.rtbOscillationReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbOscillationReport.Name = "rtbOscillationReport";
			this.rtbOscillationReport.ReadOnly = true;
			this.rtbOscillationReport.Size = new System.Drawing.Size(484, 318);
			this.rtbOscillationReport.TabIndex = 48;
			this.rtbOscillationReport.Text = "";
			// 
			// tabOscillation
			// 
			this.tabOscillation.Controls.Add(this.tabSpringPage);
			this.tabOscillation.Controls.Add(this.tabPendulumPage);
			this.tabOscillation.Location = new System.Drawing.Point(306, 3);
			this.tabOscillation.Name = "tabOscillation";
			this.tabOscillation.SelectedIndex = 0;
			this.tabOscillation.Size = new System.Drawing.Size(430, 268);
			this.tabOscillation.TabIndex = 47;
			// 
			// tabSpringPage
			// 
			this.tabSpringPage.BackColor = System.Drawing.Color.SlateGray;
			this.tabSpringPage.Controls.Add(this.txtSpringConstant);
			this.tabSpringPage.Controls.Add(this.Genlik);
			this.tabSpringPage.Controls.Add(this.txtSpringMass);
			this.tabSpringPage.Controls.Add(this.txtSpringTimeLimit);
			this.tabSpringPage.Controls.Add(this.txtSpringAmplitude);
			this.tabSpringPage.Controls.Add(this.txtSpringDamping);
			this.tabSpringPage.Controls.Add(this.label17);
			this.tabSpringPage.Controls.Add(this.label14);
			this.tabSpringPage.Controls.Add(this.label18);
			this.tabSpringPage.Controls.Add(this.label16);
			this.tabSpringPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.tabSpringPage.Location = new System.Drawing.Point(4, 25);
			this.tabSpringPage.Name = "tabSpringPage";
			this.tabSpringPage.Padding = new System.Windows.Forms.Padding(3);
			this.tabSpringPage.Size = new System.Drawing.Size(422, 239);
			this.tabSpringPage.TabIndex = 0;
			this.tabSpringPage.Text = "Yay-Kütle Sistemi";
			// 
			// txtSpringConstant
			// 
			this.txtSpringConstant.Location = new System.Drawing.Point(183, 117);
			this.txtSpringConstant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtSpringConstant.Name = "txtSpringConstant";
			this.txtSpringConstant.Size = new System.Drawing.Size(131, 30);
			this.txtSpringConstant.TabIndex = 46;
			// 
			// Genlik
			// 
			this.Genlik.AutoSize = true;
			this.Genlik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Genlik.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.Genlik.Location = new System.Drawing.Point(13, 119);
			this.Genlik.Name = "Genlik";
			this.Genlik.Size = new System.Drawing.Size(101, 22);
			this.Genlik.TabIndex = 45;
			this.Genlik.Text = "Yay Sabiti";
			// 
			// txtSpringMass
			// 
			this.txtSpringMass.Location = new System.Drawing.Point(174, 9);
			this.txtSpringMass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtSpringMass.Name = "txtSpringMass";
			this.txtSpringMass.Size = new System.Drawing.Size(131, 30);
			this.txtSpringMass.TabIndex = 40;
			// 
			// txtSpringTimeLimit
			// 
			this.txtSpringTimeLimit.Location = new System.Drawing.Point(174, 42);
			this.txtSpringTimeLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtSpringTimeLimit.Name = "txtSpringTimeLimit";
			this.txtSpringTimeLimit.Size = new System.Drawing.Size(131, 30);
			this.txtSpringTimeLimit.TabIndex = 41;
			// 
			// txtSpringAmplitude
			// 
			this.txtSpringAmplitude.Location = new System.Drawing.Point(174, 76);
			this.txtSpringAmplitude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtSpringAmplitude.Name = "txtSpringAmplitude";
			this.txtSpringAmplitude.Size = new System.Drawing.Size(131, 30);
			this.txtSpringAmplitude.TabIndex = 44;
			// 
			// txtSpringDamping
			// 
			this.txtSpringDamping.Location = new System.Drawing.Point(183, 143);
			this.txtSpringDamping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtSpringDamping.Name = "txtSpringDamping";
			this.txtSpringDamping.Size = new System.Drawing.Size(131, 30);
			this.txtSpringDamping.TabIndex = 39;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label17.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label17.Location = new System.Drawing.Point(13, 47);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(70, 22);
			this.label17.TabIndex = 36;
			this.label17.Text = "Zaman";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label14.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label14.Location = new System.Drawing.Point(15, 78);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(73, 22);
			this.label14.TabIndex = 43;
			this.label14.Text = "Genlik:";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label18.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label18.Location = new System.Drawing.Point(13, 141);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(164, 22);
			this.label18.TabIndex = 35;
			this.label18.Text = "Sönüm Katsayısı:";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label16.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label16.Location = new System.Drawing.Point(14, 13);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(62, 22);
			this.label16.TabIndex = 37;
			this.label16.Text = "Kütle ";
			// 
			// tabPendulumPage
			// 
			this.tabPendulumPage.BackColor = System.Drawing.Color.SlateGray;
			this.tabPendulumPage.Controls.Add(this.txtPendulumLength);
			this.tabPendulumPage.Controls.Add(this.label27);
			this.tabPendulumPage.Controls.Add(this.txtPendulumMass);
			this.tabPendulumPage.Controls.Add(this.txtPendulumTimeLimit);
			this.tabPendulumPage.Controls.Add(this.txtPendulumAmplitude);
			this.tabPendulumPage.Controls.Add(this.txtPendulumDamping);
			this.tabPendulumPage.Controls.Add(this.label38);
			this.tabPendulumPage.Controls.Add(this.label45);
			this.tabPendulumPage.Controls.Add(this.label46);
			this.tabPendulumPage.Controls.Add(this.label56);
			this.tabPendulumPage.Location = new System.Drawing.Point(4, 25);
			this.tabPendulumPage.Name = "tabPendulumPage";
			this.tabPendulumPage.Padding = new System.Windows.Forms.Padding(3);
			this.tabPendulumPage.Size = new System.Drawing.Size(422, 239);
			this.tabPendulumPage.TabIndex = 1;
			this.tabPendulumPage.Text = "Basit Sarkaç";
			// 
			// txtPendulumLength
			// 
			this.txtPendulumLength.Location = new System.Drawing.Point(185, 130);
			this.txtPendulumLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtPendulumLength.Name = "txtPendulumLength";
			this.txtPendulumLength.Size = new System.Drawing.Size(131, 22);
			this.txtPendulumLength.TabIndex = 56;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label27.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label27.Location = new System.Drawing.Point(15, 132);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(115, 22);
			this.label27.TabIndex = 55;
			this.label27.Text = "İp Uzunluğu";
			// 
			// txtPendulumMass
			// 
			this.txtPendulumMass.Location = new System.Drawing.Point(176, 22);
			this.txtPendulumMass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtPendulumMass.Name = "txtPendulumMass";
			this.txtPendulumMass.Size = new System.Drawing.Size(131, 22);
			this.txtPendulumMass.TabIndex = 51;
			// 
			// txtPendulumTimeLimit
			// 
			this.txtPendulumTimeLimit.Location = new System.Drawing.Point(176, 55);
			this.txtPendulumTimeLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtPendulumTimeLimit.Name = "txtPendulumTimeLimit";
			this.txtPendulumTimeLimit.Size = new System.Drawing.Size(131, 22);
			this.txtPendulumTimeLimit.TabIndex = 52;
			// 
			// txtPendulumAmplitude
			// 
			this.txtPendulumAmplitude.Location = new System.Drawing.Point(176, 89);
			this.txtPendulumAmplitude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtPendulumAmplitude.Name = "txtPendulumAmplitude";
			this.txtPendulumAmplitude.Size = new System.Drawing.Size(131, 22);
			this.txtPendulumAmplitude.TabIndex = 54;
			// 
			// txtPendulumDamping
			// 
			this.txtPendulumDamping.Location = new System.Drawing.Point(185, 156);
			this.txtPendulumDamping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtPendulumDamping.Name = "txtPendulumDamping";
			this.txtPendulumDamping.Size = new System.Drawing.Size(131, 22);
			this.txtPendulumDamping.TabIndex = 50;
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label38.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label38.Location = new System.Drawing.Point(15, 60);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(70, 22);
			this.label38.TabIndex = 48;
			this.label38.Text = "Zaman";
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label45.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label45.Location = new System.Drawing.Point(17, 91);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(73, 22);
			this.label45.TabIndex = 53;
			this.label45.Text = "Genlik:";
			// 
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label46.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label46.Location = new System.Drawing.Point(15, 154);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(164, 22);
			this.label46.TabIndex = 47;
			this.label46.Text = "Sönüm Katsayısı:";
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label56.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label56.Location = new System.Drawing.Point(16, 26);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(62, 22);
			this.label56.TabIndex = 49;
			this.label56.Text = "Kütle ";
			// 
			// btnCalculateOscillation
			// 
			this.btnCalculateOscillation.BackColor = System.Drawing.Color.Pink;
			this.btnCalculateOscillation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnCalculateOscillation.Location = new System.Drawing.Point(1002, 423);
			this.btnCalculateOscillation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCalculateOscillation.Name = "btnCalculateOscillation";
			this.btnCalculateOscillation.Size = new System.Drawing.Size(117, 34);
			this.btnCalculateOscillation.TabIndex = 38;
			this.btnCalculateOscillation.Text = "Calculate";
			this.btnCalculateOscillation.UseVisualStyleBackColor = false;
			this.btnCalculateOscillation.Click += new System.EventHandler(this.btnCalculateOscillation_Click);
			// 
			// plotOscillation
			// 
			this.plotOscillation.BackColor = System.Drawing.Color.Crimson;
			this.plotOscillation.Location = new System.Drawing.Point(336, 393);
			this.plotOscillation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.plotOscillation.Name = "plotOscillation";
			this.plotOscillation.Size = new System.Drawing.Size(533, 338);
			this.plotOscillation.TabIndex = 19;
			// 
			// pnlRotational
			// 
			this.pnlRotational.BackColor = System.Drawing.Color.SlateGray;
			this.pnlRotational.Controls.Add(this.txtDragCoefRot);
			this.pnlRotational.Controls.Add(this.label25);
			this.pnlRotational.Controls.Add(this.rtbRotationalResults);
			this.pnlRotational.Controls.Add(this.cmbGeometry);
			this.pnlRotational.Controls.Add(this.txtRotTime);
			this.pnlRotational.Controls.Add(this.label79);
			this.pnlRotational.Controls.Add(this.txtRotForce);
			this.pnlRotational.Controls.Add(this.txtRotRadius);
			this.pnlRotational.Controls.Add(this.txtRotMass);
			this.pnlRotational.Controls.Add(this.btnCalculateRotational);
			this.pnlRotational.Controls.Add(this.label81);
			this.pnlRotational.Controls.Add(this.label82);
			this.pnlRotational.Controls.Add(this.label83);
			this.pnlRotational.Controls.Add(this.plotRotational);
			this.pnlRotational.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlRotational.Location = new System.Drawing.Point(0, 0);
			this.pnlRotational.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlRotational.Name = "pnlRotational";
			this.pnlRotational.Size = new System.Drawing.Size(1283, 753);
			this.pnlRotational.TabIndex = 6;
			this.pnlRotational.TabStop = true;
			// 
			// txtDragCoefRot
			// 
			this.txtDragCoefRot.Location = new System.Drawing.Point(564, 200);
			this.txtDragCoefRot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtDragCoefRot.Name = "txtDragCoefRot";
			this.txtDragCoefRot.Size = new System.Drawing.Size(131, 22);
			this.txtDragCoefRot.TabIndex = 40;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label25.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label25.Location = new System.Drawing.Point(331, 197);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(149, 22);
			this.label25.TabIndex = 39;
			this.label25.Text = "DragCoefficient\r\n";
			// 
			// rtbRotationalResults
			// 
			this.rtbRotationalResults.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.rtbRotationalResults.Location = new System.Drawing.Point(765, 19);
			this.rtbRotationalResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbRotationalResults.Name = "rtbRotationalResults";
			this.rtbRotationalResults.ReadOnly = true;
			this.rtbRotationalResults.Size = new System.Drawing.Size(484, 318);
			this.rtbRotationalResults.TabIndex = 38;
			this.rtbRotationalResults.Text = "";
			// 
			// cmbGeometry
			// 
			this.cmbGeometry.FormattingEnabled = true;
			this.cmbGeometry.Items.AddRange(new object[] {
            "İçi Dolu Silindir",
            "",
            "",
            "İnce Disk",
            "",
            "",
            "Boş Çember",
            "İçi Dolu Küre"});
			this.cmbGeometry.Location = new System.Drawing.Point(337, 22);
			this.cmbGeometry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmbGeometry.Name = "cmbGeometry";
			this.cmbGeometry.Size = new System.Drawing.Size(221, 24);
			this.cmbGeometry.TabIndex = 34;
			// 
			// txtRotTime
			// 
			this.txtRotTime.Location = new System.Drawing.Point(567, 126);
			this.txtRotTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtRotTime.Name = "txtRotTime";
			this.txtRotTime.Size = new System.Drawing.Size(131, 22);
			this.txtRotTime.TabIndex = 33;
			// 
			// label79
			// 
			this.label79.AutoSize = true;
			this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label79.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label79.Location = new System.Drawing.Point(333, 128);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(167, 22);
			this.label79.TabIndex = 32;
			this.label79.Text = "Uygulama Süresi:";
			// 
			// txtRotForce
			// 
			this.txtRotForce.Location = new System.Drawing.Point(567, 98);
			this.txtRotForce.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtRotForce.Name = "txtRotForce";
			this.txtRotForce.Size = new System.Drawing.Size(131, 22);
			this.txtRotForce.TabIndex = 30;
			// 
			// txtRotRadius
			// 
			this.txtRotRadius.Location = new System.Drawing.Point(567, 64);
			this.txtRotRadius.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtRotRadius.Name = "txtRotRadius";
			this.txtRotRadius.Size = new System.Drawing.Size(131, 22);
			this.txtRotRadius.TabIndex = 29;
			// 
			// txtRotMass
			// 
			this.txtRotMass.Location = new System.Drawing.Point(564, 162);
			this.txtRotMass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtRotMass.Name = "txtRotMass";
			this.txtRotMass.Size = new System.Drawing.Size(131, 22);
			this.txtRotMass.TabIndex = 28;
			// 
			// btnCalculateRotational
			// 
			this.btnCalculateRotational.BackColor = System.Drawing.Color.Pink;
			this.btnCalculateRotational.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnCalculateRotational.Location = new System.Drawing.Point(347, 276);
			this.btnCalculateRotational.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCalculateRotational.Name = "btnCalculateRotational";
			this.btnCalculateRotational.Size = new System.Drawing.Size(117, 34);
			this.btnCalculateRotational.TabIndex = 27;
			this.btnCalculateRotational.Text = "Calculate";
			this.btnCalculateRotational.UseVisualStyleBackColor = false;
			this.btnCalculateRotational.Click += new System.EventHandler(this.btnCalculateRotational_Click);
			// 
			// label81
			// 
			this.label81.AutoSize = true;
			this.label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label81.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label81.Location = new System.Drawing.Point(333, 64);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(75, 22);
			this.label81.TabIndex = 26;
			this.label81.Text = "yarıçap";
			// 
			// label82
			// 
			this.label82.AutoSize = true;
			this.label82.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label82.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label82.Location = new System.Drawing.Point(333, 98);
			this.label82.Name = "label82";
			this.label82.Size = new System.Drawing.Size(161, 22);
			this.label82.TabIndex = 25;
			this.label82.Text = "Teğetsel Kuvvet:";
			// 
			// label83
			// 
			this.label83.AutoSize = true;
			this.label83.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label83.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label83.Location = new System.Drawing.Point(331, 159);
			this.label83.Name = "label83";
			this.label83.Size = new System.Drawing.Size(121, 22);
			this.label83.TabIndex = 24;
			this.label83.Text = "1.cisim kütle";
			// 
			// plotRotational
			// 
			this.plotRotational.BackColor = System.Drawing.Color.Crimson;
			this.plotRotational.Location = new System.Drawing.Point(655, 349);
			this.plotRotational.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.plotRotational.Name = "plotRotational";
			this.plotRotational.Size = new System.Drawing.Size(607, 373);
			this.plotRotational.TabIndex = 19;
			// 
			// pnlCollision
			// 
			this.pnlCollision.BackColor = System.Drawing.Color.SlateGray;
			this.pnlCollision.Controls.Add(this.label7);
			this.pnlCollision.Controls.Add(this.rtbCollisionResults);
			this.pnlCollision.Controls.Add(this.txtVel2YCollision);
			this.pnlCollision.Controls.Add(this.txtVel1YCollision);
			this.pnlCollision.Controls.Add(this.label26);
			this.pnlCollision.Controls.Add(this.label28);
			this.pnlCollision.Controls.Add(this.txtRestitution);
			this.pnlCollision.Controls.Add(this.label32);
			this.pnlCollision.Controls.Add(this.txtVel2XCollision);
			this.pnlCollision.Controls.Add(this.label33);
			this.pnlCollision.Controls.Add(this.plotCollision);
			this.pnlCollision.Controls.Add(this.txtVel1XCollision);
			this.pnlCollision.Controls.Add(this.txtMass2Collision);
			this.pnlCollision.Controls.Add(this.txtMass1Collision);
			this.pnlCollision.Controls.Add(this.btnCalculateCollision);
			this.pnlCollision.Controls.Add(this.label39);
			this.pnlCollision.Controls.Add(this.label40);
			this.pnlCollision.Controls.Add(this.label44);
			this.pnlCollision.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCollision.Location = new System.Drawing.Point(0, 0);
			this.pnlCollision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlCollision.Name = "pnlCollision";
			this.pnlCollision.Size = new System.Drawing.Size(1283, 753);
			this.pnlCollision.TabIndex = 40;
			this.pnlCollision.TabStop = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label7.Location = new System.Drawing.Point(489, 29);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 22);
			this.label7.TabIndex = 38;
			this.label7.Text = "1.cisim ";
			// 
			// rtbCollisionResults
			// 
			this.rtbCollisionResults.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.rtbCollisionResults.Location = new System.Drawing.Point(785, 27);
			this.rtbCollisionResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbCollisionResults.Name = "rtbCollisionResults";
			this.rtbCollisionResults.ReadOnly = true;
			this.rtbCollisionResults.Size = new System.Drawing.Size(484, 318);
			this.rtbCollisionResults.TabIndex = 37;
			this.rtbCollisionResults.Text = "";
			// 
			// txtVel2YCollision
			// 
			this.txtVel2YCollision.Location = new System.Drawing.Point(585, 499);
			this.txtVel2YCollision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtVel2YCollision.Name = "txtVel2YCollision";
			this.txtVel2YCollision.Size = new System.Drawing.Size(131, 22);
			this.txtVel2YCollision.TabIndex = 29;
			// 
			// txtVel1YCollision
			// 
			this.txtVel1YCollision.Location = new System.Drawing.Point(629, 97);
			this.txtVel1YCollision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtVel1YCollision.Name = "txtVel1YCollision";
			this.txtVel1YCollision.Size = new System.Drawing.Size(131, 22);
			this.txtVel1YCollision.TabIndex = 28;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label26.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label26.Location = new System.Drawing.Point(336, 492);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(159, 22);
			this.label26.TabIndex = 26;
			this.label26.Text = "ikinci cisim y hızı";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label28.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label28.Location = new System.Drawing.Point(383, 97);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(33, 22);
			this.label28.TabIndex = 24;
			this.label28.Text = "Vy";
			// 
			// txtRestitution
			// 
			this.txtRestitution.Location = new System.Drawing.Point(583, 535);
			this.txtRestitution.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtRestitution.Name = "txtRestitution";
			this.txtRestitution.Size = new System.Drawing.Size(131, 22);
			this.txtRestitution.TabIndex = 23;
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label32.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label32.Location = new System.Drawing.Point(349, 533);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(172, 22);
			this.label32.TabIndex = 22;
			this.label32.Text = "Esneklik Katsayısı";
			// 
			// txtVel2XCollision
			// 
			this.txtVel2XCollision.Location = new System.Drawing.Point(577, 449);
			this.txtVel2XCollision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtVel2XCollision.Name = "txtVel2XCollision";
			this.txtVel2XCollision.Size = new System.Drawing.Size(131, 22);
			this.txtVel2XCollision.TabIndex = 21;
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label33.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label33.Location = new System.Drawing.Point(343, 450);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(163, 22);
			this.label33.TabIndex = 20;
			this.label33.Text = "2.Cisim İlk Hızı x:";
			// 
			// plotCollision
			// 
			this.plotCollision.BackColor = System.Drawing.Color.Crimson;
			this.plotCollision.Location = new System.Drawing.Point(797, 363);
			this.plotCollision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.plotCollision.Name = "plotCollision";
			this.plotCollision.Size = new System.Drawing.Size(469, 359);
			this.plotCollision.TabIndex = 19;
			// 
			// txtVel1XCollision
			// 
			this.txtVel1XCollision.Location = new System.Drawing.Point(586, 61);
			this.txtVel1XCollision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtVel1XCollision.Name = "txtVel1XCollision";
			this.txtVel1XCollision.Size = new System.Drawing.Size(131, 22);
			this.txtVel1XCollision.TabIndex = 15;
			// 
			// txtMass2Collision
			// 
			this.txtMass2Collision.Location = new System.Drawing.Point(575, 423);
			this.txtMass2Collision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtMass2Collision.Name = "txtMass2Collision";
			this.txtMass2Collision.Size = new System.Drawing.Size(131, 22);
			this.txtMass2Collision.TabIndex = 14;
			// 
			// txtMass1Collision
			// 
			this.txtMass1Collision.Location = new System.Drawing.Point(597, 147);
			this.txtMass1Collision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtMass1Collision.Name = "txtMass1Collision";
			this.txtMass1Collision.Size = new System.Drawing.Size(131, 22);
			this.txtMass1Collision.TabIndex = 13;
			// 
			// btnCalculateCollision
			// 
			this.btnCalculateCollision.BackColor = System.Drawing.Color.Pink;
			this.btnCalculateCollision.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnCalculateCollision.Location = new System.Drawing.Point(404, 566);
			this.btnCalculateCollision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCalculateCollision.Name = "btnCalculateCollision";
			this.btnCalculateCollision.Size = new System.Drawing.Size(117, 34);
			this.btnCalculateCollision.TabIndex = 12;
			this.btnCalculateCollision.Text = "Calculate";
			this.btnCalculateCollision.UseVisualStyleBackColor = false;
			this.btnCalculateCollision.Click += new System.EventHandler(this.btnCalculateCollision_Click);
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label39.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label39.Location = new System.Drawing.Point(383, 68);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(33, 22);
			this.label39.TabIndex = 11;
			this.label39.Text = "Vx";
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label40.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label40.Location = new System.Drawing.Point(341, 420);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(132, 22);
			this.label40.TabIndex = 10;
			this.label40.Text = "Cisim Kütlesi:";
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label44.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label44.Location = new System.Drawing.Point(369, 145);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(121, 22);
			this.label44.TabIndex = 9;
			this.label44.Text = "1.cisim kütle";
			// 
			// pnlImpulse
			// 
			this.pnlImpulse.BackColor = System.Drawing.Color.SlateGray;
			this.pnlImpulse.Controls.Add(this.rtbImpulseResults);
			this.pnlImpulse.Controls.Add(this.txtImpulseInitialVel);
			this.pnlImpulse.Controls.Add(this.label68);
			this.pnlImpulse.Controls.Add(this.txtTimeLimitImpulse);
			this.pnlImpulse.Controls.Add(this.txtMassFuncImpulse);
			this.pnlImpulse.Controls.Add(this.txtForceFuncImpulse);
			this.pnlImpulse.Controls.Add(this.btnCalculateImpulse);
			this.pnlImpulse.Controls.Add(this.label70);
			this.pnlImpulse.Controls.Add(this.label76);
			this.pnlImpulse.Controls.Add(this.label77);
			this.pnlImpulse.Controls.Add(this.plotImpulse);
			this.pnlImpulse.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlImpulse.Location = new System.Drawing.Point(0, 0);
			this.pnlImpulse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlImpulse.Name = "pnlImpulse";
			this.pnlImpulse.Size = new System.Drawing.Size(1283, 753);
			this.pnlImpulse.TabIndex = 39;
			this.pnlImpulse.TabStop = true;
			// 
			// rtbImpulseResults
			// 
			this.rtbImpulseResults.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.rtbImpulseResults.Location = new System.Drawing.Point(756, 25);
			this.rtbImpulseResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbImpulseResults.Name = "rtbImpulseResults";
			this.rtbImpulseResults.ReadOnly = true;
			this.rtbImpulseResults.Size = new System.Drawing.Size(484, 318);
			this.rtbImpulseResults.TabIndex = 36;
			this.rtbImpulseResults.Text = "";
			// 
			// txtImpulseInitialVel
			// 
			this.txtImpulseInitialVel.Location = new System.Drawing.Point(582, 138);
			this.txtImpulseInitialVel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtImpulseInitialVel.Name = "txtImpulseInitialVel";
			this.txtImpulseInitialVel.Size = new System.Drawing.Size(131, 22);
			this.txtImpulseInitialVel.TabIndex = 34;
			// 
			// label68
			// 
			this.label68.AutoSize = true;
			this.label68.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label68.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label68.Location = new System.Drawing.Point(349, 137);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(111, 22);
			this.label68.TabIndex = 33;
			this.label68.Text = "İlk Hız (v1):";
			// 
			// txtTimeLimitImpulse
			// 
			this.txtTimeLimitImpulse.Location = new System.Drawing.Point(570, 100);
			this.txtTimeLimitImpulse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTimeLimitImpulse.Name = "txtTimeLimitImpulse";
			this.txtTimeLimitImpulse.Size = new System.Drawing.Size(131, 22);
			this.txtTimeLimitImpulse.TabIndex = 30;
			// 
			// txtMassFuncImpulse
			// 
			this.txtMassFuncImpulse.Location = new System.Drawing.Point(570, 65);
			this.txtMassFuncImpulse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtMassFuncImpulse.Name = "txtMassFuncImpulse";
			this.txtMassFuncImpulse.Size = new System.Drawing.Size(131, 22);
			this.txtMassFuncImpulse.TabIndex = 29;
			// 
			// txtForceFuncImpulse
			// 
			this.txtForceFuncImpulse.Location = new System.Drawing.Point(570, 31);
			this.txtForceFuncImpulse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtForceFuncImpulse.Name = "txtForceFuncImpulse";
			this.txtForceFuncImpulse.Size = new System.Drawing.Size(131, 22);
			this.txtForceFuncImpulse.TabIndex = 28;
			// 
			// btnCalculateImpulse
			// 
			this.btnCalculateImpulse.BackColor = System.Drawing.Color.Pink;
			this.btnCalculateImpulse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnCalculateImpulse.Location = new System.Drawing.Point(348, 181);
			this.btnCalculateImpulse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCalculateImpulse.Name = "btnCalculateImpulse";
			this.btnCalculateImpulse.Size = new System.Drawing.Size(117, 34);
			this.btnCalculateImpulse.TabIndex = 27;
			this.btnCalculateImpulse.Text = "Calculate";
			this.btnCalculateImpulse.UseVisualStyleBackColor = false;
			this.btnCalculateImpulse.Click += new System.EventHandler(this.btnCalculateImpulse_Click_1);
			// 
			// label70
			// 
			this.label70.AutoSize = true;
			this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label70.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label70.Location = new System.Drawing.Point(337, 65);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(158, 22);
			this.label70.TabIndex = 26;
			this.label70.Text = "Kütle fonksiyonu";
			// 
			// label76
			// 
			this.label76.AutoSize = true;
			this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label76.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label76.Location = new System.Drawing.Point(337, 100);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(123, 22);
			this.label76.TabIndex = 25;
			this.label76.Text = "Zaman Limiti";
			// 
			// label77
			// 
			this.label77.AutoSize = true;
			this.label77.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label77.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label77.Location = new System.Drawing.Point(337, 28);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(191, 22);
			this.label77.TabIndex = 24;
			this.label77.Text = "Kuvvet Fonksiyonu :";
			// 
			// plotImpulse
			// 
			this.plotImpulse.BackColor = System.Drawing.Color.Crimson;
			this.plotImpulse.Location = new System.Drawing.Point(797, 363);
			this.plotImpulse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.plotImpulse.Name = "plotImpulse";
			this.plotImpulse.Size = new System.Drawing.Size(469, 359);
			this.plotImpulse.TabIndex = 19;
			// 
			// pnlWorkEnergy
			// 
			this.pnlWorkEnergy.BackColor = System.Drawing.Color.SlateGray;
			this.pnlWorkEnergy.Controls.Add(this.rtbWorkEnergyResults);
			this.pnlWorkEnergy.Controls.Add(this.btnWorkCalculate);
			this.pnlWorkEnergy.Controls.Add(this.txtWorkEndX);
			this.pnlWorkEnergy.Controls.Add(this.txtWorkStartX);
			this.pnlWorkEnergy.Controls.Add(this.txtWorkFunction);
			this.pnlWorkEnergy.Controls.Add(this.label5);
			this.pnlWorkEnergy.Controls.Add(this.label6);
			this.pnlWorkEnergy.Controls.Add(this.label10);
			this.pnlWorkEnergy.Controls.Add(this.txtEnergyMass);
			this.pnlWorkEnergy.Controls.Add(this.label74);
			this.pnlWorkEnergy.Controls.Add(this.plotWorkEnergy);
			this.pnlWorkEnergy.Controls.Add(this.txtEnergyFinalHeight);
			this.pnlWorkEnergy.Controls.Add(this.txtEnergyFirstHeight);
			this.pnlWorkEnergy.Controls.Add(this.txtEnergyInitialVelocity);
			this.pnlWorkEnergy.Controls.Add(this.btnEnergyCalculate);
			this.pnlWorkEnergy.Controls.Add(this.label11);
			this.pnlWorkEnergy.Controls.Add(this.label12);
			this.pnlWorkEnergy.Controls.Add(this.label13);
			this.pnlWorkEnergy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlWorkEnergy.Location = new System.Drawing.Point(0, 0);
			this.pnlWorkEnergy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlWorkEnergy.Name = "pnlWorkEnergy";
			this.pnlWorkEnergy.Size = new System.Drawing.Size(1283, 753);
			this.pnlWorkEnergy.TabIndex = 38;
			this.pnlWorkEnergy.TabStop = true;
			// 
			// rtbWorkEnergyResults
			// 
			this.rtbWorkEnergyResults.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.rtbWorkEnergyResults.Location = new System.Drawing.Point(765, 2);
			this.rtbWorkEnergyResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbWorkEnergyResults.Name = "rtbWorkEnergyResults";
			this.rtbWorkEnergyResults.ReadOnly = true;
			this.rtbWorkEnergyResults.Size = new System.Drawing.Size(484, 318);
			this.rtbWorkEnergyResults.TabIndex = 29;
			this.rtbWorkEnergyResults.Text = "";
			// 
			// btnWorkCalculate
			// 
			this.btnWorkCalculate.BackColor = System.Drawing.Color.Pink;
			this.btnWorkCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnWorkCalculate.Location = new System.Drawing.Point(368, 414);
			this.btnWorkCalculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnWorkCalculate.Name = "btnWorkCalculate";
			this.btnWorkCalculate.Size = new System.Drawing.Size(117, 34);
			this.btnWorkCalculate.TabIndex = 28;
			this.btnWorkCalculate.Text = "Calculate";
			this.btnWorkCalculate.UseVisualStyleBackColor = false;
			this.btnWorkCalculate.Click += new System.EventHandler(this.btnWorkCalculate_Click_1);
			// 
			// txtWorkEndX
			// 
			this.txtWorkEndX.Location = new System.Drawing.Point(597, 367);
			this.txtWorkEndX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtWorkEndX.Name = "txtWorkEndX";
			this.txtWorkEndX.Size = new System.Drawing.Size(131, 22);
			this.txtWorkEndX.TabIndex = 27;
			// 
			// txtWorkStartX
			// 
			this.txtWorkStartX.Location = new System.Drawing.Point(597, 334);
			this.txtWorkStartX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtWorkStartX.Name = "txtWorkStartX";
			this.txtWorkStartX.Size = new System.Drawing.Size(131, 22);
			this.txtWorkStartX.TabIndex = 26;
			// 
			// txtWorkFunction
			// 
			this.txtWorkFunction.Location = new System.Drawing.Point(597, 299);
			this.txtWorkFunction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtWorkFunction.Name = "txtWorkFunction";
			this.txtWorkFunction.Size = new System.Drawing.Size(131, 22);
			this.txtWorkFunction.TabIndex = 25;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label5.Location = new System.Drawing.Point(364, 334);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(140, 22);
			this.label5.TabIndex = 24;
			this.label5.Text = "First height(m)";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label6.Location = new System.Drawing.Point(364, 367);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(144, 22);
			this.label6.TabIndex = 23;
			this.label6.Text = "Final height(m)";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label10.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label10.Location = new System.Drawing.Point(364, 295);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(95, 22);
			this.label10.TabIndex = 22;
			this.label10.Text = "fonksiyon";
			// 
			// txtEnergyMass
			// 
			this.txtEnergyMass.Location = new System.Drawing.Point(605, 138);
			this.txtEnergyMass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtEnergyMass.Name = "txtEnergyMass";
			this.txtEnergyMass.Size = new System.Drawing.Size(131, 22);
			this.txtEnergyMass.TabIndex = 21;
			// 
			// label74
			// 
			this.label74.AutoSize = true;
			this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label74.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label74.Location = new System.Drawing.Point(371, 135);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(94, 22);
			this.label74.TabIndex = 20;
			this.label74.Text = "Mass(Kg)";
			// 
			// plotWorkEnergy
			// 
			this.plotWorkEnergy.BackColor = System.Drawing.Color.Crimson;
			this.plotWorkEnergy.Location = new System.Drawing.Point(792, 367);
			this.plotWorkEnergy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.plotWorkEnergy.Name = "plotWorkEnergy";
			this.plotWorkEnergy.Size = new System.Drawing.Size(457, 337);
			this.plotWorkEnergy.TabIndex = 19;
			// 
			// txtEnergyFinalHeight
			// 
			this.txtEnergyFinalHeight.Location = new System.Drawing.Point(605, 106);
			this.txtEnergyFinalHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtEnergyFinalHeight.Name = "txtEnergyFinalHeight";
			this.txtEnergyFinalHeight.Size = new System.Drawing.Size(131, 22);
			this.txtEnergyFinalHeight.TabIndex = 15;
			// 
			// txtEnergyFirstHeight
			// 
			this.txtEnergyFirstHeight.Location = new System.Drawing.Point(605, 71);
			this.txtEnergyFirstHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtEnergyFirstHeight.Name = "txtEnergyFirstHeight";
			this.txtEnergyFirstHeight.Size = new System.Drawing.Size(131, 22);
			this.txtEnergyFirstHeight.TabIndex = 14;
			// 
			// txtEnergyInitialVelocity
			// 
			this.txtEnergyInitialVelocity.Location = new System.Drawing.Point(605, 38);
			this.txtEnergyInitialVelocity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtEnergyInitialVelocity.Name = "txtEnergyInitialVelocity";
			this.txtEnergyInitialVelocity.Size = new System.Drawing.Size(131, 22);
			this.txtEnergyInitialVelocity.TabIndex = 13;
			// 
			// btnEnergyCalculate
			// 
			this.btnEnergyCalculate.BackColor = System.Drawing.Color.Pink;
			this.btnEnergyCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnEnergyCalculate.Location = new System.Drawing.Point(368, 185);
			this.btnEnergyCalculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnEnergyCalculate.Name = "btnEnergyCalculate";
			this.btnEnergyCalculate.Size = new System.Drawing.Size(117, 34);
			this.btnEnergyCalculate.TabIndex = 12;
			this.btnEnergyCalculate.Text = "Calculate";
			this.btnEnergyCalculate.UseVisualStyleBackColor = false;
			this.btnEnergyCalculate.Click += new System.EventHandler(this.btnEnerjiHesapla_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label11.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label11.Location = new System.Drawing.Point(371, 71);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(140, 22);
			this.label11.TabIndex = 11;
			this.label11.Text = "First height(m)";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label12.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label12.Location = new System.Drawing.Point(371, 106);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(144, 22);
			this.label12.TabIndex = 10;
			this.label12.Text = "Final height(m)";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label13.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label13.Location = new System.Drawing.Point(371, 34);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(374, 22);
			this.label13.TabIndex = 9;
			this.label13.Text = "İnitial velocity: bunu kod kısmında yaptım";
			// 
			// pnlSourcesOfMagnetic
			// 
			this.pnlSourcesOfMagnetic.BackColor = System.Drawing.Color.SlateGray;
			this.pnlSourcesOfMagnetic.Controls.Add(this.formsPlot7);
			this.pnlSourcesOfMagnetic.Controls.Add(this.label50);
			this.pnlSourcesOfMagnetic.Controls.Add(this.label51);
			this.pnlSourcesOfMagnetic.Controls.Add(this.label52);
			this.pnlSourcesOfMagnetic.Controls.Add(this.textBox22);
			this.pnlSourcesOfMagnetic.Controls.Add(this.textBox23);
			this.pnlSourcesOfMagnetic.Controls.Add(this.textBox24);
			this.pnlSourcesOfMagnetic.Controls.Add(this.button15);
			this.pnlSourcesOfMagnetic.Controls.Add(this.label53);
			this.pnlSourcesOfMagnetic.Controls.Add(this.label54);
			this.pnlSourcesOfMagnetic.Controls.Add(this.label55);
			this.pnlSourcesOfMagnetic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlSourcesOfMagnetic.Location = new System.Drawing.Point(0, 0);
			this.pnlSourcesOfMagnetic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlSourcesOfMagnetic.Name = "pnlSourcesOfMagnetic";
			this.pnlSourcesOfMagnetic.Size = new System.Drawing.Size(1283, 753);
			this.pnlSourcesOfMagnetic.TabIndex = 35;
			this.pnlSourcesOfMagnetic.TabStop = true;
			// 
			// formsPlot7
			// 
			this.formsPlot7.BackColor = System.Drawing.Color.Crimson;
			this.formsPlot7.Location = new System.Drawing.Point(375, 225);
			this.formsPlot7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.formsPlot7.Name = "formsPlot7";
			this.formsPlot7.Size = new System.Drawing.Size(552, 375);
			this.formsPlot7.TabIndex = 19;
			// 
			// label50
			// 
			this.label50.AutoSize = true;
			this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label50.Location = new System.Drawing.Point(803, 33);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(116, 22);
			this.label50.TabIndex = 18;
			this.label50.Text = "Max Range:";
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label51.Location = new System.Drawing.Point(803, 62);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(140, 22);
			this.label51.TabIndex = 17;
			this.label51.Text = "Max yükseklik:";
			// 
			// label52
			// 
			this.label52.AutoSize = true;
			this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label52.Location = new System.Drawing.Point(803, 90);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(121, 22);
			this.label52.TabIndex = 16;
			this.label52.Text = "Uçuş süresi:";
			// 
			// textBox22
			// 
			this.textBox22.Location = new System.Drawing.Point(605, 106);
			this.textBox22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBox22.Name = "textBox22";
			this.textBox22.Size = new System.Drawing.Size(131, 22);
			this.textBox22.TabIndex = 15;
			// 
			// textBox23
			// 
			this.textBox23.Location = new System.Drawing.Point(605, 71);
			this.textBox23.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBox23.Name = "textBox23";
			this.textBox23.Size = new System.Drawing.Size(131, 22);
			this.textBox23.TabIndex = 14;
			// 
			// textBox24
			// 
			this.textBox24.Location = new System.Drawing.Point(605, 38);
			this.textBox24.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBox24.Name = "textBox24";
			this.textBox24.Size = new System.Drawing.Size(131, 22);
			this.textBox24.TabIndex = 13;
			// 
			// button15
			// 
			this.button15.BackColor = System.Drawing.Color.Pink;
			this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button15.Location = new System.Drawing.Point(375, 161);
			this.button15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(117, 34);
			this.button15.TabIndex = 12;
			this.button15.Text = "Calculate";
			this.button15.UseVisualStyleBackColor = false;
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label53.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label53.Location = new System.Drawing.Point(371, 71);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(196, 22);
			this.label53.TabIndex = 11;
			this.label53.Text = "Yer çekimi ivmesi (g)";
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label54.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label54.Location = new System.Drawing.Point(371, 106);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(129, 22);
			this.label54.TabIndex = 10;
			this.label54.Text = "Fırlatma açısı";
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label55.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label55.Location = new System.Drawing.Point(371, 34);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(108, 22);
			this.label55.TabIndex = 9;
			this.label55.Text = "İlk hız (v0):";
			// 
			// pnlCapacitance
			// 
			this.pnlCapacitance.BackColor = System.Drawing.Color.SlateGray;
			this.pnlCapacitance.Controls.Add(this.label20);
			this.pnlCapacitance.Controls.Add(this.cmbDielektrik);
			this.pnlCapacitance.Controls.Add(this.lblKapasitansSonuc);
			this.pnlCapacitance.Controls.Add(this.txtKapasitansV);
			this.pnlCapacitance.Controls.Add(this.txtKapasitansD);
			this.pnlCapacitance.Controls.Add(this.txtKapasitansA);
			this.pnlCapacitance.Controls.Add(this.label41);
			this.pnlCapacitance.Controls.Add(this.label42);
			this.pnlCapacitance.Controls.Add(this.label43);
			this.pnlCapacitance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCapacitance.Location = new System.Drawing.Point(0, 0);
			this.pnlCapacitance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlCapacitance.Name = "pnlCapacitance";
			this.pnlCapacitance.Size = new System.Drawing.Size(1283, 753);
			this.pnlCapacitance.TabIndex = 33;
			this.pnlCapacitance.TabStop = true;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label20.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label20.Location = new System.Drawing.Point(361, 151);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(164, 22);
			this.label20.TabIndex = 21;
			this.label20.Text = "Dielektrik Listesi ";
			// 
			// cmbDielektrik
			// 
			this.cmbDielektrik.FormattingEnabled = true;
			this.cmbDielektrik.Items.AddRange(new object[] {
            "Saf Su",
            "Cam",
            "Kağıt",
            "Teflon",
            "Boşluk/Hava"});
			this.cmbDielektrik.Location = new System.Drawing.Point(603, 150);
			this.cmbDielektrik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmbDielektrik.Name = "cmbDielektrik";
			this.cmbDielektrik.Size = new System.Drawing.Size(121, 24);
			this.cmbDielektrik.TabIndex = 20;
			// 
			// lblKapasitansSonuc
			// 
			this.lblKapasitansSonuc.AutoSize = true;
			this.lblKapasitansSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblKapasitansSonuc.Location = new System.Drawing.Point(803, 33);
			this.lblKapasitansSonuc.Name = "lblKapasitansSonuc";
			this.lblKapasitansSonuc.Size = new System.Drawing.Size(151, 22);
			this.lblKapasitansSonuc.TabIndex = 18;
			this.lblKapasitansSonuc.Text = "Sonuç Panosu :";
			// 
			// txtKapasitansV
			// 
			this.txtKapasitansV.Location = new System.Drawing.Point(605, 106);
			this.txtKapasitansV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtKapasitansV.Name = "txtKapasitansV";
			this.txtKapasitansV.Size = new System.Drawing.Size(131, 22);
			this.txtKapasitansV.TabIndex = 15;
			// 
			// txtKapasitansD
			// 
			this.txtKapasitansD.Location = new System.Drawing.Point(605, 71);
			this.txtKapasitansD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtKapasitansD.Name = "txtKapasitansD";
			this.txtKapasitansD.Size = new System.Drawing.Size(131, 22);
			this.txtKapasitansD.TabIndex = 14;
			// 
			// txtKapasitansA
			// 
			this.txtKapasitansA.Location = new System.Drawing.Point(605, 38);
			this.txtKapasitansA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtKapasitansA.Name = "txtKapasitansA";
			this.txtKapasitansA.Size = new System.Drawing.Size(131, 22);
			this.txtKapasitansA.TabIndex = 13;
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label41.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label41.Location = new System.Drawing.Point(371, 71);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(86, 22);
			this.label41.TabIndex = 11;
			this.label41.Text = "Mesafe :";
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label42.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label42.Location = new System.Drawing.Point(371, 106);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(73, 22);
			this.label42.TabIndex = 10;
			this.label42.Text = "Voltaj :";
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label43.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label43.Location = new System.Drawing.Point(371, 34);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(62, 22);
			this.label43.TabIndex = 9;
			this.label43.Text = "Alan :";
			// 
			// pnlInductance
			// 
			this.pnlInductance.BackColor = System.Drawing.Color.SlateGray;
			this.pnlInductance.Controls.Add(this.cmbRL_Durum);
			this.pnlInductance.Controls.Add(this.label23);
			this.pnlInductance.Controls.Add(this.formsPlotRL);
			this.pnlInductance.Controls.Add(this.lblRL_Sonuc);
			this.pnlInductance.Controls.Add(this.txtRL_L);
			this.pnlInductance.Controls.Add(this.txtRL_R);
			this.pnlInductance.Controls.Add(this.txtRL_V);
			this.pnlInductance.Controls.Add(this.btnRL_Hesapla);
			this.pnlInductance.Controls.Add(this.label65);
			this.pnlInductance.Controls.Add(this.label66);
			this.pnlInductance.Controls.Add(this.label67);
			this.pnlInductance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlInductance.Location = new System.Drawing.Point(0, 0);
			this.pnlInductance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlInductance.Name = "pnlInductance";
			this.pnlInductance.Size = new System.Drawing.Size(1283, 753);
			this.pnlInductance.TabIndex = 37;
			this.pnlInductance.TabStop = true;
			// 
			// cmbRL_Durum
			// 
			this.cmbRL_Durum.FormattingEnabled = true;
			this.cmbRL_Durum.Items.AddRange(new object[] {
            "Deşarj (Kısa Devre",
            "Şarj (Anahtar Kapatıldı)"});
			this.cmbRL_Durum.Location = new System.Drawing.Point(605, 135);
			this.cmbRL_Durum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmbRL_Durum.Name = "cmbRL_Durum";
			this.cmbRL_Durum.Size = new System.Drawing.Size(131, 24);
			this.cmbRL_Durum.TabIndex = 21;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label23.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label23.Location = new System.Drawing.Point(371, 134);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(150, 22);
			this.label23.TabIndex = 20;
			this.label23.Text = "Devre Durumu :";
			// 
			// formsPlotRL
			// 
			this.formsPlotRL.BackColor = System.Drawing.Color.Crimson;
			this.formsPlotRL.Location = new System.Drawing.Point(595, 276);
			this.formsPlotRL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.formsPlotRL.Name = "formsPlotRL";
			this.formsPlotRL.Size = new System.Drawing.Size(552, 375);
			this.formsPlotRL.TabIndex = 19;
			// 
			// lblRL_Sonuc
			// 
			this.lblRL_Sonuc.AutoSize = true;
			this.lblRL_Sonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblRL_Sonuc.Location = new System.Drawing.Point(803, 33);
			this.lblRL_Sonuc.Name = "lblRL_Sonuc";
			this.lblRL_Sonuc.Size = new System.Drawing.Size(66, 22);
			this.lblRL_Sonuc.TabIndex = 18;
			this.lblRL_Sonuc.Text = "Sonuç";
			// 
			// txtRL_L
			// 
			this.txtRL_L.Location = new System.Drawing.Point(605, 106);
			this.txtRL_L.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtRL_L.Name = "txtRL_L";
			this.txtRL_L.Size = new System.Drawing.Size(131, 22);
			this.txtRL_L.TabIndex = 15;
			// 
			// txtRL_R
			// 
			this.txtRL_R.Location = new System.Drawing.Point(605, 71);
			this.txtRL_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtRL_R.Name = "txtRL_R";
			this.txtRL_R.Size = new System.Drawing.Size(131, 22);
			this.txtRL_R.TabIndex = 14;
			// 
			// txtRL_V
			// 
			this.txtRL_V.Location = new System.Drawing.Point(605, 38);
			this.txtRL_V.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtRL_V.Name = "txtRL_V";
			this.txtRL_V.Size = new System.Drawing.Size(131, 22);
			this.txtRL_V.TabIndex = 13;
			// 
			// btnRL_Hesapla
			// 
			this.btnRL_Hesapla.BackColor = System.Drawing.Color.Pink;
			this.btnRL_Hesapla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnRL_Hesapla.Location = new System.Drawing.Point(375, 161);
			this.btnRL_Hesapla.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnRL_Hesapla.Name = "btnRL_Hesapla";
			this.btnRL_Hesapla.Size = new System.Drawing.Size(117, 34);
			this.btnRL_Hesapla.TabIndex = 12;
			this.btnRL_Hesapla.Text = "Calculate";
			this.btnRL_Hesapla.UseVisualStyleBackColor = false;
			this.btnRL_Hesapla.Click += new System.EventHandler(this.btnRL_Hesapla_Click);
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label65.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label65.Location = new System.Drawing.Point(371, 71);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(114, 22);
			this.label65.TabIndex = 11;
			this.label65.Text = "Direnç (R) :";
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label66.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label66.Location = new System.Drawing.Point(371, 106);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(133, 22);
			this.label66.TabIndex = 10;
			this.label66.Text = "İndüktans (L):";
			// 
			// label67
			// 
			this.label67.AutoSize = true;
			this.label67.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label67.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label67.Location = new System.Drawing.Point(371, 34);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(180, 22);
			this.label67.TabIndex = 9;
			this.label67.Text = "Batarya Voltajı (V):";
			// 
			// pnlMagneticFields
			// 
			this.pnlMagneticFields.BackColor = System.Drawing.Color.SlateGray;
			this.pnlMagneticFields.Controls.Add(this.txtFaradayV);
			this.pnlMagneticFields.Controls.Add(this.txtFaradayX2);
			this.pnlMagneticFields.Controls.Add(this.label22);
			this.pnlMagneticFields.Controls.Add(this.label21);
			this.pnlMagneticFields.Controls.Add(this.formsPlotFaraday);
			this.pnlMagneticFields.Controls.Add(this.lblFaradaySonuc);
			this.pnlMagneticFields.Controls.Add(this.txtFaradayX1);
			this.pnlMagneticFields.Controls.Add(this.txtFaradayL);
			this.pnlMagneticFields.Controls.Add(this.txtBx);
			this.pnlMagneticFields.Controls.Add(this.btnFaradayHesapla);
			this.pnlMagneticFields.Controls.Add(this.label47);
			this.pnlMagneticFields.Controls.Add(this.label48);
			this.pnlMagneticFields.Controls.Add(this.label49);
			this.pnlMagneticFields.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMagneticFields.Location = new System.Drawing.Point(0, 0);
			this.pnlMagneticFields.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlMagneticFields.Name = "pnlMagneticFields";
			this.pnlMagneticFields.Size = new System.Drawing.Size(1283, 753);
			this.pnlMagneticFields.TabIndex = 34;
			this.pnlMagneticFields.TabStop = true;
			// 
			// txtFaradayV
			// 
			this.txtFaradayV.Location = new System.Drawing.Point(619, 169);
			this.txtFaradayV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFaradayV.Name = "txtFaradayV";
			this.txtFaradayV.Size = new System.Drawing.Size(131, 22);
			this.txtFaradayV.TabIndex = 23;
			// 
			// txtFaradayX2
			// 
			this.txtFaradayX2.Location = new System.Drawing.Point(619, 130);
			this.txtFaradayX2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFaradayX2.Name = "txtFaradayX2";
			this.txtFaradayX2.Size = new System.Drawing.Size(131, 22);
			this.txtFaradayX2.TabIndex = 22;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label22.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label22.Location = new System.Drawing.Point(371, 167);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(139, 22);
			this.label22.TabIndex = 21;
			this.label22.Text = "Çerçeve Hızı v";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label21.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label21.Location = new System.Drawing.Point(371, 134);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(165, 22);
			this.label21.TabIndex = 20;
			this.label21.Text = "Bitiş Konumu x_2";
			// 
			// formsPlotFaraday
			// 
			this.formsPlotFaraday.BackColor = System.Drawing.Color.Crimson;
			this.formsPlotFaraday.Location = new System.Drawing.Point(680, 305);
			this.formsPlotFaraday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.formsPlotFaraday.Name = "formsPlotFaraday";
			this.formsPlotFaraday.Size = new System.Drawing.Size(552, 375);
			this.formsPlotFaraday.TabIndex = 19;
			// 
			// lblFaradaySonuc
			// 
			this.lblFaradaySonuc.AutoSize = true;
			this.lblFaradaySonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblFaradaySonuc.Location = new System.Drawing.Point(803, 33);
			this.lblFaradaySonuc.Name = "lblFaradaySonuc";
			this.lblFaradaySonuc.Size = new System.Drawing.Size(77, 22);
			this.lblFaradaySonuc.TabIndex = 18;
			this.lblFaradaySonuc.Text = "Results";
			// 
			// txtFaradayX1
			// 
			this.txtFaradayX1.Location = new System.Drawing.Point(619, 106);
			this.txtFaradayX1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFaradayX1.Name = "txtFaradayX1";
			this.txtFaradayX1.Size = new System.Drawing.Size(131, 22);
			this.txtFaradayX1.TabIndex = 15;
			// 
			// txtFaradayL
			// 
			this.txtFaradayL.Location = new System.Drawing.Point(619, 71);
			this.txtFaradayL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFaradayL.Name = "txtFaradayL";
			this.txtFaradayL.Size = new System.Drawing.Size(131, 22);
			this.txtFaradayL.TabIndex = 14;
			// 
			// txtBx
			// 
			this.txtBx.Location = new System.Drawing.Point(619, 38);
			this.txtBx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtBx.Name = "txtBx";
			this.txtBx.Size = new System.Drawing.Size(131, 22);
			this.txtBx.TabIndex = 13;
			// 
			// btnFaradayHesapla
			// 
			this.btnFaradayHesapla.BackColor = System.Drawing.Color.Pink;
			this.btnFaradayHesapla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnFaradayHesapla.Location = new System.Drawing.Point(365, 267);
			this.btnFaradayHesapla.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnFaradayHesapla.Name = "btnFaradayHesapla";
			this.btnFaradayHesapla.Size = new System.Drawing.Size(117, 34);
			this.btnFaradayHesapla.TabIndex = 12;
			this.btnFaradayHesapla.Text = "Calculate";
			this.btnFaradayHesapla.UseVisualStyleBackColor = false;
			this.btnFaradayHesapla.Click += new System.EventHandler(this.btnFaradayHesapla_Click);
			// 
			// label47
			// 
			this.label47.AutoSize = true;
			this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label47.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label47.Location = new System.Drawing.Point(371, 71);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(198, 22);
			this.label47.TabIndex = 11;
			this.label47.Text = "Çerçeve Yüksekliği L";
			// 
			// label48
			// 
			this.label48.AutoSize = true;
			this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label48.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label48.Location = new System.Drawing.Point(371, 106);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(213, 22);
			this.label48.TabIndex = 10;
			this.label48.Text = "Başlangıç Konumu x_1";
			// 
			// label49
			// 
			this.label49.AutoSize = true;
			this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label49.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label49.Location = new System.Drawing.Point(371, 34);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(178, 22);
			this.label49.TabIndex = 9;
			this.label49.Text = "Manyetik Alan B(x)";
			// 
			// pnlFaraday
			// 
			this.pnlFaraday.BackColor = System.Drawing.Color.SlateGray;
			this.pnlFaraday.Controls.Add(this.formsPlotFaraday2);
			this.pnlFaraday.Controls.Add(this.lblFaradaySonuc2);
			this.pnlFaraday.Controls.Add(this.txtFaradayV2);
			this.pnlFaraday.Controls.Add(this.txtFaradayR);
			this.pnlFaraday.Controls.Add(this.txtFaradayN);
			this.pnlFaraday.Controls.Add(this.btnFaradayHesapla2);
			this.pnlFaraday.Controls.Add(this.label59);
			this.pnlFaraday.Controls.Add(this.label60);
			this.pnlFaraday.Controls.Add(this.label61);
			this.pnlFaraday.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlFaraday.Location = new System.Drawing.Point(0, 0);
			this.pnlFaraday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlFaraday.Name = "pnlFaraday";
			this.pnlFaraday.Size = new System.Drawing.Size(1283, 753);
			this.pnlFaraday.TabIndex = 36;
			this.pnlFaraday.TabStop = true;
			// 
			// formsPlotFaraday2
			// 
			this.formsPlotFaraday2.BackColor = System.Drawing.Color.Crimson;
			this.formsPlotFaraday2.Location = new System.Drawing.Point(347, 222);
			this.formsPlotFaraday2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.formsPlotFaraday2.Name = "formsPlotFaraday2";
			this.formsPlotFaraday2.Size = new System.Drawing.Size(552, 375);
			this.formsPlotFaraday2.TabIndex = 19;
			// 
			// lblFaradaySonuc2
			// 
			this.lblFaradaySonuc2.AutoSize = true;
			this.lblFaradaySonuc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblFaradaySonuc2.Location = new System.Drawing.Point(803, 33);
			this.lblFaradaySonuc2.Name = "lblFaradaySonuc2";
			this.lblFaradaySonuc2.Size = new System.Drawing.Size(145, 22);
			this.lblFaradaySonuc2.TabIndex = 18;
			this.lblFaradaySonuc2.Text = "Sonuç Panosu:";
			// 
			// txtFaradayV2
			// 
			this.txtFaradayV2.Location = new System.Drawing.Point(615, 106);
			this.txtFaradayV2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFaradayV2.Name = "txtFaradayV2";
			this.txtFaradayV2.Size = new System.Drawing.Size(131, 22);
			this.txtFaradayV2.TabIndex = 15;
			// 
			// txtFaradayR
			// 
			this.txtFaradayR.Location = new System.Drawing.Point(615, 71);
			this.txtFaradayR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFaradayR.Name = "txtFaradayR";
			this.txtFaradayR.Size = new System.Drawing.Size(131, 22);
			this.txtFaradayR.TabIndex = 14;
			// 
			// txtFaradayN
			// 
			this.txtFaradayN.Location = new System.Drawing.Point(615, 33);
			this.txtFaradayN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFaradayN.Name = "txtFaradayN";
			this.txtFaradayN.Size = new System.Drawing.Size(131, 22);
			this.txtFaradayN.TabIndex = 13;
			// 
			// btnFaradayHesapla2
			// 
			this.btnFaradayHesapla2.BackColor = System.Drawing.Color.Pink;
			this.btnFaradayHesapla2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnFaradayHesapla2.Location = new System.Drawing.Point(375, 161);
			this.btnFaradayHesapla2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnFaradayHesapla2.Name = "btnFaradayHesapla2";
			this.btnFaradayHesapla2.Size = new System.Drawing.Size(117, 34);
			this.btnFaradayHesapla2.TabIndex = 12;
			this.btnFaradayHesapla2.Text = "Calculate";
			this.btnFaradayHesapla2.UseVisualStyleBackColor = false;
			this.btnFaradayHesapla2.Click += new System.EventHandler(this.btnFaradayHesapla2_Click);
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label59.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label59.Location = new System.Drawing.Point(371, 71);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(216, 22);
			this.label59.TabIndex = 11;
			this.label59.Text = "Bobin Yarıçapı (r) [cm]:";
			// 
			// label60
			// 
			this.label60.AutoSize = true;
			this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label60.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label60.Location = new System.Drawing.Point(371, 106);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(207, 22);
			this.label60.TabIndex = 10;
			this.label60.Text = "Mıknatıs Hızı (v) [m/s]:";
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label61.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label61.Location = new System.Drawing.Point(371, 34);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(218, 22);
			this.label61.TabIndex = 9;
			this.label61.Text = "Bobin Sarım Sayısı (N):";
			// 
			// TemelFizikForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.ClientSize = new System.Drawing.Size(1283, 753);
			this.Controls.Add(this.pnlSidebar);
			this.Controls.Add(this.pnlMainFizik);
			this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TemelFizikForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "temefizikForm";
			this.pnlSidebar.ResumeLayout(false);
			this.pnlSidebar.PerformLayout();
			this.pnlKinematik.ResumeLayout(false);
			this.pnlKinematik.PerformLayout();
			this.pnlProjectileMotion.ResumeLayout(false);
			this.pnlProjectileMotion.PerformLayout();
			this.pnlMainFizik.ResumeLayout(false);
			this.pnlGaussLaw.ResumeLayout(false);
			this.pnlGaussLaw.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbGaussSurface)).EndInit();
			this.pnlElectricForce.ResumeLayout(false);
			this.pnlElectricForce.PerformLayout();
			this.pnlElectricField.ResumeLayout(false);
			this.pnlElectricField.PerformLayout();
			this.pnlOscillations.ResumeLayout(false);
			this.tabOscillation.ResumeLayout(false);
			this.tabSpringPage.ResumeLayout(false);
			this.tabSpringPage.PerformLayout();
			this.tabPendulumPage.ResumeLayout(false);
			this.tabPendulumPage.PerformLayout();
			this.pnlRotational.ResumeLayout(false);
			this.pnlRotational.PerformLayout();
			this.pnlCollision.ResumeLayout(false);
			this.pnlCollision.PerformLayout();
			this.pnlImpulse.ResumeLayout(false);
			this.pnlImpulse.PerformLayout();
			this.pnlWorkEnergy.ResumeLayout(false);
			this.pnlWorkEnergy.PerformLayout();
			this.pnlSourcesOfMagnetic.ResumeLayout(false);
			this.pnlSourcesOfMagnetic.PerformLayout();
			this.pnlCapacitance.ResumeLayout(false);
			this.pnlCapacitance.PerformLayout();
			this.pnlInductance.ResumeLayout(false);
			this.pnlInductance.PerformLayout();
			this.pnlMagneticFields.ResumeLayout(false);
			this.pnlMagneticFields.PerformLayout();
			this.pnlFaraday.ResumeLayout(false);
			this.pnlFaraday.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlKinematik;
        private System.Windows.Forms.Button btnKinematik;
        private System.Windows.Forms.Panel pnlProjectileMotion;
		private System.Windows.Forms.Button btnProjectileMotion;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKinTotalTime;
		private System.Windows.Forms.TextBox txtKinAcceleration;
		private System.Windows.Forms.TextBox txtKinInitialVelocity;
		private System.Windows.Forms.Button btnKinCalculate;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProjInitialVelocity;
		private System.Windows.Forms.Button btnEgikAtıs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProjAngle;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel pnlMainFizik;
		private ScottPlot.WinForms.FormsPlot formPlotEgikatıs;
		private System.Windows.Forms.Button btnWorkEnergy;
		private System.Windows.Forms.Button btnMenuGaussLaw;
		private System.Windows.Forms.Button btnMenuElectricField;
		private System.Windows.Forms.Button btnOscillation;
		private System.Windows.Forms.Button btnRotational;
		private System.Windows.Forms.Button btnImpulse;
		private System.Windows.Forms.Button btnFaraday;
		private System.Windows.Forms.Button btnMagneticFields;
		private System.Windows.Forms.Button btnCapacitance;
		private System.Windows.Forms.Button btnInductance;
		private System.Windows.Forms.Panel pnlOscillations;
		private ScottPlot.WinForms.FormsPlot plotOscillation;
		private System.Windows.Forms.Panel pnlRotational;
		private ScottPlot.WinForms.FormsPlot plotRotational;
		private System.Windows.Forms.Panel pnlInductance;
		private ScottPlot.WinForms.FormsPlot formsPlotRL;
		private System.Windows.Forms.Label lblRL_Sonuc;
		private System.Windows.Forms.TextBox txtRL_L;
		private System.Windows.Forms.TextBox txtRL_R;
		private System.Windows.Forms.TextBox txtRL_V;
		private System.Windows.Forms.Button btnRL_Hesapla;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Panel pnlFaraday;
		private ScottPlot.WinForms.FormsPlot formsPlotFaraday2;
		private System.Windows.Forms.Label lblFaradaySonuc2;
		private System.Windows.Forms.TextBox txtFaradayV2;
		private System.Windows.Forms.TextBox txtFaradayR;
		private System.Windows.Forms.TextBox txtFaradayN;
		private System.Windows.Forms.Button btnFaradayHesapla2;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Panel pnlSourcesOfMagnetic;
		private ScottPlot.WinForms.FormsPlot formsPlot7;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.TextBox textBox22;
		private System.Windows.Forms.TextBox textBox23;
		private System.Windows.Forms.TextBox textBox24;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Panel pnlMagneticFields;
		private ScottPlot.WinForms.FormsPlot formsPlotFaraday;
		private System.Windows.Forms.Label lblFaradaySonuc;
		private System.Windows.Forms.TextBox txtFaradayX1;
		private System.Windows.Forms.TextBox txtFaradayL;
		private System.Windows.Forms.TextBox txtBx;
		private System.Windows.Forms.Button btnFaradayHesapla;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Panel pnlCapacitance;
		private System.Windows.Forms.Label lblKapasitansSonuc;
		private System.Windows.Forms.TextBox txtKapasitansV;
		private System.Windows.Forms.TextBox txtKapasitansD;
		private System.Windows.Forms.TextBox txtKapasitansA;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Panel pnlGaussLaw;
		private System.Windows.Forms.Label lblGaussRValue;
		private System.Windows.Forms.TextBox txtSphereRadius;
		private System.Windows.Forms.TextBox txtTotalChargeOrDensity;
		private System.Windows.Forms.Button btnCalculateGauss;
		private System.Windows.Forms.Label lblChargeOrDensity;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Panel pnlElectricField;
		private ScottPlot.WinForms.FormsPlot plotElectricField;
		private System.Windows.Forms.TextBox txtElektrikX1;
		private System.Windows.Forms.Button btnCalculateElectricField;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Panel pnlImpulse;
		private ScottPlot.WinForms.FormsPlot plotImpulse;
		private System.Windows.Forms.Panel pnlWorkEnergy;
		private ScottPlot.WinForms.FormsPlot plotWorkEnergy;
		private System.Windows.Forms.TextBox txtEnergyFinalHeight;
		private System.Windows.Forms.TextBox txtEnergyFirstHeight;
		private System.Windows.Forms.TextBox txtEnergyInitialVelocity;
		private System.Windows.Forms.Button btnEnergyCalculate;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.TextBox txtEnergyMass;
		private System.Windows.Forms.Button btnWorkCalculate;
		private System.Windows.Forms.TextBox txtWorkEndX;
		private System.Windows.Forms.TextBox txtWorkStartX;
		private System.Windows.Forms.TextBox txtWorkFunction;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtImpulseInitialVel;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.TextBox txtTimeLimitImpulse;
		private System.Windows.Forms.TextBox txtMassFuncImpulse;
		private System.Windows.Forms.TextBox txtForceFuncImpulse;
		private System.Windows.Forms.Button btnCalculateImpulse;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.ComboBox cmbGeometry;
		private System.Windows.Forms.TextBox txtRotTime;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.TextBox txtRotForce;
		private System.Windows.Forms.TextBox txtRotRadius;
		private System.Windows.Forms.TextBox txtRotMass;
		private System.Windows.Forms.Button btnCalculateRotational;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.Label label83;
		private System.Windows.Forms.TextBox txtSpringAmplitude;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtSpringTimeLimit;
		private System.Windows.Forms.TextBox txtSpringMass;
		private System.Windows.Forms.TextBox txtSpringDamping;
		private System.Windows.Forms.Button btnCalculateOscillation;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TrackBar tbGaussSurface;
		private System.Windows.Forms.ComboBox cmbSystemGeometry;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox cmbDielektrik;
		private System.Windows.Forms.TextBox txtFaradayV;
		private System.Windows.Forms.TextBox txtFaradayX2;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Button hvclikgridon;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.ComboBox cmbRL_Durum;
		private ScottPlot.WinForms.FormsPlot plotProj;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.RichTextBox rtbProjResults;
		private System.Windows.Forms.RichTextBox rtbKinResults;
		private ScottPlot.WinForms.FormsPlot plotKin;
		private System.Windows.Forms.RichTextBox rtbWorkEnergyResults;
		private System.Windows.Forms.CheckBox chkShowSteps;
		private System.Windows.Forms.Button btnCollision;
		private System.Windows.Forms.Panel pnlCollision;
		private System.Windows.Forms.TextBox txtVel2YCollision;
		private System.Windows.Forms.TextBox txtVel1YCollision;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox txtRestitution;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox txtVel2XCollision;
		private System.Windows.Forms.Label label33;
		private ScottPlot.WinForms.FormsPlot plotCollision;
		private System.Windows.Forms.TextBox txtVel1XCollision;
		private System.Windows.Forms.TextBox txtMass2Collision;
		private System.Windows.Forms.TextBox txtMass1Collision;
		private System.Windows.Forms.Button btnCalculateCollision;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.RichTextBox rtbImpulseResults;
		private System.Windows.Forms.RichTextBox rtbCollisionResults;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RichTextBox rtbRotationalResults;
		private System.Windows.Forms.TextBox txtDragCoefRot;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TabControl tabOscillation;
		private System.Windows.Forms.TabPage tabSpringPage;
		private System.Windows.Forms.TabPage tabPendulumPage;
		private System.Windows.Forms.TextBox txtSpringConstant;
		private System.Windows.Forms.Label Genlik;
		private System.Windows.Forms.TextBox txtPendulumLength;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox txtPendulumMass;
		private System.Windows.Forms.TextBox txtPendulumTimeLimit;
		private System.Windows.Forms.TextBox txtPendulumAmplitude;
		private System.Windows.Forms.TextBox txtPendulumDamping;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.RichTextBox rtbOscillationReport;
		private System.Windows.Forms.Button btnMenuElectricForce;
		private System.Windows.Forms.Panel pnlElectricForce;
		private ScottPlot.WinForms.FormsPlot plotElectricalForce;
		private System.Windows.Forms.TextBox txtEForceCharge1;
		private System.Windows.Forms.Button btnCalculateEForce;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.TextBox txtEFieldSourceCharge;
		private System.Windows.Forms.TextBox txtEFieldDistance;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.RichTextBox rtbEField;
		private System.Windows.Forms.RichTextBox rtbElectricalForce;
		private System.Windows.Forms.TextBox txtEForceCharge2;
		private System.Windows.Forms.TextBox txtEForceDistance;
		private System.Windows.Forms.Label lblEForceNature;
		private System.Windows.Forms.RichTextBox rtbGaussResult;
		private ScottPlot.WinForms.FormsPlot chartGaussLaw;
		private System.Windows.Forms.Label lblGaussRegion;
	}
}