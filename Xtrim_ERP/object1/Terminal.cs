using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Terminal:Persistent
    {
        public String terminal_id { get; set; }
        public String terminal_code { get; set; }
        public String terminal_name_t { get; set; }
        public String terminal_name_e { get; set; }
        
        public String sort1 { get; set; }
    }
}
