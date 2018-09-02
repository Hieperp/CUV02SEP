namespace TotalSmartCoding.Views.Mains
{
    partial class UserControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControls));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolUserGroupDetails = new System.Windows.Forms.ToolStrip();
            this.buttonJoinGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonLeaveGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonManageGroups = new System.Windows.Forms.ToolStripButton();
            this.fastUserControlIndexes = new BrightIdeasSoftware.FastObjectListView();
            this.olvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUserControlType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUserControlName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.gridexUserControls = new CustomControls.DataGridexView();
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
            this.toolUserGroups = new System.Windows.Forms.ToolStrip();
            this.buttonRegisterUser = new System.Windows.Forms.ToolStripButton();
            this.buttonDeregisterUser = new System.Windows.Forms.ToolStripButton();
            this.buttonUserToggleVoid = new System.Windows.Forms.ToolStripButton();
            this.olvTreePrimaryID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTreeAncestorID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTreeCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTreeParameterName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelCenter = new System.Windows.Forms.Panel();
            this.fastUserGroupDetails = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUserType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUserName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolUserGroupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserControlIndexes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridexUserControls)).BeginInit();
            this.toolUserGroups.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserGroupDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolUserGroupDetails
            // 
            this.toolUserGroupDetails.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolUserGroupDetails.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolUserGroupDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonJoinGroup,
            this.toolStripSeparator1,
            this.buttonLeaveGroup,
            this.toolStripSeparator2,
            this.buttonManageGroups});
            this.toolUserGroupDetails.Location = new System.Drawing.Point(0, 0);
            this.toolUserGroupDetails.Name = "toolUserGroupDetails";
            this.toolUserGroupDetails.Size = new System.Drawing.Size(1016, 39);
            this.toolUserGroupDetails.TabIndex = 0;
            this.toolUserGroupDetails.Text = "toolStrip1";
            // 
            // buttonJoinGroup
            // 
            this.buttonJoinGroup.Image = global::TotalSmartCoding.Properties.Resources.Add_UserGroup;
            this.buttonJoinGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonJoinGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonJoinGroup.Name = "buttonJoinGroup";
            this.buttonJoinGroup.Size = new System.Drawing.Size(133, 36);
            this.buttonJoinGroup.Text = "Join a new group";
            this.buttonJoinGroup.Click += new System.EventHandler(this.buttonJoinLeaveGroup_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // buttonLeaveGroup
            // 
            this.buttonLeaveGroup.Image = global::TotalSmartCoding.Properties.Resources.Remove_UserGroup;
            this.buttonLeaveGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonLeaveGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLeaveGroup.Name = "buttonLeaveGroup";
            this.buttonLeaveGroup.Size = new System.Drawing.Size(154, 36);
            this.buttonLeaveGroup.Text = "Leave selected group";
            this.buttonLeaveGroup.Click += new System.EventHandler(this.buttonJoinLeaveGroup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // buttonManageGroups
            // 
            this.buttonManageGroups.Image = global::TotalSmartCoding.Properties.Resources.Manage_group;
            this.buttonManageGroups.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonManageGroups.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonManageGroups.Name = "buttonManageGroups";
            this.buttonManageGroups.Size = new System.Drawing.Size(127, 36);
            this.buttonManageGroups.Text = "Manage Groups";
            // 
            // fastUserControlIndexes
            // 
            this.fastUserControlIndexes.AllColumns.Add(this.olvID);
            this.fastUserControlIndexes.AllColumns.Add(this.olvUserControlType);
            this.fastUserControlIndexes.AllColumns.Add(this.olvUserControlName);
            this.fastUserControlIndexes.BackColor = System.Drawing.Color.Ivory;
            this.fastUserControlIndexes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvID,
            this.olvUserControlName});
            this.fastUserControlIndexes.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastUserControlIndexes.Dock = System.Windows.Forms.DockStyle.Left;
            this.fastUserControlIndexes.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.fastUserControlIndexes.FullRowSelect = true;
            this.fastUserControlIndexes.GroupImageList = this.imageList32;
            this.fastUserControlIndexes.HideSelection = false;
            this.fastUserControlIndexes.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastUserControlIndexes.Location = new System.Drawing.Point(0, 39);
            this.fastUserControlIndexes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastUserControlIndexes.Name = "fastUserControlIndexes";
            this.fastUserControlIndexes.OwnerDraw = true;
            this.fastUserControlIndexes.ShowGroups = false;
            this.fastUserControlIndexes.Size = new System.Drawing.Size(225, 610);
            this.fastUserControlIndexes.TabIndex = 69;
            this.fastUserControlIndexes.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastUserControlIndexes.UseCompatibleStateImageBehavior = false;
            this.fastUserControlIndexes.UseFiltering = true;
            this.fastUserControlIndexes.View = System.Windows.Forms.View.Details;
            this.fastUserControlIndexes.VirtualMode = true;
            this.fastUserControlIndexes.SelectedIndexChanged += new System.EventHandler(this.fastControlGroups_SelectedIndexChanged);
            // 
            // olvID
            // 
            this.olvID.Text = "";
            this.olvID.Width = 20;
            // 
            // olvUserControlType
            // 
            this.olvUserControlType.AspectName = "UserControlType";
            this.olvUserControlType.DisplayIndex = 1;
            this.olvUserControlType.IsVisible = false;
            // 
            // olvUserControlName
            // 
            this.olvUserControlName.AspectName = "UserName";
            this.olvUserControlName.FillsFreeSpace = true;
            this.olvUserControlName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvUserControlName.Sortable = false;
            this.olvUserControlName.Text = "";
            this.olvUserControlName.Width = 90;
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
            this.imageList32.Images.SetKeyName(9, "UserGroupN");
            // 
            // gridexUserControls
            // 
            this.gridexUserControls.AllowAddRow = false;
            this.gridexUserControls.AllowDeleteRow = false;
            this.gridexUserControls.AllowUserToAddRows = false;
            this.gridexUserControls.AllowUserToDeleteRows = false;
            this.gridexUserControls.BackgroundColor = System.Drawing.Color.Ivory;
            this.gridexUserControls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridexUserControls.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridexUserControls.ColumnHeadersHeight = 24;
            this.gridexUserControls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.gridexUserControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridexUserControls.Editable = true;
            this.gridexUserControls.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.gridexUserControls.Location = new System.Drawing.Point(0, 39);
            this.gridexUserControls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridexUserControls.MultiSelect = false;
            this.gridexUserControls.Name = "gridexUserControls";
            this.gridexUserControls.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridexUserControls.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridexUserControls.RowTemplate.Height = 24;
            this.gridexUserControls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridexUserControls.Size = new System.Drawing.Size(1016, 291);
            this.gridexUserControls.TabIndex = 70;
            this.gridexUserControls.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridexAccessControls_CellContentClick);
            this.gridexUserControls.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridexUserControls_CellFormatting);
            this.gridexUserControls.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridexUserControls_CellPainting);
            // 
            // ModuleName
            // 
            this.ModuleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ModuleName.DataPropertyName = "ModuleName";
            this.ModuleName.FillWeight = 19F;
            this.ModuleName.HeaderText = "Features.Tasks";
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.ReadOnly = true;
            // 
            // ModuleDetailName
            // 
            this.ModuleDetailName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ModuleDetailName.DataPropertyName = "ModuleDetailName";
            this.ModuleDetailName.FillWeight = 21F;
            this.ModuleDetailName.HeaderText = "Features.Modules";
            this.ModuleDetailName.Name = "ModuleDetailName";
            this.ModuleDetailName.ReadOnly = true;
            // 
            // LocationName
            // 
            this.LocationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LocationName.DataPropertyName = "LocationName";
            this.LocationName.FillWeight = 11F;
            this.LocationName.HeaderText = "Locations";
            this.LocationName.Name = "LocationName";
            this.LocationName.ReadOnly = true;
            // 
            // NoAccess
            // 
            this.NoAccess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NoAccess.DataPropertyName = "NoAccess";
            this.NoAccess.FillWeight = 7F;
            this.NoAccess.HeaderText = "Access Controls.No Access";
            this.NoAccess.Name = "NoAccess";
            // 
            // ReadOnly
            // 
            this.ReadOnly.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReadOnly.DataPropertyName = "ReadOnly";
            this.ReadOnly.FillWeight = 7F;
            this.ReadOnly.HeaderText = "Access Controls.Read Only";
            this.ReadOnly.Name = "ReadOnly";
            // 
            // Editable
            // 
            this.Editable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Editable.DataPropertyName = "Editable";
            this.Editable.FillWeight = 7F;
            this.Editable.HeaderText = "Access Controls.Editable";
            this.Editable.Name = "Editable";
            // 
            // ApprovalPermitted
            // 
            this.ApprovalPermitted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ApprovalPermitted.DataPropertyName = "ApprovalPermitted";
            this.ApprovalPermitted.FillWeight = 7F;
            this.ApprovalPermitted.HeaderText = "Verify Permissions.Verify";
            this.ApprovalPermitted.Name = "ApprovalPermitted";
            // 
            // UnApprovalPermitted
            // 
            this.UnApprovalPermitted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UnApprovalPermitted.DataPropertyName = "UnApprovalPermitted";
            this.UnApprovalPermitted.FillWeight = 7F;
            this.UnApprovalPermitted.HeaderText = "Verify Permissions.Unverify";
            this.UnApprovalPermitted.Name = "UnApprovalPermitted";
            // 
            // VoidablePermitted
            // 
            this.VoidablePermitted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VoidablePermitted.DataPropertyName = "VoidablePermitted";
            this.VoidablePermitted.FillWeight = 7F;
            this.VoidablePermitted.HeaderText = "Void Permissions.Void";
            this.VoidablePermitted.Name = "VoidablePermitted";
            // 
            // UnVoidablePermitted
            // 
            this.UnVoidablePermitted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UnVoidablePermitted.DataPropertyName = "UnVoidablePermitted";
            this.UnVoidablePermitted.FillWeight = 7F;
            this.UnVoidablePermitted.HeaderText = "Void Permissions.Unvoid";
            this.UnVoidablePermitted.Name = "UnVoidablePermitted";
            // 
            // toolUserGroups
            // 
            this.toolUserGroups.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolUserGroups.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolUserGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRegisterUser,
            this.buttonDeregisterUser,
            this.buttonUserToggleVoid});
            this.toolUserGroups.Location = new System.Drawing.Point(0, 0);
            this.toolUserGroups.Name = "toolUserGroups";
            this.toolUserGroups.Size = new System.Drawing.Size(1241, 39);
            this.toolUserGroups.TabIndex = 0;
            this.toolUserGroups.Text = "toolStrip2";
            // 
            // buttonRegisterUser
            // 
            this.buttonRegisterUser.Image = global::TotalSmartCoding.Properties.Resources.add_user;
            this.buttonRegisterUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonRegisterUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRegisterUser.Name = "buttonRegisterUser";
            this.buttonRegisterUser.Size = new System.Drawing.Size(144, 36);
            this.buttonRegisterUser.Text = "Register a new user";
            this.buttonRegisterUser.Click += new System.EventHandler(this.buttonRegisterDeregisterUser_Click);
            // 
            // buttonDeregisterUser
            // 
            this.buttonDeregisterUser.Image = global::TotalSmartCoding.Properties.Resources.remove_user;
            this.buttonDeregisterUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonDeregisterUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDeregisterUser.Name = "buttonDeregisterUser";
            this.buttonDeregisterUser.Size = new System.Drawing.Size(167, 36);
            this.buttonDeregisterUser.Text = "Deregister selected user";
            this.buttonDeregisterUser.Click += new System.EventHandler(this.buttonRegisterDeregisterUser_Click);
            // 
            // buttonUserToggleVoid
            // 
            this.buttonUserToggleVoid.Image = global::TotalSmartCoding.Properties.Resources.no_persons_2;
            this.buttonUserToggleVoid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonUserToggleVoid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUserToggleVoid.Name = "buttonUserToggleVoid";
            this.buttonUserToggleVoid.Size = new System.Drawing.Size(127, 36);
            this.buttonUserToggleVoid.Text = "Set active status";
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
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.fastUserGroupDetails);
            this.panelCenter.Controls.Add(this.gridexUserControls);
            this.panelCenter.Controls.Add(this.toolUserGroupDetails);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(225, 39);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1016, 610);
            this.panelCenter.TabIndex = 74;
            // 
            // fastUserGroupDetails
            // 
            this.fastUserGroupDetails.AllColumns.Add(this.olvColumn1);
            this.fastUserGroupDetails.AllColumns.Add(this.olvUserType);
            this.fastUserGroupDetails.AllColumns.Add(this.olvUserName);
            this.fastUserGroupDetails.BackColor = System.Drawing.Color.Ivory;
            this.fastUserGroupDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvUserName});
            this.fastUserGroupDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastUserGroupDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastUserGroupDetails.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.fastUserGroupDetails.FullRowSelect = true;
            this.fastUserGroupDetails.GroupImageList = this.imageList32;
            this.fastUserGroupDetails.HideSelection = false;
            this.fastUserGroupDetails.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastUserGroupDetails.Location = new System.Drawing.Point(0, 330);
            this.fastUserGroupDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastUserGroupDetails.Name = "fastUserGroupDetails";
            this.fastUserGroupDetails.OwnerDraw = true;
            this.fastUserGroupDetails.ShowGroups = false;
            this.fastUserGroupDetails.Size = new System.Drawing.Size(1016, 280);
            this.fastUserGroupDetails.TabIndex = 102;
            this.fastUserGroupDetails.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastUserGroupDetails.UseCompatibleStateImageBehavior = false;
            this.fastUserGroupDetails.UseFiltering = true;
            this.fastUserGroupDetails.View = System.Windows.Forms.View.Details;
            this.fastUserGroupDetails.VirtualMode = true;
            // 
            // olvColumn1
            // 
            this.olvColumn1.Text = "";
            this.olvColumn1.Width = 20;
            // 
            // olvUserType
            // 
            this.olvUserType.AspectName = "UserType";
            this.olvUserType.IsVisible = false;
            this.olvUserType.Text = "UserType";
            // 
            // olvUserName
            // 
            this.olvUserName.AspectName = "UserName";
            this.olvUserName.FillsFreeSpace = true;
            this.olvUserName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvUserName.Sortable = false;
            this.olvUserName.Text = "";
            this.olvUserName.Width = 90;
            // 
            // UserControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 649);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.fastUserControlIndexes);
            this.Controls.Add(this.toolUserGroups);
            this.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserControls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Controls";
            this.Load += new System.EventHandler(this.UserControls_Load);
            this.toolUserGroupDetails.ResumeLayout(false);
            this.toolUserGroupDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserControlIndexes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridexUserControls)).EndInit();
            this.toolUserGroups.ResumeLayout(false);
            this.toolUserGroups.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserGroupDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolUserGroupDetails;
        private System.Windows.Forms.ToolStripButton buttonJoinGroup;
        private System.Windows.Forms.ToolStripButton buttonLeaveGroup;
        private BrightIdeasSoftware.FastObjectListView fastUserControlIndexes;
        private BrightIdeasSoftware.OLVColumn olvID;
        private BrightIdeasSoftware.OLVColumn olvUserControlName;
        private CustomControls.DataGridexView gridexUserControls;
        private System.Windows.Forms.ImageList imageList32;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolUserGroups;
        private BrightIdeasSoftware.OLVColumn olvTreePrimaryID;
        private BrightIdeasSoftware.OLVColumn olvTreeAncestorID;
        private BrightIdeasSoftware.OLVColumn olvTreeCode;
        private BrightIdeasSoftware.OLVColumn olvTreeParameterName;
        private System.Windows.Forms.ToolStripButton buttonRegisterUser;
        private System.Windows.Forms.ToolStripButton buttonDeregisterUser;
        private BrightIdeasSoftware.OLVColumn olvUserControlType;
        private System.Windows.Forms.Panel panelCenter;
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
        private BrightIdeasSoftware.FastObjectListView fastUserGroupDetails;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvUserName;
        private BrightIdeasSoftware.OLVColumn olvUserType;
        private System.Windows.Forms.ToolStripButton buttonUserToggleVoid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonManageGroups;
    }
}