using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

using TotalBase;
using TotalModel.Models;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.Controllers.APIs.Generals;
using TotalSmartCoding.Libraries;


namespace TotalSmartCoding.Views.Mains
{
    public partial class UserAdd : Form
    {
        private Binding bindingOrganizationalUnitID;
        private UserAPIs userAPIs { get; set; }

        public int? OrganizationalUnitID { get; set; }

        public UserAdd(UserAPIs userAPIs)
        {
            InitializeComponent();

            try
            {
                List<string> allUsers = new List<string>();
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "DOMAINNAME", "OU=SomeOU,dc=YourCompany,dc=com");// create your domain context and define the OU container to search in
                UserPrincipal qbeUser = new UserPrincipal(ctx);// define a "query-by-example" principal - here, we search for a UserPrincipal (user)
                PrincipalSearcher srch = new PrincipalSearcher(qbeUser); // create your principal searcher passing in the QBE principal    

                foreach (var found in srch.FindAll())// find all matches
                {// do whatever here - "found" is of type "Principal" - it could be user, group, computer.....          
                    allUsers.Add(found.DisplayName);
                }
                this.combexUserID.DataSource = allUsers;

                this.userAPIs = userAPIs;
                this.combexOrganizationalUnitID.DataSource = this.userAPIs.GetOrganizationalUnitIndexes();
                this.combexOrganizationalUnitID.DisplayMember = CommonExpressions.PropertyName<OrganizationalUnitIndex>(p => p.LocationOrganizationalUnitName);
                this.combexOrganizationalUnitID.ValueMember = CommonExpressions.PropertyName<OrganizationalUnitIndex>(p => p.OrganizationalUnitID);
                this.bindingOrganizationalUnitID = this.combexOrganizationalUnitID.DataBindings.Add("SelectedValue", this, CommonExpressions.PropertyName<OrganizationalUnitIndex>(p => p.OrganizationalUnitID), true, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }


        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    //this.userAPIs.UserAdd(this.OrganizationalUnitID, "DELL-E7240T\\Hiep", "DELL-E7240T\\Hiep", "DELL-E7240T\\Hiep");
                    //this.DialogResult = DialogResult.OK;
                    if (this.combexUserID.SelectedIndex >= 0 && this.OrganizationalUnitID != null)
                    {
                        this.userAPIs.UserAdd(this.OrganizationalUnitID, this.combexUserID.Text, this.combexUserID.Text, this.combexUserID.Text);
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

    }
}
