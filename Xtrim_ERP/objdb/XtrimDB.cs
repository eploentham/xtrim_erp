﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.objdb
{
    public class XtrimDB
    {
        ConnectDB conn;

        public StaffDB sfDB;
        public BankDB banDB;
        public CompanyDB copDB;

        public XtrimDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            sfDB = new StaffDB(conn);
            banDB = new BankDB(conn);
            copDB = new CompanyDB(conn);
        }
    }
}
