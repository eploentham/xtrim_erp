using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class EntryType:Persistent
    {
        public String entry_type_id { get; set; }
        public String entry_type_code { get; set; }
        public String entry_type_name_t { get; set; }
        public String entry_type_name_e { get; set; }
        public String status_app { get; set; }

        public String sort1 { get; set; }
    }
}
