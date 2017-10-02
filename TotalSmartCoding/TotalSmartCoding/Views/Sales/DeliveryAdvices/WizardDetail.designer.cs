﻿namespace TotalSmartCoding.Views.Sales.DeliveryAdvices
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
            this.panelMaster = new System.Windows.Forms.Panel();
            this.fastPendingSalesOrderDetails = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn10 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPackCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn12 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip1.SuspendLayout();
            this.panelMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingSalesOrderDetails)).BeginInit();
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 548);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(1147, 55);
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
            this.buttonAddExit.Image = global::TotalSmartCoding.Properties.Resources.Add_continue;
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
            this.buttonAdd.Image = global::TotalSmartCoding.Properties.Resources.Add_close;
            this.buttonAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAdd.Size = new System.Drawing.Size(89, 52);
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddESC_Click);
            // 
            // panelMaster
            // 
            this.panelMaster.Controls.Add(this.fastPendingSalesOrderDetails);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panelMaster.Size = new System.Drawing.Size(1147, 548);
            this.panelMaster.TabIndex = 71;
            // 
            // fastPendingSalesOrderDetails
            // 
            this.fastPendingSalesOrderDetails.AllColumns.Add(this.olvColumn7);
            this.fastPendingSalesOrderDetails.AllColumns.Add(this.olvColumn8);
            this.fastPendingSalesOrderDetails.AllColumns.Add(this.olvColumn9);
            this.fastPendingSalesOrderDetails.AllColumns.Add(this.olvColumn10);
            this.fastPendingSalesOrderDetails.AllColumns.Add(this.olvPackCode);
            this.fastPendingSalesOrderDetails.AllColumns.Add(this.olvColumn12);
            this.fastPendingSalesOrderDetails.CheckBoxes = true;
            this.fastPendingSalesOrderDetails.CheckedAspectName = "IsSelected";
            this.fastPendingSalesOrderDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn7,
            this.olvColumn8,
            this.olvColumn9,
            this.olvColumn10,
            this.olvPackCode,
            this.olvColumn12});
            this.fastPendingSalesOrderDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastPendingSalesOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastPendingSalesOrderDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPendingSalesOrderDetails.FullRowSelect = true;
            this.fastPendingSalesOrderDetails.HideSelection = false;
            this.fastPendingSalesOrderDetails.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingSalesOrderDetails.Location = new System.Drawing.Point(0, 9);
            this.fastPendingSalesOrderDetails.Name = "fastPendingSalesOrderDetails";
            this.fastPendingSalesOrderDetails.OwnerDraw = true;
            this.fastPendingSalesOrderDetails.ShowGroups = false;
            this.fastPendingSalesOrderDetails.ShowImagesOnSubItems = true;
            this.fastPendingSalesOrderDetails.Size = new System.Drawing.Size(1147, 539);
            this.fastPendingSalesOrderDetails.TabIndex = 71;
            this.fastPendingSalesOrderDetails.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastPendingSalesOrderDetails.UseCompatibleStateImageBehavior = false;
            this.fastPendingSalesOrderDetails.UseFiltering = true;
            this.fastPendingSalesOrderDetails.View = System.Windows.Forms.View.Details;
            this.fastPendingSalesOrderDetails.VirtualMode = true;
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
            this.olvColumn8.AspectName = "PickupEntryDate";
            this.olvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Text = "Date";
            this.olvColumn8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Width = 170;
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "PickupReference";
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
            this.panelMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastPendingSalesOrderDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonAddExit;
        private System.Windows.Forms.Panel panelMaster;
        private BrightIdeasSoftware.FastObjectListView fastPendingSalesOrderDetails;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn olvColumn10;
        private BrightIdeasSoftware.OLVColumn olvPackCode;
        private BrightIdeasSoftware.OLVColumn olvColumn12;
        private System.Windows.Forms.ToolStripButton buttonAdd;
    }
}