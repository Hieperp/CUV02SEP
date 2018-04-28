using System;
using System.Windows.Forms;

using TotalModel.Helpers;
using TotalSmartCoding.Libraries;

namespace TotalSmartCoding.Views.Mains
{
    public partial class ConnectServer : Form
    {
        public ConnectServer()
        {
            InitializeComponent();
        }

        private void ConnectServer_Load(object sender, EventArgs e)
        {
            this.textexApplicationRoleName.Text = ApplicationRoles.Name;
            this.textexApplicationRolePassword.Text = ApplicationRoles.Password;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.buttonConnect))
            {
                if (this.textexApplicationRoleName.Text.Trim() != "" && this.textexApplicationRolePassword.Text.Trim() != "")
                {
                    ApplicationRoles.Name = this.textexApplicationRoleName.Text.Trim();
                    ApplicationRoles.Password = this.textexApplicationRolePassword.Text.Trim();

                    CommonConfigs.AddUpdateAppSetting("SecureCode", ApplicationRoles.Password);
                    CommonConfigs.AddUpdateAppSetting("SecurePrincipal", ApplicationRoles.Name);

                    this.DialogResult = DialogResult.OK;
                }
            }
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void textexApplicationRole_TextChanged(object sender, EventArgs e)
        {
            this.buttonConnect.Enabled = this.textexApplicationRoleName.Text.Trim() != "" && this.textexApplicationRolePassword.Text.Trim() != "";
        }
    }
}
