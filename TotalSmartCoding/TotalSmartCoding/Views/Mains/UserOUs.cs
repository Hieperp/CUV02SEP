using System;
using System.Windows.Forms;

using Ninject;

using TotalBase;
using TotalModel.Models;
using TotalCore.Repositories.Generals;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.Controllers.APIs.Generals;
using TotalSmartCoding.Libraries;


namespace TotalSmartCoding.Views.Mains
{
    public partial class UserOUs : Form
    {
        private bool addOU;

        private IOrganizationalUnitRepository organizationalUnitRepository { get; set; }
        private OrganizationalUnitAPIs organizationalUnitAPIs { get; set; }

        public int? OrganizationalUnitID { get; set; }


        private Binding bindingOrganizationalUnitID;

        public UserOUs(OrganizationalUnitAPIs organizationalUnitAPIs, bool addOU)
        {
            InitializeComponent();

            try
            {
                this.organizationalUnitRepository = CommonNinject.Kernel.Get<IOrganizationalUnitRepository>();

                this.organizationalUnitAPIs = organizationalUnitAPIs;
                this.combexOrganizationalUnitID.DataSource = this.organizationalUnitAPIs.GetOrganizationalUnitIndexes();
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
            this.buttonOK.Enabled = this.OrganizationalUnitID != null && this.organizationalUnitRepository.GetEditable((int)this.OrganizationalUnitID); ;
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
                            //this.organizationalUnitAPIs.UserRegister(organizationalUnitIndex.LocationID, organizationalUnitIndex.OrganizationalUnitID, organizationalUnitIndex.FirstName, organizationalUnitIndex.LastName, organizationalUnitIndex.UserName, organizationalUnitIndex.SecurityIdentifier, (int)this.SameOUAccessLevel, (int)this.SameLocationAccessLevel, (int)this.OtherOUAccessLevel);
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
