using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    /// <summary>
    /// XMOrderInfoProductDetaisRead 的摘要说明
    /// </summary>
    public class FinancialCapitalFlow : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "autocomplete":
                    try
                    {
                        string str = CommonHelper.QueryString("p").Trim();
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();

                        var list = IoC.Resolve<IXMBusinessDataService>().GetXMBusinessDataListByClientCompany(str).Take(10);
                        if (list.Count() > 0)
                        {
                            foreach (XMBusinessDataBrief info in list)
                            {
                                info.PayPerson = info.PayPerson == null ? "空" : info.PayPerson;
                            }
                        }
                        javaS.Serialize(list, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                case "ReceivablesBudget":
                    try
                    {
                        string CodeTypeID = CommonHelper.QueryString("CodeTypeID").Trim();
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        List<HighChart> list = new List<HighChart>();

                        if (CodeTypeID == "225")
                        {
                            //var BudgetList = IoC.Resolve<IBudgetSettingService>().GetBudgetSettingListByData("");
                            var BudgetList = IoC.Resolve<IXMFinancialFieldService>().GetBudgetSettingListByData("");
                            if (BudgetList.Count > 0)
                            {
                                foreach (XMFinancialField info in BudgetList)
                                {
                                    HighChart item = new HighChart();
                                    item.Name = info.FieldName;
                                    item.Value = info.Id;
                                    list.Add(item);
                                }
                            }
                        }
                        else
                        {
                            var ReceivablesTypeList = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(int.Parse(CodeTypeID));
                            if (ReceivablesTypeList.Count > 0)
                            {
                                foreach (CodeList info in ReceivablesTypeList)
                                {
                                    HighChart item = new HighChart();
                                    item.Name = info.CodeName;
                                    item.Value = info.CodeID;
                                    list.Add(item);
                                }
                            }
                        }
                        javaS.Serialize(list, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
            }
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