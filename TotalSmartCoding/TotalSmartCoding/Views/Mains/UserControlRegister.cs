using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.Controllers.APIs.Generals;
using TotalSmartCoding.Libraries;


namespace TotalSmartCoding.Views.Mains
{
    public partial class UserControlRegister : Form
    {

        private UserAPIs userAPIs { get; set; }

        public string UserName { get; set; }

        private Binding bindingUserName;

        public UserControlRegister(UserAPIs userAPIs)
        {
            InitializeComponent();

            try
            {
                List<DomainUser> allUsers = new List<DomainUser>();

                //userAPIs.UpdateUserName("S-1-5-21-3775195119-1044016383-3360809325-1001", "NMVN\vendor");

                if (false)
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "chevronvn.com"); //, "OU=SomeOU,dc=YourCompany,dc=com"// create your domain context and define the OU container to search in
                    UserPrincipal qbeUser = new UserPrincipal(ctx);// define a "query-by-example" principal - here, we search for a UserPrincipal (user)
                    PrincipalSearcher srch = new PrincipalSearcher(qbeUser); // create your principal searcher passing in the QBE principal    

                    foreach (var found in srch.FindAll())// find all matches
                    {// do whatever here - "found" is of type "Principal" - it could be user, group, computer.....          

                        if (found.Sid.Value != null && found.Sid.Value != "" && found.SamAccountName != null && found.SamAccountName != "") userAPIs.UpdateUserName(found.Sid.Value, found.SamAccountName);

                        allUsers.Add(new DomainUser() { FirstName = "", LastName = "", UserName = found.SamAccountName, SecurityIdentifier = found.Sid.Value }); //found.UserPrincipalName: the same as SamAccountName, but with @chevron.com
                    }
                }
                else
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        allUsers.Add(new DomainUser() { FirstName = "FIST NAME" + i.ToString(), LastName = "FIST NAME" + i.ToString(), UserName = "CHEVRONVN\\Vendor " + i.ToString(), SecurityIdentifier = "S-1-5-21-290773801108-" + DateTime.Now.ToString() });
                    }
                }

                this.combexUserID.DataSource = allUsers;
                this.combexUserID.DisplayMember = CommonExpressions.PropertyName<DomainUser>(p => p.UserName);
                this.combexUserID.ValueMember = CommonExpressions.PropertyName<DomainUser>(p => p.UserName);
                this.bindingUserName = this.combexUserID.DataBindings.Add("SelectedValue", this, CommonExpressions.PropertyName<DomainUser>(p => p.UserName), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingUserName.BindingComplete += binding_BindingComplete;

                this.userAPIs = userAPIs;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }


        private void binding_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            this.buttonOK.Enabled = this.UserName != null;
        }

        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    if (this.combexUserID.SelectedIndex >= 0 && this.UserName != null)
                    {
                        DomainUser domainUser = this.combexUserID.SelectedItem as DomainUser;
                        if (domainUser != null)
                        {
                            //this.userAPIs.UserControlRegister(organizationalUnitIndex.LocationID, organizationalUnitIndex.OrganizationalUnitID, domainUser.FirstName, domainUser.LastName, domainUser.UserName, domainUser.SecurityIdentifier, (int)this.SameOUAccessLevel, (int)this.SameLocationAccessLevel, (int)this.OtherOUAccessLevel);
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

    public class DomainUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string SecurityIdentifier { get; set; }
    }
}
