using C1.Win.C1Input;
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
using Xtrim_ERP.object1;

namespace Xtrim_ERP.gui
{
    public partial class FrmCompany : Form
    {
        Company cop;
        XtrimControl xC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        public FrmCompany(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            cop = new Company();

            bg = txtCopCode.BackColor;
            fc = txtCopCode.ForeColor;
            ff = txtCopCode.Font;
        }
        private void setFocus()
        {
            this.txtCopCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCopCode.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = Color.DarkCyan;
            a.Font = new Font(ff, FontStyle.Bold);
            //a.ForeColor = Color.Black;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setControl()
        {
            cop = xC.xtDB.copDB.selectByPk1(xC.copID);

            txtCopCode.Value = xC.xtDB.copDB.cop.comp_id;
            txtAddr2E.Value = xC.xtDB.copDB.cop.comp_id;
            txtAddr2.Value = xC.xtDB.copDB.cop.comp_id;
            txtRemark.Value = xC.xtDB.copDB.cop.comp_id;
            txtLogo.Value = xC.xtDB.copDB.cop.comp_id;
            txtWebSite.Value = xC.xtDB.copDB.cop.comp_id;
            txtEmail.Value = xC.xtDB.copDB.cop.comp_id;
            txtFax.Value = xC.xtDB.copDB.cop.comp_id;
            txtTele.Value = xC.xtDB.copDB.cop.comp_id;
            //cboDist.Value = xC.xtDB.copDB.cop.comp_id;
            //cbpAmph.Value = xC.xtDB.copDB.cop.comp_id;
            //cboProv.Value = xC.xtDB.copDB.cop.comp_id;
            txtCopAddr1E.Value = xC.xtDB.copDB.cop.comp_id;
            txtCopAddressE.Value = xC.xtDB.copDB.cop.comp_id;
            txtVat.Value = xC.xtDB.copDB.cop.comp_id;
            txtTaxId.Value = xC.xtDB.copDB.cop.comp_id;
            txtZipCode.Value = xC.xtDB.copDB.cop.comp_id;
            txtAddr1.Value = xC.xtDB.copDB.cop.comp_id;
            txtCopAddressT.Value = xC.xtDB.copDB.cop.comp_id;
            txtCopNameE.Value = xC.xtDB.copDB.cop.comp_id;
            txtCopNameT.Value = xC.xtDB.copDB.cop.comp_id;
            txtID.Value = xC.xtDB.copDB.cop.comp_id;
            //txtCopCode.Value = xC.xtDB.copDB.cop.comp_id;
        }
        private void setEnable(Boolean flag)
        {
            txtCopCode.Enabled = flag;
        }

        private void FrmCompany_Load(object sender, EventArgs e)
        {

        }
    }
}
