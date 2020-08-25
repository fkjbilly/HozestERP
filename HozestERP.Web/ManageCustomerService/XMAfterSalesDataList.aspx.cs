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

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMAfterSalesDataList : BaseAdministrationPage, ISearchPage
    {        
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

        }
        public void Face_Init()
        {
            #region 客服级别
            this.ddlRank.Items.Clear();
            var codePlatformTypeList = base.XMCustomerServiceLevelService.GetXMCustomerServiceLevelList("");
            this.ddlRank.DataSource = codePlatformTypeList;
            this.ddlRank.DataTextField = "RankName";
            this.ddlRank.DataValueField = "Id";
            this.ddlRank.DataBind();
            this.ddlRank.Items.Insert(0, new ListItem("", "-1"));
            #endregion

            #region 客服组别
            string DepCode = "QC1403-3,QC1403-4,QC1506-2";//售后客服
            this.ddlGroupID.Items.Clear();
            var CoustomerServiceGroup = base.XMCustomerServiceLevelService.GetXMCoustomerServiceGroupList(DepCode);
            this.ddlGroupID.DataSource = CoustomerServiceGroup;
            this.ddlGroupID.DataTextField = "DepName";
            this.ddlGroupID.DataValueField = "DepartmentID";
            this.ddlGroupID.DataBind();
            this.ddlGroupID.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion

            #region 默认开始与结束时间

            this.ddlBeginDate.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-01";
            this.ddlEndDate.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString().PadLeft(2,'0');

            #endregion
        }
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //开始日期
            string beginDate = this.ddlBeginDate.Value.ToString();
            //结束日期
            string endDate = this.ddlEndDate.Value.ToString();

            if (string.IsNullOrEmpty(beginDate) || string.IsNullOrEmpty(endDate))
            {
                base.ShowMessage("请先选择开始日期与结束日期！");
                return;
            }

            DateTime begin = DateTime.Parse(beginDate);
            DateTime end = DateTime.Parse(endDate);
            if (begin >= end)
            {
                base.ShowMessage("开始日期不能大于结束日期，请重新选择！");
                return;
            }
            if (!(begin.Year == end.Year && begin.Month == end.Month))
            {
                base.ShowMessage("请不要跨越月份查询！");
                return;
            }
            end = end.AddDays(1);

            //组别
            int groupId = int.Parse(this.ddlGroupID.SelectedValue);
            //姓名
            string Name = this.ddlName.Text.ToString();
            //级别
            string RankName = this.ddlRank.SelectedItem.Text.Trim();
            //售后客服DepCode
            string DepCode = "QC1403-3,QC1403-4,QC1506-2";

            //根据条件查询客服信息
            var xMProjectList = base.CustomerInfoService.GetCustomerInfoPreList(groupId, Name, DepCode, RankName);
            List<XMAfterSalesDataAll> all = new List<XMAfterSalesDataAll>();
            if (xMProjectList != null && xMProjectList.Count > 0)
            {
                for (int i = 0; i < xMProjectList.Count; i++)
                {
                    XMAfterSalesDataAll one = new XMAfterSalesDataAll();
                    one.CustomerID = (int)xMProjectList[i].CustomerID;
                    one.CustomerName = xMProjectList[i].Name;
                    one.GroupID = (int)xMProjectList[i].GroupID;
                    one.GroupName = xMProjectList[i].Group;
                    List<QuestionDetailed_Result> PersonalWorkload = base.XMAfterSalesDataService.GetXMAfterSalesDataByPersonalWorkload(begin, end, one.CustomerID);
                    one.PersonalWorkload = PersonalWorkload.Count;
                    List<QuestionDetailed_Result> DemandReturnCount = PersonalWorkload.Where(p => p.IsReturns == true).ToList();//base.XMAfterSalesDataService.GetXMAfterSalesDataByDemandReturn(begin, end, one.CustomerID, "");
                    one.DemandReturn = DemandReturnCount.Count;
                    int ReturnID = 0;
                    var codelist = base.CodeService.GetCodeListAll();
                    if (codelist != null)
                    {
                        foreach (CodeList item in codelist)
                        {
                            if (item.CodeName == "退货")
                            {
                                ReturnID = item.CodeID;
                                break;
                            }
                        }
                    }
                    List<QuestionDetailed_Result> ActualReturnCount = PersonalWorkload.Where(p => p.ResultsId == ReturnID).ToList();//base.XMAfterSalesDataService.GetXMAfterSalesDataByDemandReturn(begin, end, one.CustomerID, ReturnID.ToString());
                    one.ActualReturn = ActualReturnCount.Count();

                    if (one.DemandReturn != 0)
                    {
                        one.ReturnRate = (Math.Round((Convert.ToDouble(one.DemandReturn - one.ActualReturn) * 100 / Convert.ToDouble(one.DemandReturn)), 2)).ToString() + " %";
                    }
                    else
                    {
                        one.ReturnRate = "0 %";
                    }
                    //List<QuestionDetailed_Result> PersonalWorkload = base.XMAfterSalesDataService.GetXMAfterSalesDataByPersonalWorkload(begin, end, one.CustomerID);
                    //one.PersonalWorkload = PersonalWorkload.Count;
                    string date = begin.Year.ToString() + "-" + begin.Month.ToString().PadLeft(2, '0');
                    XMAfterSalesData data = base.XMAfterSalesDataService.GetXMAfterSalesDataInfoByMonth(date, one.CustomerID);
                    if (data != null)// && begin.Year == end.Year && begin.Month == end.AddDays(-1).Month)
                    {
                        one.ID = data.ID;
                        one.ErrorCount = data.ErrorCount.ToString().Trim();
                        one.TMIndex = Math.Round((decimal)data.TMIndex, 2) + "%";
                        one.DSRScore = data.DSRScore.ToString().Trim();
                        one.ResponseTime = data.ResponseTime.ToString().Trim();
                        one.JDResponseTime = data.JDResponseTime.ToString().Trim();
                        one.JDCustomerService = data.JDCustomerService.ToString().Trim();
                        one.CustomerComplaints = data.CustomerComplaints.ToString().Trim();
                        one.EvaluationPoints = data.EvaluationPoints.ToString().Trim();
                        one.IsFile = (bool)data.Type;
                    }
                    else
                    {
                        one.ID = 0;
                        one.ErrorCount = "";
                        one.TMIndex = "";
                        one.DSRScore = "";
                        one.ResponseTime = "";
                        one.JDResponseTime = "";
                        one.JDCustomerService = "";
                        one.CustomerComplaints = "";
                        one.EvaluationPoints = "";
                        one.IsFile = false;
                    }
                    all.Add(one);
                }
            }
            //根据项目名称和平台类型查询。
            //var xMProjectList = base.XMDSRService.GetXMDSRList(NickId, PlatformTypeId, Month);
            //分页
            var xMProjectPageList = new PagedList<XMAfterSalesDataAll>(all, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, xMProjectPageList, paramPageSize + 1);
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
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMScalpingApplication = e.Row.DataItem as XMAfterSalesDataAll;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('售后客服数据编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomerService/XMAfterSalesDataAdd.aspx?Id=" + xMScalpingApplication.ID + "&CustomerID=" + xMScalpingApplication .CustomerID+ "',500, 400, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }
                LinkButton lblDemandReturn = e.Row.FindControl("lblDemandReturn") as LinkButton;
                if (lblDemandReturn != null && lblDemandReturn.Text!="0")
                {
                    //开始日期
                    string beginDate = this.ddlBeginDate.Value.ToString();
                    //结束日期
                    string endDate = this.ddlEndDate.Value.ToString();
                    //DateTime begin = DateTime.Parse(beginDate);
                    //DateTime end = DateTime.Parse(endDate).AddDays(1); 
                    lblDemandReturn.OnClientClick = "return ShowWindowDetail('需求退货客户详细信息','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomerService/XMAfterSalesDataDetail.aspx?CustomerID=" + xMScalpingApplication.CustomerID + "&beginDate=" + beginDate + "&endDate=" + endDate + "&type=DemandReturn',1000, 400, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }

                LinkButton lblActualReturn = e.Row.FindControl("lblActualReturn") as LinkButton;
                if (lblActualReturn != null && lblActualReturn.Text != "0")
                {
                    //开始日期
                    string beginDate = this.ddlBeginDate.Value.ToString();
                    //结束日期
                    string endDate = this.ddlEndDate.Value.ToString();
                    //DateTime begin = DateTime.Parse(beginDate);
                    //DateTime end = DateTime.Parse(endDate).AddDays(1); 
                    lblActualReturn.OnClientClick = "return ShowWindowDetail('实际退货详细信息','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomerService/XMAfterSalesDataDetail.aspx?CustomerID=" + xMScalpingApplication.CustomerID + "&beginDate=" + beginDate + "&endDate=" + endDate + "&type=ActualReturn',1000, 400, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }

                LinkButton lblPersonalWorkload = e.Row.FindControl("lblPersonalWorkload") as LinkButton;
                if (lblPersonalWorkload != null && lblPersonalWorkload.Text != "0")
                {
                    //开始日期
                    string beginDate = this.ddlBeginDate.Value.ToString();
                    //结束日期
                    string endDate = this.ddlEndDate.Value.ToString();
                    //DateTime begin = DateTime.Parse(beginDate);
                    //DateTime end = DateTime.Parse(endDate).AddDays(1); 
                    lblPersonalWorkload.OnClientClick = "return ShowWindowDetail('个人工作量详细信息','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomerService/XMAfterSalesDataDetail.aspx?CustomerID=" + xMScalpingApplication.CustomerID + "&beginDate=" + beginDate + "&endDate=" + endDate + "&type=PersonalWorkload',1000, 400, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }

            }
        }

        //存档
        protected void btnFile_Click(object sender, EventArgs e)
        {
            //开始日期
            string beginDate = this.ddlBeginDate.Value.ToString();
            //结束日期
            string endDate = this.ddlEndDate.Value.ToString();

            if (string.IsNullOrEmpty(beginDate) || string.IsNullOrEmpty(endDate))
            {
                base.ShowMessage("请先选择开始日期与结束日期！");
                return;
            }

            DateTime begin = DateTime.Parse(beginDate);
            DateTime end = DateTime.Parse(endDate).AddDays(1);
            if (begin >= end)
            {
                base.ShowMessage("开始日期不能大于结束日期，请重新选择！");
                return;
            }
            if (!(begin.Year == end.Year && begin.Month == end.AddDays(-1).Month))
            {
                base.ShowMessage("请不要跨越月份查询！");
                return;
            }
            string Month = begin.Year.ToString() +"-"+ begin.Month.ToString().PadLeft(2, '0');
            var list = base.XMAfterSalesDataService.GetXMAfterSalesDataListByMonth(Month);
            if (list != null && list.Count > 0)
            {
                foreach (XMAfterSalesData item in list)
                {
                    item.Type = true;
                    item.UpdateID = HozestERPContext.Current.User.CustomerID;
                    item.UpdateTime = DateTime.Now;
                    base.XMAfterSalesDataService.UpdateXMAfterSalesData(item);
                }
                base.ShowMessage("存档成功！");
            }
        }

        /// <summary>
        /// 删除行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        /// <summary>
        /// 删除行数据之前执行的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

    }

}