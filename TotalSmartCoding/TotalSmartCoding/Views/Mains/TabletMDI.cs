using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TotalSmartCoding.Libraries.Helpers;

namespace TotalSmartCoding.Views.Mains
{
    public partial class TabletMDI : Form
    {
        private Form childForm;
        public TabletMDI(Form childForm)
        {
            InitializeComponent();
            this.childForm = childForm;
        }

        private void TabletMDI_Load(object sender, EventArgs e)
        {
            try
            {
                if (childForm != null)
                {
                    childForm.MdiParent = this;
                    //childForm.Owner = this;
                    childForm.WindowState = FormWindowState.Maximized;
                    childForm.Show();
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void TabletMDI_MdiChildActivate(object sender, EventArgs e)
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
    }
}
