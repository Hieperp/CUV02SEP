using System;
using System.Windows.Forms;
using TotalCore.Extensions;
using TotalModel.Helpers;
using TotalSmartCoding.Libraries;

namespace TotalSmartCoding.Views.Mains
{
    public partial class ConnectServer : Form
    {
        private bool specifyNewRole;

        public ConnectServer(bool specifyNewRole)
        {
            InitializeComponent();

            this.specifyNewRole = specifyNewRole;
        }

        private void ConnectServer_Load(object sender, EventArgs e)
        {
            this.textexApplicationRoleName.Text = ApplicationRoles.Name;
            this.textexApplicationRolePassword.Text = ApplicationRoles.Password;

            this.textexApplicationRoleName.Visible = this.specifyNewRole;
            this.textexApplicationRolePassword.Visible = this.specifyNewRole;
            this.labelApplicationRolePassword.Visible = this.specifyNewRole;
            this.buttonConnect.Visible = this.specifyNewRole;
            this.buttonResetApplicationRolePassword.Visible = !this.specifyNewRole;

            if (!this.specifyNewRole)
            {
                this.Text = "Fail to connect to server";
                this.labelApplicationRoleName.Text = "The program on this computer can not connect to server." + "\r\n" + "\r\n" + "Please contact your administrator for more information.";
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.buttonConnect))
            {
                if (this.textexApplicationRoleName.Text.Trim() != "" && this.textexApplicationRolePassword.Text.Trim() != "")
                {
                    ApplicationRoles.Name = this.textexApplicationRoleName.Text.Trim();
                    ApplicationRoles.Password = this.textexApplicationRolePassword.Text.Trim();

                    CommonConfigs.AddUpdateAppSetting("SecureCode", SecurePassword.Encrypt(ApplicationRoles.Password));
                    CommonConfigs.AddUpdateAppSetting("SecurePrincipal", SecurePassword.Encrypt(ApplicationRoles.Name));

                    this.DialogResult = DialogResult.OK;
                }
            }
            else
                if (sender.Equals(this.buttonResetApplicationRolePassword))
                {
                    CommonConfigs.AddUpdateAppSetting("SecureCode", "");
                    this.DialogResult = DialogResult.OK;
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
