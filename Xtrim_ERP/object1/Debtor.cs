using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Debtor:Persistent
    {
        public String debtor_id { get; set; }
        public String cus_id { get; set; }
        public String amount { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_crate { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String billing_detail_id { get; set; }
        public String payment_detail_id { get; set; }
        public String job_id { get; set; }
        public String status_debtor { get; set; }
        public String comp_id { get; set; }
    }
}
