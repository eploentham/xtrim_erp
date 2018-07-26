using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ExpensesPayDetail:Persistent
    {
        public String expenses_pay_detail_id { get; set; }
        public String expenses_pay_id { get; set; }
        public String status_pay_type { get; set; }
        public String item_id { get; set; }
        public String item_name_t { get; set; }
        public String job_id { get; set; }
        public String pay_amount { get; set; }
        public String pay_to_cus_id { get; set; }
        public String pay_to_cus_name_t { get; set; }
        public String pay_to_cus_addr { get; set; }
        public String pay_to_cus_tax { get; set; }
        public String pay_cheque_no { get; set; }
        public String pay_cheque_bank_id { get; set; }
        public String pay_staff_id { get; set; }
        public String pay_date { get; set; }
        public String comp_bank_id { get; set; }
        public String pay_bank_date { get; set; }
        public String expenses_draw_detail_id { get; set; }
        public String desc_dd { get; set; }
        public String desc_d { get; set; }
        public String staff_id { get; set; }
        public String expense_clear_cash_id { get; set; }
        public String ecc_doc { get; set; }
    }
}
