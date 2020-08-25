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

namespace HozestERP.Web.ManageInventory
{
    public partial class AdjustedAdd : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBind();
                BindInfo();
            }
        }

        private void BindInfo()
        {
            if (this.type == 0)    //新生成调整单
            {
                lblTitle.Text = "生成调整单";
                lblRef.Visible = false;
                BindGrid();
            }
            else if (type == 1)     //编辑调整单
            {
                lblTitle.Text = "编辑调整单";
                lblMessage.Visible = false;
                BindGrid(this.AdjustedID);
            }
            else if (type == 2)    //查看调整单
            {
                lblTitle.Text = "查看调整单";
                lblMessage.Visible = false;
                BindGrid(this.AdjustedID);
                btnSave.Visible = false;
            }
        }

        private void loadBind()
        {

            //绑定收款方式
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(228, false);
            this.ddlPayment.DataSource = codeList;
            this.ddlPayment.DataTextField = "CodeName";
            this.ddlPayment.DataValueField = "CodeID";
            this.ddlPayment.DataBind();
            this.BindddXMProject();//项目

        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddXMProject.Value.ToString().Trim().Length > 0)
            {
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                                         .GroupBy(p => new { p.Id, p.ProjectName })
                                         .Select(p => new
                                         {
                                             Id = p.Key.Id,
                                             ProjectName = p.Key.ProjectName
                                         });
                string paramprojectIDs = "";
                string paramprojectIDSelect = this.ddXMProject.Value.ToString();
                if (paramprojectIDSelect == "-1" || paramprojectIDSelect == "99")
                {
                    for (int i = 0; i < projectList.ToList().Count; i++)
                    {
                        paramprojectIDs = paramprojectIDs + projectList.ToList()[i].Id + ",";
                    }
                    paramprojectIDs = paramprojectIDs.Substring(0, paramprojectIDs.Length - 1) + ",-1";
                }
                else
                {
                    paramprojectIDs = paramprojectIDSelect;
                }
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(paramprojectIDs);
                Ext.Net.Store Store = ddlwareHouses.GetStore();
                Store.DataSource = wareHouses;
                Store.DataBind();
                //ddlwareHouses.SelectedIndex = 0;
            }
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 682 || HozestERPContext.Current.User.CustomerID == 670)
            {
                ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                Ext.Net.Store Store = ddXMProject.GetStore();
                projectList.Add(new XMProject()
                {
                    ProjectName = "---所有---",
                    Id = -1,
                });
                Store.DataSource = projectList.OrderBy(a => a.Id);
                Store.DataBind();
                ddXMProject.SelectedIndex = 0;
                ddXMProject.Value = "-1";
            }
            else
            {
                ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    Ext.Net.ListItem liProject = new Ext.Net.ListItem();
                    liProject.Text = "---无项目权限---";
                    liProject.Value = "0";
                    ddXMProject.Items.Add(liProject);
                    ddXMProject.Value = 0;
                }
                else
                {
                    Ext.Net.Store Store = ddXMProject.GetStore();
                    Store.DataSource = projectList;
                    Store.DataBind();
                    ddXMProject.SelectedIndex = 0;
                    ddXMProject.Value = projectList.ToList()[0].Id;
                    Ext.Net.ListItem liProject1 = new Ext.Net.ListItem();
                    liProject1.Text = "---所有---";
                    liProject1.Value = "99";
                    ddXMProject.Items.Add(liProject1);
                    ddXMProject.Value = 99;
                }
            }
            #endregion
        }

        private void BindGrid()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>数量</th><th>单位</th><th>单价</th><th>金额</th><th>税率(%)</th><th>税金</th><th>价税合计</th></tr>");
            var pdInfo = base.XMPdInfoService.GetXMPdInfoById(this.PdId);
            if (pdInfo != null)
            {
                if (!string.IsNullOrEmpty(pdInfo.ProjectId.ToString()))
                {
                    if (pdInfo.ProjectId == -1)
                    {
                        ddXMProject.SelectedIndex = 0;
                    }
                    else
                    {
                        ddXMProject.Value = pdInfo.ProjectId.ToString();
                    }
                }
                var pdInfoProductDetail = base.XMPdInfoProductDetailsService.GetXMPdInfoProductDetailsListByPdID(pdInfo.Id);

                this.BindddXMProject();//项目
                if (pdInfo.ProjectId == -1)
                {
                    ddXMProject.SelectedIndex = 0;
                }
                else
                {
                    ddXMProject.Value = pdInfo.ProjectId.ToString();
                }
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlwareHouses.Value = pdInfo.WarehouseId.ToString();
                decimal price = 0;
                var details = base.XMPdInfoProductDetailsService.GetXMPdInfoProductDetailsListByPdID(pdInfo.Id);               
                if (details != null && details.Count > 0)
                {
                    foreach (XMPdInfoProductDetails Info in details)
                    {
                        var productDetail = base.XMProductDetailsService.GetXMProductDetailsListByProductId(Info.ProductId.Value);
                        if (productDetail != null && productDetail.Count > 0)
                        {
                            price = productDetail[0].Costprice.Value;
                        }
                        //查询当前产品库存是否与盘点数量一致
                        var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(Info.PlatformMerchantCode, pdInfo.WarehouseId);
                        if (InventoryInfo != null && InventoryInfo.StockNumber != Info.PCount)
                        {
                            int? a = Info.PCount - InventoryInfo.StockNumber;              //差值（盘点数量-库存数量） 差值<0  盘亏出库   差值>0  盘盈入库
                            decimal money = price * a.Value;
                            decimal tax = money * 10 / 100;
                            decimal taxMoney = money + tax;
                            str.Append("<tr  id=\"mytr\">");
                            str.Append("<td><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.PlatformMerchantCode + "' /></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" type=\"text\"  value='" + Info.ProductName + "' /></td><td><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + Info.Specifications + "' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + a.ToString() + "' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='' readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + price.ToString() + "' /></td><td><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + money.ToString() + "' /></td><td><input runat=\"server\" id=\"txtTaxRate\" class=\"TextBox\" style=\"text-align: left; width: 85px;\" value='10' /></td><td><input runat=\"server\" id=\"txtTax\" class=\"TextBox\" style=\"text-align: left; width: 90%\" type=\"text\" value='" + tax.ToString() + "' /></td><td><input runat=\"server\" id=\"txtMoneyWithTax\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + taxMoney.ToString() + "' /></td></tr>");
                        }
                        else 
                        {
                            int? a = Info.PCount - 0;              //仓库原来没有这个产品，默认原数量为0
                            decimal money = price * a.Value;
                            decimal tax = money * 10 / 100;
                            decimal taxMoney = money + tax;
                            str.Append("<tr  id=\"mytr\">");
                            str.Append("<td><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.PlatformMerchantCode + "' /></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" type=\"text\"  value='" + Info.ProductName + "' /></td><td><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + Info.Specifications + "' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + a.ToString() + "' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='' readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + price.ToString() + "' /></td><td><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + money.ToString() + "' /></td><td><input runat=\"server\" id=\"txtTaxRate\" class=\"TextBox\" style=\"text-align: left; width: 85px;\" value='10' /></td><td><input runat=\"server\" id=\"txtTax\" class=\"TextBox\" style=\"text-align: left; width: 90%\" type=\"text\" value='" + tax.ToString() + "' /></td><td><input runat=\"server\" id=\"txtMoneyWithTax\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + taxMoney.ToString() + "' /></td></tr>");
                       
                        }
                    }
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }

        private void BindGrid(int adjustedID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>数量</th><th>单位</th><th>单价</th><th>金额</th><th>税率(%)</th><th>税金</th><th>价税合计</th></tr>");
            //绑定调整单主表和产品明细表
            var adjustedInfo = base.XMAdjustedInfoService.GetXMAdjustedInfoById(adjustedID);
            if (adjustedInfo != null)
            {
                lblRef.Text = adjustedInfo.Ref;
                if (!string.IsNullOrEmpty(adjustedInfo.ProjectId.ToString()))
                {
                    if (adjustedInfo.ProjectId == -1)
                    {
                        ddXMProject.SelectedIndex = 0;
                    }
                    else
                    {
                        ddXMProject.Value = adjustedInfo.ProjectId.ToString();
                    }
                }
                var adjustedInfoDetails = base.XMAdjustedProductDetailService.GetXMAdjustedProductDetailListByAdjustedID(adjustedInfo.Id);
                txtStorageDate.Value = adjustedInfo.BizDt.ToString() == "" ? DateTime.Now.ToShortDateString() : adjustedInfo.BizDt.ToString();
                this.BindddXMProject();//项目
                if (adjustedInfo.ProjectId == -1)
                {
                    ddXMProject.SelectedIndex = 0;
                }
                else
                {
                    ddXMProject.Value = adjustedInfo.ProjectId.ToString();
                }
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlwareHouses.Value = adjustedInfo.WarehouseId.ToString();
                txtNote.Text = adjustedInfo.BillMemo;
                if (adjustedInfoDetails != null && adjustedInfoDetails.Count > 0)
                {
                    foreach (XMAdjustedProductDetail info in adjustedInfoDetails)
                    {
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.PlatformMerchantCode + "' /></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" value='" + info.ProductName + "'  type=\"text\"/></td><td><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + info.Specifications + "' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductCount.ToString() + "' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='" + info.ProductUnit + "' readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductPrice.ToString() + "' /></td><td><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductMoney.ToString() + "' /></td><td><input runat=\"server\" id=\"txtTaxRate\" class=\"TextBox\" style=\"text-align: left; width: 85px;\" value='10' /></td><td><input runat=\"server\" id=\"txtTax\" class=\"TextBox\" style=\"text-align: left; width: 90%\" type=\"text\" value='" + info.Tax.ToString() + "' /></td><td><input runat=\"server\" id=\"txtMoneyWithTax\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.MoneyWithTax.ToString() + "' /></td></tr>");
                    }
                }
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }
        /// <summary>
        /// 通过json数据绑定产品列表（用于提示错后跳转绑定）
        /// </summary>
        /// <param name="jsonContent"></param>
        private void BindGrid(string jsonContent)
        {
            
            
            decimal value = 0;
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>数量</th><th>单位</th><th>单价</th><th>金额</th><th>税率(%)</th><th>税金</th><th>价税合计</th></tr>");
            if (jsonContent != "")
            {
                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(jsonContent);
                for (int i = 0; i < ja_goods.Count; i++)
                {
                    int productCount = 0;
                    string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                    string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                    string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                    bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                    if (t)
                    {
                        productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //销售数量
                    }
                    string unit = ja_goods[i]["txtUnit"].ToString().Replace('\"', ' ').Trim();      //单位
                    decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //销售单价
                    decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //销售金额
                    decimal tax = ja_goods[i]["txtTax"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtTax"].ToString().Replace('\"', ' ').Trim());      //税率
                    decimal taxRate = ja_goods[i]["txtTaxRate"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtTaxRate"].ToString().Replace('\"', ' ').Trim());      //税率
                    decimal MoneyWithTax = ja_goods[i]["txtMoneyWithTax"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtMoneyWithTax"].ToString().Replace('\"', ' ').Trim());      //价税合计
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCode + "' /></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" value='" + productName + "'  type=\"text\"/></td><td><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + specifications + "' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCount.ToString() + "' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='" + unit + "' readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productPrice.ToString() + "' /></td><td><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productMoney.ToString() + "' /></td><td><input runat=\"server\" id=\"txtTaxRate\" class=\"TextBox\" style=\"text-align: left; width: 85px;\" value='10' /></td><td><input runat=\"server\" id=\"txtTax\" class=\"TextBox\" style=\"text-align: left; width: 90%\" type=\"text\" value='" + tax.ToString() + "' /></td><td><input runat=\"server\" id=\"txtMoneyWithTax\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + MoneyWithTax.ToString() + "' /></td></tr>");

                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }

        /// <summary>
        /// 自动生成调整单号
        /// </summary>
        /// <returns></returns>
        private string AutoAdjustedNumber()
        {
            string AdjustedCode = "";       //自动生成调整单号
            int number = 1;
            var Adjusted = base.XMAdjustedInfoService.GetXMAdjustedInfoList();
            if (Adjusted != null && Adjusted.Count > 0)
            {
                number = Adjusted[0].Id + 1;
            }
            AdjustedCode = "AD" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return AdjustedCode;
        }

        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^-?[1-9]\d*$");
            return reg1.IsMatch(str);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal value = 0;
            if (this.type == 0)            //新增
            {
                bool isEmpty = false;  //判断产品编码是否存在空
                bool isFalse = false;
                string hiddjsonContent = hdfJsonContent.Value;             //产品列表 json
                string wfID = ddlwareHouses.Value.ToString();
                string Ref = AutoAdjustedNumber();               //
                if (wfID == "")
                {
                    base.ShowMessage("请添加仓库或未选择仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (int.Parse(wfID) == -1)
                {
                    base.ShowMessage("请添加仓库或未选择仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                decimal totalMoney = 0;        //调整单总价
                decimal totalMoneywithTax = 0;      //调整单税金总数
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                        if (!t)
                        {
                            base.ShowMessage("商品采购数量数量格式不正确！");
                            BindGrid(hiddjsonContent);
                            return;
                        }
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //销售数量
                        if (productCode == "")
                        {
                            isEmpty = true;
                        }
                        if (productCount == 0)
                        {
                            isFalse = true;
                        }
                        decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //调整单单价
                        totalMoney = totalMoney + productMoney;
                        decimal MoneyWithTax = ja_goods[i]["txtMoneyWithTax"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtMoneyWithTax"].ToString().Replace('\"', ' ').Trim());      //价税合计
                        totalMoneywithTax = totalMoneywithTax + MoneyWithTax;
                    }
                }
                if (isEmpty)
                {
                    base.ShowMessage("厂家编码不能为空！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (isFalse)
                {
                    base.ShowMessage("商品数量不能为0！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                XMAdjustedInfo adjustedInfo = new XMAdjustedInfo();
                adjustedInfo.PdInfoId = this.PdId;
                adjustedInfo.Ref = Ref;
                adjustedInfo.WarehouseId = int.Parse(ddlwareHouses.Value.ToString());
                adjustedInfo.SaleMoney = totalMoney;
                adjustedInfo.MoneywithTax = totalMoneywithTax;
                adjustedInfo.ReceivingType = Convert.ToInt16(ddlPayment.SelectedValue);
                adjustedInfo.BizUserId = HozestERPContext.Current.User.CustomerID;    //操作人
                adjustedInfo.BizDt = txtStorageDate.Value == "" ? DateTime.Parse(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(txtStorageDate.Value);
                adjustedInfo.BillMemo = txtNote.Text.Trim();
                adjustedInfo.CreateDate = adjustedInfo.UpdateDate = DateTime.Now;
                adjustedInfo.CreateID = adjustedInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                adjustedInfo.IsEnable = false;
                adjustedInfo.FinancialStatus = false;
                base.XMAdjustedInfoService.InsertXMAdjustedInfo(adjustedInfo);
                int adjustedID = adjustedInfo.Id;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                        string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //销售数量
                        string unit = ja_goods[i]["txtUnit"].ToString().Replace('\"', ' ').Trim();      //单位
                        decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //销售单价
                        decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //销售金额
                        decimal tax = ja_goods[i]["txtTax"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtTax"].ToString().Replace('\"', ' ').Trim());      //税率
                        decimal taxRate = ja_goods[i]["txtTaxRate"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtTaxRate"].ToString().Replace('\"', ' ').Trim());      //税率
                        decimal MoneyWithTax = ja_goods[i]["txtMoneyWithTax"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtMoneyWithTax"].ToString().Replace('\"', ' ').Trim());      //价税合计

                        XMAdjustedProductDetail details = new XMAdjustedProductDetail();
                        details.AdId = adjustedID;
                        var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                        if (product != null)
                        {
                            details.ProductId = product.Id;
                        }
                        details.PlatformMerchantCode = productCode;
                        details.ProductCount = productCount;
                        details.ProductMoney = productMoney;
                        details.ProductPrice = productPrice;
                        details.Tax = tax;
                        details.TaxRate = taxRate;
                        details.MoneyWithTax = MoneyWithTax;
                        details.CreateDate = details.UpdateDate = DateTime.Now;
                        details.CreateID = details.UpdateID = HozestERPContext.Current.User.CustomerID;
                        details.IsEnable = false;
                        base.XMAdjustedProductDetailService.InsertXMAdjustedProductDetail(details);
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(adjustedInfo.Id);
            }
            else                                   //修改
            {
                bool isFalse = false;
                bool isEmpty = false;  //判断产品编码是否存在空
                decimal totalMoney = 0;        //调整单总价
                decimal totalMoneywithTax = 0;      //调整单税金总数
                string wfID = ddlwareHouses.Value.ToString();
                string hiddjsonContent = hdfJsonContent.Value;             //产品列表 json
                if (int.Parse(wfID) == -1)
                {
                    base.ShowMessage("请添加仓库或未选择仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                var adjusted = base.XMAdjustedInfoService.GetXMAdjustedInfoById(this.AdjustedID);
                if (adjusted != null)
                {
                    adjusted.WarehouseId = int.Parse(ddlwareHouses.Value.ToString());
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            if (productCode == "")
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
                            decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //采购单价
                            totalMoney += productMoney;
                            decimal MoneyWithTax = ja_goods[i]["txtMoneyWithTax"].ToString().Replace('\"', ' ') == "" ? value : decimal.Parse(ja_goods[i]["txtMoneyWithTax"].ToString().Replace('\"', ' ').Trim());      //价税合计
                            totalMoneywithTax = totalMoneywithTax + MoneyWithTax;
                        }
                    }
                    if (isEmpty)
                    {
                        base.ShowMessage("厂家编码不能为空！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    if (isFalse)
                    {
                        base.ShowMessage("商品数量不能为0！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    adjusted.SaleMoney = totalMoney;
                    adjusted.MoneywithTax = totalMoneywithTax;
                    adjusted.ReceivingType = int.Parse(ddlPayment.SelectedValue);
                    adjusted.BillMemo = txtNote.Text.Trim();
                    adjusted.UpdateID = HozestERPContext.Current.User.CustomerID;
                    adjusted.UpdateDate = DateTime.Now;
                    base.XMAdjustedInfoService.UpdateXMAdjustedInfo(adjusted);
                    var adjustedDetails = base.XMAdjustedProductDetailService.GetXMAdjustedProductDetailListByAdjustedID(adjusted.Id);
                    if (adjustedDetails != null && adjustedDetails.Count > 0)
                    {
                        if (hiddjsonContent != "")
                        {
                            JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                            for (int i = 0; i < ja_goods.Count; i++)
                            {
                                bool isExsit = false;                //判断厂家编码是否存在
                                string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                                int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //调整单数量
                                decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //调整单价
                                decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //调整金额
                                decimal tax = ja_goods[i]["txtTax"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtTax"].ToString().Replace('\"', ' ').Trim());      //税率
                                decimal taxRate = ja_goods[i]["txtTaxRate"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtTaxRate"].ToString().Replace('\"', ' ').Trim());      //税率
                                decimal MoneyWithTax = ja_goods[i]["txtMoneyWithTax"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtMoneyWithTax"].ToString().Replace('\"', ' ').Trim());      //价税合计

                                foreach (XMAdjustedProductDetail info in adjustedDetails)
                                {
                                    if (productCode == info.PlatformMerchantCode)
                                    {
                                        isExsit = true;
                                        info.ProductCount = productCount;
                                        info.ProductPrice = productPrice;
                                        info.ProductMoney = productMoney;
                                        info.Tax = tax;
                                        info.TaxRate = taxRate;
                                        info.MoneyWithTax = MoneyWithTax;
                                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        info.UpdateDate = DateTime.Now;
                                        base.XMAdjustedProductDetailService.UpdateXMAdjustedProductDetail(info);
                                    }
                                }
                                if (isExsit == false)             //不存在新增
                                {
                                    XMAdjustedProductDetail adjustDetail = new XMAdjustedProductDetail();
                                    adjustDetail.AdId = adjusted.Id;
                                    var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                                    if (product != null)
                                    {
                                        adjustDetail.ProductId = product.Id;
                                    }
                                    adjustDetail.PlatformMerchantCode = productCode;
                                    adjustDetail.ProductCount = productCount;
                                    adjustDetail.ProductPrice = productPrice;
                                    adjustDetail.ProductMoney = productMoney;
                                    adjustDetail.Tax = tax;
                                    adjustDetail.TaxRate = taxRate;
                                    adjustDetail.MoneyWithTax = MoneyWithTax;
                                    adjustDetail.UpdateDate = adjustDetail.CreateDate = DateTime.Now;
                                    adjustDetail.CreateID = adjustDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    adjustDetail.IsEnable = false;
                                    base.XMAdjustedProductDetailService.InsertXMAdjustedProductDetail(adjustDetail);
                                }
                            }
                        }
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(adjusted.Id);
            }
        }


        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }
        /// <summary>
        /// 主键ID 
        /// </summary>
        public int AdjustedID
        {
            get
            {
                return CommonHelper.QueryStringInt("AdjustedID");
            }
        }
        /// <summary>
        /// 盘点单ID
        /// </summary>
        public int PdId
        {
            get
            {
                return CommonHelper.QueryStringInt("PdID");
            }
        }

        /// <summary>
        /// 判断是添加还是修改
        /// </summary>
        public int type
        {
            get
            {
                return CommonHelper.QueryStringInt("type");
            }
        }
    }
}