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
		/// /// <summary>
		/// Tüm grafikler için evrensel Koyu Tema (Dark Theme) ayarlarını uygular.
		/// </summary>
		public static void ApplyDarkTheme(FormsPlot plotControl)
		{
			plotControl.Plot.FigureBackground.Color = ScottPlot.Color.FromHex("#1e1e1e");
			plotControl.Plot.DataBackground.Color = ScottPlot.Color.FromHex("#2d2d30");
			plotControl.Plot.Axes.Color(ScottPlot.Colors.LightGray);
			plotControl.Plot.Grid.LineColor = ScottPlot.Color.FromHex("#404040");
		}
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
			ApplyDarkTheme(plotControl);

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
			// Koyu Tema Ayarları
			ApplyDarkTheme(plotControl);

			plotControl.Plot.Axes.AutoScale();
			plotControl.Refresh();
		}
		public static void DrawCollision2DChart(FormsPlot plotControl, double[] x1, double[] y1, double[] x2, double[] y2)
		{
			plotControl.Plot.Clear();

			// 1. Cisim Yörüngesi (Mavi)
			var scatter1 = plotControl.Plot.Add.Scatter(x1, y1);
			scatter1.LineWidth = 3;
			scatter1.Color = Colors.Cyan;
			scatter1.LegendText = "1. Cisim Yörüngesi";

			// 2. Cisim Yörüngesi (Kırmızı)
			var scatter2 = plotControl.Plot.Add.Scatter(x2, y2);
			scatter2.LineWidth = 3;
			scatter2.Color = Colors.Crimson;
			scatter2.LegendText = "2. Cisim Yörüngesi";

			// Çarpışma Merkezine (Orijin) Hedef İşareti Ekleme
			var originMarker = plotControl.Plot.Add.Marker(0, 0);
			originMarker.Color = Colors.Yellow;
			originMarker.Size = 10;
			originMarker.Shape = ScottPlot.MarkerShape.Cross;

			plotControl.Plot.Title("Kuş Bakışı 2D Çarpışma Simülasyonu (X - Y Düzlemi)");
			plotControl.Plot.XLabel("X Konumu (m)");
			plotControl.Plot.YLabel("Y Konumu (m)");

			plotControl.Plot.ShowLegend(ScottPlot.Alignment.UpperLeft);
			// Koyu Tema Ayarları
			ApplyDarkTheme(plotControl);
			// Eksenleri eşit oranda kilitlemek (X ve Y düzlemi gerçeğe uygun görünsün diye)
			plotControl.Plot.Axes.AutoScale();
			plotControl.Plot.Axes.SquareUnits();

			plotControl.Refresh();
		}
	
	public static void DrawRotationalTelemetryChart(FormsPlot plotControl, double[] timeData, double[] rpmData, double[] energyData)
		{
			plotControl.Plot.Clear();

			// 1. Line: RPM (Left Axis - Y1)
			var sigRpm = plotControl.Plot.Add.Scatter(timeData, rpmData);
			sigRpm.Color = ScottPlot.Color.FromHex("#00BFFF");
			sigRpm.LineWidth = 3;
			sigRpm.LegendText = "Rotor Speed (RPM)";
			plotControl.Plot.Axes.Left.Label.Text = "Speed (RPM)";
			plotControl.Plot.Axes.Left.Label.ForeColor = sigRpm.Color;

			// 2. Line: Kinetic Energy (Right Axis - Y2)
			var sigEnergy = plotControl.Plot.Add.Scatter(timeData, energyData);
			sigEnergy.Color = ScottPlot.Color.FromHex("#FF8C00");
			sigEnergy.LineWidth = 3;
			sigEnergy.LegendText = "Kinetic Energy (Joule)";

			// Attach 2nd line to Right Axis
			sigEnergy.Axes.YAxis = plotControl.Plot.Axes.Right;
			plotControl.Plot.Axes.Right.Label.Text = "Energy (J)";
			plotControl.Plot.Axes.Right.Label.ForeColor = sigEnergy.Color;

			// Common Settings
			plotControl.Plot.Title("Rotor Telemetry & Terminal Velocity Curve");
			plotControl.Plot.XLabel("Time (seconds)");
			plotControl.Plot.ShowLegend(ScottPlot.Alignment.LowerRight);

			// Koyu Tema Ayarları
			ApplyDarkTheme(plotControl);

			plotControl.Plot.Axes.AutoScale();
			plotControl.Refresh();
		}
	}
}