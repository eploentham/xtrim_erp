﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xtrim_ERP.gui
{
    public partial class FrmSplash : Form
    {
        //ProgressBar pB;
        public FrmSplash()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            pB1.Minimum = 0;
            pB1.Maximum = 100;
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
