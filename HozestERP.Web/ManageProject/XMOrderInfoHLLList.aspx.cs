using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using JdSdk.Domain;
using JdSdk.Domains;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Top.Api.Domain;
using Yhd.Api;
using Yhd.Api.Object;
using Yhd.Api.Request;
using Yhd.Api.Response;

namespace HozestERP.Web.ManageProject
{
    extern alias suning;
    public partial class XMOrderInfoHLLList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //付款开始时间
                this.txtPayDateStart.Value = Convert.ToDateTime(DateTime.Now).AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
                //付款结束时间
                this.txtPayDateEnd.Value = Convert.ToDateTime(DateTime.Now).AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss");

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
            this.Master.SetTitleVisible = false;

            //平台类型动态数据绑定
            this.ddPlatformTypeId.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddPlatformTypeId.DataSource = codeList;
            this.ddPlatformTypeId.DataTextField = "CodeName";
            this.ddPlatformTypeId.DataValueField = "CodeID";
            this.ddPlatformTypeId.DataBind();
            this.ddPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));
            this.ddPlatformTypeId.SelectedValue = "259";
            this.ddPlatformTypeId.Enabled = false;

            //订单状态数据绑定  
            this.ddOrderStatusId.Items.Clear();
            //List<Setting> settingList = base.SettingManager.GetSettingsList();
            //var newSetting = settingList.Where(p => p.Description.Contains("订单状态") && p.Value != "WAIT_SELLER_STOCK_OUT,WAIT_SELLER_SEND_GOODS").ToList();
            //this.ddOrderStatusId.DataSource = newSetting;
            //this.ddOrderStatusId.DataTextField = "Name";
            //this.ddOrderStatusId.DataValueField = "Value";
            //this.ddOrderStatusId.DataBind();
            this.ddOrderStatusId.Items.Insert(0, new ListItem("---所有---", "-1"));
            //this.ddOrderStatusId.Items.Insert(1, new ListItem("等待卖家发货", "WAIT_SELLER_STOCK_OUT,WAIT_SELLER_SEND_GOODS")); 
            //this.ddOrderStatusId.Items[1].Selected = true;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
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

            //订单状态
            string OrderStatusId = this.ddOrderStatusId.SelectedValue.Trim();
            //时间类型
            int timetype = int.Parse(this.ddlOrderStatus.SelectedValue.Trim());
            //平台类型Id
            int PlatformTypeId = Convert.ToInt32(this.ddPlatformTypeId.SelectedValue.ToString());
            //是否审单
            int IsAudit = -1;
            //付款时间
            DateTime? PayDateStart = Convert.ToDateTime(txtPayDateStart.Value.Trim());
            DateTime? PayDateEnd = Convert.ToDateTime(txtPayDateEnd.Value.Trim());
            //是否异常
            int IsAbnormal = -1;
            //异常备注
            bool remarks = false;
            //数据来源
            string SourceType = "-1";
            //网名
            string WantID = this.txtWantID.Text.Trim();
            //是否为我们的订单
            int IsOurOrder = 0;

            List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();
            orderInfoList = base.XMOrderInfoAPIService.GetXMOrderInfoListOther(xMProjectId, NickId, this.txtOrderCode.Text.Trim(),
                  this.txtFullName.Text.Trim(), OrderStatusId, PlatformTypeId, PayDateStart, PayDateEnd, IsAudit, remarks,
                  0, IsAbnormal, timetype, SourceType, WantID);

            var pageList = new PagedList<XMOrderInfo>(orderInfoList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, pageList);
        }

        #endregion

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
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                #region 删除
                if (e.CommandName.Equals("XMOrderInfoDelete"))
                {

                    var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(Convert.ToInt32(e.CommandArgument));

                    if (xMOrderInfo != null)//删除
                    {
                        XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                        record.PropertyName = "IsEnable";
                        record.OldValue = System.Convert.ToString(xMOrderInfo.IsEnable);
                        bool IsEnable = true;
                        record.NewValue = System.Convert.ToString(IsEnable);
                        record.OrderInfoId = Convert.ToInt32(e.CommandArgument);
                        record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        record.UpdateTime = DateTime.Now;
                        base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);

                        xMOrderInfo.IsEnable = true;
                        xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xMOrderInfo.UpdateDate = DateTime.Now;
                        base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfo);
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                        base.ShowMessage("操作成功.");
                    }

                }
                #endregion
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }
        }

        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMOrderInfo = e.Row.DataItem as XMOrderInfo;

                //异常行
                if (xMOrderInfo.IsAbnormal == true)
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }

                //查看详情
                ImageButton imgbtnOrderInfoDetail = e.Row.FindControl("imgbtnOrderInfoDetail") as ImageButton;
                if (imgbtnOrderInfoDetail != null)
                {
                    imgbtnOrderInfoDetail.OnClientClick = "return ShowWindowDetail('基本信息','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMOrderInfoOperation.aspx?ID=" + xMOrderInfo.ID + "&IsCM=0',1150, 700, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";

                }
                //操作记录
                ImageButton imgbtnOperatingRecords = e.Row.FindControl("imgbtnOperatingRecords") as ImageButton;
                if (imgbtnOperatingRecords != null)
                {
                    imgbtnOperatingRecords.OnClientClick = "return ShowWindowDetail('操作记录','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMOrderInfoOperatingRecords.aspx?ID=" + xMOrderInfo.ID + "&IsCM=0',1000, 550, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }
                //单个订单同步

                #region 平台名称
                Label PlatformTypeId = e.Row.FindControl("PlatformTypeId") as Label;
                List<CodeList> codeList = base.CodeService.GetCodeList(Convert.ToInt32(xMOrderInfo.PlatformTypeId));
                if (codeList.Count > 0)
                    PlatformTypeId.Text = codeList[0].CodeName;
                #endregion

                #region 发货地址
                Label lblDeliveryAddress = e.Row.FindControl("lblDeliveryAddress") as Label;
                string deliveryAddress = xMOrderInfo.DeliveryAddress;
                if (deliveryAddress != null && deliveryAddress != "")
                {
                    //var SdeliveryAddress = CutStr(deliveryAddress, 20);
                    if (deliveryAddress.Length > 6)
                    {
                        string SdeliveryAddress = deliveryAddress.Substring(0, 6);
                        lblDeliveryAddress.Text = SdeliveryAddress + "...";
                    }
                    else
                    {
                        lblDeliveryAddress.Text = deliveryAddress;
                    }
                }
                else
                {
                    lblDeliveryAddress.Text = "";

                }
                #endregion

                #region 备注
                Label lblRemarks = e.Row.FindControl("lblRemarks") as Label;
                string CustomerServiceRemark = xMOrderInfo.CustomerServiceRemark;
                if (CustomerServiceRemark != null && CustomerServiceRemark != "" && CustomerServiceRemark.Length > 8)
                {
                    //var SdeliveryAddress = CutStr(deliveryAddress, 20);
                    string strCRemarks = CustomerServiceRemark.Substring(0, 8);
                    lblRemarks.Text = strCRemarks + "...";
                    lblRemarks.ToolTip = CustomerServiceRemark;
                }
                else
                {
                    lblRemarks.Text = CustomerServiceRemark;
                    lblRemarks.ToolTip = CustomerServiceRemark;

                }
                #endregion

            }
        }

        /// <summary>
        /// 截取字符串，不限制字符串长度
        /// </summary>
        /// <param name="str">待截取的字符串</param>
        /// <param name="len">每行的长度，多于这个长度自动换行</param>
        /// <returns></returns>
        public string CutStr(string str, int len)
        {
            string s = "";

            for (int i = 0; i < str.Length; i++)
            {
                int r = i % len;
                int last = (str.Length / len) * len;
                if (i != 0 && i <= last)
                {

                    if (r == 0)
                    {
                        s += str.Substring(i - len, len) + "<br>";
                    }

                }
                else if (i > last)
                {
                    s += str.Substring(i - 1);
                    break;
                }
            }
            return s;
        }

        /// <summary>
        /// 导出订单数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOrderInfoExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\OrderInfoExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                    var xMProjectId = Convert.ToInt32(this.ddXMProject.SelectedValue);
                    bool IsAiPu = this.ddXMProject.SelectedValue == "13" ? true : false;//项目名称为艾谱
                    bool IsYingYi = this.ddXMProject.SelectedValue == "17" ? true : false;

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

                    //订单状态
                    string OrderStatusId = this.ddOrderStatusId.SelectedValue.Trim();
                    //时间类型
                    int timetype = int.Parse(this.ddlOrderStatus.SelectedValue.Trim());
                    //平台类型Id
                    int PlatformTypeId = Convert.ToInt32(this.ddPlatformTypeId.SelectedValue.ToString());
                    //是否审单
                    int IsAudit = -1;
                    //付款时间
                    DateTime? PayDateStart = Convert.ToDateTime(txtPayDateStart.Value.Trim());
                    DateTime? PayDateEnd = Convert.ToDateTime(txtPayDateEnd.Value.Trim());
                    //是否异常
                    int IsAbnormal = -1;
                    //异常备注
                    bool remarks = false;
                    //数据来源
                    string SourceType = "-1";
                    //网名
                    string WantID = this.txtWantID.Text.Trim();
                    //是否为我们的订单
                    int IsOurOrder = 0;

                    List<XMOrderInfo> orderInfoList = new List<XMOrderInfo>();
                    orderInfoList = base.XMOrderInfoAPIService.GetXMOrderInfoListOther(xMProjectId, NickId, this.txtOrderCode.Text.Trim(),
                  this.txtFullName.Text.Trim(), OrderStatusId, PlatformTypeId, PayDateStart, PayDateEnd, IsAudit, remarks,
                  0, IsAbnormal, timetype, SourceType, WantID);

                    base.ExportManager.ExportXMOrderInfoToXlsOfVPH(filePath, orderInfoList.Distinct().ToList(), xMProjectId, IsAiPu, IsYingYi);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        /// <summary>
        /// 平台类型关联订单状态 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddPlatformTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddPlatformTypeId.SelectedValue != "-1")
            {
                var codetypeinfo = base.CodeTypeService.GetCodeTypeByPlatFormTypeId(this.ddPlatformTypeId.SelectedValue.Trim()).SingleOrDefault();
                var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(codetypeinfo.CodeTypeID);

                this.ddOrderStatusId.Items.Clear();
                this.ddOrderStatusId.DataSource = codeList;
                this.ddOrderStatusId.DataValueField = "CodeNO";
                this.ddOrderStatusId.DataTextField = "CodeName";
                this.ddOrderStatusId.DataBind();
                this.ddOrderStatusId.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
        }

        /// <summary>
        /// 判断是否审核
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        protected bool IsAudit(string ID)
        {
            if (ID != null && ID != "")
            {
                var xmorderinfo = base.XMOrderInfoService.GetXMOrderInfoByID(int.Parse(ID));

                if (xmorderinfo.XM_OrderInfoProductDetails != null && xmorderinfo.XM_OrderInfoProductDetails.Count > 0)
                {
                    var productinfo = xmorderinfo.XM_OrderInfoProductDetails.ToList().Where(p => p.IsAudit == true).ToList();

                    if (productinfo != null && productinfo.Count > 0)
                    {
                        return true;//有审核过
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 判断是否排单
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        protected bool IsSingleRow(string ID)
        {
            if (ID != null && ID != "")
            {
                var xmorderinfo = base.XMOrderInfoService.GetXMOrderInfoByID(int.Parse(ID));

                if (xmorderinfo.XM_OrderInfoProductDetails != null && xmorderinfo.XM_OrderInfoProductDetails.Count > 0)
                {
                    var productinfo = xmorderinfo.XM_OrderInfoProductDetails.ToList().Where(p => p.IsSingleRow == true).ToList();

                    if (productinfo != null && productinfo.Count > 0)
                    {
                        return true;//有审核过
                    }
                }
            }
            return false;
        }
    }
}