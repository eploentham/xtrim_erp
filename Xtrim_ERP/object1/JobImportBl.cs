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
        public String packages_total { get; set; }
        public String unit_package1_id { get; set; }
        public String total_con20 { get; set; }
        public String total_con40 { get; set; }
        public String volume1 { get; set; }
        public String port_of_loading_id { get; set; }
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

        public String ugwCode { get; set; }
        public String ugwNameT { get; set; }

        public String utpCode { get; set; }
        public String utpNameT { get; set; }

        public String polCode { get; set; }
        public String polNameT { get; set; }

        public String tmnCode { get; set; }
        public String tmnNameT { get; set; }

        public String ptiCode { get; set; }
        public String ptiNameT { get; set; }

        public String packages1 { get; set; }
        public String packages2 { get; set; }
        public String packages3 { get; set; }
        public String packages4 { get; set; }
        public String packages5 { get; set; }
        public String unit_package2_id { get; set; }
        public String unit_package3_id { get; set; }
        public String unit_package4_id { get; set; }
        public String unit_package5_id { get; set; }
        public String gw_total { get; set; }
        public String container1 { get; set; }
        public String container2 { get; set; }
        public String container3 { get; set; }
        public String container4 { get; set; }
        public String container5 { get; set; }
        public String container6 { get; set; }
        public String container1_doc_type_id { get; set; }
        public String container2_doc_type_id { get; set; }
        public String container3_doc_type_id { get; set; }
        public String container4_doc_type_id { get; set; }
        public String container5_doc_type_id { get; set; }
        public String container6_doc_type_id { get; set; }
        //public String ugwCode { get; set; }
        //public String ugwNameT { get; set; }
    }
}
