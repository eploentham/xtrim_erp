using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class JobImportContainer:Persistent
    {
        public String job_import_container_id { get; set; }
        public String job_import_id { get; set; }
        public String container_no { get; set; }
        public String container_doct_type_id { get; set; }
        public String seal { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
    }
}
