using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcUni
{
	public partial class formCalcuni : Form
	{
		public formCalcuni()
		{
			InitializeComponent();
		}

	

		private void button3_Click_1(object sender, EventArgs e)
		{
			// 1. Yeni sayfanın bir kopyasını oluşturuyoruz
			havacilikForm havacilikSayfasi = new havacilikForm();

			// 2. Yeni sayfayı ekranda gösteriyoruz
			havacilikSayfasi.Show();

			// 3. Şu anki ana ekranı (Form1) gizliyoruz ki arkada kalabalık yapmasın
			this.Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			temefizikForm temefizikForm = new temefizikForm();
			temefizikForm.Show();
			this.Hide();

		}

		

		private void btnMatematik_Click_1(object sender, EventArgs e)
		{
			matematikform matematikForm = new matematikform();
			matematikForm.Show();
			this.Hide();
		}

		private void btnBirimDönüştürme_Click(object sender, EventArgs e)
		{
			Birim_Dönüştürme birimDonusturmeForm = new Birim_Dönüştürme();
			birimDonusturmeForm.Show();
			this.Hide();
		}
	}
}
