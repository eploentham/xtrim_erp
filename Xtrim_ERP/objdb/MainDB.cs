using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.objdb
{
    public class MainDB
    {
        ConnectDB conn;

        public JobImportDB jimDB;
        public JobImportCheckListDB jclDB;
        public JobImportCheckExamDB jceDB;
        public JobImportContainerListDB jcsDB;
        public JobImportDeliveryDB jdvDB;
        public JobImportExpnDB jieDB;
        public JobImportContainerDB jcnDB;
        public JobImportInvDB jinDB;
        public JobImportContDB jctDB;
        public JobImportBlDB jblDB;

        public MainDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            Console.WriteLine("manDB start");
            jclDB = new JobImportCheckListDB(conn);
            jceDB = new JobImportCheckExamDB(conn);
            jcsDB = new JobImportContainerListDB(conn);
            jdvDB = new JobImportDeliveryDB(conn);
            jcnDB = new JobImportContainerDB(conn);
            jieDB = new JobImportExpnDB(conn);
            jinDB = new JobImportInvDB(conn);
            jimDB = new JobImportDB(conn);
            jctDB = new JobImportContDB(conn);
            jblDB = new JobImportBlDB(conn);
            Console.WriteLine("manDB end");
        }
    }
}
