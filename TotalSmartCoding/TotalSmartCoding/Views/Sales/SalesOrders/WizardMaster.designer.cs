namespace TotalSmartCoding.Views.Sales.SalesOrders
{
    partial class WizardMaster
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonESC = new System.Windows.Forms.ToolStripButton();
            this.buttonOK = new System.Windows.Forms.ToolStripButton();
            this.errorProviderMaster = new System.Windows.Forms.ErrorProvider(this.components);
            this.layoutTop = new System.Windows.Forms.TableLayoutPanel();
            this.combexCustomerID = new CustomControls.CombexBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textexShippingAddress = new CustomControls.TextexBox();
            this.textexContactInfo = new CustomControls.TextexBox();
            this.combexSalespersonID = new CustomControls.CombexBox();
            this.textexRemarks = new CustomControls.TextexBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMaster)).BeginInit();
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 215);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(762, 55);
            this.toolStrip1.TabIndex = 3;
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
            this.buttonOK.Enabled = false;
            this.buttonOK.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Image = global::TotalSmartCoding.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_go_next_view;
            this.buttonOK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonOK.Size = new System.Drawing.Size(94, 52);
            this.buttonOK.Text = "Next";
            this.buttonOK.Click += new System.EventHandler(this.buttonOKESC_Click);
            // 
            // errorProviderMaster
            // 
            this.errorProviderMaster.ContainerControl = this;
            // 
            // layoutTop
            // 
            this.layoutTop.AutoSize = true;
            this.layoutTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutTop.BackColor = System.Drawing.Color.Ivory;
            this.layoutTop.ColumnCount = 5;
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutTop.Controls.Add(this.combexCustomerID, 3, 1);
            this.layoutTop.Controls.Add(this.label4, 2, 2);
            this.layoutTop.Controls.Add(this.pictureBox2, 1, 1);
            this.layoutTop.Controls.Add(this.label5, 2, 1);
            this.layoutTop.Controls.Add(this.textexShippingAddress, 3, 3);
            this.layoutTop.Controls.Add(this.textexContactInfo, 3, 2);
            this.layoutTop.Controls.Add(this.combexSalespersonID, 3, 4);
            this.layoutTop.Controls.Add(this.textexRemarks, 3, 5);
            this.layoutTop.Controls.Add(this.label1, 2, 3);
            this.layoutTop.Controls.Add(this.label2, 2, 4);
            this.layoutTop.Controls.Add(this.label3, 2, 5);
            this.layoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutTop.Location = new System.Drawing.Point(0, 0);
            this.layoutTop.Margin = new System.Windows.Forms.Padding(0);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.layoutTop.RowCount = 7;
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutTop.Size = new System.Drawing.Size(762, 215);
            this.layoutTop.TabIndex = 98;
            // 
            // combexCustomerID
            // 
            this.combexCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexCustomerID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexCustomerID.Editable = true;
            this.combexCustomerID.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combexCustomerID.FormattingEnabled = true;
            this.combexCustomerID.Location = new System.Drawing.Point(251, 35);
            this.combexCustomerID.Name = "combexCustomerID";
            this.combexCustomerID.ReadOnly = false;
            this.combexCustomerID.Size = new System.Drawing.Size(487, 29);
            this.combexCustomerID.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 34);
            this.label4.TabIndex = 77;
            this.label4.Text = "Contact Info";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TotalSmartCoding.Properties.Resources.Sign_Order_48;
            this.pictureBox2.Location = new System.Drawing.Point(33, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.layoutTop.SetRowSpan(this.pictureBox2, 3);
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 75;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 35);
            this.label5.TabIndex = 78;
            this.label5.Text = "Customer";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textexShippingAddress
            // 
            this.textexShippingAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexShippingAddress.Editable = true;
            this.textexShippingAddress.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexShippingAddress.Location = new System.Drawing.Point(251, 104);
            this.textexShippingAddress.Name = "textexShippingAddress";
            this.textexShippingAddress.Size = new System.Drawing.Size(487, 28);
            this.textexShippingAddress.TabIndex = 76;
            // 
            // textexContactInfo
            // 
            this.textexContactInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexContactInfo.Editable = true;
            this.textexContactInfo.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexContactInfo.Location = new System.Drawing.Point(251, 70);
            this.textexContactInfo.Name = "textexContactInfo";
            this.textexContactInfo.Size = new System.Drawing.Size(487, 28);
            this.textexContactInfo.TabIndex = 79;
            // 
            // combexSalespersonID
            // 
            this.combexSalespersonID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combexSalespersonID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combexSalespersonID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combexSalespersonID.Editable = true;
            this.combexSalespersonID.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combexSalespersonID.FormattingEnabled = true;
            this.combexSalespersonID.Location = new System.Drawing.Point(251, 138);
            this.combexSalespersonID.Name = "combexSalespersonID";
            this.combexSalespersonID.ReadOnly = false;
            this.combexSalespersonID.Size = new System.Drawing.Size(487, 29);
            this.combexSalespersonID.TabIndex = 80;
            // 
            // textexRemarks
            // 
            this.textexRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexRemarks.Editable = true;
            this.textexRemarks.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexRemarks.Location = new System.Drawing.Point(251, 173);
            this.textexRemarks.Name = "textexRemarks";
            this.textexRemarks.Size = new System.Drawing.Size(487, 28);
            this.textexRemarks.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 34);
            this.label1.TabIndex = 82;
            this.label1.Text = "Shipping Address";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 35);
            this.label2.TabIndex = 83;
            this.label2.Text = "Salesperson";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 34);
            this.label3.TabIndex = 84;
            this.label3.Text = "Remarks";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WizardMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 270);
            this.Controls.Add(this.layoutTop);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Wizard [New Sales Order]";
            this.Load += new System.EventHandler(this.WizardMaster_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMaster)).EndInit();
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
        private System.Windows.Forms.ErrorProvider errorProviderMaster;
        private System.Windows.Forms.TableLayoutPanel layoutTop;
        private CustomControls.CombexBox combexCustomerID;
        private CustomControls.TextexBox textexShippingAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private CustomControls.TextexBox textexContactInfo;
        private CustomControls.CombexBox combexSalespersonID;
        private CustomControls.TextexBox textexRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}