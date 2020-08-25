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
    public partial class SaleDeliveryAdd : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Delivery"] = null;
                loadBind();
                BindInfo();
            }
        }

        private void BindInfo()
        {
            if (this.type == 0)    //新生成出库单
            {
                lblRef.Visible = false;
                btnSingleDelivery.Visible = false;
                btnSingleDeliveryIsAudit.Visible = false;
                btnSingleDeliveryIsAuditFalse.Visible = false;
                BindGrid();
            }
            else if (type == 1)     //编辑出库单
            {
                lblTitle.Text = "编辑销售出库单";
                lblMessage.Visible = false;
                btnSingleDelivery.Visible = true;
                BindGrid(this.SaleDeliveryID);
            }
            else if (type == 2)      //已提交出库的出库单无法编辑只能查看
            {
                lblTitle.Text = "查看销售出库单";
                lblMessage.Visible = false;
                btnSingleDelivery.Visible = false;
                BindGrid(this.SaleDeliveryID);
                btnSave.Visible = false;
            }
            txtStorageDate.Value = DateTime.Now.ToString();
        }

        private void BindGrid()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>出库数量</th><th>单位</th><th>销售单价</th><th>销售金额</th><th>操作</th></tr>");
            //获取销售单产品明细
            var saleInfoPrdouctDetails = base.XMSaleInfoProductDetailsService.GetSaleInfoProductDetailsBySaleId(this.SaleInfoID);
            if (saleInfoPrdouctDetails != null && saleInfoPrdouctDetails.Count > 0)
            {
                foreach (XMSaleInfoProductDetails info in saleInfoPrdouctDetails)
                {
                    int kDeliveryCount = GetKDeliveryCount(info.SaleInfoId, info.PlatformMerchantCode, info.ProductPrice.Value, info.SaleCount.Value);
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td id=\"PlatformMerchantCode\">" + info.PlatformMerchantCode + "</td><td id=\"ProductName\">" + info.ProductName + "</td><td>" + info.Specifications + "</td><td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + kDeliveryCount.ToString() + "' /></td><td>" + info.ProductUnit + "</td><td id=\"Price\">" + info.ProductPrice.ToString() + "</td><td id=\"ProductMoney\">" + info.ProductMoney.ToString() + "</td>");
                    str.Append("<td id=\"PID\"><input id=\"hiddPID\"  type=\"hidden\"  value='" + info.Id + "'  /><input type=\"image\" name=\"setBarCode\" id=\"setBarCodes\"  title=\"设置条形码\" src=\"../App_Themes/Blue/Image/ButtonImages/meeting.gif\"  onclick=\"return ShowWindowDetail('设置商品条形码','" + CommonHelper.GetStoreLocation() + "ManageInventory/SetProductsBarCode.aspx?Status=Delivery&&ID=" + info.Id + "',300,600, this);\"/></td>");
                    str.Append("</tr>");
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
            //自动绑定支付方式
            var saleInfo = base.XMSaleInfoService.GetXMSaleInfoById(this.SaleInfoID);
            if (saleInfo != null)
            {
                lbSaleRef.Text = saleInfo.Ref;
            }
            if (saleInfo != null && saleInfo.ReceivingType != null)
            {
                ddlPayment.SelectedValue = saleInfo.ReceivingType.ToString();
            }
            this.ddXMProject_SelectedIndexChanged(null, null);//仓库
        }

        private int GetKDeliveryCount(int infoID, string PlatformMerchantCode, decimal salePrice, int saleCount)
        {
            int Count = 0;     //剩余可出库数量（）
            int delvieryCount = 0;   //出库数量和待出库数量
            var deliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryListBySaleInfoID(infoID);
            if (deliveryInfo != null && deliveryInfo.Count > 0)
            {
                foreach (XMSaleDelivery saleDelviery in deliveryInfo)
                {
                    var saleDeliveryProductDetai = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(saleDelviery.Id);
                    if (saleDeliveryProductDetai != null && saleDeliveryProductDetai.Count > 0)
                    {
                        foreach (XMSaleDeliveryProductDetails info in saleDeliveryProductDetai)
                        {
                            if (info.PlatformMerchantCode == PlatformMerchantCode && info.ProductPrice == salePrice)
                            {
                                delvieryCount = delvieryCount + info.SaleCount.Value;
                            }
                        }
                    }
                }
            }
            Count = saleCount - delvieryCount;
            return Count;
        }

        private void BindGrid(int SaleDeliveryID)
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
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>出库数量</th><th>单位</th><th>销售单价</th><th>销售金额</th><th>操作</th></tr>");
            //绑定销售出库单主表和产品明细表
            var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(SaleDeliveryID);
            if (saleDelivery != null)
            {
                var saleInfo = base.XMSaleInfoService.GetXMSaleInfoById(saleDelivery.SaleInfoId);
                if (saleInfo != null)
                {
                    lbSaleRef.Text = saleInfo.Ref;
                }
                else
                {
                    if (saleDelivery.OrderInfoID > 0)
                    {
                        lbSaleRef.Text = saleDelivery.SaleRef;                     //线上订单订单号
                    }
                }
                bool isAudit = saleDelivery.IsAudit == null ? false : saleDelivery.IsAudit.Value;
                if (isAudit)
                {
                    btnSave.Visible = false;
                }
                lblRef.Text = saleDelivery.Ref;
                var saleDeliveryDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(saleDelivery.Id);
                if (!string.IsNullOrEmpty(saleDelivery.ProjectId.ToString()))
                {
                    if (saleDelivery.ProjectId == -1)
                    {
                        ddXMProject.SelectedIndex = 0;
                    }
                    else
                    {
                        ddXMProject.Value = saleDelivery.ProjectId.ToString();
                    }
                }
                ddlPayment.SelectedValue = saleDelivery.ReceivingType.ToString();
                this.BindddXMProject();//项目
                if (saleDelivery.ProjectId == -1)
                {
                    ddXMProject.SelectedIndex = 0;
                }
                else
                {
                    ddXMProject.Value = saleDelivery.ProjectId.ToString();
                }
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlwareHouses.Value = saleDelivery.WareHouseId.ToString();
                txtStorageDate.Value = saleDelivery.BizDt.ToString() == "" ? DateTime.Now.ToShortDateString() : saleDelivery.BizDt.ToString();
                txtNote.Text = saleDelivery.Remarks;
                if (saleDeliveryDetails != null && saleDeliveryDetails.Count > 0)
                {
                    foreach (XMSaleDeliveryProductDetails info in saleDeliveryDetails)
                    {
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td id=\"PlatformMerchantCode\">" + info.PlatformMerchantCode + "</td><td id=\"ProductName\">" + info.ProductName + "</td><td>" + info.Specifications + "</td><td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.SaleCount.ToString() + "' /></td><td>" + info.ProductUnit + "</td><td id=\"Price\">" + info.ProductPrice.ToString() + "</td><td id=\"ProductMoney\">" + info.ProductMoney.ToString() + "</td>");
                        str.Append("<td id=\"PID\"><input id=\"hiddPID\"  type=\"hidden\"  value='" + info.Id + "'  /><input type=\"image\" name=\"setBarCode\" id=\"setBarCodes\"  title=\"查看条形码\" src=\"../App_Themes/Blue/Image/ButtonImages/meeting.gif\"  onclick=\"return ShowWindowDetail('查看商品条形码','" + CommonHelper.GetStoreLocation() + "ManageInventory/ProductBarCodeList.aspx?Status=Delivery&&ID=" + info.Id + "',400,600, this);\"/></td>");
                        str.Append("</tr>");
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
            var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(SaleDeliveryID);
            this.BindddXMProject();//项目
            
                        //新增
            if (this.type != 0)
            {
                ddXMProject.Value = saleDelivery.ProjectId.ToString();
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlwareHouses.Value = saleDelivery.WareHouseId.ToString();
            }
            decimal value = 0;
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'   style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>出库数量</th><th>单位</th><th>销售单价</th><th>销售金额</th></tr>");
            if (jsonContent != "")
            {
                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(jsonContent);
                for (int i = 0; i < ja_goods.Count; i++)
                {
                    int productCount = 0;
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
                    bool t = IsNumeric(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());
                    if (t)
                    {
                        productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //销售数量
                    }
                    decimal productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim());      //销售单价
                    decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //销售金额
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td id=\"PlatformMerchantCode\">" + productCode + "</td><td id=\"ProductName\">" + productName + "</td><td>" + sp + "</td><td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCount.ToString() + "' /></td><td>" + unit + "</td><td id=\"Price\">" + productPrice.ToString() + "</td><td id=\"ProductMoney\">" + productMoney.ToString() + "</td></tr>");

                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
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
                    ddXMProject.Items.Add(liProject1);
                    ddXMProject.Value = 99;
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
            }
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        private string AutoSaleDeliveryNumber()
        {
            string SaleDeliveryCode = "";       //自动生成销售出货单号
            int number = 1;
            var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryList();
            if (saleDelivery != null && saleDelivery.Count > 0)
            {
                number = saleDelivery[0].Id + 1;
            }
            SaleDeliveryCode = "SD" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return SaleDeliveryCode;
        }

        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^[0-9]*[1-9][0-9]*$");
            return reg1.IsMatch(str);
        }
        /// <summary>
        /// 
        /// </summary>
        private int GetSaleCount(string productCode, decimal price)
        {
            int count = 0;
            if (this.type == 0)
            {
                int saleCount = 0;   //销售数量
                int deliveryCount = 0;
                var saleInfo = base.XMSaleInfoProductDetailsService.GetSaleInfoProductDetailsBySaleId(this.SaleInfoID);
                if (saleInfo != null)
                {
                    foreach (XMSaleInfoProductDetails details in saleInfo)
                    {
                        if (details.PlatformMerchantCode == productCode && details.ProductPrice == price)
                        {
                            saleCount = saleCount + details.SaleCount.Value;
                        }
                    }
                }
                var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryListBySaleInfoID(this.SaleInfoID);
                if (saleDelivery != null && saleDelivery.Count > 0)
                {
                    foreach (XMSaleDelivery delivery in saleDelivery)
                    {
                        var details = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(delivery.Id);
                        if (details != null && details.Count > 0)
                        {
                            foreach (XMSaleDeliveryProductDetails d in details)
                            {
                                if (d.PlatformMerchantCode == productCode && d.ProductPrice == price)
                                {
                                    deliveryCount = deliveryCount + d.SaleCount.Value;
                                }
                            }
                        }
                    }
                }
                count = saleCount - deliveryCount;
            }
            else if (this.type == 1)
            {
                int saleCount = 0;
                int delvieryCount = 0;
                var saleDelviery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(this.SaleDeliveryID);
                if (saleDelviery != null)
                {
                    var details = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(saleDelviery.Id);
                    if (details != null && details.Count > 0)
                    {
                        foreach (XMSaleDeliveryProductDetails saleDetails in details)
                        {
                            if (saleDetails.PlatformMerchantCode == productCode && saleDetails.ProductPrice == price)
                            {
                                delvieryCount = delvieryCount + saleDetails.SaleCount.Value;
                            }
                        }
                    }

                    var saleINfo = base.XMSaleInfoProductDetailsService.GetSaleInfoProductDetailsBySaleId(saleDelviery.SaleInfoId);
                    if (saleINfo != null && saleINfo.Count > 0)
                    {
                        foreach (XMSaleInfoProductDetails q in saleINfo)
                        {
                            if (q.PlatformMerchantCode == productCode && q.ProductPrice == price)
                            {
                                saleCount = saleCount + q.SaleCount.Value;
                            }
                        }
                    }
                }
                count = saleCount - delvieryCount;
            }
            return count;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal value = 0;
            if (this.type == 0)            //新增
            {
                string errMessage = "";
                bool isInventLess = false;    //库存是否充足
                bool isFalse = false;
                string hiddjsonContent = hdfJsonContent.Value;
                string rf = AutoSaleDeliveryNumber();        //自动生成出库单号
                if (ddlwareHouses.Value == "" || ddlwareHouses.Value == null)
                {
                    base.ShowMessage("请添加仓库或未选择仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                List<SaleDeliveryProduct> List = new List<SaleDeliveryProduct>();
                int wareHouseId = int.Parse(ddlwareHouses.Value.ToString());
                int BizUserId = HozestERPContext.Current.User.CustomerID;    // 出库人
                DateTime BizDt = txtStorageDate.Value == "" ? DateTime.Parse(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(txtStorageDate.Value);   //出库时间
                decimal totalMoney = 0;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        bool t = IsNumeric(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());
                        if (!t)
                        {
                            base.ShowMessage("商品出库数量格式不正确！");
                            BindGrid(hiddjsonContent);
                            return;
                        }
                        int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //销售数量
                        decimal productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim());      //销售单价

                        //var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(productCode, wareHouseId);
                        //if ((inventInfo != null && inventInfo.StockNumber < getSaleDeliveryTotalCount(productCode, hiddjsonContent)) || inventInfo == null)
                        //{
                        //    isInventLess = true;      //库存不足
                        //    errMessage += "厂家编码为:" + productCode + "的商品库存不足！ ";
                        //}
                        if (productCount == 0 || productCount > GetSaleCount(productCode, productPrice))
                        {
                            isFalse = true;
                        }
                        decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ') == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //采购总价
                        totalMoney += productMoney;

                        SaleDeliveryProduct list = new SaleDeliveryProduct();
                        list.pcode = productCode;
                        list.saleDeliveryCount = productCount;
                        List.Add(list);
                    }
                }
                if (isFalse)
                {
                    base.ShowMessage("商品出库数量不能为0 或出库数量不能大于可出库数量！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                //对出库商品进行分组 统计数量 判断是否库存足够
                if (List != null && List.Count > 0)
                {
                    var List2 = from l in List
                                group l by new { l.pcode } into g
                                select new
                                {
                                    pcode = g.Key.pcode,
                                    saleDeliveryCount = g.Sum(a => a.saleDeliveryCount)
                                };
                    if (List2 != null && List2.Count() > 0)
                    {
                        foreach (var parm in List2)
                        {
                            var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(parm.pcode, wareHouseId);
                            if (inventInfo == null)
                            {
                                isInventLess = true;      //库存不足
                                errMessage += "厂家编码为:" + parm.pcode + "的商品库存不足！ ";
                            }
                            else
                            {
                                if (inventInfo.StockNumber == null)
                                {
                                    isInventLess = true;      //库存不足
                                    errMessage += "厂家编码为:" + parm.pcode + "的商品库存不足！ ";
                                }
                                else
                                {
                                    if (inventInfo.StockNumber == 0 || inventInfo.StockNumber < 0 || (inventInfo.StockNumber > 0 && inventInfo.StockNumber < parm.saleDeliveryCount))
                                    {
                                        isInventLess = true;      //库存不足
                                        errMessage += "厂家编码为:" + parm.pcode + "的商品库存不足！ ";
                                    }
                                }
                            }

                        }
                    }
                }
                if (isInventLess)
                {
                    base.ShowMessage(errMessage);
                    BindGrid(hiddjsonContent);
                    return;
                }


                int paymentType = int.Parse(ddlPayment.SelectedValue);
                int billstatus = 0;     //状态默认为待出库
                string note = txtNote.Text.Trim();

                XMSaleDelivery Info = new XMSaleDelivery();
                Info.Ref = rf;
                Info.SaleInfoId = this.SaleInfoID;
                Info.OrderInfoID = 0;      //暂时未与订单关联，临时赋值
                Info.WareHouseId = wareHouseId;
                Info.BillStatus = billstatus;       //待出库
                Info.SaleMoney = totalMoney;
                Info.ReceivingType = paymentType;
                Info.Remarks = note;
                Info.BizUserId = HozestERPContext.Current.User.CustomerID;
                Info.BizDt = BizDt;
                Info.UpdateDate = Info.CreateDate = DateTime.Now;
                Info.UpdateID = Info.CreateID = HozestERPContext.Current.User.CustomerID;
                Info.IsEnable = false;
                Info.IsAudit = false;
                base.XMSaleDeliveryService.InsertXMSaleDelivery(Info);
                int saleDeliveryID = Info.Id;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string PID = ja_goods[i]["PID"].ToString().Replace('\"', ' ').Trim();       //销售订单产品详情ID
                        string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //销售数量
                        decimal productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim());      //销售单价
                        decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //销售金额
                        var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(productCode, wareHouseId);
                        if (inventInfo != null && inventInfo.StockNumber >= productCount)
                        {
                            XMSaleDeliveryProductDetails details = new XMSaleDeliveryProductDetails();
                            details.SaleDeliveryId = saleDeliveryID;
                            var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                            if (product != null)
                            {
                                details.ProductId = product.Id;
                            }
                            details.PlatformMerchantCode = productCode;
                            details.SaleCount = productCount;
                            details.ProductMoney = productMoney;
                            details.ProductPrice = productPrice;
                            details.Remarks = note;
                            details.UpdateDate = details.CreateDate = DateTime.Now;
                            details.UpdateID = details.CreateID = HozestERPContext.Current.User.CustomerID;
                            details.IsEnable = false;
                            base.XMSaleDeliveryProductDetailsService.InsertXMSaleDeliveryProductDetails(details);

                            //录入出库产品条形码
                            //  InsertSaleDeliveryBarCodes(details.Id, int.Parse(PID), productCount);
                        }
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(Info.Id);
            }
            else                                //编辑
            {
                string errMessage = "";
                bool isFalse = false;
                bool isInventLess = false;    //库存是否充足
                string hiddjsonContent = hdfJsonContent.Value;
                int id = this.SaleDeliveryID;
                decimal totalMoney = 0;        //总价
                List<SaleDeliveryProduct> List = new List<SaleDeliveryProduct>();
                var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(id);
                if (saleDelivery != null)
                {
                    if (ddlwareHouses.Value == "" || ddlwareHouses.Value == null)
                    {
                        base.ShowMessage("请添加仓库或未选择仓库！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    int wareHoursesID = int.Parse(ddlwareHouses.Value.ToString());
                    var deliveryDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(saleDelivery.Id);
                    saleDelivery.WareHouseId = wareHoursesID;
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            bool t = IsNumeric(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());
                            if (!t)
                            {
                                base.ShowMessage("商品采购数量数量格式不正确！");
                                BindGrid(hiddjsonContent);
                                return;
                            }
                            decimal productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim());      //采购单价

                            int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量
                            if (productCount == 0 || productCount > GetSaleCount(productCode, productPrice))
                            {
                                isFalse = true;
                            }
                            decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ') == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //采购总价
                            totalMoney += productMoney;
                            SaleDeliveryProduct list = new SaleDeliveryProduct();
                            list.pcode = productCode;
                            list.saleDeliveryCount = productCount;
                            List.Add(list);
                        }
                    }
                    if (isFalse)
                    {
                        base.ShowMessage("商品出库数量不能为0 或 出库数量不能大于销售数量！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    //对出库商品进行分组 统计数量 判断是否库存足够
                    if (List != null && List.Count > 0)
                    {
                        var List2 = from l in List
                                    group l by new { l.pcode } into g
                                    select new
                                    {
                                        pcode = g.Key.pcode,
                                        saleDeliveryCount = g.Sum(a => a.saleDeliveryCount)
                                    };
                        if (List2 != null && List2.Count() > 0)
                        {
                            foreach (var parm in List2)
                            {
                                var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(parm.pcode, wareHoursesID);
                                if (inventInfo == null)
                                {
                                    isInventLess = true;      //库存不足
                                    errMessage += "厂家编码为:" + parm.pcode + "的商品库存不足！ ";
                                }
                                else if (inventInfo.StockNumber == 0)        //库存为0
                                {
                                    isInventLess = true;      //库存不足
                                    errMessage += "厂家编码为:" + parm.pcode + "的商品库存不足！ ";
                                }
                                else if (inventInfo.StockNumber > 0 && inventInfo.StockNumber < parm.saleDeliveryCount)
                                {
                                    isInventLess = true;      //库存不足
                                    errMessage += "厂家编码为:" + parm.pcode + "的商品库存不足！ ";
                                }
                            }
                        }
                    }
                    if (isInventLess)
                    {
                        base.ShowMessage(errMessage);
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    saleDelivery.SaleMoney = totalMoney;
                    saleDelivery.ReceivingType = int.Parse(ddlPayment.SelectedValue);
                    saleDelivery.Remarks = txtNote.Text.Trim();
                    saleDelivery.BizDt = txtStorageDate.Value == "" ? DateTime.Parse(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(txtStorageDate.Value);   //出库时间
                    saleDelivery.UpdateID = HozestERPContext.Current.User.CustomerID;
                    saleDelivery.UpdateDate = DateTime.Now;
                    base.XMSaleDeliveryService.UpdateXMSaleDelivery(saleDelivery);
                    if (deliveryDetails != null && deliveryDetails.Count() > 0)
                    {
                        if (hiddjsonContent != "")
                        {
                            JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                            for (int i = 0; i < ja_goods.Count; i++)
                            {
                                string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                                int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量
                                decimal productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim());      //采购单价
                                decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //采购单价
                                var inventeryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(productCode, wareHoursesID);
                                if (inventeryInfo != null && inventeryInfo.StockNumber > productCount)         //库存数量大于出售数量
                                {
                                    foreach (XMSaleDeliveryProductDetails info in deliveryDetails)
                                    {
                                        if (productCode == info.PlatformMerchantCode && productPrice == info.ProductPrice)
                                        {
                                            info.SaleCount = productCount;
                                            info.ProductPrice = productPrice;
                                            info.ProductMoney = productMoney;
                                            info.UpdateDate = DateTime.Now;
                                            info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            base.XMSaleDeliveryProductDetailsService.UpdateXMSaleDeliveryProductDetails(info);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(saleDelivery.Id);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleDeliveyID"></param>
        /// <param name="pid"></param>
        /// <param name="deliveryCount"></param>
        private void InsertSaleDeliveryBarCodes(int saleDeliveyProductDetailID, int pid, int deliveryCount)
        {
            if (Session["Delivery"] != null)
            {
                List<BarCodeInfo> BarCodeList = Session["Delivery"] as List<BarCodeInfo>;
                if (BarCodeList != null && BarCodeList.Count > 0)
                {
                    foreach (BarCodeInfo str in BarCodeList)
                    {
                        if (str.PID == pid)
                        {
                            if (str.BarCodeStr != "" && str.BarCodeStr.Length > 0)
                            {
                                string[] p = str.BarCodeStr.Split(';');
                                if (p.Count() > deliveryCount)
                                {
                                    base.ShowMessage("出库商品条形码数量不能大于出库数量，请重新录入！");
                                    return;
                                }
                                if (p.Count() > 0)
                                {
                                    foreach (string parm in p)
                                    {
                                        //判断当前产品条形码是否存在 如不存在新增
                                        var info = base.XMSaleDeliveryBarCodeDetailService.GetXMSaleDeliveryBarCodeDetailByParm(saleDeliveyProductDetailID, parm);
                                        if (info == null)                  //新增
                                        {
                                            XMSaleDeliveryBarCodeDetail dDetail = new XMSaleDeliveryBarCodeDetail();
                                            dDetail.SpdId = saleDeliveyProductDetailID;
                                            var saleDeliveryProductDetail = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsById(saleDeliveyProductDetailID);
                                            if (saleDeliveryProductDetail != null)
                                            {
                                                dDetail.ProductId = saleDeliveryProductDetail.ProductId;
                                                dDetail.PlatformMerchantCode = saleDeliveryProductDetail.PlatformMerchantCode;
                                            }
                                            dDetail.BarCode = parm;
                                            dDetail.CreateDate = dDetail.UpdateDate = DateTime.Now;
                                            dDetail.CreateID = dDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            dDetail.IsEnable = false;
                                            base.XMSaleDeliveryBarCodeDetailService.InsertXMSaleDeliveryBarCodeDetail(dDetail);
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
        /// 出库审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSingleDeliveryIsAudit_Click(object sender, EventArgs e)
        {
            var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(this.SaleDeliveryID);
            if (saleDelivery != null)
            {
                saleDelivery.IsAudit = true;
                saleDelivery.UpdateDate = DateTime.Now;
                saleDelivery.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMSaleDeliveryService.UpdateXMSaleDelivery(saleDelivery);
            }
            BindGrid(this.SaleDeliveryID);
            base.ShowMessage("操作成功！");
        }

        /// <summary>
        /// 出库反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSingleDeliveryIsAuditFalse_Click(object sender, EventArgs e)
        {
            var saleDelivery = base.XMSaleDeliveryService.GetXMSaleDeliveryById(this.SaleDeliveryID);
            if (saleDelivery != null && saleDelivery.BillStatus == 1000)                    //状态为已经出库出库单无法反审核
            {
                base.ShowMessage("已经出库出库单无法反审核！");
                BindGrid(this.SaleDeliveryID);
                return;
            }
            if (saleDelivery != null)
            {
                saleDelivery.IsAudit = false;
                saleDelivery.UpdateDate = DateTime.Now;
                saleDelivery.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMSaleDeliveryService.UpdateXMSaleDelivery(saleDelivery);
            }
            BindGrid(this.SaleDeliveryID);
            base.ShowMessage("操作成功！");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleDeliveryID"></param>
        private bool GetInventory(int saleDeliveryID, int wareHouseId)
        {
            bool isInventLess = false;
            List<SaleDeliveryProduct> List = new List<SaleDeliveryProduct>();
            var deliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryById(saleDeliveryID);
            if (deliveryInfo != null)
            {
                var deliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(deliveryInfo.Id);
                foreach (XMSaleDeliveryProductDetails parm in deliveryProductDetails)
                {
                    SaleDeliveryProduct list = new SaleDeliveryProduct();
                    list.pcode = parm.PlatformMerchantCode;
                    list.saleDeliveryCount = parm.SaleCount.Value;
                    List.Add(list);
                }
                if (List != null && List.Count > 0)
                {
                    var List2 = from l in List
                                group l by new { l.pcode } into g
                                select new
                                {
                                    pcode = g.Key.pcode,
                                    saleDeliveryCount = g.Sum(a => a.saleDeliveryCount)
                                };
                    if (List2 != null && List2.Count() > 0)
                    {
                        foreach (var parm in List2)
                        {
                            var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(parm.pcode, wareHouseId);
                            if (inventInfo == null)
                            {
                                isInventLess = true;      //库存不足
                            }
                            else
                            {
                                if (inventInfo.StockNumber == null)
                                {
                                    isInventLess = true;      //库存不足
                                }
                                else
                                {
                                    if (inventInfo.StockNumber == 0 || inventInfo.StockNumber < 0 || (inventInfo.StockNumber > 0 && inventInfo.StockNumber < parm.saleDeliveryCount))
                                    {
                                        isInventLess = true;      //库存不足
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return isInventLess;
        }

        /// <summary>
        /// 提交出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSingleDelivery_Click(object sender, EventArgs e)
        {
            //提交出库
            using (TransactionScope scope = new TransactionScope())
            {
                var deliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryById(SaleDeliveryID);
                if (deliveryInfo != null)
                {
                    bool isInventLess = GetInventory(SaleDeliveryID, deliveryInfo.WareHouseId);
                    if (isInventLess)
                    {
                        base.ShowMessage("出库单库存不足，无法提交出库！");
                        BindGrid(deliveryInfo.Id);
                        return;
                    }
                    bool deliveryIsAudit = deliveryInfo.IsAudit == null ? false : deliveryInfo.IsAudit.Value;
                    if (!deliveryIsAudit)
                    {
                        base.ShowMessage("出库单未审核通过，无法提交出库！");
                        BindGrid(deliveryInfo.Id);
                        return;
                    }
                }
                if (deliveryInfo != null && deliveryInfo.BillStatus == 0)
                {
                    deliveryInfo.BillStatus = 1000;   //状态更新为已出库
                    deliveryInfo.UpdateDate = DateTime.Now;
                    deliveryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMSaleDeliveryService.UpdateXMSaleDelivery(deliveryInfo);

                    //更新产品库存表（减掉出库数量）
                    var deliveryProductDetails = base.XMSaleDeliveryProductDetailsService.GetXMSaleDeliveryProductDetailsBySaleDeliveryID(deliveryInfo.Id);
                    if (deliveryProductDetails != null && deliveryProductDetails.Count > 0)
                    {
                        foreach (XMSaleDeliveryProductDetails parm in deliveryProductDetails)
                        {
                            string code = parm.PlatformMerchantCode;              //厂家编码
                            int wfID = deliveryInfo.WareHouseId;                              //出库仓库ID
                            var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, wfID);
                            if (InventoryInfo != null)                             //厂家编码为code的产品在库存表中已经存在 更新库存数量
                            {
                                InventoryInfo.StockNumber = InventoryInfo.StockNumber - parm.SaleCount;             //库存减掉出库量
                                InventoryInfo.CanOrderCount = InventoryInfo.StockNumber;
                                InventoryInfo.UpdateDate = DateTime.Now;
                                InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);

                                //更新出库产品条形码状态 为删除
                                UpdateSaleDeliveryBarCodes(InventoryInfo.Id, parm.Id);

                            }
                            //更新库存总账主表数据   从表添加一条记录
                            UpdateInventoryLederInfo(deliveryInfo.WareHouseId, parm);

                            //更新主表数据

                            //删除库存商品条形码
                            //UpdateInventoryBarCodeInfo(InventoryInfo.Id, parm.Id);
                        }
                    }
                }
                scope.Complete();
            }
            BindGrid(this.SaleDeliveryID);
            base.ShowMessage("提交出库成功！");
        }


        /// <summary>
        /// 删除出库产品条形码
        /// </summary>
        private void UpdateSaleDeliveryBarCodes(int inventoryID, int saleDeliveryProductID)
        {
            //根据产品详情ID 获取入库产品的条形码列表
            var barCodes = base.XMSaleDeliveryBarCodeDetailService.GetXMSaleDeliveryBarCodeDetailListBySpdID(saleDeliveryProductID);
            if (barCodes != null && barCodes.Count > 0)
            {
                //遍历所有条形码
                foreach (XMSaleDeliveryBarCodeDetail Info in barCodes)
                {
                    var inventoryBarCodes = base.XMInventoryBarcodeDetailService.GetXMInventoryBarcodeDetailListByInventoryIDAndBarCode(inventoryID, Info.BarCode);
                    if (inventoryBarCodes != null)    //该产品条形码已经存在  更新状态为删除
                    {
                        inventoryBarCodes.IsEnable = true;    //删除该条形码   出库成功
                        inventoryBarCodes.UpdateDate = DateTime.Now;
                        inventoryBarCodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMInventoryBarcodeDetailService.UpdateXMInventoryBarcodeDetail(inventoryBarCodes);
                    }
                }
            }
        }


        //根据状态平均算出销售单价  (状态出库  入库   在途)
        private decimal CalculateProductPrice(int wareHousesId, XMSaleDeliveryProductDetails info, int satatus)
        {
            int count = 0;
            decimal money = 0;
            //int refType = 1002;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            decimal price = 0;
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, info.PlatformMerchantCode, satatus);
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                foreach (XMInventoryLedgerDetail Info in inventoryLederDetail)
                {
                    count = count + Info.OutCount.Value;
                    money = money + Info.OutPrice.Value * Info.OutCount.Value;
                }
            }
            count = count + info.SaleCount.Value;
            money = money + info.ProductPrice.Value * info.SaleCount.Value;
            price = money / count;
            return price;
        }


        private void UpdateInventoryLederInfo(int wareHousesId, XMSaleDeliveryProductDetails info)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, info.PlatformMerchantCode);
            if (inventoryLeder != null)     //更新数据
            {
                //更新出库数量
                inventoryLeder.OutCount = (inventoryLeder.OutCount == null ? 0 : inventoryLeder.OutCount) + info.SaleCount;
                inventoryLeder.OutPrice = CalculateProductPrice(wareHousesId, info, 1002);
                inventoryLeder.OutMoney = inventoryLeder.OutPrice * inventoryLeder.OutCount;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.WarehouseId = wareHousesId;
                inventoryLederInfo.ProductId = info.ProductId;
                inventoryLederInfo.PlatformMerchantCode = info.PlatformMerchantCode;
                inventoryLederInfo.OutCount = info.SaleCount;
                inventoryLederInfo.OutPrice = info.ProductPrice;
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.InCount = 0;
                inventoryLederInfo.InPrice = info.ProductPrice;
                inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                inventoryLederInfo.AfloatCount = 0;
                inventoryLederInfo.AfloatPrice = info.ProductPrice;
                inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(出库)
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, info.PlatformMerchantCode);
            decimal price = 0;
            decimal money = 0;
            XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
            details.WarehouseId = wareHousesId;
            details.ProductId = info.ProductId;
            details.PlatformMerchantCode = info.PlatformMerchantCode;
            details.OutCount = info.SaleCount;
            details.OutPrice = info.ProductPrice;
            details.OutMoney = info.SaleCount * info.ProductPrice;
            details.InCount = 0;
            details.InPrice = price;
            details.InMoney = money;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                details.BalanceCount = BalanceCount - details.OutCount;
            }
            else
            {
                details.BalanceCount = 0;
            }
            details.BalancePrice = info.ProductPrice;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            var saleDeliveryInfo = base.XMSaleDeliveryService.GetXMSaleDeliveryById(info.SaleDeliveryId);
            if (saleDeliveryInfo != null)
            {
                details.RefNumber = saleDeliveryInfo.Ref;
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1002;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
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

        /// <summary>
        /// 
        /// </summary>
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