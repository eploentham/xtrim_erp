using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ExpensesDrawType:Persistent
    {
        public String expenses_draw_type_id { get; set; }
        public String expenses_draw_type_code { get; set; }
        public String expenses_draw_type_name_t { get; set; }
        public String expenses_draw_type_name_e { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String use_cancel { get; set; }
        public String sort1 { get; set; }
    }
}
