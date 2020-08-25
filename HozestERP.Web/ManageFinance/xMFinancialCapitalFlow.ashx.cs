using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    /// <summary>
    /// XMOrderInfoProductDetaisRead 的摘要说明
    /// </summary>
    public class xMFinancialCapitalFlow : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "BindAssociatedPerson":
                    try
                    {
                        context.Session["RecordAssociatedPersonValue"] = null;
                        string Begin = CommonHelper.QueryString("Begin");
                        string End = CommonHelper.QueryString("End");
                        var list = IoC.Resolve<IXMFinancialCapitalFlowService>().GetXMFinancialCapitalFlowListByDate(Begin, End);
                        list = list.Distinct(new Compare<XMFinancialCapitalFlow>((x, y) => x.AssociatedPerson == y.AssociatedPerson)).ToList();//去重规则

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(list, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                case "RecordAssociatedPersonValue":
                    try
                    {
                        string AssociatedPerson = CommonHelper.QueryString("AssociatedPerson");
                        context.Session["RecordAssociatedPersonValue"] = AssociatedPerson;
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize("", josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
            }
        }

        public delegate bool CompareDelegate<T>(T x, T y);
        public class Compare<T> : IEqualityComparer<T>
        {
            private CompareDelegate<T> _compare;
            public Compare(CompareDelegate<T> d)
            {
                this._compare = d;
            }

            public bool Equals(T x, T y)
            {
                if (_compare != null)
                {
                    return this._compare(x, y);
                }
                else
                {
                    return false;
                }
            }

            public int GetHashCode(T obj)
            {
                return obj.ToString().GetHashCode();
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