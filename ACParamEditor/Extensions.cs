namespace ACParamEditor
{
    public static class Extensions
    {
        /// <summary>
        /// Get the current column via the current cell.
        /// </summary>
        /// <param name="datagridview">A DataGridView.</param>
        /// <returns>The current column.</returns>
        public static DataGridViewColumn? GetCurrentColumn(this DataGridView datagridview)
        {
            if (datagridview == null)
                return null;
            if (datagridview.ColumnCount == 0)
                return null;
            if (datagridview.RowCount == 0)
                return null;
            if (datagridview.CurrentCell == null)
                return null;
            return datagridview.Columns[datagridview.CurrentCell.ColumnIndex];
        }

        /// <summary>
        /// Get the current column's name via the current cell.
        /// </summary>
        /// <param name="datagridview">A DataGridView.</param>
        /// <returns>The current column's name.</returns>
        public static string? GetCurrentColumnName(this DataGridView datagridview)
        {
            var column = GetCurrentColumn(datagridview);
            if (column == null)
                return null;
            else
                return column.Name;
        }

        /// <summary>
        /// Get the current column's header text via the current cell.
        /// </summary>
        /// <param name="datagridview">A DataGridView.</param>
        /// <returns>The current column's header text.</returns>
        public static string? GetCurrentColumnHeaderText(this DataGridView datagridview)
        {
            var column = GetCurrentColumn(datagridview);
            if (column == null)
                return null;
            else
                return column.HeaderText;
        }

        /// <summary>
        /// Get the current column's index via the current cell.
        /// </summary>
        /// <param name="datagridview">A DataGridView.</param>
        /// <returns>The current column's index.</returns>
        public static int GetCurrentColumnIndex(this DataGridView datagridview)
        {
            if (datagridview == null)
                return -1;
            if (datagridview.ColumnCount == 0)
                return -1;
            if (datagridview.RowCount == 0)
                return -1;
            if (datagridview.CurrentCell == null)
                return -1;
            return datagridview.CurrentCell.ColumnIndex;
        }
    }
}
