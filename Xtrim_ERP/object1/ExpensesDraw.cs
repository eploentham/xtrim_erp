using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ExpensesDraw:Persistent
    {
        public String expenses_draw_id { get; set; }
        public String expenses_draw_date { get; set; }
        public String job_id { get; set; }
        public String job_code { get; set; }
        public String draw_date { get; set; }
        public String remark { get; set; }
        public String active { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String staff_id { get; set; }
        public String expenses_draw_code { get; set; }
        public String desc1 { get; set; }
        public String status_appv { get; set; }
        public String status_email { get; set; }
        public String amount { get; set; }
        public String year { get; set; }
        public String appv_amount { get; set; }
        public String appv_desc { get; set; }
        public String status_pay { get; set; }
        public String status_pay_type { get; set; }
    }
}
