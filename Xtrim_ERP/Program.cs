﻿using System;
using System.Collections.Generic;
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

            XtrimControl xc = new XtrimControl();

            //MainMenu mainmenu = new gui.MainMenu();
            Application.Run(new gui.MainMenu(xc));
            //if (logon.LogonSuccessful.Equals("1"))
            //{
            //    Application.Run(new gui.MainMenu());
            //}
            //Application.Run(new Login());

        }
    }
}