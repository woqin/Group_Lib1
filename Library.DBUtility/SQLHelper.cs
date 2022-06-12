using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DBUtility
{
    public class SQLHelper
    {
        //封装数据库连接字符串
        private static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();

        #region 封装格式化SQL语句执行的各种方法
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd=new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorInfo = "调用public static int Update(string sql)方法时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                conn.Close();
            }
        }
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd=new SqlCommand(sql,conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                //将异常信息写入日志
                string errorInfo = "调用public static SqlDataReader GetReader(string sql)方法时发生错误：" + ex.Message;
                WriteLog(errorInfo);
                throw new Exception(errorInfo);
            }
        }
        #endregion

        #region 其他方法
        private static void WriteLog(string log)
        {
            FileStream fs = new FileStream("sqlhelper.log", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + " " + log);
            sw.Close();
            fs.Close();
        }
        #endregion
    }
}
