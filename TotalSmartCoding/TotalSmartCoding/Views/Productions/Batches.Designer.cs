namespace TotalSmartCoding.Views.Productions
{
    partial class Batches
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
            this.layoutMaster = new System.Windows.Forms.TableLayoutPanel();
            this.textexFinalCartonNo = new CustomControls.TextexBox();
            this.labelFinalCartonNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelNextPalletNo = new System.Windows.Forms.Label();
            this.labelNextCartonNo = new System.Windows.Forms.Label();
            this.labelNextPackNo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimexEntryDate = new CustomControls.DateTimexPicker();
            this.textexCode = new CustomControls.TextexBox();
            this.combexCommodityID = new CustomControls.CombexBox();
            this.textexCommodityName = new CustomControls.TextexBox();
            this.textexNextPackNo = new CustomControls.TextexBox();
            this.textexNextCartonNo = new CustomControls.TextexBox();
            this.textexNextPalletNo = new CustomControls.TextexBox();
            this.textexRemarks = new CustomControls.TextexBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textexCommodityAPICode = new CustomControls.TextexBox();
            this.checkAutoBarcode = new System.Windows.Forms.CheckBox();
            this.toolStripChildForm = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonApply = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonDiscontinued = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboDiscontinued = new System.Windows.Forms.ToolStripComboBox();
            this.naviBarMaster = new Guifreaks.Navisuite.NaviBar(this.components);
            this.naviBand1 = new Guifreaks.Navisuite.NaviBand(this.components);
            this.fastBatchIndex = new BrightIdeasSoftware.FastObjectListView();
            this.olvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvEntryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBatchCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityAPICode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCommodityName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvNextPackNo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvNextCartonNo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvNextPalletNo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvIsDefault = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.checkAutoCarton = new System.Windows.Forms.CheckBox();
            this.layoutMaster.SuspendLayout();
            this.toolStripChildForm.SuspendLayout();
            this.naviBarMaster.SuspendLayout();
            this.naviBand1.ClientArea.SuspendLayout();
            this.naviBand1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastBatchIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMaster
            // 
            this.layoutMaster.AutoSize = true;
            this.layoutMaster.BackColor = System.Drawing.Color.Ivory;
            this.layoutMaster.ColumnCount = 3;
            this.layoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.layoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.layoutMaster.Controls.Add(this.checkAutoCarton, 1, 21);
            this.layoutMaster.Controls.Add(this.textexFinalCartonNo, 1, 15);
            this.layoutMaster.Controls.Add(this.labelFinalCartonNo, 1, 14);
            this.layoutMaster.Controls.Add(this.label1, 1, 18);
            this.layoutMaster.Controls.Add(this.label6, 1, 0);
            this.layoutMaster.Controls.Add(this.label2, 1, 2);
            this.layoutMaster.Controls.Add(this.label14, 1, 4);
            this.layoutMaster.Controls.Add(this.labelNextPalletNo, 1, 16);
            this.layoutMaster.Controls.Add(this.labelNextCartonNo, 1, 12);
            this.layoutMaster.Controls.Add(this.labelNextPackNo, 1, 10);
            this.layoutMaster.Controls.Add(this.label8, 1, 8);
            this.layoutMaster.Controls.Add(this.dateTimexEntryDate, 1, 1);
            this.layoutMaster.Controls.Add(this.textexCode, 1, 3);
            this.layoutMaster.Controls.Add(this.combexCommodityID, 1, 5);
            this.layoutMaster.Controls.Add(this.textexCommodityName, 1, 9);
            this.layoutMaster.Controls.Add(this.textexNextPackNo, 1, 11);
            this.layoutMaster.Controls.Add(this.textexNextCartonNo, 1, 13);
            this.layoutMaster.Controls.Add(this.textexNextPalletNo, 1, 17);
            this.layoutMaster.Controls.Add(this.textexRemarks, 1, 19);
            this.layoutMaster.Controls.Add(this.label3, 1, 6);
            this.layoutMaster.Controls.Add(this.textexCommodityAPICode, 1, 7);
            this.layoutMaster.Controls.Add(this.checkAutoBarcode, 1, 20);
            this.layoutMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMaster.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.layoutMaster.Location = new System.Drawing.Point(0, 0);
            this.layoutMaster.Margin = new System.Windows.Forms.Padding(0);
            this.layoutMaster.Name = "layoutMaster";
            this.layoutMaster.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.layoutMaster.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.layoutMaster.RowCount = 22;
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMaster.Size = new System.Drawing.Size(274, 541);
            this.layoutMaster.TabIndex = 62;
            // 
            // textexFinalCartonNo
            // 
            this.textexFinalCartonNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexFinalCartonNo.Editable = true;
            this.textexFinalCartonNo.Location = new System.Drawing.Point(24, 396);
            this.textexFinalCartonNo.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexFinalCartonNo.Name = "textexFinalCartonNo";
            this.textexFinalCartonNo.Size = new System.Drawing.Size(230, 24);
            this.textexFinalCartonNo.TabIndex = 107;
            // 
            // labelFinalCartonNo
            // 
            this.labelFinalCartonNo.AutoSize = true;
            this.labelFinalCartonNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFinalCartonNo.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.labelFinalCartonNo.Location = new System.Drawing.Point(22, 377);
            this.labelFinalCartonNo.Margin = new System.Windows.Forms.Padding(0, 8, 1, 1);
            this.labelFinalCartonNo.Name = "labelFinalCartonNo";
            this.labelFinalCartonNo.Size = new System.Drawing.Size(232, 17);
            this.labelFinalCartonNo.TabIndex = 105;
            this.labelFinalCartonNo.Text = "Ending Carton";
            this.labelFinalCartonNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.label1.Location = new System.Drawing.Point(22, 481);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 8, 1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 17);
            this.label1.TabIndex = 57;
            this.label1.Text = "Remarks";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.label6.Location = new System.Drawing.Point(22, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 8, 1, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.label2.Location = new System.Drawing.Point(22, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 8, 1, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 17);
            this.label2.TabIndex = 58;
            this.label2.Text = "Batch Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.label14.Location = new System.Drawing.Point(22, 116);
            this.label14.Margin = new System.Windows.Forms.Padding(0, 8, 1, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(232, 17);
            this.label14.TabIndex = 51;
            this.label14.Text = "Item Code";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelNextPalletNo
            // 
            this.labelNextPalletNo.AutoSize = true;
            this.labelNextPalletNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNextPalletNo.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.labelNextPalletNo.Location = new System.Drawing.Point(22, 429);
            this.labelNextPalletNo.Margin = new System.Windows.Forms.Padding(0, 8, 1, 1);
            this.labelNextPalletNo.Name = "labelNextPalletNo";
            this.labelNextPalletNo.Size = new System.Drawing.Size(232, 17);
            this.labelNextPalletNo.TabIndex = 65;
            this.labelNextPalletNo.Text = "Next Pallet";
            this.labelNextPalletNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelNextCartonNo
            // 
            this.labelNextCartonNo.AutoSize = true;
            this.labelNextCartonNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNextCartonNo.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.labelNextCartonNo.Location = new System.Drawing.Point(22, 325);
            this.labelNextCartonNo.Margin = new System.Windows.Forms.Padding(0, 8, 1, 1);
            this.labelNextCartonNo.Name = "labelNextCartonNo";
            this.labelNextCartonNo.Size = new System.Drawing.Size(232, 17);
            this.labelNextCartonNo.TabIndex = 66;
            this.labelNextCartonNo.Text = "Next Carton";
            this.labelNextCartonNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelNextPackNo
            // 
            this.labelNextPackNo.AutoSize = true;
            this.labelNextPackNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNextPackNo.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.labelNextPackNo.Location = new System.Drawing.Point(22, 273);
            this.labelNextPackNo.Margin = new System.Windows.Forms.Padding(0, 8, 1, 1);
            this.labelNextPackNo.Name = "labelNextPackNo";
            this.labelNextPackNo.Size = new System.Drawing.Size(232, 17);
            this.labelNextPackNo.TabIndex = 67;
            this.labelNextPackNo.Text = "Next Pack";
            this.labelNextPackNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.label8.Location = new System.Drawing.Point(22, 221);
            this.label8.Margin = new System.Windows.Forms.Padding(0, 8, 1, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 17);
            this.label8.TabIndex = 68;
            this.label8.Text = "Item Name";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dateTimexEntryDate
            // 
            this.dateTimexEntryDate.CustomFormat = "dd/MMM/yyyy HH:mm:ss";
            this.dateTimexEntryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimexEntryDate.Editable = true;
            this.dateTimexEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimexEntryDate.Location = new System.Drawing.Point(24, 31);
            this.dateTimexEntryDate.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.dateTimexEntryDate.Name = "dateTimexEntryDate";
            this.dateTimexEntryDate.ReadOnly = false;
            this.dateTimexEntryDate.Size = new System.Drawing.Size(230, 24);
            this.dateTimexEntryDate.TabIndex = 69;
            // 
            // textexCode
            // 
            this.textexCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCode.Editable = true;
            this.textexCode.Location = new System.Drawing.Point(24, 83);
            this.textexCode.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexCode.Name = "textexCode";
            this.textexCode.Size = new System.Drawing.Size(230, 24);
            this.textexCode.TabIndex = 70;
            // 
            // combexCommodityID
            // 
            this.combexCommodityID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexCommodityID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexCommodityID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexCommodityID.Editable = true;
            this.combexCommodityID.FormattingEnabled = true;
            this.combexCommodityID.Location = new System.Drawing.Point(24, 135);
            this.combexCommodityID.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.combexCommodityID.Name = "combexCommodityID";
            this.combexCommodityID.ReadOnly = false;
            this.combexCommodityID.Size = new System.Drawing.Size(230, 25);
            this.combexCommodityID.TabIndex = 71;
            // 
            // textexCommodityName
            // 
            this.textexCommodityName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCommodityName.Editable = false;
            this.textexCommodityName.Location = new System.Drawing.Point(24, 240);
            this.textexCommodityName.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexCommodityName.Name = "textexCommodityName";
            this.textexCommodityName.Size = new System.Drawing.Size(230, 24);
            this.textexCommodityName.TabIndex = 72;
            // 
            // textexNextPackNo
            // 
            this.textexNextPackNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexNextPackNo.Editable = true;
            this.textexNextPackNo.Location = new System.Drawing.Point(24, 292);
            this.textexNextPackNo.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexNextPackNo.Name = "textexNextPackNo";
            this.textexNextPackNo.Size = new System.Drawing.Size(230, 24);
            this.textexNextPackNo.TabIndex = 73;
            // 
            // textexNextCartonNo
            // 
            this.textexNextCartonNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexNextCartonNo.Editable = true;
            this.textexNextCartonNo.Location = new System.Drawing.Point(24, 344);
            this.textexNextCartonNo.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexNextCartonNo.Name = "textexNextCartonNo";
            this.textexNextCartonNo.Size = new System.Drawing.Size(230, 24);
            this.textexNextCartonNo.TabIndex = 74;
            // 
            // textexNextPalletNo
            // 
            this.textexNextPalletNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexNextPalletNo.Editable = true;
            this.textexNextPalletNo.Location = new System.Drawing.Point(24, 448);
            this.textexNextPalletNo.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexNextPalletNo.Name = "textexNextPalletNo";
            this.textexNextPalletNo.Size = new System.Drawing.Size(230, 24);
            this.textexNextPalletNo.TabIndex = 75;
            // 
            // textexRemarks
            // 
            this.textexRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexRemarks.Editable = true;
            this.textexRemarks.Location = new System.Drawing.Point(24, 500);
            this.textexRemarks.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexRemarks.Name = "textexRemarks";
            this.textexRemarks.Size = new System.Drawing.Size(230, 24);
            this.textexRemarks.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.label3.Location = new System.Drawing.Point(22, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 8, 1, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 17);
            this.label3.TabIndex = 77;
            this.label3.Text = "API Code";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textexCommodityAPICode
            // 
            this.textexCommodityAPICode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCommodityAPICode.Editable = false;
            this.textexCommodityAPICode.Location = new System.Drawing.Point(24, 188);
            this.textexCommodityAPICode.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexCommodityAPICode.Name = "textexCommodityAPICode";
            this.textexCommodityAPICode.Size = new System.Drawing.Size(230, 24);
            this.textexCommodityAPICode.TabIndex = 78;
            // 
            // checkAutoBarcode
            // 
            this.checkAutoBarcode.AutoSize = true;
            this.checkAutoBarcode.Location = new System.Drawing.Point(24, 533);
            this.checkAutoBarcode.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.checkAutoBarcode.Name = "checkAutoBarcode";
            this.checkAutoBarcode.Size = new System.Drawing.Size(221, 21);
            this.checkAutoBarcode.TabIndex = 106;
            this.checkAutoBarcode.Text = "Auto barcode without print && scan";
            this.checkAutoBarcode.UseVisualStyleBackColor = true;
            // 
            // toolStripChildForm
            // 
            this.toolStripChildForm.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripChildForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripChildForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.buttonApply,
            this.toolStripSeparator2,
            this.buttonDiscontinued,
            this.toolStripLabel1,
            this.comboDiscontinued});
            this.toolStripChildForm.Location = new System.Drawing.Point(0, 0);
            this.toolStripChildForm.Name = "toolStripChildForm";
            this.toolStripChildForm.Size = new System.Drawing.Size(982, 45);
            this.toolStripChildForm.TabIndex = 29;
            this.toolStripChildForm.Text = "toolStrip1";
            this.toolStripChildForm.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // buttonApply
            // 
            this.buttonApply.Image = global::TotalSmartCoding.Properties.Resources.Play_Normal;
            this.buttonApply.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(171, 42);
            this.buttonApply.Text = "Applying for Production";
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
            // 
            // buttonDiscontinued
            // 
            this.buttonDiscontinued.Image = global::TotalSmartCoding.Properties.Resources.Stop_Disabled;
            this.buttonDiscontinued.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonDiscontinued.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDiscontinued.Name = "buttonDiscontinued";
            this.buttonDiscontinued.Size = new System.Drawing.Size(113, 42);
            this.buttonDiscontinued.Text = "Discontinued";
            this.buttonDiscontinued.Click += new System.EventHandler(this.buttonDiscontinued_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(25, 42);
            this.toolStripLabel1.Text = "      ";
            // 
            // comboDiscontinued
            // 
            this.comboDiscontinued.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDiscontinued.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.comboDiscontinued.Items.AddRange(new object[] {
            "Don\'t show discontinued batches",
            "Show discontinued batches"});
            this.comboDiscontinued.Name = "comboDiscontinued";
            this.comboDiscontinued.Size = new System.Drawing.Size(204, 45);
            this.comboDiscontinued.SelectedIndexChanged += new System.EventHandler(this.comboDiscontinued_SelectedIndexChanged);
            // 
            // naviBarMaster
            // 
            this.naviBarMaster.ActiveBand = this.naviBand1;
            this.naviBarMaster.Controls.Add(this.naviBand1);
            this.naviBarMaster.Dock = System.Windows.Forms.DockStyle.Right;
            this.naviBarMaster.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naviBarMaster.HeaderHeight = 0;
            this.naviBarMaster.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.Office2010Blue;
            this.naviBarMaster.Location = new System.Drawing.Point(681, 0);
            this.naviBarMaster.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.naviBarMaster.Name = "naviBarMaster";
            this.naviBarMaster.PopupMinWidth = 10;
            this.naviBarMaster.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.naviBarMaster.ShowCollapseButton = false;
            this.naviBarMaster.ShowMoreOptionsButton = false;
            this.naviBarMaster.Size = new System.Drawing.Size(276, 579);
            this.naviBarMaster.TabIndex = 66;
            // 
            // naviBand1
            // 
            // 
            // naviBand1.ClientArea
            // 
            this.naviBand1.ClientArea.Controls.Add(this.layoutMaster);
            this.naviBand1.ClientArea.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner;
            this.naviBand1.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand1.ClientArea.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.naviBand1.ClientArea.Name = "ClientArea";
            this.naviBand1.ClientArea.Size = new System.Drawing.Size(274, 541);
            this.naviBand1.ClientArea.TabIndex = 0;
            this.naviBand1.LargeImageIndex = 0;
            this.naviBand1.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner;
            this.naviBand1.Location = new System.Drawing.Point(1, 0);
            this.naviBand1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.naviBand1.Name = "naviBand1";
            this.naviBand1.Size = new System.Drawing.Size(274, 541);
            this.naviBand1.SmallImageIndex = 0;
            this.naviBand1.TabIndex = 70;
            // 
            // fastBatchIndex
            // 
            this.fastBatchIndex.AllColumns.Add(this.olvID);
            this.fastBatchIndex.AllColumns.Add(this.olvEntryDate);
            this.fastBatchIndex.AllColumns.Add(this.olvBatchCode);
            this.fastBatchIndex.AllColumns.Add(this.olvCommodityCode);
            this.fastBatchIndex.AllColumns.Add(this.olvCommodityAPICode);
            this.fastBatchIndex.AllColumns.Add(this.olvCommodityName);
            this.fastBatchIndex.AllColumns.Add(this.olvNextPackNo);
            this.fastBatchIndex.AllColumns.Add(this.olvNextCartonNo);
            this.fastBatchIndex.AllColumns.Add(this.olvNextPalletNo);
            this.fastBatchIndex.AllColumns.Add(this.olvIsDefault);
            this.fastBatchIndex.BackColor = System.Drawing.Color.Ivory;
            this.fastBatchIndex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvID,
            this.olvEntryDate,
            this.olvBatchCode,
            this.olvCommodityCode,
            this.olvCommodityAPICode,
            this.olvCommodityName,
            this.olvNextPackNo,
            this.olvNextCartonNo,
            this.olvNextPalletNo,
            this.olvIsDefault});
            this.fastBatchIndex.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastBatchIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastBatchIndex.FullRowSelect = true;
            this.fastBatchIndex.HideSelection = false;
            this.fastBatchIndex.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastBatchIndex.Location = new System.Drawing.Point(0, 0);
            this.fastBatchIndex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fastBatchIndex.Name = "fastBatchIndex";
            this.fastBatchIndex.OwnerDraw = true;
            this.fastBatchIndex.ShowGroups = false;
            this.fastBatchIndex.Size = new System.Drawing.Size(681, 579);
            this.fastBatchIndex.TabIndex = 67;
            this.fastBatchIndex.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastBatchIndex.UseCompatibleStateImageBehavior = false;
            this.fastBatchIndex.UseFiltering = true;
            this.fastBatchIndex.View = System.Windows.Forms.View.Details;
            this.fastBatchIndex.VirtualMode = true;
            this.fastBatchIndex.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.fastBatchIndex_FormatRow);
            // 
            // olvID
            // 
            this.olvID.Text = "";
            this.olvID.Width = 0;
            // 
            // olvEntryDate
            // 
            this.olvEntryDate.AspectName = "EntryDate";
            this.olvEntryDate.AspectToStringFormat = "{0:d}";
            this.olvEntryDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvEntryDate.Text = "Date";
            this.olvEntryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvEntryDate.Width = 86;
            // 
            // olvBatchCode
            // 
            this.olvBatchCode.AspectName = "BatchCode";
            this.olvBatchCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBatchCode.Text = "Batch #";
            this.olvBatchCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBatchCode.Width = 70;
            // 
            // olvCommodityCode
            // 
            this.olvCommodityCode.AspectName = "CommodityCode";
            this.olvCommodityCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCommodityCode.Text = "Item Code";
            this.olvCommodityCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCommodityCode.Width = 90;
            // 
            // olvCommodityAPICode
            // 
            this.olvCommodityAPICode.AspectName = "CommodityAPICode";
            this.olvCommodityAPICode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCommodityAPICode.Text = "API";
            this.olvCommodityAPICode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCommodityAPICode.Width = 50;
            // 
            // olvCommodityName
            // 
            this.olvCommodityName.AspectName = "CommodityName";
            this.olvCommodityName.Text = "Item Name";
            this.olvCommodityName.Width = 250;
            // 
            // olvNextPackNo
            // 
            this.olvNextPackNo.AspectName = "NextPackNo";
            this.olvNextPackNo.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextPackNo.Text = "Next Pack";
            this.olvNextPackNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextPackNo.Width = 80;
            // 
            // olvNextCartonNo
            // 
            this.olvNextCartonNo.AspectName = "NextCartonNo";
            this.olvNextCartonNo.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextCartonNo.Text = "Next Carton";
            this.olvNextCartonNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextCartonNo.Width = 80;
            // 
            // olvNextPalletNo
            // 
            this.olvNextPalletNo.AspectName = "NextPalletNo";
            this.olvNextPalletNo.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextPalletNo.Text = "Next Pallet";
            this.olvNextPalletNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvNextPalletNo.Width = 80;
            // 
            // olvIsDefault
            // 
            this.olvIsDefault.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsDefault.Text = "";
            this.olvIsDefault.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvIsDefault.Width = 24;
            // 
            // checkAutoCarton
            // 
            this.checkAutoCarton.AutoSize = true;
            this.checkAutoCarton.Location = new System.Drawing.Point(24, 564);
            this.checkAutoCarton.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.checkAutoCarton.Name = "checkAutoCarton";
            this.checkAutoCarton.Size = new System.Drawing.Size(148, 21);
            this.checkAutoCarton.TabIndex = 108;
            this.checkAutoCarton.Text = "Not print carton label";
            this.checkAutoCarton.UseVisualStyleBackColor = true;
            // 
            // Batches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 579);
            this.Controls.Add(this.fastBatchIndex);
            this.Controls.Add(this.naviBarMaster);
            this.Controls.Add(this.toolStripChildForm);
            this.Name = "Batches";
            this.Text = "Batches";
            this.Controls.SetChildIndex(this.toolStripChildForm, 0);
            this.Controls.SetChildIndex(this.naviBarMaster, 0);
            this.Controls.SetChildIndex(this.fastBatchIndex, 0);
            this.layoutMaster.ResumeLayout(false);
            this.layoutMaster.PerformLayout();
            this.toolStripChildForm.ResumeLayout(false);
            this.toolStripChildForm.PerformLayout();
            this.naviBarMaster.ResumeLayout(false);
            this.naviBand1.ClientArea.ResumeLayout(false);
            this.naviBand1.ClientArea.PerformLayout();
            this.naviBand1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastBatchIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutMaster;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStrip toolStripChildForm;
        private System.Windows.Forms.ToolStripButton buttonDiscontinued;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNextPalletNo;
        private System.Windows.Forms.Label labelNextCartonNo;
        private System.Windows.Forms.Label labelNextPackNo;
        private Guifreaks.Navisuite.NaviBar naviBarMaster;
        private System.Windows.Forms.Label label8;
        private Guifreaks.Navisuite.NaviBand naviBand1;
        private BrightIdeasSoftware.FastObjectListView fastBatchIndex;
        private BrightIdeasSoftware.OLVColumn olvBatchCode;
        private BrightIdeasSoftware.OLVColumn olvCommodityCode;
        private BrightIdeasSoftware.OLVColumn olvCommodityName;
        private BrightIdeasSoftware.OLVColumn olvNextPackNo;
        private BrightIdeasSoftware.OLVColumn olvNextCartonNo;
        private BrightIdeasSoftware.OLVColumn olvNextPalletNo;
        private BrightIdeasSoftware.OLVColumn olvID;
        private BrightIdeasSoftware.OLVColumn olvEntryDate;
        private BrightIdeasSoftware.OLVColumn olvIsDefault;
        private System.Windows.Forms.ToolStripComboBox comboDiscontinued;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private CustomControls.DateTimexPicker dateTimexEntryDate;
        private CustomControls.TextexBox textexCode;
        private CustomControls.CombexBox combexCommodityID;
        private CustomControls.TextexBox textexCommodityName;
        private CustomControls.TextexBox textexNextPackNo;
        private CustomControls.TextexBox textexNextCartonNo;
        private CustomControls.TextexBox textexNextPalletNo;
        private CustomControls.TextexBox textexRemarks;
        private System.Windows.Forms.Label label3;
        private CustomControls.TextexBox textexCommodityAPICode;
        private BrightIdeasSoftware.OLVColumn olvCommodityAPICode;
        private System.Windows.Forms.Label labelFinalCartonNo;
        private System.Windows.Forms.CheckBox checkAutoBarcode;
        private CustomControls.TextexBox textexFinalCartonNo;
        private System.Windows.Forms.CheckBox checkAutoCarton;

    }
}