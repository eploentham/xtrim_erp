using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xtrim_ERP.object1;

namespace Xtrim_ERP.objdb
{
    public class ConnectDB
    {
        public MySqlConnection connIm, connEx, conn;
        MySqlCommand comNoClose = new MySqlCommand();



        public int _rowsAffected = 0;
        private InitConfig initC;

        public ConnectDB(InitConfig initc)
        {
            conn = new MySqlConnection();
            connIm = new MySqlConnection();
            connEx = new MySqlConnection();
            conn.ConnectionString = "Server=" + initc.hostDB + ";Database=" + initc.nameDB + ";Uid=" + initc.userDB + ";Pwd=" + initc.passDB + ";port = "+ initc.portDB+"; Connection Timeout = 300;default command timeout=0;";
            connIm.ConnectionString = "Server=" + initc.hostDBIm + ";Database=" + initc.nameDBIm + ";Uid=" + initc.userDBIm + ";Pwd=" + initc.passDBIm + ";port = " + initc.portDBIm + "; Connection Timeout = 300;default command timeout=0;";
            connEx.ConnectionString = "Server=" + initc.hostDBEx + ";Database=" + initc.nameDBEx + ";Uid=" + initc.userDBEx + ";Pwd=" + initc.passDBEx + ";port = " + initc.portDBEx + "; Connection Timeout = 300;default command timeout=0;";
        }
        public DataTable selectData(MySqlConnection con, String sql)
        {
            DataTable toReturn = new DataTable();

            MySqlCommand comMainhis = new MySqlCommand();
            comMainhis.CommandText = sql;
            comMainhis.CommandType = CommandType.Text;
            comMainhis.Connection = con;
            MySqlDataAdapter adapMainhis = new MySqlDataAdapter(comMainhis);
            try
            {
                con.Open();
                adapMainhis.Fill(toReturn);
                //return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                con.Close();
                comMainhis.Dispose();
                adapMainhis.Dispose();
            }
            return toReturn;
        }
        public DataTable selectDataNoClose(MySqlConnection con, String sql)
        {
            DataTable toReturn = new DataTable();
            
            comNoClose.CommandText = sql;
            comNoClose.CommandType = CommandType.Text;
            comNoClose.Connection = con;
            MySqlDataAdapter adapMainhis = new MySqlDataAdapter(comNoClose);
            try
            {
                //con.Open();
                adapMainhis.Fill(toReturn);
                //return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                //con.Close();
                //comMainhis.Dispose();
                adapMainhis.Dispose();
            }
            return toReturn;
        }
        public String ExecuteNonQuery(MySqlConnection con, String sql)
        {
            String toReturn = "";

            MySqlCommand com = new MySqlCommand();
            com.CommandText = sql;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            try
            {
                con.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                _rowsAffected = (int)com.ExecuteScalar();
                toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                con.Close();
                com.Dispose();
            }

            return toReturn;
        }
        public String ExecuteNonQueryNoClose(MySqlConnection con, String sql)
        {
            String toReturn = "";
            comNoClose.CommandText = sql + "; SELECT SCOPE_IDENTITY();";
            comNoClose.CommandType = CommandType.Text;
            comNoClose.Connection = con;
            try
            {
                //connMainHIS.Open();
                //_rowsAffected = comMainhisNoClose.ExecuteNonQuery();
                var aaa = comNoClose.ExecuteScalar();
                toReturn = aaa.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }
            return toReturn;
        }
        public String OpenConnection()
        {
            String toReturn = "";
            try
            {
                conn.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                //toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }

            return toReturn;
        }
        public void CloseConnection()
        {
            conn.Close();
        }
        public String OpenConnectionEx()
        {
            String toReturn = "";
            try
            {
                connEx.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                //toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }

            return toReturn;
        }
        public void CloseConnectionEx()
        {
            connEx.Close();
        }
        public String OpenConnectionIm()
        {
            String toReturn = "";
            try
            {
                connIm.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                //toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }

            return toReturn;
        }
        public void CloseConnectionIm()
        {
            connIm.Close();
        }
    }
}
