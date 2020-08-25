using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Configuration;

namespace HozestERP.WebApi.App_Start
{
    //调用次数限制
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ThrottleAttribute : ActionFilterAttribute
    {
       private readonly HandleRequest _handleRequest;
        public ThrottleAttribute()
        {
            this._handleRequest = new HandleRequest();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //var list = new List<string> { "GetProductInfo", "GetInventoryInfo" };
            //var isRequestProduct = list.Contains(actionContext.Request.RequestUri.Segments[3]);//如果是获取商品信息则不受1分钟调用一次的限制

            //var valid = this._handleRequest.IsValidRequest(actionContext.Request, isRequestProduct);
            //if (!valid)
            //    actionContext.Response = new HttpResponseMessage((HttpStatusCode)429) { ReasonPhrase = "Too Many Requests!" };

            //var loginMessage = this._handleRequest.IsLogin(actionContext);
            //if (!loginMessage.Header.IsSuccess)
            //    actionContext.Response = new HttpResponseMessage((HttpStatusCode)417) { ReasonPhrase = loginMessage.Header.Message };

        }

    }
}