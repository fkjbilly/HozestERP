using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using HozestERP.Web;
using JdSdk.Domain;
using Top.Api.Domain;

namespace HozestERP.Web.ManageProductionOrder
{
    public partial class XMProductionOrderInfoEdit : BaseAdministrationPage, IEditPage
    {
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnEdit", "ManageProductionOrder.XMProductionOrderInfoEdit.Edit");
                buttons.Add("btnIsSingleRow", "ManageProductionOrder.XMProductionOrderInfoEdit.IsSingleRow");
                buttons.Add("btnSave", "ManageProductionOrder.XMProductionOrderInfoEdit.XMProductionOrderInfoSave");
                buttons.Add("btnClose", "ManageProductionOrder.XMProductionOrderInfoEdit.XMProductionOrderInfoClose");
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDate();
            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        private void LoadDate()
        {
            var xMProductionOrderInfo = base.XMProductionOrderService.GetXMProductionOrderById(this.XMProductionOrderID);
            if (xMProductionOrderInfo != null)
            {
                //基础信息
                List<CodeList> codeList = base.CodeService.GetCodeList(Convert.ToInt32(xMProductionOrderInfo.PlatformTypeId));
                if (codeList.Count > 0)
                    lblPlatformTypeId.Text = codeList[0].CodeName;
                this.lblNickName.Text = base.XMNickService.ReturnNickNameByID(int.Parse(xMProductionOrderInfo.NickID.ToString()));
                this.lblOrderCode.Text = xMProductionOrderInfo.OrderCode;
                this.txtProductionNumber.Text = xMProductionOrderInfo.ProductionNumber;
                this.txtCompletionTime.Value = xMProductionOrderInfo.EstimateStorageDate == null ? "" : xMProductionOrderInfo.EstimateStorageDate.Value.ToString("yyyy-MM-dd");
                this.lblStatus.Text = GetProductionOrderStatus(xMProductionOrderInfo.Status.Value);
                this.txtWantID.Text = xMProductionOrderInfo.WantID;
                this.lblSingleRowStatus.Text = GetProductionOrderSingleRowStatus(xMProductionOrderInfo.SingleRowStatus.Value);
                this.txtFullName.Text = xMProductionOrderInfo.FullName;
                this.txtMobile.Text = xMProductionOrderInfo.Mobile;
                this.txtTel.Text = xMProductionOrderInfo.Mobile;
                this.txtProvince.Text = xMProductionOrderInfo.Province;
                this.txtCity.Text = xMProductionOrderInfo.City;
                this.txtCountory.Text = xMProductionOrderInfo.County;
                this.txtDeliveryAddress.Text = xMProductionOrderInfo.DeliveryAddress;
                this.txtRemark.Text = xMProductionOrderInfo.Remark;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool isSucess = false;
                //事务
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        string productionNumber = txtProductionNumber.Text.Trim();
                        string EstimateStorageDate = txtCompletionTime.Value;
                        string wantID = txtWantID.Text.Trim();
                        string fullName = txtFullName.Text.Trim();
                        string mobile = txtMobile.Text.Trim();
                        string phone = txtTel.Text.Trim();
                        string Province = txtProvince.Text.Trim();
                        string city = txtCity.Text.Trim();
                        string countory = txtCountory.Text.Trim();
                        string deliveryAddress = txtDeliveryAddress.Text.Trim();
                        string Remark = txtRemark.Text.Trim();
                        if (string.IsNullOrEmpty(productionNumber))
                        {
                            base.ShowMessage("生产单号不能为空！");
                            return;
                        }
                        if (string.IsNullOrEmpty(EstimateStorageDate))
                        {
                            base.ShowMessage("预计入库时间不能为空！");
                            return;
                        }
                        DateTime date = new DateTime();
                        if (!DateTime.TryParse(EstimateStorageDate, out date))
                        {
                            base.ShowMessage("预计入库时间格式不正确！");
                            return;
                        }
                        var productionOrderInfo = base.XMProductionOrderService.GetXMProductionOrderById(this.XMProductionOrderID);
                        if (productionOrderInfo != null)
                        {
                            productionOrderInfo.ProductionNumber = productionNumber;
                            productionOrderInfo.EstimateStorageDate = Convert.ToDateTime(EstimateStorageDate);
                            productionOrderInfo.WantID = wantID;
                            productionOrderInfo.FullName = fullName;
                            productionOrderInfo.Mobile = mobile;
                            productionOrderInfo.Province = Province;
                            productionOrderInfo.City = city;
                            productionOrderInfo.County = countory;
                            productionOrderInfo.DeliveryAddress = deliveryAddress;
                            productionOrderInfo.Remark = Remark;
                            productionOrderInfo.UpdateDate = DateTime.Now;
                            productionOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMProductionOrderService.UpdateXMProductionOrder(productionOrderInfo);
                            isSucess = true;
                        }
                    }
                    catch (Exception err)
                    {
                        this.ProcessException(err);
                    }
                    scope.Complete();
                }
                if (isSucess)
                {
                    base.ShowMessage("操作成功！");
                }
                else
                {
                    base.ShowMessage("数据格式不正确，操作失败！");
                }
                LoadDate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SingleRowStatus"></param>
        /// <returns></returns>
        private string GetProductionOrderSingleRowStatus(int singleRowStatus)
        {
            string result = "";
            switch (singleRowStatus)
            {
                case 0:
                    result = "未排单";
                    break;
                case 1:
                    result = "已排单";
                    break;
                case 2:
                    result = "部分排单";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private string GetProductionOrderStatus(int status)
        {
            string result = "";
            switch (status)
            {
                case 1000:
                    result = "未入库";
                    break;
                case 1002:
                    result = "部分入库";
                    break;
                case 1004:
                    result = "已入库";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 生产单id
        /// </summary>
        public int XMProductionOrderID
        {
            get
            {
                return CommonHelper.QueryStringInt("ID");
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("生产管理 > 生产单详情");
        }

        public void SetTrigger()
        {

        }

        #endregion

    }
}