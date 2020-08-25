using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using System.Transactions;
using HozestERP.BusinessLogic.Infrastructure;
using JdSdk.Domain;
using Top.Api.Domain;

namespace HozestERP.Web.ManageProject
{

    public partial class XMScalpingAdd : BaseAdministrationPage, IEditPage
    {


        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnSave", "ManageProject.XMScalpingAdd.Save"); //保存

                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDate();

            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        private void LoadDate()
        {

            if (this.ScalpingId == -1)
            {

                this.txtScalpingCode.Value = string.Empty;
                this.hfScalpingId.Value = "";
                this.hfPlatformTypeId.Value = "";
                this.txtPlatformType.Text = "";
                this.hfNickId.Value = "";
                this.txtNickName.Text = "";
                this.txtOrderCode.Text = string.Empty;
                this.txtWantID.Text = string.Empty;
                this.txtProductName.Text = string.Empty;

            }
            else
            {
                var xMScalping = base.XMScalpingService.GetXMScalpingByID(this.ScalpingId);
                if (xMScalping != null)
                {
                    this.txtScalpingCode.Value = xMScalping.ScalpingNo != null ? xMScalping.ScalpingNo.ScalpingCode : "";
                    this.hfScalpingId.Value = xMScalping.ScalpingNo != null ? xMScalping.ScalpingNo.ScalpingId.ToString() : "";
                    this.hfPlatformTypeId.Value = xMScalping.PlatformTypeName != null ? xMScalping.PlatformTypeName.CodeID.ToString() : "";
                    this.txtPlatformType.Text = xMScalping.PlatformTypeName != null ? xMScalping.PlatformTypeName.CodeName : "";
                    this.hfNickId.Value = xMScalping.NickName != null ? xMScalping.NickName.nick_id.ToString() : "";
                    this.txtNickName.Text = xMScalping.NickName != null ? xMScalping.NickName.nick : "";
                    this.txtOrderCode.Text = xMScalping.OrderCode != null ? xMScalping.OrderCode : "";
                    this.hidOrderCode.Value = xMScalping.OrderCode != null ? xMScalping.OrderCode : "";
                    this.txtWantID.Text = xMScalping.WantID != null ? xMScalping.WantID : "";
                    this.txtProductName.Text = xMScalping.ProductName != null ? xMScalping.ProductName : "无产品";
                    this.txtSalePrice.Text = xMScalping.SalePrice != null ? xMScalping.SalePrice.Value.ToString() : "0";
                    this.txtFee.Text = xMScalping.Fee != null ? xMScalping.Fee.Value.ToString() : "0";

                    if (xMScalping.IsAbnormal != null)
                    {
                        if (xMScalping.IsAbnormal.Value == true)
                        {
                            this.txtScalpingCode.Disabled = false;
                            this.txtPlatformType.Enabled = false;
                            this.txtNickName.Enabled = false;
                            this.txtOrderCode.Visible = true;
                            this.txtWantID.Enabled = false;
                            this.txtProductName.Enabled = false;
                            this.txtSalePrice.Enabled = false;
                            this.txtFee.Enabled = false;

                        }
                        else
                        {
                            this.txtScalpingCode.Disabled = false;
                            this.txtPlatformType.Enabled = true;
                            this.txtNickName.Enabled = true;
                            this.txtOrderCode.Visible = true;
                            this.txtWantID.Enabled = true;
                            this.txtProductName.Enabled = true;
                            this.txtSalePrice.Enabled = true;
                            this.txtFee.Enabled = true;
                        }
                    }

                    // this.txtDeduction.Text = xMScalping.Deduction != null ? xMScalping.Deduction.Value.ToString() : "";
                    //this.ddType.SelectedValue = xMScalping.Type != null ? xMScalping.Type.Value : -1;
                    //this.txtLeader.SelectSingleCustomer = base.CustomerInfoService.GetCustomerInfoByID(xMScalping.Leader.Value);
                    //if (this.txtLeader.SelectSingleCustomer != null)
                    //    this.txtLeader.Value = this.txtLeader.SelectSingleCustomer.FullName;

                }
            }



        }
        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("项目部 > 刷单信息 ");

        }

        public void SetTrigger()
        {
            // this.Master.SetTrigger(this.btnSave.UniqueID, this.Page); 

        }
        #endregion


