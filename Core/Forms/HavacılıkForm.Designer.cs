namespace ProbeCalc
{
    partial class HavacılıkForm
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
			this.hvclikgridon = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtCD = new System.Windows.Forms.TextBox();
			this.txtKutle = new System.Windows.Forms.TextBox();
			this.txtItki = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCL = new System.Windows.Forms.TextBox();
			this.label71 = new System.Windows.Forms.Label();
			this.lblKuvvetSonuc = new System.Windows.Forms.Label();
			this.txtAlan = new System.Windows.Forms.TextBox();
			this.txtYogunluk = new System.Windows.Forms.TextBox();
			this.txtHiz = new System.Windows.Forms.TextBox();
			this.btnKuvvetHesapla = new System.Windows.Forms.Button();
			this.ilkhız = new System.Windows.Forms.Label();
			this.label72 = new System.Windows.Forms.Label();
			this.label73 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// hvclikgridon
			// 
			this.hvclikgridon.BackColor = System.Drawing.Color.Red;
			this.hvclikgridon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.hvclikgridon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.hvclikgridon.Location = new System.Drawing.Point(1087, 22);
			this.hvclikgridon.Name = "hvclikgridon";
			this.hvclikgridon.Size = new System.Drawing.Size(138, 41);
			this.hvclikgridon.TabIndex = 0;
			this.hvclikgridon.Text = "Geri dön";
			this.hvclikgridon.UseVisualStyleBackColor = false;
			this.hvclikgridon.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(451, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(209, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "HAVACILIK PANELİ";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.SlateGray;
			this.panel1.Controls.Add(this.txtCD);
			this.panel1.Controls.Add(this.txtKutle);
			this.panel1.Controls.Add(this.txtItki);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtCL);
			this.panel1.Controls.Add(this.label71);
			this.panel1.Controls.Add(this.lblKuvvetSonuc);
			this.panel1.Controls.Add(this.txtAlan);
			this.panel1.Controls.Add(this.txtYogunluk);
			this.panel1.Controls.Add(this.txtHiz);
			this.panel1.Controls.Add(this.btnKuvvetHesapla);
			this.panel1.Controls.Add(this.ilkhız);
			this.panel1.Controls.Add(this.label72);
			this.panel1.Controls.Add(this.label73);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.hvclikgridon);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1262, 673);
			this.panel1.TabIndex = 3;
			// 
			// txtCD
			// 
			this.txtCD.Location = new System.Drawing.Point(417, 205);
			this.txtCD.Name = "txtCD";
			this.txtCD.Size = new System.Drawing.Size(131, 22);
			this.txtCD.TabIndex = 37;
			// 
			// txtKutle
			// 
			this.txtKutle.Location = new System.Drawing.Point(417, 233);
			this.txtKutle.Name = "txtKutle";
			this.txtKutle.Size = new System.Drawing.Size(131, 22);
			this.txtKutle.TabIndex = 36;
			// 
			// txtItki
			// 
			this.txtItki.Location = new System.Drawing.Point(417, 261);
			this.txtItki.Name = "txtItki";
			this.txtItki.Size = new System.Drawing.Size(131, 22);
			this.txtItki.TabIndex = 35;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label4.Location = new System.Drawing.Point(87, 261);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(139, 22);
			this.label4.TabIndex = 34;
			this.label4.Text = "Motor İtkisi [N]";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label3.Location = new System.Drawing.Point(87, 233);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(167, 22);
			this.label3.TabIndex = 33;
			this.label3.Text = "Uçak Kütlesi  [kg]";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label2.Location = new System.Drawing.Point(87, 205);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(267, 22);
			this.label2.TabIndex = 32;
			this.label2.Text = "Sürüklenme Katsayısı  (C_D)";
			// 
			// txtCL
			// 
			this.txtCL.Location = new System.Drawing.Point(417, 177);
			this.txtCL.Name = "txtCL";
			this.txtCL.Size = new System.Drawing.Size(131, 22);
			this.txtCL.TabIndex = 31;
			// 
			// label71
			// 
			this.label71.AutoSize = true;
			this.label71.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label71.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label71.Location = new System.Drawing.Point(87, 177);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(218, 22);
			this.label71.TabIndex = 30;
			this.label71.Text = "Taşıma Katsayısı (C_L)";
			// 
			// lblKuvvetSonuc
			// 
			this.lblKuvvetSonuc.AutoSize = true;
			this.lblKuvvetSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblKuvvetSonuc.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lblKuvvetSonuc.Location = new System.Drawing.Point(664, 91);
			this.lblKuvvetSonuc.Name = "lblKuvvetSonuc";
			this.lblKuvvetSonuc.Size = new System.Drawing.Size(77, 22);
			this.lblKuvvetSonuc.TabIndex = 29;
			this.lblKuvvetSonuc.Text = "Results";
			// 
			// txtAlan
			// 
			this.txtAlan.Location = new System.Drawing.Point(417, 149);
			this.txtAlan.Name = "txtAlan";
			this.txtAlan.Size = new System.Drawing.Size(131, 22);
			this.txtAlan.TabIndex = 28;
			// 
			// txtYogunluk
			// 
			this.txtYogunluk.Location = new System.Drawing.Point(417, 121);
			this.txtYogunluk.Name = "txtYogunluk";
			this.txtYogunluk.Size = new System.Drawing.Size(131, 22);
			this.txtYogunluk.TabIndex = 27;
			// 
			// txtHiz
			// 
			this.txtHiz.Location = new System.Drawing.Point(417, 93);
			this.txtHiz.Name = "txtHiz";
			this.txtHiz.Size = new System.Drawing.Size(131, 22);
			this.txtHiz.TabIndex = 26;
			// 
			// btnKuvvetHesapla
			// 
			this.btnKuvvetHesapla.BackColor = System.Drawing.Color.Pink;
			this.btnKuvvetHesapla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnKuvvetHesapla.Location = new System.Drawing.Point(91, 343);
			this.btnKuvvetHesapla.Name = "btnKuvvetHesapla";
			this.btnKuvvetHesapla.Size = new System.Drawing.Size(118, 35);
			this.btnKuvvetHesapla.TabIndex = 25;
			this.btnKuvvetHesapla.Text = "Calculate";
			this.btnKuvvetHesapla.UseVisualStyleBackColor = false;
			this.btnKuvvetHesapla.Click += new System.EventHandler(this.btnKuvvetHesapla_Click);
			// 
			// ilkhız
			// 
			this.ilkhız.AutoSize = true;
			this.ilkhız.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.ilkhız.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.ilkhız.Location = new System.Drawing.Point(87, 121);
			this.ilkhız.Name = "ilkhız";
			this.ilkhız.Size = new System.Drawing.Size(224, 22);
			this.ilkhız.TabIndex = 24;
			this.ilkhız.Text = "Hava Yoğunluğu [kg/m³]";
			// 
			// label72
			// 
			this.label72.AutoSize = true;
			this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label72.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label72.Location = new System.Drawing.Point(87, 149);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(159, 22);
			this.label72.TabIndex = 23;
			this.label72.Text = "Kanat Alanı  [m²]";
			// 
			// label73
			// 
			this.label73.AutoSize = true;
			this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label73.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label73.Location = new System.Drawing.Point(87, 93);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(87, 22);
			this.label73.TabIndex = 22;
			this.label73.Text = "Hız [m/s]";
			// 
			// havacilikForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.ClientSize = new System.Drawing.Size(1262, 673);
			this.Controls.Add(this.panel1);
			this.Name = "havacilikForm";
			this.Text = "havacilikForm";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hvclikgridon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtCL;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label lblKuvvetSonuc;
		private System.Windows.Forms.TextBox txtAlan;
		private System.Windows.Forms.TextBox txtYogunluk;
		private System.Windows.Forms.TextBox txtHiz;
		private System.Windows.Forms.Button btnKuvvetHesapla;
		private System.Windows.Forms.Label ilkhız;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCD;
		private System.Windows.Forms.TextBox txtKutle;
		private System.Windows.Forms.TextBox txtItki;
	}
}