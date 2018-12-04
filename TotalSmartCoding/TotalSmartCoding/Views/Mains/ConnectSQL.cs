using System;
using System.Windows.Forms;

using Ninject;

using TotalCore.Extensions;
using TotalCore.Repositories;
using TotalModel.Helpers;
using TotalSmartCoding.Libraries;

namespace TotalSmartCoding.Views.Mains
{
    public partial class ConnectSQL : Form
    {
        private bool specifyNewUser;

        public ConnectSQL(bool specifyNewUser)
        {
            InitializeComponent();

            this.specifyNewUser = specifyNewUser;
        }

        private void ConnectSQL_Load(object sender, EventArgs e)
        {
            this.textexApplicationUserName.Text = ApplicationUsers.Name;
            this.textexApplicationUserPassword.Text = ApplicationUsers.Password;

            this.textexApplicationUserName.Visible = this.specifyNewUser;
            this.textexApplicationUserPassword.Visible = this.specifyNewUser;
            this.labelApplicationUserPassword.Visible = this.specifyNewUser;
            this.buttonUpdate.Visible = this.specifyNewUser;
            this.buttonApplicationUserRequired.Visible = !this.specifyNewUser && !ApplicationUsers.Required;
            this.buttonApplicationUserIgnored.Visible = !this.specifyNewUser && ApplicationUsers.Required;

            if (!this.specifyNewUser)
            {
                this.Text = "Fail to connect to server";
                this.labelApplicationUserName.Text = "The program on this computer can not connect to server." + "\r\n" + "\r\n" + "Please contact your administrator for more information.";
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.buttonUpdate))
            {
                if (this.textexApplicationUserName.Text.Trim() != "" && this.textexApplicationUserPassword.Text.Trim() != "")
                {
                    IBaseRepository baseRepository = CommonNinject.Kernel.Get<IBaseRepository>();
                    if (baseRepository.UpdateApplicationUser(SecurePassword.Encrypt(this.textexApplicationUserName.Text.Trim()), SecurePassword.Encrypt(this.textexApplicationUserPassword.Text.Trim())) == 1)
                        this.DialogResult = DialogResult.OK;
                    else
                        throw new Exception("Fail to update SQL login.");
                }
            }
            else
                if (sender.Equals(this.buttonApplicationUserRequired) || sender.Equals(this.buttonApplicationUserIgnored))
                {
                    CommonConfigs.AddUpdateAppSetting("ApplicationUserRequired", sender.Equals(this.buttonApplicationUserRequired) ? "true" : "false");

                    CustomMsgBox.Show(this, "Please open your program again in order to take new effect.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.DialogResult = DialogResult.Cancel;
                }
                else
                    this.DialogResult = DialogResult.Cancel;
        }

        private void textexApplicationUser_TextChanged(object sender, EventArgs e)
        {
            this.buttonUpdate.Enabled = this.textexApplicationUserName.Text.Trim() != "" && this.textexApplicationUserPassword.Text.Trim() != "";
        }
    }
}
