using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class CompanyBank:Persistent
    {
        public String comp_bank_id { get; set; }
        public String comp_id { get; set; }
        public String comp_bank_name_t { get; set; }
        public String comp_bank_branch { get; set; }
        public String comp_bank_active { get; set; }
        public String acc_number { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String active { get; set; }
        public String bank_id { get; set; }
    }
}
