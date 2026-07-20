using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;
using ScottPlot.WinForms;




namespace ProbeCalc.Core.Visualization
{
	public static class ChartEngine
	{
		/// <summary>
		/// Gelen X ve Y koordinatlarını, dinamik eksen isimleriyle birlikte uzay grisi temada çizer.
		/// </summary>
		public static void Draw2DChart(
			FormsPlot plotControl,
			double[] xArray,
			double[] yArray,
			string title,
			string xLabel,
			string yLabel)
		{
			plotControl.Plot.Clear();

			var scatter = plotControl.Plot.Add.Scatter(xArray, yArray);
			scatter.LineWidth = 3;
			scatter.Color = Colors.Cyan;

			// ETİKETLER DIŞARIDAN GELİYOR! ✅
			plotControl.Plot.Title(title);
			plotControl.Plot.XLabel(xLabel);
			plotControl.Plot.YLabel(yLabel);

			// Koyu Tema Ayarları
			plotControl.Plot.FigureBackground.Color = Color.FromHex("#1e1e1e");
			plotControl.Plot.DataBackground.Color = Color.FromHex("#2d2d30");
			plotControl.Plot.Axes.Color(Colors.LightGray);
			plotControl.Plot.Grid.LineColor = Color.FromHex("#404040");

			plotControl.Plot.Axes.AutoScale();
			plotControl.Refresh();
		}
	
/// <summary>
        /// Kinetik, Potansiyel ve Toplam Enerji grafiklerini aynı ekran üzerinde 3 farklı renk çizgisiyle çizer.
        /// </summary>
        public static void DrawEnergyChart(
			FormsPlot plotControl,
			double[] heights,
			double[] kinetic,
			double[] potential,
			double[] total)
		{
			plotControl.Plot.Clear();

			// 1. Potansiyel Enerji Çizgisi (Yeşil)
			var pScatter = plotControl.Plot.Add.Scatter(heights, potential);
			pScatter.LineWidth = 3;
			pScatter.Color = Colors.ForestGreen;
			pScatter.LegendText = "Potansiyel Enerji (Ep)";

			// 2. Kinetik Enerji Çizgisi (Kırmızı)
			var kScatter = plotControl.Plot.Add.Scatter(heights, kinetic);
			kScatter.LineWidth = 3;
			kScatter.Color = Colors.Crimson;
			kScatter.LegendText = "Kinetik Enerji (Ek)";

			// 3. Toplam Enerji Çizgisi (Altın Sarısı - Sabit kalmalı)
			var tScatter = plotControl.Plot.Add.Scatter(heights, total);
			tScatter.LineWidth = 4;
			tScatter.Color = Colors.Gold;
			tScatter.LegendText = "Toplam Mekanik Enerji (E_top)";

			// Eksenler ve Gösterge (Legend) Ayarları
			plotControl.Plot.Title("Mekanik Enerjinin Korunumu Simülasyonu");
			plotControl.Plot.XLabel("Yükseklik (Metre)");
			plotControl.Plot.YLabel("Enerji (Joule)");

			// Hangi çizginin ne olduğunu gösteren kutucuğu sağ üste ekle
			plotControl.Plot.ShowLegend(Alignment.UpperRight);

			// Premium Koyu Tema Ayarları
			plotControl.Plot.FigureBackground.Color = Color.FromHex("#1e1e1e");
			plotControl.Plot.DataBackground.Color = Color.FromHex("#2d2d30");
			plotControl.Plot.Axes.Color(Colors.LightGray);
			plotControl.Plot.Grid.LineColor = Color.FromHex("#404040");

			plotControl.Plot.Axes.AutoScale();
			plotControl.Refresh();
		}
	}
}