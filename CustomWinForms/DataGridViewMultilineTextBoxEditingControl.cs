using System.Windows.Forms;

namespace CustomWinForms
{
    public class DataGridViewMultilineTextBoxEditingControl : DataGridViewTextBoxEditingControl
    {
        public override bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    return true;
            }

            return base.EditingControlWantsInputKey(keyData, dataGridViewWantsInputKey);
        }
    }
}
