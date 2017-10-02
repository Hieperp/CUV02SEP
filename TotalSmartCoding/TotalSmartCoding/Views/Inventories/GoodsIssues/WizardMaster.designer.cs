namespace TotalSmartCoding.Views.Inventories.GoodsIssues
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
            this.fastPendingDeliveryAdvices = new BrightIdeasSoftware.FastObjectListView();
            this.olvDeliveryAdviceEntryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvDeliveryAdviceReference = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCustomerName1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.fastPendingDeliveryAdviceCustomers = new BrightIdeasSoftware.FastObjectListView();
            this.olvCustomerCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCustomerName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelMaster = new System.Windows.Forms.Panel();
            this.olvSalesOrderReferences = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvVoucherCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingDeliveryAdvices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingDeliveryAdviceCustomers)).BeginInit();
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
            // fastPendingDeliveryAdvices
            // 
            this.fastPendingDeliveryAdvices.AllColumns.Add(this.olvDeliveryAdviceEntryDate);
            this.fastPendingDeliveryAdvices.AllColumns.Add(this.olvDeliveryAdviceReference);
            this.fastPendingDeliveryAdvices.AllColumns.Add(this.olvSalesOrderReferences);
            this.fastPendingDeliveryAdvices.AllColumns.Add(this.olvVoucherCode);
            this.fastPendingDeliveryAdvices.AllColumns.Add(this.olvCustomerName1);
            this.fastPendingDeliveryAdvices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvDeliveryAdviceEntryDate,
            this.olvDeliveryAdviceReference,
            this.olvSalesOrderReferences,
            this.olvVoucherCode,
            this.olvCustomerName1});
            this.fastPendingDeliveryAdvices.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingDeliveryAdvices.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingDeliveryAdvices.FullRowSelect = true;
            this.fastPendingDeliveryAdvices.HideSelection = false;
            this.fastPendingDeliveryAdvices.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingDeliveryAdvices.Location = new System.Drawing.Point(-3, 313);
            this.fastPendingDeliveryAdvices.Name = "fastPendingDeliveryAdvices";
            this.fastPendingDeliveryAdvices.OwnerDraw = true;
            this.fastPendingDeliveryAdvices.ShowGroups = false;
            this.fastPendingDeliveryAdvices.Size = new System.Drawing.Size(1147, 232);
            this.fastPendingDeliveryAdvices.TabIndex = 69;
            this.fastPendingDeliveryAdvices.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingDeliveryAdvices.UseCompatibleStateImageBehavior = false;
            this.fastPendingDeliveryAdvices.UseFiltering = true;
            this.fastPendingDeliveryAdvices.View = System.Windows.Forms.View.Details;
            this.fastPendingDeliveryAdvices.VirtualMode = true;
            // 
            // olvDeliveryAdviceEntryDate
            // 
            this.olvDeliveryAdviceEntryDate.AspectName = "DeliveryAdviceEntryDate";
            this.olvDeliveryAdviceEntryDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvDeliveryAdviceEntryDate.Text = "D.A. Date";
            this.olvDeliveryAdviceEntryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvDeliveryAdviceEntryDate.Width = 120;
            // 
            // olvDeliveryAdviceReference
            // 
            this.olvDeliveryAdviceReference.AspectName = "DeliveryAdviceReference";
            this.olvDeliveryAdviceReference.Text = "Reference";
            this.olvDeliveryAdviceReference.Width = 80;
            // 
            // olvCustomerName1
            // 
            this.olvCustomerName1.AspectName = "CustomerName";
            this.olvCustomerName1.FillsFreeSpace = true;
            this.olvCustomerName1.Text = "Customer";
            this.olvCustomerName1.Width = 192;
            // 
            // fastPendingDeliveryAdviceCustomers
            // 
            this.fastPendingDeliveryAdviceCustomers.AllColumns.Add(this.olvCustomerCode);
            this.fastPendingDeliveryAdviceCustomers.AllColumns.Add(this.olvCustomerName);
            this.fastPendingDeliveryAdviceCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvCustomerCode,
            this.olvCustomerName});
            this.fastPendingDeliveryAdviceCustomers.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingDeliveryAdviceCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.fastPendingDeliveryAdviceCustomers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingDeliveryAdviceCustomers.FullRowSelect = true;
            this.fastPendingDeliveryAdviceCustomers.HideSelection = false;
            this.fastPendingDeliveryAdviceCustomers.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingDeliveryAdviceCustomers.Location = new System.Drawing.Point(0, 9);
            this.fastPendingDeliveryAdviceCustomers.Name = "fastPendingDeliveryAdviceCustomers";
            this.fastPendingDeliveryAdviceCustomers.OwnerDraw = true;
            this.fastPendingDeliveryAdviceCustomers.ShowGroups = false;
            this.fastPendingDeliveryAdviceCustomers.Size = new System.Drawing.Size(1147, 447);
            this.fastPendingDeliveryAdviceCustomers.TabIndex = 70;
            this.fastPendingDeliveryAdviceCustomers.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingDeliveryAdviceCustomers.UseCompatibleStateImageBehavior = false;
            this.fastPendingDeliveryAdviceCustomers.UseFiltering = true;
            this.fastPendingDeliveryAdviceCustomers.View = System.Windows.Forms.View.Details;
            this.fastPendingDeliveryAdviceCustomers.VirtualMode = true;
            // 
            // olvCustomerCode
            // 
            this.olvCustomerCode.AspectName = "CustomerCode";
            this.olvCustomerCode.Text = "Customer Code";
            this.olvCustomerCode.Width = 145;
            // 
            // olvCustomerName
            // 
            this.olvCustomerName.AspectName = "CustomerName";
            this.olvCustomerName.FillsFreeSpace = true;
            this.olvCustomerName.Text = "Name";
            this.olvCustomerName.Width = 263;
            // 
            // panelMaster
            // 
            this.panelMaster.Controls.Add(this.fastPendingDeliveryAdvices);
            this.panelMaster.Controls.Add(this.fastPendingDeliveryAdviceCustomers);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panelMaster.Size = new System.Drawing.Size(1147, 548);
            this.panelMaster.TabIndex = 71;
            // 
            // olvSalesOrderReferences
            // 
            this.olvSalesOrderReferences.AspectName = "SalesOrderReferences";
            this.olvSalesOrderReferences.Text = "Sales Order";
            this.olvSalesOrderReferences.Width = 120;
            // 
            // olvVoucherCode
            // 
            this.olvVoucherCode.AspectName = "VoucherCode";
            this.olvVoucherCode.Text = "Voucher";
            this.olvVoucherCode.Width = 180;
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
            this.Text = "Create Wizard [Add New Goods Issue]";
            this.Load += new System.EventHandler(this.Wizard_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingDeliveryAdvices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingDeliveryAdviceCustomers)).EndInit();
            this.panelMaster.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonOK;
        private BrightIdeasSoftware.FastObjectListView fastPendingDeliveryAdvices;
        private BrightIdeasSoftware.FastObjectListView fastPendingDeliveryAdviceCustomers;
        private System.Windows.Forms.Panel panelMaster;
        private BrightIdeasSoftware.OLVColumn olvDeliveryAdviceEntryDate;
        private BrightIdeasSoftware.OLVColumn olvCustomerName1;
        private BrightIdeasSoftware.OLVColumn olvCustomerCode;
        private BrightIdeasSoftware.OLVColumn olvCustomerName;
        private BrightIdeasSoftware.OLVColumn olvDeliveryAdviceReference;
        private BrightIdeasSoftware.OLVColumn olvSalesOrderReferences;
        private BrightIdeasSoftware.OLVColumn olvVoucherCode;
    }
}