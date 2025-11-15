namespace CustomForms
{
    public class DataGridViewMultlineTextBoxCell : DataGridViewTextBoxCell
    {
        public override Type EditType => typeof(DataGridViewMultilineTextBoxEditingControl);
    }
}
