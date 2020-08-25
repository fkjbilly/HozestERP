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
    public partial class RejectedAdd : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBind();
                if (this.type == 0)    //新生成退库单
                {
                    lblRef.Visible = false;
                    BindGrid();
                }
                else if (this.type == 1)       //编辑退货单
                {
                    lblTitle.Text = "编辑未入库采购退货单";
                    lblMessage.Visible = false;
                    BindGrid(this.RejectedID);
                }
                else if (this.type == 2)        //查看
                {
                    lblTitle.Text = "查看未入库采购退货单";
                    lblMessage.Visible = false;
                    BindGrid(this.RejectedID);
                    btnSave.Visible = false;
                }
            }
        }

        /// <summary>
        /// 获取可入库数量
        /// </summary>
        /// <returns></returns>
        private int GetKStorageCount(int pruchaseID, string platformMerchantCode)
        {
            int storageCount = 0;     //剩余可入库数量(采购数量-入库数量-退货数量)
            int purchaseCount = 0;   //采购数量
            var purInfo = base.XMPurchaseProductDetailsService.GetXMPurchaseProductDetailsByPurchaseIDAndPlatformMerchantCode(pruchaseID, platformMerchantCode);
            if (purInfo != null && purInfo.Count > 0)
            {
                purchaseCount = purInfo[0].ProductCount;
            }
            int incount = GetStorageCount(pruchaseID, platformMerchantCode);               //入库数量
            int returnCount = GetReturnCount(pruchaseID, platformMerchantCode);       //退货数量
            storageCount = purchaseCount - incount - returnCount;
            return storageCount;
        }


        private void BindInfo(int purchaseId)
        {
            var purchases = base.XMPurchaseService.GetXMPurchaseById(purchaseId);
            if (purchases != null)
            {
                ddlSuppliers.SelectedValue = purchases.SupplierId.ToString();
            }
        }


        private void BindGrid()
        {
            BindInfo(this.PurchaseID);
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>可退货数量</th><th>退货数量</th><th>单位</th><th>退货单价</th><th>退货金额</th><th>退货状态</th><th>操作</th></tr>");
            var purchases = base.XMPurchaseService.GetXMPurchaseById(this.PurchaseID);
            if (purchases != null)
            {
                lblPurchaseCode.Text = purchases.PurchaseNumber;
            }
            //获取采购单产品明细
            var purProductDetails = base.XMPurchaseProductDetailsService.GetXMPurchaseProductDetailsByPurchaseID(this.PurchaseID);
            if (purProductDetails != null && purProductDetails.Count > 0)
            {
                foreach (XMPurchaseProductDetails info in purProductDetails)
                {
                    int RejectedCount = GetKStorageCount(this.PurchaseID, info.PlatformMerchantCode);     //剩余可退货数量(采购数量-入库数量-退货数量)
                    decimal rejectedMoney = RejectedCount * info.ProductPrice;
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td id=\"PlatformMerchantCode\">" + info.PlatformMerchantCode + "</td><td id=\"ProductName\">" + info.ProductName + "</td><td>" + info.Specifications + "</td> <td id=\"counts\"><input runat=\"server\" id=\"txtCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + RejectedCount.ToString() + "'   readonly=\"readonly\"/></td>    <td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + RejectedCount.ToString() + "' /></td><td>" + info.ProductUnit + "</td><td id=\"Price\">" + info.ProductPrice.ToString() + "</td><td id=\"ProductMoney\">" + rejectedMoney.ToString() + "</td><td><font color=\"#FF0000\">待退回</font></td><td ><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }

        /// <summary>
        /// 获采购退货数量
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <param name="platformMerchantCode"></param>
        /// <returns></returns>
        private int GetReturnCount(int purchaseId, string platformMerchantCode)
        {
            int returnCount = 0;
            var rejectedInfo = base.XMPurchaseRejectedService.GetXMPurchaseRejectedListByPurchaseID(purchaseId);
            if (rejectedInfo != null && rejectedInfo.Count > 0)
            {
                foreach (XMPurchaseRejected rejected in rejectedInfo)
                {
                    var rejectedDetail = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(rejected.Id);
                    if (rejectedDetail != null && rejectedDetail.Count > 0)
                    {
                        foreach (XMPurchaseRejectedProductDetails details in rejectedDetail)
                        {
                            if (details.PlatformMerchantCode == platformMerchantCode)
                            {
                                returnCount = returnCount + details.RejectionCount;
                            }
                        }
                    }
                }
            }
            return returnCount;
        }

        /// <summary>
        /// 获取产品已入库数量
        /// </summary>
        /// <returns></returns>
        private int GetStorageCount(int purchaseId, string platformMerchantCode)
        {
            int storageCount = 0;
            //根据采购单查询所有的入库单
            var storageInfo = base.XMStorageService.GetXMStorageListByPurcahaseID(purchaseId);
            if (storageInfo != null && storageInfo.Count > 0)
            {
                foreach (XMStorage storages in storageInfo)
                {
                    var storageProductDetail = base.XMStorageProductDetailsService.GetXMStorageProductDetailsByStorageID(storages.Id);
                    if (storageProductDetail != null && storageProductDetail.Count > 0)
                    {
                        foreach (XMStorageProductDetails detail in storageProductDetail)
                        {
                            if (detail.PlatformMerchantCode == platformMerchantCode)
                            {
                                storageCount = storageCount + detail.ProductsCount;
                            }
                        }
                    }
                }
            }
            return storageCount;
        }

        private void BindGrid(int RejectedID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>可退货数量</th><th>退货数量</th><th>单位</th><th>退货单价</th><th>退货金额</th><th>退回状态</th><th>退回操作</th></tr>");
            //绑定退货单单主表和明细表
            var rejectedInfo = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(RejectedID);
            if (rejectedInfo != null)
            {
                var purchaseInfo = base.XMPurchaseService.GetXMPurchaseById(rejectedInfo.MId);
                if (purchaseInfo != null)
                {
                    lblPurchaseCode.Text = purchaseInfo.PurchaseNumber;
                }
                var rejectedDetails = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(RejectedID);
                lblRef.Text = rejectedInfo.Ref;
                ddlSuppliers.SelectedValue = rejectedInfo.SupplierId.ToString();
                txtStorageDate.Value = rejectedInfo.BizDt.ToString() == "" ? DateTime.Now.ToShortDateString() : rejectedInfo.BizDt.ToString();
                txtNote.Text = rejectedInfo.BillMemo;
                if (rejectedDetails != null && rejectedDetails.Count > 0)
                {
                    foreach (XMPurchaseRejectedProductDetails info in rejectedDetails)
                    {
                        int rejectedCount = GetKStorageCount(this.PurchaseID, info.PlatformMerchantCode);     //剩余可退货数量(采购数量-入库数量-退货数量)
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td id=\"PlatformMerchantCode\">" + info.PlatformMerchantCode + "</td><td id=\"ProductName\">" + info.ProductName + "</td><td>" + info.Specifications + "</td><td id=\"counts\"><input runat=\"server\" id=\"txtCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + rejectedCount.ToString() + "' /></td> <td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.RejectionCount.ToString() + "' /></td><td>" + info.ProductUnit + "</td><td id=\"Price\">" + info.RejectionProductPrice.ToString() + "</td><td id=\"ProductMoney\">" + info.RejectionMoney.ToString() + "</td><td  id=\"BillStatus\">" + (info.BillStatus == null || info.BillStatus == 0 ? "<font color=\"#FF0000\">待退回</font>" : "已退回") + "</td><td ><input id=\"hiddPRId\" type=\"hidden\"  value='" + info.Id + "'/><img src=\"../images/icons/entrusted.gif\" title=\"退回操作\" id=\"imgReturn\" alt=\"退回操作\"  /></td></tr>");

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
        private void BindGrid(string jsonContent)
        {
            decimal value = 0;
            StringBuilder str = new StringBuilder();
            string productName = "";
            string specifications = "";
            string unit = "";
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>可退货数量</th><th>退货数量</th><th>单位</th><th>退货单价</th><th>退货金额</th><th>退回状态</th><th>操作</th></tr>");
            if (jsonContent != "")
            {
                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(jsonContent);
                for (int i = 0; i < ja_goods.Count; i++)
                {
                    int rejectefCount = 0;
                    string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                    bool t = IsNumeric(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());
                    if (t)
                    {
                        rejectefCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                    }
                    int count = ja_goods[i]["Count"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["Count"].ToString().Replace('\"', ' ').Trim());      //可退货数量
                    decimal productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim());      //采购单价
                    decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //采购单价
                    if (productCode != "")
                    {
                        var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                        if (product != null)
                        {
                            productName = product.ProductName;
                            specifications = product.Specifications;
                            unit = product.ProductUnit;
                        }
                    }
                    int rejectedCount = GetKStorageCount(this.PurchaseID, productCode);     //剩余可退货数量(采购数量-入库数量-退货数量)
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td id=\"PlatformMerchantCode\">" + productCode + "</td><td id=\"ProductName\">" + productName + "</td><td>" + specifications + "</td><td id=\"counts\"><input runat=\"server\" id=\"txtCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + count.ToString() + "' /></td> <td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + rejectefCount + "' /></td><td>" + unit + "</td><td id=\"Price\">" + productPrice.ToString() + "</td><td id=\"ProductMoney\">" + productMoney + "</td><td><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");

                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }

        private void loadBind()
        {
            //绑定供应商列表
            var suppliers = base.XMSuppliersService.GetXMSuppliersList();
            if (suppliers != null && suppliers.Count > 0)
            {
                ddlSuppliers.DataSource = suppliers;
                ddlSuppliers.DataTextField = "SupplierName";
                ddlSuppliers.DataValueField = "Id";
                ddlSuppliers.DataBind();
            }

            //绑定收款方式
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(228, false);
            this.ddlPayment.DataSource = codeList;
            this.ddlPayment.DataTextField = "CodeName";
            this.ddlPayment.DataValueField = "CodeID";
            this.ddlPayment.DataBind();
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        private string AutoRejectedNumber()
        {
            string rejectedCode = "";       //自动生成退货单号
            int number = 1;
            var rejected = base.XMPurchaseRejectedService.GetXMPurchaseRejectedList();
            if (rejected != null && rejected.Count > 0)
            {
                number = rejected[0].Id + 1;
            }
            rejectedCode = "PW" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return rejectedCode;
        }

        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^[0-9]*[1-9][0-9]*$");
            return reg1.IsMatch(str);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal value = 0;
            if (this.type == 0)            //新增
            {
                bool isEmpty = false;      //判断厂家编码是否填写（厂家编码必填）
                bool isFlase = false;        //判断入库数量值是否正确
                string rf = AutoRejectedNumber();      //自动生成退货单号
                int purchaseId = this.PurchaseID;
                int supplierId = ddlSuppliers.SelectedValue == "" ? -1 : int.Parse(ddlSuppliers.SelectedValue);
                int BizUserId = HozestERPContext.Current.User.CustomerID;    // 退货人
                DateTime BizDt = txtStorageDate.Value == "" ? DateTime.Parse(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(txtStorageDate.Value);   //退货时间
                int paymentType = int.Parse(ddlPayment.SelectedValue);
                string note = txtNote.Text.Trim();
                decimal totalRejectedMoney = 0;
                string hiddjsonContent = hdfJsonContent.Value;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    if (ja_goods.Count == 0)
                    {
                        isEmpty = true;
                    }
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        int rejecedCount = ja_goods[i]["Count"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["Count"].ToString().Replace('\"', ' ').Trim());      //可退货数量
                        bool t = IsNumeric(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());
                        if (!t)
                        {
                            base.ShowMessage("商品退货数量格式不正确！");
                            BindGrid(hiddjsonContent);
                            return;
                        }
                        int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                        if (productCount == 0 || productCount > rejecedCount)
                        {
                            isFlase = true;
                        }
                        decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ') == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //采购总价
                        totalRejectedMoney += productMoney;
                    }
                }
                if (isEmpty)
                {
                    base.ShowMessage("厂家编码不能为空，请输入厂家编码或 商品信息不存在");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (isFlase)
                {
                    base.ShowMessage("商品退货数量不能为0 或 大于可退货数量！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                XMPurchaseRejected rejected = new XMPurchaseRejected();
                rejected.Ref = rf;
                rejected.MId = this.PurchaseID;
                rejected.SupplierId = supplierId;
                rejected.BizUserId = BizUserId;
                rejected.BizDt = BizDt;
                rejected.BillStatus = 0;    //待退货
                rejected.RejectionMoney = totalRejectedMoney;
                rejected.ReceivingType = paymentType;
                rejected.BillMemo = note;
                rejected.CreateID = HozestERPContext.Current.User.CustomerID;
                rejected.CreateDate = DateTime.Now;
                rejected.UpdateID = HozestERPContext.Current.User.CustomerID;
                rejected.UpdateDate = DateTime.Now;
                rejected.IsEnable = false;
                rejected.IsAudit = false;
                rejected.IsStoraged = false;     //未入库
                base.XMPurchaseRejectedService.InsertXMPurchaseRejected(rejected);
                int rejectedID = rejected.Id;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                        decimal productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim());      //采购单价
                        decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //采购单价
                        XMPurchaseRejectedProductDetails details = new XMPurchaseRejectedProductDetails();
                        details.PrId = rejectedID;
                        var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                        if (product != null)
                        {
                            details.ProductId = product.Id;
                        }
                        details.PlatformMerchantCode = productCode;
                        details.RejectionCount = productCount;             // 退货数量
                        details.RejectionProductPrice = productPrice;     //退货单价
                        details.RejectionMoney = productMoney;          //退货金额
                        details.CreateDate = DateTime.Now;
                        details.CreateID = HozestERPContext.Current.User.CustomerID;
                        details.UpdateDate = DateTime.Now;
                        details.UpdateID = HozestERPContext.Current.User.CustomerID;
                        details.IsEnable = false;
                        base.XMPurchaseRejectedProductDetailsService.InsertXMPurchaseRejectedProductDetails(details);
                    }
                }

                XMPaymentApply xmPaymentApply = new XMPaymentApply();
                xmPaymentApply.PurchaseID = this.PurchaseID;
                xmPaymentApply.PayAmounts = 0 - totalRejectedMoney;
                xmPaymentApply.PayMode = paymentType;
                xmPaymentApply.SupplierID = supplierId;
                xmPaymentApply.RequstDate= DateTime.Now;
                xmPaymentApply.UserDate= DateTime.Now;
                xmPaymentApply.IsAudit = false;
                xmPaymentApply.FinancialStatus = false;
                xmPaymentApply.ApplicantID= HozestERPContext.Current.User.CustomerID;
                xmPaymentApply.UpdateDate= DateTime.Now;
                xmPaymentApply.UpdateID= HozestERPContext.Current.User.CustomerID;
                xmPaymentApply.IsEnable = false;
                xmPaymentApply.FinancialConfirm = false;
                XMPaymentApplyService.InsertXMPaymentApply(xmPaymentApply);

                base.ShowMessage("操作成功!");
                BindGrid(rejected.Id);
            }
            else                  //编辑
            {
                bool isEmpty = false;      //判断厂家编码是否填写（厂家编码必填）
                bool isFlase = false;        //判断入库数量值是否正确
                int id = this.RejectedID;
                decimal totalMoney = 0;        //总价
                var rejected = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(id);
                if (rejected != null)
                {
                    var rejectedDetails = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(rejected.Id);
                    rejected.SupplierId = ddlSuppliers.SelectedValue == "" ? -1 : int.Parse(ddlSuppliers.SelectedValue);
                    rejected.BizUserId = HozestERPContext.Current.User.CustomerID;
                    rejected.BizDt = txtStorageDate.Value == "" ? DateTime.Parse(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(txtStorageDate.Value);   //业务时间
                    string hiddjsonContent = hdfJsonContent.Value;
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        if (ja_goods.Count == 0)
                        {
                            isEmpty = true;
                        }
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            int rejecedCount = ja_goods[i]["Count"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["Count"].ToString().Replace('\"', ' ').Trim());      //可退货数量
                            bool t = IsNumeric(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());
                            if (!t)
                            {
                                base.ShowMessage("商品采购数量数量格式不正确！");
                                BindGrid(hiddjsonContent);
                                return;
                            }
                            int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                            if (productCount == 0 || productCount > rejecedCount)
                            {
                                isFlase = true;
                            }
                            decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ') == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //采购总价
                            totalMoney += productMoney;
                        }
                    }
                    if (isEmpty)
                    {
                        base.ShowMessage("厂家编码不能为空，请输入厂家编码或 商品信息不存在");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    if (isFlase)
                    {
                        base.ShowMessage("商品退货数量不能为0 或 大于可退货数量！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    rejected.RejectionMoney = totalMoney;
                    rejected.ReceivingType = int.Parse(ddlPayment.SelectedValue);
                    rejected.BillMemo = txtNote.Text.Trim();
                    rejected.UpdateDate = DateTime.Now;
                    rejected.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMPurchaseRejectedService.UpdateXMPurchaseRejected(rejected);
                    if (rejectedDetails != null && rejectedDetails.Count() > 0)
                    {
                        if (hiddjsonContent != "")
                        {
                            JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                            for (int i = 0; i < ja_goods.Count; i++)
                            {
                                string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                                int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                                decimal productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim());      //退货单价
                                decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //退货金额
                                foreach (XMPurchaseRejectedProductDetails info in rejectedDetails)
                                {
                                    if (productCode == info.PlatformMerchantCode)
                                    {
                                        info.RejectionCount = productCount;
                                        info.RejectionProductPrice = productPrice;
                                        info.RejectionMoney = productMoney;
                                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        info.UpdateDate = DateTime.Now;
                                        base.XMPurchaseRejectedProductDetailsService.UpdateXMPurchaseRejectedProductDetails(info);
                                    }
                                }
                            }
                        }
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(rejected.Id);
            }
        }
        /// <summary>
        /// 采购单ID
        /// </summary>
        public int PurchaseID
        {
            get
            {
                return CommonHelper.QueryStringInt("PurchaseID");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RejectedID
        {
            get
            {
                return CommonHelper.QueryStringInt("RejectedID");
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