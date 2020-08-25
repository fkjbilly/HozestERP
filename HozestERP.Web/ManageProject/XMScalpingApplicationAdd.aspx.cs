using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;

namespace HozestERP.Web.ManageProject
{  
     
    public partial class XMScalpingApplicationAdd : BaseAdministrationPage, IEditPage
    {
        /// <summary>
        /// 按钮 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            { 
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnSave", "ManageProject.XMScalpingApplicationAdd.Save"); //保存
                buttons.Add("imgBtnEdit", "ManageProject.XMScalpingApplicationAddDetails.Edit"); //明细编辑
                buttons.Add("imgBtnDelete", "ManageProject.XMScalpingApplicationAddDetails.Delete"); //明细删除
                buttons.Add("imgBtnUpdate", "ManageProject.XMScalpingApplicationAddDetails.Save"); //明细保存
                buttons.Add("imgBtnCancel", "ManageProject.XMScalpingApplicationAddDetails.Cancel"); //明细取消

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

            if (this.NewScalpingId != "" && this.NewScalpingId != null)
            {
                if (Convert.ToInt32( this.NewScalpingId) > 0)
                {
                    var xMScalpingApplication = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(Convert.ToInt32(this.NewScalpingId));

                    if (xMScalpingApplication != null)
                    {
                        this.ddPlatformTypeId.SelectedValue = xMScalpingApplication.PlatformTypeId.ToString();
                        this.ddNickId.SelectedValue = xMScalpingApplication.NickId != null ? xMScalpingApplication.NickId.Value.ToString() : "-1";
                        this.lblScalpingNo.Text = xMScalpingApplication.ScalpingCode != null ? xMScalpingApplication.ScalpingCode : "";
                        this.txtScalpingBeginTime.Value = xMScalpingApplication.ScalpingBeginTime != null ? xMScalpingApplication.ScalpingBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                        this.txtScalpingEndTime.Value = xMScalpingApplication.ScalpingEndTime != null ? xMScalpingApplication.ScalpingEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                        this.txtExplanation.Text = xMScalpingApplication.Explanation != null ? xMScalpingApplication.Explanation : "";

                        if (xMScalpingApplication.ManagerIsAudit != null)
                        {
                            this.ckbManagerIsAudit.Checked = xMScalpingApplication.ManagerIsAudit.Value;
                        }
                        //部门审核通过 不允许修改
                        if (xMScalpingApplication.ManagerIsAudit != null)
                        {
                            if (xMScalpingApplication.ManagerIsAudit.Value == true)
                            {
                                this.btnSave.Visible = false;
                            }
                            else
                            {

                                this.btnSave.Visible = true;
                            }
                        } 
                    }
                    else
                    {

                        //this.txtScalpingNo.Text = string.Empty;
                        this.txtExplanation.Text = string.Empty;
                    }
                    //this.txtScalpingNo.Visible = true;
                    this.gvScalpingApplicationDetails.Visible = true;
                }
                else
                {
                    //this.txtScalpingNo.Visible = false;
                    this.gvScalpingApplicationDetails.Visible = false;
                    //this.txtScalpingNo.Text = string.Empty;
                    this.txtExplanation.Text = string.Empty;
                }

            }
            else
            {
                if (this.ScalpingId > 0)
                {
                    var xMScalpingApplication = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(this.ScalpingId);

                    if (xMScalpingApplication != null)
                    {
                        this.BoolManagerIsAudit = xMScalpingApplication.ManagerIsAudit != null ? xMScalpingApplication.ManagerIsAudit.Value : false;
                        this.ddPlatformTypeId.SelectedValue = xMScalpingApplication.PlatformTypeId.ToString();
                        this.ddNickId.SelectedValue = xMScalpingApplication.NickId != null ? xMScalpingApplication.NickId.Value.ToString() : "-1";
                        this.lblScalpingNo.Text = xMScalpingApplication.ScalpingCode != null ? xMScalpingApplication.ScalpingCode : "";
                        this.txtScalpingBeginTime.Value = xMScalpingApplication.ScalpingBeginTime != null ? xMScalpingApplication.ScalpingBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                        this.txtScalpingEndTime.Value = xMScalpingApplication.ScalpingEndTime != null ? xMScalpingApplication.ScalpingEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                        this.txtExplanation.Text = xMScalpingApplication.Explanation != null ? xMScalpingApplication.Explanation : "";
                        if (xMScalpingApplication.ManagerIsAudit != null)
                        {
                            this.ckbManagerIsAudit.Checked = xMScalpingApplication.ManagerIsAudit.Value;
                        }
                        //部门审核通过 不允许修改
                        if (xMScalpingApplication.ManagerIsAudit != null)
                        {
                            if (xMScalpingApplication.ManagerIsAudit.Value == true)
                            {
                                this.btnSave.Visible = false;
                            }
                            else
                            {

                                this.btnSave.Visible = true;
                            }
                        }
                          
                    }
                    else
                    {
                         
                        this.txtExplanation.Text = string.Empty;
                    } 
                    this.gvScalpingApplicationDetails.Visible = true;
                }
                else
                { 
                    this.gvScalpingApplicationDetails.Visible = false; 
                    this.txtExplanation.Text = string.Empty;
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

            List<XMScalpingApplicationDetails> XMScalpingApplicationDetailsList = new List<XMScalpingApplicationDetails>();
            if (this.NewScalpingId != "" && this.NewScalpingId != null)
            {
                if (Convert.ToInt32(this.NewScalpingId) > 0)
                {
                    XMScalpingApplicationDetailsList = base.XMScalpingApplicationDetailsService.GetXMScalpingApplicationDetailsByScalpingIdList(Convert.ToInt32(this.NewScalpingId));
                }
            }
            else
            {
                if (this.ScalpingId > 0)
                {
                    XMScalpingApplicationDetailsList = base.XMScalpingApplicationDetailsService.GetXMScalpingApplicationDetailsByScalpingIdList(this.ScalpingId);
                }
            }
            //部门审核通过 刷单明细不可新增
            if (this.BoolManagerIsAudit == true)
            {
                this.RowEditIndex = XMScalpingApplicationDetailsList.Count();

            } 
            if (this.RowEditIndex == -1)
            {
                this.gvScalpingApplicationDetails.EditIndex = XMScalpingApplicationDetailsList.Count();
                XMScalpingApplicationDetailsList.Add(new XMScalpingApplicationDetails()); //新增编辑行
            }
            else
            {
                this.gvScalpingApplicationDetails.EditIndex = this.RowEditIndex;
            }

            this.gvScalpingApplicationDetails.DataSource = XMScalpingApplicationDetailsList;
            this.gvScalpingApplicationDetails.DataBind();
        }


        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitleTabPanelVisible = false;

            //平台类型动态数据绑定
            this.ddPlatformTypeId.Items.Clear();
            var codePlatformTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddPlatformTypeId.DataSource = codePlatformTypeList;
            this.ddPlatformTypeId.DataTextField = "CodeName";
            this.ddPlatformTypeId.DataValueField = "CodeID";
            this.ddPlatformTypeId.DataBind();


            this.ddNickId.Items.Clear();
            var NickList = base.XMNickService.GetXMNickList();
            var newNickList = NickList.Where(p => p.isEnable == true).ToList();
            this.ddNickId.DataSource = newNickList;
            this.ddNickId.DataTextField = "nick";
            this.ddNickId.DataValueField = "nick_id";
            this.ddNickId.DataBind(); 


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

        protected void gvScalpingApplicationDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                var scalpingApplicationDetails = e.Row.DataItem as XMScalpingApplicationDetails;

                if (scalpingApplicationDetails.ProductId != null)
                { 
                    var Product = base.XMProductService.GetXMProductById(scalpingApplicationDetails.ProductId.Value);
                    if (Product != null)
                    {
                        if (e.Row.RowState == DataControlRowState.Edit || (e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit)))
                        {
                            var txtProductName = e.Row.FindControl("txtProductName") as HtmlInputText;
                            var hfProductId = e.Row.FindControl("hfProductId") as HtmlInputHidden; 
                            txtProductName.Value = Product.ProductName;
                            hfProductId.Value = Product.Id.ToString();
                            txtProductName.Attributes["disabled "] = "disabled ";
                        }
                    }
                } 
                #region 流量缺口=所需流量-自然流量
                Label lblFlowGap = e.Row.FindControl("lblFlowGap") as Label;

