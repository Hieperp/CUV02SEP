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

            do
            {
                TrialConnects trialConnects = new TrialConnects();
                if (trialConnects.Connected())
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
                    logon.Dispose(); break;
                }
                else
                {
                    
                }
            } while (true);

        }


    }

    public class TrialConnects
    {
        public bool Connected()
        {
            try
            {
                if (ApplicationRoles.Name == "" || ApplicationRoles.Password == "")
                {
                    ConnectServer connectServer = new ConnectServer();
                    DialogResult connectServerResult = connectServer.ShowDialog(); connectServer.Dispose();
                    if (connectServerResult != DialogResult.OK) break;
                }

                if (ApplicationRoles.Name != "" && ApplicationRoles.Password != "")
                {
                    IBaseRepository baseRepository = CommonNinject.Kernel.Get<IBaseRepository>();
                    return baseRepository.GetVersionID((int)GlobalVariables.FillingLine.None) != null;
                }
                else
                    return false;
            }
            catch (Exception exception)
            {
                ApplicationRoles.ExceptionMessage = exception.Message;
                ExceptionHandlers.ShowExceptionMessageBox(new Form(), exception);
                return false;
            }
        }
    }
}
