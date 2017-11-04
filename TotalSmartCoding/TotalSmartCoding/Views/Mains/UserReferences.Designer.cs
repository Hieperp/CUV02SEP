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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserReferences));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.comboUserID = new System.Windows.Forms.ToolStripComboBox();
            this.buttonUserAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonUserRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.fastNMVNTasks = new BrightIdeasSoftware.FastObjectListView();
            this.olvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvNMVNTaskName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.gridexAccessControls = new CustomControls.DataGridexView();
            this.CommodityID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CommodityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.comboUserID,
            this.buttonUserAdd,
            this.buttonUserRemove,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1127, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // comboUserID
            // 
            this.comboUserID.Name = "comboUserID";
            this.comboUserID.Size = new System.Drawing.Size(450, 55);
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
            this.fastNMVNTasks.AllColumns.Add(this.olvNMVNTaskName);
            this.fastNMVNTasks.BackColor = System.Drawing.Color.Ivory;
            this.fastNMVNTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvID,
            this.olvNMVNTaskName});
            this.fastNMVNTasks.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastNMVNTasks.Dock = System.Windows.Forms.DockStyle.Left;
            this.fastNMVNTasks.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.fastNMVNTasks.FullRowSelect = true;
            this.fastNMVNTasks.HideSelection = false;
            this.fastNMVNTasks.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastNMVNTasks.Location = new System.Drawing.Point(0, 92);
            this.fastNMVNTasks.Name = "fastNMVNTasks";
            this.fastNMVNTasks.OwnerDraw = true;
            this.fastNMVNTasks.ShowGroups = false;
            this.fastNMVNTasks.Size = new System.Drawing.Size(304, 584);
            this.fastNMVNTasks.TabIndex = 69;
            this.fastNMVNTasks.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastNMVNTasks.UseCompatibleStateImageBehavior = false;
            this.fastNMVNTasks.UseFiltering = true;
            this.fastNMVNTasks.View = System.Windows.Forms.View.Details;
            this.fastNMVNTasks.VirtualMode = true;
            // 
            // olvID
            // 
            this.olvID.Text = "";
            this.olvID.Width = 0;
            // 
            // olvNMVNTaskName
            // 
            this.olvNMVNTaskName.AspectName = "Name";
            this.olvNMVNTaskName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNMVNTaskName.Text = "";
            this.olvNMVNTaskName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNMVNTaskName.Width = 90;
            // 
            // gridexAccessControls
            // 
            this.gridexAccessControls.AllowAddRow = true;
            this.gridexAccessControls.AllowDeleteRow = true;
            this.gridexAccessControls.BackgroundColor = System.Drawing.Color.Ivory;
            this.gridexAccessControls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridexAccessControls.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridexAccessControls.ColumnHeadersHeight = 24;
            this.gridexAccessControls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CommodityID,
            this.CommodityName,
            this.PackageSize,
            this.PackageVolume,
            this.Quantity,
            this.LineVolume,
            this.Remarks});
            this.gridexAccessControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridexAccessControls.Editable = true;
            this.gridexAccessControls.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.gridexAccessControls.Location = new System.Drawing.Point(304, 92);
            this.gridexAccessControls.Name = "gridexAccessControls";
            this.gridexAccessControls.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridexAccessControls.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridexAccessControls.RowTemplate.Height = 24;
            this.gridexAccessControls.Size = new System.Drawing.Size(823, 584);
            this.gridexAccessControls.TabIndex = 70;
            // 
            // CommodityID
            // 
            this.CommodityID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CommodityID.DataPropertyName = "CommodityID";
            this.CommodityID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CommodityID.FillWeight = 9F;
            this.CommodityID.HeaderText = "Items.Code";
            this.CommodityID.Name = "CommodityID";
            this.CommodityID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CommodityID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CommodityName
            // 
            this.CommodityName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CommodityName.DataPropertyName = "CommodityName";
            this.CommodityName.FillWeight = 30F;
            this.CommodityName.HeaderText = "Items.Description";
            this.CommodityName.Name = "CommodityName";
            // 
            // PackageSize
            // 
            this.PackageSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PackageSize.DataPropertyName = "PackageSize";
            this.PackageSize.FillWeight = 10F;
            this.PackageSize.HeaderText = "Package.Size";
            this.PackageSize.Name = "PackageSize";
            // 
            // PackageVolume
            // 
            this.PackageVolume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PackageVolume.DataPropertyName = "PackageVolume";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PackageVolume.DefaultCellStyle = dataGridViewCellStyle1;
            this.PackageVolume.FillWeight = 9F;
            this.PackageVolume.HeaderText = "Package.Volume";
            this.PackageVolume.Name = "PackageVolume";
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.Quantity.FillWeight = 5F;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // LineVolume
            // 
            this.LineVolume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LineVolume.DataPropertyName = "LineVolume";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.LineVolume.DefaultCellStyle = dataGridViewCellStyle3;
            this.LineVolume.FillWeight = 7F;
            this.LineVolume.HeaderText = "Volume";
            this.LineVolume.Name = "LineVolume";
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.FillWeight = 18F;
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // panelCaption
            // 
            this.panelCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption.Location = new System.Drawing.Point(0, 55);
            this.panelCaption.Name = "panelCaption";
            this.panelCaption.Size = new System.Drawing.Size(1127, 37);
            this.panelCaption.TabIndex = 71;
            // 
            // UserReferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 676);
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
        private BrightIdeasSoftware.OLVColumn olvNMVNTaskName;
        private CustomControls.DataGridexView gridexAccessControls;
        private System.Windows.Forms.DataGridViewComboBoxColumn CommodityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommodityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Panel panelCaption;
    }
}