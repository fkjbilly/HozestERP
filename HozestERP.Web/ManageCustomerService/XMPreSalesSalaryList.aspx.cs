using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Top.Api.Domain;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.Common;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Codes;
using System.Text.RegularExpressions;
using JdSdk.Domains;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using JdSdk.Domain;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Yhd.Api.Object;
using Yhd.Api;
using Yhd.Api.Request;
using Yhd.Api.Response;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.IO;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMPreSalesSalaryList : BaseAdministrationPage, ISearchPage
    {
        public List<XMPreSalesSalary> ExportXMPreSalesSalaryList;
        public int type=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
            }

        }

        #region ISearchPage 成员
        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnSynchronousOrderData.UniqueID, this.Page);

        }
        public void Face_Init()
        {
            this.ddlRank.Items.Clear();
            var codePlatformTypeList = base.XMCustomerServiceLevelService.GetXMCustomerServiceLevelList("");
            this.ddlRank.DataSource = codePlatformTypeList;
            this.ddlRank.DataTextField = "RankName";
            this.ddlRank.DataValueField = "Id";
            this.ddlRank.DataBind();
            this.ddlRank.Items.Insert(0, new ListItem("---所有---", "-1"));

            string DepCode = "QC1403-1,QC1403-2,QC1506-1";
            this.ddlGroupID.Items.Clear();
            var CoustomerServiceGroup = base.XMCustomerServiceLevelService.GetXMCoustomerServiceGroupList(DepCode);
            this.ddlGroupID.DataSource = CoustomerServiceGroup;
            this.ddlGroupID.DataTextField = "DepName";
            this.ddlGroupID.DataValueField = "DepartmentID";
            this.ddlGroupID.DataBind();
            this.ddlGroupID.Items.Insert(0, new ListItem("---所有---", "-1"));
            //日期默认为上个月
            int days = DateTime.DaysInMonth ( DateTime.Now.Year, DateTime.Now.Month); //当月天数
            this.ddlBeginDate.Value = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString().PadLeft(2,'0') + "-01";
            this.ddlEndDate.Value = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + days.ToString();
            //this.ddlMonth.Value = DateTime.Now.Year.ToString() + "-" + (DateTime.Now.AddMonths(-1).Month.ToString()).PadLeft(2,'0');
        }
        public void BindGrid(int paramPageIndex, int paramPageSize)//type为1时表示执行导出操作
        {
            try
            {
                //退款状态
                List<string> RefundStatus = new List<string>();
                RefundStatus.Add("TRADE_CLOSED");//天猫
                RefundStatus.Add("TRADE_CANCELED");//京东
                RefundStatus.Add("STATUS_97");//唯品会
                RefundStatus.Add("ORDER_CANCEL");//一号店
                RefundStatus.Add("已取消");//亚马逊
                RefundStatus.Add("40");//苏宁易购


                //开始日期
                string beginDate = this.ddlBeginDate.Value.ToString();
                //结束日期
                string endDate = this.ddlEndDate.Value.ToString();

                if (string.IsNullOrEmpty(beginDate) || string.IsNullOrEmpty(endDate))
                {
                    if (string.IsNullOrEmpty(beginDate) && string.IsNullOrEmpty(endDate))
                    {
                        return;
                    }
                    else 
                    {
                        base.ShowMessage("请先选择开始日期与结束日期！");
                        return;
                    }
                }

                DateTime begin = DateTime.Parse(beginDate);
                DateTime end = DateTime.Parse(endDate).AddDays(1);
                if (begin >= end)
                {
                    base.ShowMessage("开始日期不能大于结束日期，请重新选择！");
                    return;
                }
                //组别
                int groupId = int.Parse(this.ddlGroupID.SelectedValue);
                //姓名
                string Name = this.ddlName.Text.ToString();
                //级别
                int RankID = int.Parse(this.ddlRank.SelectedValue);
                //客服部DepCode
                string DepCode = "QC1403-1,QC1403-2,QC1506-1";

                //根据条件查询客服信息
                var xMProjectList = base.CustomerInfoService.GetCustomerInfoPreList(groupId, "", DepCode, "");
                //根据排名，求排名奖金系数
                //分页
                //var xMProjectPageList = new PagedList<XMPreSalesSalary>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                var codePlatformTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);//获取平台信息
                int JingDongID = 0;
                int TianMaoID = 0;

                for (int i = 0; i < codePlatformTypeList.Count; i++)
                {
                    if (codePlatformTypeList[i].CodeName == "京东")
                    {
                        JingDongID = codePlatformTypeList[i].CodeID;
                    }
                    if (codePlatformTypeList[i].CodeName == "天猫")
                    {
                        TianMaoID = codePlatformTypeList[i].CodeID;
                    }
                }
                for (int i = 0; i < xMProjectList.Count; i++)
                {
                    //DateTime begin = DateTime.Parse(beginDate);
                    //DateTime end = DateTime.Parse(endDate).AddDays(1);
                    //客服ID
                    int CustomerID = (int)xMProjectList[i].CustomerID;
                    //旺旺号
                    var WangNoPreList = base.XMWangNoService.GetWangNoPreList(CustomerID, begin, end, RefundStatus);
                    List<string> wangNoList = new List<string>();
                    List<XMPreSalesSalary> WangNoList = new List<XMPreSalesSalary>();
                    decimal TotalMoney = 0;//销售总金额
                    for (int j = 0; j < WangNoPreList.Count; j++)
                    {
                        if (wangNoList.IndexOf(WangNoPreList[j].WangNo) == -1)
                        {
                            wangNoList.Add(WangNoPreList[j].WangNo);
                            XMPreSalesSalary info = new XMPreSalesSalary();
                            info.PlatformTypeId = WangNoPreList[j].PlatformTypeId;
                            info.WangNo = WangNoPreList[j].WangNo;
                            WangNoList.Add(info);
                        }
                    }
                    for (int j = 0; j < WangNoPreList.Count; j++)
                    {
                        int index = wangNoList.IndexOf(WangNoPreList[j].WangNo);
                        if (WangNoList[index].TotalMoney == null)
                        {
                            WangNoList[index].TotalMoney = (decimal)0;
                        }
                        if (WangNoPreList[j].PayPrice == null)
                        {
                            WangNoPreList[j].PayPrice = (decimal)0;
                        }
                        WangNoList[index].TotalMoney = WangNoList[index].TotalMoney + WangNoPreList[j].PayPrice;//旺旺号对应实际销售
                        TotalMoney = TotalMoney + (decimal)WangNoList[index].TotalMoney;
                    }
                    xMProjectList[i].TotalMoney = TotalMoney;

                    decimal JingMao = 0;//京东天猫总销售额
                    decimal OtherPerformance = 0;//第三方平台总销售额
                    for (int j = 0; j < WangNoList.Count; j++)
                    {
                        if (WangNoList[j].PlatformTypeId == JingDongID || WangNoList[j].PlatformTypeId == TianMaoID)
                        {
                            JingMao = JingMao + (decimal)WangNoList[j].TotalMoney;
                        }
                        else
                        {
                            OtherPerformance = OtherPerformance + (decimal)WangNoList[j].TotalMoney;
                        }
                    }
                    xMProjectList[i].JingMao = JingMao;
                    xMProjectList[i].OtherPerformance = OtherPerformance;
                }
                for (int i = 0; i < xMProjectList.Count; i++)
                {
                    //DateTime begin = DateTime.Parse(beginDate);
                    //DateTime end = DateTime.Parse(endDate);
                    //客服ID
                    int CustomerID = (int)xMProjectList[i].CustomerID;
                    //旺旺号
                    var WangNoPreList = base.XMWangNoService.GetWangNoPreList(CustomerID, begin, end, RefundStatus);
                    var TotalClickFarming = base.XMWangNoService.GetTotalClickFarmingList(CustomerID, begin, end, RefundStatus);
                    var TotalRefund = base.XMWangNoService.GetTotalRefundList(CustomerID, begin, end, RefundStatus);
                    decimal totalClickFarming = 0;
                    decimal totalRefund = 0;
                    for (int z = 0; z < TotalClickFarming.Count; z++)
                    {
                        totalClickFarming = totalClickFarming + (decimal)TotalClickFarming[z].PayPrice;
                    }
                    xMProjectList[i].TotalClickFarming = totalClickFarming;
                    for (int z = 0; z < TotalRefund.Count; z++)
                    {
                        totalRefund = totalRefund + (decimal)TotalRefund[z].PayPrice;
                    }
                    xMProjectList[i].TotalRefund = totalRefund;

                    List<string> wangNoList = new List<string>();
                    List<XMPreSalesSalary> WangNoList = new List<XMPreSalesSalary>();
                    for (int j = 0; j < WangNoPreList.Count; j++)
                    {
                        if (wangNoList.IndexOf(WangNoPreList[j].WangNo) == -1)
                        {
                            wangNoList.Add(WangNoPreList[j].WangNo);
                            XMPreSalesSalary info = new XMPreSalesSalary();
                            info.PlatformTypeId = WangNoPreList[j].PlatformTypeId;
                            info.WangNo = WangNoPreList[j].WangNo;
                            WangNoList.Add(info);
                        }
                    }
                    for (int j = 0; j < WangNoPreList.Count; j++)
                    {
                        int index = wangNoList.IndexOf(WangNoPreList[j].WangNo);
                        if (WangNoList[index].TotalMoney == null)
                        {
                            WangNoList[index].TotalMoney = (decimal)0;
                        }
                        if (WangNoPreList[j].PayPrice == null)
                        {
                            WangNoPreList[j].PayPrice = (decimal)0;
                        }
                        WangNoList[index].TotalMoney = WangNoList[index].TotalMoney + WangNoPreList[j].PayPrice;//旺旺号对应实际销售
                    }

                    int GroupID = (int)xMProjectList[i].GroupID;
                    var xMPreList = base.CustomerInfoService.GetSortPreList(xMProjectList, GroupID);
                    if (xMProjectList[i].RankName == "组长" || xMProjectList[i].RankName == "主管")
                    {
                        xMProjectList[i].RankCoefficient = (decimal)0.007;
                    }
                    else if (xMPreList.Count>0 && xMPreList[0].CustomerID == xMProjectList[i].CustomerID)
                    {
                        xMProjectList[i].RankCoefficient = (decimal)0.008;
                    }
                    else if (xMPreList.Count > 1 && xMPreList[1].CustomerID == xMProjectList[i].CustomerID)
                    {
                        xMProjectList[i].RankCoefficient = (decimal)0.007;
                    }
                    else if (xMPreList.Count > 2 && xMPreList[2].CustomerID == xMProjectList[i].CustomerID)
                    {
                        xMProjectList[i].RankCoefficient = (decimal)0.006;
                    }
                    else
                    {
                        xMProjectList[i].RankCoefficient = (decimal)0.005;
                    }
                    xMProjectList[i].TotalMoney = xMProjectList[i].JingMao + xMProjectList[i].OtherPerformance;
                    xMProjectList[i].TotalCommission = xMProjectList[i].RankCoefficient * xMProjectList[i].JingMao + (decimal)0.001 * xMProjectList[i].OtherPerformance;//总提成
                    if (xMProjectList[i].BasicSalary == null)
                    {
                        xMProjectList[i].BasicSalary = 0;
                    }
                    xMProjectList[i].Total = xMProjectList[i].TotalCommission + xMProjectList[i].BasicSalary;
                    string tabWangNo = "";
                    List<XMPreSalesSalary> ExportList = new List<XMPreSalesSalary>();
                    for (int j = 0; j < WangNoList.Count; j++)
                    {
                        if (WangNoList[j].PlatformTypeId == JingDongID || WangNoList[j].PlatformTypeId == TianMaoID)
                        {
                            WangNoList[j].RankCoefficient = xMProjectList[i].RankCoefficient;
                        }
                        else
                        {
                            WangNoList[j].RankCoefficient = (decimal)0.001;
                        }
                        if (type == 0)
                        {
                            //排名系数百分比显示
                            string Coefficient = ((float)(WangNoList[j].RankCoefficient) * 100).ToString() + "%";
                            tabWangNo = tabWangNo + "<tr><td style='text-align:center;'>" + WangNoList[j].WangNo + "</td>" +
                                "<td style='text-align:left;'>" + WangNoList[j].TotalMoney + "</td>" +
                                "<td style='text-align:left;'>" + WangNoList[j].RankCoefficient * WangNoList[j].TotalMoney + "</td>" +
                                "<td style='text-align:left;'>" + Coefficient + "</td></tr>";
                        }
                        else if (type == 1)
                        {
                            XMPreSalesSalary list = new XMPreSalesSalary();
                            list.WangNo = WangNoList[j].WangNo;//旺旺号
                            list.TotalMoney = WangNoList[j].TotalMoney;//实际销售额
                            list.Commission = WangNoList[j].RankCoefficient * WangNoList[j].TotalMoney;//提成
                            list.RankCoefficient= WangNoList[j].RankCoefficient;//排名系数
                            ExportList.Add(list);
                        }
                    }
                    xMProjectList[i].tabWangNoList = ExportList;
                    xMProjectList[i].tabWangNo = tabWangNo;

                }

                if (!string.IsNullOrEmpty(Name) || RankID!=-1)
                {
                    var xMPreNameList = base.CustomerInfoService.GetSortPreNameList(xMProjectList, Name, RankID);
                    if (type == 1)
                    {
                        ExportXMPreSalesSalaryList = xMPreNameList;
                        return;
                    }
                    var xMProjectPageNameList = new PagedList<XMPreSalesSalary>(xMPreNameList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                    this.Master.BindData(this.grdvClients, xMProjectPageNameList, paramPageSize + 1);
                    return;
                }
                if (type == 1)
                {
                    ExportXMPreSalesSalaryList = xMProjectList;
                    return;
                }
                var xMProjectPageList = new PagedList<XMPreSalesSalary>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.grdvClients, xMProjectPageList, paramPageSize + 1);
            }
            catch(Exception ex)
            {
                base.ShowMessage("查询出错！");
            }
        }
        #endregion

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 更新旺旺号
        /// </summary>
        protected void btnUpdateWaqngNo_Click(object sender, EventArgs e)
        {
            //this.BindGrid(1, Master.PageSize);
        }
        
        /// <summary>
        /// 选择旺旺号
        /// </summary>
        protected void imgBtnDistribution_Click(object sender, EventArgs e)
        {
            //this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "CustomerWangNoOpen", "<script>CustomerWangNoOpen();</script>");
        
        }
        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    var xMScalpingApplication = e.Row.DataItem as XMCustomerServiceWangNo;
            //    //查看详情
            //    ImageButton imgBtnEdit = e.Row.FindControl("imgBtnDistribution") as ImageButton;
            //    if (imgBtnEdit != null)
            //    {
            //        imgBtnEdit.OnClientClick = "return ShowWindowDetail('客服与旺旺关系管理','" + CommonHelper.GetStoreLocation() + "ManageCustomerService/XMCustomerServiceWangNoList.aspx?CustomerID = " + xMScalpingApplication.CustomerID + "'"//&PageID = XMCustomerServiceInfoList'"
            //            + ",930, 470, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";
            //    }

            //}

            //if (e.Row.RowState == DataControlRowState.Edit ||
            //     e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            //{
            //    //项目名称
            //    DropDownList ddllist = (DropDownList)e.Row.FindControl("ddlRankList");
            //    ddllist.Items.Clear();
            //    //var itemList = base.XMProjectService.GetXMProjectList();

            //    var codePlatformTypeList = base.XMCustomerServiceLevelService.GetXMCustomerServiceLevelList("");
            //    ddllist.DataSource = codePlatformTypeList;
            //    ddllist.DataTextField = "RankName";
            //    ddllist.DataValueField = "ID";
            //    ddllist.DataBind();
            //}
        }
        /// <summary>
        /// 删除行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //#region 删除
            //if (e.CommandName.Equals("Delete"))
            //{
            //    var XMCustomerRankList = base.XMCustomerRankService.GetXMCustomerRankByCustomerID(Convert.ToInt32(e.CommandArgument));
            //    var XMCustomerWangNoList = base.XMCustomerWangNoService.GetXMCustomerWangNoByCustomerID(Convert.ToInt32(e.CommandArgument));
            //    if (XMCustomerRankList != null)//删除客服等级
            //    {
            //        XMCustomerRankList.IsEnabled = true;
            //        XMCustomerRankList.UpdatorID = HozestERPContext.Current.User.CustomerID;
            //        XMCustomerRankList.UpdateTime = DateTime.Now;
            //        base.XMCustomerRankService.UpdateXMCustomerRank(XMCustomerRankList);
            //    }
            //    if (XMCustomerWangNoList != null)//删除客服旺旺号
            //    {
            //        for (int i = 0; i < XMCustomerWangNoList.Count; i++)
            //        {
            //            XMCustomerWangNoList[i].IsEnabled = true;
            //            XMCustomerWangNoList[i].UpdatorID = HozestERPContext.Current.User.CustomerID;
            //            XMCustomerWangNoList[i].UpdateTime = DateTime.Now;
            //            base.XMCustomerWangNoService.UpdateXMCustomerWangNo(XMCustomerWangNoList[i]);
            //        }
            //    }
            //    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            //    base.ShowMessage("操作成功.");
            //}
            //#endregion
        }
        /// <summary>
        /// 删除行数据之前执行的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        /// <summary>
        /// 编辑行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ////组别
            //string Group = this.ddlGroup.Text.ToString();
            ////姓名
            //string Name = this.ddlName.Text.ToString();
            ////级别
            //string Rank = this.ddlRank.Text.ToString();
            ////客服部DepartmentID
            //int DepartmentID = 205;

            //this.grdvClients.EditIndex = e.NewEditIndex;
            //this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            //int Id = 0;
            //int.TryParse(this.grdvClients.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
            //var row = this.grdvClients.Rows[e.NewEditIndex];

            //var xMProjectList = base.CustomerInfoService.GetCustomerServiceInfoListByID(Group, Name, DepartmentID, Rank, Id);
            //if (xMProjectList != null)
            //{
            //    DropDownList ddProjectId = (DropDownList)row.FindControl("ddlRankList");
            //    if (xMProjectList.RankID != null)
            //    {
            //        ddProjectId.SelectedValue = xMProjectList.RankID.Value.ToString();
            //    }
            //}
        }
        /// <summary>
        /// 更新行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int nickId = 0;
            //int.TryParse(this.grdvClients.DataKeys[e.RowIndex].Value.ToString(), out nickId);
            //var row = this.grdvClients.Rows[e.RowIndex];
            //var ddProjectId = row.FindControl("ddlRankList") as DropDownList;
            //var nick = base.XMCustomerRankService.GetXMCustomerRankByCustomerID(nickId);
            //if (nick != null)
            //{
            //    XMCustomerRank CustomerRank = base.XMCustomerRankService.GetXMCustomerRankByCustomerID(nickId);
            //    CustomerRank.CustomerID = nickId;
            //    CustomerRank.RankID = int.Parse(ddProjectId.SelectedValue.ToString());
            //    CustomerRank.UpdatorID = HozestERPContext.Current.User.CustomerID;
            //    CustomerRank.UpdateTime = DateTime.Now;
            //    CustomerRank.IsEnabled = false;
            //    base.XMCustomerRankService.UpdateXMCustomerRank(CustomerRank);
            //}
            //else
            //{
            //    XMCustomerRank CustomerRank = new XMCustomerRank();
            //    CustomerRank.CustomerID = nickId;
            //    CustomerRank.RankID = int.Parse(ddProjectId.SelectedValue.ToString());
            //    CustomerRank.UpdatorID = HozestERPContext.Current.User.CustomerID;
            //    CustomerRank.UpdateTime = DateTime.Now;
            //    CustomerRank.IsEnabled = false;
            //    CustomerRank.CreatorID = HozestERPContext.Current.User.CustomerID;
            //    CustomerRank.CreateTime = DateTime.Now;
            //    base.XMCustomerRankService.InsertXMCustomerRank(CustomerRank);
            //}
            //base.ShowMessage("保存成功!");
            //this.grdvClients.EditIndex = -1;
            //this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }
        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //this.grdvClients.EditIndex = -1;
            //this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        //导出明细
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = string.Format("PreServiceSalary_{0}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                string filePath = string.Format("{0}Upload\\PreServiceSalary", HttpContext.Current.Request.PhysicalApplicationPath);
                if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = filePath +"//"+ fileName;
                type = 1;
                this.BindGrid(1, Master.PageSize);
                type = 0;
                if (ExportXMPreSalesSalaryList!=null && ExportXMPreSalesSalaryList.Count > 0)
                {
                    base.ExportManager.ExportPreServiceSalaryXls(filePath, ExportXMPreSalesSalaryList);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                    ExportXMPreSalesSalaryList = null;
                }
                else
                {
                    base.ShowMessage("数据为空，请先查询！");
                }
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }
    }
}