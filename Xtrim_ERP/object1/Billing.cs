using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Billing:Persistent
    {
        public String billing_id { get; set; }
        public String billing_code { get; set; }
        public String billing_date { get; set; }
        public String job_id { get; set; }
        public String job_code { get; set; }
        public String amount { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
    }
}
