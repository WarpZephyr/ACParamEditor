using System.Windows.Forms;

namespace ACParamEditor
{
    public static class Extensions
    {
        /// <summary>
        /// Get the selected row indices without having to use full row selection.
        /// </summary>
        /// <param name="datagridview">A DataGridView.</param>
        /// <returns>The list of row indices that have selected cells.</returns>
        public static List<int> GetSelectedRowIndicesBySelectedCells(this DataGridView datagridview)
        {
            var indices = new List<int>();
            if (datagridview == null)
                return indices;
            if (datagridview.ColumnCount == 0)
                return indices;
            if (datagridview.RowCount == 0)
                return indices;
            if (datagridview.CurrentCell == null)
                return indices;

            foreach (DataGridViewCell cell in datagridview.SelectedCells)
            {
                if (!indices.Contains(cell.RowIndex))
                {
                    indices.Add(cell.RowIndex);
                }
            }

            return indices;
        }

        /// <summary>
        /// Get the selected rows without having to use full row selection.
        /// </summary>
        /// <param name="datagridview">A DataGridView.</param>
        /// <returns>The list of rows that have selected cells.</returns>
        public static List<DataGridViewRow> GetSelectedRowsBySelectedCells(this DataGridView datagridview)
        {
            var rows = new List<DataGridViewRow>();
            if (datagridview == null)
                return rows;
            if (datagridview.ColumnCount == 0)
                return rows;
            if (datagridview.RowCount == 0)
                return rows;
            if (datagridview.CurrentCell == null)
                return rows;

            foreach (DataGridViewCell cell in datagridview.SelectedCells)
            {
                if (!rows.Contains(datagridview.Rows[cell.RowIndex]))
                {
                    rows.Add(datagridview.Rows[cell.RowIndex]);
                }
            }

            return rows;
        }

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

        /// <summary>
        /// Check if a ParamInfo list contains a param already.
        /// </summary>
        /// <param name="paramlist">An enumerable list of ParamInfo.</param>
        /// <param name="paraminfo">The param info to check for.</param>
        /// <returns>Whether or not the ParamInfo list contains the param already.</returns>
        public static bool ContainsParam(this IEnumerable<ParamInfo> paramlist, ParamInfo paraminfo)
        {
            foreach (var param in paramlist)
                if (param.Path == paraminfo.Path)
                    return true;
            return false;
        }
    }
}
