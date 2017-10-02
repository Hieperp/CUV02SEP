using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TotalBase.Enums;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.Views.Commons;

using TotalSmartCoding.Views.Productions;
using TotalSmartCoding.Views.Inventories.Pickups;
using TotalSmartCoding.Views.Inventories.GoodsIssues;
using TotalSmartCoding.Properties;
using System.IO;
using System.Reflection;
using TotalBase;
using TotalSmartCoding.Views.Sales.SalesOrders;
using TotalSmartCoding.Views.Sales.DeliveryAdvices;
using TotalSmartCoding.Views.Inventories.WarehouseAdjustments;
using TotalSmartCoding.Views.Inventories.GoodsReceipts;

namespace TotalSmartCoding.Views.Mains
{
    public partial class TabletMDI : Form
    {
        #region Contractor

        private Form childForm;
        private GlobalEnums.NmvnTaskID nmvnTaskID;
        
        public TabletMDI()
            : this(GlobalEnums.NmvnTaskID.UnKnown)
        { }

        public TabletMDI(GlobalEnums.NmvnTaskID nmvnTaskID)
            : this(nmvnTaskID, null)
        { }

        public TabletMDI(Form childForm)
            : this(GlobalEnums.NmvnTaskID.UnKnown, childForm)
        { }

        public TabletMDI(GlobalEnums.NmvnTaskID nmvnTaskID, Form childForm)
        {
            InitializeComponent();
            try
            {
                this.nmvnTaskID = nmvnTaskID;
                this.childForm = childForm;

                this.Size = new Size(1120, 600); this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; this.MinimizeBox = false; this.MaximizeBox = false; this.WindowState = FormWindowState.Normal;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void MasterMdi_Load(object sender, EventArgs e)
        {
            try
            {
                this.childForm.MdiParent = this;
                this.childForm.WindowState = FormWindowState.Maximized;
                this.childForm.Show();
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
        #endregion Contractor


        #region Form Events: Merge toolstrip & Set toolbar context
        private void MasterMdi_MdiChildActivate(object sender, EventArgs e)
        {
            try
            {
                ToolStripManager.RevertMerge(this.toolstripMain);
                IToolstripMerge mergeToolstrip = ActiveMdiChild as IToolstripMerge;
                if (mergeToolstrip != null)
                {
                    ToolStripManager.Merge(mergeToolstrip.toolstripChild, toolstripMain);
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
        #endregion Form Events


        #region <Call Tool Strip>
        private void textBoxFilters_TextChanged(object sender, EventArgs e)
        {
            try
            {
                IToolstripTablet toolstripChild = ActiveMdiChild as IToolstripTablet;
                if (toolstripChild != null) toolstripChild.ApplyFilter(this.textBoxFilters.Text);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void buttonClearFilters_Click(object sender, EventArgs e)
        {
            this.textBoxFilters.Text = "";
        }
        #endregion <Call Tool Strip>

        
    }
}
