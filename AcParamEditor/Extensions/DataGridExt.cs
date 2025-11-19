using System.Windows.Forms;

namespace AcParamEditor.Extensions
{
    internal static class DataGridExt
    {
        /// <summary>
        /// Get the current column via the current cell.
        /// </summary>
        /// <param name="datagridview">A DataGridView.</param>
        /// <returns>The current column.</returns>
        public static DataGridViewColumn? GetCurrentColumn(this DataGridView datagridview)
        {
            if (datagridview.ColumnCount == 0 ||
                datagridview.RowCount == 0 ||
                datagridview.CurrentCell == null)
                return null;

            return datagridview.Columns[datagridview.CurrentCell.ColumnIndex];
        }

        /// <summary>
        /// Get the current column's name via the current cell.
        /// </summary>
        /// <param name="datagridview">A DataGridView.</param>
        /// <returns>The current column's name.</returns>
        public static string? GetCurrentColumnName(this DataGridView datagridview)
            => GetCurrentColumn(datagridview)?.Name;
    }
}
