using System.Drawing;
using System.Windows.Forms;

namespace CustomForms
{
    /// <summary>
    /// A class that inherits ProfessionalColorTable to override colors based on whats selected.
    /// </summary>
    public class SelectableColorTable : ProfessionalColorTable
    {
        public Color CustomMenuBorder                       { get; set; }
        public Color CustomMenuItemSelected                 { get; set; }
        public Color CustomMenuItemBorder                   { get; set; }
        public Color CustomMenuItemPressedGradientBegin     { get; set; }
        public Color CustomMenuItemPressedGradientEnd       { get; set; }
        public Color CustomMenuItemSelectedGradientBegin    { get; set; }
        public Color CustomMenuItemSelectedGradientEnd      { get; set; }
        public Color CustomToolStripDropDownBackground      { get; set; }
        public Color CustomImageMarginGradientBegin         { get; set; }
        public Color CustomImageMarginGradientEnd           { get; set; }

        internal static Color DefaultDark                       = Color.FromArgb(60, 60, 60);
        internal static Color DefaultDarkSelected               = Color.FromArgb(70, 70, 70);
        internal static Color DefaultDarkGradientFlatPressed    = Color.FromArgb(55, 55, 55);
        internal static Color DefaultDarkGradientFlatSelected   = Color.FromArgb(40, 40, 40);
        internal static Color DefaultDarkBackground             = Color.FromArgb(55, 55, 55);

        public SelectableColorTable()
        {
            CustomMenuBorder                    = DefaultDark;
            CustomMenuItemSelected              = DefaultDarkSelected;
            CustomMenuItemBorder                = DefaultDarkBackground;
            CustomMenuItemPressedGradientBegin  = DefaultDarkGradientFlatPressed;
            CustomMenuItemPressedGradientEnd    = DefaultDarkGradientFlatPressed;
            CustomMenuItemSelectedGradientBegin = DefaultDarkGradientFlatSelected;
            CustomMenuItemSelectedGradientEnd   = DefaultDarkGradientFlatSelected;
            CustomToolStripDropDownBackground   = DefaultDarkBackground;
            CustomImageMarginGradientBegin      = DefaultDarkGradientFlatSelected;
            CustomImageMarginGradientEnd        = DefaultDarkGradientFlatSelected;
        }

        /// <summary>
        /// Sets colors back to the default dark colors.
        /// </summary>
        public void SetDefaultDark()
        {
            CustomMenuBorder                    = DefaultDark;
            CustomMenuItemBorder                = DefaultDark;
            CustomMenuItemSelected              = DefaultDarkSelected;
            CustomMenuItemPressedGradientBegin  = DefaultDarkGradientFlatPressed;
            CustomMenuItemPressedGradientEnd    = DefaultDarkGradientFlatPressed;
            CustomMenuItemSelectedGradientBegin = DefaultDarkGradientFlatSelected;
            CustomMenuItemSelectedGradientEnd   = DefaultDarkGradientFlatSelected;
            CustomToolStripDropDownBackground   = DefaultDarkBackground;
            CustomImageMarginGradientBegin      = DefaultDarkGradientFlatSelected;
            CustomImageMarginGradientEnd        = DefaultDarkGradientFlatSelected;
        }

        public override Color MenuBorder
        => CustomMenuBorder;

        public override Color MenuItemBorder
        => CustomMenuItemBorder;

        public override Color MenuItemSelected
        => CustomMenuItemSelected;
        
        public override Color MenuItemSelectedGradientBegin
        => CustomMenuItemSelectedGradientBegin;

        public override Color MenuItemSelectedGradientEnd
        => CustomMenuItemSelectedGradientEnd;

        public override Color MenuItemPressedGradientEnd
        => CustomMenuItemPressedGradientEnd;

        public override Color MenuItemPressedGradientBegin
        => CustomMenuItemPressedGradientBegin;

        public override Color ToolStripDropDownBackground
        => CustomToolStripDropDownBackground;

        public override Color ImageMarginGradientBegin
        => CustomImageMarginGradientBegin;

        public override Color ImageMarginGradientEnd
        => CustomImageMarginGradientEnd;
    }
}
