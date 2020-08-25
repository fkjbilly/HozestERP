using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Web.Modules;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace HozestERP.Web.ManageProject
{
    public partial class XMProductDetailsManage : BaseAdministrationPage, IEditPage
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
                    XMProduct xMProduct = base.XMProductService.GetXMProductById(this.ProductId);

                    if (xMProduct != null)
                    {
                        this.lblBrandTypeId.Text = xMProduct.BrandTypeCodeName != null ? xMProduct.BrandTypeCodeName : "";
                        this.lblProductName.Text = xMProduct.ProductName != null ? xMProduct.ProductName : "";
                        this.lblManufacturersCode.Text = xMProduct.ManufacturersCode != null ? xMProduct.ManufacturersCode : "";
                        this.lblSpecifications.Text = xMProduct.Specifications != null ? xMProduct.Specifications : "";
                        this.lblManufacturersInventory.Text = xMProduct.ManufacturersInventory != null ? xMProduct.ManufacturersInventory.Value.ToString() : "";
                        this.lblWarningQuantity.Text = xMProduct.WarningQuantity != null ? xMProduct.WarningQuantity.Value.ToString() : "";
                        this.lblProductColors.Text = xMProduct.ProductColors != null ? xMProduct.ProductColors : "";
                        this.lblProductUnit.Text = xMProduct.ProductUnit != null ? xMProduct.ProductUnit : "";
                        if (xMProduct.IsPremiums != null)
                        {
                            this.ckbIsPremiums.Checked = xMProduct.IsPremiums.Value;
                        }

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
            List<XMProductDetails> productDetailsList = base.XMProductDetailsService.GetXMProductDetailsListByProductId(this.ProductId);

            if (this.RowEditIndex == -1)
            {
                this.gvAdvanceApplicationDetail.EditIndex = productDetailsList.Count();
                productDetailsList.Add(new XMProductDetails()); //新增编辑行
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
            }
        }

        protected void gv_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                GridViewRow row = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                int QID = Convert.ToInt32(gvAdvanceApplicationDetail.DataKeys[row.DataItemIndex].Value.ToString());
                XMProductDetails xMProductDetails = base.XMProductDetailsService.GetXMProductDetailsById(QID);

                xMProductDetails.MinPrice = xMProductDetails.UnauditMinPrice;
                XMProductDetailsService.UpdateXMProductDetails(xMProductDetails);

                BindGrid();
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="ManufacturersCode">厂家编码</param>
        /// <param name="platformTypeName">平台类型</param>
        private void sendMail(string ManufacturersCode, string platformTypeName)
        {
            var setting = SettingManager.GetSettingByName("mail");
            if(setting!=null)
            {
                //创建一个邮件对像
                MailMessage mailObject = new MailMessage();
                //设置发件人
                mailObject.From = new MailAddress("fate987731237@163.com");
                //设置收件人
                mailObject.To.Add(new MailAddress(setting.Value));
                //设置邮件主题
                mailObject.SubjectEncoding = Encoding.UTF8;
                mailObject.Subject = "商品最低售价变动提醒";

                mailObject.BodyEncoding = Encoding.UTF8;//编码
                mailObject.Body = "厂家编码： "+ ManufacturersCode+" 平台类型： "+ platformTypeName;

                //创建一个发送邮件的对像 服务地址和端口
                SmtpClient smtpClient = new SmtpClient("smtp.163.com", 25);
                //帐号密码一定要正确
                smtpClient.Credentials = new NetworkCredential("fate987731237@163.com", "cx3094311");
                smtpClient.Send(mailObject);
            }
            //MessageBox.Show("ok");

        }

        protected void gvAdvanceApplicationDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            BindGrid();

            int Id = 0;
            int.TryParse(this.gvAdvanceApplicationDetail.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
            var row = this.gvAdvanceApplicationDetail.Rows[e.NewEditIndex];
            var xMProductDetails = base.XMProductDetailsService.GetXMProductDetailsById(Id);

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
            int id = (int)this.gvAdvanceApplicationDetail.DataKeys[e.RowIndex].Value;
            var row = this.gvAdvanceApplicationDetail.Rows[e.RowIndex];
            decimal d = 0;
            var ccPlatformTypeId = row.FindControl("ccPlatformTypeId") as CodeControl;
            SimpleTextBox txtPlatformMerchantCode = row.FindControl("txtPlatformMerchantCode") as SimpleTextBox;
            var hfPlatformMerchantCode = row.FindControl("hfPlatformMerchantCode") as HiddenField;

            var ccProductTypeId = row.FindControl("ccProductTypeId") as CodeControl;
            TextBox txtPlatformInventory = row.FindControl("txtPlatformInventory") as TextBox;
            TextBox txtColor = row.FindControl("txtColor") as TextBox;//颜色
            TextBox txtTManufacturersCode = row.FindControl("txtTemporaryManufacturersCode") as TextBox;//临时厂家编码
            SimpleTextBox txtstrUrl = row.FindControl("txtstrUrl") as SimpleTextBox;
            SimpleTextBox txtCostprice = row.FindControl("txtCostprice") as SimpleTextBox;
            SimpleTextBox txtSaleprice = row.FindControl("txtSaleprice") as SimpleTextBox;
            var txtUnauditMinPrice = row.FindControl("txtUnauditMinPrice") as TextBox;
            var txtTCostprice = row.FindControl("txtTCostprice") as TextBox;
            var lblTCostpriceVaule = row.FindControl("lblTCostpriceVaule") as Label;
            var txtTDateTimeStart = row.FindControl("txtTDateTimeStart") as HtmlInputText;
            var txtTDateTimeEnd = row.FindControl("txtTDateTimeEnd") as HtmlInputText;
            var lblTDateTimeStartValue = row.FindControl("lblTDateTimeStartValue") as Label;
            var lblTDateTimeEndValue = row.FindControl("lblTDateTimeEndValue") as Label;
            lblTDateTimeStartValue.Text = "";
            lblTDateTimeEndValue.Text = "";
            lblTCostpriceVaule.Text = "";

            if (!string.IsNullOrEmpty(txtTManufacturersCode.Text.Trim()))
            {
                var productList = base.XMProductDetailsService.GetXMProductListByManufacturersCode(txtTManufacturersCode.Text.Trim(), ccPlatformTypeId.SelectedValue);
                if (productList != null && productList.Count > 0)
                {
                    if (productList[0].Id != id)
                    {
                        base.ShowMessage("该厂家编码已存在！");
                        return;
                    }
                }
            }

            //同平台，同厂家编码只能有一条记录
            var XMProductDetailsList = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(txtPlatformMerchantCode.Text.Trim(), int.Parse(ccPlatformTypeId.SelectedValue.ToString()), "");
            if (XMProductDetailsList != null && XMProductDetailsList.Count > 0)
            {
                if (XMProductDetailsList.Count != 1 || id != XMProductDetailsList[0].Id)
                {
                    base.ShowMessage("该平台该商品编码已存在！");
                    return;
                }
            }

            if (!decimal.TryParse(txtTCostprice.Text.Trim(), out d))
            {
                if (txtTCostprice.Text.Trim() != "")
                    lblTCostpriceVaule.Text = "请输入正确的数值！";
            }
            if (txtTCostprice.Text != "")
            {
                if (txtTDateTimeStart.Value.ToString() == "" || txtTDateTimeEnd.Value.ToString() == "")
                {
                    lblTDateTimeStartValue.Text = "请输入开始日期！";
                    lblTDateTimeEndValue.Text = "请输入结束日期！";
                }
            }
            var chkIsMainPush = row.FindControl("chkIsMainPush") as CheckBox;
            if (lblTDateTimeStartValue.Text != "" || lblTDateTimeEndValue.Text != "")
            {
                return;
            }

            int QID = Convert.ToInt32(gvAdvanceApplicationDetail.DataKeys[e.RowIndex].Value.ToString());
            XMProductDetails xMProductDetails = base.XMProductDetailsService.GetXMProductDetailsById(QID);
            List<XMProductDetails> xMProductDetailsCodeList = null;

            if (txtPlatformMerchantCode.Text.Trim() != "")
            {
                xMProductDetailsCodeList = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(txtPlatformMerchantCode.Text.Trim(), ccPlatformTypeId.SelectedValue, txtColor.Text.Trim());
            }

            if (xMProductDetails == null) //新增
            {
                if (xMProductDetailsCodeList != null)
                {
                    if (xMProductDetailsCodeList.Count > 0)
                    {
                        base.ShowMessage("商品编码已存在！");
                        return;
                    }
                }

                XMProductDetails xMProductDetailsNew = new XMProductDetails();

                xMProductDetailsNew.ProductId = this.ProductId;
                xMProductDetailsNew.PlatformTypeId = ccPlatformTypeId.SelectedValue;
                xMProductDetailsNew.PlatformMerchantCode = txtPlatformMerchantCode.Text.Trim();
                xMProductDetailsNew.ProductTypeId = ccProductTypeId.SelectedValue;

                if (txtPlatformInventory.Text != "")
                {
                    xMProductDetailsNew.PlatformInventory = Convert.ToInt32(txtPlatformInventory.Text.Trim());
                }

                if (txtColor.Text != "")
                {
                    xMProductDetailsNew.Color = txtColor.Text.Trim();
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
                if(decimal.TryParse(txtUnauditMinPrice.Text.Trim(),out paramparse1))
                {
                    xMProductDetailsNew.UnauditMinPrice= Convert.ToDecimal(txtUnauditMinPrice.Text.Trim());
                }
                else
                {
                    xMProductDetailsNew.UnauditMinPrice = 0;
                }
                if (txtTCostprice.Text != "" || txtTManufacturersCode.Text.Trim() != "")
                {
                    if (txtTDateTimeStart.Value.ToString() != "" && txtTDateTimeEnd.Value.ToString() != "")
                    {
                        if (txtTCostprice.Text != "")
                        {
                            xMProductDetailsNew.TCostprice = Convert.ToDecimal(txtTCostprice.Text.Trim());
                        }
                        else
                        {
                            xMProductDetailsNew.TCostprice = null;
                        }
                        if (txtTManufacturersCode.Text.Trim() != "")
                        {
                            xMProductDetailsNew.TemporaryManufacturersCode = txtTManufacturersCode.Text.Trim();//临时厂家编码
                        }
                        else
                        {
                            xMProductDetailsNew.TemporaryManufacturersCode = "";
                        }

                        xMProductDetailsNew.TDateTimeStart = Convert.ToDateTime(txtTDateTimeStart.Value);
                        xMProductDetailsNew.TDateTimeEnd = Convert.ToDateTime(txtTDateTimeEnd.Value).AddDays(+1).AddMinutes(-1);
                    }
                    else
                    {
                        base.ShowMessage("开始时间或结束时间不能为空！");
                        return;
                    }
                }
                else
                {
                    xMProductDetailsNew.TCostprice = null;
                    xMProductDetailsNew.TemporaryManufacturersCode = "";
                    xMProductDetailsNew.TDateTimeStart = null;
                    xMProductDetailsNew.TDateTimeEnd = null;
                }

                xMProductDetailsNew.IsMainPush = chkIsMainPush.Checked;
                xMProductDetailsNew.IsEnable = false;
                xMProductDetailsNew.CreateID = HozestERPContext.Current.User.CustomerID;
                xMProductDetailsNew.CreateDate = DateTime.Now;
                xMProductDetailsNew.UpdateID = HozestERPContext.Current.User.CustomerID;
                xMProductDetailsNew.UpdateDate = DateTime.Now;

                base.XMProductDetailsService.InsertXMProductDetails(xMProductDetailsNew);

                if (xMProductDetails != null)
                {
                    decimal minPrice = xMProductDetails.MinPrice == null ? 0 : (decimal)xMProductDetails.MinPrice;
                    decimal unauditMinPrice = xMProductDetails.UnauditMinPrice == null ? 0 : (decimal)xMProductDetails.UnauditMinPrice;
                    if (minPrice != unauditMinPrice)
                    {
                        sendMail(xMProductDetailsNew.ManufacturersCode, xMProductDetailsNew.PlatformTypeName.CodeName);
                    }
                }
            }
            else //修改
            {
                if (xMProductDetailsCodeList != null)
                {
                    if (xMProductDetailsCodeList.Count > 0)
                    {
                        if (xMProductDetailsCodeList[0].Id != QID)//if (!txtPlatformMerchantCode.Text.Trim().Equals(hfPlatformMerchantCode.Value))
                        {
                            base.ShowMessage("商品编码已存在！");
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
                xMProductDetails.Color = txtColor.Text.Trim();

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
                if (decimal.TryParse(txtUnauditMinPrice.Text.Trim(), out paramparse1))
                {
                    xMProductDetails.UnauditMinPrice = Convert.ToDecimal(txtUnauditMinPrice.Text.Trim());
                }
                else
                {
                    xMProductDetails.UnauditMinPrice = 0;
                }
                if (txtTCostprice.Text != "" || txtTManufacturersCode.Text.Trim() != "")
                {
                    if (txtTDateTimeStart.Value.ToString() != "" || txtTDateTimeEnd.Value.ToString() != "")
                    {
                        if (txtTCostprice.Text != "")
                        {
                            xMProductDetails.TCostprice = Convert.ToDecimal(txtTCostprice.Text.Trim());
                        }
                        else
                        {
                            xMProductDetails.TCostprice = null;
                        }
                        if (txtTManufacturersCode.Text.Trim() != "")
                        {
                            xMProductDetails.TemporaryManufacturersCode = txtTManufacturersCode.Text.Trim();//临时厂家编码
                        }
                        else
                        {
                            xMProductDetails.TemporaryManufacturersCode = "";
                        }

                        xMProductDetails.TDateTimeStart = Convert.ToDateTime(txtTDateTimeStart.Value);
                        xMProductDetails.TDateTimeEnd = Convert.ToDateTime(txtTDateTimeEnd.Value).AddDays(+1).AddMinutes(-1);
                    }
                    else
                    {
                        base.ShowMessage("开始时间或结束时间不能为空！");
                        return;
                    }
                }
                else
                {
                    xMProductDetails.TCostprice = null;
                    xMProductDetails.TemporaryManufacturersCode = "";
                    xMProductDetails.TDateTimeStart = null;
                    xMProductDetails.TDateTimeEnd = null;
                }

                xMProductDetails.IsMainPush = chkIsMainPush.Checked;
                xMProductDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                xMProductDetails.UpdateDate = DateTime.Now;
                base.XMProductDetailsService.UpdateXMProductDetails(xMProductDetails);

                decimal minPrice = xMProductDetails.MinPrice == null ? 0 : (decimal)xMProductDetails.MinPrice;
                decimal unauditMinPrice = xMProductDetails.UnauditMinPrice == null ? 0 : (decimal)xMProductDetails.UnauditMinPrice;
                if (minPrice != unauditMinPrice)
                {
                    sendMail(xMProductDetails.ManufacturersCode, xMProductDetails.PlatformTypeName.CodeName);
                }
            }
            //重新绑定
            this.RowEditIndex = -1;
            BindGrid();
        }

        protected void gvAdvanceApplicationDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int QID = Convert.ToInt32(gvAdvanceApplicationDetail.DataKeys[e.RowIndex].Value.ToString());

            var xMProductDetails = base.XMProductDetailsService.GetXMProductDetailsById(QID);
            if (xMProductDetails != null)
            {
                xMProductDetails.IsEnable = true;
                xMProductDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                xMProductDetails.UpdateDate = DateTime.Now;
                base.XMProductDetailsService.UpdateXMProductDetails(xMProductDetails);
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