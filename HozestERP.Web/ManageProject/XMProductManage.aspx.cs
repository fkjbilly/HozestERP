using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.Web.Modules;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageInventory;
using System.Transactions;

namespace HozestERP.Web.ManageProject
{
    public partial class XMProductManage : BaseAdministrationPage, ISearchPage
    {
        /// <summary>
        /// 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnEdit", "XMProductManage.Edit");
                buttons.Add("imgBtnDelete", "XMProductManage.Delete");
                buttons.Add("imgBtnUpdate", "XMProductManage.Save");
                buttons.Add("imgBtnCancel", "XMProductManage.Cancel");
                buttons.Add("btnStoreManufacturersInventoryImport", "XMProductManage.ImportManufacturersInventory");
                buttons.Add("btnModifyManufacturersInventory", "XMProductManage.UpdateManufacturersInventory");
                buttons.Add("btnSaveManufacturersInventory", "XMProductManage.SaveManufacturersInventory");
                buttons.Add("imgProductDetails", "XMProductManage.XMProductDetails");//产品管理
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //弹出导入产品窗口
                this.btnImportProduct.OnClientClick = "return ShowWindowDetail('导入产品','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportProduct.aspx',600,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";


                btnImportFactoryPrice.OnClientClick= "return ShowWindowDetail('导入出厂价','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportFactoryPrice.aspx',600,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            //绑定品牌下拉框


            this.Master.SetTitleVisible = false;
            this.btnGiftStorage.OnClientClick = "return ShowWindowDetail('赠品入库','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMGiftStorage.aspx?type=0',800, 500, this, function(){});";
            this.btnSearchGiftStorageRecords.OnClientClick = "return ShowWindowDetail('赠品入库查询','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMGiftStorage.aspx?type=1',800, 500, this, function(){});";
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //产品名称
            string ProductName = this.txtProductName.Text.Trim();
            //厂家编码
            string FactoryCode = this.txtFactoryCode.Text.Trim();
            //商品编码
            string ProductCode = this.txtProductCode.Text.Trim();
            int BrandTypeId = this.CCBrandTypeList.SelectedValue;
            int SupplierId = int.Parse(string.IsNullOrWhiteSpace(this.ddSuppliers.Text) ? "-1" : this.ddSuppliers.Text);
            PagedList<XMProduct> XMProductList = base.XMProductService.SearchXMProduct(BrandTypeId, ProductName, SupplierId, FactoryCode, ProductCode, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            if (this.RowEditIndex == -1)
            {
                //新增编码行
                this.gvXMProduct.EditIndex = 0;// XMProductList.Count(); 
                XMProductList.Insert(0, new XMProduct
                {
                    ProductName = "",
                    ManufacturersCode = "",
                    Specifications = "",
                    ManufacturersInventory = 0,
                    WarningQuantity = 0
                });
            }
            else
            {
                XMProductList.Insert(0, new XMProduct
                {
                    ProductName = "",
                    ManufacturersCode = "",
                    Specifications = "",
                    ManufacturersInventory = 0,
                    WarningQuantity = 0
                });
                this.gvXMProduct.EditIndex = this.RowEditIndex;
            }

            this.Master.BindData(this.gvXMProduct, XMProductList, paramPageSize + 1);
            if (this.RowEditIndex > 0)
            {
                var editindex = this.RowEditIndex + 2 >= 10 ? (this.RowEditIndex + 2).ToString() : "0" + (this.RowEditIndex + 2).ToString();
                string id = gvXMProduct.DataKeys[this.RowEditIndex].Values[0].ToString();
                var Product = base.XMProductService.GetXMProductById(Convert.ToInt32(id));
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "", "EditSuppliers('" + editindex + "','" + Product.SuppliersID + "');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "", "TopSuppliers();", true);
        }

        #endregion

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

        }

