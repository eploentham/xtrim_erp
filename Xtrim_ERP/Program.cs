﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xtrim_ERP.control;
using Xtrim_ERP.gui;

namespace Xtrim_ERP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //foreach (Process clsProcess in Process.GetProcesses())
            //{
            //    if (clsProcess.ProcessName.ToLower().Contains("xtrim_erp"))
            //    {
            //        MessageBox.Show("11","2");
            //    }
            //}

            FrmSplash spl = new FrmSplash();
            spl.Show();
            
            //MessageBox.Show("00000", "000000");
            XtrimControl xc = new XtrimControl();
            //MessageBox.Show("1111111", "1111111");
            //MainMenu3 mainmenu3 = new gui.MainMenu3(xC);
            //spl.Dispose();
            Application.Run(new gui.MainMenu3(xc, spl));
            //if (logon.LogonSuccessful.Equals("1"))
            //{
            //    Application.Run(new gui.MainMenu());
            //}
            //Application.Run(new Login());

        }
    }
}
