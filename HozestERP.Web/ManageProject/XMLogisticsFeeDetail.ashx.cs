using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using Ext.Net;
using Newtonsoft.Json;

namespace HozestERP.Web.ManageProject
{
    /// <summary>
    /// XMLogisticsFeeDetail1 的摘要说明
    /// </summary>
    public class XMLogisticsFeeDetail1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            var start = 0;
            var limit = 10;
            var sort = string.Empty;
            var dir = string.Empty;
            var query = string.Empty;
            var OrderID = 0;

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

            if (!string.IsNullOrEmpty(context.Request["ID"]))
            {
                OrderID =int.Parse(context.Request["ID"]);
            }

            IXMLogisticsFeeDetailService XMLogisticsFeeDetailService = IoC.Resolve<IXMLogisticsFeeDetailService>();

            var data = XMLogisticsFeeDetailService.GetXMLogisticsFeeDetailList(OrderID);

            Paging<BusinessLogic.ManageProject.XMLogisticsFeeDetail> pag= new Paging<BusinessLogic.ManageProject.XMLogisticsFeeDetail>(data.OrderBy(a => a.Type).Skip(start).Take(limit), data.Count());

            context.Response.Write(string.Format("{{total:{1},'data':{0}}}", JsonConvert.SerializeObject(pag.Data), pag.TotalRecords));
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