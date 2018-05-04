namespace TotalSmartCoding.Views.Mains
{
    partial class LockedDates
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
            this.buttonBackward = new System.Windows.Forms.ToolStripButton();
            this.buttonForward = new System.Windows.Forms.ToolStripButton();
            this.fastUserGroups = new BrightIdeasSoftware.FastObjectListView();
            this.olvID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUserGroupName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLockedDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonBackward,
            this.buttonForward});
            this.toolStrip1.Location = new System.Drawing.Point(0, 229);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(562, 39);
            this.toolStrip1.TabIndex = 100;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonBackward
            // 
            this.buttonBackward.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackward.Image = global::TotalSmartCoding.Properties.Resources.calendar_with_check_mark;
            this.buttonBackward.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonBackward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBackward.Name = "buttonBackward";
            this.buttonBackward.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonBackward.Size = new System.Drawing.Size(100, 36);
            this.buttonBackward.Text = "Remove";
            this.buttonBackward.Click += new System.EventHandler(this.buttonOKESC_Click);
            // 
            // buttonForward
            // 
            this.buttonForward.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonForward.Image = global::TotalSmartCoding.Properties.Resources.calendar_with_check_mark_G;
            this.buttonForward.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonForward.Size = new System.Drawing.Size(74, 36);
            this.buttonForward.Text = "Add";
            this.buttonForward.Click += new System.EventHandler(this.buttonOKESC_Click);
            // 
            // fastUserGroups
            // 
            this.fastUserGroups.AllColumns.Add(this.olvID);
            this.fastUserGroups.AllColumns.Add(this.olvUserGroupName);
            this.fastUserGroups.AllColumns.Add(this.olvLockedDate);
            this.fastUserGroups.BackColor = System.Drawing.Color.Ivory;
            this.fastUserGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvID,
            this.olvUserGroupName,
            this.olvLockedDate});
            this.fastUserGroups.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastUserGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastUserGroups.Font = new System.Drawing.Font("Calibri Light", 10.2F);
            this.fastUserGroups.FullRowSelect = true;
            this.fastUserGroups.HideSelection = false;
            this.fastUserGroups.HighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastUserGroups.Location = new System.Drawing.Point(0, 0);
            this.fastUserGroups.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastUserGroups.Name = "fastUserGroups";
            this.fastUserGroups.OwnerDraw = true;
            this.fastUserGroups.RowHeight = 36;
            this.fastUserGroups.ShowGroups = false;
            this.fastUserGroups.Size = new System.Drawing.Size(562, 229);
            this.fastUserGroups.TabIndex = 101;
            this.fastUserGroups.UnfocusedHighlightBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.fastUserGroups.UseCompatibleStateImageBehavior = false;
            this.fastUserGroups.UseFiltering = true;
            this.fastUserGroups.View = System.Windows.Forms.View.Details;
            this.fastUserGroups.VirtualMode = true;
            // 
            // olvID
            // 
            this.olvID.Text = "";
            this.olvID.Width = 20;
            // 
            // olvUserGroupName
            // 
            this.olvUserGroupName.AspectName = "Name";
            this.olvUserGroupName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvUserGroupName.Sortable = false;
            this.olvUserGroupName.Text = "Location";
            this.olvUserGroupName.Width = 168;
            // 
            // olvLockedDate
            // 
            this.olvLockedDate.AspectName = "LockedDate";
            this.olvLockedDate.FillsFreeSpace = true;
            this.olvLockedDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvLockedDate.Text = "Locked as at date";
            this.olvLockedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LockedDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 268);
            this.Controls.Add(this.fastUserGroups);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockedDates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage locked date for readonly";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastUserGroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonBackward;
        private System.Windows.Forms.ToolStripButton buttonForward;
        private BrightIdeasSoftware.FastObjectListView fastUserGroups;
        private BrightIdeasSoftware.OLVColumn olvID;
        private BrightIdeasSoftware.OLVColumn olvUserGroupName;
        private BrightIdeasSoftware.OLVColumn olvLockedDate;
    }
}