using System;
using System.Windows.Forms;

using TotalBase;
using TotalModel.Models;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.Controllers.APIs.Generals;


namespace TotalSmartCoding.Views.Mains
{
    public partial class UserOUs : Form
    {

        private UserAPIs userAPIs { get; set; }
        private bool addOU;

        public int? OrganizationalUnitID { get; set; }


        private Binding bindingOrganizationalUnitID;

        public UserOUs(UserAPIs userAPIs, bool addOU)
        {
            InitializeComponent();

            try
            {
                this.userAPIs = userAPIs;
                this.combexOrganizationalUnitID.DataSource = this.userAPIs.GetOrganizationalUnitIndexes();
                this.combexOrganizationalUnitID.DisplayMember = CommonExpressions.PropertyName<OrganizationalUnitIndex>(p => p.LocationOrganizationalUnitName);
                this.combexOrganizationalUnitID.ValueMember = CommonExpressions.PropertyName<OrganizationalUnitIndex>(p => p.OrganizationalUnitID);
                this.bindingOrganizationalUnitID = this.combexOrganizationalUnitID.DataBindings.Add("SelectedValue", this, CommonExpressions.PropertyName<OrganizationalUnitIndex>(p => p.OrganizationalUnitID), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingOrganizationalUnitID.BindingComplete += bindingOrganizationalUnitID_BindingComplete;
                this.textexNewOrganizationalUnitID.TextChanged += textexNewOrganizationalUnitID_TextChanged;

                this.addOU = addOU;
                this.labelOrganizationalUnitID.Visible = !this.addOU; this.combexOrganizationalUnitID.Visible = !this.addOU;
                this.labelNewOrganizationalUnitID.Visible = this.addOU; this.textexNewOrganizationalUnitID.Visible = this.addOU;
                this.Text = this.addOU ? "Add new organizational unit" : "Remove OU";
                this.buttonOK.Text = this.addOU ? "Add" : "Remove";
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void textexNewOrganizationalUnitID_TextChanged(object sender, EventArgs e)
        {
            this.buttonOK.Enabled = this.textexNewOrganizationalUnitID.Text.Trim().Length > 0;
        }

        private void bindingOrganizationalUnitID_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            this.buttonOK.Enabled = this.OrganizationalUnitID != null;
        }

        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    OrganizationalUnitIndex organizationalUnitIndex = null;
                    this.textexNewOrganizationalUnitID.Text = this.textexNewOrganizationalUnitID.Text.Trim();
                    if (!this.addOU && this.combexOrganizationalUnitID.SelectedIndex >= 0) organizationalUnitIndex = this.combexOrganizationalUnitID.SelectedItem as OrganizationalUnitIndex;

                    if ((this.addOU && this.textexNewOrganizationalUnitID.Text.Length > 0) || organizationalUnitIndex != null)
                    {
                        if (CustomMsgBox.Show(this, "Are you sure you want to " + (this.addOU ? "add" : "remove") + " this organizational unit?" + "\r\n" + "\r\n" + (this.addOU ? this.textexNewOrganizationalUnitID.Text : organizationalUnitIndex.OrganizationalUnitName + "\r\nAt:  " + organizationalUnitIndex.LocationName), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                        {
                            //this.userAPIs.UserRegister(organizationalUnitIndex.LocationID, organizationalUnitIndex.OrganizationalUnitID, organizationalUnitIndex.FirstName, organizationalUnitIndex.LastName, organizationalUnitIndex.UserName, organizationalUnitIndex.SecurityIdentifier, (int)this.SameOUAccessLevel, (int)this.SameLocationAccessLevel, (int)this.OtherOUAccessLevel);
                            this.DialogResult = DialogResult.OK;
                        }
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

    }
}
