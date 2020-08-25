using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderInfoOperatingRecords : BaseAdministrationPage, ISearchPage
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
        }

        public void Face_Init()
        {
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var propertyName = PropertyName(this.txtPropertyName.Text.Trim());
            this.Master.BindData(this.grdvClients, base.XMOrderInfoOperatingRecordService.SearchXMOrderInfoOperatingRecord(this.XMOrderInfoID, propertyName, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString()), paramPageSize + 1);
        }

        #endregion

        /// <summary>
        /// 属性名称
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string PropertyName(string propertyName)
        {
            string s = "";
            if (propertyName == "发货时间")
            {
                s = "DeliveryTime";
            }
            if (propertyName == "付款时间")
            {
                s = "PayDate";
            }
            if (propertyName == "订单编号")
            {
                s = "OrderCode";
            }
            if (propertyName == "产品名称")
            {
                s = "PrdouctName";
            }
            if (propertyName == "尺寸")
            {
                s = "Specifications";
            }
            if (propertyName == "产品数量")
            {
                s = "ProductNum";
            }
            if (propertyName == "姓名")
            {
                s = "FullName";
            }
            if (propertyName == "收货地址")
            {
                s = "DeliveryAddress";
            }
            if (propertyName == "手机")
            {
                s = "Mobile";
            }
            if (propertyName == "电话")
            {
                s = "Tel";
            }
            if (propertyName == "买家帐号")
            {
                s = "MasterWangNo";
            }
            if (propertyName == "物流单号")
            {
                s = "LogisticsNumber";
            }
            if (propertyName == "出厂价")
            {
                s = "FactoryPrice";
            }
            if (propertyName == "销售价")
            {
                s = "SalesPrice";
            }
            if (propertyName == "销售订单号")
            {
                s = "SalesOrder";
            }
            if (propertyName == "商品编码")
            {
                s = "PartNo";
            }
            if (propertyName == "是否抵库")
            {
                s = "ISArrivedLibrary";
            }
            if (propertyName == "备注")
            {
                s = "Remarks";
            }
            if (propertyName == "截止发货日")
            {
                s = "CutoffShipDay";
            }
            if (propertyName == "客服备注")
            {
                s = "CustomerServiceRemark";
            }
            if (propertyName == "是否审核")
            {
                s = "IsAudit";
            }
            if (propertyName == "是否加急")
            {
                s = "IsExpedited";
            }
            if (propertyName == "是否返现")
            {
                s = "IsCashBack";
            }
            if (propertyName == "是否已发赠品")
            {
                s = "IsSentGifts";
            }
            if (propertyName == "订单状态")
            {
                s = "OrderStatusId";
            }
            if (propertyName == "是否删除")
            {
                s = "IsEnable";
            }
            if (propertyName == "是否已排单")
            {

                s = "IsHadPlanBill";
            }
            if (propertyName == "是否重新发货")
            {

                s = "IsReDelivery";
            }
            if (propertyName == "是否换货")
            {

                s = "IsChangeGoods";
            }
            if (propertyName == "是否已收到退货")
            {

                s = "IsReturnGoods";
            }
            if (propertyName == "线下订单财务审核")
            {
                s = "FinancialAuditRecord";
            }

            return s;
        }

        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMOrderInfo = e.Row.DataItem as XMOrderInfoOperatingRecord;

                #region 修改人
                Label lblUpdatorID = e.Row.FindControl("lblUpdatorID") as Label;
                CustomerInfo customerInfoList = base.CustomerInfoService.GetCustomerInfoByID(xMOrderInfo.UpdatorID.Value);
                if (customerInfoList != null)
                {
                    lblUpdatorID.Text = customerInfoList.FullName;
                }
                #endregion

                #region 原值 换行
                Label lblOldValue = e.Row.FindControl("lblOldValue") as Label;
                string oldValue = xMOrderInfo.OldValue;
                if (oldValue != null && oldValue != "")
                {
                    if (oldValue.Length < 10)
                    {

                        lblOldValue.Text = oldValue;
                    }
                    else
                    {
                        var SOldValue = CutStr(oldValue, 20);
                        lblOldValue.Text = SOldValue;
                    }

                }
                else
                {

                    lblOldValue.Text = "";
                }
                #endregion

                #region 新值 换行
                Label lblNewValue = e.Row.FindControl("lblNewValue") as Label;
                string NewValue = xMOrderInfo.NewValue;
                if (NewValue != null && NewValue != "")
                {
                    if (NewValue.Length < 10)
                    {

                        lblNewValue.Text = NewValue;
                    }
                    else
                    {
                        var SNewValue = CutStr(NewValue, 20);
                        lblNewValue.Text = SNewValue;
                    }
                }
                else
                {

                    lblNewValue.Text = "";

                }
                #endregion

                #region 属性名称

                Label lblPropertyName = e.Row.FindControl("lblPropertyName") as Label;

                lblPropertyName.Text = xMOrderInfo.PropertyName;

                if (xMOrderInfo.PropertyName == "DeliveryTime")
                {
                    lblPropertyName.Text = "发货时间";
                }
                if (xMOrderInfo.PropertyName == "PayDate")
                {
                    lblPropertyName.Text = "付款时间";
                }
                if (xMOrderInfo.PropertyName == "OrderInfoModified")
                {
                    lblPropertyName.Text = "订单更新时间";
                }
                if (xMOrderInfo.PropertyName == "OrderCode")
                {
                    lblPropertyName.Text = "订单编号";
                }
                if (xMOrderInfo.PropertyName == "PrdouctName")
                {
                    lblPropertyName.Text = "产品名称";
                }
                if (xMOrderInfo.PropertyName == "Specifications")
                {
                    lblPropertyName.Text = "尺寸";
                }
                if (xMOrderInfo.PropertyName == "ProductNum")
                {
                    lblPropertyName.Text = "产品数量";
                }
                if (xMOrderInfo.PropertyName == "FullName")
                {
                    lblPropertyName.Text = "姓名";
                }
                if (xMOrderInfo.PropertyName == "DeliveryAddress")
                {
                    lblPropertyName.Text = "收货地址";
                }
                if (xMOrderInfo.PropertyName == "Mobile")
                {
                    lblPropertyName.Text = "手机";
                }
                if (xMOrderInfo.PropertyName == "Tel")
                {
                    lblPropertyName.Text = "电话";
                }
                if (xMOrderInfo.PropertyName == "MasterWangNo")
                {
                    lblPropertyName.Text = "买家帐号";
                }
                if (xMOrderInfo.PropertyName == "LogisticsNumber")
                {
                    lblPropertyName.Text = "物流单号";
                }
                if (xMOrderInfo.PropertyName == "FactoryPrice")
                {
                    lblPropertyName.Text = "出厂价";
                }
                if (xMOrderInfo.PropertyName == "SalesPrice")
                {
                    lblPropertyName.Text = "销售价";
                }
                if (xMOrderInfo.PropertyName == "SalesOrder")
                {
                    lblPropertyName.Text = "销售订单号";
                }
                if (xMOrderInfo.PropertyName == "PartNo")
                {
                    lblPropertyName.Text = "商品编码";
                }
                if (xMOrderInfo.PropertyName == "ISArrivedLibrary")
                {
                    lblPropertyName.Text = "是否抵库";
                }
                if (xMOrderInfo.PropertyName == "Remarks")
                {
                    lblPropertyName.Text = "备注";
                }
                if (xMOrderInfo.PropertyName == "CutoffShipDay")
                {
                    lblPropertyName.Text = "截止发货日";
                }
                if (xMOrderInfo.PropertyName == "CustomerServiceRemark")
                {
                    lblPropertyName.Text = "客服备注";
                }
                if (xMOrderInfo.PropertyName == "IsAudit")
                {
                    lblPropertyName.Text = "是否审核";
                }
                if (xMOrderInfo.PropertyName == "IsExpedited")
                {
                    lblPropertyName.Text = "是否加急";
                }
                if (xMOrderInfo.PropertyName == "IsCashBack")
                {
                    lblPropertyName.Text = "是否返现";
                }
                if (xMOrderInfo.PropertyName == "IsSentGifts")
                {
                    lblPropertyName.Text = "是否已发赠品";
                }
                if (xMOrderInfo.PropertyName == "OrderStatusId")
                {
                    lblPropertyName.Text = "订单状态";
                }
                if (xMOrderInfo.PropertyName == "IsEnable")
                {
                    lblPropertyName.Text = "是否删除";
                }
                if (xMOrderInfo.PropertyName == "LogisticsNumber")
                {
                    lblPropertyName.Text = "物流单号";
                }
                if (xMOrderInfo.PropertyName == "LogisticsId")
                {
                    lblPropertyName.Text = "物流公司ID";
                }
                if (xMOrderInfo.PropertyName == "IsHadPlanBill")
                {
                    lblPropertyName.Text = "是否已排单";
                }
                if (xMOrderInfo.PropertyName == "IsReDelivery")
                {
                    lblPropertyName.Text = "是否重新发货";
                }
                if (xMOrderInfo.PropertyName == "IsChangeGoods")
                {
                    lblPropertyName.Text = "是否换货";
                }
                if (xMOrderInfo.PropertyName == "IsReturnGoods")
                {
                    lblPropertyName.Text = "是否已收到退货";
                }
                if (xMOrderInfo.PropertyName == "订单单个同步")
                {
                    lblPropertyName.Text = "订单单个同步";
                }
                if (xMOrderInfo.PropertyName == "FinancialAuditRecord")
                {
                    lblPropertyName.Text = "线下订单财务审核";
                }

                #endregion
            }
        }

        /// <summary>
        /// 截取字符串，不限制字符串长度
        /// </summary>
        /// <param name="str">待截取的字符串</param>
        /// <param name="len">每行的长度，多于这个长度自动换行</param>
        /// <returns></returns>
        public string CutStr(string str, int len)
        {
            string s = "";

            for (int i = 0; i < str.Length; i++)
            {
                int r = i % len;
                int last = (str.Length / len) * len;
                if (i != 0 && i <= last)
                {

                    if (r == 0)
                    {
                        s += str.Substring(i - len, len) + "<br>";
                    }

                }
                else if (i > last)
                {
                    s += str.Substring(i - 1);
                    break;
                }
            }
            return s;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 订单id
        /// </summary>
        public int XMOrderInfoID
        {
            get
            {
                return CommonHelper.QueryStringInt("ID");
            }
        }


    }
}