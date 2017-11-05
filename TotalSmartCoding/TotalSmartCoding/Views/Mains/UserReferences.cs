using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Ninject;
using BrightIdeasSoftware;

using TotalModel.Models;

using TotalCore.Repositories.Generals;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.Controllers.APIs.Generals;
using TotalBase;


namespace TotalSmartCoding.Views.Mains
{
    public partial class UserReferences : Form
    {
        private Binding bindingUserID;
        public int UserID { get; set; }
        public UserReferences()
        {
            InitializeComponent();
            try
            {
                this.UserID = ContextAttributes.User.UserID;

                ModuleAPIs moduleAPIs = new ModuleAPIs(CommonNinject.Kernel.Get<IModuleAPIRepository>());

                this.fastNMVNTasks.ShowGroups = true;
                this.fastNMVNTasks.AboutToCreateGroups += fastNMVNTasks_AboutToCreateGroups;
                this.fastNMVNTasks.SetObjects(moduleAPIs.GetModuleDetailIndexes());
                this.fastNMVNTasks.Sort(this.olvModuleName, SortOrder.Ascending);

                UserAPIs userAPIs = new UserAPIs(CommonNinject.Kernel.Get<IUserAPIRepository>());
                this.comboUserID.ComboBox.DataSource = userAPIs.GetUserIndexes();
                this.comboUserID.ComboBox.DisplayMember = CommonExpressions.PropertyName<UserIndex>(p => p.UserName);
                this.comboUserID.ComboBox.ValueMember = CommonExpressions.PropertyName<UserIndex>(p => p.UserID);
                this.bindingUserID = this.comboUserID.ComboBox.DataBindings.Add("SelectedValue", this, CommonExpressions.PropertyName<UserIndex>(p => p.UserID), true, DataSourceUpdateMode.OnPropertyChanged);

            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        void fastNMVNTasks_AboutToCreateGroups(object sender, BrightIdeasSoftware.CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "Sign_Order_32";
                    olvGroup.Subtitle = "Count: " + olvGroup.Contents.Count.ToString() + " Task" + (olvGroup.Contents.Count > 1 ? "s" : "");
                }
            }
        }
    }
}
