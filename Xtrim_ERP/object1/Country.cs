using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Country:Persistent
    {
        public String cou_id { get; set; }
        public String cou_code { get; set; }
        public String cou_code2 { get; set; }
        public String cou_code3 { get; set; }
        public String cou_name { get; set; }
        public String cou_name1 { get; set; }
        public String cou_name2 { get; set; }
        public String currency { get; set; }
        public String wtocountry { get; set; }
        public String startdate { get; set; }
        public String finishdate { get; set; }
        public String progver { get; set; }
        public String usrname { get; set; }
        public String update_dd { get; set; }
        public String update_tt { get; set; }
        public String sort1 { get; set; }
    }
}
