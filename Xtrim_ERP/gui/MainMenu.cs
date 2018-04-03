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
    public partial class MainMenu : Form
    {
        XtrimControl xC;
        public MainMenu(XtrimControl xc)
        {
            InitializeComponent();
            xC = xc;
            Login login = new Login();
            login.ShowDialog(this);
            if (login.LogonSuccessful.Equals("1"))
            {

            }
            else
            {
                Application.Exit();
            }
        }
        private void AddNewTab(Form frm, String label)
        {
            foreach (Control x in c1DockingTabPage2.Controls)
            {
                x.Dispose();
            }
            
            frm.TopLevel = false;
            //tab.Width = c1CommandDock2.Width - 10;
            //tab.Height = c1CommandDock2.Height - 35;
            //frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.Top = c1DockingTabPage2.Top + 30;
            frm.Left = c1DockingTabPage2.Left + 20;
            frm.Width = c1DockingTabPage2.Width - 60;
            frm.Height = c1DockingTabPage2.Height - 60;
            frm.FormBorderStyle = FormBorderStyle.None;

            frm.Visible = true;

            //c1DockingTabPage2.Hide();

            //frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);
            frm.Location = new Point(0, 0);
            c1DockingTabPage2.Controls.Add(frm);
            //tab.ResumeLayout();
            //tab.Refresh();
            //c1CommandDock2.Controls.Add(tab);
            //c1DockingTabPage2.SelectedTab = tab;

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void c1TopicBar1_LinkClick(object sender, C1.Win.C1Command.C1TopicBarClickEventArgs e)
        {
            if (e.Link.Text.Equals("Import JOB"))
            {
                //MessageBox.Show("Import JOB", "aaaaaaaaaaa");
                ImJView frm = new ImJView();
                TabPage tab = new TabPage("dddddd");
                AddNewTab(frm, "");
                //c1DockingTabPage2.p
            }
            else if (e.Link.Text.Equals("Export JOB"))
            {
                //Form3 frm3 = new Form3();
                //AddNewTab(frm3, "");
            }
            else if (e.Link.Text.Equals("Other"))
            {
                //Form4 frm4 = new Form4();
                //AddNewTab(frm4, "");
            }
        }
    }
}
