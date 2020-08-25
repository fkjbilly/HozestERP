using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Web.Modules;
using System.Web.UI.HtmlControls;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageProject
{ 
    public partial class XMCombinationDetailsManage : BaseAdministrationPage, IEditPage
    {
        /// <summary>
        /// 按钮 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnEdit", "ManageProject.XMProductDetailsManage.Edit");
                buttons.Add("imgBtnDelete", "ManageProject.XMProductDetailsManage.Delete");
                buttons.Add("imgBtnUpdate", "ManageProject.XMProductDetailsManage.Save");
                buttons.Add("imgBtnCancel", "ManageProject.XMProductDetailsManage.Cancel");
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                if (this.ProductId > 0)
                { 
                    XMCombination xMProduct = base.XMCombinationService.GetXMCombinationByID(this.ProductId);

                    if (xMProduct != null)
                    {
                        this.lblNickId.Text = xMProduct.NickName != null ? xMProduct.NickName.nick: "";
                        this.lblProductName.Text = xMProduct.ProductName != null ? xMProduct.ProductName : "";
                        this.lblManufacturersCode.Text = xMProduct.ManufacturersCode != null ? xMProduct.ManufacturersCode : "";
                    }
                    BindGrid();
                }
            }
        }

        /// <summary>
        /// 从表
        /// </summary> 
        public void BindGrid()
        {
            //暂支申请明细信息
            List<XMCombinationDetails> productDetailsList = base.XMCombinationDetailsService.GetXMProductDetailsListByProductId(this.ProductId);

            if (this.RowEditIndex == -1)
            {
                this.gvAdvanceApplicationDetail.EditIndex = productDetailsList.Count();
                productDetailsList.Add(new XMCombinationDetails()); //新增编辑行
            }
            else
            {
                this.gvAdvanceApplicationDetail.EditIndex = this.RowEditIndex;
            }

            this.gvAdvanceApplicationDetail.DataSource = productDetailsList;
            this.gvAdvanceApplicationDetail.DataBind();
        }


        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitleTabPanelVisible = false;
        }

        public void SetTrigger()
        {
        }

        #endregion

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvAdvanceApplicationDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 

                //var item = e.Row.DataItem as XMProductDetails;
                 
                //Label lblstrUrl = e.Row.FindControl("lblstrUrl") as Label;
                //if (lblstrUrl != null)
                //{
                //    string strUrl = item.strUrl;
                //    if (strUrl != null && strUrl != "" && strUrl.Length > 4)
                //    {
                //        string strUrls = strUrl.Substring(0, 4);
                //        lblstrUrl.Text = strUrls + "...";
                //        lblstrUrl.ToolTip = strUrl;
                //    }
                //    else
                //    {
                //        lblstrUrl.Text = "";
                //        lblstrUrl.ToolTip = strUrl;

                //    }
                //} 
            }
        }

        protected void gvAdvanceApplicationDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {

            this.RowEditIndex = e.NewEditIndex;
            BindGrid();

            int Id = 0;
            int.TryParse(this.gvAdvanceApplicationDetail.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
            var row = this.gvAdvanceApplicationDetail.Rows[e.NewEditIndex];
            var xMProductDetails = base.XMCombinationDetailsService.GetXMProductDetailsById(Id);

            //暂支类型
            CodeControl ccPlatformTypeId = (CodeControl)row.FindControl("ccPlatformTypeId");
            ccPlatformTypeId.SelectedValue = xMProductDetails.PlatformTypeId.Value;

            //领/还款类型
            CodeControl ccProductTypeId = (CodeControl)row.FindControl("ccProductTypeId");
            ccProductTypeId.SelectedValue = xMProductDetails.ProductTypeId.Value;
              

        }

        protected void gvAdvanceApplicationDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            BindGrid();
        }

        protected void gvAdvanceApplicationDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row = this.gvAdvanceApplicationDetail.Rows[e.RowIndex];
            decimal d = 0;
            var ccPlatformTypeId = row.FindControl("ccPlatformTypeId") as CodeControl;
            SimpleTextBox txtPlatformMerchantCode = row.FindControl("txtPlatformMerchantCode") as SimpleTextBox;
            var hfPlatformMerchantCode = row.FindControl("hfPlatformMerchantCode") as HiddenField;

            var ccProductTypeId = row.FindControl("ccProductTypeId") as CodeControl;
            TextBox txtPlatformInventory = row.FindControl("txtPlatformInventory") as TextBox;
            SimpleTextBox txtstrUrl = row.FindControl("txtstrUrl") as SimpleTextBox;
            SimpleTextBox txtCostprice = row.FindControl("txtCostprice") as SimpleTextBox;
            SimpleTextBox txtSaleprice = row.FindControl("txtSaleprice") as SimpleTextBox; 
            var txtTCostprice = row.FindControl("txtTCostprice") as TextBox;
            var lblTCostpriceVaule = row.FindControl("lblTCostpriceVaule") as Label; 
            var txtTDateTimeStart = row.FindControl("txtTDateTimeStart") as HtmlInputText; 
            var txtTDateTimeEnd = row.FindControl("txtTDateTimeEnd") as HtmlInputText; 
            var lblTDateTimeStartValue = row.FindControl("lblTDateTimeStartValue") as Label;
            var lblTDateTimeEndValue = row.FindControl("lblTDateTimeEndValue") as Label;
            lblTDateTimeStartValue.Text = "";
            lblTDateTimeEndValue.Text = "";
            lblTCostpriceVaule.Text = "";
            if (!decimal.TryParse(txtTCostprice.Text.Trim(), out d))
            {
                if (txtTCostprice.Text.Trim() != "")
                    lblTCostpriceVaule.Text = "请输入正确的数值";
            }
            if (txtTCostprice.Text != "")
            {
                if (txtTDateTimeStart.Value.ToString() == "" || txtTDateTimeEnd.Value.ToString() == "")
                {
                    lblTDateTimeStartValue.Text = "请输入开始日期";
                    lblTDateTimeEndValue.Text = "请输入结束日期";
                }
            }
            var chkIsMainPush = row.FindControl("chkIsMainPush") as CheckBox; 
            if ( lblTDateTimeStartValue.Text != "" || lblTDateTimeEndValue.Text != "")
            {
                return;
            }
              
            int QID = Convert.ToInt32(gvAdvanceApplicationDetail.DataKeys[e.RowIndex].Value.ToString()); 
            XMCombinationDetails  xMProductDetails= base.XMCombinationDetailsService.GetXMProductDetailsById(QID);


            List<XMCombinationDetails> xMProductDetailsCodeList = null;

            if (txtPlatformMerchantCode.Text.Trim() != "") {

                xMProductDetailsCodeList = base.XMCombinationDetailsService.GetXMProductDetailsByPlatformMerchantCode(txtPlatformMerchantCode.Text.Trim(), ccPlatformTypeId.SelectedValue); 
            }
             
            if (xMProductDetails ==null) //新增
            {
                if (xMProductDetailsCodeList != null)
                {
                    if (xMProductDetailsCodeList.Count > 0)
                    {
                        base.ShowMessage("商品编码已存在");
                        return; 
                    }
                }

                XMCombinationDetails xMProductDetailsNew = new XMCombinationDetails();

                xMProductDetailsNew.ProductId = this.ProductId;
                xMProductDetailsNew.PlatformTypeId = ccPlatformTypeId.SelectedValue;
                xMProductDetailsNew.PlatformMerchantCode = txtPlatformMerchantCode.Text.Trim();
                xMProductDetailsNew.ProductTypeId = ccProductTypeId.SelectedValue;

                if (txtPlatformInventory.Text != "")
                {
                    xMProductDetailsNew.PlatformInventory = Convert.ToInt32(txtPlatformInventory.Text.Trim());
                }
                xMProductDetailsNew.strUrl = txtstrUrl.Text.Trim();

                decimal paramparse1 = 0;
                if (decimal.TryParse(txtCostprice.Text.Trim(), out paramparse1))
                {
                    xMProductDetailsNew.Costprice = Convert.ToDecimal(txtCostprice.Text.Trim());
                }
                else
                {
                    xMProductDetailsNew.Costprice = 0;
                }
                if (decimal.TryParse(txtSaleprice.Text.Trim(), out paramparse1))
                {
                    xMProductDetailsNew.Saleprice = Convert.ToDecimal(txtSaleprice.Text.Trim());
                }
                else
                {
                    xMProductDetailsNew.Saleprice = 0;
                }
                if (txtTCostprice.Text != "")
                {
                    if (txtTDateTimeStart.Value.ToString() != "" || txtTDateTimeEnd.Value.ToString() != "")
                    {
                        xMProductDetailsNew.TCostprice = Convert.ToDecimal(txtTCostprice.Text.Trim());
                        xMProductDetailsNew.TDateTimeStart = Convert.ToDateTime(txtTDateTimeStart.Value);
                        xMProductDetailsNew.TDateTimeEnd = Convert.ToDateTime(txtTDateTimeEnd.Value).AddDays(+1).AddMinutes(-1);
                    }
                }
                xMProductDetailsNew.IsMainPush = chkIsMainPush.Checked;
                xMProductDetailsNew.IsEnable = false;
                xMProductDetailsNew.CreateID = HozestERPContext.Current.User.CustomerID;
                xMProductDetailsNew.CreateDate = DateTime.Now;
                xMProductDetailsNew.UpdateID = HozestERPContext.Current.User.CustomerID;
                xMProductDetailsNew.UpdateDate = DateTime.Now;

                base.XMCombinationDetailsService.InsertXMCombinationDetails(xMProductDetailsNew);
            }
            else //修改
            {

                if (xMProductDetailsCodeList != null)
                {
                    if (xMProductDetailsCodeList.Count > 0)
                    {
                        if (!txtPlatformMerchantCode.Text.Trim().Equals(hfPlatformMerchantCode.Value))
                        {
                            base.ShowMessage("商品编码已存在");
                            return;
                        }
                    }
                }

                xMProductDetails.PlatformTypeId = ccPlatformTypeId.SelectedValue;
                xMProductDetails.PlatformMerchantCode = txtPlatformMerchantCode.Text.Trim();
                xMProductDetails.ProductTypeId = ccProductTypeId.SelectedValue;
                if (txtPlatformInventory.Text != "")
                {
                    xMProductDetails.PlatformInventory = Convert.ToInt32(txtPlatformInventory.Text.Trim());
                }
                xMProductDetails.strUrl = txtstrUrl.Text.Trim();

                decimal paramparse1 = 0;
                if (decimal.TryParse(txtCostprice.Text.Trim(), out paramparse1))
                {
                    xMProductDetails.Costprice = Convert.ToDecimal(txtCostprice.Text.Trim());
                }
                else
                {
                    xMProductDetails.Costprice = 0;
                }
                if (decimal.TryParse(txtSaleprice.Text.Trim(), out paramparse1))
                {
                    xMProductDetails.Saleprice = Convert.ToDecimal(txtSaleprice.Text.Trim());
                }
                else
                {
                    xMProductDetails.Saleprice = 0;
                }
                if (txtTCostprice.Text != "")
                {
                    if (txtTDateTimeStart.Value.ToString() != "" || txtTDateTimeEnd.Value.ToString() != "")
                    {
                        xMProductDetails.TCostprice = Convert.ToDecimal(txtTCostprice.Text.Trim());
                        xMProductDetails.TDateTimeStart = Convert.ToDateTime(txtTDateTimeStart.Value);
                        xMProductDetails.TDateTimeEnd = Convert.ToDateTime(txtTDateTimeEnd.Value).AddDays(+1).AddMinutes(-1);
                    }
                }

                xMProductDetails.IsMainPush = chkIsMainPush.Checked;
                xMProductDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                xMProductDetails.UpdateDate = DateTime.Now;
                base.XMCombinationDetailsService.UpdateXMCombinationDetails(xMProductDetails);

            }
            //重新绑定
            this.RowEditIndex = -1;
            BindGrid();
        }

        protected void gvAdvanceApplicationDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int QID = Convert.ToInt32(gvAdvanceApplicationDetail.DataKeys[e.RowIndex].Value.ToString());

            var xMProductDetails = base.XMCombinationDetailsService.GetXMCombinationDetailsById(QID);
            if (xMProductDetails != null)
            {
                xMProductDetails.IsEnable = true;
                xMProductDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                xMProductDetails.UpdateDate = DateTime.Now;
                base.XMCombinationDetailsService.UpdateXMCombinationDetails(xMProductDetails);
            } 
            //重新绑定
            this.RowEditIndex = -1;
            BindGrid();
        }


        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId
        {
            get
            {
                return Convert.ToInt32(Request.Params["ProductId"]);
            }
        }


    }
}