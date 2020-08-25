using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Infrastructure;
using Ext.Net;
using Newtonsoft.Json;

namespace HozestERP.Web.ManageApplication
{
    /// <summary>
    /// ProductChoseList 的摘要说明
    /// </summary>
    public class ProductChoseList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            var start = 0;
            var limit = 10;
            var sort = string.Empty;
            var dir = string.Empty;
            var query = string.Empty;
            var productName = string.Empty;
            var platformMerchantCode = string.Empty;
            var manufacturersCode = string.Empty;

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

            IXMProductService XMProductService = IoC.Resolve<IXMProductService>();

            var result = XMProductService.GetXMProductListWithDetail();

            if (!string.IsNullOrEmpty(context.Request["productName"]))
            {
                productName= context.Request["productName"];
                result = result.Where(a => a.ProductName.IndexOf(productName)>=0);
            }

            if (!string.IsNullOrEmpty(context.Request["platformMerchantCode"]))
            {
                platformMerchantCode= context.Request["platformMerchantCode"];
                result = result.Where(a => a.PlatformMerchantCode.IndexOf(platformMerchantCode)>=0);
            }

            if (!string.IsNullOrEmpty(context.Request["manufacturersCode"]))
            {
                manufacturersCode = context.Request["manufacturersCode"];
                result = result.Where(a => a.ManufacturersCode.IndexOf(manufacturersCode)>=0);
            }

            List<ProductChose> list= result.OrderBy(a => a.ID).Skip(start).Take(limit).ToList();

            Paging<ProductChose> pag = new Paging<ProductChose>(list, result.Count());

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