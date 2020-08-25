using System;
using System.Linq;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using HozestERP.BusinessLogic.ManageFinance;

namespace HozestERP.Web.ManageInventory
{
    public partial class PurchaseAdd : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";

        private bool IsAudit = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBind(this.type);
                if (this.type == 0)           //新增
                {
                    lblTitle.Text = "新建采购订单";
                    lblNumber.Visible = false;
                    txtPurchaseNumber.Visible = true;
                    BindSupplierInfo();
                    GetPurchaseList();
                    btnPurchaseSingleIsAudit.Visible = false;
                    btnPurchaseSingleIsAuditFalse.Visible = false;
                }
                else if (this.type == 1)   //编辑
                {
                    lblTitle.Text = "编辑采购订单";
                    lblNumber.Visible = true;
                    chkAutoID.Visible = false;
                    lbl1.Visible = false;
                    txtPurchaseNumber.Visible = false;
                    BindGrid(this.scid);
                    if (IsAudit)//已经审核通过的
                    {
                        btnSave.Visible = false;
                        btnPurchaseSingleIsAudit.Visible = false;
                        btnPurchaseSingleIsAuditFalse.Visible = true;
                    }
                    else
                    {
                        btnPurchaseSingleIsAudit.Visible = true;
                        btnPurchaseSingleIsAuditFalse.Visible = false;
                    }
                }
                else                               //查看（无法保存）
                {
                    lblTitle.Text = "查看采购订单";
                    lblNumber.Visible = true;
                    chkAutoID.Visible = false;
                    lbl1.Visible = false;
                    txtPurchaseNumber.Visible = false;
                    BindGrid2(this.scid);
                    btnSave.Visible = false;
                    btnPurchaseSingleIsAudit.Visible = false;
                    btnPurchaseSingleIsAuditFalse.Visible = false;
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            hiddType.Value = this.type.ToString();
        }

