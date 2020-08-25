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
namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMAfterSalesDataAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Month = this.txtMonth.Text.Trim();
            string ErrorCount = this.txtErrorCount.Text.Trim();
            string TMIndex = this.txtTMIndex.Text.Trim();
            string DSRScore = this.txtDSRScore.Text.Trim();
            string ResponseTime = this.txtResponseTime.Text.Trim();
            string JDResponseTime = this.txtJDResponseTime.Text.Trim();
            string JDCustomerService = this.txtJDCustomerService.Text.Trim();
            string CustomerComplaints = this.txtCustomerComplaints.Text.Trim();
            string EvaluationPoints = this.txtEvaluationPoints.Text.Trim();
            if (string.IsNullOrEmpty(Month) || string.IsNullOrEmpty(ErrorCount) || string.IsNullOrEmpty(TMIndex) || string.IsNullOrEmpty(DSRScore) ||
                string.IsNullOrEmpty(ResponseTime) || string.IsNullOrEmpty(JDResponseTime) || string.IsNullOrEmpty(JDCustomerService) || string.IsNullOrEmpty(CustomerComplaints) || string.IsNullOrEmpty(EvaluationPoints))
            {
                base.ShowMessage("数据不能为空!");
                return;
            }
            else
            {
                var date = base.XMAfterSalesDataService.GetXMAfterSalesDataInfoByMonth(Month, CustomerId);
                if (date == null)//添加
                {
                    XMAfterSalesData orderinfoapp = new XMAfterSalesData();
                    orderinfoapp.CustomerID = CustomerId;
                    orderinfoapp.Type = false;
                    orderinfoapp.Month = Month;
                    orderinfoapp.ErrorCount = int.Parse(ErrorCount);
                    orderinfoapp.TMIndex = decimal.Parse(TMIndex);
                    orderinfoapp.DSRScore = decimal.Parse(DSRScore);
                    orderinfoapp.ResponseTime = decimal.Parse(ResponseTime);
                    orderinfoapp.JDResponseTime = decimal.Parse(JDResponseTime);
                    orderinfoapp.JDCustomerService = decimal.Parse(JDCustomerService);
                    orderinfoapp.CustomerComplaints = int.Parse(CustomerComplaints);
                    orderinfoapp.EvaluationPoints = int.Parse(EvaluationPoints);
                    orderinfoapp.CreateID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.CreateTime = DateTime.Now;
                    orderinfoapp.UpdateID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.UpdateTime = DateTime.Now;
                    base.XMAfterSalesDataService.InsertXMAfterSalesData(orderinfoapp);
                    base.ShowMessage("保存成功!");
                }
                else if (date.Type==false)
                {
                    date.Type = false;
                    date.Month = Month;
                    date.ErrorCount = int.Parse(ErrorCount);
                    date.TMIndex = decimal.Parse(TMIndex);
                    date.DSRScore = decimal.Parse(DSRScore);
                    date.ResponseTime = decimal.Parse(ResponseTime);
                    date.JDResponseTime = decimal.Parse(JDResponseTime);
                    date.JDCustomerService = decimal.Parse(JDCustomerService);
                    date.CustomerComplaints = int.Parse(CustomerComplaints);
                    date.EvaluationPoints = int.Parse(EvaluationPoints);
                    date.UpdateID = HozestERPContext.Current.User.CustomerID;
                    date.UpdateTime = DateTime.Now;
                    base.XMAfterSalesDataService.UpdateXMAfterSalesData(date);
                    base.ShowMessage("保存成功!");
                }
                else if (date.Type == true)
                {
                    base.ShowMessage("该客服此月份数据已存档!");
                }
            }
        }

        public void loadDate()
        {
            string Month = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0');
            if (Id != 0)
            {
                var date = base.XMAfterSalesDataService.GetXMAfterSalesDataByID(Id);
                if (date != null)
                {
                    this.txtMonth.Text = date.Month;
                    this.txtErrorCount.Text = date.ErrorCount.ToString();
                    this.txtTMIndex.Text = date.TMIndex.ToString();
                    this.txtDSRScore.Text = date.DSRScore.ToString();
                    this.txtResponseTime.Text = date.ResponseTime.ToString();
                    this.txtJDResponseTime.Text = date.JDResponseTime.ToString();
                    this.txtJDCustomerService.Text = date.JDCustomerService.ToString();
                    this.txtCustomerComplaints.Text = date.CustomerComplaints.ToString();
                    this.txtEvaluationPoints.Text = date.EvaluationPoints.ToString();
                }
                if (date != null && date.Type == true)
                {
                    base.ShowMessage("已存档，不可修改！");
                    this.txtMonth.Enabled = false;
                    this.txtErrorCount.Enabled = false;
                    this.txtTMIndex.Enabled = false;
                    this.txtDSRScore.Enabled = false;
                    this.txtResponseTime.Enabled = false;
                    this.txtJDResponseTime.Enabled = false;
                    this.txtJDCustomerService.Enabled = false;
                    this.txtCustomerComplaints.Enabled = false;
                    this.txtEvaluationPoints.Enabled = false;
                    this.btnSave.Enabled = false;
                    return;
                }
            }
        }



        /// <summary>
        /// 操作类型
        /// </summary>
        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        public int CustomerId
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerID");
            }
        }

        public void Face_Init()
        {
            this.txtMonth.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2,'0');
        }

        public void SetTrigger()
        {
            //throw new NotImplementedException();
        }
    }
}