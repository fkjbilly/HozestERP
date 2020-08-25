using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    /// <summary>
    /// Summary description for ScalpingCodeHandler
    /// </summary>
    public class ScalpingCodeHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = CommonHelper.QueryString("action");
            switch (action)
            {
                #region Select

                case "Select": //
                    try
                    {
                        string ScalpingCode = CommonHelper.QueryString("q");
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        //根据刷单单号查询(查询刷单单号 部门审核通过的)
                        var scalpingApplicationList = IoC.Resolve<IXMScalpingApplicationService>().GetXMScalpingApplicationByScalpingCode(ScalpingCode).Take(10);
                        javaS.Serialize(scalpingApplicationList, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {
                    }
                    break;
                #endregion

                #region SelectBy
                case "SelectBy"://暂支申请Add 、 暂支明细
                    try
                    {
                        string ScalpingCode = CommonHelper.QueryString("q");
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        //根据刷单单号关联暂支单查询（查询暂支单中不存在的刷单单号）
                        var scalpingApplicationList = IoC.Resolve<IXMScalpingApplicationService>().GetXMScalpingApplicationByScalpingCodeList(ScalpingCode).Take(10);
                        javaS.Serialize(scalpingApplicationList, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {

                    }
                    break;
                #endregion

                #region SelectByAdvanceState
                case "SelectByAdvanceState"://刷单记录
                    try
                    {

                        //平台id 
                        string PlatformTypeId = CommonHelper.QueryString("PlatformTypeId");
                        //店铺Id
                        string NickId = CommonHelper.QueryString("NickId");

                        string ScalpingCode = CommonHelper.QueryString("q");
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        //根据刷单单号关联暂支单查询（查询暂支单中不存在的刷单单号）
                        //匹配刷单记录
                        if (PlatformTypeId != "" && NickId != "")
                        {
                            var scalpingApplicationList = IoC.Resolve<IXMScalpingApplicationService>().GetXMScalpingApplicationByAdvanceState(ScalpingCode).Take(10);
                            var scalpingApplicationListNew = scalpingApplicationList.Where(p => p.PlatformTypeId == Convert.ToInt32(PlatformTypeId) && p.NickId.Value == Convert.ToInt32(NickId)).ToList();
                            javaS.Serialize(scalpingApplicationListNew, josn);
                        }
                        else
                        {
                            //新增、修改刷单记录
                            var scalpingApplicationList = IoC.Resolve<IXMScalpingApplicationService>().GetXMScalpingApplicationByAdvanceState(ScalpingCode).Take(10);
                            javaS.Serialize(scalpingApplicationList, josn);
                        }
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {

                    }
                    break;
                #endregion

                #region selectBywang
                case "selectBywang"://根据订单号查询旺旺
                    try
                    {
                        string ScalpingCode = CommonHelper.QueryString("q");
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        //根据刷单单号关联暂支单查询（查询暂支单中不存在的刷单单号）
                        var scalpingApplicationList = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCodeList(ScalpingCode).Take(10);
                        javaS.Serialize(scalpingApplicationList, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {

                    }
                    break;
                #endregion

                #region 根据项目选店铺
                case "selectNickByProject":
                    try
                    {
                        string projectID = CommonHelper.QueryString("projectID");
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        var nickList = IoC.Resolve<IXMOrderInfoAPIService>().GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(projectID));
                        javaS.Serialize(nickList, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {

                    }
                    break;
                #endregion

                #region
                case "selectNickByPlatform":
                    try
                    {
                        string platformID= CommonHelper.QueryString("platformID");
                        JavaScriptSerializer javaS = new JavaScriptSerializer();
                        StringBuilder josn = new StringBuilder();
                        var nickList = IoC.Resolve<IXMNickService>().GetXMNickListByPlatformType(int.Parse(platformID));
                        javaS.Serialize(nickList, josn);
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(josn.ToString());
                    }
                    catch
                    {

                    }
                    break;
                #endregion
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