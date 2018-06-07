using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportCheckExamDB
    {
        public JobImportCheckExam jce;
        ConnectDB conn;

        public JobImportCheckExamDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jce = new JobImportCheckExam();
            jce.job_import_check_exam_id = "";
            jce.job_import_id = "";
            jce.status_open_goods = "";
            jce.qty_open_goods = "";
            jce.number_open_goods = "";
            jce.status_layout_goods = "";
            jce.qty_bad_goods = "";
            jce.number_bad_goods = "";
            jce.bad_goods_desc = "";
            jce.attend_corrupt = "";
            jce.status_corrupt_goods = "";
            jce.dmc_no = "";
            jce.date_dmc = "";
            jce.date_create = "";
            jce.date_modi = "";
            jce.date_cancel = "";
            jce.user_create = "";
            jce.user_modi = "";
            jce.user_cancel = "";
            jce.remark = "";
            jce.active = "";
            jce.sort1 = "";
        }
    }
}
