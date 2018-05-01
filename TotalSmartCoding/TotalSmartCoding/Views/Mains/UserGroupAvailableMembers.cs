﻿using System;
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
using BrightIdeasSoftware;


namespace TotalSmartCoding.Views.Mains
{
    public partial class UserGroupAvailableMembers : Form
    {
        private int userGroupID;
        private UserGroupAPIs userGroupAPIs;


        public UserGroupAvailableMembers(UserGroupAPIs userGroupAPIs, int userGroupID)
        {
            InitializeComponent();

            try
            {
                this.userGroupID = userGroupID;
                this.userGroupAPIs = userGroupAPIs;

                this.fastUserGroupAvailableMembers.ShowGroups = true;
                this.fastUserGroupAvailableMembers.AboutToCreateGroups += fastUserGroupAvailableMembers_AboutToCreateGroups;

                this.fastUserGroupAvailableMembers.SetObjects(this.userGroupAPIs.GetUserGroupAvailableMembers(this.userGroupID));
                this.fastUserGroupAvailableMembers.Sort(this.olvUserType, SortOrder.Ascending);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void fastUserGroupAvailableMembers_AboutToCreateGroups(object sender, BrightIdeasSoftware.CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "UserGroupR";
                    olvGroup.Subtitle = "Available " + olvGroup.Contents.Count.ToString() + " User" + (olvGroup.Contents.Count > 1 ? "s" : "");
                }
            }
        }

        private void fastUserGroupAvailableMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonOK.Enabled = this.fastUserGroupAvailableMembers.SelectedObject != null;
        }

        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    if (this.fastUserGroupAvailableMembers.SelectedObject != null)
                    {
                        UserGroupAvailableMember userGroupAvailableMember = (UserGroupAvailableMember)this.fastUserGroupAvailableMembers.SelectedObject;
                        if (userGroupAvailableMember != null)
                        {
                            this.userGroupAPIs.UserGroupAddMember(this.userGroupID, userGroupAvailableMember.SecurityIdentifier);
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
