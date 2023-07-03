namespace ACParamEditor
{
    partial class MainWindow
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            MainFormMenu = new MenuStrip();
            MenuFile = new ToolStripMenuItem();
            MenuFileOpen = new ToolStripMenuItem();
            MenuFileSave = new ToolStripMenuItem();
            MenuFileSaveAll = new ToolStripMenuItem();
            MenuFileClose = new ToolStripMenuItem();
            MenuFileCloseAll = new ToolStripMenuItem();
            MenuGameCombobox = new ToolStripComboBox();
            MenuEditor = new ToolStripMenuItem();
            MenuEditorDef = new ToolStripMenuItem();
            MenuOther = new ToolStripMenuItem();
            MenuOtherOpenResourcesFolder = new ToolStripMenuItem();
            MenuOtherOpenResourcesDefFolder = new ToolStripMenuItem();
            MenuOtherOpenCurrentDefsFolder = new ToolStripMenuItem();
            MenuHelp = new ToolStripMenuItem();
            MenuHelpWhatIsAParam = new ToolStripMenuItem();
            MenuHelpAddingNewRows = new ToolStripMenuItem();
            MenuHelpSelectingDifferentDefs = new ToolStripMenuItem();
            MenuHelpAddingNewDefSets = new ToolStripMenuItem();
            MenuHelpIhadACrash = new ToolStripMenuItem();
            MainFormStatusStrip = new StatusStrip();
            MainFormStatusLabel = new ToolStripStatusLabel();
            MainFormSplitContainerA = new SplitContainer();
            ParamDataGridView = new DataGridView();
            paramfilename = new DataGridViewTextBoxColumn();
            paramtype = new DataGridViewTextBoxColumn();
            paramgame = new DataGridViewTextBoxColumn();
            ParamContextMenu = new ContextMenuStrip(components);
            ParamView = new ToolStripMenuItem();
            ParamViewName = new ToolStripMenuItem();
            ParamViewType = new ToolStripMenuItem();
            ParamViewGame = new ToolStripMenuItem();
            MainFormSplitContainerB = new SplitContainer();
            RowDataGridView = new DataGridView();
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
            CellDataGridView = new DataGridView();
            paramcelldisplaytype = new DataGridViewTextBoxColumn();
            paramcellinternaltype = new DataGridViewTextBoxColumn();
            paramcellvalue = new DataGridViewTextBoxColumn();
            paramcelldisplayname = new DataGridViewTextBoxColumn();
            paramcellinternalname = new DataGridViewTextBoxColumn();
            paramcelldescription = new DataGridViewTextBoxColumn();
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
            MainFormMenu.SuspendLayout();
            MainFormStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainFormSplitContainerA).BeginInit();
            MainFormSplitContainerA.Panel1.SuspendLayout();
            MainFormSplitContainerA.Panel2.SuspendLayout();
            MainFormSplitContainerA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ParamDataGridView).BeginInit();
            ParamContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainFormSplitContainerB).BeginInit();
            MainFormSplitContainerB.Panel1.SuspendLayout();
            MainFormSplitContainerB.Panel2.SuspendLayout();
            MainFormSplitContainerB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RowDataGridView).BeginInit();
            RowContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CellDataGridView).BeginInit();
            CellContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // MainFormMenu
            // 
            MainFormMenu.BackColor = Color.FromArgb(60, 60, 60);
            MainFormMenu.Items.AddRange(new ToolStripItem[] { MenuFile, MenuGameCombobox, MenuEditor, MenuOther, MenuHelp });
            MainFormMenu.Location = new Point(0, 0);
            MainFormMenu.Name = "MainFormMenu";
            MainFormMenu.Size = new Size(1270, 27);
            MainFormMenu.TabIndex = 0;
            // 
            // MenuFile
            // 
            MenuFile.BackColor = Color.FromArgb(65, 65, 65);
            MenuFile.DropDownItems.AddRange(new ToolStripItem[] { MenuFileOpen, MenuFileSave, MenuFileSaveAll, MenuFileClose, MenuFileCloseAll });
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
            MenuFileOpen.Size = new Size(120, 22);
            MenuFileOpen.Text = "Open";
            MenuFileOpen.ToolTipText = "Open more params";
            MenuFileOpen.Click += MenuFileOpen_Click;
            // 
            // MenuFileSave
            // 
            MenuFileSave.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileSave.ForeColor = SystemColors.Control;
            MenuFileSave.Name = "MenuFileSave";
            MenuFileSave.Size = new Size(120, 22);
            MenuFileSave.Text = "Save";
            MenuFileSave.ToolTipText = "Save the currently selected params";
            MenuFileSave.Click += MenuFileSave_Click;
            // 
            // MenuFileSaveAll
            // 
            MenuFileSaveAll.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileSaveAll.ForeColor = SystemColors.Control;
            MenuFileSaveAll.Name = "MenuFileSaveAll";
            MenuFileSaveAll.Size = new Size(120, 22);
            MenuFileSaveAll.Text = "Save All";
            MenuFileSaveAll.ToolTipText = "Save all params";
            MenuFileSaveAll.Click += MenuFileSaveAll_Click;
            // 
            // MenuFileClose
            // 
            MenuFileClose.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileClose.ForeColor = SystemColors.Control;
            MenuFileClose.Name = "MenuFileClose";
            MenuFileClose.Size = new Size(120, 22);
            MenuFileClose.Text = "Close";
            MenuFileClose.ToolTipText = "Close the currently selected params";
            MenuFileClose.Click += MenuFileClose_Click;
            // 
            // MenuFileCloseAll
            // 
            MenuFileCloseAll.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileCloseAll.ForeColor = SystemColors.Control;
            MenuFileCloseAll.Name = "MenuFileCloseAll";
            MenuFileCloseAll.Size = new Size(120, 22);
            MenuFileCloseAll.Text = "Close All";
            MenuFileCloseAll.ToolTipText = "Close all params";
            MenuFileCloseAll.Click += MenuFileCloseAll_Click;
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
            // MenuEditor
            // 
            MenuEditor.BackColor = Color.FromArgb(65, 65, 65);
            MenuEditor.DropDownItems.AddRange(new ToolStripItem[] { MenuEditorDef });
            MenuEditor.ForeColor = SystemColors.Control;
            MenuEditor.Name = "MenuEditor";
            MenuEditor.Size = new Size(50, 23);
            MenuEditor.Text = "Editor";
            // 
            // MenuEditorDef
            // 
            MenuEditorDef.BackColor = Color.FromArgb(55, 55, 55);
            MenuEditorDef.ForeColor = SystemColors.Control;
            MenuEditorDef.Name = "MenuEditorDef";
            MenuEditorDef.Size = new Size(195, 22);
            MenuEditorDef.Text = "Open Param Def Editor";
            MenuEditorDef.Click += MenuEditorDef_Click;
            // 
            // MenuOther
            // 
            MenuOther.BackColor = Color.FromArgb(65, 65, 65);
            MenuOther.DropDownItems.AddRange(new ToolStripItem[] { MenuOtherOpenResourcesFolder, MenuOtherOpenResourcesDefFolder, MenuOtherOpenCurrentDefsFolder });
            MenuOther.ForeColor = SystemColors.Control;
            MenuOther.Name = "MenuOther";
            MenuOther.Size = new Size(49, 23);
            MenuOther.Text = "Other";
            // 
            // MenuOtherOpenResourcesFolder
            // 
            MenuOtherOpenResourcesFolder.BackColor = Color.FromArgb(55, 55, 55);
            MenuOtherOpenResourcesFolder.ForeColor = SystemColors.Control;
            MenuOtherOpenResourcesFolder.Name = "MenuOtherOpenResourcesFolder";
            MenuOtherOpenResourcesFolder.Size = new Size(216, 22);
            MenuOtherOpenResourcesFolder.Text = "Open Resources Folder";
            MenuOtherOpenResourcesFolder.Click += MenuOtherOpenResourcesFolder_Click;
            // 
            // MenuOtherOpenResourcesDefFolder
            // 
            MenuOtherOpenResourcesDefFolder.BackColor = Color.FromArgb(55, 55, 55);
            MenuOtherOpenResourcesDefFolder.ForeColor = SystemColors.Control;
            MenuOtherOpenResourcesDefFolder.Name = "MenuOtherOpenResourcesDefFolder";
            MenuOtherOpenResourcesDefFolder.Size = new Size(216, 22);
            MenuOtherOpenResourcesDefFolder.Text = "Open Resources Def Folder";
            MenuOtherOpenResourcesDefFolder.Click += MenuOtherOpenResourcesDefFolder_Click;
            // 
            // MenuOtherOpenCurrentDefsFolder
            // 
            MenuOtherOpenCurrentDefsFolder.BackColor = Color.FromArgb(55, 55, 55);
            MenuOtherOpenCurrentDefsFolder.ForeColor = SystemColors.Control;
            MenuOtherOpenCurrentDefsFolder.Name = "MenuOtherOpenCurrentDefsFolder";
            MenuOtherOpenCurrentDefsFolder.Size = new Size(216, 22);
            MenuOtherOpenCurrentDefsFolder.Text = "Open Current Defs Folder";
            MenuOtherOpenCurrentDefsFolder.Click += MenuOtherOpenCurrentDefsFolder_Click;
            // 
            // MenuHelp
            // 
            MenuHelp.BackColor = Color.FromArgb(65, 65, 65);
            MenuHelp.DropDownItems.AddRange(new ToolStripItem[] { MenuHelpWhatIsAParam, MenuHelpAddingNewRows, MenuHelpSelectingDifferentDefs, MenuHelpAddingNewDefSets, MenuHelpIhadACrash });
            MenuHelp.ForeColor = SystemColors.Control;
            MenuHelp.Name = "MenuHelp";
            MenuHelp.Size = new Size(44, 23);
            MenuHelp.Text = "Help";
            // 
            // MenuHelpWhatIsAParam
            // 
            MenuHelpWhatIsAParam.BackColor = Color.FromArgb(55, 55, 55);
            MenuHelpWhatIsAParam.ForeColor = SystemColors.Control;
            MenuHelpWhatIsAParam.Name = "MenuHelpWhatIsAParam";
            MenuHelpWhatIsAParam.Size = new Size(195, 22);
            MenuHelpWhatIsAParam.Text = "What is a param?";
            MenuHelpWhatIsAParam.Click += MenuHelpWhatIsAParam_Click;
            // 
            // MenuHelpAddingNewRows
            // 
            MenuHelpAddingNewRows.BackColor = Color.FromArgb(55, 55, 55);
            MenuHelpAddingNewRows.ForeColor = SystemColors.Control;
            MenuHelpAddingNewRows.Name = "MenuHelpAddingNewRows";
            MenuHelpAddingNewRows.Size = new Size(195, 22);
            MenuHelpAddingNewRows.Text = "Adding new rows";
            MenuHelpAddingNewRows.Click += MenuHelpAddingNewRows_Click;
            // 
            // MenuHelpSelectingDifferentDefs
            // 
            MenuHelpSelectingDifferentDefs.BackColor = Color.FromArgb(55, 55, 55);
            MenuHelpSelectingDifferentDefs.ForeColor = SystemColors.Control;
            MenuHelpSelectingDifferentDefs.Name = "MenuHelpSelectingDifferentDefs";
            MenuHelpSelectingDifferentDefs.Size = new Size(195, 22);
            MenuHelpSelectingDifferentDefs.Text = "Selecting different defs";
            MenuHelpSelectingDifferentDefs.Click += MenuHelpSelectingDifferentDefs_Click;
            // 
            // MenuHelpAddingNewDefSets
            // 
            MenuHelpAddingNewDefSets.BackColor = Color.FromArgb(55, 55, 55);
            MenuHelpAddingNewDefSets.ForeColor = SystemColors.Control;
            MenuHelpAddingNewDefSets.Name = "MenuHelpAddingNewDefSets";
            MenuHelpAddingNewDefSets.Size = new Size(195, 22);
            MenuHelpAddingNewDefSets.Text = "Adding new def sets";
            MenuHelpAddingNewDefSets.Click += MenuHelpAddingNewDefSets_Click;
            // 
            // MenuHelpIhadACrash
            // 
            MenuHelpIhadACrash.BackColor = Color.FromArgb(55, 55, 55);
            MenuHelpIhadACrash.ForeColor = SystemColors.Control;
            MenuHelpIhadACrash.Name = "MenuHelpIhadACrash";
            MenuHelpIhadACrash.Size = new Size(195, 22);
            MenuHelpIhadACrash.Text = "I had a crash!";
            MenuHelpIhadACrash.Click += MenuHelpIhadACrash_Click;
            // 
            // MainFormStatusStrip
            // 
            MainFormStatusStrip.BackColor = Color.FromArgb(60, 60, 60);
            MainFormStatusStrip.Items.AddRange(new ToolStripItem[] { MainFormStatusLabel });
            MainFormStatusStrip.Location = new Point(0, 607);
            MainFormStatusStrip.Name = "MainFormStatusStrip";
            MainFormStatusStrip.Size = new Size(1270, 22);
            MainFormStatusStrip.TabIndex = 1;
            // 
            // MainFormStatusLabel
            // 
            MainFormStatusLabel.Name = "MainFormStatusLabel";
            MainFormStatusLabel.Size = new Size(0, 17);
            MainFormStatusLabel.ToolTipText = "This will keep you updated on what the program is doing";
            // 
            // MainFormSplitContainerA
            // 
            MainFormSplitContainerA.AllowDrop = true;
            MainFormSplitContainerA.Dock = DockStyle.Fill;
            MainFormSplitContainerA.Location = new Point(0, 27);
            MainFormSplitContainerA.Name = "MainFormSplitContainerA";
            // 
            // MainFormSplitContainerA.Panel1
            // 
            MainFormSplitContainerA.Panel1.Controls.Add(ParamDataGridView);
            MainFormSplitContainerA.Panel1.ForeColor = SystemColors.Control;
            // 
            // MainFormSplitContainerA.Panel2
            // 
            MainFormSplitContainerA.Panel2.Controls.Add(MainFormSplitContainerB);
            MainFormSplitContainerA.Size = new Size(1270, 580);
            MainFormSplitContainerA.SplitterDistance = 395;
            MainFormSplitContainerA.TabIndex = 2;
            MainFormSplitContainerA.DragDrop += MainFormSplitContainerA_DragDrop;
            MainFormSplitContainerA.DragEnter += MainFormSplitContainerA_DragEnter;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ParamDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ParamDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ParamDataGridView.Columns.AddRange(new DataGridViewColumn[] { paramfilename, paramtype, paramgame });
            ParamDataGridView.ContextMenuStrip = ParamContextMenu;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(55, 55, 55);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 75, 75);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ParamDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            ParamDataGridView.Dock = DockStyle.Fill;
            ParamDataGridView.EnableHeadersVisualStyles = false;
            ParamDataGridView.GridColor = Color.FromArgb(45, 45, 45);
            ParamDataGridView.Location = new Point(0, 0);
            ParamDataGridView.Name = "ParamDataGridView";
            ParamDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            ParamDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            ParamDataGridView.RowTemplate.Height = 25;
            ParamDataGridView.Size = new Size(395, 580);
            ParamDataGridView.TabIndex = 0;
            ParamDataGridView.SelectionChanged += ParamDataGridView_SelectionChanged;
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
            // paramgame
            // 
            paramgame.HeaderText = "Game";
            paramgame.Name = "paramgame";
            paramgame.ReadOnly = true;
            paramgame.Visible = false;
            // 
            // ParamContextMenu
            // 
            ParamContextMenu.Items.AddRange(new ToolStripItem[] { ParamView });
            ParamContextMenu.Name = "ParamDataGridViewContextMenu";
            ParamContextMenu.Size = new Size(100, 26);
            // 
            // ParamView
            // 
            ParamView.BackColor = Color.FromArgb(65, 65, 65);
            ParamView.DropDownItems.AddRange(new ToolStripItem[] { ParamViewName, ParamViewType, ParamViewGame });
            ParamView.ForeColor = SystemColors.Control;
            ParamView.Name = "ParamView";
            ParamView.Size = new Size(99, 22);
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
            ParamViewName.Size = new Size(106, 22);
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
            ParamViewType.Size = new Size(106, 22);
            ParamViewType.Text = "Type";
            ParamViewType.Click += ParamViewType_Click;
            // 
            // ParamViewGame
            // 
            ParamViewGame.BackColor = Color.FromArgb(65, 65, 65);
            ParamViewGame.CheckOnClick = true;
            ParamViewGame.ForeColor = SystemColors.Control;
            ParamViewGame.Name = "ParamViewGame";
            ParamViewGame.Size = new Size(106, 22);
            ParamViewGame.Text = "Game";
            ParamViewGame.Click += ParamViewGame_Click;
            // 
            // MainFormSplitContainerB
            // 
            MainFormSplitContainerB.Dock = DockStyle.Fill;
            MainFormSplitContainerB.Location = new Point(0, 0);
            MainFormSplitContainerB.Name = "MainFormSplitContainerB";
            // 
            // MainFormSplitContainerB.Panel1
            // 
            MainFormSplitContainerB.Panel1.Controls.Add(RowDataGridView);
            // 
            // MainFormSplitContainerB.Panel2
            // 
            MainFormSplitContainerB.Panel2.Controls.Add(CellDataGridView);
            MainFormSplitContainerB.Size = new Size(871, 580);
            MainFormSplitContainerB.SplitterDistance = 417;
            MainFormSplitContainerB.TabIndex = 0;
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            RowDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            RowDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RowDataGridView.Columns.AddRange(new DataGridViewColumn[] { paramrowid, paramrowname });
            RowDataGridView.ContextMenuStrip = RowContextMenu;
            RowDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            RowDataGridView.Dock = DockStyle.Fill;
            RowDataGridView.EnableHeadersVisualStyles = false;
            RowDataGridView.GridColor = Color.FromArgb(45, 45, 45);
            RowDataGridView.Location = new Point(0, 0);
            RowDataGridView.Name = "RowDataGridView";
            RowDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            RowDataGridView.RowTemplate.Height = 25;
            RowDataGridView.Size = new Size(417, 580);
            RowDataGridView.TabIndex = 1;
            RowDataGridView.CellValidating += RowDataGridView_CellValidating;
            RowDataGridView.SelectionChanged += RowDataGridView_SelectionChanged;
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
            CellDataGridView.BackgroundColor = Color.FromArgb(45, 45, 45);
            CellDataGridView.BorderStyle = BorderStyle.None;
            CellDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            CellDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            CellDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CellDataGridView.Columns.AddRange(new DataGridViewColumn[] { paramcelldisplaytype, paramcellinternaltype, paramcellvalue, paramcelldisplayname, paramcellinternalname, paramcelldescription, paramcelldisplayformat, paramcelldefault, paramcellincrement, paramcellmaximum, paramcellminimum, paramcellsortid, paramcellarraylength, paramcellbitsize });
            CellDataGridView.ContextMenuStrip = CellContextMenu;
            CellDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            CellDataGridView.Dock = DockStyle.Fill;
            CellDataGridView.EnableHeadersVisualStyles = false;
            CellDataGridView.GridColor = Color.FromArgb(45, 45, 45);
            CellDataGridView.Location = new Point(0, 0);
            CellDataGridView.Name = "CellDataGridView";
            CellDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            CellDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            CellDataGridView.RowTemplate.Height = 25;
            CellDataGridView.Size = new Size(450, 580);
            CellDataGridView.TabIndex = 1;
            CellDataGridView.CellValidating += CellDataGridView_CellValidating;
            CellDataGridView.SelectionChanged += CellDataGridView_SelectionChanged;
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
            CellViewDisplayType.Click += CellViewInternalType_Click;
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
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(1270, 629);
            Controls.Add(MainFormSplitContainerA);
            Controls.Add(MainFormStatusStrip);
            Controls.Add(MainFormMenu);
            ForeColor = SystemColors.Control;
            MainMenuStrip = MainFormMenu;
            Name = "MainWindow";
            Text = "Armored Core Param Editor";
            MainFormMenu.ResumeLayout(false);
            MainFormMenu.PerformLayout();
            MainFormStatusStrip.ResumeLayout(false);
            MainFormStatusStrip.PerformLayout();
            MainFormSplitContainerA.Panel1.ResumeLayout(false);
            MainFormSplitContainerA.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainFormSplitContainerA).EndInit();
            MainFormSplitContainerA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ParamDataGridView).EndInit();
            ParamContextMenu.ResumeLayout(false);
            MainFormSplitContainerB.Panel1.ResumeLayout(false);
            MainFormSplitContainerB.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainFormSplitContainerB).EndInit();
            MainFormSplitContainerB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RowDataGridView).EndInit();
            RowContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CellDataGridView).EndInit();
            CellContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainFormMenu;
        private ToolStripMenuItem MenuFile;
        private StatusStrip MainFormStatusStrip;
        private ToolStripStatusLabel MainFormStatusLabel;
        private SplitContainer MainFormSplitContainerA;
        private SplitContainer MainFormSplitContainerB;
        private DataGridView ParamDataGridView;
        private DataGridView RowDataGridView;
        private DataGridView CellDataGridView;
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
        private DataGridViewTextBoxColumn paramfilename;
        private DataGridViewTextBoxColumn paramtype;
        private DataGridViewTextBoxColumn paramgame;
        private ToolStripMenuItem ParamViewGame;
        private ToolStripMenuItem RowCopy;
        private ToolStripMenuItem RowPaste;
        private ToolStripMenuItem RowDuplicate;
        private ToolStripMenuItem CellViewSortID;
        private ToolStripMenuItem CellViewArrayLength;
        private ToolStripMenuItem CellViewBitSize;
        private ToolStripMenuItem RowDelete;
        private ToolStripMenuItem RowNew;
        private ToolStripMenuItem MenuHelp;
        private ToolStripMenuItem MenuHelpWhatIsAParam;
        private ToolStripMenuItem MenuHelpAddingNewRows;
        private ToolStripMenuItem MenuHelpSelectingDifferentDefs;
        private ToolStripMenuItem MenuHelpAddingNewDefSets;
        private ToolStripMenuItem MenuHelpIhadACrash;
        private ToolStripMenuItem MenuOther;
        private ToolStripMenuItem MenuOtherOpenResourcesFolder;
        private ToolStripMenuItem MenuOtherOpenResourcesDefFolder;
        private ToolStripMenuItem MenuOtherOpenCurrentDefsFolder;
        private ToolStripMenuItem MenuEditor;
        private ToolStripMenuItem MenuEditorDef;
        private ToolStripMenuItem CellViewInternalType;
        private DataGridViewTextBoxColumn paramcelldisplaytype;
        private DataGridViewTextBoxColumn paramcellinternaltype;
        private DataGridViewTextBoxColumn paramcellvalue;
        private DataGridViewTextBoxColumn paramcelldisplayname;
        private DataGridViewTextBoxColumn paramcellinternalname;
        private DataGridViewTextBoxColumn paramcelldescription;
        private DataGridViewTextBoxColumn paramcelldisplayformat;
        private DataGridViewTextBoxColumn paramcelldefault;
        private DataGridViewTextBoxColumn paramcellincrement;
        private DataGridViewTextBoxColumn paramcellmaximum;
        private DataGridViewTextBoxColumn paramcellminimum;
        private DataGridViewTextBoxColumn paramcellsortid;
        private DataGridViewTextBoxColumn paramcellarraylength;
        private DataGridViewTextBoxColumn paramcellbitsize;
    }
}