using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic;
using CRM.BusinessLogic.ManageContract;

namespace HozestERP.Web.ManageFinance
{  
    public partial class AdvanceApplicationList : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnDelete", "ManageFinance.AdvanceApplicationList.AdvanceApplicationDelete");//删除
                buttons.Add("btnAdd", "ManageFinance.AdvanceApplicationList.AdvanceApplicationAdd");//新增
                buttons.Add("imgbtnAdvanceApplicationDetail", "ManageFinance.AdvanceApplicationList.AdvanceApplicationBtnDetails");//明细
                buttons.Add("btnManagerIsAudit", "ManageFinance.AdvanceApplicationList.AdvanceApplicationManagerIsAudit");//部门审核btnManagerIsAuditNO
                buttons.Add("btnManagerIsAuditNO", "ManageFinance.AdvanceApplicationList.AdvanceApplicationManagerIsAuditNO");//部门反审核
                buttons.Add("btnFinanceIsAudit", "ManageFinance.AdvanceApplicationList.AdvanceApplicationFinanceIsAudit");//财务审核
                buttons.Add("btnFinanceIsAuditNO", "ManageFinance.AdvanceApplicationList.AdvanceApplicationFinanceIsAuditNO");//财务反审核
                buttons.Add("btnDirectorIsAudit", "ManageFinance.AdvanceApplicationList.AdvanceApplicationDirectorIsAudit");//总监审核
                buttons.Add("btnDirectorIsAuditNO", "ManageFinance.AdvanceApplicationList.AdvanceApplicationDirectorIsAuditNO");//总监反审核
                buttons.Add("btnFinanceOk", "ManageFinance.AdvanceApplicationList.AdvanceApplicationFinanceOk");//财务确认 
                //buttons.Add("btnOperationIsAudit", "ManageFinance.AdvanceApplicationList.AdvanceApplicationOperationIsAudit");//运营确认
                buttons.Add("btnFinanceEnd", "ManageFinance.AdvanceApplicationList.AdvanceApplicationFinanceEnd");//暂支结束 
                buttons.Add("ImagebtnPrint", "ManageFinance.AdvanceApplicationList.AdvanceApplicationbtnPrint");//打印查看
                
                
                return buttons;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (this.ParametersTypeId == 1)
                { //财务部-》主管管理-》暂支审核

                    #region 店铺名称绑定

                    //店铺数据源 
                    if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                    {
                        this.ddlNickId.Items.Clear();
                        var NickList = base.XMNickService.GetXMNickList();
                        var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                        this.ddlNickId.DataSource = newNickList;
                        this.ddlNickId.DataTextField = "nick";
                        this.ddlNickId.DataValueField = "nick_id";
                        this.ddlNickId.DataBind();
                        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    }
                    else
                    {
                        //其他
                        //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                        var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                        if (xMNickList.Count() == 0)
                        {
                            this.ddlNickId.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                        }
                        if (xMNickList.Count > 0)
                        {
                            this.ddlNickId.Items.Clear();
                            this.ddlNickId.DataSource = xMNickList;
                            this.ddlNickId.DataTextField = "nick";
                            this.ddlNickId.DataValueField = "nick_id";
                            this.ddlNickId.DataBind();
                            //this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                        }
                    }

                    #endregion 
                    //this.ddlNickId.Items.Clear();
                    //var NickList = base.XMNickService.GetXMNickList();
                    //var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                    //this.ddlNickId.DataSource = newNickList;
                    //this.ddlNickId.DataTextField = "nick";
                    //this.ddlNickId.DataValueField = "nick_id";
                    //this.ddlNickId.DataBind();
                    //this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));

                    this.ddManagerIsAudit.Enabled = false;
                    this.ddManagerIsAudit.Items[2].Selected = true; 
                    this.ddFinanceIsAudit.Enabled = true;
                    this.ddFinanceOkIsAudit.Enabled = true; 

                }
                if (this.ParametersTypeId == 2)
                { //财务部-》财务管理-》暂支确认

                    #region 店铺名称绑定

                    //店铺数据源 
                    if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                    {
                        this.ddlNickId.Items.Clear();
                        var NickList = base.XMNickService.GetXMNickList();
                        var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                        this.ddlNickId.DataSource = newNickList;
                        this.ddlNickId.DataTextField = "nick";
                        this.ddlNickId.DataValueField = "nick_id";
                        this.ddlNickId.DataBind();
                        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    }
                    else
                    {
                        //其他
                        //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                        var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                        if (xMNickList.Count() == 0)
                        {
                            this.ddlNickId.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                        }
                        if (xMNickList.Count > 0)
                        {
                            this.ddlNickId.Items.Clear();
                            this.ddlNickId.DataSource = xMNickList;
                            this.ddlNickId.DataTextField = "nick";
                            this.ddlNickId.DataValueField = "nick_id";
                            this.ddlNickId.DataBind();
                            //this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                        }
                    }

                    #endregion 
                    //this.ddlNickId.Items.Clear();
                    //var NickList = base.XMNickService.GetXMNickList();
                    //var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                    //this.ddlNickId.DataSource = newNickList;
                    //this.ddlNickId.DataTextField = "nick";
                    //this.ddlNickId.DataValueField = "nick_id";
                    //this.ddlNickId.DataBind();
                    //this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));

                    this.ddManagerIsAudit.Enabled = false;
                    this.ddManagerIsAudit.Items[2].Selected = true; 
                    this.ddFinanceIsAudit.Enabled = false;
                    this.ddFinanceIsAudit.Items[2].Selected = true; 
                    this.ddFinanceOkIsAudit.Enabled = true;
                }
                if (this.ParametersTypeId == 3)
                { //项目部-》项目管理-》暂支申请

                    #region 店铺名称绑定

                    //店铺数据源 
                    if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                    {
                        this.ddlNickId.Items.Clear();
                        var NickList = base.XMNickService.GetXMNickList();
                        var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                        this.ddlNickId.DataSource = newNickList;
                        this.ddlNickId.DataTextField = "nick";
                        this.ddlNickId.DataValueField = "nick_id";
                        this.ddlNickId.DataBind();
                        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    }
                    else
                    {
                        //其他
                        //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                        var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                        if (xMNickList.Count() == 0)
                        {
                            this.ddlNickId.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                        }
                        if (xMNickList.Count > 0)
                        {
                            this.ddlNickId.Items.Clear();
                            this.ddlNickId.DataSource = xMNickList;
                            this.ddlNickId.DataTextField = "nick";
                            this.ddlNickId.DataValueField = "nick_id";
                            this.ddlNickId.DataBind();
                            //this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                        }
                    }

                    #endregion 
                    //this.ddlNickId.Items.Clear();
                    //var NickList = base.XMNickService.GetXMNickList();
                    //var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                    //this.ddlNickId.DataSource = newNickList;
                    //this.ddlNickId.DataTextField = "nick";
                    //this.ddlNickId.DataValueField = "nick_id";
                    //this.ddlNickId.DataBind();
                    //this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));

                    this.ddManagerIsAudit.Enabled = true;
                    //this.ddManagerIsAudit.Items[2].Selected = true;
                    this.ddFinanceIsAudit.Enabled = false;
                    this.ddFinanceOkIsAudit.Enabled = false; 
                }
                if (this.ParametersTypeId == 4)
                { //项目部-》主管管理-》暂支管理

                    #region 店铺名称绑定

                    //店铺数据源 
                    if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                    {
                        this.ddlNickId.Items.Clear();
                        var NickList = base.XMNickService.GetXMNickList();
                        var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                        this.ddlNickId.DataSource = newNickList;
                        this.ddlNickId.DataTextField = "nick";
                        this.ddlNickId.DataValueField = "nick_id";
                        this.ddlNickId.DataBind();
                        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    }
                    else
                    {
                        //其他
                        //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                        var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                        if (xMNickList.Count() == 0)
                        {
                            this.ddlNickId.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                        }
                        if (xMNickList.Count > 0)
                        {
                            this.ddlNickId.Items.Clear();
                            this.ddlNickId.DataSource = xMNickList;
                            this.ddlNickId.DataTextField = "nick";
                            this.ddlNickId.DataValueField = "nick_id";
                            this.ddlNickId.DataBind();
                            //this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                        }
                    }

                    #endregion 
                    //if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84)
                    //{
                    //    this.ddlNickId.Items.Clear();
                    //    var NickList = base.XMNickService.GetXMNickList();
                    //    var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                    //    this.ddlNickId.DataSource = newNickList;
                    //    this.ddlNickId.DataTextField = "nick";
                    //    this.ddlNickId.DataValueField = "nick_id";
                    //    this.ddlNickId.DataBind();
                    //    this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    //}
                    //else
                    //{
                    //    //项目经理
                    //    var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ProjectManager);

                    //    if (xMNickList.Count > 0)
                    //    {
                    //        this.ddlNickId.Items.Clear();
                    //        this.ddlNickId.DataSource = xMNickList;
                    //        this.ddlNickId.DataTextField = "nick";
                    //        this.ddlNickId.DataValueField = "nick_id";
                    //        this.ddlNickId.DataBind();
                    //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    //    }

                    //    //店长
                    //    var xMNickListShopOwner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ShopOwner);
                    //    if (xMNickListShopOwner.Count > 0)
                    //    {

                    //        this.ddlNickId.Items.Clear();
                    //        this.ddlNickId.DataSource = xMNickListShopOwner;
                    //        this.ddlNickId.DataTextField = "nick";
                    //        this.ddlNickId.DataValueField = "nick_id";
                    //        this.ddlNickId.DataBind();
                    //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    //    }

                    //    //项目负责人
                    //    List<int> projectIdList = new List<int>();
                    //    var XMProjectList = base.XMProjectService.GetXMProjectCustomerId(HozestERPContext.Current.User.CustomerID);
                    //    if (XMProjectList.Count > 0)
                    //    {
                    //        projectIdList = XMProjectList.Select(p => p.Id).ToList();
                    //    }

                    //    var XMNickList = base.XMNickService.GetXMNickListByProjectId(projectIdList);
                    //    if (XMNickList.Count > 0)
                    //    {

                    //        this.ddlNickId.Items.Clear();
                    //        this.ddlNickId.DataSource = XMNickList;
                    //        this.ddlNickId.DataTextField = "nick";
                    //        this.ddlNickId.DataValueField = "nick_id";
                    //        this.ddlNickId.DataBind();
                    //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    //    }


                    //    //项目经理、店长、项目负责人 都返回店铺信息  以项目负责人为准
                    //    if (xMNickList.Count > 0 && xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
                    //    {
                    //        this.ddlNickId.Items.Clear();
                    //        this.ddlNickId.DataSource = XMNickList;
                    //        this.ddlNickId.DataTextField = "nick";
                    //        this.ddlNickId.DataValueField = "nick_id";
                    //        this.ddlNickId.DataBind();
                    //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    //    }

                    //    //项目经理、店长 都返回店铺信息  以项目经理为准
                    //    if (xMNickList.Count > 0 && xMNickListShopOwner.Count > 0)
                    //    {
                    //        this.ddlNickId.Items.Clear();
                    //        this.ddlNickId.DataSource = xMNickList;
                    //        this.ddlNickId.DataTextField = "nick";
                    //        this.ddlNickId.DataValueField = "nick_id";
                    //        this.ddlNickId.DataBind();
                    //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    //    }

                    //    //项目经理、项目负责人 都返回店铺信息  以项目负责人为准
                    //    if (xMNickList.Count > 0 && XMNickList.Count > 0)
                    //    {
                    //        this.ddlNickId.Items.Clear();
                    //        this.ddlNickId.DataSource = XMNickList;
                    //        this.ddlNickId.DataTextField = "nick";
                    //        this.ddlNickId.DataValueField = "nick_id";
                    //        this.ddlNickId.DataBind();
                    //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    //    }

                    //    //店长、项目负责人 都返回店铺信息  以项目负责人为准
                    //    if (xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
                    //    {
                    //        this.ddlNickId.Items.Clear();
                    //        this.ddlNickId.DataSource = XMNickList;
                    //        this.ddlNickId.DataTextField = "nick";
                    //        this.ddlNickId.DataValueField = "nick_id";
                    //        this.ddlNickId.DataBind();
                    //        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    //    }


                    //}

                    this.ddManagerIsAudit.Enabled = true;
                    this.ddFinanceIsAudit.Enabled = true;
                    this.ddFinanceOkIsAudit.Enabled = true;
                }
                else {
                    #region 店铺名称绑定

                    //店铺数据源 
                    if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                    {
                        this.ddlNickId.Items.Clear();
                        var NickList = base.XMNickService.GetXMNickList();
                        var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                        this.ddlNickId.DataSource = newNickList;
                        this.ddlNickId.DataTextField = "nick";
                        this.ddlNickId.DataValueField = "nick_id";
                        this.ddlNickId.DataBind();
                        this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                    }
                    else
                    {
                        //其他
                        //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                        var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                        if (xMNickList.Count() == 0)
                        {
                            this.ddlNickId.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                        }
                        if (xMNickList.Count > 0)
                        {
                            this.ddlNickId.Items.Clear();
                            this.ddlNickId.DataSource = xMNickList;
                            this.ddlNickId.DataTextField = "nick";
                            this.ddlNickId.DataValueField = "nick_id";
                            this.ddlNickId.DataBind();
                            //this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                        }
                    }

                    #endregion 
                //    this.ddlNickId.Items.Clear();
                //    var NickList = base.XMNickService.GetXMNickList();
                //    var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                //    this.ddlNickId.DataSource = newNickList;
                //    this.ddlNickId.DataTextField = "nick";
                //    this.ddlNickId.DataValueField = "nick_id";
                //    this.ddlNickId.DataBind();
                //    this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);


            this.Master.SetTrigger(this.btnManagerIsAudit.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnManagerIsAuditNO.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnFinanceIsAudit.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnFinanceIsAuditNO.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnFinanceOk.UniqueID, this.Page); 
            this.Master.SetTrigger(this.btnFinanceEnd.UniqueID, this.Page);
           // this.Master.SetTrigger(this.hidBtnFinanceOk.UniqueID, this.Page); 
            this.Master.SetTrigger(this.btnDirectorIsAudit.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnDirectorIsAuditNO.UniqueID, this.Page);
           // this.Master.SetTrigger(this.btnOperationIsAudit.UniqueID, this.Page);

            
        }

        public void Face_Init()
        {
            
            this.Master.SetTitle("暂支查询"); 
            //this.Master.SetTitleVisible = false; 
            //平台类型动态数据绑定
            this.ddlPlatformTypeId.Items.Clear();
            var codePlatformTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatformTypeId.DataSource = codePlatformTypeList;
            this.ddlPlatformTypeId.DataTextField = "CodeName";
            this.ddlPlatformTypeId.DataValueField = "CodeID";
            this.ddlPlatformTypeId.DataBind();
            this.ddlPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));

             
            //this.ddAdvanceState.Items.Clear();
            //var codeAdvanceStateList = base.CodeService.GetCodeListInfoByCodeTypeID(183, false);
            //this.ddAdvanceState.DataSource = codeAdvanceStateList;
            //this.ddAdvanceState.DataTextField = "CodeName";
            //this.ddAdvanceState.DataValueField = "CodeID";
            //this.ddAdvanceState.DataBind();
            //this.ddAdvanceState.Items.Insert(0, new ListItem("---所有---", "-1"));

            this.btnAdd.OnClientClick = "return ShowWindowDetail('暂支申请','" + CommonHelper.GetStoreLocation()
          + "ManageFinance/AdvanceApplicationAdd.aspx?ScalpingId=" + this.ScalpingId + "',900, 350, this, function(){document.getElementById('"
          + this.btnSearch.ClientID + "').click();});";
             
             
               
        }


        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
             
                List<int> nickIdList = new List<int>();
                if (this.ParametersTypeId == 4)
                { //项目部-》主管管理-》暂支管理


                    if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                    {

                        nickIdList.Add(Convert.ToInt32(this.ddlNickId.SelectedValue));

                    }
                    else
                    {
                        if (this.ddlNickId.SelectedValue == "")
                        {

                            if (this.ddlNickId.SelectedValue == "-1")
                            {
                                #region 店铺名称绑定

                                //店铺数据源 
                                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                                {
                                    this.ddlNickId.Items.Clear();
                                    var NickList = base.XMNickService.GetXMNickList();
                                    var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                                    this.ddlNickId.DataSource = newNickList;
                                    this.ddlNickId.DataTextField = "nick";
                                    this.ddlNickId.DataValueField = "nick_id";
                                    this.ddlNickId.DataBind();
                                    this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                                }
                                else
                                {
                                    //其他
                                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                                    var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                                    if (xMNickList.Count() == 0)
                                    {
                                        this.ddlNickId.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                                    }
                                    if (xMNickList.Count > 0)
                                    {
                                        this.ddlNickId.Items.Clear();
                                        this.ddlNickId.DataSource = xMNickList;
                                        this.ddlNickId.DataTextField = "nick";
                                        this.ddlNickId.DataValueField = "nick_id";
                                        this.ddlNickId.DataBind();
                                        //this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));
                                    }
                                }

                                #endregion 
                                ////项目经理
                                //var xMNickListProjectManager = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ProjectManager);

                                //if (xMNickListProjectManager.Count > 0)
                                //{
                                //    nickIdList = xMNickListProjectManager.Select(p => p.nick_id).ToList();
                                //}

                                ////店长
                                //var xMNickListShopOwner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ShopOwner);
                                //if (xMNickListShopOwner.Count > 0)
                                //{

                                //    nickIdList = xMNickListShopOwner.Select(p => p.nick_id).ToList();
                                //}

                                ////项目负责人
                                //List<int> projectIdList = new List<int>();
                                //var XMProjectList = base.XMProjectService.GetXMProjectCustomerId(HozestERPContext.Current.User.CustomerID);
                                //if (XMProjectList.Count > 0)
                                //{
                                //    projectIdList = XMProjectList.Select(p => p.Id).ToList();
                                //}

                                //var XMNickList = base.XMNickService.GetXMNickListByProjectId(projectIdList);
                                //if (XMNickList.Count > 0)
                                //{

                                //    nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                                //}


                                ////项目经理、店长、项目负责人 都返回店铺信息  以项目负责人为准
                                //if (xMNickListProjectManager.Count > 0 && xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
                                //{

                                //    nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                                //}
                                ////项目经理、店长 都返回店铺信息  以项目经理为准
                                //if (xMNickListProjectManager.Count > 0 && xMNickListShopOwner.Count > 0)
                                //{

                                //    nickIdList = xMNickListProjectManager.Select(p => p.nick_id).ToList();
                                //}
                                ////项目经理、项目负责人 都返回店铺信息  以项目负责人为准
                                //if (xMNickListProjectManager.Count > 0 && XMNickList.Count > 0)
                                //{

                                //    nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                                //}
                                ////店长、项目负责人 都返回店铺信息  以项目负责人为准
                                //if (xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
                                //{

                                //    nickIdList = XMNickList.Select(p => p.nick_id).ToList();
                                //}
                            }
                            else
                            {

                                nickIdList.Add(Convert.ToInt32(this.ddlNickId.SelectedValue));
                            }
                        }
                        else {
                            nickIdList.Add(Convert.ToInt32(this.ddlNickId.SelectedValue));
                            //nickIdList.Add(0);
                        }

                    }
                }
                else
                {
                    nickIdList.Add(Convert.ToInt32(this.ddlNickId.SelectedValue));
                }
                this.Master.BindData<AdvanceApplication>(this.grdAdvanceApplicationList
                         , base.AdvanceApplicationService.SearchAdvanceApplication(Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue)
                         , nickIdList, Convert.ToInt32(this.ddManagerIsAudit.SelectedValue)
                         , Convert.ToInt32(this.ddFinanceIsAudit.SelectedValue), Convert.ToInt32(this.ddFinanceOkIsAudit.SelectedValue), Convert.ToInt32(this.ddAdvanceState.SelectedValue),
                         this.txtScalpingCode.Text.Trim() , paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString()));
                
            
        }

        //private void BindGrid()
        //{
        //    this.BindGrid(1, this.Master.PageSize);
        //}
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
         

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void grdAdvanceApplicationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("AdvanceApplicationDelete"))
            {

                var advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(Convert.ToInt32(e.CommandArgument));

                if (advanceApplication != null)//删除
                {


                    advanceApplication.IsEnable = true;
                    advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    advanceApplication.UpdateTime = DateTime.Now;
                    base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    base.ShowMessage("操作成功.");
                }

            }
            #endregion
        }

        protected void grdAdvanceApplicationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 

                var advanceApplication = e.Row.DataItem as AdvanceApplication;

                #region 暂支状态处理
                Label lblAdvanceState = e.Row.FindControl("lblAdvanceState") as Label; 
                if (Convert.ToInt32(AdvanceStateEnum.TheAdvanceNoneDealWith) == advanceApplication.AdvanceState.Value) {

                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        lblAdvanceState.Text = "未处理";
                        e.Row.Cells[12].BackColor = System.Drawing.Color.Yellow;
                    }
                }
                else if (Convert.ToInt32(AdvanceStateEnum.TheAdvanceUse) == advanceApplication.AdvanceState.Value) {

                    lblAdvanceState.Text = "暂支使用中";
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Green;
                
                }
                else if (Convert.ToInt32(AdvanceStateEnum.TheAdvanceEnd) == advanceApplication.AdvanceState.Value)
                {

                    lblAdvanceState.Text = "暂支结束";
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Red;

                }
                #endregion

                //暂支总金额
                decimal TheAdvanceMoney= advanceApplication.TheAdvanceMoney.Value;


                //明细
                List<AdvanceApplicationDetail> advanceApplicationDetail = base.AdvanceApplicationDetailService.GetAdvanceApplicationDetailListByAdvanceId(advanceApplication.Id);

                #region 未领款=暂支总金额-已领款金额
                Label lblWLK = e.Row.FindControl("lblWLK") as Label;
                decimal sum = 0;//已领款金额
                if (advanceApplicationDetail.Count > 0)
                { 
                    var advanceApplicationDetailNew = advanceApplicationDetail.Where(p => p.AdvanceTypeId == 345).ToList();
                    if (advanceApplicationDetailNew.Count > 0)
                    {
                         sum = advanceApplicationDetailNew.Select(p => p.TheAdvanceMoney.Value).Sum();   
                    } 
                }
                //未领款=暂支总金额-已领款金额
                decimal YK = TheAdvanceMoney - sum; 
                lblWLK.Text = YK.ToString("0.##");
                #endregion

                #region 未还款


                #region 刷单订单总金额、总佣金

                decimal SalePriceSum = 0;
                decimal FeeSum = 0;
                decimal DeductionSum = 0;
                decimal SalePrice = 0;

                if (advanceApplication.ScalpingId!=null && advanceApplication.ScalpingId > 0)
                {
                    var scalpingList = base.XMScalpingService.GetXMScalpingByScalpingId(advanceApplication.ScalpingId.Value);

                    var scalpingListNew = scalpingList.Where(p => p.IsAbnormal == false).ToList();

                    //订单总销售额
                    SalePriceSum = scalpingListNew.Select(p => p.SalePrice == null ? 0 : p.SalePrice.Value).Sum();
                    //订单总佣金
                    FeeSum = scalpingListNew.Select(p => p.Fee == null ? 0 : p.Fee.Value).Sum();
                    //订单扣点
                    DeductionSum = scalpingListNew.Select(p => p.Deduction == null ? 0 : p.Deduction.Value).Sum();
                }

                #endregion

                Label lblWHK = e.Row.FindControl("lblWHK") as Label; 
                decimal HKsum = 0;
                if (advanceApplicationDetail.Count > 0)
                {
                    var advanceApplicationDetailNew = advanceApplicationDetail.Where(p => p.AdvanceTypeId == 346).ToList();
                    if (advanceApplicationDetailNew.Count > 0)
                    {
                        HKsum = advanceApplicationDetailNew.Select(p => p.TheAdvanceMoney.Value).Sum();
                       
                    } 
                }  

                decimal SY = 0;
                //订单回款=订单销售额-订单扣点 
                SalePrice = SalePriceSum - DeductionSum;
                if (advanceApplication.AdvanceState == (int)AdvanceStateEnum.TheAdvanceNoneDealWith)
                {
                    SY = 0;
                }
                if (advanceApplication.AdvanceState == (int)AdvanceStateEnum.TheAdvanceUse)
                {
                    //剩余还款金额=总暂支金额-已经还款金额-订单回款-订单佣金 -未领款金额-扣点
                    SY = TheAdvanceMoney - HKsum - SalePrice - FeeSum - YK - DeductionSum;
                }
                else
                {
                    //剩余还款金额=总暂支金额-已经还款金额 -未领款金额
                    SY = TheAdvanceMoney - HKsum - YK;
                }
                lblWHK.Text = "-" + SY.ToString("0.##");
                lblWHK.Style.Add("color", "red");
                

                #endregion


                #region 归还日期
                Label lblForecastReturnTime = e.Row.FindControl("lblForecastReturnTime") as Label;
                if (advanceApplication.ForecastReturnTime != null)
                {
                    if (advanceApplication.ForecastReturnTime.Value < DateTime.Now.AddDays(1) && SY >0)
                    { 
                        //未在归还日期内还款的 日期显示红色
                        lblForecastReturnTime.Text = advanceApplication.ForecastReturnTime.Value.ToString("yyyy-MM-dd");
                        lblForecastReturnTime.Style.Add("color", "red");
                    }
                    else
                    {
                        lblForecastReturnTime.Text = advanceApplication.ForecastReturnTime.Value.ToString("yyyy-MM-dd"); 
                    }
                }
                else {

                    lblForecastReturnTime.Text = "";
                }

                #endregion

                #region 暂支结束 不显示复选框
                CheckBox chkSelected = e.Row.FindControl("chkSelected") as CheckBox;
                if (chkSelected != null)
                { 
                    if (advanceApplication.AdvanceState == (int)AdvanceStateEnum.TheAdvanceEnd)
                    {
                        chkSelected.Visible = false;
                    }
                }

                #endregion

                #region 详情按钮
                //查看详情
                ImageButton imgbtnAdvanceApplicationDetail = e.Row.FindControl("imgbtnAdvanceApplicationDetail") as ImageButton;
                if (imgbtnAdvanceApplicationDetail != null)
                {
                    imgbtnAdvanceApplicationDetail.OnClientClick = "return ShowWindowDetail('暂支详情','" + CommonHelper.GetStoreLocation()
                   + "ManageFinance/AdvanceApplicationDetailManage.aspx?AdvanceId=" + advanceApplication.Id + "',900, 500, this, function(){document.getElementById('"
                   + this.btnSearch.ClientID + "').click();});";

                }
                #endregion

                #region 打印查看
                //打印查看
                ImageButton ImagebtnPrint = e.Row.FindControl("ImagebtnPrint") as ImageButton;
                if (ImagebtnPrint != null)
                {

                    if (advanceApplication.DirectorIsAudit != null)
                    {
                        if (advanceApplication.DirectorIsAudit.Value == true)
                        {

                            ImagebtnPrint.Visible = true;
                            ImagebtnPrint.OnClientClick = "return ShowWindowDetail('打印查看','" + CommonHelper.GetStoreLocation()
                           + "ManageFinance/PrintAdvanceApplication.aspx?AdvanceId=" + advanceApplication.Id + "',700, 370, this, function(){document.getElementById('"
                           + this.btnSearch.ClientID + "').click();});";
                        }
                        else {

                            ImagebtnPrint.Visible = false;
                        }
                    
                    }

                }
                #endregion


            }
        }

        /// <summary>
        /// 部门审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManagerIsAudit_Click(object sender, EventArgs e)
        {
            List<int> grdAdvanceApplicationIDs = this.Master.GetSelectedIds(this.grdAdvanceApplicationList);
            if (grdAdvanceApplicationIDs.Count <= 0)
              {
                  base.ShowMessage("你没有选择任何记录");
                  return;
              }
              else
              {
                  var AdvanceApplicationList = base.AdvanceApplicationService.GetAdvanceApplicationListById(grdAdvanceApplicationIDs);
                  var ManagerIsAuditTrue = AdvanceApplicationList.Where(a => a.ManagerIsAudit.Value == true).ToList();

                  if (ManagerIsAuditTrue.Count > 0)
                  {
                      base.ShowMessage("请选择部门未审核的数据.");
                      return;
                  }
                  foreach (GridViewRow row in grdAdvanceApplicationList.Rows)
                  {
                      CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                      if (chkSelected.Checked)
                      {
                          int Id = 0;
                          int.TryParse(this.grdAdvanceApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id); 
                         AdvanceApplication advanceApplication= base.AdvanceApplicationService.GetAdvanceApplicationById(Id);

                         if (advanceApplication != null)
                         {
                             advanceApplication.ManagerPeople = HozestERPContext.Current.User.CustomerID;
                             advanceApplication.ManagerIsAudit = true;
                             advanceApplication.ManagerTime = DateTime.Now;
                             advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                             advanceApplication.UpdateTime = DateTime.Now;
                             base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
                         } 

                      }
                  }
              }

            this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
            this.BindGrid(Master.PageIndex, Master.PageSize);

        }

        
        /// <summary>
        /// 部门反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnManagerIsAuditNO_Click(object sender, EventArgs e)
        {
            List<int> grdAdvanceApplicationIDs = this.Master.GetSelectedIds(this.grdAdvanceApplicationList);
            if (grdAdvanceApplicationIDs.Count <= 0)
              {
                  base.ShowMessage("你没有选择任何记录");
                  return;
              }
              else
              {
                  var AdvanceApplicationList = base.AdvanceApplicationService.GetAdvanceApplicationListById(grdAdvanceApplicationIDs);
                  var ManagerIsAuditFalse = AdvanceApplicationList.Where(a => a.ManagerIsAudit.Value == false && a.FinanceIsAudit.Value==false).ToList();

                  if (ManagerIsAuditFalse.Count > 0)
                  {
                      base.ShowMessage("请选择部门已审核的数据.");
                      return;
                  }
                 
                  var FinanceIsAuditTrue = AdvanceApplicationList.Where(a => a.FinanceIsAudit.Value == true).ToList();

                  if (FinanceIsAuditTrue.Count > 0)
                  {
                      base.ShowMessage("请选择财务未审核的数据.");
                      return;
                  }

                  foreach (GridViewRow row in grdAdvanceApplicationList.Rows)
                  {
                      CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                      if (chkSelected.Checked)
                      {
                          int Id = 0;
                          int.TryParse(this.grdAdvanceApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id); 
                         AdvanceApplication advanceApplication= base.AdvanceApplicationService.GetAdvanceApplicationById(Id);

                         if (advanceApplication != null)
                         {
                             advanceApplication.ManagerPeople = HozestERPContext.Current.User.CustomerID;
                             advanceApplication.ManagerIsAudit = false;
                             advanceApplication.ManagerTime = DateTime.Now;
                             advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                             advanceApplication.UpdateTime = DateTime.Now;
                             base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
                         } 

                      }
                  }
              }

            this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
            this.BindGrid(Master.PageIndex, Master.PageSize);

        }
        
        /// <summary>
        /// 财务审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinanceIsAudit_Click(object sender, EventArgs e)
        {

            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdAdvanceApplicationList);
            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            { 
                var AdvanceApplicationList = base.AdvanceApplicationService.GetAdvanceApplicationListById(customerInfoIDs); 
                var ManagerIsAuditFalse = AdvanceApplicationList.Where(a => a.ManagerIsAudit.Value == false).ToList();

                if (ManagerIsAuditFalse.Count > 0)
                {
                    base.ShowMessage("请选择部门已经审核的数据.");
                    return;
                }

                foreach (GridViewRow row in grdAdvanceApplicationList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.grdAdvanceApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(Id);

                        if (advanceApplication != null)
                        {
                            if (advanceApplication.ManagerIsAudit == true)
                            {
                                advanceApplication.FinancePeople = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.FinanceIsAudit = true;
                                advanceApplication.FinanceAuditTime = DateTime.Now;
                                advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.UpdateTime = DateTime.Now;
                                base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
                            }
                        }

                    }
                }
            }
            this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 财务反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinanceIsAuditNO_Click(object sender, EventArgs e)
        {

            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdAdvanceApplicationList);
            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {

                var AdvanceApplicationList = base.AdvanceApplicationService.GetAdvanceApplicationListById(customerInfoIDs);
                var DirectorIsAuditTrue = AdvanceApplicationList.Where(a => a.DirectorIsAudit.Value == true).ToList();

                if (DirectorIsAuditTrue.Count > 0)
                {
                    base.ShowMessage("请选择总监未审核的数据.");
                    return;
                }

                var FinanceIsAuditFalse = AdvanceApplicationList.Where(a => a.FinanceIsAudit.Value == false).ToList();

                if (FinanceIsAuditFalse.Count > 0)
                {
                    base.ShowMessage("请选择财务已审核的数据.");
                    return;
                }
                foreach (GridViewRow row in grdAdvanceApplicationList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.grdAdvanceApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(Id);

                        if (advanceApplication != null)
                        {
                           
                                advanceApplication.FinancePeople = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.FinanceIsAudit = false;
                                advanceApplication.FinanceAuditTime = DateTime.Now;
                                advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.UpdateTime = DateTime.Now;
                                base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
                           
                        }

                    }
                }
            }
            this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
         
        /// <summary>
        /// 总经理审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDirectorIsAudit_Click(object sender, EventArgs e)
        {

            List<int> DirectorIsAuditIDs = this.Master.GetSelectedIds(this.grdAdvanceApplicationList);
            if (DirectorIsAuditIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                var AdvanceApplicationList = base.AdvanceApplicationService.GetAdvanceApplicationListById(DirectorIsAuditIDs);
                var FinanceIsAuditFalse = AdvanceApplicationList.Where(a => a.FinanceIsAudit.Value == false).ToList();

                if (FinanceIsAuditFalse.Count > 0)
                {
                    base.ShowMessage("请选择财务已经审核的数据.");
                    return;
                }

                foreach (GridViewRow row in grdAdvanceApplicationList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.grdAdvanceApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(Id);

                        if (advanceApplication != null)
                        {
                            if (advanceApplication.FinanceIsAudit == true)
                            {
                                advanceApplication.DirectorPeople = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.DirectorIsAudit = true;
                                advanceApplication.DirectorTime = DateTime.Now;
                                advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.UpdateTime = DateTime.Now;
                                base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
                            }
                        }

                    }
                }
            }
            this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
         
        /// <summary>
        /// 总经理反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDirectorIsAuditNO_Click(object sender, EventArgs e)
        {

            List<int> DirectorIsAuditIDs = this.Master.GetSelectedIds(this.grdAdvanceApplicationList);
            if (DirectorIsAuditIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                var AdvanceApplicationList = base.AdvanceApplicationService.GetAdvanceApplicationListById(DirectorIsAuditIDs);
                var FinanceOkIsAuditFalse = AdvanceApplicationList.Where(a => a.FinanceOkIsAudit.Value == true).ToList();

                if (FinanceOkIsAuditFalse.Count > 0)
                {
                    base.ShowMessage("请选择财务未确认的数据.");
                    return;
                }

                var DirectorIsAuditFalse = AdvanceApplicationList.Where(a => a.DirectorIsAudit.Value == false).ToList();

                if (DirectorIsAuditFalse.Count > 0)
                {
                    base.ShowMessage("请选择总监已审核的数据.");
                    return;
                }

                foreach (GridViewRow row in grdAdvanceApplicationList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.grdAdvanceApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(Id);

                        if (advanceApplication != null)
                        {
                            if (advanceApplication.FinanceIsAudit == true)
                            {
                                advanceApplication.DirectorPeople = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.DirectorIsAudit = false;
                                advanceApplication.DirectorTime = DateTime.Now;
                                advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.UpdateTime = DateTime.Now;
                                base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
                            }
                        }

                    }
                }
            }
            this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }


        ///// <summary>
        ///// 财务确认(财务确认通过)
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void hidBtnFinanceOk_Click(object sender, EventArgs e)
        //{
        //    if (Session["SessionPayTypeId"] == null || Session["SessionFinanceOkId"] == null)
        //        return;
        //    try
        //    {
        //        var AdvanceApplicationIds = this.Master.GetSelectedIds(this.grdAdvanceApplicationList);

        //        if (AdvanceApplicationIds.Count > 0)
        //        {

        //            var AdvanceApplicationList = base.AdvanceApplicationService.GetAdvanceApplicationListById(AdvanceApplicationIds);
                     
        //            AdvanceApplication advanceApplication = null;

        //            for (int i = 0; i < AdvanceApplicationList.Count; i++)
        //            {
        //                AdvanceApplicationDetail advanceApplicationDetail = new AdvanceApplicationDetail();
        //                advanceApplication = AdvanceApplicationList[i];

        //                advanceApplicationDetail.AdvanceId = advanceApplication.Id;
        //                advanceApplicationDetail.AdvanceTypeId = 345;//暂支
        //                string payTypeId = Session["SessionPayTypeId"].ToString();
        //                advanceApplicationDetail.PayTypeId = Convert.ToInt32(payTypeId);//领款类型
        //                advanceApplicationDetail.TheAdvanceMoney = advanceApplication.TheAdvanceMoney.Value;
        //                string recipientsId = Session["SessionFinanceOkId"].ToString();//领款人
        //                advanceApplicationDetail.RecipientsId = Convert.ToInt32(recipientsId);
        //                advanceApplicationDetail.IsEnable = false;
        //                advanceApplicationDetail.CreatorID = HozestERPContext.Current.User.CustomerID;
        //                advanceApplicationDetail.CreateTime = DateTime.Now;
        //                advanceApplicationDetail.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                advanceApplicationDetail.UpdateTime = DateTime.Now;
        //                base.AdvanceApplicationDetailService.InsertAdvanceApplicationDetail(advanceApplicationDetail);

        //                advanceApplication.FinanceOkPeople = HozestERPContext.Current.User.CustomerID;
        //                advanceApplication.FinanceOkIsAudit = true;
        //                advanceApplication.AdvanceState = (int)AdvanceStateEnum.TheAdvanceUse;
        //                advanceApplication.FinanceOkTime = DateTime.Now;
        //                advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                advanceApplication.UpdateTime = DateTime.Now;
        //                base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
        //            }
        //        }
        //        this.Master.JsWrite("alert('确认成功。');RefreshSearch();", "");

        //        this.BindGrid();

        //    }
        //    catch (Exception err)
        //    {
        //        base.ProcessException(err);
        //    }
        //}

        ///// <summary>
        ///// 财务确认(财务已经审核通过、暂支未结束、财务未确认 （弹出财务确认窗口)
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void hidBtnFinanceOkF_Click(object sender, EventArgs e)
        //{
        //    string paramScript = "ShowWindowDetail1('b-win','财务确认','" + CommonHelper.GetStoreLocation() +
        //             "ManageFinance/AdvanceApplicationFinanceOk.aspx',500,200, this, function(){document.getElementById('"
        //             + this.hidBtnFinanceOk.ClientID + "').click();});";
        //    this.Master.JsWrite(paramScript, "");
        //}


        ///// <summary>
        ///// 财务确认 （判断已选择数据是否通过财务审核、是否暂支结束、是否财务已经确认）
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnFinanceOk_Click(object sender, EventArgs e)
        //{
              
        //    try
        //    {
        //        var AdvanceApplicationIds = this.Master.GetSelectedIds(this.grdAdvanceApplicationList);

        //        if (AdvanceApplicationIds.Count > 0)
        //        {
        //            var AdvanceApplicationList = base.AdvanceApplicationService.GetAdvanceApplicationListById(AdvanceApplicationIds);

        //            var DirectorIsAuditFalse = AdvanceApplicationList.Where(a => a.DirectorIsAudit.Value == false).ToList();
        //            var AdvanceStateEnd = AdvanceApplicationList.Where(a => a.AdvanceState == (int)AdvanceStateEnum.TheAdvanceEnd).ToList();
        //            var FinanceOkIsAuditTrue = AdvanceApplicationList.Where(a => a.FinanceOkIsAudit.Value == true).ToList();

        //            if (DirectorIsAuditFalse.Count > 0)
        //            {
        //                base.ShowMessage("请选择总监已经审核的数据.");
        //                return;
        //            } 
        //            if (AdvanceStateEnd.Count > 0)
        //            {
        //                base.ShowMessage("请选择暂支未结束的数据.");
        //                return;
        //            } 
        //           if (FinanceOkIsAuditTrue.Count > 0)
        //            {
        //                base.ShowMessage("请选择财务未确认的数据.");
        //                return;
        //            }
        //            //财务已经审核通过、暂支未结束、财务未确认 （弹出财务确认窗口）
        //           if (DirectorIsAuditFalse.Count == 0 && AdvanceStateEnd.Count == 0 && FinanceOkIsAuditTrue.Count == 0)
        //           {

        //               Session["SessionPayTypeId"] = null;
        //               Session["SessionFinanceOkId"] = null;
        //               string s = "document.getElementById('" + this.hidBtnFinanceOkF.ClientID + "').click();";
        //               this.Master.JsWrite(s, "");

        //           }
        //        }
               

        //    }
        //    catch (Exception err)
        //    {
        //        base.ProcessException(err);
        //    }

            
        //}
         
        /// <summary>
        /// 运营确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnOperationIsAudit_Click(object sender, EventArgs e)
        //{

        //    List<int> OperationIsAuditIDs = this.Master.GetSelectedIds(this.grdAdvanceApplicationList);
        //    if (OperationIsAuditIDs.Count <= 0)
        //    {
        //        base.ShowMessage("你没有选择任何记录");
        //        return;
        //    }
        //    else
        //    {
        //        var AdvanceApplicationList = base.AdvanceApplicationService.GetAdvanceApplicationListById(OperationIsAuditIDs);
        //        var FinanceOkIsAuditFalse = AdvanceApplicationList.Where(a => a.FinanceOkIsAudit.Value == false).ToList();

        //        if (FinanceOkIsAuditFalse.Count > 0)
        //        {
        //            base.ShowMessage("请选择财务已经确认的数据.");
        //            return;
        //        }

        //        foreach (GridViewRow row in grdAdvanceApplicationList.Rows)
        //        {
        //            CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
        //            if (chkSelected.Checked)
        //            {
        //                int Id = 0;
        //                int.TryParse(this.grdAdvanceApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
        //                AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(Id);

        //                if (advanceApplication != null)
        //                {
        //                    if (advanceApplication.FinanceOkIsAudit == true)
        //                    {
        //                        advanceApplication.OperationsPeople = HozestERPContext.Current.User.CustomerID;
        //                        advanceApplication.OperationIsAudit = true;
        //                        advanceApplication.OperationTime = DateTime.Now;
        //                        advanceApplication.AdvanceState = (int)AdvanceStateEnum.TheAdvanceUse;
        //                        advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
        //                        advanceApplication.UpdateTime = DateTime.Now;
        //                        base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);
        //                    }
        //                }

        //            }
        //        }
        //    }
        //    this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
        //    this.BindGrid();
        //}


        /// <summary>
        /// 暂支结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFinanceEnd_Click(object sender, EventArgs e)
        {

            List<int> customerInfoIDs = this.Master.GetSelectedIds(this.grdAdvanceApplicationList);
            if (customerInfoIDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (GridViewRow row in grdAdvanceApplicationList.Rows)
                {
                    CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                    if (chkSelected.Checked)
                    {
                        int Id = 0;
                        int.TryParse(this.grdAdvanceApplicationList.DataKeys[row.RowIndex].Value.ToString(), out Id);
                        AdvanceApplication advanceApplication = base.AdvanceApplicationService.GetAdvanceApplicationById(Id); 
                        if (advanceApplication != null)
                        {

                            //暂支总金额
                            decimal TheAdvanceMoney = advanceApplication.TheAdvanceMoney.Value;
                            //明细
                            List<AdvanceApplicationDetail> advanceApplicationDetail = base.AdvanceApplicationDetailService.GetAdvanceApplicationDetailListByAdvanceId(advanceApplication.Id);

                            #region 未领款=总金额-领款金额
                            decimal sum = 0;//领款金额
                            if (advanceApplicationDetail.Count > 0)
                            {
                                var advanceApplicationDetailNew = advanceApplicationDetail.Where(p => p.AdvanceTypeId == 345).ToList();
                                if (advanceApplicationDetailNew.Count > 0)
                                {
                                    sum = advanceApplicationDetailNew.Select(p => p.TheAdvanceMoney.Value).Sum();
                                }
                            }
                            //未领款金额=总金额-领款金额
                            decimal WL = TheAdvanceMoney - sum; 
                            #endregion

                            #region 未还款=总金额-还款金额
                             
                            #region 刷单订单总金额、总佣金

                            decimal SalePriceSum = 0;//订单总金额
                            decimal FeeSum = 0;//总佣金
                            decimal DeductionSum = 0;
                            decimal SalePrice = 0;

                            if (advanceApplication.ScalpingId != null && advanceApplication.ScalpingId > 0)
                            {
                                var scalpingList = base.XMScalpingService.GetXMScalpingByScalpingId(advanceApplication.ScalpingId.Value);

                                var scalpingListNew = scalpingList.Where(p => p.IsAbnormal == false).ToList();
                                //订单总销售额
                                SalePriceSum = scalpingListNew.Select(p => p.SalePrice == null ? 0 : p.SalePrice.Value).Sum();
                                //订单总佣金
                                FeeSum = scalpingListNew.Select(p => p.Fee == null ? 0 : p.Fee.Value).Sum();
                                //订单扣点
                                DeductionSum = scalpingListNew.Select(p => p.Deduction == null ? 0 : p.Deduction.Value).Sum();
                            }

                            #endregion
                            
                            //订单回款=订单销售额-订单扣点 
                            SalePrice = SalePriceSum - DeductionSum;

                            decimal HKsum = 0;//已还金额
                            if (advanceApplicationDetail.Count > 0)
                            {
                                var advanceApplicationDetailNew = advanceApplicationDetail.Where(p => p.AdvanceTypeId == 346).ToList();
                                if (advanceApplicationDetailNew.Count > 0)
                                {
                                    HKsum = advanceApplicationDetailNew.Select(p => p.TheAdvanceMoney.Value).Sum();

                                }
                            }
                            //剩余还款金额=总暂支金额-已经还款金额 -刷单总金额-总佣金-未领款金额-扣点
                            decimal SY = TheAdvanceMoney - HKsum - SalePrice - FeeSum - WL - DeductionSum;


                            #endregion


                            //未处理
                            if (advanceApplication.AdvanceState != (int)AdvanceStateEnum.TheAdvanceUse && advanceApplication.AdvanceState!=(int)AdvanceStateEnum.TheAdvanceEnd)
                            {
                                //领款金额 大于0 不可暂支结束
                                if (sum > 0)
                                {
                                    base.ShowMessage("该暂支已有领款记录!");
                                    return;
                                }

                                #region 处理暂支结束状态 
                                advanceApplication.FinanceAdvanceEndPeople = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.FinanceAdvanceEndIsAudit = true;
                                advanceApplication.FinanceAdvanceEndTime = DateTime.Now;
                                advanceApplication.AdvanceState = (int)AdvanceStateEnum.TheAdvanceEnd;
                                advanceApplication.ForecastReturnTime = DateTime.Now;
                                advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.UpdateTime = DateTime.Now;
                                base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);

                                #endregion
                            }
                            else if (advanceApplication.AdvanceState == (int)AdvanceStateEnum.TheAdvanceEnd)
                            { 
                                base.ShowMessage("该暂支已经结束!");
                                return;
                            } 
                            else
                            {  
                                //未还款金额大于0 不可暂支结束
                                if (SY > 0)
                                { 
                                    base.ShowMessage("未还款金额大于0 不可暂支结束!");
                                    return;
                                } 
                                #region 处理暂支结束状态

                                advanceApplication.FinanceAdvanceEndPeople = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.FinanceAdvanceEndIsAudit = true;
                                advanceApplication.FinanceAdvanceEndTime = DateTime.Now;
                                advanceApplication.AdvanceState = (int)AdvanceStateEnum.TheAdvanceEnd;
                                advanceApplication.ForecastReturnTime = DateTime.Now;
                                advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.UpdateTime = DateTime.Now;
                                base.AdvanceApplicationService.UpdateAdvanceApplication(advanceApplication);

                                #endregion

                                #region 在操作记录上新增 订单回款、佣金、订单扣点

                                if (SalePrice > 0 && FeeSum > 0)
                                {
                                    //346:还款类型 , 378：订单回款 ,SalePrice:订单回款金额 
                                    base.AdvanceApplicationDetailService.InsertAdvanceApplicationDetail(new AdvanceApplicationDetail()
                                        {
                                            AdvanceId = advanceApplication.Id,
                                            AdvanceTypeId = 346,
                                            PayTypeId = 378,
                                            TheAdvanceMoney = SalePrice,
                                            RecipientsId = -1,
                                            IsEnable = false,
                                            CreatorID = HozestERPContext.Current.User.CustomerID,
                                            CreateTime = DateTime.Now,
                                            UpdatorID = HozestERPContext.Current.User.CustomerID,
                                            UpdateTime = DateTime.Now


                                        });
                                    //346:还款类型 , 379：订单佣金 ,SalePrice:订单回款金额 
                                    base.AdvanceApplicationDetailService.InsertAdvanceApplicationDetail(new AdvanceApplicationDetail()
                                        {
                                            AdvanceId = advanceApplication.Id,
                                            AdvanceTypeId = 346,
                                            PayTypeId = 379,
                                            TheAdvanceMoney = FeeSum,
                                            RecipientsId = -1,
                                            IsEnable = false,
                                            CreatorID = HozestERPContext.Current.User.CustomerID,
                                            CreateTime = DateTime.Now,
                                            UpdatorID = HozestERPContext.Current.User.CustomerID,
                                            UpdateTime = DateTime.Now
                                        });

                                }
                                else if (SalePriceSum > 0 && FeeSum == 0)
                                {

                                    //346:还款类型 , 378：订单回款 ,SalePriceSum:订单回款金额 
                                    base.AdvanceApplicationDetailService.InsertAdvanceApplicationDetail(new AdvanceApplicationDetail()
                                    {
                                        AdvanceId = advanceApplication.Id,
                                        AdvanceTypeId = 346,
                                        PayTypeId = 378,
                                        TheAdvanceMoney = SalePrice,
                                        RecipientsId = -1,
                                        IsEnable = false,
                                        CreatorID = HozestERPContext.Current.User.CustomerID,
                                        CreateTime = DateTime.Now,
                                        UpdatorID = HozestERPContext.Current.User.CustomerID,
                                        UpdateTime = DateTime.Now

                                    });
                                }
                                else if (SalePriceSum == 0 && FeeSum > 0)
                                {
                                    //346:还款类型 , 379：订单佣金 ,FeeSum:订单总佣金 
                                    base.AdvanceApplicationDetailService.InsertAdvanceApplicationDetail(new AdvanceApplicationDetail()
                                    {
                                        AdvanceId = advanceApplication.Id,
                                        AdvanceTypeId = 346,
                                        PayTypeId = 379,
                                        TheAdvanceMoney = FeeSum,
                                        RecipientsId = -1,
                                        IsEnable = false,
                                        CreatorID = HozestERPContext.Current.User.CustomerID,
                                        CreateTime = DateTime.Now,
                                        UpdatorID = HozestERPContext.Current.User.CustomerID,
                                        UpdateTime = DateTime.Now
                                    });

                                }

                                if (DeductionSum > 0)
                                { 
                                    //346:还款类型 , 379：订单扣点 ,DeductionSum:订单扣点
                                    base.AdvanceApplicationDetailService.InsertAdvanceApplicationDetail(new AdvanceApplicationDetail()
                                    {
                                        AdvanceId = advanceApplication.Id,
                                        AdvanceTypeId = 346,
                                        PayTypeId = 380,
                                        TheAdvanceMoney = DeductionSum,
                                        RecipientsId = -1,
                                        IsEnable = false,
                                        CreatorID = HozestERPContext.Current.User.CustomerID,
                                        CreateTime = DateTime.Now,
                                        UpdatorID = HozestERPContext.Current.User.CustomerID,
                                        UpdateTime = DateTime.Now
                                    });
                                }
                                #endregion
                            }
                        }

                    }
                }
            }
            this.Master.JsWrite("alert('操作成功。');RefreshSearch();", "");
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }


     
         
        /// <summary>
        /// 刷单申请Id
        /// </summary>
        public int ScalpingId
        {
            get
            {
                return CommonHelper.QueryStringInt("ScalpingId");
            }
        }
         
        /// <summary>
        /// 参数类型Id
        /// </summary>
        public int ParametersTypeId
        {
            get
            {
                return CommonHelper.QueryStringInt("ParametersTypeId");
            }
        }

    }
}