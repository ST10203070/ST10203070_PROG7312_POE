using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ST10203070_PROG7312_POE
{
    public class DarkModeRenderer : ToolStripProfessionalRenderer
    {
        public DarkModeRenderer() : base(new DarkModeColors()) { }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            // Set the text color to white for all menu items when dark mode is enabled
            if (e.Item.Selected)
            {
                e.TextColor = Color.White;
            }
            else
            {
                e.TextColor = Color.White; // Ensures all text is white in dark mode
            }

            // Draw the text using the updated color
            base.OnRenderItemText(e);
        }

    }

    public class DarkModeColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected => Color.FromArgb(60, 60, 64);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(60, 60, 64);
        public override Color MenuItemSelectedGradientEnd => Color.Black;
        public override Color MenuItemBorder => Color.Gray;
        public override Color ToolStripDropDownBackground => Color.FromArgb(45, 45, 48);
        public override Color ImageMarginGradientBegin => Color.FromArgb(45, 45, 48);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(45, 45, 48);
        public override Color ImageMarginGradientEnd => Color.FromArgb(45, 45, 48);
        public override Color MenuBorder => Color.FromArgb(45, 45, 48);
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(60, 60, 64);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(60, 60, 64);
        public override Color MenuItemPressedGradientMiddle => Color.FromArgb(60, 60, 64);
    }
}
