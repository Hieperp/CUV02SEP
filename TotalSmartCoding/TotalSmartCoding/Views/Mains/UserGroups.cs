using System;
using System.Windows.Forms;

using Ninject;

using TotalBase;
using TotalModel.Models;
using TotalCore.Repositories.Generals;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.Controllers.APIs.Generals;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalCore.Repositories.Commons;


namespace TotalSmartCoding.Views.Mains
{
    public partial class UserGroups : Form
    {
        private bool addUserGroup;

        private IUserGroupRepository userGroupRepository { get; set; }
        private UserGroupAPIs userGroupAPIs { get; set; }

        public UserGroups(UserGroupAPIs userGroupAPIs, bool addUserGroup)
        {
            InitializeComponent();

            try
            {
                this.userGroupAPIs = userGroupAPIs;
                this.userGroupRepository = CommonNinject.Kernel.Get<IUserGroupRepository>();

                this.textexCode.TextChanged += textexNewUserGroupID_TextChanged;
                this.textexName.TextChanged += textexNewUserGroupID_TextChanged;
                this.textexDescription.TextChanged += textexNewUserGroupID_TextChanged;

                this.addUserGroup = addUserGroup;
                this.textexCode.ReadOnly = !this.addUserGroup;
                this.textexName.ReadOnly = !this.addUserGroup;
                this.textexDescription.ReadOnly = !this.addUserGroup;
                this.Text = this.addUserGroup ? "Add new group" : "Remove group";
                this.buttonOK.Text = this.addUserGroup ? "Add" : "Remove";
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void textexNewUserGroupID_TextChanged(object sender, EventArgs e)
        {
            this.buttonOK.Enabled = this.addUserGroup && this.textexCode.Text.Trim().Length > 0 && this.textexName.Text.Trim().Length > 0;

            //REMOVE
            //this.buttonOK.Enabled = this.OrganizationalUnitID != null && this.organizationalUnitRepository.GetEditable((int)this.OrganizationalUnitID); ;
        }

        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    UserGroupIndex userGroupIndex = null;
                    this.textexName.Text = this.textexName.Text.Trim();

                    //if (!this.addUserGroup && this.combexUserGroupID.SelectedIndex >= 0) userGroupIndex = this.combexUserGroupID.SelectedItem as UserGroupIndex;

                    if ((this.addUserGroup && this.textexCode.Text.Trim().Length > 0 && this.textexName.Text.Length > 0) || userGroupIndex != null)
                    {
                        if (CustomMsgBox.Show(this, "Are you sure you want to " + (this.addUserGroup ? "add" : "remove") + " this group?" + "\r\n" + "\r\n" + this.textexCode.Text + "-" + this.textexName.Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                        {
                            if (this.addUserGroup) this.userGroupAPIs.UserGroupAdd(this.textexCode.Text.Trim(), this.textexName.Text.Trim(), this.textexDescription.Text.Trim());
                            //if (!this.addUserGroup) this.userGroupAPIs.UserGroupRemove(userGroupIndex.UserGroupID, userGroupIndex.UserGroupName);
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