        /// <summary>
        /// 保存暂支申请信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        var hfScalpingId = this.hfScalpingId.Value;
                        var hfPlatformTypeId = this.hfPlatformTypeId.Value;
                        var hfNickId = this.hfNickId.Value;
                        var txtOrderCode = this.txtOrderCode.Text.Trim();
                        var hidOrderCode = this.hidOrderCode.Value;
                        var txtWantID = this.txtWantID.Text.Trim();
                        var txtProductName = this.txtProductName.Text.Trim();
                        var txtSalePrice = this.txtSalePrice.Text.Trim();
                        var txtFee = this.txtFee.Text.Trim();
                        //var txtDeduction = this.txtDeduction.Text.Trim() ;
                        //var ddType= this.ddType.SelectedValue;
                        //var txtLeader = this.txtLeader.SelectSingleCustomer.CustomerID;
                        decimal Deduction = 0;

                        if (Convert.ToInt32(hfNickId) > 0 && Convert.ToInt32(hfPlatformTypeId) > 0)
                        {
                            int ProjectId = 0;
                            //根据店铺Id查询  取项目Id
                            var XMNick = base.XMNickService.GetXMNickByID(Convert.ToInt32(hfNickId));
                            if (XMNick != null)
                            {
                                if (XMNick.ProjectId != null)
                                {
                                    ProjectId = XMNick.ProjectId.Value;
                                }
                            }
                            //根据项目Id 平台类型查询 扣点 
                            var xMDeductionSetUp = base.XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(ProjectId, 475, Convert.ToInt32(hfPlatformTypeId));

                            if (xMDeductionSetUp != null)
                            {
                                //计算扣点
                                if (xMDeductionSetUp.Deduction != null)
                                {
                                    decimal DeductionD = xMDeductionSetUp.Deduction.Value / 100;

                                    Deduction = Convert.ToDecimal(txtSalePrice) * DeductionD;//扣点
                                }
                            }
                            else
                            {

                                base.ShowMessage("请设置平台扣点!");
                                return;
                            }
                        }
                        //根据订单号查询 刷单记录信息
                        var XMScalpingByOrderCode = base.XMScalpingService.GetXMScalpingByOrderCode(txtOrderCode);

                        // 根据订单号查询 订单信息
                        var xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(txtOrderCode);

                        XMOrderInfo xMOrderInfoNow = new XMOrderInfo();
                        var XMOrderInfoAppList = IoC.Resolve<IXMOrderInfoAppService>().GetXMOrderInfoAppList();
                        List<XMOrderInfoApp> xMorderInfoApp = new List<XMOrderInfoApp>();

                        int count = 0;//返回记录条数
                        if (xMOrderInfo == null)
                        {
                            #region 各平台订单号同步

                            int TMInsertCount = 0;
                            int TMUpdateCount = 0;

                            int JDInsertCount = 0;
                            int JDUpdateCount = 0;

                            int TMCDInsertCount = 0;
                            int TMCDUpdateCount = 0;

                            int VPHInsertCount = 0;
                            int VPHUpdateCount = 0;

                            int YHDInsertCount = 0;
                            int YHDUpdateCount = 0;

                            int SuningInsertCount = 0;
                            int SuningUpdateCount = 0;
                            for (int i = 0; i < xMorderInfoApp.Count; i++)
                            {
                                if (xMorderInfoApp[i].PlatformTypeId == 251 || xMorderInfoApp[i].PlatformTypeId == 382)// || xMorderInfoApp[i].PlatformTypeId == 310)
                                {

                                    HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient webserver = new HozestERP.BusinessLogic.JDsingleServiceReference.JDsingleOrderGetSoapClient();
                                    HozestERP.BusinessLogic.JDsingleServiceReference.OrderInfo orderInfo = webserver.WebGetJDOrderInfo(txtOrderCode, xMorderInfoApp[i].AppKey, xMorderInfoApp[i].AppSecret, xMorderInfoApp[i].ServerUrl, xMorderInfoApp[i].AccessToken);
                                    if (orderInfo != null)
                                    {
                                        IoC.Resolve<IXMOrderInfoAPIService>().getOrderInfoJD(orderInfo, ref JDInsertCount, ref JDUpdateCount, xMorderInfoApp[i]);
                                    }
                                }
                                else if (xMorderInfoApp[i].PlatformTypeId == 250 || xMorderInfoApp[i].PlatformTypeId == 381)
                                {
                                    Trade trade = IoC.Resolve<IXMOrderInfoAPIService>().GetTrade(Convert.ToInt64(txtOrderCode), xMorderInfoApp[i]);

                                    if (trade != null)
                                    {
                                        if (xMorderInfoApp[i].PlatformTypeId == 250)
                                        {
                                            IoC.Resolve<IXMOrderInfoAPIService>().getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoApp[i]);
                                        }
                                        else if (xMorderInfoApp[i].PlatformTypeId == 381)
                                        {
                                            IoC.Resolve<IXMOrderInfoAPIService>().getTradeTM(trade, ref  TMCDInsertCount, ref  TMCDUpdateCount, xMorderInfoApp[i]);
                                        }


                                    }
                                }
                                //一号店
                                else if (xMorderInfoApp[i].PlatformTypeId == 375)
                                {
                                    IoC.Resolve<IXMOrderInfoAPIService>().getOrderYHD(txtOrderCode, ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoApp[i]);
                                }
                                //苏宁易购
                                else if (xMorderInfoApp[i].PlatformTypeId == 383)
                                {
                                    IoC.Resolve<IXMOrderInfoAPIService>().getOrderSuning(txtOrderCode, ref SuningInsertCount, ref SuningUpdateCount, xMorderInfoApp[i]);
                                }

                            }

