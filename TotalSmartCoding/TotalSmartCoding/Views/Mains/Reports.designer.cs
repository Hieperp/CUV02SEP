namespace TotalSmartCoding.Views.Mains
{
    partial class Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.toolStripChildForm = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.comboLocationID = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonWarehouseJournals = new System.Windows.Forms.ToolStripButton();
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.treeWarehouseID = new BrightIdeasSoftware.DataTreeListView();
            this.treeCommodityID = new BrightIdeasSoftware.DataTreeListView();
            this.toolStripChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeWarehouseID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeCommodityID)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripChildForm
            // 
            this.toolStripChildForm.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripChildForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripChildForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.comboLocationID,
            this.toolStripSeparator3,
            this.buttonWarehouseJournals});
            this.toolStripChildForm.Location = new System.Drawing.Point(0, 0);
            this.toolStripChildForm.Name = "toolStripChildForm";
            this.toolStripChildForm.Size = new System.Drawing.Size(1531, 55);
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
            this.toolStripButton2.Size = new System.Drawing.Size(118, 52);
            this.toolStripButton2.Text = "Disconnect";
            this.toolStripButton2.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            this.toolStripSeparator1.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // comboLocationID
            // 
            this.comboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.comboLocationID.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLocationID.Name = "comboLocationID";
            this.comboLocationID.Size = new System.Drawing.Size(118, 55);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // buttonWarehouseJournals
            // 
            this.buttonWarehouseJournals.Image = global::TotalSmartCoding.Properties.Resources.Printer__1_;
            this.buttonWarehouseJournals.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonWarehouseJournals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonWarehouseJournals.Name = "buttonWarehouseJournals";
            this.buttonWarehouseJournals.Size = new System.Drawing.Size(237, 52);
            this.buttonWarehouseJournals.Text = "Preview warehouse journal";
            this.buttonWarehouseJournals.Click += new System.EventHandler(this.buttonWarehouseJournals_Click);
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
            this.imageList32.Images.SetKeyName(6, "Pallet-32-O");
            this.imageList32.Images.SetKeyName(7, "Carton-32");
            // 
            // treeWarehouseID
            // 
            this.treeWarehouseID.DataSource = null;
            this.treeWarehouseID.FullRowSelect = true;
            this.treeWarehouseID.Location = new System.Drawing.Point(22, 0);
            this.treeWarehouseID.Name = "treeWarehouseID";
            this.treeWarehouseID.OwnerDraw = true;
            this.treeWarehouseID.RootKeyValueString = "";
            this.treeWarehouseID.ShowGroups = false;
            this.treeWarehouseID.ShowKeyColumns = false;
            this.treeWarehouseID.Size = new System.Drawing.Size(551, 138);
            this.treeWarehouseID.TabIndex = 65;
            this.treeWarehouseID.UseCompatibleStateImageBehavior = false;
            this.treeWarehouseID.UseFilterIndicator = true;
            this.treeWarehouseID.UseFiltering = true;
            this.treeWarehouseID.View = System.Windows.Forms.View.Details;
            this.treeWarehouseID.VirtualMode = true;
            // 
            // treeCommodityID
            // 
            this.treeCommodityID.DataSource = null;
            this.treeCommodityID.FullRowSelect = true;
            this.treeCommodityID.Location = new System.Drawing.Point(22, 165);
            this.treeCommodityID.Name = "treeCommodityID";
            this.treeCommodityID.OwnerDraw = true;
            this.treeCommodityID.RootKeyValueString = "";
            this.treeCommodityID.ShowGroups = false;
            this.treeCommodityID.ShowKeyColumns = false;
            this.treeCommodityID.Size = new System.Drawing.Size(551, 138);
            this.treeCommodityID.TabIndex = 66;
            this.treeCommodityID.UseCompatibleStateImageBehavior = false;
            this.treeCommodityID.UseFilterIndicator = true;
            this.treeCommodityID.UseFiltering = true;
            this.treeCommodityID.View = System.Windows.Forms.View.Details;
            this.treeCommodityID.VirtualMode = true;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 654);
            this.Controls.Add(this.treeCommodityID);
            this.Controls.Add(this.treeWarehouseID);
            this.Controls.Add(this.toolStripChildForm);
            this.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Reports";
            this.Text = "Available Items";
            this.Controls.SetChildIndex(this.toolStripChildForm, 0);
            this.Controls.SetChildIndex(this.treeWarehouseID, 0);
            this.Controls.SetChildIndex(this.treeCommodityID, 0);
            this.toolStripChildForm.ResumeLayout(false);
            this.toolStripChildForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeWarehouseID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeCommodityID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripChildForm;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList imageList32;
        private System.Windows.Forms.ToolStripButton buttonWarehouseJournals;
        private System.Windows.Forms.ToolStripComboBox comboLocationID;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private BrightIdeasSoftware.DataTreeListView treeWarehouseID;
        private BrightIdeasSoftware.DataTreeListView treeCommodityID;

    }
}