        private void GetPurchaseList()
        {
            //新增
            if (this.type == 0)
            {
                StringBuilder str = new StringBuilder();
                str.Append("<table class='table' id='MyPurchaseProductList' >");
                str.Append("<tr >");
                str.Append("<th>厂家编码</th><th>商品名称</th><th>平台</th><th>尺寸规格</th><th>采购数量</th><th>单位</th><th>采购单价</th><th>采购金额</th><th>操作</th></tr>");
                str.Append("<tr  id=\"mytr\">");
                str.Append("<td><input id=\"hiddProductId\" type=\"hidden\" /><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value=''  readonly=\"readonly\"/></td><td><input  id=\"txtProductName\" class=\"TextBox ProductName\"  type=\"text\" style=\"text-align: left;width: 90%\" value='' /></td><td id=\"tdplatform\"><select  id=\"ddlPlatForm\"></select></td><td style=\"width:10%\"><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='' /></td><td style=\"width:5%\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='0' /></td><td style=\"width:3%\"><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='' readonly=\"readonly\" /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td style=\"width:5%\"><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }

        public void BindGrid(int purchaseId)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>平台</th><th>尺寸规格</th><th>采购数量</th><th>单位</th><th>采购单价</th><th>采购金额</th><th>操作</th></tr>");
            var purchase = base.XMPurchaseService.GetXMPurchaseById(purchaseId);
            if (purchase != null)
            {
                IsAudit = purchase.IsAudit.GetValueOrDefault(false);
                lblNumber.Text = purchase.PurchaseNumber;
                var purchaseProductDetails = base.XMPurchaseProductDetailsService.GetXMPurchaseProductDetailsByPurchaseID(purchase.Id);
                txtDeliveryDate.Value = purchase.DealDate.ToString() == "" ? DateTime.Now.ToShortDateString() : purchase.DealDate.ToString();
                ddlSuppliers.SelectedValue = purchase.SupplierId.ToString();
                txtContacter.Text = purchase.Contact;
                txtTel.Text = purchase.Tel;
                txtFax.Text = purchase.Fax;
                txtDeliveryAddresss.Text = purchase.DealAddress;
                txtPurchaseDate.Value = purchase.PurchaseDate.ToString() == "" ? DateTime.Now.ToShortDateString() : purchase.PurchaseDate.ToString();
                ddlPayType.SelectedValue = purchase.PaymentType.ToString();
                txtNote.Text = purchase.BillMemo;
                txtBuyerName.Text = string.IsNullOrEmpty(purchase.BuyMember) ? "" : purchase.BuyMember;
                txtResiveName.Text = string.IsNullOrEmpty(purchase.Receiver) ? "" : purchase.Receiver;
                txtRecivesMobile.Text = string.IsNullOrEmpty(purchase.ReceiverMobile) ? "" : purchase.ReceiverMobile;
                txtSendFactory.Text = string.IsNullOrEmpty(purchase.EmitFactory) ? "" : purchase.EmitFactory;
                TextBox1.Text = string.IsNullOrEmpty(purchase.SellerRemarks) ? "" : purchase.SellerRemarks;
                txtLogisticsFee.Text = purchase.LogisticsFee == null ? "" : purchase.LogisticsFee.ToString();
                if (purchaseProductDetails != null && purchaseProductDetails.Count > 0)
                {
                    foreach (XMPurchaseProductDetails info in purchaseProductDetails)
                    {
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td><input id=\"hiddProductId\" type=\"hidden\"  value='" + info.ProductId + "'/><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.PlatformMerchantCode + "'   readonly=\"readonly\"/></td><td><input  id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" value='" + info.ProductName + "'   type=\"text\"/></td><td id=\"tdplatform\"><select  id=\"ddlPlatForm\"  selectValue='" + info.PlatformTypeId + "'></select></td><td style=\"width:10%\"><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + info.Specifications + "' /></td><td style=\"width:5%\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductCount.ToString() + "' /></td><td style=\"width:3%\"><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\"  readonly=\"readonly\"   value='" + info.ProductUnit + "'/></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductPrice.ToString() + "' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductMoney.ToString() + "' /></td><td style=\"width:5%\"><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                    }
                }
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }

        /// <summary>
        /// 审核后无法修改 页面绑定
        /// </summary>
        /// <param name="purchaseId"></param>
        public void BindGrid2(int purchaseId)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>平台</th><th>尺寸规格</th><th>采购数量</th><th>单位</th><th>采购单价</th><th>采购金额</th></tr>");
            var purchase = base.XMPurchaseService.GetXMPurchaseById(purchaseId);
            if (purchase != null)
            {
                lblNumber.Text = purchase.PurchaseNumber;
                var purchaseProductDetails = base.XMPurchaseProductDetailsService.GetXMPurchaseProductDetailsByPurchaseID(purchase.Id);
                txtDeliveryDate.Value = purchase.DealDate.ToString() == "" ? DateTime.Now.ToShortDateString() : purchase.DealDate.ToString();
                ddlSuppliers.SelectedValue = purchase.SupplierId.ToString();
                txtContacter.Text = purchase.Contact;
                txtTel.Text = purchase.Tel;
                txtFax.Text = purchase.Fax;
                txtDeliveryAddresss.Text = purchase.DealAddress;
                txtPurchaseDate.Value = purchase.PurchaseDate.ToString() == "" ? DateTime.Now.ToShortDateString() : purchase.PurchaseDate.ToString();
                ddlPayType.SelectedValue = purchase.PaymentType.ToString();
                txtNote.Text = purchase.BillMemo;
                txtBuyerName.Text = string.IsNullOrEmpty(purchase.BuyMember) ? "" : purchase.BuyMember;
                txtResiveName.Text = string.IsNullOrEmpty(purchase.Receiver) ? "" : purchase.Receiver;
                txtRecivesMobile.Text = string.IsNullOrEmpty(purchase.ReceiverMobile) ? "" : purchase.ReceiverMobile;
                txtSendFactory.Text = string.IsNullOrEmpty(purchase.EmitFactory) ? "" : purchase.EmitFactory;
                TextBox1.Text = string.IsNullOrEmpty(purchase.SellerRemarks) ? "" : purchase.SellerRemarks;
                txtLogisticsFee.Text = purchase.LogisticsFee == null ? "" : purchase.LogisticsFee.ToString();
                if (purchaseProductDetails != null && purchaseProductDetails.Count > 0)
                {
                    foreach (XMPurchaseProductDetails info in purchaseProductDetails)
                    {
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td><input id=\"hiddProductId\" type=\"hidden\"  value ='" + info.ProductId + "'/><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.PlatformMerchantCode + "'  readonly=\"readonly\"/></td><td><input  id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" value='" + info.ProductName + "'   type=\"text\"/></td><td id=\"tdplatform\"><select  id=\"ddlPlatForm\" selectValue='" + info.PlatformTypeId + "'></select></td><td style=\"width:10%\"><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + info.Specifications + "' /></td><td style=\"width:5%\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductCount.ToString() + "' /></td><td style=\"width:3%\"><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\"  readonly=\"readonly\"   value='" + info.ProductUnit + "'/></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductPrice.ToString() + "' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductMoney.ToString() + "' /></td></tr>");
                    }
                }
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonContent"></param>
        public void BindGrid(string jsonContent)
        {
            decimal value = 0;
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>平台</th><th>尺寸规格</th><th>采购数量</th><th>单位</th><th>采购单价</th><th>采购金额</th><th>操作</th></tr>");
            if (jsonContent != "")
            {
                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(jsonContent);
                for (int i = 0; i < ja_goods.Count; i++)
                {
                    int productId = 0;
                    int productCount = 0;
                    string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                    var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                    if (product != null)
                    {
                        productId = product.Id;
                    }
                    string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                    string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                    bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                    if (t)
                    {
                        productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量
                    }
                    string unit = ja_goods[i]["txtUnit"].ToString().Replace('\"', ' ').Trim();      //单位
                    string productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim();      //采购单价
                    string productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim();      //采购单价
                    int platFormId = ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim() == "" ? 251 : int.Parse(ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim());      //平台

                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td><input id=\"hiddProductId\" type=\"hidden\"  value='" + productId + "'/><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCode + "' /></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" value='" + productName + "' type=\"text\" /></td><td id=\"tdplatform\"><select  id=\"ddlPlatForm\"  selectValue='" + platFormId + "'></select></td><td style=\"width:10%\"><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + specifications + "' /></td><td style=\"width:5%\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCount.ToString() + "' /></td><td style=\"width:3%\"><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\"  readonly=\"readonly\"   value='" + unit + "'/></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productPrice + "' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productMoney + "' /></td><td style=\"width:5%\"><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }

        private void loadBind(int type)
        {
            //绑定供应商列表
            if(type==0|| type==1)
            {
                var suppliers = base.XMSuppliersService.GetXMSuppliersList();
                if (suppliers != null && suppliers.Count > 0)
                {
                    ddlSuppliers.DataSource = suppliers;
                    ddlSuppliers.DataTextField = "SupplierName";
                    ddlSuppliers.DataValueField = "Id";
                    ddlSuppliers.DataBind();
                }
            }
            else
            {
                var suppliers = base.XMSuppliersService.GetXMSuppliersListDirect();
                if (suppliers != null && suppliers.Count > 0)
                {
                    ddlSuppliers.DataSource = suppliers;
                    ddlSuppliers.DataTextField = "SupplierName";
                    ddlSuppliers.DataValueField = "Id";
                    ddlSuppliers.DataBind();
                }
            }


            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(228, false);
            this.ddlPayType.DataSource = codeList;
            this.ddlPayType.DataTextField = "CodeName";
            this.ddlPayType.DataValueField = "CodeID";
            this.ddlPayType.DataBind();
        }

        /// <summary>
        /// 默认绑定供应商信息
        /// </summary>
        private void BindSupplierInfo()
        {
            string supplierId = ddlSuppliers.SelectedValue;
            if (!string.IsNullOrEmpty(supplierId))
            {
                var supplierInfo = base.XMSuppliersService.GetXMSuppliersById(int.Parse(supplierId));
                if (supplierInfo != null)
                {
                    txtContacter.Text = supplierInfo.Contacter;
                    txtTel.Text = supplierInfo.Tel;
                    txtFax.Text = supplierInfo.Fax;
                }
            }
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }
        /// <summary>
        /// 自动生成采购单号
        /// </summary>
        /// <returns></returns>
        private string AutoPurchaseNumber()
        {
            string purChaseCode = "";       //自动生成采购单号
            int number = 1;
            var pur = base.XMPurchaseService.GetXMPurchaseList();
            if (pur != null && pur.Count > 0)
            {
                number = pur[0].Id + 1;
            }
            purChaseCode = "PO" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return purChaseCode;
        }

        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^[0-9]*[1-9][0-9]*$");
            return reg1.IsMatch(str);
        }

        public bool IsFloat(string str)
        {
            //
            Regex reg1 = new Regex(@"^[+]?([0-9]*\.?[0-9]+|[0-9]+\.?[0-9]*)([eE][+-]?[0-9]+)?$");
            return reg1.IsMatch(str);
        }


        //保存功能(根据参数执行相关功能  true  更新业务员   false 不更新业务员)
        private void OperateSave(bool isUpdate)
        {
            decimal value = 0;
            if (this.type == 0)            //新增
            {
                string purChaseCode = "";
                bool isEmpty = false;      //判断厂家编码是否填写（厂家编码必填）
                bool isFalse = false;         //判断采购数量（数量不能为0）
                string hiddjsonContent = hdfJsonContent.Value;             //产品列表 json
                string ss = hiddAutoID.Value;
                bool isAuto = bool.Parse(hiddAutoID.Value);
                if (isAuto)              //只读  自动生成采购单号
                {
                    purChaseCode = AutoPurchaseNumber();
                }
                else
                {
                    purChaseCode = txtPurchaseNumber.Text.Trim();
                    if (string.IsNullOrEmpty(purChaseCode))
                    {
                        base.ShowMessage("采购单号必须填写！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                }
                var purchaseInfo = base.XMPurchaseService.GetXMPurchaseBypurChaseCode(purChaseCode);
                if (purchaseInfo != null && purchaseInfo.Count() > 0)
                {
                    base.ShowMessage("采购单号已存在 !");
                    BindGrid(hiddjsonContent);
                    return;
                }
                int supplierId = Convert.ToInt16(ddlSuppliers.SelectedValue);
                string contacter = txtContacter.Text.Trim();
                string tel = txtTel.Text.Trim();
                string fax = txtFax.Text.Trim();
                string BuyMember = txtBuyerName.Text.Trim();
                string Receiver = txtResiveName.Text.Trim();
                string ReceiverMobile = txtRecivesMobile.Text.Trim();
                string EmitFactory = txtSendFactory.Text.Trim();
                string SellerRemarks = TextBox1.Text.Trim();
                int BizUserId = HozestERPContext.Current.User.CustomerID;    //采购人
                DateTime PurchaseDate = txtPurchaseDate.Value == "" ? DateTime.Parse(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(txtPurchaseDate.Value);
                int status = 0;                   //采购单初始状态待入库
                decimal totalMoney = 0;        //采购单总价
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        if (productCode == "")           //厂家编码存在为空的
                        {
                            isEmpty = true;
                        }

                        string productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim();      //采购单价
                        string productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim();      //采购单价

                        bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                        if (!t || !IsFloat(productPrice) || !IsFloat(productMoney))
                        {
                            base.ShowMessage("输入格式不正确！");
                            BindGrid(hiddjsonContent);
                            return;
                        }
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量
                        if (productCount == 0)
                        {
                            isFalse = true;
                        }
                        totalMoney = totalMoney + decimal.Parse(productMoney);
                    }
                }
                if (isEmpty)
                {
                    base.ShowMessage("厂家编码不能为空！请输入厂家编码");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (isFalse)
                {
                    base.ShowMessage("商品采购数量不能为 0！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                int paymentType = int.Parse(ddlPayType.SelectedValue);
                DateTime deliveryDate = txtDeliveryDate.Value == "" ? DateTime.Parse(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(txtDeliveryDate.Value);
                string deliveryAddresss = txtDeliveryAddresss.Text.Trim();
                string note = txtNote.Text.Trim();

                XMPurchase purchase = new XMPurchase();
                purchase.PurchaseNumber = purChaseCode;
                purchase.SupplierId = supplierId;
                purchase.Contact = contacter;
                purchase.Tel = tel;
                purchase.Fax = fax;
                if (isUpdate)
                {
                    purchase.BizUserId = BizUserId;
                }
                purchase.PurchaseDate = PurchaseDate;
                purchase.BillStatus = status;
                purchase.ProductsMoney = totalMoney;
                purchase.PaymentType = paymentType;
                purchase.DealDate = deliveryDate;
                purchase.DealAddress = deliveryAddresss;
                purchase.InputUserId = HozestERPContext.Current.User.CustomerID;
                purchase.Date_Created = DateTime.Now;
                purchase.UpdateDate = DateTime.Now;
                purchase.UpdateID = HozestERPContext.Current.User.CustomerID;
                purchase.BillMemo = note;
                purchase.IsEnable = false;
                purchase.IsAudit = false;
                purchase.FinancialStatus = false;
                purchase.LogisticsFee = string.IsNullOrEmpty(txtLogisticsFee.Text.Trim()) ? 0 : decimal.Parse(txtLogisticsFee.Text.Trim());

                purchase.BuyMember = BuyMember;
                purchase.Receiver = Receiver;
                purchase.ReceiverMobile = ReceiverMobile;
                purchase.EmitFactory = EmitFactory;
                purchase.SellerRemarks = SellerRemarks;

                base.XMPurchaseService.InsertXMPurchase(purchase);
                int purchaseId = purchase.Id;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                        string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量
                        string unit = ja_goods[i]["txtUnit"].ToString().Replace('\"', ' ').Trim();      //单位
                        decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //采购单价
                        decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //采购单价

                        int platFormId = ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim() == "" ? 251 : int.Parse(ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim());      //平台
                        XMPurchaseProductDetails details = new XMPurchaseProductDetails();
                        details.PurchaseId = purchaseId;
                        var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                        if (product != null)
                        {
                            details.ProductId = product.Id;
                        }
                        details.PlatformTypeId = platFormId;
                        details.PlatformMerchantCode = productCode;
                        details.ProductCount = productCount;
                        details.ProductMoney = productMoney;
                        details.ProductPrice = productPrice;
                        details.CreateID = HozestERPContext.Current.User.CustomerID;
                        details.CreateDate = DateTime.Now;
                        details.UpdateDate = DateTime.Now;
                        details.UpdateID = HozestERPContext.Current.User.CustomerID;
                        details.IsEnable = false;
                        base.XMPurchaseProductDetailsService.InsertXMPurchaseProductDetails(details);
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(purchaseId);
            }
            else                       //编辑
            {
                bool isEmpty = false;      //判断厂家编码是否填写（厂家编码必填）
                bool isFalse = false;         //判断采购数量（数量不能为0）
                int id = this.scid;
                string BuyMember = txtBuyerName.Text.Trim();
                string Receiver = txtResiveName.Text.Trim();
                string ReceiverMobile = txtRecivesMobile.Text.Trim();
                string EmitFactory = txtSendFactory.Text.Trim();
                string SellerRemarks = TextBox1.Text.Trim();
                decimal totalMoney = 0;        //采购单总价
                string hiddjsonContent = hdfJsonContent.Value;             //产品列表 json
                var purchase = base.XMPurchaseService.GetXMPurchaseById(id);
                if (purchase != null)
                {
                    var purchaseDetails = base.XMPurchaseProductDetailsService.GetXMPurchaseProductDetailsByPurchaseID(purchase.Id);
                    purchase.SupplierId = Convert.ToInt16(ddlSuppliers.SelectedValue);
                    purchase.Contact = txtContacter.Text.Trim();
                    purchase.Tel = txtTel.Text.Trim();
                    purchase.Fax = txtFax.Text.Trim();
                    if (isUpdate)
                    {
                        purchase.BizUserId = HozestERPContext.Current.User.CustomerID;
                    }
                    purchase.PurchaseDate = txtPurchaseDate.Value == "" ? DateTime.Now : Convert.ToDateTime(txtPurchaseDate.Value);
                    purchase.BillStatus = 0;
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            if (productCode == "")           //厂家编码存在为空的
                            {
                                isEmpty = true;
                            }
                            bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                            string productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim();      //采购单价

                            string productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim();      //采购单价
                            if (!t || !IsFloat(productPrice) || !IsFloat(productMoney))
                            {
                                base.ShowMessage("输入格式不正确！");
                                BindGrid(hiddjsonContent);
                                return;
                            }
                            int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量
                            if (productCount == 0)
                            {
                                isFalse = true;
                            }
                            totalMoney = totalMoney + decimal.Parse(productMoney);
                        }
                    }
                    if (isEmpty)
                    {
                        base.ShowMessage("厂家编码不能为空！请输入厂家编码");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    if (isFalse)
                    {
                        base.ShowMessage("商品采购数量不能为 0  !");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    purchase.BuyMember = BuyMember;
                    purchase.Receiver = Receiver;
                    purchase.ReceiverMobile = ReceiverMobile;
                    purchase.EmitFactory = EmitFactory;
                    purchase.SellerRemarks = SellerRemarks;
                    purchase.LogisticsFee = string.IsNullOrEmpty(txtLogisticsFee.Text.Trim()) ? 0 : decimal.Parse(txtLogisticsFee.Text.Trim());

                    purchase.ProductsMoney = totalMoney; 
                    purchase.PaymentType = int.Parse(ddlPayType.SelectedValue);
                    purchase.DealDate = txtDeliveryDate.Value == "" ? DateTime.Now : Convert.ToDateTime(txtDeliveryDate.Value);
                    purchase.DealAddress = txtDeliveryAddresss.Text.Trim();
                    purchase.UpdateDate = DateTime.Now;
                    purchase.UpdateID = HozestERPContext.Current.User.CustomerID;
                    purchase.BillMemo = txtNote.Text.Trim();
                    base.XMPurchaseService.UpdateXMPurchase(purchase);
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            bool isExsit = false;                //判断厂家编码是否存在
                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                            string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                            int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量
                            string unit = ja_goods[i]["txtUnit"].ToString().Replace('\"', ' ').Trim();      //单位
                            decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //采购单价
                            decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //采购单价
                            int platFormId = ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim() == "" ? 251 : int.Parse(ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim());      //平台
                            foreach (XMPurchaseProductDetails info in purchaseDetails)
                            {
                                if (productCode == info.PlatformMerchantCode)
                                {
                                    isExsit = true;
                                    info.ProductCount = productCount;
                                    info.PlatformTypeId = platFormId;
                                    info.ProductMoney = productMoney;
                                    info.ProductPrice = productPrice;
                                    info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    info.UpdateDate = DateTime.Now;
                                    base.XMPurchaseProductDetailsService.UpdateXMPurchaseProductDetails(info);
                                }
                            }
                            if (ja_goods.Count > purchaseDetails.Count && isExsit == false)             //不存在新增
                            {
                                XMPurchaseProductDetails detail = new XMPurchaseProductDetails();
                                detail.PurchaseId = purchase.Id;
                                var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                                if (product != null)
                                {
                                    detail.ProductId = product.Id;
                                }
                                detail.PlatformTypeId = platFormId;
                                detail.PlatformMerchantCode = productCode;
                                detail.ProductCount = productCount;
                                detail.ProductMoney = productMoney;
                                detail.ProductPrice = productPrice;
                                detail.CreateDate = DateTime.Now;
                                detail.CreateID = HozestERPContext.Current.User.CustomerID;
                                detail.UpdateDate = DateTime.Now;
                                detail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                detail.IsEnable = false;
                                base.XMPurchaseProductDetailsService.InsertXMPurchaseProductDetails(detail);
                            }
                        }
                    }

                    if (purchaseDetails != null && purchaseDetails.Count > 0)
                    {
                        foreach (XMPurchaseProductDetails info in purchaseDetails)
                        {
                            bool isDelete = true;
                            if (hiddjsonContent != "")
                            {
                                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                                for (int i = 0; i < ja_goods.Count; i++)
                                {
                                    string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                                    if (productCode == info.PlatformMerchantCode)
                                    {
                                        isDelete = false;
                                        break;
                                    }
                                }
                            }
                            if (isDelete)
                            {
                                info.IsEnable = true;
                                info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                info.UpdateDate = DateTime.Now;
                                base.XMPurchaseProductDetailsService.UpdateXMPurchaseProductDetails(info);
                            }
                        }
                    }

                }
                base.ShowMessage("操作成功!");
                BindGrid(purchase.Id);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            OperateSave(true);             //保存页面数据及更新业务员
        }
        /// <summary>
        /// 部门审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPurchaseSingleIsAudit_Click(object sender, EventArgs e)
        {
            //保存数据
            OperateSave(false);                //保存页面数据  但不更新业务员
            if (this.scid == 0)
            {
                base.ShowMessage("数据不存在！");
            }
            else
            {
                var purchases = base.XMPurchaseService.GetXMPurchaseById(this.scid);
                if (purchases != null)
                {
                    purchases.IsAudit = true;
                    purchases.UpdateDate = DateTime.Now;
                    purchases.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMPurchaseService.UpdateXMPurchase(purchases);
                    //新增请款单数据
                    //var payment = base.XMPaymentApplyService.GetXMPaymentApplyByPurchaseID(purchases.Id);
                    //if (payment == null)
                    //{
                    //    InsertPaymentRequstData(purchases);
                    //}
                }
                BindGrid(purchases.Id);
                base.ShowMessage("操作成功！");
            }
        }
        /// <summary>
        /// 部门反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPurchaseSingleIsAuditFalse_Click(object sender, EventArgs e)
        {
            //保存数据
            OperateSave(false);                //保存页面数据  但不更新业务员
            if (this.scid == 0)
            {
                base.ShowMessage("数据不存在！");
            }
            else
            {
                var purchases = base.XMPurchaseService.GetXMPurchaseById(this.scid);
                if (purchases != null)
                {
                    var payments = base.XMPaymentApplyService.GetXMPaymentApplysByPurchaseID(purchases.Id);
                    if (payments.Count > 0)             //请款单存在
                    {
                        foreach (var elem in payments)
                        {
                            if (!elem.IsAudit.Value && !elem.FinancialStatus.Value)             //可以反审核 及删除请款单
                            {
                                //删除请款单数据
                                elem.IsEnable = true;
                                elem.UpdateDate = DateTime.Now;
                                elem.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMPaymentApplyService.UpdateXMPaymentApply(elem);
                            }
                            else
                            {
                                base.ShowMessage("财务审核或公司审核已通过，无法删除!");
                                return;
                            }
                        }
                        purchases.IsAudit = false;
                        purchases.UpdateDate = DateTime.Now;
                        purchases.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMPurchaseService.UpdateXMPurchase(purchases);
                    }
                    else//请款单为生成则直接改变申请单的状态即可
                    {
                        purchases.IsAudit = false;
                        purchases.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        purchases.UpdateDate = DateTime.Now;
                        base.XMPurchaseService.UpdateXMPurchase(purchases);
                    }
                }
                BindGrid(purchases.Id);
                base.ShowMessage("操作成功!");
            }
        }

        /// <summary>
        /// 新增请款单数据
        /// </summary>
        /// <param name="id"></param>
        private void InsertPaymentRequstData(XMPurchase purchases)
        {
            XMPaymentApply paymentApply = new XMPaymentApply();
            paymentApply.PurchaseID = purchases.Id;
            paymentApply.PayAmounts = purchases.ProductsMoney.Value;
            paymentApply.PayMode = purchases.PaymentType.Value;
            paymentApply.SupplierID = purchases.SupplierId;
            paymentApply.RequstDate = DateTime.Now;
            paymentApply.UserDate = purchases.PurchaseDate;
            paymentApply.ApplicantID = HozestERPContext.Current.User.CustomerID;
            paymentApply.UpdateDate = DateTime.Now;
            paymentApply.UpdateID = HozestERPContext.Current.User.CustomerID;
            paymentApply.IsAudit = false;
            paymentApply.FinancialStatus = false;
            paymentApply.FinancialConfirm = false;
            paymentApply.IsEnable = false;
            base.XMPaymentApplyService.InsertXMPaymentApply(paymentApply);
        }

        /// <summary>
        /// id
        /// </summary>
        public int scid
        {
            get
            {
                return CommonHelper.QueryStringInt("id");
            }
        }

        /// <summary>
        /// 判断是添加还是修改
        /// </summary>
        public int type
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }
    }
}