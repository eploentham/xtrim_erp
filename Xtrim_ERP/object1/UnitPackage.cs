using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class UnitPackage:Persistent
    {
        public String unit_package_id { get; set; }
        public String unit_package_code { get; set; }
        public String unit_package_name_t { get; set; }
        public String unit_package_name_e { get; set; }

        public String sort1 { get; set; }
    }
}
