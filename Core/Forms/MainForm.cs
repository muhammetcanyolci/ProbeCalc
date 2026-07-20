using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbeCalc
{
	public partial class formProbeCalc : Form
	{
		public formProbeCalc()
		{
			InitializeComponent();
		}

		private void btnBasicPhysic_Click(object sender, EventArgs e)
		{
			TemelFizikForm temelFizikForm = new TemelFizikForm();
			temelFizikForm.Show();
			this.Hide();

		}

		private void btnMath_Click(object sender, EventArgs e)
		{
			MatematikForm matematikForm = new MatematikForm();
			matematikForm.Show();
			this.Hide();
		}

		private void btnUnitconversation_Click(object sender,EventArgs e)
		{

			Birim_Dönüştürme birimDonusturmeForm = new Birim_Dönüştürme();
			birimDonusturmeForm.Show();
			this.Hide();
		}

		private void btnAero_Click(object sender, EventArgs e)
		{
	
			HavacılıkForm havacilikSayfasi = new HavacılıkForm();
			havacilikSayfasi.Show();
			this.Hide();
		}
	}
}
