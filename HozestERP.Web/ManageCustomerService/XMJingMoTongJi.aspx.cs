using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageCustomerService;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMJingMoTongJi : BaseAdministrationPage, ISearchPage
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

        }
        public void Face_Init()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                //.Where(c => c.ProjectTypeId == 362)

                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    this.ddXMProject.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                }
                if (projectList.Count() > 0)
                {
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                }
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }


            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); //当月天数
            this.ddlBeginDate.Value = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-01";
            this.ddlEndDate.Value = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + days.ToString();

            string DepCode = "QC1403-3,QC1403-4,QC1506-2,QC1403-1,QC1403-2,QC1506-1";
            this.ddlGroupID.Items.Clear();
            var CoustomerServiceGroup = base.XMCustomerServiceLevelService.GetXMCoustomerServiceGroupList(DepCode);
            this.ddlGroupID.DataSource = CoustomerServiceGroup;
            this.ddlGroupID.DataTextField = "DepName";
            this.ddlGroupID.DataValueField = "DepartmentID";
            this.ddlGroupID.DataBind();
            this.ddlGroupID.Items.Insert(0, new ListItem("---所有---", "-1"));

            #endregion
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //开始日期
            string beginDate = this.ddlBeginDate.Value.ToString();
            //结束日期
            string endDate = this.ddlEndDate.Value.ToString();
            if (string.IsNullOrEmpty(beginDate) || string.IsNullOrEmpty(endDate))
            {
                if (string.IsNullOrEmpty(beginDate) && string.IsNullOrEmpty(endDate))
                {
                    return;
                }
                else
                {
                    base.ShowMessage("请先选择开始日期与结束日期！");
                    return;
                }
            }

            DateTime begin = DateTime.Parse(beginDate);
            DateTime end = DateTime.Parse(endDate).AddDays(1);

            if (begin >= end)
            {
                base.ShowMessage("开始日期不能大于结束日期，请重新选择！");
                return;
            }

            int groupId = int.Parse(this.ddlGroupID.SelectedValue);
            //姓名
            string Name = this.ddlName.Text.ToString();
            //项目ID
            int projectID = int.Parse(ddXMProject.SelectedValue);
            //店铺ID
            int nickID = 0;
            if (!string.IsNullOrEmpty(ddlNick.SelectedValue))
            {
                nickID = Convert.ToInt16(ddlNick.SelectedValue);
            }
            string DepCode = "QC1403-3,QC1403-4,QC1506-2,QC1403-1,QC1403-2,QC1506-1";
            //根据条件查询客服信息
            var xMProjectList = base.CustomerInfoService.GetJingMoTongJi(groupId, Name, DepCode, "");
            
            List<XMJingMoTongJiInfo> info = new List<XMJingMoTongJiInfo>();

            if (xMProjectList != null && xMProjectList.Count() > 0)
            {
                foreach (XMJingMoTongJiInfo p in xMProjectList)
                {
                    if (!string.IsNullOrEmpty(p.Name))
                    {
                        List<XMOrderInfo> List = base.XMOrderInfoService.GetJingMoTongJiByParm(p.Name, begin, end);
                        if (nickID != 0 && nickID != -1)
                        {
                            List = List.Where(q => q.NickID == nickID).ToList();
                        }
                        XMJingMoTongJiInfo m = new XMJingMoTongJiInfo();
                        m.Group = p.Group;
                        m.Name = p.Name;
                        if (List != null && List.Count() > 0)
                        {
                            m.OrderCount = List.Count();
                            //m.OrderPrice = getOrderPrice(List);
                            m.OrderPrice = List.Sum(n => n.PayPrice);
                        }
                        else
                        {
                            m.OrderCount = 0;
                            m.OrderPrice = 0;
                        }
                        info.Add(m);
                    }
                }
            }
            var xMProjectPageList = new PagedList<XMJingMoTongJiInfo>(info, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, xMProjectPageList, paramPageSize + 1);
        }


        //public decimal getOrderPrice(List<XMOrderInfo> list)
        //{
        //    decimal orderPrice = 0;
        //    if (list.Count > 0)
        //    {
        //        foreach (XMOrderInfo m in list)
        //        {
        //            orderPrice = orderPrice + m.PayPrice.Value;
        //        }
        //    }
        //    return orderPrice;
        //}

        #endregion


        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue));
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    this.ddlNick.DataSource = nickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    //其他
                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue), HozestERPContext.Current.User.CustomerID, 0);
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    if (nickList.Count() == 0)
                    {
                        this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                    }
                    else
                    {
                        if (nickList.Count() > 0)
                        {
                            this.ddlNick.DataSource = nickList;
                            this.ddlNick.DataTextField = "nick";
                            this.ddlNick.DataValueField = "nick_id";
                            this.ddlNick.DataBind();
                        }
                        this.ddlNick.Items.Insert(0, new ListItem("---所有---", "99"));
                    }
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
    }
}