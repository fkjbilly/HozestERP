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

namespace HozestERP.Web.ManageCustomer
{
    public class xMChoseExpress : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                case "ExpressManage":
                    try
                    {
                        context.Session["XMChoseExpress-XMExpressManageList"] = null;
                        string Ids = CommonHelper.QueryString("Ids");
                        string[] IDs = Ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        if (IDs.Count() > 0)
                        {
                            List<int> IntIDs = IDs.Select<string, int>(q => Convert.ToInt32(q)).ToList();
                            context.Session["XMChoseExpress-XMExpressManageList"] = IntIDs;
                        }

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
                case "Delivery":
                    try
                    {
                        context.Session["XMChoseExpress-XMDelivery"] = null;
                        string Ids = CommonHelper.QueryString("Ids");
                        string[] IDs = Ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        if (IDs.Count() > 0)
                        {
                            List<int> IntIDs = IDs.Select<string, int>(q => Convert.ToInt32(q)).ToList();
                            context.Session["XMChoseExpress-XMDelivery"] = IntIDs;
                        }

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
                case "Print":
                    try
                    {
                        string mark = "0";
                        if (context.Session["DirectThermalPrint-Delivery"] != null)
                        {
                            mark = "1";
                            List<HozestERP.BusinessLogic.ManageProject.XMDelivery> list = (List<HozestERP.BusinessLogic.ManageProject.XMDelivery>)context.Session["DirectThermalPrint-Delivery"];
                            foreach (HozestERP.BusinessLogic.ManageProject.XMDelivery Info in list)
                            {
                                var info = IoC.Resolve<IXMDeliveryService>().GetXMDeliveryById(Info.Id);
                                if (info != null)
                                {
                                    info.LogisticsId = Info.LogisticsId;
                                    info.LogisticsNumber = Info.LogisticsNumber;
                                    info.IsDelivery = Info.IsDelivery;
                                    info.PrintQuantity = Info.PrintQuantity;
                                    info.PrintBatch = Info.PrintBatch;
                                    info.PrintDateTime = Info.PrintDateTime;
                                    info.UpdateId = Info.UpdateId;
                                    info.UpdateDate = Info.UpdateDate;
                                    IoC.Resolve<IXMDeliveryService>().UpdateXMDelivery(info);
                                }
                            }
                        }

                        if (context.Session["DirectThermalPrint-Express"] != null)
                        {
                            mark = "1";
                            List<XMExpressManagement> list = (List<XMExpressManagement>)context.Session["DirectThermalPrint-Express"];
                            foreach (XMExpressManagement Info in list)
                            {
                                var info = IoC.Resolve<IXMExpressManagementService>().GetXMExpressManagementByID(Info.ID);
                                if (info != null)
                                {
                                    info.ExpressID = Info.ExpressID;
                                    info.CourierNumber = Info.CourierNumber;
                                    info.PrintCount = Info.PrintCount;
                                    info.PrintDate = Info.PrintDate;
                                    info.UpdateID = Info.UpdateID;
                                    info.UpdateDate = Info.UpdateDate;
                                    IoC.Resolve<IXMExpressManagementService>().UpdateXMExpressManagement(info);
                                }
                            }
                        }

                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        javaS.Serialize(mark, josn);
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