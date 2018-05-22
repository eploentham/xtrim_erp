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
    public partial class MainMenu3 : Form
    {
        XtrimControl xC;

        private Point _imageLocation = new Point(13, 5);
        private Point _imgHitArea = new Point(13, 2);
        Image CloseImage;
        Login login;
        Boolean flagExit = false;
        public MainMenu3(XtrimControl x)
        {
            InitializeComponent();
            //MessageBox.Show("111111", "11111111");
            xC = x;
            login = new Login(xC);
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
            tC1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tC1_DrawItem);
            tC1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tC1_MouseClick);

        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            appExit();
        }
        private Boolean appExit()
        {
            if (MessageBox.Show("ต้องการออกจากโปรแกรม", "ออกจากโปรแกรม menu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
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
                if (y is TabPage)
                {
                    if (y.Text.Equals("Import JOB"))
                    {
                        if (label.Equals("Import JOB"))
                        {
                            tC1.SelectedTab = (TabPage)y;
                            return;
                        }
                    }
                }
            }
            TabPage tab = new TabPage(label);
            tab.SuspendLayout();
            frm.TopLevel = false;
            tab.Width = tC1.Width - 10;
            tab.Height = tC1.Height - 35;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.Width = tab.Width;
            frm.Height = tab.Height;
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
        private void tC1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Image img = new Bitmap(CloseImage);
                Rectangle r = e.Bounds;
                r = this.tC1.GetTabRect(e.Index);
                r.Offset(2, 2);
                Brush TitleBrush = new SolidBrush(Color.Black);
                Font f = this.Font;
                string title = this.tC1.TabPages[e.Index].Text;

                e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));

                if (tC1.SelectedIndex >= 0)
                {
                    e.Graphics.DrawImage(img, new Point((r.X - 10) + (this.tC1.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
                }

                //if (e.Index == tC1.SelectedIndex)
                //{
                //    e.Graphics.DrawString(title, new Font(tC1.Font, FontStyle.Bold), Brushes.Red, new PointF(e.Bounds.X + 3, e.Bounds.Y + 3));
                //}
                //else
                //{
                //    e.Graphics.DrawString(title, tC1.Font, Brushes.Black, new PointF(e.Bounds.X + 3, e.Bounds.Y + 3));
                //}
            }
            catch (Exception) { }
        }

        private void tC1_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tC1.GetTabRect(tc.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = this.tC1.GetTabRect(tc.SelectedIndex);
            r.Offset(_tabWidth, _imgHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            if (tC1.SelectedIndex >= 0)
            {
                if (r.Contains(p))
                {
                    TabPage TabP = (TabPage)tc.TabPages[tc.SelectedIndex];
                    tc.TabPages.Remove(TabP);
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                if (MessageBox.Show("ต้องการออกจากโปรแกรม", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    Close();
                    return true;
                }
            }
            else
            {
                //keyData
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void menuImpJobView_Click(object sender, EventArgs e)
        {
            FrmJobImpView frm = new FrmJobImpView(xC, this);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Import JOB");
        }

        private void menuImpJobAdd_Click(object sender, EventArgs e)
        {
            FrmJobImpNew frm = new FrmJobImpNew(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            AddNewTab(frm, "Import Job Detail");
        }

        private void MainMenu3_Load(object sender, EventArgs e)
        {
            tC1.DrawMode = TabDrawMode.OwnerDrawFixed;
            CloseImage = (Image)Resources.rsz_close;
            tC1.Padding = new Point(10, 3);

            if (!login.LogonSuccessful.Equals("1"))
            {
                menuImpJob.Enabled = false;
                menuExpJob.Enabled = false;
                menuInit.Enabled = false;

                flagExit = true;
                Application.Exit();
            }
            this.Text = "Last Update 2018-05-21";
        }

        private void menuTest_Click(object sender, EventArgs e)
        {
            FrmJobImpView1 frm = new FrmJobImpView1(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Import JOB");
        }

        private void menuConvertData_Click(object sender, EventArgs e)
        {
            FrmImportData frm = new FrmImportData(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Convert Data");
        }

        private void menuCust_Click(object sender, EventArgs e)
        {
            FrmCustomer1 frm = new FrmCustomer1(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Customer");
        }

        private void menuFormTest_Click(object sender, EventArgs e)
        {
            //Form1 frm = new Form1();
            FrmCusMap frm = new FrmCusMap(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Test");
        }

        private void menuBank_Click(object sender, EventArgs e)
        {
            FrmBank frm = new FrmBank(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Bank");
        }

        private void menuCop_Click(object sender, EventArgs e)
        {
            FrmCompany frm = new FrmCompany(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Company");
        }

        private void menuStf_Click(object sender, EventArgs e)
        {
            FrmStaff frm = new FrmStaff(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Staff");
        }

        private void menuDept_Click(object sender, EventArgs e)
        {
            FrmDepartment1 frm = new FrmDepartment1(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Department");
        }
        private void menuPosi_Click(object sender, EventArgs e)
        {
            FrmPosition frm = new FrmPosition(xC);
            frm.FormBorderStyle = FormBorderStyle.None;
            TabPage tab = new TabPage("dddddd");
            AddNewTab(frm, "Position");
        }
        private void MainMenu3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!flagExit)
                {
                    if (MessageBox.Show("ต้องการออกจากโปรแกรม", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        //Close();
                        //return true;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                
            }
            else
            {
                e.Cancel = true;
            }
        }

        
    }
}
