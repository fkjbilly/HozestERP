using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Common;
using HozestERP.Common.Utils;
using System.Web;
using System.IO;
using System.Text;

namespace HozestERP.Web.ManageProject
{
    public partial class LogisticsCostStatistics : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //默认查询开始时间
                txtBeginDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
                //默认查询结束时间
                txtEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                this.BindddXMProject();//项目
                BindGrid(1, Master.PageSize);

            }
        }

        /// <summary>
        /// grid 数据绑定
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            //项目名称
            int ProjectID = Convert.ToInt32(this.ddXMProject.SelectedValue);
            DateTime date = DateTime.Now;
            if (Begin != "" || End != "")
            {
                if (Begin == "" || End == "" || !DateTime.TryParse(Begin, out date) || !DateTime.TryParse(End, out date))
                {
                    base.ShowMessage("日期格式不正确！");
                    return;
                }
            }
            if (End != "")
            {
                End = DateTime.Parse(End).AddDays(1).ToString("yyyy-MM-dd");
            }
            var list = base.XMDeliveryService.GetXMDeliveryListByParm(Begin, End, ProjectID);
            var pageList = new PagedList<HozestERP.BusinessLogic.ManageProject.XMDeliveryNew>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvLogisticsCost, pageList);

            lbTotalPrice.Text = "总费用："+ list.Sum(p => p.Price).Value.ToString();

            hiddContent.Value = "[]";

            if (list != null && list.Count > 0)
            {
                var List2 = from l in list
                            group l by new { l.NickID } into g
                            select new
                            {
                                NickID = g.Key.NickID,
                                Price = g.Sum(a => a.Price)
                            };

                if (List2 != null && List2.Count() > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    string str = "";
                    sb.Append("[");
                    foreach (var parm in List2)
                    {
                        if (parm.Price == 0)
                        {
                            continue;
                        }
                        var nicks = base.XMNickService.GetXMNickByID(parm.NickID.Value);
                        if (nicks != null)
                        {
                            if (str == "")
                            {
                                str = "['" + nicks.nick + "'," + parm.Price.ToString() + "],";
                            }
                            else
                            {
                                str += "['" + nicks.nick + "'," + parm.Price.ToString() + "],";
                            }
                        }
                    }
                    if (str != "" && str.Length > 0)
                    {
                        str = str.Substring(0, str.Length - 1);
                        sb.Append(str);
                    }
                    sb.Append("]");
                    hiddContent.Value = sb.ToString();    //将值给Hidden
                }
                else
                {
                    hiddContent.Value = "[]";
                }
            }
        }

        //项目数据绑定
        private void BindddXMProject()
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
            #endregion
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }


        /// <summary>
        /// 刷新
        /// </summary>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvLogisticsCost_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as HozestERP.BusinessLogic.ManageProject.XMDeliveryNew;
                Label lblLogisticsId = e.Row.FindControl("lblLogisticsId") as Label;        //出库状态
                if (lblLogisticsId != null)
                {
                    if (info.LogisticsId != null)
                    {
                        if (info.DeliveryTypeId.Value == 480)
                        {
                            lblLogisticsId.Text = GetCompanyCustom(info.LogisticsId.Value.ToString());
                        }
                        else
                        {
                            var CodeList = base.CodeService.GetCodeListInfoByCodeID(info.LogisticsId.Value);
                            if (CodeList != null)
                            {
                                lblLogisticsId.Text = CodeList.CodeName;
                            }
                        }
                    }
                    else
                    {
                        lblLogisticsId.Text = "";
                    }
                }
            }
        }

        /// <summary>
        /// 物流公司
        /// </summary>
        /// <param name="loginsiticId"></param>
        /// <returns></returns>
        protected string GetCompanyCustom(string loginsiticId)
        {
            try
            {
                var Logistic = base.XMCompanyCustomService.GetXMCompanyCustomByLogisticId(loginsiticId);
                if (loginsiticId != null)
                {
                    return Logistic.LogisticsName;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
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