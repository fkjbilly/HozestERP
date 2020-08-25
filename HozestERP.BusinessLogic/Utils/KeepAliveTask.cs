using System;
using System.Net;
using System.Xml;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Tasks;

namespace HozestERP.BusinessLogic.Utils
{
    /// <summary>
    /// Represents a task for pinger
    /// </summary>
    public partial class KeepAliveTask : ITask
    {
        private string _path = string.Empty;

        /// <summary>
        /// Executes a task
        /// </summary>
        /// <param name="node">Xml node that represents a task description</param>
        public void Execute(XmlNode node)
        {
            var attribute1 = node.Attributes["path"];
            if (attribute1 != null && !String.IsNullOrEmpty(attribute1.Value))
            {
                this._path = attribute1.Value;
            }
            string url = IoC.Resolve<ISettingManager>().StoreUrl;
            url += _path;

            using (var wc = new WebClient())
            {
                string response = wc.DownloadString(url);
            }
        }
    }
}
