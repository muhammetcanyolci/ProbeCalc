namespace CalcUni
{
	partial class formCalcuni
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
			this.btnTemelfizik = new System.Windows.Forms.Button();
			this.btnMatematik = new System.Windows.Forms.Button();
			this.btnAero = new System.Windows.Forms.Button();
			this.btnBirimDönüştürme = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label1.Location = new System.Drawing.Point(344, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(536, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hangi alandaki formülleri kullanmak istersiniz?";
			// 
			// btnTemelfizik
			// 
			this.btnTemelfizik.BackColor = System.Drawing.Color.DarkBlue;
			this.btnTemelfizik.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTemelfizik.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.btnTemelfizik.Location = new System.Drawing.Point(381, 123);
			this.btnTemelfizik.Name = "btnTemelfizik";
			this.btnTemelfizik.Size = new System.Drawing.Size(228, 139);
			this.btnTemelfizik.TabIndex = 1;
			this.btnTemelfizik.Text = "Temel Fizik";
			this.btnTemelfizik.UseVisualStyleBackColor = false;
			this.btnTemelfizik.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnMatematik
			// 
			this.btnMatematik.BackColor = System.Drawing.Color.DarkBlue;
			this.btnMatematik.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMatematik.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.btnMatematik.Location = new System.Drawing.Point(615, 123);
			this.btnMatematik.Name = "btnMatematik";
			this.btnMatematik.Size = new System.Drawing.Size(231, 139);
			this.btnMatematik.TabIndex = 5;
			this.btnMatematik.Text = "Matematik";
			this.btnMatematik.UseVisualStyleBackColor = false;
			this.btnMatematik.Click += new System.EventHandler(this.btnMatematik_Click_1);
			// 
			// btnAero
			// 
			this.btnAero.BackColor = System.Drawing.Color.DarkBlue;
			this.btnAero.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAero.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.btnAero.Location = new System.Drawing.Point(381, 286);
			this.btnAero.Name = "btnAero";
			this.btnAero.Size = new System.Drawing.Size(228, 139);
			this.btnAero.TabIndex = 6;
			this.btnAero.Text = "Aeronautics";
			this.btnAero.UseVisualStyleBackColor = false;
			this.btnAero.Click += new System.EventHandler(this.button3_Click_1);
			// 
			// btnBirimDönüştürme
			// 
			this.btnBirimDönüştürme.BackColor = System.Drawing.Color.DarkBlue;
			this.btnBirimDönüştürme.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBirimDönüştürme.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.btnBirimDönüştürme.Location = new System.Drawing.Point(615, 286);
			this.btnBirimDönüştürme.Name = "btnBirimDönüştürme";
			this.btnBirimDönüştürme.Size = new System.Drawing.Size(231, 139);
			this.btnBirimDönüştürme.TabIndex = 7;
			this.btnBirimDönüştürme.Text = "Birim  dönüŞtürme";
			this.btnBirimDönüştürme.UseVisualStyleBackColor = false;
			this.btnBirimDönüştürme.Click += new System.EventHandler(this.btnBirimDönüştürme_Click);
			// 
			// formCalcuni
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(1262, 673);
			this.Controls.Add(this.btnBirimDönüştürme);
			this.Controls.Add(this.btnAero);
			this.Controls.Add(this.btnMatematik);
			this.Controls.Add(this.btnTemelfizik);
			this.Controls.Add(this.label1);
			this.Name = "formCalcuni";
			this.Text = "CalcUni";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnTemelfizik;
		private System.Windows.Forms.Button btnMatematik;
		private System.Windows.Forms.Button btnAero;
		private System.Windows.Forms.Button btnBirimDönüştürme;
	}
}

