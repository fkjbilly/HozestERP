using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Collections;
using System.Collections.Generic;


namespace HozestERP.BusinessLogic.Installation
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
            return SqlDataHelper.GetConnectionString("CRMSqlConnection");
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
                SqlCommand command = new SqlCommand(strSql, connection);
                command.CommandTimeout = iTimeOut;
                i = command.ExecuteNonQuery();
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