        protected void ddlNick_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvXMProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ProductID = 0;
            if (int.TryParse(this.gvXMProduct.DataKeys[e.RowIndex].Value.ToString(), out ProductID))
            {
                // 产品信息
                var Product = base.XMProductService.GetXMProductById(ProductID);
                if (Product != null)
                {
                    //Product.IsEnable = true;
                    //Product.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    //Product.UpdateDate = DateTime.Now;
                    //base.XMProductService.UpdateXMProduct(Product);
                    base.XMProductService.DeleteXMProduct(ProductID);
                    var DetailList = base.XMProductDetailsService.GetXMProductDetailsListByProductId(ProductID);
                    if (DetailList != null && DetailList.Count > 0)
                    {
                        foreach (XMProductDetails info in DetailList)
                        {
                            base.XMProductDetailsService.DeleteXMProductDetails(info.Id);
                        }
                    }
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("删除成功.");
            }
        }

        protected void gvXMProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void gvXMProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            //this.RowEditIndex = e.NewEditIndex - 1;//行号减1 （注：减掉第一行编辑行）
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

            int Id = 0;
            int index = e.NewEditIndex;
            //int Nindex = index - 1;
            int.TryParse(this.gvXMProduct.DataKeys[index].Value.ToString(), out Id);
            var row = this.gvXMProduct.Rows[index];
            var product = base.XMProductService.GetXMProductById(Id);

