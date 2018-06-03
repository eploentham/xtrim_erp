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
using Xtrim_ERP.objdb;
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.gui
{
    public partial class FrmImportData : Form
    {
        XtrimControl xC;
        ImportDataDB imdDB;
        //Form fRm;
        public FrmImportData(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            //fRm = frm;
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
            chkInsrNew.Checked = true;
            chkStfNew.Checked = true;
            chkImp1New.Checked = true;
            chkTmnNew.Checked = true;
            chkFwdNew.Checked = true;
            chkJimBlNew.Checked = true;
            chkImpInvNew.Checked = true;
            pic1.Image = Resources.images;
            pic1.Hide();
            btnCus.Enabled = false;
            btnInsr.Enabled = false;
            btnImp1.Enabled = false;
            btnTmn.Enabled = false;
            btnFwd.Enabled = false;
            btnjimBl.Enabled = false;
            btnImpInv.Enabled = false;
            imdDB = new ImportDataDB(xC.conn);
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
            if (imdDB == null) return;
            if (chk32.Checked)
            {
                if (imdDB.testConnection(txtPathA.Value.ToString(), "32").Equals("ok"))
                {
                    pic1.Show();
                    btnCus.Enabled = true;
                    btnCons.Enabled = true;
                    btnExpCons.Enabled = true;
                    btnImpSupp.Enabled = true;
                    btnInsr.Enabled = true;
                    btnStf.Enabled = true;
                    btnImp1.Enabled = true;
                    btnTmn.Enabled = true;
                    btnFwd.Enabled = true;
                    btnjimBl.Enabled = true;
                    btnImpInv.Enabled = true;
                }
                else
                {
                    pic1.Hide();
                    btnCus.Enabled = false;
                    btnCons.Enabled = false;
                    btnExpCons.Enabled = false;
                    btnImpSupp.Enabled = false;
                    btnInsr.Enabled = false;
                    btnStf.Enabled = false;
                    btnImp1.Enabled = false;
                    btnTmn.Enabled = false;
                    btnFwd.Enabled = false;
                    btnjimBl.Enabled = false;
                    btnImpInv.Enabled = false;
                }
            }
            else
            {
                if (imdDB.testConnection(txtPathA.Value.ToString(), "64").Equals("ok"))
                {
                    pic1.Show();
                    btnCus.Enabled = true;
                    btnCons.Enabled = true;
                    btnExpCons.Enabled = true;
                    btnImpSupp.Enabled = true;
                    btnInsr.Enabled = true;
                    btnStf.Enabled = true;
                    btnImp1.Enabled = true;
                    btnTmn.Enabled = true;
                    btnFwd.Enabled = true;
                    btnjimBl.Enabled = true;
                    btnImpInv.Enabled = true;
                }
                else
                {
                    pic1.Hide();
                    btnCus.Enabled = false;
                    btnCons.Enabled = false;
                    btnExpCons.Enabled = false;
                    btnImpSupp.Enabled = false;
                    btnInsr.Enabled = false;
                    btnStf.Enabled = false;
                    btnImp1.Enabled = false;
                    btnTmn.Enabled = false;
                    btnFwd.Enabled = false;
                    btnjimBl.Enabled = false;
                    btnImpInv.Enabled = false;
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
            imdDB.ImportMEIOSYSimport(txtPathA.Value.ToString(), chkImpNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1);
        }

        private void btnCus_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBcustomer(txtPathA.Value.ToString(), chkCusNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1);
        }

        private void btnCons_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBconsignee(txtPathA.Value.ToString(), chkConsNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1);
        }

        private void btnExpCons_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBExpConsignee(txtPathA.Value.ToString(), chkExpConsNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1);
        }

        private void btnImpSupp_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBImpSupplier(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1);
        }

        private void btnInsr_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBInsurance(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1);
        }

        private void btnStf_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBStaff(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1);
        }

        private void btnImp1_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBJobImport(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1, this);
        }

        private void btnTmn_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBTermail(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1, this);
        }

        private void btnFwd_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBForwarder(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1, this);
        }

        private void btnjimBl_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBJobImportBl(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1, this);
        }

        private void btnImpInv_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBJobImportInv(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1, this);
        }

        private void btnPol_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBPortOfLoading(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1, this);
        }

        private void binJie_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBJobImportExpn(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1, this);
        }

        private void btnJct_Click(object sender, EventArgs e)
        {
            imdDB.ImportOpenJOBJobImportCont(txtPathA.Value.ToString(), chkImpSuppNew.Checked ? "new" : "append", chk32.Checked ? "32" : "64", pB1, this);
        }

        private void btnEtt_Click(object sender, EventArgs e)
        {
            imdDB.ImportEntryType("new");
        }

        private void btnPti_Click(object sender, EventArgs e)
        {
            imdDB.ImportPortImport("new");
        }
    }
}
