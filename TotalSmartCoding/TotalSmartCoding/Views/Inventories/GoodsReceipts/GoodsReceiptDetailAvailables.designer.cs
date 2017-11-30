namespace TotalSmartCoding.Views.Inventories.GoodsReceipts
{
    partial class GoodsReceiptDetailAvailables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsReceiptDetailAvailables));
            this.toolStripChildForm = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.panelMaster = new System.Windows.Forms.Panel();
            this.fastAvailablePallets = new BrightIdeasSoftware.FastObjectListView();
            this.olvIsSelected = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBinLocationCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBatchEntryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPallet = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPalletLineVolumeAvailable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPalletCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.fastAvailableCartons = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCartonQuantityAvailable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCartonLineVolumeAvailable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCartonCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripChildForm.SuspendLayout();
            this.panelMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailablePallets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailableCartons)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripChildForm
            // 
            this.toolStripChildForm.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripChildForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripChildForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator1});
            this.toolStripChildForm.Location = new System.Drawing.Point(0, 0);
            this.toolStripChildForm.Name = "toolStripChildForm";
            this.toolStripChildForm.Size = new System.Drawing.Size(1531, 39);
            this.toolStripChildForm.TabIndex = 29;
            this.toolStripChildForm.Text = "toolStrip1";
            this.toolStripChildForm.Visible = false;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::TotalSmartCoding.Properties.Resources._20130106011449193_easyicon_cn_32;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(118, 36);
            this.toolStripButton2.Text = "Disconnect";
            this.toolStripButton2.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            this.toolStripSeparator1.Visible = false;
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
            // 
            // panelMaster
            // 
            this.panelMaster.Controls.Add(this.fastAvailablePallets);
            this.panelMaster.Controls.Add(this.fastAvailableCartons);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Size = new System.Drawing.Size(1531, 654);
            this.panelMaster.TabIndex = 72;
            // 
            // fastAvailablePallets
            // 
            this.fastAvailablePallets.AllColumns.Add(this.olvIsSelected);
            this.fastAvailablePallets.AllColumns.Add(this.olvCommodityCode);
            this.fastAvailablePallets.AllColumns.Add(this.olvBinLocationCode);
            this.fastAvailablePallets.AllColumns.Add(this.olvBatchEntryDate);
            this.fastAvailablePallets.AllColumns.Add(this.olvPallet);
            this.fastAvailablePallets.AllColumns.Add(this.olvPalletLineVolumeAvailable);
            this.fastAvailablePallets.AllColumns.Add(this.olvPalletCode);
            this.fastAvailablePallets.CheckBoxes = true;
            this.fastAvailablePallets.CheckedAspectName = "IsSelected";
            this.fastAvailablePallets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvIsSelected,
            this.olvCommodityCode,
            this.olvBinLocationCode,
            this.olvBatchEntryDate,
            this.olvPallet,
            this.olvPalletLineVolumeAvailable,
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
            this.fastAvailablePallets.Size = new System.Drawing.Size(1147, 122);
            this.fastAvailablePallets.TabIndex = 69;
            this.fastAvailablePallets.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastAvailablePallets.UseCompatibleStateImageBehavior = false;
            this.fastAvailablePallets.UseFiltering = true;
            this.fastAvailablePallets.View = System.Windows.Forms.View.Details;
            this.fastAvailablePallets.VirtualMode = true;
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
            this.olvCommodityCode.Width = 86;
            // 
            // olvBinLocationCode
            // 
            this.olvBinLocationCode.AspectName = "BinLocationCode";
            this.olvBinLocationCode.Sortable = false;
            this.olvBinLocationCode.Text = "Location";
            this.olvBinLocationCode.Width = 96;
            // 
            // olvBatchEntryDate
            // 
            this.olvBatchEntryDate.AspectName = "BatchEntryDate";
            this.olvBatchEntryDate.AspectToStringFormat = "{0:d}";
            this.olvBatchEntryDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBatchEntryDate.Sortable = false;
            this.olvBatchEntryDate.Text = "Date";
            this.olvBatchEntryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBatchEntryDate.Width = 80;
            // 
            // olvPallet
            // 
            this.olvPallet.AspectName = "QuantityAvailable";
            this.olvPallet.AspectToStringFormat = "{0:#,#}";
            this.olvPallet.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPallet.Text = "Quantity";
            this.olvPallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPallet.Width = 68;
            // 
            // olvPalletLineVolumeAvailable
            // 
            this.olvPalletLineVolumeAvailable.AspectName = "LineVolumeAvailable";
            this.olvPalletLineVolumeAvailable.AspectToStringFormat = "{0:#,##0.00}";
            this.olvPalletLineVolumeAvailable.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPalletLineVolumeAvailable.Text = "Volume";
            this.olvPalletLineVolumeAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPalletLineVolumeAvailable.Width = 68;
            // 
            // olvPalletCode
            // 
            this.olvPalletCode.AspectName = "PalletCode";
            this.olvPalletCode.FillsFreeSpace = true;
            this.olvPalletCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletCode.Sortable = false;
            this.olvPalletCode.Text = "Pallet Code";
            this.olvPalletCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletCode.Width = 120;
            // 
            // fastAvailableCartons
            // 
            this.fastAvailableCartons.AllColumns.Add(this.olvColumn1);
            this.fastAvailableCartons.AllColumns.Add(this.olvColumn2);
            this.fastAvailableCartons.AllColumns.Add(this.olvColumn3);
            this.fastAvailableCartons.AllColumns.Add(this.olvColumn4);
            this.fastAvailableCartons.AllColumns.Add(this.olvCartonQuantityAvailable);
            this.fastAvailableCartons.AllColumns.Add(this.olvCartonLineVolumeAvailable);
            this.fastAvailableCartons.AllColumns.Add(this.olvCartonCode);
            this.fastAvailableCartons.CheckBoxes = true;
            this.fastAvailableCartons.CheckedAspectName = "IsSelected";
            this.fastAvailableCartons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvCartonQuantityAvailable,
            this.olvCartonLineVolumeAvailable,
            this.olvCartonCode});
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
            this.olvColumn2.Width = 86;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "BinLocationCode";
            this.olvColumn3.Sortable = false;
            this.olvColumn3.Text = "Location";
            this.olvColumn3.Width = 96;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "BatchEntryDate";
            this.olvColumn4.AspectToStringFormat = "{0:d}";
            this.olvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Sortable = false;
            this.olvColumn4.Text = "Date";
            this.olvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Width = 80;
            // 
            // olvCartonQuantityAvailable
            // 
            this.olvCartonQuantityAvailable.AspectName = "QuantityAvailable";
            this.olvCartonQuantityAvailable.AspectToStringFormat = "{0:#,#}";
            this.olvCartonQuantityAvailable.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvCartonQuantityAvailable.Text = "Quantity";
            this.olvCartonQuantityAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvCartonQuantityAvailable.Width = 68;
            // 
            // olvCartonLineVolumeAvailable
            // 
            this.olvCartonLineVolumeAvailable.AspectName = "LineVolumeAvailable";
            this.olvCartonLineVolumeAvailable.AspectToStringFormat = "{0:#,##0.00}";
            this.olvCartonLineVolumeAvailable.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvCartonLineVolumeAvailable.Text = "Volume";
            this.olvCartonLineVolumeAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvCartonLineVolumeAvailable.Width = 68;
            // 
            // olvCartonCode
            // 
            this.olvCartonCode.AspectName = "CartonCode";
            this.olvCartonCode.FillsFreeSpace = true;
            this.olvCartonCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonCode.Sortable = false;
            this.olvCartonCode.Text = "Carton Code";
            this.olvCartonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonCode.Width = 120;
            // 
            // GoodsReceiptDetailAvailables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 654);
            this.Controls.Add(this.panelMaster);
            this.Controls.Add(this.toolStripChildForm);
            this.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GoodsReceiptDetailAvailables";
            this.Text = "Goods Receipts";
            this.Controls.SetChildIndex(this.toolStripChildForm, 0);
            this.Controls.SetChildIndex(this.panelMaster, 0);
            this.toolStripChildForm.ResumeLayout(false);
            this.toolStripChildForm.PerformLayout();
            this.panelMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailablePallets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastAvailableCartons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripChildForm;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList imageList32;
        private System.Windows.Forms.Panel panelMaster;
        private BrightIdeasSoftware.FastObjectListView fastAvailablePallets;
        private BrightIdeasSoftware.OLVColumn olvIsSelected;
        private BrightIdeasSoftware.OLVColumn olvCommodityCode;
        private BrightIdeasSoftware.OLVColumn olvBinLocationCode;
        private BrightIdeasSoftware.OLVColumn olvBatchEntryDate;
        private BrightIdeasSoftware.OLVColumn olvPallet;
        private BrightIdeasSoftware.OLVColumn olvPalletLineVolumeAvailable;
        private BrightIdeasSoftware.OLVColumn olvPalletCode;
        private BrightIdeasSoftware.FastObjectListView fastAvailableCartons;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvCartonQuantityAvailable;
        private BrightIdeasSoftware.OLVColumn olvCartonLineVolumeAvailable;
        private BrightIdeasSoftware.OLVColumn olvCartonCode;

    }
}