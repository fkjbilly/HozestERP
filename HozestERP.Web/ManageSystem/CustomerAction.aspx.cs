using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageSystem
{
    public partial class CustomerAction : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var customerAction = base.ACLService.GetCustomerActionById(this.CustomerActionID);
                if (customerAction != null)
                {
                    this.txtName.Text = customerAction.Name;
                    this.txtKeyWord.Text = customerAction.SystemKeyword;
                    this.txtDisplayOrder.Value = customerAction.DisplayOrder;
                    this.txtComment.Text = customerAction.Comment;
                }
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("系统管理->功能模块 -> 事件");
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSave.UniqueID, this.Page);
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                if (this.CustomerActionID <= 0)
                {
                    base.ACLService.InsertCustomerAction(new HozestERP.BusinessLogic.CustomerManagement.CustomerAction()
                    {
                        Name = this.txtName.Text
                        ,
                        ModuleID = this.ModuleID
                        ,
                        SystemKeyword = this.txtKeyWord.Text
                        ,
                        Comment = this.txtComment.Text
                        ,
                        DisplayOrder = this.txtDisplayOrder.Value
                    });
                    this.Master.JsWrite("closeWindows();", "");
                }
                else
                {
                    var customerAction = base.ACLService.GetCustomerActionById(this.CustomerActionID);
                    customerAction.Name = this.txtName.Text;
                    customerAction.SystemKeyword = this.txtKeyWord.Text;
                    customerAction.Comment = this.txtComment.Text;
                    customerAction.DisplayOrder = this.txtDisplayOrder.Value;
                    base.ACLService.UpdateCustomerAction(customerAction);
                    this.Master.JsWrite("closeWindows();", "");
                }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (base.ACLService.CheckCustomerActionByKeyword(this.CustomerActionID, this.txtKeyWord.Text.Trim()))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        public int CustomerActionID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerActionID");
            }
        }

        public int ModuleID
        {
            get
            {
                return CommonHelper.QueryStringInt("ModuleID");
            }
        }
    }
}