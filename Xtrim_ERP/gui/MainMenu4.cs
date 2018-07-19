using C1.Win.C1Command;
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
    public partial class MainMenu4 : Form
    {
        XtrimControl xC;

        private Point _imageLocation = new Point(13, 5);
        private Point _imgHitArea = new Point(13, 2);
        Image CloseImage;
        Login login;
        Boolean flagExit = false;

        public MainMenu4(XtrimControl x, FrmSplash splash)
        {
            InitializeComponent();
            xC = x;
            login = new Login(xC, splash);
            login.ShowDialog(this);
            if (login.LogonSuccessful.Equals("1"))
            {
                initConfig();
            }
            else
            {
                Application.Exit();
            }
        }
        private void initConfig()
        {
            this.FormClosing += MainMenu4_FormClosing;
            menuExit.Click += MenuExit_Click;
            menuStf.Click += MenuStf_Click;
            menuCust.Click += MenuCust_Click;
            menuDept.Click += MenuDept_Click;
            menuPosi.Click += MenuPosi_Click;
            
            menuTest.Click += MenuTest_Click;
            menuConvertData.Click += MenuConvertData_Click;
            menuImpJobView.Click += MenuImpJobView_Click;
            menuItmType.Click += MenuItmType_Click;
            menuItmCat.Click += MenuItmCat_Click;
            menuItems.Click += MenuItems_Click;
            menuItmGrp.Click += MenuItmGrp_Click;
            menuMethodPay.Click += MenuMethodPay_Click;
            menuExpnDraw.Click += MenuExpnDraw_Click;
            menuExpnDraw1.Click += MenuExpnDraw1_Click;
            menuExpnDrawAppv.Click += MenuExpnDrawAppv_Click;
            menuExpnDrawPay.Click += MenuExpnDrawPay_Click;
            menuItmTypeSub.Click += MenuItmTypeSub_Click;
            menuBilling.Click += MenuBilling_Click;
            menuRsp.Click += MenuRsp_Click;
            menuRspAppv.Click += MenuRspAppv_Click;
            menuRspReserve.Click += MenuRspReserve_Click;
            menuCop.Click += MenuCop_Click;
            menuDebtor.Click += MenuDebtor_Click;
            menuPayment.Click += MenuPayment_Click;
            menuTax.Click += MenuTax_Click;
            menuBillingPlus.Click += MenuBillingPlus_Click;
            menuBillingMinus.Click += MenuBillingMinus_Click;
            menuExpnReceiptCash.Click += MenuExpnReceiptCash_Click;
            menuJobTax.Click += MenuJobTax_Click;
            menuRspCard.Click += MenuRspCard_Click;
            menuExpnReceipt1.Click += MenuExpnReceipt1_Click;
            //menuExpnReceipt.Click += MenuExpnReceipt_Click;
        }
        
        private void MenuRspCard_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReserveCash frm = new FrmReserveCash(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuRspCard.Text + " ");
        }

        private void MenuJobTax_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmJobTax frm = new FrmJobTax(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuJobTax.Text + " ");
        }
        private void MenuExpnReceipt1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmExpenseReceipt frm = new FrmExpenseReceipt(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuExpnReceipt1.Text + " ");
        }
        private void MenuExpnReceiptCash_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmExpenseReceiptCash frm = new FrmExpenseReceiptCash(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuExpnReceiptCash.Text + " ");
        }

        private void MenuBillingMinus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmDebtorView frm = new FrmDebtorView(xC, this, FrmDebtorView.flagForm2.DebtorMinus);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuBillingMinus.Text + " ");
        }

        private void MenuBillingPlus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmDebtorView frm = new FrmDebtorView(xC, this, FrmDebtorView.flagForm2.DebtorAdd);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuBillingPlus.Text + " ");
        }

        private void MenuTax_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmBTax frm = new FrmBTax(xC, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuTax.Text + " ");
        }

        private void MenuPayment_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmPaymentView frm = new FrmPaymentView(xC, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, menuPayment.Text +" ");
        }

        private void MenuDebtor_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmDebtor frm = new FrmDebtor(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "ลูกหนี้ ");
        }

        private void MenuCop_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCompany frm = new FrmCompany(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "บริษัท ");
        }

        private void MenuRspReserve_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReservePay frm = new FrmReservePay(xC, "reserve");
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "รับเงิน เบิกเงินสำรองจ่าย ");
        }

        private void MenuRspAppv_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReservePay frm = new FrmReservePay(xC, "appv");
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "อนุมัติ เบิกเงินสำรองจ่าย ");
        }

        private void MenuRsp_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReservePay frm = new FrmReservePay(xC, "draw");
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "เบิกเงินสำรองจ่าย ");
        }

        private void MenuBilling_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmBillingView frm = new FrmBillingView(xC, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "ทำใบวางบิล ");
        }

        private void MenuItmTypeSub_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmItemsTypeSub frm = new FrmItemsTypeSub(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "ประเภทย่อย ");
        }

        private void MenuExpnDrawPay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmExpenseDrawPayView1 frm = new FrmExpenseDrawPayView1(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "จ่ายเบิกเงิน ");
        }

        private void MenuExpnDrawAppv_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmExpenseDrawAppvView frm = new FrmExpenseDrawAppvView(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "อนุมัติเบิกเงิน ");
        }

        private void MenuExpnDraw_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //FrmExpenseDraw frm = new FrmExpenseDraw(xC);
            FrmExpenseDrawView frm = new FrmExpenseDrawView(xC, this, FrmExpenseDrawView.flagForm2.Cash);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "ใบเบิกเงิน จ่ายพนักงาน(เงินสด) ");
        }
        private void MenuExpnDraw1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //FrmExpenseDraw frm = new FrmExpenseDraw(xC);
            FrmExpenseDrawView frm = new FrmExpenseDrawView(xC, this,FrmExpenseDrawView.flagForm2.Cheque);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "ใบเบิกเงิน จ่ายลูกค้า(Cheque,...) ");
        }
        private void MenuMethodPay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //FrmMethodPayment frm = new FrmMethodPayment(xC);
            //frm.FormBorderStyle = FormBorderStyle.None;
            //AddNewTab(frm, "วิธีการจ่ายเงิน ");
        }

        private void MenuItmGrp_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmItemsGrp frm = new FrmItemsGrp(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "กลุ่ม ค่าใช้จ่าย ");
        }

        private void MenuItems_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmItems frm = new FrmItems(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "รายการ ค่าใช้จ่าย ");
        }

        private void MenuItmCat_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmItemsCat frm = new FrmItemsCat(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "หมวด ค่าใช้จ่าย ");
        }

        private void MenuItmType_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmItemsType frm = new FrmItemsType(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "ประเภทหลัก ");
        }

        private void MenuImpJobView_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmJobImpView frm = new FrmJobImpView(xC, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "Open Job Import ");
        }

        private void MenuConvertData_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmImportData frm = new FrmImportData(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Convert Data");
        }

        private void MenuTest_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void MenuEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //RibbonForm2 frm = new RibbonForm2();
            RichTextEditor.Form1 frm = new RichTextEditor.Form1();
            frm.Show();
        }

        private void MenuPosi_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmPosition frm = new FrmPosition(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Position");
        }

        private void MenuDept_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmDepartment1 frm = new FrmDepartment1(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Department");
        }

        private void MenuCust_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCustomer1 frm = new FrmCustomer1(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Customer");
        }

        private void MenuStf_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmStaff frm = new FrmStaff(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Staff");
        }
        private void menuImpJobAdd_Click(object sender, EventArgs e)
        {
            //FrmJobImpNew2 frm = new FrmJobImpNew2(xC);
            xC.jobID = "";
            FrmJobImpNew3 frm = new FrmJobImpNew3(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "Import Job Detail");
        }
        private void MenuExit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            appExit();
        }

        private void MainMenu4_FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!flagExit)
                {
                    if (MessageBox.Show("ต้องการออกจากโปรแกรม3", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        //Close();
                        //return true;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                //appExit();
            }
            else
            {
                e.Cancel = true;
            }
        }
        private Boolean appExit()
        {
            flagExit = true;
            if (MessageBox.Show("ต้องการออกจากโปรแกรม2", "ออกจากโปรแกรม menu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddNewTab(Form frm, String label)
        {
            foreach (Control y in tC1.Controls)
            {
                if (y is C1DockingTabPage)
                {
                    if (y.Text.Equals("Import JOB"))
                    {
                        if (label.Equals("Import JOB"))
                        {
                            tC1.SelectedTab = (C1DockingTabPage)y;
                            return;
                        }
                    }
                }
            }
            C1DockingTabPage tab = new C1DockingTabPage();
            tab.SuspendLayout();
            frm.TopLevel = false;
            tab.Width = tCC1.Width - 10;
            tab.Height = tCC1.Height - 35;
            
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.Width = tab.Width;
            frm.Height = tab.Height;
            tab.Text = label;
            //foreach (Control x in frm.Controls)
            //{
            //    if (x is DataGridView)
            //    {
            //        //x.Dock = DockStyle.Fill;
            //    }
            //}
            //tab.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
            frm.Visible = true;

            tC1.TabPages.Add(tab);

            //frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);
            frm.Location = new Point(0, 0);
            tab.ResumeLayout();
            tab.Refresh();
            tab.Text = label;
            tC1.SelectedTab = tab;
            c1ThemeController1.SetTheme(tC1, "Office2010Blue");
            //theme1.SetTheme(tC1, "Office2010Green");
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                appExit();
                //if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                //    Close();
                //    return true;
                //}
            }
            else
            {
                //keyData
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainMenu4_Load(object sender, EventArgs e)
        {
            if (!login.LogonSuccessful.Equals("1"))
            {
                menuImpJob.Enabled = false;
                menuExpJob.Enabled = false;
                menuOtherJob.Enabled = false;
                menuInit.Enabled = false;

                flagExit = true;
                Application.Exit();
            }
            else
            {
                menuImpJob.Enabled = false;
                menuExpJob.Enabled = false;
                menuOtherJob.Enabled = false;
                menuInit.Enabled = false;
                if (xC.user.status_module_imp_job.Equals("1"))
                {
                    menuImpJob.Enabled = true;
                }
                if (xC.user.status_module_exp_job.Equals("1"))
                {
                    menuExpJob.Enabled = true;
                }
                if (xC.user.status_module_other_job.Equals("1"))
                {
                    menuOtherJob.Enabled = true;
                }
                if (xC.user.status_admin.Equals("2"))
                {
                    menuInit.Enabled = true;
                }
            }
            this.Text = "Last Update 2018-07-16";
        }
    }
}
