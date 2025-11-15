#if DEBUG
//#define DEBUG_CRASH
#endif

using CustomForms;
using SoulsFormats;
using System.ComponentModel;
using Utilities;

namespace ACParamEditor
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// The path to the def resource folder.
        /// </summary>
        private static readonly string DefFolderPath = $"{PathUtil.ResourcesFolderPath}\\Def";

        /// <summary>
        /// The path to the dbp resource folder.
        /// </summary>
        private static readonly string DbpFolderPath = $"{PathUtil.ResourcesFolderPath}\\Dbp";

        /// <summary>
        /// The path to the tdf resource folder.
        /// </summary>
        private static readonly string TdfFolderPath = $"{PathUtil.ResourcesFolderPath}\\Tdf";

        /// <summary>
        /// The path to the param resource folder.
        /// </summary>
        private static readonly string ParamFolderPath = $"{PathUtil.ResourcesFolderPath}\\Param";

        /// <summary>
        /// The file name of the TypelessMapping list.
        /// </summary>
        private static readonly string TypelessMappingName = "TypelessMapping.txt";

        /// <summary>
        /// The currently loaded param to def map.
        /// </summary>
        private Dictionary<string, ParamDefInfo> DefMap = new Dictionary<string, ParamDefInfo>();

        /// <summary>
        /// The currently loaded params.
        /// </summary>
        private BindingList<ParamInfo> Params { get; set; } = new BindingList<ParamInfo>();

        /// <summary>
        /// The currently copied param rows.
        /// </summary>
        private List<PARAM.Row> RowCopies { get; set; } = new List<PARAM.Row>();

        /// <summary>
        /// The max number of entries that can be in the log.
        /// </summary>
        private int MaxLogEntries { get; set; } = 1000;

        public MainForm()
        {
            InitializeComponent();

            // Lock events that slow down initialization.
            LockEvents();

            // Prepare the display for multline cell editing
            PrepareMultlineCellEditDisplay();

            // Set new renderer to override colors
            var menuRenderer = new ColorableToolStripRenderer();
            MainFormMenu.Renderer = menuRenderer;
            ParamContextMenu.Renderer = menuRenderer;
            RowContextMenu.Renderer = menuRenderer;
            CellContextMenu.Renderer = menuRenderer;
            LogContextMenu.Renderer = menuRenderer;

            // Disable Image Margins for all subitems of below menu items
            ((ToolStripDropDownMenu)MenuFile.DropDown).ShowImageMargin = false;
            ParamContextMenu.ShowImageMargin = false;
            RowContextMenu.ShowImageMargin = false;
            CellContextMenu.ShowImageMargin = false;
            LogContextMenu.ShowImageMargin = false;

            // Initialization
            RefreshColumnVisibility();
            RefreshDefGames();

            // Set combobox selected item.
            TrySetSavedDefSet();

            // Attempt to load defs.
            UpdateStatus("Initial def load start.");
            LoadDefs();

            // Data bind param list.
            ParamDataGridView.AutoGenerateColumns = false;
            ParamDataGridView.DataSource = Params;
            ParamDataGridView.Columns["paramfilename"].DataPropertyName = "Name";
            ParamDataGridView.Columns["paramtype"].DataPropertyName = "Type";
            ParamDataGridView.Columns["paramformatversion"].DataPropertyName = "ParamFormatVersion";
            ParamDataGridView.Columns["paramdefformatversion"].DataPropertyName = "DefFormatVersion";
            ParamDataGridView.Columns["paramdataversion"].DataPropertyName = "ParamDataVersion";
            ParamDataGridView.Columns["paramdefdataversion"].DataPropertyName = "DefDataVersion";
            ParamDataGridView.Columns["paramgame"].DataPropertyName = "Game";

            // Unlock locked events.
            UnlockEvents();
        }

        #region Form IO

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            UpdateStatus("Opening params.");
            string[] paths = PathUtil.GetFilePaths("C:\\Users", "Open Params", "Param (*.bin)|*.bin|Param (*.param)|*.param|All Files (*)|*");
            if (paths.Length == 0)
            {
                UpdateStatus("Canceling opening params.");
                return;
            }

            LoadParamsFast(paths, sender, e);
        }

        private void MenuFileOpenFromList_Click(object sender, EventArgs e)
        {
            UpdateStatus("Opening params from list.");
            string? listPath = PathUtil.GetFilePath("C:\\Users", "Open Param List", "Text (*.txt)|*.txt|All Files (*)|*");
            if (string.IsNullOrWhiteSpace(listPath))
            {
                UpdateStatus("Canceling opening param list.");
                return;
            }

            string[] list = File.ReadAllLines(listPath);
            if (list.Length < 1)
            {
                UpdateStatus("Nothing in list, canceling opening param list.");
                return;
            }

            if (!list[0].Contains(Path.VolumeSeparatorChar))
            {
                string rootPath = FormUtil.ShowInputDialog("Please input the root path of the list.", "Input Root Path");
                if (string.IsNullOrWhiteSpace(rootPath))
                {
                    UpdateStatus("Root path not valid, canceling opening param list.");
                    return;
                }
                else if (!Directory.Exists(rootPath))
                {
                    UpdateStatus("Root path does not exist, canceling opening param list.");
                    return;
                }

                if (rootPath.EndsWith(Path.DirectorySeparatorChar))
                    rootPath = rootPath[..(rootPath.Length - 1)];

                for (int i = 0; i < list.Length; i++)
                {
                    string corrected = list[i].Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
                    if (!corrected.StartsWith(Path.DirectorySeparatorChar))
                        corrected = Path.DirectorySeparatorChar + corrected;

                    list[i] = rootPath + corrected;
                }
            }

            LoadParamsFast(list, sender, e);
        }

        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormUtil.ShowQuestionDialog("Are you sure you want to save all currently selected params?", "Save Selected Params");
            if (!question)
                return;

            var saved = new List<int>();
            foreach (DataGridViewCell cell in ParamDataGridView.SelectedCells)
            {
                if (!saved.Contains(cell.RowIndex))
                {
                    var paraminfo = (ParamInfo)ParamDataGridView.Rows[cell.RowIndex].DataBoundItem;
                    PathUtil.Backup(paraminfo.Path);
                    paraminfo.WriteToPath();
                    saved.Add(cell.RowIndex);
                }
            }

            UpdateStatus($"Saved {saved.Count} params.");
        }

        private void MenuFileSaveAll_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormUtil.ShowQuestionDialog("Are you sure you want to save all params?", "Save All Params");
            if (!question)
                return;

            int count = ParamDataGridView.RowCount;
            foreach (DataGridViewRow row in ParamDataGridView.Rows)
            {
                var paraminfo = (ParamInfo)row.DataBoundItem;
                PathUtil.Backup(paraminfo.Path);
                paraminfo.WriteToPath();
            }

            UpdateStatus($"Saved all {count} params.");
        }

        private void MenuFileClose_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormUtil.ShowQuestionDialog("Are you sure you want to close all currently selected params?", "Close Selected Params");
            if (!question)
                return;

            var closed = new List<int>();
            foreach (DataGridViewCell cell in ParamDataGridView.SelectedCells)
            {
                if (!closed.Contains(cell.RowIndex))
                {
                    var paraminfo = (ParamInfo)ParamDataGridView.Rows[cell.RowIndex].DataBoundItem;
                    Params.Remove(paraminfo);
                    closed.Add(cell.RowIndex);
                }
            }

            RefreshDataGridViews();
            UpdateStatus($"Closed {closed.Count} params.");
        }

        private void MenuFileCloseAll_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormUtil.ShowQuestionDialog("Are you sure you want to close all params?", "Close All Params");
            if (!question)
                return;

            int count = ParamDataGridView.RowCount;
            Params.Clear();
            RefreshDataGridViews();
            UpdateStatus($"Closed all {count} params.");
        }

        private void MenuFileReload_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormUtil.ShowQuestionDialog("Are you sure you want to reload all currently selected params without saving?", "Reload Selected Params");
            if (!question)
                return;

            var paths = new List<string>();
            var closed = new List<int>();
            foreach (DataGridViewCell cell in ParamDataGridView.SelectedCells)
            {
                if (!closed.Contains(cell.RowIndex))
                {
                    var paraminfo = (ParamInfo)ParamDataGridView.Rows[cell.RowIndex].DataBoundItem;
                    paths.Add(paraminfo.Path);
                    Params.Remove(paraminfo);
                    closed.Add(cell.RowIndex);
                }
            }

            LoadParamsFast(paths, sender, e);
            RefreshDataGridViews();
            UpdateStatus($"Reloaded {closed.Count} params.");
        }

        private void MenuFileReloadAll_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormUtil.ShowQuestionDialog("Are you sure you want to reload all params without saving?", "Reload All Params");
            if (!question)
                return;

            var paths = new List<string>();
            foreach (var paraminfo in Params)
            {
                paths.Add(paraminfo.Path);
            }

            Params.Clear();
            LoadParamsFast(paths, sender, e);
            RefreshDataGridViews();
            UpdateStatus($"Reloaded all {paths.Count} params.");
        }

        #endregion

        #region Form Export

        private void MenuExportParamdefs_Click(object sender, EventArgs e)
        {
            UpdateStatus("Exporting paramdefs.");
            string? folderPath = PathUtil.GetFolderPath();
            if (folderPath == null)
            {
                UpdateStatus("Canceling exporting paramdefs.");
                return;
            }

            ExportXmlDefs(folderPath);
            UpdateStatus("Exported paramdefs.");
        }

        #endregion

        #region Form View

        private void ParamViewName_Click(object sender, EventArgs e)
        {
            ParamDataGridView.Columns["paramfilename"].Visible = ParamViewName.Checked;
            UpdateStatus(ParamViewName.Checked ? "Showing Names" : "Hid Names");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewType_Click(object sender, EventArgs e)
        {
            ParamDataGridView.Columns["paramtype"].Visible = ParamViewType.Checked;
            UpdateStatus(ParamViewType.Checked ? "Showing Types" : "Hid Types");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewParamFormatVersion_Click(object sender, EventArgs e)
        {
            ParamDataGridView.Columns["paramformatversion"].Visible = ParamViewParamFormatVersion.Checked;
            UpdateStatus(ParamViewParamFormatVersion.Checked ? "Showing Param Format Versions" : "Hid Param Format Versions");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewDefFormatVersion_Click(object sender, EventArgs e)
        {
            ParamDataGridView.Columns["paramdefformatversion"].Visible = ParamViewDefFormatVersion.Checked;
            UpdateStatus(ParamViewParamFormatVersion.Checked ? "Showing Def Format Versions" : "Hid Def Format Versions");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewParamDataVersion_Click(object sender, EventArgs e)
        {
            ParamDataGridView.Columns["paramdataversion"].Visible = ParamViewParamDataVersion.Checked;
            UpdateStatus(ParamViewParamDataVersion.Checked ? "Showing Param Data Versions" : "Hid Param Data Versions");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewDefDataVersion_Click(object sender, EventArgs e)
        {
            ParamDataGridView.Columns["paramdefdataversion"].Visible = ParamViewDefDataVersion.Checked;
            UpdateStatus(ParamViewParamDataVersion.Checked ? "Showing Def Data Versions" : "Hid Def Data Versions");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewGame_Click(object sender, EventArgs e)
        {
            ParamDataGridView.Columns["paramgame"].Visible = ParamViewGame.Checked;
            UpdateStatus(ParamViewType.Checked ? "Showing Games" : "Hid Games");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void RowViewID_Click(object sender, EventArgs e)
        {
            RowDataGridView.Columns["paramrowid"].Visible = RowViewID.Checked;
            UpdateStatus(RowViewID.Checked ? "Showing IDs" : "Hid IDs");
            RowContextMenu.Show();
            RowView.DropDown.Show();
        }

        private void RowViewName_Click(object sender, EventArgs e)
        {
            RowDataGridView.Columns["paramrowname"].Visible = RowViewName.Checked;
            UpdateStatus(RowViewName.Checked ? "Showing Row Names" : "Hid Row Names");
            RowContextMenu.Show();
            RowView.DropDown.Show();
        }

        private void CellViewDisplayType_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcelldisplaytype"].Visible = CellViewDisplayType.Checked;
            UpdateStatus(CellViewDisplayType.Checked ? "Showing Cell Display Types" : "Hid Cell Display Types");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewInternalType_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellinternaltype"].Visible = CellViewInternalType.Checked;
            UpdateStatus(CellViewInternalType.Checked ? "Showing Cell Internal Types" : "Hid Cell Internal Types");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewValue_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellvalue"].Visible = CellViewValue.Checked;
            UpdateStatus(CellViewValue.Checked ? "Showing Cell Values" : "Hid Cell Values");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewDisplayName_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcelldisplayname"].Visible = CellViewDisplayName.Checked;
            UpdateStatus(CellViewDisplayName.Checked ? "Showing Cell Display Names" : "Hid Cell Display Names");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewInternalName_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellinternalname"].Visible = CellViewInternalName.Checked;
            UpdateStatus(CellViewInternalName.Checked ? "Showing Cell Internal Names" : "Hid Cell Internal Names");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewDescription_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcelldescription"].Visible = CellViewDescription.Checked;
            UpdateStatus(CellViewDescription.Checked ? "Showing Cell Descriptions" : "Hid Cell Descriptions");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewDisplayFormat_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcelldisplayformat"].Visible = CellViewDisplayFormat.Checked;
            UpdateStatus(CellViewDisplayFormat.Checked ? "Showing Cell Display Formats" : "Hid Cell Display Formats");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewDefault_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcelldefault"].Visible = CellViewDefault.Checked;
            UpdateStatus(CellViewDefault.Checked ? "Showing Cell Default Values" : "Hid Cell Default Values");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewIncrement_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellincrement"].Visible = CellViewIncrement.Checked;
            UpdateStatus(CellViewIncrement.Checked ? "Showing Cell Increment Amount" : "Hid Cell Increment Amount");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewMinimum_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellminimum"].Visible = CellViewMinimum.Checked;
            UpdateStatus(CellViewMinimum.Checked ? "Showing Cell Minimum Values" : "Hid Cell Mimimum Values");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewMaximum_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellmaximum"].Visible = CellViewMaximum.Checked;
            UpdateStatus(CellViewMaximum.Checked ? "Showing Cell Maximum Values" : "Hid Cell Maximum Values");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewSortID_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellsortid"].Visible = CellViewSortID.Checked;
            UpdateStatus(CellViewSortID.Checked ? "Showing Cell Sort IDs" : "Hid Cell Sort IDs");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewArrayLength_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellarraylength"].Visible = CellViewArrayLength.Checked;
            UpdateStatus(CellViewArrayLength.Checked ? "Showing Cell Array Lengths" : "Hid Cell Array Lengths");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewBitSize_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellbitsize"].Visible = CellViewBitSize.Checked;
            UpdateStatus(CellViewBitSize.Checked ? "Showing Cell Bit Sizes" : "Hid Cell Bit Sizes");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        #endregion

        #region Form Log

        private void LogContextMenuCopy_Click(object sender, EventArgs e)
        {
            var copy_buffer = new System.Text.StringBuilder();
            foreach (object item in LogListBox.Items)
            {
                copy_buffer.AppendLine(item.ToString());
            }

            if (copy_buffer.Length > 0)
            {
                Clipboard.SetDataObject(copy_buffer.ToString());
            }
        }

        private void LogContextMenuClear_Click(object sender, EventArgs e)
        {
            LogListBox.Items.Clear();
        }

        private void LogListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                var copy_buffer = new System.Text.StringBuilder();
                foreach (object item in LogListBox.SelectedItems)
                {
                    copy_buffer.AppendLine(item.ToString());
                }

                if (copy_buffer.Length > 0)
                {
                    Clipboard.SetDataObject(copy_buffer.ToString());
                }
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                for (int i = 0; i < LogListBox.Items.Count; i++)
                {
                    LogListBox.SetSelected(i, true);
                }
            }
        }

        #endregion

        #region Form DataGridView

        private void ParamDataGridView_SelectionChanged(object? sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            RefreshRows();
        }

        private void RowDataGridView_SelectionChanged(object? sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            var currentparam = (ParamInfo)ParamDataGridView.CurrentRow.DataBoundItem;
            if (currentparam.RowCount == 0)
            {
                CellDataGridView.DataSource = null;
                return;
            }

            if (RowDataGridView.CurrentRow.Index + 1 > currentparam.RowCount)
                return;

            CellDataGridView.AutoGenerateColumns = false;
            CellDataGridView.DataSource = ((PARAM.Row)RowDataGridView.CurrentRow.DataBoundItem).Cells;

            CellDataGridView.Columns["paramcelldisplaytype"].DataPropertyName = "DisplayType";
            CellDataGridView.Columns["paramcellinternaltype"].DataPropertyName = "InternalType";
            CellDataGridView.Columns["paramcellvalue"].DataPropertyName = "Value";
            CellDataGridView.Columns["paramcelldisplayname"].DataPropertyName = "DisplayName";
            CellDataGridView.Columns["paramcellinternalname"].DataPropertyName = "InternalName";
            CellDataGridView.Columns["paramcelldescription"].DataPropertyName = "Description";
            CellDataGridView.Columns["paramcelldisplayformat"].DataPropertyName = "DisplayFormat";
            CellDataGridView.Columns["paramcelldefault"].DataPropertyName = "Default";
            CellDataGridView.Columns["paramcellincrement"].DataPropertyName = "Increment";
            CellDataGridView.Columns["paramcellminimum"].DataPropertyName = "Minimum";
            CellDataGridView.Columns["paramcellmaximum"].DataPropertyName = "Maximum";
            CellDataGridView.Columns["paramcellsortid"].DataPropertyName = "SortID";
            CellDataGridView.Columns["paramcellarraylength"].DataPropertyName = "ArrayLength";
            CellDataGridView.Columns["paramcellbitsize"].DataPropertyName = "BitSize";
        }

        private void RowDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!RowDataGridView.IsCurrentCellInEditMode)
                return;

            if (RowDataGridView.GetCurrentColumnName() == "paramrowid")
            {
                try
                {
                    int id = Convert.ToInt32(e.FormattedValue);
                }
                catch
                {
                    RowDataGridView.CancelEdit();
                    UpdateStatus($"{e.FormattedValue} is not a valid row ID.");
                }
            }
        }

        private void CellDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!CellDataGridView.IsCurrentCellInEditMode)
                return;

            var cell = (PARAM.Cell)CellDataGridView.CurrentRow.DataBoundItem;
            if (!CellValueValid(cell, e.FormattedValue))
            {
                CellDataGridView.CancelEdit();
                CellDataGridView.EndEdit();
                UpdateStatus($"Invalid value: {e.FormattedValue}");
            }
        }

        private void CellDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Unfortunately the data grid editing cell object only displays \r\n as newlines
            // This will overwrite any singular \n with \r\n to fix that, while also making all newlines save that way
            if (e.Value is string str)
            {
                // If we replace \n right away we could end up with \r\r\n
                // First replace \r\n with \n, then fix it back with \n to \r\n
                e.Value = str.Replace("\r\n", "\n").Replace("\n", "\r\n");
            }
        }

        private void PrepareMultlineCellEditDisplay()
        {
            // This somehow updates the edited cell as it's being edited to resize it cleanly.
            // https://stackoverflow.com/a/78950461
            CellDataGridView.EditingControlShowing += (sender, e) =>
            {
                if (e.Control is TextBox textBox)
                {
                    string revertText = textBox.Text;
                    textBox.TextChanged -= OnTextChanged;
                    textBox.PreviewKeyDown -= PreviewKeyDown;
                    textBox.TextChanged += OnTextChanged;
                    textBox.PreviewKeyDown += PreviewKeyDown;

                    void OnTextChanged(object? sender, EventArgs e)
                    {
                        BeginInvoke(() => // Because drawing artifacts have been known to occur otherwise.
                        {
                            CellDataGridView.CurrentCell.Value = textBox.Text;
                        });
                    }

                    void PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
                    {
                        if (e.KeyData == Keys.Escape)
                        {
                            CellDataGridView.CurrentCell.Value = revertText;
                        }
                    }
                }
            };
        }

        #endregion

        #region Form Game Combobox

        private void MenuGameCombobox_DropDown(object sender, EventArgs e)
        {
            RefreshDefGames();
        }

        private void MenuGameCombobox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // TODO: Make defset system clearer by not relying on the combobox as data storage
            // Try to save our new selection if possible, otherwise save "None"
            if (MenuGameCombobox.SelectedIndex < MenuGameCombobox.Items.Count)
            {
                string? selection = MenuGameCombobox.Items[MenuGameCombobox.SelectedIndex] as string ?? "None";
                Properties.Settings.Default.SelectedDefSet = selection;
                Properties.Settings.Default.Save();
            }

            LoadDefs();
        }

        #endregion

        #region Form DragDrop

        private void ParamSplitContainerOuter_DragEnter(object sender, DragEventArgs e)
        {
            var data = e.Data;
            if (data == null)
                return;

            if (data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void ParamSplitContainerOuter_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data;
            if (data == null)
                return;

            string[] paths = (string[])data.GetData(DataFormats.FileDrop);
            LoadParamsFast(paths, sender, e);
        }

        #endregion

        #region Form Rows

        private void RowNew_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            var currentparam = (ParamInfo)ParamDataGridView.CurrentRow.DataBoundItem;
            int id = 1;
            if (currentparam.Param.Rows.Count > 0)
                id = currentparam.GetNextRowID();
            currentparam.Param.Rows.Add(new PARAM.Row(id, "NEWROW", currentparam.Param.AppliedParamdef));

            RefreshRows();
            UpdateStatus("Made a new row.");
        }

        private void RowDelete_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormUtil.ShowQuestionDialog("Are you sure you wish to delete the currently selected rows?", "Delete Currently Selected Rows");
            if (!question)
            {
                UpdateStatus("Canceled row deletion.");
                return;
            }

            var currentparam = (ParamInfo)ParamDataGridView.CurrentRow.DataBoundItem;

            var removalList = new List<PARAM.Row>();
            foreach (DataGridViewCell cell in RowDataGridView.SelectedCells)
            {
                var row = (PARAM.Row)RowDataGridView.Rows[cell.RowIndex].DataBoundItem;
                if (!removalList.Contains(row))
                {
                    removalList.Add(row);
                }
            }

            foreach (var row in removalList)
            {
                currentparam.Param.Rows.Remove(row);
            }

            RefreshRows();
            UpdateStatus($"Deleted {removalList.Count} rows.");
        }

        private void RowCopy_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.CurrentRow == null)
                return;

            var copies = new List<PARAM.Row>();
            var found = new List<int>();
            foreach (DataGridViewCell cell in RowDataGridView.SelectedCells)
            {
                if (!found.Contains(cell.RowIndex))
                {
                    copies.Add(new PARAM.Row((PARAM.Row)RowDataGridView.Rows[cell.RowIndex].DataBoundItem));
                    found.Add(cell.RowIndex);
                }
            }
            RowCopies = copies;
            UpdateStatus($"Copied {RowCopies.Count} rows.");
        }

        private void RowPaste_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.CurrentRow == null || RowCopies.Count == 0)
                return;

            var currentparam = (ParamInfo)ParamDataGridView.CurrentRow.DataBoundItem;

            if (!currentparam.RowCompatible(RowCopies[0]))
            {
                UpdateStatus($"Copied rows are not compatibile.");
                return;
            }

            int count = 0;
            foreach (var row in RowCopies)
            {
                var rows = (List<PARAM.Row>)RowDataGridView.DataSource;
                if (rows.Count == ushort.MaxValue)
                {
                    UpdateStatus($"Row limit of {ushort.MaxValue} reached, stopped pasting.");
                    UpdateStatus($"Pasted {count} rows.");
                    return;
                }

                if (currentparam.ContainsRowID(row.ID))
                    row.ID = currentparam.GetNextRowID();
                rows.Add(row);
                count++;
            }

            RefreshRows();
            UpdateStatus($"Pasted {count} rows.");
        }

        private void RowDuplicate_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.CurrentRow == null)
                return;

            var copies = new List<PARAM.Row>();
            var found = new List<int>();
            foreach (DataGridViewCell cell in RowDataGridView.SelectedCells)
            {
                if (!found.Contains(cell.RowIndex))
                {
                    copies.Add(new PARAM.Row((PARAM.Row)RowDataGridView.Rows[cell.RowIndex].DataBoundItem));
                    found.Add(cell.RowIndex);
                }
            }

            var currentparam = (ParamInfo)ParamDataGridView.CurrentRow.DataBoundItem;

            int count = 0;
            foreach (var row in copies)
            {
                var rows = (List<PARAM.Row>)RowDataGridView.DataSource;
                if (rows.Count == ushort.MaxValue)
                {
                    UpdateStatus($"Row limit of {ushort.MaxValue} reached, stopped duplicating.");

                    RefreshRows();
                    UpdateStatus($"Duplicated {count} rows.");
                    return;
                }

                if (currentparam.ContainsRowID(row.ID))
                    row.ID = currentparam.GetNextRowID();
                rows.Add(row);
            }

            RefreshRows();
            UpdateStatus($"Duplicated {count} rows.");
        }

        #endregion

        #region Form Key Events

        private void ParamDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.Shift)
                {
                    if (e.KeyCode == Keys.S) MenuFileSaveAll_Click(sender, e);
                    else if (e.KeyCode == Keys.D) MenuFileCloseAll_Click(sender, e);
                    else if (e.KeyCode == Keys.R) MenuFileReloadAll_Click(sender, e);
                }
                else
                {
                    if (e.KeyCode == Keys.S) MenuFileSave_Click(sender, e);
                    else if (e.KeyCode == Keys.D) MenuFileClose_Click(sender, e);
                    else if (e.KeyCode == Keys.R) MenuFileReload_Click(sender, e);
                    else if (e.KeyCode == Keys.O) MenuFileOpen_Click(sender, e);
                }
            }
            else
            {

            }
        }

        private void RowDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.Shift)
                {

                }
                else
                {
                    if (e.KeyCode == Keys.N) RowNew_Click(sender, e);
                    else if (e.KeyCode == Keys.C) RowCopy_Click(sender, e);
                    else if (e.KeyCode == Keys.V) RowPaste_Click(sender, e);
                    else if (e.KeyCode == Keys.D) RowDuplicate_Click(sender, e);
                }
            }
            else
            {
                if (e.KeyCode == Keys.Delete) RowDelete_Click(sender, e);
            }
        }

        #endregion

        #region Refresh

        private void RefreshAll()
        {
            RefreshParamOpenAccess();
            RefreshDataGridViews();
            RefreshRows();
            RefreshColumnVisibility();
            RefreshDefGames();
            UpdateStatus("Refreshed form.");
        }

        private void RefreshParamOpenAccess()
        {
            if (DefMap.Count == 0)
            {
                MenuFileOpen.Enabled = false;
                MenuFileSave.Enabled = false;
                MenuFileSaveAll.Enabled = false;
                MenuFileClose.Enabled = false;
                MenuFileCloseAll.Enabled = false;
                ParamSplitContainerOuter.AllowDrop = false;
            }
            else
            {
                MenuFileOpen.Enabled = true;
                MenuFileSave.Enabled = true;
                MenuFileSaveAll.Enabled = true;
                MenuFileClose.Enabled = true;
                MenuFileCloseAll.Enabled = true;
                ParamSplitContainerOuter.AllowDrop = true;
            }
        }

        private void RefreshDataGridViews()
        {
            if (ParamDataGridView.Rows.Count == 0)
            {
                RowDataGridView.DataSource = null;
                CellDataGridView.DataSource = null;
            }
        }

        private void RefreshRows()
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            RowDataGridView.AutoGenerateColumns = false;
            RowDataGridView.DataSource = new List<PARAM.Row>();
            RowDataGridView.DataSource = ((ParamInfo)ParamDataGridView.CurrentRow.DataBoundItem).Param.Rows;
            RowDataGridView.Columns["paramrowid"].DataPropertyName = "ID";
            RowDataGridView.Columns["paramrowname"].DataPropertyName = "Name";
        }

        private void RefreshColumnVisibility()
        {
            ParamDataGridView.Columns["paramfilename"].Visible = ParamViewName.Checked;
            ParamDataGridView.Columns["paramtype"].Visible = ParamViewType.Checked;
            ParamDataGridView.Columns["paramgame"].Visible = ParamViewGame.Checked;
            RowDataGridView.Columns["paramrowid"].Visible = RowViewID.Checked;
            RowDataGridView.Columns["paramrowname"].Visible = RowViewName.Checked;
            CellDataGridView.Columns["paramcelldisplaytype"].Visible = CellViewDisplayType.Checked;
            CellDataGridView.Columns["paramcellinternaltype"].Visible = CellViewInternalType.Checked;
            CellDataGridView.Columns["paramcellvalue"].Visible = CellViewValue.Checked;
            CellDataGridView.Columns["paramcelldisplayname"].Visible = CellViewDisplayName.Checked;
            CellDataGridView.Columns["paramcellinternalname"].Visible = CellViewInternalName.Checked;
            CellDataGridView.Columns["paramcelldescription"].Visible = CellViewInternalName.Checked;
            CellDataGridView.Columns["paramcelldisplayformat"].Visible = CellViewDisplayFormat.Checked;
            CellDataGridView.Columns["paramcelldefault"].Visible = CellViewDefault.Checked;
            CellDataGridView.Columns["paramcellincrement"].Visible = CellViewIncrement.Checked;
            CellDataGridView.Columns["paramcellminimum"].Visible = CellViewMinimum.Checked;
            CellDataGridView.Columns["paramcellmaximum"].Visible = CellViewMaximum.Checked;
            CellDataGridView.Columns["paramcellsortid"].Visible = CellViewSortID.Checked;
            CellDataGridView.Columns["paramcellarraylength"].Visible = CellViewArrayLength.Checked;
            CellDataGridView.Columns["paramcellbitsize"].Visible = CellViewBitSize.Checked;
        }

        private void RefreshDefGames()
        {
            // Clean missing folders
            for (int i = 1; i < MenuGameCombobox.Items.Count; i++)
                if (!Directory.Exists($"{DefFolderPath}\\{MenuGameCombobox.Items[i]}"))
                    MenuGameCombobox.Items.Remove(MenuGameCombobox.Items[i]);

            // Set item to None if the previously selected item is now deleted to prevent empty box
            if (MenuGameCombobox.SelectedIndex == -1)
                MenuGameCombobox.SelectedIndex = 0;

            // Create folder if it doesn't exist to prevent crashing and to have it made
            if (!Directory.Exists(DefFolderPath))
                Directory.CreateDirectory(DefFolderPath);

            // Gather game folder paths
            string[] gamenames = Directory.GetDirectories(DefFolderPath);

            // Get names of folders on paths
            for (int i = 0; i < gamenames.Length; i++)
                gamenames[i] = Path.GetFileName(gamenames[i]);

            // Add names
            foreach (string name in gamenames)
                if (!MenuGameCombobox.Items.Contains(name))
                    MenuGameCombobox.Items.Add(name);
        }

        private void TrySetSavedDefSet()
        {
            // TODO: Make defset system clearer by not relying on the combobox as data storage
            // Try to load the saved def set
            string preferredDefSet = Properties.Settings.Default.SelectedDefSet;

            // Try to find it's index by name
            int index = MenuGameCombobox.Items.IndexOf(preferredDefSet);
            if (index == -1)
            {
                // If we couldn't find it...
                if (MenuGameCombobox.Items.Count == 1)
                {
                    // TODO: Possible rework on how "None" works or if it is even necessary?
                    // ... and we only have 1 item, that item currently must be "None" which is our only option
                    preferredDefSet = "None";
                    Properties.Settings.Default.SelectedDefSet = preferredDefSet;
                    Properties.Settings.Default.Save();
                }
                else if (MenuGameCombobox.Items.Count > 1)
                {
                    // ... and we have more than 1 item, try using it, otherwise use "None"
                    Properties.Settings.Default.SelectedDefSet = MenuGameCombobox.Items[1] as string ?? "None";
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                // Set the selected index if we found it
                MenuGameCombobox.SelectedIndex = index;
            }
        }

        #endregion

        #region Status

        private void UpdateStatus(string text)
        {
            if (LogListBox.Items.Count + 1 > MaxLogEntries)
            {
                LogListBox.Items.RemoveAt(0);
            }

            LogListBox.Items.Add(text);
            LogListBox.ScrollToBottom();
        }

        #endregion

        #region Param Defs

        private void ExportXmlDefs(string folder)
        {
            if (File.Exists(folder))
            {
                UpdateStatus($"Cannot export paramdefs as folder path is a file: {folder}");
                return;
            }

            foreach (var defpair in DefMap)
            {
                var value = defpair.Value;
                var name = value.Name;
                var def = value.Def;
                ExportXmlDef(Path.Combine(folder, $"{Path.GetFileNameWithoutExtension(name)}.xml"), def);
            }
        }

        private void ExportXmlDef(string path, PARAMDEF def)
        {
            PathUtil.Backup(path);
            def.XmlSerialize(path, true);
        }

        private string GetCurrentDefPath()
        {
            return $"{DefFolderPath}\\{MenuGameCombobox.Text}";
        }

        private static PARAMDEF? ReadParamDef(string path)
        {
            if (path == null)
                return null;
            if (!File.Exists(path))
                return null;
#if !DEBUG_CRASH
            try
            {
#endif
                if (path.EndsWith(".xml"))
                    return PARAMDEF.XmlDeserialize(path, false, false);
                else
                    return PARAMDEF.Read(path);
#if !DEBUG_CRASH
            }
            catch
            {
                return null;
            }
#endif
        }

        private void LoadDefs()
        {
            DefMap.Clear();

            if (MenuGameCombobox.Text == "None")
            {
                UpdateStatus("Selected defs set to None.");
                RefreshParamOpenAccess();
                return;
            }

            string dir = GetCurrentDefPath();
            if (!Directory.Exists(dir))
            {
                RefreshDefGames();
                UpdateStatus("Current defs selection does not exist and was removed.");
                LoadDefs();
                return;
            }

            string[] paths = Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly);
            string mappingPath = Path.Combine(dir, TypelessMappingName);

            int total = paths.Length;
            int failed = 0;
            int skipped = 0;
            foreach (string path in paths)
            {
                if (Path.GetFileName(path) == TypelessMappingName)
                {
                    UpdateStatus($"Skipped {TypelessMappingName}");
                    skipped++;
                    continue;
                }

                var def = ReadParamDef(path);
                if (def != null)
                {
                    if (!DefMap.ContainsKey(def.ParamType))
                    {
                        DefMap.Add(def.ParamType, new ParamDefInfo(Path.GetFileNameWithoutExtension(path), def));
                        continue;
                    }

                    UpdateStatus($"Skipped already loaded {Path.GetFileName(path) ?? "Unknown File"}");
                    skipped++;
                    continue;
                }

                UpdateStatus($"Failed to read {Path.GetFileName(path) ?? "Unknown File"} as a def.");
                failed++;
            }

            LoadDefMappings(mappingPath);
            UpdateStatus($"Loaded {total - failed - skipped} {MenuGameCombobox.Text} defs, skipped {skipped} files, and failed to read {failed} files out of {total} total files.");
            RefreshParamOpenAccess();
        }

        private void LoadDefMappings(string mappingPath)
        {
            if (!File.Exists(mappingPath))
            {
                return;
            }

            int count = 0;
            int failed = 0;
            string[] lines = File.ReadAllLines(mappingPath);
            var mappings = Mapping.ParseMapping(lines);
            foreach (var pair in mappings)
            {
                if (DefMap.TryGetValue(pair.Value, out ParamDefInfo? def))
                {
                    if (def != null)
                    {
                        DefMap.Add(pair.Key, def);
                        count++;
                        continue;
                    }
                }
                failed++;
            }

            UpdateStatus($"Loaded {count} typeless param to def mappings, failed to load {failed} mappings.");
        }

        #endregion

        #region Params

        private ParamInfo ReadParamInfo(string path)
        {
            PARAM param = PARAM.Read(path);
            if (!DefMap.TryGetValue(param.ParamType, out ParamDefInfo? def))
            {
                DefMap.TryGetValue(PathUtil.GetExtensionlessFileName(path), out def);
            }

            var paraminfo = new ParamInfo(param, def?.Def, path);
            paraminfo.Game = MenuGameCombobox.Text;
            return paraminfo;
        }

        private void LoadParams(IList<string> paths)
        {
            if (paths == null || paths.Count == 0)
                return;

            int success = 0;
            int skipped = 0;
            int failed = 0;
            bool skip = false;

            foreach (string path in paths)
            {
                if (path == null || !File.Exists(path))
                    continue;

                if (Params.ContainsParam(path))
                {
                    if (!skip)
                    {
                        skip = FormUtil.ShowQuestionDialog($"A param that already exists has been detected, would you like to skip already loaded params?", "Skip loaded params");
                        if (skip)
                        {
                            skipped++;
                            continue;
                        }
                    }
                    else if (skip)
                    {
                        skipped++;
                        continue;
                    }
                }

#if !DEBUG_CRASH
                try
                {
#endif
                    var paraminfo = ReadParamInfo(path);
                    if (paraminfo.AppliedDef == false)
                    {
                        UpdateStatus($"Failed to read {Path.GetFileName(path) ?? "Unknown File"} because the param def could either not be found or matched.");
                        failed++;
                        continue;
                    }

                    success++;
                    Params.Add(paraminfo);
#if !DEBUG_CRASH
                }
                catch
                {
                    UpdateStatus($"Failed to read {Path.GetFileName(path) ?? "Unknown File"} as a param.");
                    failed++;
                    continue;
                }
#endif
            }

            UpdateStatus($"Loaded {success} params, skipped {skipped} files, and failed to read {failed} files out of {paths.Count} total files.");
        }

        /// <summary>
        /// Load params faster by locking events that are called too much during load.
        /// </summary>
        /// <remarks>
        /// Sender and EventArgs are necessary as we need an event to fire after unlocking again.
        /// </remarks>
        /// <param name="paths">The paths to the params to load.</param>
        /// <param name="sender">The sender object of the event calling this method.</param>
        /// <param name="e">The EventArgs of the event calling this method.</param>
        private void LoadParamsFast(IList<string> paths, object sender, EventArgs e)
        {
            LockEvents();
            LoadParams(paths);
            UnlockEvents();
            ParamDataGridView_SelectionChanged(sender, e);
        }

        #endregion

        #region Validation

        private static bool CellValueValid(PARAM.Cell cell, object newvalue)
        {
            var temp = new PARAM.Cell(cell);
            try
            {
                temp.Value = newvalue;
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// Lock certain events because they cause unnecessary slowdown during initialization and mass loading.
        /// </summary>
        private void LockEvents()
        {
            ParamDataGridView.SelectionChanged -= ParamDataGridView_SelectionChanged;
            RowDataGridView.SelectionChanged -= RowDataGridView_SelectionChanged;
            MenuGameCombobox.SelectedIndexChanged -= MenuGameCombobox_SelectedIndexChanged;
        }

        /// <summary>
        /// Unlock certain events again once they are ready to be used.
        /// </summary>
        private void UnlockEvents()
        {
            ParamDataGridView.SelectionChanged += ParamDataGridView_SelectionChanged;
            RowDataGridView.SelectionChanged += RowDataGridView_SelectionChanged;
            MenuGameCombobox.SelectedIndexChanged += MenuGameCombobox_SelectedIndexChanged;
        }

        #endregion

    }
}