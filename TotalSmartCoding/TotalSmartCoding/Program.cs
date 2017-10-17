using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

using TotalBase;
using TotalBase.Enums;
using System.Threading;

using TotalSmartCoding.Libraries;
using TotalSmartCoding.Views.Mains;
using TotalSmartCoding.Views.Productions;
using TotalSmartCoding.Views.Inventories.Pickups;
using TotalSmartCoding.Views.Inventories.GoodsIssues;


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
    }
}
