namespace TotalSmartCoding.Views.Mains
{
    partial class ConnectSQL
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
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.layoutTop = new System.Windows.Forms.TableLayoutPanel();
            this.labelApplicationUserName = new System.Windows.Forms.Label();
            this.labelApplicationUserPassword = new System.Windows.Forms.Label();
            this.textexApplicationUserName = new CustomControls.TextexBox();
            this.textexApplicationUserPassword = new CustomControls.TextexBox();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.ToolStripButton();
            this.buttonUpdate = new System.Windows.Forms.ToolStripButton();
            this.buttonApplicationUserIgnored = new System.Windows.Forms.ToolStripButton();
            this.buttonApplicationUserRequired = new System.Windows.Forms.ToolStripButton();
            this.panelBottom.SuspendLayout();
            this.panelBottomRight.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottomLeft.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.layoutTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelBottomRight);
            this.panelBottom.Controls.Add(this.panelBottomLeft);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 152);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(464, 42);
            this.panelBottom.TabIndex = 75;
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.Controls.Add(this.toolStrip1);
            this.panelBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomRight.Location = new System.Drawing.Point(143, 0);
            this.panelBottomRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Size = new System.Drawing.Size(321, 42);
            this.panelBottomRight.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonExit,
            this.buttonUpdate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(321, 42);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.Controls.Add(this.toolStrip2);
            this.panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.panelBottomLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.Size = new System.Drawing.Size(143, 42);
            this.panelBottomLeft.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonApplicationUserIgnored,
            this.buttonApplicationUserRequired});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip2.Size = new System.Drawing.Size(143, 42);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // layoutTop
            // 
            this.layoutTop.AutoSize = true;
            this.layoutTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutTop.BackColor = System.Drawing.SystemColors.Control;
            this.layoutTop.ColumnCount = 5;
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutTop.Controls.Add(this.labelApplicationUserName, 3, 1);
            this.layoutTop.Controls.Add(this.labelApplicationUserPassword, 3, 3);
            this.layoutTop.Controls.Add(this.pictureBoxIcon, 1, 1);
            this.layoutTop.Controls.Add(this.textexApplicationUserName, 3, 2);
            this.layoutTop.Controls.Add(this.textexApplicationUserPassword, 3, 4);
            this.layoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutTop.Location = new System.Drawing.Point(0, 0);
            this.layoutTop.Margin = new System.Windows.Forms.Padding(0);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.layoutTop.RowCount = 6;
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.layoutTop.Size = new System.Drawing.Size(464, 152);
            this.layoutTop.TabIndex = 104;
            // 
            // labelApplicationUserName
            // 
            this.labelApplicationUserName.AutoSize = true;
            this.labelApplicationUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelApplicationUserName.Location = new System.Drawing.Point(108, 27);
            this.labelApplicationUserName.Margin = new System.Windows.Forms.Padding(0);
            this.labelApplicationUserName.Name = "labelApplicationUserName";
            this.labelApplicationUserName.Size = new System.Drawing.Size(336, 15);
            this.labelApplicationUserName.TabIndex = 78;
            this.labelApplicationUserName.Text = "Login Name";
            this.labelApplicationUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelApplicationUserPassword
            // 
            this.labelApplicationUserPassword.AutoSize = true;
            this.labelApplicationUserPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelApplicationUserPassword.Location = new System.Drawing.Point(108, 77);
            this.labelApplicationUserPassword.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelApplicationUserPassword.Name = "labelApplicationUserPassword";
            this.labelApplicationUserPassword.Size = new System.Drawing.Size(336, 15);
            this.labelApplicationUserPassword.TabIndex = 83;
            this.labelApplicationUserPassword.Text = "Password";
            this.labelApplicationUserPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textexApplicationUserName
            // 
            this.textexApplicationUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexApplicationUserName.Editable = false;
            this.textexApplicationUserName.Location = new System.Drawing.Point(112, 43);
            this.textexApplicationUserName.Margin = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.textexApplicationUserName.Name = "textexApplicationUserName";
            this.textexApplicationUserName.Size = new System.Drawing.Size(331, 23);
            this.textexApplicationUserName.TabIndex = 88;
            this.textexApplicationUserName.TextChanged += new System.EventHandler(this.textexApplicationUser_TextChanged);
            // 
            // textexApplicationUserPassword
            // 
            this.textexApplicationUserPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexApplicationUserPassword.Editable = false;
            this.textexApplicationUserPassword.Location = new System.Drawing.Point(112, 93);
            this.textexApplicationUserPassword.Margin = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.textexApplicationUserPassword.Name = "textexApplicationUserPassword";
            this.textexApplicationUserPassword.PasswordChar = '*';
            this.textexApplicationUserPassword.Size = new System.Drawing.Size(331, 23);
            this.textexApplicationUserPassword.TabIndex = 89;
            this.textexApplicationUserPassword.TextChanged += new System.EventHandler(this.textexApplicationUser_TextChanged);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::TotalSmartCoding.Properties.Resources.f_key_icon_48;
            this.pictureBoxIcon.Location = new System.Drawing.Point(35, 27);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.layoutTop.SetRowSpan(this.pictureBoxIcon, 4);
            this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIcon.TabIndex = 11;
            this.pictureBoxIcon.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Image = global::TotalSmartCoding.Properties.Resources.LogoutApp;
            this.buttonExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonExit.Size = new System.Drawing.Size(61, 39);
            this.buttonExit.Text = "Exit";
            this.buttonExit.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Enabled = false;
            this.buttonUpdate.Image = global::TotalSmartCoding.Properties.Resources.User_Control_Update;
            this.buttonUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonUpdate.Size = new System.Drawing.Size(81, 39);
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonApplicationUserIgnored
            // 
            this.buttonApplicationUserIgnored.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonApplicationUserIgnored.Image = global::TotalSmartCoding.Properties.Resources.f_cross_icon;
            this.buttonApplicationUserIgnored.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonApplicationUserIgnored.Name = "buttonApplicationUserIgnored";
            this.buttonApplicationUserIgnored.Size = new System.Drawing.Size(24, 39);
            this.buttonApplicationUserIgnored.Text = "Ignore SQL login";
            this.buttonApplicationUserIgnored.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonApplicationUserRequired
            // 
            this.buttonApplicationUserRequired.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonApplicationUserRequired.Image = global::TotalSmartCoding.Properties.Resources.f_User_icon_24;
            this.buttonApplicationUserRequired.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonApplicationUserRequired.Name = "buttonApplicationUserRequired";
            this.buttonApplicationUserRequired.Size = new System.Drawing.Size(24, 39);
            this.buttonApplicationUserRequired.Text = "Use SQL login";
            this.buttonApplicationUserRequired.Click += new System.EventHandler(this.button_Click);
            // 
            // ConnectSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 194);
            this.ControlBox = false;
            this.Controls.Add(this.layoutTop);
            this.Controls.Add(this.panelBottom);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConnectSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Specify a SQL login name";
            this.Load += new System.EventHandler(this.ConnectSQL_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottomRight.ResumeLayout(false);
            this.panelBottomRight.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottomLeft.ResumeLayout(false);
            this.panelBottomLeft.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.layoutTop.ResumeLayout(false);
            this.layoutTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelBottomRight;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonExit;
        private System.Windows.Forms.ToolStripButton buttonUpdate;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.TableLayoutPanel layoutTop;
        private System.Windows.Forms.Label labelApplicationUserName;
        private System.Windows.Forms.Label labelApplicationUserPassword;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private CustomControls.TextexBox textexApplicationUserName;
        private CustomControls.TextexBox textexApplicationUserPassword;
        private System.Windows.Forms.ToolStripButton buttonApplicationUserRequired;
        private System.Windows.Forms.ToolStripButton buttonApplicationUserIgnored;
    }
}