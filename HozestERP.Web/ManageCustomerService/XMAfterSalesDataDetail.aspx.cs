using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMAfterSalesDataDetail : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        public void loadDate()
        {
            DateTime begin = DateTime.Parse(beginDate);
            DateTime end = DateTime.Parse(endDate).AddDays(1);
            List<QuestionDetailed_Result> PersonalWorkload = base.XMAfterSalesDataService.GetXMAfterSalesDataByPersonalWorkload(begin, end, CustomerId);
            List<QuestionDetailed_Result> DemandReturnCount = PersonalWorkload.Where(p => p.IsReturns == true).ToList(); //base.XMAfterSalesDataService.GetXMAfterSalesDataByDemandReturn(begin, end, CustomerId, "");
            int ReturnID = 0;
            var codelist = base.CodeService.GetCodeListAll();
            if (codelist != null)
            {
                foreach (CodeList item in codelist)
                {
                    if (item.CodeName == "退货")
                    {
                        ReturnID = item.CodeID;
                        break;
                    }
                }
            }
            List<QuestionDetailed_Result> ActualReturnCount = PersonalWorkload.Where(p => p.ResultsId == ReturnID).ToList(); //base.XMAfterSalesDataService.GetXMAfterSalesDataByDemandReturn(begin, end, CustomerId, ReturnID.ToString());
            //List<QuestionDetailed_Result> PersonalWorkload = base.XMAfterSalesDataService.GetXMAfterSalesDataByPersonalWorkload(begin, end, CustomerId);
            if (type == "DemandReturn")
            {
                this.grdvZYNewsList.DataSource = DemandReturnCount;
            }
            else if (type == "ActualReturn")
            {
                this.grdvZYNewsList.DataSource = ActualReturnCount;
            }
            else if (type == "PersonalWorkload")
            {
                this.grdvZYNewsList.DataSource = PersonalWorkload;
            }
            //绑定数据源
            this.grdvZYNewsList.DataBind();
        }

        protected void grdvZYNewsList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string beginDate
        {
            get
            {
                return CommonHelper.QueryString("beginDate");
            }
        }

        public string endDate
        {
            get
            {
                return CommonHelper.QueryString("endDate");
            }
        }

        public int CustomerId
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerID");
            }
        }

        public string type
        {
            get
            {
                return CommonHelper.QueryString("type");
            }
        }

        public void Face_Init()
        {

        }

        public void SetTrigger()
        {

        }
    }
}