using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ReserveCash:Persistent
    {
        public String reserve_cash_id { get; set; }
        public String reserve_pay_id { get; set; }
        public String expenses_pay_detail_id { get; set; }
        public String amount { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String status_reserve { get; set; }
        public String desc1 { get; set; }
    }
}
