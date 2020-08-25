using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageBusiness
{
    public partial class NotShippedSales : BaseAdministrationPage, ISearchPage
    {
        public string TotalCount = "0";
        public string TotalCost = "0";
        public string TotalPercentage = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtPayBegin.Value = DateTime.Now.ToString("yyyy-MM") + "-01";
                this.txtPayEnd.Value = DateTime.Now.ToString("yyyy-MM-dd");
                this.Master.PageSize = 50;
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string Begin = this.txtBegin.Value;
            string End = this.txtEnd.Value;
            string PayBegin = this.txtPayBegin.Value;
            string PayEnd = this.txtPayEnd.Value;
            string ProjectId = Request.Form["SelProjectId"];
            string NickId = Request.Form["SelNickList"];
            int WaitNotice = this.chkWaitNotice.Checked == true ? 1 : 0;//等通知
            int Urgent = this.chkUrgent.Checked == true ? 1 : 0;//加急
            int CanDeliver = this.chkCanDeliver.Checked == true ? 1 : 0;//能发就发
            int AppointDeliveryTime = this.chkAppointDeliveryTime.Checked == true ? 1 : 0;//预约发货时间
            int Remarks = this.chkRemarks.Checked == true ? 1 : 0;     //异常备注

            List<ProductSalesData> modifylist = new List<ProductSalesData>();
            List<ProductSalesData> List = new List<ProductSalesData>();
            List<int?> NickIdList = new List<int?>();
            int no = 0;
            int? total = 0;

            if (PayBegin == "" || PayEnd == "")
            {
                base.ShowMessage("付款开始时间和结束时间不能为空！");
                Session["ProductSalesDataList"] = null;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "NotShippedSales", "dataBind('" + ProjectId + "','" + NickId + "')", true);//ajax
                this.gvContent.DataSource = null;
                this.gvContent.DataBind();
                return;
            }

            DateTime PayBeginDate = DateTime.Parse(PayBegin);
            DateTime PayEndDate = DateTime.Parse(PayEnd).AddDays(1).AddSeconds(-1);

            if (AppointDeliveryTime == 1 && (Begin == "" || End == ""))
            {
                base.ShowMessage("预约发货开始时间和结束时间不能为空！");
                Session["ProductSalesDataList"] = null;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "NotShippedSales", "dataBind('" + ProjectId + "','" + NickId + "')", true);//ajax
                this.gvContent.DataSource = null;
                this.gvContent.DataBind();
                return;
            }

            if (NickId == "-1")
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickList("", 1, Convert.ToInt32(ProjectId));
                foreach (XMNick info in nickList)
                {
                    NickIdList.Add(info.nick_id);
                }
            }
            else if (NickId == "99")
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", 1, Convert.ToInt32(ProjectId), HozestERPContext.Current.User.CustomerID, 0);
                foreach (XMNick info in nickList)
                {
                    NickIdList.Add(info.nick_id);
                }
            }
            else
            {
                NickIdList.Add(int.Parse(NickId));
            }

            var list = base.XMOrderInfoProductDetailsService.GetNotShippedSales(Begin, End, int.Parse(ProjectId), NickIdList, null, WaitNotice, Urgent, CanDeliver, AppointDeliveryTime, Remarks, PayBeginDate, PayEndDate);
            if (list != null)
            {
                foreach (var info in list)
                {
                    if (info.ProductNum > 1)
                    {
                        int ProductNum = (int)info.ProductNum;
                        info.ProductNum = 1;
                        info.FactoryPrice = info.FactoryPrice / ProductNum;
                        for (int i = 0; i < ProductNum; i++)
                        {
                            modifylist.Add(info);
                        }
                    }
                    else if (info.ProductNum == 1)
                    {
                        modifylist.Add(info);
                    }
                }

                Session["ProductSalesDataList"] = modifylist;
                total = modifylist.Sum(x => x.ProductNum == null ? 0 : x.ProductNum);
                TotalCount = total.ToString();
            }

            var ProductSalesList = base.XMOrderInfoProductDetailsService.GetNotShippedSales(Begin, End, int.Parse(ProjectId), NickIdList, modifylist, WaitNotice, Urgent, CanDeliver, AppointDeliveryTime, Remarks, PayBeginDate, PayEndDate);
            var Group = ProductSalesList.GroupBy(x => new { x.ProductName }).ToList();
            foreach (var Info in Group)
            {
                no++;
                decimal Cost = 0;
                StringBuilder table = new StringBuilder();
                var InfoList = Info.OrderByDescending(x => x.ProductNum).ToList<ProductSalesData>();
                int InfoCount = (int)InfoList.Sum(x => x.ProductNum);

                foreach (var info in InfoList)
                {
                    string Proportion = Math.Round((decimal.Parse(info.ProductNum.ToString()) * 100 / decimal.Parse(InfoCount.ToString())), 2).ToString() + " %";
                    decimal cost = (decimal)info.ProductNum * decimal.Parse(info.FactoryPrice.ToString());
                    cost = Math.Round(cost, 2);
                    table.Append("<tr>");
                    table.Append("<td style='text-align:center;'>").Append(info.Manufacturers).Append("</td>");
                    table.Append("<td style='text-align:center;'>").Append(info.Specifications).Append("</td>");
                    table.Append("<td style='text-align:center;'>").Append(info.FactoryPrice).Append("</td>");
                    table.Append("<td style='text-align:center;'>").Append(info.ProductNum).Append("</td>");
                    table.Append("<td style='text-align:center;'>").Append(cost).Append("</td>");
                    table.Append("<td style='text-align:center;'>").Append(Proportion).Append("</td>");
                    table.Append("</tr>");
                    Cost += cost;
                }

                ProductSalesData one = new ProductSalesData();
                one.ID = no;
                one.ProductName = InfoList[0].ProductName;
                one.Count = InfoCount;
                one.Cost = Cost.ToString();
                one.CountProportion = Math.Round((decimal.Parse(one.Count.ToString()) * 100 / decimal.Parse(total.ToString())), 2).ToString() + " %";
                one.Table = table.ToString();
                List.Add(one);

                TotalCost = (decimal.Parse(TotalCost) + Cost).ToString();
                TotalPercentage = (decimal.Parse(TotalPercentage.Replace(" %", "")) + decimal.Parse(one.CountProportion.Replace(" %", ""))).ToString() + " %";
            }

            if (List != null && List.Count > 0)
            {
                List = List.OrderByDescending(x => x.Count).ToList();
            }
            //分页
            var PageList = new PagedList<ProductSalesData>(List, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.gvContent, PageList, paramPageSize + 1);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "NotShippedSales", "dataBind('" + ProjectId + "','" + NickId + "')", true);//ajax
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string Begin = this.txtBegin.Value;
                    string End = this.txtEnd.Value;
                    string PayBegin = this.txtPayBegin.Value;
                    string PayEnd = this.txtPayEnd.Value;
                    string ProjectId = Request.Form["SelProjectId"];
                    string NickId = Request.Form["SelNickList"];
                    int WaitNotice = this.chkWaitNotice.Checked == true ? 1 : 0;//等通知
                    int Urgent = this.chkUrgent.Checked == true ? 1 : 0;//加急
                    int CanDeliver = this.chkCanDeliver.Checked == true ? 1 : 0;//能发就发
                    int AppointDeliveryTime = this.chkAppointDeliveryTime.Checked == true ? 1 : 0;//预约发货时间
                    int Remarks = this.chkRemarks.Checked == true ? 1 : 0;     //异常备注

                    if (PayBegin == "" || PayEnd == "")
                    {
                        base.ShowMessage("付款开始时间和结束时间不能为空！");
                        Session["ProductSalesDataList"] = null;
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "NotShippedSales", "dataBind('" + ProjectId + "','" + NickId + "')", true);//ajax
                        this.gvContent.DataSource = null;
                        this.gvContent.DataBind();
                        return;
                    }

                    DateTime PayBeginDate = DateTime.Parse(PayBegin);
                    DateTime PayEndDate = DateTime.Parse(PayEnd).AddDays(1).AddSeconds(-1);

                    if (AppointDeliveryTime == 1 && (Begin == "" || End == ""))
                    {
                        base.ShowMessage("预约发货开始时间和结束时间不能为空！");
                        Session["ProductSalesDataList"] = null;
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "NotShippedSales", "dataBind('" + ProjectId + "','" + NickId + "')", true);//ajax
                        this.gvContent.DataSource = null;
                        this.gvContent.DataBind();
                        return;
                    }

                    List<ProductSalesData> modifylist = new List<ProductSalesData>();
                    List<int?> NickIdList = new List<int?>();

                    if (NickId == "-1")
                    {
                        var nickList = base.XMOrderInfoAPIService.GetXMNickList("", 1, Convert.ToInt32(ProjectId));
                        foreach (XMNick info in nickList)
                        {
                            NickIdList.Add(info.nick_id);
                        }
                    }
                    else if (NickId == "99")
                    {
                        var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", 1, Convert.ToInt32(ProjectId), HozestERPContext.Current.User.CustomerID, 0);
                        foreach (XMNick info in nickList)
                        {
                            NickIdList.Add(info.nick_id);
                        }
                    }
                    else
                    {
                        NickIdList.Add(int.Parse(NickId));
                    }

                    //string fileName = string.Format("NotShippedSales_{0}_{1}.xls", DateTime.Now.ToString("yyMMddHHmmssff"), CommonHelper.GenerateRandomDigitCode(4));
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\NotShippedSalesData", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "\\" + fileName;

                    var list = base.XMOrderInfoProductDetailsService.GetNotShippedSales(Begin, End, int.Parse(ProjectId), NickIdList, null, WaitNotice, Urgent, CanDeliver, AppointDeliveryTime, Remarks, PayBeginDate, PayEndDate);
                    //if (list != null)
                    //{
                    //    foreach (var info in list)
                    //    {
                    //        if (info.ProductNum > 1)
                    //        {
                    //            int ProductNum = (int)info.ProductNum;
                    //            info.ProductNum = 1;
                    //            info.FactoryPrice = info.FactoryPrice / ProductNum;
                    //            for (int i = 0; i < ProductNum; i++)
                    //            {
                    //                modifylist.Add(info);
                    //            }
                    //        }
                    //        else if (info.ProductNum == 1)
                    //        {
                    //            modifylist.Add(info);
                    //        }
                    //    }
                    //}
                    //var ProductSalesList = base.XMOrderInfoProductDetailsService.GetNotShippedSales(Begin, End, int.Parse(ProjectId), NickIdList, modifylist, WaitNotice, Urgent, CanDeliver, AppointDeliveryTime, Remarks, PayBeginDate, PayEndDate);
                    base.ExportManager.ExportProductSalesNotDeliXls(filePath, list);

                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }
    }
}