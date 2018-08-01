using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ExpensesClearCash:Persistent
    {
        public String expense_clear_cash_id { get; set; }
        public String expenses_pay_detail_id { get; set; }
        public String expenses_draw_detail_id { get; set; }
        public String expenses_draw_id { get; set; }
        public String staff_id { get; set; }
        public String ecc_doc { get; set; }
        public String expense_clear_cash_date { get; set; }
        public String item_id { get; set; }
        public String item_name_t { get; set; }
        public String pay_amount { get; set; }
        public String pay_date { get; set; }
        public String job_id { get; set; }
        public String job_code { get; set; }
        public String qty { get; set; }
        public String price { get; set; }
        public String unit_id { get; set; }
        public String unit_name_t { get; set; }
        public String vat { get; set; }
        public String total { get; set; }
        public String receipt_no { get; set; }
        public String receipt_date { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String pay_to_cus_id { get; set; }
        public String pay_to_cus_name_t { get; set; }
        public String pay_to_cus_addr { get; set; }
        public String pay_to_cus_tax { get; set; }
        public String pay_staff_id { get; set; }
        public String row1 { get; set; }
        public String item_code { get; set; }
        public String status_appv { get; set; }
        public String status_doc { get; set; }
        public String appv_staff_id { get; set; }
        public String doc_staff_id { get; set; }
        public String erc_doc { get; set; }
    }
}
