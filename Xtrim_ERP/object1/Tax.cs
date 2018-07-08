using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Tax:Persistent
    {
        public String tax_id { get; set; }
        public String tax_code { get; set; }
        public String tax_date { get; set; }
        public String job_id { get; set; }
        public String job_code { get; set; }
        public String expenses_pay_detail_id { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String year_id { get; set; }
        public String cust_id { get; set; }

        public String cust_name_t { get; set; }
        public String cust_addr { get; set; }
        public String cust_tele { get; set; }
        public String agent_id { get; set; }
        public String agent_name_t { get; set; }
        public String agent_addr { get; set; }
        public String agent_tele { get; set; }
        public String payer_id { get; set; }
        public String payer_name_t { get; set; }
        public String payer_addr { get; set; }

        public String payer_tele { get; set; }
        public String status_tax_type { get; set; }
        public String row_no { get; set; }
        public String status_payer { get; set; }
        public String payer_other { get; set; }
        public String status_tax_normal { get; set; }
        public String tax_add_no { get; set; }
        public String ref1 { get; set; }
        public String line1_date { get; set; }
        public String line1_amount { get; set; }

        public String line1_tax { get; set; }
        public String line2_date { get; set; }
        public String line2_amount { get; set; }
        public String line2_tax { get; set; }
        public String line3_date { get; set; }
        public String line3_amount { get; set; }
        public String line3_tax { get; set; }
        public String line41_date { get; set; }
        public String line41_amount { get; set; }
        public String line41_tax { get; set; }

        public String line41_text { get; set; }
        public String line421_date { get; set; }
        public String line421_amount { get; set; }
        public String line421_tax { get; set; }
        public String line421_text { get; set; }
        public String line422_date { get; set; }
        public String line422_amount { get; set; }
        public String line422_tax { get; set; }
        public String line422_text { get; set; }
        public String line423_date { get; set; }

        public String line423_amount { get; set; }
        public String line423_tax { get; set; }
        public String line423_text { get; set; }
        public String line5_date { get; set; }
        public String line5_amount { get; set; }
        public String line5_tax { get; set; }
        public String line5_text { get; set; }
        public String line6_date { get; set; }
        public String line6_amount { get; set; }
        public String line6_tax { get; set; }

        public String line6_text { get; set; }
        public String status_page { get; set; }
    }
}
