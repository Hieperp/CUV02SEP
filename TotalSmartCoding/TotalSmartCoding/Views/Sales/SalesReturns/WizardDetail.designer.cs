﻿namespace TotalSmartCoding.Views.Sales.SalesReturns
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
            this.fastPendingPallets = new BrightIdeasSoftware.FastObjectListView();
            this.olvPalletSelected = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPalletGoodsIssueEntryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPalletQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPalletLineVolume = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPalletCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelMaster = new System.Windows.Forms.Panel();
            this.fastPendingCartons = new BrightIdeasSoftware.FastObjectListView();
            this.olvCartonSelected = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCartonGoodsIssueEntryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCartonQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCartonLineVolume = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCartonCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelBottomRight = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonESC = new System.Windows.Forms.ToolStripButton();
            this.buttonAddExit = new System.Windows.Forms.ToolStripButton();
            this.buttonAdd = new System.Windows.Forms.ToolStripButton();
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.layoutTop = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.textexFilters = new System.Windows.Forms.ToolStripTextBox();
            this.buttonClearFilters = new System.Windows.Forms.ToolStripButton();
            this.dateTimexUpperFillterDate = new CustomControls.DateTimexPicker();
            this.dateTimexLowerFillterDate = new CustomControls.DateTimexPicker();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingPallets)).BeginInit();
            this.panelMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingCartons)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelBottomRight.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottomLeft.SuspendLayout();
            this.layoutTop.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fastPendingPallets
            // 
            this.fastPendingPallets.AllColumns.Add(this.olvPalletSelected);
            this.fastPendingPallets.AllColumns.Add(this.olvPalletGoodsIssueEntryDate);
            this.fastPendingPallets.AllColumns.Add(this.olvCommodityCode);
            this.fastPendingPallets.AllColumns.Add(this.olvCommodityName);
            this.fastPendingPallets.AllColumns.Add(this.olvPalletQuantity);
            this.fastPendingPallets.AllColumns.Add(this.olvPalletLineVolume);
            this.fastPendingPallets.AllColumns.Add(this.olvPalletCode);
            this.fastPendingPallets.CheckBoxes = true;
            this.fastPendingPallets.CheckedAspectName = "IsSelected";
            this.fastPendingPallets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvPalletSelected,
            this.olvPalletGoodsIssueEntryDate,
            this.olvCommodityCode,
            this.olvCommodityName,
            this.olvPalletQuantity,
            this.olvPalletLineVolume,
            this.olvPalletCode});
            this.fastPendingPallets.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingPallets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingPallets.FullRowSelect = true;
            this.fastPendingPallets.HideSelection = false;
            this.fastPendingPallets.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingPallets.Location = new System.Drawing.Point(0, 156);
            this.fastPendingPallets.Margin = new System.Windows.Forms.Padding(2);
            this.fastPendingPallets.Name = "fastPendingPallets";
            this.fastPendingPallets.OwnerDraw = true;
            this.fastPendingPallets.ShowGroups = false;
            this.fastPendingPallets.ShowImagesOnSubItems = true;
            this.fastPendingPallets.Size = new System.Drawing.Size(1040, 200);
            this.fastPendingPallets.TabIndex = 69;
            this.fastPendingPallets.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingPallets.UseCompatibleStateImageBehavior = false;
            this.fastPendingPallets.UseFiltering = true;
            this.fastPendingPallets.View = System.Windows.Forms.View.Details;
            this.fastPendingPallets.VirtualMode = true;
            // 
            // olvPalletSelected
            // 
            this.olvPalletSelected.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletSelected.Sortable = false;
            this.olvPalletSelected.Text = "";
            this.olvPalletSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletSelected.Width = 20;
            // 
            // olvPalletGoodsIssueEntryDate
            // 
            this.olvPalletGoodsIssueEntryDate.AspectName = "GoodsIssueEntryDate";
            this.olvPalletGoodsIssueEntryDate.AspectToStringFormat = "{0:d}";
            this.olvPalletGoodsIssueEntryDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletGoodsIssueEntryDate.Text = "Issued Date";
            this.olvPalletGoodsIssueEntryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletGoodsIssueEntryDate.Width = 108;
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
            this.olvCommodityName.Width = 268;
            // 
            // olvPalletQuantity
            // 
            this.olvPalletQuantity.AspectName = "Quantity";
            this.olvPalletQuantity.AspectToStringFormat = "{0:#,#}";
            this.olvPalletQuantity.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPalletQuantity.Text = "Quantity";
            this.olvPalletQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPalletQuantity.Width = 80;
            // 
            // olvPalletLineVolume
            // 
            this.olvPalletLineVolume.AspectName = "LineVolume";
            this.olvPalletLineVolume.AspectToStringFormat = "{0:#,##0.00}";
            this.olvPalletLineVolume.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPalletLineVolume.Text = "Volume";
            this.olvPalletLineVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPalletLineVolume.Width = 90;
            // 
            // olvPalletCode
            // 
            this.olvPalletCode.AspectName = "PalletCode";
            this.olvPalletCode.FillsFreeSpace = true;
            this.olvPalletCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletCode.Text = "Pallet Code";
            this.olvPalletCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPalletCode.Width = 150;
            // 
            // panelMaster
            // 
            this.panelMaster.BackColor = System.Drawing.Color.Ivory;
            this.panelMaster.Controls.Add(this.fastPendingPallets);
            this.panelMaster.Controls.Add(this.fastPendingCartons);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Margin = new System.Windows.Forms.Padding(2);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.panelMaster.Size = new System.Drawing.Size(951, 445);
            this.panelMaster.TabIndex = 71;
            // 
            // fastPendingCartons
            // 
            this.fastPendingCartons.AllColumns.Add(this.olvCartonSelected);
            this.fastPendingCartons.AllColumns.Add(this.olvCartonGoodsIssueEntryDate);
            this.fastPendingCartons.AllColumns.Add(this.olvColumn4);
            this.fastPendingCartons.AllColumns.Add(this.olvColumn6);
            this.fastPendingCartons.AllColumns.Add(this.olvCartonQuantity);
            this.fastPendingCartons.AllColumns.Add(this.olvCartonLineVolume);
            this.fastPendingCartons.AllColumns.Add(this.olvCartonCode);
            this.fastPendingCartons.CheckBoxes = true;
            this.fastPendingCartons.CheckedAspectName = "IsSelected";
            this.fastPendingCartons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvCartonSelected,
            this.olvCartonGoodsIssueEntryDate,
            this.olvColumn4,
            this.olvColumn6,
            this.olvCartonQuantity,
            this.olvCartonLineVolume,
            this.olvCartonCode});
            this.fastPendingCartons.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingCartons.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingCartons.FullRowSelect = true;
            this.fastPendingCartons.HideSelection = false;
            this.fastPendingCartons.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingCartons.Location = new System.Drawing.Point(0, 42);
            this.fastPendingCartons.Margin = new System.Windows.Forms.Padding(2);
            this.fastPendingCartons.Name = "fastPendingCartons";
            this.fastPendingCartons.OwnerDraw = true;
            this.fastPendingCartons.ShowGroups = false;
            this.fastPendingCartons.ShowImagesOnSubItems = true;
            this.fastPendingCartons.Size = new System.Drawing.Size(1040, 200);
            this.fastPendingCartons.TabIndex = 70;
            this.fastPendingCartons.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingCartons.UseCompatibleStateImageBehavior = false;
            this.fastPendingCartons.UseFiltering = true;
            this.fastPendingCartons.View = System.Windows.Forms.View.Details;
            this.fastPendingCartons.VirtualMode = true;
            // 
            // olvCartonSelected
            // 
            this.olvCartonSelected.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonSelected.Sortable = false;
            this.olvCartonSelected.Text = "";
            this.olvCartonSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonSelected.Width = 20;
            // 
            // olvCartonGoodsIssueEntryDate
            // 
            this.olvCartonGoodsIssueEntryDate.AspectName = "GoodsIssueEntryDate";
            this.olvCartonGoodsIssueEntryDate.AspectToStringFormat = "{0:d}";
            this.olvCartonGoodsIssueEntryDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonGoodsIssueEntryDate.Text = "Issued Date";
            this.olvCartonGoodsIssueEntryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonGoodsIssueEntryDate.Width = 108;
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
            this.olvColumn6.Width = 268;
            // 
            // olvCartonQuantity
            // 
            this.olvCartonQuantity.AspectName = "Quantity";
            this.olvCartonQuantity.AspectToStringFormat = "{0:#,#}";
            this.olvCartonQuantity.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvCartonQuantity.Text = "Quantity";
            this.olvCartonQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvCartonQuantity.Width = 80;
            // 
            // olvCartonLineVolume
            // 
            this.olvCartonLineVolume.AspectName = "LineVolume";
            this.olvCartonLineVolume.AspectToStringFormat = "{0:#,##0.00}";
            this.olvCartonLineVolume.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvCartonLineVolume.Text = "Volume";
            this.olvCartonLineVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvCartonLineVolume.Width = 90;
            // 
            // olvCartonCode
            // 
            this.olvCartonCode.AspectName = "CartonCode";
            this.olvCartonCode.FillsFreeSpace = true;
            this.olvCartonCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonCode.Text = "Carton Code";
            this.olvCartonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCartonCode.Width = 150;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelBottomRight);
            this.panelBottom.Controls.Add(this.panelBottomLeft);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 445);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(951, 45);
            this.panelBottom.TabIndex = 72;
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.Controls.Add(this.toolStrip1);
            this.panelBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomRight.Location = new System.Drawing.Point(617, 0);
            this.panelBottomRight.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Size = new System.Drawing.Size(334, 45);
            this.panelBottomRight.TabIndex = 0;
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
            this.toolStrip1.Size = new System.Drawing.Size(334, 45);
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
            this.buttonESC.Size = new System.Drawing.Size(64, 42);
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
            this.buttonAddExit.Size = new System.Drawing.Size(120, 42);
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
            this.buttonAdd.Size = new System.Drawing.Size(65, 42);
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddESC_Click);
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.Controls.Add(this.layoutTop);
            this.panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.panelBottomLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.Size = new System.Drawing.Size(617, 45);
            this.panelBottomLeft.TabIndex = 1;
            // 
            // layoutTop
            // 
            this.layoutTop.AutoSize = true;
            this.layoutTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutTop.BackColor = System.Drawing.Color.Transparent;
            this.layoutTop.ColumnCount = 4;
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutTop.Controls.Add(this.toolStrip2, 0, 0);
            this.layoutTop.Controls.Add(this.dateTimexUpperFillterDate, 2, 0);
            this.layoutTop.Controls.Add(this.dateTimexLowerFillterDate, 3, 0);
            this.layoutTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.layoutTop.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutTop.Location = new System.Drawing.Point(0, 0);
            this.layoutTop.Margin = new System.Windows.Forms.Padding(0);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.layoutTop.RowCount = 1;
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.layoutTop.Size = new System.Drawing.Size(553, 45);
            this.layoutTop.TabIndex = 94;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.textexFilters,
            this.buttonClearFilters});
            this.toolStrip2.Location = new System.Drawing.Point(206, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip2.Size = new System.Drawing.Size(347, 39);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TotalSmartCoding.Properties.Resources.Zoom_seach;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Filters";
            // 
            // textexFilters
            // 
            this.textexFilters.AutoSize = false;
            this.textexFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textexFilters.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexFilters.Name = "textexFilters";
            this.textexFilters.Size = new System.Drawing.Size(270, 24);
            this.textexFilters.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textexFilters.TextChanged += new System.EventHandler(this.textexFilters_TextChanged);
            // 
            // buttonClearFilters
            // 
            this.buttonClearFilters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonClearFilters.Image = global::TotalSmartCoding.Properties.Resources.Edit_clear;
            this.buttonClearFilters.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonClearFilters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonClearFilters.Name = "buttonClearFilters";
            this.buttonClearFilters.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonClearFilters.Size = new System.Drawing.Size(36, 36);
            this.buttonClearFilters.Text = "Clear current filters";
            this.buttonClearFilters.Click += new System.EventHandler(this.buttonClearFilters_Click);
            // 
            // dateTimexUpperFillterDate
            // 
            this.dateTimexUpperFillterDate.CustomFormat = "dd/MMM/yyyy";
            this.dateTimexUpperFillterDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimexUpperFillterDate.Editable = true;
            this.dateTimexUpperFillterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimexUpperFillterDate.Location = new System.Drawing.Point(105, 8);
            this.dateTimexUpperFillterDate.Margin = new System.Windows.Forms.Padding(0, 8, 1, 1);
            this.dateTimexUpperFillterDate.Name = "dateTimexUpperFillterDate";
            this.dateTimexUpperFillterDate.ReadOnly = false;
            this.dateTimexUpperFillterDate.Size = new System.Drawing.Size(101, 24);
            this.dateTimexUpperFillterDate.TabIndex = 91;
            // 
            // dateTimexLowerFillterDate
            // 
            this.dateTimexLowerFillterDate.CustomFormat = "dd/MMM/yyyy";
            this.dateTimexLowerFillterDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimexLowerFillterDate.Editable = true;
            this.dateTimexLowerFillterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimexLowerFillterDate.Location = new System.Drawing.Point(3, 8);
            this.dateTimexLowerFillterDate.Margin = new System.Windows.Forms.Padding(0, 8, 3, 1);
            this.dateTimexLowerFillterDate.Name = "dateTimexLowerFillterDate";
            this.dateTimexLowerFillterDate.ReadOnly = false;
            this.dateTimexLowerFillterDate.Size = new System.Drawing.Size(101, 24);
            this.dateTimexLowerFillterDate.TabIndex = 90;
            // 
            // WizardDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 490);
            this.Controls.Add(this.panelMaster);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select and add items";
            this.Load += new System.EventHandler(this.WizardDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingPallets)).EndInit();
            this.panelMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingCartons)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottomRight.ResumeLayout(false);
            this.panelBottomRight.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottomLeft.ResumeLayout(false);
            this.panelBottomLeft.PerformLayout();
            this.layoutTop.ResumeLayout(false);
            this.layoutTop.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView fastPendingPallets;
        private System.Windows.Forms.Panel panelMaster;
        private BrightIdeasSoftware.OLVColumn olvCommodityCode;
        private BrightIdeasSoftware.OLVColumn olvPalletCode;
        private BrightIdeasSoftware.OLVColumn olvPalletSelected;
        private BrightIdeasSoftware.OLVColumn olvCommodityName;
        private BrightIdeasSoftware.FastObjectListView fastPendingCartons;
        private BrightIdeasSoftware.OLVColumn olvCartonSelected;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvCartonCode;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelBottomRight;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonAddExit;
        private System.Windows.Forms.ToolStripButton buttonAdd;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripTextBox textexFilters;
        private System.Windows.Forms.ToolStripButton buttonClearFilters;
        private BrightIdeasSoftware.OLVColumn olvPalletQuantity;
        private BrightIdeasSoftware.OLVColumn olvPalletLineVolume;
        private BrightIdeasSoftware.OLVColumn olvCartonQuantity;
        private BrightIdeasSoftware.OLVColumn olvCartonLineVolume;
        private System.Windows.Forms.TableLayoutPanel layoutTop;
        private CustomControls.DateTimexPicker dateTimexLowerFillterDate;
        private CustomControls.DateTimexPicker dateTimexUpperFillterDate;
        private BrightIdeasSoftware.OLVColumn olvPalletGoodsIssueEntryDate;
        private BrightIdeasSoftware.OLVColumn olvCartonGoodsIssueEntryDate;
    }
}