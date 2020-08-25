using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.Profile;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageSystem
{
    public partial class EnterprisesDetails : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var enterprise = base.EnterpriseService.GetEnterpriseByID(this.EntId);
                if (enterprise != null)
                {
                    this.txtDisplayOrder.Value = enterprise.DisplayOrder;
                    this.txtEntName.Text = enterprise.EntName;
                    this.txtEntTel.Text = enterprise.EntTel;
                    this.txtEntFax.Text = enterprise.EntFax;
                    this.txtEntEmail.Text = enterprise.EntEmail;
                    this.txtEntWebSite.Text = enterprise.EntWebSite;
                    this.txtEntZip.Text = enterprise.EntZip;
                    this.txtEntBank.Text = enterprise.EntBank;
                    this.txtEntAddress.Text = enterprise.EntAddress;
                    this.txtEntBankAccount.Text = enterprise.EntBankAccount;
                }
                else
                {
                    this.txtDisplayOrder.Value = 1;
                    this.txtEntName.Text = string.Empty;
                    this.txtEntTel.Text = string.Empty;
                    this.txtEntFax.Text = string.Empty;
                    this.txtEntEmail.Text = string.Empty;
                    this.txtEntWebSite.Text = string.Empty;
                    this.txtEntZip.Text = string.Empty;
                    this.txtEntBank.Text = string.Empty;
                    this.txtEntAddress.Text = string.Empty;
                    this.txtEntBankAccount.Text = string.Empty;
                }
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("系统管理->集团公司详细信息");
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSave.UniqueID, this.Page);
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var enterprise = base.EnterpriseService.GetEnterpriseByID(this.EntId);
                if (enterprise != null)
                {
                    enterprise.DisplayOrder = this.txtDisplayOrder.Value;
                    enterprise.EntName=this.txtEntName.Text.Trim();
                    enterprise.EntTel=this.txtEntTel.Text.Trim();
                    enterprise.EntFax=this.txtEntFax.Text.Trim();
                    enterprise.EntEmail=this.txtEntEmail.Text.Trim();
                    enterprise.EntWebSite=this.txtEntWebSite.Text.Trim();
                    enterprise.EntZip=this.txtEntZip.Text.Trim();
                    enterprise.EntBank=this.txtEntBank.Text.Trim();
                    enterprise.EntAddress=this.txtEntAddress.Text.Trim();
                    enterprise.EntBankAccount=this.txtEntBankAccount.Text.Trim();
                    base.EnterpriseService.UpdateEnterprise(enterprise);
                }
                else
                {
                    base.EnterpriseService.InsertEnterprise(new Enterprise()
                    {
                        DisplayOrder = this.txtDisplayOrder.Value
                        , EntName=this.txtEntName.Text.Trim()
                        ,EntTel=this.txtEntTel.Text.Trim()
                        ,EntFax=this.txtEntFax.Text.Trim()
                        ,EntEmail=this.txtEntEmail.Text.Trim()
                        ,EntWebSite=this.txtEntWebSite.Text.Trim()
                        ,EntZip=this.txtEntZip.Text.Trim()
                        ,EntBank=this.txtEntBank.Text.Trim()
                        ,EntAddress=this.txtEntAddress.Text.Trim()
                        ,EntBankAccount=this.txtEntBankAccount.Text.Trim()
                        ,Deleted = false
                        ,AddUserId = HozestERPContext.Current.User.CustomerID
                        ,AddTime = DateTime.Now.ToString()

                    });

                }
                this.Master.JsWrite("alert('保存成功.');window.close();", "");
            }
        }

        public int EntId
        {
            get
            {
                return CommonHelper.QueryStringInt("EntId");
            }
        }
    }
}