using CustomWinForms;
using System.Drawing;
using System.Windows.Forms;

namespace AcParamEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            MainFormMenu = new MenuStrip();
            MenuFile = new ToolStripMenuItem();
            MenuFileOpen = new ToolStripMenuItem();
            MenuFileSave = new ToolStripMenuItem();
            MenuFileClose = new ToolStripMenuItem();
            MenuFileReload = new ToolStripMenuItem();
            MenuFileAllSeparator = new ToolStripSeparator();
            MenuFileSaveAll = new ToolStripMenuItem();
            MenuFileCloseAll = new ToolStripMenuItem();
            MenuFileReloadAll = new ToolStripMenuItem();
            MenuGameCombobox = new ToolStripComboBox();
            MenuImport = new ToolStripMenuItem();
            MenuImportParams = new ToolStripMenuItem();
            MenuExport = new ToolStripMenuItem();
            MenuExportParams = new ToolStripMenuItem();
            MenuExportParamsCsv = new ToolStripMenuItem();
            MenuExportParamsTsv = new ToolStripMenuItem();
            MenuExportParamsXls = new ToolStripMenuItem();
            MenuExportParamsXlsx = new ToolStripMenuItem();
            MenuExportParamdefs = new ToolStripMenuItem();
            MenuOptions = new ToolStripMenuItem();
            MenuOptionsExportAsWorkbook = new ToolStripMenuItem();
            ParamSplitContainerOuter = new SplitContainer();
            ParamDataGridView = new DoubleBufferedDataGridView();
            paramfilename = new DataGridViewTextBoxColumn();
            paramtype = new DataGridViewTextBoxColumn();
            paramformatversion = new DataGridViewTextBoxColumn();
            paramdefformatversion = new DataGridViewTextBoxColumn();
            paramdataversion = new DataGridViewTextBoxColumn();
            paramdefdataversion = new DataGridViewTextBoxColumn();
            paramgame = new DataGridViewTextBoxColumn();
            ParamContextMenu = new ContextMenuStrip(components);
            ParamView = new ToolStripMenuItem();
            ParamViewName = new ToolStripMenuItem();
            ParamViewType = new ToolStripMenuItem();
            ParamViewParamFormatVersion = new ToolStripMenuItem();
            ParamViewDefFormatVersion = new ToolStripMenuItem();
            ParamViewParamDataVersion = new ToolStripMenuItem();
            ParamViewDefDataVersion = new ToolStripMenuItem();
            ParamViewGame = new ToolStripMenuItem();
            ParamContextMenuSave = new ToolStripMenuItem();
            ParamContextMenuClose = new ToolStripMenuItem();
            ParamContextMenuReload = new ToolStripMenuItem();
            ParamSplitContainerInner = new SplitContainer();
            RowDataGridView = new DoubleBufferedDataGridView();
            paramrowid = new DataGridViewTextBoxColumn();
            paramrowname = new DataGridViewTextBoxColumn();
            RowContextMenu = new ContextMenuStrip(components);
            RowView = new ToolStripMenuItem();
            RowViewID = new ToolStripMenuItem();
            RowViewName = new ToolStripMenuItem();
            RowNew = new ToolStripMenuItem();
            RowDelete = new ToolStripMenuItem();
            RowCopy = new ToolStripMenuItem();
            RowPaste = new ToolStripMenuItem();
            RowDuplicate = new ToolStripMenuItem();
            CellDataGridView = new DoubleBufferedDataGridView();
            paramcelldisplaytype = new DataGridViewTextBoxColumn();
            paramcellinternaltype = new DataGridViewTextBoxColumn();
            paramcellvalue = new DataGridViewMultilineTextBoxColumn();
            paramcelldisplayname = new DataGridViewTextBoxColumn();
            paramcellinternalname = new DataGridViewTextBoxColumn();
            paramcelldescription = new DataGridViewMultilineTextBoxColumn();
            paramcelldisplayformat = new DataGridViewTextBoxColumn();
            paramcelldefault = new DataGridViewTextBoxColumn();
            paramcellincrement = new DataGridViewTextBoxColumn();
            paramcellmaximum = new DataGridViewTextBoxColumn();
            paramcellminimum = new DataGridViewTextBoxColumn();
            paramcellsortid = new DataGridViewTextBoxColumn();
            paramcellarraylength = new DataGridViewTextBoxColumn();
            paramcellbitsize = new DataGridViewTextBoxColumn();
            CellContextMenu = new ContextMenuStrip(components);
            CellView = new ToolStripMenuItem();
            CellViewDisplayType = new ToolStripMenuItem();
            CellViewInternalType = new ToolStripMenuItem();
            CellViewValue = new ToolStripMenuItem();
            CellViewDisplayName = new ToolStripMenuItem();
            CellViewInternalName = new ToolStripMenuItem();
            CellViewDescription = new ToolStripMenuItem();
            CellViewDisplayFormat = new ToolStripMenuItem();
            CellViewDefault = new ToolStripMenuItem();
            CellViewIncrement = new ToolStripMenuItem();
            CellViewMinimum = new ToolStripMenuItem();
            CellViewMaximum = new ToolStripMenuItem();
            CellViewSortID = new ToolStripMenuItem();
            CellViewArrayLength = new ToolStripMenuItem();
            CellViewBitSize = new ToolStripMenuItem();
            LogListBox = new ScrollingListBox();
            LogContextMenu = new ContextMenuStrip(components);
            LogContextMenuCopy = new ToolStripMenuItem();
            LogContextMenuClear = new ToolStripMenuItem();
            MainWindowSplitContainer = new SplitContainer();
            MenuOptionsExportUsingInternalNames = new ToolStripMenuItem();
            MainFormMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ParamSplitContainerOuter).BeginInit();
            ParamSplitContainerOuter.Panel1.SuspendLayout();
            ParamSplitContainerOuter.Panel2.SuspendLayout();
            ParamSplitContainerOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ParamDataGridView).BeginInit();
            ParamContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ParamSplitContainerInner).BeginInit();
            ParamSplitContainerInner.Panel1.SuspendLayout();
            ParamSplitContainerInner.Panel2.SuspendLayout();
            ParamSplitContainerInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RowDataGridView).BeginInit();
            RowContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CellDataGridView).BeginInit();
            CellContextMenu.SuspendLayout();
            LogContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainWindowSplitContainer).BeginInit();
            MainWindowSplitContainer.Panel1.SuspendLayout();
            MainWindowSplitContainer.Panel2.SuspendLayout();
            MainWindowSplitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // MainFormMenu
            // 
            MainFormMenu.BackColor = Color.FromArgb(60, 60, 60);
            MainFormMenu.Items.AddRange(new ToolStripItem[] { MenuFile, MenuGameCombobox, MenuImport, MenuExport, MenuOptions });
            MainFormMenu.Location = new Point(0, 0);
            MainFormMenu.Name = "MainFormMenu";
            MainFormMenu.Size = new Size(1270, 27);
            MainFormMenu.TabIndex = 0;
            // 
            // MenuFile
            // 
            MenuFile.BackColor = Color.FromArgb(65, 65, 65);
            MenuFile.DropDownItems.AddRange(new ToolStripItem[] { MenuFileOpen, MenuFileSave, MenuFileClose, MenuFileReload, MenuFileAllSeparator, MenuFileSaveAll, MenuFileCloseAll, MenuFileReloadAll });
            MenuFile.ForeColor = SystemColors.Control;
            MenuFile.Name = "MenuFile";
            MenuFile.Size = new Size(37, 23);
            MenuFile.Text = "File";
            // 
            // MenuFileOpen
            // 
            MenuFileOpen.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileOpen.ForeColor = SystemColors.Control;
            MenuFileOpen.Name = "MenuFileOpen";
            MenuFileOpen.Size = new Size(127, 22);
            MenuFileOpen.Text = "Open";
            MenuFileOpen.ToolTipText = "Open more params.";
            MenuFileOpen.Click += MenuFileOpen_Click;
            // 
            // MenuFileSave
            // 
            MenuFileSave.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileSave.ForeColor = SystemColors.Control;
            MenuFileSave.Name = "MenuFileSave";
            MenuFileSave.Size = new Size(127, 22);
            MenuFileSave.Text = "Save";
            MenuFileSave.ToolTipText = "Save the currently selected params.";
            MenuFileSave.Click += MenuFileSave_Click;
            // 
            // MenuFileClose
            // 
            MenuFileClose.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileClose.ForeColor = SystemColors.Control;
            MenuFileClose.Name = "MenuFileClose";
            MenuFileClose.Size = new Size(127, 22);
            MenuFileClose.Text = "Close";
            MenuFileClose.ToolTipText = "Close the currently selected params.";
            MenuFileClose.Click += MenuFileClose_Click;
            // 
            // MenuFileReload
            // 
            MenuFileReload.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileReload.ForeColor = SystemColors.Control;
            MenuFileReload.Name = "MenuFileReload";
            MenuFileReload.Size = new Size(127, 22);
            MenuFileReload.Text = "Reload";
            MenuFileReload.ToolTipText = "Reload the currently selected params.";
            MenuFileReload.Click += MenuFileReload_Click;
            // 
            // MenuFileAllSeparator
            // 
            MenuFileAllSeparator.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileAllSeparator.ForeColor = SystemColors.Control;
            MenuFileAllSeparator.Name = "MenuFileAllSeparator";
            MenuFileAllSeparator.Size = new Size(124, 6);
            // 
            // MenuFileSaveAll
            // 
            MenuFileSaveAll.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileSaveAll.ForeColor = SystemColors.Control;
            MenuFileSaveAll.Name = "MenuFileSaveAll";
            MenuFileSaveAll.Size = new Size(127, 22);
            MenuFileSaveAll.Text = "Save All";
            MenuFileSaveAll.ToolTipText = "Save all params.";
            MenuFileSaveAll.Click += MenuFileSaveAll_Click;
            // 
            // MenuFileCloseAll
            // 
            MenuFileCloseAll.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileCloseAll.ForeColor = SystemColors.Control;
            MenuFileCloseAll.Name = "MenuFileCloseAll";
            MenuFileCloseAll.Size = new Size(127, 22);
            MenuFileCloseAll.Text = "Close All";
            MenuFileCloseAll.ToolTipText = "Close all params.";
            MenuFileCloseAll.Click += MenuFileCloseAll_Click;
            // 
            // MenuFileReloadAll
            // 
            MenuFileReloadAll.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileReloadAll.ForeColor = SystemColors.Control;
            MenuFileReloadAll.Name = "MenuFileReloadAll";
            MenuFileReloadAll.Size = new Size(127, 22);
            MenuFileReloadAll.Text = "Reload All";
            MenuFileReloadAll.ToolTipText = "Reload all params.";
            MenuFileReloadAll.Click += MenuFileReloadAll_Click;
            // 
            // MenuGameCombobox
            // 
            MenuGameCombobox.Alignment = ToolStripItemAlignment.Right;
            MenuGameCombobox.BackColor = Color.FromArgb(65, 65, 65);
            MenuGameCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            MenuGameCombobox.FlatStyle = FlatStyle.Standard;
            MenuGameCombobox.ForeColor = SystemColors.Control;
            MenuGameCombobox.Items.AddRange(new object[] { "None" });
            MenuGameCombobox.Name = "MenuGameCombobox";
            MenuGameCombobox.Size = new Size(121, 23);
            MenuGameCombobox.ToolTipText = "Select which set of defs from Resources should be used";
            MenuGameCombobox.DropDown += MenuGameCombobox_DropDown;
            MenuGameCombobox.SelectedIndexChanged += MenuGameCombobox_SelectedIndexChanged;
            // 
            // MenuImport
            // 
            MenuImport.BackColor = Color.FromArgb(65, 65, 65);
            MenuImport.DropDownItems.AddRange(new ToolStripItem[] { MenuImportParams });
            MenuImport.ForeColor = SystemColors.Control;
            MenuImport.Name = "MenuImport";
            MenuImport.Size = new Size(55, 23);
            MenuImport.Text = "Import";
            // 
            // MenuImportParams
            // 
            MenuImportParams.BackColor = Color.FromArgb(55, 55, 55);
            MenuImportParams.ForeColor = SystemColors.Control;
            MenuImportParams.Name = "MenuImportParams";
            MenuImportParams.Size = new Size(113, 22);
            MenuImportParams.Text = "Params";
            MenuImportParams.Click += MenuImportParams_Click;
            // 
            // MenuExport
            // 
            MenuExport.BackColor = Color.FromArgb(65, 65, 65);
            MenuExport.DropDownItems.AddRange(new ToolStripItem[] { MenuExportParams, MenuExportParamdefs });
            MenuExport.ForeColor = SystemColors.Control;
            MenuExport.Name = "MenuExport";
            MenuExport.Size = new Size(53, 23);
            MenuExport.Text = "Export";
            // 
            // MenuExportParams
            // 
            MenuExportParams.BackColor = Color.FromArgb(55, 55, 55);
            MenuExportParams.DropDownItems.AddRange(new ToolStripItem[] { MenuExportParamsCsv, MenuExportParamsTsv, MenuExportParamsXls, MenuExportParamsXlsx });
            MenuExportParams.ForeColor = SystemColors.Control;
            MenuExportParams.Name = "MenuExportParams";
            MenuExportParams.Size = new Size(130, 22);
            MenuExportParams.Text = "Params";
            // 
            // MenuExportParamsCsv
            // 
            MenuExportParamsCsv.BackColor = Color.FromArgb(60, 60, 60);
            MenuExportParamsCsv.ForeColor = SystemColors.Control;
            MenuExportParamsCsv.Name = "MenuExportParamsCsv";
            MenuExportParamsCsv.Size = new Size(95, 22);
            MenuExportParamsCsv.Text = "Csv";
            MenuExportParamsCsv.Click += MenuExportParamsCsv_Click;
            // 
            // MenuExportParamsTsv
            // 
            MenuExportParamsTsv.BackColor = Color.FromArgb(60, 60, 60);
            MenuExportParamsTsv.ForeColor = SystemColors.Control;
            MenuExportParamsTsv.Name = "MenuExportParamsTsv";
            MenuExportParamsTsv.Size = new Size(95, 22);
            MenuExportParamsTsv.Text = "Tsv";
            MenuExportParamsTsv.Click += MenuExportParamsTsv_Click;
            // 
            // MenuExportParamsXls
            // 
            MenuExportParamsXls.BackColor = Color.FromArgb(60, 60, 60);
            MenuExportParamsXls.ForeColor = SystemColors.Control;
            MenuExportParamsXls.Name = "MenuExportParamsXls";
            MenuExportParamsXls.Size = new Size(95, 22);
            MenuExportParamsXls.Text = "Xls";
            MenuExportParamsXls.Click += MenuExportParamsXls_Click;
            // 
            // MenuExportParamsXlsx
            // 
            MenuExportParamsXlsx.BackColor = Color.FromArgb(60, 60, 60);
            MenuExportParamsXlsx.ForeColor = SystemColors.Control;
            MenuExportParamsXlsx.Name = "MenuExportParamsXlsx";
            MenuExportParamsXlsx.Size = new Size(95, 22);
            MenuExportParamsXlsx.Text = "Xlsx";
            MenuExportParamsXlsx.Click += MenuExportParamsXlsx_Click;
            // 
            // MenuExportParamdefs
            // 
            MenuExportParamdefs.BackColor = Color.FromArgb(55, 55, 55);
            MenuExportParamdefs.ForeColor = SystemColors.Control;
            MenuExportParamdefs.Name = "MenuExportParamdefs";
            MenuExportParamdefs.Size = new Size(130, 22);
            MenuExportParamdefs.Text = "Paramdefs";
            MenuExportParamdefs.Click += MenuExportParamdefs_Click;
            // 
            // MenuOptions
            // 
            MenuOptions.BackColor = Color.FromArgb(65, 65, 65);
            MenuOptions.DropDownItems.AddRange(new ToolStripItem[] { MenuOptionsExportAsWorkbook, MenuOptionsExportUsingInternalNames });
            MenuOptions.ForeColor = SystemColors.Control;
            MenuOptions.Name = "MenuOptions";
            MenuOptions.Size = new Size(61, 23);
            MenuOptions.Text = "Options";
            // 
            // MenuOptionsExportAsWorkbook
            // 
            MenuOptionsExportAsWorkbook.BackColor = Color.FromArgb(55, 55, 55);
            MenuOptionsExportAsWorkbook.CheckOnClick = true;
            MenuOptionsExportAsWorkbook.ForeColor = SystemColors.Control;
            MenuOptionsExportAsWorkbook.Name = "MenuOptionsExportAsWorkbook";
            MenuOptionsExportAsWorkbook.Size = new Size(224, 22);
            MenuOptionsExportAsWorkbook.Text = "Export As Workbook";
            MenuOptionsExportAsWorkbook.Click += MenuOptionsExportAsWorkbook_Click;
            // 
            // ParamSplitContainerOuter
            // 
            ParamSplitContainerOuter.AllowDrop = true;
            ParamSplitContainerOuter.Dock = DockStyle.Fill;
            ParamSplitContainerOuter.Location = new Point(0, 0);
            ParamSplitContainerOuter.Name = "ParamSplitContainerOuter";
            // 
            // ParamSplitContainerOuter.Panel1
            // 
            ParamSplitContainerOuter.Panel1.Controls.Add(ParamDataGridView);
            ParamSplitContainerOuter.Panel1.ForeColor = SystemColors.Control;
            // 
            // ParamSplitContainerOuter.Panel2
            // 
            ParamSplitContainerOuter.Panel2.Controls.Add(ParamSplitContainerInner);
            ParamSplitContainerOuter.Size = new Size(1270, 600);
            ParamSplitContainerOuter.SplitterDistance = 395;
            ParamSplitContainerOuter.TabIndex = 2;
            ParamSplitContainerOuter.DragDrop += ParamSplitContainerOuter_DragDrop;
            ParamSplitContainerOuter.DragEnter += ParamSplitContainerOuter_DragEnter;
            // 
            // ParamDataGridView
            // 
            ParamDataGridView.AllowUserToAddRows = false;
            ParamDataGridView.AllowUserToDeleteRows = false;
            ParamDataGridView.AllowUserToOrderColumns = true;
            ParamDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ParamDataGridView.BackgroundColor = Color.FromArgb(45, 45, 45);
            ParamDataGridView.BorderStyle = BorderStyle.None;
            ParamDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.Control;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            ParamDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            ParamDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ParamDataGridView.Columns.AddRange(new DataGridViewColumn[] { paramfilename, paramtype, paramformatversion, paramdefformatversion, paramdataversion, paramdefdataversion, paramgame });
            ParamDataGridView.ContextMenuStrip = ParamContextMenu;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(55, 55, 55);
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = SystemColors.Control;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(75, 75, 75);
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            ParamDataGridView.DefaultCellStyle = dataGridViewCellStyle10;
            ParamDataGridView.Dock = DockStyle.Fill;
            ParamDataGridView.EnableHeadersVisualStyles = false;
            ParamDataGridView.GridColor = Color.FromArgb(45, 45, 45);
            ParamDataGridView.Location = new Point(0, 0);
            ParamDataGridView.Name = "ParamDataGridView";
            ParamDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = SystemColors.Control;
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            ParamDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            ParamDataGridView.ShowCellToolTips = false;
            ParamDataGridView.Size = new Size(395, 600);
            ParamDataGridView.TabIndex = 0;
            ParamDataGridView.SelectionChanged += ParamDataGridView_SelectionChanged;
            ParamDataGridView.KeyDown += ParamDataGridView_KeyDown;
            // 
            // paramfilename
            // 
            paramfilename.FillWeight = 81.21828F;
            paramfilename.HeaderText = "Name";
            paramfilename.Name = "paramfilename";
            paramfilename.ReadOnly = true;
            // 
            // paramtype
            // 
            paramtype.FillWeight = 118.781723F;
            paramtype.HeaderText = "Type";
            paramtype.Name = "paramtype";
            paramtype.ReadOnly = true;
            // 
            // paramformatversion
            // 
            paramformatversion.HeaderText = "Param Format Version";
            paramformatversion.Name = "paramformatversion";
            paramformatversion.Visible = false;
            // 
            // paramdefformatversion
            // 
            paramdefformatversion.HeaderText = "Def Format Version";
            paramdefformatversion.Name = "paramdefformatversion";
            paramdefformatversion.ReadOnly = true;
            paramdefformatversion.Visible = false;
            // 
            // paramdataversion
            // 
            paramdataversion.HeaderText = "Param Data Version";
            paramdataversion.Name = "paramdataversion";
            paramdataversion.Visible = false;
            // 
            // paramdefdataversion
            // 
            paramdefdataversion.HeaderText = "Def Data Version";
            paramdefdataversion.Name = "paramdefdataversion";
            paramdefdataversion.ReadOnly = true;
            paramdefdataversion.Visible = false;
            // 
            // paramgame
            // 
            paramgame.HeaderText = "Game";
            paramgame.Name = "paramgame";
            paramgame.ReadOnly = true;
            paramgame.Visible = false;
            // 
            // ParamContextMenu
            // 
            ParamContextMenu.Items.AddRange(new ToolStripItem[] { ParamView, ParamContextMenuSave, ParamContextMenuClose, ParamContextMenuReload });
            ParamContextMenu.Name = "ParamDataGridViewContextMenu";
            ParamContextMenu.Size = new Size(111, 92);
            // 
            // ParamView
            // 
            ParamView.BackColor = Color.FromArgb(65, 65, 65);
            ParamView.DropDownItems.AddRange(new ToolStripItem[] { ParamViewName, ParamViewType, ParamViewParamFormatVersion, ParamViewDefFormatVersion, ParamViewParamDataVersion, ParamViewDefDataVersion, ParamViewGame });
            ParamView.ForeColor = SystemColors.Control;
            ParamView.Name = "ParamView";
            ParamView.Size = new Size(110, 22);
            ParamView.Text = "View";
            // 
            // ParamViewName
            // 
            ParamViewName.BackColor = Color.FromArgb(65, 65, 65);
            ParamViewName.Checked = true;
            ParamViewName.CheckOnClick = true;
            ParamViewName.CheckState = CheckState.Checked;
            ParamViewName.ForeColor = SystemColors.Control;
            ParamViewName.Name = "ParamViewName";
            ParamViewName.Size = new Size(190, 22);
            ParamViewName.Text = "Name";
            ParamViewName.Click += ParamViewName_Click;
            // 
            // ParamViewType
            // 
            ParamViewType.BackColor = Color.FromArgb(65, 65, 65);
            ParamViewType.Checked = true;
            ParamViewType.CheckOnClick = true;
            ParamViewType.CheckState = CheckState.Checked;
            ParamViewType.ForeColor = SystemColors.Control;
            ParamViewType.Name = "ParamViewType";
            ParamViewType.Size = new Size(190, 22);
            ParamViewType.Text = "Type";
            ParamViewType.Click += ParamViewType_Click;
            // 
            // ParamViewParamFormatVersion
            // 
            ParamViewParamFormatVersion.BackColor = Color.FromArgb(65, 65, 65);
            ParamViewParamFormatVersion.CheckOnClick = true;
            ParamViewParamFormatVersion.ForeColor = SystemColors.Control;
            ParamViewParamFormatVersion.Name = "ParamViewParamFormatVersion";
            ParamViewParamFormatVersion.Size = new Size(190, 22);
            ParamViewParamFormatVersion.Text = "Param Format Version";
            ParamViewParamFormatVersion.Click += ParamViewParamFormatVersion_Click;
            // 
            // ParamViewDefFormatVersion
            // 
            ParamViewDefFormatVersion.BackColor = Color.FromArgb(65, 65, 65);
            ParamViewDefFormatVersion.CheckOnClick = true;
            ParamViewDefFormatVersion.ForeColor = SystemColors.Control;
            ParamViewDefFormatVersion.Name = "ParamViewDefFormatVersion";
            ParamViewDefFormatVersion.Size = new Size(190, 22);
            ParamViewDefFormatVersion.Text = "Def Format Version";
            ParamViewDefFormatVersion.Click += ParamViewDefFormatVersion_Click;
            // 
            // ParamViewParamDataVersion
            // 
            ParamViewParamDataVersion.BackColor = Color.FromArgb(65, 65, 65);
            ParamViewParamDataVersion.CheckOnClick = true;
            ParamViewParamDataVersion.ForeColor = SystemColors.Control;
            ParamViewParamDataVersion.Name = "ParamViewParamDataVersion";
            ParamViewParamDataVersion.Size = new Size(190, 22);
            ParamViewParamDataVersion.Text = "Param Data Version";
            ParamViewParamDataVersion.Click += ParamViewParamDataVersion_Click;
            // 
            // ParamViewDefDataVersion
            // 
            ParamViewDefDataVersion.BackColor = Color.FromArgb(65, 65, 65);
            ParamViewDefDataVersion.CheckOnClick = true;
            ParamViewDefDataVersion.ForeColor = SystemColors.Control;
            ParamViewDefDataVersion.Name = "ParamViewDefDataVersion";
            ParamViewDefDataVersion.Size = new Size(190, 22);
            ParamViewDefDataVersion.Text = "Def Data Version";
            ParamViewDefDataVersion.Click += ParamViewDefDataVersion_Click;
            // 
            // ParamViewGame
            // 
            ParamViewGame.BackColor = Color.FromArgb(65, 65, 65);
            ParamViewGame.CheckOnClick = true;
            ParamViewGame.ForeColor = SystemColors.Control;
            ParamViewGame.Name = "ParamViewGame";
            ParamViewGame.Size = new Size(190, 22);
            ParamViewGame.Text = "Game";
            ParamViewGame.Click += ParamViewGame_Click;
            // 
            // ParamContextMenuSave
            // 
            ParamContextMenuSave.BackColor = Color.FromArgb(65, 65, 65);
            ParamContextMenuSave.ForeColor = SystemColors.Control;
            ParamContextMenuSave.Name = "ParamContextMenuSave";
            ParamContextMenuSave.Size = new Size(110, 22);
            ParamContextMenuSave.Text = "Save";
            ParamContextMenuSave.ToolTipText = "Save the currently selected params.";
            ParamContextMenuSave.Click += MenuFileSave_Click;
            // 
            // ParamContextMenuClose
            // 
            ParamContextMenuClose.BackColor = Color.FromArgb(65, 65, 65);
            ParamContextMenuClose.ForeColor = SystemColors.Control;
            ParamContextMenuClose.Name = "ParamContextMenuClose";
            ParamContextMenuClose.Size = new Size(110, 22);
            ParamContextMenuClose.Text = "Close";
            ParamContextMenuClose.ToolTipText = "Close the currently selected params.";
            ParamContextMenuClose.Click += MenuFileClose_Click;
            // 
            // ParamContextMenuReload
            // 
            ParamContextMenuReload.BackColor = Color.FromArgb(65, 65, 65);
            ParamContextMenuReload.ForeColor = SystemColors.Control;
            ParamContextMenuReload.Name = "ParamContextMenuReload";
            ParamContextMenuReload.Size = new Size(110, 22);
            ParamContextMenuReload.Text = "Reload";
            ParamContextMenuReload.ToolTipText = "Reload the currently selected params.";
            ParamContextMenuReload.Click += MenuFileReload_Click;
            // 
            // ParamSplitContainerInner
            // 
            ParamSplitContainerInner.Dock = DockStyle.Fill;
            ParamSplitContainerInner.Location = new Point(0, 0);
            ParamSplitContainerInner.Name = "ParamSplitContainerInner";
            // 
            // ParamSplitContainerInner.Panel1
            // 
            ParamSplitContainerInner.Panel1.Controls.Add(RowDataGridView);
            // 
            // ParamSplitContainerInner.Panel2
            // 
            ParamSplitContainerInner.Panel2.Controls.Add(CellDataGridView);
            ParamSplitContainerInner.Size = new Size(871, 600);
            ParamSplitContainerInner.SplitterDistance = 417;
            ParamSplitContainerInner.TabIndex = 0;
            // 
            // RowDataGridView
            // 
            RowDataGridView.AllowUserToAddRows = false;
            RowDataGridView.AllowUserToDeleteRows = false;
            RowDataGridView.AllowUserToOrderColumns = true;
            RowDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RowDataGridView.BackgroundColor = Color.FromArgb(45, 45, 45);
            RowDataGridView.BorderStyle = BorderStyle.None;
            RowDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            RowDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            RowDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RowDataGridView.Columns.AddRange(new DataGridViewColumn[] { paramrowid, paramrowname });
            RowDataGridView.ContextMenuStrip = RowContextMenu;
            RowDataGridView.DefaultCellStyle = dataGridViewCellStyle10;
            RowDataGridView.Dock = DockStyle.Fill;
            RowDataGridView.EnableHeadersVisualStyles = false;
            RowDataGridView.GridColor = Color.FromArgb(45, 45, 45);
            RowDataGridView.Location = new Point(0, 0);
            RowDataGridView.Name = "RowDataGridView";
            RowDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            RowDataGridView.ShowCellToolTips = false;
            RowDataGridView.Size = new Size(417, 600);
            RowDataGridView.TabIndex = 1;
            RowDataGridView.CellValidating += RowDataGridView_CellValidating;
            RowDataGridView.SelectionChanged += RowDataGridView_SelectionChanged;
            RowDataGridView.KeyDown += RowDataGridView_KeyDown;
            // 
            // paramrowid
            // 
            paramrowid.FillWeight = 65.9898453F;
            paramrowid.HeaderText = "ID";
            paramrowid.Name = "paramrowid";
            // 
            // paramrowname
            // 
            paramrowname.FillWeight = 134.010162F;
            paramrowname.HeaderText = "Row Name";
            paramrowname.Name = "paramrowname";
            // 
            // RowContextMenu
            // 
            RowContextMenu.Items.AddRange(new ToolStripItem[] { RowView, RowNew, RowDelete, RowCopy, RowPaste, RowDuplicate });
            RowContextMenu.Name = "ParamDataGridViewContextMenu";
            RowContextMenu.Size = new Size(125, 136);
            // 
            // RowView
            // 
            RowView.BackColor = Color.FromArgb(65, 65, 65);
            RowView.DropDownItems.AddRange(new ToolStripItem[] { RowViewID, RowViewName });
            RowView.ForeColor = SystemColors.Control;
            RowView.Name = "RowView";
            RowView.Size = new Size(124, 22);
            RowView.Text = "View";
            // 
            // RowViewID
            // 
            RowViewID.BackColor = Color.FromArgb(65, 65, 65);
            RowViewID.Checked = true;
            RowViewID.CheckOnClick = true;
            RowViewID.CheckState = CheckState.Checked;
            RowViewID.ForeColor = SystemColors.Control;
            RowViewID.Name = "RowViewID";
            RowViewID.Size = new Size(132, 22);
            RowViewID.Text = "ID";
            RowViewID.Click += RowViewID_Click;
            // 
            // RowViewName
            // 
            RowViewName.BackColor = Color.FromArgb(65, 65, 65);
            RowViewName.Checked = true;
            RowViewName.CheckOnClick = true;
            RowViewName.CheckState = CheckState.Checked;
            RowViewName.ForeColor = SystemColors.Control;
            RowViewName.Name = "RowViewName";
            RowViewName.Size = new Size(132, 22);
            RowViewName.Text = "Row Name";
            RowViewName.Click += RowViewName_Click;
            // 
            // RowNew
            // 
            RowNew.BackColor = Color.FromArgb(65, 65, 65);
            RowNew.ForeColor = SystemColors.Control;
            RowNew.Name = "RowNew";
            RowNew.Size = new Size(124, 22);
            RowNew.Text = "New";
            RowNew.ToolTipText = "Add a new row";
            RowNew.Click += RowNew_Click;
            // 
            // RowDelete
            // 
            RowDelete.BackColor = Color.FromArgb(65, 65, 65);
            RowDelete.ForeColor = SystemColors.Control;
            RowDelete.Name = "RowDelete";
            RowDelete.Size = new Size(124, 22);
            RowDelete.Text = "Delete";
            RowDelete.ToolTipText = "Delete the selected rows";
            RowDelete.Click += RowDelete_Click;
            // 
            // RowCopy
            // 
            RowCopy.BackColor = Color.FromArgb(65, 65, 65);
            RowCopy.ForeColor = SystemColors.Control;
            RowCopy.Name = "RowCopy";
            RowCopy.Size = new Size(124, 22);
            RowCopy.Text = "Copy";
            RowCopy.ToolTipText = "Copy the currently selected rows";
            RowCopy.Click += RowCopy_Click;
            // 
            // RowPaste
            // 
            RowPaste.BackColor = Color.FromArgb(65, 65, 65);
            RowPaste.ForeColor = SystemColors.Control;
            RowPaste.Name = "RowPaste";
            RowPaste.Size = new Size(124, 22);
            RowPaste.Text = "Paste";
            RowPaste.ToolTipText = "Paste copied rows";
            RowPaste.Click += RowPaste_Click;
            // 
            // RowDuplicate
            // 
            RowDuplicate.BackColor = Color.FromArgb(65, 65, 65);
            RowDuplicate.ForeColor = SystemColors.Control;
            RowDuplicate.Name = "RowDuplicate";
            RowDuplicate.Size = new Size(124, 22);
            RowDuplicate.Text = "Duplicate";
            RowDuplicate.ToolTipText = "Duplicate the selected rows";
            RowDuplicate.Click += RowDuplicate_Click;
            // 
            // CellDataGridView
            // 
            CellDataGridView.AllowUserToAddRows = false;
            CellDataGridView.AllowUserToDeleteRows = false;
            CellDataGridView.AllowUserToOrderColumns = true;
            CellDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CellDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            CellDataGridView.BackgroundColor = Color.FromArgb(45, 45, 45);
            CellDataGridView.BorderStyle = BorderStyle.None;
            CellDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            CellDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            CellDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CellDataGridView.Columns.AddRange(new DataGridViewColumn[] { paramcelldisplaytype, paramcellinternaltype, paramcellvalue, paramcelldisplayname, paramcellinternalname, paramcelldescription, paramcelldisplayformat, paramcelldefault, paramcellincrement, paramcellmaximum, paramcellminimum, paramcellsortid, paramcellarraylength, paramcellbitsize });
            CellDataGridView.ContextMenuStrip = CellContextMenu;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(55, 55, 55);
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = SystemColors.Control;
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(75, 75, 75);
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            CellDataGridView.DefaultCellStyle = dataGridViewCellStyle12;
            CellDataGridView.Dock = DockStyle.Fill;
            CellDataGridView.EnableHeadersVisualStyles = false;
            CellDataGridView.GridColor = Color.FromArgb(45, 45, 45);
            CellDataGridView.Location = new Point(0, 0);
            CellDataGridView.Name = "CellDataGridView";
            CellDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            CellDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            CellDataGridView.ShowCellToolTips = false;
            CellDataGridView.Size = new Size(450, 600);
            CellDataGridView.TabIndex = 1;
            CellDataGridView.CellFormatting += CellDataGridView_CellFormatting;
            CellDataGridView.DataError += CellDataGridView_DataError;
            // 
            // paramcelldisplaytype
            // 
            paramcelldisplaytype.FillWeight = 40F;
            paramcelldisplaytype.HeaderText = "Display Type";
            paramcelldisplaytype.Name = "paramcelldisplaytype";
            paramcelldisplaytype.ReadOnly = true;
            paramcelldisplaytype.Resizable = DataGridViewTriState.True;
            // 
            // paramcellinternaltype
            // 
            paramcellinternaltype.HeaderText = "Internal Type";
            paramcellinternaltype.Name = "paramcellinternaltype";
            paramcellinternaltype.Visible = false;
            // 
            // paramcellvalue
            // 
            paramcellvalue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            paramcellvalue.DefaultCellStyle = dataGridViewCellStyle3;
            paramcellvalue.FillWeight = 60F;
            paramcellvalue.HeaderText = "Cell Value";
            paramcellvalue.Name = "paramcellvalue";
            // 
            // paramcelldisplayname
            // 
            paramcelldisplayname.FillWeight = 70F;
            paramcelldisplayname.HeaderText = "Display Name";
            paramcelldisplayname.Name = "paramcelldisplayname";
            paramcelldisplayname.ReadOnly = true;
            // 
            // paramcellinternalname
            // 
            paramcellinternalname.FillWeight = 75F;
            paramcellinternalname.HeaderText = "Internal Name";
            paramcellinternalname.Name = "paramcellinternalname";
            paramcellinternalname.ReadOnly = true;
            paramcellinternalname.Visible = false;
            // 
            // paramcelldescription
            // 
            paramcelldescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            paramcelldescription.DefaultCellStyle = dataGridViewCellStyle4;
            paramcelldescription.FillWeight = 130F;
            paramcelldescription.HeaderText = "Description";
            paramcelldescription.Name = "paramcelldescription";
            paramcelldescription.ReadOnly = true;
            paramcelldescription.Visible = false;
            // 
            // paramcelldisplayformat
            // 
            paramcelldisplayformat.HeaderText = "Display Format";
            paramcelldisplayformat.Name = "paramcelldisplayformat";
            paramcelldisplayformat.ReadOnly = true;
            paramcelldisplayformat.Visible = false;
            // 
            // paramcelldefault
            // 
            paramcelldefault.HeaderText = "Default Value";
            paramcelldefault.Name = "paramcelldefault";
            paramcelldefault.ReadOnly = true;
            paramcelldefault.Visible = false;
            // 
            // paramcellincrement
            // 
            paramcellincrement.HeaderText = "Increment Amount";
            paramcellincrement.Name = "paramcellincrement";
            paramcellincrement.ReadOnly = true;
            paramcellincrement.Visible = false;
            // 
            // paramcellmaximum
            // 
            paramcellmaximum.HeaderText = "Maxmium Value";
            paramcellmaximum.Name = "paramcellmaximum";
            paramcellmaximum.ReadOnly = true;
            paramcellmaximum.Visible = false;
            // 
            // paramcellminimum
            // 
            paramcellminimum.HeaderText = "Minimum Value";
            paramcellminimum.Name = "paramcellminimum";
            paramcellminimum.ReadOnly = true;
            paramcellminimum.Visible = false;
            // 
            // paramcellsortid
            // 
            paramcellsortid.HeaderText = "Sort ID";
            paramcellsortid.Name = "paramcellsortid";
            paramcellsortid.ReadOnly = true;
            paramcellsortid.Visible = false;
            // 
            // paramcellarraylength
            // 
            paramcellarraylength.HeaderText = "Array Length";
            paramcellarraylength.Name = "paramcellarraylength";
            paramcellarraylength.ReadOnly = true;
            paramcellarraylength.Visible = false;
            // 
            // paramcellbitsize
            // 
            paramcellbitsize.HeaderText = "Bit Size";
            paramcellbitsize.Name = "paramcellbitsize";
            paramcellbitsize.ReadOnly = true;
            paramcellbitsize.Visible = false;
            // 
            // CellContextMenu
            // 
            CellContextMenu.Items.AddRange(new ToolStripItem[] { CellView });
            CellContextMenu.Name = "ParamDataGridViewContextMenu";
            CellContextMenu.Size = new Size(100, 26);
            // 
            // CellView
            // 
            CellView.BackColor = Color.FromArgb(65, 65, 65);
            CellView.DropDownItems.AddRange(new ToolStripItem[] { CellViewDisplayType, CellViewInternalType, CellViewValue, CellViewDisplayName, CellViewInternalName, CellViewDescription, CellViewDisplayFormat, CellViewDefault, CellViewIncrement, CellViewMinimum, CellViewMaximum, CellViewSortID, CellViewArrayLength, CellViewBitSize });
            CellView.ForeColor = SystemColors.Control;
            CellView.Name = "CellView";
            CellView.Size = new Size(99, 22);
            CellView.Text = "View";
            // 
            // CellViewDisplayType
            // 
            CellViewDisplayType.BackColor = Color.FromArgb(65, 65, 65);
            CellViewDisplayType.Checked = true;
            CellViewDisplayType.CheckOnClick = true;
            CellViewDisplayType.CheckState = CheckState.Checked;
            CellViewDisplayType.ForeColor = SystemColors.Control;
            CellViewDisplayType.Name = "CellViewDisplayType";
            CellViewDisplayType.Size = new Size(175, 22);
            CellViewDisplayType.Text = "Display Type";
            CellViewDisplayType.Click += CellViewDisplayType_Click;
            // 
            // CellViewInternalType
            // 
            CellViewInternalType.BackColor = Color.FromArgb(65, 65, 65);
            CellViewInternalType.CheckOnClick = true;
            CellViewInternalType.ForeColor = SystemColors.Control;
            CellViewInternalType.Name = "CellViewInternalType";
            CellViewInternalType.Size = new Size(175, 22);
            CellViewInternalType.Text = "Internal Type";
            CellViewInternalType.Click += CellViewInternalType_Click;
            // 
            // CellViewValue
            // 
            CellViewValue.BackColor = Color.FromArgb(65, 65, 65);
            CellViewValue.Checked = true;
            CellViewValue.CheckOnClick = true;
            CellViewValue.CheckState = CheckState.Checked;
            CellViewValue.ForeColor = SystemColors.Control;
            CellViewValue.Name = "CellViewValue";
            CellViewValue.Size = new Size(175, 22);
            CellViewValue.Text = "Value";
            CellViewValue.Click += CellViewValue_Click;
            // 
            // CellViewDisplayName
            // 
            CellViewDisplayName.BackColor = Color.FromArgb(65, 65, 65);
            CellViewDisplayName.Checked = true;
            CellViewDisplayName.CheckOnClick = true;
            CellViewDisplayName.CheckState = CheckState.Checked;
            CellViewDisplayName.ForeColor = SystemColors.Control;
            CellViewDisplayName.Name = "CellViewDisplayName";
            CellViewDisplayName.Size = new Size(175, 22);
            CellViewDisplayName.Text = "Display Name";
            CellViewDisplayName.Click += CellViewDisplayName_Click;
            // 
            // CellViewInternalName
            // 
            CellViewInternalName.BackColor = Color.FromArgb(65, 65, 65);
            CellViewInternalName.CheckOnClick = true;
            CellViewInternalName.ForeColor = SystemColors.Control;
            CellViewInternalName.Name = "CellViewInternalName";
            CellViewInternalName.Size = new Size(175, 22);
            CellViewInternalName.Text = "Internal Name";
            CellViewInternalName.Click += CellViewInternalName_Click;
            // 
            // CellViewDescription
            // 
            CellViewDescription.BackColor = Color.FromArgb(65, 65, 65);
            CellViewDescription.CheckOnClick = true;
            CellViewDescription.ForeColor = SystemColors.Control;
            CellViewDescription.Name = "CellViewDescription";
            CellViewDescription.Size = new Size(175, 22);
            CellViewDescription.Text = "Description";
            CellViewDescription.Click += CellViewDescription_Click;
            // 
            // CellViewDisplayFormat
            // 
            CellViewDisplayFormat.BackColor = Color.FromArgb(65, 65, 65);
            CellViewDisplayFormat.CheckOnClick = true;
            CellViewDisplayFormat.ForeColor = SystemColors.Control;
            CellViewDisplayFormat.Name = "CellViewDisplayFormat";
            CellViewDisplayFormat.Size = new Size(175, 22);
            CellViewDisplayFormat.Text = "Display Format";
            CellViewDisplayFormat.Click += CellViewDisplayFormat_Click;
            // 
            // CellViewDefault
            // 
            CellViewDefault.BackColor = Color.FromArgb(65, 65, 65);
            CellViewDefault.CheckOnClick = true;
            CellViewDefault.ForeColor = SystemColors.Control;
            CellViewDefault.Name = "CellViewDefault";
            CellViewDefault.Size = new Size(175, 22);
            CellViewDefault.Text = "Default Value";
            CellViewDefault.Click += CellViewDefault_Click;
            // 
            // CellViewIncrement
            // 
            CellViewIncrement.BackColor = Color.FromArgb(65, 65, 65);
            CellViewIncrement.CheckOnClick = true;
            CellViewIncrement.ForeColor = SystemColors.Control;
            CellViewIncrement.Name = "CellViewIncrement";
            CellViewIncrement.Size = new Size(175, 22);
            CellViewIncrement.Text = "Increment Amount";
            CellViewIncrement.Click += CellViewIncrement_Click;
            // 
            // CellViewMinimum
            // 
            CellViewMinimum.BackColor = Color.FromArgb(65, 65, 65);
            CellViewMinimum.CheckOnClick = true;
            CellViewMinimum.ForeColor = SystemColors.Control;
            CellViewMinimum.Name = "CellViewMinimum";
            CellViewMinimum.Size = new Size(175, 22);
            CellViewMinimum.Text = "Minimum Value";
            CellViewMinimum.Click += CellViewMinimum_Click;
            // 
            // CellViewMaximum
            // 
            CellViewMaximum.BackColor = Color.FromArgb(65, 65, 65);
            CellViewMaximum.CheckOnClick = true;
            CellViewMaximum.ForeColor = SystemColors.Control;
            CellViewMaximum.Name = "CellViewMaximum";
            CellViewMaximum.Size = new Size(175, 22);
            CellViewMaximum.Text = "Maximum Value";
            CellViewMaximum.Click += CellViewMaximum_Click;
            // 
            // CellViewSortID
            // 
            CellViewSortID.BackColor = Color.FromArgb(65, 65, 65);
            CellViewSortID.CheckOnClick = true;
            CellViewSortID.ForeColor = SystemColors.Control;
            CellViewSortID.Name = "CellViewSortID";
            CellViewSortID.Size = new Size(175, 22);
            CellViewSortID.Text = "Sort ID";
            CellViewSortID.Click += CellViewSortID_Click;
            // 
            // CellViewArrayLength
            // 
            CellViewArrayLength.BackColor = Color.FromArgb(65, 65, 65);
            CellViewArrayLength.CheckOnClick = true;
            CellViewArrayLength.ForeColor = SystemColors.Control;
            CellViewArrayLength.Name = "CellViewArrayLength";
            CellViewArrayLength.Size = new Size(175, 22);
            CellViewArrayLength.Text = "Array Length";
            CellViewArrayLength.Click += CellViewArrayLength_Click;
            // 
            // CellViewBitSize
            // 
            CellViewBitSize.BackColor = Color.FromArgb(65, 65, 65);
            CellViewBitSize.CheckOnClick = true;
            CellViewBitSize.ForeColor = SystemColors.Control;
            CellViewBitSize.Name = "CellViewBitSize";
            CellViewBitSize.Size = new Size(175, 22);
            CellViewBitSize.Text = "Bit Size";
            CellViewBitSize.Click += CellViewBitSize_Click;
            // 
            // LogListBox
            // 
            LogListBox.BackColor = Color.FromArgb(35, 35, 35);
            LogListBox.BorderStyle = BorderStyle.FixedSingle;
            LogListBox.ContextMenuStrip = LogContextMenu;
            LogListBox.Dock = DockStyle.Fill;
            LogListBox.ForeColor = SystemColors.Window;
            LogListBox.FormattingEnabled = true;
            LogListBox.HorizontalScrollbar = true;
            LogListBox.IntegralHeight = false;
            LogListBox.Location = new Point(0, 0);
            LogListBox.Name = "LogListBox";
            LogListBox.SelectionMode = SelectionMode.MultiExtended;
            LogListBox.Size = new Size(1270, 118);
            LogListBox.TabIndex = 0;
            LogListBox.KeyDown += LogListBox_KeyDown;
            // 
            // LogContextMenu
            // 
            LogContextMenu.Items.AddRange(new ToolStripItem[] { LogContextMenuCopy, LogContextMenuClear });
            LogContextMenu.Name = "LogContextMenu";
            LogContextMenu.Size = new Size(103, 48);
            // 
            // LogContextMenuCopy
            // 
            LogContextMenuCopy.BackColor = Color.FromArgb(65, 65, 65);
            LogContextMenuCopy.ForeColor = SystemColors.Control;
            LogContextMenuCopy.Name = "LogContextMenuCopy";
            LogContextMenuCopy.Size = new Size(102, 22);
            LogContextMenuCopy.Text = "Copy";
            LogContextMenuCopy.ToolTipText = "Copies the entire log to your clipboard.";
            LogContextMenuCopy.Click += LogContextMenuCopy_Click;
            // 
            // LogContextMenuClear
            // 
            LogContextMenuClear.BackColor = Color.FromArgb(65, 65, 65);
            LogContextMenuClear.ForeColor = SystemColors.Control;
            LogContextMenuClear.Name = "LogContextMenuClear";
            LogContextMenuClear.Size = new Size(102, 22);
            LogContextMenuClear.Text = "Clear";
            LogContextMenuClear.ToolTipText = "Clears the log.";
            LogContextMenuClear.Click += LogContextMenuClear_Click;
            // 
            // MainWindowSplitContainer
            // 
            MainWindowSplitContainer.Dock = DockStyle.Fill;
            MainWindowSplitContainer.Location = new Point(0, 27);
            MainWindowSplitContainer.Name = "MainWindowSplitContainer";
            MainWindowSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // MainWindowSplitContainer.Panel1
            // 
            MainWindowSplitContainer.Panel1.Controls.Add(ParamSplitContainerOuter);
            // 
            // MainWindowSplitContainer.Panel2
            // 
            MainWindowSplitContainer.Panel2.Controls.Add(LogListBox);
            MainWindowSplitContainer.Size = new Size(1270, 722);
            MainWindowSplitContainer.SplitterDistance = 600;
            MainWindowSplitContainer.TabIndex = 3;
            // 
            // MenuOptionsExportUsingInternalNames
            // 
            MenuOptionsExportUsingInternalNames.BackColor = Color.FromArgb(55, 55, 55);
            MenuOptionsExportUsingInternalNames.CheckOnClick = true;
            MenuOptionsExportUsingInternalNames.ForeColor = SystemColors.Control;
            MenuOptionsExportUsingInternalNames.Name = "MenuOptionsExportUsingInternalNames";
            MenuOptionsExportUsingInternalNames.Size = new Size(224, 22);
            MenuOptionsExportUsingInternalNames.Text = "Export Using Internal Names";
            MenuOptionsExportUsingInternalNames.Click += MenuOptionsExportUsingInternalNames_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(1270, 749);
            Controls.Add(MainWindowSplitContainer);
            Controls.Add(MainFormMenu);
            ForeColor = SystemColors.Control;
            MainMenuStrip = MainFormMenu;
            Name = "MainForm";
            Text = "Armored Core Param Editor";
            MainFormMenu.ResumeLayout(false);
            MainFormMenu.PerformLayout();
            ParamSplitContainerOuter.Panel1.ResumeLayout(false);
            ParamSplitContainerOuter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ParamSplitContainerOuter).EndInit();
            ParamSplitContainerOuter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ParamDataGridView).EndInit();
            ParamContextMenu.ResumeLayout(false);
            ParamSplitContainerInner.Panel1.ResumeLayout(false);
            ParamSplitContainerInner.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ParamSplitContainerInner).EndInit();
            ParamSplitContainerInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RowDataGridView).EndInit();
            RowContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CellDataGridView).EndInit();
            CellContextMenu.ResumeLayout(false);
            LogContextMenu.ResumeLayout(false);
            MainWindowSplitContainer.Panel1.ResumeLayout(false);
            MainWindowSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainWindowSplitContainer).EndInit();
            MainWindowSplitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainFormMenu;
        private ToolStripMenuItem MenuFile;
        private SplitContainer ParamSplitContainerOuter;
        private SplitContainer ParamSplitContainerInner;
        private DoubleBufferedDataGridView ParamDataGridView;
        private DoubleBufferedDataGridView RowDataGridView;
        private DoubleBufferedDataGridView CellDataGridView;
        private DataGridViewTextBoxColumn paramrowid;
        private DataGridViewTextBoxColumn paramrowname;
        private ToolStripMenuItem MenuFileOpen;
        private ToolStripMenuItem MenuFileSave;
        private ToolStripMenuItem MenuFileClose;
        private ToolStripMenuItem MenuFileSaveAll;
        private ToolStripMenuItem MenuFileCloseAll;
        private ToolStripComboBox MenuGameCombobox;
        private ContextMenuStrip ParamContextMenu;
        private ToolStripMenuItem ParamView;
        private ContextMenuStrip RowContextMenu;
        private ToolStripMenuItem RowView;
        private ContextMenuStrip CellContextMenu;
        private ToolStripMenuItem CellView;
        private ToolStripMenuItem ParamViewName;
        private ToolStripMenuItem ParamViewType;
        private ToolStripMenuItem RowViewID;
        private ToolStripMenuItem RowViewName;
        private ToolStripMenuItem CellViewDisplayName;
        private ToolStripMenuItem CellViewInternalName;
        private ToolStripMenuItem CellViewDisplayType;
        private ToolStripMenuItem CellViewValue;
        private ToolStripMenuItem CellViewDescription;
        private ToolStripMenuItem CellViewDisplayFormat;
        private ToolStripMenuItem CellViewDefault;
        private ToolStripMenuItem CellViewIncrement;
        private ToolStripMenuItem CellViewMinimum;
        private ToolStripMenuItem CellViewMaximum;
        private ToolStripMenuItem ParamViewGame;
        private ToolStripMenuItem RowCopy;
        private ToolStripMenuItem RowPaste;
        private ToolStripMenuItem RowDuplicate;
        private ToolStripMenuItem CellViewSortID;
        private ToolStripMenuItem CellViewArrayLength;
        private ToolStripMenuItem CellViewBitSize;
        private ToolStripMenuItem RowDelete;
        private ToolStripMenuItem RowNew;
        private ToolStripMenuItem CellViewInternalType;
        private ToolStripMenuItem ParamViewParamFormatVersion;
        private ToolStripMenuItem ParamViewParamDataVersion;
        private ToolStripMenuItem ParamViewDefFormatVersion;
        private ToolStripMenuItem ParamViewDefDataVersion;
        private DataGridViewTextBoxColumn paramfilename;
        private DataGridViewTextBoxColumn paramtype;
        private DataGridViewTextBoxColumn paramformatversion;
        private DataGridViewTextBoxColumn paramdefformatversion;
        private DataGridViewTextBoxColumn paramdataversion;
        private DataGridViewTextBoxColumn paramdefdataversion;
        private DataGridViewTextBoxColumn paramgame;
        private ScrollingListBox LogListBox;
        private SplitContainer MainWindowSplitContainer;
        private ToolStripMenuItem MenuFileReload;
        private ToolStripMenuItem MenuFileReloadAll;
        private ContextMenuStrip LogContextMenu;
        private ToolStripMenuItem LogContextMenuClear;
        private ToolStripMenuItem ParamContextMenuSave;
        private ToolStripMenuItem ParamContextMenuClose;
        private ToolStripMenuItem ParamContextMenuReload;
        private ToolStripMenuItem LogContextMenuCopy;
        private ToolStripMenuItem MenuExport;
        private ToolStripMenuItem MenuExportParamdefs;
        private DataGridViewTextBoxColumn paramcelldisplaytype;
        private DataGridViewTextBoxColumn paramcellinternaltype;
        private DataGridViewMultilineTextBoxColumn paramcellvalue;
        private DataGridViewTextBoxColumn paramcelldisplayname;
        private DataGridViewTextBoxColumn paramcellinternalname;
        private DataGridViewMultilineTextBoxColumn paramcelldescription;
        private DataGridViewTextBoxColumn paramcelldisplayformat;
        private DataGridViewTextBoxColumn paramcelldefault;
        private DataGridViewTextBoxColumn paramcellincrement;
        private DataGridViewTextBoxColumn paramcellmaximum;
        private DataGridViewTextBoxColumn paramcellminimum;
        private DataGridViewTextBoxColumn paramcellsortid;
        private DataGridViewTextBoxColumn paramcellarraylength;
        private DataGridViewTextBoxColumn paramcellbitsize;
        private ToolStripMenuItem MenuExportParams;
        private ToolStripMenuItem MenuExportParamsCsv;
        private ToolStripSeparator MenuFileAllSeparator;
        private ToolStripMenuItem MenuExportParamsXls;
        private ToolStripMenuItem MenuImport;
        private ToolStripMenuItem MenuImportParams;
        private ToolStripMenuItem MenuOptions;
        private ToolStripMenuItem MenuOptionsExportAsWorkbook;
        private ToolStripMenuItem MenuExportParamsTsv;
        private ToolStripMenuItem MenuExportParamsXlsx;
        private ToolStripMenuItem MenuOptionsExportUsingInternalNames;
    }
}