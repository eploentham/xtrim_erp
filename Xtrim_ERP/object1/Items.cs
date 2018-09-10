using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Items:Persistent
    {
        public String item_id { get; set; }
        public String item_code { get; set; }
        public String item_name_t { get; set; }
        public String item_name_e { get; set; }
        public String active { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String status_app { get; set; }
        public String remark { get; set; }
        public String sort1 { get; set; }

        public String acc_code { get; set; }
        public String status_tax53 { get; set; }
        public String item_grp_id { get; set; }
        public String item_type_sub_id { get; set; }
        public String item_cat_id { get; set; }
        public String f_method_payment_id { get; set; }
        public String status_invoice { get; set; }
        public String price1 { get; set; }
        public String price2 { get; set; }
        public String price3 { get; set; }
        public String price4 { get; set; }
        public String price5 { get; set; }
        public String unit_id { get; set; }
        public String item_group_id { get; set; }
        public String tax_id { get; set; }

        public String qty { get; set; }
        public String amt { get; set; }
        public String wtax1 { get; set; }
        public String wtax3 { get; set; }
        public String vat { get; set; }
        public String total { get; set; }
        public String unit_name_t { get; set; }
        public String cust_name_t { get; set; }
        public String cust_addr { get; set; }
        public String cust_id { get; set; }
        public String cust_tax { get; set; }
        public String receipt_no { get; set; }
        public String receipt_date { get; set; }
        public String status_hide { get; set; }
        public String wtax5 { get; set; }
        public String amt_wtax1 { get; set; }
        public String amt_wtax3 { get; set; }
        public String amt_wtax5 { get; set; }
    }
}
