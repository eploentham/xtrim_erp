using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.object1
{
    public class JobImportBl:Persistent
    {
        public String job_import_bl_id { get; set; }
        public String job_import_id { get; set; }
        public String forwarder_id { get; set; }
        public String mbl_mawb { get; set; }
        public String hbl_hawb { get; set; }
        public String m_vessel { get; set; }
        public String f_vessel { get; set; }
        public String etd { get; set; }
        public String eta { get; set; }
        public String port_imp_id { get; set; }
        public String terminal_id { get; set; }
        public String marsk { get; set; }
        public String description { get; set; }
        public String gw { get; set; }
        public String gw_unit_id { get; set; }
        public String total_packages { get; set; }
        public String unit_package_id { get; set; }
        public String total_con20 { get; set; }
        public String total_con40 { get; set; }
        public String volume1 { get; set; }
        public String port_of_loding_id { get; set; }
        public String date_check_exam { get; set; }
        public String date_delivery { get; set; }
        public String date_tofac { get; set; }
        public String truck_id { get; set; }
        public String car_number { get; set; }
        public String tranfer_with_job_id { get; set; }
        public String truck_cop_id { get; set; }
        public String status_doc_forrow { get; set; }
        public String doc_forrow { get; set; }
        public String date_doc_forrow { get; set; }
        public String status_job_forrow { get; set; }
        public String job_forrow_description { get; set; }
        public String date_finish_job_forrow { get; set; }
        public String status_oth_job { get; set; }
        public String delivery_remark { get; set; }
        public String container_yard { get; set; }
        public String oth_job_no { get; set; }

        public String fwdCode { get; set; }
        public String fwdNameT { get; set; }
    }
}
