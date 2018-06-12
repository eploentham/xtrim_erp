using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportContainerDB
    {
        public JobImportContainer jcn;
        ConnectDB conn;

        public JobImportContainerDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jcn = new JobImportContainer();
            jcn.job_import_container_id = "job_import_container_id";
            jcn.job_import_id = "job_import_id";
            jcn.container_no = "container_no";
            jcn.container_doct_type_id = "container_doct_type_id";
            jcn.seal = "seal";
            jcn.active = "active";
            jcn.remark = "remark";
            jcn.date_create = "date_create";
            jcn.date_modi = "date_modi";
            jcn.date_cancel = "date_cancel";
            jcn.user_create = "user_create";
            jcn.user_modi = "user_modi";
            jcn.user_cancel = "user_cancel";
        }
    }
}
