namespace TotalSmartCoding.Views.Mains
{
    partial class UserControlRegister
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
            this.buttonOK = new System.Windows.Forms.ToolStripButton();
            this.layoutTop = new System.Windows.Forms.TableLayoutPanel();
            this.combexUserID = new CustomControls.CombexBox();
            this.combexOrganizationalUnitID = new CustomControls.CombexBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.layoutTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonESC,
            this.buttonOK});
            this.toolStrip1.Location = new System.Drawing.Point(0, 343);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(622, 39);
            this.toolStrip1.TabIndex = 100;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonESC
            // 
            this.buttonESC.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonESC.Image = global::TotalSmartCoding.Properties.Resources.signout_icon_24;
            this.buttonESC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonESC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonESC.Name = "buttonESC";
            this.buttonESC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonESC.Size = new System.Drawing.Size(74, 36);
            this.buttonESC.Text = "Cancel";
            this.buttonESC.Click += new System.EventHandler(this.buttonOKESC_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Image = global::TotalSmartCoding.Properties.Resources.Add_continue;
            this.buttonOK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonOK.Size = new System.Drawing.Size(90, 36);
            this.buttonOK.Text = "Register";
            this.buttonOK.Click += new System.EventHandler(this.buttonOKESC_Click);
            // 
            // layoutTop
            // 
            this.layoutTop.AutoSize = true;
            this.layoutTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutTop.BackColor = System.Drawing.SystemColors.Control;
            this.layoutTop.ColumnCount = 5;
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.layoutTop.Controls.Add(this.combexUserID, 3, 2);
            this.layoutTop.Controls.Add(this.combexOrganizationalUnitID, 3, 4);
            this.layoutTop.Controls.Add(this.pictureBox2, 1, 1);
            this.layoutTop.Controls.Add(this.label5, 3, 1);
            this.layoutTop.Controls.Add(this.label2, 3, 3);
            this.layoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutTop.Location = new System.Drawing.Point(0, 0);
            this.layoutTop.Margin = new System.Windows.Forms.Padding(0);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.layoutTop.RowCount = 9;
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutTop.Size = new System.Drawing.Size(622, 343);
            this.layoutTop.TabIndex = 101;
            // 
            // combexUserID
            // 
            this.combexUserID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexUserID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexUserID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexUserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combexUserID.Editable = true;
            this.combexUserID.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combexUserID.FormattingEnabled = true;
            this.combexUserID.Location = new System.Drawing.Point(84, 36);
            this.combexUserID.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.combexUserID.Name = "combexUserID";
            this.combexUserID.ReadOnly = false;
            this.combexUserID.Size = new System.Drawing.Size(522, 25);
            this.combexUserID.TabIndex = 1;
            // 
            // combexOrganizationalUnitID
            // 
            this.combexOrganizationalUnitID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexOrganizationalUnitID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexOrganizationalUnitID.BackColor = System.Drawing.SystemColors.Window;
            this.combexOrganizationalUnitID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexOrganizationalUnitID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combexOrganizationalUnitID.Editable = true;
            this.combexOrganizationalUnitID.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combexOrganizationalUnitID.FormattingEnabled = true;
            this.combexOrganizationalUnitID.Location = new System.Drawing.Point(84, 85);
            this.combexOrganizationalUnitID.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.combexOrganizationalUnitID.Name = "combexOrganizationalUnitID";
            this.combexOrganizationalUnitID.ReadOnly = false;
            this.combexOrganizationalUnitID.Size = new System.Drawing.Size(522, 25);
            this.combexOrganizationalUnitID.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TotalSmartCoding.Properties.Resources.add_user;
            this.pictureBox2.Location = new System.Drawing.Point(28, 20);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.layoutTop.SetRowSpan(this.pictureBox2, 4);
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 75;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 78;
            this.label5.Text = "User";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 83;
            this.label2.Text = "Organizational Unit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserControlRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 382);
            this.Controls.Add(this.layoutTop);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserControlRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register user from domain directory for new location";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.layoutTop.ResumeLayout(false);
            this.layoutTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonESC;
        private System.Windows.Forms.ToolStripButton buttonOK;
        private System.Windows.Forms.TableLayoutPanel layoutTop;
        private CustomControls.CombexBox combexUserID;
        private System.Windows.Forms.Label label5;
        private CustomControls.CombexBox combexOrganizationalUnitID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}