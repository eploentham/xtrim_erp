using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class Privilege:Persistent
    {
        public String priv_id { get; set; }
        public String code { get; set; }
        public String desc1 { get; set; }
        public String announceno { get; set; }
        public String announcedd { get; set; }
        public String announcedesc { get; set; }
        public String startdate { get; set; }
        public String finishdate { get; set; }
        public String permitwarn { get; set; }
        public String progver { get; set; }
        public String usrname { get; set; }
        public String update_dd { get; set; }
        public String update_tt { get; set; }
        public String status_app { get; set; }
        public String sort1 { get; set; }

    }
}
