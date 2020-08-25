using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using System.Web;
using HozestERP.Common.Utils;
using System.IO;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMCustomerSaleAcountAnalysis : BaseAdministrationPage, ISearchPage
    {
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

            string DepCode = "QC1403-3,QC1403-4,QC1506-2,QC1403-1,QC1403-2,QC1506-1";
            this.ddlGroupID.Items.Clear();
            var CoustomerServiceGroup = base.XMCustomerServiceLevelService.GetXMCoustomerServiceGroupList(DepCode);
            this.ddlGroupID.DataSource = CoustomerServiceGroup;
            this.ddlGroupID.DataTextField = "DepName";
            this.ddlGroupID.DataValueField = "DepartmentID";
            this.ddlGroupID.DataBind();
            this.ddlGroupID.Items.Insert(0, new ListItem("---所有---", "-1"));

            this.ddlCustomerService.Items.Clear();
            var CustomerServiceList = base.XMConsultationService.GetCustomerServiceList(DepCode);
            this.ddlCustomerService.DataSource = CustomerServiceList;
            this.ddlCustomerService.DataTextField = "FullName";
            this.ddlCustomerService.DataValueField = "CustomerID";
            this.ddlCustomerService.DataBind();
            this.ddlCustomerService.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            this.txtBeginDate.Value = DateTime.Now.Year + "-" + DateTime.Now.Month + "-01";
            this.txtEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            if (string.IsNullOrEmpty(txtBeginDate.Value.Trim()) || string.IsNullOrEmpty(txtEndDate.Value.Trim()))
            {
                base.ShowMessage("请输入开始日期和结束日期！");
                return;
            }

            if (!string.IsNullOrEmpty(txtBeginDate.Value.Trim()))
            {
                if (string.IsNullOrEmpty(txtEndDate.Value.Trim()))
                {
                    base.ShowMessage("请输入结束日期！");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtEndDate.Value.Trim()))
            {
                if (string.IsNullOrEmpty(txtBeginDate.Value.Trim()))
                {
                    base.ShowMessage("请输入开始日期！");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtBeginDate.Value.Trim())
                && !string.IsNullOrEmpty(txtEndDate.Value.Trim()))
            {
                DateTime dt = new DateTime();
                if (!DateTime.TryParse(txtBeginDate.Value.Trim(), out dt))
                {
                    base.ShowMessage("开始日期输入错误！");
                    return;
                }
                if (!DateTime.TryParse(txtEndDate.Value.Trim(), out dt))
                {
                    base.ShowMessage("结束日期输入错误！");
                    return;
                }

                if (DateTime.Parse(txtEndDate.Value.Trim()) < DateTime.Parse(txtBeginDate.Value.Trim()))
                {
                    base.ShowMessage("结束日期不能小于开始日期！");
                    return;
                }
            }
            this.BindGrid(paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
        }

        public void BindGrid(int paramPageIndex, int paramPageSize, string sortExpression, string sortDirection)
        {
            var PlatformId = int.Parse(this.ddlPlatform.SelectedValue);
            var NickId = int.Parse(this.ddlNick.SelectedValue);
            var BeginDate = this.txtBeginDate.Value;
            var EndDate = this.txtEndDate.Value;
            int CustomerId = Convert.ToInt16(this.ddlCustomerService.SelectedValue);
            int GroupID = Convert.ToInt16(this.ddlGroupID.SelectedValue);
            var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
            List<int> a = new List<int> { };
            if (NickId == -2 || NickId == -1)
            {
                foreach (var list in xMNickList)
                {
                    a.Add(list.nick_id);
                }
            }
            else
            {
                a.Add(NickId);
            }
            string DepCode = "QC1403-3,QC1403-4,QC1506-2,QC1403-1,QC1403-2,QC1506-1";
            //根据条件查询客服信息
            var xMCustomerList = base.CustomerInfoService.GetCustomerSaleAcount(GroupID, CustomerId, DepCode);
            List<HozestERP.BusinessLogic.ManageCustomerService.XMCustomerSaleAcountAnalysis> info = new List<HozestERP.BusinessLogic.ManageCustomerService.XMCustomerSaleAcountAnalysis>();
            if (xMCustomerList != null && xMCustomerList.Count > 0)
            {
                foreach (HozestERP.BusinessLogic.ManageCustomerService.XMCustomerSaleAcountAnalysis p in xMCustomerList)
                {
                    if (p.CustomerID != null)
                    {
                        List<XMOrderInfo> List = base.XMOrderInfoService.GetCustomerSaleMoneyParm(p.CustomerID.Value, DateTime.Parse(BeginDate), DateTime.Parse(EndDate), PlatformId, a);
                        HozestERP.BusinessLogic.ManageCustomerService.XMCustomerSaleAcountAnalysis m = new BusinessLogic.ManageCustomerService.XMCustomerSaleAcountAnalysis();
                        m.Group = p.Group;
                        m.Name = p.Name;
                        if (List != null && List.Count > 0)
                        {
                            m.DealCount = List.Count();
                            m.DealMoney = List.Sum(n => n.PayPrice);
                        }
                        else
                        {
                            m.DealCount = 0;
                            m.DealMoney = 0;
                        }
                        info.Add(m);
                    }
                }
            }

            var pageList = new PagedList<HozestERP.BusinessLogic.ManageCustomerService.XMCustomerSaleAcountAnalysis>(info, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, pageList, paramPageSize + 1);
        }

        #endregion


        protected void ddlGroupID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string groupId = ddlGroupID.SelectedValue;
            if (!string.IsNullOrEmpty(groupId))
            {
                int depId = int.Parse(groupId);
                if (depId > 0)
                {
                    var CustomerServiceList = base.CustomerInfoService.GetCustomerInfoListByDepId(depId);
                    if (CustomerServiceList != null && CustomerServiceList.Count > 0)
                    {
                        this.ddlCustomerService.DataSource = CustomerServiceList;
                        this.ddlCustomerService.DataTextField = "FullName";
                        this.ddlCustomerService.DataValueField = "CustomerID";
                        this.ddlCustomerService.DataBind();
                        this.ddlCustomerService.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));
                    }
                }
                else
                {
                    #region 售前客服
                    //客服部DepCode
                    string DepCode = "QC1403-3,QC1403-4,QC1506-2,QC1403-1,QC1403-2,QC1506-1";
                    this.ddlCustomerService.Items.Clear();
                    var CustomerServiceList = base.XMConsultationService.GetCustomerServiceList(DepCode);
                    this.ddlCustomerService.DataSource = CustomerServiceList;
                    this.ddlCustomerService.DataTextField = "FullName";
                    this.ddlCustomerService.DataValueField = "CustomerID";
                    this.ddlCustomerService.DataBind();
                    this.ddlCustomerService.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

                    #endregion
                }
            }
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        //导出
        protected void btnDaochu_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtBeginDate.Value.Trim()) || string.IsNullOrEmpty(txtEndDate.Value.Trim()))
                    {
                        base.ShowMessage("请输入开始日期和结束日期！");
                        return;
                    }

                    if (!string.IsNullOrEmpty(txtBeginDate.Value.Trim()))
                    {
                        if (string.IsNullOrEmpty(txtEndDate.Value.Trim()))
                        {
                            base.ShowMessage("请输入结束日期！");
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(txtEndDate.Value.Trim()))
                    {
                        if (string.IsNullOrEmpty(txtBeginDate.Value.Trim()))
                        {
                            base.ShowMessage("请输入开始日期！");
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(txtBeginDate.Value.Trim())
                        && !string.IsNullOrEmpty(txtEndDate.Value.Trim()))
                    {
                        DateTime dt = new DateTime();
                        if (!DateTime.TryParse(txtBeginDate.Value.Trim(), out dt))
                        {
                            base.ShowMessage("开始日期输入错误！");
                            return;
                        }
                        if (!DateTime.TryParse(txtEndDate.Value.Trim(), out dt))
                        {
                            base.ShowMessage("结束日期输入错误！");
                            return;
                        }

                        if (DateTime.Parse(txtEndDate.Value.Trim()) < DateTime.Parse(txtBeginDate.Value.Trim()))
                        {
                            base.ShowMessage("结束日期不能小于开始日期！");
                            return;
                        }
                    }
                    var PlatformId = int.Parse(this.ddlPlatform.SelectedValue);
                    var NickId = int.Parse(this.ddlNick.SelectedValue);
                    var BeginDate = this.txtBeginDate.Value;
                    var EndDate = this.txtEndDate.Value;
                    int CustomerId = Convert.ToInt16(this.ddlCustomerService.SelectedValue);
                    int GroupID = Convert.ToInt16(this.ddlGroupID.SelectedValue);
                    var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                    List<int> a = new List<int> { };
                    if (NickId == -2 || NickId == -1)
                    {
                        foreach (var list in xMNickList)
                        {
                            a.Add(list.nick_id);
                        }
                    }
                    else
                    {
                        a.Add(NickId);
                    }
                    string DepCode = "QC1403-3,QC1403-4,QC1506-2,QC1403-1,QC1403-2,QC1506-1";
                    //根据条件查询客服信息
                    var xMCustomerList = base.CustomerInfoService.GetCustomerSaleAcount(GroupID, CustomerId, DepCode);
                    List<HozestERP.BusinessLogic.ManageCustomerService.XMCustomerSaleAcountAnalysis> info = new List<HozestERP.BusinessLogic.ManageCustomerService.XMCustomerSaleAcountAnalysis>();
                    if (xMCustomerList != null && xMCustomerList.Count > 0)
                    {
                        foreach (HozestERP.BusinessLogic.ManageCustomerService.XMCustomerSaleAcountAnalysis p in xMCustomerList)
                        {
                            if (p.CustomerID != null)
                            {
                                List<XMOrderInfo> List = base.XMOrderInfoService.GetCustomerSaleMoneyParm(p.CustomerID.Value, DateTime.Parse(BeginDate), DateTime.Parse(EndDate), PlatformId, a);
                                HozestERP.BusinessLogic.ManageCustomerService.XMCustomerSaleAcountAnalysis m = new BusinessLogic.ManageCustomerService.XMCustomerSaleAcountAnalysis();
                                m.Group = p.Group;
                                m.Name = p.Name;
                                if (List != null && List.Count > 0)
                                {
                                    m.DealCount = List.Count();
                                    m.DealMoney = List.Sum(n => n.PayPrice);
                                }
                                else
                                {
                                    m.DealCount = 0;
                                    m.DealMoney = 0;
                                }
                                info.Add(m);
                            }
                        }
                    }

                    //导出存放路径
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\CustomerSaleMoneyExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;

                    base.ExportManager.ExportCustomerSaleAnalysisToXls(filePath, info);
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