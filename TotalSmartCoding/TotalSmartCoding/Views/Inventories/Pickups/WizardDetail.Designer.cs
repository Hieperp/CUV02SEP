namespace TotalSmartCoding.Views.Inventories.Pickups
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonESC = new System.Windows.Forms.ToolStripButton();
            this.buttonAdd = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textexCode = new CustomControls.TextexBox();
            this.textexCommodityCodeAndName = new CustomControls.TextexBox();
            this.textexQuantity = new CustomControls.TextexBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProviderMaster = new System.Windows.Forms.ErrorProvider(this.components);
            this.fastBinLocations = new BrightIdeasSoftware.FastObjectListView();
            this.olvNo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.splitContainerCenter = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textexBinLocationCode = new CustomControls.TextexBox();
            this.textexLineVolume = new CustomControls.TextexBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastBinLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCenter)).BeginInit();
            this.splitContainerCenter.Panel1.SuspendLayout();
            this.splitContainerCenter.Panel2.SuspendLayout();
            this.splitContainerCenter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonESC,
            this.buttonAdd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 713);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(595, 52);
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
            this.buttonESC.Size = new System.Drawing.Size(73, 49);
            this.buttonESC.Text = "Close";
            this.buttonESC.Click += new System.EventHandler(this.buttonAddESC_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Image = global::TotalSmartCoding.Properties.Resources.export_arrow_48;
            this.buttonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAdd.Size = new System.Drawing.Size(247, 52);
            this.buttonAdd.Text = "Add this pallet to pickup list";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddESC_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(2, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 24);
            this.label2.TabIndex = 103;
            this.label2.Text = "Barcode";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(2, 50);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 24);
            this.label10.TabIndex = 95;
            this.label10.Text = "Item Description";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(1, 138);
            this.label9.Margin = new System.Windows.Forms.Padding(1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 28);
            this.label9.TabIndex = 101;
            this.label9.Text = "Bin Location";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textexCode
            // 
            this.textexCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCode.Editable = true;
            this.textexCode.Location = new System.Drawing.Point(180, 18);
            this.textexCode.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexCode.Name = "textexCode";
            this.textexCode.ReadOnly = true;
            this.textexCode.Size = new System.Drawing.Size(398, 28);
            this.textexCode.TabIndex = 104;
            // 
            // textexCommodityCodeAndName
            // 
            this.textexCommodityCodeAndName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexCommodityCodeAndName.Editable = true;
            this.textexCommodityCodeAndName.Location = new System.Drawing.Point(180, 48);
            this.textexCommodityCodeAndName.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexCommodityCodeAndName.Name = "textexCommodityCodeAndName";
            this.textexCommodityCodeAndName.ReadOnly = true;
            this.textexCommodityCodeAndName.Size = new System.Drawing.Size(398, 28);
            this.textexCommodityCodeAndName.TabIndex = 105;
            // 
            // textexQuantity
            // 
            this.textexQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexQuantity.Editable = true;
            this.textexQuantity.Location = new System.Drawing.Point(180, 78);
            this.textexQuantity.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexQuantity.Name = "textexQuantity";
            this.textexQuantity.ReadOnly = true;
            this.textexQuantity.Size = new System.Drawing.Size(398, 28);
            this.textexQuantity.TabIndex = 108;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(2, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 24);
            this.label4.TabIndex = 107;
            this.label4.Text = "Quantity";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // errorProviderMaster
            // 
            this.errorProviderMaster.ContainerControl = this;
            // 
            // fastBinLocations
            // 
            this.fastBinLocations.AllColumns.Add(this.olvNo);
            this.fastBinLocations.AllColumns.Add(this.olvCode);
            this.fastBinLocations.AllColumns.Add(this.olvQuantity);
            this.fastBinLocations.AllColumns.Add(this.olvType);
            this.fastBinLocations.CheckedAspectName = "";
            this.fastBinLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvNo,
            this.olvCode,
            this.olvQuantity,
            this.olvType});
            this.fastBinLocations.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastBinLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastBinLocations.FullRowSelect = true;
            this.fastBinLocations.HideSelection = false;
            this.fastBinLocations.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastBinLocations.HighlightForegroundColor = System.Drawing.Color.Black;
            this.fastBinLocations.Location = new System.Drawing.Point(0, 0);
            this.fastBinLocations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastBinLocations.Name = "fastBinLocations";
            this.fastBinLocations.OwnerDraw = true;
            this.fastBinLocations.RowHeight = 32;
            this.fastBinLocations.ShowGroups = false;
            this.fastBinLocations.ShowImagesOnSubItems = true;
            this.fastBinLocations.Size = new System.Drawing.Size(595, 181);
            this.fastBinLocations.TabIndex = 109;
            this.fastBinLocations.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastBinLocations.UseCompatibleStateImageBehavior = false;
            this.fastBinLocations.UseFiltering = true;
            this.fastBinLocations.View = System.Windows.Forms.View.Details;
            this.fastBinLocations.VirtualMode = true;
            this.fastBinLocations.SelectedIndexChanged += new System.EventHandler(this.fastBinLocations_SelectedIndexChanged);
            // 
            // olvNo
            // 
            this.olvNo.HeaderFont = new System.Drawing.Font("Niagara Engraved", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvNo.Text = "";
            this.olvNo.Width = 15;
            // 
            // olvCode
            // 
            this.olvCode.AspectName = "Code";
            this.olvCode.HeaderFont = new System.Drawing.Font("Niagara Engraved", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCode.Text = "Code";
            this.olvCode.Width = 200;
            // 
            // olvQuantity
            // 
            this.olvQuantity.AspectName = "";
            this.olvQuantity.HeaderFont = new System.Drawing.Font("Niagara Engraved", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvQuantity.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvQuantity.Text = "No of Pallets";
            this.olvQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvQuantity.Width = 160;
            // 
            // olvType
            // 
            this.olvType.AspectName = "";
            this.olvType.FillsFreeSpace = true;
            this.olvType.HeaderFont = new System.Drawing.Font("Niagara Engraved", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvType.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvType.Text = "Type";
            this.olvType.Width = 150;
            // 
            // splitContainerCenter
            // 
            this.splitContainerCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCenter.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerCenter.Name = "splitContainerCenter";
            this.splitContainerCenter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerCenter.Panel1
            // 
            this.splitContainerCenter.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainerCenter.Panel2
            // 
            this.splitContainerCenter.Panel2.Controls.Add(this.fastBinLocations);
            this.splitContainerCenter.Size = new System.Drawing.Size(595, 372);
            this.splitContainerCenter.SplitterDistance = 186;
            this.splitContainerCenter.SplitterWidth = 5;
            this.splitContainerCenter.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.84455F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.15545F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textexQuantity, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textexBinLocationCode, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textexCode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textexCommodityCodeAndName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textexLineVolume, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(595, 186);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textexBinLocationCode
            // 
            this.textexBinLocationCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexBinLocationCode.Editable = true;
            this.textexBinLocationCode.ForeColor = System.Drawing.Color.Firebrick;
            this.textexBinLocationCode.Location = new System.Drawing.Point(180, 138);
            this.textexBinLocationCode.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexBinLocationCode.Name = "textexBinLocationCode";
            this.textexBinLocationCode.ReadOnly = true;
            this.textexBinLocationCode.Size = new System.Drawing.Size(398, 28);
            this.textexBinLocationCode.TabIndex = 109;
            // 
            // textexLineVolume
            // 
            this.textexLineVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexLineVolume.Editable = true;
            this.textexLineVolume.Location = new System.Drawing.Point(180, 108);
            this.textexLineVolume.Margin = new System.Windows.Forms.Padding(2, 1, 1, 1);
            this.textexLineVolume.Name = "textexLineVolume";
            this.textexLineVolume.ReadOnly = true;
            this.textexLineVolume.Size = new System.Drawing.Size(398, 28);
            this.textexLineVolume.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(2, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 24);
            this.label3.TabIndex = 112;
            this.label3.Text = "Volume";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WizardDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 372);
            this.Controls.Add(this.splitContainerCenter);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please find a bin location for this pallet";
            this.Load += new System.EventHandler(this.WizardDetail_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastBinLocations)).EndInit();
            this.splitContainerCenter.Panel1.ResumeLayout(false);
            this.splitContainerCenter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCenter)).EndInit();
            this.splitContainerCenter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private CustomControls.TextexBox textexCode;
        private CustomControls.TextexBox textexCommodityCodeAndName;
        private CustomControls.TextexBox textexQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProviderMaster;
        private System.Windows.Forms.SplitContainer splitContainerCenter;
        private CustomControls.TextexBox textexBinLocationCode;
        private BrightIdeasSoftware.FastObjectListView fastBinLocations;
        private BrightIdeasSoftware.OLVColumn olvCode;
        private BrightIdeasSoftware.OLVColumn olvType;
        private BrightIdeasSoftware.OLVColumn olvQuantity;
        private BrightIdeasSoftware.OLVColumn olvNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.TextexBox textexLineVolume;
        private System.Windows.Forms.Label label3;
    }
}