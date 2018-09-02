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
        private UserGroupAPIs userGroupAPIs { get; set; }

        private BindingList<UserGroupControlDTO> bindingListUserControls;

        #region Contruction
        public UserControls()
        {
            InitializeComponent();
            try
            {
                this.userGroupAPIs = new UserGroupAPIs(CommonNinject.Kernel.Get<IUserGroupAPIRepository>());

                this.fastUserControlIndexes.ShowGroups = true;
                this.fastUserControlIndexes.AboutToCreateGroups += fastGroups_AboutToCreateGroups;

                this.fastUserGroupDetails.ShowGroups = true;
                this.fastUserGroupDetails.AboutToCreateGroups += fastGroups_AboutToCreateGroups;

                this.gridexUserControls.AutoGenerateColumns = false;
                this.gridexUserControls.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.bindingListUserControls = new BindingList<UserGroupControlDTO>();
                this.gridexUserControls.DataSource = this.bindingListUserControls;
                this.bindingListUserControls.ListChanged += bindingListUserControls_ListChanged;

                StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.gridexUserControls);
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
                this.LoadUserGroups();
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

                customTabCenter.TabPages.Add("tabCenterAA", "Permission Controls          ");
                customTabCenter.TabPages.Add("tabCenterAA", "Users                ");
                customTabCenter.TabPages[0].BackColor = this.panelCenter.BackColor;
                customTabCenter.TabPages[1].BackColor = this.panelCenter.BackColor;

                customTabCenter.TabPages[0].Controls.Add(this.gridexUserControls);
                customTabCenter.TabPages[1].Controls.Add(this.fastUserGroupDetails);
                customTabCenter.TabPages[1].Controls.Add(this.toolUserGroupDetails);

                this.gridexUserControls.Dock = DockStyle.Fill;
                this.fastUserGroupDetails.Dock = DockStyle.Fill;
                this.toolUserGroupDetails.Dock = DockStyle.Top;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
        #endregion Contruction


        #region Add, Remove UserGroup

        private void LoadUserGroups()
        {
            try
            {
                this.fastUserControlIndexes.SetObjects(this.userGroupAPIs.GetUserGroupIndexes());
                this.fastUserControlIndexes.Sort(this.olvUserGroupType, SortOrder.Ascending);

                fastUserGroups_SelectedIndexChanged(this.fastUserControlIndexes, new EventArgs());
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void buttonRegisterDeregisterUser_Click(object sender, EventArgs e)
        {
            UserGroups wizardUserGroups = new UserGroups(this.userGroupAPIs, (sender.Equals(this.buttonDeregisterUser) ? this.SelectedUserGroupIndex : null));
            DialogResult dialogResult = wizardUserGroups.ShowDialog();

            wizardUserGroups.Dispose();
            if (dialogResult == DialogResult.OK) this.LoadUserGroups();
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

        private UserGroupIndex selectedUserGroupIndex;
        private UserGroupIndex SelectedUserGroupIndex
        {
            get { return this.selectedUserGroupIndex; }
            set
            {
                if (this.selectedUserGroupIndex != value)
                {
                    this.selectedUserGroupIndex = value;
                    this.GetUserControls();
                    this.GetUserGroupMembers();
                }
            }
        }

        private void fastUserGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.fastUserControlIndexes.SelectedObject != null)
            {
                UserGroupIndex userGroupIndex = (UserGroupIndex)this.fastUserControlIndexes.SelectedObject;
                if (userGroupIndex != null)
                    this.SelectedUserGroupIndex = userGroupIndex;
            }
            else
            {
                this.GetUserControls();
                this.GetUserGroupMembers();
            }
        }

        private void GetUserGroupMembers()
        {
            try
            {
                if (this.userGroupAPIs != null)
                {
                    this.fastUserGroupDetails.SetObjects(this.userGroupAPIs.GetUserGroupMembers(this.SelectedUserGroupIndex != null ? this.SelectedUserGroupIndex.UserGroupID : 0));
                    this.fastUserGroupDetails.Sort(this.olvUserType, SortOrder.Ascending);
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void GetUserControls()
        {
            try
            {
                if (this.userGroupAPIs != null && this.bindingListUserControls != null)
                {
                    IList<UserGroupControl> userGroupControls = this.userGroupAPIs.GetUserGroupControls(this.SelectedUserGroupIndex != null ? this.SelectedUserGroupIndex.UserGroupID : 0);
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

        private void gridexAccessControls_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.gridexUserControls.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
            if (sender.Equals(this.buttonJoinGroup) && this.SelectedUserGroupIndex != null)
            {
                UserGroupAvailableMembers wizardUserRegister = new UserGroupAvailableMembers(this.userGroupAPIs, this.SelectedUserGroupIndex.UserGroupID);
                dialogResult = wizardUserRegister.ShowDialog(); wizardUserRegister.Dispose();
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

            if (dialogResult == DialogResult.OK) this.GetUserGroupMembers();
        }

        #endregion Add, remove member

        

        #region MERGE CELL
        private void gridexUserControls_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0 || !(e.ColumnIndex == 0 || e.ColumnIndex == 1))
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void gridexUserControls_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || !(e.ColumnIndex == 0 || e.ColumnIndex == 1))
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = gridexUserControls.AdvancedCellBorderStyle.Top;
            }
        }

        private bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = gridexUserControls[column, row];
            DataGridViewCell cell2 = gridexUserControls[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        #endregion MERGE CELL


    }
}
