namespace CustomForms
{
    public class DataGridViewMultilineTextBoxColumn : DataGridViewTextBoxColumn
    {
        public DataGridViewMultilineTextBoxColumn() : base()
        {
            CellTemplate = new DataGridViewMultlineTextBoxCell();
            DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
