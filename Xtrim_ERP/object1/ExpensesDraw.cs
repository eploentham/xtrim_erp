using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class ExpensesDraw:Persistent
    {
        public String expense_draw_id { get; set; }
        public String expense_draw_code { get; set; }
        public String expense_name_t { get; set; }
        public String expense_draw_name_e { get; set; }
        public String expense_draw_type_id { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_crate { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String expense_type_id { get; set; }
    }
}
