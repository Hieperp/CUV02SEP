namespace TotalSmartCoding.Views.Commons.Customers
{
    partial class CustomerPopup
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelBottomRight = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonESC = new System.Windows.Forms.ToolStripButton();
            this.buttonOK = new System.Windows.Forms.ToolStripButton();
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.textexFilters = new System.Windows.Forms.ToolStripTextBox();
            this.buttonClearFilters = new System.Windows.Forms.ToolStripButton();
            this.fastCustomerBases = new BrightIdeasSoftware.FastObjectListView();
            this.olvCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvShippingAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelBottom.SuspendLayout();
            this.panelBottomRight.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottomLeft.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastCustomerBases)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelBottomRight);
            this.panelBottom.Controls.Add(this.panelBottomLeft);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 309);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(716, 45);
            this.panelBottom.TabIndex = 73;
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.Controls.Add(this.toolStrip1);
            this.panelBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomRight.Location = new System.Drawing.Point(462, 0);
            this.panelBottomRight.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Size = new System.Drawing.Size(254, 45);
            this.panelBottomRight.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonESC,
            this.buttonOK});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(254, 45);
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
            // 
            // buttonOK
            // 
            this.buttonOK.Image = global::TotalSmartCoding.Properties.Resources.Add_continue;
            this.buttonOK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonOK.Size = new System.Drawing.Size(58, 42);
            this.buttonOK.Text = "Ok";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.Controls.Add(this.toolStrip2);
            this.panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.panelBottomLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.Size = new System.Drawing.Size(462, 45);
            this.panelBottomLeft.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.textexFilters,
            this.buttonClearFilters});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip2.Size = new System.Drawing.Size(462, 45);
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
            this.toolStripButton1.Size = new System.Drawing.Size(36, 42);
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
            this.buttonClearFilters.Size = new System.Drawing.Size(36, 42);
            this.buttonClearFilters.Text = "Clear current filters";
            this.buttonClearFilters.Click += new System.EventHandler(this.buttonClearFilters_Click);
            // 
            // fastCustomerBases
            // 
            this.fastCustomerBases.AllColumns.Add(this.olvCode);
            this.fastCustomerBases.AllColumns.Add(this.olvName);
            this.fastCustomerBases.AllColumns.Add(this.olvShippingAddress);
            this.fastCustomerBases.CheckedAspectName = "";
            this.fastCustomerBases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvCode,
            this.olvName,
            this.olvShippingAddress});
            this.fastCustomerBases.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastCustomerBases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastCustomerBases.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastCustomerBases.FullRowSelect = true;
            this.fastCustomerBases.HideSelection = false;
            this.fastCustomerBases.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastCustomerBases.Location = new System.Drawing.Point(0, 0);
            this.fastCustomerBases.Margin = new System.Windows.Forms.Padding(2);
            this.fastCustomerBases.MultiSelect = false;
            this.fastCustomerBases.Name = "fastCustomerBases";
            this.fastCustomerBases.OwnerDraw = true;
            this.fastCustomerBases.ShowGroups = false;
            this.fastCustomerBases.ShowImagesOnSubItems = true;
            this.fastCustomerBases.Size = new System.Drawing.Size(716, 309);
            this.fastCustomerBases.TabIndex = 74;
            this.fastCustomerBases.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastCustomerBases.UseCompatibleStateImageBehavior = false;
            this.fastCustomerBases.UseFiltering = true;
            this.fastCustomerBases.View = System.Windows.Forms.View.Details;
            this.fastCustomerBases.VirtualMode = true;
            this.fastCustomerBases.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fastCustomerBases_MouseDoubleClick);
            // 
            // olvCode
            // 
            this.olvCode.AspectName = "Code";
            this.olvCode.Text = "Code";
            this.olvCode.Width = 90;
            // 
            // olvName
            // 
            this.olvName.AspectName = "Name";
            this.olvName.Text = "Name";
            this.olvName.Width = 207;
            // 
            // olvShippingAddress
            // 
            this.olvShippingAddress.AspectName = "ShippingAddress";
            this.olvShippingAddress.FillsFreeSpace = true;
            this.olvShippingAddress.Text = "Address";
            // 
            // CustomerPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 354);
            this.Controls.Add(this.fastCustomerBases);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.Load += new System.EventHandler(this.CustomerPopup_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottomRight.ResumeLayout(false);
            this.panelBottomRight.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottomLeft.ResumeLayout(false);
            this.panelBottomLeft.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastCustomerBases)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelBottomRight;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonOK;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripTextBox textexFilters;
        private System.Windows.Forms.ToolStripButton buttonClearFilters;
        private BrightIdeasSoftware.FastObjectListView fastCustomerBases;
        private BrightIdeasSoftware.OLVColumn olvCode;
        private BrightIdeasSoftware.OLVColumn olvName;
        private BrightIdeasSoftware.OLVColumn olvShippingAddress;

    }
}