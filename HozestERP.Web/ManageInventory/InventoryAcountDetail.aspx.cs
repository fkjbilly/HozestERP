using System;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageInventory
{
    public partial class InventoryAcountDetail : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
            }
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            DateTime date = DateTime.Now;
            if (Begin != "" || End != "")
            {
                if (Begin == "" || End == "" || !DateTime.TryParse(Begin, out date) || !DateTime.TryParse(End, out date))
                {
                    base.ShowMessage("日期格式不正确！");
                    return;
                }
            }
            if (End != "")
            {
                End = DateTime.Parse(End).AddDays(1).ToString("yyyy-MM-dd");
            }

            var list = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(Begin, End, this.WareHousesID, this.PlatformMerchantCode);
            var pageList = new PagedList<XMInventoryLedgerDetail>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvInventoryLedgerDetail, pageList);
        }

        public string CustomerName(string customerID)
        {
            string name = "";
            var customer = base.CustomerInfoService.GetCustomerInfoByID(Convert.ToInt16(customerID));
            if (customer != null)
            {
                name = customer.FullName;
            }
            return name;
        }
        /// <summary>
        /// 或去业务类型
        /// </summary>
        /// <param name="RefType"></param>
        /// <returns></returns>
        public string GetRefType(string RefType)
        {
            string type = "";
            switch (RefType)
            {
                case "1":
                    type = "采购入库";
                    break;
                case "1000":
                    type = "采购退货";
                    break;
                case "1002":
                    type = "销售出库";
                    break;
                case "1004":
                    type = "销售退货入库";
                    break;
                case "1008":
                    type = "库存盘点-盘盈入库";
                    break;
                case "1010":
                    type = "库存盘点-盘亏出库";
                    break;
                case "1011":
                    type = "调拨出库";
                    break;
                case "1012":
                    type = "调拨入库";
                    break;
            }
            return type;
        }


        protected void grdvInventoryLedgerDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
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
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }


        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        public int WareHousesID
        {
            get
            {
                return CommonHelper.QueryStringInt("WarehouseId");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PlatformMerchantCode
        {
            get { return CommonHelper.QueryString("PlatformMerchantCode"); }
        }
    }
}