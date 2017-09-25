﻿namespace TotalSmartCoding.Views.Inventories.Pickups
{
    partial class Pickups
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pickups));
            this.tableLayoutMaster = new System.Windows.Forms.TableLayoutPanel();
            this.textexRemarks = new CustomControls.TextexBox();
            this.textexDescription = new CustomControls.TextexBox();
            this.textexTotalLineVolume = new CustomControls.TextexBox();
            this.textexTotalQuantity = new CustomControls.TextexBox();
            this.textexTotalPalletCounts = new CustomControls.TextexBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.combexStorekeeperID = new CustomControls.CombexBox();
            this.combexForkliftDriverID = new CustomControls.CombexBox();
            this.textexReference = new CustomControls.TextexBox();
            this.dateTimexEntryDate = new CustomControls.DateTimexPicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textexWarehouseCode = new CustomControls.TextexBox();
            this.toolStripChildForm = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.naviDetails = new Guifreaks.Navisuite.NaviGroup(this.components);
            this.labelFillingLineName = new System.Windows.Forms.Label();
            this.gridexPalletDetails = new CustomControls.DataGridexView();
            this.CommodityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PalletCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BinLocationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastPickupIndex = new BrightIdeasSoftware.FastObjectListView();
            this.olvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvEntryDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvFillingLineNickName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvReference = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvApproved = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.naviPendingItems = new Guifreaks.Navisuite.NaviBar(this.components);
            this.naviPendingPallets = new Guifreaks.Navisuite.NaviBand(this.components);
            this.fastPendingPallets = new BrightIdeasSoftware.FastObjectListView();
            this.olvCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.naviPickupIndex = new Guifreaks.Navisuite.NaviBand(this.components);
            this.naviIndex = new Guifreaks.Navisuite.NaviBar(this.components);
            this.panelMaster = new System.Windows.Forms.Panel();
            this.imageList24 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutMaster.SuspendLayout();
            this.toolStripChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naviDetails)).BeginInit();
            this.naviDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridexPalletDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastPickupIndex)).BeginInit();
            this.naviPendingItems.SuspendLayout();
            this.naviPendingPallets.ClientArea.SuspendLayout();
            this.naviPendingPallets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingPallets)).BeginInit();
            this.naviPickupIndex.ClientArea.SuspendLayout();
            this.naviPickupIndex.SuspendLayout();
            this.naviIndex.SuspendLayout();
            this.panelMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMaster
            // 
            this.tableLayoutMaster.AutoSize = true;
            this.tableLayoutMaster.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutMaster.ColumnCount = 6;
            this.tableLayoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutMaster.Controls.Add(this.textexRemarks, 4, 5);
            this.tableLayoutMaster.Controls.Add(this.textexDescription, 4, 4);
            this.tableLayoutMaster.Controls.Add(this.textexTotalLineVolume, 4, 3);
            this.tableLayoutMaster.Controls.Add(this.textexTotalQuantity, 4, 2);
            this.tableLayoutMaster.Controls.Add(this.textexTotalPalletCounts, 4, 1);
            this.tableLayoutMaster.Controls.Add(this.label1, 3, 5);
            this.tableLayoutMaster.Controls.Add(this.label8, 3, 4);
            this.tableLayoutMaster.Controls.Add(this.label5, 3, 3);
            this.tableLayoutMaster.Controls.Add(this.label2, 3, 2);
            this.tableLayoutMaster.Controls.Add(this.label4, 3, 1);
            this.tableLayoutMaster.Controls.Add(this.combexStorekeeperID, 1, 5);
            this.tableLayoutMaster.Controls.Add(this.combexForkliftDriverID, 1, 4);
            this.tableLayoutMaster.Controls.Add(this.textexReference, 1, 2);
            this.tableLayoutMaster.Controls.Add(this.dateTimexEntryDate, 1, 1);
            this.tableLayoutMaster.Controls.Add(this.label9, 0, 5);
            this.tableLayoutMaster.Controls.Add(this.label3, 0, 4);
            this.tableLayoutMaster.Controls.Add(this.label10, 0, 3);
            this.tableLayoutMaster.Controls.Add(this.label7, 0, 2);
            this.tableLayoutMaster.Controls.Add(this.label6, 0, 1);
            this.tableLayoutMaster.Controls.Add(this.textexWarehouseCode, 1, 3);
            this.tableLayoutMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMaster.Location = new System.Drawing.Point(0, 53);
            this.tableLayoutMaster.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutMaster.Name = "tableLayoutMaster";
            this.tableLayoutMaster.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.tableLayoutMaster.RowCount = 7;
            this.tableLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMaster.Size = new System.Drawing.Size(1019, 262);
            this.tableLayoutMaster.TabIndex = 62;
            // 
            // textexRemarks
            // 
            this.textexRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexRemarks.Editable = true;
            this.textexRemarks.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.textexRemarks.Location = new System.Drawing.Point(685, 161);
            this.textexRemarks.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexRemarks.Name = "textexRemarks";
            this.textexRemarks.Size = new System.Drawing.Size(284, 36);
            this.textexRemarks.TabIndex = 84;
            // 
            // textexDescription
            // 
            this.textexDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexDescription.Editable = true;
            this.textexDescription.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.textexDescription.Location = new System.Drawing.Point(685, 122);
            this.textexDescription.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexDescription.Name = "textexDescription";
            this.textexDescription.Size = new System.Drawing.Size(284, 36);
            this.textexDescription.TabIndex = 83;
            // 
            // textexTotalLineVolume
            // 
            this.textexTotalLineVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexTotalLineVolume.Editable = false;
            this.textexTotalLineVolume.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.textexTotalLineVolume.Location = new System.Drawing.Point(685, 84);
            this.textexTotalLineVolume.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexTotalLineVolume.Name = "textexTotalLineVolume";
            this.textexTotalLineVolume.Size = new System.Drawing.Size(284, 36);
            this.textexTotalLineVolume.TabIndex = 82;
            this.textexTotalLineVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textexTotalQuantity
            // 
            this.textexTotalQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexTotalQuantity.Editable = false;
            this.textexTotalQuantity.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.textexTotalQuantity.Location = new System.Drawing.Point(685, 46);
            this.textexTotalQuantity.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexTotalQuantity.Name = "textexTotalQuantity";
            this.textexTotalQuantity.Size = new System.Drawing.Size(284, 36);
            this.textexTotalQuantity.TabIndex = 81;
            this.textexTotalQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textexTotalPalletCounts
            // 
            this.textexTotalPalletCounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexTotalPalletCounts.Editable = false;
            this.textexTotalPalletCounts.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.textexTotalPalletCounts.Location = new System.Drawing.Point(685, 8);
            this.textexTotalPalletCounts.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexTotalPalletCounts.Name = "textexTotalPalletCounts";
            this.textexTotalPalletCounts.Size = new System.Drawing.Size(284, 36);
            this.textexTotalPalletCounts.TabIndex = 80;
            this.textexTotalPalletCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.label1.Location = new System.Drawing.Point(493, 163);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 33);
            this.label1.TabIndex = 75;
            this.label1.Text = "Remark";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.label8.Location = new System.Drawing.Point(491, 122);
            this.label8.Margin = new System.Windows.Forms.Padding(1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 37);
            this.label8.TabIndex = 78;
            this.label8.Text = "Description";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.label5.Location = new System.Drawing.Point(491, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 36);
            this.label5.TabIndex = 77;
            this.label5.Text = "Total Volume";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.label2.Location = new System.Drawing.Point(493, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 32);
            this.label2.TabIndex = 56;
            this.label2.Text = "Total Quantity";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.label4.Location = new System.Drawing.Point(491, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 36);
            this.label4.TabIndex = 28;
            this.label4.Text = "Pallet Count";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // combexStorekeeperID
            // 
            this.combexStorekeeperID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexStorekeeperID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexStorekeeperID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexStorekeeperID.Editable = true;
            this.combexStorekeeperID.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.combexStorekeeperID.FormattingEnabled = true;
            this.combexStorekeeperID.Location = new System.Drawing.Point(195, 161);
            this.combexStorekeeperID.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.combexStorekeeperID.Name = "combexStorekeeperID";
            this.combexStorekeeperID.ReadOnly = false;
            this.combexStorekeeperID.Size = new System.Drawing.Size(284, 37);
            this.combexStorekeeperID.TabIndex = 74;
            // 
            // combexForkliftDriverID
            // 
            this.combexForkliftDriverID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexForkliftDriverID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexForkliftDriverID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexForkliftDriverID.Editable = true;
            this.combexForkliftDriverID.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.combexForkliftDriverID.FormattingEnabled = true;
            this.combexForkliftDriverID.Location = new System.Drawing.Point(195, 122);
            this.combexForkliftDriverID.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.combexForkliftDriverID.Name = "combexForkliftDriverID";
            this.combexForkliftDriverID.ReadOnly = false;
            this.combexForkliftDriverID.Size = new System.Drawing.Size(284, 37);
            this.combexForkliftDriverID.TabIndex = 73;
            // 
            // textexReference
            // 
            this.textexReference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexReference.Editable = false;
            this.textexReference.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.textexReference.Location = new System.Drawing.Point(195, 46);
            this.textexReference.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexReference.Name = "textexReference";
            this.textexReference.Size = new System.Drawing.Size(284, 36);
            this.textexReference.TabIndex = 71;
            // 
            // dateTimexEntryDate
            // 
            this.dateTimexEntryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimexEntryDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimexEntryDate.Editable = true;
            this.dateTimexEntryDate.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.dateTimexEntryDate.Location = new System.Drawing.Point(195, 8);
            this.dateTimexEntryDate.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.dateTimexEntryDate.Name = "dateTimexEntryDate";
            this.dateTimexEntryDate.ReadOnly = false;
            this.dateTimexEntryDate.Size = new System.Drawing.Size(284, 36);
            this.dateTimexEntryDate.TabIndex = 70;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.label9.Location = new System.Drawing.Point(1, 161);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 37);
            this.label9.TabIndex = 79;
            this.label9.Text = "Store Keeper";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.label3.Location = new System.Drawing.Point(3, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 33);
            this.label3.TabIndex = 76;
            this.label3.Text = "Forklift Driver";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.label10.Location = new System.Drawing.Point(3, 86);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 32);
            this.label10.TabIndex = 35;
            this.label10.Text = "Warehouse";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.label7.Location = new System.Drawing.Point(3, 48);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 32);
            this.label7.TabIndex = 31;
            this.label7.Text = "Reference";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Niagara Engraved", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 36);
            this.label6.TabIndex = 30;
            this.label6.Text = "Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textexWarehouseCode
            // 
            this.textexWarehouseCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexWarehouseCode.Editable = false;
            this.textexWarehouseCode.Font = new System.Drawing.Font("Niagara Engraved", 16.2F);
            this.textexWarehouseCode.Location = new System.Drawing.Point(195, 84);
            this.textexWarehouseCode.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexWarehouseCode.Name = "textexWarehouseCode";
            this.textexWarehouseCode.Size = new System.Drawing.Size(284, 36);
            this.textexWarehouseCode.TabIndex = 85;
            // 
            // toolStripChildForm
            // 
            this.toolStripChildForm.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripChildForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripChildForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStripChildForm.Location = new System.Drawing.Point(0, 0);
            this.toolStripChildForm.Name = "toolStripChildForm";
            this.toolStripChildForm.Size = new System.Drawing.Size(1837, 39);
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
            // naviDetails
            // 
            this.naviDetails.Caption = "   Pickup for";
            this.naviDetails.Controls.Add(this.labelFillingLineName);
            this.naviDetails.Controls.Add(this.tableLayoutMaster);
            this.naviDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.naviDetails.ExpandedHeight = 315;
            this.naviDetails.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naviDetails.HeaderContextMenuStrip = null;
            this.naviDetails.HeaderHeight = 51;
            this.naviDetails.Location = new System.Drawing.Point(295, 0);
            this.naviDetails.Name = "naviDetails";
            this.naviDetails.Padding = new System.Windows.Forms.Padding(0, 53, 0, 0);
            this.naviDetails.Size = new System.Drawing.Size(1019, 315);
            this.naviDetails.TabIndex = 30;
            // 
            // labelFillingLineName
            // 
            this.labelFillingLineName.AutoSize = true;
            this.labelFillingLineName.BackColor = System.Drawing.Color.Transparent;
            this.labelFillingLineName.ForeColor = System.Drawing.Color.Firebrick;
            this.labelFillingLineName.Location = new System.Drawing.Point(154, 9);
            this.labelFillingLineName.Name = "labelFillingLineName";
            this.labelFillingLineName.Size = new System.Drawing.Size(156, 33);
            this.labelFillingLineName.TabIndex = 63;
            this.labelFillingLineName.Text = "DRUM LINE";
            // 
            // gridexPalletDetails
            // 
            this.gridexPalletDetails.AllowAddRow = false;
            this.gridexPalletDetails.AllowDeleteRow = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridexPalletDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridexPalletDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridexPalletDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CommodityCode,
            this.PalletCode,
            this.BinLocationCode,
            this.Quantity,
            this.LineVolume});
            this.gridexPalletDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridexPalletDetails.Editable = false;
            this.gridexPalletDetails.Location = new System.Drawing.Point(0, 3);
            this.gridexPalletDetails.Name = "gridexPalletDetails";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridexPalletDetails.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridexPalletDetails.RowTemplate.Height = 45;
            this.gridexPalletDetails.Size = new System.Drawing.Size(1019, 477);
            this.gridexPalletDetails.TabIndex = 65;
            this.gridexPalletDetails.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridexPalletDetails_UserDeletedRow);
            // 
            // CommodityCode
            // 
            this.CommodityCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CommodityCode.DataPropertyName = "CommodityCode";
            this.CommodityCode.FillWeight = 14F;
            this.CommodityCode.HeaderText = "Item";
            this.CommodityCode.Name = "CommodityCode";
            // 
            // PalletCode
            // 
            this.PalletCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PalletCode.DataPropertyName = "PalletCode";
            this.PalletCode.FillWeight = 50F;
            this.PalletCode.HeaderText = "Pallet Code";
            this.PalletCode.Name = "PalletCode";
            // 
            // BinLocationCode
            // 
            this.BinLocationCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BinLocationCode.DataPropertyName = "BinLocationCode";
            this.BinLocationCode.FillWeight = 15F;
            this.BinLocationCode.HeaderText = "Location";
            this.BinLocationCode.Name = "BinLocationCode";
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.Quantity.FillWeight = 10F;
            this.Quantity.HeaderText = "Qty";
            this.Quantity.Name = "Quantity";
            // 
            // LineVolume
            // 
            this.LineVolume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LineVolume.DataPropertyName = "LineVolume";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LineVolume.DefaultCellStyle = dataGridViewCellStyle3;
            this.LineVolume.FillWeight = 11F;
            this.LineVolume.HeaderText = "Volume";
            this.LineVolume.Name = "LineVolume";
            // 
            // fastPickupIndex
            // 
            this.fastPickupIndex.AllColumns.Add(this.olvID);
            this.fastPickupIndex.AllColumns.Add(this.olvEntryDate);
            this.fastPickupIndex.AllColumns.Add(this.olvFillingLineNickName);
            this.fastPickupIndex.AllColumns.Add(this.olvReference);
            this.fastPickupIndex.AllColumns.Add(this.olvApproved);
            this.fastPickupIndex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvID,
            this.olvFillingLineNickName,
            this.olvReference,
            this.olvApproved});
            this.fastPickupIndex.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPickupIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastPickupIndex.Font = new System.Drawing.Font("Sitka Banner", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPickupIndex.FullRowSelect = true;
            this.fastPickupIndex.GroupImageList = this.imageList32;
            this.fastPickupIndex.HideSelection = false;
            this.fastPickupIndex.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPickupIndex.Location = new System.Drawing.Point(0, 0);
            this.fastPickupIndex.Name = "fastPickupIndex";
            this.fastPickupIndex.OwnerDraw = true;
            this.fastPickupIndex.RowHeight = 45;
            this.fastPickupIndex.ShowGroups = false;
            this.fastPickupIndex.Size = new System.Drawing.Size(293, 705);
            this.fastPickupIndex.TabIndex = 68;
            this.fastPickupIndex.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPickupIndex.UseCompatibleStateImageBehavior = false;
            this.fastPickupIndex.UseFiltering = true;
            this.fastPickupIndex.View = System.Windows.Forms.View.Details;
            this.fastPickupIndex.VirtualMode = true;
            // 
            // olvID
            // 
            this.olvID.Groupable = false;
            this.olvID.Text = "";
            this.olvID.Width = 0;
            // 
            // olvEntryDate
            // 
            this.olvEntryDate.AspectName = "EntryDate";
            this.olvEntryDate.AspectToStringFormat = "{0:d}";
            this.olvEntryDate.DisplayIndex = 1;
            this.olvEntryDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvEntryDate.IsVisible = false;
            this.olvEntryDate.Text = "Date";
            this.olvEntryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvEntryDate.Width = 10;
            // 
            // olvFillingLineNickName
            // 
            this.olvFillingLineNickName.AspectName = "FillingLineNickName";
            this.olvFillingLineNickName.Groupable = false;
            this.olvFillingLineNickName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvFillingLineNickName.Text = "";
            this.olvFillingLineNickName.Width = 85;
            // 
            // olvReference
            // 
            this.olvReference.AspectName = "Reference";
            this.olvReference.Groupable = false;
            this.olvReference.Text = "Pickups";
            this.olvReference.Width = 85;
            // 
            // olvApproved
            // 
            this.olvApproved.AspectName = "Approved";
            this.olvApproved.FillsFreeSpace = true;
            this.olvApproved.Groupable = false;
            this.olvApproved.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvApproved.Text = "";
            this.olvApproved.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvApproved.Width = 24;
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
            // 
            // naviPendingItems
            // 
            this.naviPendingItems.ActiveBand = this.naviPendingPallets;
            this.naviPendingItems.Controls.Add(this.naviPendingPallets);
            this.naviPendingItems.Dock = System.Windows.Forms.DockStyle.Right;
            this.naviPendingItems.Font = new System.Drawing.Font("Cambria", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naviPendingItems.HeaderHeight = 50;
            this.naviPendingItems.Location = new System.Drawing.Point(1314, 0);
            this.naviPendingItems.Name = "naviPendingItems";
            this.naviPendingItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.naviPendingItems.Size = new System.Drawing.Size(523, 795);
            this.naviPendingItems.TabIndex = 69;
            this.naviPendingItems.Text = "naviBar1";
            // 
            // naviPendingPallets
            // 
            // 
            // naviPendingPallets.ClientArea
            // 
            this.naviPendingPallets.ClientArea.Controls.Add(this.fastPendingPallets);
            this.naviPendingPallets.ClientArea.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner;
            this.naviPendingPallets.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviPendingPallets.ClientArea.Name = "ClientArea";
            this.naviPendingPallets.ClientArea.Size = new System.Drawing.Size(521, 705);
            this.naviPendingPallets.ClientArea.TabIndex = 0;
            this.naviPendingPallets.LargeImageIndex = 0;
            this.naviPendingPallets.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner;
            this.naviPendingPallets.Location = new System.Drawing.Point(1, 50);
            this.naviPendingPallets.Name = "naviPendingPallets";
            this.naviPendingPallets.Size = new System.Drawing.Size(521, 705);
            this.naviPendingPallets.SmallImageIndex = 0;
            this.naviPendingPallets.TabIndex = 3;
            // 
            // fastPendingPallets
            // 
            this.fastPendingPallets.AllColumns.Add(this.olvCode);
            this.fastPendingPallets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvCode});
            this.fastPendingPallets.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingPallets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastPendingPallets.Font = new System.Drawing.Font("Sitka Banner", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingPallets.FullRowSelect = true;
            this.fastPendingPallets.HideSelection = false;
            this.fastPendingPallets.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingPallets.Location = new System.Drawing.Point(0, 0);
            this.fastPendingPallets.Name = "fastPendingPallets";
            this.fastPendingPallets.OwnerDraw = true;
            this.fastPendingPallets.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fastPendingPallets.RowHeight = 45;
            this.fastPendingPallets.ShowGroups = false;
            this.fastPendingPallets.Size = new System.Drawing.Size(521, 705);
            this.fastPendingPallets.TabIndex = 69;
            this.fastPendingPallets.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingPallets.UseCompatibleStateImageBehavior = false;
            this.fastPendingPallets.UseFiltering = true;
            this.fastPendingPallets.View = System.Windows.Forms.View.Details;
            this.fastPendingPallets.VirtualMode = true;
            this.fastPendingPallets.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fastPendingPallets_MouseClick);
            // 
            // olvCode
            // 
            this.olvCode.AspectName = "Code";
            this.olvCode.FillsFreeSpace = true;
            this.olvCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCode.Text = "                         Pending Pallet";
            this.olvCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCode.Width = 400;
            // 
            // naviPickupIndex
            // 
            // 
            // naviPickupIndex.ClientArea
            // 
            this.naviPickupIndex.ClientArea.Controls.Add(this.fastPickupIndex);
            this.naviPickupIndex.ClientArea.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner;
            this.naviPickupIndex.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviPickupIndex.ClientArea.Name = "ClientArea";
            this.naviPickupIndex.ClientArea.Size = new System.Drawing.Size(293, 705);
            this.naviPickupIndex.ClientArea.TabIndex = 0;
            this.naviPickupIndex.LargeImageIndex = 0;
            this.naviPickupIndex.LayoutStyle = Guifreaks.Navisuite.NaviLayoutStyle.StyleFromOwner;
            this.naviPickupIndex.Location = new System.Drawing.Point(1, 50);
            this.naviPickupIndex.Name = "naviPickupIndex";
            this.naviPickupIndex.Size = new System.Drawing.Size(293, 705);
            this.naviPickupIndex.SmallImageIndex = 0;
            this.naviPickupIndex.TabIndex = 72;
            // 
            // naviIndex
            // 
            this.naviIndex.ActiveBand = this.naviPickupIndex;
            this.naviIndex.Controls.Add(this.naviPickupIndex);
            this.naviIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.naviIndex.HeaderHeight = 50;
            this.naviIndex.Location = new System.Drawing.Point(0, 0);
            this.naviIndex.Name = "naviIndex";
            this.naviIndex.Size = new System.Drawing.Size(295, 795);
            this.naviIndex.TabIndex = 71;
            this.naviIndex.Text = "naviBar2";
            // 
            // panelMaster
            // 
            this.panelMaster.BackColor = System.Drawing.SystemColors.Window;
            this.panelMaster.Controls.Add(this.gridexPalletDetails);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(295, 315);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panelMaster.Size = new System.Drawing.Size(1019, 480);
            this.panelMaster.TabIndex = 72;
            // 
            // imageList24
            // 
            this.imageList24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList24.ImageStream")));
            this.imageList24.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList24.Images.SetKeyName(0, "Placeholder");
            this.imageList24.Images.SetKeyName(1, "LocationPin");
            this.imageList24.Images.SetKeyName(2, "Flashing");
            // 
            // Pickups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1837, 795);
            this.Controls.Add(this.panelMaster);
            this.Controls.Add(this.naviDetails);
            this.Controls.Add(this.naviIndex);
            this.Controls.Add(this.naviPendingItems);
            this.Controls.Add(this.toolStripChildForm);
            this.Name = "Pickups";
            this.Text = "Pickups";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pickups_FormClosing);
            this.Controls.SetChildIndex(this.toolStripChildForm, 0);
            this.Controls.SetChildIndex(this.naviPendingItems, 0);
            this.Controls.SetChildIndex(this.naviIndex, 0);
            this.Controls.SetChildIndex(this.naviDetails, 0);
            this.Controls.SetChildIndex(this.panelMaster, 0);
            this.tableLayoutMaster.ResumeLayout(false);
            this.tableLayoutMaster.PerformLayout();
            this.toolStripChildForm.ResumeLayout(false);
            this.toolStripChildForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naviDetails)).EndInit();
            this.naviDetails.ResumeLayout(false);
            this.naviDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridexPalletDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastPickupIndex)).EndInit();
            this.naviPendingItems.ResumeLayout(false);
            this.naviPendingPallets.ClientArea.ResumeLayout(false);
            this.naviPendingPallets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingPallets)).EndInit();
            this.naviPickupIndex.ClientArea.ResumeLayout(false);
            this.naviPickupIndex.ResumeLayout(false);
            this.naviIndex.ResumeLayout(false);
            this.panelMaster.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMaster;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private Guifreaks.Navisuite.NaviGroup naviDetails;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStrip toolStripChildForm;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private CustomControls.DateTimexPicker dateTimexEntryDate;
        private BrightIdeasSoftware.FastObjectListView fastPickupIndex;
        private BrightIdeasSoftware.OLVColumn olvID;
        private BrightIdeasSoftware.OLVColumn olvEntryDate;
        private CustomControls.DataGridexView gridexPalletDetails;
        private Guifreaks.Navisuite.NaviBar naviPendingItems;
        private Guifreaks.Navisuite.NaviBar naviIndex;
        private System.Windows.Forms.Panel panelMaster;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private CustomControls.TextexBox textexReference;
        private CustomControls.CombexBox combexForkliftDriverID;
        private CustomControls.CombexBox combexStorekeeperID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private CustomControls.TextexBox textexTotalPalletCounts;
        private CustomControls.TextexBox textexTotalQuantity;
        private CustomControls.TextexBox textexTotalLineVolume;
        private CustomControls.TextexBox textexDescription;
        private CustomControls.TextexBox textexRemarks;
        private Guifreaks.Navisuite.NaviBand naviPickupIndex;
        private Guifreaks.Navisuite.NaviBand naviPendingPallets;
        private BrightIdeasSoftware.FastObjectListView fastPendingPallets;
        private BrightIdeasSoftware.OLVColumn olvCode;
        private CustomControls.TextexBox textexWarehouseCode;
        private System.Windows.Forms.Label labelFillingLineName;
        private BrightIdeasSoftware.OLVColumn olvReference;
        private System.Windows.Forms.ImageList imageList32;
        private System.Windows.Forms.ImageList imageList24;
        private BrightIdeasSoftware.OLVColumn olvApproved;
        private BrightIdeasSoftware.OLVColumn olvFillingLineNickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommodityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PalletCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BinLocationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineVolume;

    }
}