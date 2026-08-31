using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbeCalc.Core.Utilities
{
	internal static class ShowingPanel
	{
		public static void ShowPanel( Panel thePanel)
		{
			if (thePanel.Parent != null)
			{
				foreach (Control sibling in thePanel.Parent.Controls)
				{
					if (sibling is Panel siblingPanel && siblingPanel != thePanel)
						siblingPanel.Visible = false;
				}
			}

			thePanel.Visible = true;
			thePanel.BringToFront();
		} 
	}
}
