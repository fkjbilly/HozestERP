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

namespace HozestERP.Web.ManageProject
{ 

    public partial class XMCommunicationRecordEdit : BaseAdministrationPage, IEditPage
    {
        #region Properties
        public int QuestionID
        {
            get
            {
                return Convert.ToInt32(Request.Params["QuestionID"]);
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
                buttons.Add("imgBtnEdit", "XMCommunicationRecordEdit.GridView.Edit");//沟通记录-编辑
                buttons.Add("imgBtnDelete", "XMCommunicationRecordEdit.GridView.Delete");//沟通记录-删除
                buttons.Add("imgBtnUpdate", "XMCommunicationRecordEdit.GridView.Save");//沟通记录-保存
                buttons.Add("imgBtnCancel", "XMCommunicationRecordEdit.GridView.Cancel"); //沟通记录-取消

                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                if (this.QuestionID > 0)
                { 
                    XMQuestion xMQuestion = base.XMQuestionService.GetById(this.QuestionID); 
                    if (xMQuestion != null)
                    { 
                        lblOrderNO.Text = xMQuestion.OrderNO;
                        lblNick.Text = xMQuestion.NickName; 
                        lblPlatform.Text = xMQuestion.PlatformType; 
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

            List<XMCommunicationRecord> xMCommunicationRecord = base.XMCommunicationRecordService.GetXMCommunicationRecordListByQuestionID(this.QuestionID);


            if (QuestionType == "feedback")
            {
                this.gvXMCommunicationRecord.DataSource = xMCommunicationRecord;
                this.gvXMCommunicationRecord.DataBind();
            }
            else if (QuestionType == "dealwith")
            { 
                if (this.RowEditIndex == -1)
                {
                    this.gvXMCommunicationRecord.EditIndex = xMCommunicationRecord.Count();
                    xMCommunicationRecord.Add(new XMCommunicationRecord()); //新增编辑行
                }
                else
                {
                    this.gvXMCommunicationRecord.EditIndex = this.RowEditIndex;
                }

                this.gvXMCommunicationRecord.DataSource = xMCommunicationRecord;
                this.gvXMCommunicationRecord.DataBind();
            }
            
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
            //联系主题
            TextBox txtContactTheme = row.FindControl("txtContactTheme") as TextBox;
            //联系内容
            TextBox txtContactContent = row.FindControl("txtContactContent") as TextBox;

            //联系时间
            Label lblContactTime = row.FindControl("lblContactTime") as Label;

            //联系主题
            Label lblContactTheme = row.FindControl("lblContactTheme") as Label;
            //联系内容
            Label lblContactContent = row.FindControl("lblContactContent") as Label;

            lblContactTime.Text = "";
            if (string.IsNullOrEmpty(txtContactTime.Value))
            {
                lblContactTime.Text = "联系时间不能为空";
                lblContactTime.ForeColor = System.Drawing.Color.Red;
                return;
            }


            lblContactTheme.Text = "";
            if (string.IsNullOrEmpty(txtContactTheme.Text.Trim()))
            {
                lblContactTheme.Text = "联系主题不能为空";
                lblContactTheme.ForeColor = System.Drawing.Color.Red;
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
            XMCommunicationRecord xMCommunicationRecord = new XMCommunicationRecord();
            if (QID == 0) //新增
            { 

                //根据主表Id 查询问题明细信息 
               var QuestionDetailsList= base.XMQuestionDetailService.GetQuestionDetails(this.QuestionID);
                //查询明细是提交中的数据
               var QuestionDetailsListNow = QuestionDetailsList.Where(p => p.Status.Value == Convert.ToInt32(QuestionStatusEnum.Submit)).ToList(); 

                xMCommunicationRecord.QuestionID = this.QuestionID;
                xMCommunicationRecord.ContactTime = Convert.ToDateTime(txtContactTime.Value);
                xMCommunicationRecord.ContactTheme = txtContactTheme.Text.Trim();
                xMCommunicationRecord.ContactContent = txtContactContent.Text.Trim();
                xMCommunicationRecord.IsEnable = false; 
                xMCommunicationRecord.CreateTime = DateTime.Now;
                xMCommunicationRecord.CreateId = HozestERPContext.Current.User.CustomerID;
                xMCommunicationRecord.UpdateId = HozestERPContext.Current.User.CustomerID;
                xMCommunicationRecord.UpdateTime = DateTime.Now;
                //新增沟通记录
                base.XMCommunicationRecordService.InsertXMCommunicationRecord(xMCommunicationRecord); 

                // 修改 问题主表信息、明细信息
                if (QuestionDetailsListNow.Count > 0) {
                    
                    //修改 问题处理明细 
                    XMQuestionDetail questionDetail;
                    for (int i = 0; i < QuestionDetailsListNow.Count; i++)
                    {
                        questionDetail = QuestionDetailsListNow[i]; 
                        questionDetail.Status = Convert.ToInt32(QuestionStatusEnum.Deal);//处理状态 ：处理中
                        questionDetail.OrdersTime = DateTime.Now;//接单时间
                        questionDetail.ResultsId = 447;//441:无(94)
                        questionDetail.SrvAfterCustomerID = HozestERPContext.Current.User.CustomerID; //售后
                        questionDetail.LastModifyTime = DateTime.Now;
                        questionDetail.LastModifyByID = HozestERPContext.Current.User.CustomerID;
                        questionDetail.OrdersTime = DateTime.Now;
                        base.XMQuestionDetailService.Update(questionDetail);
                        questionDetail = null;
                    }
                    //修改 主表（处理人当前新增沟通记录人员）
                    XMQuestion mXMQuestion = new XMQuestion();
                    mXMQuestion = base.XMQuestionService.GetById(Convert.ToInt32(this.QuestionID));
                    mXMQuestion.Status = Convert.ToInt32(QuestionStatusEnum.Deal);
                    mXMQuestion.LastModifyTime = DateTime.Now;
                    mXMQuestion.LastModifyByID = HozestERPContext.Current.User.CustomerID; //售后
                    base.XMQuestionService.Update(mXMQuestion);
                }  
                 
                base.ShowMessage("操作成功.");
                
            }
            else //修改
            {
                XMCommunicationRecord xMCommunicationRecordUpdate = base.XMCommunicationRecordService.GetXMCommunicationRecordById(QID);
                xMCommunicationRecordUpdate.ContactTime = Convert.ToDateTime(txtContactTime.Value);
                xMCommunicationRecordUpdate.ContactTheme = txtContactTheme.Text.Trim();
                xMCommunicationRecordUpdate.ContactContent = txtContactContent.Text.Trim();
                xMCommunicationRecordUpdate.UpdateId = HozestERPContext.Current.User.CustomerID;
                xMCommunicationRecordUpdate.UpdateTime = DateTime.Now;
                base.XMCommunicationRecordService.UpdateXMCommunicationRecord(xMCommunicationRecordUpdate);

                base.ShowMessage("操作成功.");
                
            } 
            //重新绑定
            this.RowEditIndex = -1;
            BindGrid();
        }

        protected void gvXMCommunicationRecord_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int QID = Convert.ToInt32(gvXMCommunicationRecord.DataKeys[e.RowIndex].Value.ToString());
            XMCommunicationRecord mRecord = base.XMCommunicationRecordService.GetXMCommunicationRecordById(QID);
            if (mRecord != null)
            {
                mRecord.IsEnable = true;
                mRecord.UpdateId = HozestERPContext.Current.User.CustomerID;
                mRecord.UpdateTime = DateTime.Now;
                base.XMCommunicationRecordService.UpdateXMCommunicationRecord(mRecord);

                base.ShowMessage("操作成功.");
            }
            //重新绑定
            this.RowEditIndex = -1;
            BindGrid();
        }



        

            
        /// <summary>
        /// 问题类型： feedback：反馈 ；dealwith：处理
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