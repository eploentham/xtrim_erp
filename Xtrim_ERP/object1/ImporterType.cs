using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ImporterType:Persistent
    {
        public String importer_type_id { get; set; }
        public String importer_type_code { get; set; }
        public String importer_type_name { get; set; }
        public String active { get; set; }
    }
}
