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
            this.label5 = new System.Windows.Forms.Label();
            this.textexShippingAddress = new CustomControls.TextexBox();
            this.textexContactInfo = new CustomControls.TextexBox();
            this.combexSalespersonID = new CustomControls.CombexBox();
            this.textexRemarks = new CustomControls.TextexBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimexDeliveryDate = new CustomControls.DateTimexPicker();
            this.label6 = new System.Windows.Forms.Label();
            this.textexVoucherCode = new CustomControls.TextexBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimexEntryDate = new CustomControls.DateTimexPicker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 302);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(752, 55);
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
            this.layoutTop.ColumnCount = 5;
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.layoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.layoutTop.Controls.Add(this.combexCustomerID, 3, 2);
            this.layoutTop.Controls.Add(this.label4, 2, 3);
            this.layoutTop.Controls.Add(this.label5, 2, 2);
            this.layoutTop.Controls.Add(this.textexShippingAddress, 3, 4);
            this.layoutTop.Controls.Add(this.textexContactInfo, 3, 3);
            this.layoutTop.Controls.Add(this.combexSalespersonID, 3, 7);
            this.layoutTop.Controls.Add(this.textexRemarks, 3, 8);
            this.layoutTop.Controls.Add(this.label1, 2, 4);
            this.layoutTop.Controls.Add(this.label2, 2, 7);
            this.layoutTop.Controls.Add(this.label3, 2, 8);
            this.layoutTop.Controls.Add(this.dateTimexDeliveryDate, 3, 6);
            this.layoutTop.Controls.Add(this.label6, 2, 6);
            this.layoutTop.Controls.Add(this.textexVoucherCode, 3, 5);
            this.layoutTop.Controls.Add(this.label7, 2, 5);
            this.layoutTop.Controls.Add(this.label8, 2, 1);
            this.layoutTop.Controls.Add(this.dateTimexEntryDate, 3, 1);
            this.layoutTop.Controls.Add(this.pictureBox2, 1, 1);
            this.layoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutTop.Location = new System.Drawing.Point(0, 0);
            this.layoutTop.Margin = new System.Windows.Forms.Padding(0);
            this.layoutTop.Name = "layoutTop";
            this.layoutTop.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.layoutTop.RowCount = 10;
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutTop.Size = new System.Drawing.Size(752, 302);
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
            this.combexCustomerID.Location = new System.Drawing.Point(247, 58);
            this.combexCustomerID.Margin = new System.Windows.Forms.Padding(1);
            this.combexCustomerID.Name = "combexCustomerID";
            this.combexCustomerID.ReadOnly = false;
            this.combexCustomerID.Size = new System.Drawing.Size(484, 29);
            this.combexCustomerID.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 30);
            this.label4.TabIndex = 77;
            this.label4.Text = "Contact Info";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 31);
            this.label5.TabIndex = 78;
            this.label5.Text = "Customer";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textexShippingAddress
            // 
            this.textexShippingAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexShippingAddress.Editable = true;
            this.textexShippingAddress.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexShippingAddress.Location = new System.Drawing.Point(247, 119);
            this.textexShippingAddress.Margin = new System.Windows.Forms.Padding(1);
            this.textexShippingAddress.Name = "textexShippingAddress";
            this.textexShippingAddress.Size = new System.Drawing.Size(484, 28);
            this.textexShippingAddress.TabIndex = 76;
            // 
            // textexContactInfo
            // 
            this.textexContactInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexContactInfo.Editable = true;
            this.textexContactInfo.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexContactInfo.Location = new System.Drawing.Point(247, 89);
            this.textexContactInfo.Margin = new System.Windows.Forms.Padding(1);
            this.textexContactInfo.Name = "textexContactInfo";
            this.textexContactInfo.Size = new System.Drawing.Size(484, 28);
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
            this.combexSalespersonID.Location = new System.Drawing.Point(247, 209);
            this.combexSalespersonID.Margin = new System.Windows.Forms.Padding(1);
            this.combexSalespersonID.Name = "combexSalespersonID";
            this.combexSalespersonID.ReadOnly = false;
            this.combexSalespersonID.Size = new System.Drawing.Size(484, 29);
            this.combexSalespersonID.TabIndex = 80;
            // 
            // textexRemarks
            // 
            this.textexRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexRemarks.Editable = true;
            this.textexRemarks.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexRemarks.Location = new System.Drawing.Point(247, 240);
            this.textexRemarks.Margin = new System.Windows.Forms.Padding(1);
            this.textexRemarks.Name = "textexRemarks";
            this.textexRemarks.Size = new System.Drawing.Size(484, 28);
            this.textexRemarks.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 30);
            this.label1.TabIndex = 82;
            this.label1.Text = "Shipping Address";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 31);
            this.label2.TabIndex = 83;
            this.label2.Text = "Salesperson";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 30);
            this.label3.TabIndex = 84;
            this.label3.Text = "Remarks";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimexDeliveryDate
            // 
            this.dateTimexDeliveryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimexDeliveryDate.Editable = true;
            this.dateTimexDeliveryDate.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimexDeliveryDate.Location = new System.Drawing.Point(247, 179);
            this.dateTimexDeliveryDate.Margin = new System.Windows.Forms.Padding(1);
            this.dateTimexDeliveryDate.Name = "dateTimexDeliveryDate";
            this.dateTimexDeliveryDate.ReadOnly = false;
            this.dateTimexDeliveryDate.Size = new System.Drawing.Size(484, 28);
            this.dateTimexDeliveryDate.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 30);
            this.label6.TabIndex = 86;
            this.label6.Text = "Delivery Lead Time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textexVoucherCode
            // 
            this.textexVoucherCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textexVoucherCode.Editable = true;
            this.textexVoucherCode.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textexVoucherCode.Location = new System.Drawing.Point(247, 149);
            this.textexVoucherCode.Margin = new System.Windows.Forms.Padding(1);
            this.textexVoucherCode.Name = "textexVoucherCode";
            this.textexVoucherCode.Size = new System.Drawing.Size(484, 28);
            this.textexVoucherCode.TabIndex = 87;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(87, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 30);
            this.label7.TabIndex = 88;
            this.label7.Text = "Voucher #";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(87, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 30);
            this.label8.TabIndex = 89;
            this.label8.Text = "Sales Order Date";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimexEntryDate
            // 
            this.dateTimexEntryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimexEntryDate.Editable = true;
            this.dateTimexEntryDate.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimexEntryDate.Location = new System.Drawing.Point(247, 28);
            this.dateTimexEntryDate.Margin = new System.Windows.Forms.Padding(1);
            this.dateTimexEntryDate.Name = "dateTimexEntryDate";
            this.dateTimexEntryDate.ReadOnly = false;
            this.dateTimexEntryDate.Size = new System.Drawing.Size(484, 28);
            this.dateTimexEntryDate.TabIndex = 90;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TotalSmartCoding.Properties.Resources.Sign_Order_48;
            this.pictureBox2.Location = new System.Drawing.Point(33, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.layoutTop.SetRowSpan(this.pictureBox2, 3);
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 75;
            this.pictureBox2.TabStop = false;
            // 
            // WizardMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 357);
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
        private CustomControls.DateTimexPicker dateTimexDeliveryDate;
        private System.Windows.Forms.Label label6;
        private CustomControls.TextexBox textexVoucherCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private CustomControls.DateTimexPicker dateTimexEntryDate;
    }
}