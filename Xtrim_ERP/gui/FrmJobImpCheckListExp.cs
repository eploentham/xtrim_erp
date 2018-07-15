using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xtrim_ERP.control;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.gui
{
    public partial class FrmJobImpCheckListExp : C1.Win.C1Ribbon.C1RibbonForm
    {
        XtrimControl xC;
        ExpensesDrawDatail expndd;

        Font fEdit, fEditB;
        Color bg, fc, cgrfOld;
        Font ff, ffB;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String tableId = "";

        public FrmJobImpCheckListExp(XtrimControl x, String tableid)
        {
            InitializeComponent();
            xC = x;
            this.tableId = tableid;
            initConfig();
        }
        private void initConfig()
        {
            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(panel1, "VS2013Light");

            setControl(tableId);

            btnImages.Click += BtnImages_Click;
            btnSave.Click += BtnSave_Click;

            foreach (Control c in panel1.Controls)
            {
                theme1.SetTheme(c, "VS2013Light");
            }
        }

        private void setControl(String id)
        {
            txtId.Value = id;
            Items itm = new Items();
            expndd = new ExpensesDrawDatail();
            expndd = xC.xtDB.expnddDB.selectByPk1(id);
            itm = xC.xtDB.itmDB.selectByPk1(expndd.item_id);
            txtTableId.Value = expndd.expenses_draw_detail_id;
            txtItmNameT1.Value = expndd.item_name_t;
            txtRcpAmt.Value = expndd.receipt_amount;
            txtRcpNum.Value = expndd.receipt_no;
            txtRcpDate.Value = expndd.receipt_date;
            txtItmCode.Value = itm.item_code;
            txtItmNameT.Value = expndd.item_name_t;
            setImages(txtId.Text);
        }
        private void setImages(String id)
        {
            Images img = new Images();
            DataTable dt = new DataTable();
            dt = xC.xtDB.imgDB.selectByTableId(id);
            int i = 0;
            Point btnsize = new Point(42, 45);
            foreach(DataRow row in dt.Rows)
            {
                C1Button btnImg = new C1Button();
                btnImg.Image = global::Xtrim_ERP.Properties.Resources.PrintPreview_large;
                btnImg.Location = new System.Drawing.Point(3, 3);
                btnImg.Name = "btnImg"+i;
                btnImg.Size = new System.Drawing.Size(btnsize);
                btnImg.TabIndex = 500;
                btnImg.Text = "";
                btnImg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                theme1.SetTheme(btnImg, "VS2013Light");
                btnImg.UseVisualStyleBackColor = true;
                btnImg.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
                i++;
            }
        }
        private void setExpnDD()
        {
            expndd.receipt_amount = txtRcpAmt.Text.Replace("$","").Replace(",","");
            expndd.receipt_date = xC.datetoDB(txtRcpDate.Text);
            expndd.receipt_no = txtRcpNum.Text;
            expndd.expenses_draw_detail_id = txtId.Text;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setExpnDD();
                xC.xtDB.expnddDB.updateReceipt(expndd, xC.userId);
            }
        }
        private void BtnImages_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmImages frm = new FrmImages(xC, tableId);
            frm.ShowDialog(this);
        }

        private void FrmJobImpCheckListExp_Load(object sender, EventArgs e)
        {


        }
    }
}
