using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class JobImportBlDB
    {
        public JobImportBl jbl;
        ConnectDB conn;

        public JobImportBlDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jbl = new JobImportBl();
            jbl.job_import_bl_id = "job_import_bl_id";
            jbl.job_import_id = "job_import_id";
            jbl.forwarder_id = "forwarder_id";
            jbl.mbl_mawb = "mbl_mawb";
            jbl.hbl_hawb = "hbl_hawb";
            jbl.m_vessel = "m_vessel";
            jbl.f_vessel = "f_vessel";
            jbl.etd = "etd";
            jbl.eta = "eta";
            jbl.port_imp_id = "port_import_id";

            jbl.terminal_id = "terminal_id";
            jbl.marsk = "marsk";
            jbl.description = "description";
            jbl.gw = "gw";
            jbl.gw_unit_id = "unit_gw_id";
            jbl.packages_total = "packages_total";
            jbl.unit_package1_id = "unit_package1_id";
            jbl.total_con20 = "total_con20";
            jbl.total_con40 = "total_con40";
            jbl.volume1 = "volume1";

            jbl.port_of_loading_id = "port_of_loading_id";
            jbl.date_check_exam = "date_check_exam";
            jbl.date_delivery = "date_delivery";
            jbl.date_tofac = "date_tofac";
            jbl.truck_id = "truck_id";
            jbl.car_number = "car_number";
            jbl.tranfer_with_job_id = "tranfer_with_job_id";
            jbl.truck_cop_id = "trunk_cop_id";
            jbl.status_doc_forrow = "status_doc_forrow";
            jbl.doc_forrow = "doc_forrow";

            jbl.date_doc_forrow = "date_doc_forrow";
            jbl.status_job_forrow = "status_job_forrow";
            jbl.job_forrow_description = "job_forrow_description";
            jbl.date_finish_job_forrow = "date_finish_job_forrow";
            jbl.status_oth_job = "status_oth_job";
            jbl.delivery_remark = "delivery_remark";
            jbl.container_yard = "container_yard";
            jbl.date_create = "date_create";
            jbl.date_modi = "date_modi";
            jbl.date_cancel = "date_cancel";

            jbl.user_create = "user_create";
            jbl.user_modi = "user_modi";
            jbl.user_cancel = "user_cancel";
            jbl.active = "active";
            jbl.remark = "remark";
            jbl.oth_job_no = "oth_job_no";

            jbl.fwdCode = "";
            jbl.fwdCode = "";

            jbl.ugwCode = "";
            jbl.ugwNameT = "";
            jbl.utpCode = "";
            jbl.utpNameT = "";
            jbl.polCode = "";
            jbl.polNameT = "";
            jbl.tmnCode = "";
            jbl.tmnNameT = "";

            jbl.packages1 = "packages1";
            jbl.packages2 = "packages2";
            jbl.packages3 = "packages3";
            jbl.packages4 = "packages4";
            jbl.packages5 = "packages5";
            jbl.unit_package1_id = "unit_package1_id";
            jbl.unit_package2_id = "unit_package2_id";
            jbl.unit_package3_id = "unit_package3_id";
            jbl.unit_package4_id = "unit_package4_id";
            jbl.unit_package5_id = "unit_package5_id";
            jbl.gw_total = "gw_total";
            jbl.container1 = "container1";
            jbl.container2 = "container2";
            jbl.container3 = "container3";
            jbl.container4 = "container4";
            jbl.container5 = "container5";
            jbl.container6 = "container6";
            jbl.container1_doc_type_id = "container1_doc_type_id";
            jbl.container2_doc_type_id = "container2_doc_type_id";
            jbl.container3_doc_type_id = "container3_doc_type_id";
            jbl.container4_doc_type_id = "container4_doc_type_id";
            jbl.container5_doc_type_id = "container5_doc_type_id";
            jbl.container6_doc_type_id = "container6_doc_type_id";
            jbl.bl_type = "bl_type";
            jbl.consignmnt_id = "consignmnt_id";
            jbl.bl = "bl";
            jbl.unit_volume1_id = "unit_volume1_id";
            jbl.deli_gw = "deli_gw";
            jbl.deli_imp_addr = "deli_imp_addr";
            jbl.deli_imp_id = "deli_imp_id";
            jbl.deli_package = "deli_package";
            jbl.deli_place_addr_id = "deli_place_addr_id";
            jbl.deli_place_addr_name_t = "deli_place_addr_name_t";
            jbl.deli_truck_cop_id = "deli_truck_cop_id";
            jbl.deli_unit_gw_id = "deli_unit_gw_id";
            jbl.deli_unit_package_id = "deli_unit_package_id";
            jbl.deli_unit_volume_id = "deli_unit_volume_id";
            jbl.deli_volume = "deli_volume";
            jbl.deli_yard_id = "deli_yard_id";
            jbl.deli_truck_id = "deli_truck_id";
            jbl.deli_yard_addr_name_t = "deli_yard_addr_name_t";

            jbl.table = "t_job_import_bl";
            jbl.pkField = "job_import_bl_id";
        }
        private void chkNull(JobImportBl p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.container_yard = p.container_yard == null ? "" : p.container_yard;
            p.delivery_remark = p.delivery_remark == null ? "" : p.delivery_remark;
            p.remark = p.remark == null ? "" : p.remark;
            p.status_oth_job = p.status_oth_job == null ? "" : p.status_oth_job;
            p.date_finish_job_forrow = p.date_finish_job_forrow == null ? "" : p.date_finish_job_forrow;
            p.job_forrow_description = p.job_forrow_description == null ? "" : p.job_forrow_description;
            p.status_job_forrow = p.status_job_forrow == null ? "" : p.status_job_forrow;
            p.date_doc_forrow = p.date_doc_forrow == null ? "" : p.date_doc_forrow;
            p.doc_forrow = p.doc_forrow == null ? "" : p.doc_forrow;
            p.status_doc_forrow = p.status_doc_forrow == null ? "" : p.status_doc_forrow;
            p.car_number = p.car_number == null ? "" : p.car_number;
            p.date_tofac = p.date_tofac == null ? "" : p.date_tofac;
            p.date_delivery = p.date_delivery == null ? "" : p.date_delivery;
            p.date_check_exam = p.date_check_exam == null ? "" : p.date_check_exam;
            p.volume1 = p.volume1 == null ? "" : p.volume1;
            p.total_con40 = p.total_con40 == null ? "" : p.total_con40;
            p.total_con20 = p.total_con20 == null ? "" : p.total_con20;
            p.packages_total = p.packages_total == null ? "" : p.packages_total;
            p.gw = p.gw == null ? "" : p.gw;
            p.description = p.description == null ? "" : p.description;
            p.marsk = p.marsk == null ? "" : p.marsk;
            p.eta = p.eta == null ? "" : p.eta;
            p.etd = p.etd == null ? "" : p.etd;
            p.f_vessel = p.f_vessel == null ? "" : p.f_vessel;
            p.m_vessel = p.m_vessel == null ? "" : p.m_vessel;
            p.hbl_hawb = p.hbl_hawb == null ? "" : p.hbl_hawb;
            p.mbl_mawb = p.mbl_mawb == null ? "" : p.mbl_mawb;
            p.oth_job_no = p.oth_job_no == null ? "" : p.oth_job_no;
            p.deli_gw = p.deli_gw == null ? "" : p.deli_gw;
            p.deli_imp_addr = p.deli_imp_addr == null ? "" : p.deli_imp_addr;
            p.deli_package = p.deli_package == null ? "" : p.deli_package;
            p.deli_place_addr_name_t = p.deli_place_addr_name_t == null ? "" : p.deli_place_addr_name_t;
            p.deli_volume = p.deli_volume == null ? "" : p.deli_volume;
            p.deli_yard_addr_name_t = p.deli_yard_addr_name_t == null ? "" : p.deli_yard_addr_name_t;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            conn.user.staff_id = conn.user.staff_id == null ? "" : conn.user.staff_id;
            p.packages1 = p.packages1 == null ? "" : p.packages1;
            p.packages2 = p.packages2 == null ? "" : p.packages2;
            p.packages3 = p.packages3 == null ? "" : p.packages3;
            p.packages4 = p.packages4 == null ? "" : p.packages4;
            p.packages5 = p.packages5 == null ? "" : p.packages5;
            p.container1 = p.container1 == null ? "" : p.container1;
            p.container2 = p.container2 == null ? "" : p.container2;
            p.container3 = p.container3 == null ? "" : p.container3;
            p.container4 = p.container4 == null ? "" : p.container4;
            p.container5 = p.container5 == null ? "" : p.container5;
            p.container6 = p.container6 == null ? "" : p.container6;
            p.gw_total = p.gw_total == null ? "" : p.gw_total;
            p.bl = p.bl == null ? "" : p.bl;

            p.truck_cop_id = int.TryParse(p.truck_cop_id, out chk) ? chk.ToString() : "0";
            p.tranfer_with_job_id = int.TryParse(p.tranfer_with_job_id, out chk) ? chk.ToString() : "0";
            p.truck_id = int.TryParse(p.truck_id, out chk) ? chk.ToString() : "0";
            p.port_of_loading_id = int.TryParse(p.port_of_loading_id, out chk) ? chk.ToString() : "0";
            p.unit_package1_id = int.TryParse(p.unit_package1_id, out chk) ? chk.ToString() : "0";
            p.gw_unit_id = int.TryParse(p.gw_unit_id, out chk) ? chk.ToString() : "0";
            p.terminal_id = int.TryParse(p.terminal_id, out chk) ? chk.ToString() : "0";
            p.deli_imp_id = int.TryParse(p.deli_imp_id, out chk) ? chk.ToString() : "0";
            p.deli_place_addr_id = int.TryParse(p.deli_place_addr_id, out chk) ? chk.ToString() : "0";
            p.deli_truck_cop_id = int.TryParse(p.deli_truck_cop_id, out chk) ? chk.ToString() : "0";
            p.deli_unit_gw_id = int.TryParse(p.deli_unit_gw_id, out chk) ? chk.ToString() : "0";
            p.deli_unit_package_id = int.TryParse(p.deli_unit_package_id, out chk) ? chk.ToString() : "0";
            p.deli_unit_volume_id = int.TryParse(p.deli_unit_volume_id, out chk) ? chk.ToString() : "0";
            p.deli_yard_id = int.TryParse(p.deli_yard_id, out chk) ? chk.ToString() : "0";
            p.deli_truck_id = int.TryParse(p.deli_truck_id, out chk) ? chk.ToString() : "0";

            p.port_imp_id = Decimal.TryParse(p.port_imp_id, out chk1) ? chk1.ToString() : "0";
            p.forwarder_id = Decimal.TryParse(p.forwarder_id, out chk1) ? chk1.ToString() : "0";
            p.job_import_id = Decimal.TryParse(p.job_import_id, out chk1) ? chk1.ToString() : "0";
            p.container1_doc_type_id = Decimal.TryParse(p.container1_doc_type_id, out chk1) ? chk1.ToString() : "0";
            p.container2_doc_type_id = Decimal.TryParse(p.container2_doc_type_id, out chk1) ? chk1.ToString() : "0";
            p.container3_doc_type_id = Decimal.TryParse(p.container3_doc_type_id, out chk1) ? chk1.ToString() : "0";
            p.container4_doc_type_id = Decimal.TryParse(p.container4_doc_type_id, out chk1) ? chk1.ToString() : "0";
            p.container5_doc_type_id = Decimal.TryParse(p.container5_doc_type_id, out chk1) ? chk1.ToString() : "0";
            p.container6_doc_type_id = Decimal.TryParse(p.container6_doc_type_id, out chk1) ? chk1.ToString() : "0";
            p.unit_package1_id = Decimal.TryParse(p.unit_package1_id, out chk1) ? chk1.ToString() : "0";
            p.unit_package2_id = Decimal.TryParse(p.unit_package2_id, out chk1) ? chk1.ToString() : "0";
            p.unit_package3_id = Decimal.TryParse(p.unit_package3_id, out chk1) ? chk1.ToString() : "0";
            p.unit_package4_id = Decimal.TryParse(p.unit_package4_id, out chk1) ? chk1.ToString() : "0";
            p.unit_package5_id = Decimal.TryParse(p.unit_package5_id, out chk1) ? chk1.ToString() : "0";
            p.consignmnt_id = Decimal.TryParse(p.consignmnt_id, out chk1) ? chk1.ToString() : "0";
            p.unit_volume1_id = Decimal.TryParse(p.unit_volume1_id, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(JobImportBl p)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            Decimal chk1 = 0;


            chkNull(p);

            sql = "Insert Into " + jbl.table + "(" + jbl.job_import_id + "," + jbl.forwarder_id + "," + jbl.mbl_mawb + "," +
                jbl.hbl_hawb + "," + jbl.m_vessel + "," + jbl.f_vessel + "," +
                jbl.etd + "," + jbl.eta + "," + jbl.port_imp_id + "," +
                jbl.terminal_id + "," + jbl.marsk + "," + jbl.description + "," +
                jbl.gw + "," + jbl.gw_unit_id + "," + jbl.packages_total + "," +
                jbl.unit_package1_id + "," + jbl.total_con20 + "," + jbl.total_con40 + "," +
                jbl.volume1 + "," + jbl.port_of_loading_id + "," + jbl.date_check_exam + "," +
                jbl.date_delivery + "," + jbl.date_tofac + ", " + jbl.truck_id + ", " +
                jbl.car_number + "," + jbl.tranfer_with_job_id + ", " + jbl.truck_cop_id + ", " +
                jbl.status_doc_forrow + "," + jbl.doc_forrow + ", " + jbl.date_doc_forrow + ", " +
                jbl.status_job_forrow + "," + jbl.job_forrow_description + ", " + jbl.date_finish_job_forrow + ", " +
                jbl.status_oth_job + "," + jbl.delivery_remark + ", " + jbl.container_yard + ", " +                
                jbl.date_create + "," + jbl.date_modi + ", " + jbl.date_cancel + ", " +
                jbl.user_create + "," + jbl.user_modi + ", " + jbl.user_cancel + ", " +
                jbl.active + "," + jbl.remark + "," + jbl.oth_job_no + "," +
                jbl.packages1 + "," + jbl.packages2 + "," + jbl.packages3 + "," +
                jbl.packages4 + "," + jbl.packages5 + "," + jbl.container1 + "," +
                jbl.container2 + "," + jbl.container3 + "," + jbl.container4 + "," +
                jbl.container5 + "," + jbl.container6 + "," + jbl.gw_total + "," +
                jbl.container1_doc_type_id + "," + jbl.container2_doc_type_id + "," + jbl.container3_doc_type_id + "," +
                jbl.container4_doc_type_id + "," + jbl.container5_doc_type_id + "," + jbl.container6_doc_type_id + "," +
                jbl.unit_package2_id + "," + jbl.unit_package3_id + "," + jbl.unit_package4_id + "," +
                jbl.unit_package5_id + ", " + jbl.bl_type + ", " + jbl.consignmnt_id + ", " +
                jbl.bl + ", " + jbl.unit_volume1_id + "," +
                jbl.deli_gw + ", " + jbl.deli_imp_addr + ", " + jbl.deli_imp_id + ", " +
                jbl.deli_package + ", " + jbl.deli_place_addr_id + ", " + jbl.deli_place_addr_name_t + ", " +
                jbl.deli_truck_cop_id + ", " + jbl.deli_unit_gw_id + ", " + jbl.deli_unit_package_id + ", " +
                jbl.deli_unit_volume_id + ", " + jbl.deli_volume + ", " + jbl.deli_yard_id + ", " +
                jbl.deli_truck_id + "," + jbl.deli_yard_addr_name_t + " " +
                ") " +
                "Values ('" + p.job_import_id + "','" + p.forwarder_id + "','" + p.mbl_mawb + "'," +
                "'" + p.hbl_hawb.Replace("'", "''") + "','" + p.m_vessel.Replace("'", "''") + "','" + p.f_vessel.Replace("'", "''") + "'," +
                "'" + p.etd.Replace("'", "''") + "','" + p.eta.Replace("'", "''") + "','" + p.port_imp_id + "'," +
                "'" + p.terminal_id + "','" + p.marsk.Replace("'", "''") + "','" + p.description.Replace("'", "''") + "'," +
                "'" + p.gw.Replace("'", "''") + "','" + p.gw_unit_id + "','" + p.packages_total.Replace("'", "''") + "'," +
                "'" + p.unit_package1_id + "','" + p.total_con20.Replace("'", "''") + "','" + p.total_con40.Replace("'", "''") + "'," +
                "'" + p.volume1.Replace("'", "''") + "','" + p.port_of_loading_id + "','" + p.date_check_exam + "', " +
                "'" + p.date_delivery + "','" + p.date_tofac + "','" + p.truck_id + "', " +
                "'" + p.car_number.Replace("'", "''") + "','" + p.tranfer_with_job_id + "','" + p.truck_cop_id + "', " +
                "'" + p.status_doc_forrow.Replace("'", "''") + "','" + p.doc_forrow.Replace("'", "''") + "','" + p.date_doc_forrow + "', " +
                "'" + p.status_job_forrow.Replace("'", "''") + "','" + p.job_forrow_description.Replace("'", "''") + "','" + p.date_finish_job_forrow + "', " +
                "'" + p.status_oth_job + "','" + p.delivery_remark.Replace("'", "''") + "','" + p.container_yard + "', " +                
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + conn.user.staff_id + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.active + "','" + p.remark.Replace("'", "''")  + "','" + p.oth_job_no.Replace("'", "''") + "', " +
                "'" + p.packages1 + "','" + p.packages2.Replace("'", "''") + "','" + p.packages3.Replace("'", "''") + "', " +
                "'" + p.packages4 + "','" + p.packages5.Replace("'", "''") + "','" + p.container1.Replace("'", "''") + "', " +
                "'" + p.container2 + "','" + p.container3.Replace("'", "''") + "','" + p.container4.Replace("'", "''") + "', " +
                "'" + p.container5 + "','" + p.container6.Replace("'", "''") + "','" + p.gw_total.Replace("'", "''") + "', " +
                "'" + p.container1_doc_type_id + "','" + p.container2_doc_type_id + "','" + p.container3_doc_type_id + "', " +
                "'" + p.container4_doc_type_id + "','" + p.container5_doc_type_id + "','" + p.container6_doc_type_id + "', " +
                "'" + p.unit_package2_id + "','" + p.unit_package3_id.Replace("'", "''") + "','" + p.unit_package4_id + "', " +
                "'" + p.unit_package5_id + "','" + p.bl_type + "','" + p.consignmnt_id + "'," +
                "'" + p.bl + "','" + p.unit_volume1_id + "'," +
                "'" + p.deli_gw + "','" + p.deli_imp_addr + "','" + p.deli_imp_id + "'," +
                "'" + p.deli_package + "','" + p.deli_place_addr_id + "','" + p.deli_place_addr_name_t + "'," +
                "'" + p.deli_truck_cop_id + "','" + p.deli_unit_gw_id + "','" + p.deli_unit_package_id + "'," +
                "'" + p.deli_unit_volume_id + "','" + p.deli_volume + "','" + p.deli_yard_id + "'," +
                "'" + p.deli_truck_id + "','" + p.deli_yard_addr_name_t + "' " +
                ")";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String update(JobImportBl p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + jbl.table + " Set " +
                " " + jbl.job_import_id + " = '" + p.job_import_id + "'" +
                "," + jbl.forwarder_id + " = '" + p.forwarder_id + "'" +
                "," + jbl.hbl_hawb + " = '" + p.hbl_hawb.Replace("'", "''") + "'" +
                "," + jbl.m_vessel + " = '" + p.m_vessel.Replace("'", "''") + "'" +
                "," + jbl.f_vessel + " = '" + p.f_vessel.Replace("'", "''") + "'" +
                "," + jbl.etd + " = '" + p.etd.Replace("'", "''") + "'" +
                "," + jbl.eta + " = '" + p.eta.Replace("'", "''") + "'" +
                "," + jbl.port_imp_id + " = '" + p.port_imp_id + "'" +
                "," + jbl.terminal_id + " = '" + p.terminal_id.Replace("'", "''") + "'" +
                "," + jbl.marsk + " = '" + p.marsk.Replace("'", "''") + "'" +
                "," + jbl.description + " = '" + p.description.Replace("'", "''") + "'" +
                "," + jbl.gw + " = '" + p.gw.Replace("'", "''") + "'" +
                "," + jbl.gw_unit_id + " = '" + p.gw_unit_id + "'" +
                "," + jbl.packages_total + " = '" + p.packages_total + "'" +
                "," + jbl.unit_package1_id + " = '" + p.unit_package1_id + "'" +
                "," + jbl.total_con20 + " = '" + p.total_con20.Replace("'", "''") + "'" +
                "," + jbl.total_con40 + " = '" + p.total_con40.Replace("'", "''") + "'" +
                "," + jbl.volume1 + " = '" + p.volume1.Replace("'", "''") + "'" +
                "," + jbl.port_of_loading_id + " = '" + p.port_of_loading_id + "' " +
                "," + jbl.date_check_exam + " = '" + p.date_check_exam + "' " +
                "," + jbl.date_delivery + " = '" + p.date_delivery + "' " +
                "," + jbl.date_tofac + " = '" + p.date_tofac + "' " +
                "," + jbl.truck_id + " = '" + p.truck_id + "' " +
                "," + jbl.car_number + " = '" + p.car_number.Replace("'", "''") + "' " +
                "," + jbl.tranfer_with_job_id + " = '" + p.tranfer_with_job_id + "' " +
                "," + jbl.truck_cop_id + " = '" + p.truck_cop_id + "' " +
                "," + jbl.status_doc_forrow + " = '" + p.status_doc_forrow + "' " +
                "," + jbl.doc_forrow + " = '" + p.doc_forrow.Replace("'", "''") + "' " +
                "," + jbl.date_doc_forrow + " = '" + p.date_doc_forrow + "' " +
                "," + jbl.status_job_forrow + " = '" + p.status_job_forrow.Replace("'", "''") + "' " +
                "," + jbl.job_forrow_description + " = '" + p.job_forrow_description.Replace("'", "''") + "' " +
                "," + jbl.date_finish_job_forrow + " = '" + p.date_finish_job_forrow.Replace("'", "''") + "' " +
                "," + jbl.status_oth_job + " = '" + p.status_oth_job.Replace("'", "''") + "' " +
                "," + jbl.delivery_remark + " = '" + p.delivery_remark.Replace("'", "''") + "' " +
                "," + jbl.container_yard + " = '" + p.container_yard.Replace("'", "''") + "' " +
                //"," + jbl.date_create + " = '" + p.date_create.Replace("'", "''") + "' " +
                "," + jbl.date_modi + " = now() " +
                //"," + jbl.date_cancel + " = '" + p.date_cancel.Replace("'", "''") + "' " +
                //"," + jbl.user_create + " = '" + p.user_create.Replace("'", "''") + "' " +
                "," + jbl.user_modi + " = '" + conn.user.staff_id + "' " +
                //"," + jbl.user_cancel + " = '" + p.user_cancel.Replace("'", "''") + "' " +
                "," + jbl.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + jbl.packages1 + " = '" + p.packages1.Replace("'", "''") + "' " +
                "," + jbl.packages2 + " = '" + p.packages2.Replace("'", "''") + "' " +
                "," + jbl.packages3 + " = '" + p.packages3.Replace("'", "''") + "' " +
                "," + jbl.packages4 + " = '" + p.packages4.Replace("'", "''") + "' " +
                "," + jbl.packages5 + " = '" + p.packages5.Replace("'", "''") + "' " +
                "," + jbl.container1 + " = '" + p.container1.Replace("'", "''") + "' " +
                "," + jbl.container2 + " = '" + p.container2.Replace("'", "''") + "' " +
                "," + jbl.container3 + " = '" + p.container3.Replace("'", "''") + "' " +
                "," + jbl.container4 + " = '" + p.container4.Replace("'", "''") + "' " +
                "," + jbl.container5 + " = '" + p.container5.Replace("'", "''") + "' " +
                "," + jbl.container6 + " = '" + p.container6.Replace("'", "''") + "' " +
                "," + jbl.gw_total + " = '" + p.gw_total.Replace("'", "''") + "' " +
                "," + jbl.container1_doc_type_id + " = '" + p.container1_doc_type_id.Replace("'", "''") + "' " +
                "," + jbl.container2_doc_type_id + " = '" + p.container2_doc_type_id.Replace("'", "''") + "' " +
                "," + jbl.container3_doc_type_id + " = '" + p.container3_doc_type_id.Replace("'", "''") + "' " +
                "," + jbl.container4_doc_type_id + " = '" + p.container4_doc_type_id.Replace("'", "''") + "' " +
                "," + jbl.container5_doc_type_id + " = '" + p.container5_doc_type_id.Replace("'", "''") + "' " +
                "," + jbl.container6_doc_type_id + " = '" + p.container6_doc_type_id.Replace("'", "''") + "' " +
                "," + jbl.unit_package2_id + " = '" + p.unit_package2_id.Replace("'", "''") + "' " +
                "," + jbl.unit_package3_id + " = '" + p.unit_package3_id.Replace("'", "''") + "' " +
                "," + jbl.unit_package4_id + " = '" + p.unit_package4_id.Replace("'", "''") + "' " +
                "," + jbl.unit_package5_id + " = '" + p.unit_package5_id.Replace("'", "''") + "' " +
                "," + jbl.mbl_mawb + " = '" + p.mbl_mawb.Replace("'", "''") + "' " +
                "," + jbl.bl_type + " = '" + p.bl_type.Replace("'", "''") + "' " +
                "," + jbl.consignmnt_id + " = '" + p.consignmnt_id.Replace("'", "''") + "' " +
                "," + jbl.bl + " = '" + p.bl.Replace("'", "''") + "' " +
                "," + jbl.unit_volume1_id + " = '" + p.unit_volume1_id.Replace("'", "''") + "' " +
                "Where " + jbl.pkField + "='" + p.job_import_bl_id+ "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String updateDeli(JobImportBl p)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);

            sql = "Update " + jbl.table + " Set " +
                " " + jbl.deli_gw + " = '" + p.deli_gw + "'" +
                "," + jbl.deli_imp_addr + " = '" + p.deli_imp_addr + "'" +
                "," + jbl.deli_imp_id + " = '" + p.deli_imp_id.Replace("'", "''") + "'" +
                "," + jbl.deli_package + " = '" + p.deli_package.Replace("'", "''") + "'" +
                "," + jbl.deli_place_addr_id + " = '" + p.deli_place_addr_id.Replace("'", "''") + "'" +
                "," + jbl.deli_place_addr_name_t + " = '" + p.deli_place_addr_name_t.Replace("'", "''") + "'" +
                "," + jbl.deli_truck_cop_id + " = '" + p.deli_truck_cop_id.Replace("'", "''") + "'" +
                "," + jbl.deli_unit_gw_id + " = '" + p.deli_unit_gw_id + "'" +
                "," + jbl.deli_unit_package_id + " = '" + p.deli_unit_package_id.Replace("'", "''") + "'" +
                "," + jbl.deli_unit_volume_id + " = '" + p.deli_unit_volume_id.Replace("'", "''") + "'" +
                "," + jbl.deli_volume + " = '" + p.deli_volume.Replace("'", "''") + "'" +
                "," + jbl.deli_yard_id + " = '" + p.deli_yard_id.Replace("'", "''") + "'" +
                "," + jbl.deli_truck_id + " = '" + p.deli_truck_id.Replace("'", "''") + "'" +
                "," + jbl.deli_yard_addr_name_t + " = '" + p.deli_yard_addr_name_t.Replace("'", "''") + "'" +
                "Where " + jbl.pkField + "='" + p.job_import_bl_id + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String insertJobImportBl(JobImportBl p)
        {
            String re = "";

            if (p.job_import_bl_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }
            return re;
        }

        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + jbl.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select jbl.*  " +
                "From " + jbl.table + " jbl " +
                " " +
                "Where jbl." + jbl.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select jbl.* " +
                "From " + jbl.table + " jbl " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jbl." + jbl.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public JobImportBl selectByPk1(String copId)
        {
            JobImportBl cop1 = new JobImportBl();
            DataTable dt = new DataTable();
            String sql = "select jbl.* " +
                "From " + jbl.table + " jbl " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where jbl." + jbl.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setJobImportBl(dt);
            return cop1;
        }
        public JobImportBl selectByJobId(String copId)
        {
            JobImportBl cop1 = new JobImportBl();
            DataTable dt = new DataTable();
            String sql = "select jbl.*, " +
                "IFNULL(fwd.forwarder_code, '') as forwarder_code, IFNULL(fwd.forwarder_name_t, '') as forwarder_name_t, " +
                "IFNULL(pol.port_of_loading_code, '') as port_of_loading_code, IFNULL(pol.port_of_loading_name_t, '') as port_of_loading_name_t, " +
                "IFNULL(tmn.terminal_code, '') as terminal_code, IFNULL(tmn.terminal_name_t, '') as terminal_name_t, " +
                "IFNULL(pti.port_import_code, '') as port_import_code, IFNULL(pti.port_import_name_t, '') as port_import_name_t, " +
                "IFNULL(ugw.unit_gw_code, '') as unit_gw_code, IFNULL(ugw.unit_gw_name_t, '') as unit_gw_name_t " +
                "From " + jbl.table + " jbl " +
                "Left Join b_forwarder fwd On jbl.forwarder_id = fwd.forwarder_id  " +
                "Left Join b_port_of_loading pol On jbl.port_of_loading_id = pol.port_of_loading_id  " +
                "Left Join b_terminal tmn On jbl.terminal_id = tmn.terminal_id  " +
                "Left Join b_port_import pti On jbl.port_import_id = pti.port_import_id  " +
                "Left Join b_unit_gw ugw On jbl.unit_gw_id = ugw.unit_gw_id  " +
                "Where jbl." + jbl.job_import_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setJobImportBl(dt);
            return cop1;
        }
        private JobImportBl setJobImportBl(DataTable dt)
        {
            JobImportBl jbl1 = new JobImportBl();
            if (dt.Rows.Count > 0)
            {
                jbl1.job_import_bl_id = dt.Rows[0][jbl.job_import_bl_id].ToString();
                jbl1.job_import_id = dt.Rows[0][jbl.job_import_id].ToString();
                jbl1.forwarder_id = dt.Rows[0][jbl.forwarder_id].ToString();
                jbl1.mbl_mawb = dt.Rows[0][jbl.mbl_mawb].ToString();
                jbl1.hbl_hawb = dt.Rows[0][jbl.hbl_hawb].ToString();
                jbl1.m_vessel = dt.Rows[0][jbl.m_vessel].ToString();
                jbl1.f_vessel = dt.Rows[0][jbl.f_vessel].ToString();
                jbl1.etd = dt.Rows[0][jbl.etd].ToString();
                jbl1.eta = dt.Rows[0][jbl.eta].ToString();
                jbl1.port_imp_id = dt.Rows[0][jbl.port_imp_id].ToString();
                jbl1.terminal_id = dt.Rows[0][jbl.terminal_id].ToString();
                jbl1.marsk = dt.Rows[0][jbl.marsk].ToString();
                jbl1.description = dt.Rows[0][jbl.description].ToString();
                jbl1.gw = dt.Rows[0][jbl.gw].ToString();
                jbl1.gw_unit_id = dt.Rows[0][jbl.gw_unit_id].ToString();
                jbl1.packages_total = dt.Rows[0][jbl.packages_total].ToString();
                jbl1.unit_package1_id = dt.Rows[0][jbl.unit_package1_id].ToString();
                jbl1.total_con20 = dt.Rows[0][jbl.total_con20].ToString();
                jbl1.total_con40 = dt.Rows[0][jbl.total_con40].ToString();
                jbl1.volume1 = dt.Rows[0][jbl.volume1].ToString();
                jbl1.port_of_loading_id = dt.Rows[0][jbl.port_of_loading_id].ToString();
                jbl1.date_check_exam = dt.Rows[0][jbl.date_check_exam].ToString();
                jbl1.date_delivery = dt.Rows[0][jbl.date_delivery].ToString();
                jbl1.date_tofac = dt.Rows[0][jbl.date_tofac].ToString();
                jbl1.truck_id = dt.Rows[0][jbl.truck_id].ToString();
                jbl1.car_number = dt.Rows[0][jbl.car_number].ToString();
                jbl1.tranfer_with_job_id = dt.Rows[0][jbl.tranfer_with_job_id].ToString();
                jbl1.truck_cop_id = dt.Rows[0][jbl.truck_cop_id].ToString();
                jbl1.date_create = dt.Rows[0][jbl.date_create].ToString();
                jbl1.date_modi = dt.Rows[0][jbl.date_modi].ToString();
                jbl1.date_cancel = dt.Rows[0][jbl.date_cancel].ToString();
                jbl1.user_create = dt.Rows[0][jbl.user_create].ToString();
                jbl1.user_modi = dt.Rows[0][jbl.user_modi].ToString();
                jbl1.user_cancel = dt.Rows[0][jbl.user_cancel].ToString();
                jbl1.active = dt.Rows[0][jbl.active].ToString();
                jbl1.remark = dt.Rows[0][jbl.remark].ToString();
                jbl1.doc_forrow = dt.Rows[0][jbl.doc_forrow].ToString();
                jbl1.status_doc_forrow = dt.Rows[0][jbl.status_doc_forrow].ToString();
                jbl1.date_doc_forrow = dt.Rows[0][jbl.date_doc_forrow].ToString();
                jbl1.status_job_forrow = dt.Rows[0][jbl.status_job_forrow].ToString();
                jbl1.job_forrow_description = dt.Rows[0][jbl.job_forrow_description].ToString();
                jbl1.date_finish_job_forrow = dt.Rows[0][jbl.date_finish_job_forrow].ToString();
                jbl1.status_oth_job = dt.Rows[0][jbl.status_oth_job].ToString();
                jbl1.delivery_remark = dt.Rows[0][jbl.delivery_remark].ToString();
                jbl1.container_yard = dt.Rows[0][jbl.container_yard].ToString();
                //jbl.status_doc_forrow = dt.Rows[0][jbl.remark2].ToString();

                jbl1.fwdCode = dt.Rows[0]["forwarder_code"].ToString();
                jbl1.fwdNameT = dt.Rows[0]["forwarder_name_t"].ToString();
                jbl1.polCode = dt.Rows[0]["port_of_loading_code"].ToString();
                jbl1.polNameT = dt.Rows[0]["port_of_loading_name_t"].ToString();
                jbl1.tmnCode = dt.Rows[0]["terminal_code"].ToString();
                jbl1.tmnNameT = dt.Rows[0]["terminal_name_t"].ToString();

                jbl1.ptiCode = dt.Rows[0]["port_import_code"].ToString();
                jbl1.ptiNameT = dt.Rows[0]["port_import_name_t"].ToString();
                jbl1.ugwCode = dt.Rows[0]["unit_gw_code"].ToString();
                jbl1.ugwNameT = dt.Rows[0]["unit_gw_name_t"].ToString();

                jbl1.packages1 = dt.Rows[0][jbl.packages1].ToString();
                jbl1.packages2 = dt.Rows[0][jbl.packages2].ToString();
                jbl1.packages3 = dt.Rows[0][jbl.packages3].ToString();
                jbl1.packages4 = dt.Rows[0][jbl.packages4].ToString();
                jbl1.packages5 = dt.Rows[0][jbl.packages5].ToString();
                jbl1.container1 = dt.Rows[0][jbl.container1].ToString();
                jbl1.container2 = dt.Rows[0][jbl.container2].ToString();
                jbl1.container3 = dt.Rows[0][jbl.container3].ToString();
                jbl1.container4 = dt.Rows[0][jbl.container4].ToString();
                jbl1.container5 = dt.Rows[0][jbl.container5].ToString();
                jbl1.container6 = dt.Rows[0][jbl.container6].ToString();
                jbl1.gw_total = dt.Rows[0][jbl.gw_total].ToString();
                jbl1.container1_doc_type_id = dt.Rows[0][jbl.container1_doc_type_id].ToString();
                jbl1.container2_doc_type_id = dt.Rows[0][jbl.container2_doc_type_id].ToString();
                jbl1.container3_doc_type_id = dt.Rows[0][jbl.container3_doc_type_id].ToString();
                jbl1.container4_doc_type_id = dt.Rows[0][jbl.container4_doc_type_id].ToString();
                jbl1.container5_doc_type_id = dt.Rows[0][jbl.container5_doc_type_id].ToString();
                jbl1.container6_doc_type_id = dt.Rows[0][jbl.container6_doc_type_id].ToString();
                jbl1.unit_package2_id = dt.Rows[0][jbl.unit_package2_id].ToString();
                jbl1.unit_package3_id = dt.Rows[0][jbl.unit_package3_id].ToString();
                jbl1.unit_package4_id = dt.Rows[0][jbl.unit_package4_id].ToString();
                jbl1.unit_package5_id = dt.Rows[0][jbl.unit_package5_id].ToString();
                jbl1.bl_type = dt.Rows[0][jbl.bl_type].ToString();
                jbl1.consignmnt_id = dt.Rows[0][jbl.consignmnt_id].ToString();
                jbl1.bl = dt.Rows[0][jbl.bl].ToString();
                jbl1.unit_volume1_id = dt.Rows[0][jbl.unit_volume1_id].ToString();

                jbl1.deli_gw = dt.Rows[0][jbl.deli_gw].ToString();
                jbl1.deli_imp_addr = dt.Rows[0][jbl.deli_imp_addr].ToString();
                jbl1.deli_imp_id = dt.Rows[0][jbl.deli_imp_id].ToString();
                jbl1.deli_package = dt.Rows[0][jbl.deli_package].ToString();
                jbl1.deli_place_addr_id = dt.Rows[0][jbl.deli_place_addr_id].ToString();
                jbl1.deli_place_addr_name_t = dt.Rows[0][jbl.deli_place_addr_name_t].ToString();
                jbl1.deli_truck_cop_id = dt.Rows[0][jbl.deli_truck_cop_id].ToString();
                jbl1.deli_unit_gw_id = dt.Rows[0][jbl.deli_unit_gw_id].ToString();
                jbl1.deli_unit_package_id = dt.Rows[0][jbl.deli_unit_package_id].ToString();
                jbl1.deli_unit_volume_id = dt.Rows[0][jbl.deli_unit_volume_id].ToString();
                jbl1.deli_volume = dt.Rows[0][jbl.deli_volume].ToString();
                jbl1.deli_yard_id = dt.Rows[0][jbl.deli_yard_id].ToString();
                jbl1.deli_truck_id = dt.Rows[0][jbl.deli_truck_id].ToString();
                jbl1.deli_yard_addr_name_t = dt.Rows[0][jbl.deli_yard_addr_name_t].ToString();
            }

            return jbl1;
        }
    }
}
