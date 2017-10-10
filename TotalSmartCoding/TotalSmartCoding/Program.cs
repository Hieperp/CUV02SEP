using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

using TotalBase;
using TotalBase.Enums;
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
        [STAThread]
        static void Main()
        {
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
