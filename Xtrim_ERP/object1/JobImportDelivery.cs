using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class JobImportDelivery:Persistent
    {
        public String job_import_delivery_id { get; set; }
        public String job_import_id { get; set; }
        public String row1 { get; set; }
        public String delivery_doc_no { get; set; }
        public String car_type_id { get; set; }
        public String transporter_id { get; set; }
        public String place_id { get; set; }
        public String packages { get; set; }
        public String unit_package_id { get; set; }
        public String gw { get; set; }
        public String unit_gw_id { get; set; }
        public String volume1 { get; set; }
        public String unit_volume1_id { get; set; }
        public String job_import_delivery1_id { get; set; }
        public String container_no { get; set; }
        public String doc_type_namet_container { get; set; }
        public String seal { get; set; }
        public String yard_container { get; set; }
        public String remark { get; set; }
        public String active { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
    }
}
