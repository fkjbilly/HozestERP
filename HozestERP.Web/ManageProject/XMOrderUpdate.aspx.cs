using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.PlatOrderGrab;
using HozestERP.Common;
using HozestERP.Common.Utils;
using JdSdk.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Top.Api.Domain;
using Yhd.Api;
using Yhd.Api.Request;
using Yhd.Api.Response;

namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderUpdate : BaseAdministrationPage, IEditPage
    {
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnUpdateAllorder", "ManageProject.XMOrderUpdate.UpdateAllorder");//全部订单同步
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ckbIsScalping.Enabled = false;
                this.ckbIsCashBack.Enabled = false;
                this.ckbIsSentGifts.Enabled = false;
                this.ckbIsEvaluate.Enabled = false;
                this.ckbIsDistributed.Enabled = false;
                this.ckbIsInvoiced.Enabled = false;
                //问题反馈、问题处理
                if (this.XMOrderType == "QuestionValue")
                {
                    if (this.XMQuestionId != 0)
                    {

                        var xMQuestion = base.XMQuestionService.GetById(this.XMQuestionId);

                        if (xMQuestion != null)
                        {
                            this.txtSearchOrderCode.Text = xMQuestion.OrderNO;
                        }

                    }
                }
                //退换货
                else if (this.XMOrderType == "Application")
                {
                    if (this.XMApplicationOrderCode != "")
                    {
                        this.txtSearchOrderCode.Text = this.XMApplicationOrderCode.ToString();
                    }
                }
                //发货单管理
                else if (this.XMOrderType == "DeliveryValue")
                {
                    if (this.XMDeliveryId != 0)
                    {

                        var xMDelivery = base.XMDeliveryService.GetXMDeliveryById(this.XMDeliveryId);

                        if (xMDelivery != null)
                        {
                            this.txtSearchOrderCode.Text = xMDelivery.OrderCode;
                        }

                    }
                }
                //返现管理
                else if (this.XMOrderType == "XMCashBackApplicationValue")
                {
                    if (this.XMCashBackApplicationId != 0)
                    {

                        var xMCashBackApplication = base.XMCashBackApplicationService.GetXMCashBackApplicationById(this.XMCashBackApplicationId);

                        if (xMCashBackApplication != null)
                        {
                            this.txtSearchOrderCode.Text = xMCashBackApplication.OrderCode;
                        }

                    }
                }
                //赠品管理
                else if (this.XMOrderType == "XMPremiumsValue")
                {
                    if (this.XMPremiumsId != 0)
                    {
                        var xMPremiums = base.XMPremiumsService.GetXMPremiumsById(this.XMPremiumsId);

                        if (xMPremiums != null)
                        {
                            this.txtSearchOrderCode.Text = xMPremiums.OrderCode;
                        }

                    }
                }



                GetValue(this.txtSearchOrderCode.Text.Trim());

            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("订单管理 > 订单单个同步");
        }

        public void SetTrigger()
        {
            // this.Master.SetTrigger(this.btnSave.UniqueID, this.Page); 

        }
        #endregion

        private XMOrderInfo xmorderinfo;//订单信息

        /// <summary>
        /// 订单号获取数据绑定
        /// </summary>
        /// <param name="ordercode"></param>
        protected void GetValue(string ordercode)
        {
            if (ordercode != "")
            {
                xmorderinfo = null;//初始化
                xmorderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(ordercode);//订单号查询订单
                if (xmorderinfo != null)
                {
                    //基础信息
                    //List<CodeList> codeList = base.CodeService.GetCodeList(Convert.ToInt32(xmorderinfo.PlatformTypeId));
                    //if (codeList.Count > 0)
                    //{
                    //    lblPlatformTypeId.Text = codeList[0].CodeName;
                    //}
                    this.lblPlatformTypeId.Text = xmorderinfo.PlatformName;
                    this.lblNickId.Text = xmorderinfo.NickName;
                    this.lblOrderCode.Text = xmorderinfo.OrderCode;
                    this.lblOrderStatus.Text = GetOrderStatusNew(xmorderinfo.OrderStatus == null ? "" : xmorderinfo.OrderStatus, xmorderinfo==null?"": xmorderinfo.PlatformTypeId.ToString());
                    this.txtCompletionTime.Text = xmorderinfo.CompletionTime == null ? "" : xmorderinfo.CompletionTime.Value.ToString("yyyy-MM-dd");  //xMOrderInfo.CompletionTime;
                    this.txtDeliveryTime.Text = xmorderinfo.DeliveryTime == null ? "" : xmorderinfo.DeliveryTime.Value.ToString("yyyy-MM-dd");  //xMOrderInfo.DeliveryTime;
                    this.txtPayDate.Text = xmorderinfo.PayDate == null ? "" : xmorderinfo.PayDate.Value.ToString(); //xMOrderInfo.PayDate;
                    this.txtOrderInfoCreateDate.Text = xmorderinfo.OrderInfoCreateDate == null ? "" : xmorderinfo.OrderInfoCreateDate.Value.ToString();
                    this.txtSourceType.Text = xmorderinfo.SourceType;
                    this.txtWantID.Text = xmorderinfo.WantID;
                    if (xmorderinfo.IsScalping != null && xmorderinfo.IsScalping != false)
                    {
                        this.ckbIsScalping.Checked = true;
                    }
                    if (xmorderinfo.IsCashBack != null && xmorderinfo.IsCashBack != false)
                    {
                        this.ckbIsCashBack.Checked = true;
                    }
                    if (xmorderinfo.IsSentGifts != null && xmorderinfo.IsSentGifts != false)
                    {
                        this.ckbIsSentGifts.Checked = true;
                    }
                    if (xmorderinfo.IsEvaluate != null && xmorderinfo.IsEvaluate != false)
                    {
                        this.ckbIsEvaluate.Checked = true;
                    }
                    //商品价格
                    this.txtProductPrice.Text = xmorderinfo.ProductPrice == null ? "0" : xmorderinfo.ProductPrice.ToString();
                    this.txtDistributePrice.Text = xmorderinfo.DistributePrice == null ? "0" : xmorderinfo.DistributePrice.ToString();
                    this.txtSupportPrice.Text = xmorderinfo.SupportPrice == null ? "0" : xmorderinfo.SupportPrice.ToString();
                    this.txtTaxes.Text = xmorderinfo.Taxes == null ? "0" : xmorderinfo.Taxes.ToString();
                    this.txtDiscount.Text = xmorderinfo.Discount == null ? "0" : xmorderinfo.Discount.ToString();
                    this.txtProductPromotion.Text = xmorderinfo.ProductPromotion == null ? "0" : xmorderinfo.ProductPromotion.ToString();
                    this.txtOrderPromotion.Text = xmorderinfo.OrderPromotion == null ? "0" : xmorderinfo.OrderPromotion.ToString();
                    this.txtOrderPrice.Text = xmorderinfo.OrderPrice == null ? "0" : xmorderinfo.OrderPrice.ToString();
                    this.txtReceivablePrice.Text = xmorderinfo.ReceivablePrice == null ? "0" : xmorderinfo.ReceivablePrice.ToString();
                    this.txtPayPrice.Text = xmorderinfo.PayPrice == null ? "0" : xmorderinfo.PayPrice.ToString();
                    //订单其他信息
                    this.txtDistributeMethod.Text = xmorderinfo.DistributeMethod;
                    if (xmorderinfo.IsDistributed != null && xmorderinfo.IsDistributed != false)
                    {
                        this.ckbIsDistributed.Checked = true;
                    }
                    this.txtProductWeight.Text = xmorderinfo.ProductWeight == null ? "0" : xmorderinfo.ProductWeight.ToString();
                    this.txtPayMethod.Text = xmorderinfo.PayMethod;
                    this.txtInvoicePrice.Text = xmorderinfo.InvoicePrice == null ? "0" : xmorderinfo.InvoicePrice.ToString();
                    if (xmorderinfo.IsInvoiced != null && xmorderinfo.IsInvoiced != false)
                    {
                        this.ckbIsInvoiced.Checked = true;
                    }
                    this.txtInvoiceNo.Text = xmorderinfo.InvoiceNo;
                    this.txtInvoiceHead.Text = xmorderinfo.InvoiceHead;
                    this.txtCustomerService.Text = xmorderinfo.CustomerServiceName;
                    //收货人信息
                    this.txtAppointDeliveryTime.Text = xmorderinfo.AppointDeliveryTime == null ? "" : xmorderinfo.AppointDeliveryTime.ToString();
                    this.txtFullName.Text = xmorderinfo.FullName;
                    this.txtMobile.Text = xmorderinfo.Mobile;
                    this.txtTel.Text = xmorderinfo.Tel;
                    this.txtAddress.Text = xmorderinfo.Province + " " + xmorderinfo.City + " " + xmorderinfo.County;
                    this.txtDeliveryAddress.Text = xmorderinfo.DeliveryAddress;
                    this.txtDeliveryAddressSpare.Text = xmorderinfo.DeliveryAddressSpare;
                    //订单产品信息
                    this.grdvClients.DataSource = xmorderinfo.XM_OrderInfoProductDetails;
                    this.grdvClients.DataBind();
                    //备注信息
                    this.txtRemark.Text = xmorderinfo.Remark;
                    this.txtCustomerRemark.Text = xmorderinfo.CustomerServiceRemark;


                    bool Edit = false;
                    if (xmorderinfo.XM_OrderInfoProductDetails == null || xmorderinfo.XM_OrderInfoProductDetails.Count == 0)
                    {
                        Edit = true;
                    }

                    if (xmorderinfo.NickID != 32 && xmorderinfo.XM_OrderInfoProductDetails.Count > 0)
                    {
                        foreach (var Info in xmorderinfo.XM_OrderInfoProductDetails)
                        {
                            if (Info.IsSingleRow == null || Info.IsSingleRow == false)
                            {
                                Edit = true;
                                break;
                            }
                        }
                    }
                    else if (xmorderinfo.NickID == 32 && xmorderinfo.XM_OrderInfoProductDetails.Count > 0)
                    {
                        foreach (var Info in xmorderinfo.XM_OrderInfoProductDetails)
                        {
                            if (Info.PlatformMerchantCode.Length > 2 && Info.PlatformMerchantCode.Substring(0, 2) == "CM" && (Info.IsSingleRow == null || Info.IsSingleRow == false))
                            {
                                Edit = true;
                                break;
                            }
                        }
                    }

                    string type = "";
                    if (Edit)
                    {
                        //弹出收货人信息修改页面
                        this.btnUpdateConsignee.OnClientClick = "return ShowWindowDetail('收货人信息','" + CommonHelper.GetStoreLocation() +
                    "ManageProject/XMOrderUpdateConsignee.aspx?OrderCode=" + ordercode + "',400,420, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                        type = "1";
                    }
                    else
                    {
                        this.btnUpdateConsignee.OnClientClick = "return alert('已排单的订单不能修改！');";
                        type = "0";
                    }

                    //弹出客服备注修改页面
                    this.btnUpdateCustomerServiceRemark.OnClientClick = "return ShowWindowDetail('备注信息','" + CommonHelper.GetStoreLocation() +
                "ManageProject/XMOrderUpdateCustomerRemark.aspx?type=" + type + "&OrderCode=" + ordercode + "',600,320, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                    //弹出商品信息修改页面
                    this.btnUpdateProductDetails.OnClientClick = "return ShowWindowDetail('商品信息','" + CommonHelper.GetStoreLocation() +
                "ManageProject/XMOrderUpdateProductDetails.aspx?OrderCode=" + ordercode + "',900,400, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                }
                else
                {
                    base.ShowMessage("请输入正确的订单编号！");

                    //弹出收货人信息修改页面
                    this.btnUpdateConsignee.OnClientClick = "return ShowWindowDetail('','',,,,;});";

                    //弹出商品信息修改页面
                    this.btnUpdateProductDetails.OnClientClick = "return ShowWindowDetail('','',,,,;});";

                    //弹出客服备注修改页面
                    this.btnUpdateCustomerServiceRemark.OnClientClick = "return ShowWindowDetail('','',,,,;});";
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
            if (this.txtSearchOrderCode.Text.Trim() == "")
            {
                base.ShowMessage("请输入订单编号！");
            }
            else
            {
                GetValue(this.txtSearchOrderCode.Text.Trim());
            }
        }

        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="OrderStatus"></param>
        /// <returns></returns>
        protected string GetOrderStatus(string OrderStatus)
        {
            List<Setting> settingList = base.SettingManager.GetSettingsList();
            var Setting = settingList.FirstOrDefault(p => p.Value.Contains(OrderStatus));
            if (Setting != null)
            {
                return Setting.Name;
            }
            else //其他类型订单全部使用通用状态
            {
                var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(239);
                if (Setting != null)
                {
                    return Setting.Name;
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="OrderStatus"></param>
        /// <returns></returns>
        protected string GetOrderStatusNew(string OrderStatus, string platformtypeid)
        {
            var codeTypeInfo = base.CodeTypeService.GetCodeTypeByPlatFormTypeId(platformtypeid).SingleOrDefault();
            if (codeTypeInfo != null)
            {
                var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(codeTypeInfo.CodeTypeID);
                var Setting = codeList.FirstOrDefault(p => p.CodeNO.Equals(OrderStatus));
                if (Setting != null)
                {
                    return Setting.CodeName;
                }
                else
                {
                    return "";
                }
            }
            else //其他类型订单全部使用通用状态
            {
                var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(239);
                var Setting = codeList.FirstOrDefault(p => p.CodeNO.Equals(OrderStatus));
                if (Setting != null)
                {
                    return Setting.CodeName;
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtSearchOrderCode.Text.Trim() == "")
            {
                base.ShowMessage("请输入订单编号！");
                return;
            }
            else
            {
                //订单号查询
                xmorderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(this.txtSearchOrderCode.Text.Trim());
            }

            int TMInsertCount = 0;
            int TMUpdateCount = 0;

            int JDInsertCount = 0;
            int JDUpdateCount = 0;

            int TMCDInsertCount = 0;
            int TMCDUpdateCount = 0;

            int VPHInsertCount = 0;
            int VPHUpdateCount = 0;

            int VPHMPInsertCount = 0;
            int VPHMPUpdateCount = 0;

            int YHDInsertCount = 0;
            int YHDUpdateCount = 0;

            int SuningInsertCount = 0;
            int SuningUpdateCount = 0;
            //订单号订单表 已经存在  
            if (this.xmorderinfo != null)
            {
                #region 各平台单个订单同步

                var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();

                switch (xmorderinfo.PlatformTypeId)
                {
                    //天猫
                    case 250:
                        XMOrderInfoApp xMorderInfoAppTMNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 250 && q.NickId == xmorderinfo.NickID).FirstOrDefault();
                        if (xMorderInfoAppTMNew != null)
                        {

                            Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(xmorderinfo.OrderCode), xMorderInfoAppTMNew);

                            if (trade != null)
                            {
                                base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoAppTMNew);
                            }
                        }
                        break;
                    //京东 (喜临门、嘟丽)
                    case 251:
                        List<XMOrderInfoApp> xMorderInfoAppJDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 251 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoAppJDNew.Count > 0)
                        {
                            for (int j = 0; j < xMorderInfoAppJDNew.Count; j++)
                            {
                                HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xmorderinfo.OrderCode, xMorderInfoAppJDNew[j].AppKey, xMorderInfoAppJDNew[j].AppSecret, xMorderInfoAppJDNew[j].ServerUrl, xMorderInfoAppJDNew[j].AccessToken);
                                if (orderInfo != null)
                                {
                                    base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDNew[j]);
                                }
                            }
                        }
                        break;
                    case 823://京东拼购
                        var xMorderInfoAppJDNew1 = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 823 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoAppJDNew1.Count > 0)
                        {
                            for (int j = 0; j < xMorderInfoAppJDNew1.Count; j++)
                            {
                                HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xmorderinfo.OrderCode, xMorderInfoAppJDNew1[j].AppKey, xMorderInfoAppJDNew1[j].AppSecret, xMorderInfoAppJDNew1[j].ServerUrl, xMorderInfoAppJDNew1[j].AccessToken);
                                if (orderInfo != null)
                                {
                                    base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDNew1[j]);
                                }
                            }
                        }
                        break;
                    //京东闪购
                    case 382:
                        List<XMOrderInfoApp> xMorderInfoAppJDSJNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 382 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoAppJDSJNew.Count > 0)
                        {
                            for (int j = 0; j < xMorderInfoAppJDSJNew.Count; j++)
                            {
                                HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xmorderinfo.OrderCode, xMorderInfoAppJDSJNew[j].AppKey, xMorderInfoAppJDSJNew[j].AppSecret, xMorderInfoAppJDSJNew[j].ServerUrl, xMorderInfoAppJDSJNew[j].AccessToken);
                                if (orderInfo != null)
                                {
                                    base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDSJNew[j]);

                                }
                            }
                        }
                        break;
                    //淘宝集市店
                    case 381:
                        List<XMOrderInfoApp> xMorderInfoAppTMCDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 381 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoAppTMCDNew.Count > 0)
                        {
                            for (int j = 0; j < xMorderInfoAppTMCDNew.Count; j++)
                            {
                                Trade trade = base.XMOrderInfoAPIService.GetTrade(long.Parse(xmorderinfo.OrderCode), xMorderInfoAppTMCDNew[j]);
                                if (trade != null)
                                {
                                    base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMCDInsertCount, ref  TMCDUpdateCount, xMorderInfoAppTMCDNew[j]);
                                }
                            }
                        }
                        break;
                    //唯品会
                    case 259:
                        List<XMOrderInfoApp> xMorderInfoVPHNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 259 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoVPHNew.Count > 0)
                        {
                            base.XMOrderInfoAPIService.getOrderVPH(DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd  HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss"), xmorderinfo.OrderCode, ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoVPHNew[0]);
                        }
                        break;
                    //唯品会MP
                    case 803:
                        List<XMOrderInfoApp> xMorderInfoVPHMPNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 803 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoVPHMPNew.Count > 0)
                        {
                            for (int l = 0; l < xMorderInfoVPHMPNew.Count; l++)
                            {
                                base.XMOrderInfoAPIService.getOrderVPHMP(xmorderinfo.OrderCode, ref VPHMPInsertCount, ref VPHMPUpdateCount, xMorderInfoVPHMPNew[l]);
                            }
                        }
                        break;
                    //一号店
                    case 375:
                        List<XMOrderInfoApp> xMorderInfoYHDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 375 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoYHDNew.Count > 0)
                        {
                            for (int j = 0; j < xMorderInfoYHDNew.Count; j++)
                            {
                                base.XMOrderInfoAPIService.getOrderYHD(xmorderinfo.OrderCode, ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoYHDNew[j]);
                            }
                        }
                        break;
                    //苏宁易购
                    case 383:
                        List<XMOrderInfoApp> xMorderInfoSuningNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 383 && q.NickId == xmorderinfo.NickID).ToList();
                        if (xMorderInfoSuningNew.Count > 0)
                        {
                            for (int j = 0; j < xMorderInfoSuningNew.Count; j++)
                            {
                                base.XMOrderInfoAPIService.getOrderSuning(xmorderinfo.OrderCode, ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoSuningNew[j]);
                            }
                        }
                        break;
                }

                int count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount + VPHMPInsertCount + VPHMPUpdateCount;

                if (count > 0)
                {
                    //修改公公参数
                    base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");

                    #region 订单单个同步记录操作

                    int UpsatorID1 = 0;
                    if (HozestERPContext.Current.User != null)
                    {
                        UpsatorID1 = HozestERPContext.Current.User.CustomerID;

                    }
                    else
                    {
                        string UserName = "admin";
                        List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                        if (customer.Count > 0)
                        {
                            UpsatorID1 = customer[0].CustomerID;
                        }
                    }

                    XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                    record1.OrderInfoId = this.xmorderinfo.ID;
                    record1.PropertyName = "订单单个同步";
                    record1.OldValue = "同步成功";
                    record1.NewValue = "同步成功";
                    record1.UpdatorID = UpsatorID1;
                    record1.UpdateTime = DateTime.Now;
                    IoC.Resolve<XMOrderInfoOperatingRecordService>().InsertXMOrderInfoOperatingRecord(record1);// base.ProjectService.InsertXMOrderInfoOperatingRecord(record);

                    #endregion

                    //更新数据
                    GetValue(this.txtSearchOrderCode.Text.Trim());

                    base.ShowMessage("订单编码:" + xmorderinfo.OrderCode + " 数据同步成功！");
                }
                else
                {
                    //修改公公参数
                    base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");

                    #region 订单单个同步记录操作

                    int UpsatorID1 = 0;
                    if (HozestERPContext.Current.User != null)
                    {
                        UpsatorID1 = HozestERPContext.Current.User.CustomerID;

                    }
                    else
                    {
                        string UserName = "admin";
                        List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                        if (customer.Count > 0)
                        {
                            UpsatorID1 = customer[0].CustomerID;
                        }
                    }

                    XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                    record1.OrderInfoId = this.xmorderinfo.ID;
                    record1.PropertyName = "订单单个同步";
                    record1.OldValue = "同步失败";
                    record1.NewValue = "同步失败";
                    record1.UpdatorID = UpsatorID1;
                    record1.UpdateTime = DateTime.Now;
                    IoC.Resolve<XMOrderInfoOperatingRecordService>().InsertXMOrderInfoOperatingRecord(record1);// base.ProjectService.InsertXMOrderInfoOperatingRecord(record);

                    #endregion

                    base.ShowMessage("订单编码:" + xmorderinfo.OrderCode + " 数据同步失败！");
                }

                #endregion
            }
            else //订单号 在订单表不存在
            {
                int count = 0;
                #region 订单号 在订单表不存在

                var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();

                List<XMOrderInfoApp> xMorderInfoAppTMList = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 250).ToList();
                List<XMOrderInfoApp> xMorderInfoAppJDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 251 || q.PlatformTypeId == 823).ToList();
                List<XMOrderInfoApp> xMorderInfoAppJDSJNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 382).ToList();
                List<XMOrderInfoApp> xMorderInfoAppTMCDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 381).ToList();
                // List<XMOrderInfoApp> xMorderInfoAppJDCDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 309).ToList();
                List<XMOrderInfoApp> xMorderInfoVPHNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 259).ToList();
                List<XMOrderInfoApp> xMorderInfoYHDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 375).ToList();
                List<XMOrderInfoApp> xMorderInfoSuningNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 383).ToList();
                List<XMOrderInfoApp> xMorderInfoVPHMPNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 803).ToList();
                //天猫 
                if (xMorderInfoAppTMList.Count > 0)
                {
                    for (int t = 0; t < xMorderInfoAppTMList.Count; t++)
                    {
                        XMOrderInfoApp xMorderInfoAppTMNew = xMorderInfoAppTMList[t];

                        if (xMorderInfoAppTMNew != null)
                        {
                            Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(this.txtSearchOrderCode.Text.Trim()), xMorderInfoAppTMNew);

                            if (trade != null)
                            {
                                base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoAppTMNew);
                                count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount + VPHMPInsertCount + VPHMPUpdateCount;
                            }
                        }
                    }
                }
                //京东 (喜临门、嘟丽)  
                if (count == 0)
                {
                    if (xMorderInfoAppJDNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoAppJDNew.Count; j++)
                        {
                            HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                            HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(this.txtSearchOrderCode.Text.Trim(), xMorderInfoAppJDNew[j].AppKey, xMorderInfoAppJDNew[j].AppSecret, xMorderInfoAppJDNew[j].ServerUrl, xMorderInfoAppJDNew[j].AccessToken);
                            if (orderInfo != null)
                            {
                                base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDNew[j]);
                                count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount + VPHMPInsertCount + VPHMPUpdateCount;
                            }
                        }
                    }
                }
                //京东闪购 
                if (count == 0)
                {
                    if (xMorderInfoAppJDSJNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoAppJDSJNew.Count; j++)
                        {
                            HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                            HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(this.txtSearchOrderCode.Text.Trim(), xMorderInfoAppJDNew[j].AppKey, xMorderInfoAppJDNew[j].AppSecret, xMorderInfoAppJDNew[j].ServerUrl, xMorderInfoAppJDNew[j].AccessToken);

                            if (orderInfo != null)
                            {
                                base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDSJNew[j]);
                                count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount + VPHMPInsertCount + VPHMPUpdateCount;
                            }
                        }
                    }
                }
                //淘宝集市店 
                if (count == 0)
                {
                    if (xMorderInfoAppTMCDNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoAppTMCDNew.Count; j++)
                        {
                            Trade trade = base.XMOrderInfoAPIService.GetTrade(long.Parse(this.txtSearchOrderCode.Text.Trim()), xMorderInfoAppTMCDNew[j]);
                            if (trade != null)
                            {
                                base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMCDInsertCount, ref  TMCDUpdateCount, xMorderInfoAppTMCDNew[j]);
                                count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount + VPHMPInsertCount + VPHMPUpdateCount;
                            }
                        }
                    }
                }
                //C店 
                //if (count == 0)
                //{
                //    if (xMorderInfoAppJDCDNew.Count > 0)
                //    {
                //        for (int j = 0; j < xMorderInfoAppJDCDNew.Count; j++)
                //        {
                //            OrderInfo orderInfo = base.XMOrderInfoAPIService.getOrderInfo(this.txtSearchOrderCode.Text.Trim(), xMorderInfoAppJDCDNew[j]);
                //            if (orderInfo != null)
                //            {
                //                base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDCDNew[j]);
                //                count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount + VPHMPInsertCount + VPHMPUpdateCount;


                //            }
                //        }
                //    }
                //}
                //唯品会 
                if (count == 0)
                {
                    if (xMorderInfoVPHNew.Count > 0)
                    {
                        base.XMOrderInfoAPIService.getOrderVPH(Convert.ToDateTime(DateTime.Now).AddDays(-10).ToString("yyyy-MM-dd HH:mm:ss"), Convert.ToDateTime(DateTime.Now).AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss"), this.txtSearchOrderCode.Text.Trim(), ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoVPHNew[0]);
                        count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount + VPHMPInsertCount + VPHMPUpdateCount;
                    }
                }

                //唯品会MP
                if (count == 0) 
                {
                    if (xMorderInfoVPHMPNew.Count > 0)
                    {
                        for (int l = 0; l < xMorderInfoVPHMPNew.Count; l++)
                        {
                            base.XMOrderInfoAPIService.getOrderVPHMP(this.txtSearchOrderCode.Text.Trim(), ref VPHMPInsertCount, ref VPHMPUpdateCount, xMorderInfoVPHMPNew[l]);
                            count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount + VPHMPInsertCount + VPHMPUpdateCount;
                        }
                    }
                }

                //一号店 
                if (count == 0)
                {
                    if (xMorderInfoYHDNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoYHDNew.Count; j++)
                        {
                            base.XMOrderInfoAPIService.getOrderYHD(this.txtSearchOrderCode.Text.Trim(), ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoYHDNew[j]);
                            count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount + VPHMPInsertCount + VPHMPUpdateCount;
                        }
                    }
                }
                //苏宁易购 
                if (count == 0)
                {
                    if (xMorderInfoSuningNew.Count > 0)
                    {
                        for (int j = 0; j < xMorderInfoSuningNew.Count; j++)
                        {
                            base.XMOrderInfoAPIService.getOrderSuning(this.txtSearchOrderCode.Text.Trim(), ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoSuningNew[j]);
                            count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount + VPHMPInsertCount + VPHMPUpdateCount;
                        }
                    }
                }

                if (this.txtSearchOrderCode.Text.Trim() != "")
                {
                    if (count > 0)
                    {
                        //修改公公参数
                        base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");

                        //更新数据
                        GetValue(this.txtSearchOrderCode.Text.Trim());

                        base.ShowMessage("订单编码:" + xmorderinfo.OrderCode + " 数据同步成功！");
                    }
                }
                #endregion
            }
        }
        //订单类型
        public string XMOrderType
        {
            get
            {
                return Request.Params["XMOrderType"];
            }
        }

        //问题反馈、问题处理Id
        public int XMQuestionId
        {
            get
            {
                return Convert.ToInt32(Request.Params["XMQuestionId"]);
            }
        }
        //退换货订单号
        public string XMApplicationOrderCode
        {
            get
            {
                return Request.Params["XMApplicationOrderCode"];
            }
        }
        //发货单Id
        public int XMDeliveryId
        {
            get
            {
                return Convert.ToInt32(Request.Params["XMDeliveryId"]);
            }
        }
        //返现管理Id
        public int XMCashBackApplicationId
        {
            get
            {
                return Convert.ToInt32(Request.Params["XMCashBackApplicationId"]);
            }
        }
        //赠品申请id 
        public int XMPremiumsId
        {
            get
            {
                return Convert.ToInt32(Request.Params["XMPremiumsId"]);
            }
        }

        protected void btnUpdateAllorder_Click(object sender, EventArgs e)
        {
            //List<XMOrderInfo>  xmorderinfo = base.XMOrderInfoService.GetXMOrderInfoList();//订单号查询订单

            #region  批量修改唯品会订单
            string[] status = new string[2];
            status[0] = "-1";
            List<XMOrderInfo> xmorderinfo = base.XMOrderInfoAPIService.GetXMOrderInfoByCreateDate(1, -1, "-1", "", "",
                    "", status, 259, "", DateTime.Parse("2015-01-01 00:00:00"), DateTime.Parse("2015-12-31 23:59:59"), -1, false,
                    0, -1, "同步", true);

            #endregion
            if (xmorderinfo.Count > 0)
            {
                for (int i = 0; i < xmorderinfo.Count; i++)
                {
                    if (xmorderinfo[i].OrderCode != null && xmorderinfo[i].OrderCode != "" && xmorderinfo[i].PlatformTypeId != null && xmorderinfo[i].NickID != null)
                    {
                        int TMInsertCount = 0;
                        int TMUpdateCount = 0;

                        int JDInsertCount = 0;
                        int JDUpdateCount = 0;

                        int TMCDInsertCount = 0;
                        int TMCDUpdateCount = 0;

                        int VPHInsertCount = 0;
                        int VPHUpdateCount = 0;

                        int VPHMPInsertCount = 0;
                        int VPHMPUpdateCount = 0;

                        int YHDInsertCount = 0;
                        int YHDUpdateCount = 0;

                        int SuningInsertCount = 0;
                        int SuningUpdateCount = 0;
                        //订单号订单表 已经存在  
                        #region 各平台单个订单同步

                        var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();

                        switch (xmorderinfo[i].PlatformTypeId)
                        {
                            //天猫
                            case 250:
                                XMOrderInfoApp xMorderInfoAppTMNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 250 && q.NickId == xmorderinfo[i].NickID).FirstOrDefault();
                                if (xMorderInfoAppTMNew != null)
                                {

                                    Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(xmorderinfo[i].OrderCode), xMorderInfoAppTMNew);

                                    if (trade != null)
                                    {
                                        base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoAppTMNew);
                                    }
                                }
                                break;
                            //京东 (喜临门、嘟丽)
                            case 251:

                                List<XMOrderInfoApp> xMorderInfoAppJDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 251 && q.NickId == xmorderinfo[i].NickID).ToList();
                                if (xMorderInfoAppJDNew.Count > 0)
                                {
                                    for (int j = 0; j < xMorderInfoAppJDNew.Count; j++)
                                    {
                                        HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                        HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xmorderinfo[i].OrderCode, xMorderInfoAppJDNew[j].AppKey, xMorderInfoAppJDNew[j].AppSecret, xMorderInfoAppJDNew[j].ServerUrl, xMorderInfoAppJDNew[j].AccessToken);
                                        if (orderInfo != null)
                                        {
                                            base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDNew[j]);

                                        }
                                    }
                                }
                                break;

                            //京东闪购
                            case 382:
                                List<XMOrderInfoApp> xMorderInfoAppJDSJNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 382 && q.NickId == xmorderinfo[i].NickID).ToList();
                                if (xMorderInfoAppJDSJNew.Count > 0)
                                {
                                    for (int j = 0; j < xMorderInfoAppJDSJNew.Count; j++)
                                    {
                                        HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                        HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(xmorderinfo[i].OrderCode, xMorderInfoAppJDSJNew[j].AppKey, xMorderInfoAppJDSJNew[j].AppSecret, xMorderInfoAppJDSJNew[j].ServerUrl, xMorderInfoAppJDSJNew[j].AccessToken);
                                        if (orderInfo != null)
                                        {
                                            base.XMOrderInfoAPIService.getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoAppJDSJNew[j]);

                                        }
                                    }
                                }
                                break;
                            //淘宝集市店
                            case 381:
                                List<XMOrderInfoApp> xMorderInfoAppTMCDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 381 && q.NickId == xmorderinfo[i].NickID).ToList();
                                if (xMorderInfoAppTMCDNew.Count > 0)
                                {
                                    for (int j = 0; j < xMorderInfoAppTMCDNew.Count; j++)
                                    {
                                        Trade trade = base.XMOrderInfoAPIService.GetTrade(long.Parse(xmorderinfo[i].OrderCode), xMorderInfoAppTMCDNew[j]);
                                        if (trade != null)
                                        {
                                            base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMCDInsertCount, ref  TMCDUpdateCount, xMorderInfoAppTMCDNew[j]);
                                        }
                                    }
                                }
                                break;
                            //唯品会
                            case 259:
                                List<XMOrderInfoApp> xMorderInfoVPHNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 259 && q.NickId == xmorderinfo[i].NickID).ToList();
                                if (xMorderInfoVPHNew.Count > 0)
                                {
                                    //base.XMOrderInfoAPIService.getOrderVPH("", "", xmorderinfo[i].OrderCode, ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoVPHNew[0]);
                                    base.XMVipapis.GetVipOrderByModifyDate();
                                }
                                break;
                            //一号店
                            case 375:
                                List<XMOrderInfoApp> xMorderInfoYHDNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 375 && q.NickId == xmorderinfo[i].NickID).ToList();
                                if (xMorderInfoYHDNew.Count > 0)
                                {
                                    for (int j = 0; j < xMorderInfoYHDNew.Count; j++)
                                    {
                                        base.XMOrderInfoAPIService.getOrderYHD(xmorderinfo[i].OrderCode, ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoYHDNew[j]);
                                    }
                                }
                                break;
                            //苏宁易购
                            case 383:
                                List<XMOrderInfoApp> xMorderInfoSuningNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 383 && q.NickId == xmorderinfo[i].NickID).ToList();
                                if (xMorderInfoSuningNew.Count > 0)
                                {
                                    for (int j = 0; j < xMorderInfoSuningNew.Count; j++)
                                    {
                                        base.XMOrderInfoAPIService.getOrderSuning(xmorderinfo[i].OrderCode, ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoSuningNew[j]);
                                    }
                                }
                                break;
                        }

                        int count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount + VPHMPInsertCount + VPHMPUpdateCount;

                        if (count > 0)
                        {
                            //修改公公参数
                            base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");
                            #region 订单单个同步记录操作

                            int UpsatorID1 = 0;
                            if (HozestERPContext.Current.User != null)
                            {
                                UpsatorID1 = HozestERPContext.Current.User.CustomerID;

                            }
                            else
                            {
                                string UserName = "admin";
                                List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                                if (customer.Count > 0)
                                {
                                    UpsatorID1 = customer[0].CustomerID;
                                }
                            }

                            XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                            record1.OrderInfoId = this.xmorderinfo.ID;
                            record1.PropertyName = "订单单个同步";
                            record1.OldValue = "同步成功";
                            record1.NewValue = "同步成功";
                            record1.UpdatorID = UpsatorID1;
                            record1.UpdateTime = DateTime.Now;
                            IoC.Resolve<XMOrderInfoOperatingRecordService>().InsertXMOrderInfoOperatingRecord(record1);// base.ProjectService.InsertXMOrderInfoOperatingRecord(record);

                            #endregion

                            //更新数据
                            GetValue(this.txtSearchOrderCode.Text.Trim());


                        }
                        else
                        {
                            //修改公公参数
                            base.SettingManager.SetParam("XMOrderInfoList.IndexSession", "true");

                            #region 订单单个同步记录操作

                            int UpsatorID1 = 0;
                            if (HozestERPContext.Current.User != null)
                            {
                                UpsatorID1 = HozestERPContext.Current.User.CustomerID;

                            }
                            else
                            {
                                string UserName = "admin";
                                List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                                if (customer.Count > 0)
                                {
                                    UpsatorID1 = customer[0].CustomerID;
                                }
                            }

                            XMOrderInfoOperatingRecord record1 = new XMOrderInfoOperatingRecord();
                            record1.OrderInfoId = this.xmorderinfo.ID;
                            record1.PropertyName = "订单单个同步";
                            record1.OldValue = "同步失败";
                            record1.NewValue = "同步失败";
                            record1.UpdatorID = UpsatorID1;
                            record1.UpdateTime = DateTime.Now;
                            IoC.Resolve<XMOrderInfoOperatingRecordService>().InsertXMOrderInfoOperatingRecord(record1);// base.ProjectService.InsertXMOrderInfoOperatingRecord(record);

                            #endregion
                        }

                        #endregion

                    }
                }
            }
        }
    }
}