﻿namespace TotalSmartCoding.Views.Commons.Employees
{
    partial class Employees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employees));
            this.textexCode = new CustomControls.TextexBox();
            this.combexTeamID = new CustomControls.CombexBox();
            this.toolStripChildForm = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.layoutTop = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimexBirthday = new CustomControls.DateTimexPicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textexAddress = new CustomControls.TextexBox();
            this.textexTitle = new CustomControls.TextexBox();
            this.textexTelephone = new CustomControls.TextexBox();
            this.textexName = new CustomControls.TextexBox();
            this.textexRemarks = new CustomControls.TextexBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.fastEmployeeIndex = new BrightIdeasSoftware.FastObjectListView();
            this.olvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBlank = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTeamCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvBirthday = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTelephone = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvInActive = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvRemarks = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripChildForm.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.layoutTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastEmployeeIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // textexCode
            // 
            this.textexCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCode.Editable = true;
            this.textexCode.Location = new System.Drawing.Point(28, 47);
            this.textexCode.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexCode.Name = "textexCode";
            this.textexCode.Size = new System.Drawing.Size(314, 28);
            this.textexCode.TabIndex = 81;
            // 
            // combexTeamID
            // 
            this.combexTeamID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexTeamID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexTeamID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexTeamID.Editable = true;
            this.combexTeamID.FormattingEnabled = true;
            this.combexTeamID.Location = new System.Drawing.Point(28, 169);
            this.combexTeamID.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.combexTeamID.Name = "combexTeamID";
            this.combexTeamID.ReadOnly = false;
            this.combexTeamID.Size = new System.Drawing.Size(314, 29);
            this.combexTeamID.TabIndex = 83;
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
            this.panelCenter.Controls.Add(this.layoutTop);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCenter.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelCenter.Location = new System.Drawing.Point(1163, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(368, 654);
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
            this.layoutTop.Controls.Add(this.dateTimexBirthday, 1, 10);
            this.layoutTop.Controls.Add(this.label1, 1, 16);
            this.layoutTop.Controls.Add(this.textexAddress, 1, 14);
            this.layoutTop.Controls.Add(this.textexTitle, 1, 8);
            this.layoutTop.Controls.Add(this.textexTelephone, 1, 12);
            this.layoutTop.Controls.Add(this.textexCode, 1, 2);
            this.layoutTop.Controls.Add(this.combexTeamID, 1, 6);
            this.layoutTop.Controls.Add(this.textexName, 1, 4);
            this.layoutTop.Controls.Add(this.textexRemarks, 1, 17);
            this.layoutTop.Controls.Add(this.label13, 1, 1);
            this.layoutTop.Controls.Add(this.label14, 1, 3);
            this.layoutTop.Controls.Add(this.label3, 1, 5);
            this.layoutTop.Controls.Add(this.label5, 1, 7);
            this.layoutTop.Controls.Add(this.label8, 1, 9);
            this.layoutTop.Controls.Add(this.label9, 1, 11);
            this.layoutTop.Controls.Add(this.label12, 1, 13);
            this.layoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutTop.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutTop.Location = new System.Drawing.Point(0, 0);
            this.layoutTop.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.RowCount = 18;
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
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.Size = new System.Drawing.Size(368, 654);
            this.layoutTop.TabIndex = 8;
            // 
            // dateTimexBirthday
            // 
            this.dateTimexBirthday.CustomFormat = "dd/MMM/yyyy";
            this.dateTimexBirthday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimexBirthday.Editable = true;
            this.dateTimexBirthday.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimexBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimexBirthday.Location = new System.Drawing.Point(28, 292);
            this.dateTimexBirthday.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.dateTimexBirthday.Name = "dateTimexBirthday";
            this.dateTimexBirthday.ReadOnly = false;
            this.dateTimexBirthday.Size = new System.Drawing.Size(314, 28);
            this.dateTimexBirthday.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(25, 443);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(318, 31);
            this.label1.TabIndex = 99;
            this.label1.Text = "Remarks";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textexAddress
            // 
            this.textexAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexAddress.Editable = true;
            this.textexAddress.Location = new System.Drawing.Point(28, 414);
            this.textexAddress.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexAddress.Name = "textexAddress";
            this.textexAddress.Size = new System.Drawing.Size(314, 28);
            this.textexAddress.TabIndex = 98;
            // 
            // textexTitle
            // 
            this.textexTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexTitle.Editable = true;
            this.textexTitle.Location = new System.Drawing.Point(28, 231);
            this.textexTitle.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexTitle.Name = "textexTitle";
            this.textexTitle.Size = new System.Drawing.Size(314, 28);
            this.textexTitle.TabIndex = 80;
            // 
            // textexTelephone
            // 
            this.textexTelephone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexTelephone.Editable = true;
            this.textexTelephone.Location = new System.Drawing.Point(28, 353);
            this.textexTelephone.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexTelephone.Name = "textexTelephone";
            this.textexTelephone.Size = new System.Drawing.Size(314, 28);
            this.textexTelephone.TabIndex = 82;
            // 
            // textexName
            // 
            this.textexName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexName.Editable = true;
            this.textexName.Location = new System.Drawing.Point(28, 108);
            this.textexName.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexName.Name = "textexName";
            this.textexName.Size = new System.Drawing.Size(314, 28);
            this.textexName.TabIndex = 86;
            // 
            // textexRemarks
            // 
            this.textexRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexRemarks.Editable = true;
            this.textexRemarks.Location = new System.Drawing.Point(28, 475);
            this.textexRemarks.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.textexRemarks.Name = "textexRemarks";
            this.textexRemarks.Size = new System.Drawing.Size(314, 28);
            this.textexRemarks.TabIndex = 88;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(25, 15);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label13.Size = new System.Drawing.Size(318, 31);
            this.label13.TabIndex = 96;
            this.label13.Text = "Code";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(25, 76);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label14.Size = new System.Drawing.Size(318, 31);
            this.label14.TabIndex = 97;
            this.label14.Text = "Description";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(25, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label3.Size = new System.Drawing.Size(318, 31);
            this.label3.TabIndex = 77;
            this.label3.Text = "Sales Team";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(25, 199);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label5.Size = new System.Drawing.Size(318, 31);
            this.label5.TabIndex = 89;
            this.label5.Text = "Title";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(25, 260);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label8.Size = new System.Drawing.Size(318, 31);
            this.label8.TabIndex = 90;
            this.label8.Text = "Birthday";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(25, 321);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label9.Size = new System.Drawing.Size(318, 31);
            this.label9.TabIndex = 91;
            this.label9.Text = "Telephone";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(25, 382);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label12.Size = new System.Drawing.Size(318, 31);
            this.label12.TabIndex = 94;
            this.label12.Text = "Address";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // fastEmployeeIndex
            // 
            this.fastEmployeeIndex.AllColumns.Add(this.olvID);
            this.fastEmployeeIndex.AllColumns.Add(this.olvBlank);
            this.fastEmployeeIndex.AllColumns.Add(this.olvTeamCode);
            this.fastEmployeeIndex.AllColumns.Add(this.olvCode);
            this.fastEmployeeIndex.AllColumns.Add(this.olvName);
            this.fastEmployeeIndex.AllColumns.Add(this.olvTitle);
            this.fastEmployeeIndex.AllColumns.Add(this.olvBirthday);
            this.fastEmployeeIndex.AllColumns.Add(this.olvTelephone);
            this.fastEmployeeIndex.AllColumns.Add(this.olvInActive);
            this.fastEmployeeIndex.AllColumns.Add(this.olvRemarks);
            this.fastEmployeeIndex.BackColor = System.Drawing.Color.Ivory;
            this.fastEmployeeIndex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvID,
            this.olvBlank,
            this.olvCode,
            this.olvName,
            this.olvTitle,
            this.olvBirthday,
            this.olvTelephone,
            this.olvInActive,
            this.olvRemarks});
            this.fastEmployeeIndex.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastEmployeeIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastEmployeeIndex.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.fastEmployeeIndex.FullRowSelect = true;
            this.fastEmployeeIndex.GroupImageList = this.imageList32;
            this.fastEmployeeIndex.HideSelection = false;
            this.fastEmployeeIndex.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastEmployeeIndex.Location = new System.Drawing.Point(0, 0);
            this.fastEmployeeIndex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastEmployeeIndex.Name = "fastEmployeeIndex";
            this.fastEmployeeIndex.OwnerDraw = true;
            this.fastEmployeeIndex.ShowGroups = false;
            this.fastEmployeeIndex.Size = new System.Drawing.Size(1163, 654);
            this.fastEmployeeIndex.TabIndex = 68;
            this.fastEmployeeIndex.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastEmployeeIndex.UseCompatibleStateImageBehavior = false;
            this.fastEmployeeIndex.UseFiltering = true;
            this.fastEmployeeIndex.View = System.Windows.Forms.View.Details;
            this.fastEmployeeIndex.VirtualMode = true;
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
            // olvTeamCode
            // 
            this.olvTeamCode.AspectName = "TeamCode";
            this.olvTeamCode.DisplayIndex = 2;
            this.olvTeamCode.IsVisible = false;
            this.olvTeamCode.Text = "Team";
            this.olvTeamCode.Width = 0;
            // 
            // olvCode
            // 
            this.olvCode.AspectName = "Code";
            this.olvCode.AspectToStringFormat = "";
            this.olvCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCode.Text = "Code";
            this.olvCode.Width = 120;
            // 
            // olvName
            // 
            this.olvName.AspectName = "Name";
            this.olvName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvName.Text = "Name";
            this.olvName.Width = 296;
            // 
            // olvTitle
            // 
            this.olvTitle.AspectName = "Title";
            this.olvTitle.Text = "Title";
            this.olvTitle.Width = 168;
            // 
            // olvBirthday
            // 
            this.olvBirthday.AspectName = "Birthday";
            this.olvBirthday.AspectToStringFormat = "{0:d}";
            this.olvBirthday.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBirthday.Text = "Birthday";
            this.olvBirthday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvBirthday.Width = 108;
            // 
            // olvTelephone
            // 
            this.olvTelephone.AspectName = "Telephone";
            this.olvTelephone.Text = "Telephone";
            this.olvTelephone.Width = 139;
            // 
            // olvInActive
            // 
            this.olvInActive.AspectName = "ImageID";
            this.olvInActive.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvInActive.Text = "";
            this.olvInActive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvInActive.Width = 30;
            // 
            // olvRemarks
            // 
            this.olvRemarks.AspectName = "Remarks";
            this.olvRemarks.FillsFreeSpace = true;
            this.olvRemarks.Text = "Remarks";
            this.olvRemarks.Width = 500;
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
            this.imageList32.Images.SetKeyName(9, "Employee-32");
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 654);
            this.Controls.Add(this.fastEmployeeIndex);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.toolStripChildForm);
            this.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Employees";
            this.Text = "Employees";
            this.Controls.SetChildIndex(this.toolStripChildForm, 0);
            this.Controls.SetChildIndex(this.panelCenter, 0);
            this.Controls.SetChildIndex(this.fastEmployeeIndex, 0);
            this.toolStripChildForm.ResumeLayout(false);
            this.toolStripChildForm.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            this.layoutTop.ResumeLayout(false);
            this.layoutTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastEmployeeIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutTop;
        private System.Windows.Forms.ToolStrip toolStripChildForm;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private BrightIdeasSoftware.FastObjectListView fastEmployeeIndex;
        private BrightIdeasSoftware.OLVColumn olvID;
        private BrightIdeasSoftware.OLVColumn olvCode;
        private BrightIdeasSoftware.OLVColumn olvName;
        private System.Windows.Forms.ImageList imageList32;
        private BrightIdeasSoftware.OLVColumn olvInActive;
        private BrightIdeasSoftware.OLVColumn olvTitle;
        private BrightIdeasSoftware.OLVColumn olvRemarks;
        private System.Windows.Forms.Label label3;
        private CustomControls.TextexBox textexTitle;
        private CustomControls.TextexBox textexTelephone;
        private CustomControls.TextexBox textexName;
        private CustomControls.TextexBox textexRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private CustomControls.TextexBox textexCode;
        private CustomControls.CombexBox combexTeamID;
        private System.Windows.Forms.Panel panelCenter;
        private BrightIdeasSoftware.OLVColumn olvBlank;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private CustomControls.TextexBox textexAddress;
        private CustomControls.DateTimexPicker dateTimexBirthday;
        private BrightIdeasSoftware.OLVColumn olvBirthday;
        private BrightIdeasSoftware.OLVColumn olvTelephone;
        private BrightIdeasSoftware.OLVColumn olvTeamCode;

    }
}