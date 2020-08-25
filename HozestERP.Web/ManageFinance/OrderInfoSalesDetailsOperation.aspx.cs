using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using HozestERP.BusinessLogic.ManageProject;
using System.Data;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Common.Utils;
using System.IO;
using HozestERP.Common; 

namespace HozestERP.Web.ManageFinance
{ 

    public partial class OrderInfoSalesDetailsOperation : BaseAdministrationPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!X.IsAjaxRequest)
            if (!IsPostBack)
            {
                #region 付款开始时间、结束时间 （默认当前月初、月末）

                DateTime dt = DateTime.Now;
                //本月第一天时间   
                DateTime dt_First = dt.AddDays(-(dt.Day) + 1);
                //付款开始时间
                this.txtOrderInfoModifiedStart.Text = dt_First.ToString("yyyy-MM-dd");
                //将本月月数+1   
                DateTime dt2 = dt.AddMonths(1);
                //本月最后一天时间   
                DateTime dt_Last = dt2.AddDays(-(dt.Day));
                //付款结束时间
                this.txtOrderInfoModifiedEnd.Text = dt_Last.ToString("yyyy-MM-dd");

                #endregion  
                this.BindDateComboBox();
                this.BindData(); 
            }
        }
         
        private void BindDateComboBox()
        {
            #region 平台类型绑定 

            //平台类型动态数据绑定
            this.cbPlatformTypeId.Items.Clear();
            var codeLists = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
             //list 转 DateTable 
            DataTable dt = new DataTable();
            dt.Columns.Add("CodeID");
            dt.Columns.Add("CodeName"); 
            foreach (var codeList in codeLists)
            {
                DataRow dr = dt.NewRow();
                dr["CodeID"] = codeList.CodeID;
                dr["CodeName"] = codeList.CodeName;
                dt.Rows.Add(dr);
            }
             //平台下拉框绑定数据源
            foreach (DataRow dr_Secret in dt.Rows)  //遍历获取两个值
            {
                Ext.Net.ListItem Secretslist = new Ext.Net.ListItem();         //每次创建一个Ext.Net.ListItem的对象
                Secretslist.Value = dr_Secret["CodeID"].ToString();
                Secretslist.Text = dr_Secret["CodeName"].ToString();
                this.cbPlatformTypeId.Items.Add(Secretslist);
            }
            this.cbPlatformTypeId.Items.Insert(0, new Ext.Net.ListItem("--所有--", "-1"));
            this.cbPlatformTypeId.Value = "-1";

            #endregion

            #region 项目类型绑定 

            //平台类型动态数据绑定
            this.cbXMProjectTypeId.Items.Clear();
            var codeProjectTypeLists = base.CodeService.GetCodeListInfoByCodeTypeID(189, false);
             //list 转 DateTable 
            DataTable dtProjectType = new DataTable();
            dtProjectType.Columns.Add("CodeID");
            dtProjectType.Columns.Add("CodeName");
            foreach (var codeList in codeProjectTypeLists)
            {
                DataRow dr = dtProjectType.NewRow();
                dr["CodeID"] = codeList.CodeID;
                dr["CodeName"] = codeList.CodeName;
                dtProjectType.Rows.Add(dr);
            }
             //平台下拉框绑定数据源
            foreach (DataRow dr_Secret in dtProjectType.Rows)  //遍历获取两个值
            {
                Ext.Net.ListItem Secretslist = new Ext.Net.ListItem();         //每次创建一个Ext.Net.ListItem的对象
                Secretslist.Value = dr_Secret["CodeID"].ToString();
                Secretslist.Text = dr_Secret["CodeName"].ToString();
                this.cbXMProjectTypeId.Items.Add(Secretslist);
            }
            this.cbXMProjectTypeId.Items.Insert(0, new Ext.Net.ListItem("--所有--", "-1"));
            this.cbXMProjectTypeId.Value = "-1";

            #endregion 

            #region 项目名称绑定 

            //平台类型动态数据绑定
            this.cbXMProject.Items.Clear();
            var projectList = base.XMProjectService.GetXMProjectList();
            //list 转 DateTable 
            DataTable dtproject = new DataTable();
            dtproject.Columns.Add("Id");
            dtproject.Columns.Add("ProjectName");
            foreach (var project in projectList)
            {
                DataRow dr = dtproject.NewRow();
                dr["Id"] = project.Id;
                dr["ProjectName"] = project.ProjectName;
                dtproject.Rows.Add(dr);
            }
            //平台下拉框绑定数据源
            foreach (DataRow dr_Secret in dtproject.Rows)  //遍历获取两个值
            {
                Ext.Net.ListItem Secretslist = new Ext.Net.ListItem();         //每次创建一个Ext.Net.ListItem的对象
                Secretslist.Value = dr_Secret["Id"].ToString();
                Secretslist.Text = dr_Secret["ProjectName"].ToString();
                this.cbXMProject.Items.Add(Secretslist);
            }
            this.cbXMProject.Items.Insert(0, new Ext.Net.ListItem("--所有--", "-1"));
            this.cbXMProject.Value = "-1";

            #endregion

            #region 店铺名称绑定


            this.cbNick.Items.Clear();
            var NickList = base.XMNickService.GetXMNickList();
            var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList(); 
            //list 转 DateTable 
            DataTable dtNick = new DataTable();
            dtNick.Columns.Add("nick_id");
            dtNick.Columns.Add("nick");
            foreach (var nick in NickListNew)
            {
                DataRow dr = dtNick.NewRow();
                dr["nick_id"] = nick.nick_id;
                dr["nick"] = nick.nick;
                dtNick.Rows.Add(dr);
            }
            //平台下拉框绑定数据源
            foreach (DataRow dr_Secret in dtNick.Rows)  //遍历获取两个值
            {
                Ext.Net.ListItem Secretslist = new Ext.Net.ListItem();         //每次创建一个Ext.Net.ListItem的对象
                Secretslist.Value = dr_Secret["nick_id"].ToString();
                Secretslist.Text = dr_Secret["nick"].ToString();
                this.cbNick.Items.Add(Secretslist);
            }
            this.cbNick.Items.Insert(0, new Ext.Net.ListItem("---所有---", "-1"));
            this.cbNick.Value = "-1";

            #endregion

            #region 时间类型

            DataTable status = new DataTable();
            status.Columns.Add("ValueId");
            status.Columns.Add("ValueNsme");
            DataRow dr4 = status.NewRow();
            dr4["ValueId"] = "1";
            dr4["ValueNsme"] = "创单时间";
            status.Rows.Add(dr4); 
            DataRow dr1 = status.NewRow();
            dr1["ValueId"] = "2";//"WAIT_SELLER_SEND_GOODS,SELLER_CONSIGNED_PART,WAIT_SELLER_STOCK_OUT,WAIT_SELLER_DELIVERY,ORDER_TRUNED_TO_DO,10";
            dr1["ValueNsme"] = "付款时间";
            status.Rows.Add(dr1);
            DataRow dr2 = status.NewRow();
            dr2["ValueId"] = "3";//"WAIT_BUYER_CONFIRM_GOODS,WAIT_GOODS_RECEIVE_CONFIRM,STATUS_1,STATUS_10,STATUS_11,STATUS_22,STATUS_97,ORDER_OUT_OF_WH,新,以接受,已发货,已取消,20,21,SEND_TO_DISTRIBUTION_CENER,DISTRIBUTION_CENTER_RECEIVED,ORDER_RECEIVED";
            dr2["ValueNsme"] = "发货时间";
            status.Rows.Add(dr2);
            DataRow dr3 = status.NewRow();
            dr3["ValueId"] = "4";//"TRADE_BUYER_SIGNED,TRADE_FINISHED,FINISHED_L,RECEIPTS_CONFIRM,STATUS_1,STATUS_10,STATUS_11,STATUS_22,STATUS_97,ORDER_FINISH,新,以接受,已发货,已取消,30";
            dr3["ValueNsme"] = "交易成功时间";
            status.Rows.Add(dr3); 
            //DataRow dr4 = status.NewRow();
            //dr4["ValueId"] = "TRADE_CLOSED,TRADE_CANCELED,ORDER_CANCEL,40";
            //dr4["ValueNsme"] = "交易关闭";
            //status.Rows.Add(dr4);  
            //DataRow dr5 = status.NewRow();
            //dr5["ValueId"] = "LOCKED";
            //dr5["ValueNsme"] = "已锁定";
            //status.Rows.Add(dr5);  

            this.cbOrderStatus.Items.Clear();
            foreach (DataRow dr_Secret in status.Rows)  //遍历获取两个值
            {
                Ext.Net.ListItem Secretslist = new Ext.Net.ListItem();         //每次创建一个Ext.Net.ListItem的对象
                Secretslist.Value = dr_Secret["ValueId"].ToString();
                Secretslist.Text = dr_Secret["ValueNsme"].ToString();
                this.cbOrderStatus.Items.Add(Secretslist);
            }
            //this.cbOrderStatus.Items.Insert(0, new Ext.Net.ListItem("---所有---", "-1"));
            this.cbOrderStatus.Value = "1";
              
            #endregion
        } 

        /// <summary>
        /// 项目类型 关联项目名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbXMProjectTypeId_Change(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cbXMProjectTypeId.Value) > 0)
            {

                var ProjectTypeList = base.XMProjectService.GetXMProjectProjectTypeId(Convert.ToInt32(this.cbXMProjectTypeId.Value));

                #region 项目名称绑定

                //平台类型动态数据绑定
                this.cbXMProject.Items.Clear();
                //list 转 DateTable 
                DataTable dtproject = new DataTable();
                dtproject.Columns.Add("Id");
                dtproject.Columns.Add("ProjectName");
                foreach (var project in ProjectTypeList)
                {
                    DataRow dr = dtproject.NewRow();
                    dr["Id"] = project.Id;
                    dr["ProjectName"] = project.ProjectName;
                    dtproject.Rows.Add(dr);
                }
                //平台下拉框绑定数据源
                foreach (DataRow dr_Secret in dtproject.Rows)  //遍历获取两个值
                {
                    Ext.Net.ListItem Secretslist = new Ext.Net.ListItem();         //每次创建一个Ext.Net.ListItem的对象
                    Secretslist.Value = dr_Secret["Id"].ToString();
                    Secretslist.Text = dr_Secret["ProjectName"].ToString();
                    this.cbXMProject.Items.Add(Secretslist);
                }
                this.cbXMProject.Items.Insert(0, new Ext.Net.ListItem("--所有--", "-1"));
                this.cbXMProject.Value = "-1";

                #endregion

                this.ComboBoxXMProjectPanel.UpdateContent();
            }
        }

        /// <summary>
        /// 项目名称 关联店铺
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbXMProject_Change(object sender, EventArgs e)
        {
            if (Convert.ToInt32( this.cbXMProject.Value)> 0)
            {


               // this.cbNick.DataBind(); ;

                var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.cbXMProject.Value));

                #region 店铺名称绑定 
                   
                //list 转 DateTable 
                DataTable dtNick1 = new DataTable();
                dtNick1.Columns.Add("nick_id");
                dtNick1.Columns.Add("nick");
                foreach (var nick in nickList)
                {
                    DataRow dr = dtNick1.NewRow();
                    dr["nick_id"] = nick.nick_id;
                    dr["nick"] = nick.nick;
                    dtNick1.Rows.Add(dr);
                }
                //平台下拉框绑定数据源
                foreach (DataRow dr_Secret in dtNick1.Rows)  //遍历获取两个值
                {
                    Ext.Net.ListItem Secretslist = new Ext.Net.ListItem();         //每次创建一个Ext.Net.ListItem的对象
                    Secretslist.Value = dr_Secret["nick_id"].ToString();
                    Secretslist.Text = dr_Secret["nick"].ToString();
                    this.cbNick.Items.Add(Secretslist);
                }
                this.cbNick.Items.Insert(0, new Ext.Net.ListItem("-所有-", "-1"));
                this.cbNick.Value = "-1"; 
                #endregion


                this.ComboBoxPanel1.UpdateContent(); 
            }
        }

         
        protected void CitiesRefresh(object sender, EventArgs e)
        {
            var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.cbXMProject.Value));

            //list 转 DateTable 
            //DataTable dtNick1 = new DataTable();
            //dtNick1.Columns.Add("nick_id");
            //dtNick1.Columns.Add("nick");
            //foreach (var nick in nickList)
            //{
            //    DataRow dr = dtNick1.NewRow();
            //    dr["nick_id"] = nick.nick_id;
            //    dr["nick"] = nick.nick;
            //    dtNick1.Rows.Add(dr);
            //}
             
            //this.CitiesStore.DataSource = dtNick1;

            //this.CitiesStore.DataBind();

            //this.CitiesStore.DataBind(); 
            //.reload()  


        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.Page.Theme = "";
        }


        //public int PageIndex
        //{
        //    get { return this.PagingToolbar5.PageIndex; }
        //    set { this.PagingToolbar5.PageIndex = value; }
        //}

        //public int PageSize
        //{
        //    get
        //    {
        //        try
        //        {
        //            if (Convert.ToInt32(this.PagingToolbar5.PageSize) <= 0)
        //            {
        //                return 10;
        //            }
        //            return this.PagingToolbar5.PageSize;
        //        }
        //        catch
        //        {
        //        }

        //        return 10;
        //    }
        //    set { this.PagingToolbar5.PageSize = value; }
        //}
         
         
       // public int TotalCount { get; private set; }
        //public int TotalPages { get; private set; }
         

        private void BindData()
        {
            //绑定数据源
            #region 条件查询

            //平台类型
            string cbPlatformTypeId = "-1";
            if (this.cbPlatformTypeId.Value != null)
            {
                cbPlatformTypeId = this.cbPlatformTypeId.Value.ToString();
            }

            //付款开始时间
            string OrderInfoModifiedStart = this.txtOrderInfoModifiedStart.Text;
            //付款结束时间
            string OrderInfoModifiedEnd =  DateTime.Parse(this.txtOrderInfoModifiedEnd.Text).AddDays(1).AddSeconds(-1).ToString();//结束时间设置到该天23：59：59

              
            //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
            var cbOrderStatusId = this.cbOrderStatus.Value.ToString();


            //项目类型： 自运营、代运营
            string cbXMProjectTypeId="-1";
            
            if (this.cbXMProjectTypeId.Value != null)
            { 
                cbXMProjectTypeId = this.cbXMProjectTypeId.Value.ToString();
            }
              
            
            //项目名称
            string cbXMProject = "-1";
            if (this.cbXMProject.Value != null)
            {
                cbXMProject = this.cbXMProject.Value.ToString();
            } 
            string cbNick = "-1";

            if (this.cbNick.Value != null)
            {
                cbNick = this.cbNick.Value.ToString();
            }

            //店铺集合
            List<int> nickIdList = new List<int>();

            #region 店铺条件查询集合 处理
            //选择某项目  
            if (cbXMProject != "-1")
            {
                if (cbNick == "-1")//项目下的所有店铺
                {
                    var nickList = base.XMNickService.GetXMNickListByProjectId( Convert.ToInt32(this.cbXMProject.Value),Convert.ToInt32(this.cbXMProjectTypeId.Value));
                     
                    var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList(); 

                    if (NickListNew.Count > 0)
                    {
                        nickIdList = NickListNew.Select(p => p.nick_id).ToList();
                    }
                }
                else
                {

                    nickIdList.Add(Convert.ToInt32(this.cbNick.Value));
                }
            }
            else
            {
                if (cbNick == "-1")
                {
                    var NickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.cbXMProject.Value), Convert.ToInt32(this.cbXMProjectTypeId.Value));

                    var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    nickIdList = NickListNew.Select(a => a.nick_id).ToList();
                }
                else
                {
                    nickIdList.Add(Convert.ToInt32(this.cbNick.Value));
                }

            }
            #endregion

            //厂家编码
            var ManufacturersCode = this.txtManufacturersCode.Text.Trim();

            #endregion

            #region 订单明细


            var xmOrderInfoList = base.XMOrderInfoService.getXMOrderInfoList(Convert.ToInt32(cbPlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId), ManufacturersCode);
             
           // var pageList = new PagedList<OrderInfoSalesDetails>(xmOrderInfoList, this.PageIndex, this.PageSize);
            
            Store store = this.GridPanel5.GetStore();
             
            store.DataSource = xmOrderInfoList;
            store.DataBind();
           
            
            //this.Store5.DataSource = xmOrderInfoList;
            //this.Store5.DataBind(); 


            #endregion 

            #region 产品明细
            //原数据源
            var OrderInfoSalesDetailsList = base.XMOrderInfoProductDetailsService.GetOrderInfoSalesDetailsList(Convert.ToInt32(cbPlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId), ManufacturersCode);
              
            //去掉重复的数据源
            var NotOrderInfoSalesDetailsList = OrderInfoSalesDetailsList.GroupBy(p => p.OrderCode).Select(g => g.First()).ToList();

            //重复数据源(重新给成交金额赋值)
            var NotDate = (from a in OrderInfoSalesDetailsList
                           where !NotOrderInfoSalesDetailsList.Contains(a)
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

            //去掉重复的数据源 + 重复数据源
            var OrderInfoSalesDetailsListNew = NotOrderInfoSalesDetailsList.Concat(NotDate).OrderByDescending(p=>p.OrderCode).ToList();

            Store store1 = this.GridPanel1.GetStore();
            store1.DataSource = OrderInfoSalesDetailsListNew;
            store1.DataBind();

            //Store1.DataSource = OrderInfoSalesDetailsListNew;
            //Store1.DataBind();
            #endregion

            #region 产品统计
            List<OrderInfoSalesDetails> ProductSalesDetailsList =
                          OrderInfoSalesDetailsList.GroupBy(g => new { g.ProductName }).
                          Select(group => new OrderInfoSalesDetails()
                          {
                              ProductName = group.Key.ProductName,
                              FactoryPrice = group.Sum(l => l.FactoryPrice),
                              ProductNum = group.Sum(l => l.ProductNum),
                              AvgFactoryPrice = Math.Round(group.Sum(l => l.FactoryPrice.Value) / Convert.ToDecimal( group.Sum(l => l.ProductNum)), 2)
                          }).ToList();


            Store store2 = this.GridPanel2.GetStore();
            store2.DataSource = ProductSalesDetailsList;
            store2.DataBind();

            //Store2.DataSource = ProductSalesDetailsList;//Math.Round(d,2)
            //Store2.DataBind();

            #endregion

            #region 返现明细

            List<OrderInfoSalesDetails> XMCashBackApplicationDetailsList = base.XMCashBackApplicationService.GetXMCashBackApplicationDetailsList(
               Convert.ToInt32(cbPlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32(cbOrderStatusId));


            //List<XMCashBackApplication> XMCashBackApplicationDetailsList = base.XMCashBackApplicationService.GetXMCashBackApplicationDetailsList( OrderInfoListNew, Convert.ToInt32(StatusEnum.AlreadyCashBack));

            Store store3 = this.GridPanel3.GetStore();
            store3.DataSource = XMCashBackApplicationDetailsList;
            store3.DataBind();

            //Store3.DataSource = XMCashBackApplicationDetailsList;
            //Store3.DataBind();

            #endregion

            #region 刷单记录明细

            List<OrderInfoSalesDetails> XMScalpingDetailsList = base.XMScalpingService.GetXMScalpingDetailsList
                (Convert.ToInt32(cbPlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId));


            Store store4 = this.GridPanel4.GetStore();
            store4.DataSource = XMScalpingDetailsList;
            store4.DataBind();

            //Store4.DataSource = XMScalpingDetailsList;
            //Store4.DataBind();

            #endregion

            #region 统计数据绑定

            var strSumProductNum = ProductSalesDetailsList.Sum(p => p.ProductNum == null ? 0 : p.ProductNum.Value).ToString();

            var strSumFactoryPrice = ProductSalesDetailsList.Sum(p => p.FactoryPrice == null ? 0 : p.FactoryPrice.Value).ToString();

            var strSumCashBackMoney = XMCashBackApplicationDetailsList.Sum(p => p.CashBackMoney == null ? 0 : p.CashBackMoney.Value).ToString();

            var strSumSalePrice = XMScalpingDetailsList.Sum(p => p.SalePrice == null ? 0 : p.SalePrice.Value).ToString();

            var strSumFee = XMScalpingDetailsList.Sum(p => p.Fee == null ? 0 : p.Fee.Value).ToString();

            var strSumDeduction = XMScalpingDetailsList.Sum(p => p.Deduction == null ? 0 : p.Deduction.Value).ToString();
             

            var strPayPriceList = OrderInfoSalesDetailsList.GroupBy(p => p.OrderCode).Select(g => g.First()).ToList();
            
            var strPayPrice = strPayPriceList.Sum(p => p.PayPrice == null ? 0 : p.PayPrice.Value).ToString();

            //总订购数量
            this.txtSumProductNumV.Text = "订购数量:";
            this.txtSumProductNumSum.Text = strSumProductNum == "" ? "0" : strSumProductNum; 
            //出厂总价
            this.txtSumFactoryPriceV.Text = "出厂价格:";
            this.txtSumFactoryPriceSum.Text = strSumFactoryPrice == "" ? "0" : strSumFactoryPrice;
            //总返现金额
            this.txtSumCashBackMoneyV.Text = "返现金额:";
            this.txtSumCashBackMoneySum.Text = strSumCashBackMoney == "" ? "0" : strSumCashBackMoney;
            //刷单总销售额
            this.txtSumSalePriceV.Text = "刷单金额:";
            this.txtSumSalePriceSum.Text = strSumSalePrice == "" ? "0" : strSumSalePrice;
            //总佣金
            this.txtSumFeeV.Text = "刷单佣金:";
            this.txtSumFeeSum.Text = strSumFee == "" ? "0" : strSumFee;
            //总扣点
            this.txtSumDeductionV.Text = "平台扣点:";
            this.txtSumDeductionSum.Text = strSumDeduction == "" ? "0" : strSumDeduction;


            this.txtPayPriceV.Text = "成交金额:";
            this.txtPayPriceSum.Text = strPayPrice == "" ? "0" : strPayPrice;

            #endregion

        }


         // 分页刷新
        protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.BindData();
        }
        //分页刷新
        protected void MyData2_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
           this.BindData();
        }
        //分页刷新
        protected void MyData3_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.BindData();
        }
        //分页刷新
        protected void MyData4_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.BindData();
        }
        //分页刷新
        protected void MyData5_Refresh(object sender,  StoreRefreshDataEventArgs e)
        {
            int start = e.Start;
            int limit = e.Limit; 
            #region 订单明细
             
            //var xmOrderInfoList = base.XMOrderInfoService.getXMOrderInfoList(Convert.ToInt32(cbPlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId), ManufacturersCode);
             
            //var pageList = new PagedList<OrderInfoSalesDetails>(xmOrderInfoList, this.PageIndex, this.PageSize);

            //int total = xmOrderInfoList.Count();//总条数
            //int TotalPages = 0; //总页数
            //TotalPages = total / this.PageSize;
            //if (total % this.PageSize > 0)
            //    TotalPages++; 

            //this.TotalCount = total;
            //this.TotalPages = TotalPages;  
            //e.Total = total;

            //this.Store5.DataSource = xmOrderInfoList.Skip((this.PageIndex-1)* this.PageSize).Take(this.PageSize).ToList();
            //this.Store5.DataBind();  
             
            #endregion 
            this.BindData();
        }

         
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {


            this.PagingToolbar1.PageSize = 10;
            this.PagingToolbar2.PageSize = 10;
            this.PagingToolbar3.PageSize = 10;
            this.PagingToolbar4.PageSize = 10;
            this.PagingToolbar5.PageSize = 10;
            this.BindData();   
             
        }




        //导出明细
        protected void btnOrderInfoSalesDetailsExport_Click(object sender, EventArgs e)
        { 
            try
            {
                //string StartTime = DateTime.Parse(this.txtOrderInfoModifiedStart.Text).ToString("yyyy-MM-dd").ToString();
                //string EndTime = DateTime.Parse(this.txtOrderInfoModifiedEnd.Text).ToString("yyyy-MM-dd").ToString();
                //string Platform = "All";
                //string Project = "All";
                //string Nick = "All";

                //if (this.cbPlatformTypeId.Value != "-1") 
                //    Platform = this.cbPlatformTypeId.Text;
                //if (this.cbXMProject.Value != "-1")
                //    Project = this.cbXMProject.Text;
                //if (this.cbNick.Value != "-1")
                //    Nick = this.cbNick.Text;
                //string fileName = string.Format("Exports_{0}_{1}.xls", Platform + "-" + Project + "-" + Nick + "Earnings", StartTime + "--" + EndTime);
                //string filePath = string.Format("{0}Upload\\OrderInfoSalesDetailsExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);
                  
                string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                string filePath = string.Format("{0}Upload\\OrderInfoSalesDetailsExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                #region 条件查询

                //平台类型
                string cbPlatformTypeId = "-1";
                if (this.cbPlatformTypeId.Value != null)
                {
                    cbPlatformTypeId = this.cbPlatformTypeId.Value.ToString();
                }

                //付款开始时间
                string OrderInfoModifiedStart = this.txtOrderInfoModifiedStart.Text;
                //付款结束时间
                string OrderInfoModifiedEnd = DateTime.Parse(this.txtOrderInfoModifiedEnd.Text).AddDays(1).AddSeconds(-1).ToString();//结束时间设置到该天23：59：59


                //时间类型 创单时间：1、 付款时间：2、发货时间：3、交易成功时间：4
                var cbOrderStatusId = this.cbOrderStatus.Value.ToString();


                //项目类型： 自运营、代运营
                string cbXMProjectTypeId = "-1";

                if (this.cbXMProjectTypeId.Value != null)
                {
                    cbXMProjectTypeId = this.cbXMProjectTypeId.Value.ToString();
                }


                //项目名称
                string cbXMProject = "-1";
                if (this.cbXMProject.Value != null)
                {
                    cbXMProject = this.cbXMProject.Value.ToString();
                }
                string cbNick = "-1";

                if (this.cbNick.Value != null)
                {
                    cbNick = this.cbNick.Value.ToString();
                }

                //店铺集合
                List<int> nickIdList = new List<int>();

                #region 店铺条件查询集合 处理
                //选择某项目  
                if (cbXMProject != "-1")
                {
                    if (cbNick == "-1")//项目下的所有店铺
                    {
                        var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.cbXMProject.Value), Convert.ToInt32(this.cbXMProjectTypeId.Value));
                         
                        var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                        if (NickListNew.Count > 0)
                        {
                            nickIdList = NickListNew.Select(p => p.nick_id).ToList();
                        }
                    }
                    else
                    {

                        nickIdList.Add(Convert.ToInt32(this.cbNick.Value));
                    }
                }
                else
                {
                    if (cbNick == "-1")
                    {
                        var NickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.cbXMProject.Value), Convert.ToInt32(this.cbXMProjectTypeId.Value));
                         
                        var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                        nickIdList = NickListNew.Select(a => a.nick_id).ToList();
                    }
                    else
                    {
                        nickIdList.Add(Convert.ToInt32(this.cbNick.Value));
                    }

                }
                #endregion

                //厂家编码
                var ManufacturersCode = this.txtManufacturersCode.Text.Trim();

                #endregion
                 
                #region 订单明细

                var xmOrderInfoList = base.XMOrderInfoService.getXMOrderInfoList(Convert.ToInt32(cbPlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId), ManufacturersCode);

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

                var OrderInfoSalesDetailsList = base.XMOrderInfoProductDetailsService.GetOrderInfoSalesDetailsList(Convert.ToInt32(cbPlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId), ManufacturersCode);
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
              Convert.ToInt32(cbPlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(StatusEnum.AlreadyCashBack), Convert.ToInt32(cbOrderStatusId));

                #endregion

                #region 刷单记录明细

                List<OrderInfoSalesDetails> XMScalpingDetailsList = base.XMScalpingService.GetXMScalpingDetailsList
                    (Convert.ToInt32(cbPlatformTypeId), nickIdList, Convert.ToDateTime(OrderInfoModifiedStart), Convert.ToDateTime(OrderInfoModifiedEnd), Convert.ToInt32(cbOrderStatusId));

                #endregion

                base.ExportManager.ExportOrderInfoSalesDetailsXls(filePath, OrderInfoListNew, OrderInfoSalesDetailsListDealWithNew, ProductSalesDetailsList, XMCashBackApplicationDetailsList, XMScalpingDetailsList);
                 
                CommonHelper.WriteResponseXls(filePath, fileName);
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            } 
        }

     

    }
}