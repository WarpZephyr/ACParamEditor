using CustomForms;
using SoulsFormats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace ACParamEditor
{
    public partial class DefEditorForm : Form
    {
        /// <summary>
        /// The path to the def resource folder.
        /// </summary>
        private static readonly string DefFolderPath = $"{PathUtil.ResourcesFolderPath}\\Def";

        /// <summary>
        /// The currently loaded defs.
        /// </summary>
        private BindingList<ParamdefInfo> Defs { get; set; } = new BindingList<ParamdefInfo>();

        /// <summary>
        /// The currently copied param def fields.
        /// </summary>
        private List<PARAMDEF.Field> FieldCopies { get; set; } = new List<PARAMDEF.Field>();

        public DefEditorForm()
        {
            InitializeComponent();

            // Set new renderer to override colors
            var menuRenderer = new ColorableToolStripRenderer();
            DefEditorFormMenu.Renderer = menuRenderer;
            DefContextMenu.Renderer = menuRenderer;
            FieldContextMenu.Renderer = menuRenderer;

            // Disable Image Margins for all subitems of below menu items
            ((ToolStripDropDownMenu)MenuFile.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)MenuOther.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)MenuHelp.DropDown).ShowImageMargin = false;
            DefContextMenu.ShowImageMargin = false;
            FieldContextMenu.ShowImageMargin = false;

            // Initialization
            RerfeshColumnVisibility();
            RefreshDefGames();

            // Set combobox selected item.
            MenuGameCombobox.SelectedIndex = 0;

            // Data bind param def list
            DefDataGridView.AutoGenerateColumns = false;
            DefDataGridView.DataSource = Defs;
            DefDataGridView.Columns["paramdeffilename"].DataPropertyName = "Name";
            DefDataGridView.Columns["paramdeftype"].DataPropertyName = "Type";
            DefDataGridView.Columns["paramdefformatversion"].DataPropertyName = "FormatVersion";
            DefDataGridView.Columns["paramdefdataversion"].DataPropertyName = "DataVersion";
            DefDataGridView.Columns["paramdefgame"].DataPropertyName = "Game";
        }

        #region Form IO

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            UpdateStatus("Opening paramdefs.");
            string[] paths = PathUtil.GetFilePaths("C:\\Users", "Open Paramdefs", "Paramdef (*.def)|*.def|Paramdef (*.paramdef)|*.paramdef|Paramdef (*.xml)|*.xml|All (*.*)|*.*");
            LoadDefs(paths);
            if (paths.Length == 0)
                UpdateStatus("Canceling opening paramdefs.");
        }

        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            if (DefDataGridView.Rows.Count == 0)
                return;

            bool question = FormUtil.ShowQuestionDialog("Are you sure you want to save all currently selected paramdefs?", "Save Selected Paramdefs");
            if (!question)
                return;

            var saved = new List<int>();
            foreach (DataGridViewCell cell in DefDataGridView.SelectedCells)
            {
                if (!saved.Contains(cell.RowIndex))
                {
                    var definfo = (ParamdefInfo)DefDataGridView.Rows[cell.RowIndex].DataBoundItem;
                    PathUtil.Backup(definfo.Path);
                    definfo.WriteToPath();
                    saved.Add(cell.RowIndex);
                }
            }

            UpdateStatus($"Saved {saved.Count} paramdefs.");
        }

        private void MenuFileSaveAll_Click(object sender, EventArgs e)
        {
            if (DefDataGridView.Rows.Count == 0)
                return;

            bool question = FormUtil.ShowQuestionDialog("Are you sure you want to save all paramdefs?", "Save All Paramdefs");
            if (!question)
                return;

            int count = DefDataGridView.RowCount;
            foreach (DataGridViewRow row in DefDataGridView.Rows)
            {
                var definfo = (ParamdefInfo)row.DataBoundItem;
                PathUtil.Backup(definfo.Path);
                definfo.WriteToPath();
            }

            UpdateStatus($"Saved all {count} paramdefs.");
        }

        private void MenuFileClose_Click(object sender, EventArgs e)
        {
            if (DefDataGridView.Rows.Count == 0)
                return;

            bool question = FormUtil.ShowQuestionDialog("Are you sure you want to close all currently selected paramdefs?", "Close Selected Paramdefs");
            if (!question)
                return;

            var closed = new List<int>();
            foreach (DataGridViewCell cell in DefDataGridView.SelectedCells)
            {
                if (!closed.Contains(cell.RowIndex))
                {
                    var definfo = (ParamdefInfo)DefDataGridView.Rows[cell.RowIndex].DataBoundItem;
                    Defs.Remove(definfo);
                    closed.Add(cell.RowIndex);
                }
            }

            RefreshDataGridViews();
            UpdateStatus($"Closed {closed.Count} paramdefs.");
        }

        private void MenuFileCloseAll_Click(object sender, EventArgs e)
        {
            if (DefDataGridView.Rows.Count == 0)
                return;

            bool question = FormUtil.ShowQuestionDialog("Are you sure you want to close all paramdefs?", "Close All Paramdefs");
            if (!question)
                return;

            int count = DefDataGridView.RowCount;
            Defs.Clear();
            RefreshDataGridViews();

            UpdateStatus($"Closed all {count} paramdefs.");
        }

        #endregion

        #region Form View

        private void DefViewName_Click(object sender, EventArgs e)
        {
            DefDataGridView.Columns["paramdeffilename"].Visible = DefViewName.Checked;
            UpdateStatus(DefViewName.Checked ? "Showing Names" : "Hid Names");
            DefContextMenu.Show();
            DefView.DropDown.Show();
        }

        private void DefViewType_Click(object sender, EventArgs e)
        {
            DefDataGridView.Columns["paramdeftype"].Visible = DefViewType.Checked;
            UpdateStatus(DefViewType.Checked ? "Showing Types" : "Hid Types");
            DefContextMenu.Show();
            DefView.DropDown.Show();
        }

        private void DefViewFormatVersion_Click(object sender, EventArgs e)
        {
            DefDataGridView.Columns["paramdefformatversion"].Visible = DefViewFormatVersion.Checked;
            UpdateStatus(DefViewFormatVersion.Checked ? "Showing Format Versions" : "Hid Format Versions");
            DefContextMenu.Show();
            DefView.DropDown.Show();
        }

        private void DefViewDataVersion_Click(object sender, EventArgs e)
        {
            DefDataGridView.Columns["paramdefdataversion"].Visible = DefViewDataVersion.Checked;
            UpdateStatus(DefViewDataVersion.Checked ? "Showing Data Versions" : "Hid Data Versions");
            DefContextMenu.Show();
            DefView.DropDown.Show();
        }

        private void DefViewGame_Click(object sender, EventArgs e)
        {
            DefDataGridView.Columns["paramdefgame"].Visible = DefViewGame.Checked;
            UpdateStatus(DefViewGame.Checked ? "Showing Games" : "Hid Games");
            DefContextMenu.Show();
            DefView.DropDown.Show();
        }

        private void FieldViewDisplayType_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffielddisplaytype"].Visible = FieldViewDisplayType.Checked;
            UpdateStatus(FieldViewDisplayType.Checked ? "Showing Field Display Types" : "Hid Field Display Types");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewInternalType_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffieldinternaltype"].Visible = FieldViewInternalType.Checked;
            UpdateStatus(FieldViewInternalType.Checked ? "Showing Field Internal Types" : "Hid Field Internal Types");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewDisplayName_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffielddisplayname"].Visible = FieldViewDisplayName.Checked;
            UpdateStatus(FieldViewDisplayName.Checked ? "Showing Field Display Names" : "Hid Field Display Names");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewInternalName_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffieldinternalname"].Visible = FieldViewInternalName.Checked;
            UpdateStatus(FieldViewInternalName.Checked ? "Showing Field Internal Names" : "Hid Field Internal Names");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewDescription_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffielddescription"].Visible = FieldViewDescription.Checked;
            UpdateStatus(FieldViewDescription.Checked ? "Showing Field Descriptions" : "Hid Field Descriptions");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewDisplayFormat_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffielddisplayformat"].Visible = FieldViewDisplayFormat.Checked;
            UpdateStatus(FieldViewDisplayFormat.Checked ? "Showing Field Display Formats" : "Hid Field Display Formats");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewDefault_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffielddefault"].Visible = FieldViewDefault.Checked;
            UpdateStatus(FieldViewDefault.Checked ? "Showing Field Default Values" : "Hid Field Default Values");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewIncrement_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffieldincrement"].Visible = FieldViewIncrement.Checked;
            UpdateStatus(FieldViewIncrement.Checked ? "Showing Field Increment Amount" : "Hid Field Increment Amount");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewMinimum_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffieldminimum"].Visible = FieldViewMinimum.Checked;
            UpdateStatus(FieldViewMinimum.Checked ? "Showing Field Minimum Values" : "Hid Field Mimimum Values");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewMaximum_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffieldmaximum"].Visible = FieldViewMaximum.Checked;
            UpdateStatus(FieldViewMaximum.Checked ? "Showing Field Maximum Values" : "Hid Field Maximum Values");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewSortID_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffieldsortid"].Visible = FieldViewSortID.Checked;
            UpdateStatus(FieldViewSortID.Checked ? "Showing Field Sort IDs" : "Hid Field Sort IDs");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewArrayLength_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffieldarraylength"].Visible = FieldViewArrayLength.Checked;
            UpdateStatus(FieldViewArrayLength.Checked ? "Showing Field Array Lengths" : "Hid Field Array Lengths");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        private void FieldViewBitSize_Click(object sender, EventArgs e)
        {
            FieldDataGridView.Columns["paramdeffieldbitsize"].Visible = FieldViewBitSize.Checked;
            UpdateStatus(FieldViewBitSize.Checked ? "Showing Field Bit Sizes" : "Hid Field Bit Sizes");
            FieldContextMenu.Show();
            FieldView.DropDown.Show();
        }

        #endregion

        #region Form DataGridView

        private void DefDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            RefreshFields();

            int count = DefDataGridView.GetSelectedRowCountBySelectedCells();
            if (count > 1)
                UpdateStatus($"Selected {count} param defs.");
        }

        private void FieldDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int count = FieldDataGridView.GetSelectedRowCountBySelectedCells();
            if (count > 1)
                UpdateStatus($"Selected {count} fields.");
        }

        private void FieldDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (FieldDataGridView.GetCurrentColumnName() == "paramdeffielddisplaytype" && MenuOptionsValidationNewDefaults.Checked)
            {
                var def = (ParamdefInfo)DefDataGridView.CurrentRow.DataBoundItem;
                var field = (PARAMDEF.Field)FieldDataGridView.CurrentRow.DataBoundItem;
                field.Default = ParamUtil.GetDefaultDefault(def.Def, field.DisplayType);
                field.Increment = ParamUtil.GetDefaultIncrement(def.Def, field.DisplayType);
                field.Minimum = ParamUtil.GetDefaultMinimum(def.Def, field.DisplayType);
                field.Maximum = ParamUtil.GetDefaultMaximum(def.Def, field.DisplayType);

                RefreshFields();
                UpdateStatus("Set value types depending on display type to new defaults.");
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
            LoadDefSets();
        }

        #endregion

        #region Form DragDrop

        private void DefEditorFormSplitContainerA_DragEnter(object sender, DragEventArgs e)
        {
            var data = e.Data;
            if (data == null)
                return;

            if (data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void DefEditorFormSplitContainerA_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data;
            if (data == null)
                return;

            string[] paths = (string[])data.GetData(DataFormats.FileDrop);
            LoadDefs(paths);
        }

        #endregion

        #region Form Options

        private void MenuOptionsValidationNewDefaults_Click(object sender, EventArgs e)
        {
            UpdateStatus(MenuOptionsValidationNewDefaults.Checked ? "Turning on new defaults validation." : "Turning off new defaults validation.");
        }

        #endregion

        #region Form Other

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

        #region Refresh

        private void RefreshAll()
        {
            RefreshDataGridViews();
            RefreshFields();
            RerfeshColumnVisibility();
            RefreshDefGames();
            UpdateStatus("Refreshed all.");
        }

        private void RefreshDataGridViews()
        {
            if (DefDataGridView.Rows.Count == 0)
            {
                FieldDataGridView.DataSource = null;
            }

            UpdateStatus("Refreshed DataGridViews.");
        }

        private void RefreshFields()
        {
            if (DefDataGridView.Rows.Count == 0)
                return;

            FieldDataGridView.AutoGenerateColumns = false;
            FieldDataGridView.DataSource = new List<PARAMDEF.Field>();
            FieldDataGridView.Refresh();
            var def = (ParamdefInfo)DefDataGridView.CurrentRow.DataBoundItem;

            FieldDataGridView.DataSource = def.Fields;
            FieldDataGridView.Columns["paramdeffielddisplaytype"].DataPropertyName = "DisplayType";
            FieldDataGridView.Columns["paramdeffieldinternaltype"].DataPropertyName = "InternalType";
            FieldDataGridView.Columns["paramdeffielddisplayname"].DataPropertyName = "DisplayName";
            FieldDataGridView.Columns["paramdeffieldinternalname"].DataPropertyName = "InternalName";
            FieldDataGridView.Columns["paramdeffielddescription"].DataPropertyName = "Description";
            FieldDataGridView.Columns["paramdeffielddisplayformat"].DataPropertyName = "DisplayFormat";
            FieldDataGridView.Columns["paramdeffielddefault"].DataPropertyName = "Default";
            FieldDataGridView.Columns["paramdeffieldincrement"].DataPropertyName = "Increment";
            FieldDataGridView.Columns["paramdeffieldminimum"].DataPropertyName = "Minimum";
            FieldDataGridView.Columns["paramdeffieldmaximum"].DataPropertyName = "Maximum";
            FieldDataGridView.Columns["paramdeffieldsortid"].DataPropertyName = "SortID";
            FieldDataGridView.Columns["paramdeffieldarraylength"].DataPropertyName = "ArrayLength";
            FieldDataGridView.Columns["paramdeffieldbitsize"].DataPropertyName = "BitSize";
            UpdateStatus("Refreshed fields.");
        }

        private void RerfeshColumnVisibility()
        {
            DefDataGridView.Columns["paramdeffilename"].Visible = DefViewName.Checked;
            DefDataGridView.Columns["paramdeftype"].Visible = DefViewType.Checked;
            DefDataGridView.Columns["paramdefgame"].Visible = DefViewGame.Checked;
            FieldDataGridView.Columns["paramdeffielddisplaytype"].Visible = FieldViewDisplayType.Checked;
            FieldDataGridView.Columns["paramdeffieldinternaltype"].Visible = FieldViewInternalType.Checked;
            FieldDataGridView.Columns["paramdeffielddisplayname"].Visible = FieldViewDisplayName.Checked;
            FieldDataGridView.Columns["paramdeffieldinternalname"].Visible = FieldViewInternalName.Checked;
            FieldDataGridView.Columns["paramdeffielddescription"].Visible = FieldViewDescription.Checked;
            FieldDataGridView.Columns["paramdeffielddisplayformat"].Visible = FieldViewDisplayFormat.Checked;
            FieldDataGridView.Columns["paramdeffielddefault"].Visible = FieldViewDefault.Checked;
            FieldDataGridView.Columns["paramdeffieldincrement"].Visible = FieldViewIncrement.Checked;
            FieldDataGridView.Columns["paramdeffieldminimum"].Visible = FieldViewMinimum.Checked;
            FieldDataGridView.Columns["paramdeffieldmaximum"].Visible = FieldViewMaximum.Checked;
            FieldDataGridView.Columns["paramdeffieldsortid"].Visible = FieldViewSortID.Checked;
            FieldDataGridView.Columns["paramdeffieldarraylength"].Visible = FieldViewArrayLength.Checked;
            FieldDataGridView.Columns["paramdeffieldbitsize"].Visible = FieldViewBitSize.Checked;
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
            DefEditorFormStatusLabel.Text = text;
        }

        private void UpdateDefLoadStatus(int total, int skipped, int failed)
        {
            if (total == 1)
            {
                if (total - failed - skipped == total)
                {
                    UpdateStatus("Successfully read param def.");
                }
                else if (skipped == 1)
                {
                    UpdateStatus("Skipped already loaded param def.");
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
                    UpdateStatus($"Successfully read all {total} param defs.");
                }
                else if (failed == 0 && skipped > 0)
                {
                    UpdateStatus($"Successfully read {total - skipped} param defs and skipped {skipped} already loaded param defs.");
                }
                else if (total - failed != 0 && skipped == 0)
                {
                    UpdateStatus($"Read {total - failed} param defs, failed reading {failed} files.");
                }
                else if (total - failed - skipped != 0 && failed > 0 && skipped > 0)
                {
                    UpdateStatus($"Read {total - failed - skipped} param defs, skipped {skipped} already loaded param defs, failed reading {failed} files.");
                }
                else if (failed > 0 && skipped > 0)
                {
                    UpdateStatus($"Skipped {skipped} already loaded param defs, failed reading {failed} files.");
                }
                else if (failed == 0 && total - skipped == 0)
                {
                    UpdateStatus($"Skipped all {total} already loaded param defs.");
                }
                else if (skipped == 0 && total - failed == 0)
                {
                    UpdateStatus($"Failed to read all {total} files.");
                }
            }
        }

        private void UpdateDefSetLoadStatus(int total, int failed)
        {
            if (total == 0)
            {
                UpdateStatus($"No param defs found in {MenuGameCombobox.Text}.");
            }
            else if (total == 1)
            {
                if (total - failed == total)
                {
                    UpdateStatus($"Successfully read only param def in {MenuGameCombobox.Text}.");
                }
                else if (failed == 1)
                {
                    UpdateStatus($"Failed to read only file in {MenuGameCombobox.Text}.");
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
                    UpdateStatus($"Failed to read all {total} files in {MenuGameCombobox.Text}.");
                }
            }
        }

        #endregion

        #region Param Defs

        private string GetCurrentDefPath()
        {
            return $"{DefFolderPath}\\{MenuGameCombobox.Text}";
        }

        private void LoadDefSets()
        {
            if (Defs.Count > 0)
            {
                bool question = FormUtil.ShowQuestionDialog("Are you sure you want to swap param def sets? This will close all current defs without saving.", "Close all defs without saving and load new def set");
                if (!question)
                {
                    UpdateStatus("Canceled def set swap.");
                    return;
                }
            }

            Defs.Clear();

            if (MenuGameCombobox.Text == "None")
            {
                UpdateStatus("Selected defs set to None.");
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
                var definfo = ReadParamdefInfo(path);
                if (definfo != null)
                    Defs.Add(definfo);
                else
                    failed++;
            }

            UpdateDefSetLoadStatus(total, failed);
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

        private ParamdefInfo? ReadParamdefInfo(string path)
        {
            var def = ReadParamDef(path);
            if (def == null)
                return null;
            var definfo = new ParamdefInfo(path, def);
            definfo.Game = MenuGameCombobox.Text;
            return definfo;
        }

        private void LoadDefs(string[] paths)
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
                    var definfo = ReadParamdefInfo(path);
                    if (definfo == null)
                    {
                        failed++;
                        continue;
                    }

                    if (Defs.ContainsParamdef(definfo))
                    {
                        if (!skip)
                        {
                            skip = FormUtil.ShowQuestionDialog($"A param def that already exists has been detected, would you like to skip already loaded param defs?", "Skip loaded param defs");
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

                    Defs.Add(definfo);
                }
                catch
                {
                    failed++;
                    continue;
                }
            }

            UpdateDefLoadStatus(total, skipped, failed);
        }

        #endregion

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
    }
}
