using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using Ext.Net;
using Newtonsoft.Json;
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.Web.ManageProject
{
    /// <summary>
    /// XMLogisticsFeeBranch1 的摘要说明
    /// </summary>
    public class XMLogisticsFeeBranch1 : IHttpHandler
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

            IXMLogisticsFeeBranchService XMLogisticsFeeBranchService = IoC.Resolve<IXMLogisticsFeeBranchService>();
            ICodeService CodeService = IoC.Resolve<ICodeService>();

            var query1 = XMLogisticsFeeBranchService.GetXMLogisticsFeeBranchList();

            List<XMLogisticsFeeBranchNew> list = query1.OrderBy(a => a.ID).Skip(start).Take(limit).ToList();
            List<CodeList> codeList = CodeService.GetCodeListAll();

            var data = from p in list
                       select new FinalData
                       {
                           ID=p.ID,
                           Project=p.Project,
                           Logistics= codeList.Where(a=>a.CodeID==p.LogisticsID).FirstOrDefault()==null?"": codeList.Where(a => a.CodeID == p.LogisticsID).FirstOrDefault().CodeName,
                           ProductCategory= codeList.Where(a => a.CodeID == p.ProductCategoryID).FirstOrDefault()==null?"": codeList.Where(a => a.CodeID == p.ProductCategoryID).FirstOrDefault().CodeName,
                           Fee=p.Fee,
                       };

            Paging<FinalData> pag= new Paging<FinalData>(data, query1.Count());

            context.Response.Write(string.Format("{{total:{1},'data':{0}}}", JsonConvert.SerializeObject(pag.Data), pag.TotalRecords));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private class FinalData
        {
            public int ID { get; set; }

            /// <summary>
            /// 项目
            /// </summary>
            public string Project { get; set; }

            /// <summary>
            /// 物流公司
            /// </summary>
            public string Logistics { get; set; }

            /// <summary>
            /// 商品类型
            /// </summary>
            public string ProductCategory { get; set; }

            /// <summary>
            /// 费用
            /// </summary>
            public decimal Fee { get; set; }
        }
    }
}