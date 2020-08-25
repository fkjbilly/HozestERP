using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.Controls;
using System.IO;
using System.Web;

namespace HozestERP.Web.ManageProject
{
    public partial class XMClaimInfo : BaseAdministrationPage, ISearchPage
    {
        public List<HozestERP.BusinessLogic.ManageProject.XMClaimInfo> List = new List<HozestERP.BusinessLogic.ManageProject.XMClaimInfo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                this.btnAdd.OnClientClick = "return ShowWindowDetail('新增理赔单','" + CommonHelper.GetStoreLocation()
                    + "ManageProject/XMClaimInfoAdd.aspx?Type=0"
                    + "&&ClaimInfoID=-1"
                    + "',1200,500, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                btnImport.OnClientClick= "return ShowWindowDetail('对账导入','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportClaimInfo.aspx',500,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                this.BindGrid(1, Master.PageSize);
            }
        }

        private void loadData()
        {
            if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
            {
                List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                if (XMProjectList.Count > 0)
                {
                    this.ddXMProject.Items.Clear();
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
        }

        public string CustomerName(string customerID)
        {
            string name = "";
            var customer = base.CustomerInfoService.GetCustomerInfoByID(Convert.ToInt16(customerID));
            if (customer != null)
            {
                name = customer.FullName;
            }
            return name;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string fullName = txtRealName.Text.Trim();             //客户姓名 
            string responsiblePerson = txtResponsiblePerson.Text.Trim();    //责任人姓名
            string orderCode = txtOrderCode.Text.Trim();         //订单号
            string Begin = this.txtBeginDate.Value.Trim();          //创单开始时间
            string End = this.txtEndDate.Value.Trim();               //创单结束时间
            int isReturn = Convert.ToInt16(this.ddlIsReturn.SelectedValue.Trim());           //是否退回
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);           //所选项目
            var NickId = Convert.ToInt32(this.ddlNick.SelectedValue);                            //店铺
            string ClaimCode = txtClaimCode.Text.Trim();            //理赔单号 
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

            var list = base.XMClaimInfoService.GetXMClaimInfoListByParm(fullName, orderCode, ClaimCode, Begin, End, isReturn, xMProjectId, nickids, responsiblePerson).GroupBy(p => p.ClaimRef).Select(g => g.First()).ToList();
            List = list;

            var pageList = new PagedList<HozestERP.BusinessLogic.ManageProject.XMClaimInfo>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClaimInfo, pageList);
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
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //删除根据字表审核状态  如有一个审核通过  主表将不允许删除   如都未审核  可删除
            string errMessage = "";
            bool isDelete = false;
            List<int> ClamInfoIDs = this.Master.GetSelectedIds(this.grdvClaimInfo);
            if (ClamInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            //else
            //{
            //    foreach (int ID in ClamInfoIDs)
            //    {
            //        var clamInfo = base.XMClaimInfoService.GetXMClaimInfoById(ID);
            //        if (clamInfo != null)
            //        {
            //            bool isConfirm = true;
            //            var claimDetai = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(clamInfo.Id);
            //            if (claimDetai != null && claimDetai.Count > 0)
            //            {
            //                foreach (XMClaimInfoDetail q in claimDetai)
            //                {
            //                    if (!q.IsConfirm.Value)
            //                    {
            //                        isConfirm = false;
            //                    }
            //                }
            //            }
            //            //理赔单已确认 无法删除
            //            if (isConfirm)
            //            {
            //                errMessage += "理赔单号为" + clamInfo.ClaimRef + "无法删除！";
            //                isDelete = true;
            //            }
            //        }
            //    }

            //    if (isDelete)
            //    {
            //        base.ShowMessage(errMessage);
            //    }
            //}
            if (!isDelete)
            {
                if (ClamInfoIDs.Count <= 0)
                {
                    base.ShowMessage("你没有选择任何记录！");
                    return;
                }
                else
                {
                    foreach (int ID in ClamInfoIDs)
                    {
                        var clamInfo = base.XMClaimInfoService.GetXMClaimInfoById(ID);
                        if (clamInfo != null)
                        {
                            //删除主表
                            clamInfo.IsEnable = true;
                            clamInfo.UpdateDate = DateTime.Now;
                            clamInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMClaimInfoService.UpdateXMClaimInfo(clamInfo);
                            //删除对应从表
                            var claimDetails = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(clamInfo.Id);
                            if (claimDetails != null && claimDetails.Count > 0)
                            {
                                foreach (XMClaimInfoDetail details in claimDetails)
                                {
                                    details.IsEnable = true;
                                    details.UpdateDate = DateTime.Now;
                                    details.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    base.XMClaimInfoDetailService.UpdateXMClaimInfoDetail(details);
                                }
                            }
                        }
                    }
                }
            }
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            if (!isDelete)
            {
                base.ShowMessage("操作成功！");
            }
        }

        protected void grdvClaimInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as HozestERP.BusinessLogic.ManageProject.XMClaimInfo;
                ImageCheckBox imageIsComfirm = e.Row.FindControl("chkManagerIsAudit") as ImageCheckBox;
                ImageButton imgClaimDetail = e.Row.FindControl("imgClaimDetail") as ImageButton;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑理赔单','" + CommonHelper.GetStoreLocation()
                        + "ManageProject/XMClaimInfoAdd.aspx?Type=1"
                        + "&&ClaimInfoID=" + info.Id
                        + "',1200,500, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgClaimDetail != null)
                {
                    imgClaimDetail.OnClientClick = "return ShowWindowDetail('查看理赔单','" + CommonHelper.GetStoreLocation() +
                        "ManageProject/XMClaimInfoAdd.aspx?Type=2"
                        + "&&ClaimInfoID=" + info.Id
                        + "',1200,500, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }

                //根据明细确认
                bool isConfirm = true;
                var claimDetai = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(info.Id);
                if (claimDetai != null && claimDetai.Count > 0)
                {
                    foreach (XMClaimInfoDetail q in claimDetai)
                    {
                        if (!q.IsConfirm.Value)
                        {
                            isConfirm = false;
                        }
                    }
                }
                imageIsComfirm.Checked = isConfirm;
                //财务确认后将无法编辑和删除
                if (isConfirm)
                {
                    if (imgBtnEdit != null)
                    {
                        imgBtnEdit.Visible = false;
                    }
                    //if (imgBtnDelete != null)
                    //{
                    //    imgBtnDelete.Visible = false;
                    //}
                }
            }
        }

