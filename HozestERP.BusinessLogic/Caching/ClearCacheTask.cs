using System;
using System.Xml;
using HozestERP.BusinessLogic.Audit;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Tasks;

namespace HozestERP.BusinessLogic.Caching
{
    /// <summary>
    /// Clear cache schedueled task implementation
    /// </summary>
    public partial class ClearCacheTask : ITask
    {
        /// <summary>
        /// Executes the clear cache task
        /// </summary>
        /// <param name="node">XML node that represents a task description</param>
        public void Execute(XmlNode node)
        {
            try
            {
                new HozestERPStaticCache().Clear();
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogService>().InsertLog(LogTypeEnum.AdministrationArea, "Error clearing cache.", ex);
            }
        }
    }
}
