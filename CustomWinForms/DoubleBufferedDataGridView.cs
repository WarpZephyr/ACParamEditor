using System.Windows.Forms;

namespace CustomWinForms
{
    // Got this from a stackoverflow post and modified it.
    // DataGridView draw is faster with DoubleBuffered enabled.
    //
    // Post: https://stackoverflow.com/questions/65481050/scrolling-datagridview-seems-to-bring-down-performance-drastically
    // Answer: https://stackoverflow.com/a/65483301
    // Author: Hans Billiet
    // Date: Dec 28, 2020 at 19:53

    /// <summary>
    /// A DataGridView with DoubleBuffered enabled.
    /// </summary>
    /// <remarks>
    /// Only enables DoubleBuffered if the current session is not a terminal server session unless SetDoubleBuffered() is called.
    /// </remarks>
    public class DoubleBufferedDataGridView : DataGridView
    {
        public DoubleBufferedDataGridView()
        {
            // if not remote desktop session then enable double-buffering optimization
            if (!SystemInformation.TerminalServerSession)
                DoubleBuffered = true;
        }

        /// <summary>
        /// Sets DataGridView DoubleBuffered to true regardless of whether or not the current session is a terminal server session.
        /// </summary>
        public void SetDoubleBuffered()
        {
            DoubleBuffered = true;
        }

        /// <summary>
        /// Sets DataGridView DoubleBuffered to false.
        /// </summary>
        public void UnsetDoubleBuffered()
        {
            DoubleBuffered = false;
        }
    }
}
