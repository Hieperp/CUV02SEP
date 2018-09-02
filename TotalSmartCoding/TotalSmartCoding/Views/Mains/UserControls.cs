using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

using Ninject;
using AutoMapper;

using BrightIdeasSoftware;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;
using TotalDTO.Generals;

using TotalCore.Repositories.Generals;

using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.Controllers.APIs.Generals;
using TotalSmartCoding.Libraries.StackedHeaders;


namespace TotalSmartCoding.Views.Mains
{
    public partial class UserControls : Form
    {
        private UserControlAPIs userControlAPIs { get; set; }
        private UserGroupAPIs userGroupAPIs { get; set; }

        private BindingList<UserGroupControlDTO> bindingListUserControls;

        #region Contruction
        public UserControls()
        {
            InitializeComponent();
            try
            {
                this.userControlAPIs = new UserControlAPIs(CommonNinject.Kernel.Get<IUserControlAPIRepository>());
                this.userGroupAPIs = new UserGroupAPIs(CommonNinject.Kernel.Get<IUserGroupAPIRepository>());

                this.fastUserControlIndexes.ShowGroups = true;
                this.fastUserControlIndexes.AboutToCreateGroups += fastGroups_AboutToCreateGroups;

                this.fastUserGroupDetails.ShowGroups = true;
                this.fastUserGroupDetails.AboutToCreateGroups += fastGroups_AboutToCreateGroups;

                this.fastUserSalespersons.ShowGroups = true;
                this.fastUserSalespersons.AboutToCreateGroups += fastGroups_AboutToCreateGroups;

                //this.bindingListUserControls = new BindingList<UserGroupControlDTO>();
                //this.gridexUserControls.DataSource = this.bindingListUserControls;
                //this.bindingListUserControls.ListChanged += bindingListUserControls_ListChanged;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void UserControls_Load(object sender, EventArgs e)
        {
            try
            {
                this.InitializeTabControl();
                this.LoadUserControls();
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        protected void InitializeTabControl()
        {
            try
            {
                CustomTabControl customTabCenter = new CustomTabControl();
                customTabCenter.DisplayStyle = TabStyle.VisualStudio;
                customTabCenter.Font = this.panelCenter.Font;
                panelCenter.Controls.Add(customTabCenter);
                customTabCenter.Dock = DockStyle.Fill;

                customTabCenter.TabPages.Add("tabCenterAA", "Member of Groups            ");
                customTabCenter.TabPages.Add("tabCenterAA", "Salespersons                        ");
                customTabCenter.TabPages[0].BackColor = this.panelCenter.BackColor;
                customTabCenter.TabPages[1].BackColor = this.panelCenter.BackColor;

                customTabCenter.TabPages[0].Controls.Add(this.fastUserGroupDetails);
                customTabCenter.TabPages[0].Controls.Add(this.toolUserGroupDetails);
                customTabCenter.TabPages[1].Controls.Add(this.fastUserSalespersons);
                customTabCenter.TabPages[1].Controls.Add(this.toolUserSalespersons);


                this.fastUserGroupDetails.Dock = DockStyle.Fill;
                this.toolUserGroupDetails.Dock = DockStyle.Top;
                this.fastUserSalespersons.Dock = DockStyle.Fill;
                this.toolUserSalespersons.Dock = DockStyle.Top;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
        #endregion Contruction


        #region Add, Remove UserGroup

        private void LoadUserControls()
        {
            try
            {
                this.fastUserControlIndexes.SetObjects(this.userControlAPIs.GetUserControlIndexes());
                this.fastUserControlIndexes.Sort(this.olvUserControlType, SortOrder.Ascending);

                fastControlGroups_SelectedIndexChanged(this.fastUserControlIndexes, new EventArgs());
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void buttonRegisterDeregisterUser_Click(object sender, EventArgs e)
        {
            //UserGroups wizardUserGroups = new UserGroups(this.userGroupAPIs, (sender.Equals(this.buttonDeregisterUser) ? this.SelectedUserControlIndex : null));
            //DialogResult dialogResult = wizardUserGroups.ShowDialog();

            //wizardUserGroups.Dispose();
            //if (dialogResult == DialogResult.OK) this.LoadUserControls();
        }

        #endregion Add, Remove UserGroup

        #region Handle Task
        private void fastGroups_AboutToCreateGroups(object sender, BrightIdeasSoftware.CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = sender.Equals(this.fastUserControlIndexes) ? "Assembly-32" : "UserGroupN";
                    olvGroup.Subtitle = olvGroup.Contents.Count.ToString() + (sender.Equals(this.fastUserControlIndexes) ? " Group" : " User") + (olvGroup.Contents.Count > 1 ? "s" : "");
                }
            }
        }

        private UserControlIndex selectedUserControlIndex;
        private UserControlIndex SelectedUserControlIndex
        {
            get { return this.selectedUserControlIndex; }
            set
            {
                if (this.selectedUserControlIndex != value)
                {
                    this.selectedUserControlIndex = value;
                    this.GetUserControls();
                    this.GetUserControlGroups();
                }
            }
        }

        private void fastControlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.fastUserControlIndexes.SelectedObject != null)
            {
                UserControlIndex userGroupIndex = (UserControlIndex)this.fastUserControlIndexes.SelectedObject;
                if (userGroupIndex != null)
                    this.SelectedUserControlIndex = userGroupIndex;
            }
            else
            {
                this.GetUserControls();
                this.GetUserControlGroups();
            }
        }

        private void GetUserControlGroups()
        {
            try
            {
                if (this.userControlAPIs != null)
                {
                    this.fastUserGroupDetails.SetObjects(this.userControlAPIs.GetUserControlGroups(this.SelectedUserControlIndex != null ? this.SelectedUserControlIndex.SecurityIdentifier : null));
                    this.fastUserGroupDetails.Sort(this.olvGroupType, SortOrder.Ascending);
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void GetUserControls()
        {
            return; //--xxx
            try
            {
                if (this.userGroupAPIs != null && this.bindingListUserControls != null)
                {
                    IList<UserGroupControl> userGroupControls = this.userGroupAPIs.GetUserGroupControls(this.SelectedUserControlIndex != null ? this.SelectedUserControlIndex.UserID : 0);
                    this.bindingListUserControls.RaiseListChangedEvents = false;
                    Mapper.Map<ICollection<UserGroupControl>, ICollection<UserGroupControlDTO>>(userGroupControls, this.bindingListUserControls);
                    this.bindingListUserControls.RaiseListChangedEvents = true;
                    this.bindingListUserControls.ResetBindings();
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void bindingListUserControls_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                if (e.PropertyDescriptor != null && e.NewIndex >= 0 && e.NewIndex < this.bindingListUserControls.Count)
                {
                    UserGroupControlDTO userGroupControlDTO = this.bindingListUserControls[e.NewIndex];
                    if (userGroupControlDTO != null)
                    {
                        this.userGroupAPIs.SaveUserGroupControls(userGroupControlDTO.UserGroupControlID, userGroupControlDTO.AccessLevel, userGroupControlDTO.ApprovalPermitted, userGroupControlDTO.UnApprovalPermitted, userGroupControlDTO.VoidablePermitted, userGroupControlDTO.UnVoidablePermitted, userGroupControlDTO.ShowDiscount);
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        #endregion Handle Task

        #region Add, remove member
        private void buttonJoinLeaveGroup_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.Cancel;
            if (sender.Equals(this.buttonJoinGroup) && this.SelectedUserControlIndex != null)
            {
                //UserGroupAvailableMembers wizardUserRegister = new UserGroupAvailableMembers(this.userGroupAPIs, this.SelectedUserControlIndex.UserGroupID);
                //dialogResult = wizardUserRegister.ShowDialog(); wizardUserRegister.Dispose();
            }
            if (sender.Equals(this.buttonLeaveGroup) && this.fastUserGroupDetails.SelectedObject != null)
            {
                UserGroupMember userGroupMember = (UserGroupMember)this.fastUserGroupDetails.SelectedObject;
                if (userGroupMember != null && CustomMsgBox.Show(this, "Are you sure you want to remove: " + "\r\n" + "\r\n" + userGroupMember.UserName + "\r\n" + "\r\n" + "from this group?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    this.userGroupAPIs.UserGroupRemoveMember(userGroupMember.UserGroupDetailID);
                    dialogResult = DialogResult.OK;
                }
            }

            if (dialogResult == DialogResult.OK) this.GetUserControlGroups();
        }

        #endregion Add, remove member
    }
}
