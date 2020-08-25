using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageProject;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using HozestERP.BusinessLogic; 

namespace HozestERP.Web.ManageProject
{ 
     
    public partial class XMDeliveryDetailsManage : BaseAdministrationPage, IEditPage
    {
        /// <summary>
        /// 按钮 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnEdit", "ManageProject.XMDeliveryDetailsManage.Edit"); //明细编辑
                buttons.Add("imgBtnDelete", "ManageProject.XMDeliveryDetailsManage.Delete"); //明细删除
                buttons.Add("imgBtnUpdate", "ManageProject.XMDeliveryDetailsManage.Save"); //明细保存
                buttons.Add("imgBtnCancel", "ManageProject.XMDeliveryDetailsManage.Cancel"); //明细取消

                return buttons;
            }
        }
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        public void loadDate()
        {
            if (this.DeliveryId > 0)
            {
              HozestERP.BusinessLogic.ManageProject.XMDelivery   xMDelivery = base.XMDeliveryService.GetXMDeliveryById(this.DeliveryId);

                if (xMDelivery != null)
                {
                   // this.lblOrderCode.Text = xMDelivery.OrderCode;
                    this.lblDeliveryNumber.Text = xMDelivery.DeliveryNumber;
                }
            }

            BindGrid();
        }

        /// <summary>
        /// 从表
        /// </summary> 
        public void BindGrid()
        {
            //刷单申请明细信息

            List<XMDeliveryDetails> xMDeliveryDetailsList = new List<XMDeliveryDetails>();
            HozestERP.BusinessLogic.ManageProject.XMDelivery  xMDelivery= null;
            if (this.DeliveryId > 0)
            {
                //明细
                xMDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsByDeliveryId(this.DeliveryId);
                //主表信息
                xMDelivery = base.XMDeliveryService.GetXMDeliveryById(this.DeliveryId);
            }
           // 运营审核通过的赠品申请单 赠品明细不允许新增、修改、删除
            if (xMDelivery != null)
            {
                if (xMDelivery.IsDelivery.Value == true)
                {
                    this.grdXMDeliveryDetailsManage.EditIndex = this.RowEditIndex;
                }
                else
                {
                    //if (this.RowEditIndex == -1)
                    //{
                    //    this.grdXMDeliveryDetailsManage.EditIndex = xMDeliveryDetailsList.Count();
                    //    xMDeliveryDetailsList.Add(new XMDeliveryDetails()); //新增编辑行
                    //}
                    //else
                    //{
                        this.grdXMDeliveryDetailsManage.EditIndex = this.RowEditIndex;
                    //}
                }
            }
            else
            {
                //if (this.RowEditIndex == -1)
                //{
                //    this.grdXMDeliveryDetailsManage.EditIndex = xMDeliveryDetailsList.Count();
                //    xMDeliveryDetailsList.Add(new XMDeliveryDetails()); //新增编辑行
                //}
                //else
                //{
                    this.grdXMDeliveryDetailsManage.EditIndex = this.RowEditIndex;
                //}

            }
            this.grdXMDeliveryDetailsManage.DataSource = xMDeliveryDetailsList;
            this.grdXMDeliveryDetailsManage.DataBind();
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
         
        protected void grdXMDeliveryDetailsManage_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            HozestERP.BusinessLogic.ManageProject.XMDelivery xMDelivery = new BusinessLogic.ManageProject.XMDelivery();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                  
                //编辑按钮
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                //删除按钮
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;

                //财务审核通过 不显示编辑按钮、删除按钮

                if (xMDelivery != null)
                {
                    if (xMDelivery.IsDelivery==true)
                    {
                        if (imgBtnEdit != null && imgBtnDelete != null)
                        {
                            imgBtnEdit.Visible = false;
                            imgBtnDelete.Visible = false;
                        }
                    }
                    else
                    {
                        if (imgBtnEdit != null && imgBtnDelete != null)
                        {
                            imgBtnEdit.Visible = true;
                            imgBtnDelete.Visible = true;
                        }
                    }
                }
                else
                {
                    if (imgBtnEdit != null && imgBtnDelete != null)
                    {
                        imgBtnEdit.Visible = false;
                        imgBtnDelete.Visible = false;
                    }
                }
            }


            if (e.Row.RowState == DataControlRowState.Edit ||
                         (e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit)))
            {
                SimpleTextBox txtProductNum = e.Row.FindControl("txtProductNum") as SimpleTextBox;
                if (txtProductNum != null)
                {
                    if (txtProductNum.Text == "")
                    {
                        txtProductNum.Text = "1";
                    }
                }

            }
        }

        protected void grdXMDeliveryDetailsManage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            BindGrid();
            //int Id = 0;
            //int.TryParse(this.grdXMDeliveryDetailsManage.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
            //var row = this.grdXMDeliveryDetailsManage.Rows[e.NewEditIndex];
            //var premiumsDetails = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(Id);
            //if (premiumsDetails != null)
            //{
            //    //商品Id
            //    HtmlInputHidden hfProductId = (HtmlInputHidden)row.FindControl("hfProductId");
            //    if (hfProductId != null)
            //    {
            //        hfProductId.Value = premiumsDetails.ProductDetaislId != null ? premiumsDetails.ProductDetaislId.Value.ToString() : "-1";
            //    }
            //    //商品名称
            //    HtmlInputText txtProductName = (HtmlInputText)row.FindControl("txtProductName");

            //    if (txtProductName != null)
            //    {
            //        txtProductName.Value = premiumsDetails.PrdouctName;
            //    }
            //    //尺寸
            //    TextBox txtEditSpecifications = (TextBox)row.FindControl("txtEditSpecifications");

            //    if (premiumsDetails.ProductDetaislId != null)
            //    {
            //        var product = base.XMProductService.GetXMProductById(premiumsDetails.ProductDetaislId.Value);
            //        if (product != null)
            //        {
            //            //尺寸 
            //            if (txtEditSpecifications != null)
            //            {
            //                txtEditSpecifications.Text = product.Specifications;
            //            }
            //        }
            //    }

            //}


            ScriptManager.RegisterStartupScript(this.grdXMDeliveryDetailsManage, this.Page.GetType(), "xmdeliverydetailsmanage", "autoCompleteBind()", true);

        }

        protected void grdXMDeliveryDetailsManage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            BindGrid();
            ScriptManager.RegisterStartupScript(this.grdXMDeliveryDetailsManage, this.Page.GetType(), "xmdeliverydetailsmanage", "autoCompleteBind()", true);
        }

        protected void grdXMDeliveryDetailsManage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //商品Id
            var hfProductId = this.grdXMDeliveryDetailsManage.Rows[e.RowIndex].FindControl("hfProductId") as HtmlInputHidden;
            //商品名称
            var txtProductName = this.grdXMDeliveryDetailsManage.Rows[e.RowIndex].FindControl("txtProductName") as HtmlInputText;
            //商品编码
            var txtPlatformMerchantCode = this.grdXMDeliveryDetailsManage.Rows[e.RowIndex].FindControl("txtPlatformMerchantCode") as TextBox; 
            //数量
            var txtProductNum = this.grdXMDeliveryDetailsManage.Rows[e.RowIndex].FindControl("txtProductNum") as SimpleTextBox;
            //尺寸
            var txtEditSpecifications = this.grdXMDeliveryDetailsManage.Rows[e.RowIndex].FindControl("txtEditSpecifications") as TextBox;  

            int keyID = 0;
            int.TryParse(e.Keys[0].ToString(), out keyID);
            var deliveryDetails = base.XMDeliveryDetailsService.GetXMDeliveryDetailsById(keyID);
            if (deliveryDetails == null)
            {
                #region 赠品明细新增
                int productId = 0;
                int.TryParse(hfProductId.Value, out productId);
                var Product = base.XMProductService.GetXMProductById(productId);
                if (Product == null)
                {
                    hfProductId.Value = "";
                    txtProductName.Value = "";
                    txtPlatformMerchantCode.Text = ""; 
                    txtEditSpecifications.Text = "";
                    this.Master.ShowMessage("商品名称有误.");
                    ScriptManager.RegisterStartupScript(this.grdXMDeliveryDetailsManage, this.Page.GetType(), "xmdeliverydetailsmanage", "autoCompleteBind()", true);
                    return;
                }
                deliveryDetails = new XMDeliveryDetails();
                deliveryDetails.DeliveryId = this.DeliveryId;
                deliveryDetails.ProductlId = Convert.ToInt32(hfProductId.Value);
                deliveryDetails.PlatformMerchantCode = txtPlatformMerchantCode.Text;
                deliveryDetails.PrdouctName = txtProductName.Value;
                deliveryDetails.Specifications = txtEditSpecifications.Text;
                deliveryDetails.ProductNum = Convert.ToInt32(txtProductNum.Text);
                deliveryDetails.IsEnabled = false;
                deliveryDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                deliveryDetails.CreateDate = DateTime.Now;
                deliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                deliveryDetails.UpdateDate = DateTime.Now;
                base.XMDeliveryDetailsService.InsertXMDeliveryDetails(deliveryDetails);

                #endregion
            }
            else
            {

                int productId = 0;
                int.TryParse(hfProductId.Value, out productId);
                var Product = base.XMProductService.GetXMProductById(productId);
                if (Product == null)
                {
                    hfProductId.Value = "";
                    txtProductName.Value = "";
                    txtPlatformMerchantCode.Text = ""; 
                    txtEditSpecifications.Text = "";
                    this.Master.ShowMessage("商品名称有误.");
                    ScriptManager.RegisterStartupScript(this.grdXMDeliveryDetailsManage, this.Page.GetType(), "xmdeliverydetailsmanage", "autoCompleteBind()", true);
                    return;
                }

                deliveryDetails.ProductlId = Convert.ToInt32(hfProductId.Value);
                deliveryDetails.PlatformMerchantCode = txtPlatformMerchantCode.Text;
                deliveryDetails.PrdouctName = txtProductName.Value;
                deliveryDetails.Specifications = txtEditSpecifications.Text;
                deliveryDetails.ProductNum = Convert.ToInt32(txtProductNum.Text);
                deliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                deliveryDetails.UpdateDate = DateTime.Now;
                base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(deliveryDetails);
                  
            }
            this.RowEditIndex = -1;
            this.Master.JsWrite("alert('保存成功！')", "");
            this.BindGrid();
            ScriptManager.RegisterStartupScript(this.grdXMDeliveryDetailsManage, this.Page.GetType(), "xmdeliverydetailsmanage", "autoCompleteBind()", true);
        }

        protected void grdXMDeliveryDetailsManage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int QID = Convert.ToInt32(grdXMDeliveryDetailsManage.DataKeys[e.RowIndex].Value.ToString());

            var xeliveryDetails = base.XMDeliveryDetailsService.GetXMDeliveryDetailsById(QID);
            if (xeliveryDetails != null)
            {
                xeliveryDetails.IsEnabled = true;
                xeliveryDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                xeliveryDetails.UpdateDate = DateTime.Now;
                base.XMDeliveryDetailsService.UpdateXMDeliveryDetails(xeliveryDetails);
            }

            //重新绑定
            this.RowEditIndex = -1;
            this.Master.JsWrite("alert('操作成功！')", "");
            BindGrid();
            ScriptManager.RegisterStartupScript(this.grdXMDeliveryDetailsManage, this.Page.GetType(), "xmdeliverydetailsmanage", "autoCompleteBind()", true);
        }


        /// <summary>
        /// 发货单主表Id
        /// </summary>
        public int DeliveryId
        {
            get
            {
                return CommonHelper.QueryStringInt("DeliveryId");
            }
        }

    }
}