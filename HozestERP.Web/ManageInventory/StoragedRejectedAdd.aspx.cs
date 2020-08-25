using System;
using System.Linq;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Transactions;
using HozestERP.BusinessLogic.ManageFinance;

namespace HozestERP.Web.ManageInventory
{
    public partial class StoragedRejectedAdd : BaseAdministrationPage, IEditPage
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
                    btnSingleRejectedDelivery.Visible = false;
                    BindGrid();
                }
                else if (this.type == 1)       //编辑退货单
                {
                    lblTitle.Text = "编辑已入库采购退货单";
                    lblMessage.Visible = false;
                    BindGrid(this.RejectedID);
                }
                else if (this.type == 2)        //查看
                {
                    lblTitle.Text = "查看已入库采购退货单";
                    lblMessage.Visible = false;
                    BindGrid(this.RejectedID);
                    btnSave.Visible = false;
                    btnSingleRejectedDelivery.Visible = false;
                }
            }
        }

        private void BindGrid()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>ID</th><th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>可退货数量</th><th>退货数量</th><th>操作</th></tr>");
            var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(this.ID);
            if (InventoryInfo != null)
            {
                //lblStorageCode.Text = storages.Ref;
                lblRejectedWareHoueses.Text = InventoryInfo.WfName;

                int RejectedCount = int.Parse(InventoryInfo.StockNumber.ToString());                 //可退货数量 = 入库数量- 已经退货数量
                str.Append("<tr  id=\"mytr\">");
                str.Append("<td id=\"ID\">" + this.ID + "</td><td id=\"PlatformMerchantCode\">" + InventoryInfo.PlatformMerchantCode + "</td><td id=\"ProductName\">" + InventoryInfo.ProductName + "</td><td>" + InventoryInfo.Specifications + "</td> <td id=\"counts\"><input runat=\"server\" id=\"txtCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + RejectedCount.ToString() + "'   readonly=\"readonly\"/></td>    <td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + RejectedCount.ToString() + "' /></td><td ><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");

            }
            str.Append("</table>");
            TableStr = str.ToString();
        }


        private int getRejectedCount(int storageID, string PlatformMerchantCode)
        {
            int KRejectedCount = 0;
            var storageRejected = base.XMPurchaseRejectedService.GetXMPurchaseRejectedListByStorageID(storageID);
            if (storageRejected != null && storageRejected.Count > 0)
            {
                foreach (XMPurchaseRejected parm in storageRejected)
                {
                    var storageRejectProductDetails = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(parm.Id);
                    if (storageRejectProductDetails != null && storageRejectProductDetails.Count > 0)
                    {
                        foreach (XMPurchaseRejectedProductDetails info in storageRejectProductDetails)
                        {
                            if (info.PlatformMerchantCode == PlatformMerchantCode)
                            {
                                KRejectedCount += info.RejectionCount;
                            }
                        }
                    }
                }
            }
            return KRejectedCount;
        }


        private void BindGrid(int RejectedID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>ID</th><th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>可退货数量</th><th>退货数量</th></tr>");
            //绑定退货单单主表和明细表
            var rejectedInfo = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(RejectedID);
            if (rejectedInfo != null)
            {
                var PurchaseRejectedProductDetails = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(rejectedInfo.Id);
                foreach (XMPurchaseRejectedProductDetails PurchaseRejectedProductDetailsinfo in PurchaseRejectedProductDetails) 
                {
                    if (PurchaseRejectedProductDetailsinfo.InventoryInfoID != null)
                    {
                        var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(int.Parse(PurchaseRejectedProductDetailsinfo.InventoryInfoID.ToString()));
                        if (InventoryInfo != null)
                        {
                            lblRejectedWareHoueses.Text += InventoryInfo.WfName + " ";
                        }
                    }
                    else
                    {
                        var storageInfo = base.XMStorageService.GetXMStorageById(rejectedInfo.MId);
                        if (storageInfo != null)
                        {
                            lblStorageCode.Text = storageInfo.Ref;
                            lblRejectedWareHoueses.Text = storageInfo.WareHouseName;
                        }
                    }
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
                        int rejectedCount = 0;
                        if (info.InventoryInfoID != null)//新代码使用库存管理的ID查询
                        {
                            var xmInventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(int.Parse(info.InventoryInfoID.ToString()));
                             rejectedCount = int.Parse(xmInventoryInfo.StockNumber.ToString()) - info.RejectionCount;     //剩余可退货数量(入库数量-退货数量)
                            }
                        else 
                        {
                            //老的查询方式根据入库单和商品编码查询
                             rejectedCount = GetKStorageCount(rejectedInfo.MId, info.PlatformMerchantCode) - info.RejectionCount;     //剩余可退货数量(入库数量-退货数量)
                        }
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td id=\"ID\">" + info.InventoryInfoID + "</td><td id=\"PlatformMerchantCode\">" + info.PlatformMerchantCode + "</td><td id=\"ProductName\">" + info.ProductName + "</td><td>" + info.Specifications + "</td><td id=\"counts\"><input runat=\"server\" id=\"txtCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + rejectedCount.ToString() + "' /></td> <td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.RejectionCount.ToString() + "' /></td></tr>");
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
            str.Append("<th>ID</th><th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>可退货数量</th><th>退货数量</th><th>操作</th></tr>");
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
                    int InventoryInfoID = ja_goods[i]["InventoryInfoID"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["InventoryInfoID"].ToString().Replace('\"', ' ').Trim()); 
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
                    var xmInventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(InventoryInfoID);
                    int rejectedCount = int.Parse(xmInventoryInfo.StockNumber.ToString()) - rejectefCount;     //剩余可退货数量(入库数量-退货数量)
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td id=\"ID\">" + InventoryInfoID + "</td><td id=\"PlatformMerchantCode\">" + productCode + "</td><td id=\"ProductName\">" + productName + "</td><td>" + specifications + "</td><td id=\"counts\"><input runat=\"server\" id=\"txtCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + count.ToString() + "' /></td> <td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + rejectefCount + "' /></td><td><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");

                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }

        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^[0-9]*[1-9][0-9]*$");
            return reg1.IsMatch(str);
        }



        /// <summary>
        /// 入库数量
        /// </summary>
        /// <returns></returns>
        private int GetKStorageCount(int storageID, string platformMerchantCode)
        {
            int storageCount = 0;
            var storageProductDetails = base.XMStorageProductDetailsService.GetXMStorageProductDetailsByStorageID(storageID);
            if (storageProductDetails != null && storageProductDetails.Count > 0)
            {
                foreach (XMStorageProductDetails parm in storageProductDetails)
                {
                    if (platformMerchantCode == parm.PlatformMerchantCode)
                    {
                        storageCount += parm.ProductsCount;
                    }
                }
            }
            return storageCount;
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal value = 0;
            if (this.type == 0)            //新增
            {
                bool isEmpty = false;      //判断厂家编码是否填写（厂家编码必填）
                bool isFlase = false;        //判断入库数量值是否正确
                string rf = AutoRejectedNumber();      //自动生成退货单号
 
                var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(this.ID);
                int storageID = -1;
                if(InventoryInfo != null)
                {
                    storageID= InventoryInfo.WfId;
                }
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
                    }
                }
                if (isFlase)
                {
                    base.ShowMessage("商品退货数量不能为0 或 大于可退货数量！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (isEmpty)
                {
                    base.ShowMessage("厂家编码不能为空，请输入厂家编码 或商品信息不存在！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                XMPurchaseRejected rejected = new XMPurchaseRejected();
                rejected.Ref = rf;
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
                rejected.IsStoraged = true;     //已经入库
                base.XMPurchaseRejectedService.InsertXMPurchaseRejected(rejected);
                int rejectedID = rejected.Id;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                        XMPurchaseRejectedProductDetails details = new XMPurchaseRejectedProductDetails();
                        details.PrId = rejectedID;
                        var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                        if (product != null)
                        {
                            details.ProductId = product.Id;
                        }
                        details.InventoryInfoID = this.ID;//库存ID
                        details.PlatformMerchantCode = productCode;
                        details.RejectionCount = productCount;             // 退货数量
                        details.CreateDate = DateTime.Now;
                        details.CreateID = HozestERPContext.Current.User.CustomerID;
                        details.UpdateDate = DateTime.Now;
                        details.UpdateID = HozestERPContext.Current.User.CustomerID;
                        details.IsEnable = false;
                        base.XMPurchaseRejectedProductDetailsService.InsertXMPurchaseRejectedProductDetails(details);
                    }
                }

                XMPaymentApply xmPaymentApply = new XMPaymentApply();
                //xmPaymentApply.PurchaseID = this.PurchaseID;
                xmPaymentApply.PayAmounts = 0 - totalRejectedMoney;
                xmPaymentApply.PayMode = paymentType;
                xmPaymentApply.SupplierID = supplierId;
                xmPaymentApply.RequstDate = DateTime.Now;
                xmPaymentApply.UserDate = DateTime.Now;
                xmPaymentApply.IsAudit = false;
                xmPaymentApply.FinancialStatus = false;
                xmPaymentApply.ApplicantID = HozestERPContext.Current.User.CustomerID;
                xmPaymentApply.UpdateDate = DateTime.Now;
                xmPaymentApply.UpdateID = HozestERPContext.Current.User.CustomerID;
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
                        }
                    }
                    if (isFlase)
                    {
                        base.ShowMessage("商品退货数量不能为0 或 大于可退货数量！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    if (isEmpty)
                    {
                        base.ShowMessage("厂家编码不能为空，请输入厂家编码或 商品信息不存在");
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
                                foreach (XMPurchaseRejectedProductDetails info in rejectedDetails)
                                {
                                    if (productCode == info.PlatformMerchantCode)
                                    {
                                        info.InventoryInfoID = this.ID;//库存ID
                                        info.RejectionCount = productCount;
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
        /// 提交出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSingleRejectedDelivery_Click(object sender, EventArgs e)
        {
            //提交出库
            using (TransactionScope scope = new TransactionScope())
            {
                var storageRejected = base.XMPurchaseRejectedService.GetXMPurchaseRejectedById(this.RejectedID);
                if (storageRejected != null)
                {
                    bool isInventLess = GetInventory(this.RejectedID);
                    if (isInventLess)
                    {
                        base.ShowMessage("已入库退货单库存不足，无法提交出库！");
                        BindGrid(storageRejected.Id);
                        return;
                    }

                    bool storageRejectedIsAudit = storageRejected.IsAudit == null ? false : storageRejected.IsAudit.Value;
                    if (!storageRejectedIsAudit)
                    {
                        base.ShowMessage("已入库退货单未审核通过，无法提交出库！");
                        BindGrid(storageRejected.Id);
                        return;
                    }
                }

                if (storageRejected != null && storageRejected.BillStatus == 0)                 //更新状态   更新库存数量
                {
                    storageRejected.BillStatus = 1000;   //状态更新为已出库
                    storageRejected.UpdateDate = DateTime.Now;
                    storageRejected.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMPurchaseRejectedService.UpdateXMPurchaseRejected(storageRejected);
                    //更新产品库存表（减掉已入库退货数量）
                    var storageRejectedProductDetails = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(storageRejected.Id);
                    if (storageRejectedProductDetails != null && storageRejectedProductDetails.Count > 0)
                    {
                        foreach (XMPurchaseRejectedProductDetails parm in storageRejectedProductDetails)
                        {
                            string code = parm.PlatformMerchantCode;              //厂家编码
                            var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(int.Parse(parm.InventoryInfoID.ToString()));
                            if (InventoryInfo != null)                             //厂家编码为code的产品在库存表中已经存在 更新库存数量
                            {
                                InventoryInfo.StockNumber = InventoryInfo.StockNumber - parm.RejectionCount;             //库存减掉退货数量
                                InventoryInfo.CanOrderCount = InventoryInfo.StockNumber;
                                InventoryInfo.UpdateDate = DateTime.Now;
                                InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
                            }
                        }
                    }
                    scope.Complete();
                }
            }
            BindGrid(this.RejectedID);
            base.ShowMessage("提交出库成功！");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleDeliveryID"></param>
        private bool GetInventory(int PRID)
        {
            bool isInventLess = false;
            var rejectedProductDetails = base.XMPurchaseRejectedProductDetailsService.GetXMPurchaseRejectedProductDetailsByRejectedID(PRID);
                if (rejectedProductDetails != null && rejectedProductDetails.Count > 0)
                {
                    foreach (XMPurchaseRejectedProductDetails Info in rejectedProductDetails)
                    {
                        var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(int.Parse(Info.InventoryInfoID.ToString()));
                        if (inventInfo == null)
                        {
                            isInventLess = true;      //库存不足
                        }
                        else if (inventInfo.StockNumber == 0)        //库存为0
                        {
                            isInventLess = true;      //库存不足
                        }
                        else if (inventInfo.StockNumber > 0 && inventInfo.StockNumber < Info.RejectionCount)
                        {
                            isInventLess = true;      //库存不足
                        }
                    }
                }
            return isInventLess;
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        /// <summary>
        /// 库存ID
        /// </summary>
        public int ID
        {
            get { return CommonHelper.QueryStringInt("ID"); }
        }

        /// <summary>
        /// 退货单ID
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