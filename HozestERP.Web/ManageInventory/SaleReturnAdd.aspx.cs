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
    public partial class SaleReturnAdd : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SaleReturn"] = null;
                loadBind();
                BindInfo();
            }
        }

        private void BindInfo()
        {
            if (this.type == 0)    //新生成退货入库单
            {
                lblRef.Visible = false;
                btnSaleReturnStorge.Visible = false;
                BindGrid();
            }
            else if (type == 1)     //编辑退货入库单
            {
                lblTitle.Text = "编辑退货入库单";
                lblMessage.Visible = false;
                btnSaleReturnStorge.Visible = true;
                BindGrid(this.SaleReturnID);
            }
            else if (type == 2)        //查看退货入库单
            {
                lblTitle.Text = "查看退货入库单";
                lblMessage.Visible = false;
                btnSaleReturnStorge.Visible = false;
                BindGrid(this.SaleReturnID);
                btnSave.Visible = false;
            }
        }

        private void BindGrid()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>可退货数量</th><th>退货数量</th><th>单位</th><th>退货单价</th><th>退货金额</th><th>操作</th></tr>");
            //获取销售出库单产品明细
            var saleDeliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(this.SaleDeliveryID);
            if (saleDeliveryProductDetails != null && saleDeliveryProductDetails.Count > 0)
            {
                foreach (XMSaleDeliveryProductDetails info in saleDeliveryProductDetails)
                {
                    int kReturnCount = GetKReturnCount(info.SaleCount.Value, info.Id);     //可退货数量 <= 销售出库产品数量-  已经退货数量
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td id=\"PlatformMerchantCode\">" + info.PlatformMerchantCode + "</td><td id=\"ProductName\">" + info.ProductName + "</td><td>" + info.Specifications + "</td> <td id=\"counts\"><input runat=\"server\" id=\"txtKCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + kReturnCount.ToString() + "'  readonly=\"readonly\"/></td><td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + kReturnCount.ToString() + "' /></td><td>" + info.ProductUnit + "</td><td id=\"Price\">" + info.ProductPrice.ToString() + "</td><td id=\"ProductMoney\">" + info.ProductMoney.ToString() + "</td><td id=\"PID\"><input id=\"hiddPID\"  type=\"hidden\"  value='" + info.Id + "'  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /> <input type=\"image\" name=\"setBarCode\" id=\"setBarCodes\"  title=\"设置条形码\" src=\"../App_Themes/Blue/Image/ButtonImages/meeting.gif\"  onclick=\"return ShowWindowDetail('设置商品条形码','" + CommonHelper.GetStoreLocation() + "ManageInventory/SetProductsBarCode.aspx?Status=SaleReturn&&ID=" + info.Id + "',300,600, this);\"/></td></tr>");
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
            //绑定收款方式
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(228, false);
            this.ddlPayment.DataSource = codeList;
            this.ddlPayment.DataTextField = "CodeName";
            this.ddlPayment.DataValueField = "CodeID";
            this.ddlPayment.DataBind();
           
            this.ddXMProject_SelectedIndexChanged(null, null);//仓库
        }



        private void BindGrid(int saleReturnID)
        {
            //绑定收款方式
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(228, false);
            this.ddlPayment.DataSource = codeList;
            this.ddlPayment.DataTextField = "CodeName";
            this.ddlPayment.DataValueField = "CodeID";
            this.ddlPayment.DataBind();
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>可退货数量</th><th>退货数量</th><th>单位</th><th>退货单价</th><th>退货金额</th><th>操作</th></tr>");
            //绑定退货入库单主表和产品明细表
            var saleReturn = base.XMSaleReturnService.GetXMSaleReturnById(saleReturnID);
            if (saleReturn != null)
            {
                
                lblRef.Text = saleReturn.Ref;
                var saleReturnDetails = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsListBySaleReturnID(saleReturnID);
                if (!string.IsNullOrEmpty(saleReturn.ProjectId.ToString()))
                {
                    ddXMProject.Value = saleReturn.ProjectId.ToString();
                }
                
                ddlPayment.SelectedValue = saleReturn.PaymentType.ToString();
                this.BindddXMProject();//项目
                if (saleReturn.ProjectId == -1) 
                {
                    ddXMProject.SelectedIndex = 0;
                }
                else
                {
                    ddXMProject.Value = saleReturn.ProjectId.ToString();
                }
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlwareHouses.Value = saleReturn.WarehouseId.ToString();
                txtNote.Text = saleReturn.Remarks;
                txtStorageDate.Value = saleReturn.BizDt.ToString() == "" ? DateTime.Now.ToShortDateString() : saleReturn.BizDt.ToString();
                if (saleReturnDetails != null && saleReturnDetails.Count > 0)
                {
                    foreach (XMSaleReturnProductDetails info in saleReturnDetails)
                    {
                        string PlatformMerchantCode = "";
                        int kSaleReturnCount = 0;
                        if (info.DeliveryProductsDetailID != null && info.DeliveryProductsDetailID.ToString() != "")
                        {
                            //var deliveryp = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(info.DeliveryProductsDetailID.Value);
                            //var applicationExchange = XMApplicationExchangeService.GetXMApplicationExchangeByID((int)info.DeliveryProductsDetailID);
                            var product = XMProductService.GetXMProductById((int)info.ProductId);
                            if (product != null)
                            {
                                PlatformMerchantCode = product.ManufacturersCode;
                                //kSaleReturnCount = GetKReturnCount(deliveryp.SaleCount.Value, deliveryp.Id);
                            }
                        }
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td id=\"PlatformMerchantCode\">" + PlatformMerchantCode + "</td><td id=\"ProductName\">" + info.ProductName + "</td><td>" + info.Specifications + "</td><td id=\"counts\"><input runat=\"server\" id=\"txtKCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + kSaleReturnCount.ToString() + "'  readonly=\"readonly\"/></td><td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.RejectionProdcutsCount.ToString() + "' /></td><td>" + info.ProductUnit + "</td><td id=\"Price\">" + info.RejectionProductsPrice.ToString() + "</td><td id=\"ProductMoney\">" + info.RejectionsaleMoney.ToString() + "</td>");
                        str.Append("<td id=\"PID\"><input id=\"hiddPID\"  type=\"hidden\"  value='" + info.Id + "'  /><input type=\"image\" name=\"setBarCode\" id=\"setBarCodes\"  title=\"查看条形码\" src=\"../App_Themes/Blue/Image/ButtonImages/meeting.gif\"  onclick=\"return ShowWindowDetail('查看商品条形码','" + CommonHelper.GetStoreLocation() + "ManageInventory/ProductBarCodeList.aspx?Status=SaleReturn&&ID=" + info.Id + "',400,600, this);\"/></td>");
                        str.Append("</tr>");
                    }
                }
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }

        private int GetKReturnCount(int deliveryId, string PlatformMerchantCode)
        {
            int count = 0;
            var saleDeliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(deliveryId);
            if (saleDeliveryProductDetails != null && saleDeliveryProductDetails.Count > 0)
            {
                foreach (XMSaleDeliveryProductDetails info in saleDeliveryProductDetails)
                {
                    if (info.PlatformMerchantCode == PlatformMerchantCode)
                    {
                        count = count + info.SaleCount.Value;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// 通过json数据绑定产品列表
        /// </summary>
        private void BindGrid(string jsonContent)
        {
            var saleReturn = base.XMSaleReturnService.GetXMSaleReturnById(SaleReturnID);
            this.BindddXMProject();//项目

            //新增
            if (this.type != 0)
            {
                ddXMProject.Value = saleReturn.ProjectId.ToString();
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlwareHouses.Value = saleReturn.WarehouseId.ToString();
            }
            decimal value = 0;
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>可退货数量</th><th>退货数量</th><th>单位</th><th>退货单价</th><th>退货金额</th><th>操作</th></tr>");
            if (jsonContent != "")
            {
                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(jsonContent);
                for (int i = 0; i < ja_goods.Count; i++)
                {
                    string productName = "";
                    string sp = "";
                    string unit = "";
                    string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                    var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                    if (product != null)
                    {
                        productName = product.ProductName;
                        sp = product.Specifications;
                        unit = product.ProductUnit;
                    }

                    string productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim();      //退货数量
                    string productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim();      //退货单价
                    string productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim();      //退货金额
                    int kReturnCount = ja_goods[i]["KCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["KCount"].ToString().Replace('\"', ' ').Trim());      //可退货数量

                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td id=\"PlatformMerchantCode\">" + productCode + "</td><td id=\"ProductName\">" + productName + "</td><td>" + sp + "</td><td id=\"counts\"><input runat=\"server\" id=\"txtKCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + kReturnCount.ToString() + "'  readonly=\"readonly\"/></td><td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCount + "' /></td><td>" + unit + "</td><td id=\"Price\">" + productPrice + "</td><td id=\"ProductMoney\">" + productMoney + "</td><td><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }

        private int GetKReturnCount(int saleCount, int infoId)
        {
            var returnInfo = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsListByDeliveryProductsDetailID(infoId);
            if (returnInfo != null && returnInfo.Count > 0)
            {
                foreach (XMSaleReturnProductDetails Info in returnInfo)
                {
                    saleCount = saleCount - Info.RejectionProdcutsCount.Value;
                }
            }
            return saleCount;
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
                    ddXMProject.Items.Insert(0,liProject1);
                }
            }
            #endregion
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

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        private string AutoSaleReturnNumber()
        {
            string SaleReturnCode = "";       //自动生成销售退货单号
            int number = 1;
            var saleReturn = base.XMSaleReturnService.GetXMSaleReturnList();
            if (saleReturn != null && saleReturn.Count > 0)
            {
                number = saleReturn[0].Id + 1;
            }
            SaleReturnCode = "SR" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return SaleReturnCode;
        }

        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^[0-9]*[0-9][0-9]*$");
            return reg1.IsMatch(str);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal value = 0;
            if (this.type == 0)            //新增
            {
                bool isFalse = false;
                string hiddjsonContent = hdfJsonContent.Value;
                string rf = AutoSaleReturnNumber();        //自动生成入库单号
                int orderinfoID = 0;     //暂时未与订单关联
                if (ddlwareHouses.Value == "" || ddlwareHouses.Value == null)
                {
                    base.ShowMessage("请添加仓库或未选择仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                int wareHouseId = int.Parse(ddlwareHouses.Value.ToString());
                int billStatus = 0;    //状态为待入库
                int BizUserId = HozestERPContext.Current.User.CustomerID;    // 入库人
                DateTime BizDt = txtStorageDate.Value == "" ? DateTime.Parse(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(txtStorageDate.Value);   //入库时间
                decimal totalMoney = 0;
                int paymentType = int.Parse(ddlPayment.SelectedValue);
                string note = txtNote.Text.Trim();

                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        bool t = IsNumeric(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());
                        if (!t)
                        {
                            base.ShowMessage("商品采购数量数量格式不正确！");
                            BindGrid(hiddjsonContent);
                            return;
                        }
                        int kReturnCount = ja_goods[i]["KCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["KCount"].ToString().Replace('\"', ' ').Trim());      //可退货数量
                        int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                        if (productCount < 0 || productCount > (kReturnCount + productCount))
                        {
                            isFalse = true;
                        }
                        decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ') == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //采购总价
                        totalMoney += productMoney;
                    }
                }
                if (isFalse)
                {
                    base.ShowMessage("退货商品数量不能为0或退货数量不能大于出库数量！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                XMSaleReturn returnInfo = new XMSaleReturn();
                returnInfo.Ref = rf;
                returnInfo.OrderInfoID = orderinfoID;
                returnInfo.WarehouseId = wareHouseId;
                returnInfo.BillStatus = billStatus;
                returnInfo.RejectionsaleMoney = totalMoney;
                returnInfo.SaleDeliveryId = this.SaleDeliveryID;
                returnInfo.PaymentType = paymentType;
                returnInfo.Remarks = note;
                returnInfo.BizUserId = BizUserId;
                returnInfo.BizDt = BizDt;
                returnInfo.CreateDate = returnInfo.UpdateDate = DateTime.Now;
                returnInfo.UpdateID = returnInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                returnInfo.IsEnable = false;
                base.XMSaleReturnService.InsertXMSaleReturn(returnInfo);
                int saleReturnId = returnInfo.Id;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string PID = ja_goods[i]["PID"].ToString().Replace('\"', ' ').Trim();       //销售订单产品详情ID
                        string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                        decimal productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim());      //退货单价
                        decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //退货金额
                        var saleDeliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(this.SaleDeliveryID);
                        XMSaleReturnProductDetails returnDetails = new XMSaleReturnProductDetails();
                        returnDetails.SaleReturnId = saleReturnId;
                        var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                        if (product != null)
                        {
                            returnDetails.ProductId = product.Id;
                        }
                        if (saleDeliveryProductDetails != null && saleDeliveryProductDetails.Count > 0)
                        {
                            foreach (XMSaleDeliveryProductDetails info in saleDeliveryProductDetails)
                            {
                                if (productCode == info.PlatformMerchantCode && productPrice == info.ProductPrice)
                                {
                                    returnDetails.DeliveryProductsDetailID = info.Id;
                                }
                            }
                        }
                        returnDetails.RejectionProdcutsCount = productCount;   //退货数量
                        returnDetails.RejectionProductsPrice = productPrice;  // 退货单价
                        returnDetails.RejectionsaleMoney = productMoney;  //退货金额
                        returnDetails.CreateDate = returnDetails.UpdateDate = DateTime.Now;
                        returnDetails.CreateID = returnDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                        returnDetails.IsEnable = false;
                        base.XMSaleReturnProductDetailsService.InsertXMSaleReturnProductDetails(returnDetails);
                        //插入退货商品条形码集合
                        // InsertSaleReturnBarCodes(returnDetails.Id, int.Parse(PID), productCount);
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(returnInfo.Id);
            }
            else                         //编辑
            {
                bool isFalse = false;
                string hiddjsonContent = hdfJsonContent.Value;
                int id = this.SaleReturnID;
                decimal totalMoney = 0;        //总价
                var saleReturnInfo = base.XMSaleReturnService.GetXMSaleReturnById(id);
                if (saleReturnInfo != null)
                {
                    if (ddlwareHouses.Value == "" || ddlwareHouses.Value == null)
                    {
                        base.ShowMessage("请添加仓库或未选择仓库！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    int wareHoursesID = int.Parse(ddlwareHouses.Value.ToString());
                    var saleReturnDetails = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsListBySaleReturnID(saleReturnInfo.Id);
                    saleReturnInfo.WarehouseId = wareHoursesID;
                    saleReturnInfo.BizDt = txtStorageDate.Value == "" ? DateTime.Parse(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(txtStorageDate.Value);   //业务时间

                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            bool t = IsNumeric(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());
                            if (!t)
                            {
                                base.ShowMessage("商品采购数量数量格式不正确！");
                                BindGrid(hiddjsonContent);
                                return;
                            }
                            int kReturnCount = ja_goods[i]["KCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["KCount"].ToString().Replace('\"', ' ').Trim());      //可退货数量
                            int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                            if (productCount <0 || productCount > (kReturnCount + productCount))
                            {
                                isFalse = true;
                            }
                            decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ') == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //采购总价
                            totalMoney += productMoney;
                        }
                    }
                    if (isFalse)
                    {
                        base.ShowMessage("退货商品数量不能为0或退货数量不能大于出库数量！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    saleReturnInfo.RejectionsaleMoney = totalMoney;
                    saleReturnInfo.PaymentType = int.Parse(ddlPayment.SelectedValue);
                    saleReturnInfo.Remarks = txtNote.Text.Trim();
                    base.XMSaleReturnService.UpdateXMSaleReturn(saleReturnInfo);
                    if (saleReturnDetails != null && saleReturnDetails.Count() > 0)
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
                                foreach (XMSaleReturnProductDetails info in saleReturnDetails)
                                {
                                    var details = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(info.DeliveryProductsDetailID.Value);
                                    if (details != null && productCode == details.PlatformMerchantCode && productPrice == details.ProductPrice)
                                    {
                                        info.RejectionProdcutsCount = productCount;
                                        info.RejectionProductsPrice = productPrice;
                                        info.RejectionsaleMoney = productMoney;
                                        info.UpdateDate = DateTime.Now;
                                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMSaleReturnProductDetailsService.UpdateXMSaleReturnProductDetails(info);
                                    }
                                }
                            }
                        }

                        foreach (XMSaleReturnProductDetails info in saleReturnDetails)
                        {
                            bool isDelete = true;
                            var details2 = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(info.DeliveryProductsDetailID.Value);
                            if (hiddjsonContent != "")
                            {
                                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                                for (int i = 0; i < ja_goods.Count; i++)
                                {
                                    string productCode2 = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                                    decimal productPrice2 = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim());      //退货单价
                                    if (details2 != null && productCode2 == details2.PlatformMerchantCode && productPrice2 == details2.ProductPrice)
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
                                base.XMSaleReturnProductDetailsService.UpdateXMSaleReturnProductDetails(info);
                            }
                        }

                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(saleReturnInfo.Id);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InsertSaleReturnBarCodes(int saleReturnDetailID, int PID, int returnCount)
        {
            if (Session["SaleReturn"] != null)
            {
                List<BarCodeInfo> BarCodeList = Session["SaleReturn"] as List<BarCodeInfo>;
                if (BarCodeList != null && BarCodeList.Count > 0)
                {
                    foreach (BarCodeInfo str in BarCodeList)
                    {
                        if (str.PID == PID)
                        {
                            if (str.BarCodeStr != "" && str.BarCodeStr.Length > 0)
                            {
                                string[] p = str.BarCodeStr.Split(';');
                                if (p.Count() != returnCount)
                                {
                                    base.ShowMessage("退货商品条形码数量不一致，请重新录入！");
                                    return;
                                }
                                if (p.Count() > 0)
                                {
                                    foreach (string parm in p)
                                    {
                                        //判断当前产品条形码是否存在 如不存在新增
                                        var info = base.XMSaleReturnBarCodeDetailService.GetXMSaleReturnBarCodeDetailByParm(saleReturnDetailID, parm);
                                        if (info == null)                  //新增
                                        {
                                            XMSaleReturnBarCodeDetail rDetail = new XMSaleReturnBarCodeDetail();
                                            rDetail.SpdId = saleReturnDetailID;
                                            var saleReturnDetails = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsById(saleReturnDetailID);
                                            if (saleReturnDetails != null)
                                            {
                                                rDetail.ProductId = saleReturnDetails.ProductId;
                                            }
                                            rDetail.BarCode = parm;
                                            rDetail.CreateDate = rDetail.UpdateDate = DateTime.Now;
                                            rDetail.CreateID = rDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            rDetail.IsEnable = false;
                                            base.XMSaleReturnBarCodeDetailService.InsertXMSaleReturnBarCodeDetail(rDetail);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 提交入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaleReturnStorge_Click(object sender, EventArgs e)
        {
            //提交入库 
            using (TransactionScope scope = new TransactionScope())
            {
                var saleReturn = base.XMSaleReturnService.GetXMSaleReturnById(SaleReturnID);
                if (saleReturn != null && saleReturn.BillStatus == 0)
                {
                    //更新状态
                    saleReturn.BillStatus = 1000;     //状态更新为已入库
                    saleReturn.UpdateDate = DateTime.Now;
                    saleReturn.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMSaleReturnService.UpdateXMSaleReturn(saleReturn);
                    //更新产品库存表
                    var details = base.XMSaleReturnProductDetailsService.GetXMSaleReturnProductDetailsListBySaleReturnID(saleReturn.Id);
                    if (details != null && details.Count > 0)
                    {
                        foreach (XMSaleReturnProductDetails Info in details)
                        {
                            string platformCode = "";
                            var saleDelivery = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(Info.DeliveryProductsDetailID.Value);
                            if (saleDelivery != null)
                            {
                                platformCode = saleDelivery.PlatformMerchantCode;
                            }
                            int wfID = saleReturn.WarehouseId.Value;
                            var inventeryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(platformCode, wfID);
                            if (inventeryInfo != null)                //更新库存
                            {
                                inventeryInfo.StockNumber += Info.RejectionProdcutsCount;
                                inventeryInfo.CanOrderCount = inventeryInfo.StockNumber;
                                inventeryInfo.UpdateDate = DateTime.Now;
                                inventeryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMInventoryInfoService.UpdateXMInventoryInfo(inventeryInfo);
                                //更新入库产品条形码
                                UpdateProductBarCodeList(inventeryInfo.Id, Info.Id);
                            }
                            else
                            {
                                //产品不存在  新增
                                XMInventoryInfo parm = new XMInventoryInfo();
                                parm.PrductId = Info.ProductId.Value;
                                parm.PlatformMerchantCode = platformCode;
                                parm.WfId = saleReturn.WarehouseId.Value;
                                parm.StockNumber = Info.RejectionProdcutsCount;
                                parm.CanOrderCount = parm.StockNumber;
                                parm.WarningValue = 0;                            //警戒值  可自行设定
                                parm.CreateDate = parm.UpdateDate = DateTime.Now;
                                parm.CreateID = parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                parm.IsEnable = false;
                                base.XMInventoryInfoService.InsertXMInventoryInfo(parm);
                                //更新入库产品条形码
                                UpdateProductBarCodeList(parm.Id, Info.Id);
                            }
                            //更新库存总账主表数据   从表添加一条记录
                            UpdateInventoryLederInfo(wfID, Info, saleDelivery.PlatformMerchantCode);
                        }
                    }
                }
                scope.Complete();
            }
            BindGrid(this.SaleReturnID);
            base.ShowMessage("提交入库成功！");
        }
        /// <summary>
        /// 提交入库   向库存添加该产品的条形码
        /// </summary>
        /// <param name="inventoryID"></param>
        /// <param name="storageDetailID"></param>
        private void UpdateProductBarCodeList(int inventoryID, int saleReturnProductDetailID)
        {
            //根据产品详情ID 获取入库产品的条形码列表
            var barCodes = base.XMSaleReturnBarCodeDetailService.GetXMSaleReturnBarCodeDetailListBySrdID(saleReturnProductDetailID);
            if (barCodes != null && barCodes.Count > 0)
            {
                //遍历所有条形码
                foreach (XMSaleReturnBarCodeDetail Info in barCodes)
                {
                    //查询该仓库产品条形码是否已经存在
                    var inventoryBarCodes = base.XMInventoryBarcodeDetailService.GetXMInventoryBarcodeDetailListByInventoryIDAndBarCode(inventoryID, Info.BarCode);
                    if (inventoryBarCodes == null)              //该产品条形码不存在  新增
                    {
                        XMInventoryBarcodeDetail inventoryBarCode = new XMInventoryBarcodeDetail();
                        inventoryBarCode.SpdId = inventoryID;
                        inventoryBarCode.PrductId = Info.ProductId;
                        inventoryBarCode.PlatformMerchantCode = Info.PlatformMerchantCode;
                        inventoryBarCode.BarCode = Info.BarCode;
                        inventoryBarCode.CreateDate = inventoryBarCode.UpdateDate = DateTime.Now;
                        inventoryBarCode.UpdateID = inventoryBarCode.CreateID = HozestERPContext.Current.User.CustomerID;
                        inventoryBarCode.IsEnable = false;
                        base.XMInventoryBarcodeDetailService.InsertXMInventoryBarcodeDetail(inventoryBarCode);
                    }
                }
            }
        }

        private void UpdateInventoryLederInfo(int wareHousesId, XMSaleReturnProductDetails info, string platformMerchantCode)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, platformMerchantCode);
            if (inventoryLeder != null)     //更新数据
            {
                //更新入库数量（加上）
                inventoryLeder.InCount = (inventoryLeder.InCount == null ? 0 : inventoryLeder.InCount) + info.RejectionProdcutsCount;
                inventoryLeder.InMoney = info.RejectionProductsPrice * inventoryLeder.InCount;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.WarehouseId = wareHousesId;
                inventoryLederInfo.ProductId = info.ProductId;
                inventoryLederInfo.PlatformMerchantCode = platformMerchantCode;
                inventoryLederInfo.AfloatCount = 0;
                inventoryLederInfo.AfloatPrice = info.ProductPrice;
                inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                inventoryLederInfo.InCount = info.ProductCount;
                inventoryLederInfo.InPrice = info.ProductPrice;
                inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                inventoryLederInfo.OutCount = 0;
                inventoryLederInfo.OutPrice = info.ProductPrice;
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(入库)
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, platformMerchantCode);
            decimal price = 0;
            decimal money = 0;
            XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
            details.WarehouseId = wareHousesId;
            details.ProductId = info.ProductId;
            details.PlatformMerchantCode = platformMerchantCode;
            details.InCount = info.RejectionProdcutsCount;                  //入库数量
            details.InPrice = info.RejectionProductsPrice;                      //入库单价
            details.InMoney = info.RejectionsaleMoney;                      //金额
            details.OutCount = 0;
            details.OutPrice = price;
            details.OutMoney = money;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                details.BalanceCount = BalanceCount + details.InCount;
            }
            else
            {
                details.BalanceCount = details.InCount;
            }
            details.BalancePrice = info.RejectionProductsPrice;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            var saleReturns = base.XMSaleReturnService.GetXMSaleReturnById(info.SaleReturnId);
            if (saleReturns != null)
            {
                details.RefNumber = saleReturns.Ref;
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1004;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
        }

        public int SaleReturnID
        {
            get { return CommonHelper.QueryStringInt("SaleReturnID"); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SaleDeliveryID
        {
            get
            {
                return CommonHelper.QueryStringInt("SaleDeliveryID");
            }
        }
        public int SaleInfoID
        {
            get
            {
                return CommonHelper.QueryStringInt("SaleInfoID");
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