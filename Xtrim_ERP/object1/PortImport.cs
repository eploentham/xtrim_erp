using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class PortImport:Persistent
    {
        public String port_import_id { get; set; }
        public String port_import_code { get; set; }
        public String port_import_name_t { get; set; }
        public String port_import_name_e { get; set; }        
        public String status_app { get; set; }        
        public String sort1 { get; set; }
    }
}
