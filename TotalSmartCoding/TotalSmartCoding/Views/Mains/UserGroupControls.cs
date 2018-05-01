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

        private Binding bindingUserID;
        private BindingList<UserGroupControlDTO> bindingListUserGroupControls;

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



                this.treeUserID.RootKeyValue = 0;
                this.treeUserID.SelectedIndexChanged += treeUserID_SelectedIndexChanged;

                this.comboActiveOption.SelectedIndex = 0;

                this.comboUserID.ComboBox.DisplayMember = CommonExpressions.PropertyName<UserIndex>(p => p.UserName);
                this.comboUserID.ComboBox.ValueMember = CommonExpressions.PropertyName<UserIndex>(p => p.UserID);
                this.bindingUserID = this.comboUserID.ComboBox.DataBindings.Add("SelectedValue", this, "SelectedUserID", true, DataSourceUpdateMode.OnPropertyChanged);


                this.gridexUserGroupControls.AutoGenerateColumns = false;
                this.gridexUserGroupControls.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.bindingListUserGroupControls = new BindingList<UserGroupControlDTO>();
                this.gridexUserGroupControls.DataSource = this.bindingListUserGroupControls;
                this.bindingListUserGroupControls.ListChanged += bindingListUserGroupControls_ListChanged;

                StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.gridexUserGroupControls);

                this.LoadUserGroups();
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

                fastUserGroups_SelectedIndexChanged(this.fastUserGroups, new EventArgs());
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

                    this.GetUserGroupControls();
                }
            }
        }

        #endregion Select User

        #region Handle Task
        private void fastUserGroups_AboutToCreateGroups(object sender, BrightIdeasSoftware.CreateGroupsEventArgs e)
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
                    this.GetUserGroupControls();
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
                    this.GetUserGroupControls();
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
                this.GetUserGroupControls();
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
                        //this.userGroupAPIs.SaveUserGroupControls(userGroupControlDTO.AccessControlID, userGroupControlDTO.AccessLevel, userGroupControlDTO.ApprovalPermitted, userGroupControlDTO.UnApprovalPermitted, userGroupControlDTO.VoidablePermitted, userGroupControlDTO.UnVoidablePermitted, userGroupControlDTO.ShowDiscount);
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
