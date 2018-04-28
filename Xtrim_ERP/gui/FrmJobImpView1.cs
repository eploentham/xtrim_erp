using System;
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
    public partial class FrmJobImpView1 : Form
    {
        XtrimControl xC;
        public FrmJobImpView1(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
        }

        private void FrmJobImpView1_Load(object sender, EventArgs e)
        {

        }
    }
}
