using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.Web.Modules;
using HozestERP.Controls;
using System.Web.UI.HtmlControls;
using JdSdk.Domain;
using Top.Api.Domain;
using System.Transactions;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageApplication;
using System.IO;

namespace HozestERP.Web.ManageApplication
{
    public partial class XMDataAnalysisApplication : BaseAdministrationPage, ISearchPage
    {
        public List<XMDataAnalysy> xmConsultationAll;
        public List<XMDataAnalysy> xmConsultationTotal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;

            #region 店铺名称绑定

            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 522)
            {
                this.ddlNick.Items.Clear();
                var NickList = base.XMNickService.GetXMNickList();
                var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                if (newNickList.Count() > 0)
                {
                    this.ddlNick.DataSource = newNickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }
            else
            {
                var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                if (xMNickList.Count() == 0)
                {
                    this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                }
                if (xMNickList.Count > 0)
                {
                    this.ddlNick.Items.Clear();
                    this.ddlNick.DataSource = xMNickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-2"));
                }
            }

            #endregion

            #region 平台类型
            //平台类型动态数据绑定
            this.ddlPlatform.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatform.DataSource = codeList;
            this.ddlPlatform.DataTextField = "CodeName";
            this.ddlPlatform.DataValueField = "CodeID";
            this.ddlPlatform.DataBind();
            this.ddlPlatform.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));
            #endregion

            #region 售后客服
            //客服部DepCode
            string DepCode = "QC1403-1,QC1403-2,QC1506-1";//售前客服
            this.ddlCustomerService.Items.Clear();
            var CustomerServiceList = base.XMConsultationService.GetCustomerServiceList(DepCode);
            this.ddlCustomerService.DataSource = CustomerServiceList;
            this.ddlCustomerService.DataTextField = "FullName";
            this.ddlCustomerService.DataValueField = "CustomerID";
            this.ddlCustomerService.DataBind();
            this.ddlCustomerService.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            #endregion

            this.txtBeginDate.ctlDateTime.Text = DateTime.Now.Year+"-"+DateTime.Now.Month+"-01";
            this.txtEndDate.ctlDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            if (string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()) || string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
            {
                base.ShowMessage("请输入开始日期和结束日期！");
                return;
            }

            if (!string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("请输入结束日期！");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("请输入开始日期！");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtBeginDate.ctlDateTime.Text.Trim())
                && !string.IsNullOrEmpty(txtEndDate.ctlDateTime.Text.Trim()))
            {
                DateTime dt = new DateTime();
                if (!DateTime.TryParse(txtBeginDate.ctlDateTime.Text.Trim(), out dt))
                {
                    base.ShowMessage("开始日期输入错误！");
                    return;
                }
                if (!DateTime.TryParse(txtEndDate.ctlDateTime.Text.Trim(), out dt))
                {
                    base.ShowMessage("结束日期输入错误！");
                    return;
                }

                if (DateTime.Parse(txtEndDate.ctlDateTime.Text.Trim()) < DateTime.Parse(txtBeginDate.ctlDateTime.Text.Trim()))
                {
                    base.ShowMessage("结束日期不能小于开始日期！");
                    return;
                }
            }
            this.BindGrid(paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
        }

        public void BindGrid(int paramPageIndex, int paramPageSize, string sortExpression, string sortDirection)
        {
            int No = 1;
            var PlatformId = int.Parse(this.ddlPlatform.SelectedValue);
            var NickId = int.Parse(this.ddlNick.SelectedValue);
            var BeginDate = this.txtBeginDate.SelectedDate;
            var EndDate = this.txtEndDate.SelectedDate;
            var CustomerId = this.ddlCustomerService.SelectedValue;
            var ApplicationType = this.ddlApplicationType.SelectedValue;

            var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
            List<int?> a = new List<int?> { };
            if (NickId == -2)
            {
                foreach (var list in xMNickList)
                {
                    a.Add(list.nick_id);
                }
            }

            var Questionlist = base.XMApplicationService.GetDataAnalysisList(PlatformId, NickId, BeginDate, EndDate, int.Parse(CustomerId), a, int.Parse(ApplicationType));
            List<XMDataAnalysy> List = new List<XMDataAnalysy>();
            List<XMDataAnalysy> ALL = new List<XMDataAnalysy>();
            var Group_CreatorID = Questionlist.GroupBy(x => new { x.CreateID });
            foreach (var Info in Group_CreatorID)
            {
                int no = 1;
                int DealTotal = 0;
                XMDataAnalysy record = new XMDataAnalysy();
                var InfoList = Info.ToList<XMApplication>();
                record.ID = No;
                record.CreatorID = InfoList[0].CreateID;
                No++;
                var group = InfoList.GroupBy(x => new { x.PlatformTypeId, x.NickId, x.ApplicationType });
                foreach (var data in group)
                {
                    var info = data.ToList<XMApplication>();
                    List<string> CustomerIDList = new List<string>();
                    XMDataAnalysy one = new XMDataAnalysy();
                    one.ID = no;
                    one.PlatformTypeId = info[0].PlatformTypeId;
                    one.NickId = info[0].NickId;
                    one.CreatorID = info[0].CreateID;
                    one.ApplicationType = (int)info[0].ApplicationType;
                    one.DealCount = info.Count;
                    ALL.Add(one);
                    no++;
                    record.DetailTab = record.DetailTab + "<tr><td>" + one.ID.ToString() + "</td><td>" + one.PlatformType + "</td><td>" + one.NickName
                        + "</td><td>" + one.ApplicationTypeName + "</td><td>" + one.DealCount + "</td></tr>";
                    DealTotal = DealTotal + one.DealCount;
                }
                record.DealCount = DealTotal;
                List.Add(record);
            }
            xmConsultationTotal = List;
            xmConsultationAll = ALL;
            var pageList = new PagedList<XMDataAnalysy>(List, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.gvQuestion, pageList, paramPageSize + 1);
        }

        #endregion

        protected void hidBtnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        //导出
        protected void btnDaochu_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    var BeginDate = this.txtBeginDate.SelectedDate;
                    var EndDate = this.txtEndDate.SelectedDate;
                    string DateRange =((DateTime)BeginDate).ToString("yyyy-MM-dd") + "to" + ((DateTime)EndDate).ToString("yyyy-MM-dd");
                    string fileName = string.Format("DataAnalysy_" + DateRange + "_{0}{1}.xls", DateTime.Now.ToString("yyMMddHHmmssfff"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\DataAnalysyApplication", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;
                    this.BindGrid(Master.PageIndex, Master.PageSize);
                    base.ExportManager.ExportDataAnalysisXlsApplication(filePath, xmConsultationAll, xmConsultationTotal);

                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }
    }
}
