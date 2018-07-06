using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class BillingCover:Persistent
    {
        public String billing_cover_id { get; set; }
        public String billing_cover_code { get; set; }
        public String remark1 { get; set; }
        public String remark2 { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String job_id { get; set; }
        public String cust_id { get; set; }
    }
}
