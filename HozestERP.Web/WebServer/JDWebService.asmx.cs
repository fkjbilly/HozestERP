using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using JdSdk.Domain;
using Top.Api.Domain;

namespace HozestERP.Web.WebServer
{
    /// <summary>
    /// JDWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class JDWebService : System.Web.Services.WebService
    {

        [WebMethod(Description="京东同步数据保存到数据库")]
        public void WebPageJDOrderData(List<OrderInfo> orderlst, XMOrderInfoApp xMorderInfoApp)
        {
            //IoC.Resolve<IXMOrderInfoAPIService>().PageJDOrderData(orderlst, xMorderInfoApp);
        }
    }
}
