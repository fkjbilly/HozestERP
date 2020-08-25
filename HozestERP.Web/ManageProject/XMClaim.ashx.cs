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
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    /// <summary>
    /// XMOrderInfoProductDetaisRead 的摘要说明
    /// </summary>
    public class XMClaim : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "ClaimInfo":
                    try
                    {
                        string str = CommonHelper.QueryString("p");
                        int type = int.Parse(CommonHelper.QueryString("q"));
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        if (type == 0)
                        {
                            var list = IoC.Resolve<IXMApplicationService>().GetXMApplicationListByApplicationNo(str).Take(10);
                            javaS.Serialize(list, josn);
                            context.Response.ContentType = "text/plain";
                            context.Response.Write(josn.ToString());
                        }
                        else
                        {
                            var list = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoListByOrderCode(str,1).Take(10);
                            if(list.Count()>0)
                            {
                                javaS.Serialize(list, josn);
                            }
                            else
                            {
                                var list1 = IoC.Resolve<IXMOrderInfoService>().getXMOrderInfoListByOrderCode(str, 2).Take(10);
                                if (list1.Count() > 0)
                                {
                                    javaS.Serialize(list1, josn);
                                }
                            }
                            context.Response.ContentType = "text/plain";
                            context.Response.Write(josn.ToString());
                        }
                    }
                    catch
                    {
                    }
                    break;
                //case "SavePremiumsAddPage":
                //    try
                //    {
                //        context.Session["SavePremiumsAddData"] = null;
                //        string OrderCode = CommonHelper.QueryString("OrderCode");
                //        string wangwang = CommonHelper.QueryString("wangwang");
                //        int ApplicationTypeId = CommonHelper.QueryStringInt("ApplicationTypeId");
                //        int PaymentPerson = CommonHelper.QueryStringInt("PaymentPerson");
                //        string chk = CommonHelper.QueryString("chk");
                //        string Nick = CommonHelper.QueryString("Nick");

                //        XMPremiums info = new XMPremiums();
                //        info.OrderCode = OrderCode;
                //        info.WantId = wangwang;
                //        info.PremiumsTypeId = ApplicationTypeId;
                //        info.PaymentPerson = PaymentPerson;
                //        info.IsEnable = chk == "0" ? false : true;//是否无订单号
                //        info.NoOrderNickId = Nick;
                //        context.Session["SavePremiumsAddData"] = info;

                //        JavaScriptSerializer javaS = new JavaScriptSerializer();
                //        StringBuilder josn = new StringBuilder();
                //        javaS.Serialize("", josn);
                //        context.Response.ContentType = "text/plain";
                //        context.Response.Write(josn.ToString());
                //    }
                //    catch
                //    {
                //    }
                //    break;
                case "BindCreateID":
                    try
                    {
                        context.Session["RecordResponsiblePersonValue"] = null;
                        context.Session["RecordCreateIDValue"] = null;
                        string Begin = CommonHelper.QueryString("Begin");
                        string End = CommonHelper.QueryString("End");
                        var list = IoC.Resolve<IXMClaimInfoService>().GetXMClaimInfoListByDate(Begin, End);
                        list = list.Distinct(new Compare<HozestERP.BusinessLogic.ManageProject.XMClaimInfo>((x, y) => x.CreateID == y.CreateID)).ToList();//去重规则

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
                case "BindResponsiblePerson":
                    try
                    {
                        context.Session["RecordResponsiblePersonValue"] = null;
                        context.Session["RecordCreateIDValue"] = null;
                        string Begin = CommonHelper.QueryString("Begin");
                        string End = CommonHelper.QueryString("End");
                        var list = IoC.Resolve<IXMClaimInfoDetailService>().GetXMClaimInfoDetailListByDate(Begin, End);
                        list = list.Distinct(new Compare<HozestERP.BusinessLogic.ManageProject.XMClaimInfoDetail>((x, y) => x.ResponsiblePerson == y.ResponsiblePerson)).ToList();

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
                case "RecordResponsiblePersonValue":
                    try
                    {
                        string ResponsiblePerson = CommonHelper.QueryString("ResponsiblePerson");
                        context.Session["RecordResponsiblePersonValue"] = ResponsiblePerson;
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
                case "RecordCreateIDValue":
                    try
                    {
                        string CreateID = CommonHelper.QueryString("CreateID");
                        context.Session["RecordCreateIDValue"] = CreateID;
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