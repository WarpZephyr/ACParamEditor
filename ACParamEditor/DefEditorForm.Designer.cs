namespace ACParamEditor
{
    partial class DefEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DefEditorFormMenu = new MenuStrip();
            MenuFile = new ToolStripMenuItem();
            MenuFileOpen = new ToolStripMenuItem();
            MenuFileSave = new ToolStripMenuItem();
            MenuFileSaveAll = new ToolStripMenuItem();
            MenuFileClose = new ToolStripMenuItem();
            MenuFileCloseAll = new ToolStripMenuItem();
            MenuGameCombobox = new ToolStripComboBox();
            MenuExport = new ToolStripMenuItem();
            MenuExportParam = new ToolStripMenuItem();
            MenuExportDef = new ToolStripMenuItem();
            MenuExportXml = new ToolStripMenuItem();
            MenuExportTxt = new ToolStripMenuItem();
            MenuOptions = new ToolStripMenuItem();
            MenuOptionsValidation = new ToolStripMenuItem();
            MenuOptionsValidationNewDefaults = new ToolStripMenuItem();
            MenuOther = new ToolStripMenuItem();
            MenuOtherOpenResourcesFolder = new ToolStripMenuItem();
            MenuOtherOpenResourcesDefFolder = new ToolStripMenuItem();
            MenuOtherOpenCurrentDefsFolder = new ToolStripMenuItem();
            MenuHelp = new ToolStripMenuItem();
            MenuHelpWhatIsAParamDef = new ToolStripMenuItem();
            MenuHelpAddingNewFields = new ToolStripMenuItem();
            MenuHelpSelectingDifferentDefs = new ToolStripMenuItem();
            MenuHelpAddingNewDefSets = new ToolStripMenuItem();
            MenuHelpIhadACrash = new ToolStripMenuItem();
            DefEditorFormStatusStrip = new StatusStrip();
            DefEditorFormStatusLabel = new ToolStripStatusLabel();
            DefEditorFormSplitContainerA = new SplitContainer();
            DefDataGridView = new DataGridView();
            paramdeffilename = new DataGridViewTextBoxColumn();
            paramdeftype = new DataGridViewTextBoxColumn();
            paramdefformatversion = new DataGridViewTextBoxColumn();
            paramdefdataversion = new DataGridViewTextBoxColumn();
            paramdefgame = new DataGridViewTextBoxColumn();
            DefContextMenu = new ContextMenuStrip(components);
            DefView = new ToolStripMenuItem();
            DefViewName = new ToolStripMenuItem();
            DefViewType = new ToolStripMenuItem();
            DefViewGame = new ToolStripMenuItem();
            FieldDataGridView = new DataGridView();
            paramdeffielddisplaytype = new DataGridViewTextBoxColumn();
            paramdeffieldinternaltype = new DataGridViewTextBoxColumn();
            paramdeffielddisplayname = new DataGridViewTextBoxColumn();
            paramdeffieldinternalname = new DataGridViewTextBoxColumn();
            paramdeffielddescription = new DataGridViewTextBoxColumn();
            paramdeffielddisplayformat = new DataGridViewTextBoxColumn();
            paramdeffielddefault = new DataGridViewTextBoxColumn();
            paramdeffieldincrement = new DataGridViewTextBoxColumn();
            paramdeffieldmaximum = new DataGridViewTextBoxColumn();
            paramdeffieldminimum = new DataGridViewTextBoxColumn();
            paramdeffieldsortid = new DataGridViewTextBoxColumn();
            paramdeffieldarraylength = new DataGridViewTextBoxColumn();
            paramdeffieldbitsize = new DataGridViewTextBoxColumn();
            FieldContextMenu = new ContextMenuStrip(components);
            FieldView = new ToolStripMenuItem();
            FieldViewDisplayType = new ToolStripMenuItem();
            FieldViewInternalType = new ToolStripMenuItem();
            FieldViewDisplayName = new ToolStripMenuItem();
            FieldViewInternalName = new ToolStripMenuItem();
            FieldViewDescription = new ToolStripMenuItem();
            FieldViewDisplayFormat = new ToolStripMenuItem();
            FieldViewDefault = new ToolStripMenuItem();
            FieldViewIncrement = new ToolStripMenuItem();
            FieldViewMinimum = new ToolStripMenuItem();
            FieldViewMaximum = new ToolStripMenuItem();
            FieldViewSortID = new ToolStripMenuItem();
            FieldViewArrayLength = new ToolStripMenuItem();
            FieldViewBitSize = new ToolStripMenuItem();
            FieldNew = new ToolStripMenuItem();
            FieldDelete = new ToolStripMenuItem();
            FieldCopy = new ToolStripMenuItem();
            FieldPaste = new ToolStripMenuItem();
            FieldDuplicate = new ToolStripMenuItem();
            DefViewFormatVersion = new ToolStripMenuItem();
            DefViewDataVersion = new ToolStripMenuItem();
            DefEditorFormMenu.SuspendLayout();
            DefEditorFormStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DefEditorFormSplitContainerA).BeginInit();
            DefEditorFormSplitContainerA.Panel1.SuspendLayout();
            DefEditorFormSplitContainerA.Panel2.SuspendLayout();
            DefEditorFormSplitContainerA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DefDataGridView).BeginInit();
            DefContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FieldDataGridView).BeginInit();
            FieldContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // DefEditorFormMenu
            // 
            DefEditorFormMenu.BackColor = Color.FromArgb(60, 60, 60);
            DefEditorFormMenu.Items.AddRange(new ToolStripItem[] { MenuFile, MenuGameCombobox, MenuExport, MenuOptions, MenuOther, MenuHelp });
            DefEditorFormMenu.Location = new Point(0, 0);
            DefEditorFormMenu.Name = "DefEditorFormMenu";
            DefEditorFormMenu.Size = new Size(1076, 27);
            DefEditorFormMenu.TabIndex = 1;
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
            MenuFileOpen.ToolTipText = "Open more param defs";
            MenuFileOpen.Click += MenuFileOpen_Click;
            // 
            // MenuFileSave
            // 
            MenuFileSave.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileSave.ForeColor = SystemColors.Control;
            MenuFileSave.Name = "MenuFileSave";
            MenuFileSave.Size = new Size(120, 22);
            MenuFileSave.Text = "Save";
            MenuFileSave.ToolTipText = "Save the currently selected param defs";
            MenuFileSave.Click += MenuFileSave_Click;
            // 
            // MenuFileSaveAll
            // 
            MenuFileSaveAll.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileSaveAll.ForeColor = SystemColors.Control;
            MenuFileSaveAll.Name = "MenuFileSaveAll";
            MenuFileSaveAll.Size = new Size(120, 22);
            MenuFileSaveAll.Text = "Save All";
            MenuFileSaveAll.ToolTipText = "Save all param defs";
            MenuFileSaveAll.Click += MenuFileSaveAll_Click;
            // 
            // MenuFileClose
            // 
            MenuFileClose.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileClose.ForeColor = SystemColors.Control;
            MenuFileClose.Name = "MenuFileClose";
            MenuFileClose.Size = new Size(120, 22);
            MenuFileClose.Text = "Close";
            MenuFileClose.ToolTipText = "Close the currently selected param defs";
            MenuFileClose.Click += MenuFileClose_Click;
            // 
            // MenuFileCloseAll
            // 
            MenuFileCloseAll.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileCloseAll.ForeColor = SystemColors.Control;
            MenuFileCloseAll.Name = "MenuFileCloseAll";
            MenuFileCloseAll.Size = new Size(120, 22);
            MenuFileCloseAll.Text = "Close All";
            MenuFileCloseAll.ToolTipText = "Close all param defs";
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
            MenuGameCombobox.ToolTipText = "Select a set of defs from Resources to load and edit";
            MenuGameCombobox.DropDown += MenuGameCombobox_DropDown;
            MenuGameCombobox.SelectedIndexChanged += MenuGameCombobox_SelectedIndexChanged;
            // 
            // MenuExport
            // 
            MenuExport.BackColor = Color.FromArgb(65, 65, 65);
            MenuExport.DropDownItems.AddRange(new ToolStripItem[] { MenuExportParam, MenuExportDef, MenuExportXml, MenuExportTxt });
            MenuExport.ForeColor = SystemColors.Control;
            MenuExport.Name = "MenuExport";
            MenuExport.Size = new Size(53, 23);
            MenuExport.Text = "Export";
            // 
            // MenuExportParam
            // 
            MenuExportParam.BackColor = Color.FromArgb(55, 55, 55);
            MenuExportParam.ForeColor = SystemColors.Control;
            MenuExportParam.Name = "MenuExportParam";
            MenuExportParam.Size = new Size(108, 22);
            MenuExportParam.Text = "Param";
            // 
            // MenuExportDef
            // 
            MenuExportDef.BackColor = Color.FromArgb(55, 55, 55);
            MenuExportDef.ForeColor = SystemColors.Control;
            MenuExportDef.Name = "MenuExportDef";
            MenuExportDef.Size = new Size(108, 22);
            MenuExportDef.Text = "Def";
            // 
            // MenuExportXml
            // 
            MenuExportXml.BackColor = Color.FromArgb(55, 55, 55);
            MenuExportXml.ForeColor = SystemColors.Control;
            MenuExportXml.Name = "MenuExportXml";
            MenuExportXml.Size = new Size(108, 22);
            MenuExportXml.Text = "Xml";
            // 
            // MenuExportTxt
            // 
            MenuExportTxt.BackColor = Color.FromArgb(55, 55, 55);
            MenuExportTxt.ForeColor = SystemColors.Control;
            MenuExportTxt.Name = "MenuExportTxt";
            MenuExportTxt.Size = new Size(108, 22);
            MenuExportTxt.Text = "Txt";
            // 
            // MenuOptions
            // 
            MenuOptions.BackColor = Color.FromArgb(65, 65, 65);
            MenuOptions.DropDownItems.AddRange(new ToolStripItem[] { MenuOptionsValidation });
            MenuOptions.ForeColor = SystemColors.Control;
            MenuOptions.Name = "MenuOptions";
            MenuOptions.Size = new Size(61, 23);
            MenuOptions.Text = "Options";
            // 
            // MenuOptionsValidation
            // 
            MenuOptionsValidation.BackColor = Color.FromArgb(55, 55, 55);
            MenuOptionsValidation.DropDownItems.AddRange(new ToolStripItem[] { MenuOptionsValidationNewDefaults });
            MenuOptionsValidation.ForeColor = SystemColors.Control;
            MenuOptionsValidation.Name = "MenuOptionsValidation";
            MenuOptionsValidation.Size = new Size(126, 22);
            MenuOptionsValidation.Text = "Validation";
            // 
            // MenuOptionsValidationNewDefaults
            // 
            MenuOptionsValidationNewDefaults.BackColor = Color.FromArgb(55, 55, 55);
            MenuOptionsValidationNewDefaults.Checked = true;
            MenuOptionsValidationNewDefaults.CheckOnClick = true;
            MenuOptionsValidationNewDefaults.CheckState = CheckState.Checked;
            MenuOptionsValidationNewDefaults.ForeColor = SystemColors.Control;
            MenuOptionsValidationNewDefaults.Name = "MenuOptionsValidationNewDefaults";
            MenuOptionsValidationNewDefaults.Size = new Size(361, 22);
            MenuOptionsValidationNewDefaults.Text = "Set values to new defaults when changing display type";
            MenuOptionsValidationNewDefaults.Click += MenuOptionsValidationNewDefaults_Click;
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
            MenuHelp.DropDownItems.AddRange(new ToolStripItem[] { MenuHelpWhatIsAParamDef, MenuHelpAddingNewFields, MenuHelpSelectingDifferentDefs, MenuHelpAddingNewDefSets, MenuHelpIhadACrash });
            MenuHelp.ForeColor = SystemColors.Control;
            MenuHelp.Name = "MenuHelp";
            MenuHelp.Size = new Size(44, 23);
            MenuHelp.Text = "Help";
            // 
            // MenuHelpWhatIsAParamDef
            // 
            MenuHelpWhatIsAParamDef.BackColor = Color.FromArgb(55, 55, 55);
            MenuHelpWhatIsAParamDef.ForeColor = SystemColors.Control;
            MenuHelpWhatIsAParamDef.Name = "MenuHelpWhatIsAParamDef";
            MenuHelpWhatIsAParamDef.Size = new Size(195, 22);
            MenuHelpWhatIsAParamDef.Text = "What is a param def?";
            // 
            // MenuHelpAddingNewFields
            // 
            MenuHelpAddingNewFields.BackColor = Color.FromArgb(55, 55, 55);
            MenuHelpAddingNewFields.ForeColor = SystemColors.Control;
            MenuHelpAddingNewFields.Name = "MenuHelpAddingNewFields";
            MenuHelpAddingNewFields.Size = new Size(195, 22);
            MenuHelpAddingNewFields.Text = "Adding new fields";
            // 
            // MenuHelpSelectingDifferentDefs
            // 
            MenuHelpSelectingDifferentDefs.BackColor = Color.FromArgb(55, 55, 55);
            MenuHelpSelectingDifferentDefs.ForeColor = SystemColors.Control;
            MenuHelpSelectingDifferentDefs.Name = "MenuHelpSelectingDifferentDefs";
            MenuHelpSelectingDifferentDefs.Size = new Size(195, 22);
            MenuHelpSelectingDifferentDefs.Text = "Selecting different defs";
            // 
            // MenuHelpAddingNewDefSets
            // 
            MenuHelpAddingNewDefSets.BackColor = Color.FromArgb(55, 55, 55);
            MenuHelpAddingNewDefSets.ForeColor = SystemColors.Control;
            MenuHelpAddingNewDefSets.Name = "MenuHelpAddingNewDefSets";
            MenuHelpAddingNewDefSets.Size = new Size(195, 22);
            MenuHelpAddingNewDefSets.Text = "Adding new def sets";
            // 
            // MenuHelpIhadACrash
            // 
            MenuHelpIhadACrash.BackColor = Color.FromArgb(55, 55, 55);
            MenuHelpIhadACrash.ForeColor = SystemColors.Control;
            MenuHelpIhadACrash.Name = "MenuHelpIhadACrash";
            MenuHelpIhadACrash.Size = new Size(195, 22);
            MenuHelpIhadACrash.Text = "I had a crash!";
            // 
            // DefEditorFormStatusStrip
            // 
            DefEditorFormStatusStrip.BackColor = Color.FromArgb(60, 60, 60);
            DefEditorFormStatusStrip.Items.AddRange(new ToolStripItem[] { DefEditorFormStatusLabel });
            DefEditorFormStatusStrip.Location = new Point(0, 428);
            DefEditorFormStatusStrip.Name = "DefEditorFormStatusStrip";
            DefEditorFormStatusStrip.Size = new Size(1076, 22);
            DefEditorFormStatusStrip.TabIndex = 2;
            // 
            // DefEditorFormStatusLabel
            // 
            DefEditorFormStatusLabel.Name = "DefEditorFormStatusLabel";
            DefEditorFormStatusLabel.Size = new Size(0, 17);
            DefEditorFormStatusLabel.ToolTipText = "This will keep you updated on what the program is doing";
            // 
            // DefEditorFormSplitContainerA
            // 
            DefEditorFormSplitContainerA.AllowDrop = true;
            DefEditorFormSplitContainerA.Dock = DockStyle.Fill;
            DefEditorFormSplitContainerA.Location = new Point(0, 27);
            DefEditorFormSplitContainerA.Name = "DefEditorFormSplitContainerA";
            // 
            // DefEditorFormSplitContainerA.Panel1
            // 
            DefEditorFormSplitContainerA.Panel1.Controls.Add(DefDataGridView);
            // 
            // DefEditorFormSplitContainerA.Panel2
            // 
            DefEditorFormSplitContainerA.Panel2.Controls.Add(FieldDataGridView);
            DefEditorFormSplitContainerA.Size = new Size(1076, 401);
            DefEditorFormSplitContainerA.SplitterDistance = 398;
            DefEditorFormSplitContainerA.TabIndex = 3;
            DefEditorFormSplitContainerA.DragDrop += DefEditorFormSplitContainerA_DragDrop;
            DefEditorFormSplitContainerA.DragEnter += DefEditorFormSplitContainerA_DragEnter;
            // 
            // DefDataGridView
            // 
            DefDataGridView.AllowUserToAddRows = false;
            DefDataGridView.AllowUserToDeleteRows = false;
            DefDataGridView.AllowUserToOrderColumns = true;
            DefDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DefDataGridView.BackgroundColor = Color.FromArgb(45, 45, 45);
            DefDataGridView.BorderStyle = BorderStyle.None;
            DefDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DefDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DefDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DefDataGridView.Columns.AddRange(new DataGridViewColumn[] { paramdeffilename, paramdeftype, paramdefformatversion, paramdefdataversion, paramdefgame });
            DefDataGridView.ContextMenuStrip = DefContextMenu;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(55, 55, 55);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 75, 75);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DefDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            DefDataGridView.Dock = DockStyle.Fill;
            DefDataGridView.EnableHeadersVisualStyles = false;
            DefDataGridView.GridColor = Color.FromArgb(45, 45, 45);
            DefDataGridView.Location = new Point(0, 0);
            DefDataGridView.Name = "DefDataGridView";
            DefDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DefDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DefDataGridView.RowTemplate.Height = 25;
            DefDataGridView.Size = new Size(398, 401);
            DefDataGridView.TabIndex = 1;
            DefDataGridView.SelectionChanged += DefDataGridView_SelectionChanged;
            // 
            // paramdeffilename
            // 
            paramdeffilename.FillWeight = 80F;
            paramdeffilename.HeaderText = "Name";
            paramdeffilename.Name = "paramdeffilename";
            paramdeffilename.ReadOnly = true;
            // 
            // paramdeftype
            // 
            paramdeftype.FillWeight = 134.010162F;
            paramdeftype.HeaderText = "Type";
            paramdeftype.Name = "paramdeftype";
            // 
            // paramdefformatversion
            // 
            paramdefformatversion.HeaderText = "Format Version";
            paramdefformatversion.Name = "paramdefformatversion";
            paramdefformatversion.Visible = false;
            // 
            // paramdefdataversion
            // 
            paramdefdataversion.HeaderText = "Data Version";
            paramdefdataversion.Name = "paramdefdataversion";
            paramdefdataversion.Visible = false;
            // 
            // paramdefgame
            // 
            paramdefgame.HeaderText = "Game";
            paramdefgame.Name = "paramdefgame";
            paramdefgame.ReadOnly = true;
            paramdefgame.Visible = false;
            // 
            // DefContextMenu
            // 
            DefContextMenu.Items.AddRange(new ToolStripItem[] { DefView });
            DefContextMenu.Name = "ParamDataGridViewContextMenu";
            DefContextMenu.Size = new Size(181, 48);
            // 
            // DefView
            // 
            DefView.BackColor = Color.FromArgb(65, 65, 65);
            DefView.DropDownItems.AddRange(new ToolStripItem[] { DefViewName, DefViewType, DefViewFormatVersion, DefViewDataVersion, DefViewGame });
            DefView.ForeColor = SystemColors.Control;
            DefView.Name = "DefView";
            DefView.Size = new Size(180, 22);
            DefView.Text = "View";
            // 
            // DefViewName
            // 
            DefViewName.BackColor = Color.FromArgb(65, 65, 65);
            DefViewName.Checked = true;
            DefViewName.CheckOnClick = true;
            DefViewName.CheckState = CheckState.Checked;
            DefViewName.ForeColor = SystemColors.Control;
            DefViewName.Name = "DefViewName";
            DefViewName.Size = new Size(180, 22);
            DefViewName.Text = "Name";
            DefViewName.Click += DefViewName_Click;
            // 
            // DefViewType
            // 
            DefViewType.BackColor = Color.FromArgb(65, 65, 65);
            DefViewType.Checked = true;
            DefViewType.CheckOnClick = true;
            DefViewType.CheckState = CheckState.Checked;
            DefViewType.ForeColor = SystemColors.Control;
            DefViewType.Name = "DefViewType";
            DefViewType.Size = new Size(180, 22);
            DefViewType.Text = "Type";
            DefViewType.Click += DefViewType_Click;
            // 
            // DefViewGame
            // 
            DefViewGame.BackColor = Color.FromArgb(65, 65, 65);
            DefViewGame.CheckOnClick = true;
            DefViewGame.ForeColor = SystemColors.Control;
            DefViewGame.Name = "DefViewGame";
            DefViewGame.Size = new Size(180, 22);
            DefViewGame.Text = "Game";
            DefViewGame.Click += DefViewGame_Click;
            // 
            // FieldDataGridView
            // 
            FieldDataGridView.AllowUserToAddRows = false;
            FieldDataGridView.AllowUserToDeleteRows = false;
            FieldDataGridView.AllowUserToOrderColumns = true;
            FieldDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            FieldDataGridView.BackgroundColor = Color.FromArgb(45, 45, 45);
            FieldDataGridView.BorderStyle = BorderStyle.None;
            FieldDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            FieldDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            FieldDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FieldDataGridView.Columns.AddRange(new DataGridViewColumn[] { paramdeffielddisplaytype, paramdeffieldinternaltype, paramdeffielddisplayname, paramdeffieldinternalname, paramdeffielddescription, paramdeffielddisplayformat, paramdeffielddefault, paramdeffieldincrement, paramdeffieldmaximum, paramdeffieldminimum, paramdeffieldsortid, paramdeffieldarraylength, paramdeffieldbitsize });
            FieldDataGridView.ContextMenuStrip = FieldContextMenu;
            FieldDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            FieldDataGridView.Dock = DockStyle.Fill;
            FieldDataGridView.EnableHeadersVisualStyles = false;
            FieldDataGridView.GridColor = Color.FromArgb(45, 45, 45);
            FieldDataGridView.Location = new Point(0, 0);
            FieldDataGridView.Name = "FieldDataGridView";
            FieldDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            FieldDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            FieldDataGridView.RowTemplate.Height = 25;
            FieldDataGridView.Size = new Size(674, 401);
            FieldDataGridView.TabIndex = 1;
            FieldDataGridView.CellValueChanged += FieldDataGridView_CellValueChanged;
            FieldDataGridView.SelectionChanged += FieldDataGridView_SelectionChanged;
            // 
            // paramdeffielddisplaytype
            // 
            paramdeffielddisplaytype.FillWeight = 60F;
            paramdeffielddisplaytype.HeaderText = "Display Type";
            paramdeffielddisplaytype.Name = "paramdeffielddisplaytype";
            paramdeffielddisplaytype.Resizable = DataGridViewTriState.True;
            // 
            // paramdeffieldinternaltype
            // 
            paramdeffieldinternaltype.HeaderText = "Internal Type";
            paramdeffieldinternaltype.Name = "paramdeffieldinternaltype";
            // 
            // paramdeffielddisplayname
            // 
            paramdeffielddisplayname.FillWeight = 70F;
            paramdeffielddisplayname.HeaderText = "Display Name";
            paramdeffielddisplayname.Name = "paramdeffielddisplayname";
            // 
            // paramdeffieldinternalname
            // 
            paramdeffieldinternalname.FillWeight = 75F;
            paramdeffieldinternalname.HeaderText = "Internal Name";
            paramdeffieldinternalname.Name = "paramdeffieldinternalname";
            // 
            // paramdeffielddescription
            // 
            paramdeffielddescription.FillWeight = 130F;
            paramdeffielddescription.HeaderText = "Description";
            paramdeffielddescription.Name = "paramdeffielddescription";
            paramdeffielddescription.Visible = false;
            // 
            // paramdeffielddisplayformat
            // 
            paramdeffielddisplayformat.HeaderText = "Display Format";
            paramdeffielddisplayformat.Name = "paramdeffielddisplayformat";
            paramdeffielddisplayformat.Visible = false;
            // 
            // paramdeffielddefault
            // 
            paramdeffielddefault.HeaderText = "Default Value";
            paramdeffielddefault.Name = "paramdeffielddefault";
            paramdeffielddefault.Visible = false;
            // 
            // paramdeffieldincrement
            // 
            paramdeffieldincrement.HeaderText = "Increment Amount";
            paramdeffieldincrement.Name = "paramdeffieldincrement";
            paramdeffieldincrement.Visible = false;
            // 
            // paramdeffieldmaximum
            // 
            paramdeffieldmaximum.HeaderText = "Maxmium Value";
            paramdeffieldmaximum.Name = "paramdeffieldmaximum";
            paramdeffieldmaximum.Visible = false;
            // 
            // paramdeffieldminimum
            // 
            paramdeffieldminimum.HeaderText = "Minimum Value";
            paramdeffieldminimum.Name = "paramdeffieldminimum";
            paramdeffieldminimum.Visible = false;
            // 
            // paramdeffieldsortid
            // 
            paramdeffieldsortid.HeaderText = "Sort ID";
            paramdeffieldsortid.Name = "paramdeffieldsortid";
            paramdeffieldsortid.Visible = false;
            // 
            // paramdeffieldarraylength
            // 
            paramdeffieldarraylength.HeaderText = "Array Length";
            paramdeffieldarraylength.Name = "paramdeffieldarraylength";
            paramdeffieldarraylength.Visible = false;
            // 
            // paramdeffieldbitsize
            // 
            paramdeffieldbitsize.HeaderText = "Bit Size";
            paramdeffieldbitsize.Name = "paramdeffieldbitsize";
            paramdeffieldbitsize.Visible = false;
            // 
            // FieldContextMenu
            // 
            FieldContextMenu.Items.AddRange(new ToolStripItem[] { FieldView, FieldNew, FieldDelete, FieldCopy, FieldPaste, FieldDuplicate });
            FieldContextMenu.Name = "ParamDataGridViewContextMenu";
            FieldContextMenu.Size = new Size(125, 136);
            // 
            // FieldView
            // 
            FieldView.BackColor = Color.FromArgb(65, 65, 65);
            FieldView.DropDownItems.AddRange(new ToolStripItem[] { FieldViewDisplayType, FieldViewInternalType, FieldViewDisplayName, FieldViewInternalName, FieldViewDescription, FieldViewDisplayFormat, FieldViewDefault, FieldViewIncrement, FieldViewMinimum, FieldViewMaximum, FieldViewSortID, FieldViewArrayLength, FieldViewBitSize });
            FieldView.ForeColor = SystemColors.Control;
            FieldView.Name = "FieldView";
            FieldView.Size = new Size(124, 22);
            FieldView.Text = "View";
            // 
            // FieldViewDisplayType
            // 
            FieldViewDisplayType.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewDisplayType.Checked = true;
            FieldViewDisplayType.CheckOnClick = true;
            FieldViewDisplayType.CheckState = CheckState.Checked;
            FieldViewDisplayType.ForeColor = SystemColors.Control;
            FieldViewDisplayType.Name = "FieldViewDisplayType";
            FieldViewDisplayType.Size = new Size(175, 22);
            FieldViewDisplayType.Text = "Display Type";
            FieldViewDisplayType.Click += FieldViewDisplayType_Click;
            // 
            // FieldViewInternalType
            // 
            FieldViewInternalType.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewInternalType.Checked = true;
            FieldViewInternalType.CheckOnClick = true;
            FieldViewInternalType.CheckState = CheckState.Checked;
            FieldViewInternalType.ForeColor = SystemColors.Control;
            FieldViewInternalType.Name = "FieldViewInternalType";
            FieldViewInternalType.Size = new Size(175, 22);
            FieldViewInternalType.Text = "Internal Type";
            FieldViewInternalType.Click += FieldViewInternalType_Click;
            // 
            // FieldViewDisplayName
            // 
            FieldViewDisplayName.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewDisplayName.Checked = true;
            FieldViewDisplayName.CheckOnClick = true;
            FieldViewDisplayName.CheckState = CheckState.Checked;
            FieldViewDisplayName.ForeColor = SystemColors.Control;
            FieldViewDisplayName.Name = "FieldViewDisplayName";
            FieldViewDisplayName.Size = new Size(175, 22);
            FieldViewDisplayName.Text = "Display Name";
            FieldViewDisplayName.Click += FieldViewDisplayName_Click;
            // 
            // FieldViewInternalName
            // 
            FieldViewInternalName.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewInternalName.Checked = true;
            FieldViewInternalName.CheckOnClick = true;
            FieldViewInternalName.CheckState = CheckState.Checked;
            FieldViewInternalName.ForeColor = SystemColors.Control;
            FieldViewInternalName.Name = "FieldViewInternalName";
            FieldViewInternalName.Size = new Size(175, 22);
            FieldViewInternalName.Text = "Internal Name";
            FieldViewInternalName.Click += FieldViewInternalName_Click;
            // 
            // FieldViewDescription
            // 
            FieldViewDescription.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewDescription.CheckOnClick = true;
            FieldViewDescription.ForeColor = SystemColors.Control;
            FieldViewDescription.Name = "FieldViewDescription";
            FieldViewDescription.Size = new Size(175, 22);
            FieldViewDescription.Text = "Description";
            FieldViewDescription.Click += FieldViewDescription_Click;
            // 
            // FieldViewDisplayFormat
            // 
            FieldViewDisplayFormat.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewDisplayFormat.CheckOnClick = true;
            FieldViewDisplayFormat.ForeColor = SystemColors.Control;
            FieldViewDisplayFormat.Name = "FieldViewDisplayFormat";
            FieldViewDisplayFormat.Size = new Size(175, 22);
            FieldViewDisplayFormat.Text = "Display Format";
            FieldViewDisplayFormat.Click += FieldViewDisplayFormat_Click;
            // 
            // FieldViewDefault
            // 
            FieldViewDefault.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewDefault.CheckOnClick = true;
            FieldViewDefault.ForeColor = SystemColors.Control;
            FieldViewDefault.Name = "FieldViewDefault";
            FieldViewDefault.Size = new Size(175, 22);
            FieldViewDefault.Text = "Default Value";
            FieldViewDefault.Click += FieldViewDefault_Click;
            // 
            // FieldViewIncrement
            // 
            FieldViewIncrement.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewIncrement.CheckOnClick = true;
            FieldViewIncrement.ForeColor = SystemColors.Control;
            FieldViewIncrement.Name = "FieldViewIncrement";
            FieldViewIncrement.Size = new Size(175, 22);
            FieldViewIncrement.Text = "Increment Amount";
            FieldViewIncrement.Click += FieldViewIncrement_Click;
            // 
            // FieldViewMinimum
            // 
            FieldViewMinimum.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewMinimum.CheckOnClick = true;
            FieldViewMinimum.ForeColor = SystemColors.Control;
            FieldViewMinimum.Name = "FieldViewMinimum";
            FieldViewMinimum.Size = new Size(175, 22);
            FieldViewMinimum.Text = "Minimum Value";
            FieldViewMinimum.Click += FieldViewMinimum_Click;
            // 
            // FieldViewMaximum
            // 
            FieldViewMaximum.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewMaximum.CheckOnClick = true;
            FieldViewMaximum.ForeColor = SystemColors.Control;
            FieldViewMaximum.Name = "FieldViewMaximum";
            FieldViewMaximum.Size = new Size(175, 22);
            FieldViewMaximum.Text = "Maximum Value";
            FieldViewMaximum.Click += FieldViewMaximum_Click;
            // 
            // FieldViewSortID
            // 
            FieldViewSortID.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewSortID.CheckOnClick = true;
            FieldViewSortID.ForeColor = SystemColors.Control;
            FieldViewSortID.Name = "FieldViewSortID";
            FieldViewSortID.Size = new Size(175, 22);
            FieldViewSortID.Text = "Sort ID";
            FieldViewSortID.Click += FieldViewSortID_Click;
            // 
            // FieldViewArrayLength
            // 
            FieldViewArrayLength.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewArrayLength.CheckOnClick = true;
            FieldViewArrayLength.ForeColor = SystemColors.Control;
            FieldViewArrayLength.Name = "FieldViewArrayLength";
            FieldViewArrayLength.Size = new Size(175, 22);
            FieldViewArrayLength.Text = "Array Length";
            FieldViewArrayLength.Click += FieldViewArrayLength_Click;
            // 
            // FieldViewBitSize
            // 
            FieldViewBitSize.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewBitSize.CheckOnClick = true;
            FieldViewBitSize.ForeColor = SystemColors.Control;
            FieldViewBitSize.Name = "FieldViewBitSize";
            FieldViewBitSize.Size = new Size(175, 22);
            FieldViewBitSize.Text = "Bit Size";
            FieldViewBitSize.Click += FieldViewBitSize_Click;
            // 
            // FieldNew
            // 
            FieldNew.BackColor = Color.FromArgb(65, 65, 65);
            FieldNew.ForeColor = SystemColors.Control;
            FieldNew.Name = "FieldNew";
            FieldNew.Size = new Size(124, 22);
            FieldNew.Text = "New";
            FieldNew.ToolTipText = "Add a new field";
            // 
            // FieldDelete
            // 
            FieldDelete.BackColor = Color.FromArgb(65, 65, 65);
            FieldDelete.ForeColor = SystemColors.Control;
            FieldDelete.Name = "FieldDelete";
            FieldDelete.Size = new Size(124, 22);
            FieldDelete.Text = "Delete";
            FieldDelete.ToolTipText = "Delete the selected fields";
            // 
            // FieldCopy
            // 
            FieldCopy.BackColor = Color.FromArgb(65, 65, 65);
            FieldCopy.ForeColor = SystemColors.Control;
            FieldCopy.Name = "FieldCopy";
            FieldCopy.Size = new Size(124, 22);
            FieldCopy.Text = "Copy";
            FieldCopy.ToolTipText = "Copy the currently selected fields";
            // 
            // FieldPaste
            // 
            FieldPaste.BackColor = Color.FromArgb(65, 65, 65);
            FieldPaste.ForeColor = SystemColors.Control;
            FieldPaste.Name = "FieldPaste";
            FieldPaste.Size = new Size(124, 22);
            FieldPaste.Text = "Paste";
            FieldPaste.ToolTipText = "Paste copied fields";
            // 
            // FieldDuplicate
            // 
            FieldDuplicate.BackColor = Color.FromArgb(65, 65, 65);
            FieldDuplicate.ForeColor = SystemColors.Control;
            FieldDuplicate.Name = "FieldDuplicate";
            FieldDuplicate.Size = new Size(124, 22);
            FieldDuplicate.Text = "Duplicate";
            FieldDuplicate.ToolTipText = "Duplicate the selected fields";
            // 
            // DefViewFormatVersion
            // 
            DefViewFormatVersion.BackColor = Color.FromArgb(65, 65, 65);
            DefViewFormatVersion.CheckOnClick = true;
            DefViewFormatVersion.ForeColor = SystemColors.Control;
            DefViewFormatVersion.Name = "DefViewFormatVersion";
            DefViewFormatVersion.Size = new Size(180, 22);
            DefViewFormatVersion.Text = "Format Version";
            DefViewFormatVersion.Click += DefViewFormatVersion_Click;
            // 
            // DefViewDataVersion
            // 
            DefViewDataVersion.BackColor = Color.FromArgb(65, 65, 65);
            DefViewDataVersion.CheckOnClick = true;
            DefViewDataVersion.ForeColor = SystemColors.Control;
            DefViewDataVersion.Name = "DefViewDataVersion";
            DefViewDataVersion.Size = new Size(180, 22);
            DefViewDataVersion.Text = "Data Version";
            DefViewDataVersion.Click += DefViewDataVersion_Click;
            // 
            // DefEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(1076, 450);
            Controls.Add(DefEditorFormSplitContainerA);
            Controls.Add(DefEditorFormStatusStrip);
            Controls.Add(DefEditorFormMenu);
            ForeColor = SystemColors.Control;
            Name = "DefEditorForm";
            Text = "Armored Core Param Def Editor";
            DefEditorFormMenu.ResumeLayout(false);
            DefEditorFormMenu.PerformLayout();
            DefEditorFormStatusStrip.ResumeLayout(false);
            DefEditorFormStatusStrip.PerformLayout();
            DefEditorFormSplitContainerA.Panel1.ResumeLayout(false);
            DefEditorFormSplitContainerA.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DefEditorFormSplitContainerA).EndInit();
            DefEditorFormSplitContainerA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DefDataGridView).EndInit();
            DefContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FieldDataGridView).EndInit();
            FieldContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip DefEditorFormMenu;
        private ToolStripMenuItem MenuFile;
        private ToolStripMenuItem MenuFileOpen;
        private ToolStripMenuItem MenuFileSave;
        private ToolStripMenuItem MenuFileSaveAll;
        private ToolStripMenuItem MenuFileClose;
        private ToolStripMenuItem MenuFileCloseAll;
        private ToolStripComboBox MenuGameCombobox;
        private ToolStripMenuItem MenuOther;
        private ToolStripMenuItem MenuOtherOpenResourcesFolder;
        private ToolStripMenuItem MenuOtherOpenResourcesDefFolder;
        private ToolStripMenuItem MenuOtherOpenCurrentDefsFolder;
        private ToolStripMenuItem MenuHelp;
        private ToolStripMenuItem MenuHelpWhatIsAParamDef;
        private ToolStripMenuItem MenuHelpAddingNewFields;
        private ToolStripMenuItem MenuHelpWhatIsAParam;
        private ToolStripMenuItem MenuHelpAddingNewRows;
        private ToolStripMenuItem MenuHelpSelectingDifferentDefs;
        private ToolStripMenuItem MenuHelpAddingNewDefSets;
        private ToolStripMenuItem MenuHelpIhadACrash;
        private StatusStrip DefEditorFormStatusStrip;
        private ToolStripStatusLabel DefEditorFormStatusLabel;
        private SplitContainer DefEditorFormSplitContainerA;
        private DataGridView DefDataGridView;
        private DataGridView FieldDataGridView;
        private ContextMenuStrip DefContextMenu;
        private ToolStripMenuItem DefView;
        private ToolStripMenuItem DefViewName;
        private ToolStripMenuItem DefViewType;
        private ToolStripMenuItem RowViewID;
        private ToolStripMenuItem RowViewName;
        private ToolStripMenuItem RowViewNew;
        private ToolStripMenuItem RowDelete;
        private ToolStripMenuItem RowCopy;
        private ToolStripMenuItem RowPaste;
        private ToolStripMenuItem RowDuplicate;
        private ContextMenuStrip FieldContextMenu;
        private ToolStripMenuItem FieldView;
        private ToolStripMenuItem FieldViewDisplayType;
        private ToolStripMenuItem FieldViewDisplayName;
        private ToolStripMenuItem FieldViewInternalName;
        private ToolStripMenuItem FieldViewDescription;
        private ToolStripMenuItem FieldViewDisplayFormat;
        private ToolStripMenuItem FieldViewDefault;
        private ToolStripMenuItem FieldViewIncrement;
        private ToolStripMenuItem FieldViewMinimum;
        private ToolStripMenuItem FieldViewMaximum;
        private ToolStripMenuItem FieldViewSortID;
        private ToolStripMenuItem FieldViewArrayLength;
        private ToolStripMenuItem FieldViewBitSize;
        private ToolStripMenuItem FieldNew;
        private ToolStripMenuItem FieldDelete;
        private ToolStripMenuItem FieldCopy;
        private ToolStripMenuItem FieldPaste;
        private ToolStripMenuItem FieldDuplicate;
        private ToolStripMenuItem DefViewGame;
        private ToolStripMenuItem FieldViewInternalType;
        private DataGridViewTextBoxColumn paramdeffielddisplaytype;
        private DataGridViewTextBoxColumn paramdeffieldinternaltype;
        private DataGridViewTextBoxColumn paramdeffielddisplayname;
        private DataGridViewTextBoxColumn paramdeffieldinternalname;
        private DataGridViewTextBoxColumn paramdeffielddescription;
        private DataGridViewTextBoxColumn paramdeffielddisplayformat;
        private DataGridViewTextBoxColumn paramdeffielddefault;
        private DataGridViewTextBoxColumn paramdeffieldincrement;
        private DataGridViewTextBoxColumn paramdeffieldmaximum;
        private DataGridViewTextBoxColumn paramdeffieldminimum;
        private DataGridViewTextBoxColumn paramdeffieldsortid;
        private DataGridViewTextBoxColumn paramdeffieldarraylength;
        private DataGridViewTextBoxColumn paramdeffieldbitsize;
        private ToolStripMenuItem MenuOptions;
        private ToolStripMenuItem MenuOptionsValidation;
        private ToolStripMenuItem MenuOptionsValidationNewDefaults;
        private ToolStripMenuItem MenuExport;
        private ToolStripMenuItem MenuExportXml;
        private ToolStripMenuItem MenuExportParam;
        private ToolStripMenuItem MenuExportDef;
        private ToolStripMenuItem MenuExportTxt;
        private DataGridViewTextBoxColumn paramdeffilename;
        private DataGridViewTextBoxColumn paramdeftype;
        private DataGridViewTextBoxColumn paramdefformatversion;
        private DataGridViewTextBoxColumn paramdefdataversion;
        private DataGridViewTextBoxColumn paramdefgame;
        private ToolStripMenuItem DefViewFormatVersion;
        private ToolStripMenuItem DefViewDataVersion;
    }
}