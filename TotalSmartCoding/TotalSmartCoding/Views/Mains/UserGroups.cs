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
        private UserGroupAPIs userGroupAPIs;
        private UserGroupIndex userGroupIndex;

        public UserGroups(UserGroupAPIs userGroupAPIs, UserGroupIndex userGroupIndex)
        {
            InitializeComponent();

            try
            {
                this.userGroupAPIs = userGroupAPIs;
                this.userGroupIndex = userGroupIndex;

                this.textexCode.TextChanged += textexNewUserGroupID_TextChanged;
                this.textexName.TextChanged += textexNewUserGroupID_TextChanged;
                this.textexDescription.TextChanged += textexNewUserGroupID_TextChanged;

                this.textexCode.ReadOnly = this.userGroupIndex != null;
                this.textexName.ReadOnly = this.userGroupIndex != null;
                this.textexDescription.ReadOnly = this.userGroupIndex != null;
                this.Text = this.userGroupIndex != null ? "Remove group" : "Add new group";
                this.buttonOK.Text = this.userGroupIndex != null ? "Remove" : "Add";

                if (this.userGroupIndex != null) { this.textexCode.Text = this.userGroupIndex.Code; this.textexName.Text = this.userGroupIndex.Name; this.textexDescription.Text = this.userGroupIndex.Description; }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void textexNewUserGroupID_TextChanged(object sender, EventArgs e)
        {
            this.buttonOK.Enabled = this.userGroupIndex != null || (this.textexCode.Text.Trim().Length > 0 && this.textexName.Text.Trim().Length > 0);
        }

        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    if ((this.textexCode.Text.Trim().Length > 0 && this.textexName.Text.Trim().Length > 0) || this.userGroupIndex != null)
                    {
                        if (CustomMsgBox.Show(this, "Are you sure you want to " + (this.userGroupIndex != null ? "remove" : "add") + " this group?" + "\r\n" + "\r\n" + this.textexCode.Text + "-" + this.textexName.Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                        {
                            if (this.userGroupIndex == null) this.userGroupAPIs.UserGroupAdd(this.textexCode.Text.Trim(), this.textexName.Text.Trim(), this.textexDescription.Text.Trim());
                            if (this.userGroupIndex != null) this.userGroupAPIs.UserGroupRemove(this.userGroupIndex.UserGroupID, this.userGroupIndex.Name);
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
