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

namespace HozestERP.Web.ManageProject
{
    public partial class XMClaimList : BaseAdministrationPage, ISearchPage
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
            //this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
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

            //平台类型动态数据绑定
            this.ddlPlatform.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatform.DataSource = codeList;
            this.ddlPlatform.DataTextField = "CodeName";
            this.ddlPlatform.DataValueField = "CodeID";
            this.ddlPlatform.DataBind();
            this.ddlPlatform.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            //索赔类型动态数据绑定
            this.ddlClaimType.Items.Clear();
            var ClaimTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(210, false);
            this.ddlClaimType.DataSource = ClaimTypeList;
            this.ddlClaimType.DataTextField = "CodeName";
            this.ddlClaimType.DataValueField = "CodeID";
            this.ddlClaimType.DataBind();
            this.ddlClaimType.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));

            this.txtBeginDate.Value = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            this.txtEndDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

            this.btnAdd.OnClientClick = "return ShowWindowDetail('索赔单添加','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMClaimAdd.aspx?Id=-1', 800, 500, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            this.BindGrid(paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
        }

        public void BindGrid(int paramPageIndex, int paramPageSize, string sortExpression, string sortDirection)
        {
            if (this.txtBeginDate.Value == "" || this.txtEndDate.Value == "")
            {
                base.ShowMessage("索赔单生成时间不能为空!");
                return;
            }

            var list = ClaimFormList();

            var pageList = new PagedList<XMClaimForm>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.gvQuestion, pageList, paramPageSize + 1);
        }

        public List<XMClaimForm> ClaimFormList()
        {
            int Platform = int.Parse(this.ddlPlatform.SelectedValue);//平台
            int nickid = int.Parse(this.ddlNick.SelectedValue);//店铺
            string ClaimNumber = this.txtClaimNumber.Text.Trim();//索赔单号
            int Financial = int.Parse(this.Financial.SelectedValue);//财务审核
            int ClaimType = int.Parse(this.ddlClaimType.SelectedValue);//索赔类型
            string ApplicationNo = this.txtApplicationNo.Text.Trim();//退货单号
            string OrderCode = this.txtOrderCode.Text.Trim();//订单号

            DateTime BeginDate = DateTime.Parse(this.txtBeginDate.Value);//开始时间
            DateTime EndDate = DateTime.Parse(this.txtEndDate.Value).AddDays(1).AddSeconds(-1);//结束时间

            var list = base.XMClaimFormService.GetXMClaimFormListByCondition(Platform, nickid, ClaimNumber, Financial, ClaimType, ApplicationNo, OrderCode, BeginDate, EndDate);
            return list;
        }

        #endregion

        protected void hidBtnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtEndDate.Value.Trim()) || string.IsNullOrEmpty(this.txtBeginDate.Value.Trim()))
            {
                base.ShowMessage("索赔单生成时间不能为空！");
                return;
            }

            DateTime dt = new DateTime();
            if (!DateTime.TryParse(txtBeginDate.Value.Trim(), out dt) || !DateTime.TryParse(txtEndDate.Value.Trim(), out dt))
            {
                base.ShowMessage("索赔单生成时间格式错误");
                return;
            }

            if (DateTime.Parse(txtEndDate.Value.Trim()) < DateTime.Parse(txtBeginDate.Value.Trim()))
            {
                base.ShowMessage("索赔单生成结束日期不能小于开始日期");
                return;
            }

            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 财务审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFin_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (IDs.Count <= 0)
                return;
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in IDs)
                {
                    var info = base.XMClaimFormService.GetXMClaimFormByID(item);
                    if (info != null)
                    {
                        info.FinancialStatus = true;
                        info.FinishTime = DateTime.Now;
                        info.UpdateDate = DateTime.Now;
                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMClaimFormService.UpdateXMClaimForm(info);
                    }
                    else
                    {
                        base.ShowMessage("财务审核失败，找不到索赔单！");
                        return;
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("财务审核成功！");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 财务反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinNo_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (IDs.Count <= 0)
                return;
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in IDs)
                {
                    var info = base.XMClaimFormService.GetXMClaimFormByID(item);
                    if (info != null)
                    {
                        info.FinancialStatus = false;
                        info.UpdateDate = DateTime.Now;
                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMClaimFormService.UpdateXMClaimForm(info);
                    }
                    else
                    {
                        base.ShowMessage("财务审核失败，找不到索赔单！");
                        return;
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("财务反审核成功.");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void gvQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMClaimForm;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;

                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('索赔单编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMClaimAdd.aspx?Id=" + info.ID + "', 800, 500, this, function(){document.getElementById('"
                   + this.hidBtnSearch.ClientID + "').click();});";
                }
            }
        }

        protected void gvQuestion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("ToDelete"))
            {
                var info = base.XMClaimFormService.GetXMClaimFormByID(Convert.ToInt32(e.CommandArgument));
                if (info != null)//删除
                {
                    info.IsEnable = true;
                    info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    info.UpdateDate = DateTime.Now;
                    base.XMClaimFormService.UpdateXMClaimForm(info);

                    var DetailList = base.XMClaimFormDetailService.GetXMClaimFormDetailListByClaimFormID(Convert.ToInt32(e.CommandArgument));
                    if (DetailList != null && DetailList.Count > 0)
                    {
                        foreach (XMClaimFormDetail one in DetailList)
                        {
                            base.XMClaimFormDetailService.DeleteXMClaimFormDetail(one.ID);
                        }
                    }
                                        
                    var list = ClaimFormList();
                    int rowscount = list.Count();//获取行数;
                    if (rowscount % this.Master.PageSize == 0)
                    {
                        this.BindGrid(this.Master.PageIndex - 1, this.Master.PageSize);
                    }
                    else
                    {
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    }

                    base.ShowMessage("删除成功！");
                }
            }
            #endregion
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> IDs = this.Master.GetSelectedIds(this.gvQuestion);
                if (IDs.Count != 1)
                {
                    base.ShowMessage("请选择一个且只能选择一个索赔单，再导出！");
                    return;
                }
                var info = base.XMClaimFormService.GetXMClaimFormByID(IDs[0]);
                if (info != null && (bool)(info.FinancialStatus) == false)
                {
                    base.ShowMessage("该索赔单财务还未审核，不能导出！");
                    return;
                }

                string fileName = string.Format("ClaimForm_{0}.doc", DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-fff"));
                string filePath = string.Format("{0}Upload\\ClaimForm", HttpContext.Current.Request.PhysicalApplicationPath);
                if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = filePath + "\\" + fileName;

                base.ExportManager.ExportClaimFormDocx(filePath, IDs[0]);
                CommonHelper.WriteResponseXls(filePath, fileName);
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> questionIDs = this.Master.GetSelectedIds(this.gvQuestion);
            if (questionIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var item in questionIDs)
                {
                    var xMQuestion = base.XMApplicationService.GetXMApplicationByID(item);
                    if (xMQuestion != null && xMQuestion.SupervisorStatus == false && xMQuestion.FinancialStatus == false)
                    {
                        xMQuestion.IsEnable = true;
                        xMQuestion.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xMQuestion.UpdateDate = DateTime.Now;
                        base.XMApplicationService.UpdateXMApplication(xMQuestion);

                        var del = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(item, 0, 0, 0);
                        foreach (var a in del)
                        {
                            base.XMApplicationExchangeService.DeleteXMApplicationExchange(a.ID);
                        }
                    }
                    else
                    {
                        base.ShowMessage("所选项不能删除的项.");
                        return;
                    }

                }
                scope.Complete();
            }
            base.ShowMessage("操作成功.");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
    }
}
