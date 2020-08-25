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
    public partial class ProductSales : BaseAdministrationPage, ISearchPage
    {
        public string TotalCount = "0";
        public string TotalCost = "0";
        public string TotalPercentage = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtBegin.Value = DateTime.Now.ToString("yyyy-MM") + "-01";
                this.txtEnd.Value = DateTime.Now.ToString("yyyy-MM-dd");
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
            string ProjectId = Request.Form["SelProjectId"];
            string NickId = Request.Form["SelNickList"];
            int WarehouseID = int.Parse(Request.Form["SelWarehouse"]);
            int ProvinceNameID = int.Parse(Request.Form["SelProvinceName"]);

            List<ProductSalesData> modifylist = new List<ProductSalesData>();
            List<ProductSalesData> List = new List<ProductSalesData>();
            List<int?> NickIdList = new List<int?>();
            DateTime a = DateTime.Now;
            int no = 0;
            int? total = 0;

            if (!DateTime.TryParse(Begin, out a) || !DateTime.TryParse(End, out a))
            {
                base.ShowMessage("开始时间或结束时间格式错误！");
                return;
            }

            DateTime BeginDate = DateTime.Parse(Begin);
            DateTime EndDate = DateTime.Parse(End).AddDays(1).AddSeconds(-1);

            if (BeginDate > EndDate)
            {
                base.ShowMessage("开始时间不能大于结束时间！");
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

            var list = base.XMOrderInfoProductDetailsService.GetProductSales(BeginDate, EndDate, int.Parse(ProjectId), NickIdList, null, WarehouseID, ProvinceNameID);
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

            var ProductSalesList = base.XMOrderInfoProductDetailsService.GetProductSales(BeginDate, EndDate, int.Parse(ProjectId), NickIdList, modifylist, WarehouseID, ProvinceNameID);

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
                    table.Append("<td style='text-align:center;'>").Append(Math.Round((decimal)info.FactoryPrice, 2)).Append("</td>");
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
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ProductSales", "dataBind('" + ProjectId + "','" + NickId + "','" + WarehouseID + "','" + ProvinceNameID + "')", true);//ajax
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
                    string ProjectId = Request.Form["SelProjectId"];
                    string NickId = Request.Form["SelNickList"];
                    int WarehouseID = int.Parse(Request.Form["SelWarehouse"]);
                    int ProvinceNameID = int.Parse(Request.Form["SelProvinceName"]);
                    List<ProductSalesData> modifylist = new List<ProductSalesData>();
                    List<int?> NickIdList = new List<int?>();
                    DateTime a = DateTime.Now;

                    if (!DateTime.TryParse(Begin, out a) || !DateTime.TryParse(End, out a))
                    {
                        base.ShowMessage("开始时间或结束时间格式错误！");
                        return;
                    }

                    DateTime BeginDate = DateTime.Parse(Begin);
                    DateTime EndDate = DateTime.Parse(End).AddDays(1).AddSeconds(-1);

                    if (BeginDate > EndDate)
                    {
                        base.ShowMessage("开始时间不能大于结束时间！");
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

                    string fileName = string.Format("ProductSales_{0}_{1}.xls", DateTime.Now.ToString("yyMMddHHmmssff"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\ProductSalesData", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;

                    var list = base.XMOrderInfoProductDetailsService.GetProductSales(BeginDate, EndDate, int.Parse(ProjectId), NickIdList, null, WarehouseID, ProvinceNameID);
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
                    }
                    var ProductSalesList = base.XMOrderInfoProductDetailsService.GetProductSales(BeginDate, EndDate, int.Parse(ProjectId), NickIdList, modifylist, WarehouseID, ProvinceNameID);
                    base.ExportManager.ExportProductSalesXls(filePath, ProductSalesList);

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