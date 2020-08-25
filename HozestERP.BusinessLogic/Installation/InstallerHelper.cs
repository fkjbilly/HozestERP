using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Configuration;

using HozestERP.BusinessLogic.Configuration;
using HozestERP.Common.Utils;

namespace HozestERP.BusinessLogic.Installation
{
    public partial class InstallerHelper
    {
        /// <summary>
        /// Checks if the connection string is set
        /// </summary>
        /// <returns></returns>
        public static bool ConnectionStringIsSet()
        {
            return !String.IsNullOrEmpty(HozestERPConfig.ConnectionString);
        }

        /// <summary>
        /// Backup database
        /// </summary>
        /// <param name="fileName">Destination file name</param>
        public static void Backup(string fileName)
        {
            //TODO SQL Server only now
            string sqlConnectionString = SqlDataHelper.GetConnectionString("CRMSqlConnection");
            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                string dbName = SqlDataHelper.GetDatabaseName(sqlConnectionString);
                string commandText = string.Format(
                    "BACKUP DATABASE [{0}] TO DISK = '{1}' WITH FORMAT",
                    dbName,
                    fileName);

                DbCommand dbCommand = new SqlCommand(commandText, conn);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dbCommand.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Restore database
        /// </summary>
        /// <param name="fileName">Target file name</param>
        public static void RestoreBackup(string fileName)
        {
            //TODO SQL Server only now

            string sqlConnectionString = SqlDataHelper.GetConnectionString("CRMSqlConnection");
            string masterConnectionString = SqlDataHelper.GetMasterConnectionString(sqlConnectionString);
            using (SqlConnection conn = new SqlConnection(masterConnectionString))
            {
                string dbName = SqlDataHelper.GetDatabaseName(sqlConnectionString);
                string commandText = string.Format(
                    "DECLARE @ErrorMessage NVARCHAR(4000)\n" +
                    "ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE\n" +
                    "BEGIN TRY\n" +
                        "RESTORE DATABASE [{0}] FROM DISK = '{1}' WITH REPLACE\n" +
                    "END TRY\n" +
                    "BEGIN CATCH\n" +
                        "SET @ErrorMessage = ERROR_MESSAGE()\n" +
                    "END CATCH\n" +
                    "ALTER DATABASE [{0}] SET MULTI_USER WITH ROLLBACK IMMEDIATE\n" +
                    "IF (@ErrorMessage is not NULL)\n" +
                    "BEGIN\n" +
                        "RAISERROR (@ErrorMessage, 16, 1)\n" +
                    "END",
                    dbName,
                    fileName);

                DbCommand dbCommand = new SqlCommand(commandText, conn);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dbCommand.ExecuteNonQuery();
            }

            //clear all pools
            SqlConnection.ClearAllPools();
        }
    }
}
