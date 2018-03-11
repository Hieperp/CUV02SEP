namespace TotalSmartCoding.Views.Commons.CommoditySettings
{
    partial class CommoditySettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommoditySettings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripChildForm = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.layoutTop = new System.Windows.Forms.TableLayoutPanel();
            this.combexCommodityID = new CustomControls.CombexBox();
            this.textexCommodityCategoryName = new CustomControls.TextexBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textexRemarks = new CustomControls.TextexBox();
            this.textexPackageSize = new CustomControls.TextexBox();
            this.textexCommodityName = new CustomControls.TextexBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numericPackageVolume = new CustomControls.NumericBox();
            this.fastCommoditySettingIndex = new BrightIdeasSoftware.FastObjectListView();
            this.olvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBlank = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityCategoryName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPackageSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPackageVolume = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLowDSI1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvAlertDSI1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvHighDSI1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.gridexViewDetails = new CustomControls.DataGridexView();
            this.LocationID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LowDSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertDSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HighDSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripChildForm.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.layoutTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPackageVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastCommoditySettingIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridexViewDetails)).BeginInit();
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
            this.toolStripChildForm.Size = new System.Drawing.Size(1722, 51);
            this.toolStripChildForm.TabIndex = 29;
            this.toolStripChildForm.Text = "toolStrip1";
            this.toolStripChildForm.Visible = false;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(118, 48);
            this.toolStripButton2.Text = "Disconnect";
            this.toolStripButton2.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 51);
            this.toolStripSeparator1.Visible = false;
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.Ivory;
            this.panelCenter.BackgroundImage = global::TotalSmartCoding.Properties.Resources.Blue2010Large;
            this.panelCenter.Controls.Add(this.gridexViewDetails);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCenter.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelCenter.Location = new System.Drawing.Point(1500, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(368, 858);
            this.panelCenter.TabIndex = 76;
            // 
            // layoutTop
            // 
            this.layoutTop.AutoSize = true;
            this.layoutTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutTop.BackColor = System.Drawing.Color.Ivory;
            this.layoutTop.ColumnCount = 3;
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutTop.Controls.Add(this.combexCommodityID, 1, 2);
            this.layoutTop.Controls.Add(this.textexCommodityCategoryName, 1, 6);
            this.layoutTop.Controls.Add(this.label10, 1, 11);
            this.layoutTop.Controls.Add(this.textexRemarks, 1, 12);
            this.layoutTop.Controls.Add(this.textexPackageSize, 1, 8);
            this.layoutTop.Controls.Add(this.textexCommodityName, 1, 4);
            this.layoutTop.Controls.Add(this.label13, 1, 1);
            this.layoutTop.Controls.Add(this.label14, 1, 3);
            this.layoutTop.Controls.Add(this.label8, 1, 7);
            this.layoutTop.Controls.Add(this.label9, 1, 5);
            this.layoutTop.Controls.Add(this.label12, 1, 9);
            this.layoutTop.Controls.Add(this.numericPackageVolume, 1, 10);
            this.layoutTop.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutTop.Location = new System.Drawing.Point(1500, 0);
            this.layoutTop.Margin = new System.Windows.Forms.Padding(0);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.RowCount = 14;
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.Size = new System.Drawing.Size(633, 382);
            this.layoutTop.TabIndex = 8;
            // 
            // combexCommodityID
            // 
            this.combexCommodityID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexCommodityID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexCommodityID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexCommodityID.Editable = true;
            this.combexCommodityID.FormattingEnabled = true;
            this.combexCommodityID.Location = new System.Drawing.Point(28, 47);
            this.combexCommodityID.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.combexCommodityID.Name = "combexCommodityID";
            this.combexCommodityID.ReadOnly = false;
            this.combexCommodityID.Size = new System.Drawing.Size(579, 29);
            this.combexCommodityID.TabIndex = 107;
            // 
            // textexCommodityCategoryName
            // 
            this.textexCommodityCategoryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCommodityCategoryName.Editable = true;
            this.textexCommodityCategoryName.Location = new System.Drawing.Point(28, 170);
            this.textexCommodityCategoryName.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexCommodityCategoryName.Name = "textexCommodityCategoryName";
            this.textexCommodityCategoryName.Size = new System.Drawing.Size(579, 28);
            this.textexCommodityCategoryName.TabIndex = 106;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(25, 321);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label10.Size = new System.Drawing.Size(583, 31);
            this.label10.TabIndex = 97;
            this.label10.Text = "Remarks";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textexRemarks
            // 
            this.textexRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexRemarks.Editable = true;
            this.textexRemarks.Location = new System.Drawing.Point(28, 353);
            this.textexRemarks.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexRemarks.Name = "textexRemarks";
            this.textexRemarks.Size = new System.Drawing.Size(579, 28);
            this.textexRemarks.TabIndex = 88;
            // 
            // textexPackageSize
            // 
            this.textexPackageSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexPackageSize.Editable = true;
            this.textexPackageSize.Location = new System.Drawing.Point(28, 231);
            this.textexPackageSize.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexPackageSize.Name = "textexPackageSize";
            this.textexPackageSize.Size = new System.Drawing.Size(579, 28);
            this.textexPackageSize.TabIndex = 78;
            // 
            // textexCommodityName
            // 
            this.textexCommodityName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCommodityName.Editable = true;
            this.textexCommodityName.Location = new System.Drawing.Point(28, 109);
            this.textexCommodityName.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexCommodityName.Name = "textexCommodityName";
            this.textexCommodityName.Size = new System.Drawing.Size(579, 28);
            this.textexCommodityName.TabIndex = 86;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(25, 15);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label13.Size = new System.Drawing.Size(583, 31);
            this.label13.TabIndex = 96;
            this.label13.Text = "Code";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(25, 77);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label14.Size = new System.Drawing.Size(583, 31);
            this.label14.TabIndex = 97;
            this.label14.Text = "Name";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(25, 199);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label8.Size = new System.Drawing.Size(583, 31);
            this.label8.TabIndex = 90;
            this.label8.Text = "Package Size";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(25, 138);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label9.Size = new System.Drawing.Size(583, 31);
            this.label9.TabIndex = 91;
            this.label9.Text = "Category";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(25, 260);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label12.Size = new System.Drawing.Size(583, 31);
            this.label12.TabIndex = 94;
            this.label12.Text = "Package Volume";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // numericPackageVolume
            // 
            this.numericPackageVolume.DecimalPlaces = 2;
            this.numericPackageVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericPackageVolume.Editable = false;
            this.numericPackageVolume.Location = new System.Drawing.Point(28, 292);
            this.numericPackageVolume.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.numericPackageVolume.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericPackageVolume.Name = "numericPackageVolume";
            this.numericPackageVolume.Size = new System.Drawing.Size(579, 28);
            this.numericPackageVolume.TabIndex = 101;
            this.numericPackageVolume.ThousandsSeparator = true;
            // 
            // fastCommoditySettingIndex
            // 
            this.fastCommoditySettingIndex.AllColumns.Add(this.olvID);
            this.fastCommoditySettingIndex.AllColumns.Add(this.olvBlank);
            this.fastCommoditySettingIndex.AllColumns.Add(this.olvCommodityCategoryName);
            this.fastCommoditySettingIndex.AllColumns.Add(this.olvCommodityCode);
            this.fastCommoditySettingIndex.AllColumns.Add(this.olvCommodityName);
            this.fastCommoditySettingIndex.AllColumns.Add(this.olvPackageSize);
            this.fastCommoditySettingIndex.AllColumns.Add(this.olvPackageVolume);
            this.fastCommoditySettingIndex.AllColumns.Add(this.olvLowDSI1);
            this.fastCommoditySettingIndex.AllColumns.Add(this.olvAlertDSI1);
            this.fastCommoditySettingIndex.AllColumns.Add(this.olvHighDSI1);
            this.fastCommoditySettingIndex.BackColor = System.Drawing.Color.Ivory;
            this.fastCommoditySettingIndex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvID,
            this.olvBlank,
            this.olvCommodityCategoryName,
            this.olvCommodityCode,
            this.olvCommodityName,
            this.olvPackageSize,
            this.olvPackageVolume,
            this.olvLowDSI1,
            this.olvAlertDSI1,
            this.olvHighDSI1});
            this.fastCommoditySettingIndex.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastCommoditySettingIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastCommoditySettingIndex.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.fastCommoditySettingIndex.FullRowSelect = true;
            this.fastCommoditySettingIndex.GroupImageList = this.imageList32;
            this.fastCommoditySettingIndex.HideSelection = false;
            this.fastCommoditySettingIndex.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastCommoditySettingIndex.Location = new System.Drawing.Point(0, 0);
            this.fastCommoditySettingIndex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastCommoditySettingIndex.Name = "fastCommoditySettingIndex";
            this.fastCommoditySettingIndex.OwnerDraw = true;
            this.fastCommoditySettingIndex.ShowGroups = false;
            this.fastCommoditySettingIndex.Size = new System.Drawing.Size(1500, 858);
            this.fastCommoditySettingIndex.TabIndex = 68;
            this.fastCommoditySettingIndex.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastCommoditySettingIndex.UseCompatibleStateImageBehavior = false;
            this.fastCommoditySettingIndex.UseFiltering = true;
            this.fastCommoditySettingIndex.View = System.Windows.Forms.View.Details;
            this.fastCommoditySettingIndex.VirtualMode = true;
            // 
            // olvID
            // 
            this.olvID.Text = "";
            this.olvID.Width = 0;
            // 
            // olvBlank
            // 
            this.olvBlank.Text = "";
            this.olvBlank.Width = 15;
            // 
            // olvCommodityCategoryName
            // 
            this.olvCommodityCategoryName.AspectName = "CommodityCategoryName";
            this.olvCommodityCategoryName.Text = "Category";
            this.olvCommodityCategoryName.Width = 80;
            // 
            // olvCommodityCode
            // 
            this.olvCommodityCode.AspectName = "CommodityCode";
            this.olvCommodityCode.AspectToStringFormat = "";
            this.olvCommodityCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCommodityCode.Text = "Code";
            this.olvCommodityCode.Width = 100;
            // 
            // olvCommodityName
            // 
            this.olvCommodityName.AspectName = "CommodityName";
            this.olvCommodityName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCommodityName.Text = "Name";
            this.olvCommodityName.Width = 368;
            // 
            // olvPackageSize
            // 
            this.olvPackageSize.AspectName = "PackageSize";
            this.olvPackageSize.Text = "Package Size";
            this.olvPackageSize.Width = 110;
            // 
            // olvPackageVolume
            // 
            this.olvPackageVolume.AspectName = "PackageVolume";
            this.olvPackageVolume.AspectToStringFormat = "{0:#,##0.00}";
            this.olvPackageVolume.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPackageVolume.Text = "Volume";
            this.olvPackageVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvPackageVolume.Width = 70;
            // 
            // olvLowDSI1
            // 
            this.olvLowDSI1.AspectName = "LowDSI1";
            this.olvLowDSI1.AspectToStringFormat = "{0:#,#}";
            this.olvLowDSI1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvLowDSI1.Text = "Low DSI";
            this.olvLowDSI1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvLowDSI1.Width = 50;
            // 
            // olvAlertDSI1
            // 
            this.olvAlertDSI1.AspectName = "AlertDSI1";
            this.olvAlertDSI1.AspectToStringFormat = "{0:#,#}";
            this.olvAlertDSI1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvAlertDSI1.Text = "Alert DSI";
            this.olvAlertDSI1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvAlertDSI1.Width = 50;
            // 
            // olvHighDSI1
            // 
            this.olvHighDSI1.AspectName = "HighDSI1";
            this.olvHighDSI1.AspectToStringFormat = "{0:#,#}";
            this.olvHighDSI1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvHighDSI1.Text = "High DSI";
            this.olvHighDSI1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.imageList32.Images.SetKeyName(8, "CustomerRed");
            this.imageList32.Images.SetKeyName(9, "price-tag-32");
            // 
            // gridexViewDetails
            // 
            this.gridexViewDetails.AllowAddRow = true;
            this.gridexViewDetails.AllowDeleteRow = true;
            this.gridexViewDetails.BackgroundColor = System.Drawing.Color.Ivory;
            this.gridexViewDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridexViewDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridexViewDetails.ColumnHeadersHeight = 24;
            this.gridexViewDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocationID,
            this.LowDSI,
            this.AlertDSI,
            this.HighDSI});
            this.gridexViewDetails.Editable = true;
            this.gridexViewDetails.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.gridexViewDetails.Location = new System.Drawing.Point(6, 424);
            this.gridexViewDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridexViewDetails.Name = "gridexViewDetails";
            this.gridexViewDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridexViewDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridexViewDetails.RowTemplate.Height = 24;
            this.gridexViewDetails.Size = new System.Drawing.Size(350, 125);
            this.gridexViewDetails.TabIndex = 66;
            // 
            // LocationID
            // 
            this.LocationID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LocationID.DataPropertyName = "LocationID";
            this.LocationID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.LocationID.FillWeight = 9F;
            this.LocationID.HeaderText = "Location";
            this.LocationID.Name = "LocationID";
            this.LocationID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LocationID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LowDSI
            // 
            this.LowDSI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LowDSI.DataPropertyName = "LowDSI";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.LowDSI.DefaultCellStyle = dataGridViewCellStyle1;
            this.LowDSI.FillWeight = 7F;
            this.LowDSI.HeaderText = "Low DSI";
            this.LowDSI.Name = "LowDSI";
            // 
            // AlertDSI
            // 
            this.AlertDSI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AlertDSI.DataPropertyName = "AlertDSI";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.AlertDSI.DefaultCellStyle = dataGridViewCellStyle2;
            this.AlertDSI.FillWeight = 7F;
            this.AlertDSI.HeaderText = "Alert DSI";
            this.AlertDSI.Name = "AlertDSI";
            // 
            // HighDSI
            // 
            this.HighDSI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HighDSI.DataPropertyName = "HighDSI";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.HighDSI.DefaultCellStyle = dataGridViewCellStyle3;
            this.HighDSI.FillWeight = 7F;
            this.HighDSI.HeaderText = "High DSI";
            this.HighDSI.Name = "HighDSI";
            // 
            // CommoditySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1868, 858);
            this.Controls.Add(this.layoutTop);
            this.Controls.Add(this.fastCommoditySettingIndex);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.toolStripChildForm);
            this.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CommoditySettings";
            this.Text = "Low, High & Alert Settings";
            this.Controls.SetChildIndex(this.toolStripChildForm, 0);
            this.Controls.SetChildIndex(this.panelCenter, 0);
            this.Controls.SetChildIndex(this.fastCommoditySettingIndex, 0);
            this.Controls.SetChildIndex(this.layoutTop, 0);
            this.toolStripChildForm.ResumeLayout(false);
            this.toolStripChildForm.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.layoutTop.ResumeLayout(false);
            this.layoutTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPackageVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastCommoditySettingIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridexViewDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutTop;
        private System.Windows.Forms.ToolStrip toolStripChildForm;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private BrightIdeasSoftware.FastObjectListView fastCommoditySettingIndex;
        private BrightIdeasSoftware.OLVColumn olvID;
        private BrightIdeasSoftware.OLVColumn olvCommodityCode;
        private BrightIdeasSoftware.OLVColumn olvCommodityName;
        private System.Windows.Forms.ImageList imageList32;
        private BrightIdeasSoftware.OLVColumn olvCommodityCategoryName;
        private CustomControls.TextexBox textexPackageSize;
        private CustomControls.TextexBox textexCommodityName;
        private CustomControls.TextexBox textexRemarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panelCenter;
        private BrightIdeasSoftware.OLVColumn olvBlank;
        private System.Windows.Forms.Label label14;
        private CustomControls.NumericBox numericPackageVolume;
        private System.Windows.Forms.Label label10;
        private BrightIdeasSoftware.OLVColumn olvPackageSize;
        private BrightIdeasSoftware.OLVColumn olvPackageVolume;
        private BrightIdeasSoftware.OLVColumn olvLowDSI1;
        private BrightIdeasSoftware.OLVColumn olvAlertDSI1;
        private BrightIdeasSoftware.OLVColumn olvHighDSI1;
        private CustomControls.TextexBox textexCommodityCategoryName;
        private CustomControls.CombexBox combexCommodityID;
        private CustomControls.DataGridexView gridexViewDetails;
        private System.Windows.Forms.DataGridViewComboBoxColumn LocationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowDSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertDSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn HighDSI;

    }
}