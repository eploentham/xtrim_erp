using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ReceiptDetail:Persistent
    {
        public String receipt_detail_id { get; set; }
        public String receipt_id { get; set; }
        public String item_id { get; set; }
        public String item_name_t { get; set; }
        public String qty { get; set; }
        public String price { get; set; }
        public String amount { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cencel { get; set; }
        public String job_id { get; set; }
        public String job_code { get; set; }
        public String billing_detail_id { get; set; }
    }
}
