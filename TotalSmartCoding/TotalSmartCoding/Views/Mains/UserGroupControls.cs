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
    public partial class UserGroupControls : Form
    {
        private IUserRepository userRepository { get; set; }
        private UserAPIs userAPIs { get; set; }
        private OrganizationalUnitAPIs organizationalUnitAPIs { get; set; }

        private UserGroupAPIs userGroupAPIs { get; set; }

        private BindingList<UserGroupControlDTO> bindingListUserGroupControls;

        #region Contruction
        public UserGroupControls()
        {
            InitializeComponent();
            try
            {
                this.SelectedUserID = ContextAttributes.User.UserID;

                ModuleAPIs moduleAPIs = new ModuleAPIs(CommonNinject.Kernel.Get<IModuleAPIRepository>());




                this.userRepository = CommonNinject.Kernel.Get<IUserRepository>();
                this.userAPIs = new UserAPIs(CommonNinject.Kernel.Get<IUserAPIRepository>());
                this.organizationalUnitAPIs = new OrganizationalUnitAPIs(CommonNinject.Kernel.Get<IOrganizationalUnitAPIRepository>());
                this.userGroupAPIs = new UserGroupAPIs(CommonNinject.Kernel.Get<IUserGroupAPIRepository>());


                this.fastUserGroups.ShowGroups = true;
                this.fastUserGroups.AboutToCreateGroups += fastUserGroups_AboutToCreateGroups;

                this.fastUserGroupDetails.ShowGroups = true;
                this.fastUserGroupDetails.AboutToCreateGroups += fastUserGroups_AboutToCreateGroups;



                this.gridexUserGroupControls.AutoGenerateColumns = false;
                this.gridexUserGroupControls.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.bindingListUserGroupControls = new BindingList<UserGroupControlDTO>();
                this.gridexUserGroupControls.DataSource = this.bindingListUserGroupControls;
                this.bindingListUserGroupControls.ListChanged += bindingListUserGroupControls_ListChanged;

                StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.gridexUserGroupControls);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void UserGroupControls_Load(object sender, EventArgs e)
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

                customTabCenter.TabPages[0].Controls.Add(this.gridexUserGroupControls);
                customTabCenter.TabPages[1].Controls.Add(this.fastUserGroupDetails);
                customTabCenter.TabPages[1].Controls.Add(this.toolUserGroupDetails);

                this.gridexUserGroupControls.Dock = DockStyle.Fill;
                this.fastUserGroupDetails.Dock = DockStyle.Fill;
                this.toolUserGroupDetails.Dock = DockStyle.Top;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
        #endregion Contruction


        #region

        private void LoadUserGroups()
        {
            try
            {
                //OPTION: TRY TO KEEP LAST SelectedUserID                int lastSelectedUserID = this.SelectedUserID;
                this.fastUserGroups.SetObjects(this.userGroupAPIs.GetUserGroupIndexes());
                this.fastUserGroups.Sort(this.olvUserType, SortOrder.Ascending);

                fastUserGroups_SelectedIndexChanged(this.fastUserGroups, new EventArgs());
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        #endregion

        #region Handle Task
        private void fastUserGroups_AboutToCreateGroups(object sender, BrightIdeasSoftware.CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "Assembly-32";
                    olvGroup.Subtitle = "Count: " + olvGroup.Contents.Count.ToString() + " Group" + (olvGroup.Contents.Count > 1 ? "s" : "");
                }
            }
        }

        //private UserIndex SelectedUserIndex { get; set; }
        //private int selectedUserID;
        //public int SelectedUserID
        //{
        //    get { return this.selectedUserID; }
        //    set
        //    {
        //        if (this.selectedUserID != value)
        //        {
        //            this.selectedUserID = value;
        //            this.GetUserGroupControls();
        //            this.GetUserGroupMembers();
        //        }
        //    }
        //}


        private UserGroupIndex selectedUserGroupIndex;
        private UserGroupIndex SelectedUserGroupIndex
        {
            get { return this.selectedUserGroupIndex; }
            set
            {
                if (this.selectedUserGroupIndex != value)
                {
                    this.selectedUserGroupIndex = value;
                    this.GetUserGroupControls();
                    this.GetUserGroupMembers();
                }
            }
        }

        private void fastUserGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.fastUserGroups.SelectedObject != null)
            {
                UserGroupIndex userGroupIndex = (UserGroupIndex)this.fastUserGroups.SelectedObject;
                if (userGroupIndex != null)
                    this.SelectedUserGroupIndex = userGroupIndex;
            }
            else
            {
                this.GetUserGroupControls();
                this.GetUserGroupMembers();
            }
        }

        private void GetUserGroupMembers()
        {
            try
            {
                this.fastUserGroupDetails.SetObjects(this.userGroupAPIs.GetUserGroupMembers(this.SelectedUserGroupIndex != null ? this.SelectedUserGroupIndex.UserGroupID : 0));
                this.fastUserGroupDetails.Sort(this.olvColumn1, SortOrder.Ascending);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void GetUserGroupControls()
        {
            try
            {
                if (this.userGroupAPIs != null && this.bindingListUserGroupControls != null)
                {
                    IList<UserGroupControl> userGroupControls = this.userGroupAPIs.GetUserGroupControls(this.SelectedUserGroupIndex != null ? this.SelectedUserGroupIndex.UserGroupID : 0);
                    this.bindingListUserGroupControls.RaiseListChangedEvents = false;
                    Mapper.Map<ICollection<UserGroupControl>, ICollection<UserGroupControlDTO>>(userGroupControls, this.bindingListUserGroupControls);
                    this.bindingListUserGroupControls.RaiseListChangedEvents = true;
                    this.bindingListUserGroupControls.ResetBindings();
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void gridexAccessControls_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.gridexUserGroupControls.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void bindingListUserGroupControls_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                if (e.PropertyDescriptor != null && e.NewIndex >= 0 && e.NewIndex < this.bindingListUserGroupControls.Count)
                {
                    UserGroupControlDTO userGroupControlDTO = this.bindingListUserGroupControls[e.NewIndex];
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

        #region Register, Unuegister, ToggleVoid
        private void UserGroupAddRemoveMember_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            if (sender.Equals(this.buttonUserGroupAddMember) && this.SelectedUserGroupIndex != null)
            {
                UserGroupAvailableMembers wizardUserRegister = new UserGroupAvailableMembers(this.userGroupAPIs, this.SelectedUserGroupIndex.UserGroupID);
                dialogResult = wizardUserRegister.ShowDialog(); wizardUserRegister.Dispose();
            }
            if (sender.Equals(this.buttonUserGroupRemoveMember) && this.SelectedUserGroupIndex != null && this.fastUserGroupDetails.SelectedObject != null)
            {
                UserGroupAvailableMember userGroupAvailableMember = (UserGroupAvailableMember)this.fastUserGroupDetails.SelectedObject;
                if (userGroupAvailableMember != null && CustomMsgBox.Show(this, "Are you sure you want to add: " + "\r\n" + "\r\n" + userGroupAvailableMember.UserName + "\r\n" + "\r\n" + "to this group?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    this.userGroupAPIs.UserGroupRemoveMember(this.SelectedUserGroupIndex.UserGroupID, userGroupAvailableMember.SecurityIdentifier);
                    this.DialogResult = DialogResult.OK;
                }
            }

            //if (dialogResult == DialogResult.OK) this.LoadUserTrees();
        }

        private void buttonUserUnregister_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedUserIndex != null && this.SelectedUserIndex.UserID > 0 && !this.SelectedUserIndex.IsDatabaseAdmin)
                {
                    if (CustomMsgBox.Show(this, "Are you sure you want to cancel this user registration?" + "\r\n" + "\r\nUser:  " + this.SelectedUserIndex.UserName + "\r\nAt:  " + this.SelectedUserIndex.FullyQualifiedOrganizationalUnitName, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        this.userAPIs.UserUnregister(this.SelectedUserIndex.UserID, this.SelectedUserIndex.UserName, this.SelectedUserIndex.FullyQualifiedOrganizationalUnitName);
                        //this.LoadUserTrees();
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
        #endregion Register, Unuegister, ToggleVoid

        private void buttonAddRemoveUserGroup_Click(object sender, EventArgs e)
        {
            UserGroups wizardUserGroups = new UserGroups(this.userGroupAPIs, (sender.Equals(this.buttonRemoveUserGroup) ? this.SelectedUserGroupIndex : null));
            DialogResult dialogResult = wizardUserGroups.ShowDialog();

            wizardUserGroups.Dispose();
            if (dialogResult == DialogResult.OK) this.LoadUserGroups();
        }

        #region MERGE CELL
        private void gridexUserGroupControls_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0 || !(e.ColumnIndex == 0 || e.ColumnIndex == 1))
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void gridexUserGroupControls_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                e.AdvancedBorderStyle.Top = gridexUserGroupControls.AdvancedCellBorderStyle.Top;
            }
        }

        private bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = gridexUserGroupControls[column, row];
            DataGridViewCell cell2 = gridexUserGroupControls[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        #endregion MERGE CELL


    }
}
