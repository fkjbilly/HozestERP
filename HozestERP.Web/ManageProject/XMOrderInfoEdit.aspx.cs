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

namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderInfoEdit : BaseAdministrationPage, IEditPage
    {
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnEdit", "ManageProject.XMOrderInfoEdit.XMOrderInfoEdit");
                buttons.Add("btnIsAudit", "ManageProject.XMOrderInfoEdit.XMOrderInfoIsAudit");
                buttons.Add("btnSave", "ManageProject.XMOrderInfoEdit.XMOrderInfoSave");
                buttons.Add("btnClose", "ManageProject.XMOrderInfoEdit.XMOrderInfoClose");
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDate();

                if (Request["Referrer"] != null)
                {
                    btnEdit.Visible = false;
                    btnIsAudit.Visible = false;
                }
            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        private void LoadDate()
        {
            var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);
            if (xMOrderInfo != null)
            {
                //基础信息
                List<CodeList> codeList = base.CodeService.GetCodeList(Convert.ToInt32(xMOrderInfo.PlatformTypeId));
                if (codeList.Count > 0)
                    lblPlatformTypeId.Text = codeList[0].CodeName;

                this.hfPlatformTypeId.Value = xMOrderInfo.PlatformTypeId.Value.ToString();
                this.lblNickName.Text = base.XMNickService.ReturnNickNameByID(int.Parse(xMOrderInfo.NickID.ToString()));
                this.hfNickId.Value = xMOrderInfo.NickID.Value.ToString();
                this.lblOrderCode.Text = xMOrderInfo.OrderCode;
                this.lblOrderStatus.Text = GetOrderStatus(xMOrderInfo.OrderStatus, xMOrderInfo.PlatformTypeId.ToString());
                this.txtCompletionTime.Value = xMOrderInfo.CompletionTime == null ? "" : xMOrderInfo.CompletionTime.Value.ToString("yyyy-MM-dd");  //xMOrderInfo.CompletionTime;
                this.txtDeliveryTime.Value = xMOrderInfo.DeliveryTime == null ? "" : xMOrderInfo.DeliveryTime.Value.ToString("yyyy-MM-dd");  //xMOrderInfo.DeliveryTime;
                this.txtPayDate.Value = xMOrderInfo.PayDate == null ? "" : xMOrderInfo.PayDate.Value.ToString(); //xMOrderInfo.PayDate;
                this.txtOrderInfoCreateDate.Value = xMOrderInfo.OrderInfoCreateDate == null ? "" : xMOrderInfo.OrderInfoCreateDate.Value.ToString();
                this.txtSourceType.Text = xMOrderInfo.SourceType;
                this.txtWantID.Text = xMOrderInfo.WantID;
                if (xMOrderInfo.IsScalping != null && xMOrderInfo.IsScalping != false)
                {
                    this.ckbIsScalping.Checked = true;
                }
                if (xMOrderInfo.IsCashBack != null && xMOrderInfo.IsCashBack != false)
                {
                    this.ckbIsCashBack.Checked = true;
                }
                if (xMOrderInfo.IsSentGifts != null && xMOrderInfo.IsSentGifts != false)
                {
                    this.ckbIsSentGifts.Checked = true;
                }
                if (xMOrderInfo.IsEvaluate != null && xMOrderInfo.IsEvaluate != false)
                {
                    this.ckbIsEvaluate.Checked = true;
                }
                //商品价格
                this.txtProductPrice.Text = xMOrderInfo.ProductPrice == null ? "0" : xMOrderInfo.ProductPrice.ToString();
                this.txtDistributePrice.Text = xMOrderInfo.DistributePrice == null ? "0" : xMOrderInfo.DistributePrice.ToString();
                this.txtSupportPrice.Text = xMOrderInfo.SupportPrice == null ? "0" : xMOrderInfo.SupportPrice.ToString();
                this.txtTaxes.Text = xMOrderInfo.Taxes == null ? "0" : xMOrderInfo.Taxes.ToString();
                this.txtDiscount.Text = xMOrderInfo.Discount == null ? "0" : xMOrderInfo.Discount.ToString();
                this.txtProductPromotion.Text = xMOrderInfo.ProductPromotion == null ? "0" : xMOrderInfo.ProductPromotion.ToString();
                this.txtOrderPromotion.Text = xMOrderInfo.OrderPromotion == null ? "0" : xMOrderInfo.OrderPromotion.ToString();
                this.txtOrderPrice.Text = xMOrderInfo.OrderPrice == null ? "0" : xMOrderInfo.OrderPrice.ToString();
                this.txtReceivablePrice.Text = xMOrderInfo.ReceivablePrice == null ? "0" : xMOrderInfo.ReceivablePrice.ToString();

                decimal PayPrice = decimal.Parse(xMOrderInfo.PayPrice == null ? "0" : xMOrderInfo.PayPrice.ToString());
                decimal Hll = 0;
                if (xMOrderInfo.PlatformTypeId == 259)
                {
                    foreach (XMOrderInfoProductDetails item in xMOrderInfo.XM_OrderInfoProductDetails)
                    {
                        if (item.PlatformMerchantCode.Length > 2)
                        {
                            var ddh = item.PlatformMerchantCode.Substring(0, 2);
                            if (ddh != "CM")
                            {
                                Hll += (decimal)item.SalesPrice;
                            }
                        }
                    }
                }
                if (IsCM)
                {
                    PayPrice = PayPrice - Hll;
                }
                else
                {
                    PayPrice = Hll;
                }

                this.txtPayPrice.Text = PayPrice.ToString();//xMOrderInfo.PayPrice == null ? "0" : xMOrderInfo.PayPrice.ToString();

                //订单其他信息
                this.txtDistributeMethod.Text = base.XMOrderInfoService.ReturnDistributeMethod(xMOrderInfo.DistributeMethod);
                if (xMOrderInfo.IsDistributed != null && xMOrderInfo.IsDistributed != false)
                {
                    this.ckbIsDistributed.Checked = true;
                }
                this.txtProductWeight.Text = xMOrderInfo.ProductWeight == null ? "0" : xMOrderInfo.ProductWeight.ToString();
                this.txtPayMethod.Text = base.XMOrderInfoService.ReturnPayMethod(xMOrderInfo.PayMethod);
                this.txtInvoicePrice.Text = xMOrderInfo.InvoicePrice == null ? "0" : xMOrderInfo.InvoicePrice.ToString();
                if (xMOrderInfo.IsInvoiced != null && xMOrderInfo.IsInvoiced != false)
                {
                    this.ckbIsInvoiced.Checked = true;
                }
                this.txtInvoiceNo.Text = xMOrderInfo.InvoiceNo;
                this.txtInvoiceHead.Text = xMOrderInfo.InvoiceHead;
                this.txtCustomerService.Text = xMOrderInfo.CustomerServiceName;
                //收货人信息
                this.txtAppointDeliveryTime.Value = xMOrderInfo.AppointDeliveryTime == null ? "" : xMOrderInfo.AppointDeliveryTime.ToString();
                this.txtFullName.Text = xMOrderInfo.FullName;
                this.txtMobile.Text = xMOrderInfo.Mobile;
                this.txtTel.Text = xMOrderInfo.Tel;
                this.txtAddress.Text = xMOrderInfo.Province + " " + xMOrderInfo.City + " " + xMOrderInfo.County;
                this.txtDeliveryAddress.Text = xMOrderInfo.DeliveryAddress;
                this.txtDeliveryAddressSpare.Text = xMOrderInfo.DeliveryAddressSpare;
                //备注
                this.txtRemark.Text = xMOrderInfo.Remark;
                this.txtCustomerRemark.Text = xMOrderInfo.CustomerServiceRemark;
                //商品体积
                #region
                decimal productVolume = 0;
                List<XMOrderInfoProductDetails> list_OrderInfoProductDetails = XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderId(XMOrderInfoID);
                foreach (var item in list_OrderInfoProductDetails)
                {
                    decimal volume = 0;
                    decimal.TryParse(item.ProductVolume, out volume);
                    productVolume = productVolume + volume;
                }
                txtVolume.Text = productVolume.ToString();
                #endregion
                //商品物流费用
                #region
                decimal productFee = 0;
                List<BusinessLogic.ManageProject.XMLogisticsFeeDetail> list_LogisticsFeeDetail = XMLogisticsFeeDetailService.GetXMLogisticsFeeDetailList(XMOrderInfoID).ToList();
                foreach (var item in list_LogisticsFeeDetail)
                {
                    productFee = productFee + (decimal)item.Fee;
                }
                txtLogisticsFee.Text = productFee.ToString();
                #endregion
            }
            else
            {
                //基础信息
                this.lblOrderCode.Text = string.Empty;
                this.lblOrderStatus.Text = string.Empty;
                this.txtCompletionTime.Value = (DateTime.Now).ToString();
                this.txtDeliveryTime.Value = (DateTime.Now).ToString();
                this.txtPayDate.Value = (DateTime.Now).ToString();
                this.txtOrderInfoCreateDate.Value = (DateTime.Now).ToString();
                this.txtSourceType.Text = string.Empty;
                this.txtWantID.Text = string.Empty;
                this.ckbIsScalping.Checked = false;
                this.ckbIsCashBack.Checked = false;
                this.ckbIsSentGifts.Checked = false;
                this.ckbIsEvaluate.Checked = false;
                //商品价格
                this.txtProductPrice.Text = string.Empty;
                this.txtDistributePrice.Text = string.Empty;
                this.txtSupportPrice.Text = string.Empty;
                this.txtTaxes.Text = string.Empty;
                this.txtDiscount.Text = string.Empty;
                this.txtProductPromotion.Text = string.Empty;
                this.txtOrderPromotion.Text = string.Empty;
                this.txtOrderPrice.Text = string.Empty;
                this.txtReceivablePrice.Text = string.Empty;
                this.txtPayPrice.Text = string.Empty;
                //订单其他信息
                this.txtDistributeMethod.Text = string.Empty;
                this.ckbIsDistributed.Checked = false;
                this.txtProductWeight.Text = string.Empty;
                this.txtPayMethod.Text = string.Empty;
                this.txtInvoicePrice.Text = string.Empty;
                this.ckbIsInvoiced.Checked = false;
                this.txtInvoiceNo.Text = string.Empty;
                this.txtInvoiceHead.Text = string.Empty;
                //收货人信息
                this.txtAppointDeliveryTime.Value = string.Empty;
                this.txtFullName.Text = string.Empty;
                this.txtMobile.Text = string.Empty;
                this.txtTel.Text = string.Empty;
                this.txtAddress.Text = string.Empty;
                this.txtDeliveryAddress.Text = string.Empty;
                this.txtDeliveryAddressSpare.Text = string.Empty;
                //备注
                this.txtCustomerRemark.Text = string.Empty;
            }

            this.ReadOnlyN();

        }

        /// <summary>
        /// 不可编辑
        /// </summary>
        public void ReadOnlyN()
        {
            //基础信息
            this.txtCompletionTime.Disabled = true;
            this.txtDeliveryTime.Disabled = true;
            this.txtPayDate.Disabled = true;
            this.txtOrderInfoCreateDate.Disabled = true;
            this.txtSourceType.ReadOnly = true;
            this.txtWantID.ReadOnly = true;
            this.ckbIsScalping.Enabled = false;
            this.ckbIsCashBack.Enabled = false;
            this.ckbIsSentGifts.Enabled = false;
            this.ckbIsEvaluate.Enabled = false;
            //商品价格
            this.txtProductPrice.ReadOnly = true;
            this.txtDistributePrice.ReadOnly = true;
            this.txtSupportPrice.ReadOnly = true;
            this.txtTaxes.ReadOnly = true;
            this.txtDiscount.ReadOnly = true;
            this.txtProductPromotion.ReadOnly = true;
            this.txtOrderPromotion.ReadOnly = true;
            this.txtOrderPrice.ReadOnly = true;
            this.txtReceivablePrice.ReadOnly = true;
            this.txtPayPrice.ReadOnly = true;
            //订单其他信息
            this.txtDistributeMethod.ReadOnly = true;
            this.ckbIsDistributed.Enabled = false;
            this.txtProductWeight.ReadOnly = true;
            this.txtPayMethod.ReadOnly = true;
            this.txtInvoicePrice.ReadOnly = true;
            this.ckbIsInvoiced.Enabled = false;
            this.txtInvoiceNo.ReadOnly = true;
            this.txtInvoiceHead.ReadOnly = true;
            //收货人信息
            this.txtAppointDeliveryTime.Disabled = true;
            this.txtFullName.ReadOnly = true;
            this.txtMobile.ReadOnly = true;
            this.txtTel.ReadOnly = true;
            this.txtAddress.ReadOnly = true;
            this.txtDeliveryAddress.ReadOnly = true;
            //this.txtDeliveryAddressSpare.ReadOnly = true;
            //备注
            this.txtCustomerRemark.ReadOnly = true;
            this.txtRemark.ReadOnly = true;
            //商品物流费用
            txtLogisticsFee.ReadOnly = true;
            //商品体积
            txtVolume.ReadOnly = true;

            this.btnEdit.Visible = true;
            this.btnIsAudit.Visible = true;
            this.btnSave.Visible = false;
            this.btnClose.Visible = false;
        }

        /// <summary>
        /// 可编辑
        /// </summary>
        public void ReadOnlyY()
        {
            int PlatformTypeId = 0;
            var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);
            if (xMOrderInfo != null)
            {
                PlatformTypeId = xMOrderInfo.PlatformTypeId.Value;
            }

            //基础信息
            this.txtCompletionTime.Disabled = false;
            this.txtDeliveryTime.Disabled = false;
            this.txtPayDate.Disabled = false;
            this.txtOrderInfoCreateDate.Disabled = false;
            this.txtSourceType.ReadOnly = false;
            this.txtWantID.ReadOnly = false;
            this.ckbIsScalping.Enabled = true;
            this.ckbIsCashBack.Enabled = true;
            this.ckbIsSentGifts.Enabled = true;
            this.ckbIsEvaluate.Enabled = true;
            //商品价格
            this.txtProductPrice.ReadOnly = false;
            this.txtDistributePrice.ReadOnly = false;
            this.txtSupportPrice.ReadOnly = false;
            this.txtTaxes.ReadOnly = false;
            this.txtDiscount.ReadOnly = false;
            this.txtProductPromotion.ReadOnly = false;
            this.txtOrderPromotion.ReadOnly = false;
            this.txtOrderPrice.ReadOnly = false;
            this.txtReceivablePrice.ReadOnly = false;
            this.txtPayPrice.ReadOnly = false;
            //订单其他信息
            this.txtDistributeMethod.ReadOnly = false;
            this.ckbIsDistributed.Enabled = true;
            this.txtProductWeight.ReadOnly = false;
            this.txtPayMethod.ReadOnly = false;
            this.txtInvoicePrice.ReadOnly = false;
            this.ckbIsInvoiced.Enabled = true;
            this.txtInvoiceNo.ReadOnly = false;
            this.txtInvoiceHead.ReadOnly = false;
            //收货人信息
            this.txtAppointDeliveryTime.Disabled = false;
            this.txtFullName.ReadOnly = false;
            this.txtMobile.ReadOnly = false;
            this.txtTel.ReadOnly = false;
            this.txtAddress.ReadOnly = false;
            this.txtDeliveryAddress.ReadOnly = false;
            // this.txtDeliveryAddressSpare.ReadOnly = false;
            //备注
            this.txtCustomerRemark.ReadOnly = false;
            this.txtRemark.ReadOnly = false;

            this.btnSave.Visible = true;
            this.btnClose.Visible = true;
            this.btnEdit.Visible = false;
            this.btnIsAudit.Visible = false;
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("订单管理 > 订单详情");
        }

        public void SetTrigger()
        {
            // this.Master.SetTrigger(this.btnSave.UniqueID, this.Page); 

        }

        #endregion

        /// <summary>
        /// 截取字符串，不限制字符串长度
        /// </summary>
        /// <param name="str">待截取的字符串</param>
        /// <returns></returns>
        public string CutStr(string str)
        {
            string s = "";

            if (str.IndexOf("/服务单号：") > -1)
            {
                string strj = "/服务单号：";
                string strt = "<br>服务单号：";
                s = str.Replace(strj, strt);
            }
            else
            {
                s = str;
            }

            return s;
        }

        /// <summary>
        /// 保存保护申请信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //事务
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        //提示信息
                        string paramMessage = "";

                        var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);

                        if (xMOrderInfo != null)//修改
                        {

                            string CustomerServiceRemarkOld = "";
                            //修改之前的客服备注信息
                            if (xMOrderInfo.CustomerServiceRemark != null)
                                CustomerServiceRemarkOld = xMOrderInfo.CustomerServiceRemark.Trim();

                            //修改之前的备用地址 
                            //string DeliveryAddressSpareOld = xMOrderInfo.DeliveryAddressSpare.Trim();

                            #region 字符判断
                            decimal d = 0;
                            decimal i = 0;

                            if (txtProductPrice.Text.Trim() != "")
                            {
                                if (!decimal.TryParse(txtProductPrice.Text.Trim(), out  i))
                                {
                                    base.ShowMessage("您输入的商品总额不正确!");
                                    return;
                                }
                            }

                            if (txtDistributePrice.Text.Trim() != "")
                            {
                                if (!decimal.TryParse(txtDistributePrice.Text.Trim(), out  i))
                                {
                                    base.ShowMessage("您输入的配送费用不正确!");
                                    return;
                                }
                            }

                            if (txtSupportPrice.Text.Trim() != "")
                            {
                                if (!decimal.TryParse(txtSupportPrice.Text.Trim(), out  i))
                                {
                                    base.ShowMessage("您输入的保价费用不正确!");
                                    return;
                                }
                            }

                            if (txtTaxes.Text.Trim() != "")
                            {
                                if (!decimal.TryParse(txtTaxes.Text.Trim(), out  i))
                                {
                                    base.ShowMessage("您输入的税金不正确!");
                                    return;
                                }
                            }

                            if (txtDiscount.Text.Trim() != "")
                            {
                                if (!decimal.TryParse(txtDiscount.Text.Trim(), out  i))
                                {
                                    base.ShowMessage("您输入的折扣不正确!");
                                    return;
                                }
                            }

                            if (txtProductPromotion.Text.Trim() != "")
                            {
                                if (!decimal.TryParse(txtProductPromotion.Text.Trim(), out  i))
                                {
                                    base.ShowMessage("您输入的商品促销优惠不正确!");
                                    return;
                                }
                            }

                            if (txtOrderPromotion.Text.Trim() != "")
                            {
                                if (!decimal.TryParse(txtOrderPromotion.Text.Trim(), out  i))
                                {
                                    base.ShowMessage("您输入的订单促销优惠不正确!");
                                    return;
                                }
                            }

                            if (txtReceivablePrice.Text.Trim() != "")
                            {
                                if (!decimal.TryParse(txtReceivablePrice.Text.Trim(), out  i))
                                {
                                    base.ShowMessage("您输入的应收金额不正确!");
                                    return;
                                }
                            }

                            if (txtPayPrice.Text.Trim() != "")
                            {
                                if (!decimal.TryParse(txtPayPrice.Text.Trim(), out  i))
                                {
                                    base.ShowMessage("您输入的已支付金额不正确!");
                                    return;
                                }
                            }

                            if (txtProductWeight.Text.Trim() != "")
                            {
                                if (!decimal.TryParse(txtProductWeight.Text.Trim(), out  i))
                                {
                                    base.ShowMessage("您输入的产品重量不正确!");
                                    return;
                                }
                            }

                            if (txtInvoicePrice.Text.Trim() != "")
                            {
                                if (!decimal.TryParse(txtInvoicePrice.Text.Trim(), out  i))
                                {
                                    base.ShowMessage("您输入的支付费用不正确!");
                                    return;
                                }
                            }
                            #endregion

                            #region 记录操作
                            //基本信息
                            if (xMOrderInfo.OrderCode != null || xMOrderInfo.OrderCode != "" && this.lblOrderCode.Text.Trim() != "")
                            {
                                if (xMOrderInfo.OrderCode != this.lblOrderCode.Text.Trim())
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "OrderCode";
                                    record.OldValue = xMOrderInfo.OrderCode;
                                    record.NewValue = this.lblOrderCode.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }

                            string completeTime = xMOrderInfo.CompletionTime == null ? "" : xMOrderInfo.CompletionTime.Value.ToString("yyyy-MM-dd");
                            if (this.txtCompletionTime.Value != "" && xMOrderInfo.CompletionTime != null)
                            {
                                if (completeTime != this.txtCompletionTime.Value)
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "CompletionTime";
                                    record.OldValue = System.Convert.ToString(completeTime);
                                    record.NewValue = System.Convert.ToString(this.txtCompletionTime.Value);
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }

                            string detime = xMOrderInfo.DeliveryTime == null ? "" : xMOrderInfo.DeliveryTime.Value.ToString("yyyy-MM-dd");
                            if (this.txtDeliveryTime.Value != "" && xMOrderInfo.DeliveryTime != null)
                            {
                                if (detime != this.txtDeliveryTime.Value)
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "DeliveryTime";
                                    record.OldValue = System.Convert.ToString(detime);
                                    record.NewValue = System.Convert.ToString(this.txtDeliveryTime.Value);
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.PayDate != null && this.txtPayDate.Value != "")
                            {
                                if (xMOrderInfo.PayDate != Convert.ToDateTime(this.txtPayDate.Value))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "PayDate";
                                    record.OldValue = System.Convert.ToString(xMOrderInfo.PayDate);
                                    record.NewValue = System.Convert.ToString(this.txtPayDate.Value);
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.OrderInfoCreateDate != null && this.txtOrderInfoCreateDate.Value != "")
                            {
                                if (xMOrderInfo.OrderInfoCreateDate != Convert.ToDateTime(this.txtOrderInfoCreateDate.Value))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "OrderInfoCreateDate";
                                    record.OldValue = System.Convert.ToString(xMOrderInfo.OrderInfoCreateDate);
                                    record.NewValue = System.Convert.ToString(this.txtOrderInfoCreateDate.Value);
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.SourceType != null || xMOrderInfo.SourceType != "" && this.txtSourceType.Text != "")
                            {
                                if (xMOrderInfo.SourceType != this.txtSourceType.Text)
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "SourceType";
                                    record.OldValue = xMOrderInfo.SourceType;
                                    record.NewValue = this.txtSourceType.Text;
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.WantID != null || xMOrderInfo.WantID != "" && this.txtWantID.Text != "")
                            {
                                if (xMOrderInfo.WantID != this.txtWantID.Text)
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "WantID";
                                    record.OldValue = xMOrderInfo.WantID;
                                    record.NewValue = this.txtWantID.Text;
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.IsScalping != null)
                            {
                                if (xMOrderInfo.IsScalping != this.ckbIsScalping.Checked)
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "IsScalping";
                                    record.OldValue = xMOrderInfo.IsScalping.ToString();
                                    record.NewValue = this.ckbIsScalping.Checked.ToString();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.IsCashBack != null)
                            {
                                if (xMOrderInfo.IsCashBack != this.ckbIsCashBack.Checked)
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "IsCashBack";
                                    record.OldValue = xMOrderInfo.IsCashBack.ToString();
                                    record.NewValue = this.ckbIsCashBack.Checked.ToString();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.IsSentGifts != null)
                            {
                                if (xMOrderInfo.IsSentGifts != this.ckbIsSentGifts.Checked)
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "IsSentGifts";
                                    record.OldValue = xMOrderInfo.IsSentGifts.ToString();
                                    record.NewValue = this.ckbIsSentGifts.Checked.ToString();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.IsEvaluate != null)
                            {
                                if (xMOrderInfo.IsEvaluate != this.ckbIsEvaluate.Checked)
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "IsEvaluate";
                                    record.OldValue = xMOrderInfo.IsEvaluate.ToString();
                                    record.NewValue = this.ckbIsEvaluate.Checked.ToString();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            //商品价格
                            if (xMOrderInfo.ProductPrice != null && this.txtProductPrice.Text.Trim() != "")
                            {
                                if (xMOrderInfo.ProductPrice != decimal.Parse(this.txtProductPrice.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "ProductPrice";
                                    record.OldValue = xMOrderInfo.ProductPrice.ToString();
                                    record.NewValue = this.txtProductPrice.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.SupportPrice != null && this.txtSupportPrice.Text.Trim() != "")
                            {
                                if (xMOrderInfo.SupportPrice != decimal.Parse(this.txtSupportPrice.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "SupportPrice";
                                    record.OldValue = xMOrderInfo.SupportPrice.ToString();
                                    record.NewValue = this.txtSupportPrice.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.DistributePrice != null && this.txtDistributePrice.Text.Trim() != "")
                            {
                                if (xMOrderInfo.DistributePrice != decimal.Parse(this.txtDistributePrice.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "DistributePrice";
                                    record.OldValue = xMOrderInfo.DistributePrice.ToString();
                                    record.NewValue = this.txtDistributePrice.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.Taxes != null && this.txtTaxes.Text.Trim() != "")
                            {
                                if (xMOrderInfo.Taxes != decimal.Parse(this.txtTaxes.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "Taxes";
                                    record.OldValue = xMOrderInfo.Taxes.ToString();
                                    record.NewValue = this.txtTaxes.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.Discount != null && this.txtDiscount.Text.Trim() != "")
                            {
                                if (xMOrderInfo.Discount != decimal.Parse(this.txtDiscount.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "Discount";
                                    record.OldValue = xMOrderInfo.Discount.ToString();
                                    record.NewValue = this.txtDiscount.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.ProductPromotion != null && this.txtProductPromotion.Text.Trim() != "")
                            {
                                if (xMOrderInfo.ProductPromotion != decimal.Parse(this.txtProductPromotion.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "ProductPromotion";
                                    record.OldValue = xMOrderInfo.ProductPromotion.ToString();
                                    record.NewValue = this.txtProductPromotion.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.OrderPromotion != null && this.txtOrderPromotion.Text.Trim() != "")
                            {
                                if (xMOrderInfo.OrderPromotion != decimal.Parse(this.txtOrderPromotion.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "OrderPromotion";
                                    record.OldValue = xMOrderInfo.OrderPromotion.ToString();
                                    record.NewValue = this.txtOrderPromotion.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.OrderPrice != null && this.txtOrderPrice.Text.Trim() != "")
                            {
                                if (xMOrderInfo.OrderPrice != decimal.Parse(this.txtOrderPrice.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "OrderPrice";
                                    record.OldValue = xMOrderInfo.OrderPrice.ToString();
                                    record.NewValue = this.txtOrderPrice.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.ReceivablePrice != null && this.txtReceivablePrice.Text.Trim() != "")
                            {
                                if (xMOrderInfo.ReceivablePrice != decimal.Parse(this.txtReceivablePrice.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "ReceivablePrice";
                                    record.OldValue = xMOrderInfo.ReceivablePrice.ToString();
                                    record.NewValue = this.txtReceivablePrice.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.PayPrice != null && this.txtPayPrice.Text.Trim() != "")
                            {
                                if (xMOrderInfo.PayPrice != decimal.Parse(this.txtPayPrice.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "PayPrice";
                                    record.OldValue = xMOrderInfo.PayPrice.ToString();
                                    record.NewValue = this.txtPayPrice.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            //订单其他信息
                            if (xMOrderInfo.DistributeMethod != null || xMOrderInfo.DistributeMethod != "" && this.txtDistributeMethod.Text.Trim() != "")
                            {
                                if (xMOrderInfo.DistributeMethod != this.txtDistributeMethod.Text.Trim())
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "DistributeMethod";
                                    record.OldValue = xMOrderInfo.DistributeMethod.ToString();
                                    record.NewValue = this.txtDistributeMethod.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.IsDistributed != null)
                            {
                                if (xMOrderInfo.IsDistributed != this.ckbIsDistributed.Checked)
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "IsDistributed";
                                    record.OldValue = xMOrderInfo.IsDistributed.ToString();
                                    record.NewValue = this.ckbIsDistributed.Checked.ToString();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.ProductWeight != null && this.txtProductWeight.Text.Trim() != "")
                            {
                                if (xMOrderInfo.ProductWeight != decimal.Parse(this.txtProductWeight.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "ProductWeight";
                                    record.OldValue = xMOrderInfo.ProductWeight.ToString();
                                    record.NewValue = this.txtProductWeight.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.PayMethod != null || xMOrderInfo.PayMethod != "" && this.txtPayMethod.Text.Trim() != "")
                            {
                                if (xMOrderInfo.PayMethod != this.txtPayMethod.Text.Trim())
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "PayMethod";
                                    record.OldValue = xMOrderInfo.PayMethod.ToString();
                                    record.NewValue = this.txtPayMethod.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.InvoicePrice != null && this.txtInvoicePrice.Text.Trim() != "")
                            {
                                if (xMOrderInfo.InvoicePrice != decimal.Parse(this.txtInvoicePrice.Text.Trim()))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "InvoicePrice";
                                    record.OldValue = xMOrderInfo.InvoicePrice.ToString();
                                    record.NewValue = this.txtInvoicePrice.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.IsInvoiced != null)
                            {
                                if (xMOrderInfo.IsInvoiced != this.ckbIsInvoiced.Checked)
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "IsInvoiced";
                                    record.OldValue = xMOrderInfo.IsInvoiced.ToString();
                                    record.NewValue = this.ckbIsInvoiced.Checked.ToString();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.InvoiceNo != null || xMOrderInfo.InvoiceNo != "" && this.txtInvoiceNo.Text.Trim() != "")
                            {
                                if (xMOrderInfo.InvoiceNo != this.txtInvoiceNo.Text.Trim())
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "InvoiceNo";
                                    record.OldValue = xMOrderInfo.InvoiceNo.ToString();
                                    record.NewValue = this.txtInvoiceNo.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.InvoiceHead != null || xMOrderInfo.InvoiceHead != "" && this.txtInvoiceHead.Text.Trim() != "")
                            {
                                if (xMOrderInfo.InvoiceHead != this.txtInvoiceHead.Text.Trim())
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "InvoiceHead";
                                    record.OldValue = xMOrderInfo.InvoiceHead.ToString();
                                    record.NewValue = this.txtInvoiceHead.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            //收货人信息
                            if (xMOrderInfo.AppointDeliveryTime != null && this.txtAppointDeliveryTime.Value != "")
                            {
                                if (xMOrderInfo.AppointDeliveryTime != Convert.ToDateTime(this.txtAppointDeliveryTime.Value))
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "AppointDeliveryTime";
                                    record.OldValue = System.Convert.ToString(xMOrderInfo.AppointDeliveryTime);
                                    record.NewValue = System.Convert.ToString(this.txtAppointDeliveryTime.Value);
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.FullName != null || xMOrderInfo.FullName != "" && this.txtFullName.Text.Trim() != "")
                            {
                                if (xMOrderInfo.FullName != this.txtFullName.Text.Trim())
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "FullName";
                                    record.OldValue = xMOrderInfo.FullName;
                                    record.NewValue = this.txtFullName.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.DeliveryAddress != null || xMOrderInfo.DeliveryAddress != "" && this.txtDeliveryAddress.Text.Trim() != "")
                            {
                                if (xMOrderInfo.DeliveryAddress != this.txtDeliveryAddress.Text.Trim())
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "DeliveryAddress";
                                    record.OldValue = xMOrderInfo.DeliveryAddress;
                                    record.NewValue = this.txtDeliveryAddress.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.Remark != null || xMOrderInfo.Remark != "" && this.txtRemark.Text.Trim() != "")
                            {
                                if (xMOrderInfo.Remark != this.txtRemark.Text.Trim())
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "Remark";
                                    record.OldValue = xMOrderInfo.Remark;
                                    record.NewValue = this.txtRemark.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.CustomerServiceRemark != null || xMOrderInfo.CustomerServiceRemark != "" && this.txtCustomerRemark.Text.Trim() != "")
                            {
                                if (xMOrderInfo.CustomerServiceRemark != this.txtCustomerRemark.Text.Trim())
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "CustomerServiceRemark";
                                    record.OldValue = xMOrderInfo.CustomerServiceRemark;
                                    record.NewValue = this.txtCustomerRemark.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            //if (xMOrderInfo.DeliveryAddressSpare != null || xMOrderInfo.DeliveryAddressSpare != "" && this.txtDeliveryAddressSpare.Text.Trim() != "")
                            //{
                            //    if (xMOrderInfo.DeliveryAddressSpare != this.txtDeliveryAddressSpare.Text.Trim())
                            //    {
                            //        XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                            //        record.OrderInfoId = this.XMOrderInfoID;
                            //        record.PropertyName = "DeliveryAddressSpare";
                            //        record.OldValue = xMOrderInfo.DeliveryAddressSpare;
                            //        record.NewValue = this.txtDeliveryAddressSpare.Text.Trim();
                            //        record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            //        record.UpdateTime = DateTime.Now;
                            //        base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                            //    }
                            //}

                            if (xMOrderInfo.Tel != null || xMOrderInfo.Tel != "" && this.txtTel.Text.Trim() != "")
                            {
                                if (xMOrderInfo.Tel != this.txtTel.Text.Trim())
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "Tel";
                                    record.OldValue = xMOrderInfo.Tel;
                                    record.NewValue = this.txtTel.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            if (xMOrderInfo.Mobile != null || xMOrderInfo.Mobile != "" && this.txtMobile.Text.Trim() != "")
                            {
                                if (xMOrderInfo.Mobile != this.txtMobile.Text.Trim())
                                {
                                    XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                    record.OrderInfoId = this.XMOrderInfoID;
                                    record.PropertyName = "Mobile";
                                    record.OldValue = xMOrderInfo.Mobile;
                                    record.NewValue = this.txtMobile.Text.Trim();
                                    record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    record.UpdateTime = DateTime.Now;
                                    base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                }
                            }
                            string OrderStatus = this.lblOrderStatus.Text.Trim();

                            if (xMOrderInfo.PlatformTypeId == 259)
                            {
                                if (xMOrderInfo.OrderStatus != null && OrderStatus != "")
                                {
                                    if (xMOrderInfo.OrderStatus != this.lblOrderStatus.Text)
                                    {
                                        XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                                        record.OrderInfoId = this.XMOrderInfoID;
                                        record.PropertyName = "OrderStatus";
                                        record.OldValue = System.Convert.ToString(xMOrderInfo.OrderStatus);
                                        record.NewValue = System.Convert.ToString(this.lblOrderStatus.Text);
                                        record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                        record.UpdateTime = DateTime.Now;
                                        base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                                    }
                                }
                            }

                            #endregion

                            #region  订单基础信息
                            if (!string.IsNullOrEmpty(this.txtCompletionTime.Value))
                            {
                                xMOrderInfo.CompletionTime = Convert.ToDateTime(this.txtCompletionTime.Value);
                            }
                            if (!string.IsNullOrEmpty(this.txtDeliveryTime.Value))
                            {
                                xMOrderInfo.DeliveryTime = Convert.ToDateTime(this.txtDeliveryTime.Value);
                            }
                            if (!string.IsNullOrEmpty(this.txtPayDate.Value))
                            {
                                xMOrderInfo.PayDate = Convert.ToDateTime(this.txtPayDate.Value);
                            }
                            if (!string.IsNullOrEmpty(this.txtPayDate.Value))
                            {
                                xMOrderInfo.OrderInfoCreateDate = Convert.ToDateTime(this.txtOrderInfoCreateDate.Value);
                            }
                            xMOrderInfo.SourceType = this.txtSourceType.Text;
                            xMOrderInfo.WantID = this.txtWantID.Text;
                            xMOrderInfo.IsScalping = this.ckbIsScalping.Checked;
                            xMOrderInfo.IsCashBack = this.ckbIsCashBack.Checked;
                            xMOrderInfo.IsSentGifts = this.ckbIsSentGifts.Checked;
                            xMOrderInfo.IsEvaluate = this.ckbIsEvaluate.Checked;
                            //商品价格
                            xMOrderInfo.ProductPrice = this.txtProductPrice.Text == "" ? 0 : decimal.Parse(this.txtProductPrice.Text);
                            xMOrderInfo.DistributePrice = this.txtDistributePrice.Text == "" ? 0 : decimal.Parse(this.txtDistributePrice.Text);
                            xMOrderInfo.SupportPrice = this.txtSupportPrice.Text == "" ? 0 : decimal.Parse(this.txtSupportPrice.Text);
                            xMOrderInfo.Taxes = this.txtTaxes.Text == "" ? 0 : decimal.Parse(this.txtTaxes.Text);
                            xMOrderInfo.Discount = this.txtDiscount.Text == "" ? 0 : decimal.Parse(this.txtDiscount.Text);
                            xMOrderInfo.ProductPromotion = this.txtProductPromotion.Text == "" ? 0 : decimal.Parse(this.txtProductPromotion.Text);
                            xMOrderInfo.OrderPromotion = this.txtOrderPromotion.Text == "" ? 0 : decimal.Parse(this.txtOrderPromotion.Text);
                            xMOrderInfo.OrderPrice = this.txtOrderPrice.Text == "" ? 0 : decimal.Parse(this.txtOrderPrice.Text);
                            xMOrderInfo.ReceivablePrice = this.txtReceivablePrice.Text == "" ? 0 : decimal.Parse(this.txtReceivablePrice.Text);
                            xMOrderInfo.PayPrice = this.txtPayPrice.Text == "" ? 0 : decimal.Parse(this.txtPayPrice.Text);
                            //订单其他信息
                            xMOrderInfo.DistributeMethod = this.txtDistributeMethod.Text;
                            xMOrderInfo.IsDistributed = this.ckbIsDistributed.Checked;
                            xMOrderInfo.ProductWeight = this.txtProductWeight.Text == "" ? 0 : decimal.Parse(this.txtProductWeight.Text);
                            xMOrderInfo.PayMethod = this.txtPayMethod.Text;
                            xMOrderInfo.InvoicePrice = this.txtInvoicePrice.Text == "" ? 0 : decimal.Parse(this.txtInvoicePrice.Text);
                            xMOrderInfo.IsInvoiced = this.ckbIsInvoiced.Checked;
                            xMOrderInfo.InvoiceNo = this.txtInvoiceNo.Text;
                            xMOrderInfo.InvoiceHead = this.txtInvoiceHead.Text;
                            //收货人信息
                            this.txtMobile.ReadOnly = true;
                            this.txtTel.ReadOnly = true;
                            this.txtAddress.ReadOnly = true;
                            this.txtDeliveryAddress.ReadOnly = true;
                            //this.txtDeliveryAddressSpare.ReadOnly = true;

                            if (!string.IsNullOrEmpty(this.txtAppointDeliveryTime.Value))
                            {
                                xMOrderInfo.AppointDeliveryTime = Convert.ToDateTime(this.txtAppointDeliveryTime.Value);
                            }
                            else
                            {
                                xMOrderInfo.AppointDeliveryTime = null;
                            }

                            xMOrderInfo.OrderCode = this.lblOrderCode.Text.Trim();
                            xMOrderInfo.FullName = this.txtFullName.Text.Trim();
                            xMOrderInfo.DeliveryAddress = this.txtDeliveryAddress.Text.Trim();

                            //更改收货地址
                            if (this.txtCustomerRemark.Text.Trim() != null && this.txtCustomerRemark.Text.Trim() != "")
                            {
                                if (this.txtCustomerRemark.Text.Trim().IndexOf("//更改床垫地址") > -1)
                                {
                                    string s = this.txtCustomerRemark.Text.Trim().Substring(this.txtCustomerRemark.Text.Trim().IndexOf("//更改床垫地址") + 8).Trim();

                                    int f = s.IndexOf("/");
                                    if (f > -1)
                                    {
                                        xMOrderInfo.DeliveryAddressSpare = s.Substring(0, f).Trim(); ;//备用收货地址

                                    }
                                    else
                                    {

                                        xMOrderInfo.DeliveryAddressSpare = "";
                                    }
                                }
                                else
                                {
                                    xMOrderInfo.DeliveryAddressSpare = "";
                                }
                            }

                            //xMOrderInfo.DeliveryAddressSpare = this.txtDeliveryAddressSpare.Text.Trim();

                            xMOrderInfo.Tel = this.txtTel.Text.Trim();
                            xMOrderInfo.Mobile = this.txtMobile.Text.Trim();
                            //备注
                            xMOrderInfo.Remark = this.txtRemark.Text.Trim();
                            xMOrderInfo.CustomerServiceRemark = this.txtCustomerRemark.Text.Trim();

                            xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            xMOrderInfo.UpdateDate = DateTime.Now;

                            #endregion

                            //修改后的客服备注信息 
                            string CustomerServiceRemarkNew = this.txtCustomerRemark.Text.Trim();

                            //买家备注 
                            string Remark = this.txtRemark.Text.Trim();

                            #region  判断是否刷单
                            bool IsScalping = false;
                            //刷单关键词
                            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(191, false);

                            if (codeList.Count > 0)
                            {

                                for (int cl = 0; cl < codeList.Count; cl++)
                                {
                                    string CodeName = "";
                                    CodeName = codeList[cl].CodeName.Trim();
                                    if (CustomerServiceRemarkNew.IndexOf(CodeName) > -1)
                                    {
                                        IsScalping = true;
                                    }
                                    if (Remark.IndexOf(CodeName) > -1)
                                    {
                                        IsScalping = true;
                                    }
                                }
                                #region 有返回刷单关键字

                                if (IsScalping == true)
                                {
                                    //根据订单号查询刷单记录 
                                    List<XMScalping> xmScalpingList = base.XMScalpingService.GetXMScalpingByOrderCode(this.lblOrderCode.Text.Trim());

                                    if (xmScalpingList.Count == 0)
                                    {
                                        string ProductName = "";
                                        var xMOrderInfoProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderCode(this.lblOrderCode.Text.Trim());
                                        if (xMOrderInfoProductDetails.Count > 0)
                                        {
                                            ProductName = xMOrderInfoProductDetails[0].ProductName;
                                        }

                                        #region 根据店铺Id查询项目  再根据项目Id、平台类型Id查询扣点

                                        int ProjectId = 0;
                                        //根据店铺Id查询  取项目Id
                                        var XMNick = base.XMNickService.GetXMNickByID(Convert.ToInt32(this.hfNickId.Value));
                                        if (XMNick != null)
                                        {
                                            if (XMNick.ProjectId != null)
                                            {
                                                ProjectId = XMNick.ProjectId.Value;
                                            }
                                        }
                                        //根据项目Id 平台类型查询 扣点 
                                        var xMDeductionSetUp = base.XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(ProjectId, 475, Convert.ToInt32(this.hfPlatformTypeId.Value));


                                        #endregion

                                        XMScalping xmScalping = new XMScalping();

                                        xmScalping.PlatformTypeId = Convert.ToInt32(this.hfPlatformTypeId.Value);
                                        xmScalping.NickId = Convert.ToInt32(this.hfNickId.Value);
                                        xmScalping.OrderCode = this.lblOrderCode.Text.Trim();
                                        xmScalping.WantID = this.txtWantID.Text.Trim();
                                        xmScalping.ProductName = ProductName;
                                        xmScalping.SalePrice = Convert.ToDecimal(this.txtPayPrice.Text.Trim());
                                        xmScalping.Fee = 0;
                                        if (xMDeductionSetUp != null)
                                        {
                                            //计算扣点
                                            if (xMDeductionSetUp.Deduction != null)
                                            {
                                                decimal DeductionD = xMDeductionSetUp.Deduction.Value / 100;

                                                xmScalping.Deduction = Convert.ToDecimal(this.txtPayPrice.Text.Trim()) * DeductionD;//扣点
                                            }
                                        }
                                        else
                                        {
                                            xmScalping.Deduction = 0;//扣点
                                        }
                                        xmScalping.IsAbnormal = false;
                                        xmScalping.IsEnable = false;
                                        xmScalping.CreateID = HozestERPContext.Current.User.CustomerID;
                                        xmScalping.CreateDate = DateTime.Now;
                                        xmScalping.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        xmScalping.UpdateDate = DateTime.Now;
                                        base.XMScalpingService.InsertXMScalping(xmScalping);
                                    }

                                    xMOrderInfo.IsScalping = IsScalping;
                                }
                                #endregion
                            }

                            #endregion

                            #region 赠品新增、修改;返现新增、修改 ;订单信息修改

                            //原赠品信息
                            string PremiumsOld = "";
                            //新赠品信息
                            string PremiumsNew = "";
                            //原返现信息 
                            string CashBackOld = "";
                            //新返现信息
                            string CashBackNew = "";
                            //返回赠品条数
                            int PremiumsInst = 0;
                            //返回返现条数
                            int CashBackInst = 0;

                            //判断备注信息中 赠品、返现信息是否修改过
                            if (CustomerServiceRemarkOld != CustomerServiceRemarkNew)
                            {

                                #region 原赠品信息
                                string strOld = "";
                                if (CustomerServiceRemarkOld.IndexOf("/赠品") > -1)
                                {
                                    strOld = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/赠品") + 3).Trim();
                                }
                                int fOld = strOld.IndexOf("/");
                                if (fOld > -1)
                                {
                                    PremiumsOld = strOld.Substring(0, fOld).Trim();
                                }
                                #endregion

                                #region 新赠品信息
                                string strNew = "";
                                if (CustomerServiceRemarkNew.IndexOf("/赠品") > -1)
                                {
                                    strNew = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/赠品") + 3).Trim();
                                }
                                int fNew = strNew.IndexOf("/");
                                if (fNew > -1)
                                {
                                    PremiumsNew = strNew.Substring(0, fNew).Trim();
                                }
                                #endregion

                                #region 赠品信息新增、修改

                                //根据订单号、赠品类型：赠品  查询 赠品申请表
                                List<XMPremiums> PremiumsList = base.XMPremiumsService.GetXMPremiumsListByOrderCode(this.lblOrderCode.Text.Trim(), (int)StatusEnum.ChildPremiums);

                                if (PremiumsOld != PremiumsNew)
                                {
                                    //赠品表中已经存在赠品信息
                                    if (PremiumsList.Count > 0)
                                    {
                                        var AlreadyCheckList = PremiumsList.Where(a => a.ManagerStatus.Value == (int)StatusEnum.AlreadyCheck).ToList();
                                        //赠品信息项目已审核 （不允许修改）
                                        if (AlreadyCheckList.Count > 0)
                                        {
                                            paramMessage = "订单号：" + this.lblOrderCode.Text.Trim() + "赠品信息已审核,不允许修改赠品内容.";

                                            base.ShowMessage(paramMessage);
                                            return;
                                        }
                                        //修改赠品信息
                                        else
                                        {
                                            //返回赠品条数
                                            PremiumsInst = base.XMOrderInfoAPIService.XMPremiumsInst(CustomerServiceRemarkNew, this.txtWantID.Text.Trim(), this.lblOrderCode.Text.Trim(), (int)StatusEnum.ChildPremiums, ref paramMessage, (int)xMOrderInfo.PlatformTypeId, (int)xMOrderInfo.NickID);
                                        }
                                    }
                                    else
                                    {
                                        //赠品表中不存在 （订单信息） 
                                        //返回赠品条数
                                        PremiumsInst = base.XMOrderInfoAPIService.XMPremiumsInst(CustomerServiceRemarkNew, this.txtWantID.Text.Trim(), this.lblOrderCode.Text.Trim(), (int)StatusEnum.ChildPremiums, ref paramMessage, (int)xMOrderInfo.PlatformTypeId, (int)xMOrderInfo.NickID);
                                    }
                                }
                                //最新的返现信息 为空
                                if (PremiumsNew == "")
                                {
                                    if (PremiumsList.Count > 0)
                                    {
                                        if (PremiumsList[0].ManagerStatus != Convert.ToInt32(StatusEnum.AlreadyCheck))
                                        {
                                            //删除原返现信息
                                            base.XMPremiumsService.DeleteXMPremiums(PremiumsList[0].Id);
                                        }
                                    }
                                }
                                #endregion

                                if (xMOrderInfo.PlatformTypeId.Value == 250)
                                {
                                    #region 原返现信息
                                    string strCBOld = "";
                                    if (CustomerServiceRemarkOld.IndexOf("/退差价") > -1)
                                    {
                                        strCBOld = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/退差价")).Trim();
                                    }
                                    string BuyerAlipayNoOld = "";//账号信息
                                    string BuyerNameOld = "";// 收款人账号

                                    if ((CustomerServiceRemarkOld.IndexOf("/支付宝") > -1 || CustomerServiceRemarkOld.IndexOf("/卡号") > -1))
                                    {
                                        if (CustomerServiceRemarkOld.IndexOf("/支付宝") > -1)
                                        {
                                            string a = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/支付宝") + 1).Trim();
                                            if (a.IndexOf("/") > 0)
                                            {
                                                int I2 = a.IndexOf("/");
                                                BuyerAlipayNoOld = a.Substring(0, I2);
                                            }
                                        }
                                        else if (CustomerServiceRemarkOld.IndexOf("/卡号") > -1)
                                        {
                                            string b = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/卡号") + 1).Trim();
                                            if (b.IndexOf("/") > 0)
                                            {
                                                int I = b.IndexOf("/");
                                                BuyerAlipayNoOld = b.Substring(0, I);
                                            }

                                        }
                                        if (BuyerAlipayNoOld != "")
                                        {
                                            int length = BuyerAlipayNoOld.Length + 1;
                                            string c = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf(BuyerAlipayNoOld) + length);
                                            //订单备注信息中 收货人后面有/
                                            int I3 = c.IndexOf("/");
                                            if (I3 > -1)
                                            {
                                                BuyerNameOld = c.Substring(0, I3);
                                            }
                                        }
                                    }
                                    //账号信息、收款人账号 都不为空
                                    if ((BuyerAlipayNoOld != "" && BuyerNameOld != "") || (BuyerAlipayNoOld == "" && BuyerNameOld != ""))
                                    {
                                        int f = strCBOld.IndexOf(BuyerNameOld);
                                        if (f > -1)
                                        {
                                            //原返现信息
                                            CashBackOld = strCBOld.Substring(0, f + BuyerNameOld.Length);
                                        }
                                    }
                                    else if (BuyerAlipayNoOld != "" && BuyerNameOld == "")
                                    {
                                        int f = strCBOld.IndexOf(BuyerAlipayNoOld);
                                        if (f > -1)
                                        {
                                            //原返现信息
                                            CashBackOld = strCBOld.Substring(0, f + BuyerAlipayNoOld.Length);
                                        }
                                    }
                                    else
                                    {
                                        int f = strCBOld.IndexOf("元/");

                                        if (f > -1)
                                        {
                                            CashBackOld = strCBOld.Substring(0, f + 2);//OrderRemark.Substring(OrderRemark.IndexOf("返现") + 2, OrderRemark.IndexOf("元/") - 2); 
                                        }
                                    }
                                    #endregion

                                    #region 新返现信息 (并有原返现信息对比   记录返现申请)

                                    string strCBNew = "";
                                    if (CustomerServiceRemarkNew.IndexOf("/退差价") > -1)
                                    {
                                        strCBNew = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/退差价")).Trim();
                                    }
                                    string BuyerAlipayNoNew = "";//账号信息
                                    string BuyerNameNew = "";// 收款人账号

                                    if ((CustomerServiceRemarkNew.IndexOf("/支付宝") > -1 || CustomerServiceRemarkNew.IndexOf("/卡号") > -1))
                                    {
                                        if (CustomerServiceRemarkNew.IndexOf("/支付宝") > -1)
                                        {
                                            string a = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/支付宝") + 1).Trim();
                                            if (a.IndexOf("/") > 0)
                                            {
                                                int I2 = a.IndexOf("/");
                                                BuyerAlipayNoNew = a.Substring(0, I2);
                                            }
                                        }
                                        else if (CustomerServiceRemarkNew.IndexOf("/卡号") > -1)
                                        {
                                            string b = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/卡号") + 1).Trim();
                                            if (b.IndexOf("/") > 0)
                                            {
                                                int I = b.IndexOf("/");
                                                BuyerAlipayNoNew = b.Substring(0, I);
                                            }

                                        }
                                        if (BuyerAlipayNoNew != "")
                                        {
                                            int length = BuyerAlipayNoNew.Length + 1;
                                            string c = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf(BuyerAlipayNoNew) + length);
                                            //订单备注信息中 收货人后面有/
                                            int I3 = c.IndexOf("/");
                                            if (I3 > -1)
                                            {
                                                BuyerNameNew = c.Substring(0, I3);
                                            }
                                        }
                                    }
                                    //账号信息、收款人账号 都不为空
                                    if ((BuyerAlipayNoNew != "" && BuyerNameNew != "") || (BuyerAlipayNoNew == "" && BuyerNameNew != ""))
                                    {
                                        int f = strCBNew.IndexOf(BuyerNameNew);
                                        if (f > -1)
                                        {
                                            //原返现信息
                                            CashBackNew = strCBNew.Substring(0, f + BuyerNameNew.Length);
                                        }


                                        #region 返现信息新增、修改 （有收款人账号、收款人姓名）

                                        //根据订单号、返现类型：返现 查询返现申请
                                        List<XMCashBackApplication> XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByOrderCode(this.lblOrderCode.Text.Trim(), (int)StatusEnum.ChildCashBack);

                                        if (CashBackOld != CashBackNew)
                                        {

                                            if (XMCashBackApplicationList.Count > 0)
                                            {

                                                var AlreadyCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == (int)StatusEnum.AlreadyCheck).ToList();

                                                //返现信息项目已审核 （不允许修改）
                                                if (AlreadyCheckList.Count > 0)
                                                {
                                                    paramMessage = "订单号：" + this.lblOrderCode.Text.Trim() + "返现信息已审核,不允许修改返现内容.";

                                                    base.ShowMessage(paramMessage);
                                                    return;
                                                }
                                                //修改返现信息
                                                else
                                                {
                                                    //返回返现条数
                                                    CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, this.txtWantID.Text.Trim(), this.lblOrderCode.Text.Trim(), this.txtFullName.Text.Trim(), (int)StatusEnum.ChildCashBack, ref paramMessage);
                                                }
                                            }
                                            else
                                            {
                                                //返回返现条数
                                                CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, this.txtWantID.Text.Trim(), this.lblOrderCode.Text.Trim(), this.txtFullName.Text.Trim(), (int)StatusEnum.ChildCashBack, ref paramMessage);
                                            }
                                        }

                                        //最新的返现信息 为空
                                        if (CashBackNew == "")
                                        {
                                            if (XMCashBackApplicationList.Count > 0)
                                            {
                                                if (XMCashBackApplicationList[0].ManagerStatus != Convert.ToInt32(StatusEnum.AlreadyCheck))
                                                {
                                                    //删除原返现信息
                                                    // base.XMCashBackApplicationService.DeleteXMCashBackApplication(XMCashBackApplicationList[0].Id);//不自动删除，增删改到返现申请里面操作
                                                }

                                            }
                                        }
                                        #endregion
                                    }
                                    else if (BuyerAlipayNoNew != "" && BuyerNameNew == "")
                                    {
                                        int f = strCBNew.IndexOf(BuyerAlipayNoNew);
                                        if (f > -1)
                                        {
                                            //原返现信息
                                            CashBackNew = strCBNew.Substring(0, f + BuyerAlipayNoNew.Length);
                                        }


                                        #region 返现信息新增、修改 （有收款人账号、收款人姓名）

                                        //根据订单号、返现类型：返现 查询返现申请
                                        List<XMCashBackApplication> XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByOrderCode(this.lblOrderCode.Text.Trim(), (int)StatusEnum.ChildCashBack);

                                        if (CashBackOld != CashBackNew)
                                        {

                                            if (XMCashBackApplicationList.Count > 0)
                                            {

                                                var AlreadyCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == (int)StatusEnum.AlreadyCheck).ToList();

                                                //返现信息项目已审核 （不允许修改）
                                                if (AlreadyCheckList.Count > 0)
                                                {
                                                    paramMessage = "订单号：" + this.lblOrderCode.Text.Trim() + "返现信息已审核,不允许修改返现内容.";

                                                    base.ShowMessage(paramMessage);
                                                    return;
                                                }
                                                //修改返现信息
                                                else
                                                {
                                                    //返回返现条数
                                                    CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, this.txtWantID.Text.Trim(), this.lblOrderCode.Text.Trim(), this.txtFullName.Text.Trim(), (int)StatusEnum.ChildCashBack, ref paramMessage);
                                                }
                                            }
                                            else
                                            {
                                                //返回返现条数
                                                CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, this.txtWantID.Text.Trim(), this.lblOrderCode.Text.Trim(), this.txtFullName.Text.Trim(), (int)StatusEnum.ChildCashBack, ref paramMessage);
                                            }
                                        }

                                        //最新的返现信息 为空
                                        if (CashBackNew == "")
                                        {
                                            if (XMCashBackApplicationList.Count > 0)
                                            {
                                                if (XMCashBackApplicationList[0].ManagerStatus != Convert.ToInt32(StatusEnum.AlreadyCheck))
                                                {
                                                    //删除原返现信息
                                                    //base.XMCashBackApplicationService.DeleteXMCashBackApplication(XMCashBackApplicationList[0].Id);//不自动删除，增删改到返现申请里面操作
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        int f = strCBNew.IndexOf("元/");

                                        if (f > -1)
                                        {
                                            CashBackNew = strCBNew.Substring(0, f + 2);//OrderRemark.Substring(OrderRemark.IndexOf("返现") + 2, OrderRemark.IndexOf("元/") - 2); 
                                        }

                                        #region 返现信息新增、修改  （无收款人账号、收款人姓名）

                                        //根据订单号、返现类型：返现 查询返现申请
                                        List<XMCashBackApplication> XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByOrderCode(this.lblOrderCode.Text.Trim(), (int)StatusEnum.ChildCashBack);

                                        if (CashBackOld != CashBackNew)
                                        {

                                            if (XMCashBackApplicationList.Count > 0)
                                            {

                                                var AlreadyCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == (int)StatusEnum.AlreadyCheck).ToList();

                                                //返现信息项目已审核 （不允许修改）
                                                if (AlreadyCheckList.Count > 0)
                                                {
                                                    paramMessage = "订单号：" + this.lblOrderCode.Text.Trim() + "返现信息已审核,不允许修改返现内容.";

                                                    base.ShowMessage(paramMessage);
                                                    return;
                                                }
                                                //修改返现信息
                                                else
                                                {
                                                    //返回返现条数
                                                    CashBackInst = base.XMOrderInfoAPIService.TMCashBackApplicationInst(CustomerServiceRemarkNew, this.txtWantID.Text.Trim(), this.lblOrderCode.Text.Trim(), this.txtFullName.Text.Trim(), (int)StatusEnum.ChildCashBack, ref paramMessage);
                                                }
                                            }
                                            else
                                            {
                                                //返回返现条数
                                                CashBackInst = base.XMOrderInfoAPIService.TMCashBackApplicationInst(CustomerServiceRemarkNew, this.txtWantID.Text.Trim(), this.lblOrderCode.Text.Trim(), this.txtFullName.Text.Trim(), (int)StatusEnum.ChildCashBack, ref paramMessage);
                                            }
                                        }

                                        //最新的返现信息 为空
                                        if (CashBackNew == "")
                                        {
                                            if (XMCashBackApplicationList.Count > 0)
                                            {
                                                if (XMCashBackApplicationList[0].ManagerStatus != Convert.ToInt32(StatusEnum.AlreadyCheck))
                                                {
                                                    //删除原返现信息
                                                    // base.XMCashBackApplicationService.DeleteXMCashBackApplication(XMCashBackApplicationList[0].Id);//不自动删除，增删改到返现申请里面操作
                                                }
                                            }
                                        }
                                        #endregion

                                    }

                                    #endregion

                                }
                                else
                                {
                                    #region 原返现信息
                                    string strCBOld = "";
                                    if (CustomerServiceRemarkOld.IndexOf("/退差价") > -1)
                                    {
                                        strCBOld = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/退差价")).Trim();
                                    }
                                    string BuyerAlipayNoOld = "";//账号信息
                                    string BuyerNameOld = "";// 收款人账号

                                    if ((CustomerServiceRemarkOld.IndexOf("/支付宝") > -1 || CustomerServiceRemarkOld.IndexOf("/卡号") > -1))
                                    {
                                        if (CustomerServiceRemarkOld.IndexOf("/支付宝") > -1)
                                        {
                                            string a = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/支付宝") + 1).Trim();
                                            if (a.IndexOf("/") > 0)
                                            {
                                                int I2 = a.IndexOf("/");
                                                BuyerAlipayNoOld = a.Substring(0, I2);
                                            }
                                        }
                                        else if (CustomerServiceRemarkOld.IndexOf("/卡号") > -1)
                                        {
                                            string b = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf("/卡号") + 1).Trim();
                                            if (b.IndexOf("/") > 0)
                                            {
                                                int I = b.IndexOf("/");
                                                BuyerAlipayNoOld = b.Substring(0, I);
                                            }

                                        }
                                        if (BuyerAlipayNoOld != "")
                                        {
                                            int length = BuyerAlipayNoOld.Length + 1;
                                            string c = CustomerServiceRemarkOld.Substring(CustomerServiceRemarkOld.IndexOf(BuyerAlipayNoOld) + length);
                                            //订单备注信息中 收货人后面有/
                                            int I3 = c.IndexOf("/");
                                            if (I3 > -1)
                                            {
                                                BuyerNameOld = c.Substring(0, I3);
                                            }
                                        }
                                    }
                                    //账号信息、收款人账号 都不为空
                                    if ((BuyerAlipayNoOld != "" && BuyerNameOld != "") || (BuyerAlipayNoOld == "" && BuyerNameOld != ""))
                                    {
                                        int f = strCBOld.IndexOf(BuyerNameOld);
                                        if (f > -1)
                                        {
                                            //原返现信息
                                            CashBackOld = strCBOld.Substring(0, f + BuyerNameOld.Length);
                                        }
                                    }
                                    else if (BuyerAlipayNoOld != "" && BuyerNameOld == "")
                                    {
                                        int f = strCBOld.IndexOf(BuyerAlipayNoOld);
                                        if (f > -1)
                                        {
                                            //原返现信息
                                            CashBackOld = strCBOld.Substring(0, f + BuyerAlipayNoOld.Length);
                                        }
                                    }
                                    #endregion

                                    #region 新返现信息

                                    string strCBNew = "";
                                    if (CustomerServiceRemarkNew.IndexOf("/退差价") > -1)
                                    {
                                        strCBNew = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/退差价")).Trim();
                                    }
                                    string BuyerAlipayNoNew = "";//账号信息
                                    string BuyerNameNew = "";// 收款人账号

                                    if ((CustomerServiceRemarkNew.IndexOf("/支付宝") > -1 || CustomerServiceRemarkNew.IndexOf("/卡号") > -1))
                                    {
                                        if (CustomerServiceRemarkNew.IndexOf("/支付宝") > -1)
                                        {
                                            string a = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/支付宝") + 1).Trim();
                                            if (a.IndexOf("/") > 0)
                                            {
                                                int I2 = a.IndexOf("/");
                                                BuyerAlipayNoNew = a.Substring(0, I2);
                                            }
                                        }
                                        else if (CustomerServiceRemarkNew.IndexOf("/卡号") > -1)
                                        {
                                            string b = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf("/卡号") + 1).Trim();
                                            if (b.IndexOf("/") > 0)
                                            {
                                                int I = b.IndexOf("/");
                                                BuyerAlipayNoNew = b.Substring(0, I);
                                            }

                                        }
                                        if (BuyerAlipayNoNew != "")
                                        {
                                            int length = BuyerAlipayNoNew.Length + 1;
                                            string c = CustomerServiceRemarkNew.Substring(CustomerServiceRemarkNew.IndexOf(BuyerAlipayNoNew) + length);
                                            //订单备注信息中 收货人后面有/
                                            int I3 = c.IndexOf("/");
                                            if (I3 > -1)
                                            {
                                                BuyerNameNew = c.Substring(0, I3);
                                            }
                                        }
                                    }
                                    //账号信息、收款人账号 都不为空
                                    if ((BuyerAlipayNoNew != "" && BuyerNameNew != "") || (BuyerAlipayNoNew == "" && BuyerNameNew != ""))
                                    {
                                        int f = strCBNew.IndexOf(BuyerNameNew);
                                        if (f > -1)
                                        {
                                            //原返现信息
                                            CashBackNew = strCBNew.Substring(0, f + BuyerNameNew.Length);
                                        }
                                    }
                                    else if (BuyerAlipayNoNew != "" && BuyerNameNew == "")
                                    {
                                        int f = strCBNew.IndexOf(BuyerAlipayNoNew);
                                        if (f > -1)
                                        {
                                            //原返现信息
                                            CashBackNew = strCBNew.Substring(0, f + BuyerAlipayNoNew.Length);
                                        }
                                    }

                                    #endregion

                                    #region 返现信息新增、修改

                                    //根据订单号、返现类型：返现 查询返现申请
                                    List<XMCashBackApplication> XMCashBackApplicationList = base.XMCashBackApplicationService.GetXMCashBackApplicationByOrderCode(this.lblOrderCode.Text.Trim(), (int)StatusEnum.ChildCashBack);

                                    if (CashBackOld != CashBackNew)
                                    {

                                        if (XMCashBackApplicationList.Count > 0)
                                        {

                                            var AlreadyCheckList = XMCashBackApplicationList.Where(a => a.ManagerStatus.Value == (int)StatusEnum.AlreadyCheck).ToList();

                                            //返现信息项目已审核 （不允许修改）
                                            if (AlreadyCheckList.Count > 0)
                                            {
                                                paramMessage = "订单号：" + this.lblOrderCode.Text.Trim() + "返现信息已审核,不允许修改返现内容.";

                                                base.ShowMessage(paramMessage);
                                                return;
                                            }
                                            //修改返现信息
                                            else
                                            {
                                                //返回返现条数
                                                CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, this.txtWantID.Text.Trim(), this.lblOrderCode.Text.Trim(), this.txtFullName.Text.Trim(), (int)StatusEnum.ChildCashBack, ref paramMessage);
                                            }
                                        }
                                        else
                                        {
                                            //返回返现条数
                                            CashBackInst = base.XMOrderInfoAPIService.CashBackApplicationInst(CustomerServiceRemarkNew, this.txtWantID.Text.Trim(), this.lblOrderCode.Text.Trim(), this.txtFullName.Text.Trim(), (int)StatusEnum.ChildCashBack, ref paramMessage);
                                        }
                                    }

                                    //最新的返现信息 为空
                                    if (CashBackNew == "")
                                    {
                                        if (XMCashBackApplicationList.Count > 0)
                                        {
                                            if (XMCashBackApplicationList[0].ManagerStatus != Convert.ToInt32(StatusEnum.AlreadyCheck))
                                            {
                                                //删除原返现信息
                                                // base.XMCashBackApplicationService.DeleteXMCashBackApplication(XMCashBackApplicationList[0].Id);//不自动删除，增删改到返现申请里面操作
                                            }
                                        }
                                    }
                                    #endregion
                                }

                                if (xMOrderInfo.SourceType == "同步")
                                {
                                    #region 修改平台后台备注信息

                                    if (xMOrderInfo != null)
                                    {
                                        //订单号
                                        string OrderCode = this.lblOrderCode.Text.Trim();

                                        var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();

                                        List<XMOrderInfoApp> xMorderInfoAppNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == xMOrderInfo.PlatformTypeId && q.NickId == xMOrderInfo.NickID).ToList();
                                        if (xMorderInfoAppNew.Count > 0)
                                        {
                                            for (int k = 0; k < xMorderInfoAppNew.Count; k++)
                                            {
                                                #region  京东、京东闪购
                                                if (xMorderInfoAppNew[k].PlatformTypeId == 251 || xMorderInfoAppNew[k].PlatformTypeId == 382 || xMorderInfoAppNew[k].PlatformTypeId == 823)
                                                {
                                                    #region 平台后台修改备注 (功能取消）
                                                    //修改备注 
                                                    var orderVenderRemark = base.XMOrderInfoAPIService.SetOrderVenderRemark(OrderCode, this.txtCustomerRemark.Text.Trim(), "", xMorderInfoAppNew[k]);
                                                    if (orderVenderRemark != null)
                                                    {

                                                        if (orderVenderRemark.OUP != null)
                                                        {

                                                            if (orderVenderRemark.OUP.Code.ToString() == "0")
                                                            {
                                                                base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                                                paramMessage = "操作成功.";
                                                                //            //return;
                                                            }
                                                            else
                                                            {
                                                                paramMessage = "操作失败,请联系管理员.";
                                                                //return;
                                                            }
                                                        }
                                                    }

                                                    #endregion
                                                }
                                                #endregion

                                                #region  淘宝、淘宝集市店
                                                else if (xMorderInfoAppNew[k].PlatformTypeId == 250 || xMorderInfoAppNew[k].PlatformTypeId == 381)
                                                {
                                                    #region 平台后台修改备注
                                                    //修改备注
                                                    var tradeMemoUpdate = base.XMOrderInfoAPIService.ReturnTradeMemoUpdate(Convert.ToInt64(OrderCode), this.txtCustomerRemark.Text.Trim(), xMorderInfoAppNew[k]);

                                                    if (tradeMemoUpdate != null)
                                                    {

                                                        base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                                        paramMessage = "操作成功.";
                                                        //return;
                                                    }
                                                    else
                                                    {
                                                        paramMessage = "操作失败,请联系管理员.";
                                                        //return; 
                                                    }

                                                    #endregion
                                                }
                                                #endregion

                                                #region 一号店
                                                else if (xMorderInfoAppNew[k].PlatformTypeId == 375)
                                                {
                                                    #region 平台后台修改备注
                                                    //修改备注 
                                                    int OrderMerchantRemarkUpdateInt = base.XMOrderInfoAPIService.OrderMerchantRemarkUpdate(OrderCode, this.txtCustomerRemark.Text.Trim(), xMorderInfoAppNew[k]);

                                                    if (OrderMerchantRemarkUpdateInt == 1)
                                                    {
                                                        base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                                        paramMessage = "操作成功.";
                                                        // return; 
                                                    }
                                                    else
                                                    {

                                                        paramMessage = "操作失败,请联系管理员.";
                                                        //return; 
                                                    }

                                                    #endregion
                                                }
                                                #endregion

                                                #region  苏宁易购
                                                else if (xMorderInfoAppNew[k].PlatformTypeId == 383)
                                                {
                                                    #region 平台后台修改备注

                                                    string colorMarkFlag = "";
                                                    if (this.txtCustomerRemark.Text.Trim().IndexOf("已提单") > -1)
                                                    {
                                                        colorMarkFlag = "2";//交易备注旗帜, 空表示灰色， 1表示红色， 2表示黄色， 3表示绿色， 4表示蓝色， 5表示紫色
                                                    }
                                                    else
                                                    {
                                                        colorMarkFlag = "1";
                                                    }
                                                    //修改备注
                                                    var tradeMemoUpdate = base.XMOrderInfoAPIService.OrdernoteModifyUpdate(xMOrderInfo.OrderCode, this.txtCustomerRemark.Text.Trim(), colorMarkFlag, xMorderInfoAppNew[k]);

                                                    if (tradeMemoUpdate != null && tradeMemoUpdate != "")
                                                    {
                                                        if (tradeMemoUpdate == "Y")
                                                        {
                                                            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                                            paramMessage = "苏宁易购平台操作成功.";
                                                            // return;
                                                        }
                                                        else
                                                        {
                                                            paramMessage = "苏宁易购平台操作失败,请联系管理员.";
                                                            //return;
                                                        }
                                                    }

                                                    #endregion
                                                }
                                                #endregion

                                                //其它平台信息修改
                                                else
                                                {
                                                    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                                    paramMessage = "操作成功.";
                                                }

                                                //唯品会
                                                //else if (xMorderInfoAppNew[0].PlatformTypeId == 259)
                                                //{
                                                //    return;
                                                //}
                                            }
                                        }
                                        else
                                        {
                                            base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                            paramMessage = "操作成功.";
                                        }
                                    }

                                    #endregion
                                }
                                else
                                {
                                    base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                    paramMessage = "操作成功.";
                                }
                            }
                            // 修改其他信息
                            else
                            {
                                base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                                paramMessage = "操作成功.";
                            }

                            #endregion
                        }

                        scope.Complete();
                        base.ShowMessage(paramMessage);
                    }
                    catch (Exception err)
                    {
                        this.ProcessException(err);
                    }

                }
            }
            this.ReadOnlyN();
            LoadDate();
        }

        //protected void btnClose_Click(object sender, EventArgs e)
        //{
        //    //window.close(); 
        //    StringBuilder scriptString = new StringBuilder();
        //    scriptString.Append("<script language = javascript>");
        //    scriptString.Append(" window.close(); ");
        //    scriptString.Append("</" + "script>");
        //    Response.Write(scriptString.ToString()); 
        //}

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);
            if (xMOrderInfo != null)
            {
                bool Edit = false;
                if (xMOrderInfo.XM_OrderInfoProductDetails == null || xMOrderInfo.XM_OrderInfoProductDetails.Count == 0)
                {
                    Edit = true;
                }

                if (xMOrderInfo.NickID != 32 && xMOrderInfo.XM_OrderInfoProductDetails.Count > 0)
                {
                    foreach (var Info in xMOrderInfo.XM_OrderInfoProductDetails)
                    {
                        if (Info.IsSingleRow == null || Info.IsSingleRow == false)
                        {
                            Edit = true;
                            break;
                        }
                    }
                }
                else if (xMOrderInfo.NickID == 32 && xMOrderInfo.XM_OrderInfoProductDetails.Count > 0)
                {
                    foreach (var Info in xMOrderInfo.XM_OrderInfoProductDetails)
                    {
                        if (Info.PlatformMerchantCode.Length > 2 && Info.PlatformMerchantCode.Substring(0, 2) == "CM" && (Info.IsSingleRow == null || Info.IsSingleRow == false))
                        {
                            Edit = true;
                            break;
                        }
                    }
                }

                if (Edit)
                {
                    this.ReadOnlyY();
                }
                else
                {
                    this.ReadOnlyN();

                    //备注
                    this.txtRemark.ReadOnly = false;
                    this.btnSave.Visible = true;
                    this.btnClose.Visible = true;
                    this.btnEdit.Visible = false;
                    this.btnIsAudit.Visible = false;
                }
            }
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAudit_Click(object sender, EventArgs e)
        {
            var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);

            if (xMOrderInfo != null)//修改
            {
                if (!IsAllowAudit(xMOrderInfo))
                {
                    base.ShowMessage("该订单状态不正确，不能审核！");
                    return;
                }
                bool IsAudit = true;
                foreach (XMOrderInfoProductDetails xmpd in xMOrderInfo.XM_OrderInfoProductDetails)
                {
                    xmpd.IsAudit = true;
                    xmpd.UpdateID = HozestERPContext.Current.User.CustomerID;
                    xmpd.UpdateDate = DateTime.Now;
                    if (xmpd.IsAudit == true)
                    {
                        IsAudit = true;
                    }
                }
                xMOrderInfo.IsAudit = true;
                xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                xMOrderInfo.UpdateDate = DateTime.Now;

                XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                record.PropertyName = "IsAudit";
                record.OldValue = System.Convert.ToString(IsAudit);
                record.NewValue = System.Convert.ToString(true);
                record.OrderInfoId = this.XMOrderInfoID;
                record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                record.UpdateTime = DateTime.Now;
                base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);

                base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                base.ShowMessage("操作成功！");
            }
        }

        public bool IsAllowAudit(XMOrderInfo Info)
        {
            bool status = false;
            if (Info.PlatformTypeId == 250 || Info.PlatformTypeId == 381)
            {
                if (Info.OrderStatus == "WAIT_SELLER_SEND_GOODS")
                {
                    status = true;
                }
                //订单状态为已发货且发货时间不为空
                if (Info.OrderStatus == "WAIT_BUYER_CONFIRM_GOODS" && Info.DeliveryTime != null)
                {
                    status = true;
                }
                //订单状态为已完成且完成时间不为空
                if (Info.OrderStatus == "TRADE_FINISHED" && Info.CompletionTime != null)
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 511)
            {
                if (Info.OrderStatus == "DS_WAIT_SELLER_DELIVERY")
                {
                    status = true;
                }
                //订单状态为已发货且发货时间不为空
                if (Info.OrderStatus == "DS_WAIT_BUYER_RECEIVE" && Info.DeliveryTime != null)
                {
                    status = true;
                }
                //订单状态为已完成且完成时间不为空
                if (Info.OrderStatus == "DS_DEAL_END_NORMAL" && Info.CompletionTime != null)
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 251 || Info.PlatformTypeId == 537 || Info.PlatformTypeId == 382 || Info.PlatformTypeId == 691)
            {
                if (Info.OrderStatus == "WAIT_SELLER_DELIVERY" || Info.OrderStatus == "WAIT_SELLER_STOCK_OUT")
                {
                    status = true;
                }
                if (Info.OrderStatus == "WAIT_GOODS_RECEIVE_CONFIRM" && Info.DeliveryTime != null)
                {
                    status = true;
                }
                if (Info.OrderStatus == "FINISHED_L" && Info.CompletionTime != null)
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 259)
            {
                if (Info.OrderStatus == "STATUS_10")
                {
                    status = true;
                }
                if (Info.OrderStatus == "STATUS_22" && Info.DeliveryTime != null)           //订单状态为已发货 且发货时间不为空
                {
                    status = true;
                }
                if (Info.OrderStatus == "STATUS_25" && Info.CompletionTime != null)      //订单已经完成 且完成时间不为空
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 375)
            {
                if (Info.OrderStatus == "ORDER_TRUNED_TO_DO")
                {
                    status = true;
                }
                if (Info.OrderStatus == "ORDER_OUT_OF_WH" && Info.DeliveryTime != null)          //订单状态已发货
                {
                    status = true;
                }
                if (Info.OrderStatus == "ORDER_FINISH" && Info.CompletionTime != null)            //订单已完成且完成时间不为空
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 376)
            {
                if (Info.OrderStatus == "以接受")
                {
                    status = true;
                }
                if (Info.OrderStatus == "已发货" && Info.DeliveryTime != null)
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 383)
            {
                if (Info.OrderStatus == "10")
                {
                    status = true;
                }
                if (Info.OrderStatus == "20" && Info.DeliveryTime != null)                    //订单状态已发货且发货时间不为空
                {
                    status = true;
                }
                if (Info.OrderStatus == "30" && Info.CompletionTime != null)
                {
                    status = true;
                }
            }
            if (Info.PlatformTypeId == 736 || Info.PlatformTypeId == 825)//以后其他通用状态在都使用这个IF
            {
                if (Info.OrderStatus == "已付款")
                {
                    status = true;
                }
                if (Info.OrderStatus == "已发货" && Info.DeliveryTime != null)                    //订单状态已发货且发货时间不为空
                {
                    status = true;
                }
                if (Info.OrderStatus == "已完成" && Info.CompletionTime != null)
                {
                    status = true;
                }
            }
            return status;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            LoadDate();
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

        public bool IsCM
        {
            get
            {
                int cm = CommonHelper.QueryStringInt("IsCM");
                if (cm == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="OrderStatus"></param>
        /// <returns></returns>
        protected string GetOrderStatus(string OrderStatus, string platformtypeid)
        {
            var platFormTypeID = string.Empty;
            switch(platformtypeid)
            {
                case "537":
                    platFormTypeID = "194";
                    break;
            }
            var codeTypeInfo = base.CodeTypeService.GetCodeTypeByPlatFormTypeId(platformtypeid).SingleOrDefault();
            if (codeTypeInfo != null)
            {
                var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(codeTypeInfo.CodeTypeID);
                var Setting = codeList.FirstOrDefault(p => p.CodeNO.Equals(OrderStatus));
                if (Setting != null)
                {
                    return Setting.CodeName;
                }
                else
                {
                    return "";
                }
            }
            else //其他类型订单全部使用通用状态
            {
                var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(239);
                var Setting = codeList.FirstOrDefault(p => p.CodeNO.Equals(OrderStatus));
                if (Setting != null)
                {
                    return Setting.CodeName;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}