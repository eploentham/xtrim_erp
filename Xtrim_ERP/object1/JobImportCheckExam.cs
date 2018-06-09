using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class JobImportCheckExam:Persistent
    {
        public String job_import_check_exam_id { get; set; }
        public String job_import_id { get; set; }
        public String status_open_goods { get; set; }
        public String qty_open_goods { get; set; }
        public String number_open_goods { get; set; }
        public String status_layout_goods { get; set; }
        public String qty_bad_goods { get; set; }
        public String number_bad_goods { get; set; }
        public String bad_goods_desc { get; set; }
        public String attend_corrupt { get; set; }
        public String status_corrupt_goods { get; set; }
        public String dmc_no { get; set; }
        public String dmc_date { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String remark { get; set; }
        public String active { get; set; }
        public String sort1 { get; set; }
        public String custom_date { get; set; }
        public String transport_date { get; set; }
    }
}
