using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using System.Web.UI.HtmlControls;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageCustomerService;

namespace HozestERP.Web.ManageCustomerService
{

    public partial class XMConsultationDetailsp : BaseAdministrationPage, IEditPage
    {
        #region Properties
        public int ConsultationId
        {
            get
            {
                return Convert.ToInt32(Request.Params["ConsultationId"]);
            }
        }
        #endregion

        /// <summary>
        /// 按钮 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnEdit", "XMConsultationDetails.GridView.Edit");//沟通记录-编辑
                buttons.Add("imgBtnDelete", "XMConsultationDetails.GridView.Delete");//沟通记录-删除
                buttons.Add("imgBtnUpdate", "XMConsultationDetails.GridView.Save");//沟通记录-保存
                buttons.Add("imgBtnCancel", "XMConsultationDetails.GridView.Cancel"); //沟通记录-取消

                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                if (this.ConsultationId > 0)
                {
                    XMConsultation xMConsultation = base.XMConsultationService.GetXMConsultationById(this.ConsultationId);
                    if (xMConsultation != null)
                    {
                        lblOrderNO.Text = xMConsultation.CustomerID;
                        lblNick.Text = xMConsultation.NickName;
                        lblPlatform.Text = xMConsultation.PlatformType; 
                    }
                }
                BindGrid();
            }
        }

        /// <summary>
        /// 从表
        /// </summary> 
        public void BindGrid()
        {

            List<XMConsultationDetails> xMConDetails = base.XMConsultationDetailsService.GetXMConsultationDetailsByClist(this.ConsultationId);
            if (this.RowEditIndex == -1)
            {
                this.gvXMCommunicationRecord.EditIndex = xMConDetails.Count();
                xMConDetails.Add(new XMConsultationDetails()); //新增编辑行
            }
            else
            {
                this.gvXMCommunicationRecord.EditIndex = this.RowEditIndex;
            }

            this.gvXMCommunicationRecord.DataSource = xMConDetails;
            this.gvXMCommunicationRecord.DataBind();
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

        protected void gvXMCommunicationRecord_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               // var item = (XMCommunicationRecord)e.Row.DataItem; 
                 
            }

              if (e.Row.RowState == DataControlRowState.Edit ||
                e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            { 
                //联系时间
                HtmlInputText txtContactTime = e.Row.FindControl("txtContactTime") as HtmlInputText;

                if (txtContactTime != null) { 
                    txtContactTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
             }

        }

        protected void gvXMCommunicationRecord_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvXMCommunicationRecord_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            BindGrid();
        }

        protected void gvXMCommunicationRecord_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row = this.gvXMCommunicationRecord.Rows[e.RowIndex];

            //联系时间
            HtmlInputText txtContactTime = row.FindControl("txtContactTime") as HtmlInputText;
            //联系内容
            TextBox txtContactContent = row.FindControl("txtContactContent") as TextBox;

            //联系时间
            Label lblContactTime = row.FindControl("lblContactTime") as Label;
            //联系内容
            Label lblContactContent = row.FindControl("lblContactContent") as Label;

            lblContactTime.Text = "";
            if (string.IsNullOrEmpty(txtContactTime.Value))
            {
                lblContactTime.Text = "联系时间不能为空";
                lblContactTime.ForeColor = System.Drawing.Color.Red;
                return;
            }
            lblContactContent.Text = "";
            if (string.IsNullOrEmpty(txtContactContent.Text.Trim()))
            {
                lblContactContent.Text = "联系内容不能为空";
                lblContactContent.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int QID = Convert.ToInt32(gvXMCommunicationRecord.DataKeys[e.RowIndex].Value.ToString());
            XMConsultationDetails XMConsultationDetails = new XMConsultationDetails();
            if (QID == 0) //新增
            {
                XMConsultationDetails.ConsultationId = this.ConsultationId;
                XMConsultationDetails.ContactTime = Convert.ToDateTime(txtContactTime.Value);
                //XMConsultationDetails.ContactTheme = txtContactTheme.Text.Trim();
                XMConsultationDetails.ContactContent = txtContactContent.Text.Trim();
                XMConsultationDetails.Created = DateTime.Now;
                XMConsultationDetails.CreatorID = HozestERPContext.Current.User.CustomerID;
                XMConsultationDetails.UpdatorID = HozestERPContext.Current.User.CustomerID;
                XMConsultationDetails.Updated = DateTime.Now;
                //新增咨询记录
                base.XMConsultationDetailsService.InsertXMConsultationDetails(XMConsultationDetails);
                base.ShowMessage("操作成功.");
                
            }
            else //修改
            {
                XMConsultationDetails xMConsultationDetailsUpdate = base.XMConsultationDetailsService.GetXMConsultationDetailsByid(QID);
                xMConsultationDetailsUpdate.ContactTime = Convert.ToDateTime(txtContactTime.Value);
                //xMCommunicationRecordUpdate.ContactTheme = txtContactTheme.Text.Trim();
                xMConsultationDetailsUpdate.ContactContent = txtContactContent.Text.Trim();
                XMConsultationDetails.UpdatorID = HozestERPContext.Current.User.CustomerID;
                XMConsultationDetails.Updated = DateTime.Now;
                base.XMConsultationDetailsService.UpdateXMConsultationDetails(xMConsultationDetailsUpdate);

                base.ShowMessage("操作成功.");
                
            } 
            //重新绑定
            this.RowEditIndex = -1;
            BindGrid();
        }

        protected void gvXMCommunicationRecord_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int QID = Convert.ToInt32(gvXMCommunicationRecord.DataKeys[e.RowIndex].Value.ToString());
            base.XMConsultationDetailsService.DeleteXMConsultationDetails(QID);
            base.ShowMessage("操作成功.");
            //重新绑定
            this.RowEditIndex = -1;
            BindGrid();
        }



        

            
        /// <summary>
        /// 问题类型： Feedback：反馈 ；DealWith：处理
        /// </summary>
        public string QuestionType
        {
            get
            {
                return CommonHelper.QueryString("QuestionType");// Request.Params["QuestionType"];
            }
        }
    }
}