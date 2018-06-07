using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class JobImportImage:Persistent
    {
        public String job_import_image_id { get; set; }
        public String job_import_id { get; set; }
        public String path_pic { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String status_pic { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String sort1 { get; set; }
    }
}
