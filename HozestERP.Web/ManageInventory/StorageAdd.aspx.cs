using System;
using System.Linq;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using System.Transactions;

namespace HozestERP.Web.ManageInventory
{
    public partial class StorageAdd : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";
        List<storageInfo> list = new List<storageInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Storage"] = null;
                loadBind();
                BindInfo();
            }
        }

        private void BindInfo()
        {
            if (this.type == 0)    //新生成入库单
            {
                btnSingleStorage.Visible = false;
                btnSingleStorageIsAudit.Visible = false;
                btnSingleStorageIsAuditFalse.Visible = false;
                BindGrid();
            }
            else if (type == 1)     //编辑入库单
            {
                lblTitle.Text = "编辑采购入库单";
                chkAutoID.Visible = false;
                lbl1.Visible = false;
                txtStorageNumber.Visible = false;
                btnSingleStorage.Visible = true;
                BindGrid(this.StorageID);
            }
            else if (type == 2)      //已提交入库的入库单无法编辑只能查看
            {
                lblTitle.Text = "查看采购入库单";
                chkAutoID.Visible = false;
                lbl1.Visible = false;
                txtStorageNumber.Visible = false;
                BindGrid(this.StorageID);
                btnSave.Visible = false;
                btnSingleStorage.Visible = false;
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
            if (ddlwareHouses.Value != "" && ddlwareHouses.Value != null)
            {
                int wareHoursesID = int.Parse(ddlwareHouses.Value.ToString());
                var warehouse = base.XMWareHousesService.GetXMWareHousesById(wareHoursesID);
                if (warehouse != null)
                {
                    ddXMProject.Value = warehouse.ProjectId.ToString();
                }
            }
        }

        private void BindGrid()
        {
            //绑定收款方式
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(228, false);
            this.ddlPayment.DataSource = codeList;
            this.ddlPayment.DataTextField = "CodeName";
            this.ddlPayment.DataValueField = "CodeID";
            this.ddlPayment.DataBind();
            BindInfo(this.PurchaseID);
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>最大可入库数量</th><th>入库数量</th><th>单位</th><th>采购单价</th><th>采购金额</th><th>操作</th></tr>");
            //获取采购单产品明细
            var purProductDetails = base.XMPurchaseProductDetailsService.GetXMPurchaseProductDetailsByPurchaseID(this.PurchaseID);
            if (purProductDetails != null && purProductDetails.Count > 0)
            {
                foreach (XMPurchaseProductDetails info in purProductDetails)
                {
                    int storageCount = GetKStorageCount(this.PurchaseID, info.PlatformMerchantCode);
                    decimal money = storageCount * info.ProductPrice;
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td id=\"PlatformMerchantCode\">" + info.PlatformMerchantCode + "</td><td id=\"ProductName\">" + info.ProductName + "</td><td>" + info.Specifications + "</td> <td id=\"counts\"><input runat=\"server\" id=\"txtCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + storageCount.ToString() + "'  readonly=\"readonly\"/></td>     <td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + storageCount.ToString() + "' /></td><td>" + info.ProductUnit + "</td><td id=\"Price\">" + info.ProductPrice.ToString() + "</td><td id=\"ProductMoney\">" + money.ToString() + "</td>");
                    str.Append("<td id=\"PID\"><input id=\"hiddPID\"  type=\"hidden\"  value='" + info.Id + "'  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  />&nbsp;<input type=\"image\" name=\"setBarCode\" id=\"setBarCodes\"  title=\"设置条形码\" src=\"../App_Themes/Blue/Image/ButtonImages/meeting.gif\"  onclick=\"return ShowWindowDetail('设置商品条形码','" + CommonHelper.GetStoreLocation() + "ManageInventory/SetProductsBarCode.aspx?Status=Storage&&ID=" + info.Id + "',300,600, this);\"/></td>");
                    str.Append("</tr>");
                    storageInfo Info = new storageInfo();
                    Info.ProCode = info.PlatformMerchantCode;     //厂家编码
                    Info.StorageCount = storageCount;
                    list.Add(Info);
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
            this.ddXMProject_SelectedIndexChanged(null, null);//店铺
        }

        private void BindGrid(int storageID)
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
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>最大可入库数量</th><th>入库数量</th><th>单位</th><th>采购单价</th><th>采购金额</th><th>操作</th></tr>");
            //绑定入库单主表和明细表
            var storageInfo = base.XMStorageService.GetXMStorageById(storageID);
            if (storageInfo != null)
            {
                bool isAudit = storageInfo.IsAudit == null ? false : storageInfo.IsAudit.Value;
                if (isAudit)         //审核后无法修改
                {
                    btnSave.Visible = false;
                }
                var storageDetails = base.XMStorageProductDetailsService.GetXMStorageProductDetailsByStorageID(storageID);
                if (!string.IsNullOrEmpty(storageInfo.ProjectId.ToString()))
                {
                    if (storageInfo.ProjectId == -1)
                    {
                        ddXMProject.SelectedIndex = 0;
                    }
                    else
                    {
                        ddXMProject.Value = storageInfo.ProjectId.ToString();
                    }
                }
                ddlwareHouses.Value = storageInfo.WareHouseId.ToString();
                ddlSuppliers.SelectedValue = storageInfo.SupplierId.ToString();
                ddlPayment.SelectedValue = storageInfo.PaymentType.ToString();
                txtNote.Text = storageInfo.BillMemo;
                lblNumber.Text = storageInfo.Ref;
                this.BindddXMProject();//项目
                if (storageInfo.ProjectId == -1)
                {
                    ddXMProject.SelectedIndex = 0;
                }
                else
                {
                    ddXMProject.Value = storageInfo.ProjectId.ToString();
                }
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlwareHouses.Value = storageInfo.WareHouseId.ToString();
                txtStorageDate.Value = storageInfo.StorageDate.ToString() == "" ? DateTime.Now.ToShortDateString() : storageInfo.StorageDate.ToString();
                if (storageDetails != null && storageDetails.Count > 0)
                {
                    foreach (XMStorageProductDetails info in storageDetails)
                    {
                        int storageCount = GetKStorageCount(this.PurchaseID, info.PlatformMerchantCode);     //剩余可入库数量(采购数量-入库数量-退货数量)

                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td id=\"PlatformMerchantCode\">" + info.PlatformMerchantCode + "</td><td id=\"ProductName\">" + info.ProductName + "</td><td>" + info.Specifications + "</td> <td id=\"counts\"><input runat=\"server\" id=\"txtCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + storageCount.ToString() + "'  readonly=\"readonly\"/></td>     <td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + info.ProductsCount.ToString() + "' /></td><td>" + info.ProductUnit + "</td><td id=\"Price\">" + info.ProductsPrice.ToString() + "</td><td id=\"ProductMoney\">" + info.ProductsMoney.ToString() + "</td>");
                        str.Append("<td id=\"PID\"><input id=\"hiddPID\"  type=\"hidden\"  value='" + info.Id + "'  /> <img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /> &nbsp;<input type=\"image\" name=\"setBarCode\" id=\"setBarCodes\"  title=\"查看条形码\" src=\"../App_Themes/Blue/Image/ButtonImages/meeting.gif\"  onclick=\"return ShowWindowDetail('查看商品条形码','" + CommonHelper.GetStoreLocation() + "ManageInventory/ProductBarCodeList.aspx?Status=Storage&&ID=" + info.Id + "',400,600, this);\"/></td>");
                        str.Append("</tr>");
                    }
                }
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }
        /// <summary>
        /// 获取采购数量
        /// </summary>
        /// <param name="purchaseId"></param>
        private int GetpurchaseCount(int purchaseId, string platformMerchantCode)
        {
            int purchaseCount = 0;
            var purchaseDetail = base.XMPurchaseProductDetailsService.GetXMPurchaseProductDetailsByPurchaseIDAndPlatformMerchantCode(purchaseId, platformMerchantCode);
            if (purchaseDetail != null && purchaseDetail.Count > 0)
            {
                purchaseCount = purchaseDetail[0].ProductCount;
            }
            return purchaseCount;
        }
        /// <summary>
        /// 获取产品入库数量(状态为待人库和已入库)
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
        /// 
        /// </summary>
        /// <param name="jsonContent"></param>
        private void BindGrid(string jsonContent)
        {
            var Storage = base.XMStorageService.GetXMStorageById(StorageID);
            this.BindddXMProject();//项目

            //新增
            if (this.type != 0)
            {
                ddXMProject.Value = Storage.ProjectId.ToString();
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlwareHouses.Value = Storage.WareHouseId.ToString();
            }
            decimal value = 0;
            StringBuilder str = new StringBuilder();
            string productName = "";
            string specifications = "";
            string unit = "";
            str.Append("<table class='table' id='MyPurchaseProductList'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>最大可入库数量</th><th>入库数量</th><th>单位</th><th>采购单价</th><th>采购金额</th><th>操作</th></tr>");
            if (jsonContent != "")
            {
                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(jsonContent);
                for (int i = 0; i < ja_goods.Count; i++)
                {
                    string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                    string productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim();      //采购数量
                    string pID = ja_goods[i]["PID"].ToString().Replace('\"', ' ').Trim();
                    string productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim();      //采购单价
                    string productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim();      //采购单价
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
                    int storageCount = GetKStorageCount(this.PurchaseID, productCode);     //剩余可入库数量(采购数量-入库数量-退货数量)
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td id=\"PlatformMerchantCode\">" + productCode + "</td><td id=\"ProductName\">" + productName + "</td><td>" + specifications + "</td><td id=\"counts\"><input runat=\"server\" id=\"txtCount\" readonly=\"readonly\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + storageCount.ToString() + "' /></td> <td id=\"count\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCount.ToString() + "' /></td><td>" + unit + "</td><td id=\"Price\">" + productPrice + "</td><td id=\"ProductMoney\">" + productMoney + "</td><td id=\"PID\"> <input id=\"hiddPID\"  type=\"hidden\"  value='" + pID + "'  />  <img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /> &nbsp;<input type=\"image\" name=\"setBarCode\" id=\"setBarCodes\"  title=\"设置条形码\" src=\"../App_Themes/Blue/Image/ButtonImages/meeting.gif\"  onclick=\"return ShowWindowDetail('设置商品条形码','" + CommonHelper.GetStoreLocation() + "ManageInventory/SetProductsBarCode.aspx?Status=Storage&&ID=" + pID + "',300,600, this);\"/> </td></tr>");
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        private void loadBind()
        {
            //绑定供应商列表
            var suppliers = base.XMSuppliersService.GetXMSuppliersListDirect();
            if (suppliers != null && suppliers.Count > 0)
            {
                ddlSuppliers.DataSource = suppliers;
                ddlSuppliers.DataTextField = "SupplierName";
                ddlSuppliers.DataValueField = "Id";
                ddlSuppliers.DataBind();
                this.ddlSuppliers.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddlSuppliers.Items[0].Selected = true;
            }
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

        private void BindWareHoursesList(List<XMProject> List)
        {
            List<XMWareHouses> WareList = new List<XMWareHouses>();
            if (List != null && List.Count > 0)
            {
                foreach (XMProject pro in List)
                {
                    var wareHouesse = base.XMWareHousesService.GetXMWarehouseListByProjectId(pro.Id);
                    if (wareHouesse != null && wareHouesse.Count > 0)
                    {
                        foreach (XMWareHouses ware in wareHouesse)
                        {
                            WareList.Add(ware);
                        }
                    }
                }
            }
            this.ddlwareHouses.Items.Clear();
            Ext.Net.Store Store = ddlwareHouses.GetStore();
            Store.DataSource = WareList;
            Store.DataBind();
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

        private string AutoStorageNumber()
        {
            string storageCode = "";       //自动生成入库单号
            int number = 1;
            var storages = base.XMStorageService.GetXMStorageList();
            if (storages != null && storages.Count > 0)
            {
                number = storages[0].Id + 1;
            }
            storageCode = "PW" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return storageCode;
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
                string hiddjsonContent = hdfJsonContent.Value;
                string rf = "";

                bool isAuto = bool.Parse(hiddAutoID.Value);
                if (isAuto)              //只读  自动生成采购单号
                {
                    rf = AutoStorageNumber();
                }
                else
                {
                    rf = txtStorageNumber.Text.Trim();
                    if (string.IsNullOrEmpty(rf))
                    {
                        base.ShowMessage("入库单号必须填写！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                }
                int purchaseId = this.PurchaseID;
                if (ddlwareHouses.Value == "" || ddlwareHouses.Value == null)
                {
                    base.ShowMessage("请添加仓库或未选择仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                int wareHouseId = int.Parse(ddlwareHouses.Value.ToString());
                int supplierId = ddlSuppliers.SelectedValue == "" ? -1 : int.Parse(ddlSuppliers.SelectedValue);
                int BizUserId = HozestERPContext.Current.User.CustomerID;    // 入库人
                DateTime BizDt = txtStorageDate.Value == "" ? DateTime.Parse(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(txtStorageDate.Value);   //入库时间
                decimal totalMoney = 0;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    if (ja_goods.Count == 0)
                    {
                        isEmpty = true;
                    }
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        int storageCount = ja_goods[i]["StorageCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["StorageCount"].ToString().Replace('\"', ' ').Trim());      //可如库数量

                        string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        bool t = IsNumeric(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());
                        if (!t)
                        {
                            base.ShowMessage("商品采购数量数量格式不正确！");
                            BindGrid(hiddjsonContent);
                            return;
                        }
                        int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量

                        if (productCode == "")           //厂家编码存在为空的
                        {
                            isEmpty = true;
                        }

                        if (productCount == 0 || productCount > storageCount)
                        {
                            isFlase = true;           //
                        }
                        decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ') == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //采购总价
                        totalMoney += productMoney;
                    }
                }
                if (isEmpty)
                {
                    base.ShowMessage("厂家编码不能为空，请输入厂家编码 或商品信息不存在！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                //判断输入入库数量是否满足要求 （要求 输入数量必须小于等于可入库数量（可入库数量= 采购数量- 入库数量- 退货数量））
                if (isFlase)
                {
                    base.ShowMessage("入库数量不能为 0 或入库数量不能大于可入库数量！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                int paymentType = int.Parse(ddlPayment.SelectedValue);
                string note = txtNote.Text.Trim();

                XMStorage storage = new XMStorage();
                storage.Ref = rf;
                storage.PurchaseId = purchaseId;
                storage.WareHouseId = wareHouseId;
                storage.SupplierId = supplierId;
                storage.BizUserId = BizUserId;
                storage.BizDt = BizDt;
                storage.CreateID = HozestERPContext.Current.User.CustomerID;
                storage.CreateDate = DateTime.Now;
                storage.BillStatus = 0;      //默认 待入库
                storage.ProductsMoney = totalMoney;
                storage.PaymentType = paymentType;
                storage.BillMemo = note;
                storage.IsEnable = false;
                storage.IsAudit = false;
                base.XMStorageService.InsertXMStorage(storage);
                int storageID = storage.Id;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string PID = ja_goods[i]["PID"].ToString().Replace('\"', ' ').Trim();       //采购商品详情ID
                        string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量
                        decimal productPrice = ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["price"].ToString().Replace('\"', ' ').Trim());      //采购单价
                        decimal productMoney = ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["money"].ToString().Replace('\"', ' ').Trim());      //采购单价

                        XMStorageProductDetails storageDetails = new XMStorageProductDetails();
                        storageDetails.StorageId = storageID;
                        var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                        if (product != null)
                        {
                            storageDetails.ProductId = product.Id;
                        }
                        storageDetails.PlatformMerchantCode = productCode;
                        storageDetails.ProductsCount = productCount;
                        storageDetails.ProductsMoney = productMoney;
                        storageDetails.ProductsPrice = productPrice;
                        storageDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                        storageDetails.CreateDate = DateTime.Now;
                        storageDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                        storageDetails.UpdateDate = DateTime.Now;
                        storageDetails.IsEnable = false;
                        base.XMStorageProductDetailsService.InsertXMStorageProductDetails(storageDetails);
                        //在库存总账中添加一条记录
                        InsertInventoryLeder(wareHouseId, productCode, productCount, productPrice, productMoney);

                        //新增入库商品条形码
                        // InsertStorageProductBarCodes(storageDetails.Id, int.Parse(PID), productCount);
                    }
                }

                base.ShowMessage("操作成功!");
                BindGrid(storage.Id);
            }
            else                            //编辑
            {
                int id = this.StorageID;
                decimal totalMoney = 0;        //总价
                bool isEmpty = false;      //判断厂家编码是否填写（厂家编码必填）
                bool isFlase = false;        //判断入库数量值是否正确
                string hiddjsonContent = hdfJsonContent.Value;
                var storage = base.XMStorageService.GetXMStorageById(id);
                if (storage != null)
                {
                    var storageDetails = base.XMStorageProductDetailsService.GetXMStorageProductDetailsByStorageID(storage.Id);
                    if (ddlwareHouses.Value == "" || ddlwareHouses.Value == null)
                    {
                        base.ShowMessage("请添加仓库或未选择仓库！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    int wareHouseId = int.Parse(ddlwareHouses.Value.ToString());
                    storage.WareHouseId = wareHouseId;
                    storage.SupplierId = ddlSuppliers.SelectedValue == "" ? -1 : int.Parse(ddlSuppliers.SelectedValue);
                    storage.BizUserId = HozestERPContext.Current.User.CustomerID;
                    storage.BizDt = txtStorageDate.Value == "" ? DateTime.Parse(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(txtStorageDate.Value);   //业务时间
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        if (ja_goods.Count == 0)
                        {
                            isEmpty = true;
                        }
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            string productCode = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            if (productCode == "")           //厂家编码存在为空的
                            {
                                isEmpty = true;
                            }
                            int storageCount = ja_goods[i]["StorageCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["StorageCount"].ToString().Replace('\"', ' ').Trim());      //可如库数量
                            bool t = IsNumeric(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());
                            if (!t)
                            {
                                base.ShowMessage("商品采购数量数量格式不正确！");
                                BindGrid(hiddjsonContent);
                                return;
                            }
                            int productCount = ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["ProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量
                            if (productCount == 0 || productCount > (storageCount + productCount))
                            {
                                isFlase = true;           //
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
                        base.ShowMessage("入库数量不能为 0 或入库数量不能大于可入库数量！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    storage.ProductsMoney = totalMoney;
                    storage.PaymentType = int.Parse(ddlPayment.SelectedValue);
                    storage.BillMemo = txtNote.Text.Trim();
                    base.XMStorageService.UpdateXMStorage(storage);
                    if (storageDetails != null && storageDetails.Count() > 0)
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
                                foreach (XMStorageProductDetails info in storageDetails)
                                {
                                    if (productCode == info.PlatformMerchantCode)
                                    {
                                        info.ProductsCount = productCount;
                                        info.ProductsPrice = productPrice;
                                        info.ProductsMoney = productMoney;
                                        info.UpdateDate = DateTime.Now;
                                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMStorageProductDetailsService.UpdateXMStorageProductDetails(info);
                                    }
                                }
                            }
                        }


                        //过滤掉已经删除的
                        foreach (XMStorageProductDetails info in storageDetails)
                        {
                            bool isDelete = true;
                            if (hiddjsonContent != "")
                            {
                                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                                for (int i = 0; i < ja_goods.Count; i++)
                                {
                                    string productCode2 = ja_goods[i]["PlatformMerchantCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                                    if (productCode2 == info.PlatformMerchantCode)
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
                                base.XMStorageProductDetailsService.UpdateXMStorageProductDetails(info);
                            }
                        }
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(storage.Id);
            }
        }

        /// <summary>
        /// 生成入库单后 更新在途产品数量
        /// </summary>
        /// <param name="wareHousesID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <param name="count"></param>
        /// <param name="productPrice"></param>
        /// <param name="productMoney"></param>
        private void InsertInventoryLeder(int wareHousesID, string PlatformMerchantCode, int count, decimal productPrice, decimal productMoney)
        {
            int productId = 1;
            string productName = "";
            string specifications = "";
            string unit = "";
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesID, PlatformMerchantCode);
            if (inventoryLeder == null)              //新增一条   在途 还未入库
            {
                var product = base.XMProductService.getXMProductByManufacturersCode(PlatformMerchantCode);
                if (product != null)
                {
                    productId = product.Id;
                    productName = product.ProductName;
                    specifications = product.Specifications;
                    unit = product.ProductUnit;
                }
                XMInventoryLedger leder = new XMInventoryLedger();
                leder.WarehouseId = wareHousesID;
                leder.ProductId = productId;
                leder.PlatformMerchantCode = PlatformMerchantCode;
                leder.AfloatCount = count;
                leder.AfloatPrice = productPrice;
                leder.AfloatMoney = productMoney;
                leder.CreateDate = leder.UpdateDate = DateTime.Now;
                leder.CreateID = leder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(leder);
            }
            else                    //更新在途数量
            {
                inventoryLeder.AfloatCount = inventoryLeder.AfloatCount + count;
                inventoryLeder.AfloatPrice = productPrice;
                inventoryLeder.AfloatMoney = productMoney;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
        }

        /// <summary>
        ///  //录入产品厂家编码
        /// </summary>
        /// <param name="storageDetailID"></param>
        /// <param name="pid"></param>
        /// <param name="storageCount">入库数量</param>
        private void InsertStorageProductBarCodes(int storageDetailID, int pid, int storageCount)
        {
            if (Session["Storage"] != null)
            {
                List<BarCodeInfo> BarCodeList = Session["Storage"] as List<BarCodeInfo>;
                if (BarCodeList != null && BarCodeList.Count > 0)
                {
                    foreach (BarCodeInfo str in BarCodeList)
                    {
                        if (str.PID == pid)
                        {
                            if (str.BarCodeStr != "" && str.BarCodeStr.Length > 0)
                            {
                                string[] p = str.BarCodeStr.Split(';');
                                if (p.Count() > storageCount)
                                {
                                    base.ShowMessage("入库商品条形码数量不能大于入库数量，请重新录入！");
                                    return;
                                }
                                if (p.Count() > 0)
                                {
                                    foreach (string parm in p)
                                    {
                                        //判断当前产品条形码是否存在 如不存在新增
                                        var info = base.XMStorageProductBarCodeDetailService.GetXMStorageProductBarCodeDetailByParm(storageDetailID, parm);
                                        if (info == null)                  //新增
                                        {
                                            XMStorageProductBarCodeDetail sDetail = new XMStorageProductBarCodeDetail();
                                            sDetail.SpdId = storageDetailID;
                                            var storageDetail = base.XMStorageProductDetailsService.GetXMStorageProductDetailsById(storageDetailID);
                                            if (storageDetail != null)
                                            {
                                                sDetail.ProductId = storageDetail.ProductId;
                                                sDetail.PlatformMerchantCode = storageDetail.PlatformMerchantCode;
                                            }
                                            sDetail.BarCode = parm;
                                            sDetail.CreateDate = sDetail.UpdateDate = DateTime.Now;
                                            sDetail.CreateID = sDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            sDetail.IsEnable = false;
                                            base.XMStorageProductBarCodeDetailService.InsertXMStorageProductBarCodeDetail(sDetail);
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
        /// 入库审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSingleStorageIsAudit_Click(object sender, EventArgs e)
        {
            var storages = base.XMStorageService.GetXMStorageById(this.StorageID);
            if (storages != null && storages.IsAudit == false)
            {
                storages.IsAudit = true;
                storages.UpdateID = HozestERPContext.Current.User.CustomerID;
                storages.UpdateDate = DateTime.Now;
                base.XMStorageService.UpdateXMStorage(storages);
            }
            BindGrid(this.StorageID);
            base.ShowMessage("操作成功!");
        }

        /// <summary>
        /// 入库反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSingleStorageIsAuditFalse_Click(object sender, EventArgs e)
        {
            var storages = base.XMStorageService.GetXMStorageById(this.StorageID);
            if (storages != null && storages.BillStatus == 1000)             //已经入库无法反审核
            {
                base.ShowMessage("已经入库无法反审核 !");
                BindGrid(this.StorageID);
                return;
            }
            if (storages != null)
            {
                storages.IsAudit = false;
                storages.UpdateID = HozestERPContext.Current.User.CustomerID;
                storages.UpdateDate = DateTime.Now;
                base.XMStorageService.UpdateXMStorage(storages);
            }
            BindGrid(this.StorageID);
            base.ShowMessage("操作成功!");
        }

        /// <summary>
        /// 提交入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSingleStorage_Click(object sender, EventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var storages = base.XMStorageService.GetXMStorageById(StorageID);
                if (storages != null)
                {
                    bool storageIsAudit = storages.IsAudit == null ? false : storages.IsAudit.Value;
                    if (!storageIsAudit)
                    {
                        base.ShowMessage("采购未审核通过，无法提交入库！");
                        BindGrid(this.StorageID);
                        return;
                    }
                }
                if (storages != null && storages.BillStatus == 0)
                {
                    //更新状态
                    storages.BillStatus = 1000;      //状态更新为已入库
                    storages.StorageDate = DateTime.Now;
                    base.XMStorageService.UpdateXMStorage(storages);
                    var storageProductDetails = base.XMStorageProductDetailsService.GetXMStorageProductDetailsByStorageID(storages.Id);
                    if (storageProductDetails != null && storageProductDetails.Count > 0)
                    {
                        foreach (XMStorageProductDetails Info in storageProductDetails)
                        {
                            string code = Info.PlatformMerchantCode;
                            int wfID = storages.WareHouseId;
                            var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(code, wfID);
                            if (InventoryInfo != null)                       //厂家编码为code的产品在库存表中已经存在 更新库存数量
                            {
                                InventoryInfo.StockNumber += Info.ProductsCount;
                                InventoryInfo.CanOrderCount = InventoryInfo.StockNumber;
                                InventoryInfo.UpdateDate = DateTime.Now;
                                InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
                                //更新入库产品条形码
                                UpdateProductBarCodeList(InventoryInfo.Id, Info.Id);
                            }
                            else
                            {
                                //产品不存在  新增
                                XMInventoryInfo parm = new XMInventoryInfo();
                                parm.PrductId = Info.ProductId.Value;
                                parm.PlatformMerchantCode = Info.PlatformMerchantCode;
                                parm.WfId = storages.WareHouseId;
                                parm.StockNumber = Info.ProductsCount;
                                parm.CanOrderCount = parm.StockNumber;
                                parm.WarningValue = 0;
                                parm.CreateID = HozestERPContext.Current.User.CustomerID;
                                parm.CreateDate = DateTime.Now;
                                parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                parm.UpdateDate = DateTime.Now;
                                parm.IsEnable = false;
                                base.XMInventoryInfoService.InsertXMInventoryInfo(parm);
                                //更新入库产品条形码
                                UpdateProductBarCodeList(parm.Id, Info.Id);
                            }
                            //更新库存总账主表数据   从表添加一条记录
                            UpdateInventoryLederInfo(storages.WareHouseId, Info);
                        }
                    }
                }
                scope.Complete();
            }
            BindGrid(this.StorageID);
            base.ShowMessage("提交入库成功！");
        }
        /// <summary>
        /// 提交入库   向库存添加该产品的条形码
        /// </summary>
        /// <param name="inventoryID"></param>
        /// <param name="storageDetailID"></param>
        private void UpdateProductBarCodeList(int inventoryID, int storageDetailID)
        {
            //根据产品详情ID 获取入库产品的条形码列表
            var barCodes = base.XMStorageProductBarCodeDetailService.GetXMStorageProductBarCodeDetailListBySpdID(storageDetailID);
            if (barCodes != null && barCodes.Count > 0)
            {
                //遍历所有条形码
                foreach (XMStorageProductBarCodeDetail Info in barCodes)
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

        private void UpdateInventoryLederInfo(int wareHousesId, XMStorageProductDetails info)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, info.PlatformMerchantCode);
            if (inventoryLeder != null)     //更新数据
            {
                //更新在途数量(减去)
                inventoryLeder.AfloatCount = inventoryLeder.AfloatCount == 0 ? 0 : inventoryLeder.AfloatCount - info.ProductsCount;
                inventoryLeder.AfloatPrice = info.ProductsPrice;
                inventoryLeder.AfloatMoney = info.ProductsPrice * inventoryLeder.AfloatCount;
                //更新入库数量（加上）
                inventoryLeder.InCount = (inventoryLeder.InCount == null ? 0 : inventoryLeder.InCount) + info.ProductsCount;
                inventoryLeder.InMoney = info.ProductsPrice * inventoryLeder.InCount;
                inventoryLeder.InPrice = info.ProductsPrice;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else                       //新增数据
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.WarehouseId = wareHousesId;
                inventoryLederInfo.ProductId = info.ProductId;
                inventoryLederInfo.PlatformMerchantCode = info.PlatformMerchantCode;
                inventoryLederInfo.AfloatCount = 0;
                inventoryLederInfo.AfloatPrice = info.ProductsPrice;
                inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                inventoryLederInfo.InCount = info.ProductsCount;
                inventoryLederInfo.InPrice = info.ProductsPrice;
                inventoryLederInfo.InMoney = inventoryLederInfo.InCount * inventoryLederInfo.InPrice;
                inventoryLederInfo.OutCount = 0;
                inventoryLederInfo.OutPrice = info.ProductsPrice;
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(入库)
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, info.PlatformMerchantCode);
            decimal price = 0;
            decimal money = 0;
            XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
            details.WarehouseId = wareHousesId;
            details.ProductId = info.ProductId;
            details.PlatformMerchantCode = info.PlatformMerchantCode;
            details.InCount = info.ProductsCount;                  //入库数量
            details.InPrice = info.ProductsPrice;                      //入库单价
            details.InMoney = info.ProductsMoney;
            details.OutCount = 0;
            details.OutPrice = price;
            details.OutMoney = money;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                details.BalanceCount = BalanceCount + details.InCount;
            }
            else           //
            {
                details.BalanceCount = details.InCount;
            }
            details.BalancePrice = info.ProductsPrice;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            details.BalanceMoney = details.BalanceCount * details.BalancePrice;
            var storages = base.XMStorageService.GetXMStorageById(info.StorageId);
            if (storages != null)
            {
                details.RefNumber = storages.Ref;        //业务单号
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
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
        public int StorageID
        {
            get
            {
                return CommonHelper.QueryStringInt("StorageID");
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

    public class storageInfo
    {
        public string ProCode;           //厂家编码
        public int StorageCount;       //可以入库数量
    }
}