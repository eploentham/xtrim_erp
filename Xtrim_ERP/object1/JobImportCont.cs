using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class JobImportCont:Persistent
    {
        public String job_import_cont_id { get; set; }
        public String job_import_id { get; set; }
        public String row_no { get; set; }
        public String container_no { get; set; }
        public String container_seal { get; set; }
        public String container_type { get; set; }
        public String packages_per_con { get; set; }
        public String unit_package_id { get; set; }
        public String gw_per_con { get; set; }
        public String unit_gw_id { get; set; }
        public String truck_id { get; set; }
        public String qty_container { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
    }
}
