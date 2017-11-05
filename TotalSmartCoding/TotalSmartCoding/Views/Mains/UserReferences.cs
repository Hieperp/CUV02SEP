using System.Windows.Forms;
using System.Collections.Generic;

using Ninject;
using BrightIdeasSoftware;

using TotalModel.Models;

using TotalCore.Repositories.Generals;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Controllers.APIs.Generals;



namespace TotalSmartCoding.Views.Mains
{
    public partial class UserReferences : Form
    {
        public UserReferences()
        {
            InitializeComponent();

            ModuleAPIs moduleAPIs = new ModuleAPIs(CommonNinject.Kernel.Get<IModuleAPIRepository>());

            this.fastNMVNTasks.ShowGroups = true;
            this.fastNMVNTasks.AboutToCreateGroups += fastNMVNTasks_AboutToCreateGroups;
            this.fastNMVNTasks.SetObjects(moduleAPIs.GetModuleDetailIndexes());
            this.fastNMVNTasks.Sort(this.olvModuleName, SortOrder.Ascending);
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
