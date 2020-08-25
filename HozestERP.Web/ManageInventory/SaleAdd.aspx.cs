using System;
using System.Linq;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using HozestERP.BusinessLogic.ManageProject;
using System.Web.UI.WebControls;
using System.Transactions;

namespace HozestERP.Web.ManageInventory
{
    public partial class SaleAdd : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBind();
                if (this.type == 0)           //新增
                {
                    lblTitle.Text = "新建销售订单";
                    lblRef.Visible = false;
                    GetSaleList();
                }
                else if (this.type == 1)   //修改
                {
                    lblTitle.Text = "编辑销售订单";
                    lblMessage.Visible = false;
                    BindGrid(this.scid);
                }
                else if (this.type == 2)   //查看
                {
                    lblTitle.Text = "查看销售订单";
                    lblMessage.Visible = false;
                    BindGrid(this.scid);
                    btnSave.Visible = false;
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            hiddType.Value = this.type.ToString();
        }

        private void GetSaleList()
        {
            //新增
            if (this.type == 0)
            {
                StringBuilder str = new StringBuilder();
                str.Append("<table class='table' id='MyPurchaseProductList' >");
                str.Append("<tr >");
                str.Append("<th>厂家编码</th><th>商品名称</th><th>平台</th><th>尺寸规格</th><th>销售数量</th><th>单位</th><th>销售单价</th><th>销售金额</th><th>操作</th></tr>");
                str.Append("<tr  id=\"mytr\">");
                str.Append("<td><input id=\"hiddProductId\" type=\"hidden\" /><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value=''  readonly=\"readonly\"/></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\"  type=\"text\" style=\"text-align: left;width: 90%\" value='' /></td><td id=\"tdplatform\"><select  id=\"ddlPlatForm\"></select></td><td><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='' readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }

        public void BindGrid(int saleID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>平台</th><th>尺寸规格</th><th>销售数量</th><th>单位</th><th>销售单价</th><th>销售金额</th><th>操作</th></tr>");
            var sale = base.XMSaleInfoService.GetXMSaleInfoById(saleID);
            if (sale != null)
            {
                lblRef.Text = sale.Ref;
                var saleProductDetails = base.XMSaleInfoProductDetailsService.GetSaleInfoProductDetailsBySaleId(sale.Id);
                txtDeliveryDate.Value = sale.BizDt.ToString() == "" ? DateTime.Now.ToShortDateString() : sale.BizDt.ToString();
                ddlPayment.SelectedValue = sale.ReceivingType.ToString();
                ddXMProject.SelectedValue = sale.ProjectId.ToString();
                txtCustomerName.Text = sale.CustomerName;
                txtTel.Text = sale.Tel;
                txtAddress.Text = sale.SaleAddress;
                txtExpressFee.Text = sale.ExpressFee == null ? "0" : sale.ExpressFee.ToString();
                txtPartsFee.Text = sale.PartsFee == null ? "0" : sale.PartsFee.ToString();
                txtInstallFee.Text = sale.InstallFee == null ? "0" : sale.InstallFee.ToString();
                txtNote.Text = sale.Remarks;
                if (saleProductDetails != null && saleProductDetails.Count > 0)
                {
                    foreach (XMSaleInfoProductDetails info in saleProductDetails)
                    {
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td><input id=\"hiddProductId\" type=\"hidden\" value='" + info.ProductId + "' /><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.PlatformMerchantCode + "'  readonly=\"readonly\"/></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\"  type=\"text\" style=\"text-align: left;width: 90%\" value='" + info.ProductName + "' /></td><td id=\"tdplatform\"><select  id=\"ddlPlatForm\" selectValue='" + info.PlatformTypeId + "'></select></td><td><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + info.Specifications + "' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.SaleCount.ToString() + "' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='" + info.ProductUnit + "' readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductPrice.ToString() + "' /></td><td><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductMoney.ToString() + "' /></td><td><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                    }
                }
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }
        /// <summary>
        /// 通过json数据绑定产品列表
        /// </summary>
        private void BindGrid(string jsonContent)
        {
            decimal value = 0;
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>平台</th><th>尺寸规格</th><th>销售数量</th><th>单位</th><th>销售单价</th><th>销售金额</th><th>操作</th></tr>");
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
                    string unit = ja_goods[i]["txtUnit"].ToString().Replace('\"', ' ').Trim();      //单位
                    bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                    if (t)
                    {
                        productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //销售数量
                    }
                    decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //销售单价
                    decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //销售金额
                    int platFormId = ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim() == "" ? 251 : int.Parse(ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim());      //平台
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td><input id=\"hiddProductId\" type=\"hidden\"  value='" + productId + "'/><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCode + "'  readonly=\"readonly\"/></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productName + "' /></td><td id=\"tdplatform\"><select  id=\"ddlPlatForm\"  selectValue='" + platFormId + "'></select></td><td><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + specifications + "' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCount.ToString() + "' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='" + unit + "' readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productPrice.ToString() + "' /></td><td><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productMoney.ToString() + "' /></td><td><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }

        /// <summary>
        /// 自动生成销售单号
        /// </summary>
        /// <returns></returns>
        private string AutoSaleNumber()
        {
            string saleCode = "";       //自动生成销售单号
            int number = 1;
            var sale = base.XMSaleInfoService.GetXMSaleInfoList();
            if (sale != null && sale.Count > 0)
            {
                number = sale[0].Id + 1;
            }
            saleCode = "SO" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return saleCode;
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
                decimal Todecimal = 0;
                decimal fee = 0;
                bool isSame = false;     //判断厂家编码相同 价格是否相同 
                bool isFalse = false;
                bool isEmpty = false;     //判断厂家编码是否为空 （厂家编码必填*）
                string rf = AutoSaleNumber();        //自动生成退货单号
                int orderInfoId = 0;                              //导入订单时使用给OrderInfoID 赋值
                string customerName = txtCustomerName.Text.Trim();      //客户名
                string cusAddress = txtAddress.Text.Trim();                        //客户地址
                string tel = txtTel.Text.Trim();                                              //客户电话
                int paymentType = int.Parse(ddlPayment.SelectedValue);
                string note = txtNote.Text.Trim();
                decimal totalSaleMoney = 0;
                string expressFee = txtExpressFee.Text.Trim();
                string partsFee = txtPartsFee.Text.Trim();
                string InstallFee = txtInstallFee.Text.Trim();
                if (expressFee != "" && decimal.TryParse(expressFee, out Todecimal) == false)
                {
                    ShowMessage("快递费必须为数字！");
                    return;
                }
                if (partsFee != "" && decimal.TryParse(partsFee, out Todecimal) == false)
                {
                    ShowMessage("配件费必须为数字！");
                    return;
                }
                if (InstallFee != "" && decimal.TryParse(InstallFee, out Todecimal) == false)
                {
                    ShowMessage("安装费必须为数字！");
                    return;
                }
                string hiddjsonContent = hdfJsonContent.Value;
                int ProjectId = ddXMProject.SelectedValue == "" ? -1 : Convert.ToInt16(ddXMProject.SelectedValue);
                if (ProjectId == -1)
                {
                    base.ShowMessage("请选择项目！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //销售单价
                        for (int j = i + 1; j < ja_goods.Count; j++)
                        {
                            string productCode2 = ja_goods[j]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            decimal productPrice2 = ja_goods[j]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[j]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //销售单价
                            if ((productCode == productCode2) && (productPrice == productPrice2))
                            {
                                isSame = true;
                            }
                        }
                    }
                }

                if (isSame)    //厂家编码   商品价格 两项  不能相同
                {
                    base.ShowMessage("同一个厂家编码，相同销售单价无法添加！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        if (productCode == "")
                        {
                            isEmpty = true;                     //厂家编码存在为空
                        }
                        bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                        if (!t)
                        {
                            base.ShowMessage("商品采购数量数量格式不正确！");
                            BindGrid(hiddjsonContent);
                            return;
                        }
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //销售数量
                        if (productCount == 0)
                        {
                            isFalse = true;
                        }
                        decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //销售总价
                        totalSaleMoney += productMoney;
                    }
                }
                if (isEmpty)              //厂家编码为空
                {
                    base.ShowMessage("厂家编码不能为空！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (isFalse)
                {
                    base.ShowMessage("商品销售数量不能为0！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                XMSaleInfo saleInfo = new XMSaleInfo();
                saleInfo.Ref = rf;
                saleInfo.OrderInfoID = orderInfoId;
                saleInfo.ProjectId = ProjectId;
                saleInfo.CustomerName = customerName;
                saleInfo.Tel = tel;
                saleInfo.SaleAddress = cusAddress;
                saleInfo.SaleMoney = totalSaleMoney;
                saleInfo.ExpressFee = expressFee == "" ? fee : decimal.Parse(expressFee);
                saleInfo.PartsFee = partsFee == "" ? fee : decimal.Parse(partsFee);
                saleInfo.InstallFee = InstallFee == "" ? fee : decimal.Parse(InstallFee);
                saleInfo.ReceivingType = paymentType;
                saleInfo.BillStatus = 0;    //默认为待出库
                saleInfo.FinancialStatus = false;
                saleInfo.Remarks = note;
                saleInfo.BizUserId = HozestERPContext.Current.User.CustomerID;
                saleInfo.BizDt = DateTime.Now;
                saleInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                saleInfo.CreateDate = DateTime.Now;
                saleInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                saleInfo.UpdateDate = DateTime.Now;
                saleInfo.IsEnable = false;
                base.XMSaleInfoService.InsertXMSaleInfo(saleInfo);
                int saleID = saleInfo.Id;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //销售数量
                        decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //销售单价
                        decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //销售金额
                        int platFormId = ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim() == "" ? 251 : int.Parse(ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim());      //平台
                        XMSaleInfoProductDetails details = new XMSaleInfoProductDetails();
                        details.SaleInfoId = saleID;
                        var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                        if (product != null)
                        {
                            details.ProductId = product.Id;
                        }
                        details.PlatformTypeId = platFormId;
                        details.PlatformMerchantCode = productCode;
                        details.SaleCount = productCount;
                        details.ProductMoney = productMoney;
                        details.ProductPrice = productPrice;
                        details.Remarks = note;
                        details.CreateDate = DateTime.Now;
                        details.CreateID = HozestERPContext.Current.User.CustomerID;
                        details.UpdateID = HozestERPContext.Current.User.CustomerID;
                        details.UpdateDate = DateTime.Now;
                        details.IsEnable = false;
                        base.XMSaleInfoProductDetailsService.InsertXMSaleInfoProductDetails(details);
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(saleID);
            }
            else                    //编辑
            {
                decimal Todecimal = 0;
                decimal fee = 0;
                bool isSame = false;     //判断厂家编码相同 价格是否相同 
                int id = this.scid;
                bool isFalse = false;
                bool isEmpty = false;    //判断厂家编码是否为空
                decimal totalMoney = 0;        //销售单总价
                string expressFee = txtExpressFee.Text.Trim();
                string partsFee = txtPartsFee.Text.Trim();
                string InstallFee = txtInstallFee.Text.Trim();
                if (expressFee != "" && decimal.TryParse(expressFee, out Todecimal) == false)
                {
                    ShowMessage("快递费必须为数字！");
                    return;
                }
                if (partsFee != "" && decimal.TryParse(partsFee, out Todecimal) == false)
                {
                    ShowMessage("配件费必须为数字！");
                    return;
                }
                if (InstallFee != "" && decimal.TryParse(InstallFee, out Todecimal) == false)
                {
                    ShowMessage("安装费必须为数字！");
                    return;
                }
                string hiddjsonContent = hdfJsonContent.Value;             //产品列表 json
                int ProjectId = ddXMProject.SelectedValue == "" ? -1 : Convert.ToInt16(ddXMProject.SelectedValue);
                if (ProjectId == -1)
                {
                    base.ShowMessage("请选择项目！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                var saleInfo = base.XMSaleInfoService.GetXMSaleInfoById(id);
                if (saleInfo != null)
                {
                    var details = base.XMSaleInfoProductDetailsService.GetSaleInfoProductDetailsBySaleId(saleInfo.Id);
                    saleInfo.OrderInfoID = 0;
                    saleInfo.CustomerName = txtCustomerName.Text.Trim();
                    saleInfo.Tel = txtTel.Text.Trim();
                    saleInfo.SaleAddress = txtAddress.Text.Trim();
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //销售单价
                            for (int j = i + 1; j < ja_goods.Count; j++)
                            {
                                string productCode2 = ja_goods[j]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                                decimal productPrice2 = ja_goods[j]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[j]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //销售单价
                                if ((productCode == productCode2) && (productPrice == productPrice2))
                                {
                                    isSame = true;
                                }
                            }
                        }
                    }
                    if (isSame)    //厂家编码   商品价格 两项  不能相同
                    {
                        base.ShowMessage("同一个厂家编码，相同销售单价无法添加！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            if (productCode == "")          //判断厂家编码是否为空
                            {
                                isEmpty = true;
                            }
                            bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                            if (!t)
                            {
                                base.ShowMessage("商品采购数量数量格式不正确！");
                                BindGrid(hiddjsonContent);
                                return;
                            }
                            int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //销售数量
                            if (productCount == 0)
                            {
                                isFalse = true;
                            }
                            decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //销售金额
                            totalMoney = totalMoney + productMoney;
                        }
                    }

                    if (isEmpty)           //存在厂家编码为空的行数据
                    {
                        base.ShowMessage("厂家编码不能为空！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    if (isFalse)
                    {
                        base.ShowMessage("商品采购数量不能为 0！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    saleInfo.SaleMoney = totalMoney;
                    saleInfo.ExpressFee = expressFee == "" ? fee : decimal.Parse(expressFee);
                    saleInfo.PartsFee = partsFee == "" ? fee : decimal.Parse(partsFee);
                    saleInfo.InstallFee = InstallFee == "" ? fee : decimal.Parse(InstallFee);
                    saleInfo.ReceivingType = int.Parse(ddlPayment.SelectedValue);
                    saleInfo.Remarks = txtNote.Text.Trim();
                    saleInfo.BizUserId = HozestERPContext.Current.User.CustomerID;
                    saleInfo.BizDt = DateTime.Now;
                    saleInfo.UpdateDate = DateTime.Now;
                    saleInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                    saleInfo.ProjectId = ProjectId;
                    base.XMSaleInfoService.UpdateXMSaleInfo(saleInfo);
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            bool isExsit = false;                //判断厂家编码是否存在
                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                            string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                            int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //销售数量
                            string unit = ja_goods[i]["txtUnit"].ToString().Replace('\"', ' ').Trim();      //单位
                            decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //销售单价
                            decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //销售金额
                            int platFormId = ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim() == "" ? 251 : int.Parse(ja_goods[i]["PlatformTypeId"].ToString().Replace('\"', ' ').Trim());      //平台

                            foreach (XMSaleInfoProductDetails info in details)
                            {
                                if (productCode == info.PlatformMerchantCode && productPrice == info.ProductPrice)
                                {
                                    isExsit = true;
                                    info.SaleCount = productCount;
                                    info.ProductPrice = productPrice;
                                    info.ProductMoney = productMoney;
                                    info.PlatformTypeId = platFormId;
                                    info.ProductMoney = productMoney;
                                    info.ProductPrice = productPrice;
                                    info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    info.UpdateDate = DateTime.Now;
                                    base.XMSaleInfoProductDetailsService.UpdateXMSaleInfoProductDetails(info);
                                }
                            }
                            if (ja_goods.Count >= details.Count && isExsit == false)             //不存在新增
                            {
                                XMSaleInfoProductDetails saleInfoDetails = new XMSaleInfoProductDetails();
                                saleInfoDetails.SaleInfoId = saleInfo.Id;
                                var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                                if (product != null)
                                {
                                    saleInfoDetails.ProductId = product.Id;
                                }
                                saleInfoDetails.PlatformTypeId = platFormId;
                                saleInfoDetails.PlatformMerchantCode = productCode;
                                saleInfoDetails.SaleCount = productCount;
                                saleInfoDetails.ProductPrice = productPrice;
                                saleInfoDetails.ProductMoney = productMoney;
                                saleInfoDetails.CreateDate = DateTime.Now;
                                saleInfoDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                                saleInfoDetails.UpdateDate = DateTime.Now;
                                saleInfoDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                saleInfoDetails.IsEnable = false;
                                base.XMSaleInfoProductDetailsService.InsertXMSaleInfoProductDetails(saleInfoDetails);
                            }
                        }
                        if (details != null && details.Count > 0)
                        {
                            foreach (XMSaleInfoProductDetails info in details)
                            {
                                bool isDelete = true;
                                if (hiddjsonContent != "")
                                {
                                    JArray ja_goods2 = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                                    for (int i = 0; i < ja_goods.Count; i++)
                                    {
                                        string productCode2 = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                                        decimal productPrice2 = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //销售单价
                                        if (productCode2 == info.PlatformMerchantCode && productPrice2 == info.ProductPrice)
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
                                    base.XMSaleInfoProductDetailsService.UpdateXMSaleInfoProductDetails(info);
                                }
                            }
                        }
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(saleInfo.Id);
            }
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        private void loadBind()
        {
            //绑定收款方式
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(228, false);
            this.ddlPayment.DataSource = codeList;
            this.ddlPayment.DataTextField = "CodeName";
            this.ddlPayment.DataValueField = "CodeID";
            this.ddlPayment.DataBind();

            if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
            {
                List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                if (XMProjectList.Count > 0)
                {
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                }
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddXMProject.Items[0].Selected = true;
            }
            else
            {
                this.BindddXMProject();//项目
            }
        }


        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定
            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                //.Where(c => c.ProjectTypeId == 362)

                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    this.ddXMProject.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                }
                if (projectList.Count() > 0)
                {
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                }
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion
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