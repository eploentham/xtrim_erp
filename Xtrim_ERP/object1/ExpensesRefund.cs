using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ExpensesRefund:Persistent
    {
        public String expenses_refund_id { get; set; }
        public String expense_clear_cash_id { get; set; }
        public String job_id { get; set; }
        public String expenses_pay_detail_id { get; set; }
        public String desc1 { get; set; }
        public String amount { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String status_page { get; set; }
        public String status_appv { get; set; }
        public String status_doc { get; set; }
        public String expenses_refund_date { get; set; }
        public String ecc_doc { get; set; }
        public String job_code { get; set; }
        public String pay_staff_id { get; set; }
    }
}
