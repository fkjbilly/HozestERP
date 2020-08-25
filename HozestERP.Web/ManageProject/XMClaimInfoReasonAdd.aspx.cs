using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMClaimInfoReasonAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var CustomerInfo = base.CustomerInfoService.GetCustomerInfoByID(HozestERPContext.Current.User.CustomerID);
                if (CustomerInfo != null)
                {
                    this.txtResponsiblePerson.Text = CustomerInfo.FullName;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "";
            string ResponsiblePerson = this.txtResponsiblePerson.Text.Trim();
            string ClaimReason = this.txtClaimReason.Text.Trim();
            if (!string.IsNullOrEmpty(ResponsiblePerson))
            {
                //调用XMPremiumsAdd.aspx的ToSave函数
                if (Session["SavePremiumsAddData"] != null)
                {
                    XMPremiums data = (XMPremiums)Session["SavePremiumsAddData"];
                    string OrderCode = data.OrderCode;
                    string wangwang = data.WantId;
                    string ApplicationTypeId = data.PremiumsTypeId.ToString();
                    string PaymentPerson = data.PaymentPerson.ToString();
                    bool chk = (bool)data.IsEnable;
                    string note = data.Note;
                    string NickId = data.NoOrderNickId;

                    XMPremiumsAdd PremiumsAddPage = new XMPremiumsAdd();
                    PremiumsAddPage.ToSave(ref msg,OrderCode, wangwang, ApplicationTypeId, PaymentPerson, chk, ID, ResponsiblePerson, ClaimReason, note, NickId, true);
                    base.ShowMessage(msg);
                }
            }
            else
            {
                base.ShowMessage("责任人必须填写！");
            }
        }

        public int ID
        {
            get
            {
                return CommonHelper.QueryStringInt("ID");
            }
        }

        #region
        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }
        #endregion
    }
}