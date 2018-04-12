using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Staff:Persistent
    {
        public String staff_id { get; set; }
        public String staff_code { get; set; }
        public String username { get; set; }
        public String prefix { get; set; }
        public String staff_name_t { get; set; }
        public String staff_name_e { get; set; }
        public String password1 { get; set; }
        public String active { get; set; }
        public String staff_remark { get; set; }
        public String priority { get; set; }
        public String tele { get; set; }
        public String mobile { get; set; }
        public String fax { get; set; }
        public String email { get; set; }
        public String posi_id { get; set; }
        public String posi_name { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
    }
}
