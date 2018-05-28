using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Xtrim_ERP.gui
{
    public partial class RibbonForm2 : C1.Win.C1Ribbon.C1RibbonForm
    {
        public RibbonForm2()
        {
            InitializeComponent();
        }

        private void c1Ribbon1_RibbonEvent(object sender, C1.Win.C1Ribbon.RibbonEventArgs e)
        {
            sB.Text = "5555555555555555555555555555555555555555";
        }

        private void RibbonForm2_Load(object sender, EventArgs e)
        {

        }
    }
}
