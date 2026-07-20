namespace ProbeCalc
{
	partial class formProbeCalc
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
			this.btnBasicPhysic = new System.Windows.Forms.Button();
			this.btnMath = new System.Windows.Forms.Button();
			this.btnAero = new System.Windows.Forms.Button();
			this.btnUnitconversation = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label1.Location = new System.Drawing.Point(258, 44);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(441, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hangi alandaki formülleri kullanmak istersiniz?";
			// 
			// btnBasicPhysic
			// 
			this.btnBasicPhysic.BackColor = System.Drawing.Color.DarkBlue;
			this.btnBasicPhysic.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBasicPhysic.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.btnBasicPhysic.Location = new System.Drawing.Point(286, 100);
			this.btnBasicPhysic.Margin = new System.Windows.Forms.Padding(2);
			this.btnBasicPhysic.Name = "btnBasicPhysic";
			this.btnBasicPhysic.Size = new System.Drawing.Size(171, 113);
			this.btnBasicPhysic.TabIndex = 1;
			this.btnBasicPhysic.Text = "Temel Fizik";
			this.btnBasicPhysic.UseVisualStyleBackColor = false;
			this.btnBasicPhysic.Click += new System.EventHandler(this.btnBasicPhysic_Click);
			// 
			// btnMath
			// 
			this.btnMath.BackColor = System.Drawing.Color.DarkBlue;
			this.btnMath.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMath.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.btnMath.Location = new System.Drawing.Point(461, 100);
			this.btnMath.Margin = new System.Windows.Forms.Padding(2);
			this.btnMath.Name = "btnMath";
			this.btnMath.Size = new System.Drawing.Size(173, 113);
			this.btnMath.TabIndex = 5;
			this.btnMath.Text = "Matematik";
			this.btnMath.UseVisualStyleBackColor = false;
			this.btnMath.Click += new System.EventHandler(this.btnMath_Click);
			// 
			// btnAero
			// 
			this.btnAero.BackColor = System.Drawing.Color.DarkBlue;
			this.btnAero.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAero.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.btnAero.Location = new System.Drawing.Point(286, 232);
			this.btnAero.Margin = new System.Windows.Forms.Padding(2);
			this.btnAero.Name = "btnAero";
			this.btnAero.Size = new System.Drawing.Size(171, 113);
			this.btnAero.TabIndex = 6;
			this.btnAero.Text = "Aeronautics";
			this.btnAero.UseVisualStyleBackColor = false;
			this.btnAero.Click += new System.EventHandler(this.btnAero_Click);
			// 
			// btnUnitconversation
			// 
			this.btnUnitconversation.BackColor = System.Drawing.Color.DarkBlue;
			this.btnUnitconversation.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUnitconversation.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.btnUnitconversation.Location = new System.Drawing.Point(461, 232);
			this.btnUnitconversation.Margin = new System.Windows.Forms.Padding(2);
			this.btnUnitconversation.Name = "btnUnitconversation";
			this.btnUnitconversation.Size = new System.Drawing.Size(173, 113);
			this.btnUnitconversation.TabIndex = 7;
			this.btnUnitconversation.Text = "Birim  dönüŞtürme";
			this.btnUnitconversation.UseVisualStyleBackColor = false;
			this.btnUnitconversation.Click += new System.EventHandler(this.btnUnitconversation_Click);
			// 
			// formProbeCalc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(946, 547);
			this.Controls.Add(this.btnUnitconversation);
			this.Controls.Add(this.btnAero);
			this.Controls.Add(this.btnMath);
			this.Controls.Add(this.btnBasicPhysic);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "formProbeCalc";
			this.Text = "ProbeCalc";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBasicPhysic;
		private System.Windows.Forms.Button btnMath;
		private System.Windows.Forms.Button btnAero;
		private System.Windows.Forms.Button btnUnitconversation;
	}
}

