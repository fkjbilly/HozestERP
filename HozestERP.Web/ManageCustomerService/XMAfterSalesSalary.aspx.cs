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
using System.Text;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMAfterSalesSalary : BaseAdministrationPage, ISearchPage
    {
        public List<XMCustomerServiceKPI> ExportXMCustomerServiceKPIList;
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
            #region 级别
            this.ddlRank.Items.Clear();
            var codePlatformTypeList = base.XMCustomerServiceLevelService.GetXMCustomerServiceLevelList("");
            this.ddlRank.DataSource = codePlatformTypeList;
            this.ddlRank.DataTextField = "RankName";
            this.ddlRank.DataValueField = "Id";
            this.ddlRank.DataBind();
            this.ddlRank.Items.Insert(0, new ListItem("", "-1"));
            #endregion

            #region 组别
            string DepCode = "QC1403-3,QC1403-4,QC1506-2";//售后
            this.ddlGroupID.Items.Clear();
            var CoustomerServiceGroup = base.XMCustomerServiceLevelService.GetXMCoustomerServiceGroupList(DepCode);
            this.ddlGroupID.DataSource = CoustomerServiceGroup;
            this.ddlGroupID.DataTextField = "DepName";
            this.ddlGroupID.DataValueField = "DepartmentID";
            this.ddlGroupID.DataBind();
            this.ddlGroupID.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion

            #region 默认月份
            //日期默认为本月
            this.ddlMonth.Value = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0');
            #endregion
        }
        public void BindGrid(int paramPageIndex, int paramPageSize)//type为1时表示执行导出操作
        {
            try
            {
                //月份
                string Month = this.ddlMonth.Value.ToString().Trim();

                if (string.IsNullOrEmpty(Month))
                {
                    base.ShowMessage("请先选择月份！");
                    return;
                }

                //组别
                int groupId = int.Parse(this.ddlGroupID.SelectedValue);
                //姓名
                string Name = this.ddlName.Text.ToString();
                //级别
                string RankName = this.ddlRank.SelectedItem.Text.Trim();
                //客服部DepCode
                string DepCode = "QC1403-3,QC1403-4,QC1506-2";

                //所有售后客服
                var xMProjectListAll = base.CustomerInfoService.GetCustomerInfoPreList(groupId, "", DepCode, "");
                //组内平均工作量
                List<XMAfterSalesDataAll> average = new List<XMAfterSalesDataAll>();
                #region 组内平均工作量
                List<XMAfterSalesDataAll> all = new List<XMAfterSalesDataAll>();
                foreach (XMPreSalesSalary user in xMProjectListAll)
                {
                    XMAfterSalesDataAll ASalesDataAll = GetAfterSalesData(user, Month);
                    all.Add(ASalesDataAll);
                }
                IEnumerable<IGrouping<int, XMAfterSalesDataAll>> alldata = all.GroupBy(x => x.GroupID);
                foreach (IGrouping<int, XMAfterSalesDataAll> info in alldata)
                {
                    XMAfterSalesDataAll group = new XMAfterSalesDataAll();
                    List<XMAfterSalesDataAll> sl = info.ToList<XMAfterSalesDataAll>();//分组后的集合
                    int total = 0;
                    foreach (XMAfterSalesDataAll item in sl)
                    {
                        group.GroupID = item.GroupID;
                        total = total + item.PersonalWorkload;
                    }
                    group.AverageWorkload = Math.Round((double)total / (double)(sl.Count()), 2);
                    average.Add(group);//各组平均工作量
                }
                #endregion

                //根据条件查询客服信息
                var xMProjectList = base.CustomerInfoService.GetCustomerInfoPreList(groupId, Name, DepCode, RankName);
                List<XMCustomerServiceKPI> list = new List<XMCustomerServiceKPI>();
                if (xMProjectList != null && xMProjectList.Count > 0)
                {
                    foreach (XMPreSalesSalary user in xMProjectList)
                    {
                        XMAfterSalesDataAll ASalesDataAll = GetAfterSalesData(user, Month);
                        XMCustomerServiceKPI kpi = new XMCustomerServiceKPI();
                        kpi.ID = user.ID;
                        kpi.GroupID = user.GroupID;
                        kpi.Group = user.Group;
                        kpi.CustomerID = user.CustomerID;
                        kpi.Name = user.Name;
                        kpi.RankID = user.RankID;
                        kpi.RankName = user.RankName;
                        kpi.BasicSalary = user.BasicSalary;
                        kpi.BonusBase = user.BonusBase;
                        if (kpi.RankID == null)
                        {
                            base.ShowMessage(kpi.Group +" "+ kpi.Name + "未设置级别，请先设置客服级别！");
                            return;
                        }
                        StringBuilder sb = new StringBuilder();
                        if (ASalesDataAll.ExistXMAfterSalesData)
                        {
                            kpi = GetKPIScore(kpi, ASalesDataAll, average);

                            double Percent = 0;

                            #region 奖金基准百分比
                            if (double.Parse(kpi.KPIScore) >= 110)
                            {
                                Percent = 1.2;
                            }
                            else if (double.Parse(kpi.KPIScore) >= 100)
                            {
                                Percent = 1.1;
                            }
                            else if (double.Parse(kpi.KPIScore) >= 90)
                            {
                                Percent = 1;
                            }
                            else if (double.Parse(kpi.KPIScore) >= 80)
                            {
                                Percent = 0.8;
                            }
                            else if (double.Parse(kpi.KPIScore) >= 70)
                            {
                                Percent = 0.7;
                            }
                            else if (double.Parse(kpi.KPIScore) >= 60)
                            {
                                Percent = 0.6;
                            }
                            else
                            {
                                Percent = 0;
                            }
                            kpi.Percent = Percent.ToString();
                            #endregion

                            if (kpi.BasicSalary == null && kpi.BonusBase == null)
                            {
                                kpi.BasicSalary = 0;
                                kpi.BonusBase = 0;
                                kpi.RealBonus = "0";
                                kpi.Total = 0;
                            }
                            else
                            {
                                kpi.RealBonus = (double.Parse(kpi.BonusBase.ToString()) * Percent).ToString();
                                kpi.Total = double.Parse(kpi.BasicSalary.ToString()) + double.Parse(kpi.BonusBase.ToString()) * Percent;
                            }

                            sb.Append("<td style='width: 9%;text-align:center;'>" + kpi.ReturnRate + "</td>");
                            sb.Append("<td style='width: 9%;text-align:center;'><font style='font-weight:bold;' color='red'>" + kpi.ReturnRateS + "</font></td>");
                            sb.Append("<td style='width: 9%;text-align:center;'>" + kpi.GroupAverage + "</td>");
                            sb.Append("<td style='width: 9%;text-align:center;'>" + kpi.GroupAverageP + "</td>");
                            sb.Append("<td style='width: 6%;text-align:center;'><font style='font-weight:bold;' color='red'>" + kpi.GroupAverageS + "</font></td>");
                            sb.Append("<td style='width: 8%;text-align:center;'><font style='font-weight:bold;' color='red'>" + kpi.ResponseTimeS + "</font></td>");
                            sb.Append("<td style='width: 6%;text-align:center;'><font style='font-weight:bold;' color='red'>" + kpi.DSRS + "</font></td>");
                            sb.Append("<td style='width: 8%;text-align:center;'><font style='font-weight:bold;' color='red'>" + kpi.JingdongSaleS + "</font></td>");
                            sb.Append("<td style='width: 8%;text-align:center;'><font style='font-weight:bold;' color='red'>" + kpi.AftermarketErrorS + "</font></td>");
                            sb.Append("<td style='width: 12%;text-align:center;'><font style='font-weight:bold;' color='red'>" + kpi.TMIndexS + "</font></td>");
                            sb.Append("<td style='width: 8%;text-align:center;'><font style='font-weight:bold;' color='red'>" + kpi.CustomerComplaintsS + "</font></td>");
                            sb.Append("<td style='width: 8%;text-align:center;'><font style='font-weight:bold;' color='red'>" + kpi.EvaluationPointsS + "</font></td>");
                        }
                        else
                        {
                            kpi.KPIScore = "数据不足，无法计算，请先填写“售后客服数据”！";
                            kpi.Total = 0;
                            sb.Append("<td colspan='12' style='width: 8%;text-align:center;'>此售后客服该月数据未填写，无法计算KPI得分，无法计算薪酬！</td>");
                        }
                        sb.Append("</tr>");
                        kpi.tabKPI = sb.ToString();
                        list.Add(kpi);
                    }
                    ExportXMCustomerServiceKPIList = list;
                }
                var xMProjectPageList = new PagedList<XMCustomerServiceKPI>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                this.Master.BindData(this.grdvClients, xMProjectPageList, paramPageSize + 1);
            }
            catch (Exception ex)
            {
                base.ShowMessage("查询出错！");
            }
        }
        #endregion

        /// <summary>
        /// 得到KPI得分
        /// </summary>
        public XMCustomerServiceKPI GetKPIScore(XMCustomerServiceKPI KPI, XMAfterSalesDataAll ASalesDataAll, List<XMAfterSalesDataAll> average)
        {
            #region 退货挽回率
            if (ASalesDataAll.ReturnRate != "0 %")
            {
                double a = double.Parse(ASalesDataAll.ReturnRate.Replace("%", "").Trim()) / 100;
                KPI.ReturnRate = Math.Round((a - 0.8) / 0.05, 2);
            }
            else
            {
                KPI.ReturnRate = 0;
            }
            if (KPI.RankName.IndexOf("初级") != -1 || KPI.RankName.IndexOf("中级") != -1)
            {
                if (KPI.ReturnRate > 0)
                {
                    KPI.ReturnRateS = KPI.ReturnRate * 2 + 20;
                }
                else
                {
                    KPI.ReturnRateS = KPI.ReturnRate * 1 + 20;
                }
            }
            else if (KPI.RankName.IndexOf("高级") != -1 || KPI.RankName.IndexOf("资深") != -1 || KPI.RankName.IndexOf("专家") != -1)
            {
                if (KPI.ReturnRate > 0)
                {
                    KPI.ReturnRateS = KPI.ReturnRate * 1 + 20;
                }
                else
                {
                    KPI.ReturnRateS = KPI.ReturnRate * 2 + 20;
                }
            }
            if (KPI.ReturnRateS > 30)
            {
                KPI.ReturnRateS = 30;
            }
            else if (KPI.ReturnRateS < 0)
            {
                KPI.ReturnRateS = 0;
            }
            #endregion

            #region 组内平均值
            foreach (XMAfterSalesDataAll item in average)
            {
                if (item.GroupID == KPI.GroupID)
                {
                    KPI.GroupAverage = item.AverageWorkload;
                    break;
                }
            }

            if (KPI.GroupAverage != 0)
            {
                KPI.GroupAverageP = (Math.Round((double)ASalesDataAll.PersonalWorkload * 100 / KPI.GroupAverage)).ToString() + " %";
            }
            else
            {
                KPI.GroupAverageP = "0 %";
            }

            if (KPI.GroupAverage != 0)
            {
                double b = Math.Round((double)ASalesDataAll.PersonalWorkload / KPI.GroupAverage);
                if (KPI.RankName.IndexOf("初级") != -1)
                {
                    double one = (b - 0.7) / 0.05;
                    KPI.GroupAverageS = 20 + one * 1;
                }
                else if (KPI.RankName.IndexOf("中级") != -1)
                {
                    double one = (b - 0.9) / 0.05;
                    KPI.GroupAverageS = 20 + one * 1;
                }
                else if (KPI.RankName.IndexOf("高级") != -1)
                {
                    double one = (b - 1.1) / 0.05;
                    if (one > 0)
                    {
                        KPI.GroupAverageS = 20 + one * 1;
                    }
                    else
                    {
                        KPI.GroupAverageS = 20 + one * 2;
                    }
                }
                else if (KPI.RankName.IndexOf("资深") != -1)
                {
                    double one = (b - 1.3) / 0.05;
                    if (one > 0)
                    {
                        KPI.GroupAverageS = 20 + one * 1;
                    }
                    else
                    {
                        KPI.GroupAverageS = 20 + one * 2;
                    }
                }
                else if (KPI.RankName.IndexOf("专家") != -1)
                {
                    double one = (b - 1.5) / 0.05;
                    if (one > 0)
                    {
                        KPI.GroupAverageS = 20 + one * 1;
                    }
                    else
                    {
                        KPI.GroupAverageS = 20 + one * 2;
                    }
                }
            }
            else 
            {
                KPI.GroupAverageS = 20;
            }

            if (KPI.GroupAverageS > 30)
            {
                KPI.GroupAverageS = 30;
            }
            else if (KPI.GroupAverageS < 0)
            {
                KPI.GroupAverageS = 0;
            }
            #endregion

            #region 售后客服出错
            if (KPI.RankName.IndexOf("初级") != -1)
            {
                KPI.AftermarketErrorS = 20 - int.Parse(ASalesDataAll.ErrorCount) * 1;
            }
            else if (KPI.RankName.IndexOf("中级") != -1)
            {
                KPI.AftermarketErrorS = 20 - int.Parse(ASalesDataAll.ErrorCount) * 3;
            }
            else if (KPI.RankName.IndexOf("高级") != -1)
            {
                KPI.AftermarketErrorS = 20 - int.Parse(ASalesDataAll.ErrorCount) * 5;
            }
            else if (KPI.RankName.IndexOf("资深") != -1)
            {
                KPI.AftermarketErrorS = 20 - int.Parse(ASalesDataAll.ErrorCount) * 5;
            }
            else if (KPI.RankName.IndexOf("专家") != -1)
            {
                KPI.AftermarketErrorS = 20 - int.Parse(ASalesDataAll.ErrorCount) * 6;
            }
            else if (KPI.AftermarketErrorS < 0)
            {
                KPI.AftermarketErrorS = 0;
            }
            #endregion

            #region 天猫售后综合指数
            if (double.Parse(ASalesDataAll.TMIndex.Replace("%","").Trim()) <= 10)
            {
                KPI.TMIndexS = -10;
            }
            else
            {
                KPI.TMIndexS = 0;
            }
            #endregion

            #region DSR指标
            KPI.DSRS = Math.Round(double.Parse(ASalesDataAll.DSRScore), 2);
            if (KPI.DSRS > 15)
            {
                KPI.DSRS = 15;
            }
            else if (KPI.DSRS < 0)
            {
                KPI.DSRS = 0;
            }
            #endregion

            #region 响应时间
            KPI.ResponseTimeS = 10;
            double Time = double.Parse(ASalesDataAll.ResponseTime);
            double JDTime = double.Parse(ASalesDataAll.JDResponseTime);
            double time = (Time - 30) / (30 * 30 * 0.1);
            double jdtime = (JDTime - 30) / (30 * 30 * 0.1);
            if (time > 0)
            {
                KPI.ResponseTimeS = -2 * time + KPI.ResponseTimeS;
            }
            if (JDTime > 0)
            {
                KPI.ResponseTimeS = -2 * jdtime + KPI.ResponseTimeS;
            }
            if (KPI.ResponseTimeS < 0)
            {
                KPI.ResponseTimeS = 0;
            }
            KPI.ResponseTimeS = Math.Round(KPI.ResponseTimeS, 2);
            #endregion

            #region 京东售后
            KPI.JingdongSaleS = 10;
            KPI.JingdongSaleS = KPI.JingdongSaleS - 5 * double.Parse(ASalesDataAll.JDCustomerService);
            if (KPI.JingdongSaleS < 0)
            {
                KPI.JingdongSaleS = 0;
            }
            #endregion

            #region 客户意见处理
            KPI.CustomerComplaintsS = 10;
            KPI.CustomerComplaintsS = KPI.CustomerComplaintsS - 5 * int.Parse(ASalesDataAll.CustomerComplaints);
            if (KPI.CustomerComplaintsS < 0)
            {
                KPI.CustomerComplaintsS = 0;
            }
            #endregion

            #region 评价内容加分
            KPI.EvaluationPointsS = 0;
            KPI.EvaluationPointsS = KPI.EvaluationPointsS + 5 * (double.Parse(ASalesDataAll.EvaluationPoints) / 10);
            if (KPI.EvaluationPointsS > 10)
            {
                KPI.EvaluationPointsS = 10;
            }
            #endregion

            //KPI总得分
            KPI.KPIScore = (KPI.ReturnRateS + KPI.GroupAverageS + KPI.AftermarketErrorS + KPI.TMIndexS + KPI.DSRS + KPI.ResponseTimeS
                + KPI.JingdongSaleS + KPI.CustomerComplaintsS + KPI.EvaluationPointsS).ToString();

            return KPI;
        }

        /// <summary>
        /// 得到月售后数据
        /// </summary>
        public XMAfterSalesDataAll GetAfterSalesData(XMPreSalesSalary user, string Month)
        {
            string[] year_month = Month.Split('-');
            DateTime begin = DateTime.Parse(Month + "-01");
            DateTime end = DateTime.Parse(Month + "-" + (DateTime.DaysInMonth(int.Parse(year_month[0]), int.Parse(year_month[1]))).ToString());
            XMAfterSalesDataAll one = new XMAfterSalesDataAll();
            one.CustomerID = (int)user.CustomerID;
            one.CustomerName = user.Name;
            one.GroupID = (int)user.GroupID;
            one.GroupName = user.Group;
            List<QuestionDetailed_Result> PersonalWorkload = base.XMAfterSalesDataService.GetXMAfterSalesDataByPersonalWorkload(begin, end, one.CustomerID);
            one.PersonalWorkload = PersonalWorkload.Count;
            List<QuestionDetailed_Result> DemandReturnCount = PersonalWorkload.Where(p => p.IsReturns == true).ToList();
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
            List<QuestionDetailed_Result> ActualReturnCount = PersonalWorkload.Where(p => p.ResultsId == ReturnID).ToList();
            one.ActualReturn = ActualReturnCount.Count();

            if (one.DemandReturn != 0)
            {
                one.ReturnRate = (Math.Round((Convert.ToDouble(one.DemandReturn - one.ActualReturn) * 100 / Convert.ToDouble(one.DemandReturn)), 2)).ToString() + " %";
            }
            else
            {
                one.ReturnRate = "0 %";
            }

            string date = begin.Year.ToString() + "-" + begin.Month.ToString().PadLeft(2, '0');
            XMAfterSalesData data = base.XMAfterSalesDataService.GetXMAfterSalesDataInfoByMonth(Month, one.CustomerID);
            if (data != null)
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
                one.ExistXMAfterSalesData = true;
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
                one.ExistXMAfterSalesData = false;
            }
            return one;
        }

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

        #region
        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
        /// <summary>
        /// 编辑行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        /// <summary>
        /// 更新行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        }
        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }
        #endregion

        //导出明细
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = string.Format("AfterSalesSalary_{0}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                string filePath = string.Format("{0}Upload\\AfterSalesSalary", HttpContext.Current.Request.PhysicalApplicationPath);
                if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = filePath + "//" + fileName;
                this.BindGrid(1, Master.PageSize);
                if (ExportXMCustomerServiceKPIList != null && ExportXMCustomerServiceKPIList.Count > 0)
                {
                    base.ExportManager.ExportAfterSalesSalaryXls(filePath, ExportXMCustomerServiceKPIList);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                    ExportXMCustomerServiceKPIList = null;
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