                            if (xMorderInfoApp.Count > 0 && xMorderInfoApp[0].PlatformTypeId == 259)
                            {

                                string payDateStart = Convert.ToDateTime(DateTime.Now).AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss");
                                string payDateEnd = Convert.ToDateTime(DateTime.Now).AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");
                                IoC.Resolve<IXMOrderInfoAPIService>().getOrderVPH(payDateStart, payDateEnd, txtOrderCode, ref VPHInsertCount, ref VPHUpdateCount, xMorderInfoApp[0]);
                            }
                            #endregion
                            //同步个平台 返回的记录条数 
                            count = JDInsertCount + JDUpdateCount + TMInsertCount + TMUpdateCount + VPHInsertCount + VPHUpdateCount + YHDInsertCount + YHDUpdateCount + TMCDInsertCount + TMCDUpdateCount + SuningInsertCount + SuningUpdateCount;
                        }

                        if (count > 0)
                        {
                            // 修改订单表是否刷单状态 （订单存在IsScalping=true） 并判断订单是否存在
                            xMOrderInfoNow = IoC.Resolve<IXMOrderInfoService>().GetXMOrderByOrderCode(txtOrderCode);
                        }
                        else
                        {
                            xMOrderInfoNow = xMOrderInfo;
                        }

                        if (xMOrderInfoNow == null)
                        {
                            base.ShowMessage(txtOrderCode + "订单号有误,请确认!");
                            return;
                        }

                        var xMScalping = base.XMScalpingService.GetXMScalpingByID(this.ScalpingId);
                        if (xMScalping == null)
                        {

                            if (XMScalpingByOrderCode.Count > 0)
                            {
                                base.ShowMessage(txtOrderCode + "订单号已存在!");
                                return;
                            }

                            XMScalping xMScalpingNew = new XMScalping();
                            int scalpingId = 0;
                            int.TryParse(this.hfScalpingId.Value, out scalpingId);
                            var scalping = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(scalpingId);
                            if (scalping == null)
                            {
                                this.hfScalpingId.Value = "";
                                this.txtScalpingCode.Value = "";
                                this.hfNickId.Value = "";
                                this.txtNickName.Text = "";
                                this.hfPlatformTypeId.Value = "";
                                this.txtPlatformType.Text = "";
                                this.Master.ShowMessage("刷单单号有误.");
                                ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "ScalpingAdd", "autoCompleteBindScalpingAdd()", true);
                                return;
                            }
                            xMScalpingNew.ScalpingApplication = Convert.ToInt32(hfScalpingId);
                            xMScalpingNew.PlatformTypeId = Convert.ToInt32(hfPlatformTypeId);
                            xMScalpingNew.NickId = Convert.ToInt32(hfNickId);
                            //xMScalpingNew.Type = ddType;
                            xMScalpingNew.OrderCode = txtOrderCode;
                            xMScalpingNew.OrderInfoCreateDate = xMOrderInfoNow.OrderInfoCreateDate;
                            xMScalpingNew.WantID = txtWantID;
                            xMScalpingNew.ProductName = txtProductName;
                            xMScalpingNew.SalePrice = Convert.ToDecimal(txtSalePrice);
                            xMScalpingNew.Fee = Convert.ToDecimal(txtFee);
                            xMScalpingNew.Deduction = Deduction;
                            //xMScalpingNew.Leader = Convert.ToInt32(txtLeader);
                            xMScalpingNew.IsAbnormal = false;
                            xMScalpingNew.IsEnable = false;
                            xMScalpingNew.CreateID = HozestERPContext.Current.User.CustomerID;
                            xMScalpingNew.CreateDate = DateTime.Now;
                            xMScalpingNew.UpdateID = HozestERPContext.Current.User.CustomerID;
                            xMScalpingNew.UpdateDate = DateTime.Now;

                            #region 修改订单表是否刷单状态 （订单存在IsScalping=true）
                            // var xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(txtOrderCode);
                            if (xMOrderInfoNow != null)
                            {
                                xMOrderInfoNow.IsScalping = true;
                                xMOrderInfoNow.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xMOrderInfoNow.UpdateDate = DateTime.Now;
                                base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfoNow);
                            }
                            #endregion

                            base.XMScalpingService.InsertXMScalping(xMScalpingNew);
                            //base.ShowMessage("保存成功");

                            this.Master.JsWrite("alert('保存成功.');window.PopClose();", "");
                            scope.Complete();

                        }
                        else
                        {

                            if (XMScalpingByOrderCode.Count > 0)
                            {
                                if (!txtOrderCode.Equals(hidOrderCode))
                                {
                                    base.ShowMessage(txtOrderCode + "订单号已存在!");
                                    return;
                                }
                            }



                            int scalpingId = 0;
                            int.TryParse(this.hfScalpingId.Value, out scalpingId);
                            var scalping = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(scalpingId);
                            if (scalping == null)
                            {
                                this.hfScalpingId.Value = "";
                                this.txtScalpingCode.Value = "";
                                this.hfNickId.Value = "";
                                this.txtNickName.Text = "";
                                this.hfPlatformTypeId.Value = "";
                                this.txtPlatformType.Text = "";
                                this.Master.ShowMessage("刷单单号有误.");
                                ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "ScalpingAdd", "autoCompleteBindScalpingAdd()", true);
                                return;
                            }
                            xMScalping.ScalpingApplication = Convert.ToInt32(hfScalpingId);
                            xMScalping.PlatformTypeId = Convert.ToInt32(hfPlatformTypeId);
                            xMScalping.NickId = Convert.ToInt32(hfNickId);
                            //xMScalping.Type = ddType;
                            xMScalping.OrderCode = txtOrderCode;
                            xMScalping.WantID = txtWantID;
                            xMScalping.ProductName = txtProductName;
                            xMScalping.SalePrice = Convert.ToDecimal(txtSalePrice);
                            xMScalping.Fee = Convert.ToDecimal(txtFee);
                            xMScalping.Deduction = Deduction;
                            //xMScalping.Leader = Convert.ToInt32(txtLeader);
                            xMScalping.IsAbnormal = false;
                            xMScalping.UpdateID = HozestERPContext.Current.User.CustomerID;
                            xMScalping.UpdateDate = DateTime.Now;

                            #region 修改订单表是否刷单状态 （订单存在IsScalping=true）
                            //var xMOrderInfo = base.XMOrderInfoService.GetXMOrderByOrderCode(txtOrderCode);
                            if (xMOrderInfoNow != null)
                            {
                                xMOrderInfoNow.IsScalping = true;
                                xMOrderInfoNow.UpdateID = HozestERPContext.Current.User.CustomerID;
                                xMOrderInfoNow.UpdateDate = DateTime.Now;
                                base.XMOrderInfoService.UpdateXMOrderInfo(xMOrderInfoNow);
                            }
                            #endregion


                            base.XMScalpingService.UpdateXMScalping(xMScalping);
                            //base.ShowMessage("保存成功");

                            this.Master.JsWrite("alert('保存成功.');window.PopClose();", "");
                            scope.Complete();
                        }
                    }
                    catch (Exception err)
                    {
                        this.ProcessException(err);
                    }
                }
            }
        }


        //protected void pro_Change(object sender, EventArgs e)
        //{
        //  int NickId= Convert.ToInt16(this.hfNickId.Value);
        //  int PlatformTypeId=Convert.ToInt32(this.hfPlatformTypeId.Value);

        //  var txtSalePrice = this.txtSalePrice.Text.Trim();

        //  if (NickId > 0 && PlatformTypeId > 0)
        //  {
        //      int ProjectId = 0;
        //      //根据店铺Id查询  取项目Id
        //      var XMNick = base.XMNickService.GetXMNickByID(NickId);
        //      if (XMNick != null)
        //      {
        //          if (XMNick.ProjectId != null)
        //          {
        //              ProjectId = XMNick.ProjectId.Value;
        //          }
        //      }
        //      //根据项目Id 平台类型查询 扣点 
        //      var xMDeductionSetUp = base.XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(ProjectId, PlatformTypeId);

        //      decimal Deduction = 0;
        //      //计算扣点
        //      if (xMDeductionSetUp.Deduction != null)
        //      {
        //          decimal DeductionD = xMDeductionSetUp.Deduction.Value / 100;

        //        Deduction = Convert.ToDecimal(txtSalePrice) * DeductionD;//扣点
        //      }


        //  }

        //}

        /// <summary>
        /// 刷单表id 
        /// </summary>
        public int ScalpingId
        {
            get
            {
                return CommonHelper.QueryStringInt("ScalpingId");
            }
        }
    }
}