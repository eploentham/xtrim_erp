using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtrim_ERP.objdb
{
    public class MeiosysDB
    {
        ConnectDB conn;
        String year = "";
        public MeiosysDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {

        }
        public DataTable selectJobNoImport()
        {
            year = DateTime.Now.Year.ToString();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "select job.jobno, job.cusrefno, job.jobdate, job.imdate, job.bl, job.importer, job.vslname, job.housebl" +
                ", imp.tname, job4.im_ename, job.vslnamerem, couo.name as origin, couc.name as consignmnt, job.loaded, plc.name as loaded_name "+
                ", job.released, plcr.name as name_repleased, job.out_released, plco.name as name_out_repleased, job.approval, plca.name as name_approval " +
                "from job_"+ year + " as job "+
                "left join importer imp on imp.code = job.importer "+
                "left join job_4_"+ year + " job4 on job4.jobno = job.jobno " +
                "left join country couo on couo.code = job.origin " +
                "left join country couc on couc.code = job.consignmnt " +
                "left join place plc on plc.code = job.loaded " +
                "left join place plcr on plcr.code = job.released " +
                "left join place plco on plco.code = job.out_released " +
                "left join place plca on plca.code = job.approval " +
                "Where job.cusrefno is null or job.cusrefno = '' " +
                "Order By job.jobno desc ";
            dt = conn.selectData(conn.connIm, sql);
            return dt;
        }
        public DataTable selectJobNoImport(String jobNo)
        {
            year = DateTime.Now.Year.ToString();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "select job.jobno, job.cusrefno, job.jobdate, job.imdate, job.bl, job.importer, job.vslname, job.housebl" +
                ", imp.tname, job4.im_ename, job.vslnamerem, couo.name as origin, couc.name as consignmnt, job.loaded, plc.name as loaded_name " +
                ", job.released, plcr.name as name_repleased, job.out_released, plco.name as name_out_repleased, job.approval, plca.name as name_approval " +
                "from job_" + year + " as job " +
                "left join importer imp on imp.code = job.importer " +
                "left join job_4_" + year + " job4 on job4.jobno = job.jobno " +
                "left join country couo on couo.code = job.origin " +
                "left join country couc on couc.code = job.consignmnt " +
                "left join place plc on plc.code = job.loaded " +
                "left join place plcr on plcr.code = job.released " +
                "left join place plco on plco.code = job.out_released " +
                "left join place plca on plca.code = job.approval " +
                "Where job.jobno = '"+ jobNo + "' " +
                "Order By job.jobno desc ";
            dt = conn.selectData(conn.connIm, sql);
            return dt;
        }
        public DataTable selectJobInvNoImport(String jobNo)
        {
            year = DateTime.Now.Year.ToString();
            DataTable dt = new DataTable();
            String sql = "";
            sql = "select hinv.invno, hinv.invdate, hinv.invitemno, hinv.pono, hinv.consignee, cons.tname " +
                ", hinv.termpaycod, hinv.termpaydet, hinv.totalinv, hinv.currency, hinv.exratethb, hinv.totalinvthb " +
                "from hinv_"+ year + " hinv " +
                "left join consignee cons on hinv.consignee = cons.code " +
                "Where hinv.jobno = '" + jobNo + "' ";
            dt = conn.selectData(conn.connIm, sql);
            return dt;
        }
    }
}
