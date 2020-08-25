using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.Controls;
using HozestERP.Web.Modules;
using JdSdk.Domain;
using Top.Api.Domain;

namespace HozestERP.Web.ManageProject
{
    public partial class XMClaimAnalysisType : BaseAdministrationPage, ISearchPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["RecordResponsiblePersonValue"] = null;
                Session["RecordCreateIDValue"] = null;
                loadData();
                BindDataAnalysis();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void loadData()
        {
            if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
            {
                List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                if (XMProjectList.Count > 0)
                {
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                }
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddXMProject.Items[0].Selected = true;
            }
            else
            {
                this.BindddXMProject();//项目
            }
            this.ddXMProject_SelectedIndexChanged(null, null);//店铺
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();

            #region 项目名称绑定
            string projectids = "";
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
                    for (int i = 0; i < projectList.ToList().Count; i++)
                    {
                        projectids = projectids + projectList.ToList()[i].Id + ",";
                    }
                    if (projectids.Length > 0)
                    {
                        projectids = projectids.Substring(0, projectids.Length - 1);
                    }
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                }
            }
            #endregion

            #region 注释创建人绑定，责任人绑定
            //#region 创建人绑定

            //var list = base.XMClaimInfoService.GetXMClaimInfoListByDate(Begin, End);
            //this.ddlCreateID.Items.Clear();
            //this.ddlCreateID.DataSource = list.Distinct(new Compare<HozestERP.BusinessLogic.ManageProject.XMClaimInfo>((x, y) => x.CreateID == y.CreateID));//去重规则
            //this.ddlCreateID.DataTextField = "CreateName";
            //this.ddlCreateID.DataValueField = "CreateID";
            //this.ddlCreateID.DataBind();
            //this.ddlCreateID.Items.Insert(0, new ListItem("---所有---", "-1"));

            //#endregion

            //#region 责任人绑定

            //var List = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByDate(Begin, End);
            //this.ddlResponsiblePerson.Items.Clear();
            //this.ddlResponsiblePerson.DataSource = List.Distinct(new Compare<HozestERP.BusinessLogic.ManageProject.XMClaimInfoDetail>((x, y) => x.ResponsiblePerson == y.ResponsiblePerson));
            //this.ddlResponsiblePerson.DataTextField = "ResponsiblePerson";
            //this.ddlResponsiblePerson.DataValueField = "ResponsiblePerson";
            //this.ddlResponsiblePerson.DataBind();
            //this.ddlResponsiblePerson.Items.Insert(0, new ListItem("---所有---", "-1"));

            //#endregion
            #endregion
        }

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
            BindDataAnalysis();
        }

        private void BindDataAnalysis()
        {
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

            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            string RealName = txtRealName.Text.Trim();//客户姓名
            int CreateID = -1;
            if (Session["RecordCreateIDValue"] != null)
            {
                CreateID = int.Parse(Session["RecordCreateIDValue"].ToString());
            }
            string ResponsiblePerson = "-1";
            if (Session["RecordResponsiblePersonValue"] != null)
            {
                ResponsiblePerson = Session["RecordResponsiblePersonValue"].ToString();
            }
            string orderCode = txtOrderCode.Text.Trim();
            string claimRef = txtClaimRef.Text.Trim();
            int isReturn = int.Parse(DropDownList1.SelectedValue);
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
            var NickId = Convert.ToInt32(this.ddlNick.SelectedValue);
            string nickids = "";
            if (NickId == 99) //某个项目店铺权限，选择有权限的店铺
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), xMProjectId, HozestERPContext.Current.User.CustomerID, 0);
                for (int i = 0; i < nickList.Count; i++)
                {
                    nickids = nickids + nickList[i].nick_id + ",";
                }
                if (nickids.Length > 0)
                {
                    nickids = nickids.Substring(0, nickids.Length - 1);
                }
            }
            else
            {
                nickids = NickId.ToString();
            }

            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='List'  style=\"width:100%\">");
            str.Append("<tr >");
            str.Append("<th>理赔类型</th><th>当期已确认</th><th>当期未确认</th><th>全部已确认</th><th>全部未确认</th></tr>");
            var ClaimTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(222, false);//210
            if (ClaimTypeList != null && ClaimTypeList.Count > 0)
            {
                foreach (CodeList p in ClaimTypeList)
                {
                    decimal acount = 0;
                    decimal acount2 = 0;
                    decimal acount3 = 0;
                    decimal acount4 = 0;
                    string url = "";
                    string url2 = "";
                    string url3 = "";
                    string url4 = "";
                    str.Append("<tr  id=\"mytr\">");
                    //当期财务已确认
                    var list = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByParm(CreateID, ResponsiblePerson, RealName, orderCode, claimRef, isReturn, 1, Begin, End, p.CodeID, xMProjectId, nickids);
                    //当期财务未确认
                    var list2 = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByParm(CreateID, ResponsiblePerson, RealName, orderCode, claimRef, isReturn, 0, Begin, End, p.CodeID, xMProjectId, nickids);
                    //全部财务确认
                    var list3 = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByParm(CreateID, ResponsiblePerson, RealName, orderCode, claimRef, isReturn, 1, "", "", p.CodeID, xMProjectId, nickids);
                    //全部财务未确认
                    var list4 = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByParm(CreateID, ResponsiblePerson, RealName, orderCode, claimRef, isReturn, 0, "", "", p.CodeID, xMProjectId, nickids);

                    if (list != null && list.Count > 0)
                    {
                        acount = list.Sum(n => n.ClaimAcount).Value;
                    }
                    if (list2 != null && list2.Count > 0)
                    {
                        acount2 = list2.Sum(n => n.ClaimAcount).Value;
                    }
                    if (list3 != null && list3.Count > 0)
                    {
                        acount3 = list3.Sum(n => n.ClaimAcount).Value;
                    }
                    if (list4 != null && list4.Count > 0)
                    {
                        acount4 = list4.Sum(n => n.ClaimAcount).Value;
                    }

                    url = "RealName=" + RealName + "&&OrderCode=" + orderCode + "&&ClaimRef=" + claimRef + "&&Begin=" + Begin + "&&End=" + End + "&&IsReturn=" + isReturn + "&&ProjectID=" + xMProjectId + "&&NickIds=" + nickids + "&&ClaimTypeID=" + p.CodeID + "&&IsConfirm=1";       //当期确认
                    url2 = "RealName=" + RealName + "&&OrderCode=" + orderCode + "&&ClaimRef=" + claimRef + "&&Begin=" + Begin + "&&End=" + End + "&&IsReturn=" + isReturn + "&&ProjectID=" + xMProjectId + "&&NickIds=" + nickids + "&&ClaimTypeID=" + p.CodeID + "&&IsConfirm=0";
                    url3 = "RealName=" + RealName + "&&OrderCode=" + orderCode + "&&ClaimRef=" + claimRef + "&&IsReturn=" + isReturn + "&&ProjectID=" + xMProjectId + "&&NickIds=" + nickids + "&&ClaimTypeID=" + p.CodeID + "&&IsConfirm=1";   //全部确认
                    url4 = "RealName=" + RealName + "&&OrderCode=" + orderCode + "&&ClaimRef=" + claimRef + "&&IsReturn=" + isReturn + "&&ProjectID=" + xMProjectId + "&&NickIds=" + nickids + "&&ClaimTypeID=" + p.CodeID + "&&IsConfirm=0";   //全部未确认
                    str.Append("<td >" + p.CodeName + "</td><td ><a  href=\"#\" onclick=\"return ShowWindowDetail('理赔单明细','" + CommonHelper.GetStoreLocation() + "ManageProject/ClaimInfoDetail.aspx?" + url + "',1200,500, this);\">" + acount + "</a></td><td><a  href=\"#\"   onclick=\"return ShowWindowDetail('理赔单明细','" + CommonHelper.GetStoreLocation() + "ManageProject/ClaimInfoDetail.aspx?" + url2 + "',1200,500, this);\">" + acount2 + "</a></td> <td ><a  href=\"#\"    onclick=\"return ShowWindowDetail('理赔单明细','" + CommonHelper.GetStoreLocation() + "ManageProject/ClaimInfoDetail.aspx?" + url3 + "',1200,500, this);\">" + acount3 + "</a></td><td ><a  href=\"#\"   onclick=\"return ShowWindowDetail('理赔单明细','" + CommonHelper.GetStoreLocation() + "ManageProject/ClaimInfoDetail.aspx?" + url4 + "',1200,500, this);\">" + acount4 + "</a></td>");
                    str.Append("</tr>");
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();

            ScriptManager.RegisterStartupScript(this.btnSearch, this.Page.GetType(), "ClaimAnalysisTypeBind", "BindCreateID()", true);//ajax
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataAnalysis();
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