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

namespace HozestERP.Web.ManageProject
{
    public partial class XMCombinationManage : BaseAdministrationPage, ISearchPage
    {
        ///// <summary>
        ///// 权限控制
        ///// </summary>
        //protected override Dictionary<string, string> ButtonSecuritys
        //{
        //    get
        //    {
        //        Dictionary<string, string> buttons = new Dictionary<string, string>();
        //        buttons.Add("imgBtnEdit", "XMProductManage.Edit");
        //        buttons.Add("imgBtnDelete", "XMProductManage.Delete");
        //        buttons.Add("imgBtnUpdate", "XMProductManage.Save");
        //        buttons.Add("imgBtnCancel", "XMProductManage.Cancel");
        //        buttons.Add("btnStoreManufacturersInventoryImport", "XMProductManage.ImportManufacturersInventory");
        //        buttons.Add("btnModifyManufacturersInventory", "XMProductManage.UpdateManufacturersInventory");
        //        buttons.Add("btnSaveManufacturersInventory", "XMProductManage.SaveManufacturersInventory");
        //        buttons.Add("imgProductDetails", "XMProductManage.XMProductDetails");//产品管理

        //        return buttons;
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.ProjectId != 0)
                {
                    var NickListP = base.XMNickService.GetXMNickListByProjectId(this.ProjectId);
                    var NewNickListP = NickListP.Where(p => p.isEnable == true).ToList();
                    ddlNick.DataSource = NewNickListP;
                    ddlNick.DataTextField = "nick";
                    ddlNick.DataValueField = "nick_id";
                    ddlNick.DataBind();
                    ddlNick.Items.Insert(0, new ListItem("--所有--", "-1"));
                    this.txtNick.Visible = false;
                }
                else
                {
                    if (this.NickId == -1)
                    {
                        this.txtNick.Visible = false;
                        this.ddlNick.Visible = true;
                        #region 店铺名称绑定

                        ////店铺数据源 
                        //if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                        //{
                        this.ddlNick.Items.Clear();
                        var NickList = base.XMNickService.GetXMNickList();
                        var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                        this.ddlNick.DataSource = newNickList;
                        this.ddlNick.DataTextField = "nick";
                        this.ddlNick.DataValueField = "nick_id";
                        this.ddlNick.DataBind();
                        this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                        //}
                        //else
                        //{
                        //    //其他
                        //    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                        //    var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                        //    if (xMNickList.Count() == 0)
                        //    {
                        //        this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                        //    }
                        //    if (xMNickList.Count > 0)
                        //    {
                        //        this.ddlNick.Items.Clear();
                        //        this.ddlNick.DataSource = xMNickList;
                        //        this.ddlNick.DataTextField = "nick";
                        //        this.ddlNick.DataValueField = "nick_id";
                        //        this.ddlNick.DataBind();
                        //        //this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                        //    }
                        //}

                        #endregion
                        //var NickList = base.XMNickService.GetXMNickList();
                        //var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                        //ddlNick.DataSource = newNickList;
                        //ddlNick.DataTextField = "nick";
                        //ddlNick.DataValueField = "nick_id";
                        //ddlNick.DataBind();
                        //ddlNick.Items.Insert(0, new ListItem("--所有--", "-1"));
                    }
                    else
                    {
                        this.txtNick.Visible = true;
                        this.ddlNick.Visible = false;
                        this.txtNick.Text = this.Nick;
                    }
                }
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
            this.Master.SetTitleVisible = false;

            this.btnAdd.OnClientClick = "return ShowWindowDetail('组合产品管理添加','" + CommonHelper.GetStoreLocation()
          + "ManageProject/XMCombinationManageAdd.aspx?CombinationID=0',800, 500, this, function(){document.getElementById('"
          + this.btnSearch.ClientID + "').click();});";
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //店铺ID
            int NIckID = int.Parse(this.ddlNick.SelectedValue);
            //产品名称
            string ProductName = this.txtProductName.Text.Trim();
            //厂家编码
            string FactoryCode = this.txtFactoryCode.Text.Trim();
            //商品编码
            string ProductCode = this.txtProductCode.Text.Trim();

