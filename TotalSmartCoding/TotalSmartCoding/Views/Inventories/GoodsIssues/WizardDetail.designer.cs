namespace TotalSmartCoding.Views.Inventories.GoodsIssues
{
    partial class WizardDetail
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
            this.buttonAddExit = new System.Windows.Forms.ToolStripButton();
            this.fastAvailablePallets = new BrightIdeasSoftware.FastObjectListView();
            this.olvIsSelected = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBinLocationCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBatchEntryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPalletCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelMaster = new System.Windows.Forms.Panel();
            this.fastAvailableCartons = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.fastAvailablePacks = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn10 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailablePallets)).BeginInit();
            this.panelMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailableCartons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailablePacks)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonESC,
            this.buttonAddExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 548);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(1147, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // buttonESC
            // 
            this.buttonESC.Image = global::TotalSmartCoding.Properties.Resources.signout_icon_24;
            this.buttonESC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonESC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonESC.Name = "buttonESC";
            this.buttonESC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonESC.Size = new System.Drawing.Size(73, 52);
            this.buttonESC.Text = "Close";
            this.buttonESC.Click += new System.EventHandler(this.buttonAddESC_Click);
            // 
            // buttonAddExit
            // 
            this.buttonAddExit.Image = global::TotalSmartCoding.Properties.Resources.Add_continue;
            this.buttonAddExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonAddExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddExit.Name = "buttonAddExit";
            this.buttonAddExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAddExit.Size = new System.Drawing.Size(158, 52);
            this.buttonAddExit.Text = "Add and Close";
            this.buttonAddExit.Click += new System.EventHandler(this.buttonAddESC_Click);
            // 
            // fastAvailablePallets
            // 
            this.fastAvailablePallets.AllColumns.Add(this.olvIsSelected);
            this.fastAvailablePallets.AllColumns.Add(this.olvCommodityCode);
            this.fastAvailablePallets.AllColumns.Add(this.olvBinLocationCode);
            this.fastAvailablePallets.AllColumns.Add(this.olvBatchEntryDate);
            this.fastAvailablePallets.AllColumns.Add(this.olvPalletCode);
            this.fastAvailablePallets.CheckBoxes = true;
            this.fastAvailablePallets.CheckedAspectName = "IsSelected";
            this.fastAvailablePallets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvIsSelected,
            this.olvCommodityCode,
            this.olvBinLocationCode,
            this.olvBatchEntryDate,
            this.olvPalletCode});
            this.fastAvailablePallets.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastAvailablePallets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastAvailablePallets.FullRowSelect = true;
            this.fastAvailablePallets.HideSelection = false;
            this.fastAvailablePallets.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastAvailablePallets.Location = new System.Drawing.Point(0, 303);
            this.fastAvailablePallets.Name = "fastAvailablePallets";
            this.fastAvailablePallets.OwnerDraw = true;
            this.fastAvailablePallets.RowHeight = 32;
            this.fastAvailablePallets.ShowGroups = false;
            this.fastAvailablePallets.ShowImagesOnSubItems = true;
            this.fastAvailablePallets.Size = new System.Drawing.Size(1147, 245);
            this.fastAvailablePallets.TabIndex = 69;
            this.fastAvailablePallets.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastAvailablePallets.UseCompatibleStateImageBehavior = false;
            this.fastAvailablePallets.UseFiltering = true;
            this.fastAvailablePallets.View = System.Windows.Forms.View.Details;
            this.fastAvailablePallets.VirtualMode = true;
            this.fastAvailablePallets.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.fastAvailableGoodsReceiptDetails_ItemChecked);
            this.fastAvailablePallets.SelectedIndexChanged += new System.EventHandler(this.fastAvailableGoodsReceiptDetails_SelectedIndexChanged);
            // 
            // olvIsSelected
            // 
            this.olvIsSelected.HeaderCheckBox = true;
            this.olvIsSelected.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsSelected.Text = "";
            this.olvIsSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsSelected.Width = 20;
            // 
            // olvCommodityCode
            // 
            this.olvCommodityCode.AspectName = "CommodityCode";
            this.olvCommodityCode.Sortable = false;
            this.olvCommodityCode.Text = "Item";
            this.olvCommodityCode.Width = 96;
            // 
            // olvBinLocationCode
            // 
            this.olvBinLocationCode.AspectName = "BinLocationCode";
            this.olvBinLocationCode.Sortable = false;
            this.olvBinLocationCode.Text = "Location";
            this.olvBinLocationCode.Width = 102;
            // 
            // olvBatchEntryDate
            // 
            this.olvBatchEntryDate.AspectName = "BatchEntryDate";
            this.olvBatchEntryDate.AspectToStringFormat = "{0:d}";
            this.olvBatchEntryDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBatchEntryDate.Sortable = false;
            this.olvBatchEntryDate.Text = "Date";
            this.olvBatchEntryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBatchEntryDate.Width = 85;
            // 
            // olvPalletCode
            // 
            this.olvPalletCode.AspectName = "PalletCode";
            this.olvPalletCode.FillsFreeSpace = true;
            this.olvPalletCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletCode.Sortable = false;
            this.olvPalletCode.Text = "Pallet Code";
            this.olvPalletCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletCode.Width = 200;
            // 
            // panelMaster
            // 
            this.panelMaster.Controls.Add(this.fastAvailablePallets);
            this.panelMaster.Controls.Add(this.fastAvailableCartons);
            this.panelMaster.Controls.Add(this.fastAvailablePacks);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panelMaster.Size = new System.Drawing.Size(1147, 603);
            this.panelMaster.TabIndex = 71;
            // 
            // fastAvailableCartons
            // 
            this.fastAvailableCartons.AllColumns.Add(this.olvColumn1);
            this.fastAvailableCartons.AllColumns.Add(this.olvColumn2);
            this.fastAvailableCartons.AllColumns.Add(this.olvColumn3);
            this.fastAvailableCartons.AllColumns.Add(this.olvColumn4);
            this.fastAvailableCartons.AllColumns.Add(this.olvColumn5);
            this.fastAvailableCartons.CheckBoxes = true;
            this.fastAvailableCartons.CheckedAspectName = "IsSelected";
            this.fastAvailableCartons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5});
            this.fastAvailableCartons.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastAvailableCartons.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastAvailableCartons.FullRowSelect = true;
            this.fastAvailableCartons.HideSelection = false;
            this.fastAvailableCartons.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastAvailableCartons.Location = new System.Drawing.Point(0, 130);
            this.fastAvailableCartons.Name = "fastAvailableCartons";
            this.fastAvailableCartons.OwnerDraw = true;
            this.fastAvailableCartons.RowHeight = 32;
            this.fastAvailableCartons.ShowGroups = false;
            this.fastAvailableCartons.ShowImagesOnSubItems = true;
            this.fastAvailableCartons.Size = new System.Drawing.Size(1147, 245);
            this.fastAvailableCartons.TabIndex = 70;
            this.fastAvailableCartons.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastAvailableCartons.UseCompatibleStateImageBehavior = false;
            this.fastAvailableCartons.UseFiltering = true;
            this.fastAvailableCartons.View = System.Windows.Forms.View.Details;
            this.fastAvailableCartons.VirtualMode = true;
            this.fastAvailableCartons.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.fastAvailableGoodsReceiptDetails_ItemChecked);
            this.fastAvailableCartons.SelectedIndexChanged += new System.EventHandler(this.fastAvailableGoodsReceiptDetails_SelectedIndexChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.HeaderCheckBox = true;
            this.olvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn1.Text = "";
            this.olvColumn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn1.Width = 20;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "CommodityCode";
            this.olvColumn2.Sortable = false;
            this.olvColumn2.Text = "Item";
            this.olvColumn2.Width = 96;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "BinLocationCode";
            this.olvColumn3.Sortable = false;
            this.olvColumn3.Text = "Location";
            this.olvColumn3.Width = 102;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "BatchEntryDate";
            this.olvColumn4.AspectToStringFormat = "{0:d}";
            this.olvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Sortable = false;
            this.olvColumn4.Text = "Date";
            this.olvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Width = 85;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "PalletCode";
            this.olvColumn5.FillsFreeSpace = true;
            this.olvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Sortable = false;
            this.olvColumn5.Text = "Pallet Code";
            this.olvColumn5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Width = 200;
            // 
            // fastAvailablePacks
            // 
            this.fastAvailablePacks.AllColumns.Add(this.olvColumn6);
            this.fastAvailablePacks.AllColumns.Add(this.olvColumn7);
            this.fastAvailablePacks.AllColumns.Add(this.olvColumn8);
            this.fastAvailablePacks.AllColumns.Add(this.olvColumn9);
            this.fastAvailablePacks.AllColumns.Add(this.olvColumn10);
            this.fastAvailablePacks.CheckBoxes = true;
            this.fastAvailablePacks.CheckedAspectName = "IsSelected";
            this.fastAvailablePacks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn6,
            this.olvColumn7,
            this.olvColumn8,
            this.olvColumn9,
            this.olvColumn10});
            this.fastAvailablePacks.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastAvailablePacks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastAvailablePacks.FullRowSelect = true;
            this.fastAvailablePacks.HideSelection = false;
            this.fastAvailablePacks.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastAvailablePacks.Location = new System.Drawing.Point(-3, 0);
            this.fastAvailablePacks.Name = "fastAvailablePacks";
            this.fastAvailablePacks.OwnerDraw = true;
            this.fastAvailablePacks.RowHeight = 32;
            this.fastAvailablePacks.ShowGroups = false;
            this.fastAvailablePacks.ShowImagesOnSubItems = true;
            this.fastAvailablePacks.Size = new System.Drawing.Size(1147, 245);
            this.fastAvailablePacks.TabIndex = 71;
            this.fastAvailablePacks.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastAvailablePacks.UseCompatibleStateImageBehavior = false;
            this.fastAvailablePacks.UseFiltering = true;
            this.fastAvailablePacks.View = System.Windows.Forms.View.Details;
            this.fastAvailablePacks.VirtualMode = true;
            this.fastAvailablePacks.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.fastAvailableGoodsReceiptDetails_ItemChecked);
            this.fastAvailablePacks.SelectedIndexChanged += new System.EventHandler(this.fastAvailableGoodsReceiptDetails_SelectedIndexChanged);
            // 
            // olvColumn6
            // 
            this.olvColumn6.HeaderCheckBox = true;
            this.olvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn6.Text = "";
            this.olvColumn6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn6.Width = 20;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "CommodityCode";
            this.olvColumn7.Sortable = false;
            this.olvColumn7.Text = "Item";
            this.olvColumn7.Width = 96;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "BinLocationCode";
            this.olvColumn8.Sortable = false;
            this.olvColumn8.Text = "Location";
            this.olvColumn8.Width = 102;
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "BatchEntryDate";
            this.olvColumn9.AspectToStringFormat = "{0:d}";
            this.olvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn9.Sortable = false;
            this.olvColumn9.Text = "Date";
            this.olvColumn9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn9.Width = 85;
            // 
            // olvColumn10
            // 
            this.olvColumn10.AspectName = "PalletCode";
            this.olvColumn10.FillsFreeSpace = true;
            this.olvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn10.Sortable = false;
            this.olvColumn10.Text = "Pallet Code";
            this.olvColumn10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn10.Width = 200;
            // 
            // WizardDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 603);
            this.Controls.Add(this.panelMaster);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WizardDetail";
            this.Text = "Create Wizard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WizardDetail_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailablePallets)).EndInit();
            this.panelMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailableCartons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailablePacks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonAddExit;
        private BrightIdeasSoftware.FastObjectListView fastAvailablePallets;
        private System.Windows.Forms.Panel panelMaster;
        private BrightIdeasSoftware.OLVColumn olvCommodityCode;
        private BrightIdeasSoftware.OLVColumn olvPalletCode;
        private BrightIdeasSoftware.OLVColumn olvIsSelected;
        private BrightIdeasSoftware.OLVColumn olvBinLocationCode;
        private BrightIdeasSoftware.OLVColumn olvBatchEntryDate;
        private BrightIdeasSoftware.FastObjectListView fastAvailableCartons;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.FastObjectListView fastAvailablePacks;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn olvColumn10;
    }
}