        protected void grdvClaimInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    //删除主表  及相应从表
                    var Info = base.XMClaimInfoService.GetXMClaimInfoById(Convert.ToInt16(id));
                    if (Info != null)
                    {
                        //查询理赔单状态 如财务已确认 将无法删除  
                        //bool isConfirm = true;
                        //var claimDetai = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(Info.Id);
                        //if (claimDetai != null && claimDetai.Count > 0)
                        //{
                        //    foreach (XMClaimInfoDetail q in claimDetai)
                        //    {
                        //        if (!q.IsConfirm.Value)
                        //        {
                        //            isConfirm = false;
                        //        }
                        //    }
                        //}
                        //if (isConfirm)
                        //{
                        //    base.ShowMessage("财务已确认，将无法删除！");
                        //    return;
                        //}
                        Info.IsEnable = true;
                        Info.UpdateDate = DateTime.Now;
                        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMClaimInfoService.UpdateXMClaimInfo(Info);
                        //查询相应从表
                        var details = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(Info.Id);
                        if (details != null && details.Count > 0)
                        {
                            foreach (XMClaimInfoDetail p in details)
                            {
                                p.IsEnable = true;
                                p.UpdateDate = DateTime.Now;
                                p.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMClaimInfoDetailService.UpdateXMClaimInfoDetail(p);
                            }
                        }
                    }
                    base.ShowMessage("操作成功！");
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                }

            }
            #endregion
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        #endregion

        protected void btnClaimInfoExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    List<int> IDs = this.Master.GetSelectedIds(this.grdvClaimInfo);
                    List<HozestERP.BusinessLogic.ManageProject.XMClaimInfo> list = new List<HozestERP.BusinessLogic.ManageProject.XMClaimInfo>();
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\ClaimInfoExport", HttpContext.Current.Request.PhysicalApplicationPath);
                    if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = filePath + "//" + fileName;

                    BindGrid(Master.PageIndex, Master.PageSize);

                    if (IDs.Count <= 0)
                    {
                        list = List;
                    }
                    else
                    {
                        foreach (var a in List)
                        {
                            if (IDs.Contains(a.Id))
                            {
                                list.Add(a);
                            }
                        }
                    }

                    base.ExportManager.ExportClaimInfoToXls(filePath, list);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        protected void btnRowInfoExport_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> IDs = this.Master.GetSelectedIds(this.grdvClaimInfo);
                if (IDs.Count != 1)
                {
                    base.ShowMessage("请选择一行记录");
                    return;
                }


                string fileName = string.Format("ClaimInfo_{0}.doc", DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-fff"));
                string filePath = string.Format("{0}Upload\\ClaimInfo", HttpContext.Current.Request.PhysicalApplicationPath);
                if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = filePath + "\\" + fileName;


                ExportManager.ExportClaimInfoDocx(filePath, IDs[0]);
                CommonHelper.WriteResponseXls(filePath, fileName);



            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }
    }
}