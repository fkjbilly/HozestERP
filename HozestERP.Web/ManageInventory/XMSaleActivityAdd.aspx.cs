using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageInventory
{
    public partial class XMSaleActivityAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                dpLogDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                if (this.Type == 1)   //编辑 绑定数据
                {
                    BindInfo();
                }
            }
        }

        //绑定项目和店铺下拉框
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
        /// 绑定数据
        /// </summary>
        private void BindInfo()
        {
            var saleActivities = base.XMActivityService.GetXMActivityById(this.Id);
            if (saleActivities != null)
            {
                txtActivityTitle.Text = saleActivities.Title;
                dpLogDate.Value = saleActivities.ActivityDate.ToShortDateString();
                ddlActivityTypes.SelectedValue = saleActivities.ActivityTypeID.ToString();
                var product = base.XMProductService.GetXMProductById(saleActivities.ProductId);
                if (product != null)
                {
                    txtProductName.Text = product.ProductName;
                    txtPlatformMerchantCode.Text = product.ManufacturersCode;
                }
                if (saleActivities.ProjectId != null)
                {
                    ddXMProject.SelectedValue = saleActivities.ProjectId.ToString();
                }
                if (saleActivities.NickId != null)
                {
                    ddlNick.SelectedValue = saleActivities.NickId.ToString();
                }
                txtRemark.Text = saleActivities.Remark;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Type == 0)        //新增
            {
                string activityTitle = txtActivityTitle.Text.Trim();
                string productName = txtProductName.Text.Trim();
                string platformMerchantCode = txtPlatformMerchantCode.Text.Trim();
                if (activityTitle == "")
                {
                    base.ShowMessage("销售活动标题必须填写！");
                    return;
                }
                if (productName == "")
                {
                    base.ShowMessage("商品名称必须填写！");
                    return;
                }
                if (platformMerchantCode == "")
                {
                    base.ShowMessage("销售厂家编码必须填写！");
                    return;
                }

                DateTime ActivtyDate = dpLogDate.Value == "" ? Convert.ToDateTime(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(dpLogDate.Value);
                var activities = base.XMActivityService.GetXMActivityByParm(ActivtyDate, platformMerchantCode);
                if (activities != null)      //数据已经存在 无法新增
                {
                    base.ShowMessage("当前活动日期下该产品已经存在活动信息，无法添加！");
                    return;
                }
                //新增数据
                XMActivity saleActivities = new XMActivity();
                saleActivities.ActivityDate = ActivtyDate;
                saleActivities.Title = activityTitle;
                var product = base.XMProductService.getXMProductByManufacturersCode(platformMerchantCode);
                if (product != null)
                {
                    saleActivities.ProductId = product.Id;
                    saleActivities.PlatformMerchantCode = product.ManufacturersCode;
                }
                if (!string.IsNullOrEmpty(ddlActivityTypes.SelectedValue))
                {
                    saleActivities.ActivityTypeID = int.Parse(ddlActivityTypes.SelectedValue);
                }
                saleActivities.Remark = txtRemark.Text.Trim();
                saleActivities.CreateDate = saleActivities.UpdateDate = DateTime.Now;
                saleActivities.CreateID = saleActivities.UpdateID = HozestERPContext.Current.User.CustomerID;
                saleActivities.IsEnable = false;
                if (int.Parse(ddlNick.SelectedValue) != -1 && int.Parse(ddlNick.SelectedValue) != 99)
                {
                    saleActivities.NickId = int.Parse(ddlNick.SelectedValue);
                }
                saleActivities.ProjectId = int.Parse(ddXMProject.SelectedValue);
                base.XMActivityService.InsertXMActivity(saleActivities);
                base.ShowMessage("操作成功！");
            }
            else                              //编辑
            {
                string activityTitle = txtActivityTitle.Text.Trim();
                string productName = txtProductName.Text.Trim();
                string platformMerchantCode = txtPlatformMerchantCode.Text.Trim();
                if (activityTitle == "")
                {
                    base.ShowMessage("销售活动标题必须填写！");
                    return;
                }
                if (productName == "")
                {
                    base.ShowMessage("商品名称必须填写！");
                    return;
                }
                if (platformMerchantCode == "")
                {
                    base.ShowMessage("销售厂家编码必须填写！");
                    return;
                }
                DateTime ActivtyDate = dpLogDate.Value == "" ? Convert.ToDateTime(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(dpLogDate.Value);
                var activityEdit = base.XMActivityService.GetXMActivityByParm(ActivtyDate, platformMerchantCode);
                var activities = base.XMActivityService.GetXMActivityById(this.Id);
                if (activityEdit != null && activities != null && activityEdit.Id != activities.Id)       //不是当前日期或当前产品  查询是否存在
                {
                    base.ShowMessage("当前活动日期与当前编辑不符！");
                    return;
                }
                if (activities != null)
                {
                    activities.ActivityDate = ActivtyDate;
                    var product = base.XMProductService.getXMProductByManufacturersCode(platformMerchantCode);
                    if (product != null)
                    {
                        activities.ProductId = product.Id;
                        activities.PlatformMerchantCode = product.ManufacturersCode;
                    }
                    if (ddlActivityTypes.SelectedValue != "")
                    {
                        activities.ActivityTypeID = int.Parse(ddlActivityTypes.SelectedValue);
                    }
                    activities.Remark = txtRemark.Text.Trim();
                    activities.UpdateDate = DateTime.Now;
                    activities.UpdateID = HozestERPContext.Current.User.CustomerID;
                    activities.Title = activityTitle;
                    activities.ProjectId = int.Parse(ddXMProject.SelectedValue);
                    if (int.Parse(ddlNick.SelectedValue) != -1 && int.Parse(ddlNick.SelectedValue) != 99)
                    {
                        activities.NickId = int.Parse(ddlNick.SelectedValue);
                    }
                    base.XMActivityService.UpdateXMActivity(activities);
                    base.ShowMessage("操作成功！");
                }
            }
        }

        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }


        public int Type
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }

        public void Face_Init()
        {
            var saleActivityTypes = base.XMActivityTypeService.GetXMActivityTypeList();
            this.ddlActivityTypes.DataSource = saleActivityTypes;
            this.ddlActivityTypes.DataTextField = "ActivityName";
            this.ddlActivityTypes.DataValueField = "Id";
            this.ddlActivityTypes.DataBind();
        }

        public void SetTrigger()
        {
        }
    }
}