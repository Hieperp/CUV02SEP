﻿namespace TotalSmartCoding.Views.Inventories.WarehouseAdjustments
{
    partial class WizardUnpack
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
            this.fastPendingPallets = new BrightIdeasSoftware.FastObjectListView();
            this.olvIsSelected = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBinLocationCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBatchEntryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvQuantityAvailable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPalletCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelMaster = new System.Windows.Forms.Panel();
            this.fastPendingCartons = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCartonCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.splitContainerBottom = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.textexFilters = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.buttonClearFilters = new System.Windows.Forms.ToolStripButton();
            this.buttonESC = new System.Windows.Forms.ToolStripButton();
            this.buttonAddExit = new System.Windows.Forms.ToolStripButton();
            this.buttonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingPallets)).BeginInit();
            this.panelMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingCartons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottom)).BeginInit();
            this.splitContainerBottom.Panel1.SuspendLayout();
            this.splitContainerBottom.Panel2.SuspendLayout();
            this.splitContainerBottom.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonESC,
            this.buttonAddExit,
            this.buttonAdd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(726, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fastPendingPallets
            // 
            this.fastPendingPallets.AllColumns.Add(this.olvIsSelected);
            this.fastPendingPallets.AllColumns.Add(this.olvBinLocationCode);
            this.fastPendingPallets.AllColumns.Add(this.olvCommodityCode);
            this.fastPendingPallets.AllColumns.Add(this.olvCommodityName);
            this.fastPendingPallets.AllColumns.Add(this.olvBatchEntryDate);
            this.fastPendingPallets.AllColumns.Add(this.olvQuantityAvailable);
            this.fastPendingPallets.AllColumns.Add(this.olvPalletCode);
            this.fastPendingPallets.CheckBoxes = true;
            this.fastPendingPallets.CheckedAspectName = "IsSelected";
            this.fastPendingPallets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvIsSelected,
            this.olvBinLocationCode,
            this.olvCommodityCode,
            this.olvCommodityName,
            this.olvBatchEntryDate,
            this.olvQuantityAvailable,
            this.olvPalletCode});
            this.fastPendingPallets.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingPallets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingPallets.FullRowSelect = true;
            this.fastPendingPallets.HideSelection = false;
            this.fastPendingPallets.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingPallets.Location = new System.Drawing.Point(0, 303);
            this.fastPendingPallets.Name = "fastPendingPallets";
            this.fastPendingPallets.OwnerDraw = true;
            this.fastPendingPallets.ShowGroups = false;
            this.fastPendingPallets.ShowImagesOnSubItems = true;
            this.fastPendingPallets.Size = new System.Drawing.Size(1386, 245);
            this.fastPendingPallets.TabIndex = 69;
            this.fastPendingPallets.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingPallets.UseCompatibleStateImageBehavior = false;
            this.fastPendingPallets.UseFiltering = true;
            this.fastPendingPallets.View = System.Windows.Forms.View.Details;
            this.fastPendingPallets.VirtualMode = true;
            this.fastPendingPallets.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.fastPendingPallets_ItemChecked);
            // 
            // olvIsSelected
            // 
            this.olvIsSelected.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsSelected.Text = "";
            this.olvIsSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsSelected.Width = 20;
            // 
            // olvBinLocationCode
            // 
            this.olvBinLocationCode.AspectName = "BinLocationCode";
            this.olvBinLocationCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBinLocationCode.Text = "Bin Location";
            this.olvBinLocationCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBinLocationCode.Width = 110;
            // 
            // olvCommodityCode
            // 
            this.olvCommodityCode.AspectName = "CommodityCode";
            this.olvCommodityCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCommodityCode.Text = "Item";
            this.olvCommodityCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCommodityCode.Width = 100;
            // 
            // olvCommodityName
            // 
            this.olvCommodityName.AspectName = "CommodityName";
            this.olvCommodityName.Text = "Item Name";
            this.olvCommodityName.Width = 310;
            // 
            // olvBatchEntryDate
            // 
            this.olvBatchEntryDate.AspectName = "BatchEntryDate";
            this.olvBatchEntryDate.AspectToStringFormat = "{0:d}";
            this.olvBatchEntryDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBatchEntryDate.Text = "Batch Date";
            this.olvBatchEntryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBatchEntryDate.Width = 100;
            // 
            // olvQuantityAvailable
            // 
            this.olvQuantityAvailable.AspectName = "QuantityAvailable";
            this.olvQuantityAvailable.AspectToStringFormat = "{0:#,#}";
            this.olvQuantityAvailable.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvQuantityAvailable.Text = "Quantity";
            this.olvQuantityAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvQuantityAvailable.Width = 79;
            // 
            // olvPalletCode
            // 
            this.olvPalletCode.AspectName = "PalletCode";
            this.olvPalletCode.FillsFreeSpace = true;
            this.olvPalletCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletCode.Text = "Pallet Code";
            this.olvPalletCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletCode.Width = 200;
            // 
            // panelMaster
            // 
            this.panelMaster.BackColor = System.Drawing.Color.Ivory;
            this.panelMaster.Controls.Add(this.fastPendingPallets);
            this.panelMaster.Controls.Add(this.fastPendingCartons);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panelMaster.Size = new System.Drawing.Size(1386, 548);
            this.panelMaster.TabIndex = 71;
            // 
            // fastPendingCartons
            // 
            this.fastPendingCartons.AllColumns.Add(this.olvColumn1);
            this.fastPendingCartons.AllColumns.Add(this.olvCartonCode);
            this.fastPendingCartons.CheckedAspectName = "";
            this.fastPendingCartons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvCartonCode});
            this.fastPendingCartons.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingCartons.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingCartons.FullRowSelect = true;
            this.fastPendingCartons.HideSelection = false;
            this.fastPendingCartons.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingCartons.Location = new System.Drawing.Point(0, 152);
            this.fastPendingCartons.Name = "fastPendingCartons";
            this.fastPendingCartons.OwnerDraw = true;
            this.fastPendingCartons.ShowGroups = false;
            this.fastPendingCartons.ShowImagesOnSubItems = true;
            this.fastPendingCartons.Size = new System.Drawing.Size(1386, 245);
            this.fastPendingCartons.TabIndex = 70;
            this.fastPendingCartons.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingCartons.UseCompatibleStateImageBehavior = false;
            this.fastPendingCartons.UseFiltering = true;
            this.fastPendingCartons.View = System.Windows.Forms.View.Details;
            this.fastPendingCartons.VirtualMode = true;
            this.fastPendingCartons.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.fastObjectListView_ItemsChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.Text = "";
            this.olvColumn1.Width = 20;
            // 
            // olvCartonCode
            // 
            this.olvCartonCode.AspectName = "Code";
            this.olvCartonCode.FillsFreeSpace = true;
            this.olvCartonCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonCode.Text = "Carton Code";
            this.olvCartonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonCode.Width = 200;
            // 
            // splitContainerBottom
            // 
            this.splitContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainerBottom.Location = new System.Drawing.Point(0, 548);
            this.splitContainerBottom.Name = "splitContainerBottom";
            // 
            // splitContainerBottom.Panel1
            // 
            this.splitContainerBottom.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainerBottom.Panel2
            // 
            this.splitContainerBottom.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainerBottom.Size = new System.Drawing.Size(1386, 55);
            this.splitContainerBottom.SplitterDistance = 659;
            this.splitContainerBottom.SplitterWidth = 1;
            this.splitContainerBottom.TabIndex = 72;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.textexFilters,
            this.buttonClearFilters});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip2.Size = new System.Drawing.Size(659, 55);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // textexFilters
            // 
            this.textexFilters.AutoSize = false;
            this.textexFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textexFilters.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexFilters.Name = "textexFilters";
            this.textexFilters.Size = new System.Drawing.Size(360, 28);
            this.textexFilters.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textexFilters.TextChanged += new System.EventHandler(this.textexFilters_TextChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TotalSmartCoding.Properties.Resources.Zoom_seach;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // buttonClearFilters
            // 
            this.buttonClearFilters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonClearFilters.Image = global::TotalSmartCoding.Properties.Resources.Edit_clear;
            this.buttonClearFilters.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonClearFilters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonClearFilters.Name = "buttonClearFilters";
            this.buttonClearFilters.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonClearFilters.Size = new System.Drawing.Size(52, 52);
            this.buttonClearFilters.Text = "toolStripButton1";
            this.buttonClearFilters.Click += new System.EventHandler(this.buttonClearFilters_Click);
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
            this.buttonAddExit.Image = global::TotalSmartCoding.Properties.Resources.Add_close;
            this.buttonAddExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonAddExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddExit.Name = "buttonAddExit";
            this.buttonAddExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAddExit.Size = new System.Drawing.Size(158, 52);
            this.buttonAddExit.Text = "Add and Close";
            this.buttonAddExit.Click += new System.EventHandler(this.buttonAddESC_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::TotalSmartCoding.Properties.Resources.Add_continue;
            this.buttonAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAdd.Size = new System.Drawing.Size(89, 52);
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddESC_Click);
            // 
            // WizardUnpack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 603);
            this.Controls.Add(this.panelMaster);
            this.Controls.Add(this.splitContainerBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardUnpack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unpacking Pallets";
            this.Load += new System.EventHandler(this.WizardDetail_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingPallets)).EndInit();
            this.panelMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingCartons)).EndInit();
            this.splitContainerBottom.Panel1.ResumeLayout(false);
            this.splitContainerBottom.Panel1.PerformLayout();
            this.splitContainerBottom.Panel2.ResumeLayout(false);
            this.splitContainerBottom.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottom)).EndInit();
            this.splitContainerBottom.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonAddExit;
        private BrightIdeasSoftware.FastObjectListView fastPendingPallets;
        private System.Windows.Forms.Panel panelMaster;
        private BrightIdeasSoftware.OLVColumn olvBatchEntryDate;
        private BrightIdeasSoftware.OLVColumn olvCommodityCode;
        private BrightIdeasSoftware.OLVColumn olvBinLocationCode;
        private BrightIdeasSoftware.OLVColumn olvPalletCode;
        private BrightIdeasSoftware.OLVColumn olvIsSelected;
        private BrightIdeasSoftware.OLVColumn olvCommodityName;
        private BrightIdeasSoftware.FastObjectListView fastPendingCartons;
        private BrightIdeasSoftware.OLVColumn olvCartonCode;
        private System.Windows.Forms.ToolStripButton buttonAdd;
        private BrightIdeasSoftware.OLVColumn olvQuantityAvailable;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private System.Windows.Forms.SplitContainer splitContainerBottom;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton buttonClearFilters;
        private System.Windows.Forms.ToolStripTextBox textexFilters;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}