using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Ninject;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Helpers;
using TotalCore.Repositories;

using TotalSmartCoding.Libraries;
using TotalSmartCoding.Views.Mains;
using TotalSmartCoding.Views.Productions;
using TotalSmartCoding.Views.Inventories.Pickups;
using TotalSmartCoding.Views.Inventories.GoodsIssues;
using TotalSmartCoding.Libraries.Helpers;
using TotalCore.Extensions;


namespace TotalSmartCoding
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static Mutex mutex = null;
        [STAThread]
        static void Main()
        {
            const string applicationName = "TotalSmartCodingSolution"; bool createdNew;
            mutex = new Mutex(true, applicationName, out createdNew);
            if (!createdNew) { return; }   //app is already running! Exiting the application  

            Registries.ProductName = Application.ProductName.ToUpper();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            AutoMapperConfig.SetupMappings();


            ApplicationRoles.Name = CommonConfigs.ReadSetting("SecurePrincipal");
            ApplicationRoles.Password = CommonConfigs.ReadSetting("SecureCode");

            if (ApplicationRoles.Name != "") ApplicationRoles.Name = SecurePassword.Decrypt(ApplicationRoles.Name);
            if (ApplicationRoles.Password != "") ApplicationRoles.Password = SecurePassword.Decrypt(ApplicationRoles.Password);
            
            TrialConnects trialConnects = new TrialConnects();
            DialogResult trialConnectResult = trialConnects.Connected();
            if (trialConnectResult == DialogResult.Yes)
            {
                Logon logon = new Logon();

                if (logon.ShowDialog() == DialogResult.OK)
                {
                    if (GlobalVariables.FillingLineID == GlobalVariables.FillingLine.Smallpack || GlobalVariables.FillingLineID == GlobalVariables.FillingLine.Pail || GlobalVariables.FillingLineID == GlobalVariables.FillingLine.Drum)
                        Application.Run(new MasterMDI(GlobalEnums.NmvnTaskID.SmartCoding, new SmartCoding()));
                    else
                    {
                        if (GlobalVariables.ConfigID == (int)GlobalVariables.FillingLine.Pickup)
                            Application.Run(new MasterMDI(GlobalEnums.NmvnTaskID.Pickup, new Pickups()));
                        else if (GlobalVariables.ConfigID == (int)GlobalVariables.FillingLine.GoodsIssue)
                            Application.Run(new MasterMDI(GlobalEnums.NmvnTaskID.GoodsIssue, new GoodsIssues()));
                        else
                            Application.Run(new MasterMDI());
                    }
                }
                logon.Dispose();
            }
            else
                if (trialConnectResult == DialogResult.No)
                {
                    ConnectServer connectServer = new ConnectServer(false);
                    connectServer.ShowDialog(); connectServer.Dispose();
                }
        }

    }

    public class TrialConnects
    {
        public DialogResult Connected()
        {
            try
            {
                if (ApplicationRoles.Name == "" || ApplicationRoles.Password == "")
                {
                    ConnectServer connectServer = new ConnectServer(true);
                    DialogResult connectServerResult = connectServer.ShowDialog(); connectServer.Dispose();
                    if (connectServerResult != DialogResult.OK) return DialogResult.Cancel;
                }

                IBaseRepository baseRepository = CommonNinject.Kernel.Get<IBaseRepository>();
                return baseRepository.GetVersionID((int)GlobalVariables.FillingLine.None) != null ? DialogResult.Yes : DialogResult.No;
            }
            catch (Exception exception)
            {
                ApplicationRoles.ExceptionMessage = exception.Message;
                ExceptionHandlers.ShowExceptionMessageBox(new Form(), exception);
                return DialogResult.No;
            }
        }
    }
}
