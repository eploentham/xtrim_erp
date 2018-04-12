using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Bank:Persistent
    {
        public String bank_id { get; set; }
        public String bank_code { get; set; }
        public String bank_name_t { get; set; }
        public String bank_name_e { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
    }
}
