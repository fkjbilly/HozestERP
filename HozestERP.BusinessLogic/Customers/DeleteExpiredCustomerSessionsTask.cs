using System;
using System.Xml;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Tasks;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    /// <summary>
    /// Represents a task for deleting expired customer sessions
    /// </summary>
    public partial class DeleteExpiredCustomerSessionsTask : ITask
    {
        private int _deleteExpiredCustomerSessionsOlderThanMinutes = 43200; //30 days

        /// <summary>
        /// Executes a task
        /// </summary>
        /// <param name="node">Xml node that represents a task description</param>
        public void Execute(XmlNode node)
        {
            XmlAttribute attribute1 = node.Attributes["deleteExpiredCustomerSessionsOlderThanMinutes"];
            if (attribute1 != null && !String.IsNullOrEmpty(attribute1.Value))
            {
                this._deleteExpiredCustomerSessionsOlderThanMinutes = int.Parse(attribute1.Value);
            }

            DateTime olderThan = DateTime.UtcNow;
            olderThan = olderThan.AddMinutes(-(double)this._deleteExpiredCustomerSessionsOlderThanMinutes);
            IoC.Resolve<ICustomerService>().DeleteExpiredCustomerSessions(olderThan);
        }
    }
}
