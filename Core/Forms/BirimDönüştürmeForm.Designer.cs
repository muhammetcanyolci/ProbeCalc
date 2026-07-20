namespace ProbeCalc
{
	partial class Birim_Dönüştürme
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCevir = new System.Windows.Forms.Button();
			this.txtDeger = new System.Windows.Forms.TextBox();
			this.cmbCikti = new System.Windows.Forms.ComboBox();
			this.cmbGirdi = new System.Windows.Forms.ComboBox();
			this.lblSonuc = new System.Windows.Forms.Label();
			this.cmbKategori = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBirimDönüştürme = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.SlateGray;
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.btnCevir);
			this.panel1.Controls.Add(this.txtDeger);
			this.panel1.Controls.Add(this.cmbCikti);
			this.panel1.Controls.Add(this.cmbGirdi);
			this.panel1.Controls.Add(this.lblSonuc);
			this.panel1.Controls.Add(this.cmbKategori);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnBirimDönüştürme);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1262, 673);
			this.panel1.TabIndex = 4;
			// 
			// btnCevir
			// 
			this.btnCevir.BackColor = System.Drawing.Color.Pink;
			this.btnCevir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnCevir.Location = new System.Drawing.Point(40, 142);
			this.btnCevir.Name = "btnCevir";
			this.btnCevir.Size = new System.Drawing.Size(118, 35);
			this.btnCevir.TabIndex = 34;
			this.btnCevir.Text = "Calculate";
			this.btnCevir.UseVisualStyleBackColor = false;
			this.btnCevir.Click += new System.EventHandler(this.btnCevir_Click);
			// 
			// txtDeger
			// 
			this.txtDeger.Location = new System.Drawing.Point(238, 100);
			this.txtDeger.Name = "txtDeger";
			this.txtDeger.Size = new System.Drawing.Size(100, 22);
			this.txtDeger.TabIndex = 33;
			// 
			// cmbCikti
			// 
			this.cmbCikti.FormattingEnabled = true;
			this.cmbCikti.Items.AddRange(new object[] {
            " Uzunluk",
            " Kütle",
            " Hız",
            " Sıcaklık",
            " Alan",
            " Hacim"});
			this.cmbCikti.Location = new System.Drawing.Point(541, 98);
			this.cmbCikti.Name = "cmbCikti";
			this.cmbCikti.Size = new System.Drawing.Size(191, 24);
			this.cmbCikti.TabIndex = 32;
			// 
			// cmbGirdi
			// 
			this.cmbGirdi.FormattingEnabled = true;
			this.cmbGirdi.Items.AddRange(new object[] {
            " Uzunluk",
            " Kütle",
            " Hız",
            " Sıcaklık",
            " Alan",
            " Hacim"});
			this.cmbGirdi.Location = new System.Drawing.Point(344, 98);
			this.cmbGirdi.Name = "cmbGirdi";
			this.cmbGirdi.Size = new System.Drawing.Size(191, 24);
			this.cmbGirdi.TabIndex = 31;
			// 
			// lblSonuc
			// 
			this.lblSonuc.AutoSize = true;
			this.lblSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblSonuc.ForeColor = System.Drawing.SystemColors.Control;
			this.lblSonuc.Location = new System.Drawing.Point(369, 155);
			this.lblSonuc.Name = "lblSonuc";
			this.lblSonuc.Size = new System.Drawing.Size(66, 22);
			this.lblSonuc.TabIndex = 30;
			this.lblSonuc.Text = "Sonuç";
			// 
			// cmbKategori
			// 
			this.cmbKategori.FormattingEnabled = true;
			this.cmbKategori.Items.AddRange(new object[] {
            "Uzunluk",
            "Kütle",
            "Alan",
            "Hacim",
            "Hız",
            "Sıcaklık",
            "Basınç",
            "Kuvvet",
            "Enerji"});
			this.cmbKategori.Location = new System.Drawing.Point(41, 100);
			this.cmbKategori.Name = "cmbKategori";
			this.cmbKategori.Size = new System.Drawing.Size(191, 24);
			this.cmbKategori.TabIndex = 2;
			this.cmbKategori.SelectedIndexChanged += new System.EventHandler(this.cmbKategori_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(339, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(228, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "BİRİM DÖNÜŞTÜRME";
			// 
			// btnBirimDönüştürme
			// 
			this.btnBirimDönüştürme.BackColor = System.Drawing.Color.Red;
			this.btnBirimDönüştürme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnBirimDönüştürme.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnBirimDönüştürme.Location = new System.Drawing.Point(1087, 22);
			this.btnBirimDönüştürme.Name = "btnBirimDönüştürme";
			this.btnBirimDönüştürme.Size = new System.Drawing.Size(138, 41);
			this.btnBirimDönüştürme.TabIndex = 0;
			this.btnBirimDönüştürme.Text = "Geri dön";
			this.btnBirimDönüştürme.UseVisualStyleBackColor = false;
			this.btnBirimDönüştürme.Click += new System.EventHandler(this.btnBirimDönüştürme_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.ForeColor = System.Drawing.SystemColors.Control;
			this.label2.Location = new System.Drawing.Point(38, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(440, 20);
			this.label2.TabIndex = 35;
			this.label2.Text = "Yapmak istediğiniz dönüşümü seçip büyüklüğü girin";
			// 
			// Birim_Dönüştürme
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1262, 673);
			this.Controls.Add(this.panel1);
			this.Name = "Birim_Dönüştürme";
			this.Text = "Birim_Dönüştürme";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBirimDönüştürme;
		private System.Windows.Forms.ComboBox cmbKategori;
		private System.Windows.Forms.ComboBox cmbGirdi;
		private System.Windows.Forms.Label lblSonuc;
		private System.Windows.Forms.TextBox txtDeger;
		private System.Windows.Forms.ComboBox cmbCikti;
		private System.Windows.Forms.Button btnCevir;
		private System.Windows.Forms.Label label2;
	}
}