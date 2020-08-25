using System;
using System.Xml;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Tasks;

namespace HozestERP.BusinessLogic.Audit.UsersOnline
{
    /// <summary>
    /// Purge onlie users schedueled task implementation
    /// </summary>
    public partial class PurgeOnlineUsersTask : ITask
    {
        /// <summary>
        /// Executes the clear cache task
        /// </summary>
        /// <param name="node">XML node that represents a task description</param>
        public void Execute(XmlNode node)
        {
            try
            {
                IoC.Resolve<IOnlineUserService>().PurgeUsers();
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogService>().InsertLog(LogTypeEnum.CustomerError, "Error purging online users.", ex);
            }
        }
    }
}
