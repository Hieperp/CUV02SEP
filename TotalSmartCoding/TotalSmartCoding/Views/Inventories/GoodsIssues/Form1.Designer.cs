namespace TotalSmartCoding.Views.Inventories.GoodsIssues
{
    partial class Form1
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
            this.fastPendingPacks = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn10 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPackCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn12 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingPacks)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonESC,
            this.buttonAddExit,
            this.buttonAdd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 559);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(899, 55);
            this.toolStrip1.TabIndex = 1;
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
            this.buttonESC.Size = new System.Drawing.Size(73, 52);
            this.buttonESC.Text = "Close";
            // 
            // buttonAddExit
            // 
            this.buttonAddExit.Image = global::TotalSmartCoding.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_go_next_view;
            this.buttonAddExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonAddExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddExit.Name = "buttonAddExit";
            this.buttonAddExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAddExit.Size = new System.Drawing.Size(158, 52);
            this.buttonAddExit.Text = "Add and Close";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::TotalSmartCoding.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_go_previous_view;
            this.buttonAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAdd.Size = new System.Drawing.Size(89, 52);
            this.buttonAdd.Text = "Add";
            // 
            // fastPendingPacks
            // 
            this.fastPendingPacks.AllColumns.Add(this.olvColumn7);
            this.fastPendingPacks.AllColumns.Add(this.olvColumn8);
            this.fastPendingPacks.AllColumns.Add(this.olvColumn9);
            this.fastPendingPacks.AllColumns.Add(this.olvColumn10);
            this.fastPendingPacks.AllColumns.Add(this.olvPackCode);
            this.fastPendingPacks.AllColumns.Add(this.olvColumn12);
            this.fastPendingPacks.CheckBoxes = true;
            this.fastPendingPacks.CheckedAspectName = "IsSelected";
            this.fastPendingPacks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn7,
            this.olvColumn8,
            this.olvColumn9,
            this.olvColumn10,
            this.olvPackCode,
            this.olvColumn12});
            this.fastPendingPacks.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingPacks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastPendingPacks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingPacks.FullRowSelect = true;
            this.fastPendingPacks.HideSelection = false;
            this.fastPendingPacks.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingPacks.Location = new System.Drawing.Point(0, 0);
            this.fastPendingPacks.Name = "fastPendingPacks";
            this.fastPendingPacks.OwnerDraw = true;
            this.fastPendingPacks.ShowGroups = false;
            this.fastPendingPacks.ShowImagesOnSubItems = true;
            this.fastPendingPacks.Size = new System.Drawing.Size(899, 614);
            this.fastPendingPacks.TabIndex = 72;
            this.fastPendingPacks.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingPacks.UseCompatibleStateImageBehavior = false;
            this.fastPendingPacks.UseFiltering = true;
            this.fastPendingPacks.View = System.Windows.Forms.View.Details;
            this.fastPendingPacks.VirtualMode = true;
            // 
            // olvColumn7
            // 
            this.olvColumn7.HeaderCheckBox = true;
            this.olvColumn7.HeaderCheckState = System.Windows.Forms.CheckState.Checked;
            this.olvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn7.Text = "";
            this.olvColumn7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn7.Width = 20;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "DeliveryAdviceEntryDate";
            this.olvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Text = "Date";
            this.olvColumn8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Width = 170;
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "DeliveryAdviceReference";
            this.olvColumn9.Text = "Reference";
            this.olvColumn9.Width = 137;
            // 
            // olvColumn10
            // 
            this.olvColumn10.AspectName = "CommodityCode";
            this.olvColumn10.Text = "Item";
            this.olvColumn10.Width = 192;
            // 
            // olvPackCode
            // 
            this.olvPackCode.AspectName = "PackCode";
            this.olvPackCode.FillsFreeSpace = true;
            this.olvPackCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPackCode.Text = "Pack Code";
            this.olvPackCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvPackCode.Width = 200;
            // 
            // olvColumn12
            // 
            this.olvColumn12.AspectName = "CommodityName";
            this.olvColumn12.FillsFreeSpace = true;
            this.olvColumn12.Text = "Item Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 614);
            this.Controls.Add(this.fastPendingPacks);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingPacks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonAddExit;
        private System.Windows.Forms.ToolStripButton buttonAdd;
        private BrightIdeasSoftware.FastObjectListView fastPendingPacks;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn olvColumn10;
        private BrightIdeasSoftware.OLVColumn olvPackCode;
        private BrightIdeasSoftware.OLVColumn olvColumn12;
    }
}