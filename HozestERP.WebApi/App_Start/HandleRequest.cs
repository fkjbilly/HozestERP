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
using System.Web.Caching;
using System.Runtime.Remoting.Messaging;
using HozestERP.WebApi.Message;
using System.Text;

namespace HozestERP.WebApi.App_Start
{
    public class HandleRequest
    {
        private const string RemoteEndpointMessage =
       "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string OwinContext = "MS_OwinContext";
        /// <summary>
        /// 客户端ip名称前缀
        /// </summary>
        private string Name { 
            get{
                return "Client";
            }
        } 
        /// <summary>
        /// 限制客户端的调用时间
        /// </summary>
        private int Second { 
            get{
                return int.Parse(ConfigurationManager.AppSettings.Get("waitsecond"));
            }
        }

        /// <summary>
        /// 限制客户端的调用产品信息时间
        /// </summary>
        private int MillSecond
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings.Get("waitMillisecond"));
            }
        }

        private string GetClientIp(HttpRequestMessage request)
        {
            //获取传统context
 
            if (request.Properties.ContainsKey("MS_HttpContext"))
            { 
                //HttpContextWrapper 类是从 HttpContextBase 类派生的。 HttpContextWrapper 类用作 HttpContext 类的包装。 在运行时，通常使用 HttpContextWrapper 类的实例调用 HttpContext 对象上的成员。
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
 
            //CS客户端获取ip地址
            //让与发送消息的远程终结点有关的客户端 IP 地址和端口号可用。
            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }

            // Self-hosting using Owin. Needs reference to Microsoft.Owin.dll. 
            if (request.Properties.ContainsKey(OwinContext))
            {
                dynamic owinContext = request.Properties[OwinContext];
                if (owinContext != null)
                {
                    return owinContext.Request.RemoteIpAddress;
                }
            }
 
            return null;
        }
        /// <summary>
        /// 调用线程池闲置线程处理本次客户端调用的频次问题
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="isRequestProduct">是否是调用产品信息接口</param>
        /// <returns></returns>
        public bool IsValidRequest(HttpRequestMessage requestMessage,bool isRequestProduct)
        {
            bool result = false;
            AutoResetEvent resetEvent = new AutoResetEvent(false);
            ThreadPool.QueueUserWorkItem(new WaitCallback(state =>
            {
                result = DoSomething(requestMessage, isRequestProduct);
                resetEvent.Set();
            }));

            resetEvent.WaitOne();
            return result;
        }



        public bool DoSomething(HttpRequestMessage requestMessage, bool isRequestProduct)
        {
            var allowExecute = false;
            var ClientIp = GetClientIp(requestMessage);
            var key = string.Concat(Name, "-", ClientIp);
            if (GetCacheValue(key) == null)
            {
                if(isRequestProduct)//如果是调用产品信息，则1秒限制为2次
                    SetCacheValue(key,ClientIp,DateTime.Now.AddMilliseconds(MillSecond)); //没有回调
                else
                    SetCacheValue(key, ClientIp, DateTime.Now.AddSeconds(Second)); //没有回调
                allowExecute = true;
            }
            return allowExecute;
        }

        /// <summary>
        /// 获取缓存的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存名称</param>
        /// <param name="obj">存储的对象</param>
        /// <param name="dateTime">过期时间</param>
        /// <returns></returns>
        public static void SetCacheValue(string key, string obj, DateTime dateTime)
        {
            HttpRuntime.Cache.Insert(key,
                        obj,
                        null, // 没有依赖关系
                        dateTime, // 绝对过期
                        Cache.NoSlidingExpiration,
                        CacheItemPriority.Low,
                        null);
        }
        /// <summary>
        /// 获取缓存的值
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="key">缓存名称</param>
        /// <returns></returns>
        public static object GetCacheValue(string key)
        {
            var cacheValue = HttpRuntime.Cache[key];
            return cacheValue;
        }
        /// <summary>
        /// 判断请求接口的请求头中身份信息是否正确
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        public ApiMassage IsLogin(HttpActionContext actionContext)
        {
            var request = actionContext.Request;//来自客户端的http请求

            var returnMessage = new ApiMassage();
            returnMessage.Header = new Message.Header();

            StringBuilder sb = new StringBuilder();

            var requestUserName = string.Empty;
            var requestPassWord = string.Empty;
            var requestAccessToken = string.Empty;
            
            var configUserName = ConfigurationManager.AppSettings["userName"];//账号
            var configPassWord = ConfigurationManager.AppSettings["passWord"];//密码
            var configAccessToken = ConfigurationManager.AppSettings["accessToken"];//秘钥

            if (request.Headers.Contains("userName"))
            {
                requestUserName = HttpUtility.UrlDecode(request.Headers.GetValues("userName").FirstOrDefault());
            }
            if (request.Headers.Contains("passWord"))
            {
                requestPassWord = HttpUtility.UrlDecode(request.Headers.GetValues("passWord").FirstOrDefault());
            }
            if (request.Headers.Contains("accessToken"))
            {
                requestAccessToken = HttpUtility.UrlDecode(request.Headers.GetValues("accessToken").FirstOrDefault());
            }

            if (string.IsNullOrWhiteSpace(requestUserName))
            {
                sb.Append("用户名为空!");
            }
            else 
            {
               if(!configUserName.Equals(requestUserName))
                   sb.Append("用户名不正确!");
            }

            if (string.IsNullOrWhiteSpace(requestPassWord))
            {
                sb.Append("密码为空!");
            }
            else
            {
                if (!configPassWord.Equals(requestPassWord))
                    sb.Append("密码不正确!");
            }

            if (string.IsNullOrWhiteSpace(requestAccessToken))
            {
                sb.Append("Token为空!");
            }
            else
            {
                if (!configAccessToken.Equals(requestAccessToken))
                    sb.Append("Token不正确!");
            }

            if (sb.Length == 0)
                returnMessage.Header.IsSuccess = true;
            else
            {
                returnMessage.Header.IsSuccess = false;
                returnMessage.Header.Message = sb.ToString();
            }

            return returnMessage;
        }
    }
}