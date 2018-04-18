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
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public partial class FrmImportData : Form
    {
        XtrimControl xC;
        public FrmImportData(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            chk32.Checked = true;
            chk64.Checked = false;
            chkImpNew.Checked = true;
            chkCusNew.Checked = true;
            chkExpConsNew.Checked = true;
            chkImpSuppNew.Checked = true;
            chkConsNew.Checked = true;
            pic1.Image = Resources.images;
            pic1.Hide();
            btnCus.Enabled = false;
            pB1.Hide();
        }

        private void FrmImportData_Load(object sender, EventArgs e)
        {

        }        

        private void btnPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "access files (*.mdb)|*.mdb|All files (*.*)|*.*";
            ofd.InitialDirectory = @"C:\";
            ofd.Title = "Please select an image file to encrypt.";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPathA.Value = ofd.FileName;
            }
        }
        private void chkTestConnection()
        {
            if (chk32.Checked)
            {
                if (xC.xtDB.imdDB.testConnection(txtPathA.Value.ToString(), "32").Equals("ok"))
                {
                    pic1.Show();
                    btnCus.Enabled = true;
                    btnCons.Enabled = true;
                    btnExpCons.Enabled = true;
                    btnImpSupp.Enabled = true;
                }
                else
                {
                    pic1.Hide();
                    btnCus.Enabled = false;
                    btnCons.Enabled = false;
                    btnExpCons.Enabled = false;
                    btnImpSupp.Enabled = false;
                }
            }
            else
            {
                if (xC.xtDB.imdDB.testConnection(txtPathA.Value.ToString(), "64").Equals("ok"))
                {
                    pic1.Show();
                    btnCus.Enabled = true;
                    btnCons.Enabled = true;
                    btnExpCons.Enabled = true;
                    btnImpSupp.Enabled = true;
                }
                else
                {
                    pic1.Hide();
                    btnCus.Enabled = false;
                    btnCons.Enabled = false;
                    btnExpCons.Enabled = false;
                    btnImpSupp.Enabled = false;
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            chkTestConnection();

        }

        private void chk64_CheckedChanged(object sender, EventArgs e)
        {
            chkTestConnection();
        }

        private void chk32_CheckedChanged(object sender, EventArgs e)
        {
            chkTestConnection();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            xC.xtDB.imdDB.ImportMEIOSYSimport(chkImpNew.Checked ? "new" : "append", pB1);
        }

        private void btnCus_Click(object sender, EventArgs e)
        {
            xC.xtDB.imdDB.ImportOpenJOBcustomer(txtPathA.Value.ToString(), chkCusNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1);
        }

        private void btnCons_Click(object sender, EventArgs e)
        {
            xC.xtDB.imdDB.ImportOpenJOBconsignee(txtPathA.Value.ToString(), chkConsNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1);
        }

        private void btnExpCons_Click(object sender, EventArgs e)
        {
            xC.xtDB.imdDB.ImportOpenJOBExpConsignee(txtPathA.Value.ToString(), chkExpConsNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1);
        }

        private void btnImpSupp_Click(object sender, EventArgs e)
        {
            xC.xtDB.imdDB.ImportOpenJOBImpSupplier(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1);
        }
    }
}
