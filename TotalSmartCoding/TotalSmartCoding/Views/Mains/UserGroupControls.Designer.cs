namespace TotalSmartCoding.Views.Mains
{
    partial class UserGroupControls
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGroupControls));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolUserGroupDetails = new System.Windows.Forms.ToolStrip();
            this.comboUserID = new System.Windows.Forms.ToolStripComboBox();
            this.comboOrganizationalUnit = new System.Windows.Forms.ToolStripComboBox();
            this.comboInActive = new System.Windows.Forms.ToolStripComboBox();
            this.buttonUserRegister = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonUserUnregister = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonUserToggleVoid = new System.Windows.Forms.ToolStripButton();
            this.fastUserGroups = new BrightIdeasSoftware.FastObjectListView();
            this.olvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUserGroupType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUserGroupCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUserGroupName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.gridexUserGroupControls = new CustomControls.DataGridexView();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleDetailName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAccess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ReadOnly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Editable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ApprovalPermitted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UnApprovalPermitted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VoidablePermitted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UnVoidablePermitted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.buttonAddUserGroup = new System.Windows.Forms.ToolStripButton();
            this.buttonRemoveUserGroup = new System.Windows.Forms.ToolStripButton();
            this.treeUserID = new BrightIdeasSoftware.DataTreeListView();
            this.olvTreeName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTreeSelected = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTreePrimaryID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTreeAncestorID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTreeCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTreeParameterName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.naviIndex = new Guifreaks.Navisuite.NaviBar(this.components);
            this.navibandUserTrees = new Guifreaks.Navisuite.NaviBand(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.pictureTopleft = new System.Windows.Forms.PictureBox();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.gridexUserGroupDetails = new CustomControls.DataGridexView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolUserGroupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridexUserGroupControls)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeUserID)).BeginInit();
            this.naviIndex.SuspendLayout();
            this.navibandUserTrees.ClientArea.SuspendLayout();
            this.navibandUserTrees.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTopleft)).BeginInit();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridexUserGroupDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolUserGroupDetails
            // 
            this.toolUserGroupDetails.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolUserGroupDetails.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolUserGroupDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboUserID,
            this.comboOrganizationalUnit,
            this.comboInActive,
            this.buttonUserRegister,
            this.toolStripSeparator1,
            this.buttonUserUnregister,
            this.toolStripSeparator2,
            this.buttonUserToggleVoid});
            this.toolUserGroupDetails.Location = new System.Drawing.Point(0, 0);
            this.toolUserGroupDetails.Name = "toolUserGroupDetails";
            this.toolUserGroupDetails.Size = new System.Drawing.Size(983, 55);
            this.toolUserGroupDetails.TabIndex = 0;
            this.toolUserGroupDetails.Text = "toolStrip1";
            // 
            // comboUserID
            // 
            this.comboUserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUserID.Enabled = false;
            this.comboUserID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboUserID.Name = "comboUserID";
            this.comboUserID.Size = new System.Drawing.Size(396, 55);
            this.comboUserID.SelectedIndexChanged += new System.EventHandler(this.comboUserID_SelectedIndexChanged);
            // 
            // comboOrganizationalUnit
            // 
            this.comboOrganizationalUnit.Enabled = false;
            this.comboOrganizationalUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboOrganizationalUnit.Name = "comboOrganizationalUnit";
            this.comboOrganizationalUnit.Size = new System.Drawing.Size(196, 55);
            // 
            // comboInActive
            // 
            this.comboInActive.Enabled = false;
            this.comboInActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboInActive.Name = "comboInActive";
            this.comboInActive.Size = new System.Drawing.Size(88, 55);
            // 
            // buttonUserRegister
            // 
            this.buttonUserRegister.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUserRegister.Image = global::TotalSmartCoding.Properties.Resources.add_user;
            this.buttonUserRegister.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonUserRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUserRegister.Name = "buttonUserRegister";
            this.buttonUserRegister.Size = new System.Drawing.Size(52, 52);
            this.buttonUserRegister.ToolTipText = "Register user for new location";
            this.buttonUserRegister.Click += new System.EventHandler(this.buttonUserRegister_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // buttonUserUnregister
            // 
            this.buttonUserUnregister.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUserUnregister.Image = global::TotalSmartCoding.Properties.Resources.remove_user;
            this.buttonUserUnregister.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonUserUnregister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUserUnregister.Name = "buttonUserUnregister";
            this.buttonUserUnregister.Size = new System.Drawing.Size(52, 52);
            this.buttonUserUnregister.ToolTipText = "Cancel user registration";
            this.buttonUserUnregister.Click += new System.EventHandler(this.buttonUserUnregister_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // buttonUserToggleVoid
            // 
            this.buttonUserToggleVoid.Image = global::TotalSmartCoding.Properties.Resources.no_persons_2;
            this.buttonUserToggleVoid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonUserToggleVoid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUserToggleVoid.Name = "buttonUserToggleVoid";
            this.buttonUserToggleVoid.Size = new System.Drawing.Size(151, 52);
            this.buttonUserToggleVoid.Text = "Set active status";
            this.buttonUserToggleVoid.Click += new System.EventHandler(this.buttonUserToggleVoid_Click);
            // 
            // fastUserGroups
            // 
            this.fastUserGroups.AllColumns.Add(this.olvID);
            this.fastUserGroups.AllColumns.Add(this.olvUserGroupType);
            this.fastUserGroups.AllColumns.Add(this.olvUserGroupCode);
            this.fastUserGroups.AllColumns.Add(this.olvUserGroupName);
            this.fastUserGroups.BackColor = System.Drawing.Color.Ivory;
            this.fastUserGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvID,
            this.olvUserGroupName});
            this.fastUserGroups.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastUserGroups.Dock = System.Windows.Forms.DockStyle.Left;
            this.fastUserGroups.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.fastUserGroups.FullRowSelect = true;
            this.fastUserGroups.GroupImageList = this.imageList32;
            this.fastUserGroups.HideSelection = false;
            this.fastUserGroups.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastUserGroups.Location = new System.Drawing.Point(33, 55);
            this.fastUserGroups.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastUserGroups.Name = "fastUserGroups";
            this.fastUserGroups.OwnerDraw = true;
            this.fastUserGroups.ShowGroups = false;
            this.fastUserGroups.Size = new System.Drawing.Size(225, 594);
            this.fastUserGroups.TabIndex = 69;
            this.fastUserGroups.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastUserGroups.UseCompatibleStateImageBehavior = false;
            this.fastUserGroups.UseFiltering = true;
            this.fastUserGroups.View = System.Windows.Forms.View.Details;
            this.fastUserGroups.VirtualMode = true;
            this.fastUserGroups.SelectedIndexChanged += new System.EventHandler(this.fastUserGroups_SelectedIndexChanged);
            // 
            // olvID
            // 
            this.olvID.Text = "";
            this.olvID.Width = 20;
            // 
            // olvUserGroupType
            // 
            this.olvUserGroupType.AspectName = "UserGroupType";
            this.olvUserGroupType.IsVisible = false;
            // 
            // olvUserGroupCode
            // 
            this.olvUserGroupCode.AspectName = "Code";
            this.olvUserGroupCode.IsVisible = false;
            // 
            // olvUserGroupName
            // 
            this.olvUserGroupName.AspectName = "Name";
            this.olvUserGroupName.FillsFreeSpace = true;
            this.olvUserGroupName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvUserGroupName.Sortable = false;
            this.olvUserGroupName.Text = "";
            this.olvUserGroupName.Width = 90;
            // 
            // imageList32
            // 
            this.imageList32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList32.ImageStream")));
            this.imageList32.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList32.Images.SetKeyName(0, "Forklift");
            this.imageList32.Images.SetKeyName(1, "ForkliftYellow");
            this.imageList32.Images.SetKeyName(2, "ForkliftOrange");
            this.imageList32.Images.SetKeyName(3, "ForkliftJapan");
            this.imageList32.Images.SetKeyName(4, "Placeholder32");
            this.imageList32.Images.SetKeyName(5, "Storage32");
            this.imageList32.Images.SetKeyName(6, "Sales-Order-32");
            this.imageList32.Images.SetKeyName(7, "Sign_Order_32");
            this.imageList32.Images.SetKeyName(8, "Assembly-32");
            // 
            // gridexUserGroupControls
            // 
            this.gridexUserGroupControls.AllowAddRow = false;
            this.gridexUserGroupControls.AllowDeleteRow = false;
            this.gridexUserGroupControls.AllowUserToAddRows = false;
            this.gridexUserGroupControls.AllowUserToDeleteRows = false;
            this.gridexUserGroupControls.BackgroundColor = System.Drawing.Color.Ivory;
            this.gridexUserGroupControls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridexUserGroupControls.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridexUserGroupControls.ColumnHeadersHeight = 24;
            this.gridexUserGroupControls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModuleName,
            this.ModuleDetailName,
            this.LocationName,
            this.NoAccess,
            this.ReadOnly,
            this.Editable,
            this.ApprovalPermitted,
            this.UnApprovalPermitted,
            this.VoidablePermitted,
            this.UnVoidablePermitted});
            this.gridexUserGroupControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridexUserGroupControls.Editable = true;
            this.gridexUserGroupControls.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.gridexUserGroupControls.Location = new System.Drawing.Point(0, 55);
            this.gridexUserGroupControls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridexUserGroupControls.MultiSelect = false;
            this.gridexUserGroupControls.Name = "gridexUserGroupControls";
            this.gridexUserGroupControls.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridexUserGroupControls.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridexUserGroupControls.RowTemplate.Height = 24;
            this.gridexUserGroupControls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridexUserGroupControls.Size = new System.Drawing.Size(983, 291);
            this.gridexUserGroupControls.TabIndex = 70;
            this.gridexUserGroupControls.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridexAccessControls_CellContentClick);
            this.gridexUserGroupControls.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridexUserGroupControls_CellFormatting);
            this.gridexUserGroupControls.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridexUserGroupControls_CellPainting);
            // 
            // ModuleName
            // 
            this.ModuleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ModuleName.DataPropertyName = "ModuleName";
            this.ModuleName.FillWeight = 24F;
            this.ModuleName.HeaderText = "Features.Tasks";
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.ReadOnly = true;
            // 
            // ModuleDetailName
            // 
            this.ModuleDetailName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ModuleDetailName.DataPropertyName = "ModuleDetailName";
            this.ModuleDetailName.FillWeight = 24F;
            this.ModuleDetailName.HeaderText = "Features.Modules";
            this.ModuleDetailName.Name = "ModuleDetailName";
            this.ModuleDetailName.ReadOnly = true;
            // 
            // LocationName
            // 
            this.LocationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LocationName.DataPropertyName = "LocationName";
            this.LocationName.FillWeight = 12F;
            this.LocationName.HeaderText = "Locations";
            this.LocationName.Name = "LocationName";
            this.LocationName.ReadOnly = true;
            // 
            // NoAccess
            // 
            this.NoAccess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NoAccess.DataPropertyName = "NoAccess";
            this.NoAccess.FillWeight = 9F;
            this.NoAccess.HeaderText = "Access Controls.No Access";
            this.NoAccess.Name = "NoAccess";
            // 
            // ReadOnly
            // 
            this.ReadOnly.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReadOnly.DataPropertyName = "ReadOnly";
            this.ReadOnly.FillWeight = 9F;
            this.ReadOnly.HeaderText = "Access Controls.Read Only";
            this.ReadOnly.Name = "ReadOnly";
            // 
            // Editable
            // 
            this.Editable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Editable.DataPropertyName = "Editable";
            this.Editable.FillWeight = 9F;
            this.Editable.HeaderText = "Access Controls.Editable";
            this.Editable.Name = "Editable";
            // 
            // ApprovalPermitted
            // 
            this.ApprovalPermitted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ApprovalPermitted.DataPropertyName = "ApprovalPermitted";
            this.ApprovalPermitted.FillWeight = 9F;
            this.ApprovalPermitted.HeaderText = "Verify Permissions.Verify";
            this.ApprovalPermitted.Name = "ApprovalPermitted";
            // 
            // UnApprovalPermitted
            // 
            this.UnApprovalPermitted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UnApprovalPermitted.DataPropertyName = "UnApprovalPermitted";
            this.UnApprovalPermitted.FillWeight = 9F;
            this.UnApprovalPermitted.HeaderText = "Verify Permissions.Unverify";
            this.UnApprovalPermitted.Name = "UnApprovalPermitted";
            // 
            // VoidablePermitted
            // 
            this.VoidablePermitted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VoidablePermitted.DataPropertyName = "VoidablePermitted";
            this.VoidablePermitted.FillWeight = 9F;
            this.VoidablePermitted.HeaderText = "Void Permissions.Void";
            this.VoidablePermitted.Name = "VoidablePermitted";
            // 
            // UnVoidablePermitted
            // 
            this.UnVoidablePermitted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UnVoidablePermitted.DataPropertyName = "UnVoidablePermitted";
            this.UnVoidablePermitted.FillWeight = 9F;
            this.UnVoidablePermitted.HeaderText = "Void Permissions.Unvoid";
            this.UnVoidablePermitted.Name = "UnVoidablePermitted";
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAddUserGroup,
            this.buttonRemoveUserGroup});
            this.toolStrip2.Location = new System.Drawing.Point(33, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1208, 55);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // buttonAddUserGroup
            // 
            this.buttonAddUserGroup.Image = global::TotalSmartCoding.Properties.Resources.Data_add;
            this.buttonAddUserGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonAddUserGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddUserGroup.Name = "buttonAddUserGroup";
            this.buttonAddUserGroup.Size = new System.Drawing.Size(164, 52);
            this.buttonAddUserGroup.Text = "Add new group";
            this.buttonAddUserGroup.Click += new System.EventHandler(this.buttonAddRemoveUserGroup_Click);
            // 
            // buttonRemoveUserGroup
            // 
            this.buttonRemoveUserGroup.Image = global::TotalSmartCoding.Properties.Resources.RemoveOU;
            this.buttonRemoveUserGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonRemoveUserGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemoveUserGroup.Name = "buttonRemoveUserGroup";
            this.buttonRemoveUserGroup.Size = new System.Drawing.Size(202, 52);
            this.buttonRemoveUserGroup.Text = "Remove selected group";
            this.buttonRemoveUserGroup.Click += new System.EventHandler(this.buttonAddRemoveUserGroup_Click);
            // 
            // treeUserID
            // 
            this.treeUserID.AllColumns.Add(this.olvTreeName);
            this.treeUserID.AllColumns.Add(this.olvTreeSelected);
            this.treeUserID.AllColumns.Add(this.olvTreePrimaryID);
            this.treeUserID.AllColumns.Add(this.olvTreeAncestorID);
            this.treeUserID.AllColumns.Add(this.olvTreeCode);
            this.treeUserID.AllColumns.Add(this.olvTreeParameterName);
            this.treeUserID.BackColor = System.Drawing.Color.Wheat;
            this.treeUserID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvTreeName,
            this.olvTreeSelected});
            this.treeUserID.DataSource = null;
            this.treeUserID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeUserID.FullRowSelect = true;
            this.treeUserID.KeyAspectName = "NodeID";
            this.treeUserID.Location = new System.Drawing.Point(0, 0);
            this.treeUserID.Name = "treeUserID";
            this.treeUserID.OwnerDraw = true;
            this.treeUserID.ParentKeyAspectName = "ParentNodeID";
            this.treeUserID.RootKeyValueString = "";
            this.treeUserID.ShowGroups = false;
            this.treeUserID.ShowKeyColumns = false;
            this.treeUserID.Size = new System.Drawing.Size(1, 1);
            this.treeUserID.TabIndex = 71;
            this.treeUserID.UseCompatibleStateImageBehavior = false;
            this.treeUserID.UseFilterIndicator = true;
            this.treeUserID.UseFiltering = true;
            this.treeUserID.View = System.Windows.Forms.View.Details;
            this.treeUserID.VirtualMode = true;
            // 
            // olvTreeName
            // 
            this.olvTreeName.AspectName = "Name";
            this.olvTreeName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvTreeName.IsEditable = false;
            this.olvTreeName.Sortable = false;
            this.olvTreeName.Text = "All Organizational Units";
            this.olvTreeName.Width = 275;
            // 
            // olvTreeSelected
            // 
            this.olvTreeSelected.AspectName = "Selected";
            this.olvTreeSelected.CheckBoxes = true;
            this.olvTreeSelected.FillsFreeSpace = true;
            this.olvTreeSelected.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvTreeSelected.IsEditable = false;
            this.olvTreeSelected.Sortable = false;
            this.olvTreeSelected.Text = "Inactive";
            this.olvTreeSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvTreeSelected.Width = 79;
            // 
            // olvTreePrimaryID
            // 
            this.olvTreePrimaryID.AspectName = "PrimaryID";
            this.olvTreePrimaryID.IsVisible = false;
            // 
            // olvTreeAncestorID
            // 
            this.olvTreeAncestorID.AspectName = "AncestorID";
            this.olvTreeAncestorID.IsVisible = false;
            // 
            // olvTreeCode
            // 
            this.olvTreeCode.AspectName = "Code";
            this.olvTreeCode.IsVisible = false;
            // 
            // olvTreeParameterName
            // 
            this.olvTreeParameterName.AspectName = "ParameterName";
            this.olvTreeParameterName.IsVisible = false;
            // 
            // naviIndex
            // 
            this.naviIndex.ActiveBand = this.navibandUserTrees;
            this.naviIndex.Collapsed = true;
            this.naviIndex.Controls.Add(this.navibandUserTrees);
            this.naviIndex.Controls.Add(this.button1);
            this.naviIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.naviIndex.HeaderHeight = 42;
            this.naviIndex.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.Office2010Blue;
            this.naviIndex.Location = new System.Drawing.Point(0, 36);
            this.naviIndex.Margin = new System.Windows.Forms.Padding(4);
            this.naviIndex.Name = "naviIndex";
            this.naviIndex.PopupHeight = 554;
            this.naviIndex.PopupMinWidth = 368;
            this.naviIndex.ShowMoreOptionsButton = false;
            this.naviIndex.Size = new System.Drawing.Size(33, 613);
            this.naviIndex.TabIndex = 72;
            // 
            // navibandUserTrees
            // 
            // 
            // navibandUserTrees.ClientArea
            // 
            this.navibandUserTrees.ClientArea.Controls.Add(this.treeUserID);
            this.navibandUserTrees.ClientArea.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner;
            this.navibandUserTrees.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.navibandUserTrees.ClientArea.Margin = new System.Windows.Forms.Padding(0);
            this.navibandUserTrees.ClientArea.Name = "ClientArea";
            this.navibandUserTrees.ClientArea.Size = new System.Drawing.Size(1, 1);
            this.navibandUserTrees.ClientArea.TabIndex = 0;
            this.navibandUserTrees.LargeImageIndex = 0;
            this.navibandUserTrees.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner;
            this.navibandUserTrees.Location = new System.Drawing.Point(1, 42);
            this.navibandUserTrees.Margin = new System.Windows.Forms.Padding(4);
            this.navibandUserTrees.Name = "navibandUserTrees";
            this.navibandUserTrees.Size = new System.Drawing.Size(0, 0);
            this.navibandUserTrees.SmallImageIndex = 0;
            this.navibandUserTrees.TabIndex = 72;
            this.navibandUserTrees.Text = "Click here to expand";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::TotalSmartCoding.Properties.Resources.Man_2;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 43);
            this.button1.TabIndex = 77;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.naviIndex);
            this.panelLeft.Controls.Add(this.pictureTopleft);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(33, 649);
            this.panelLeft.TabIndex = 73;
            // 
            // pictureTopleft
            // 
            this.pictureTopleft.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureTopleft.Image = global::TotalSmartCoding.Properties.Resources.refresh;
            this.pictureTopleft.Location = new System.Drawing.Point(0, 0);
            this.pictureTopleft.Name = "pictureTopleft";
            this.pictureTopleft.Size = new System.Drawing.Size(33, 36);
            this.pictureTopleft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureTopleft.TabIndex = 73;
            this.pictureTopleft.TabStop = false;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.gridexUserGroupDetails);
            this.panelCenter.Controls.Add(this.gridexUserGroupControls);
            this.panelCenter.Controls.Add(this.toolUserGroupDetails);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(258, 55);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(983, 594);
            this.panelCenter.TabIndex = 74;
            // 
            // gridexUserGroupDetails
            // 
            this.gridexUserGroupDetails.AllowAddRow = false;
            this.gridexUserGroupDetails.AllowDeleteRow = false;
            this.gridexUserGroupDetails.AllowUserToAddRows = false;
            this.gridexUserGroupDetails.AllowUserToDeleteRows = false;
            this.gridexUserGroupDetails.BackgroundColor = System.Drawing.Color.Ivory;
            this.gridexUserGroupDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridexUserGroupDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridexUserGroupDetails.ColumnHeadersHeight = 24;
            this.gridexUserGroupDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.gridexUserGroupDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridexUserGroupDetails.Editable = true;
            this.gridexUserGroupDetails.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.gridexUserGroupDetails.Location = new System.Drawing.Point(0, 346);
            this.gridexUserGroupDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridexUserGroupDetails.MultiSelect = false;
            this.gridexUserGroupDetails.Name = "gridexUserGroupDetails";
            this.gridexUserGroupDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridexUserGroupDetails.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridexUserGroupDetails.RowTemplate.Height = 24;
            this.gridexUserGroupDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridexUserGroupDetails.Size = new System.Drawing.Size(983, 248);
            this.gridexUserGroupDetails.TabIndex = 71;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "UserName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // UserGroupControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 649);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.fastUserGroups);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panelLeft);
            this.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserGroupControls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User References [Determine the tasks each user can perform]";
            this.Load += new System.EventHandler(this.UserGroupControls_Load);
            this.toolUserGroupDetails.ResumeLayout(false);
            this.toolUserGroupDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridexUserGroupControls)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeUserID)).EndInit();
            this.naviIndex.ResumeLayout(false);
            this.navibandUserTrees.ClientArea.ResumeLayout(false);
            this.navibandUserTrees.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureTopleft)).EndInit();
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridexUserGroupDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolUserGroupDetails;
        private System.Windows.Forms.ToolStripComboBox comboUserID;
        private System.Windows.Forms.ToolStripButton buttonUserRegister;
        private System.Windows.Forms.ToolStripButton buttonUserUnregister;
        private BrightIdeasSoftware.FastObjectListView fastUserGroups;
        private BrightIdeasSoftware.OLVColumn olvID;
        private BrightIdeasSoftware.OLVColumn olvUserGroupName;
        private CustomControls.DataGridexView gridexUserGroupControls;
        private System.Windows.Forms.ImageList imageList32;
        private BrightIdeasSoftware.OLVColumn olvUserGroupCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private BrightIdeasSoftware.DataTreeListView treeUserID;
        private BrightIdeasSoftware.OLVColumn olvTreeName;
        private BrightIdeasSoftware.OLVColumn olvTreeSelected;
        private BrightIdeasSoftware.OLVColumn olvTreePrimaryID;
        private BrightIdeasSoftware.OLVColumn olvTreeAncestorID;
        private BrightIdeasSoftware.OLVColumn olvTreeCode;
        private BrightIdeasSoftware.OLVColumn olvTreeParameterName;
        private Guifreaks.Navisuite.NaviBar naviIndex;
        private Guifreaks.Navisuite.NaviBand navibandUserTrees;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripComboBox comboOrganizationalUnit;
        private System.Windows.Forms.ToolStripButton buttonAddUserGroup;
        private System.Windows.Forms.ToolStripComboBox comboInActive;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox pictureTopleft;
        private System.Windows.Forms.ToolStripButton buttonRemoveUserGroup;
        private System.Windows.Forms.ToolStripButton buttonUserToggleVoid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private BrightIdeasSoftware.OLVColumn olvUserGroupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleDetailName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NoAccess;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ReadOnly;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Editable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ApprovalPermitted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UnApprovalPermitted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VoidablePermitted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UnVoidablePermitted;
        private System.Windows.Forms.Panel panelCenter;
        private CustomControls.DataGridexView gridexUserGroupDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}