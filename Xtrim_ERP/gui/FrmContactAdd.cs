﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.control;

namespace Xtrim_ERP.gui
{
    public partial class FrmContactAdd : Form
    {
        XtrimControl xC;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        public FrmContactAdd(XtrimControl x)
        {
            InitializeComponent();
            xC = x;

        }

        private void FrmContactAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
