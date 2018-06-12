using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportImageDB
    {
        public JobImportImage jii;
        ConnectDB conn;

        public JobImportImageDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jii = new JobImportImage();
            jii.job_import_image_id = "job_import_image_id";
            jii.job_import_id = "job_import_id";
            jii.path_pic = "path_pic";
            jii.active = "active";
            jii.remark = "remark";
            jii.status_pic = "status_pic";
            jii.date_create = "date_create";
            jii.date_modi = "date_modi";
            jii.date_cancel = "date_cancel";
            jii.user_create = "user_create";
            jii.user_modi = "user_modi";
            jii.user_cancel = "user_cancel";
            jii.sort1 = "sort1";
        }
    }
}
