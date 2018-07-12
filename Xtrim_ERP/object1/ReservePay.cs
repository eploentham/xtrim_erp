using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ReservePay:Persistent
    {
        public String reserve_pay_id { get; set; }
        public String desc1 { get; set; }
        public String active { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String remark { get; set; }
        public String status_appv { get; set; }
        public String amount_draw { get; set; }
        public String amount_appv { get; set; }
        public String amount_reserve { get; set; }
        public String date_draw { get; set; }
        public String date_appv { get; set; }
        public String date_reserve { get; set; }
        public String staff_id { get; set; }
        public String amount_onhand { get; set; }
    }
}
