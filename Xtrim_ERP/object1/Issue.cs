using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Issue:Persistent
    {
        public String active { get; set; }
        public String date_cancel { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String issue_id { get; set; }
        public String issue_name_e { get; set; }
        public String issue_name_t { get; set; }
        public String sort1 { get; set; }
        public String user_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
    }
}
