

using System;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Audit
{
    /// <summary>
    /// Log service interface
    /// </summary>
    public partial interface ILogService
    {
        /// <summary>
        /// Deletes a log item
        /// </summary>
        /// <param name="logId">Log item identifier</param>
        void DeleteLog(int logId);

        /// <summary>
        /// Clears a log
        /// </summary>
        void ClearLog();

        /// <summary>
        /// Gets all log items
        /// </summary>
        /// <param name="createdOnFrom">Log item creation from; null to load all customers</param>
        /// <param name="createdOnTo">Log item creation to; null to load all customers</param>
        /// <param name="message">Message</param>
        /// <param name="logTypeId">Log type identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Log item collection</returns>
        PagedList<Log> GetAllLogs(DateTime? createdOnFrom,
           DateTime? createdOnTo, string message, int logTypeId, int pageIndex, int pageSize);

        /// <summary>
        /// Gets a log item
        /// </summary>
        /// <param name="logId">Log item identifier</param>
        /// <returns>Log item</returns>
        Log GetLogById(int logId);

        /// <summary>
        /// Inserts a log item
        /// </summary>
        /// <param name="logType">Log item type</param>
        /// <param name="message">The short message</param>
        /// <param name="exception">The exception</param>
        /// <returns>A log item</returns>
        Log InsertLog(LogTypeEnum logType, string message, string exception);

        /// <summary>
        /// Inserts a log item
        /// </summary>
        /// <param name="logType">Log item type</param>
        /// <param name="message">The short message</param>
        /// <param name="exception">The exception</param>
        /// <returns>A log item</returns>
        Log InsertLog(LogTypeEnum logType, string message, Exception exception);

        /// <summary>
        /// Inserts a log item
        /// </summary>
        /// <param name="logType">Log item type</param>
        /// <param name="severity">The severity</param>
        /// <param name="message">The short message</param>
        /// <param name="exception">The full exception</param>
        /// <param name="IPAddress">The IP address</param>
        /// <param name="customerId">The customer identifier</param>
        /// <param name="pageUrl">The page URL</param>
        /// <returns>Log item</returns>
        Log InsertLog(LogTypeEnum logType, int severity, string message,
            Exception exception, string IPAddress,
            int customerId, string pageUrl);
    }
}
