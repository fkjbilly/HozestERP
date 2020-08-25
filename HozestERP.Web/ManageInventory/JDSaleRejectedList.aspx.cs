using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Customers;
using System.Transactions;
using HozestERP.BusinessLogic.ManageProject;
using System.Web;
using System.Text;

namespace HozestERP.Web.ManageInventory
{
    public partial class JDSaleRejectedList : BaseAdministrationPage, ISearchPage
    {
        private static List<XMJDSaleRejected> list_XMJDSaleRejected { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBind();
                this.btnRejectedAdd.OnClientClick = "return ShowWindowDetail('新增京东自营退货单','" + CommonHelper.GetStoreLocation() +
"ManageInventory/JDSaleRejectedAdd.aspx?Type=0"
+ "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                this.btnImportLogisticsFee.OnClientClick = "return ShowWindowDetail('导入物流费用数据','" + CommonHelper.GetStoreLocation() +
"ManageProject/ImportJdSaleLogisticsFee.aspx',750,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                BindGrid(1, Master.PageSize);
            }
        }

        //绑定
        private void loadBind()
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
                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvJdRejecedInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMJDSaleRejected;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imageDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                ImageButton imgProductDetails = e.Row.FindControl("imgProductDetails") as ImageButton;
                var ckbJDIsConfirm = e.Row.FindControl("JDIsConfirm") as HozestERP.Controls.ImageCheckBox;
                var ckbXBIsConfirm = e.Row.FindControl("XBIsConfirm") as HozestERP.Controls.ImageCheckBox;
                var ckbXLMIsConfirm = e.Row.FindControl("XLMIsConfirm") as HozestERP.Controls.ImageCheckBox;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('编辑京东自营退货单','" + CommonHelper.GetStoreLocation() +
        "ManageInventory/JDSaleRejectedAdd.aspx?Type=1"
          + "&&JdSaleRejectID=" + info.Id
        + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
                if (imgProductDetails != null)
                {
                    imgProductDetails.OnClientClick = "return ShowWindowDetail('查看京东自营退货单','" + CommonHelper.GetStoreLocation() +
     "ManageInventory/JDSaleRejectedAdd.aspx?Type=2"
       + "&&JdSaleRejectID=" + info.Id
     + "',1200,600, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }

                var jdSaleRejected = base.XMJDSaleRejectedService.GetXMJDSaleRejectedById(info.Id);
                if (jdSaleRejected != null)
                {
                    bool jdConfirm = true;
                    bool xbConfirm = true;
                    bool xlmConfirm = true;
                    var detail = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(jdSaleRejected.Id);
                    if (detail != null && detail.Count > 0)
                    {
                        foreach (XMJDSaleRejectedProductDetail p in detail)
                        {
                            if (p.JDIsConfirm==false)
                            {
                                jdConfirm = false;
                            }
                            if (p.XBIsConfirm==false)
                            {
                                xbConfirm = false;
                            }
                            if (p.XLMIsConfirm==false)
                            {
                                xlmConfirm = false;
                            }
                        }
                    }
                    ckbJDIsConfirm.Checked = jdConfirm;
                    ckbXBIsConfirm.Checked = xbConfirm;
                    ckbXLMIsConfirm.Checked = xlmConfirm;
                    //if (jdConfirm && xbConfirm && xlmConfirm)
                    if (xlmConfirm)
                    {
                        if (imgBtnEdit != null)
                        {
                            imgBtnEdit.Visible = false;
                        }
                        if (imageDelete != null)
                        {
                            imageDelete.Visible = false;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvJdRejecedInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            try
            {
                if (e.CommandName.Equals("Del"))
                {
                    var id = e.CommandArgument.ToString();
                    if (!string.IsNullOrEmpty(id))//删除
                    {
                        var jdSaleRejecteds = base.XMJDSaleRejectedService.GetXMJDSaleRejectedById(int.Parse(id));
                        if (jdSaleRejecteds != null)
                        {
                            //事务
                            using (TransactionScope scope = new TransactionScope())
                            {
                                //删除从表
                                var details = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(jdSaleRejecteds.Id);
                                if (details != null && details.Count > 0)
                                {
                                    foreach (XMJDSaleRejectedProductDetail parm in details)
                                    {
                                        if (parm.JDIsConfirm.Value || parm.XBIsConfirm.Value || parm.XLMIsConfirm.Value)         //三项如有一项已经确认将无法删除
                                        {
                                            throw new Exception("退货单已经确认，无法执行删除操作！");
                                        }
                                        parm.IsEnable = true;
                                        parm.UpdateDate = DateTime.Now;
                                        parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMJDSaleRejectedProductDetailService.UpdateXMJDSaleRejectedProductDetail(parm);
                                    }
                                }
                                //删除主表
                                jdSaleRejecteds.IsEnable = true;
                                jdSaleRejecteds.UpdateDate = DateTime.Now;
                                jdSaleRejecteds.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMJDSaleRejectedService.UpdateXMJDSaleRejected(jdSaleRejecteds);

                                scope.Complete();

                                base.ShowMessage("操作成功！");
                            }
                        }
                        else
                        {
                            base.ShowMessage("未查到该数据！");
                        }
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    }
                }
            }
            catch(Exception ex)
            {
                base.ShowMessage(ex.Message);
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 根据用户customerID  获取用户 包含店铺列表
        /// </summary>
        /// <returns></returns>
        private string GetCustomerMappingNickIDs()
        {
            string nickids = "";
            int cutomerId = HozestERPContext.Current.User.CustomerID;
            var nicklist = base.XMNickCustomerMappingService.GetProjectXMNickCustomerMappingListByCustomerID(cutomerId);
            if (nicklist != null && nicklist.Count > 0)         //存在店铺列表
            {
                foreach (XMNickCustomerMapping map in nicklist)
                {
                    nickids = nickids + map.NickId + ",";
                }
            }
            if (nickids != "" && nickids.Length > 0)
            {
                nickids = nickids.Substring(0, nickids.Length - 1);
            }
            return nickids;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string nickids = "";
            //获取用户角色
            string nickids2 = GetCustomerMappingNickIDs();             //权限
            string rejectCode = txtRejectedCode.Text.Trim();
            string prepareCode = txtPrepareRef.Text.Trim();
            //开始日期
            string Begin = this.txtBeginDate.Value.Trim();
            //结束日期
            string End = this.txtEndDate.Value.Trim();
            string jdBegin = txtJDBeginDate.Value.Trim();
            string jdEnd = txtJDEndDate.Value.Trim();
            string xlmBegin = txtXLMBeginDate.Value.Trim();
            string xlmEnd = txtXLMEndDate.Value.Trim();
            int returnCategoryID = Convert.ToInt16(ddlReturnCategoryList.SelectedValue);
            var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
            var NickId = Convert.ToInt32(this.ddlNick.SelectedValue);
            var FactoryID= Convert.ToInt32(this.DdlFactory.SelectedValue);
            int jdIsConfirm = Convert.ToInt16(ddlJDIsConfirm.SelectedValue);
            int xbIsConfirm = Convert.ToInt16(ddlXBIsConfirm.SelectedValue);
            int xlmIsConfirm = Convert.ToInt16(ddlXLIIsConfirm.SelectedValue);
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
            var paramnote = this.txtNote.Text.Trim();
            var list = base.XMJDSaleRejectedService.GetXMJDSaleRejectedListByParm(rejectCode, Begin, End,jdBegin,jdEnd,xlmBegin,xlmEnd,returnCategoryID, xMProjectId, nickids, nickids2, FactoryID, jdIsConfirm, xbIsConfirm, xlmIsConfirm, paramnote, prepareCode);
            list_XMJDSaleRejected = list;
            var pageList = new PagedList<XMJDSaleRejected>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvJdRejecedInfo, pageList);
        }


        /// <summary>
        /// 京东收货确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnJDIsConfirm_Click(object sender, EventArgs e)
        {
            FormPanel1.Reset();
            window1.Show();
        }
        /// <summary>
        /// 新邦收货确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnXBIsConfirm_Click(object sender, EventArgs e)
        //{
        //    string errMessage = "退货单号为：";
        //    bool isConfirm = true;
        //    List<int> saleRejectedIDs = this.Master.GetSelectedIds(this.grdvJdRejecedInfo);
        //    if (saleRejectedIDs.Count <= 0)
        //    {
        //        base.ShowMessage("你没有选择任何记录");
        //        return;
        //    }
        //    else
        //    {
        //        foreach (int ID in saleRejectedIDs)
        //        {
        //            var jdSaleRejecteds = base.XMJDSaleRejectedService.GetXMJDSaleRejectedById(ID);
        //            if (jdSaleRejecteds != null)
        //            {
        //                var details = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(jdSaleRejecteds.Id);
        //                if (details != null && details.Count > 0)
        //                {
        //                    foreach (XMJDSaleRejectedProductDetail parm in details)
        //                    {
        //                        if (!parm.JDIsConfirm.Value)
        //                        {
        //                            isConfirm = false;
        //                            errMessage += jdSaleRejecteds.Ref + ",";
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    if (!isConfirm)
        //    {
        //        base.ShowMessage(errMessage + "京东未确认收货，无法执行相关操作！");
        //    }
        //    else
        //    {
        //        if (saleRejectedIDs.Count <= 0)
        //        {
        //            base.ShowMessage("你没有选择任何记录");
        //            return;
        //        }
        //        else
        //        {
        //            foreach (int ID in saleRejectedIDs)
        //            {
        //                var jdSaleRejecteds = base.XMJDSaleRejectedService.GetXMJDSaleRejectedById(ID);
        //                if (jdSaleRejecteds != null)
        //                {
        //                    var detail = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(ID);
        //                    if (detail != null && detail.Count > 0)
        //                    {
        //                        foreach (XMJDSaleRejectedProductDetail p in detail)
        //                        {
        //                            p.XBIsConfirm = true;
        //                            p.XBConfirmDate = jdSaleRejecteds.UpdateDate = DateTime.Now;
        //                            p.XBConfirmer = jdSaleRejecteds.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                            p.UpdateID = HozestERPContext.Current.User.CustomerID;
        //                            p.UpdateDate = DateTime.Now;
        //                            base.XMJDSaleRejectedService.UpdateXMJDSaleRejected(jdSaleRejecteds);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        base.ShowMessage("操作成功！");
        //    }
        //    BindGrid(this.Master.PageIndex, this.Master.PageSize);
        //}
        /// <summary>
        /// 喜临门确认收货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnXLMIsConfirm_Click(object sender, EventArgs e)
        {
            FormPanel2.Reset();
            window2.Show();
        }

        protected void btnJdSave_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            List<int> saleRejectedIDs = this.Master.GetSelectedIds(this.grdvJdRejecedInfo);
            if (saleRejectedIDs.Count <= 0)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录！").Show();
                return;
            }
            else
            {
                foreach (int ID in saleRejectedIDs)
                {
                    var details = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(ID);
                    if (details != null && details.Count > 0)
                    {
                        foreach (XMJDSaleRejectedProductDetail parm in details)
                        {
                            parm.JDIsConfirm = true;
                            parm.JDConfirmDate = DateTime.Parse(dfJdComfirmDate.Value.ToString());
                            parm.JDConfirmer = HozestERPContext.Current.User.CustomerID;
                            parm.UpdateDate = DateTime.Now;
                            parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMJDSaleRejectedProductDetailService.UpdateXMJDSaleRejectedProductDetail(parm);
                        }
                    }
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                Ext.Net.ExtNet.Msg.Alert("提示", "操作成功！").Show();
                window1.Hide();

            }
        }

        protected void btnXlmSave_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            string errMessage = "退货单号为：";
            bool isConfirm = true;
            List<int> saleRejectedIDs = this.Master.GetSelectedIds(this.grdvJdRejecedInfo);
            if (saleRejectedIDs.Count <= 0)
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录！").Show();
                return;
            }
            else
            {
                //foreach (int ID in saleRejectedIDs)
                //{
                //    var jdSaleRejecteds = base.XMJDSaleRejectedService.GetXMJDSaleRejectedById(ID);
                //    if (jdSaleRejecteds != null)
                //    {
                //        var detail = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(jdSaleRejecteds.Id);
                //        if (detail != null && detail.Count > 0)
                //        {
                //            foreach (XMJDSaleRejectedProductDetail p in detail)
                //            {
                //                if (!p.XBIsConfirm.Value)
                //                {
                //                    isConfirm = false;
                //                    errMessage += jdSaleRejecteds.Ref + ",";
                //                }
                //            }
                //        }
                //    }
                //}
            }
            if (!isConfirm)
            {
                base.ShowMessage(errMessage + "新邦未确认收货，无法执行相关操作！");
            }
            else
            {
                if (saleRejectedIDs.Count <= 0)
                {
                    Ext.Net.ExtNet.Msg.Alert("提示", "你没有选择任何记录！").Show();
                    return;
                }
                else
                {
                    foreach (int ID in saleRejectedIDs)
                    {
                        var jdSaleRejecteds = base.XMJDSaleRejectedService.GetXMJDSaleRejectedById(ID);
                        if (jdSaleRejecteds != null)
                        {
                            var details = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(jdSaleRejecteds.Id);
                            if (details != null && details.Count > 0)
                            {
                                foreach (XMJDSaleRejectedProductDetail parm in details)
                                {
                                    parm.XLMIsConfirm = true;
                                    parm.XLMConfirmDate = DateTime.Parse(dfXlmComfirmDate.Value.ToString());
                                    parm.UpdateDate = DateTime.Now;
                                    parm.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    parm.XLMConfirmer = jdSaleRejecteds.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    base.XMJDSaleRejectedService.UpdateXMJDSaleRejected(jdSaleRejecteds);
                                }
                            }
                        }
                    }
                }
                Ext.Net.ExtNet.Msg.Alert("提示", "操作成功！").Show();
                window2.Hide();
            }
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        /// <summary>
        /// 退货推送千胜系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendQS_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvJdRejecedInfo);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                foreach (int ID in IDs)
                {
                    var XMJDSaleRejected = base.XMJDSaleRejectedService.GetXMJDSaleRejectedById(ID);

                    string msg = "";
                    string method = "qs.returnorder.put";
                    StringBuilder body = new StringBuilder();
                    body = GetTHHPutJson(body, XMJDSaleRejected, ref msg);
                    if (body == null)
                    {
                        //msg += "发货单号：" + Info.DeliveryNumber + "，转换Json格式错误！";
                        continue;
                    }
                    XLMInterface myXLMInterface = new XLMInterface();
                    string url = myXLMInterface.GetUrl(method, body.ToString());
                    string josnStr = myXLMInterface.GetResponseData(body.ToString(), url);//GetInfo(url);
                    if (josnStr == "error")
                    {
                        msg += "网络连接错误，请稍后再试！";
                        break;
                    }

                    Dictionary<string, object> data = myXLMInterface.JsonToDictionary(josnStr);
                    if (data.ContainsKey("flag"))
                    {
                        msg += "退换货单号：" + XMJDSaleRejected.Ref + "，" + data["message"] + "！<br/>";
                    }
                    else
                    {
                        if (data["success"].ToString() != "True")
                        {
                            msg += "退换货单号：" + XMJDSaleRejected.Ref + "，" + data["message"] + "！<br/>";
                        }
                        else
                        {
                            var detail = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(ID);
                            if (detail != null && detail.Count > 0)
                            {
                                foreach (XMJDSaleRejectedProductDetail p in detail)
                                {
                                    p.XBIsConfirm = true;
                                    p.XBConfirmDate = XMJDSaleRejected.UpdateDate = DateTime.Now;//推送操作时间
                                    p.XBConfirmer = XMJDSaleRejected.UpdateID = HozestERPContext.Current.User.CustomerID;//推送操作人
                                    p.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    p.UpdateDate = DateTime.Now;
                                    base.XMJDSaleRejectedService.UpdateXMJDSaleRejected(XMJDSaleRejected);
                                }
                            }
                        }
                    }


                    if (msg != "")
                    {
                        base.ShowMessage(msg);
                    }
                    else
                    {
                        base.ShowMessage("喜临门退货推送成功！");

                        this.BindGrid(1, Master.PageSize);
                    }
                }
            }
        }

        public StringBuilder GetTHHPutJson(StringBuilder body, BusinessLogic.ManageInventory.XMJDSaleRejected myXMJDSaleRejected, ref string msg)
        {
            try
            {
                var myXMJDSaleRejectedProductDetailList = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(myXMJDSaleRejected.Id);
                if (myXMJDSaleRejectedProductDetailList.Count > 0)
                {
                    //退回工厂
                    string paraminWarehouseCode = "";
                    if (myXMJDSaleRejected.FactoryID != null)
                    {
                        var codelist = base.CodeService.GetCodeListInfoByCodeID(int.Parse(myXMJDSaleRejected.FactoryID.ToString()));
                        if (codelist != null)
                        {
                            paraminWarehouseCode = codelist.CodeName;
                        }
                    }
                    //退货原因
                    string paramreturnReason = "";
                    if (myXMJDSaleRejected.ReturnCategoryID != null)
                    {
                        var codelist = base.CodeService.GetCodeListInfoByCodeID(int.Parse(myXMJDSaleRejected.ReturnCategoryID.ToString()));
                        if (codelist != null)
                        {
                            paramreturnReason = codelist.CodeName;
                        }
                    }

                    //platReturnHeader
                    body.Append("{").Append("\"platReturnHeader\":{").Append("");
                    body.Append("\"inWarehouseCode\":").Append("\"" + paraminWarehouseCode + "\",");//退回仓库
                    body.Append("\"amount\":").Append("\"" + myXMJDSaleRejected.ReturnMoney + "\",");//支付金额
                    body.Append("\"payType\":").Append("\"001\",");//付款方式
                    body.Append("\"refundType\":").Append("\"2\",");//退换货类型
                    body.Append("\"tid\":").Append("\"" + myXMJDSaleRejected.Ref + "\",");//销售订单号
                    body.Append("\"outCode\":").Append("\"" + myXMJDSaleRejected.Ref + "\",");//外部编号
                    body.Append("\"returnReason\":").Append("\"" + paramreturnReason + "\",");//退换货原因
                    body.Append("\"remark\":").Append("\"" + myXMJDSaleRejected.Note.Replace("\r\n","") + ",ERP推送" + HozestERPContext.Current.User.CustomerID + "\"},");//备注

                    //platReturnDetails
                    body.Append("\"platReturnDetails\":[");


                    for (int i = 0; i < myXMJDSaleRejectedProductDetailList.Count; i++)
                    {
                        body.Append("{");
                        var detail = myXMJDSaleRejectedProductDetailList[i];
                        body.Append("\"totalFee\":").Append("\"" + detail.RejectionMoney + "\",");
                        body.Append("\"num\":").Append("\"" + detail.RejectionCount + "\",");
                        body.Append("\"outerSkuId\":").Append("\"" + detail.PlatformMerchantCode + "\",");
                        body.Append("\"price\":").Append("\"" + detail.RejectionPrice + "\",");
                        body.Append("\"sn\":").Append("\"99919\"}");
                        if (i != myXMJDSaleRejectedProductDetailList.Count - 1)
                        {
                            body.Append(",");
                        }
                    }
                    body.Append("]}");

                }
                else
                {
                    msg = "找不到退货商品！";
                }
                return body;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 导出京东自营退货单明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {

            string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
            string filePath = string.Format("{0}Upload\\JDSaleRejectedExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);
            var data=XMJDSaleRejectedService.Export(list_XMJDSaleRejected);
            ExportManager.ExportJDSaleRejectedExcel(filePath, data);
            CommonHelper.WriteResponseXls(filePath, fileName);
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(230, false);
            this.ddlReturnCategoryList.DataSource = codeList;
            this.ddlReturnCategoryList.DataTextField = "CodeName";
            this.ddlReturnCategoryList.DataValueField = "CodeID";
            this.ddlReturnCategoryList.DataBind();
            this.ddlReturnCategoryList.Items.Insert(0, new ListItem("---所有---", "-1"));
            this.ddlReturnCategoryList.Items[0].Selected = true;

            var CodeList1 = CodeService.GetCodeListInfoByCodeTypeID(245);
            this.DdlFactory.DataSource = CodeList1;
            this.DdlFactory.DataTextField = "CodeName";
            this.DdlFactory.DataValueField = "CodeID";
            this.DdlFactory.DataBind();
            this.DdlFactory.Items.Insert(0, new ListItem("---所有---", "-1"));
            this.DdlFactory.Items[0].Selected = true;
        }

        #endregion

    }
}