using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class JobImportExpn:Persistent
    {
        public String job_import_expenses_id { get; set; }
        public String job_import_id { get; set; }
        public String expenses_id { get; set; }
        public String row_no { get; set; }
        public String expenses_date { get; set; }
        public String method_payment_id { get; set; }
        public String tax_date { get; set; }
        public String tax_amount { get; set; }
        public String amount { get; set; }
        public String cost_amount { get; set; }
        public String status_deposit { get; set; }
        public String remark { get; set; }
        public String receipt_no { get; set; }
        public String receipt_date { get; set; }
        public String status_receipt { get; set; }
        public String status_billing { get; set; }
        public String cheque_no { get; set; }
        public String cheque_amount { get; set; }
        public String xtrim_is_no { get; set; }
        public String tax_card { get; set; }
        public String enter_inv_no { get; set; }
        public String tax_gkn_id { get; set; }
        public String amount_pay { get; set; }
        public String cheque_pay_amount { get; set; }
        public String cheque_pay_no { get; set; }
        public String cheque_date { get; set; }
    }
}
