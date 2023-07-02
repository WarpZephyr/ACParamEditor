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
            MainFormStatusLabel = new ToolStripStatusLabel();
            MainFormSplitContainerB = new SplitContainer();
            DefDataGridView = new DataGridView();
            paramdefname = new DataGridViewTextBoxColumn();
            paramdeftype = new DataGridViewTextBoxColumn();
            paramdefgame = new DataGridViewTextBoxColumn();
            DefContextMenu = new ContextMenuStrip(components);
            RowView = new ToolStripMenuItem();
            DefViewName = new ToolStripMenuItem();
            DefViewType = new ToolStripMenuItem();
            DefViewGame = new ToolStripMenuItem();
            FieldDataGridView = new DataGridView();
            paramdeffieldtype = new DataGridViewTextBoxColumn();
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
            CellView = new ToolStripMenuItem();
            FieldViewType = new ToolStripMenuItem();
            CellViewValue = new ToolStripMenuItem();
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
            DefEditorFormMenu.SuspendLayout();
            DefEditorFormStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainFormSplitContainerB).BeginInit();
            MainFormSplitContainerB.Panel1.SuspendLayout();
            MainFormSplitContainerB.Panel2.SuspendLayout();
            MainFormSplitContainerB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DefDataGridView).BeginInit();
            DefContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FieldDataGridView).BeginInit();
            FieldContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // DefEditorFormMenu
            // 
            DefEditorFormMenu.BackColor = Color.FromArgb(60, 60, 60);
            DefEditorFormMenu.Items.AddRange(new ToolStripItem[] { MenuFile, MenuGameCombobox, MenuOther, MenuHelp });
            DefEditorFormMenu.Location = new Point(0, 0);
            DefEditorFormMenu.Name = "DefEditorFormMenu";
            DefEditorFormMenu.Size = new Size(800, 27);
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
            // 
            // MenuFileSave
            // 
            MenuFileSave.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileSave.ForeColor = SystemColors.Control;
            MenuFileSave.Name = "MenuFileSave";
            MenuFileSave.Size = new Size(120, 22);
            MenuFileSave.Text = "Save";
            MenuFileSave.ToolTipText = "Save the currently selected param defs";
            // 
            // MenuFileSaveAll
            // 
            MenuFileSaveAll.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileSaveAll.ForeColor = SystemColors.Control;
            MenuFileSaveAll.Name = "MenuFileSaveAll";
            MenuFileSaveAll.Size = new Size(120, 22);
            MenuFileSaveAll.Text = "Save All";
            MenuFileSaveAll.ToolTipText = "Save all param defs";
            // 
            // MenuFileClose
            // 
            MenuFileClose.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileClose.ForeColor = SystemColors.Control;
            MenuFileClose.Name = "MenuFileClose";
            MenuFileClose.Size = new Size(120, 22);
            MenuFileClose.Text = "Close";
            MenuFileClose.ToolTipText = "Close the currently selected param defs";
            // 
            // MenuFileCloseAll
            // 
            MenuFileCloseAll.BackColor = Color.FromArgb(55, 55, 55);
            MenuFileCloseAll.ForeColor = SystemColors.Control;
            MenuFileCloseAll.Name = "MenuFileCloseAll";
            MenuFileCloseAll.Size = new Size(120, 22);
            MenuFileCloseAll.Text = "Close All";
            MenuFileCloseAll.ToolTipText = "Close all param defs";
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
            // 
            // MenuOtherOpenResourcesDefFolder
            // 
            MenuOtherOpenResourcesDefFolder.BackColor = Color.FromArgb(55, 55, 55);
            MenuOtherOpenResourcesDefFolder.ForeColor = SystemColors.Control;
            MenuOtherOpenResourcesDefFolder.Name = "MenuOtherOpenResourcesDefFolder";
            MenuOtherOpenResourcesDefFolder.Size = new Size(216, 22);
            MenuOtherOpenResourcesDefFolder.Text = "Open Resources Def Folder";
            // 
            // MenuOtherOpenCurrentDefsFolder
            // 
            MenuOtherOpenCurrentDefsFolder.BackColor = Color.FromArgb(55, 55, 55);
            MenuOtherOpenCurrentDefsFolder.ForeColor = SystemColors.Control;
            MenuOtherOpenCurrentDefsFolder.Name = "MenuOtherOpenCurrentDefsFolder";
            MenuOtherOpenCurrentDefsFolder.Size = new Size(216, 22);
            MenuOtherOpenCurrentDefsFolder.Text = "Open Current Defs Folder";
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
            DefEditorFormStatusStrip.Items.AddRange(new ToolStripItem[] { MainFormStatusLabel });
            DefEditorFormStatusStrip.Location = new Point(0, 428);
            DefEditorFormStatusStrip.Name = "DefEditorFormStatusStrip";
            DefEditorFormStatusStrip.Size = new Size(800, 22);
            DefEditorFormStatusStrip.TabIndex = 2;
            // 
            // MainFormStatusLabel
            // 
            MainFormStatusLabel.Name = "MainFormStatusLabel";
            MainFormStatusLabel.Size = new Size(0, 17);
            MainFormStatusLabel.ToolTipText = "This will keep you updated on what the program is doing";
            // 
            // MainFormSplitContainerB
            // 
            MainFormSplitContainerB.Dock = DockStyle.Fill;
            MainFormSplitContainerB.Location = new Point(0, 27);
            MainFormSplitContainerB.Name = "MainFormSplitContainerB";
            // 
            // MainFormSplitContainerB.Panel1
            // 
            MainFormSplitContainerB.Panel1.Controls.Add(DefDataGridView);
            // 
            // MainFormSplitContainerB.Panel2
            // 
            MainFormSplitContainerB.Panel2.Controls.Add(FieldDataGridView);
            MainFormSplitContainerB.Size = new Size(800, 401);
            MainFormSplitContainerB.SplitterDistance = 382;
            MainFormSplitContainerB.TabIndex = 3;
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
            DefDataGridView.Columns.AddRange(new DataGridViewColumn[] { paramdefname, paramdeftype, paramdefgame });
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
            DefDataGridView.Size = new Size(382, 401);
            DefDataGridView.TabIndex = 1;
            // 
            // paramdefname
            // 
            paramdefname.FillWeight = 65.9898453F;
            paramdefname.HeaderText = "Name";
            paramdefname.Name = "paramdefname";
            // 
            // paramdeftype
            // 
            paramdeftype.FillWeight = 134.010162F;
            paramdeftype.HeaderText = "Type";
            paramdeftype.Name = "paramdeftype";
            // 
            // paramdefgame
            // 
            paramdefgame.HeaderText = "Game";
            paramdefgame.Name = "paramdefgame";
            paramdefgame.Visible = false;
            // 
            // DefContextMenu
            // 
            DefContextMenu.Items.AddRange(new ToolStripItem[] { RowView });
            DefContextMenu.Name = "ParamDataGridViewContextMenu";
            DefContextMenu.Size = new Size(100, 26);
            // 
            // RowView
            // 
            RowView.BackColor = Color.FromArgb(65, 65, 65);
            RowView.DropDownItems.AddRange(new ToolStripItem[] { DefViewName, DefViewType, DefViewGame });
            RowView.ForeColor = SystemColors.Control;
            RowView.Name = "RowView";
            RowView.Size = new Size(99, 22);
            RowView.Text = "View";
            // 
            // DefViewName
            // 
            DefViewName.BackColor = Color.FromArgb(65, 65, 65);
            DefViewName.Checked = true;
            DefViewName.CheckOnClick = true;
            DefViewName.CheckState = CheckState.Checked;
            DefViewName.ForeColor = SystemColors.Control;
            DefViewName.Name = "DefViewName";
            DefViewName.Size = new Size(106, 22);
            DefViewName.Text = "Name";
            // 
            // DefViewType
            // 
            DefViewType.BackColor = Color.FromArgb(65, 65, 65);
            DefViewType.Checked = true;
            DefViewType.CheckOnClick = true;
            DefViewType.CheckState = CheckState.Checked;
            DefViewType.ForeColor = SystemColors.Control;
            DefViewType.Name = "DefViewType";
            DefViewType.Size = new Size(106, 22);
            DefViewType.Text = "Type";
            // 
            // DefViewGame
            // 
            DefViewGame.BackColor = Color.FromArgb(65, 65, 65);
            DefViewGame.Checked = true;
            DefViewGame.CheckOnClick = true;
            DefViewGame.CheckState = CheckState.Checked;
            DefViewGame.ForeColor = SystemColors.Control;
            DefViewGame.Name = "DefViewGame";
            DefViewGame.Size = new Size(106, 22);
            DefViewGame.Text = "Game";
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
            FieldDataGridView.Columns.AddRange(new DataGridViewColumn[] { paramdeffieldtype, paramdeffielddisplayname, paramdeffieldinternalname, paramdeffielddescription, paramdeffielddisplayformat, paramdeffielddefault, paramdeffieldincrement, paramdeffieldmaximum, paramdeffieldminimum, paramdeffieldsortid, paramdeffieldarraylength, paramdeffieldbitsize });
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
            FieldDataGridView.Size = new Size(414, 401);
            FieldDataGridView.TabIndex = 1;
            // 
            // paramdeffieldtype
            // 
            paramdeffieldtype.FillWeight = 40F;
            paramdeffieldtype.HeaderText = "Field Type";
            paramdeffieldtype.Name = "paramdeffieldtype";
            paramdeffieldtype.ReadOnly = true;
            paramdeffieldtype.Resizable = DataGridViewTriState.True;
            // 
            // paramdeffielddisplayname
            // 
            paramdeffielddisplayname.FillWeight = 70F;
            paramdeffielddisplayname.HeaderText = "Display Name";
            paramdeffielddisplayname.Name = "paramdeffielddisplayname";
            paramdeffielddisplayname.ReadOnly = true;
            // 
            // paramdeffieldinternalname
            // 
            paramdeffieldinternalname.FillWeight = 75F;
            paramdeffieldinternalname.HeaderText = "Internal Name";
            paramdeffieldinternalname.Name = "paramdeffieldinternalname";
            paramdeffieldinternalname.ReadOnly = true;
            paramdeffieldinternalname.Visible = false;
            // 
            // paramdeffielddescription
            // 
            paramdeffielddescription.FillWeight = 130F;
            paramdeffielddescription.HeaderText = "Description";
            paramdeffielddescription.Name = "paramdeffielddescription";
            paramdeffielddescription.ReadOnly = true;
            paramdeffielddescription.Visible = false;
            // 
            // paramdeffielddisplayformat
            // 
            paramdeffielddisplayformat.HeaderText = "Display Format";
            paramdeffielddisplayformat.Name = "paramdeffielddisplayformat";
            paramdeffielddisplayformat.ReadOnly = true;
            paramdeffielddisplayformat.Visible = false;
            // 
            // paramdeffielddefault
            // 
            paramdeffielddefault.HeaderText = "Default Value";
            paramdeffielddefault.Name = "paramdeffielddefault";
            paramdeffielddefault.ReadOnly = true;
            paramdeffielddefault.Visible = false;
            // 
            // paramdeffieldincrement
            // 
            paramdeffieldincrement.HeaderText = "Increment Amount";
            paramdeffieldincrement.Name = "paramdeffieldincrement";
            paramdeffieldincrement.ReadOnly = true;
            paramdeffieldincrement.Visible = false;
            // 
            // paramdeffieldmaximum
            // 
            paramdeffieldmaximum.HeaderText = "Maxmium Value";
            paramdeffieldmaximum.Name = "paramdeffieldmaximum";
            paramdeffieldmaximum.ReadOnly = true;
            paramdeffieldmaximum.Visible = false;
            // 
            // paramdeffieldminimum
            // 
            paramdeffieldminimum.HeaderText = "Minimum Value";
            paramdeffieldminimum.Name = "paramdeffieldminimum";
            paramdeffieldminimum.ReadOnly = true;
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
            FieldContextMenu.Items.AddRange(new ToolStripItem[] { CellView, FieldNew, FieldDelete, FieldCopy, FieldPaste, FieldDuplicate });
            FieldContextMenu.Name = "ParamDataGridViewContextMenu";
            FieldContextMenu.Size = new Size(125, 136);
            // 
            // CellView
            // 
            CellView.BackColor = Color.FromArgb(65, 65, 65);
            CellView.DropDownItems.AddRange(new ToolStripItem[] { FieldViewType, CellViewValue, FieldViewDisplayName, FieldViewInternalName, FieldViewDescription, FieldViewDisplayFormat, FieldViewDefault, FieldViewIncrement, FieldViewMinimum, FieldViewMaximum, FieldViewSortID, FieldViewArrayLength, FieldViewBitSize });
            CellView.ForeColor = SystemColors.Control;
            CellView.Name = "CellView";
            CellView.Size = new Size(124, 22);
            CellView.Text = "View";
            // 
            // FieldViewType
            // 
            FieldViewType.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewType.Checked = true;
            FieldViewType.CheckOnClick = true;
            FieldViewType.CheckState = CheckState.Checked;
            FieldViewType.ForeColor = SystemColors.Control;
            FieldViewType.Name = "FieldViewType";
            FieldViewType.Size = new Size(175, 22);
            FieldViewType.Text = "Field Type";
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
            CellViewValue.Text = "Field Value";
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
            // 
            // FieldViewInternalName
            // 
            FieldViewInternalName.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewInternalName.CheckOnClick = true;
            FieldViewInternalName.ForeColor = SystemColors.Control;
            FieldViewInternalName.Name = "FieldViewInternalName";
            FieldViewInternalName.Size = new Size(175, 22);
            FieldViewInternalName.Text = "Internal Name";
            // 
            // FieldViewDescription
            // 
            FieldViewDescription.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewDescription.CheckOnClick = true;
            FieldViewDescription.ForeColor = SystemColors.Control;
            FieldViewDescription.Name = "FieldViewDescription";
            FieldViewDescription.Size = new Size(175, 22);
            FieldViewDescription.Text = "Description";
            // 
            // FieldViewDisplayFormat
            // 
            FieldViewDisplayFormat.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewDisplayFormat.CheckOnClick = true;
            FieldViewDisplayFormat.ForeColor = SystemColors.Control;
            FieldViewDisplayFormat.Name = "FieldViewDisplayFormat";
            FieldViewDisplayFormat.Size = new Size(175, 22);
            FieldViewDisplayFormat.Text = "Display Format";
            // 
            // FieldViewDefault
            // 
            FieldViewDefault.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewDefault.CheckOnClick = true;
            FieldViewDefault.ForeColor = SystemColors.Control;
            FieldViewDefault.Name = "FieldViewDefault";
            FieldViewDefault.Size = new Size(175, 22);
            FieldViewDefault.Text = "Default Value";
            // 
            // FieldViewIncrement
            // 
            FieldViewIncrement.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewIncrement.CheckOnClick = true;
            FieldViewIncrement.ForeColor = SystemColors.Control;
            FieldViewIncrement.Name = "FieldViewIncrement";
            FieldViewIncrement.Size = new Size(175, 22);
            FieldViewIncrement.Text = "Increment Amount";
            // 
            // FieldViewMinimum
            // 
            FieldViewMinimum.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewMinimum.CheckOnClick = true;
            FieldViewMinimum.ForeColor = SystemColors.Control;
            FieldViewMinimum.Name = "FieldViewMinimum";
            FieldViewMinimum.Size = new Size(175, 22);
            FieldViewMinimum.Text = "Minimum Value";
            // 
            // FieldViewMaximum
            // 
            FieldViewMaximum.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewMaximum.CheckOnClick = true;
            FieldViewMaximum.ForeColor = SystemColors.Control;
            FieldViewMaximum.Name = "FieldViewMaximum";
            FieldViewMaximum.Size = new Size(175, 22);
            FieldViewMaximum.Text = "Maximum Value";
            // 
            // FieldViewSortID
            // 
            FieldViewSortID.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewSortID.CheckOnClick = true;
            FieldViewSortID.ForeColor = SystemColors.Control;
            FieldViewSortID.Name = "FieldViewSortID";
            FieldViewSortID.Size = new Size(175, 22);
            FieldViewSortID.Text = "Sort ID";
            // 
            // FieldViewArrayLength
            // 
            FieldViewArrayLength.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewArrayLength.CheckOnClick = true;
            FieldViewArrayLength.ForeColor = SystemColors.Control;
            FieldViewArrayLength.Name = "FieldViewArrayLength";
            FieldViewArrayLength.Size = new Size(175, 22);
            FieldViewArrayLength.Text = "Array Length";
            // 
            // FieldViewBitSize
            // 
            FieldViewBitSize.BackColor = Color.FromArgb(65, 65, 65);
            FieldViewBitSize.CheckOnClick = true;
            FieldViewBitSize.ForeColor = SystemColors.Control;
            FieldViewBitSize.Name = "FieldViewBitSize";
            FieldViewBitSize.Size = new Size(175, 22);
            FieldViewBitSize.Text = "Bit Size";
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
            // DefEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(800, 450);
            Controls.Add(MainFormSplitContainerB);
            Controls.Add(DefEditorFormStatusStrip);
            Controls.Add(DefEditorFormMenu);
            ForeColor = SystemColors.Control;
            Name = "DefEditorForm";
            Text = "Armored Core Param Def Editor";
            DefEditorFormMenu.ResumeLayout(false);
            DefEditorFormMenu.PerformLayout();
            DefEditorFormStatusStrip.ResumeLayout(false);
            DefEditorFormStatusStrip.PerformLayout();
            MainFormSplitContainerB.Panel1.ResumeLayout(false);
            MainFormSplitContainerB.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainFormSplitContainerB).EndInit();
            MainFormSplitContainerB.ResumeLayout(false);
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
        private ToolStripStatusLabel MainFormStatusLabel;
        private SplitContainer MainFormSplitContainerB;
        private DataGridView DefDataGridView;
        private DataGridViewTextBoxColumn paramdefname;
        private DataGridViewTextBoxColumn paramdeftype;
        private DataGridViewTextBoxColumn paramdefgame;
        private DataGridView FieldDataGridView;
        private DataGridViewTextBoxColumn paramdeffieldtype;
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
        private ContextMenuStrip DefContextMenu;
        private ToolStripMenuItem RowView;
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
        private ToolStripMenuItem CellView;
        private ToolStripMenuItem FieldViewType;
        private ToolStripMenuItem CellViewValue;
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
    }
}