using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.CustomerManagement;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api.Domain;


namespace HozestERP.Web.WebServer
{
    /// <summary>
    /// BrowserWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BrowserWebService : System.Web.Services.WebService
    {
        
        [WebMethod(Description = "判断是否是AE管理员")]
        public bool IsManger(string paramEmpID)
        {
            try
            {
                int customerID = 0;
                int.TryParse(paramEmpID, out customerID);
                var customerRoles = IoC.Resolve<ICustomerService>().GetCustomerRolesByCustomerId(customerID);
                List<string> roleNames = new List<string>();
                roleNames.Add("AE主管");
                roleNames.Add("AE助理");
                roleNames.Add("Administrator");
                roleNames.Add("总经理");
                if (customerRoles.Where(p=>roleNames.Contains(p.Name)).Count() > 0 )
                {
                    return true;
                }
            }
            catch (Exception myEx)
            {
                throw myEx;
            }
            return false;
        }

        [WebMethod(Description = "登录判断")]
        public WebServiceUserInfo CheckLogin(string paramLoginName, string paramPassWord)
        {
            try
            {
                return IoC.Resolve<ICustomerService>().WebServiceLogin(paramLoginName, paramPassWord);
            }
            catch (Exception myEx)
            {
                throw myEx;
            }
        }
    } 
}
