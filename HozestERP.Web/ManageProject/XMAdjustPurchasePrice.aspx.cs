using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.Common.Utils;
using HozestERP.Web.Modules;

namespace HozestERP.Web.ManageProject
{
    public partial class XMAdjustPurchasePrice : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPayDateStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0).ToString();
                txtPayDateEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59, 59).ToString();
            }
        }

        public void Face_Init()
        {
            //平台类型动态数据绑定
            this.ddlPlatformTypeId.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatformTypeId.DataSource = codeList;
            this.ddlPlatformTypeId.DataTextField = "CodeName";
            this.ddlPlatformTypeId.DataValueField = "CodeID";
            this.ddlPlatformTypeId.DataBind();
            this.ddlPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));

            if (codeList.Where(x => x.CodeID == 537).Count() > 0)//京东自营
            {
                this.ddlPlatformTypeId.SelectedValue = "537";
            }
        }

        public void SetTrigger()
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int PlatformTypeId = Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue.ToString());
                decimal PurchasePrice = string.IsNullOrEmpty(txtAdjustPurchasePrice.Text.Trim()) ? 0 : Convert.ToDecimal(txtAdjustPurchasePrice.Text.Trim());

                if (this.txtPayDateStart.Value.Trim() != "" && this.txtPayDateEnd.Value.Trim() != "")
                {
                    DateTime DateStart = Convert.ToDateTime(txtPayDateStart.Value.Trim());
                    DateTime DateEnd = Convert.ToDateTime(txtPayDateEnd.Value.Trim());
                    if (DateStart >= DateEnd)
                    {
                        base.ShowMessage("开始日期不能大于结束日期，请重新选择！");
                        return;
                    }

                    XMProduct info = base.XMProductService.getXMProductByManufacturersCode(this.MerchantCode);
                    if (info != null)
                    {
                        //采购订单
                        var PurchaseList = base.XMPurchaseService.GetXMPurchaseByParm(PlatformTypeId, MerchantCode, DateStart, DateEnd);
                        if (PurchaseList != null && PurchaseList.Count > 0)
                        {
                            UpdatePurchase(PlatformTypeId, MerchantCode, PurchasePrice, PurchaseList);
                        }

                        var ProductDetail = base.XMProductDetailsService.GetXMProductDetailsListByProductId(info.Id).Where(x => x.PlatformTypeId == PlatformTypeId).ToList();
                        if (ProductDetail != null && ProductDetail.Count > 0)
                        {
                            PurchaseList = base.XMPurchaseService.GetXMPurchaseByParm(PlatformTypeId, ProductDetail[0].PlatformMerchantCode, DateStart, DateEnd);
                            if (PurchaseList != null && PurchaseList.Count > 0)
                            {
                                UpdatePurchase(PlatformTypeId, ProductDetail[0].PlatformMerchantCode, PurchasePrice, PurchaseList);
                            }
                        }
                        else
                        {
                            base.ShowMessage("该产品该平台的商品编码不存在！");
                            return;
                        }
                    }
                    else
                    {
                        base.ShowMessage("该厂家编码不存在！");
                        return;
                    }

                    base.ShowMessage("操作成功！");
                }
                else
                {
                    base.ShowMessage("请先填写开始与结束日期！");
                    return;
                }
            }
        }

        public void UpdatePurchase(int PlatformTypeId, string MerchantCode, decimal PurchasePrice, List<XMPurchase> PurchaseList)
        {
            foreach (var purchase in PurchaseList)
            {
                //采购订单
                var PurchaseDetailList = purchase.XM_PurchaseProductDetails.Where(x => x.PlatformTypeId == PlatformTypeId && x.PlatformMerchantCode == MerchantCode).ToList();
                foreach (var detail in PurchaseDetailList)
                {
                    purchase.ProductsMoney -= detail.ProductMoney;

                    detail.ProductPrice = PurchasePrice;
                    detail.ProductMoney = PurchasePrice * detail.ProductCount;
                    detail.UpdateDate = DateTime.Now;
                    detail.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMPurchaseProductDetailsService.UpdateXMPurchaseProductDetails(detail);

                    purchase.ProductsMoney += detail.ProductMoney;
                }

                purchase.UpdateDate = DateTime.Now;
                purchase.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMPurchaseService.UpdateXMPurchase(purchase);

                //采购入库单
                var StorageList = base.XMStorageService.GetXMStorageListByPurcahaseID(purchase.Id);
                foreach (var storage in StorageList)
                {
                    var StorageDetailList = storage.XM_StorageProductDetails.Where(x => x.PlatformMerchantCode == MerchantCode).ToList();
                    foreach (var detail in StorageDetailList)
                    {
                        storage.ProductsMoney -= detail.ProductsMoney;

                        detail.ProductsPrice = PurchasePrice;
                        detail.ProductsMoney = PurchasePrice * detail.ProductsCount;
                        detail.UpdateDate = DateTime.Now;
                        detail.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMStorageProductDetailsService.UpdateXMStorageProductDetails(detail);

                        storage.ProductsMoney += detail.ProductsMoney;
                    }

                    storage.UpdateDate = DateTime.Now;
                    storage.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMStorageService.UpdateXMStorage(storage);
                }

                //应付账款
                var PaymentApply = base.XMPaymentApplyService.GetXMPaymentApplyByPurchaseID(purchase.Id);
                if (PaymentApply != null)
                {
                    PaymentApply.PayAmounts = (decimal)purchase.ProductsMoney;
                    PaymentApply.UpdateDate = DateTime.Now;
                    PaymentApply.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMPaymentApplyService.UpdateXMPaymentApply(PaymentApply);
                }
            }
        }

        public string MerchantCode
        {
            get
            {
                return CommonHelper.QueryString("MerchantCode");
            }
        }
    }
}