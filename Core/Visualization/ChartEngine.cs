using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;
using ScottPlot.WinForms;




namespace CalcUni.Core.Visualization
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

			// ARTIK ETİKETLER DIŞARIDAN GELİYOR! ✅
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
	}

}