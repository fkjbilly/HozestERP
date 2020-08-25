using HozestERP.WebApi.Manager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HozestERP.WebApi.SQl
{
    public partial class SqlDataHelper
    {
        #region Methods

        public const int iTimeOut = 180; //180 秒
        internal static string GetConnectionString(string connectionStringName)
        {
            string connectionString = null;

            ConnectionStringSettings settings = WebConfigurationManager.ConnectionStrings[connectionStringName];
            if (settings != null)
            {
                connectionString = settings.ConnectionString;
            }

            return connectionString;
        }

        public static string GetConnectionString()
        {
            return SqlDataHelper.GetConnectionString("HozestERPConnectionString");
        }

        /// <summary>
        /// 根据sql语句得到 DataTable
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDatatableBySql(string strSql)
        {
            DataTable dt = new DataTable();
            string strConn = SqlDataHelper.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                SqlCommand command = new SqlCommand(strSql, connection);
                command.CommandTimeout = iTimeOut;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// 根据sql语句执行增删改操作,返回受影响的行数
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public static int ExcuteBySql(string strSql)
        {
            int i = 0;
            string strConn = SqlDataHelper.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();//开启事务
                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandTimeout = iTimeOut;
                command.Transaction = transaction;
                try
                {
                    command.CommandText = strSql;
                    i = command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    InsertLog.Insert(ex.Message, ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return i;
        }

        //public static void Execute()
        //{
        //    string connectionString = SqlDataHelper.GetConnectionString();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlTransaction transaction;
        //        using (SqlCommand cmd = connection.CreateCommand())
        //        {
        //            //启动事务
        //            transaction = connection.BeginTransaction();
        //            cmd.Connection = connection;
        //            cmd.Transaction = transaction;
        //            try
        //            {
        //                cmd.CommandText = "sql语句！";
        //                cmd.ExecuteNonQuery();

        //                //完成提交
        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                //数据回滚
        //                transaction.Rollback();
        //                throw ex;
        //            }
        //        }
        //    }

        //}
        /// <summary>
        /// 执行增删改，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            int i = 0;
            string strConn = SqlDataHelper.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandTimeout = iTimeOut;
                i = command.ExecuteNonQuery();
                connection.Close();
            }

            return i;
        }
        /// <summary>
        /// Gets connection string to master database
        /// </summary>
        /// <param name="connetionString">A connection string</param>
        /// <returns></returns>
        public static string GetMasterConnectionString(string connetionString)
        {
            var builder = new SqlConnectionStringBuilder(connetionString);
            builder.InitialCatalog = "master";
            return builder.ToString();
        }

        /// <summary>
        /// Gets database name from connection string
        /// </summary>
        /// <param name="connetionString">A connection string</param>
        /// <returns></returns>
        public static string GetDatabaseName(string connetionString)
        {
            var builder = new SqlConnectionStringBuilder(connetionString);
            return builder.InitialCatalog;
        }

        #endregion
    }
}