            var xMProjectList = base.XMCombinationService.GetXMCombinationList(NIckID, ProductName, FactoryCode, ProductCode);
            var xMProjectPageList = new PagedList<XMCombination>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.gvXMProduct, xMProjectPageList, paramPageSize + 1);
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

        protected string selectnick(int nickid)
        {
            string nick = "";
            var nicklist = base.XMNickService.GetXMNickByID(nickid);
            if (nicklist != null)
            {
                nick = nicklist.nick;
            }
            return nick;
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
                var Product = base.XMCombinationService.GetXMCombinationByID(ProductID);
                if (Product != null)
                {
                    Product.IsEnabled = true;
                    Product.UpdatorID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    Product.UpdateTime = DateTime.Now;
                    base.XMCombinationService.UpdateXMCombination(Product);
                    var productDetails = base.XMCombinationDetailsService.GetXMCombinationDetailsListByProductId(Product.ID);
                    foreach(var elem in productDetails)
                    {
                        elem.IsEnable = true;
                        elem.UpdateDate = DateTime.Now;
                        elem.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    }
                    base.XMCombinationDetailsService.UpdateXMCombinationDetails(productDetails);
                 }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("删除成功！");
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
            int Nindex = index - 1;
            int.TryParse(this.gvXMProduct.DataKeys[Nindex].Value.ToString(), out Id);
            var row = this.gvXMProduct.Rows[Nindex];
            var product = base.XMProductService.GetXMProductById(Id);

            if (product != null)
            {
                //品牌
                CodeControl CCBrandTypeId = (CodeControl)row.FindControl("CCBrandTypeId");
                if (CCBrandTypeId != null)
                {
                    CCBrandTypeId.SelectedValue = product.BrandTypeId.Value;
                }
            }
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
                if (this.NickId == -1)
                {
                    var ddlNick = row.FindControl("ddlNick") as DropDownList;
                    ddlNick.Enabled = false;

                }
                else
                {
                    var ddlNick = row.FindControl("ddlNick") as DropDownList;
                    ddlNick.Enabled = true;
                }
                //品牌
                CodeControl CCBrandTypeId = (CodeControl)row.FindControl("CCBrandTypeId");

                var txtProductName = row.FindControl("txtProductName") as TextBox;
                var lblMsgProductNameVaule = row.FindControl("lblMsgProductNameVaule") as Label;
                lblMsgProductNameVaule.Text = "";
                if (txtProductName.Text.Trim() == "")
                {
                    lblMsgProductNameVaule.Text = "不允许为空";
                }
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
                var txtManufacturersInventoryE = row.FindControl("txtManufacturersInventoryE") as TextBox;
                var lblMsgManufacturersInventoryEVaule = row.FindControl("lblMsgManufacturersInventoryEVaule") as Label;
                lblMsgManufacturersInventoryEVaule.Text = "";
                if (txtManufacturersInventoryE.Text.Trim() == "")
                {

                    lblMsgManufacturersInventoryEVaule.Text = "不允许为空";
                }
                if (!int.TryParse(txtManufacturersInventoryE.Text.Trim(), out paramparse))
                {
                    if (txtManufacturersInventoryE.Text.Trim() != "")
                        lblMsgManufacturersInventoryEVaule.Text = "请输入正确的数值";
                }
                //预警库存数
                var txtWarningQuantityE = row.FindControl("txtWarningQuantityE") as TextBox;
                var lblMsgWarningQuantityEVaule = row.FindControl("lblMsgWarningQuantityEVaule") as Label;
                lblMsgWarningQuantityEVaule.Text = "";
                if (txtWarningQuantityE.Text.Trim() == "")
                {
                    lblMsgWarningQuantityEVaule.Text = "不允许为空";
                }

                if (!int.TryParse(txtWarningQuantityE.Text.Trim(), out paramparse))
                {
                    if (txtWarningQuantityE.Text.Trim() != "")
                        lblMsgWarningQuantityEVaule.Text = "请输入正确的数值";
                }

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

                // 是否赠品
                var chkIsPremiums = row.FindControl("chkIsPremiums") as CheckBox;


                //|| lblMsgProductColorsVaule.Text != ""
                if (lblMsgProductNameVaule.Text != "" || lblMsgManufacturersCodeVaule.Text != "" ||
                    lblMsgSpecificationsVaule.Text != "" || lblMsgManufacturersInventoryEVaule.Text != "" ||
                    lblMsgWarningQuantityEVaule.Text != "")
                {
                    return;
                }

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
                    Product.Specifications = txtSpecifications.Text.Trim();
                    int paramparse1 = 0;

                    #region 数据转换

                    if (int.TryParse(txtManufacturersInventoryE.Text.Trim(), out paramparse1))
                    {
                        Product.ManufacturersInventory = int.Parse(txtManufacturersInventoryE.Text.Trim());
                    }
                    else
                    {
                        Product.ManufacturersInventory = 0;
                    }
                    if (int.TryParse(txtWarningQuantityE.Text.Trim(), out paramparse1))
                    {
                        Product.WarningQuantity = int.Parse(txtWarningQuantityE.Text.Trim());
                    }
                    else
                    {
                        Product.WarningQuantity = 0;
                    }
                    #endregion
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

                    if (int.TryParse(txtManufacturersInventoryE.Text.Trim(), out paramparse1))
                    {
                        ProductNew.ManufacturersInventory = int.Parse(txtManufacturersInventoryE.Text.Trim());
                    }
                    else
                    {
                        ProductNew.ManufacturersInventory = 0;
                    }
                    if (int.TryParse(txtWarningQuantityE.Text.Trim(), out paramparse1))
                    {
                        ProductNew.WarningQuantity = int.Parse(txtWarningQuantityE.Text.Trim());
                    }
                    else
                    {
                        ProductNew.WarningQuantity = 0;
                    }
                    #endregion
                    ProductNew.ProductColors = txtProductColors.Text.Trim();
                    ProductNew.ProductUnit = txtProductUnit.Text.Trim();
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
                DropDownList ddlNick = (DropDownList)e.Row.FindControl("ddlNick");
                //找到DropDownList 控件，然后进行绑定或者追加内容
                if (this.ProjectId != 0)
                {
                    var NickListP = base.XMNickService.GetXMNickListByProjectId(this.ProjectId);
                    var NewNickListP = NickListP.Where(p => p.isEnable == true).ToList();
                    ddlNick.DataSource = NewNickListP;
                    ddlNick.DataTextField = "nick";
                    ddlNick.DataValueField = "nick_id";
                    ddlNick.DataBind();
                    ddlNick.Items.Insert(0, new ListItem("--所有--", "-1"));
                    this.txtNick.Visible = false;
                }
                else
                {
                    //绑定店铺数据
                    var NickList = base.XMNickService.GetXMNickList();
                    if (this.NickId == -1)
                    {
                        var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                        ddlNick.DataSource = newNickList;
                        ddlNick.DataTextField = "nick";
                        ddlNick.DataValueField = "nick_id";
                        ddlNick.DataBind();
                    }
                    else
                    {

                        var newNickList1 = NickList.Where(p => p.isEnable == true && p.nick_id == this.NickId).ToList();
                        ddlNick.DataSource = newNickList1;
                        ddlNick.DataTextField = "nick";
                        ddlNick.DataValueField = "nick_id";
                        ddlNick.DataBind();
                    }
                }
                //Label lblNick = (Label)e.Row.FindControl("lblNick");
                //lblNick.Text = this.Nick;

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMProduct = (XMCombination)e.Row.DataItem;


                //弹出产品信息
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                //编辑
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('组合产品管理编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMCombinationManageAdd.aspx?CombinationID=" + xMProduct.ID + "',800, 500, this, function(){document.getElementById('"
                   + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('产品信息','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMCombinationDetailsManage.aspx?ProductId=" + xMProduct.ID + "&PageFrom=1',1100, 560, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";

                }
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

    }
}