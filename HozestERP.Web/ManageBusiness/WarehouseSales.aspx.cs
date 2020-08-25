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
    public partial class WarehouseSales : BaseAdministrationPage, ISearchPage
    {
        public string TotalCount = "0";
        public string TotalPercentage = "0 %";
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

            var list = base.XMOrderInfoProductDetailsService.GetWarehouseSales(BeginDate, EndDate, int.Parse(ProjectId), NickIdList, WarehouseID, ProvinceNameID);
            if (list != null)
            {
                decimal totalCount = decimal.Parse(list.Sum(x => x.ProductNum).ToString());
                decimal totalPercentage = 0;
                foreach (var Info in list)
                {
                    decimal percentage = 0;
                    Info.ProductNum = Info.ProductNum == null ? 0 : Info.ProductNum;
                    Info.Count = Info.ProductNum;
                    if (totalCount != 0)
                    {
                        percentage = Math.Round(Math.Round(decimal.Parse(Info.ProductNum == null ? "0" : Info.ProductNum.ToString()) / totalCount, 4) * 100,2);
                        totalPercentage += percentage;
                    }
                    Info.CountProportion = percentage.ToString() + " %";
                }
                TotalCount = totalCount.ToString();
                TotalPercentage = totalPercentage.ToString() + " %";

                Session["ProductSalesDataList"] = list;
            }

            //分页
            var PageList = new PagedList<ProductSalesData>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.gvContent, PageList, paramPageSize + 1);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "WarehouseSales", "dataBind('" + ProjectId + "','" + NickId + "','" + WarehouseID + "','" + ProvinceNameID + "')", true);//ajax
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }
    }
}