using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using TotalModel.Models;
using TotalSmartCoding.Libraries.Helpers;

namespace TotalSmartCoding.Views.Commons.Customers
{
    public partial class CustomerPopup : Form
    {
        public CustomerBase CustomerBase;
        private List<CustomerBase> customerBases;

        public CustomerPopup(List<CustomerBase> customerBases)
        {
            InitializeComponent();

            this.customerBases = customerBases;
        }

        private void CustomerPopup_Load(object sender, EventArgs e)
        {
            this.fastCustomerBases.SetObjects(this.customerBases);
            this.ActiveControl = this.textexFilters.TextBox;
        }

        private void textexFilters_TextChanged(object sender, EventArgs e)
        {
            try
            {
                OLVHelpers.ApplyFilters(this.fastCustomerBases, this.textexFilters.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void buttonClearFilters_Click(object sender, EventArgs e)
        {
            this.textexFilters.Text = "";
        }

        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    if ((CustomerBase)this.fastCustomerBases.SelectedObject != null)
                    {
                        this.CustomerBase = (CustomerBase)this.fastCustomerBases.SelectedObject;
                        this.DialogResult = DialogResult.OK;
                    }
                }

                if (sender.Equals(this.buttonESC))
                    this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void fastCustomerBases_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.buttonOKESC_Click(this.buttonOK, new EventArgs());
        }
    }
}
