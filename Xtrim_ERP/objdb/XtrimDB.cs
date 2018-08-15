using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class XtrimDB
    {
        ConnectDB conn;

        //public StaffDB sfDB;
        public CompanyDB copDB;
        public StaffDB stfDB;
        public MeiosysDB mioDB;
        public ImagesDB imgDB;

        public XtrimDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            Console.WriteLine("xtDB start");
            stfDB = new StaffDB(conn);
            copDB = new CompanyDB(conn);
            mioDB = new MeiosysDB(conn);
            imgDB = new ImagesDB(conn);
            Console.WriteLine("xtDB end");
        }
    }
}
