using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HozestERP.Common.Utils;
using System.Web.Script.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.Web.ManageInventory
{
    /// <summary>
    /// GetPlatFormList 的摘要说明
    /// </summary>
    public class GetPlatFormList : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            List<PlatFormType> List = new List<PlatFormType>();
            JavaScriptSerializer javaS = new JavaScriptSerializer();
            StringBuilder josn = new StringBuilder();
            var codePlatformTypeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(182, false);
            if (codePlatformTypeList != null && codePlatformTypeList.Count > 0)
            {
                foreach (CodeList code in codePlatformTypeList)
                {
                    PlatFormType platform = new PlatFormType();
                    platform.ID = code.CodeID;
                    platform.Name = code.CodeName;
                    List.Add(platform);
                }
            }
            javaS.Serialize(List, josn);
            context.Response.ContentType = "text/plain";
            context.Response.Write(josn.ToString());
        }

        public class PlatFormType
        {
            public int ID;
            public string Name;
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