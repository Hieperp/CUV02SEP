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
            this.olvGroupType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUserGroupName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolUserSalespersons = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.fastUserSalespersons = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUserGroupCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolUserGroupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserControlIndexes)).BeginInit();
            this.toolUserGroups.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserGroupDetails)).BeginInit();
            this.toolUserSalespersons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserSalespersons)).BeginInit();
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
            this.toolUserGroupDetails.Size = new System.Drawing.Size(763, 39);
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
            this.buttonManageGroups.Size = new System.Drawing.Size(126, 36);
            this.buttonManageGroups.Text = "Manage groups";
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
            this.fastUserControlIndexes.Size = new System.Drawing.Size(329, 610);
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
            this.toolUserGroups.Size = new System.Drawing.Size(1092, 39);
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
            this.panelCenter.Controls.Add(this.fastUserSalespersons);
            this.panelCenter.Controls.Add(this.toolUserSalespersons);
            this.panelCenter.Controls.Add(this.fastUserGroupDetails);
            this.panelCenter.Controls.Add(this.toolUserGroupDetails);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(329, 39);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(763, 610);
            this.panelCenter.TabIndex = 74;
            // 
            // fastUserGroupDetails
            // 
            this.fastUserGroupDetails.AllColumns.Add(this.olvColumn1);
            this.fastUserGroupDetails.AllColumns.Add(this.olvGroupType);
            this.fastUserGroupDetails.AllColumns.Add(this.olvUserGroupCode);
            this.fastUserGroupDetails.AllColumns.Add(this.olvUserGroupName);
            this.fastUserGroupDetails.BackColor = System.Drawing.Color.Ivory;
            this.fastUserGroupDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvUserGroupCode,
            this.olvUserGroupName});
            this.fastUserGroupDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastUserGroupDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.fastUserGroupDetails.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.fastUserGroupDetails.FullRowSelect = true;
            this.fastUserGroupDetails.GroupImageList = this.imageList32;
            this.fastUserGroupDetails.HideSelection = false;
            this.fastUserGroupDetails.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastUserGroupDetails.Location = new System.Drawing.Point(0, 39);
            this.fastUserGroupDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastUserGroupDetails.Name = "fastUserGroupDetails";
            this.fastUserGroupDetails.OwnerDraw = true;
            this.fastUserGroupDetails.ShowGroups = false;
            this.fastUserGroupDetails.Size = new System.Drawing.Size(763, 244);
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
            // olvGroupType
            // 
            this.olvGroupType.AspectName = "GroupType";
            this.olvGroupType.IsVisible = false;
            this.olvGroupType.Text = "";
            // 
            // olvUserGroupName
            // 
            this.olvUserGroupName.AspectName = "UserGroupName";
            this.olvUserGroupName.FillsFreeSpace = true;
            this.olvUserGroupName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvUserGroupName.Sortable = false;
            this.olvUserGroupName.Text = "";
            this.olvUserGroupName.Width = 90;
            // 
            // toolUserSalespersons
            // 
            this.toolUserSalespersons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolUserSalespersons.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolUserSalespersons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.toolStripButton2});
            this.toolUserSalespersons.Location = new System.Drawing.Point(0, 283);
            this.toolUserSalespersons.Name = "toolUserSalespersons";
            this.toolUserSalespersons.Size = new System.Drawing.Size(763, 39);
            this.toolUserSalespersons.TabIndex = 103;
            this.toolUserSalespersons.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::TotalSmartCoding.Properties.Resources.Add_UserGroup;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(163, 36);
            this.toolStripButton1.Text = "Add a new salesperson";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::TotalSmartCoding.Properties.Resources.Remove_UserGroup;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(196, 36);
            this.toolStripButton2.Text = "Remove selected salesperson";
            // 
            // fastUserSalespersons
            // 
            this.fastUserSalespersons.AllColumns.Add(this.olvColumn2);
            this.fastUserSalespersons.AllColumns.Add(this.olvGroupType);
            this.fastUserSalespersons.AllColumns.Add(this.olvColumn3);
            this.fastUserSalespersons.BackColor = System.Drawing.Color.Ivory;
            this.fastUserSalespersons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2,
            this.olvColumn3});
            this.fastUserSalespersons.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastUserSalespersons.Dock = System.Windows.Forms.DockStyle.Top;
            this.fastUserSalespersons.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.fastUserSalespersons.FullRowSelect = true;
            this.fastUserSalespersons.GroupImageList = this.imageList32;
            this.fastUserSalespersons.HideSelection = false;
            this.fastUserSalespersons.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastUserSalespersons.Location = new System.Drawing.Point(0, 322);
            this.fastUserSalespersons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastUserSalespersons.Name = "fastUserSalespersons";
            this.fastUserSalespersons.OwnerDraw = true;
            this.fastUserSalespersons.ShowGroups = false;
            this.fastUserSalespersons.Size = new System.Drawing.Size(763, 244);
            this.fastUserSalespersons.TabIndex = 104;
            this.fastUserSalespersons.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastUserSalespersons.UseCompatibleStateImageBehavior = false;
            this.fastUserSalespersons.UseFiltering = true;
            this.fastUserSalespersons.View = System.Windows.Forms.View.Details;
            this.fastUserSalespersons.VirtualMode = true;
            // 
            // olvColumn2
            // 
            this.olvColumn2.Text = "";
            this.olvColumn2.Width = 20;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "UserName";
            this.olvColumn3.FillsFreeSpace = true;
            this.olvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Sortable = false;
            this.olvColumn3.Text = "";
            this.olvColumn3.Width = 90;
            // 
            // olvUserGroupCode
            // 
            this.olvUserGroupCode.AspectName = "UserGroupCode";
            this.olvUserGroupCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvUserGroupCode.Sortable = false;
            this.olvUserGroupCode.Text = "";
            this.olvUserGroupCode.Width = 207;
            // 
            // UserControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 649);
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
            this.toolUserGroups.ResumeLayout(false);
            this.toolUserGroups.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserGroupDetails)).EndInit();
            this.toolUserSalespersons.ResumeLayout(false);
            this.toolUserSalespersons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserSalespersons)).EndInit();
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
        private BrightIdeasSoftware.FastObjectListView fastUserGroupDetails;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvUserGroupName;
        private BrightIdeasSoftware.OLVColumn olvGroupType;
        private System.Windows.Forms.ToolStripButton buttonUserToggleVoid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonManageGroups;
        private BrightIdeasSoftware.FastObjectListView fastUserSalespersons;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.ToolStrip toolUserSalespersons;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private BrightIdeasSoftware.OLVColumn olvUserGroupCode;
    }
}