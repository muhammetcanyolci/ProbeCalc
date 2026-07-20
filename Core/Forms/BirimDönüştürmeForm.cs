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
	public partial class Birim_Dönüştürme : Form
	{
		public Birim_Dönüştürme()
		{
			InitializeComponent();
		}
		private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmbGirdi.Items.Clear();
			cmbCikti.Items.Clear();

			string secilen = cmbKategori.Text.Trim();
			string[] birimler = new string[0];

			// BİLİMSEL VE MÜHENDİSLİK BİRİMLERİ LİSTESİ
			if (secilen == "Uzunluk") birimler = new[] { "Nanometre (nm)", "Mikrometre (µm)", "Milimetre (mm)", "Santimetre (cm)", "Metre (m)", "Kilometre (km)", "İnç (in)", "Feet (ft)", "Yarda (yd)", "Mil (mi)", "Deniz Mili (NM)" };
			else if (secilen == "Kütle") birimler = new[] { "Miligram (mg)", "Gram (g)", "Kilogram (kg)", "Ton (t)", "Pound (lbs)", "Ons (oz)", "Slug" };
			else if (secilen == "Alan") birimler = new[] { "Milimetrekare (mm²)", "Santimetrekare (cm²)", "Metrekare (m²)", "Kilometrekare (km²)", "Hektar", "Dönüm", "İnç Kare (sq in)", "Feet Kare (sq ft)" };
			else if (secilen == "Hacim") birimler = new[] { "Santimetreküp (cm³ / mL)", "Litre (L)", "Metreküp (m³)", "İnç Küp (cu in)", "Feet Küp (cu ft)", "Galon (US)" };
			else if (secilen == "Hız") birimler = new[] { "Milimetre/Saniye (mm/s)", "Metre/Saniye (m/s)", "Kilometre/Saat (km/h)", "Mil/Saat (mph)", "Knot (kts)", "Mach (Deniz Seviyesi)" };
			else if (secilen == "Sıcaklık") birimler = new[] { "Santigrat (°C)", "Fahrenhayt (°F)", "Kelvin (K)", "Rankine (°R)" };
			else if (secilen == "Basınç") birimler = new[] { "Pascal (Pa)", "Kilopascal (kPa)", "Megapascal (MPa)", "Bar", "Atmosfer (atm)", "PSI", "mmHg" };
			else if (secilen == "Kuvvet") birimler = new[] { "Newton (N)", "Kilonewton (kN)", "Pound-kuvvet (lbf)", "Kilogram-kuvvet (kgf)" };
			else if (secilen == "Enerji") birimler = new[] { "Joule (J)", "Kilojoule (kJ)", "Kalori (cal)", "Kilokalori (kcal)", "Watt-saat (Wh)", "Kilowatt-saat (kWh)", "BTU", "Elektronvolt (eV)" };

			if (birimler.Length > 0)
			{
				cmbGirdi.Items.AddRange(birimler);
				cmbCikti.Items.AddRange(birimler);
				cmbGirdi.SelectedIndex = 0;
				cmbCikti.SelectedIndex = 1;
			}
		}

		private void btnCevir_Click(object sender, EventArgs e)
		{
			try
			{
				double deger = double.Parse(txtDeger.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
				string gBirim = cmbGirdi.Text;
				string cBirim = cmbCikti.Text;

				if (string.IsNullOrWhiteSpace(gBirim) || string.IsNullOrWhiteSpace(cBirim)) return;

				// --- SICAKLIK İÇİN ÖZEL TERMODİNAMİK HESAPLAMALAR ---
				if (cmbKategori.Text == "Sıcaklık")
				{
					double celsius = deger;
					if (gBirim == "Fahrenhayt (°F)") celsius = (deger - 32) * 5 / 9;
					else if (gBirim == "Kelvin (K)") celsius = deger - 273.15;
					else if (gBirim == "Rankine (°R)") celsius = (deger - 491.67) * 5 / 9;

					double sonucS = celsius;
					if (cBirim == "Fahrenhayt (°F)") sonucS = (celsius * 9 / 5) + 32;
					else if (cBirim == "Kelvin (K)") sonucS = celsius + 273.15;
					else if (cBirim == "Rankine (°R)") sonucS = (celsius + 273.15) * 9 / 5;

					lblSonuc.Text = $"{deger} {gBirim} \n=\n {sonucS:F4} {cBirim}";
					lblSonuc.Font = new Font("Consolas", 12, FontStyle.Bold);
					return;
				}

				// --- DEV ÇARPAN SÖZLÜĞÜ (Her kategorinin ilk birimi Baz alınmıştır) ---
				var carpanlar = new Dictionary<string, double>()
		{
            // Uzunluk (Baz: Metre)
            { "Nanometre (nm)", 1e-9 }, { "Mikrometre (µm)", 1e-6 }, { "Milimetre (mm)", 0.001 }, { "Santimetre (cm)", 0.01 }, { "Metre (m)", 1.0 }, { "Kilometre (km)", 1000.0 }, { "İnç (in)", 0.0254 }, { "Feet (ft)", 0.3048 }, { "Yarda (yd)", 0.9144 }, { "Mil (mi)", 1609.344 }, { "Deniz Mili (NM)", 1852.0 },
            
            // Kütle (Baz: Kilogram)
            { "Miligram (mg)", 1e-6 }, { "Gram (g)", 0.001 }, { "Kilogram (kg)", 1.0 }, { "Ton (t)", 1000.0 }, { "Pound (lbs)", 0.453592 }, { "Ons (oz)", 0.0283495 }, { "Slug", 14.5939 },
            
            // Alan (Baz: Metrekare)
            { "Milimetrekare (mm²)", 1e-6 }, { "Santimetrekare (cm²)", 0.0001 }, { "Metrekare (m²)", 1.0 }, { "Kilometrekare (km²)", 1e6 }, { "Hektar", 10000.0 }, { "Dönüm", 1000.0 }, { "İnç Kare (sq in)", 0.00064516 }, { "Feet Kare (sq ft)", 0.092903 },
            
            // Hacim (Baz: Litre)
            { "Santimetreküp (cm³ / mL)", 0.001 }, { "Litre (L)", 1.0 }, { "Metreküp (m³)", 1000.0 }, { "İnç Küp (cu in)", 0.0163871 }, { "Feet Küp (cu ft)", 28.3168 }, { "Galon (US)", 3.78541 },
            
            // Hız (Baz: m/s)
            { "Milimetre/Saniye (mm/s)", 0.001 }, { "Metre/Saniye (m/s)", 1.0 }, { "Kilometre/Saat (km/h)", 0.277778 }, { "Mil/Saat (mph)", 0.44704 }, { "Knot (kts)", 0.514444 }, { "Mach (Deniz Seviyesi)", 340.29 },
            
            // Basınç (Baz: Pascal)
            { "Pascal (Pa)", 1.0 }, { "Kilopascal (kPa)", 1000.0 }, { "Megapascal (MPa)", 1e6 }, { "Bar", 100000.0 }, { "Atmosfer (atm)", 101325.0 }, { "PSI", 6894.76 }, { "mmHg", 133.322 },
            
            // Kuvvet (Baz: Newton)
            { "Newton (N)", 1.0 }, { "Kilonewton (kN)", 1000.0 }, { "Pound-kuvvet (lbf)", 4.44822 }, { "Kilogram-kuvvet (kgf)", 9.80665 },
            
            // Enerji (Baz: Joule)
            { "Joule (J)", 1.0 }, { "Kilojoule (kJ)", 1000.0 }, { "Kalori (cal)", 4.184 }, { "Kilokalori (kcal)", 4184.0 }, { "Watt-saat (Wh)", 3600.0 }, { "Kilowatt-saat (kWh)", 3.6e6 }, { "BTU", 1055.06 }, { "Elektronvolt (eV)", 1.602e-19 }
		};

				if (carpanlar.ContainsKey(gBirim) && carpanlar.ContainsKey(cBirim))
				{
					double bazDeger = deger * carpanlar[gBirim];
					double nihaiSonuc = bazDeger / carpanlar[cBirim];

					// Çok büyük veya çok küçük sayılarda bilimsel gösterim (E formatı) kullan
					if (nihaiSonuc > 1e6 || (nihaiSonuc < 1e-4 && nihaiSonuc > 0))
					{
						lblSonuc.Text = $"{deger} {gBirim} \n=\n {nihaiSonuc:E4} {cBirim}";
					}
					else
					{
						lblSonuc.Text = $"{deger} {gBirim} \n=\n {nihaiSonuc:F6} {cBirim}";
					}

					lblSonuc.Font = new Font("Consolas", 12, FontStyle.Bold);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Lütfen hesaplanabilir geçerli bir sayı girin.", "Girdi Hatası");
			}
		}

		private void btnBirimDönüştürme_Click(object sender, EventArgs e)
		{
			formCalcuni form1 = new formCalcuni();
			form1.Show();
		  this.Hide();
		}

	
	}
	
}
