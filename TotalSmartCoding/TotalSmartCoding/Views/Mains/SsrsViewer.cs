﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalSmartCoding.Views.Mains
{
    public partial class SsrsViewer : Form
    {
        public SsrsViewer()
        {
            InitializeComponent();
        }

        private void SsrsViewer_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
