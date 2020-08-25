using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Web;

namespace HozestERP.Web.ManageProject
{
    public partial class XMExpressListContrast : BaseAdministrationPage, ISearchPage
    {
        /// <summary>
        /// 按钮 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnExportDelviery", "ManageProject.XMExpressListContrast.ExportDelivery"); // 导入发货单
                buttons.Add("Button1", "ManageProject.XMExpressListContrast.ExportExpressList"); // 导入快递账单
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["xmDeliveryList"] = null;
                Session["xmExpressList"] = null;
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
                this.BindGrid(1, Master.PageSize);
            }
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            int year = int.Parse(ddlYear.SelectedValue);
            int month = int.Parse(ddlMonth.SelectedValue);
            string expressIDs = ddlExpress.SelectedValue;
            //合并集合
            List<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage> Info = new List<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>();
            var delvieryInfo = base.XMDeliveryService.GetXMDeliveryByPrintDate(year, month, expressIDs);
            if (delvieryInfo != null && delvieryInfo.Count > 0)
            {
                foreach (var info in delvieryInfo)
                {
                    HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage expressList = new HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage();
                    expressList.Number = info.LogisticsNumber;
                    expressList.Cost = info.Price;
                    expressList.Year = year;
                    expressList.Month = month;
                    expressList.ExpressID = info.LogisticsId.Value;
                    expressList.ExpressName = info.ExpressName;
                    Info.Add(expressList);
                }
            }
            var expressInfo = base.XMExpressManagementService.GetXMExpressManagementListByparm(year, month, expressIDs);
            if (expressInfo != null && expressInfo.Count > 0)
            {
                foreach (var p in expressInfo)
                {
                    HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage expressList2 = new HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage();
                    expressList2.Number = p.CourierNumber;
                    expressList2.Cost = p.Price;
                    expressList2.Year = year;
                    expressList2.Month = month;
                    expressList2.ExpressID = p.ExpressID.Value;
                    expressList2.ExpressName = p.ExpressName;
                    Info.Add(expressList2);
                }
            }

            //快递账单
            var list = base.XMExpressListManagementService.GetXMExpressListManagementByParm(year, month, expressIDs);
            if ((list != null && list.Count > 0) && (Info != null && Info.Count > 0))
            {
                var reslut = list.Except(list.Intersect(Info, new MyComparer()), new MyComparer());
                var pageList = new PagedList<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>(reslut.ToList(), paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.GridView1, pageList);
                Session["xmExpressList"] = reslut.ToList();

                var reslut2 = Info.Except(Info.Intersect(list, new MyComparer()), new MyComparer());
                var pageList2 = new PagedList<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>(reslut2.ToList(), paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.grdvClients, pageList2);
                Session["xmDeliveryList"] = reslut2.ToList();
            }

            if ((list != null && list.Count == 0) && (Info != null && Info.Count > 0))
            {
                var pageList2 = new PagedList<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.GridView1, pageList2);

                var pageList = new PagedList<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>(Info, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.grdvClients, pageList);
                Session["xmDeliveryList"] = Info;
            }

            if ((Info != null && Info.Count == 0) && (list != null && list.Count > 0))
            {
                var pageList2 = new PagedList<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>(Info, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.grdvClients, pageList2);

                var pageList = new PagedList<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.GridView1, pageList);
                Session["xmExpressList"] = list;
            }

            if ((Info != null && Info.Count == 0) && (list != null && list.Count == 0))
            {
                var pageList = new PagedList<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>(Info, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.grdvClients, pageList);

                var pageList2 = new PagedList<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.GridView1, pageList2);
            }
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["xmDeliveryList"] = null;
            Session["xmExpressList"] = null;
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\ExpressList", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    List<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage> xmExpressList = new List<BusinessLogic.ManageProject.XMNewExpressListManage>();
                    if (Session["xmExpressList"] != null)
                    {
                        xmExpressList = Session["xmExpressList"] as List<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>;
                        base.ExportManager.ExportExpressList(filePath, xmExpressList);
                        CommonHelper.WriteResponseXls(filePath, fileName);
                    }
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExportDelviery_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\ExpressDeliveryList", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    List<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage> deliveryList = new List<BusinessLogic.ManageProject.XMNewExpressListManage>();
                    if (Session["xmDeliveryList"] != null)
                    {
                        deliveryList = Session["xmDeliveryList"] as List<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>;
                    }
                    base.ExportManager.ExportExpressList(filePath, deliveryList);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        #region
        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            //快递绑定
            this.ddlExpress.Items.Clear();
            var xMCompanyCustomList = base.XMCompanyCustomService.GetXMCompanyCustomList();
            List<XMCompanyCustom> List = new List<XMCompanyCustom>();
            if (xMCompanyCustomList != null && xMCompanyCustomList.Count > 0)
            {
                foreach (var parm in xMCompanyCustomList)
                {
                    bool isExsit = false;
                    if (List.Count == 0)
                    {
                        XMCompanyCustom Info = new XMCompanyCustom();
                        Info.LogisticsId = parm.LogisticsId;
                        Info.LogisticsName = parm.LogisticsName;
                        List.Add(Info);
                    }
                    else
                    {
                        foreach (var d in List)
                        {
                            if (d.LogisticsName == parm.LogisticsName)
                            {
                                d.LogisticsId += "," + parm.LogisticsId;
                                isExsit = true;
                            }
                        }
                        if (isExsit == false)
                        {
                            XMCompanyCustom Info = new XMCompanyCustom();
                            Info.LogisticsId = parm.LogisticsId;
                            Info.LogisticsName = parm.LogisticsName;
                            List.Add(Info);
                        }
                    }
                }
            }

            this.ddlExpress.DataSource = List;
            this.ddlExpress.DataTextField = "LogisticsName";
            this.ddlExpress.DataValueField = "LogisticsId";
            this.ddlExpress.DataBind();
        }

        #endregion
    }

    //两个集合对比通用类
    public class MyComparer : IEqualityComparer<HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage>
    {
        public bool Equals(HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage x, HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage y)
        {
            return x.Number == y.Number && x.Year == y.Year && x.Month == y.Month && x.ExpressName == y.ExpressName;
        }

        public int GetHashCode(HozestERP.BusinessLogic.ManageProject.XMNewExpressListManage obj)
        {
            return obj.Number.GetHashCode() ^ obj.Year.GetHashCode() ^ obj.Month.GetHashCode() ^ obj.ExpressName.GetHashCode();
        }
    }


}