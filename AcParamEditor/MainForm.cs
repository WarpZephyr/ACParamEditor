using AcParamEditor.Data;
using AcParamEditor.Data.Builders;
using AcParamEditor.Data.Configs;
using AcParamEditor.Data.Parsers;
using AcParamEditor.Extensions;
using AcParamEditor.Utilities;
using CustomWinForms;
using SoulsFormats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AcParamEditor
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// A string representing the path to a generic resource folder named "Resources" inside of the directory the program is running from.
        /// </summary>
        private static readonly string ResourcesFolderPath = $"{AppInfo.AppDirectory}\\Resources";

        /// <summary>
        /// The path to the def resource folder.
        /// </summary>
        private static readonly string DefFolderPath = $"{ResourcesFolderPath}\\Def";

        /// <summary>
        /// The path to the tdf resource folder.
        /// </summary>
        private static readonly string TdfFolderPath = $"{ResourcesFolderPath}\\Tdf";

        /// <summary>
        /// The file name of the TentativeParamType list.
        /// </summary>
        private const string TentativeParamTypeName = "TentativeParamType.csv";

        /// <summary>
        /// The currently loaded param to def map.
        /// </summary>
        private readonly Dictionary<string, ParamDefInfo> DefMap;

        /// <summary>
        /// The currently loaded param to def map.
        /// </summary>
        private readonly Dictionary<string, PARAMDEF> RawDefMap;

        /// <summary>
        /// The currently loaded params.
        /// </summary>
        private readonly BindingList<ParamInfo> Params;

        /// <summary>
        /// The currently copied param rows.
        /// </summary>
        private List<PARAM.Row> RowCopies;

        /// <summary>
        /// The max number of entries that can be in the log.
        /// </summary>
        private readonly int MaxLogEntries;

        /// <summary>
        /// Whether or not the skip dialog has been shown for params yet.
        /// </summary>
        private bool ShownSkipAlreadyLoadedDialog;

        /// <summary>
        /// Whether or not to skip already loaded params.
        /// </summary>
        private bool SkipAlreadyLoaded;

        public MainForm()
        {
            DefMap = [];
            RawDefMap = [];
            Params = [];
            RowCopies = [];
            MaxLogEntries = 1000;

            InitializeComponent();

            // Lock events that slow down initialization.
            LockEvents();

            // Set options
            MenuOptionsExportAsWorkbook.Checked = Properties.Settings.Default.ExportAsWorkbook;
            MenuOptionsExportUsingInternalNames.Checked = Properties.Settings.Default.ExportUsingInternalNames;

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
            Log("Initial def load start.");
            LoadDefs();

            // Data bind param list.
            ParamDataGridView.AutoGenerateColumns = false;
            ParamDataGridView.DataSource = Params;
            GetColumnOrThrow(ParamDataGridView.Columns, "paramfilename").DataPropertyName = "Name";
            GetColumnOrThrow(ParamDataGridView.Columns, "paramtype").DataPropertyName = "Type";
            GetColumnOrThrow(ParamDataGridView.Columns, "paramformatversion").DataPropertyName = "ParamFormatVersion";
            GetColumnOrThrow(ParamDataGridView.Columns, "paramdefformatversion").DataPropertyName = "DefFormatVersion";
            GetColumnOrThrow(ParamDataGridView.Columns, "paramdataversion").DataPropertyName = "ParamDataVersion";
            GetColumnOrThrow(ParamDataGridView.Columns, "paramdefdataversion").DataPropertyName = "DefDataVersion";
            GetColumnOrThrow(ParamDataGridView.Columns, "paramgame").DataPropertyName = "Game";

            // Unlock locked events.
            UnlockEvents();
        }

        #region Form Options

        private void MenuOptionsExportAsWorkbook_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ExportAsWorkbook = MenuOptionsExportAsWorkbook.Checked;
            Properties.Settings.Default.Save();
        }

        private void MenuOptionsExportUsingInternalNames_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ExportUsingInternalNames = MenuOptionsExportUsingInternalNames.Checked;
            Properties.Settings.Default.Save();
        }

        #endregion

        #region Form IO

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            Log("Opening params.");
            string[] paths = FileDialogs.GetFilePaths("Open Params", "Param (*.bin)|*.bin|" +
                "Param (*.param)|*.param|" +
                "Csv Param (*.csv)|*.csv|" +
                "Tsv Param (*.tsv)|*.tsv|" +
                "Xls Param (*.xls)|*.xls|" +
                "Xlsx Param (*.xlsx)|*.xlsx|" +
                "All Files (*)|*");

            if (paths.Length == 0)
            {
                Log("Canceling opening params.");
                return;
            }

            LoadParamsFast(paths, sender, e);
        }

        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            if (!FormDialogs.ShowQuestionDialog("Are you sure you want to save all currently selected params?", "Save Selected Params"))
                return;

            var selectedParams = GetSelectedParams();
            foreach (var paramInfo in selectedParams)
            {
                FileEx.BackupFile(paramInfo.Path);
                paramInfo.WriteToPath();
            }

            Log($"Saved {selectedParams.Count} params.");
        }

        private void MenuFileSaveAll_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormDialogs.ShowQuestionDialog("Are you sure you want to save all params?", "Save All Params");
            if (!question)
                return;

            int count = ParamDataGridView.RowCount;
            foreach (DataGridViewRow row in ParamDataGridView.Rows)
            {
                var paraminfo = (ParamInfo?)row.DataBoundItem ?? throw new Exception("Failed to get param data.");
                FileEx.BackupFile(paraminfo.Path);
                paraminfo.WriteToPath();
            }

            Log($"Saved all {count} params.");
        }

        private void MenuFileClose_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormDialogs.ShowQuestionDialog("Are you sure you want to close all currently selected params?", "Close Selected Params");
            if (!question)
                return;

            var selectedParams = GetSelectedParams();
            foreach (var paramInfo in selectedParams)
            {
                Params.Remove(paramInfo);
            }

            RefreshDataGridViews();
            Log($"Closed {selectedParams.Count} params.");
        }

        private void MenuFileCloseAll_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormDialogs.ShowQuestionDialog("Are you sure you want to close all params?", "Close All Params");
            if (!question)
                return;

            int count = ParamDataGridView.RowCount;
            Params.Clear();
            RefreshDataGridViews();
            Log($"Closed all {count} params.");
        }

        private void MenuFileReload_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormDialogs.ShowQuestionDialog("Are you sure you want to reload all currently selected params without saving?", "Reload Selected Params");
            if (!question)
                return;

            var paths = new List<string>();
            var selectedParams = GetSelectedParams();
            foreach (var paramInfo in selectedParams)
            {
                paths.Add(paramInfo.Path);
                Params.Remove(paramInfo);
            }

            LoadParamsFast(paths, sender, e);
            RefreshDataGridViews();
            Log($"Reloaded {selectedParams.Count} params.");
        }

        private void MenuFileReloadAll_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormDialogs.ShowQuestionDialog("Are you sure you want to reload all params without saving?", "Reload All Params");
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
            Log($"Reloaded all {paths.Count} params.");
        }

        #endregion

        #region Form Import

        private void MenuImportParams_Click(object sender, EventArgs e)
        {
            MenuFileOpen_Click(sender, e);
        }

        #endregion

        #region Form Export

        private void MenuExportParamsCsv_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            if (!FormDialogs.ShowQuestionDialog("Are you sure you want to export all currently selected params to Csv?", "Export Selected Params to Csv"))
                return;

            var selectedParams = GetSelectedParams();
            ExportParams(selectedParams, ParamFileType.Csv, false);
        }

        private void MenuExportParamsTsv_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            if (!FormDialogs.ShowQuestionDialog("Are you sure you want to export all currently selected params to Tsv?", "Export Selected Params to Tsv"))
                return;

            var selectedParams = GetSelectedParams();
            ExportParams(selectedParams, ParamFileType.Tsv, false);
        }

        private void MenuExportParamsXls_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormDialogs.ShowQuestionDialog("Are you sure you want to export all currently selected params to Xls?", "Export Selected Params to Xls");
            if (!question)
                return;

            var selectedParams = GetSelectedParams();
            ExportParams(selectedParams, ParamFileType.Xls, Properties.Settings.Default.ExportAsWorkbook);
        }

        private void MenuExportParamsXlsx_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormDialogs.ShowQuestionDialog("Are you sure you want to export all currently selected params to Xlsx?", "Export Selected Params to Xlsx");
            if (!question)
                return;

            var selectedParams = GetSelectedParams();
            ExportParams(selectedParams, ParamFileType.Xlsx, Properties.Settings.Default.ExportAsWorkbook);
        }

        private void MenuExportParamdefs_Click(object sender, EventArgs e)
        {
            Log("Exporting paramdefs.");
            string? folderPath = FileDialogs.GetFolderPath();
            if (folderPath == null)
            {
                Log("Canceling exporting paramdefs.");
                return;
            }

            ExportXmlDefs(folderPath);
            Log("Exported paramdefs.");
        }

        #endregion

        #region Form View

        private void ParamViewName_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(ParamDataGridView.Columns, "paramfilename").Visible = ParamViewName.Checked;
            Log(ParamViewName.Checked ? "Showing Names" : "Hid Names");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewType_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(ParamDataGridView.Columns, "paramtype").Visible = ParamViewType.Checked;
            Log(ParamViewType.Checked ? "Showing Types" : "Hid Types");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewParamFormatVersion_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(ParamDataGridView.Columns, "paramformatversion").Visible = ParamViewParamFormatVersion.Checked;
            Log(ParamViewParamFormatVersion.Checked ? "Showing Param Format Versions" : "Hid Param Format Versions");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewDefFormatVersion_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(ParamDataGridView.Columns, "paramdefformatversion").Visible = ParamViewDefFormatVersion.Checked;
            Log(ParamViewParamFormatVersion.Checked ? "Showing Def Format Versions" : "Hid Def Format Versions");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewParamDataVersion_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(ParamDataGridView.Columns, "paramdataversion").Visible = ParamViewParamDataVersion.Checked;
            Log(ParamViewParamDataVersion.Checked ? "Showing Param Data Versions" : "Hid Param Data Versions");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewDefDataVersion_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(ParamDataGridView.Columns, "paramdefdataversion").Visible = ParamViewDefDataVersion.Checked;
            Log(ParamViewParamDataVersion.Checked ? "Showing Def Data Versions" : "Hid Def Data Versions");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void ParamViewGame_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(ParamDataGridView.Columns, "paramgame").Visible = ParamViewGame.Checked;
            Log(ParamViewType.Checked ? "Showing Games" : "Hid Games");
            ParamContextMenu.Show();
            ParamView.DropDown.Show();
        }

        private void RowViewID_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(RowDataGridView.Columns, "paramrowid").Visible = RowViewID.Checked;
            Log(RowViewID.Checked ? "Showing IDs" : "Hid IDs");
            RowContextMenu.Show();
            RowView.DropDown.Show();
        }

        private void RowViewName_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(RowDataGridView.Columns, "paramrowname").Visible = RowViewName.Checked;
            Log(RowViewName.Checked ? "Showing Row Names" : "Hid Row Names");
            RowContextMenu.Show();
            RowView.DropDown.Show();
        }

        private void CellViewDisplayType_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldisplaytype").Visible = CellViewDisplayType.Checked;
            Log(CellViewDisplayType.Checked ? "Showing Cell Display Types" : "Hid Cell Display Types");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewInternalType_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellinternaltype").Visible = CellViewInternalType.Checked;
            Log(CellViewInternalType.Checked ? "Showing Cell Internal Types" : "Hid Cell Internal Types");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewValue_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellvalue").Visible = CellViewValue.Checked;
            Log(CellViewValue.Checked ? "Showing Cell Values" : "Hid Cell Values");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewDisplayName_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldisplayname").Visible = CellViewDisplayName.Checked;
            Log(CellViewDisplayName.Checked ? "Showing Cell Display Names" : "Hid Cell Display Names");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewInternalName_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellinternalname").Visible = CellViewInternalName.Checked;
            Log(CellViewInternalName.Checked ? "Showing Cell Internal Names" : "Hid Cell Internal Names");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewDescription_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldescription").Visible = CellViewDescription.Checked;
            Log(CellViewDescription.Checked ? "Showing Cell Descriptions" : "Hid Cell Descriptions");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewDisplayFormat_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldisplayformat").Visible = CellViewDisplayFormat.Checked;
            Log(CellViewDisplayFormat.Checked ? "Showing Cell Display Formats" : "Hid Cell Display Formats");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewDefault_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldefault").Visible = CellViewDefault.Checked;
            Log(CellViewDefault.Checked ? "Showing Cell Default Values" : "Hid Cell Default Values");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewIncrement_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellincrement").Visible = CellViewIncrement.Checked;
            Log(CellViewIncrement.Checked ? "Showing Cell Increment Amount" : "Hid Cell Increment Amount");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewMinimum_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellminimum").Visible = CellViewMinimum.Checked;
            Log(CellViewMinimum.Checked ? "Showing Cell Minimum Values" : "Hid Cell Mimimum Values");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewMaximum_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellmaximum").Visible = CellViewMaximum.Checked;
            Log(CellViewMaximum.Checked ? "Showing Cell Maximum Values" : "Hid Cell Maximum Values");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewSortID_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellsortid").Visible = CellViewSortID.Checked;
            Log(CellViewSortID.Checked ? "Showing Cell Sort IDs" : "Hid Cell Sort IDs");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewArrayLength_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellarraylength").Visible = CellViewArrayLength.Checked;
            Log(CellViewArrayLength.Checked ? "Showing Cell Array Lengths" : "Hid Cell Array Lengths");
            CellContextMenu.Show();
            CellView.DropDown.Show();
        }

        private void CellViewBitSize_Click(object sender, EventArgs e)
        {
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellbitsize").Visible = CellViewBitSize.Checked;
            Log(CellViewBitSize.Checked ? "Showing Cell Bit Sizes" : "Hid Cell Bit Sizes");
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

        private static DataGridViewColumn GetColumnOrThrow(DataGridViewColumnCollection columns, string columnName)
            => columns[columnName] ?? throw new Exception($"Couldn't get column: \"{columnName}\"");

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

            var currentParamViewRow = ParamDataGridView.CurrentRow ?? throw new Exception("Failed to get current param view row.");
            var currentparam = (ParamInfo?)currentParamViewRow.DataBoundItem ?? throw new Exception("Failed to get param data.");
            if (currentparam.RowCount == 0)
            {
                CellDataGridView.DataSource = null;
                return;
            }

            var currentRowViewRow = RowDataGridView.CurrentRow ?? throw new Exception("Failed to get current row view row.");
            if (currentRowViewRow.Index + 1 > currentparam.RowCount)
                return;

            CellDataGridView.AutoGenerateColumns = false;

            var currentRow = (PARAM.Row?)currentRowViewRow.DataBoundItem ?? throw new Exception("Failed to get param row data.");
            CellDataGridView.DataSource = currentRow.Cells;

            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldisplaytype").DataPropertyName = "DisplayType";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellinternaltype").DataPropertyName = "InternalType";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellvalue").DataPropertyName = "Value";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldisplayname").DataPropertyName = "DisplayName";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellinternalname").DataPropertyName = "InternalName";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldescription").DataPropertyName = "Description";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldisplayformat").DataPropertyName = "DisplayFormat";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldefault").DataPropertyName = "Default";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellincrement").DataPropertyName = "Increment";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellminimum").DataPropertyName = "Minimum";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellmaximum").DataPropertyName = "Maximum";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellsortid").DataPropertyName = "SortID";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellarraylength").DataPropertyName = "ArrayLength";
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellbitsize").DataPropertyName = "BitSize";
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
                    Log($"{e.FormattedValue} is not a valid row ID.");
                }
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

        private void CellDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            CellDataGridView.CancelEdit();
            CellDataGridView.EndEdit();
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
                            var currentCell = CellDataGridView.CurrentCell ?? throw new Exception("Failed to get current cell.");
                            currentCell.Value = textBox.Text;
                        });
                    }

                    void PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
                    {
                        if (e.KeyData == Keys.Escape)
                        {
                            var currentCell = CellDataGridView.CurrentCell ?? throw new Exception("Failed to get current cell.");
                            currentCell.Value = revertText;
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

            string[]? paths = (string[]?)data.GetData(DataFormats.FileDrop);
            if (paths == null)
                return;

            LoadParamsFast(paths, sender, e);
        }

        #endregion

        #region Form Rows

        private void RowNew_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            var currentRow = ParamDataGridView.CurrentRow ?? throw new Exception("Failed to get current row.");
            var currentparam = (ParamInfo?)currentRow.DataBoundItem ?? throw new Exception("Failed to get param data.");

            int id = 1;
            if (currentparam.Param.Rows.Count > 0)
                id = currentparam.GetNextRowID();
            currentparam.Param.Rows.Add(new PARAM.Row(id, "NEWROW", currentparam.Param.AppliedParamdef));

            RefreshRows();
            Log("Made a new row.");
        }

        private void RowDelete_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            bool question = FormDialogs.ShowQuestionDialog("Are you sure you wish to delete the currently selected rows?", "Delete Currently Selected Rows");
            if (!question)
            {
                Log("Canceled row deletion.");
                return;
            }

            var currentRow = ParamDataGridView.CurrentRow ?? throw new Exception("Failed to get current row.");
            var currentParam = (ParamInfo?)currentRow.DataBoundItem ?? throw new Exception("Failed to get param data.");

            var removalList = new List<PARAM.Row>();
            foreach (DataGridViewCell cell in RowDataGridView.SelectedCells)
            {
                var row = (PARAM.Row?)RowDataGridView.Rows[cell.RowIndex].DataBoundItem ?? throw new Exception("Failed to get param row data.");
                if (!removalList.Contains(row))
                {
                    removalList.Add(row);
                }
            }

            foreach (var row in removalList)
            {
                currentParam.Param.Rows.Remove(row);
            }

            RefreshRows();
            Log($"Deleted {removalList.Count} rows.");
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
                    var row = (PARAM.Row?)RowDataGridView.Rows[cell.RowIndex].DataBoundItem ?? throw new Exception("Failed to get param row data.");
                    copies.Add(new PARAM.Row(row));
                    found.Add(cell.RowIndex);
                }
            }
            RowCopies = copies;
            Log($"Copied {RowCopies.Count} rows.");
        }

        private void RowPaste_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.CurrentRow == null || RowCopies.Count == 0)
                return;

            var currentRow = ParamDataGridView.CurrentRow ?? throw new Exception("Failed to get current row.");
            var currentParam = (ParamInfo?)currentRow.DataBoundItem ?? throw new Exception("Failed to get param data.");

            if (!currentParam.RowCompatible(RowCopies[0]))
            {
                Log($"Copied rows are not compatibile.");
                return;
            }

            int count = 0;
            foreach (var row in RowCopies)
            {
                var rows = (List<PARAM.Row>?)RowDataGridView.DataSource ?? throw new Exception("Failed to get param rows data.");
                if (rows.Count == ushort.MaxValue)
                {
                    Log($"Row limit of {ushort.MaxValue} reached, stopped pasting.");
                    Log($"Pasted {count} rows.");
                    return;
                }

                if (currentParam.ContainsRowID(row.ID))
                    row.ID = currentParam.GetNextRowID();
                rows.Add(row);
                count++;
            }

            RefreshRows();
            Log($"Pasted {count} rows.");
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
                    var row = (PARAM.Row?)RowDataGridView.Rows[cell.RowIndex].DataBoundItem ?? throw new Exception("Failed to get param row data.");
                    copies.Add(new PARAM.Row(row));
                    found.Add(cell.RowIndex);
                }
            }

            var currentParam = (ParamInfo?)ParamDataGridView.CurrentRow.DataBoundItem ?? throw new Exception("Failed to get param data.");

            int count = 0;
            foreach (var row in copies)
            {
                var rows = (List<PARAM.Row>?)RowDataGridView.DataSource ?? throw new Exception("Failed to get param rows data.");
                if (rows.Count == ushort.MaxValue)
                {
                    Log($"Row limit of {ushort.MaxValue} reached, stopped duplicating.");

                    RefreshRows();
                    Log($"Duplicated {count} rows.");
                    return;
                }

                if (currentParam.ContainsRowID(row.ID))
                    row.ID = currentParam.GetNextRowID();
                rows.Add(row);
            }

            RefreshRows();
            Log($"Duplicated {count} rows.");
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

            var currentRow = ParamDataGridView.CurrentRow ?? throw new Exception("Failed to get current row.");
            var paraminfo = (ParamInfo?)currentRow.DataBoundItem ?? throw new Exception("Failed to get param data.");
            RowDataGridView.DataSource = paraminfo.Param.Rows;
            GetColumnOrThrow(RowDataGridView.Columns, "paramrowid").DataPropertyName = "ID";
            GetColumnOrThrow(RowDataGridView.Columns, "paramrowname").DataPropertyName = "Name";
        }

        private void RefreshColumnVisibility()
        {
            GetColumnOrThrow(ParamDataGridView.Columns, "paramfilename").Visible = ParamViewName.Checked;
            GetColumnOrThrow(ParamDataGridView.Columns, "paramtype").Visible = ParamViewType.Checked;
            GetColumnOrThrow(ParamDataGridView.Columns, "paramgame").Visible = ParamViewGame.Checked;
            GetColumnOrThrow(RowDataGridView.Columns, "paramrowid").Visible = RowViewID.Checked;
            GetColumnOrThrow(RowDataGridView.Columns, "paramrowname").Visible = RowViewName.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldisplaytype").Visible = CellViewDisplayType.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellinternaltype").Visible = CellViewInternalType.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellvalue").Visible = CellViewValue.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldisplayname").Visible = CellViewDisplayName.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellinternalname").Visible = CellViewInternalName.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldescription").Visible = CellViewInternalName.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldisplayformat").Visible = CellViewDisplayFormat.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcelldefault").Visible = CellViewDefault.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellincrement").Visible = CellViewIncrement.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellminimum").Visible = CellViewMinimum.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellmaximum").Visible = CellViewMaximum.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellsortid").Visible = CellViewSortID.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellarraylength").Visible = CellViewArrayLength.Checked;
            GetColumnOrThrow(CellDataGridView.Columns, "paramcellbitsize").Visible = CellViewBitSize.Checked;
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

        private void Log(string text)
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
                Log($"Cannot export paramdefs as folder path is a file: {folder}");
                return;
            }

            foreach (var defpair in DefMap)
            {
                var value = defpair.Value;
                var name = value.Name;
                var def = value.Def;

                const StringComparison strComp = StringComparison.InvariantCultureIgnoreCase;
                string outPath = Path.Combine(folder, name.Replace(".def", ".xml", strComp).Replace(".paramdef", ".xml", strComp));
                FileEx.BackupFile(outPath);
                def.XmlSerialize(outPath, true);
            }
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
            try
            {
                if (path.EndsWith(".xml"))
                    return PARAMDEF.XmlDeserialize(path, false, false);
                else
                    return PARAMDEF.Read(path);
            }
            catch
            {
                return null;
            }
        }

        private void LoadDefs()
        {
            DefMap.Clear();
            RawDefMap.Clear();

            if (MenuGameCombobox.Text == "None")
            {
                Log("Selected defs set to None.");
                RefreshParamOpenAccess();
                return;
            }

            string dir = GetCurrentDefPath();
            if (!Directory.Exists(dir))
            {
                RefreshDefGames();
                Log("Current defs selection does not exist and was removed.");
                LoadDefs();
                return;
            }

            string[] paths = Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly);
            string csvPath = Path.Combine(dir, TentativeParamTypeName);

            int total = paths.Length;
            int failed = 0;
            int skipped = 0;
            foreach (string path in paths)
            {
                if (Path.GetFileName(path) == TentativeParamTypeName)
                {
                    Log($"Skipped {TentativeParamTypeName}");
                    skipped++;
                    continue;
                }

                var def = ReadParamDef(path);
                if (def != null)
                {
                    if (!DefMap.ContainsKey(def.ParamType))
                    {
                        DefMap.Add(def.ParamType, new ParamDefInfo(Path.GetFileNameWithoutExtension(path), def));
                        RawDefMap.Add(def.ParamType, def);
                        continue;
                    }

                    Log($"Skipped already loaded {Path.GetFileName(path) ?? "Unknown File"}");
                    skipped++;
                    continue;
                }

                Log($"Failed to read {Path.GetFileName(path) ?? "Unknown File"} as a def.");
                failed++;
            }

            TentativeParamTypeMap.LoadCsv(DefMap, RawDefMap, csvPath);
            Log($"Loaded {total - failed - skipped} {MenuGameCombobox.Text} defs, skipped {skipped} files, and failed to read {failed} files out of {total} total files.");
            RefreshParamOpenAccess();
        }

        #endregion

        #region Params

        private bool AddParam(ParamInfo paramInfo)
        {
            bool alreadyLoaded = Params.ContainsParam(paramInfo.Path);
            if (!ShownSkipAlreadyLoadedDialog && alreadyLoaded)
            {
                SkipAlreadyLoaded = FormDialogs.ShowQuestionDialog($"Already loaded params detected, do you wish to skip already loaded params?", "Skip Already Loaded Params");
                ShownSkipAlreadyLoadedDialog = true;
            }

            if (SkipAlreadyLoaded && alreadyLoaded)
            {
                return false;
            }

            Params.Add(paramInfo);
            return true;
        }

        private List<ParamInfo> GetSelectedParams()
        {
            // Looping over selected rows does not work unless the entire row is selected
            // However users are freely able to select single cells in rows, because this is nice for text copying
            // So we loop over selected cells, and ignore cells in rows we've already checked
            var foundRows = new HashSet<int>();
            var selectedParams = new List<ParamInfo>();
            foreach (DataGridViewCell cell in ParamDataGridView.SelectedCells)
            {
                if (!foundRows.Contains(cell.RowIndex))
                {
                    var paraminfo = (ParamInfo?)ParamDataGridView.Rows[cell.RowIndex].DataBoundItem ?? throw new Exception("Failed to get param data.");
                    selectedParams.Add(paraminfo);
                    foundRows.Add(cell.RowIndex);
                }
            }

            return selectedParams;
        }

        private void LoadBinaryParam(string path)
        {
            string name = PathEx.RemoveFileExtensions(Path.GetFileName(path));

            PARAM? param;
            param = PARAM.Read(path);
            string? paramType = param.ParamType;
            if (string.IsNullOrEmpty(paramType))
            {
                paramType = name;
            }

            if (!DefMap.TryGetValue(paramType, out ParamDefInfo? def))
            {
                Log($"Error: Could not find paramdef for: \"{name}\"");
                return;
            }

            if (param.ApplyParamdefSomewhatCarefully(def.Def))
            {
                var paramInfo = new ParamInfo(param, path)
                {
                    Game = MenuGameCombobox.Text
                };

                if (AddParam(paramInfo))
                    Log($"Loaded param: \"{name}\"");
                else
                    Log($"Skipped already loaded param: \"{name}\"");
            }
            else
            {
                Log($"Error: Found paramdef did not match the param: \"{name}\"");
            }
        }

        private void LoadSheetParam(ISpreadSheetParser parser, ParamWorkbookConfig config, string folder)
        {
            using var importer = new ParamImporter(parser, config, RawDefMap);
            while (importer.NextSheet(out string? sheetName))
            {
                if (importer.NextParam(out ParamImporter.ImportedParam? import))
                {
                    string outPath = Path.Combine(folder, $"{import.Name}{import.Extension}");
                    var paramInfo = new ParamInfo(import.Param, outPath)
                    {
                        Game = MenuGameCombobox.Text
                    };

                    if (AddParam(paramInfo))
                        Log($"Loaded sheet as param: \"{sheetName}\"");
                    else
                        Log($"Skipped already loaded param: \"{sheetName}\"");
                }
                else
                {
                    Log($"Error: Failed to load sheet as param: \"{sheetName}\"");
                }
            }
        }

        private void LoadCsvParam(string path)
        {
            string name = PathEx.RemoveFileExtensions(Path.GetFileName(path));
            string? folder = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(folder))
            {
                Log($"Error: Could not get folder name for: {name}");
                return;
            }

            string configPath = $"{path}.config.json";
            if (!File.Exists(configPath))
            {
                Log($"Error: Could not find param config for: {name}");
                return;
            }

            if (!ParamWorkbookConfig.TryLoad(configPath, out ParamWorkbookConfig? config))
            {
                Log($"Error: Failed to load param config for: {name}");
                return;
            }

            using var parser = CsvParser.OpenFile(path, Encoding.UTF8, name);
            LoadSheetParam(parser, config, folder);
        }

        private void LoadTsvParam(string path)
        {
            string name = PathEx.RemoveFileExtensions(Path.GetFileName(path));
            string? folder = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(folder))
            {
                Log($"Error: Could not get folder name for: {name}");
                return;
            }

            string configPath = $"{path}.config.json";
            if (!File.Exists(configPath))
            {
                Log($"Error: Could not find param config for: {name}");
                return;
            }

            if (!ParamWorkbookConfig.TryLoad(configPath, out ParamWorkbookConfig? config))
            {
                Log($"Error: Failed to load param config for: {name}");
                return;
            }

            using var parser = TsvParser.OpenFile(path, Encoding.UTF8, name);
            LoadSheetParam(parser, config, folder);
        }

        private void LoadXlsParams(string path)
        {
            string name = PathEx.RemoveFileExtensions(Path.GetFileName(path));
            string? folder = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(folder))
            {
                Log($"Error: Could not get folder name for: {name}");
                return;
            }

            string configPath = $"{path}.config.json";
            if (!File.Exists(configPath))
            {
                Log($"Error: Could not find param config for: {name}");
                return;
            }

            if (!ParamWorkbookConfig.TryLoad(configPath, out ParamWorkbookConfig? config))
            {
                Log($"Error: Failed to load param config for: {name}");
                return;
            }

            using var parser = XlsParser.OpenFile(path);
            LoadSheetParam(parser, config, folder);
        }

        private void LoadXlsxParams(string path)
        {
            string name = PathEx.RemoveFileExtensions(Path.GetFileName(path));
            string? folder = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(folder))
            {
                Log($"Error: Could not get folder name for: {name}");
                return;
            }

            string configPath = $"{path}.config.json";
            if (!File.Exists(configPath))
            {
                Log($"Error: Could not find param config for: {name}");
                return;
            }

            if (!ParamWorkbookConfig.TryLoad(configPath, out ParamWorkbookConfig? config))
            {
                Log($"Error: Failed to load param config for: {name}");
                return;
            }

            using var parser = XlsxParser.OpenFile(path);
            LoadSheetParam(parser, config, folder);
        }

        private void LoadParams(string path)
        {
            var fileType = ParamFileType.Binary;
            string extension = Path.GetExtension(path);
            switch (extension.ToLowerInvariant())
            {
                case ".csv":
                    fileType = ParamFileType.Csv;
                    break;
                case ".tsv":
                    fileType = ParamFileType.Tsv;
                    break;
                case ".xls":
                    fileType = ParamFileType.Xls;
                    break;
                case ".xlsx":
                    fileType = ParamFileType.Xlsx;
                    break;
            }

            try
            {
                switch (fileType)
                {
                    case ParamFileType.Binary:
                        LoadBinaryParam(path);
                        break;
                    case ParamFileType.Csv:
                        LoadCsvParam(path);
                        break;
                    case ParamFileType.Tsv:
                        LoadTsvParam(path);
                        break;
                    case ParamFileType.Xls:
                        LoadXlsParams(path);
                        break;
                    case ParamFileType.Xlsx:
                        LoadXlsxParams(path);
                        break;
                }
            }
            catch (IOException)
            {
                Log($"Error: The input file path is likely being held open by another program: \"{path}\"");
                return;
            }
        }

        private void LoadParams(IList<string> paths)
        {
            if (paths == null || paths.Count == 0)
                return;

            foreach (string path in paths)
            {
                if (path == null || !File.Exists(path))
                    continue;

                try
                {
                    LoadParams(path);
                }
                catch
                {
                    Log($"Error: Failed to read param: \"{Path.GetFileName(path)}\"");
                    continue;
                }
            }
        }

        private void ExportBinaryParams(IList<ParamInfo> paramInfos)
        {
            foreach (ParamInfo paramInfo in paramInfos)
            {
                paramInfo.WriteToPath();
            }
        }

        private void ExportParamAsSingleSheet(ParamInfo paramInfo, ParamExporter exporter, int columnLimit = -1, int rowLimit = -1)
        {
            string name = PathEx.RemoveFileExtensions(Path.GetFileName(paramInfo.Path));
            if (columnLimit > -1 && paramInfo.Param.AppliedParamdef.Fields.Count > columnLimit)
            {
                Log($"Error: The number of columns exceeds the amount supported by this format: \"{name}\"");
                return;
            }

            if (rowLimit > -1 && paramInfo.Param.Rows.Count > rowLimit)
            {
                Log($"Error: The number of rows exceeds the amount supported by this format: \"{name}\"");
                return;
            }

            string extension = Path.GetExtension(paramInfo.Path);
            exporter.AddParam(name, extension, paramInfo.Param);

            string? folder = Path.GetDirectoryName(paramInfo.Path);
            if (string.IsNullOrEmpty(folder))
            {
                Log($"Error: Could not get folder name of param: \"{name}\"");
                return;
            }

            string outPath = Path.Combine(folder, $"{name}.{exporter.Extension}");
            string configOutPath = $"{outPath}.config.json";

            try
            {
                exporter.Export(outPath);
            }
            catch (IOException)
            {
                Log($"Error: The output file path is likely being held open by another program: \"{outPath}\"");
                return;
            }

            try
            {
                exporter.GetConfig().Save(configOutPath);
            }
            catch (IOException)
            {
                Log($"Error: The output config file path is likely being held open by another program: \"{configOutPath}\"");
                return;
            }

            Log($"Exported param as single sheet: \"{name}\"");
        }

        private void ExportParamsAsWorkbook(IList<ParamInfo> paramInfos, ParamExporter exporter, string outPath, int columnLimit = -1, int rowLimit = -1)
        {
            foreach (ParamInfo paramInfo in paramInfos)
            {
                string name = PathEx.RemoveFileExtensions(Path.GetFileName(paramInfo.Path));
                if (columnLimit > -1 && paramInfo.Param.AppliedParamdef.Fields.Count > columnLimit)
                {
                    Log($"Error: The number of columns exceeds the amount supported by this format: \"{name}\"");
                    return;
                }

                if (rowLimit > -1 && paramInfo.Param.Rows.Count > rowLimit)
                {
                    Log($"Error: The number of rows exceeds the amount supported by this format: \"{name}\"");
                    return;
                }

                string extension = Path.GetExtension(paramInfo.Path);
                exporter.AddParam(name, extension, paramInfo.Param);
            }

            string configOutPath = $"{outPath}.config.json";

            try
            {
                exporter.Export(outPath);
            }
            catch (IOException)
            {
                Log($"Error: The output file path is likely being held open by another program: \"{outPath}\"");
                return;
            }

            try
            {
                exporter.GetConfig().Save(configOutPath);
            }
            catch (IOException)
            {
                Log($"Error: The output config file path is likely being held open by another program: \"{configOutPath}\"");
                return;
            }

            Log("Exported params as workbook.");
        }

        private void ExportCsvParams(IList<ParamInfo> paramInfos)
        {
            foreach (ParamInfo paramInfo in paramInfos)
            {
                using var builder = new CsvBuilder(Encoding.UTF8);
                using var exporter = new ParamExporter(builder, Properties.Settings.Default.ExportUsingInternalNames);
                ExportParamAsSingleSheet(paramInfo, exporter);
            }
        }

        private void ExportTsvParams(IList<ParamInfo> paramInfos)
        {
            foreach (ParamInfo paramInfo in paramInfos)
            {
                using var builder = new TsvBuilder(Encoding.UTF8);
                using var exporter = new ParamExporter(builder, Properties.Settings.Default.ExportUsingInternalNames);
                ExportParamAsSingleSheet(paramInfo, exporter);
            }
        }

        private void ExportXlsParams(IList<ParamInfo> paramInfos, bool exportAsWorkbook)
        {
            if (exportAsWorkbook)
            {
                string? outPath = FileDialogs.GetSavePath("Export params as Xls workbook", "Xls Param Workbook (*.xls)|*.xls");
                if (string.IsNullOrEmpty(outPath))
                {
                    Log("Canceling Xls workbook export.");
                    return;
                }

                using var builder = new XlsBuilder();
                using var exporter = new ParamExporter(builder, Properties.Settings.Default.ExportUsingInternalNames);
                ExportParamsAsWorkbook(paramInfos, exporter, outPath, 256, 65536);
            }
            else
            {
                foreach (ParamInfo paramInfo in paramInfos)
                {
                    using var builder = new XlsBuilder();
                    using var exporter = new ParamExporter(builder, Properties.Settings.Default.ExportUsingInternalNames);
                    ExportParamAsSingleSheet(paramInfo, exporter, 256, 65536);
                }
            }
        }

        private void ExportXlsxParams(IList<ParamInfo> paramInfos, bool exportAsWorkbook)
        {
            if (exportAsWorkbook)
            {
                string? outPath = FileDialogs.GetSavePath("Export params as Xlsx workbook", "Xlsx Param Workbook (*.xlsx)|*.xlsx");
                if (string.IsNullOrEmpty(outPath))
                {
                    Log("Canceling Xlsx workbook export.");
                    return;
                }

                using var builder = new XlsxBuilder();
                using var exporter = new ParamExporter(builder, Properties.Settings.Default.ExportUsingInternalNames);
                ExportParamsAsWorkbook(paramInfos, exporter, outPath, 16384, 1048576);
            }
            else
            {
                foreach (ParamInfo paramInfo in paramInfos)
                {
                    using var builder = new XlsxBuilder();
                    using var exporter = new ParamExporter(builder, Properties.Settings.Default.ExportUsingInternalNames);
                    ExportParamAsSingleSheet(paramInfo, exporter, 16384, 1048576);
                }
            }
        }

        private void ExportParams(IList<ParamInfo> paramInfos, ParamFileType fileType, bool exportAsWorkbook)
        {
            switch (fileType)
            {
                case ParamFileType.Binary:
                    ExportBinaryParams(paramInfos);
                    break;
                case ParamFileType.Csv:
                    ExportCsvParams(paramInfos);
                    break;
                case ParamFileType.Tsv:
                    ExportTsvParams(paramInfos);
                    break;
                case ParamFileType.Xls:
                    ExportXlsParams(paramInfos, exportAsWorkbook);
                    break;
                case ParamFileType.Xlsx:
                    ExportXlsxParams(paramInfos, exportAsWorkbook);
                    break;
            }
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