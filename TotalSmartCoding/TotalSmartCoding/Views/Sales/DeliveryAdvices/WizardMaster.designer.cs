namespace TotalSmartCoding.Views.Sales.DeliveryAdvices
{
    partial class WizardMaster
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonESC = new System.Windows.Forms.ToolStripButton();
            this.buttonOK = new System.Windows.Forms.ToolStripButton();
            this.fastPendingSalesOrders = new BrightIdeasSoftware.FastObjectListView();
            this.olvSalesOrderEntryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvSalesOrderReference = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCustomerName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.fastPendingSalesOrderCustomers = new BrightIdeasSoftware.FastObjectListView();
            this.olvCustomerID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvWarehouseName1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelMaster = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingSalesOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingSalesOrderCustomers)).BeginInit();
            this.panelMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonESC,
            this.buttonOK});
            this.toolStrip1.Location = new System.Drawing.Point(0, 548);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(1147, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonESC
            // 
            this.buttonESC.Image = global::TotalSmartCoding.Properties.Resources.signout_icon_24;
            this.buttonESC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonESC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonESC.Name = "buttonESC";
            this.buttonESC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonESC.Size = new System.Drawing.Size(81, 52);
            this.buttonESC.Text = "Cancel";
            this.buttonESC.Click += new System.EventHandler(this.buttonOKESC_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Image = global::TotalSmartCoding.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_go_next_view;
            this.buttonOK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonOK.Size = new System.Drawing.Size(92, 52);
            this.buttonOK.Text = "Next";
            this.buttonOK.Click += new System.EventHandler(this.buttonOKESC_Click);
            // 
            // fastPendingSalesOrders
            // 
            this.fastPendingSalesOrders.AllColumns.Add(this.olvSalesOrderEntryDate);
            this.fastPendingSalesOrders.AllColumns.Add(this.olvSalesOrderReference);
            this.fastPendingSalesOrders.AllColumns.Add(this.olvCustomerName);
            this.fastPendingSalesOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvSalesOrderEntryDate,
            this.olvSalesOrderReference,
            this.olvCustomerName});
            this.fastPendingSalesOrders.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingSalesOrders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingSalesOrders.FullRowSelect = true;
            this.fastPendingSalesOrders.HideSelection = false;
            this.fastPendingSalesOrders.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingSalesOrders.Location = new System.Drawing.Point(-3, 313);
            this.fastPendingSalesOrders.Name = "fastPendingSalesOrders";
            this.fastPendingSalesOrders.OwnerDraw = true;
            this.fastPendingSalesOrders.ShowGroups = false;
            this.fastPendingSalesOrders.Size = new System.Drawing.Size(1147, 232);
            this.fastPendingSalesOrders.TabIndex = 69;
            this.fastPendingSalesOrders.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingSalesOrders.UseCompatibleStateImageBehavior = false;
            this.fastPendingSalesOrders.UseFiltering = true;
            this.fastPendingSalesOrders.View = System.Windows.Forms.View.Details;
            this.fastPendingSalesOrders.VirtualMode = true;
            // 
            // olvSalesOrderEntryDate
            // 
            this.olvSalesOrderEntryDate.AspectName = "SalesOrderEntryDate";
            this.olvSalesOrderEntryDate.Width = 170;
            // 
            // olvSalesOrderReference
            // 
            this.olvSalesOrderReference.AspectName = "SalesOrderReference";
            this.olvSalesOrderReference.Width = 137;
            // 
            // olvCustomerName
            // 
            this.olvCustomerName.AspectName = "CustomerName";
            this.olvCustomerName.Width = 192;
            // 
            // fastPendingSalesOrderCustomers
            // 
            this.fastPendingSalesOrderCustomers.AllColumns.Add(this.olvCustomerID);
            this.fastPendingSalesOrderCustomers.AllColumns.Add(this.olvWarehouseName1);
            this.fastPendingSalesOrderCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvCustomerID,
            this.olvWarehouseName1});
            this.fastPendingSalesOrderCustomers.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingSalesOrderCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.fastPendingSalesOrderCustomers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingSalesOrderCustomers.FullRowSelect = true;
            this.fastPendingSalesOrderCustomers.HideSelection = false;
            this.fastPendingSalesOrderCustomers.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingSalesOrderCustomers.Location = new System.Drawing.Point(0, 9);
            this.fastPendingSalesOrderCustomers.Name = "fastPendingSalesOrderCustomers";
            this.fastPendingSalesOrderCustomers.OwnerDraw = true;
            this.fastPendingSalesOrderCustomers.ShowGroups = false;
            this.fastPendingSalesOrderCustomers.Size = new System.Drawing.Size(1147, 447);
            this.fastPendingSalesOrderCustomers.TabIndex = 70;
            this.fastPendingSalesOrderCustomers.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingSalesOrderCustomers.UseCompatibleStateImageBehavior = false;
            this.fastPendingSalesOrderCustomers.UseFiltering = true;
            this.fastPendingSalesOrderCustomers.View = System.Windows.Forms.View.Details;
            this.fastPendingSalesOrderCustomers.VirtualMode = true;
            // 
            // olvCustomerID
            // 
            this.olvCustomerID.AspectName = "CustomerID";
            this.olvCustomerID.Width = 161;
            // 
            // olvWarehouseName1
            // 
            this.olvWarehouseName1.AspectName = "CustomerName";
            this.olvWarehouseName1.Width = 263;
            // 
            // panelMaster
            // 
            this.panelMaster.Controls.Add(this.fastPendingSalesOrders);
            this.panelMaster.Controls.Add(this.fastPendingSalesOrderCustomers);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panelMaster.Size = new System.Drawing.Size(1147, 548);
            this.panelMaster.TabIndex = 71;
            // 
            // WizardMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 603);
            this.Controls.Add(this.panelMaster);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Wizard";
            this.Load += new System.EventHandler(this.Wizard_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingSalesOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingSalesOrderCustomers)).EndInit();
            this.panelMaster.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonOK;
        private BrightIdeasSoftware.FastObjectListView fastPendingSalesOrders;
        private BrightIdeasSoftware.FastObjectListView fastPendingSalesOrderCustomers;
        private System.Windows.Forms.Panel panelMaster;
        private BrightIdeasSoftware.OLVColumn olvSalesOrderEntryDate;
        private BrightIdeasSoftware.OLVColumn olvCustomerName;
        private BrightIdeasSoftware.OLVColumn olvCustomerID;
        private BrightIdeasSoftware.OLVColumn olvWarehouseName1;
        private BrightIdeasSoftware.OLVColumn olvSalesOrderReference;
    }
}