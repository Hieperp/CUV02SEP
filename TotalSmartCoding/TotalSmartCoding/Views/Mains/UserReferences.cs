﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms;

using Ninject;
using BrightIdeasSoftware;

using TotalModel.Models;

using TotalCore.Repositories.Generals;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.Controllers.APIs.Generals;
using TotalBase;
using TotalSmartCoding.Libraries.StackedHeaders;
using System.ComponentModel;
using AutoMapper;
using TotalDTO.Generals;
using TotalBase.Enums;


namespace TotalSmartCoding.Views.Mains
{
    public partial class UserReferences : Form
    {
        private Binding bindingUserID;
        private UserAPIs userAPIs { get; set; }

        private BindingList<UserAccessControlDTO> bindingListUserAccessControls;

        public UserReferences()
        {
            InitializeComponent();
            try
            {
                this.SelectedUserID = ContextAttributes.User.UserID;

                ModuleAPIs moduleAPIs = new ModuleAPIs(CommonNinject.Kernel.Get<IModuleAPIRepository>());

                this.fastNMVNTasks.ShowGroups = true;
                this.fastNMVNTasks.AboutToCreateGroups += fastNMVNTasks_AboutToCreateGroups;
                this.fastNMVNTasks.SetObjects(moduleAPIs.GetModuleDetailIndexes());
                this.fastNMVNTasks.Sort(this.olvModuleName, SortOrder.Ascending);

                this.userAPIs = new UserAPIs(CommonNinject.Kernel.Get<IUserAPIRepository>());

                this.comboActiveOption.SelectedIndex = 0;
                this.treeUserID.SelectedIndexChanged += treeUserID_SelectedIndexChanged;


                this.comboUserID.ComboBox.DataSource = this.userAPIs.GetUserIndexes(this.comboActiveOption.SelectedIndex == 0 ? GlobalEnums.ActiveOption.Active : GlobalEnums.ActiveOption.Both);
                this.comboUserID.ComboBox.DisplayMember = CommonExpressions.PropertyName<UserIndex>(p => p.UserName);
                this.comboUserID.ComboBox.ValueMember = CommonExpressions.PropertyName<UserIndex>(p => p.UserID);
                this.bindingUserID = this.comboUserID.ComboBox.DataBindings.Add("SelectedValue", this, "SelectedUserID", true, DataSourceUpdateMode.OnPropertyChanged);


                this.gridexUserAccessControl.AutoGenerateColumns = false;
                this.gridexUserAccessControl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.bindingListUserAccessControls = new BindingList<UserAccessControlDTO>();
                this.gridexUserAccessControl.DataSource = this.bindingListUserAccessControls;
                this.bindingListUserAccessControls.ListChanged += bindingListUserAccessControls_ListChanged;

                StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.gridexUserAccessControl);
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

        private void LoadUserTrees()
        {
            this.treeUserID.RootKeyValue = 0;
            IList<UserTree> userTrees = this.userAPIs.GetUserTrees(this.comboActiveOption.SelectedIndex == 0 ? GlobalEnums.ActiveOption.Active : GlobalEnums.ActiveOption.Both);
            this.treeUserID.DataSource = new BindingSource(userTrees, "");
            this.treeUserID.ExpandAll();
        }

        private void comboUserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboUserID.SelectedItem != null)
            {
                UserIndex userIndex = this.comboUserID.SelectedItem as UserIndex;
                if (userIndex != null)
                {
                    this.SelectedUserIndex = userIndex;
                    this.comboOrganizationalUnit.Text = this.SelectedUserIndex.LocationName + "\\" + this.SelectedUserIndex.OrganizationalUnitName;
                    this.comboInActive.Text = this.SelectedUserIndex.InActive ? "In Active" : "Active";
                }
            }
        }

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


        private void fastNMVNTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetUserAccessControls();
        }

        private void GetUserAccessControls()
        {
            try
            {
                if (this.SelectedUserIndex != null && this.SelectedUserIndex.UserID > 0 && this.fastNMVNTasks.SelectedObject != null)
                {
                    ModuleDetailIndex moduleDetailIndex = (ModuleDetailIndex)this.fastNMVNTasks.SelectedObject;
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
            this.gridexUserAccessControl.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            UserAdd wizardUserAdd = new UserAdd(this.userAPIs);
            DialogResult dialogResult = wizardUserAdd.ShowDialog();

            wizardUserAdd.Dispose();
            if (dialogResult == DialogResult.OK) this.comboUserID.ComboBox.DataSource = this.userAPIs.GetUserIndexes(this.comboActiveOption.SelectedIndex == 0 ? GlobalEnums.ActiveOption.Active : GlobalEnums.ActiveOption.Both);
        }

        private void buttonUserRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedUserIndex != null && this.SelectedUserIndex.UserID > 0)
                {
                    if (CustomMsgBox.Show(this, "Are you sure you want to delete " + this.comboUserID.Text + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                    {
                        this.userAPIs.UserUnregister(this.SelectedUserIndex.UserID);
                        this.comboUserID.ComboBox.DataSource = this.userAPIs.GetUserIndexes(this.comboActiveOption.SelectedIndex == 0 ? GlobalEnums.ActiveOption.Active : GlobalEnums.ActiveOption.Both);
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

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
    }
}
