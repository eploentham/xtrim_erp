using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ImagesDB
    {
        public Images img;
        ConnectDB conn;
        public List<Images> lexpn;
        public ImagesDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            img = new Images();
            img.image_id = "image_id";
            img.table_id = "table_id";
            img.image_name = "image_name";
            img.image_path = "image_path";
            
            img.active = "active";
            img.remark = "remark";
            img.date_create = "date_create";
            img.date_modi = "date_modi";
            img.date_cancel = "date_cancel";
            img.user_create = "user_create";
            img.user_modi = "user_modi";
            img.user_cancel = "user_cancel";
            img.job_id = "job_id";

            img.table = "t_images";
            img.pkField = "image_id";

            lexpn = new List<Images>();
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Images utp1 in lexpn)
            {
                if (name.Trim().Equals(utp1.table_id))
                {
                    id = utp1.image_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Images p)
        {
            int chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.image_name = p.image_name == null ? "" : p.image_name;
            p.image_path = p.image_path == null ? "" : p.image_path;
            p.remark = p.remark == null ? "" : p.remark;
                        
            p.table_id = int.TryParse(p.table_id, out chk) ? chk.ToString() : "0";
            p.job_id = int.TryParse(p.job_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(Images p, String userId)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            chkNull(p);
            sql = "Insert Into " + img.table + "(" + img.image_name + "," + img.table_id + "," + img.job_id + "," +
                img.active + "," + img.remark + ", " + img.image_path + "," +
                img.date_create + ", " + img.date_modi + ", " + img.date_cancel + "," +
                img.user_create + ", " + img.user_modi + ", " + img.user_cancel + " " + 
                ") " +
                "Values ('" + p.image_name + "','" + p.table_id + "','" + p.job_id + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.image_path + "', " +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "' " +
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
        public String update(Images p, String userId)
        {
            String re = "", sql = "";
            chkNull(p);
            sql = "Update " + img.table + " Set " +
                " " + img.image_name + "='" + p.image_name + "' " +                
                "," + img.table_id + "='" + p.table_id.Replace("'", "''") + "' " +
                "," + img.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + img.date_modi + "=now() " +
                "," + img.user_modi + "='" + userId.Replace("'", "''") + "' " +
                "," + img.image_path + "='" + p.image_path.Replace("'", "''") + "' " +                
                "Where " + img.pkField + "='" + p.image_id + "'";

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
        public String insertImages(Images p, String userId)
        {
            String re = "";

            if (p.image_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }
            return re;
        }
        public String voidImage(String id)
        {
            String re = "", sql = "";
            sql = "Update " + img.table + " Set " +
                " " + img.active + "='3' " +
                "," + img.date_cancel + "=now() " +
                "Where " + img.pkField + "='" + id + "'";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        //public String updateBillingCover(String id, String coverid)
        //{
        //    String re = "", sql = "";
        //    sql = "Update " + img.table + " Set " +
        //        " " + img.billing_cover_id + "='" + coverid + "' " +
        //        "Where " + img.image_id + "='" + id + "'";
        //    re = conn.ExecuteNonQuery(conn.conn, sql);

        //    return re;
        //}
        //public DataTable selectByCusId(String copId)
        //{
        //    DataTable dt = new DataTable();
        //    String sql = "select bll.* " +
        //        "From " + img.table + " bll " +
        //        //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
        //        "Where bll." + img.cust_id + " ='" + copId + "' and " + img.active + "='1' ";
        //    dt = conn.selectData(conn.conn, sql);
        //    return dt;
        //}
        public DataTable selectByJobId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + img.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + img.image_path + " ='" + copId + "' and " + img.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByTableId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + img.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + img.table_id + " ='" + copId + "' and " + img.active + "='1' " +
                "Order By "+img.image_id;
            dt = conn.selectData(conn.conn, sql);            
            return dt;
        }
        public Images selectByTableId1(String copId)
        {
            Images cop1 = new Images();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + img.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + img.table_id + " ='" + copId + "' and " + img.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setImage(dt);
            return cop1;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + img.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + img.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Images selectByPk1(String copId)
        {
            Images cop1 = new Images();
            DataTable dt = new DataTable();
            String sql = "select bll.* " +
                "From " + img.table + " bll " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where bll." + img.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setImage(dt);
            return cop1;
        }
        public Images setImage(DataTable dt)
        {
            Images img1 = new Images();
            if (dt.Rows.Count > 0)
            {
                img1.image_id = dt.Rows[0][img.image_id].ToString();
                img1.table_id = dt.Rows[0][img.table_id].ToString();
                img1.image_name = dt.Rows[0][img.image_name].ToString();
                img1.image_path = dt.Rows[0][img.image_path].ToString();
                img1.active = dt.Rows[0][img.active].ToString();
                img1.date_cancel = dt.Rows[0][img.date_cancel].ToString();
                img1.date_create = dt.Rows[0][img.date_create].ToString();
                img1.date_modi = dt.Rows[0][img.date_modi].ToString();
                img1.user_cancel = dt.Rows[0][img.user_cancel].ToString();
                img1.user_create = dt.Rows[0][img.user_create].ToString();
                img1.user_modi = dt.Rows[0][img.user_modi].ToString();
                
                img1.remark = dt.Rows[0][img.remark].ToString();
                img1.job_id = dt.Rows[0][img.job_id].ToString();

            }
            else
            {
                img1.image_id = "";
                img1.table_id = "";
                img1.image_name = "";
                img1.image_path = "";
                
                img1.active = "";
                img1.remark = "";
                img1.date_create = "";
                img1.date_modi = "";
                img1.date_cancel = "";
                img1.user_create = "";
                img1.user_modi = "";
                img1.user_cancel = "";
                img1.job_id = "";
            }

            return img1;
        }
    }
}
