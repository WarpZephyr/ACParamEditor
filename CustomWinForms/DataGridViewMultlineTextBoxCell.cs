using System;
using System.Windows.Forms;

namespace CustomWinForms
{
    public class DataGridViewMultlineTextBoxCell : DataGridViewTextBoxCell
    {
        public override Type EditType => typeof(DataGridViewMultilineTextBoxEditingControl);
    }
}
