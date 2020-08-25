using System;
using System.Linq;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageBusiness
{
    public partial class XMClaimPaymentPerson : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindInfo();
            }
        }

        private void bindInfo()
        {
            string ids = "";
            if (Session["IDs"] == null)
            {
                base.ShowMessage("请选择修改的记录！");
                return;
            }
            if (Session["IDs"] != null)
            {
                ids = Session["IDs"].ToString();
            }
            if (ids != "" && ids.Split(',').Count() > 0)
            {
                IDs = ids;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string errMessag = "";
            bool isAudit = false;
            if (IDs == "" || IDs == null)
            {
                base.ShowMessage("请选择记录！");
                return;
            }
            if (IDs != null && IDs != "")
            {
                var list = base.XMFinancialCapitalFlowService.GetXMFinancialCapitalFlowListByIDs(IDs);
                if (list != null && list.Count > 0)
                {
                    foreach (var parm in list)
                    {
                        if (parm.Audit.Value)
                        {
                            isAudit = true;
                            errMessag = "数据已经审核通过，无法实现操作！";
                        }
                    }
                    if (isAudit)
                    {
                        base.ShowMessage(errMessag);
                        return;
                    }
                    //保存
                    foreach (var Info in list)
                    {
                        Info.AssociatedPerson = txtPaymentPerson.Text.Trim();
                        Info.Updater = HozestERPContext.Current.User.CustomerID;
                        Info.UpdateDate = DateTime.Now;
                        base.XMFinancialCapitalFlowService.UpdateXMFinancialCapitalFlow(Info);
                    }
                    if (errMessag == "")
                    {
                        base.ShowMessage("操作成功！");
                    }
                    else
                    {
                        base.ShowMessage(errMessag);
                    }
                }
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Session["IDs"] = null;
        }


        public string IDs
        {
            get { return (string)ViewState["IDs"]; }
            set { ViewState["IDs"] = value; }
        }


        #region ISearchPage 成员
        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
        }
        #endregion


    }
}