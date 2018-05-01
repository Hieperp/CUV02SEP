﻿using System;
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

        private Binding bindingUserID;
        private BindingList<UserAccessControlDTO> bindingListUserAccessControls;

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
                this.fastUserGroups.AboutToCreateGroups += fastNMVNTasks_AboutToCreateGroups;

                this.LoadUserGroups();



                this.treeUserID.RootKeyValue = 0;
                this.treeUserID.SelectedIndexChanged += treeUserID_SelectedIndexChanged;

                this.comboActiveOption.SelectedIndex = 0;

                this.comboUserID.ComboBox.DisplayMember = CommonExpressions.PropertyName<UserIndex>(p => p.UserName);
                this.comboUserID.ComboBox.ValueMember = CommonExpressions.PropertyName<UserIndex>(p => p.UserID);
                this.bindingUserID = this.comboUserID.ComboBox.DataBindings.Add("SelectedValue", this, "SelectedUserID", true, DataSourceUpdateMode.OnPropertyChanged);


                this.gridexUserGroupControls.AutoGenerateColumns = false;
                this.gridexUserGroupControls.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.bindingListUserAccessControls = new BindingList<UserAccessControlDTO>();
                this.gridexUserGroupControls.DataSource = this.bindingListUserAccessControls;
                this.bindingListUserAccessControls.ListChanged += bindingListUserAccessControls_ListChanged;

                StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.gridexUserGroupControls);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        #region

        private void LoadUserGroups()
        {
            try
            {
                //OPTION: TRY TO KEEP LAST SelectedUserID                int lastSelectedUserID = this.SelectedUserID;
                this.fastUserGroups.SetObjects(this.userGroupAPIs.GetUserGroupIndexes());
                this.fastUserGroups.Sort(this.olvUserGroupType, SortOrder.Ascending);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        #endregion a

        #region Select User
        private void comboActiveOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadUserTrees();
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }

        }

        private void LoadUserTrees()
        {
            try
            {
                int lastSelectedUserID = this.SelectedUserID;

                this.comboUserID.ComboBox.DataSource = this.userAPIs.GetUserIndexes(this.comboActiveOption.SelectedIndex == 0 ? GlobalEnums.ActiveOption.Active : GlobalEnums.ActiveOption.Both);

                IList<UserTree> userTrees = this.userAPIs.GetUserTrees(this.comboActiveOption.SelectedIndex == 0 ? GlobalEnums.ActiveOption.Active : GlobalEnums.ActiveOption.Both);
                this.treeUserID.DataSource = new BindingSource(userTrees, "");
                this.treeUserID.ExpandAll();

                if (this.SelectedUserID != lastSelectedUserID)
                { //OPTION: TRY TO KEEP LAST SelectedUserID
                    UserTree userTree = userTrees.FirstOrDefault(w => w.PrimaryID == lastSelectedUserID);
                    if (userTree != null) this.treeUserID.SelectObject(userTree);
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void treeUserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int? selectedUserID = this.getSelectedUserID();
                if (selectedUserID != null && selectedUserID != this.SelectedUserID)
                {
                    foreach (UserIndex userIndex in this.comboUserID.Items)
                    {
                        if (userIndex.UserID == (int)selectedUserID)
                            this.comboUserID.SelectedIndex = this.comboUserID.Items.IndexOf(userIndex);
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private int? getSelectedUserID()
        {
            if (this.treeUserID.SelectedObject != null)
            {
                UserTree userTree = (UserTree)this.treeUserID.SelectedObject;
                if (userTree != null && userTree.ParameterName == "UserID") return userTree.PrimaryID; else return null;
            }
            else return null;
        }


        private void comboUserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboUserID.SelectedItem != null)
            {
                UserIndex userIndex = this.comboUserID.SelectedItem as UserIndex;
                if (userIndex != null)
                {
                    this.SelectedUserIndex = userIndex;
                    this.comboOrganizationalUnit.Text = this.SelectedUserIndex.FullyQualifiedOrganizationalUnitName;
                    this.comboInActive.Text = this.SelectedUserIndex.InActive ? "In Active" : "Active";

                    this.buttonUserToggleVoid.Enabled = !this.SelectedUserIndex.IsDatabaseAdmin;
                    this.buttonUserUnregister.Enabled = !this.SelectedUserIndex.IsDatabaseAdmin && this.userRepository.GetEditable(this.SelectedUserIndex.UserID);

                    this.GetUserAccessControls();
                }
            }
        }

        #endregion Select User

        #region Handle Task
        private void fastNMVNTasks_AboutToCreateGroups(object sender, BrightIdeasSoftware.CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "Assembly-32";
                    olvGroup.Subtitle = "Count: " + olvGroup.Contents.Count.ToString() + " Task" + (olvGroup.Contents.Count > 1 ? "s" : "");
                }
            }
        }

        private UserIndex SelectedUserIndex { get; set; }
        private int selectedUserID;
        public int SelectedUserID
        {
            get { return this.selectedUserID; }
            set
            {
                if (this.selectedUserID != value)
                {
                    this.selectedUserID = value;
                    this.GetUserAccessControls();
                }
            }
        }


        private void fastUserGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetUserAccessControls();
        }

        private void GetUserAccessControls()
        {
            try
            {
                if (this.SelectedUserIndex != null && this.SelectedUserIndex.UserID > 0 && this.fastUserGroups.SelectedObject != null)
                {
                    ModuleDetailIndex moduleDetailIndex = (ModuleDetailIndex)this.fastUserGroups.SelectedObject;
                    if (moduleDetailIndex != null)
                    {
                        IList<UserAccessControl> userAccessControls = this.userAPIs.GetUserAccessControls(this.SelectedUserIndex.UserID, moduleDetailIndex.ModuleDetailID);
                        this.bindingListUserAccessControls.RaiseListChangedEvents = false;
                        Mapper.Map<ICollection<UserAccessControl>, ICollection<UserAccessControlDTO>>(userAccessControls, this.bindingListUserAccessControls);
                        this.bindingListUserAccessControls.RaiseListChangedEvents = true;
                        this.bindingListUserAccessControls.ResetBindings();
                    }
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

        private void bindingListUserAccessControls_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                if (e.PropertyDescriptor != null && e.NewIndex >= 0 && e.NewIndex < this.bindingListUserAccessControls.Count)
                {
                    UserAccessControlDTO userAccessControlDTO = this.bindingListUserAccessControls[e.NewIndex];
                    if (userAccessControlDTO != null)
                    {
                        if (userAccessControlDTO.LocationID != this.SelectedUserIndex.LocationID) { userAccessControlDTO.ApprovalPermitted = false; userAccessControlDTO.UnApprovalPermitted = false; userAccessControlDTO.VoidablePermitted = false; userAccessControlDTO.UnVoidablePermitted = false; }
                        if (userAccessControlDTO.LocationID != this.SelectedUserIndex.LocationID && userAccessControlDTO.AccessLevel > 1) { userAccessControlDTO.AccessLevel = 1; }

                        this.userAPIs.SaveUserAccessControls(userAccessControlDTO.AccessControlID, userAccessControlDTO.AccessLevel, userAccessControlDTO.ApprovalPermitted, userAccessControlDTO.UnApprovalPermitted, userAccessControlDTO.VoidablePermitted, userAccessControlDTO.UnVoidablePermitted, userAccessControlDTO.ShowDiscount);
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
        private void buttonUserRegister_Click(object sender, EventArgs e)
        {
            UserRegister wizardUserRegister = new UserRegister(this.userAPIs, this.organizationalUnitAPIs);
            DialogResult dialogResult = wizardUserRegister.ShowDialog();

            wizardUserRegister.Dispose();
            if (dialogResult == DialogResult.OK) this.LoadUserTrees();
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
                        this.LoadUserTrees();
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void buttonUserToggleVoid_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedUserIndex != null && this.SelectedUserIndex.UserID > 0 && !this.SelectedUserIndex.IsDatabaseAdmin)
                {
                    if (CustomMsgBox.Show(this, "Are you sure you want to " + (this.SelectedUserIndex.InActive ? "enable" : "disable") + " this user registration?" + "\r\n" + "\r\nUser:  " + this.SelectedUserIndex.UserName + "\r\nAt:  " + this.SelectedUserIndex.FullyQualifiedOrganizationalUnitName, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                    {
                        this.userAPIs.UserToggleVoid(this.SelectedUserIndex.UserID, !this.SelectedUserIndex.InActive);
                        this.LoadUserTrees();
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
        #endregion Register, Unuegister, ToggleVoid

        private void buttonAddRemoveOU_Click(object sender, EventArgs e)
        {
            UserGroups wizardUserGroups = new UserGroups(this.userGroupAPIs, sender.Equals(this.buttonAddOU));
            DialogResult dialogResult = wizardUserGroups.ShowDialog();

            wizardUserGroups.Dispose();
            if (dialogResult == DialogResult.OK) this.LoadUserGroups();
        }
    }
}
