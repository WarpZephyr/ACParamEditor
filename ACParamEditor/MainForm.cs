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

        /// <summary>
        /// The currently copied param rows.
        /// </summary>
        private List<PARAM.Row> RowCopies { get; set; } = new List<PARAM.Row>();

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
            ((ToolStripDropDownMenu)MenuEditor.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)MenuOther.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)MenuHelp.DropDown).ShowImageMargin = false;
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
            UpdateStatus("Opening params.");
            string[] paths = PathUtil.GetFilePaths("C:\\Users", "Open Params", "Param (*.bin)|*.bin|Param (*.param)|*.param|All (*.*)|*.*");
            LoadParams(paths);
            if (paths.Length == 0)
                UpdateStatus("Canceling opening params.");
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

        #region Form DataGridView

        private void ParamDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            RefreshRows();

            int count = ParamDataGridView.GetSelectedRowCountBySelectedCells();
            if (count > 1)
                UpdateStatus($"Selected {count} params.");
        }

        private void RowDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            // This feels hacky
            var currentparam = (ParamInfo)ParamDataGridView.CurrentRow.DataBoundItem;
            if (currentparam.Param == null)
            {
                Params.Remove(currentparam);
                UpdateStatus("Warning: Invalid param found, removing.");
                return;
            }

            if (currentparam.RowCount == 0)
            {
                CellDataGridView.DataSource = null;
                return;
            }

            if (RowDataGridView.CurrentRow.Index + 1 > currentparam.RowCount)
                return;
            // This feels hacky

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

            int count = RowDataGridView.GetSelectedRowCountBySelectedCells();
            if (count > 1)
                UpdateStatus($"Selected {count} rows.");
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

        private void CellDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            int count = CellDataGridView.GetSelectedRowCountBySelectedCells();
            if (count > 1)
                UpdateStatus($"Selected {count} clls.");
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

        #region Form Rows

        private void RowNew_Click(object sender, EventArgs e)
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            var currentparam = (ParamInfo)ParamDataGridView.CurrentRow.DataBoundItem;
            if (currentparam.Param == null)
            {
                Params.Remove(currentparam);
                UpdateStatus("Warning: Invalid param found, removing.");
                return;
            }

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
            if (currentparam.Param == null)
            {
                Params.Remove(currentparam);
                UpdateStatus("Warning: Invalid param found, removing.");
                return;
            }

            var found = new List<int>();
            foreach (DataGridViewCell cell in RowDataGridView.SelectedCells)
            {
                if (!found.Contains(cell.RowIndex))
                {
                    currentparam.Param.Rows.Remove((PARAM.Row)RowDataGridView.Rows[cell.RowIndex].DataBoundItem);
                    found.Add(cell.RowIndex);
                }
            }

            RefreshRows();
            UpdateStatus($"Deleted {found.Count} rows.");
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
            if (currentparam.Param == null)
            {
                Params.Remove(currentparam);
                UpdateStatus("Warning: Invalid param found, removing.");
                return;
            }

            if (!currentparam.RowCompatible(RowCopies[0]))
            {
                UpdateStatus($"Copied rows are not compatibile.");
                return;
            }

            foreach (var row in RowCopies)
            {
                if (currentparam.ContainsRowID(row.ID))
                    row.ID = currentparam.GetNextRowID();
                ((List<PARAM.Row>)RowDataGridView.DataSource).Add(row);
            }

            RefreshRows();
            UpdateStatus($"Pasted {RowCopies.Count} rows.");
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
            if (currentparam.Param == null)
            {
                Params.Remove(currentparam);
                UpdateStatus("Warning: Invalid param found, removing.");
                return;
            }

            foreach (var row in copies)
            {
                if (currentparam.ContainsRowID(row.ID))
                    row.ID = currentparam.GetNextRowID();
                ((List<PARAM.Row>)RowDataGridView.DataSource).Add(row);
            }

            RefreshRows();
            UpdateStatus($"Duplicated {copies.Count} rows.");
        }

        #endregion

        #region Form Editor

        private void MenuEditorDef_Click(object sender, EventArgs e)
        {
            var form = new DefEditorForm();
            UpdateStatus("Opened Param Def Editor");
            form.ShowDialog();
            UpdateStatus("Closed Param Def Editor");
        }

        #endregion

        #region Form Other

        private void MenuOtherOpenResourcesFolder_Click(object sender, EventArgs e)
        {
            try
            {
                bool question = FormUtil.ShowQuestionDialog("Are you sure you want to open the Resources folder?", "Open Resources Folder");
                if (!question)
                {
                    UpdateStatus("Canceled opening Resources folder.");
                    return;
                }

                if (PathUtil.OpenResources())
                {
                    UpdateStatus("Opened Resources folder.");
                }
                else
                {
                    UpdateStatus("Could not find Resources folder.");
                }
            }
            catch
            {
                UpdateStatus("Failed to open Resources folder.");
            }
        }

        private void MenuOtherOpenResourcesDefFolder_Click(object sender, EventArgs e)
        {
            try
            {
                bool question = FormUtil.ShowQuestionDialog("Are you sure you want to open the Resources Def folder?", "Open Resources Def Folder");
                if (!question)
                {
                    UpdateStatus("Canceled opening Resources Def folder.");
                    return;
                }

                if (PathUtil.OpenFolder(DefFolderPath))
                {
                    UpdateStatus("Opened Resources Def folder.");
                }
                else
                {
                    UpdateStatus("Could not find Resources Def folder.");
                }
            }
            catch
            {
                UpdateStatus("Failed to open Resources Def folder.");
            }
        }

        private void MenuOtherOpenCurrentDefsFolder_Click(object sender, EventArgs e)
        {
            try
            {
                bool question = FormUtil.ShowQuestionDialog("Are you sure you want to open the Current Def folder?", "Open Current Def Folder");
                if (!question)
                {
                    UpdateStatus("Canceled opening Current Def folder.");
                    return;
                }

                if (PathUtil.OpenFolder(GetCurrentDefPath()))
                {
                    UpdateStatus("Opened Current Def folder.");
                }
                else
                {
                    RefreshDefGames();
                    UpdateStatus("Could not find Current Def folder, refreshing def combobox.");
                }
            }
            catch
            {
                UpdateStatus("Failed to open Current Def folder.");
            }
        }

        #endregion

        #region Form Help

        private void MenuHelpWhatIsAParam_Click(object sender, EventArgs e)
        {
            FormUtil.ShowInformationDialog("A param is a file used for settings in FromSoftware games.\n" +
                "Params are like spreadsheets in that they have rows, and those rows have cells.\n\n" +
                "You can add as many rows as you want as they are entries.\n" +
                "However cells must always be the same across all rows.\n\n" +
                "Params are read using \".def\" files which define them.\n" +
                "Without a def file, you cannot read a param, though defs they can be made.\n\n" +
                "Generally params are in a \"param\" folder,\n" +
                "The extensions used are usually \".bin\" though rarely \".param\" is also seen.", "What is a param?");
        }

        private void MenuHelpAddingNewRows_Click(object sender, EventArgs e)
        {
            FormUtil.ShowInformationDialog("Rows are entries for the same data.\n" +
                "They can be added by right-clicking and pressing \"New\"\n" +
                "You can also copy and paste or duplicate all selected rows.\n" +
                "If the rows in another param are compatible, you can paste the copied rows into it.\n\n" +
                "Selected rows can also be deleted.", "Adding New Rows");
        }

        private void MenuHelpSelectingDifferentDefs_Click(object sender, EventArgs e)
        {
            FormUtil.ShowInformationDialog("The combobox, or dropdown in the upper right corner will allow you to select different sets of defs from the Resources folder.", "Selecting different defs");
        }

        private void MenuHelpAddingNewDefSets_Click(object sender, EventArgs e)
        {
            FormUtil.ShowInformationDialog("The \"Resources\\Def\\\" folder with the program holds several different def sets.\n\n" +
                "The program will treat any folder it finds in here as a new set of defs.\n\n" +
                "Any defs found inside will be loaded which switched to in the combobox in the upper right corner.\n\n" +
                "The names of added folders will be displayed as the name in the combobox.\n\n" +
                "Def files and XML files designed for def can be used.\n" +
                "Defs are usually found along in the \"def\" folder in the under the \"param\" folder in game files.\n\n" +
                "Newer games may not include defs, in which case they must be made with XML.", "Adding different defs");
        }

        private void MenuHelpIhadACrash_Click(object sender, EventArgs e)
        {
            FormUtil.ShowInformationDialog("If you had a crash, any issues, or just suggestions about the program, you can leave an issue on the github repo here:\n\n" +
                "https://www.github.com/WarpZephyr/ACParamEditor", "I had a crash!");
        }

        #endregion

        #region Refresh

        private void RefreshAll()
        {
            RefreshParamOpenAccess();
            RefreshDataGridViews();
            RefreshRows();
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

        private void RefreshRows()
        {
            if (ParamDataGridView.Rows.Count == 0)
                return;

            RowDataGridView.AutoGenerateColumns = false;
            RowDataGridView.DataSource = new List<PARAM.Row>();
            RowDataGridView.Refresh();
            var param = ((ParamInfo)ParamDataGridView.CurrentRow.DataBoundItem).Param;
            if (param == null)
            {
                Params.Remove(((ParamInfo)ParamDataGridView.CurrentRow.DataBoundItem));
                UpdateStatus("Warning: Invalid param found, removing.");
                return;
            }

            RowDataGridView.DataSource = param.Rows;
            RowDataGridView.Columns["paramrowid"].DataPropertyName = "ID";
            RowDataGridView.Columns["paramrowname"].DataPropertyName = "Name";
            UpdateStatus("Refreshed rows.");
        }

        private void RerfeshColumnVisibility()
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

        private void UpdateParamLoadStatus(int total, int skipped, int failed)
        {
            if (total == 1)
            {
                if (total - failed - skipped == total)
                {
                    UpdateStatus("Successfully read param.");
                }
                else if (skipped == 1)
                {
                    UpdateStatus("Skipped already loaded param.");
                }
                else if (failed == 1)
                {
                    UpdateStatus("Failed to read file.");
                }
            }
            else if (total > 1)
            {
                if (total - failed - skipped == total)
                {
                    UpdateStatus($"Successfully read all {total} params.");
                }
                else if (failed == 0 && skipped > 0)
                {
                    UpdateStatus($"Successfully read {total - skipped} params and skipped {skipped} already loaded params.");
                }
                else if (total - failed != 0 && skipped == 0)
                {
                    UpdateStatus($"Read {total - failed} params, failed reading {failed} files.");
                }
                else if (total - failed - skipped != 0 && failed > 0 && skipped > 0)
                {
                    UpdateStatus($"Read {total - failed - skipped} params, skipped {skipped} already loaded params, failed reading {failed} files.");
                }
                else if (failed > 0 && skipped > 0)
                {
                    UpdateStatus($"Skipped {skipped} already loaded params, failed reading {failed} files.");
                }
                else if (failed == 0 && total - skipped == 0)
                {
                    UpdateStatus($"Skipped all {total} already loaded params.");
                }
                else if (skipped == 0 && total - failed == 0)
                {
                    UpdateStatus($"Failed to read all {total} files.");
                }
            }
        }

        private void UpdateDefLoadStatus(int total, int failed)
        {
            if (total == 0)
            {
                UpdateStatus($"No param defs found in {MenuGameCombobox.Text}, disabling param loading until defs are loaded.");
            }
            else if (total == 1)
            {
                if (total - failed == total)
                {
                    UpdateStatus($"Successfully read only param def in {MenuGameCombobox.Text}.");
                }
                else if (failed == 1)
                {
                    UpdateStatus($"Failed to read only file in {MenuGameCombobox.Text}, disabling param loading until defs are loaded.");
                }
            }
            else if (total > 1)
            {
                if (total - failed == total)
                {
                    UpdateStatus($"Successfully read all {total} {MenuGameCombobox.Text} param defs.");
                }
                else if (total - failed != 0)
                {
                    UpdateStatus($"Read {total - failed} {MenuGameCombobox.Text} param defs, failed reading {failed} files.");
                }
                else if (total - failed == 0)
                {
                    UpdateStatus($"Failed to read all {total} files in {MenuGameCombobox.Text}, disabling param loading until defs are loaded.");
                }
            }
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
                if (path.EndsWith(".xml"))
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

            UpdateDefLoadStatus(total, failed);
            RefreshParamOpenAccess();
        }

        #endregion

        #region Params

        private ParamInfo ReadParamInfo(string path)
        {
            var paraminfo = new ParamInfo(path, LoadedDefs);
            paraminfo.Game = MenuGameCombobox.Text;
            return paraminfo;
        }

        private void LoadParams(string[] paths)
        {
            if (paths == null || paths.Length == 0)
                return;

            int total = paths.Length;
            int skipped = 0;
            int failed = 0;
            bool skip = false;
            foreach (string path in paths)
            {
                if (path == null || !File.Exists(path))
                    continue;

                try
                {
#if DEBUG
                    if (BND3.Is(path))
                    {
                        ReadBinder(BND3.Read(path), path, "\\");
                        continue;
                    }
#endif

                    var paraminfo = ReadParamInfo(path);
                    if (paraminfo.AppliedDef == false)
                    {
                        failed++;
                        continue;
                    }

                    if (Params.ContainsParam(paraminfo))
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

                    Params.Add(paraminfo);
                }
                catch
                {
                    failed++;
                    continue;
                }
            }

            UpdateParamLoadStatus(total, skipped, failed);
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

        #region Binder - Experimental

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

        #endregion
    }
}