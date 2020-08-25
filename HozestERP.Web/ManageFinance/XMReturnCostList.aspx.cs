using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.Common;
using System.Web.UI.HtmlControls;
using System.Transactions;

namespace HozestERP.Web.ManageFinance
{
    public partial class XMReturnCostList : BaseAdministrationPage, IEditPage
    {
        #region IEditPage 成员

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        protected string GetOrderCode(string applicationId)
        {
            string orderCode = string.Empty;
            if (!string.IsNullOrEmpty(applicationId))
            {
                XMApplication application = base.XMApplicationService.GetXMApplicationByID(Convert.ToInt16(applicationId));
                if (application != null)
                {
                    orderCode = application.OrderCode;
                }
            }
            return orderCode;
        }

        public void BindGrid()
        {
            List<XMApplicationExchange> AppExchangeList = new List<XMApplicationExchange>();
            if (Session["AppExchangeList"] != null)
            {
                AppExchangeList = (List<XMApplicationExchange>)Session["AppExchangeList"];
                this.grdvClients.DataSource = AppExchangeList;
                this.grdvClients.DataBind();
            }
            else
            {
                base.ShowMessage("操作超时，请重新查询！");
            }
        }

        protected void Clients_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

    }
}