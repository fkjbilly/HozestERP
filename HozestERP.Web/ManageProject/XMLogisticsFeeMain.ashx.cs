using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Codes;
using Ext.Net;
using Newtonsoft.Json;

namespace HozestERP.Web.ManageProject
{
    /// <summary>
    /// XMLogisticsFeeMain1 的摘要说明
    /// </summary>
    public class XMLogisticsFeeMain1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            var start = 0;
            var limit = 10;
            var sort = string.Empty;
            var dir = string.Empty;
            var query = string.Empty;
            var province = string.Empty;
            var city = string.Empty;
            var area = string.Empty;

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

            IXMLogisticsFeeMainService XMLogisticsFeeMainService = IoC.Resolve<IXMLogisticsFeeMainService>();
            ICodeService CodeService = IoC.Resolve<ICodeService>();

            var query1= XMLogisticsFeeMainService.GetXMLogisticsFeeMainList();

            List<XMLogisticsFeeMainNew> list = query1.OrderBy(a => a.ID).Skip(start).Take(limit).ToList();
            List<CodeList> codeList = CodeService.GetCodeListAll();

            var data = from p in list
                       select new FinalData
                       {
                           ID = p.ID,
                           Project = p.Project,
                           WareHouse = codeList.Where(a => a.CodeID == p.WareHouseID).FirstOrDefault() == null ? "" : codeList.Where(a => a.CodeID == p.WareHouseID).FirstOrDefault().CodeName,
                           Province=p.Province,
                           City=p.City,
                           Area=p.Area,
                           Logistics= codeList.Where(a=>a.CodeID==p.LogisticsID).FirstOrDefault()==null?"": codeList.Where(a => a.CodeID == p.LogisticsID).FirstOrDefault().CodeName,
                           Fee=p.Fee,
                       };

            if (!string.IsNullOrEmpty(context.Request["province"]))
            {
                province = context.Request["province"];
                data = data.Where(a => a.Province.IndexOf(province) >= 0);
            }

            if (!string.IsNullOrEmpty(context.Request["city"]))
            {
                city = context.Request["city"];
                data = data.Where(a => a.City.IndexOf(city) >= 0);
            }

            if (!string.IsNullOrEmpty(context.Request["area"]))
            {
                area = context.Request["area"];
                data = data.Where(a => a.Area.IndexOf(area) >= 0);
            }

            Paging<FinalData> pag = new Paging<FinalData>(data, query1.Count());

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
            /// 发货点
            /// </summary>
            public string WareHouse { get; set; }

            /// <summary>
            /// 省
            /// </summary>
            public string Province { get; set; }

            /// <summary>
            /// 市
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// 区
            /// </summary>
            public string Area { get; set; }

            /// <summary>
            /// 物流公司
            /// </summary>
            public string Logistics { get; set; }

            /// <summary>
            /// 费用
            /// </summary>
            public decimal Fee { get; set; }

        }
    }
}