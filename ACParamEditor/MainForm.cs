using CustomForms;
using SoulsFormats;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Utilities;

namespace ACParamEditor
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// The path to the def resource folder.
        /// </summary>
        private static readonly string DefFolderPath = $"{PathUtil.ResourcesFolderPath}\\Def";

        /// <summary>
        /// The path to the param resource folder.
        /// </summary>
        private static readonly string ParamFolderPath = $"{PathUtil.ResourcesFolderPath}\\Param";

        /// <summary>
        /// The currently loaded defs.
        /// </summary>
        private List<PARAMDEF> LoadedDefs { get; set; } = new List<PARAMDEF>();

        /// <summary>
        /// The currently loaded params.
        /// </summary>
        private BindingList<ParamInfo> Params { get; set; } = new BindingList<ParamInfo>();

        public MainWindow()
        {
            InitializeComponent();

            // Set new renderer to override colors
            var menuRenderer = new ColorableToolStripRenderer();
            MainFormMenu.Renderer = menuRenderer;
            ParamContextMenu.Renderer = menuRenderer;
            RowContextMenu.Renderer = menuRenderer;
            CellContextMenu.Renderer = menuRenderer;

            // Disable Image Margins for all subitems of below menu items
            ((ToolStripDropDownMenu)MenuFile.DropDown).ShowImageMargin = false;
            ParamContextMenu.ShowImageMargin = false;
            RowContextMenu.ShowImageMargin = false;
            CellContextMenu.ShowImageMargin = false;

            // Initialization
            RerfeshColumnVisibility();
            RefreshDefGames();

            // Set combobox selected item.
            MenuGameCombobox.SelectedIndex = 0;
            if (MenuGameCombobox.Items.Count > 1)
                MenuGameCombobox.SelectedIndex = 1;

            // Attempt to load defs.
            LoadDefs();

            // Data bind param list
            ParamDataGridView.AutoGenerateColumns = false;
            ParamDataGridView.DataSource = Params;
            ParamDataGridView.Columns["paramfilename"].DataPropertyName = "Name";
            ParamDataGridView.Columns["paramtype"].DataPropertyName = "Type";
            ParamDataGridView.Columns["paramgame"].DataPropertyName = "Game";
        }

        #region Form IO

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            string[] paths = PathUtil.GetFilePaths("C:\\Users", "Open Params", "Param (*.bin)|*.bin|Param (*.param)|*.param|All (*.*)|*.*");
            LoadParams(paths);
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

            int count = saved.Count;
            UpdateStatus($"Saved {count} params.");
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

            int count = closed.Count;
            UpdateStatus($"Closed {count} params.");
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

        #endregion

        #region Form View

        private void ParamViewName_Click(object sender, EventArgs e)
        {
            ParamDataGridView.Columns["paramfilename"].Visible = ParamViewName.Checked;
            UpdateStatus(ParamViewName.Checked ? "Showing Names" : "Hid Names");
        }

        private void ParamViewType_Click(object sender, EventArgs e)
        {
            ParamDataGridView.Columns["paramtype"].Visible = ParamViewType.Checked;
            UpdateStatus(ParamViewType.Checked ? "Showing Types" : "Hid Types");
        }

        private void ParamViewGame_Click(object sender, EventArgs e)
        {
            ParamDataGridView.Columns["paramgame"].Visible = ParamViewGame.Checked;
            UpdateStatus(ParamViewType.Checked ? "Showing Games" : "Hid Games");
        }

        private void RowViewID_Click(object sender, EventArgs e)
        {
            RowDataGridView.Columns["paramrowid"].Visible = RowViewID.Checked;
            UpdateStatus(RowViewID.Checked ? "Showing IDs" : "Hid IDs");
        }

        private void RowViewName_Click(object sender, EventArgs e)
        {
            RowDataGridView.Columns["paramrowname"].Visible = RowViewName.Checked;
            UpdateStatus(RowViewName.Checked ? "Showing Row Names" : "Hid Row Names");
        }

        private void CellViewType_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcelltype"].Visible = CellViewType.Checked;
            UpdateStatus(CellViewType.Checked ? "Showing Cell Types" : "Hid Cell Types");
        }

        private void CellViewValue_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellvalue"].Visible = CellViewValue.Checked;
            UpdateStatus(CellViewValue.Checked ? "Showing Cell Values" : "Hid Cell Values");
        }

        private void CellViewDisplayName_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcelldisplayname"].Visible = CellViewDisplayName.Checked;
            UpdateStatus(CellViewDisplayName.Checked ? "Showing Cell Display Names" : "Hid Cell Display Names");
        }

        private void CellViewInternalName_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellinternalname"].Visible = CellViewInternalName.Checked;
            UpdateStatus(CellViewInternalName.Checked ? "Showing Cell Internal Names" : "Hid Cell Internal Names");
        }

        private void CellViewDescription_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcelldescription"].Visible = CellViewDescription.Checked;
            UpdateStatus(CellViewDescription.Checked ? "Showing Cell Descriptions" : "Hid Cell Descriptions");
        }

        private void CellViewDisplayFormat_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcelldisplayformat"].Visible = CellViewDisplayFormat.Checked;
            UpdateStatus(CellViewDescription.Checked ? "Showing Cell Display Formats" : "Hid Cell Display Formats");
        }

        private void CellViewDefault_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcelldefault"].Visible = CellViewDefault.Checked;
            UpdateStatus(CellViewDescription.Checked ? "Showing Cell Default Values" : "Hid Cell Default Values");
        }

        private void CellViewIncrement_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellincrement"].Visible = CellViewIncrement.Checked;
            UpdateStatus(CellViewDescription.Checked ? "Showing Cell Increment Amount" : "Hid Cell Increment Amount");
        }

        private void CellViewMinimum_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellminimum"].Visible = CellViewMinimum.Checked;
            UpdateStatus(CellViewDescription.Checked ? "Showing Cell Minimum Values" : "Hid Cell Mimimum Values");
        }

        private void CellViewMaximum_Click(object sender, EventArgs e)
        {
            CellDataGridView.Columns["paramcellmaximum"].Visible = CellViewMaximum.Checked;
            UpdateStatus(CellViewDescription.Checked ? "Showing Cell Maximum Values" : "Hid Cell Maximum Values");
        }

        #endregion

        #region Form DataGridView

        private void ParamDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            RowDataGridView.AutoGenerateColumns = false;
            RowDataGridView.DataSource = ((ParamInfo)ParamDataGridView.CurrentRow.DataBoundItem).Param.Rows;
            RowDataGridView.Columns["paramrowid"].DataPropertyName = "ID";
            RowDataGridView.Columns["paramrowname"].DataPropertyName = "Name";

            var selected = new List<int>();
            foreach (DataGridViewCell cell in ParamDataGridView.SelectedCells)
            {
                if (!selected.Contains(cell.RowIndex))
                {
                    selected.Add(cell.RowIndex);
                }
            }
            if (selected.Count > 1)
                UpdateStatus($"Selected {selected.Count} params.");
        }

        private void RowDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            CellDataGridView.AutoGenerateColumns = false;
            CellDataGridView.DataSource = ((PARAM.Row)RowDataGridView.CurrentRow.DataBoundItem).Cells;
            CellDataGridView.Columns["paramcelltype"].DataPropertyName = "DisplayType";
            CellDataGridView.Columns["paramcellvalue"].DataPropertyName = "Value";
            CellDataGridView.Columns["paramcelldisplayname"].DataPropertyName = "DisplayName";
            CellDataGridView.Columns["paramcellinternalname"].DataPropertyName = "InternalName";
            CellDataGridView.Columns["paramcelldescription"].DataPropertyName = "Description";
            CellDataGridView.Columns["paramcelldisplayformat"].DataPropertyName = "DisplayFormat";
            CellDataGridView.Columns["paramcelldefault"].DataPropertyName = "Default";
            CellDataGridView.Columns["paramcellincrement"].DataPropertyName = "Increment";
            CellDataGridView.Columns["paramcellminimum"].DataPropertyName = "Minimum";
            CellDataGridView.Columns["paramcellmaximum"].DataPropertyName = "Maximum";

            var selected = new List<int>();
            foreach (DataGridViewCell cell in RowDataGridView.SelectedCells)
            {
                if (!selected.Contains(cell.RowIndex))
                {
                    selected.Add(cell.RowIndex);
                }
            }
            if (selected.Count > 1)
                UpdateStatus($"Selected {selected.Count} rows.");
        }

        private void CellDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            var selected = new List<int>();
            foreach (DataGridViewCell cell in CellDataGridView.SelectedCells)
            {
                if (!selected.Contains(cell.RowIndex))
                {
                    selected.Add(cell.RowIndex);
                }
            }
            if (selected.Count > 1)
                UpdateStatus($"Selected {selected.Count} cells.");
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
                if (cell.DisplayType == DefType.dummy8)
                    UpdateStatus($"Invalid value: {e.FormattedValue}; Dummy8 should not be modified.");
                else
                    UpdateStatus($"Invalid value: {e.FormattedValue}");
            }
        }

        #endregion

        #region Form Game Combobox

        private void MenuGameCombobox_DropDown(object sender, EventArgs e)
        {
            RefreshDefGames();
        }

        private void MenuGameCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDefs();
        }

        #endregion

        #region Form DragDrop

        private void MainFormSplitContainerA_DragEnter(object sender, DragEventArgs e)
        {
            var data = e.Data;
            if (data == null)
                return;

            if (data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void MainFormSplitContainerA_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data;
            if (data == null)
                return;

            string[] paths = (string[])data.GetData(DataFormats.FileDrop);
            LoadParams(paths);
        }

        #endregion

        #region Refresh

        private void RefreshAll()
        {
            RefreshParamOpenAccess();
            RefreshDataGridViews();
            RerfeshColumnVisibility();
            RefreshDefGames();
            UpdateStatus("Refreshed all.");
        }

        private void RefreshParamOpenAccess()
        {
            if (LoadedDefs.Count == 0)
            {
                MenuFileOpen.Enabled = false;
                MenuFileSave.Enabled = false;
                MenuFileSaveAll.Enabled = false;
                MenuFileClose.Enabled = false;
                MenuFileCloseAll.Enabled = false;
                MainFormSplitContainerA.AllowDrop = false;
            }
            else
            {
                MenuFileOpen.Enabled = true;
                MenuFileSave.Enabled = true;
                MenuFileSaveAll.Enabled = true;
                MenuFileClose.Enabled = true;
                MenuFileCloseAll.Enabled = true;
                MainFormSplitContainerA.AllowDrop = true;
            }
        }

        private void RefreshDataGridViews()
        {
            if (ParamDataGridView.Rows.Count == 0)
            {
                RowDataGridView.DataSource = null;
                CellDataGridView.DataSource = null;
            }
            UpdateStatus("Refreshed DataGridViews.");
        }

        private void RerfeshColumnVisibility()
        {
            ParamDataGridView.Columns["paramfilename"].Visible = ParamViewName.Checked;
            ParamDataGridView.Columns["paramtype"].Visible = ParamViewType.Checked;
            RowDataGridView.Columns["paramrowid"].Visible = RowViewID.Checked;
            RowDataGridView.Columns["paramrowname"].Visible = RowViewName.Checked;
            CellDataGridView.Columns["paramcelltype"].Visible = CellViewType.Checked;
            CellDataGridView.Columns["paramcellvalue"].Visible = CellViewValue.Checked;
            CellDataGridView.Columns["paramcelldisplayname"].Visible = CellViewDisplayName.Checked;
            CellDataGridView.Columns["paramcellinternalname"].Visible = CellViewInternalName.Checked;
            CellDataGridView.Columns["paramcelldescription"].Visible = CellViewInternalName.Checked;
            UpdateStatus("Refreshed column visibility.");
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

            UpdateStatus("Refreshed def detection.");
        }

        #endregion

        #region Status

        private void UpdateStatus(string text)
        {
            MainFormStatusLabel.Text = text;
        }

        private void UpdateCountStatus(string text, string partialtext, string emptytext, string failedtext, int count, int failcount)
        {
            if (failcount == 0)
                MainFormStatusLabel.Text = text;
            else if (count - failcount > 0)
                MainFormStatusLabel.Text = partialtext;
            else if (count - failcount == 0)
                MainFormStatusLabel.Text = failedtext;
            else if (count == 0)
                MainFormStatusLabel.Text = emptytext;
        }

        #endregion

        # region Param Defs

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
                if (path.EndsWith(".def") || path.EndsWith(".paramdef"))
                    return PARAMDEF.Read(path);
                else if (path.EndsWith(".xml"))
                    return PARAMDEF.XmlDeserialize(path);
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
            LoadedDefs.Clear();

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
                UpdateStatus("Old defs selection does not exist and was removed.");
                return;
            }

            string[] paths = Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly);

            int total = paths.Length;
            int failed = 0;
            foreach (string path in paths)
            {
                var def = ReadParamDef(path);
                if (def != null)
                    LoadedDefs.Add(def);
                else
                    failed++;
            }

            UpdateCountStatus($"Successfully read all {total} {MenuGameCombobox.Text} param defs.",
                              $"Read {total} param defs, failed reading {failed} param defs.",
                              $"No param defs were read.",
                              $"Failed to read all {total} param defs.", total, failed);

            RefreshParamOpenAccess();
        }

        #endregion

        #region Params

        private ParamInfo ReadParamInfo(string path)
        {
            var paraminfo = new ParamInfo(path, LoadedDefs);
            if (MenuGameCombobox.Text != "None")
                paraminfo.Game = MenuGameCombobox.Text;
            return paraminfo;
        }

        private void LoadParams(string[] paths)
        {
            if (paths == null || paths.Length == 0)
                return;

            int total = paths.Length;
            int failed = 0;
            foreach (string path in paths)
            {
                if (path == null || !File.Exists(path))
                    continue;

                try
                {
                    if (BND3.Is(path))
                    {
                        ReadBinder(BND3.Read(path), path, "\\");
                        continue;
                    }

                    var paraminfo = ReadParamInfo(path);
                    if (paraminfo.AppliedDef == false)
                    {
                        failed++;
                        continue;
                    }
                    Params.Add(paraminfo);
                }
                catch
                {
                    failed++;
                    continue;
                }
            }

            UpdateCountStatus($"Successfully read all {total} params.",
                              $"Read {total - failed} params, failed reading {failed} params.",
                              $"No params were read.",
                              $"Failed to read all {total} params.", total, failed);
        }

        #endregion

        #region Validation

        private bool CellValueValid(PARAM.Cell cell, object newvalue)
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

        private void ReadBinder(IBinder bnd, string path, string rel)
        {
            foreach (var file in bnd.Files)
            {

                if (BND3.Is(file.Bytes))
                {
                    string prev = new string(rel);
                    ReadBinder(BND3.Read(file.Bytes), path, rel += $"{file.Name}\\");
                    rel = prev;
                }
                else if (BND4.Is(file.Bytes))
                {
                    string prev = new string(rel);
                    ReadBinder(BND4.Read(file.Bytes), path, rel += $"{file.Name}\\");
                    rel = prev;
                }
                else
                {
                    try
                    {
                        string prev = new string(rel);
                        var param = new ParamInfo(PARAM.Read(file.Bytes), path, rel += file.Name, LoadedDefs);
                        if (param.AppliedDef)
                            Params.Add(param);
                        rel = prev;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }
    }
}