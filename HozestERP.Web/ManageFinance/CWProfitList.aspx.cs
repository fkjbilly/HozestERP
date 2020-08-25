using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using CRM.BusinessLogic.ManageContract;

namespace HozestERP.Web.ManageFinance
{
      
    public partial class CWProfitList : BaseAdministrationPage, ISearchPage
    {

  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //base.CWProfitService.TimingGetCWProfit(); 
                //this.BindGrid(1, Master.PageSize); 
                this.lblTitle.Text = this.ddlDateTime.Text + "数";

                this.BindData();
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
            #region 平台类型绑定

            //平台类型动态数据绑定
            this.ddlPlatformTypeId.Items.Clear();
            var codeLists = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatformTypeId.DataSource = codeLists;
            this.ddlPlatformTypeId.DataTextField = "CodeName";
            this.ddlPlatformTypeId.DataValueField = "CodeID";
            this.ddlPlatformTypeId.DataBind();
            this.ddlPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion

            #region 项目类型绑定

            //平台类型动态数据绑定
            this.ddlXMProjectTypeId.Items.Clear();
            var codeProjectTypeLists = base.CodeService.GetCodeListInfoByCodeTypeID(189, false);
            this.ddlXMProjectTypeId.DataSource = codeProjectTypeLists;
            this.ddlXMProjectTypeId.DataTextField = "CodeName";
            this.ddlXMProjectTypeId.DataValueField = "CodeID";
            this.ddlXMProjectTypeId.DataBind();
            this.ddlXMProjectTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));
            #endregion

            #region 项目名称绑定

            //平台类型动态数据绑定
            this.ddlXMProjectNameId.Items.Clear();
            var projectList = base.XMProjectService.GetXMProjectList();
            this.ddlXMProjectNameId.DataSource = projectList;
            this.ddlXMProjectNameId.DataTextField = "ProjectName";
            this.ddlXMProjectNameId.DataValueField = "Id";
            this.ddlXMProjectNameId.DataBind();
            this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));

            #endregion

            #region 店铺名称绑定 
           // this.ddlNickList.Items.Clear();
           // var NickList = base.XMNickService.GetXMNickList();
           //// var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
           // this.ddlNickList.DataSource = NickList;
           // this.ddlNickList.DataTextField = "nick";
           // this.ddlNickList.DataValueField = "nick_id";
           // this.ddlNickList.DataBind();
           // this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));


            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 508)
            {
                this.ddlNickList.Items.Clear();
                var NickList = base.XMNickService.GetXMNickList();
                var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                this.ddlNickList.DataSource = newNickList;
                this.ddlNickList.DataTextField = "nick";
                this.ddlNickList.DataValueField = "nick_id";
                this.ddlNickList.DataBind();
                this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                //项目经理
                var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ProjectManager);

                if (xMNickList.Count > 0)
                {
                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = xMNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }

                //店长
                var xMNickListShopOwner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.ShopOwner);
                if (xMNickListShopOwner.Count > 0)
                {

                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = xMNickListShopOwner;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }

                //推广专员
                var xMNickListPromotionSpecialist = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.PromotionSpecialist);
                if (xMNickListPromotionSpecialist.Count > 0)
                {

                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = xMNickListPromotionSpecialist;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }

                //文案专员
                var xMNickListCopywriterCommissioner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.CopywriterCommissioner);
                if (xMNickListCopywriterCommissioner.Count > 0)
                {

                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = xMNickListCopywriterCommissioner;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }


                //运营专员
                var xMNickListOperationCommissioner = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", (int)CustomerTypeEnum.OperationCommissioner);
                if (xMNickListOperationCommissioner.Count > 0)
                {

                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = xMNickListOperationCommissioner;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }

                //项目负责人
                List<int> projectIdList = new List<int>();
                var XMProjectList = base.XMProjectService.GetXMProjectCustomerId(HozestERPContext.Current.User.CustomerID);
                if (XMProjectList.Count > 0)
                {
                    projectIdList = XMProjectList.Select(p => p.Id).ToList();
                }

                var XMNickList = base.XMNickService.GetXMNickListByProjectId(projectIdList);
                if (XMNickList.Count > 0)
                {

                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = XMNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }


                //项目经理、店长、推广专员、文案专员、运营专员、项目负责人 都返回店铺信息  以项目负责人为准
                if (xMNickList.Count > 0 && xMNickListShopOwner.Count > 0 && xMNickListPromotionSpecialist.Count > 0 && xMNickListCopywriterCommissioner.Count > 0 && xMNickListOperationCommissioner.Count > 0 && XMNickList.Count > 0)
                {
                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = XMNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }

                //项目经理、店长 都返回店铺信息  以项目经理为准
                if (xMNickList.Count > 0 && xMNickListShopOwner.Count > 0)
                {
                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = xMNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }

                //项目经理、项目负责人 都返回店铺信息  以项目负责人为准
                if (xMNickList.Count > 0 && XMNickList.Count > 0)
                {
                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = XMNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }

                //店长、项目负责人 都返回店铺信息  以项目负责人为准
                if (xMNickListShopOwner.Count > 0 && XMNickList.Count > 0)
                {
                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = XMNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                //推广专员、项目负责人 都返回店铺信息  以项目负责人为准
                if (xMNickListPromotionSpecialist.Count > 0 && XMNickList.Count > 0)
                {
                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = XMNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                //文案专员、项目负责人 都返回店铺信息  以项目负责人为准
                if (xMNickListCopywriterCommissioner.Count > 0 && XMNickList.Count > 0)
                {
                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = XMNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                //运营专员、项目负责人 都返回店铺信息  以项目负责人为准
                if (xMNickListOperationCommissioner.Count > 0 && XMNickList.Count > 0)
                {
                    this.ddlNickList.Items.Clear();
                    this.ddlNickList.DataSource = XMNickList;
                    this.ddlNickList.DataTextField = "nick";
                    this.ddlNickList.DataValueField = "nick_id";
                    this.ddlNickList.DataBind();
                    this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));
                }

            }

            #endregion 
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        { //绑定数据源
            #region 条件查询

            //平台类型
            string PlatformTypeId = "-1";
            if (this.ddlPlatformTypeId.SelectedValue != null)
            {
                PlatformTypeId = this.ddlPlatformTypeId.SelectedValue.ToString();
            }
            //时间：本月、本季、本年
            string ddlDateTime = this.ddlDateTime.SelectedValue.ToString();

            //月份
            string DateTimeMonth = "";
            
            //string DateTimeYear = "";// DateTime.Parse(this.txtOrderInfoModifiedEnd.Text).AddDays(1).AddSeconds(-1).ToString();//结束时间设置到该天23：59：59

            DateTime dt = DateTime.Now;//当前时间

            //年份
            string DateTimeYear = dt.Year.ToString(); 

            if (ddlDateTime == "本月") {

                DateTimeMonth = dt.Month.ToString();//当前月份
               
            }
            else if (ddlDateTime == "本季") {

                DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day); //本季度初  
                DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1); //本季度末  

                //本季度的第二个月
               int montht= startQuarter.Month + 1; 

               DateTimeMonth = startQuarter.Month.ToString() + "," + montht.ToString() + "," + endQuarter.Month.ToString();

            }
            else if (ddlDateTime == "本年") {

                DateTimeMonth = "1,2,3,4,5,6,7,8,9,10,11,12";
                //DateTime startYear = new DateTime(dt.Year, 1, 1); //本年年初  
                //DateTime endYear = new DateTime(dt.Year, 12, 31); //本年年末 
            
            }
             

            //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
            var cbOrderStatusId = this.ddlOrderStatus.SelectedValue;


            //项目类型： 自运营、代运营
            string cbXMProjectTypeId = "-1";

            if (this.ddlXMProjectTypeId.SelectedValue != null)
            {
                cbXMProjectTypeId = this.ddlXMProjectTypeId.SelectedValue.ToString();
            }


            //项目名称
            string cbXMProject = "-1";
            if (this.ddlXMProjectNameId.SelectedValue != null)
            {
                cbXMProject = this.ddlXMProjectNameId.SelectedValue.ToString();
            }
            string cbNick = "-1";

            if (this.ddlNickList.SelectedValue != null)
            {
                cbNick = this.ddlNickList.SelectedValue.ToString();
            }

            //店铺集合
            List<int> nickIdList = new List<int>();

            //合并新的list
            //List<CWProfitMapping> CWProfitMappingList = new List<CWProfitMapping>();

            #region 店铺条件查询集合 处理
            //选择某项目  
            if (cbXMProject != "-1")
            {
                if (cbNick == "-1")//项目下的所有店铺
                {
                    var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                    //var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    if (nickList.Count > 0)
                    {
                        nickIdList = nickList.Select(p => p.nick_id).ToList();
                    }
                }
                else
                {

                    nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                }
            }
            else
            {
                if (cbNick == "-1")
                {
                    var NickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                    //var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    nickIdList = NickList.Select(a => a.nick_id).ToList();
                }
                else
                {
                    nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                }

            }
            #endregion

           // int ParentID = 0; //父级Id 
            #endregion 
            List<CWProfit> CWProfitListYYSR = base.CWProfitService.GetCWProfitSearchList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToInt32(cbOrderStatusId), DateTimeYear, DateTimeMonth, -1);
            //营业收入
            List<CWProfitMapping> CWProfitListYYSRNew =
                          CWProfitListYYSR.GroupBy(g => new { g.ProjectId }).
                          Select(group => new CWProfitMapping()
                          { 
                             ProjectId = group.Key.ProjectId,
                             CountMoney = group.Sum(l => l.CountMoney==null ? 0 :l.CountMoney.Value),
                             YearCountMoney = 0,
                             MonthProfit = 0,
                             YearProfit = 0 
                          }).ToList();

            ////增值税

            ////营业成本

            ////进货成本
            //List<CWProfit> CWProfitListJHCB = base.CWProfitService.GetCWProfitSearchList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToInt32(cbOrderStatusId), DateTimeYear, DateTimeMonth, 4); 
            //List<CWProfitMapping> CWProfitListJHCBNew =
            //              CWProfitListJHCB.GroupBy(g => new { g.ProjectId }).
            //              Select(group => new CWProfitMapping()
            //              {
            //                  //Id=0,
            //                  ProjectId = group.Key.ProjectId,
            //                  CountMoney = group.Sum(l => l.CountMoney),
            //                  YearCountMoney = 0,
            //                  MonthProfit = 0,
            //                  YearProfit = 0
            //              }).ToList();

            // CWProfitMappingList = CWProfitListYYSRNew.Concat(CWProfitListJHCBNew).ToList();
            ////赠品成本

            //List<CWProfit> CWProfitListZPCB = base.CWProfitService.GetCWProfitSearchList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToInt32(cbOrderStatusId), DateTimeYear, DateTimeMonth, 24);
            //List<CWProfitMapping> CWProfitListZPCBNew =
            //              CWProfitListZPCB.GroupBy(g => new { g.ProjectId }).
            //              Select(group => new CWProfitMapping()
            //              {
            //                  //Id=0,
            //                  ProjectId = group.Key.ProjectId,
            //                  CountMoney = group.Sum(l => l.CountMoney),
            //                  YearCountMoney = 0,
            //                  MonthProfit = 0,
            //                  YearProfit = 0
            //              }).ToList();

            //CWProfitMappingList = CWProfitMappingList.Concat(CWProfitListZPCBNew).ToList();
            ////平台成本费用

            ////运费

            ////刷拍成本
            //List<CWProfit> CWProfitListSPCB = base.CWProfitService.GetCWProfitSearchList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToInt32(cbOrderStatusId), DateTimeYear, DateTimeMonth, 7);
            //List<CWProfitMapping> CWProfitListSPCBNew =
            //              CWProfitListSPCB.GroupBy(g => new { g.ProjectId }).
            //              Select(group => new CWProfitMapping()
            //              {
            //                  //Id=0,
            //                  ProjectId = group.Key.ProjectId,
            //                  CountMoney = group.Sum(l => l.CountMoney),
            //                  YearCountMoney = 0,
            //                  MonthProfit = 0,
            //                  YearProfit = 0
            //              }).ToList();
            //CWProfitMappingList = CWProfitMappingList.Concat(CWProfitListSPCBNew).ToList();
            ////返现成本
            //List<CWProfit> CWProfitListFXCB = base.CWProfitService.GetCWProfitSearchList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToInt32(cbOrderStatusId), DateTimeYear, DateTimeMonth, 8);
            //List<CWProfitMapping> CWProfitListFXCBNew =
            //              CWProfitListFXCB.GroupBy(g => new { g.ProjectId }).
            //              Select(group => new CWProfitMapping()
            //              {
            //                  //Id=0,
            //                  ProjectId = group.Key.ProjectId,
            //                  CountMoney = group.Sum(l => l.CountMoney),
            //                  YearCountMoney = 0,
            //                  MonthProfit = 0,
            //                  YearProfit = 0
            //              }).ToList();

            //CWProfitMappingList = CWProfitMappingList.Concat(CWProfitListFXCBNew).ToList();

            //var pageList = new PagedList<CWProfitMapping>(CWProfitListYYSRNew, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            //this.Master.BindData(this.grdvCWProfitLis, pageList);
        }

        #endregion


        private void BindData()
        {

            #region 条件查询

            //平台类型
            string PlatformTypeId = "-1";
            if (this.ddlPlatformTypeId.SelectedValue != null)
            {
                PlatformTypeId = this.ddlPlatformTypeId.SelectedValue.ToString();
            }
            //时间：本月、本季、本年
            string ddlDateTime = this.ddlDateTime.SelectedValue.ToString();

            //月份
            string DateTimeMonth = "";

            //string DateTimeYear = "";// DateTime.Parse(this.txtOrderInfoModifiedEnd.Text).AddDays(1).AddSeconds(-1).ToString();//结束时间设置到该天23：59：59

            DateTime dt = DateTime.Now;//当前时间

            //年份
            string DateTimeYear = dt.Year.ToString();

            if (ddlDateTime == "本月")
            {

                DateTimeMonth = dt.Month.ToString();//当前月份

            }
            else if (ddlDateTime == "本季")
            {

                DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day); //本季度初  
                DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1); //本季度末  

                //本季度的第二个月
                int montht = startQuarter.Month + 1;

                DateTimeMonth = startQuarter.Month.ToString() + "," + montht.ToString() + "," + endQuarter.Month.ToString();

            }
            else if (ddlDateTime == "本年")
            {

                DateTimeMonth = "1,2,3,4,5,6,7,8,9,10,11,12";
                //DateTime startYear = new DateTime(dt.Year, 1, 1); //本年年初  
                //DateTime endYear = new DateTime(dt.Year, 12, 31); //本年年末 

            }


            //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
            var cbOrderStatusId = this.ddlOrderStatus.SelectedValue;


            //项目类型： 自运营、代运营
            string cbXMProjectTypeId = "-1";

            if (this.ddlXMProjectTypeId.SelectedValue != null)
            {
                cbXMProjectTypeId = this.ddlXMProjectTypeId.SelectedValue.ToString();
            }


            //项目名称
            string cbXMProject = "-1";
            if (this.ddlXMProjectNameId.SelectedValue != null)
            {
                cbXMProject = this.ddlXMProjectNameId.SelectedValue.ToString();
            }
            string cbNick = "-1";

            if (this.ddlNickList.SelectedValue != null)
            {
                cbNick = this.ddlNickList.SelectedValue.ToString();
            }

            //店铺集合
            List<int> nickIdList = new List<int>();

            //合并新的list
            //List<CWProfitMapping> CWProfitMappingList = new List<CWProfitMapping>();

            #region 店铺条件查询集合 处理
            //选择某项目  
            if (cbXMProject != "-1")
            {
                if (cbNick == "-1")//项目下的所有店铺
                {
                    var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                   // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    if (nickList.Count > 0)
                    {
                        nickIdList = nickList.Select(p => p.nick_id).ToList();
                    }
                }
                else
                {

                    nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                }
            }
            else
            {
                if (cbNick == "-1")
                {
                    var NickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                    //var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    nickIdList = NickList.Select(a => a.nick_id).ToList();
                }
                else
                {
                    nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                }

            }
            #endregion

            // int ParentID = 0; //父级Id 
            #endregion

            #region 利润数据

            List<CWProfit> CWProfitListYYSR = base.CWProfitService.GetCWProfitSearchList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToInt32(cbOrderStatusId), DateTimeYear, DateTimeMonth, -1);
            
            //营业收入
            List<CWProfitMapping> CWProfitListYYSRNew =
                          CWProfitListYYSR.GroupBy(g => new { g.ProjectId }).
                          Select(group => new CWProfitMapping()
                          {
                              ProjectId = group.Key.ProjectId,
                              CountMoney = group.Sum(l => l.CountMoney == null ? 0 : l.CountMoney.Value),
                              YearCountMoney = 0,
                              MonthProfit = 0,
                              YearProfit = 0
                          }).ToList();

            decimal CountMoneySum1 = 0;//营业收入
            decimal CountMoneySum4 = 0;//进货成本
            decimal CountMoneySum24 = 0;//赠品成本  
            decimal CountMoneySum7 = 0;//刷拍成本
            decimal CountMoneySum8 = 0;//返现成本 
          

            if (CWProfitListYYSRNew.Count > 0)
            { 
                foreach (var item in CWProfitListYYSRNew)
                {
                    if (item.ProjectId == 1)
                    {
                        CountMoneySum1 = item.CountMoney.Value;
                    }
                    if (item.ProjectId == 4)
                    {
                        CountMoneySum4 = item.CountMoney.Value;
                    }
                    if (item.ProjectId == 24)
                    {
                        CountMoneySum24 = item.CountMoney.Value;
                    }
                    if (item.ProjectId == 7)
                    {
                        CountMoneySum7 = item.CountMoney.Value;
                    }
                    if (item.ProjectId == 8)
                    {
                        CountMoneySum8 = item.CountMoney.Value;
                    }

                   
                }

            }
            #endregion

            #region 人员开支费用

            decimal CountMoneySum11 = 0;// 运营部门人员工资
            decimal CountMoneySum12 = 0;// 运营部门人员社保
            decimal CountMoneySum13 = 0;//运营部门人员奖金

            decimal CountMoneySum15 = 0;//运营部门销售奖金
            decimal CountMoneySum16 = 0;//差旅费
            decimal CountMoneySum17 = 0;//办公费用
            decimal CountMoneySum18 = 0;//其他费用
            decimal CountMoneySum19 = 0;//固定资产折旧
            decimal CountMoneySum20 = 0;// 摊销费用
            decimal CountMoneySum21 = 0;//广告费补贴   

            decimal CountMoneySum6 = 0;//运费
            int CountMoneySum6Index = 0;//运费是否返回数据
            

            List<CWStaffSpending> CWStaffSpendingList = base.CWStaffSpendingService.GetCWStaffSpendingList(-1, Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), DateTimeYear, DateTimeMonth);
            //人员开支费用  根据利润项目分组
           // List<CWStaffSpending> CWStaffSpendingListNew = CWStaffSpendingList.GroupBy(p => p.ProfitProjectId).Select(g => g.First()).ToList();
            List<CWStaffSpendingMapping> CWStaffSpendingListNew =
                              CWStaffSpendingList.GroupBy(g => new { g.ProfitProjectId }).
                              Select(group => new CWStaffSpendingMapping()
                              {
                                  ProfitProjectId = group.Key.ProfitProjectId,
                                  CountMoney = group.Sum(l => l.CountMoney)
                              }).ToList();

            if (CWStaffSpendingListNew.Count > 0)
            {

                foreach (var item in CWStaffSpendingListNew)
                {
                    if (item.ProfitProjectId == 6)
                    {
                        CountMoneySum6 = item.CountMoney.Value;
                        CountMoneySum6Index++;
                    } 
                    if (item.ProfitProjectId == 11)
                    {
                        CountMoneySum11 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 12)
                    {
                        CountMoneySum12 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 13)
                    {
                        CountMoneySum13 = item.CountMoney.Value;
                    }

                    if (item.ProfitProjectId == 15)
                    {
                        CountMoneySum15 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 16)
                    {
                        CountMoneySum16 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 17)
                    {
                        CountMoneySum17 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 18)
                    {
                        CountMoneySum18 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 19)
                    {
                        CountMoneySum19 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 20)
                    {
                        CountMoneySum20 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 21) {

                        CountMoneySum21 = item.CountMoney.Value;
                    }
                }
            
            }

            #endregion 
             
            #region 平台费用 
            decimal CountMoneySum5 = 0;//平台成本费用

            List<CWPlatformSpending> CWPlatformSpendingList = base.CWPlatformSpendingService.GetCWPlatformSpendingSearchList(Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue), DateTimeYear, DateTimeMonth);
             
            //List<CWPlatformSpending> CWPlatformSpendingNew =
            //                  CWPlatformSpendingList.GroupBy(g => new { g.PlatformTypeId }).
            //                  Select(group => new CWPlatformSpending()
            //                  {
            //                      PlatformTypeId = group.Key.PlatformTypeId,
            //                      CountMoney = group.Sum(l => l.CountMoney)
            //                  }).ToList();

            if (CWPlatformSpendingList.Count > 0)
            {

                CountMoneySum5 = CWPlatformSpendingList.Select(p=>p.CountMoney.Value).Sum();
            }


            #endregion


            string  DateTimeMonthYear = "1,2,3,4,5,6,7,8,9,10,11,12";

            #region 利润数据年
             
            List<CWProfit> CWProfitListYYSRYear = base.CWProfitService.GetCWProfitSearchList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToInt32(cbOrderStatusId), DateTimeYear, DateTimeMonthYear, -1);
            //营业收入
            List<CWProfitMapping> CWProfitListYYSRYearNew =
                          CWProfitListYYSRYear.GroupBy(g => new { g.ProjectId }).
                          Select(group => new CWProfitMapping()
                          {
                              ProjectId = group.Key.ProjectId,
                              CountMoney = group.Sum(l => l.CountMoney == null ? 0 : l.CountMoney.Value),
                              YearCountMoney = 0,
                              MonthProfit = 0,
                              YearProfit = 0
                          }).ToList();

            decimal CountMoneySumYear1 = 0;//营业收入
            decimal CountMoneySumYear4 = 0;//进货成本
            decimal CountMoneySumYear24 = 0;//赠品成本 
            decimal CountMoneySumYear7 = 0;//刷拍成本
            decimal CountMoneySumYear8 = 0;//返现成本 
          

            if (CWProfitListYYSRYearNew.Count > 0)
            { 
                foreach (var item in CWProfitListYYSRYearNew)
                {
                    if (item.ProjectId == 1)
                    {
                        CountMoneySumYear1 = item.CountMoney.Value;
                    }
                    if (item.ProjectId == 4)
                    {
                        CountMoneySumYear4 = item.CountMoney.Value;
                    }
                    if (item.ProjectId == 24)
                    {
                        CountMoneySumYear24 = item.CountMoney.Value;
                    }
                    if (item.ProjectId == 7)
                    {
                        CountMoneySumYear7 = item.CountMoney.Value;
                    }
                    if (item.ProjectId == 8)
                    {
                        CountMoneySumYear8 = item.CountMoney.Value;
                    }

                   
                }

            }
            #endregion

            #region 人员开支费用年

            decimal CountMoneySumYear11 = 0;// 运营部门人员工资
            decimal CountMoneySumYear12 = 0;// 运营部门人员社保
            decimal CountMoneySumYear13 = 0;//运营部门人员奖金

            decimal CountMoneySumYear15 = 0;//运营部门销售奖金
            decimal CountMoneySumYear16 = 0;//差旅费
            decimal CountMoneySumYear17 = 0;//办公费用
            decimal CountMoneySumYear18 = 0;//其他费用
            decimal CountMoneySumYear19 = 0;//固定资产折旧
            decimal CountMoneySumYear20 = 0;// 摊销费用
            decimal CountMoneySumYear21 = 0;//广告费补贴
            decimal CountMoneySumYear6 = 0;//运费
            

            List<CWStaffSpending> CWStaffSpendingYearList = base.CWStaffSpendingService.GetCWStaffSpendingList(-1, Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), DateTimeYear, DateTimeMonthYear);
            //人员开支费用  根据利润项目分组


            List<CWStaffSpendingMapping> CWStaffSpendingListYearNew =
                               CWStaffSpendingYearList.GroupBy(g => new { g.ProfitProjectId }).
                               Select(group => new CWStaffSpendingMapping()
                               {
                                  ProfitProjectId = group.Key.ProfitProjectId, 
                                   CountMoney = group.Sum(l => l.CountMoney)
                               }).ToList();


           // List<> CWStaffSpendingListYearNew = CWStaffSpendingYearList.GroupBy(p => p.ProfitProjectId).Select(g => g.First()).ToList();


            if (CWStaffSpendingListYearNew.Count > 0) {
                 
                foreach (var item in CWStaffSpendingListYearNew)
                {
                    if (item.ProfitProjectId == 6)
                    {
                        CountMoneySumYear6 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 11)
                    {
                        CountMoneySumYear11 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 12)
                    {
                        CountMoneySumYear12 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 13)
                    {
                        CountMoneySumYear13 = item.CountMoney.Value;
                    }

                    if (item.ProfitProjectId == 15)
                    {
                        CountMoneySumYear15 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 16)
                    {
                        CountMoneySumYear16 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 17)
                    {
                        CountMoneySumYear17 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 18)
                    {
                        CountMoneySumYear18 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 19)
                    {
                        CountMoneySumYear19 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 20)
                    {
                        CountMoneySumYear20 = item.CountMoney.Value;
                    }
                    if (item.ProfitProjectId == 21) {

                        CountMoneySumYear21 = item.CountMoney.Value;
                    }
                }
            
            }

            #endregion 
             
            #region 平台费用年
            decimal CountMoneySumYear5 = 0;//平台成本费用

            List<CWPlatformSpending> CWPlatformSpendingYearList = base.CWPlatformSpendingService.GetCWPlatformSpendingSearchList(Convert.ToInt32(this.ddlPlatformTypeId.SelectedValue), DateTimeYear, DateTimeMonthYear);

            //List<CWPlatformSpending> CWPlatformSpendingYearNew =
            //                  CWPlatformSpendingYearList.GroupBy(g => new { g.PlatformTypeId }).
            //                  Select(group => new CWPlatformSpending()
            //                  {
            //                      PlatformTypeId = group.Key.PlatformTypeId,
            //                      CountMoney = group.Sum(l => l.CountMoney)
            //                  }).ToList();

            if (CWPlatformSpendingYearList.Count > 0)
            {

                CountMoneySumYear5 = CWPlatformSpendingYearList.Select(p => p.CountMoney.Value).Sum();
            }


            #endregion

            //string StrNickIdList = "";
            
            //if (nickIdList.Count != 0)
            //{
            //    StrNickIdList = string.Join(",", nickIdList);
            //}

            //int ProjectId = 1;//营业收入  
            //decimal  CountMoneySum = base.CWProfitService.GetCWProfitSearchList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToInt32(cbOrderStatusId), DateTimeYear, DateTimeMonth, ProjectId).Select(p=>p.CountMoney==null? 0:p.CountMoney.Value).Sum();
            #region 营业收入 
            this.lblYYSRMonthMoney.Text = CountMoneySum1.ToString();// 本月数
            this.lblYYSRYearMoney.Text = CountMoneySumYear1.ToString();//年度累计数
            this.lblYYSRMonthProfit.Text = "0";//月度达成率
            this.lblYYSRYearProfit.Text = "0";//月度达成率 
            lblYYSRMonthMoney.OnClientClick = "return ShowWindowDetail('订单明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/OrderInfoDetails.aspx?PlatformTypeId=" + PlatformTypeId 
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue 
            + "&OrderStatusId=" + this.ddlOrderStatus.SelectedValue
            + "&DateTimeId=" + this.ddlDateTime.SelectedValue
            + "', 1200, 690, this, function(){});";
            #endregion

            #region 增值税  
            decimal ZZSMonthMoney =Math.Round((CountMoneySum1 - CountMoneySum4) / (decimal)1.17 * (decimal)0.17 - CountMoneySum6 / (decimal)1.06 * (decimal)0.06,2); 
            decimal ZZSMonthMoneyYear =Math.Round((CountMoneySumYear1 - CountMoneySumYear4) / (decimal)1.17 * (decimal)0.17 - CountMoneySumYear6 / (decimal)1.06 * (decimal)0.06,2); 
            this.lblZZSMonthMoney.Text = ZZSMonthMoney.ToString();
            this.lblZZSRearMoney.Text=ZZSMonthMoneyYear.ToString();
            this.lblZZSMonthProfit.Text="0";
            this.lblZZSYearProfit.Text = "0";
            #endregion 

            #region 营业成本

            //营业成本=进货成本+赠品成本+平台成本费用+运费+刷拍成本+返现成本
            decimal YYCBMonthMoney=Convert.ToDecimal(CountMoneySum4)+Convert.ToDecimal(CountMoneySum24)+CountMoneySum5+CountMoneySum6+Convert.ToDecimal(CountMoneySum7)+Convert.ToDecimal(CountMoneySum8);
            
             decimal YYCBMonthMoneyYear=Convert.ToDecimal(CountMoneySumYear4)+Convert.ToDecimal(CountMoneySumYear24)+CountMoneySumYear5+CountMoneySumYear6+Convert.ToDecimal(CountMoneySumYear7)+Convert.ToDecimal(CountMoneySumYear8);
            
            this.lblYYCBMonthMoney.Text = YYCBMonthMoney.ToString();
            this.lblYYCBYearMoney.Text = YYCBMonthMoneyYear.ToString();
            this.lblYYCBMonthProfit.Text = "0";
            this.lblYYCBYearProfit.Text = "0";
            #endregion

            #region  进货成本
            //int ProjectId4 = 4;//进货成本  
            //decimal CountMoneySum4 = base.CWProfitService.GetCWProfitSearchList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToInt32(cbOrderStatusId), DateTimeYear, DateTimeMonth, ProjectId4).Select(p => p.CountMoney == null ? 0 : p.CountMoney.Value).Sum();
            this.lblJHCBMonthMoney.Text = CountMoneySum4.ToString();// 本月数
            this.lblJHCBYearMoney.Text = CountMoneySumYear4.ToString();//年度累计数
            this.lblJHCBMonthProfit.Text = "0";//月度达成率
            this.lblJHCBYearProfit.Text = "0";//月度达成率
            lblJHCBMonthMoney.OnClientClick = "return ShowWindowDetail('产品明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/OrderInfoProductDetails.aspx?PlatformTypeId=" + PlatformTypeId
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&OrderStatusId=" + this.ddlOrderStatus.SelectedValue
            + "&DateTimeId=" + this.ddlDateTime.SelectedValue
            + "', 1200, 700, this, function(){});";
            #endregion

            #region  赠品成本
            //int ProjectId24 = 24;//赠品成本  
            //decimal CountMoneySum24 = base.CWProfitService.GetCWProfitSearchList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToInt32(cbOrderStatusId), DateTimeYear, DateTimeMonth, ProjectId24).Select(p => p.CountMoney == null ? 0 : p.CountMoney.Value).Sum();
            this.lblZPCBMonthMoney.Text = CountMoneySum24.ToString();// 本月数
            this.lblZPCBYearMoney.Text = CountMoneySumYear24.ToString();//年度累计数
            this.lblZPCBMonthProfit.Text = "0";//月度达成率
            this.lblZPCBYearProfit.Text = "0";//月度达成率
            lblZPCBMonthMoney.OnClientClick = "return ShowWindowDetail('赠品明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/PremiumsDetails.aspx?PlatformTypeId=" + PlatformTypeId
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&OrderStatusId=" + this.ddlOrderStatus.SelectedValue
            + "&DateTimeId=" + this.ddlDateTime.SelectedValue
            + "', 1000, 500, this, function(){});";
            #endregion

            #region 平台成本费用
            this.lblPTCBFYMonthMoney.Text=CountMoneySum5.ToString();
            this.lblPTCBFYYearMoney.Text=CountMoneySumYear5.ToString();
            this.lblPTCBFYMonthProfit.Text = "0";
            this.lblPTCBFYYearProfit.Text = "0";
            this.lblPTCBFYMonthMoney.OnClientClick = "return ShowWindowDetail('平台费用明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/CWPlatformSpendingDetails.aspx?PlatformTypeId=" + PlatformTypeId
            + "&DateTimeId=" + this.ddlDateTime.SelectedValue
            + "', 1000, 620, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            
            #endregion



            #region 运费
            //this.lblYFMonthMoney.Text=CountMoneySum6.ToString();
            if (CountMoneySum6Index == 0 && this.ddlXMProjectNameId.SelectedValue != "-1")
            {
                //根据店铺项目 查询运费比例 
                var xmproject = base.XMProjectService.GetXMProjectById(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue));
                if (xmproject != null)
                {
                    if (xmproject.ShipmentProportion != null)
                    {
                        decimal ShipmentProportion = xmproject.ShipmentProportion.Value / 100;

                        CountMoneySum6 =Math.Round( CountMoneySum1 * ShipmentProportion,2);
                    }
                }
                this.txtYFMonthMoney.Text = CountMoneySum6.ToString();
                this.txtYFMonthMoney.ForeColor = System.Drawing.Color.Red;
                //this.txtYFMonthMoney.Attributes.Add("ForeColor", "red");
            }
            else
            {
                this.txtYFMonthMoney.Text = CountMoneySum6.ToString();
                this.txtYFMonthMoney.ForeColor = System.Drawing.Color.Black;
            }
            this.lblYFYearMoney.Text = CountMoneySumYear6.ToString();
            this.lblYFMonthProfit.Text = "0";
            this.lblYFYearProfit.Text = "0";

            string paramScript6 = "return ShowWindowDetail('费用','" + CommonHelper.GetStoreLocation()
             + "ManageFinance/OpenProfitOtherDataInput.aspx?ProjectId=6&XMProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
             + "',560,200, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            this.txtYFMonthMoney.Attributes.Add("onclick", paramScript6);
           
            #endregion

            #region  刷拍成本
            //int ProjectId7 = 7;//刷拍成本  
            //decimal CountMoneySum7 = base.CWProfitService.GetCWProfitSearchList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToInt32(cbOrderStatusId), DateTimeYear, DateTimeMonth, ProjectId7).Select(p => p.CountMoney == null ? 0 : p.CountMoney.Value).Sum();
            this.lblSPCBMonthMoney.Text = CountMoneySum7.ToString();// 本月数
            this.lblSPCBYearMoney.Text =  CountMoneySumYear7.ToString();//年度累计数
            this.lblSPCBMonthProfit.Text = "0";//月度达成率
            this.lblSPCBYearProfit.Text = "0";//月度达成率
            lblSPCBMonthMoney.OnClientClick = "return ShowWindowDetail('刷单明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/XMScalpingDetails.aspx?PlatformTypeId=" + PlatformTypeId
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&OrderStatusId=" + this.ddlOrderStatus.SelectedValue
            + "&DateTimeId=" + this.ddlDateTime.SelectedValue
            + "', 1000, 500, this, function(){});";
            #endregion

            #region  返现成本
            this.lblFXCBMonthMoney.Text = CountMoneySum8.ToString();// 本月数
            this.lblFXCBYearMoney.Text =CountMoneySumYear8.ToString();//年度累计数
            this.lblFXCBMonthProfit.Text = "0";//月度达成率
            this.lblFXCBYearProfit.Text = "0";//月度达成率 
            lblFXCBMonthMoney.OnClientClick = "return ShowWindowDetail('返现明细','" + CommonHelper.GetStoreLocation()
            + "ManageFinance/XMCashBackApplicationDetails.aspx?PlatformTypeId=" + PlatformTypeId
            + "&ProjectTypeId=" + this.ddlXMProjectTypeId.SelectedValue
            + "&ProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
            + "&NickId=" + this.ddlNickList.SelectedValue
            + "&OrderStatusId=" + this.ddlOrderStatus.SelectedValue
            + "&DateTimeId=" + this.ddlDateTime.SelectedValue
            + "', 1000, 500, this, function(){});";
            #endregion
             
            #region 毛利
            //毛利=营业收入-增值税-营业成本
            decimal MLMonthMoney =Math.Round( CountMoneySum1 - Convert.ToDecimal(this.lblZZSMonthMoney.Text) - Convert.ToDecimal(this.lblYYCBMonthMoney.Text),2);
            
            decimal MLMonthMoneyYear =Math.Round( CountMoneySumYear1 - Convert.ToDecimal(this.lblZZSRearMoney.Text) - Convert.ToDecimal(this.lblYYCBYearMoney.Text),2);

            this.lblMLMonthMoney.Text = MLMonthMoney.ToString();
            this.lblMLYearMoney.Text=MLMonthMoneyYear.ToString();
            this.lblMLMonthProfit.Text="0";
            this.lblMLYearProfit.Text = "0";
          
            #endregion

            #region 直接人工
            //直接人工=运营部门人员工资+运营部门人员社保+运营部门人员奖金
            decimal ZJRGMonthMoney = Math.Round(CountMoneySum11 + CountMoneySum12 + CountMoneySum13, 2); 
            decimal ZJRGMonthMoneyYear = Math.Round(CountMoneySumYear11 + CountMoneySumYear12 + CountMoneySumYear13, 2);
            this.lblZJRGMonthMoney.Text = ZJRGMonthMoney.ToString();
            this.lblZJRGYearMoney.Text = ZJRGMonthMoneyYear.ToString();
            this.lblZJRGMonthProfit.Text="0";
            this.lblZJRGYearProfit.Text = "0"; 
            #endregion

            #region 运营部门人员工资
            this.txtRYGZMonthMoney.Text = CountMoneySum11.ToString();
            this.lblRYGZYearMoney.Text = CountMoneySumYear11.ToString();
            this.lblRYGZMonthProfit.Text="0";
            this.lblRYGZYearProfit.Text = "0";

            string paramScript = "return ShowWindowDetail('费用','" + CommonHelper.GetStoreLocation()
                + "ManageFinance/OpenProfitOtherDataInput.aspx?ProjectId=11&XMProjectNameId=" + this.ddlXMProjectNameId.SelectedValue 
                + "',560,200, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";  
            this.txtRYGZMonthMoney.Attributes.Add("onclick", paramScript);

             
           #endregion 

            #region 运营部门人员社保
            this.txtRYSBMonthMoney.Text=CountMoneySum12.ToString();
            this.lblRYSBYearMoney.Text = CountMoneySumYear12.ToString();
            this.lblRYSBMonthProfit.Text="0";
            this.lblRYSBYearProfit.Text="0"; 
            string paramScript12 = "return ShowWindowDetail('费用','" + CommonHelper.GetStoreLocation()
               + "ManageFinance/OpenProfitOtherDataInput.aspx?ProjectId=12&XMProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
               + "',560,200, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            this.txtRYSBMonthMoney.Attributes.Add("onclick", paramScript12);

            #endregion

            #region  运营部门人员奖金
            this.txtRYJJMonthMoney.Text=CountMoneySum13.ToString();
            this.lblRYJJYearMoney.Text = CountMoneySumYear13.ToString();
            this.lblRYJJMonthProfit.Text="0";
            this.lblRYJJYearProfit.Text = "0";
            string paramScript13 = "return ShowWindowDetail('费用','" + CommonHelper.GetStoreLocation()
               + "ManageFinance/OpenProfitOtherDataInput.aspx?ProjectId=13&XMProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
               + "',560,200, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            this.txtRYJJMonthMoney.Attributes.Add("onclick", paramScript13);
            #endregion

            #region   营业费用  
            //营业费用=运营部门销售奖金+差旅费+办公费用+其他费用+固定资产折旧+摊销费用
            decimal YYFYMonthMoney =Math.Round( CountMoneySum15 + CountMoneySum16 + CountMoneySum17 + CountMoneySum18 + CountMoneySum19 + CountMoneySum20,2);

            decimal YYFYMonthMoneyYear = Math.Round(CountMoneySumYear15 + CountMoneySumYear16 + CountMoneySumYear17 + CountMoneySumYear18 + CountMoneySumYear19 + CountMoneySumYear20, 2);

            this.lblYYFYMonthMoney.Text = YYFYMonthMoney.ToString();
            this.lblYYFYYearMoney.Text = YYFYMonthMoneyYear.ToString();
            this.lblYYFYMonthProfit.Text = "0";
            this.lblYYFYYearProfit.Text = "0";
            #endregion

            #region  运营部门销售奖金
            this.txtXSJJMonthMoney.Text = CountMoneySum15.ToString();
            this.lblXSJJYearMoney.Text = CountMoneySumYear15.ToString();
            this.lblXSJJMonthProfit.Text = "0";
            this.lblXSJJYearProfit.Text = "0";
            string paramScript15 = "return ShowWindowDetail('费用','" + CommonHelper.GetStoreLocation()
               + "ManageFinance/OpenProfitOtherDataInput.aspx?ProjectId=15&XMProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
               + "',560,200, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            this.txtXSJJMonthMoney.Attributes.Add("onclick", paramScript15);
            #endregion 

            #region  差旅费
            this.txtCLFMonthMoney.Text = CountMoneySum16.ToString();
            this.lblCLFYearMoney.Text = CountMoneySumYear16.ToString();
            this.lblCLFMonthProfit.Text = "0";
            this.lblCLFYearProfit.Text = "0";
            string paramScript16 = "return ShowWindowDetail('费用','" + CommonHelper.GetStoreLocation()
               + "ManageFinance/OpenProfitOtherDataInput.aspx?ProjectId=16&XMProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
               + "',560,200, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            this.txtCLFMonthMoney.Attributes.Add("onclick", paramScript16);
            #endregion 

            #region  办公费用
            this.txtBGFYMonthMoney.Text = CountMoneySum17.ToString();
            this.lblBGFYYearMoney.Text = CountMoneySumYear17.ToString();
            this.lblBGFYMonthProfit.Text = "0";
            this.lblBGFYYearProfit.Text = "0";
            string paramScript17 = "return ShowWindowDetail('费用','" + CommonHelper.GetStoreLocation()
               + "ManageFinance/OpenProfitOtherDataInput.aspx?ProjectId=17&XMProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
               + "',560,200, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            this.txtBGFYMonthMoney.Attributes.Add("onclick", paramScript17);
            #endregion
             
            #region  其他费用
            this.txtQTFYMonthMoney.Text = CountMoneySum18.ToString();
            this.lblQTFYYearMoney.Text = CountMoneySumYear18.ToString();
            this.lblQTFYMonthProfit.Text = "0";
            this.lblQTFYYearProfit.Text = "0";
            string paramScript18 = "return ShowWindowDetail('费用','" + CommonHelper.GetStoreLocation()
               + "ManageFinance/OpenProfitOtherDataInput.aspx?ProjectId=18&XMProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
               + "',560,200, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            this.txtQTFYMonthMoney.Attributes.Add("onclick", paramScript18);
            #endregion
           
            #region  固定资产折旧
            this.txtGDZCMonthMoney.Text = CountMoneySum19.ToString();
            this.lblGDZCYearMoney.Text = CountMoneySumYear19.ToString();
            this.lblGDZCMonthProfit.Text = "0";
            this.lblGDZCYearProfit.Text = "0";
            string paramScript19 = "return ShowWindowDetail('费用','" + CommonHelper.GetStoreLocation()
               + "ManageFinance/OpenProfitOtherDataInput.aspx?ProjectId=19&XMProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
               + "',560,200, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            this.txtGDZCMonthMoney.Attributes.Add("onclick", paramScript19);
            #endregion
             
            #region  摊销费用
            this.txtTXFYMonthMoney.Text = CountMoneySum20.ToString();
            this.lblTXFYYearMoney.Text = CountMoneySumYear20.ToString();
            this.lblTXFYMonthProfit.Text = "0";
            this.lblTXFYYearProfit.Text = "0";
            string paramScript20 = "return ShowWindowDetail('费用','" + CommonHelper.GetStoreLocation()
               + "ManageFinance/OpenProfitOtherDataInput.aspx?ProjectId=20&XMProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
               + "',560,200, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            this.txtTXFYMonthMoney.Attributes.Add("onclick", paramScript20);
            #endregion 

            #region  广告费补贴
            this.txtGGFMonthMoney.Text = CountMoneySum21.ToString();
            this.lblGGFYearMoney.Text = CountMoneySumYear21.ToString();
            this.lblGGFMonthProfit.Text = "0";
            this.lblGGFYearProfit.Text = "0";
            string paramScript21 = "return ShowWindowDetail('费用','" + CommonHelper.GetStoreLocation()
               + "ManageFinance/OpenProfitOtherDataInput.aspx?ProjectId=21&XMProjectNameId=" + this.ddlXMProjectNameId.SelectedValue
               + "',560,200, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            this.txtGGFMonthMoney.Attributes.Add("onclick", paramScript21);
            #endregion

            #region 营业税金及附加
            //营业税金及附加=增值税*0.12+营业收入/1.17*0.001
            decimal YYSJMonthMoney =Math.Round( Convert.ToDecimal(this.lblZZSMonthMoney.Text) * (decimal)0.12 + CountMoneySum1 / (decimal)1.17 * (decimal)0.001,2); 
            decimal YYSJMonthMoneyYear = Math.Round(Convert.ToDecimal(this.lblZZSRearMoney.Text) * (decimal)0.12 + CountMoneySumYear1 / (decimal)1.17 * (decimal)0.001, 2);

            this.lblYYSJMonthMoney.Text = YYSJMonthMoney.ToString();
            this.lblYYSJYearMoney.Text = YYSJMonthMoneyYear.ToString();
            this.lblYYSJMonthProfit.Text="0";
            this.lblYYSJYearProfit.Text="0";
            #endregion

            #region 税前利润
            //税前利润=毛利-直接人工-营业费用-营业税金及附加-广告费补贴
            decimal SQLRMonthMoney =Math.Round( Convert.ToDecimal(this.lblMLMonthMoney.Text) - Convert.ToDecimal(this.lblZJRGMonthMoney.Text)
                - Convert.ToDecimal(this.lblYYFYMonthMoney.Text) - Convert.ToDecimal(this.lblYYSJMonthMoney.Text) + Convert.ToDecimal(this.txtGGFMonthMoney.Text),2);

            decimal SQLRMonthMoneyYear = Math.Round(Convert.ToDecimal(this.lblMLYearMoney.Text) - Convert.ToDecimal(this.lblZJRGYearMoney.Text)
               - Convert.ToDecimal(this.lblYYFYYearMoney.Text) - Convert.ToDecimal(this.lblYYSJYearMoney.Text) + Convert.ToDecimal(this.lblGGFYearMoney.Text), 2);

            this.lblSQLRMonthMoney.Text = SQLRMonthMoney.ToString();
            this.lblSQLRYearMoney.Text = SQLRMonthMoneyYear.ToString();
            this.lblSQLRMonthProfit.Text="0";
            this.lblSQLRYearProfit.Text = "0";
            #endregion

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.lblTitle.Text = this.ddlDateTime.Text + "数";

            this.BindData();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindData();
        }


        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOrderInfoSalesDetailsExport_Click(object sender, EventArgs e)
        {
            try
            {
            string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
            string filePath = string.Format("{0}Upload\\OrderInfoSalesDetailsExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

            #region 条件查询

            //平台类型
            string PlatformTypeId = "-1";
            if (this.ddlPlatformTypeId.SelectedValue != null)
            {
                PlatformTypeId = this.ddlPlatformTypeId.SelectedValue.ToString();
            }
            //时间：本月、本季、本年
            string ddlDateTime = this.ddlDateTime.SelectedValue.ToString();

            string OrderInfoModifiedStart = "";//开始时间
            string OrderInfoModifiedEnd = "";//结束时间

            DateTime dt1 = DateTime.Now;//当前时间 
            DateTime dt = Convert.ToDateTime(dt1.ToString("yyyy-MM-dd"));

            if (ddlDateTime == "本月")
            {
                //本月第一天时间   
                DateTime dt_First = dt.AddDays(-(dt.Day) + 1);
                //将本月月数+1   
                DateTime dt2 = dt.AddMonths(1);
                //本月最后一天时间   
                DateTime dt_Last = dt2.AddDays(-(dt.Day));

                OrderInfoModifiedStart = dt_First.ToString();
                OrderInfoModifiedEnd = dt_Last.AddDays(1).AddSeconds(-1).ToString();//结束时间设置到该天23：59：59 

            }
            else if (ddlDateTime == "本季")
            {
                DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day); //本季度初  

                OrderInfoModifiedStart = startQuarter.ToString();
                OrderInfoModifiedEnd = startQuarter.AddMonths(3).AddSeconds(-1).ToString(); //本季度末  


            }
            else if (ddlDateTime == "本年")
            {
                DateTime startYear = new DateTime(dt.Year, 1, 1); //本年年初  
                DateTime endYear = new DateTime(dt.Year, 12, 31); //本年年末 

                OrderInfoModifiedStart = startYear.ToString();
                OrderInfoModifiedEnd = endYear.AddSeconds(-1).ToString(); //本季度末  

            }
                 
            //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
            var cbOrderStatusId = this.ddlOrderStatus.SelectedValue;


            //项目类型： 自运营、代运营
            string cbXMProjectTypeId = "-1";

            if (this.ddlXMProjectTypeId.SelectedValue != null)
            {
                cbXMProjectTypeId = this.ddlXMProjectTypeId.SelectedValue.ToString();
            }


            //项目名称
            string cbXMProject = "-1";
            if (this.ddlXMProjectNameId.SelectedValue != null)
            {
                cbXMProject = this.ddlXMProjectNameId.SelectedValue.ToString();
            }
            string cbNick = "-1";

            if (this.ddlNickList.SelectedValue != null)
            {
                cbNick = this.ddlNickList.SelectedValue.ToString();
            }

            //店铺集合
            List<int> nickIdList = new List<int>();

            //合并新的list
            //List<CWProfitMapping> CWProfitMappingList = new List<CWProfitMapping>();

            #region 店铺条件查询集合 处理
            //选择某项目  
            if (cbXMProject != "-1")
            {
                if (cbNick == "-1")//项目下的所有店铺
                {
                    var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                    //var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    if (nickList.Count > 0)
                    {
                        nickIdList = nickList.Select(p => p.nick_id).ToList();
                    }
                }
                else
                {

                    nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                }
            }
            else
            {
                if (cbNick == "-1")
                {
                    var NickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue), Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue));

                    //var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    nickIdList = NickList.Select(a => a.nick_id).ToList();
                }
                else
                {
                    nickIdList.Add(Convert.ToInt32(this.ddlNickList.SelectedValue));
                }

            }
            #endregion

            // int ParentID = 0; //父级Id 
            #endregion

            #region 订单明细 
            var xmOrderInfoList = base.XMOrderInfoService.getXMOrderInfoList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId), "");
           
            #region 取京东数据 （销售额=应收金额+配送运费）
            var OrderInfoJdList = (from p in xmOrderInfoList
                                   where p.PlatformTypeId == 251
                                   select new OrderInfoSalesDetails
                                   {
                                       ID = p.ID,
                                       PlatformTypeId = p.PlatformTypeId,
                                       NickID = p.NickID,
                                       OrderCode = p.OrderCode,
                                       WantID = p.WantID,
                                       OrderInfoCreateDate = p.OrderInfoCreateDate,
                                       PayDate = p.PayDate,
                                       DeliveryTime = p.DeliveryTime,
                                       CompletionTime = p.CompletionTime,
                                       FullName = p.FullName,
                                       Mobile = p.Mobile,
                                       Tel = p.Tel,
                                       DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                                       ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                                       PayPrice = p.ReceivablePrice + p.DistributePrice,
                                       SalesPrice = 0,
                                       ProjectId = p.ProjectId,
                                       ProjectName = p.ProjectName,
                                       PlatformTypeName = p.PlatformTypeName,
                                       NickName = p.NickName
                                   }).ToList();
            #endregion

            #region 排除京东数据
            var OrderInfoNotJdList = (from p in xmOrderInfoList
                                      where p.PlatformTypeId != 251
                                      select new OrderInfoSalesDetails
                                      {
                                          ID = p.ID,
                                          PlatformTypeId = p.PlatformTypeId,
                                          NickID = p.NickID,
                                          OrderCode = p.OrderCode,
                                          WantID = p.WantID,
                                          OrderInfoCreateDate = p.OrderInfoCreateDate,
                                          PayDate = p.PayDate,
                                          DeliveryTime = p.DeliveryTime,
                                          CompletionTime = p.CompletionTime,
                                          FullName = p.FullName,
                                          Mobile = p.Mobile,
                                          Tel = p.Tel,
                                          DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                                          ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                                          PayPrice = p.PayPrice,
                                          SalesPrice = 0,
                                          ProjectId = p.ProjectId,
                                          ProjectName = p.ProjectName,
                                          PlatformTypeName = p.PlatformTypeName,
                                          NickName = p.NickName
                                      }).ToList();

            #endregion

            //合并数据源

            var OrderInfoListNew = OrderInfoJdList.Concat(OrderInfoNotJdList).OrderByDescending(p => p.OrderCode).ToList();

            #endregion

            #region 产品明细

            //原数据源

            var OrderInfoSalesDetailsList = base.XMOrderInfoProductDetailsService.GetOrderInfoSalesDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId), "");
           
            //去掉重复订单 数据源
            var OrderInfoSalesDetailsListNew = OrderInfoSalesDetailsList.GroupBy(p => p.OrderCode).Select(g => g.First()).ToList();

            // 取出重复订单
            var NotDate = (from a in OrderInfoSalesDetailsList
                           where !OrderInfoSalesDetailsListNew.Contains(a)
                           select new OrderInfoSalesDetails
                           {
                               ID = a.ID,
                               OrderCode = a.OrderCode,
                               PlatformTypeId = a.PlatformTypeId,
                               DeliveryTime = a.DeliveryTime,
                               PayDate = a.PayDate,
                               DetailsID = a.DetailsID,
                               PlatformMerchantCode = a.PlatformMerchantCode,
                               ProductName = a.ProductName,
                               Specifications = a.Specifications,
                               ProductNum = a.ProductNum,
                               FactoryPrice = a.FactoryPrice,
                               PayPrice = 0,
                               NickID = a.NickID,
                               PlatformTypeName = a.PlatformTypeName,
                               ProjectId = a.ProjectId,
                               ProjectName = a.ProjectName,
                               NickName = a.NickName,
                               ManufacturersCode = a.ManufacturersCode,
                               ProductId = a.ProductId
                           }).ToList();

            var OrderInfoSalesDetailsListDealWithNew = OrderInfoSalesDetailsListNew.Concat(NotDate).OrderByDescending(p => p.OrderCode).ToList();

            #endregion

            #region 产品统计
            List<OrderInfoSalesDetails> ProductSalesDetailsList =
                          OrderInfoSalesDetailsList.GroupBy(g => new { g.ProductName }).
                          Select(group => new OrderInfoSalesDetails()
                          {
                              ProductName = group.Key.ProductName,
                              FactoryPrice = group.Sum(l => l.FactoryPrice),
                              ProductNum = group.Sum(l => l.ProductNum),
                              AvgFactoryPrice = Math.Round(group.Sum(l => l.FactoryPrice.Value) / Convert.ToDecimal(group.Sum(l => l.ProductNum)), 2)
                          }).ToList();

            #endregion

            #region 返现明细
            List<OrderInfoSalesDetails> XMCashBackApplicationDetailsList = base.XMCashBackApplicationService.GetXMCashBackApplicationDetailsList(
          Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32(cbOrderStatusId));
                  
            #endregion

            #region 刷单记录明细

            //刷单记录明细
            List<OrderInfoSalesDetails> XMScalpingDetailsList = base.XMScalpingService.GetXMScalpingDetailsList
               (Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId));
                 
            #endregion


            #region 赠品明细

           
            //赠品明细
            var XMOrderInfoAndPremiumsDetailsList = base.XMOrderInfoService.getXMOrderInfoAndPremiumsDetailsList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId));

            #endregion

            //退换货明细
            var XMApplication = base.XMApplicationService.GetXMEXList(Convert.ToInt32(PlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd));
            base.ExportManager.ExportOrderInfoSalesDetailsXls(filePath, OrderInfoListNew, OrderInfoSalesDetailsListDealWithNew, ProductSalesDetailsList, XMCashBackApplicationDetailsList, XMScalpingDetailsList, XMOrderInfoAndPremiumsDetailsList, XMApplication);

            CommonHelper.WriteResponseXls(filePath, fileName);

            }
            catch (Exception exc)
            {
                ProcessException(exc);
            } 
         }
        /// <summary>
        /// 项目类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlXMProjectTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue) > 0)
            { 
                var ProjectTypeList = base.XMProjectService.GetXMProjectProjectTypeId(Convert.ToInt32(this.ddlXMProjectTypeId.SelectedValue)); 
                this.ddlXMProjectNameId.Items.Clear(); 
                this.ddlXMProjectNameId.DataSource = ProjectTypeList;
                this.ddlXMProjectNameId.DataTextField = "ProjectName";
                this.ddlXMProjectNameId.DataValueField = "Id";
                this.ddlXMProjectNameId.DataBind();
                this.ddlXMProjectNameId.Items.Insert(0, new ListItem("---所有---", "-1"));

            } 
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlXMProjectNameId_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue) > 0)
            //{ 
                var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddlXMProjectNameId.SelectedValue)); 
                this.ddlNickList.Items.Clear(); 
               // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                this.ddlNickList.DataSource = nickList;
                this.ddlNickList.DataTextField = "nick";
                this.ddlNickList.DataValueField = "nick_id";
                this.ddlNickList.DataBind();
                this.ddlNickList.Items.Insert(0, new ListItem("---所有---", "-1"));

                this.BindData();
            //} 
        }

        /// <summary>
        /// 平台类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPlatformTypeId_SelectedIndexChanged(object sender, EventArgs e)
        { 
                this.BindData();
           
        }
        
         

    }
}