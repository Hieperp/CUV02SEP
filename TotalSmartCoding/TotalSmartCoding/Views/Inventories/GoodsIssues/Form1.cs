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

namespace TotalSmartCoding.Views.Inventories.GoodsIssues
{
    public partial class Form1 : Form, IToolstripMerge
    {
        public virtual ToolStrip toolstripChild { get; protected set; }

        public Form1()
        {
            InitializeComponent();

            this.toolstripChild = this.toolStrip1;
        }
    }
}
