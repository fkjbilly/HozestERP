using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Customers;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageCustomer
{
    public partial class SocialSecurityFundList : BaseAdministrationPage, ISearchPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //弹出人员薪资导入页面
                this.btnImportSocialSecurityFund.OnClientClick = "return ShowWindowDetail('社保公积金导入','" + CommonHelper.GetStoreLocation() +
            "ManageCustomer/ImportSocialSecurityFund.aspx', 500, 280, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                if (DateTime.Now.Month == 1)
                {
                    this.ddlYear.SelectedValue = (DateTime.Now.Year - 1).ToString();
                    this.ddlMonth.SelectedValue = "12";
                }
                else
                {
                    this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                    this.ddlMonth.SelectedValue = (DateTime.Now.Month - 1).ToString();
                }

                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            //部门
            CommonMethod.DropDownListDepartment(this.ddlDepartment, true);
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            int no = 1;
            int change = 0;
            StringBuilder str = new StringBuilder();
            List<int> DepIdList = new List<int>();
            string DepartmentID = this.ddlDepartment.SelectedValue;//部门
            string FullName = this.txtFullName.Text.Trim();//姓名
            string Year = this.ddlYear.SelectedValue;//年
            string Month = this.ddlMonth.SelectedValue;//月
            DepIdList = DepartmentIdList(int.Parse(DepartmentID), DepIdList);

            var list = base.SocialSecurityFundService.GetSocialSecurityFundListByData(int.Parse(DepartmentID), DepIdList, FullName, int.Parse(Year), int.Parse(Month));
            var pageList = new PagedList<SocialSecurityFund>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, pageList);

            for (int j = 0; j < pageList.Count; j++)
            {
                if (no == 1)
                {
                    str.Append("<table bordercolor='#ababab' border='1' style='background-color: Silver; border-style: Ridge;height: 5px; width: 100%; border-collapse: collapse; word-break: keep-all; word-wrap: normal;margin-top：0px;' rules='all'>");
                    str.Append("<tr class='GridHeader2' style='font-weight:bold;height:40px;'>");
                    str.Append("<th class='GridHeard2' nowrap='noWrap' align='center' style='width:50px;white-space:nowrap;cursor:pointer;' scope='col'>序号</th>");
                    str.Append("<th class='GridHeard2' nowrap='noWrap' align='center' style='width:120px;white-space:nowrap;cursor:pointer;' scope='col'>年月</th>");
                    str.Append("<th class='GridHeard2' nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>姓名</th>");
                    str.Append("<th class='GridHeard2' nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>部门性质</th>");
                    str.Append("<th class='GridHeard2' nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>部门</th>");
                    str.Append("<th class='GridHeard2' nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>管理职级</th>");
                    str.Append("<th class='GridHeard2' nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>岗位</th>");
                    str.Append("<th class='GridHeard2' nowrap='noWrap' align='center' style='width:50px;white-space:nowrap;cursor:pointer;' scope='col'>户籍</th>");
                    str.Append("<th class='GridHeard2' nowrap='noWrap' align='center' style='width:100px;white-space:nowrap;cursor:pointer;' scope='col'>险种</th>");
                    str.Append("</tr>");
                }
                string color = "#FFFFFF";
                if (no % 2 == 0)
                {
                    color = "#F7F7F7";
                }
                str.Append("<tr class='GridRow' align='center' style='background-color:" + color + ";height:5px;height:5px;' oldcolor='" + color + "'>");
                str.Append("<td style='width:50px;height:36px;' align='center'>" + no + "</td>");
                str.Append("<td style='width:120px;'>" + pageList[j].YearMonth + "</td>");
                str.Append("<td style='width:100px;'>" + pageList[j].FullName + "</td>");
                str.Append("<td style='width:100px;'>" + pageList[j].ParentDepName + "</td>");
                str.Append("<td style='width:100px;'>" + pageList[j].DepartmentName + "</td>");
                str.Append("<td style='width:100px;'>" + pageList[j].RankManagement + "</td>");
                str.Append("<td style='width:100px;'>" + pageList[j].Post + "</td>");
                str.Append("<td style='width:50px;'>" + pageList[j].HouseholdRegister + "</td>");
                str.Append("<td style='width:100px;border-right:none;'>" + pageList[j].InsuranceType + "</td>");
                str.Append("</tr>");
                no++;
            }
            if (pageList.Count > 0)
            {
                change = 1;
                str.Append("<tr class='GridRow' style='background-color:#F7F7F7'><td style='height:10px;' colspan='9'></td></tr></table>");
            }
            TableStr = str.ToString();
            ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "BindGrid", "ChangeOverflow('" + change + "')", true);//ajax
        }

        #endregion

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))//删除
                {
                    base.SocialSecurityFundService.DeleteSocialSecurityFund(Convert.ToInt32(e.CommandArgument));

                    List<int> DepIdList = new List<int>();
                    string DepartmentID = this.ddlDepartment.SelectedValue;//部门
                    string FullName = this.txtFullName.Text.Trim();//姓名
                    string Year = this.ddlYear.SelectedValue;//年
                    string Month = this.ddlMonth.SelectedValue;//月
                    DepIdList = DepartmentIdList(int.Parse(DepartmentID), DepIdList);

                    var list = base.SocialSecurityFundService.GetSocialSecurityFundListByData(int.Parse(DepartmentID), DepIdList, FullName, int.Parse(Year), int.Parse(Month));
                    int rowscount = list.Count();//获取行数;

                    if (rowscount % this.Master.PageSize == 0)
                    {
                        this.BindGrid(this.Master.PageIndex - 1, this.Master.PageSize);
                    }
                    else
                    {
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    }
                    base.ShowMessage("操作成功！");
                }
            }
            #endregion
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as SocialSecurityFund;

                e.Row.Attributes.Add("ondblclick", "return ShowWindowDetail('社保公积金查看','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomer/SocialSecurityFundAdd.aspx?ID=" + info.ID + "&Type=0',550, 600, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});");

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('社保公积金修改','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomer/SocialSecurityFundAdd.aspx?ID=" + info.ID + "&Type=1',550, 600, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }
            }
        }

        protected void grdvClients_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //判断创建的行是否为表头行
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //获取表头所在行的所有单元格
                TableCellCollection tcHeader = e.Row.Cells;
                //清除自动生成的表头
                tcHeader.Clear();

                //第一行
                tcHeader.Add(new TableHeaderCell());
                tcHeader[0].ColumnSpan = 3;
                tcHeader[0].Text = "养老(元)";
                tcHeader[0].HorizontalAlign = HorizontalAlign.Center;//居中显示

                tcHeader.Add(new TableHeaderCell());
                tcHeader[1].ColumnSpan = 3;
                tcHeader[1].Text = "医疗(元)";
                tcHeader[1].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[2].ColumnSpan = 3;
                tcHeader[2].Text = "失业(元)";
                tcHeader[2].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[3].ColumnSpan = 2;
                tcHeader[3].Text = "工伤(元)";
                tcHeader[3].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].ColumnSpan = 2;
                tcHeader[4].Text = "生育(元)";
                tcHeader[4].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[5].ColumnSpan = 3;
                tcHeader[5].Text = "公积金(元)";
                tcHeader[5].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[6].RowSpan = 2;
                tcHeader[6].Text = "公司承担";
                tcHeader[6].HorizontalAlign = HorizontalAlign.Center;
                tcHeader[6].Attributes.Add("class", "GridHeader2");

                tcHeader.Add(new TableHeaderCell());
                tcHeader[7].RowSpan = 2;
                tcHeader[7].Text = "个人承担";
                tcHeader[7].HorizontalAlign = HorizontalAlign.Center;
                tcHeader[7].Attributes.Add("class", "GridHeader2");

                tcHeader.Add(new TableHeaderCell());
                tcHeader[8].RowSpan = 2;
                tcHeader[8].Text = "总计";
                tcHeader[8].HorizontalAlign = HorizontalAlign.Center;
                tcHeader[8].Attributes.Add("class", "GridHeader2");

                tcHeader.Add(new TableHeaderCell());
                tcHeader[9].RowSpan = 2;
                tcHeader[9].Text = "</th></tr><tr>";
                tcHeader[9].HorizontalAlign = HorizontalAlign.Center;

                //第二行
                tcHeader.Add(new TableHeaderCell());
                tcHeader[10].Text = "基数";
                tcHeader[10].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[11].Text = "公司部分";
                tcHeader[11].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[12].Text = "个人部分";
                tcHeader[12].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[13].Text = "基数";
                tcHeader[13].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[14].Text = "公司部分";
                tcHeader[14].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[15].Text = "个人部分";
                tcHeader[15].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[16].Text = "基数";
                tcHeader[16].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[17].Text = "公司部分";
                tcHeader[17].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[18].Text = "个人部分";
                tcHeader[18].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[19].Text = "基数";
                tcHeader[19].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[20].Text = "公司部分";
                tcHeader[20].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[21].Text = "基数";
                tcHeader[21].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[22].Text = "公司部分";
                tcHeader[22].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[23].Text = "基数";
                tcHeader[23].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[24].Text = "公司部分";
                tcHeader[24].HorizontalAlign = HorizontalAlign.Center;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[25].Text = "个人部分</th></tr><tr>";
                tcHeader[25].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        /// <summary>
        /// 查询
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

        public List<int> DepartmentIdList(int DepartmentID, List<int> DepIdList)
        {
            DepIdList.Add(DepartmentID);
            var list = base.CustomerSalaryService.GetDepartmentIDByID(DepartmentID);
            if (list != null && list.Count > 0)
            {
                foreach (Department one in list)
                {
                    DepartmentIdList(one.DepartmentID, DepIdList);
                }
            }
            return DepIdList;
        }
    }
}