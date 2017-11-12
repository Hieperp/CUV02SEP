﻿namespace TotalSmartCoding.Views.Inventories.GoodsReceipts
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
            this.buttonAdd = new System.Windows.Forms.ToolStripButton();
            this.fastPendingPallets = new BrightIdeasSoftware.FastObjectListView();
            this.olvIsSelected = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPalletCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelMaster = new System.Windows.Forms.Panel();
            this.fastPendingCartons = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCartonCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingPallets)).BeginInit();
            this.panelMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingCartons)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonESC,
            this.buttonAddExit,
            this.buttonAdd});
            this.toolStrip1.Location = new System.Drawing.Point(614, 551);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(362, 55);
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
            // fastPendingPallets
            // 
            this.fastPendingPallets.AllColumns.Add(this.olvIsSelected);
            this.fastPendingPallets.AllColumns.Add(this.olvCommodityCode);
            this.fastPendingPallets.AllColumns.Add(this.olvCommodityName);
            this.fastPendingPallets.AllColumns.Add(this.olvColumn3);
            this.fastPendingPallets.AllColumns.Add(this.olvPalletCode);
            this.fastPendingPallets.CheckBoxes = true;
            this.fastPendingPallets.CheckedAspectName = "IsSelected";
            this.fastPendingPallets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvIsSelected,
            this.olvCommodityCode,
            this.olvCommodityName,
            this.olvColumn3,
            this.olvPalletCode});
            this.fastPendingPallets.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingPallets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingPallets.FullRowSelect = true;
            this.fastPendingPallets.HideSelection = false;
            this.fastPendingPallets.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingPallets.Location = new System.Drawing.Point(0, 192);
            this.fastPendingPallets.Name = "fastPendingPallets";
            this.fastPendingPallets.OwnerDraw = true;
            this.fastPendingPallets.ShowGroups = false;
            this.fastPendingPallets.ShowImagesOnSubItems = true;
            this.fastPendingPallets.Size = new System.Drawing.Size(1147, 245);
            this.fastPendingPallets.TabIndex = 69;
            this.fastPendingPallets.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingPallets.UseCompatibleStateImageBehavior = false;
            this.fastPendingPallets.UseFiltering = true;
            this.fastPendingPallets.View = System.Windows.Forms.View.Details;
            this.fastPendingPallets.VirtualMode = true;
            // 
            // olvIsSelected
            // 
            this.olvIsSelected.HeaderCheckBox = true;
            this.olvIsSelected.HeaderCheckState = System.Windows.Forms.CheckState.Checked;
            this.olvIsSelected.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsSelected.Sortable = false;
            this.olvIsSelected.Text = "";
            this.olvIsSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsSelected.Width = 20;
            // 
            // olvCommodityCode
            // 
            this.olvCommodityCode.AspectName = "CommodityCode";
            this.olvCommodityCode.Text = "Item";
            this.olvCommodityCode.Width = 90;
            // 
            // olvCommodityName
            // 
            this.olvCommodityName.AspectName = "CommodityName";
            this.olvCommodityName.Text = "Item Name";
            this.olvCommodityName.Width = 310;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "BinLocationCode";
            this.olvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Text = "Bin Location";
            this.olvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Width = 110;
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
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panelMaster.Size = new System.Drawing.Size(1147, 548);
            this.panelMaster.TabIndex = 71;
            // 
            // fastPendingCartons
            // 
            this.fastPendingCartons.AllColumns.Add(this.olvColumn1);
            this.fastPendingCartons.AllColumns.Add(this.olvColumn4);
            this.fastPendingCartons.AllColumns.Add(this.olvColumn6);
            this.fastPendingCartons.AllColumns.Add(this.olvColumn2);
            this.fastPendingCartons.AllColumns.Add(this.olvCartonCode);
            this.fastPendingCartons.CheckBoxes = true;
            this.fastPendingCartons.CheckedAspectName = "IsSelected";
            this.fastPendingCartons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn4,
            this.olvColumn6,
            this.olvColumn2,
            this.olvCartonCode});
            this.fastPendingCartons.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingCartons.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingCartons.FullRowSelect = true;
            this.fastPendingCartons.HideSelection = false;
            this.fastPendingCartons.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingCartons.Location = new System.Drawing.Point(0, 52);
            this.fastPendingCartons.Name = "fastPendingCartons";
            this.fastPendingCartons.OwnerDraw = true;
            this.fastPendingCartons.ShowGroups = false;
            this.fastPendingCartons.ShowImagesOnSubItems = true;
            this.fastPendingCartons.Size = new System.Drawing.Size(1147, 245);
            this.fastPendingCartons.TabIndex = 70;
            this.fastPendingCartons.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingCartons.UseCompatibleStateImageBehavior = false;
            this.fastPendingCartons.UseFiltering = true;
            this.fastPendingCartons.View = System.Windows.Forms.View.Details;
            this.fastPendingCartons.VirtualMode = true;
            // 
            // olvColumn1
            // 
            this.olvColumn1.HeaderCheckBox = true;
            this.olvColumn1.HeaderCheckState = System.Windows.Forms.CheckState.Checked;
            this.olvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn1.Sortable = false;
            this.olvColumn1.Text = "";
            this.olvColumn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn1.Width = 20;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "CommodityCode";
            this.olvColumn4.Text = "Item";
            this.olvColumn4.Width = 90;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "CommodityName";
            this.olvColumn6.Text = "Item Name";
            this.olvColumn6.Width = 310;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "BinLocationCode";
            this.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Text = "Bin Location";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Width = 110;
            // 
            // olvCartonCode
            // 
            this.olvCartonCode.AspectName = "CartonCode";
            this.olvCartonCode.FillsFreeSpace = true;
            this.olvCartonCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonCode.Text = "Carton Code";
            this.olvCartonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonCode.Width = 200;
            // 
            // WizardDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 603);
            this.Controls.Add(this.panelMaster);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select and add items";
            this.Load += new System.EventHandler(this.WizardDetail_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingPallets)).EndInit();
            this.panelMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingCartons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonAddExit;
        private BrightIdeasSoftware.FastObjectListView fastPendingPallets;
        private System.Windows.Forms.Panel panelMaster;
        private BrightIdeasSoftware.OLVColumn olvCommodityCode;
        private BrightIdeasSoftware.OLVColumn olvPalletCode;
        private BrightIdeasSoftware.OLVColumn olvIsSelected;
        private BrightIdeasSoftware.OLVColumn olvCommodityName;
        private BrightIdeasSoftware.FastObjectListView fastPendingCartons;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvCartonCode;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private System.Windows.Forms.ToolStripButton buttonAdd;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
    }
}