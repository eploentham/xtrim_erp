using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class CustomerRemark:Persistent
    {
        public String remark_id { get; set; }
        public String cust_id { get; set; }
        public String remark { get; set; }
        public String remark2 { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String active { get; set; }
        public String sort1 { get; set; }
        public String status_show1 { get; set; }
        public String status_show2 { get; set; }
        public String status_show3 { get; set; }
    }
}
