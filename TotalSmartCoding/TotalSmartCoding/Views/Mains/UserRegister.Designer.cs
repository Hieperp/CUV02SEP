namespace TotalSmartCoding.Views.Mains
{
    partial class UserRegister
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
            this.label5 = new System.Windows.Forms.Label();
            this.combexOrganizationalUnitID = new CustomControls.CombexBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.combexSameOUAccessLevels = new CustomControls.CombexBox();
            this.combexSameLocationAccessLevels = new CustomControls.CombexBox();
            this.combexOtherOUAccessLevels = new CustomControls.CombexBox();
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 245);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(810, 55);
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
            this.buttonESC.Size = new System.Drawing.Size(83, 52);
            this.buttonESC.Text = "Cancel";
            this.buttonESC.Click += new System.EventHandler(this.buttonOKESC_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Image = global::TotalSmartCoding.Properties.Resources.Add_continue;
            this.buttonOK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonOK.Size = new System.Drawing.Size(103, 52);
            this.buttonOK.Text = "Finish";
            this.buttonOK.Click += new System.EventHandler(this.buttonOKESC_Click);
            // 
            // layoutTop
            // 
            this.layoutTop.AutoSize = true;
            this.layoutTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutTop.ColumnCount = 5;
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.layoutTop.Controls.Add(this.combexUserID, 3, 1);
            this.layoutTop.Controls.Add(this.label5, 2, 1);
            this.layoutTop.Controls.Add(this.combexOrganizationalUnitID, 3, 2);
            this.layoutTop.Controls.Add(this.label2, 2, 2);
            this.layoutTop.Controls.Add(this.pictureBox2, 1, 1);
            this.layoutTop.Controls.Add(this.label1, 2, 5);
            this.layoutTop.Controls.Add(this.label4, 2, 7);
            this.layoutTop.Controls.Add(this.label6, 2, 6);
            this.layoutTop.Controls.Add(this.label3, 3, 4);
            this.layoutTop.Controls.Add(this.combexSameOUAccessLevels, 3, 5);
            this.layoutTop.Controls.Add(this.combexSameLocationAccessLevels, 3, 6);
            this.layoutTop.Controls.Add(this.combexOtherOUAccessLevels, 3, 7);
            this.layoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutTop.Location = new System.Drawing.Point(0, 0);
            this.layoutTop.Margin = new System.Windows.Forms.Padding(0);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.layoutTop.RowCount = 9;
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutTop.Size = new System.Drawing.Size(810, 245);
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
            this.combexUserID.Location = new System.Drawing.Point(260, 28);
            this.combexUserID.Margin = new System.Windows.Forms.Padding(1);
            this.combexUserID.Name = "combexUserID";
            this.combexUserID.ReadOnly = false;
            this.combexUserID.Size = new System.Drawing.Size(523, 29);
            this.combexUserID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 31);
            this.label5.TabIndex = 78;
            this.label5.Text = "User";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // combexOrganizationalUnitID
            // 
            this.combexOrganizationalUnitID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexOrganizationalUnitID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexOrganizationalUnitID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexOrganizationalUnitID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combexOrganizationalUnitID.Editable = true;
            this.combexOrganizationalUnitID.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combexOrganizationalUnitID.FormattingEnabled = true;
            this.combexOrganizationalUnitID.Location = new System.Drawing.Point(260, 59);
            this.combexOrganizationalUnitID.Margin = new System.Windows.Forms.Padding(1);
            this.combexOrganizationalUnitID.Name = "combexOrganizationalUnitID";
            this.combexOrganizationalUnitID.ReadOnly = false;
            this.combexOrganizationalUnitID.Size = new System.Drawing.Size(523, 29);
            this.combexOrganizationalUnitID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 31);
            this.label2.TabIndex = 83;
            this.label2.Text = "Organizational Unit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TotalSmartCoding.Properties.Resources.add_user;
            this.pictureBox2.Location = new System.Drawing.Point(33, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.layoutTop.SetRowSpan(this.pictureBox2, 8);
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 75;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 31);
            this.label1.TabIndex = 84;
            this.label1.Text = "Division";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 31);
            this.label4.TabIndex = 86;
            this.label4.Text = "Division";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 31);
            this.label6.TabIndex = 87;
            this.label6.Text = "Division";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(259, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(522, 21);
            this.label3.TabIndex = 85;
            this.label3.Text = "Division";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combexSameOUAccessLevels
            // 
            this.combexSameOUAccessLevels.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexSameOUAccessLevels.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexSameOUAccessLevels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexSameOUAccessLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combexSameOUAccessLevels.Editable = true;
            this.combexSameOUAccessLevels.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combexSameOUAccessLevels.FormattingEnabled = true;
            this.combexSameOUAccessLevels.Location = new System.Drawing.Point(260, 134);
            this.combexSameOUAccessLevels.Margin = new System.Windows.Forms.Padding(1);
            this.combexSameOUAccessLevels.Name = "combexSameOUAccessLevels";
            this.combexSameOUAccessLevels.ReadOnly = false;
            this.combexSameOUAccessLevels.Size = new System.Drawing.Size(523, 29);
            this.combexSameOUAccessLevels.TabIndex = 3;
            // 
            // combexSameLocationAccessLevels
            // 
            this.combexSameLocationAccessLevels.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexSameLocationAccessLevels.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexSameLocationAccessLevels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexSameLocationAccessLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combexSameLocationAccessLevels.Editable = true;
            this.combexSameLocationAccessLevels.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combexSameLocationAccessLevels.FormattingEnabled = true;
            this.combexSameLocationAccessLevels.Location = new System.Drawing.Point(260, 165);
            this.combexSameLocationAccessLevels.Margin = new System.Windows.Forms.Padding(1);
            this.combexSameLocationAccessLevels.Name = "combexSameLocationAccessLevels";
            this.combexSameLocationAccessLevels.ReadOnly = false;
            this.combexSameLocationAccessLevels.Size = new System.Drawing.Size(523, 29);
            this.combexSameLocationAccessLevels.TabIndex = 4;
            // 
            // combexOtherOUAccessLevels
            // 
            this.combexOtherOUAccessLevels.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexOtherOUAccessLevels.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexOtherOUAccessLevels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexOtherOUAccessLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combexOtherOUAccessLevels.Editable = true;
            this.combexOtherOUAccessLevels.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combexOtherOUAccessLevels.FormattingEnabled = true;
            this.combexOtherOUAccessLevels.Location = new System.Drawing.Point(260, 196);
            this.combexOtherOUAccessLevels.Margin = new System.Windows.Forms.Padding(1);
            this.combexOtherOUAccessLevels.Name = "combexOtherOUAccessLevels";
            this.combexOtherOUAccessLevels.ReadOnly = false;
            this.combexOtherOUAccessLevels.Size = new System.Drawing.Size(523, 29);
            this.combexOtherOUAccessLevels.TabIndex = 5;
            // 
            // UserRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 300);
            this.Controls.Add(this.layoutTop);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserRegister";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private CustomControls.CombexBox combexSameOUAccessLevels;
        private CustomControls.CombexBox combexSameLocationAccessLevels;
        private CustomControls.CombexBox combexOtherOUAccessLevels;
    }
}