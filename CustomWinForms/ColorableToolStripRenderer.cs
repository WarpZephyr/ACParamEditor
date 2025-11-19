using System.Drawing;
using System.Windows.Forms;

namespace CustomWinForms
{
    /// <summary>
    /// A class that inherits ToolStripProfessionalRenderer to override colors based on whats selected, is currently incomplete.
    /// </summary>
    public class ColorableToolStripRenderer : ToolStripProfessionalRenderer
    {
        public Color ArrowColor { get; set; }

        public new SelectableColorTable ColorTable { get; set; }

        public ColorableToolStripRenderer() : base(new SelectableColorTable())
        {
            ArrowColor = Color.White;
            ColorTable = new SelectableColorTable();
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if (e.Item is ToolStripMenuItem)
                e.ArrowColor = ArrowColor;
            base.OnRenderArrow(e);
        }

        // Fix border bug on toolstrips
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {

        }
    }
}
