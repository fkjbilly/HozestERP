using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.Web.ManageSystem
{
    public partial class LoginLogs : BaseAdministrationPage, ISearchPage
    {
        /// <summary>
        /// 判断当前页面是否有权限
        /// </summary>
        /// <returns></returns>
        //protected override bool ValidatePageSecurity()
        //{
        //    return this.ACLService.IsActionAllowed(22, "ManageACL");
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, 10);
            }
        }


        #region ISearchPage 成员

        /// <summary>
        /// 添加事件
        /// </summary>
        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            this.Master.SetTitle("参数设置 > 查看登陆日志");
            this.Master.SetSearchPanelVisible = false;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var customerSessions = base.CustomerService.GetAllCustomerSessions(paramPageIndex, paramPageSize);
            this.Master.BindData<CustomerSession>(this.grdvMessage, customerSessions);
        }

        #endregion
    }
}