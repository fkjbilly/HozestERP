using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageCustomerService;
using Newtonsoft.Json;

namespace HozestERP.Web.ManageCustomerService
{
    /// <summary>
    /// CbWorkerInfo 的摘要说明
    /// </summary>
    public class CbWorkerInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            var start = 0;
            var limit = 10;
            var sort = string.Empty;
            var dir = string.Empty;
            var query = string.Empty;

            if (!string.IsNullOrEmpty(context.Request["start"]))
            {
                start = int.Parse(context.Request["start"]);
            }

            if (!string.IsNullOrEmpty(context.Request["limit"]))
            {
                limit = int.Parse(context.Request["limit"]);
            }

            if (!string.IsNullOrEmpty(context.Request["sort"]))
            {
                sort = context.Request["sort"];
            }

            if (!string.IsNullOrEmpty(context.Request["dir"]))
            {
                dir = context.Request["dir"];
            }

            if (!string.IsNullOrEmpty(context.Request["query"]))
            {
                query = context.Request["query"];
            }

            IQueryable<BusinessLogic.ManageCustomerService.XMWorkerInfo> queryable = null;

            if(query=="*")
            {
                queryable = IoC.Resolve<IXMWorkerInfoService>().getList(a => a.IsEnable == false);
            }
            else
            {
                queryable = IoC.Resolve<IXMWorkerInfoService>().getList(a =>a.IsEnable==false&&(a.FullName.Contains(query)||a.Tel.Contains(query)||a.Province.Contains(query)||a.City.Contains(query)||a.Regin.Contains(query)));
            }



            Paging<BusinessLogic.ManageCustomerService.XMWorkerInfo> pag = new Paging<BusinessLogic.ManageCustomerService.XMWorkerInfo>(queryable.OrderBy(a => a.ID), queryable.Count());

            context.Response.Write(string.Format("{{total:{1},'plants':{0}}}", JsonConvert.SerializeObject(pag.Data), pag.TotalRecords));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}