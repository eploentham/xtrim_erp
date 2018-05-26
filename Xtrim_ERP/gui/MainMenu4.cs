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

        }
        private void menuImpJobAdd_Click(object sender, EventArgs e)
        {
            FrmJobImpNew1 frm = new FrmJobImpNew1(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "Import Job Detail");
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
            this.Text = "Last Update 2018-05-21";
        }
    }
}