            if (product != null)
            {
                //品牌
                CodeControl CCBrandTypeId = (CodeControl)row.FindControl("CCBrandTypeId");
                if (CCBrandTypeId != null)
                {
                    CCBrandTypeId.SelectedValue = product.BrandTypeId.Value;
                }

                //发货方
                DropDownList ddlShipper = (DropDownList)row.FindControl("ddlShipper");
                if (ddlShipper != null)
                {
                    ddlShipper.SelectedValue = product.Shipper.ToString();
                }
            }
            //供应商
            var editindex = index + 2 >= 10 ? (index + 2).ToString() : "0" + (index + 2).ToString();
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "", "EditSuppliers('" + editindex + "');", true);
        }
       
        /// <summary>
        /// 记录行 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvXMProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int paramparse = 0;
            //decimal param = 0;
            if (int.TryParse(this.gvXMProduct.DataKeys[e.RowIndex].Value.ToString(), out paramparse))
            {
                var row = this.gvXMProduct.Rows[e.RowIndex];

                #region 字符验证
                //品牌
                CodeControl CCBrandTypeId = (CodeControl)row.FindControl("CCBrandTypeId");

                var txtProductName = row.FindControl("txtProductName") as TextBox;
                var lblMsgProductNameVaule = row.FindControl("lblMsgProductNameVaule") as Label;
                lblMsgProductNameVaule.Text = "";
                if (txtProductName.Text.Trim() == "")
                {
                    lblMsgProductNameVaule.Text = "不允许为空";
                }
                //发货方
                var ddlShipper = row.FindControl("ddlShipper") as DropDownList;
                var ddSuppliersID = row.FindControl("ddEditSuppliersID") as TextBox;
                //厂家编码
                var txtManufacturersCode = row.FindControl("txtManufacturersCode") as TextBox;
                var hfManufacturersCode = row.FindControl("hfManufacturersCode") as HiddenField;

                var lblMsgManufacturersCodeVaule = row.FindControl("lblMsgManufacturersCodeVaule") as Label;
                lblMsgManufacturersCodeVaule.Text = "";
                if (txtManufacturersCode.Text.Trim() == "")
                {
                    lblMsgManufacturersCodeVaule.Text = "不允许为空";
                }
                //尺寸
                var txtSpecifications = row.FindControl("txtSpecifications") as TextBox;
                var lblMsgSpecificationsVaule = row.FindControl("lblMsgSpecificationsVaule") as Label;
                lblMsgSpecificationsVaule.Text = "";
                if (txtSpecifications.Text.Trim() == "")
                {
                    lblMsgSpecificationsVaule.Text = "不允许为空";
                }
                //厂家库存
                //var txtManufacturersInventoryE = row.FindControl("txtManufacturersInventoryE") as TextBox;
                //var lblMsgManufacturersInventoryEVaule = row.FindControl("lblMsgManufacturersInventoryEVaule") as Label;
                //lblMsgManufacturersInventoryEVaule.Text = "";
                //if (txtManufacturersInventoryE.Text.Trim() == "")
                //{

                //    lblMsgManufacturersInventoryEVaule.Text = "不允许为空";
                //}
                //if (!int.TryParse(txtManufacturersInventoryE.Text.Trim(), out paramparse))
                //{
                //    if (txtManufacturersInventoryE.Text.Trim() != "")
                //        lblMsgManufacturersInventoryEVaule.Text = "请输入正确的数值";
                //}
                //预警库存数
                //var txtWarningQuantityE = row.FindControl("txtWarningQuantityE") as TextBox;
                //var lblMsgWarningQuantityEVaule = row.FindControl("lblMsgWarningQuantityEVaule") as Label;
                //lblMsgWarningQuantityEVaule.Text = "";
                //if (txtWarningQuantityE.Text.Trim() == "")
                //{
                //    lblMsgWarningQuantityEVaule.Text = "不允许为空";
                //}

                //if (!int.TryParse(txtWarningQuantityE.Text.Trim(), out paramparse))
                //{
                //    if (txtWarningQuantityE.Text.Trim() != "")
                //        lblMsgWarningQuantityEVaule.Text = "请输入正确的数值";
                //}

                //颜色
                var txtProductColors = row.FindControl("txtProductColors") as TextBox;
                //var lblMsgProductColorsVaule = row.FindControl("lblMsgProductColorsVaule") as Label;
                //lblMsgProductColorsVaule.Text = "";
                //if (txtProductColors.Text.Trim() == "")
                //{
                //    lblMsgProductColorsVaule.Text = "不允许为空";
                //}

                //计量单位
                var txtProductUnit = row.FindControl("txtProductUnit") as TextBox;

                //体重
                var txtProductWeight = row.FindControl("txtProductWeight") as TextBox;
                //体积
                var txtProductVolume = row.FindControl("txtProductVolume") as TextBox;
                //系列
                var txtSeries = row.FindControl("txtSeries") as TextBox;

                // 是否赠品
                var chkIsPremiums = row.FindControl("chkIsPremiums") as CheckBox;


                //|| lblMsgProductColorsVaule.Text != ""
                //if (lblMsgProductNameVaule.Text != "" || lblMsgManufacturersCodeVaule.Text != "" ||
                //    lblMsgSpecificationsVaule.Text != "" || lblMsgManufacturersInventoryEVaule.Text != "" ||
                //    lblMsgWarningQuantityEVaule.Text != "")
                //{
                //    return;
                //}

                #endregion

                var Product = base.XMProductService.GetXMProductById(int.Parse(this.gvXMProduct.DataKeys[e.RowIndex].Value.ToString()));

                List<XMProduct> ProductManufacturersCodeList = new List<XMProduct>();
                if (txtManufacturersCode.Text.Trim() != "")
                {
                    ProductManufacturersCodeList = base.XMProductService.getXMProductListByEqusManufacturersCode(txtManufacturersCode.Text.Trim());
                }
                //修改
                if (Product != null)
                {
                    #region
                    if (ProductManufacturersCodeList.Count > 0)
                    {
                        if (!txtManufacturersCode.Text.Trim().Equals(hfManufacturersCode.Value))
                        {
                            base.ShowMessage("厂家编码已存在");
                            return;
                        }
                    }
                    Product.BrandTypeId = CCBrandTypeId.SelectedValue;
                    Product.ProductName = txtProductName.Text.Trim();
                    Product.ManufacturersCode = txtManufacturersCode.Text.Trim();
                    Product.Shipper = int.Parse(ddlShipper.SelectedValue.Trim());
                    Product.SuppliersID = int.Parse(ddSuppliersID.Text.Trim());
                    Product.Specifications = txtSpecifications.Text.Trim();
                    int paramparse1 = 0;

                    #region 数据转换

                    //if (int.TryParse(txtManufacturersInventoryE.Text.Trim(), out paramparse1))
                    //{
                    //    Product.ManufacturersInventory = int.Parse(txtManufacturersInventoryE.Text.Trim());
                    //}
                    //else
                    //{
                    //    Product.ManufacturersInventory = 0;
                    //}
                    //if (int.TryParse(txtWarningQuantityE.Text.Trim(), out paramparse1))
                    //{
                    //    Product.WarningQuantity = int.Parse(txtWarningQuantityE.Text.Trim());
                    //}
                    //else
                    //{
                    //    Product.WarningQuantity = 0;
                    //}
                    #endregion
                    Product.Series = txtSeries.Text.Trim();
                    Product.ProductColors = txtProductColors.Text.Trim();
                    Product.ProductUnit = txtProductUnit.Text.Trim();
                    Product.ProductWeight = txtProductWeight.Text.Trim();
                    Product.ProductVolume = txtProductVolume.Text.Trim();
                    Product.IsPremiums = chkIsPremiums.Checked;
                    Product.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    Product.UpdateDate = DateTime.Now;
                    //修改产品信息
                    base.XMProductService.UpdateXMProduct(Product);

                    #endregion
                }
                // 新增
                else
                {
                    if (ProductManufacturersCodeList.Count > 0)
                    {
                        base.ShowMessage("厂家编码已存在");
                        return;
                    }

                    XMProduct ProductNew = new XMProduct();
                    ProductNew.BrandTypeId = CCBrandTypeId.SelectedValue;
                    ProductNew.ProductName = txtProductName.Text.Trim();
                    ProductNew.ManufacturersCode = txtManufacturersCode.Text.Trim();
                    ProductNew.Specifications = txtSpecifications.Text.Trim();
                    int paramparse1 = 0;

                    #region 数据转换

                    //if (int.TryParse(txtManufacturersInventoryE.Text.Trim(), out paramparse1))
                    //{
                    //    ProductNew.ManufacturersInventory = int.Parse(txtManufacturersInventoryE.Text.Trim());
                    //}
                    //else
                    //{
                    //    ProductNew.ManufacturersInventory = 0;
                    //}
                    //if (int.TryParse(txtWarningQuantityE.Text.Trim(), out paramparse1))
                    //{
                    //    ProductNew.WarningQuantity = int.Parse(txtWarningQuantityE.Text.Trim());
                    //}
                    //else
                    //{
                    //    ProductNew.WarningQuantity = 0;
                    //}
                    #endregion
                    ProductNew.Series = txtSeries.Text.Trim();
                    ProductNew.ProductColors = txtProductColors.Text.Trim();
                    ProductNew.ProductUnit = txtProductUnit.Text.Trim();
                    ProductNew.Shipper = int.Parse(ddlShipper.SelectedValue.Trim());
                    ProductNew.SuppliersID = int.Parse(ddSuppliersID.Text.Trim());
                    ProductNew.ProductWeight = txtProductWeight.Text.Trim();
                    ProductNew.ProductVolume = txtProductVolume.Text.Trim();
                    ProductNew.IsPremiums = chkIsPremiums.Checked;
                    ProductNew.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    ProductNew.UpdateDate = DateTime.Now;
                    ProductNew.IsEnable = false;//默认可用
                    ProductNew.CreateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    ProductNew.CreateDate = DateTime.Now;
                    ProductNew.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    ProductNew.UpdateDate = DateTime.Now;
                    //新增产品
                    base.XMProductService.InsertXMProduct(ProductNew);
                }
                this.RowEditIndex = -1;
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            }
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvXMProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == DataControlRowState.Edit ||
                e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                DropDownList ddlShipper = (DropDownList)e.Row.FindControl("ddlShipper");
                //找到DropDownList 控件，然后进行绑定或者追加内容
                var ShipperList = base.CodeService.GetCodeListInfoByCodeTypeID(226);
                ddlShipper.DataSource = ShipperList;
                ddlShipper.DataTextField = "CodeName";
                ddlShipper.DataValueField = "CodeID";
                ddlShipper.DataBind();
                ddlShipper.SelectedIndex = 0;
               // this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>EditSuppliers('1');</script>", true);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMProduct = (XMProduct)e.Row.DataItem;

                //调整价格
                ImageButton imgAdjust = e.Row.FindControl("imgAdjust") as ImageButton;
                if (imgAdjust != null)
                {
                    imgAdjust.OnClientClick = "return ShowWindowDetail('调整价格','" + CommonHelper.GetStoreLocation()
                 + "ManageProject/XMAdjustOperation.aspx?MerchantCode=" + xMProduct.ManufacturersCode + "',900, 300, this, function(){document.getElementById('"
                 + this.btnRefresh.ClientID + "').click();});";
                }

                //弹出产品信息
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('产品信息','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMProductDetailsManage.aspx?ProductId=" + xMProduct.Id + "',1100, 560, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";

                }

                //ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                //string paramScript1 = "return ShowNewTabDetail('" + CommonHelper.GetStoreLocation() + "ManageProject/XMProductDetailsManage.aspx?ProductId="
                // + xMProduct.Id + "','ProductOperation" + xMProduct.Id + "','" + xMProduct.ProductName + "的产品信息');";
                //if (imgProductDetails != null)
                //    imgProductDetails.Attributes.Add("onclick", paramScript1);
            }
        }

        /// <summary>
        /// 修改库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModifyManufacturersInventory_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow item in gvXMProduct.Rows)
            {
                if (item.RowIndex != gvXMProduct.EditIndex)
                {
                    // 设置txtInventory 为可编辑控件
                    Label lblManufacturersInventory = item.FindControl("lblManufacturersInventory") as Label;
                    TextBox txtManufacturersInventory = item.FindControl("txtManufacturersInventory") as TextBox;
                    lblManufacturersInventory.Visible = false;
                    txtManufacturersInventory.Visible = true;
                    txtManufacturersInventory.Text = txtManufacturersInventory.Text == "" ? "0" : txtManufacturersInventory.Text;
                }
            }
        }

        /// <summary>
        /// 保存库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveManufacturersInventory_Click(object sender, EventArgs e)
        {
            #region 字符验证
            int errorcount = 0;
            //循环所有行
            foreach (GridViewRow msgReach in gvXMProduct.Rows)
            {
                if (msgReach.RowIndex != gvXMProduct.EditIndex)
                {
                    TextBox txtManufacturersInventory = msgReach.FindControl("txtManufacturersInventory") as TextBox;
                    Label lblManufacturersInventory = msgReach.FindControl("lblManufacturersInventory") as Label;
                    decimal temp = 0;
                    if (!decimal.TryParse(txtManufacturersInventory.Text.Trim(), out temp))
                    {
                        if (txtManufacturersInventory.Text.Trim() != "")
                        {
                            lblManufacturersInventory.Text = "请输入正确的数值";//确保输入的达成值都是数字
                            lblManufacturersInventory.Visible = true;
                            errorcount++;
                        }
                    }
                    else
                    {
                        lblManufacturersInventory.Visible = false;
                    }
                }
            }
            if (errorcount > 0)
            {
                return;
            }
            #endregion

            bool isEdit = false;
            //循环grid 每行 
            foreach (GridViewRow item in gvXMProduct.Rows)
            {
                if (item.RowIndex != gvXMProduct.EditIndex)
                {
                    //库存控件
                    TextBox txtManufacturersInventory = item.FindControl("txtManufacturersInventory") as TextBox;
                    string id = gvXMProduct.DataKeys[item.RowIndex].Values[0].ToString();
                    if (txtManufacturersInventory.Visible)
                    {
                        isEdit = true;
                        var Product = base.XMProductService.GetXMProductById(Convert.ToInt32(id));
                        //数据转换
                        if (txtManufacturersInventory.Text.Trim() != "")
                        {
                            Product.ManufacturersInventory = int.Parse(txtManufacturersInventory.Text.Trim());
                        }
                        else
                        {
                            Product.ManufacturersInventory = 0;
                        }
                        Product.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        Product.UpdateDate = DateTime.Now;
                        //数据数据
                        base.XMProductService.UpdateXMProduct(Product);
                    }
                }
            }
            if (isEdit)
                base.ShowMessage("保存成功!");
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void btnMoveCargo_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMProduct);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                foreach (int ID in IDs)
                {
                    var Product = base.XMProductService.GetXMProductById(ID);
                    if (Product != null)
                    {
                        Product.IsMoveCargo = true;
                        Product.UpdateID = HozestERPContext.Current.User.CustomerID;
                        Product.UpdateDate = DateTime.Now;
                        base.XMProductService.UpdateXMProduct(Product);
                    }
                }
                base.ShowMessage("操作成功！");
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            }
        }

        protected void btnUnMoveCargo_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvXMProduct);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                foreach (int ID in IDs)
                {
                    var Product = base.XMProductService.GetXMProductById(ID);
                    if (Product != null)
                    {
                        Product.IsMoveCargo = false;
                        Product.UpdateID = HozestERPContext.Current.User.CustomerID;
                        Product.UpdateDate = DateTime.Now;
                        base.XMProductService.UpdateXMProduct(Product);
                    }
                }
                base.ShowMessage("操作成功！");
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            }
        }
        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {

                List<int> IDs = this.Master.GetSelectedIds(this.gvXMProduct);
                var productDetails = base.XMProductDetailsService.GetXMProductDetailsListByProductIds(IDs);
                var detailsIds = productDetails.Select(m => m.Id).ToList();
                using (TransactionScope scope = new TransactionScope())
                {
                    base.XMProductDetailsService.BatchDeleteXMProductDetails(detailsIds);
                    base.XMProductService.BatchDeleteXMProduct(IDs);
                    scope.Complete();
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("删除成功.");
            }
            catch (Exception ex)
            {
                base.ShowMessage("错误:." + ex.Message);
            }
        }
        protected void btnExportProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                string filePath = string.Format("{0}Upload\\Product\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                //产品名称
                string ProductName = this.txtProductName.Text.Trim();
                //厂家编码
                string FactoryCode = this.txtFactoryCode.Text.Trim();
                //商品编码
                string ProductCode = this.txtProductCode.Text.Trim();
                int BrandTypeId = this.CCBrandTypeList.SelectedValue;

                List<XMProduct> list = XMProductService.GetXMProducts(BrandTypeId, ProductName, FactoryCode, ProductCode);

                ExportManager.ExportProductExcel(filePath, list);
                CommonHelper.WriteResponseXls(filePath, fileName);
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }

        public int RowEditIndex
        {
            get
            {
                int editIndex = -1;
                try
                {
                    int.TryParse(ViewState["RowEditIndex"].ToString(), out editIndex);
                }
                catch
                {
                }
                return editIndex;
            }
            set
            {
                ViewState["RowEditIndex"] = value;
            }
        }

        //protected void btnStoreManufacturersInventoryImport_Click(object sender, EventArgs e)
        //{
        //try
        //{
        //    //btnStoreQuantityImport.Enabled = false;
        //    if (fileUploadImport.HasFile)
        //    {
        //        string fileExtension = System.IO.Path.GetExtension(fileUploadImport.FileName);
        //        if (fileExtension.ToLower() == ".xls" || fileExtension.ToLower() == ".xlsx")
        //        {
        //            string uploadFilePath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad";
        //            if (!Directory.Exists(uploadFilePath))
        //            {
        //                Directory.CreateDirectory(uploadFilePath);
        //            }
        //            string uploadFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;
        //            string fullPath = Path.Combine(uploadFilePath, uploadFileName);
        //            fileUploadImport.SaveAs(fullPath);
        //            string msg = string.Empty;
        //            int result = base.ImportManager.ImportStoreQuantity(fullPath, ref msg);
        //            if (result > 0)
        //            {
        //                var mSetting = base.SettingManager.GetSettingByName("StoreQuantityUpdateTime");
        //                mSetting.Value = DateTime.Now.ToString("yyyy-MM-dd");
        //                base.SettingManager.UpdateSetting(mSetting.SettingID, mSetting.Name, mSetting.Value, mSetting.Description);
        //                base.ShowMessage("导入成功!");
        //            }
        //            else
        //                base.ShowMessage("导入失败,请检查!");
        //        }
        //        else
        //        {
        //            base.ShowMessage("文件格式不正确!");
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        base.ShowMessage("请上传文件!");
        //        return;
        //    }
        //}
        //catch (Exception err)
        //{
        //    base.ProcessException(err, false);
        //    base.ShowMessage("导入失败!");
        //}
        //finally
        //{
        //    //btnStoreQuantityImport.Enabled = true;
        //}
        //}

        /// <summary>
        /// 项目Id
        /// </summary>
        public int ProjectId
        {
            get
            {
                return CommonHelper.QueryStringInt("ProjectId");
            }
        }

        /// <summary>
        /// 店铺Id
        /// </summary>
        public int NickId
        {
            get
            {
                return CommonHelper.QueryStringInt("NickId");
            }
        }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Nick
        {
            get
            {
                return CommonHelper.QueryString("Nick");
            }
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
     
        //选中行索引Id
        //private int RowsIndex = -1;

    }
}