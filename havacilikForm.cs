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
	public partial class havacilikForm : Form
	{
		public havacilikForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			// 1. Arkada gizlenmiş olan Form1'i (Ana Menüyü) bulup tekrar gösteriyoruz
			Application.OpenForms["formcalcuni"].Show();

			// 2. İşimiz bittiği için şu anki sayfayı (Havacılık) tamamen kapatıyoruz
			this.Close();
		}



		private void btnKuvvetHesapla_Click(object sender, EventArgs e)
		{
		
			try
			{
				// 1. Girdileri al ve virgülleri noktaya çevirerek oku
				double V = double.Parse(txtHiz.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
				double rho = double.Parse(txtYogunluk.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
				double S = double.Parse(txtAlan.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
				double CL = double.Parse(txtCL.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
				double CD = double.Parse(txtCD.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
				double m = double.Parse(txtKutle.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
				double T = double.Parse(txtItki.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);

				double g = 9.81; // Yerçekimi ivmesi

				// 2. 4 Temel Kuvveti Hesapla
				double dinamikBasinc = 0.5 * rho * V * V;

				double Lift = dinamikBasinc * S * CL;
				double Drag = dinamikBasinc * S * CD;
				double Weight = m * g;

				// 3. Durum Analizi (Net Kuvvetler)
				double netDikey = Lift - Weight;
				double netYatay = T - Drag;

				string ucusDurumu = "";
				if (netDikey > 0) ucusDurumu += "✈️ Uçak Tırmanıyor (Lift > Weight)\n";
				else if (netDikey < 0) ucusDurumu += "🛬 Uçak Alçalıyor (Weight > Lift)\n";
				else ucusDurumu += "➖ İrtifa Sabit (Lift = Weight)\n";

				if (netYatay > 0) ucusDurumu += "🚀 Uçak Hızlanıyor (Thrust > Drag)\n";
				else if (netYatay < 0) ucusDurumu += "🛑 Uçak Yavaşlıyor (Drag > Thrust)\n";
				else ucusDurumu += "➖ Hız Sabit (Thrust = Drag)\n";

				// 4. Ekrana Çıktı Ver
				lblKuvvetSonuc.Text =
					$"--- 4 TEMEL KUVVET ANALİZİ ---\n\n" +
					$"LIFT (Taşıma):   {Lift:F2} N\n" +
					$"WEIGHT (Ağırlık): {Weight:F2} N\n" +
					$"THRUST (İtki):   {T:F2} N\n" +
					$"DRAG (Sürüklenme):{Drag:F2} N\n\n" +
					$"--- UÇUŞ DURUMU ---\n" +
					ucusDurumu;

				lblKuvvetSonuc.Font = new Font("Consolas", 10, FontStyle.Bold);
			}
			catch (Exception)
			{
				MessageBox.Show("Lütfen tüm alanlara geçerli sayılar girdiğinizden emin olun.\nOndalık kısımlar için nokta veya virgül kullanabilirsiniz.");
			}
		}
	
	}
}
