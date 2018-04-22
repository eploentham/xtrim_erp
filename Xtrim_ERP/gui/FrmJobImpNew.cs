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
    public partial class FrmJobImpNew : Form
    {
        JobImport jim;
        JobImportBl jbl;
        JobImportInv jin;
        XtrimControl xC;
        Font fEdit, fEditB;

        public FrmJobImpNew(XtrimControl x)
        {
            InitializeComponent();
            xC = x;
            initConfig();
        }
        private void initConfig()
        {
            jim = new JobImport();
            jbl = new JobImportBl();
            jin = new JobImportInv();
            ComboBoxItem a1 = new ComboBoxItem();
            a1.Value = "1";
            a1.Text = "1-ทางเรือ (Sea)";
            ComboBoxItem a2 = new ComboBoxItem();
            a2.Value = "2";
            a2.Text = "2-รถไฟ (Rail)";
            ComboBoxItem a3 = new ComboBoxItem();
            a3.Value = "2";
            a3.Text = "3-รถยนต์ (Road)";
            //a1.Add("1-ทางเรือ (Sea)");
            //a1.Add("2-รถไฟ (Rail)");
            //a1.Add("3-รถยนต์ (Road)");
            //a1.Add("4-เครื่องบิน (Air)");
            //a1.Add("5-ไปรษณีย์ (Mail)");
            //a1.Add("6-อื่นฯ (Other)");
            //cboTransMode.Items.Add("1-ทางเรือ (Sea)");
            //cboTransMode.Items.Add("2-รถไฟ (Rail)");
            //cboTransMode.Items.Add("3-รถยนต์ (Road)");
            //cboTransMode.Items.Add("4-เครื่องบิน (Air)");
            //cboTransMode.Items.Add("5-ไปรษณีย์ (Mail)");
            //cboTransMode.Items.Add("6-อื่นฯ (Other)");
            cboTransMode.Items.Add(a1);
            cboTransMode.Items.Add(a2);
            cboTransMode.Items.Add(a3);
            setControl();
        }
        private void setControl()
        {
            if (xC.jobID.Equals("")) return;
            jim = xC.xtDB.jimDB.selectByPk1(xC.jobID);
            jbl = xC.xtDB.jblDB.selectByJobId(xC.jobID);

            txtID.Value = jim.imp_id;
            txtJobCode.Value = jim.job_import_code;
            txtJobDate.Value = jim.job_import_date;
            xC.xtDB.cusDB.setCboCus(cboCus, jim.cust_id);
            xC.xtDB.impDB.setCboImp(cboImp, jim.imp_id);
            //cboCus.SelectedValue = jim.cust_id;
            txtRef1.Value = jim.ref_1;
            txtRef2.Value = jim.ref_2;
            txtRef3.Value = jim.ref_3;
            txtRef4.Value = jim.ref_4;
            txtRef5.Value = jim.ref_5;
            lbCusAddr.Value = jim.cusAddr;
            lbImpAddr.Value = jim.impAddr;
            txtJobDate.Value = jim.job_import_date;
            xC.xtDB.ettDB.setCboEtt(cboEtt, jim.entry_type);
            xC.xtDB.pvlDB.setCboPvl(cboPvl, jim.privi_id);
            xC.xtDB.fwdDB.setCboFwd(cboFwd, jbl.forwarder_id);
            xC.xtDB.ptiDB.setCboPti(cboPti, jbl.port_imp_id);
            xC.xtDB.tmnDB.setCboTmn(cboTmn, jbl.terminal_id);
            xC.xtDB.ugwDB.setCboUgw(cboUgw, jbl.gw_unit_id);
            xC.xtDB.utpDB.setCboUtp(cboUtp, jbl.unit_package_id);
            xC.xtDB.ugwDB.setCboUgw(cboUgw1, jbl.gw_unit_id);
            xC.xtDB.utpDB.setCboUtp(cboUtp1, jbl.unit_package_id);
            xC.xtDB.polDB.setCboPol(cboPol, jbl.port_of_loding_id);
            //xC.xtDB.utpDB.setCboUtp(cboUtp, jbl.u);
            //cboUtp1 = cboUtp;
            //cboUgw1 = cboUgw;
            //cboUtp1.SelectedItem = cboUtp.SelectedItem;
            //cboUgw1.SelectedItem = cboUgw.SelectedItem;
            txtGw.Value = jbl.gw;
            txtGw1.Value = jbl.gw;
            txtTotalP.Value = jbl.total_packages;
            txtTotalP1.Value = jbl.total_packages;
            txtVolume.Value = jbl.volume1;
            txtTotal20.Value = jbl.total_con20;
            txtTotal40.Value = jbl.total_con40;
            txtMbl.Value = jbl.mbl_mawb;
            txtMbl1.Value = jbl.mbl_mawb;
            txtHbl.Value = jbl.hbl_hawb;
            txtHbl1.Value = jbl.hbl_hawb;
            txtMves.Value = jbl.m_vessel;
            txtMves1.Value = jbl.m_vessel;
            txtEtd.Value = jbl.etd;
            txtEtd1.Value = jbl.etd;
            txtInsurDate.Value = jim.insr_date;
            txtFves.Value = jbl.f_vessel;
            txtEta.Value = jbl.eta;
            txtRemark1.Value = jim.remark;
            txtRemark2.Value = jbl.remark;
            txtDeliRemark.Value = jbl.delivery_remark;
            txtEdiRef.Value = jim.ref_edi;
            txtTaxAmt.Value = jim.tax_amt;
            txtImpEntry.Value = jim.imp_entry;
            txtInvDate.Value = jim.inv_date;
            txtPolicyDate.Value = jim.policy_date;
            txtPolicyNo.Value = jim.policy_no;
            txtPremium.Value = jim.premium;

            txtDesc.Value = jbl.description;
        }

        private void c1Label16_Click(object sender, EventArgs e)
        {

        }

        private void FrmJobImpNew_Load(object sender, EventArgs e)
        {

        }
    }
}
