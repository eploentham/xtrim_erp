using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportDeliveryDB
    {
        public JobImportDelivery jdv;
        ConnectDB conn;

        public JobImportDeliveryDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jdv = new JobImportDelivery();
            jdv.job_import_delivery_id = "job_import_delivery_id";
            jdv.job_import_id = "job_import_id";
            jdv.row1 = "row1";
            jdv.delivery_doc_no = "delivery_doc_no";
            jdv.car_type_id = "car_type_id";
            jdv.transporter_id = "transporter_id";
            jdv.place_id = "place_id";
            jdv.packages = "packages";
            jdv.unit_package_id = "unit_package_id";
            jdv.gw = "gw";
            jdv.unit_gw_id = "unit_gw_id";
            jdv.volume1 = "volume1";
            jdv.unit_volume1_id = "unit_volume1_id";
            jdv.job_import_delivery1_id = "job_import_delivery1_id";
            jdv.container_no = "container_no";
            jdv.doc_type_namet_container = "doc_type_namet_container";
            jdv.seal = "seal";
            jdv.yard_container = "yard_container";
            jdv.remark = "remark";
            jdv.active = "active";
            jdv.date_create = "date_create";
            jdv.date_modi = "date_modi";
            jdv.date_cancel = "date_cancel";
            jdv.user_create = "user_create";
            jdv.user_modi = "user_modi";
            jdv.user_cancel = "user_cancel";
        }
    }
}
