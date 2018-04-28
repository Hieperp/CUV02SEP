namespace TotalSmartCoding.Views.Mains
{
    partial class ConnectServer
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
            this.buttonExit = new System.Windows.Forms.ToolStripButton();
            this.buttonConnect = new System.Windows.Forms.ToolStripButton();
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.buttonLoginRestore = new System.Windows.Forms.ToolStripButton();
            this.buttonDownload = new System.Windows.Forms.ToolStripButton();
            this.layoutTop = new System.Windows.Forms.TableLayoutPanel();
            this.labelSecurityIdentifier = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.textexApplicationRoleName = new CustomControls.TextexBox();
            this.textexApplicationRolePassword = new CustomControls.TextexBox();
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
            this.panelBottom.Location = new System.Drawing.Point(0, 175);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(618, 55);
            this.panelBottom.TabIndex = 75;
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.Controls.Add(this.toolStrip1);
            this.panelBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomRight.Location = new System.Drawing.Point(143, 0);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Size = new System.Drawing.Size(475, 55);
            this.panelBottomRight.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonExit,
            this.buttonConnect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(475, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonExit
            // 
            this.buttonExit.Image = global::TotalSmartCoding.Properties.Resources.signout_icon_24;
            this.buttonExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonExit.Size = new System.Drawing.Size(61, 52);
            this.buttonExit.Text = "Exit";
            this.buttonExit.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Image = global::TotalSmartCoding.Properties.Resources.Login;
            this.buttonConnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonConnect.Size = new System.Drawing.Size(115, 52);
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.Controls.Add(this.toolStrip2);
            this.panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.Size = new System.Drawing.Size(143, 55);
            this.panelBottomLeft.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonLoginRestore,
            this.buttonDownload});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip2.Size = new System.Drawing.Size(143, 55);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // buttonLoginRestore
            // 
            this.buttonLoginRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLoginRestore.Image = global::TotalSmartCoding.Properties.Resources.Settings;
            this.buttonLoginRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLoginRestore.Name = "buttonLoginRestore";
            this.buttonLoginRestore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonLoginRestore.Size = new System.Drawing.Size(24, 52);
            this.buttonLoginRestore.Text = "Manual restore stored procedures and update new version";
            this.buttonLoginRestore.Visible = false;
            // 
            // buttonDownload
            // 
            this.buttonDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDownload.Image = global::TotalSmartCoding.Properties.Resources.Download;
            this.buttonDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(24, 52);
            this.buttonDownload.Text = "Download latest version";
            this.buttonDownload.Visible = false;
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
            this.layoutTop.Controls.Add(this.labelSecurityIdentifier, 3, 1);
            this.layoutTop.Controls.Add(this.labelUserID, 3, 3);
            this.layoutTop.Controls.Add(this.pictureBoxIcon, 1, 1);
            this.layoutTop.Controls.Add(this.textexApplicationRoleName, 3, 2);
            this.layoutTop.Controls.Add(this.textexApplicationRolePassword, 3, 4);
            this.layoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutTop.Location = new System.Drawing.Point(0, 0);
            this.layoutTop.Margin = new System.Windows.Forms.Padding(0);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.layoutTop.RowCount = 6;
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutTop.Size = new System.Drawing.Size(618, 175);
            this.layoutTop.TabIndex = 104;
            // 
            // labelSecurityIdentifier
            // 
            this.labelSecurityIdentifier.AutoSize = true;
            this.labelSecurityIdentifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSecurityIdentifier.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSecurityIdentifier.Location = new System.Drawing.Point(108, 22);
            this.labelSecurityIdentifier.Margin = new System.Windows.Forms.Padding(0);
            this.labelSecurityIdentifier.Name = "labelSecurityIdentifier";
            this.labelSecurityIdentifier.Size = new System.Drawing.Size(490, 21);
            this.labelSecurityIdentifier.TabIndex = 78;
            this.labelSecurityIdentifier.Text = "Application Role";
            this.labelSecurityIdentifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUserID.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserID.Location = new System.Drawing.Point(108, 81);
            this.labelUserID.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(490, 21);
            this.labelUserID.TabIndex = 83;
            this.labelUserID.Text = "Password";
            this.labelUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::TotalSmartCoding.Properties.Resources.Identity_icon_48;
            this.pictureBoxIcon.Location = new System.Drawing.Point(35, 22);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.layoutTop.SetRowSpan(this.pictureBoxIcon, 4);
            this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIcon.TabIndex = 11;
            this.pictureBoxIcon.TabStop = false;
            // 
            // textexApplicationRoleName
            // 
            this.textexApplicationRoleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexApplicationRoleName.Editable = false;
            this.textexApplicationRoleName.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexApplicationRoleName.Location = new System.Drawing.Point(112, 44);
            this.textexApplicationRoleName.Margin = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.textexApplicationRoleName.Name = "textexApplicationRoleName";
            this.textexApplicationRoleName.Size = new System.Drawing.Size(485, 28);
            this.textexApplicationRoleName.TabIndex = 88;
            this.textexApplicationRoleName.TextChanged += new System.EventHandler(this.textexApplicationRole_TextChanged);
            // 
            // textexApplicationRolePassword
            // 
            this.textexApplicationRolePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexApplicationRolePassword.Editable = false;
            this.textexApplicationRolePassword.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexApplicationRolePassword.Location = new System.Drawing.Point(112, 103);
            this.textexApplicationRolePassword.Margin = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.textexApplicationRolePassword.Name = "textexApplicationRolePassword";
            this.textexApplicationRolePassword.PasswordChar = '*';
            this.textexApplicationRolePassword.Size = new System.Drawing.Size(485, 28);
            this.textexApplicationRolePassword.TabIndex = 89;
            this.textexApplicationRolePassword.TextChanged += new System.EventHandler(this.textexApplicationRole_TextChanged);
            // 
            // ConnectServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 230);
            this.ControlBox = false;
            this.Controls.Add(this.layoutTop);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConnectServer";
            this.Text = "Specify an application role";
            this.Load += new System.EventHandler(this.ConnectServer_Load);
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
        private System.Windows.Forms.ToolStripButton buttonConnect;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton buttonLoginRestore;
        private System.Windows.Forms.ToolStripButton buttonDownload;
        private System.Windows.Forms.TableLayoutPanel layoutTop;
        private System.Windows.Forms.Label labelSecurityIdentifier;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private CustomControls.TextexBox textexApplicationRoleName;
        private CustomControls.TextexBox textexApplicationRolePassword;
    }
}