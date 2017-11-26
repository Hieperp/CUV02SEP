﻿namespace TotalSmartCoding.Views.Mains
{
    partial class Logon
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
            this.checkEmptyData = new System.Windows.Forms.CheckBox();
            this.lbEmployeeID = new System.Windows.Forms.Label();
            this.comboBoxEmployeeID = new System.Windows.Forms.ComboBox();
            this.comboBoxAutonicsPortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelChangePassword = new System.Windows.Forms.Label();
            this.comboFillingLineID = new System.Windows.Forms.ComboBox();
            this.lbProductionLineID = new System.Windows.Forms.Label();
            this.labelPortAutonis = new System.Windows.Forms.Label();
            this.labelNoDomino = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelBottomRight = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonExit = new System.Windows.Forms.ToolStripButton();
            this.buttonLogin = new System.Windows.Forms.ToolStripButton();
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.buttonLoginRestore = new System.Windows.Forms.ToolStripButton();
            this.buttonDownload = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelBottomRight.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottomLeft.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEmptyData
            // 
            this.checkEmptyData.AutoSize = true;
            this.checkEmptyData.Location = new System.Drawing.Point(-3, 169);
            this.checkEmptyData.Name = "checkEmptyData";
            this.checkEmptyData.Size = new System.Drawing.Size(134, 21);
            this.checkEmptyData.TabIndex = 28;
            this.checkEmptyData.Text = "Empty Database";
            this.checkEmptyData.UseVisualStyleBackColor = true;
            this.checkEmptyData.Visible = false;
            // 
            // lbEmployeeID
            // 
            this.lbEmployeeID.AutoSize = true;
            this.lbEmployeeID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployeeID.Location = new System.Drawing.Point(136, 77);
            this.lbEmployeeID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEmployeeID.Name = "lbEmployeeID";
            this.lbEmployeeID.Size = new System.Drawing.Size(79, 20);
            this.lbEmployeeID.TabIndex = 5;
            this.lbEmployeeID.Text = "User Login";
            // 
            // comboBoxEmployeeID
            // 
            this.comboBoxEmployeeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmployeeID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEmployeeID.FormattingEnabled = true;
            this.comboBoxEmployeeID.Location = new System.Drawing.Point(138, 101);
            this.comboBoxEmployeeID.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxEmployeeID.Name = "comboBoxEmployeeID";
            this.comboBoxEmployeeID.Size = new System.Drawing.Size(552, 28);
            this.comboBoxEmployeeID.TabIndex = 14;
            // 
            // comboBoxAutonicsPortName
            // 
            this.comboBoxAutonicsPortName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAutonicsPortName.FormattingEnabled = true;
            this.comboBoxAutonicsPortName.Location = new System.Drawing.Point(138, 162);
            this.comboBoxAutonicsPortName.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAutonicsPortName.Name = "comboBoxAutonicsPortName";
            this.comboBoxAutonicsPortName.Size = new System.Drawing.Size(553, 28);
            this.comboBoxAutonicsPortName.TabIndex = 15;
            this.comboBoxAutonicsPortName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Mật khẩu";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(4, 73);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(323, 26);
            this.textBoxPassword.TabIndex = 17;
            // 
            // labelChangePassword
            // 
            this.labelChangePassword.AutoSize = true;
            this.labelChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChangePassword.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelChangePassword.Location = new System.Drawing.Point(77, 53);
            this.labelChangePassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChangePassword.Name = "labelChangePassword";
            this.labelChangePassword.Size = new System.Drawing.Size(196, 17);
            this.labelChangePassword.TabIndex = 18;
            this.labelChangePassword.Text = "Click vào đây để đổi mật khẩu";
            // 
            // comboFillingLineID
            // 
            this.comboFillingLineID.Enabled = false;
            this.comboFillingLineID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFillingLineID.FormattingEnabled = true;
            this.comboFillingLineID.Location = new System.Drawing.Point(138, 40);
            this.comboFillingLineID.Margin = new System.Windows.Forms.Padding(4);
            this.comboFillingLineID.Name = "comboFillingLineID";
            this.comboFillingLineID.Size = new System.Drawing.Size(552, 28);
            this.comboFillingLineID.TabIndex = 21;
            this.comboFillingLineID.Validated += new System.EventHandler(this.comboFillingLineID_Validated);
            // 
            // lbProductionLineID
            // 
            this.lbProductionLineID.AutoSize = true;
            this.lbProductionLineID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductionLineID.Location = new System.Drawing.Point(136, 16);
            this.lbProductionLineID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProductionLineID.Name = "lbProductionLineID";
            this.lbProductionLineID.Size = new System.Drawing.Size(36, 20);
            this.lbProductionLineID.TabIndex = 20;
            this.lbProductionLineID.Text = "Line";
            this.lbProductionLineID.DoubleClick += new System.EventHandler(this.lbProductionLineID_DoubleClick);
            // 
            // labelPortAutonis
            // 
            this.labelPortAutonis.AutoSize = true;
            this.labelPortAutonis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPortAutonis.Location = new System.Drawing.Point(136, 138);
            this.labelPortAutonis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPortAutonis.Name = "labelPortAutonis";
            this.labelPortAutonis.Size = new System.Drawing.Size(111, 20);
            this.labelPortAutonis.TabIndex = 24;
            this.labelPortAutonis.Text = "Zebra Comport";
            this.labelPortAutonis.Visible = false;
            // 
            // labelNoDomino
            // 
            this.labelNoDomino.AutoSize = true;
            this.labelNoDomino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoDomino.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelNoDomino.Location = new System.Drawing.Point(0, 111);
            this.labelNoDomino.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNoDomino.Name = "labelNoDomino";
            this.labelNoDomino.Size = new System.Drawing.Size(308, 17);
            this.labelNoDomino.TabIndex = 26;
            this.labelNoDomino.Text = "Double click vào đây không kết nối máy in phun";
            this.labelNoDomino.DoubleClick += new System.EventHandler(this.labelNoDomino_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxPassword);
            this.panel1.Controls.Add(this.labelNoDomino);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelChangePassword);
            this.panel1.Location = new System.Drawing.Point(727, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 150);
            this.panel1.TabIndex = 27;
            this.panel1.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelBottomRight);
            this.panelBottom.Controls.Add(this.panelBottomLeft);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 220);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(713, 55);
            this.panelBottom.TabIndex = 74;
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.Controls.Add(this.toolStrip1);
            this.panelBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomRight.Location = new System.Drawing.Point(143, 0);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Size = new System.Drawing.Size(570, 55);
            this.panelBottomRight.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonExit,
            this.buttonLogin});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(570, 55);
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
            this.buttonExit.Click += new System.EventHandler(this.buttonLoginExit_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Image = global::TotalSmartCoding.Properties.Resources.Login;
            this.buttonLogin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonLogin.Size = new System.Drawing.Size(98, 52);
            this.buttonLogin.Text = "Login";
            this.buttonLogin.Click += new System.EventHandler(this.buttonLoginExit_Click);
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
            this.buttonLoginRestore.Text = "Restore store procedures";
            this.buttonLoginRestore.Visible = false;
            this.buttonLoginRestore.Click += new System.EventHandler(this.buttonLoginExit_Click);
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
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::TotalSmartCoding.Properties.Resources.Identity_icon_48;
            this.pictureBoxIcon.Location = new System.Drawing.Point(35, 16);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIcon.TabIndex = 11;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.DoubleClick += new System.EventHandler(this.pictureBoxIcon_DoubleClick);
            // 
            // Logon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 275);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.checkEmptyData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelPortAutonis);
            this.Controls.Add(this.comboFillingLineID);
            this.Controls.Add(this.lbProductionLineID);
            this.Controls.Add(this.comboBoxAutonicsPortName);
            this.Controls.Add(this.comboBoxEmployeeID);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.lbEmployeeID);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Logon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to smart barcode solution";
            this.Load += new System.EventHandler(this.PublicApplicationLogon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottomRight.ResumeLayout(false);
            this.panelBottomRight.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottomLeft.ResumeLayout(false);
            this.panelBottomLeft.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbEmployeeID;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.ComboBox comboBoxEmployeeID;
        private System.Windows.Forms.ComboBox comboBoxAutonicsPortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelChangePassword;
        private System.Windows.Forms.ComboBox comboFillingLineID;
        private System.Windows.Forms.Label lbProductionLineID;
        private System.Windows.Forms.Label labelPortAutonis;
        private System.Windows.Forms.Label labelNoDomino;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkEmptyData;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelBottomRight;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonExit;
        private System.Windows.Forms.ToolStripButton buttonLogin;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton buttonLoginRestore;
        private System.Windows.Forms.ToolStripButton buttonDownload;
    }
}