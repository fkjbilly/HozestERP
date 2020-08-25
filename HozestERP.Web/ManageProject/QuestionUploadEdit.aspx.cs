using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject; 
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.Common;
using System.Data;
using System.Web.SessionState;
using System.Text;
using System.Text.RegularExpressions;
using HozestERP.Web.Modules;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web.ManageProject
{
    public partial class QuestionUploadEdit : BaseAdministrationPage, IEditPage
    {
        #region Properties
        public int QuestionID
        {
            get
            {
                return Convert.ToInt32(Request.Params["QuestionID"]);
            }
        }
        public int StatusId
        {
            get
            {
                return Convert.ToInt32(Request.Params["Status"]);
            }
        }  
        public int SrvBeforeCustomerID
        {
            get
            {
                if (Request.Params["SrvBeforeCustomerID"] != null)
                {
                    return Convert.ToInt32(Request.Params["SrvBeforeCustomerID"]);
                }
                else {
                    return 0;
                }
            }
        }

        public int SrvAfterCustomerID
        {
            get
            {
                if (Request.Params["SrvAfterCustomerID"] != "" && Request.Params["SrvAfterCustomerID"] != null)
                {
                    return Convert.ToInt32(Request.Params["SrvAfterCustomerID"]);
                }
                else {
                    return 0;
                }
            }
        }

        //
        
        #endregion

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("UploadFile", "ManageProject.QuestionUploadEdit.UploadFile"); //图片上传按钮
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.UploadFile.TaggantID = Guid.NewGuid();
                this.UploadFile.ObjectID = this.QuestionID;
                this.UploadFile.TableName = "XM_QuestionDetail";
                BindGrid();
            }
        }

        private void BindGrid()
        {
            var uploadfiles = base.FileService.GetUploadFileList(this.QuestionID).Where(p => p.TableName.Trim() == "XM_QuestionDetail").ToList();
            this.gvQuestionDetail.DataSource = uploadfiles;
            this.gvQuestionDetail.DataBind();
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SettrEditHeadVisible = false;

            //if (StatusId != (int)QuestionStatusEnum.Complete && SrvBeforeCustomerID == HozestERPContext.Current.User.CustomerID)
            if (SrvAfterCustomerID == HozestERPContext.Current.User.CustomerID || SrvAfterCustomerID==0 || SrvBeforeCustomerID == HozestERPContext.Current.User.CustomerID)
            {
                this.UploadFile.Visible = true;

            }
            else {
                this.UploadFile.Visible = false;
            }

          
        }

        public void SetTrigger()
        {
        }

        #endregion

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}