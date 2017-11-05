namespace TotalSmartCoding.Views.Mains
{
    partial class UserReferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserReferences));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.comboUserID = new System.Windows.Forms.ToolStripComboBox();
            this.buttonUserAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonUserRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.fastNMVNTasks = new BrightIdeasSoftware.FastObjectListView();
            this.olvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvModuleName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvModuleDetailName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.gridexAccessControls = new CustomControls.DataGridexView();
            this.LocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrganizationalUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoAccess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ReadOnly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Editable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ApprovalPermitted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UnApprovalPermitted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VoidablePermitted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UnVoidablePermitted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelCaption = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastNMVNTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridexAccessControls)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.comboUserID,
            this.buttonUserAdd,
            this.buttonUserRemove,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1422, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TotalSmartCoding.Properties.Resources.Man_2;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 52);
            // 
            // comboUserID
            // 
            this.comboUserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUserID.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.comboUserID.Name = "comboUserID";
            this.comboUserID.Size = new System.Drawing.Size(680, 55);
            // 
            // buttonUserAdd
            // 
            this.buttonUserAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUserAdd.Image = global::TotalSmartCoding.Properties.Resources.Green_cross;
            this.buttonUserAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonUserAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUserAdd.Name = "buttonUserAdd";
            this.buttonUserAdd.Size = new System.Drawing.Size(52, 52);
            this.buttonUserAdd.Text = "toolStripButton1";
            // 
            // buttonUserRemove
            // 
            this.buttonUserRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUserRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonUserRemove.Image")));
            this.buttonUserRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUserRemove.Name = "buttonUserRemove";
            this.buttonUserRemove.Size = new System.Drawing.Size(24, 52);
            this.buttonUserRemove.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 52);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // fastNMVNTasks
            // 
            this.fastNMVNTasks.AllColumns.Add(this.olvID);
            this.fastNMVNTasks.AllColumns.Add(this.olvModuleName);
            this.fastNMVNTasks.AllColumns.Add(this.olvModuleDetailName);
            this.fastNMVNTasks.BackColor = System.Drawing.Color.Ivory;
            this.fastNMVNTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvID,
            this.olvModuleDetailName});
            this.fastNMVNTasks.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastNMVNTasks.Dock = System.Windows.Forms.DockStyle.Left;
            this.fastNMVNTasks.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.fastNMVNTasks.FullRowSelect = true;
            this.fastNMVNTasks.GroupImageList = this.imageList32;
            this.fastNMVNTasks.HideSelection = false;
            this.fastNMVNTasks.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastNMVNTasks.Location = new System.Drawing.Point(0, 86);
            this.fastNMVNTasks.Name = "fastNMVNTasks";
            this.fastNMVNTasks.OwnerDraw = true;
            this.fastNMVNTasks.ShowGroups = false;
            this.fastNMVNTasks.Size = new System.Drawing.Size(304, 677);
            this.fastNMVNTasks.TabIndex = 69;
            this.fastNMVNTasks.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastNMVNTasks.UseCompatibleStateImageBehavior = false;
            this.fastNMVNTasks.UseFiltering = true;
            this.fastNMVNTasks.View = System.Windows.Forms.View.Details;
            this.fastNMVNTasks.VirtualMode = true;
            this.fastNMVNTasks.SelectedIndexChanged += new System.EventHandler(this.fastNMVNTasks_SelectedIndexChanged);
            // 
            // olvID
            // 
            this.olvID.Text = "";
            this.olvID.Width = 20;
            // 
            // olvModuleName
            // 
            this.olvModuleName.AspectName = "ModuleName";
            this.olvModuleName.IsVisible = false;
            // 
            // olvModuleDetailName
            // 
            this.olvModuleDetailName.AspectName = "ModuleDetailName";
            this.olvModuleDetailName.FillsFreeSpace = true;
            this.olvModuleDetailName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvModuleDetailName.Sortable = false;
            this.olvModuleDetailName.Text = "";
            this.olvModuleDetailName.Width = 90;
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
            // 
            // gridexAccessControls
            // 
            this.gridexAccessControls.AllowAddRow = false;
            this.gridexAccessControls.AllowDeleteRow = false;
            this.gridexAccessControls.AllowUserToAddRows = false;
            this.gridexAccessControls.AllowUserToDeleteRows = false;
            this.gridexAccessControls.BackgroundColor = System.Drawing.Color.Ivory;
            this.gridexAccessControls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridexAccessControls.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridexAccessControls.ColumnHeadersHeight = 24;
            this.gridexAccessControls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocationName,
            this.OrganizationalUnitName,
            this.NoAccess,
            this.ReadOnly,
            this.Editable,
            this.ApprovalPermitted,
            this.UnApprovalPermitted,
            this.VoidablePermitted,
            this.UnVoidablePermitted});
            this.gridexAccessControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridexAccessControls.Editable = true;
            this.gridexAccessControls.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.gridexAccessControls.Location = new System.Drawing.Point(304, 86);
            this.gridexAccessControls.Name = "gridexAccessControls";
            this.gridexAccessControls.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridexAccessControls.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridexAccessControls.RowTemplate.Height = 24;
            this.gridexAccessControls.Size = new System.Drawing.Size(1118, 677);
            this.gridexAccessControls.TabIndex = 70;
            this.gridexAccessControls.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridexAccessControls_CellContentClick);
            // 
            // LocationName
            // 
            this.LocationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LocationName.DataPropertyName = "LocationName";
            this.LocationName.FillWeight = 15F;
            this.LocationName.HeaderText = "Organizational Units.Location";
            this.LocationName.Name = "LocationName";
            this.LocationName.ReadOnly = true;
            // 
            // OrganizationalUnitName
            // 
            this.OrganizationalUnitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrganizationalUnitName.DataPropertyName = "OrganizationalUnitName";
            this.OrganizationalUnitName.FillWeight = 22F;
            this.OrganizationalUnitName.HeaderText = "Organizational Units.Division";
            this.OrganizationalUnitName.Name = "OrganizationalUnitName";
            this.OrganizationalUnitName.ReadOnly = true;
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
            // panelCaption
            // 
            this.panelCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption.Location = new System.Drawing.Point(0, 55);
            this.panelCaption.Name = "panelCaption";
            this.panelCaption.Size = new System.Drawing.Size(1422, 31);
            this.panelCaption.TabIndex = 71;
            // 
            // UserReferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 763);
            this.Controls.Add(this.gridexAccessControls);
            this.Controls.Add(this.fastNMVNTasks);
            this.Controls.Add(this.panelCaption);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserReferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User References";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastNMVNTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridexAccessControls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox comboUserID;
        private System.Windows.Forms.ToolStripButton buttonUserAdd;
        private System.Windows.Forms.ToolStripButton buttonUserRemove;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private BrightIdeasSoftware.FastObjectListView fastNMVNTasks;
        private BrightIdeasSoftware.OLVColumn olvID;
        private BrightIdeasSoftware.OLVColumn olvModuleDetailName;
        private CustomControls.DataGridexView gridexAccessControls;
        private System.Windows.Forms.Panel panelCaption;
        private System.Windows.Forms.ImageList imageList32;
        private BrightIdeasSoftware.OLVColumn olvModuleName;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrganizationalUnitName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NoAccess;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ReadOnly;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Editable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ApprovalPermitted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UnApprovalPermitted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VoidablePermitted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UnVoidablePermitted;
    }
}