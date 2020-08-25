using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageBusiness;
using System.Web.Script.Serialization;
using System.Text;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageApplication;



namespace HozestERP.Web.ManageProject
{
    /// <summary>
    /// XMField 的摘要说明
    /// </summary>
    public class XMField : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id = CommonHelper.QueryString("Id");
            JavaScriptSerializer javaS = new JavaScriptSerializer();
            StringBuilder josn = new StringBuilder();
            var field = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldById(int.Parse(id));
            var childField = IoC.Resolve<IXMFinancialFieldService>().GetXMFinancialFieldByParentID(field.ParentID.Value);
            List<Field> List = new List<Field>();
            if (childField != null)
            {
                foreach (XMFinancialField info in childField)
                {
                    Field fieldInfo = new Field();
                    fieldInfo.Id = info.Id;
                    fieldInfo.FieldName = info.FieldName;
                    fieldInfo.ParentId = info.ParentID.Value;
                    List.Add(fieldInfo);
                }
            }
            javaS.Serialize(List, josn);
            context.Response.ContentType = "text/plain";
            context.Response.Write(josn.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class Field
    {
        public int Id;
        public string FieldName;
        public int ParentId;
    }
}