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
            sql = "select job.jobno, job.cusrefno, job.jobdate, job.imdate, job.bl, job.importer, job.vslname, job.housebl, imp.tname, job4.im_ename " +
                "from job_"+ year + " as job "+
                "left join importer imp on imp.code = job.importer "+
                "left join job_4_"+ year + " job4 on job4.jobno = job.jobno " +
                "Where job.cusrefno is null or job.cusrefno = '' " +
                "Order By job.jobno desc ";
            dt = conn.selectData(conn.connIm, sql);
            return dt;
        }
    }
}