                if (scalpingApplicationDetails.RequiredFlow != null && scalpingApplicationDetails.NaturalFlow != null)
                {

                    if (lblFlowGap != null)
                    {
                        lblFlowGap.Text =(Convert.ToDecimal(scalpingApplicationDetails.RequiredFlow)-Convert.ToDecimal(scalpingApplicationDetails.NaturalFlow)).ToString();
                    }
                
                }
                #endregion 
                #region 销售额=（预计成交+预计刷单数量）*客单价

                Label lblSales = e.Row.FindControl("lblSales") as Label;

                if (scalpingApplicationDetails.ForecastDeal != null && scalpingApplicationDetails.ForecastScalpingQuantity != null && scalpingApplicationDetails.CustomerPrice!=null)
                {

                    if (lblSales != null)
                    {
                        int Ivalue = Convert.ToInt32(scalpingApplicationDetails.ForecastDeal) + Convert.ToInt32(scalpingApplicationDetails.ForecastScalpingQuantity);

                        decimal Dvalue = Ivalue * scalpingApplicationDetails.CustomerPrice.Value;

                        lblSales.Text = Dvalue.ToString();
                    }

                }
                #endregion

                #region 部门审核通过 不允许修改
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;  
               
                if (imgBtnEdit != null && imgBtnDelete != null)
                {
                    if (this.BoolManagerIsAudit == true)
                    {
                        imgBtnEdit.Visible = false;
                        imgBtnDelete.Visible = false;
                    }
                    else
                    {
                        imgBtnEdit.Visible = true;
                        imgBtnDelete.Visible = true;
                    }
                }
                #endregion
            }
        }

        protected void gvScalpingApplicationDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

            this.RowEditIndex = e.NewEditIndex;
            BindGrid(); 
            //int Id = 0;
            //int.TryParse(this.gvScalpingApplicationDetails.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
            //var row = this.gvScalpingApplicationDetails.Rows[e.NewEditIndex]; 
            ScriptManager.RegisterStartupScript(this.gvScalpingApplicationDetails, this.Page.GetType(), "xmsalpingApplicationDetails", "autoCompleteBind()", true);

        }

        protected void gvScalpingApplicationDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            BindGrid();
            ScriptManager.RegisterStartupScript(this.gvScalpingApplicationDetails, this.Page.GetType(), "xmsalpingApplicationDetails", "autoCompleteBind()", true);
        }

        protected void gvScalpingApplicationDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var hfProductId = this.gvScalpingApplicationDetails.Rows[e.RowIndex].FindControl("hfProductId") as HtmlInputHidden;
            var txtProductName = this.gvScalpingApplicationDetails.Rows[e.RowIndex].FindControl("txtProductName") as HtmlInputText;
            var txtScalpingTime = this.gvScalpingApplicationDetails.Rows[e.RowIndex].FindControl("txtScalpingTime") as HtmlInputText;

            var lblScalpingTime1 = this.gvScalpingApplicationDetails.Rows[e.RowIndex].FindControl("lblScalpingTime1") as Label;

            var txtRequiredFlow = this.gvScalpingApplicationDetails.Rows[e.RowIndex].FindControl("txtRequiredFlow") as SimpleTextBox;
            var txtNaturalFlow = this.gvScalpingApplicationDetails.Rows[e.RowIndex].FindControl("txtNaturalFlow") as SimpleTextBox; 
            var txtForecastDeal = this.gvScalpingApplicationDetails.Rows[e.RowIndex].FindControl("txtForecastDeal") as SimpleTextBox;
            var txtForecastScalpingQuantity = this.gvScalpingApplicationDetails.Rows[e.RowIndex].FindControl("txtForecastScalpingQuantity") as SimpleTextBox;
            var txtConversionRate = this.gvScalpingApplicationDetails.Rows[e.RowIndex].FindControl("txtConversionRate") as SimpleTextBox;

            var lblConversionRate = this.gvScalpingApplicationDetails.Rows[e.RowIndex].FindControl("lblConversionRate") as Label;
            
            var txtCustomerPrice = this.gvScalpingApplicationDetails.Rows[e.RowIndex].FindControl("txtCustomerPrice") as SimpleTextBox;

            int paramparse = 0;
            lblScalpingTime1.Text = "";
            if (txtScalpingTime.Value.ToString()=="") {

                lblScalpingTime1.Text = "请输入刷单时间";
            }
            lblConversionRate.Text = "";
            if (!int.TryParse(txtConversionRate.Text.Trim(), out paramparse))
                {
                    if (txtConversionRate.Text.Trim() != "")
                        lblConversionRate.Text = "请输入正确的数值";
                }
             
            if (lblScalpingTime1.Text != "" || lblConversionRate.Text != "")
            {
                return;
            }

            int keyID = 0;
            int.TryParse(e.Keys[0].ToString(), out keyID);
            var SAdetails = base.XMScalpingApplicationDetailsService.GetXMScalpingApplicationDetailsByScalpingDetailsId(keyID);
            if (SAdetails == null)
            {
                int productId = 0;
                int.TryParse(hfProductId.Value, out productId);
                var Product = base.XMProductService.GetXMProductById(productId);
                if (Product == null)
                {
                    hfProductId.Value = ""; 
                    txtProductName.Value = "";
                    this.Master.ShowMessage("产品名称有误.");
                    ScriptManager.RegisterStartupScript(this.gvScalpingApplicationDetails, this.Page.GetType(), "xmsalpingApplicationDetails", "autoCompleteBind()", true);
                    return;
                }


                SAdetails = new XMScalpingApplicationDetails();

                if (this.ScalpingId > 0) {

                    SAdetails.ScalpingId = this.ScalpingId;
                }
                else if (this.ScalpingId == -1 && this.NewScalpingId != "" && this.NewScalpingId != null)
                {
                    if (Convert.ToInt32(this.NewScalpingId) > 0)
                    {
                        SAdetails.ScalpingId = Convert.ToInt32(this.NewScalpingId);
                    }
                } 
                SAdetails.ProductId = Product.Id;
                SAdetails.ScalpingTime = Convert.ToDateTime( txtScalpingTime.Value);
                SAdetails.RequiredFlow = txtRequiredFlow.Text.Trim();
                SAdetails.NaturalFlow = txtNaturalFlow.Text.Trim();
                SAdetails.ForecastDeal = Convert.ToInt32( txtForecastDeal.Text.Trim());
                SAdetails.ForecastScalpingQuantity = Convert.ToInt32(txtForecastScalpingQuantity.Text.Trim());
                SAdetails.ConversionRate = Convert.ToDecimal(txtConversionRate.Text.Trim());
                SAdetails.CustomerPrice = Convert.ToDecimal(txtCustomerPrice.Text.Trim());
                SAdetails.IsEnable = false; 
                SAdetails.CreatorID = HozestERPContext.Current.User.CustomerID;
                SAdetails.CreateTime = DateTime.Now;
                SAdetails.UpdatorID = HozestERPContext.Current.User.CustomerID;
                SAdetails.UpdateTime = DateTime.Now;
                base.XMScalpingApplicationDetailsService.InsertXMScalpingApplicationDetails(SAdetails);
            }
            else
            { 
                SAdetails.ScalpingTime = Convert.ToDateTime(txtScalpingTime.Value);
                SAdetails.RequiredFlow = txtRequiredFlow.Text.Trim();
                SAdetails.NaturalFlow = txtNaturalFlow.Text.Trim();
                SAdetails.ForecastDeal = Convert.ToInt32(txtForecastDeal.Text.Trim());
                SAdetails.ForecastScalpingQuantity = Convert.ToInt32(txtForecastScalpingQuantity.Text.Trim());
                SAdetails.ConversionRate = Convert.ToDecimal(txtConversionRate.Text.Trim());
                SAdetails.CustomerPrice = Convert.ToDecimal(txtCustomerPrice.Text.Trim());  
                SAdetails.UpdatorID = HozestERPContext.Current.User.CustomerID;
                SAdetails.UpdateTime = DateTime.Now;
                base.XMScalpingApplicationDetailsService.UpdateXMScalpingApplicationDetails(SAdetails);
            }
            this.RowEditIndex = -1;
            this.Master.JsWrite("alert('保存成功！')", "");
            this.BindGrid();
            ScriptManager.RegisterStartupScript(this.gvScalpingApplicationDetails, this.Page.GetType(), "xmsalpingApplicationDetails", "autoCompleteBind()", true);
        }

        protected void gvScalpingApplicationDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int QID = Convert.ToInt32(gvScalpingApplicationDetails.DataKeys[e.RowIndex].Value.ToString());

            var scalpingApplicationDetails = base.XMScalpingApplicationDetailsService.GetXMScalpingApplicationDetailsByScalpingDetailsId(QID);
            if (scalpingApplicationDetails != null)
            {
                scalpingApplicationDetails.IsEnable = true;
                scalpingApplicationDetails.UpdatorID = HozestERPContext.Current.User.CustomerID;
                scalpingApplicationDetails.UpdateTime = DateTime.Now;
                base.XMScalpingApplicationDetailsService.UpdateXMScalpingApplicationDetails(scalpingApplicationDetails);
            }

            //重新绑定
            this.RowEditIndex = -1;
            BindGrid();
            ScriptManager.RegisterStartupScript(this.gvScalpingApplicationDetails, this.Page.GetType(), "xmsalpingApplicationDetails", "autoCompleteBind()", true);
        }


        /// <summary>
        /// 保存刷单申请信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {  
            if (Page.IsValid)
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                    try
                    {
                        //string txtScalpingNo = this.txtScalpingNo.Text;
                        string ddPlatformTypeId = this.ddPlatformTypeId.SelectedValue;
                        string ddNickId = this.ddNickId.SelectedValue;
                        string txtScalpingBeginTime = this.txtScalpingBeginTime.Value;
                        string txtScalpingEndTime = this.txtScalpingEndTime.Value;
                        string txtExplanation = this.txtExplanation.Text.Trim();

                        if (txtScalpingBeginTime.ToString() == "" || txtScalpingEndTime.ToString() == "")
                        {
                            base.ShowMessage("刷单开始日期、结束日期不能为空!");
                            return;
                        }

                        if (this.ScalpingId == -1){


                            if (this.NewScalpingId != "" && this.NewScalpingId != null)
                            {
                                if (Convert.ToInt32(this.NewScalpingId) > 0)
                                {
                                    XMScalpingApplication xMScalpingApplicationNew = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(Convert.ToInt32(this.NewScalpingId));
                                    xMScalpingApplicationNew.PlatformTypeId = Convert.ToInt32(ddPlatformTypeId);
                                    xMScalpingApplicationNew.NickId = Convert.ToInt32(ddNickId);
                                    xMScalpingApplicationNew.Explanation = txtExplanation;
                                    if (txtScalpingBeginTime != "")
                                    {
                                        xMScalpingApplicationNew.ScalpingBeginTime = Convert.ToDateTime(txtScalpingBeginTime);
                                    }
                                    if (txtScalpingEndTime != "")
                                    {
                                        xMScalpingApplicationNew.ScalpingEndTime = Convert.ToDateTime(txtScalpingEndTime);
                                    }
                                    xMScalpingApplicationNew.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    xMScalpingApplicationNew.UpdateTime = DateTime.Now;

                                    base.XMScalpingApplicationService.UpdateXMScalpingApplication(xMScalpingApplicationNew);
                                      
                                    this.Master.JsWrite("alert('保存成功！')", "");
                                }
                            }
                            else
                            {

                                XMScalpingApplication scalpingApplication = new XMScalpingApplication(); 
                                scalpingApplication.PlatformTypeId = Convert.ToInt32(ddPlatformTypeId);
                                scalpingApplication.NickId = Convert.ToInt32(ddNickId);
                                scalpingApplication.ScalpingCode = DateTime.Now.ToString("yyyyMMddHHmmss");
                                scalpingApplication.Explanation = txtExplanation;
                                if (txtScalpingBeginTime != "")
                                {
                                    scalpingApplication.ScalpingBeginTime = Convert.ToDateTime(txtScalpingBeginTime);
                                }
                                if (txtScalpingEndTime != "")
                                {
                                    scalpingApplication.ScalpingEndTime = Convert.ToDateTime(txtScalpingEndTime);
                                }
                                scalpingApplication.ManagerIsAudit = false;
                                scalpingApplication.IsEnable = false;
                                scalpingApplication.CreatorID = HozestERPContext.Current.User.CustomerID;
                                scalpingApplication.CreateTime = DateTime.Now;
                                scalpingApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                scalpingApplication.UpdateTime = DateTime.Now;

                                base.XMScalpingApplicationService.InsertXMScalpingApplication(scalpingApplication);

                                this.NewScalpingId = scalpingApplication.ScalpingId.ToString();

                                this.Master.JsWrite("alert('保存成功！')", "");
                            }
                        }
                        else
                        {

                            XMScalpingApplication xMScalpingApplication = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(this.ScalpingId);
                            xMScalpingApplication.PlatformTypeId = Convert.ToInt32(ddPlatformTypeId);
                            xMScalpingApplication.NickId = Convert.ToInt32(ddNickId);
                            xMScalpingApplication.Explanation = txtExplanation;
                            if (txtScalpingBeginTime != "")
                            {
                                xMScalpingApplication.ScalpingBeginTime = Convert.ToDateTime(txtScalpingBeginTime);
                            }
                            if (txtScalpingEndTime != "")
                            {
                                xMScalpingApplication.ScalpingEndTime = Convert.ToDateTime(txtScalpingEndTime);
                            }
                            xMScalpingApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                            xMScalpingApplication.UpdateTime = DateTime.Now;

                            base.XMScalpingApplicationService.UpdateXMScalpingApplication(xMScalpingApplication);

                            //this.NewScalpingId = scalpingApplication.ScalpingId; 

                            this.Master.JsWrite("alert('保存成功！')", "");
                           // scope.Complete();
                        }
                    }
                    catch (Exception err)
                    {
                        this.ProcessException(err);
                    }
                //}
                loadDate();
            }
        }


        private bool BoolManagerIsAudit=false;


        public string NewScalpingId
        {
            get
            {
                try
                {
                    return (Session["SessionPayTypeId"] as string);
                }
                catch
                {
                }
                return string.Empty;
            }
            set
            {
                Session["SessionPayTypeId"] = value;
            }
        }

        /// <summary>
        /// 刷单申请Id
        /// </summary>
        public int ScalpingId
        {
            get
            {
                return CommonHelper.QueryStringInt("ScalpingId");
            } 
        }
         
    }
}