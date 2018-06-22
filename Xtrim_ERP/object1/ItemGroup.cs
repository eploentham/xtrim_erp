using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ItemGroup:Persistent
    {
        public String item_group_id { get; set; }
        public String item_group_name_t { get; set; }
        public String item_group_name_e { get; set; }
    }
}
