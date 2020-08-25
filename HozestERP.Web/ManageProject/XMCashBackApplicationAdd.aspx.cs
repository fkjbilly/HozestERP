using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Infrastructure;
using Top.Api.Domain;

namespace HozestERP.Web.ManageProject
{

    public partial class XMCashBackApplicationAdd : BaseAdministrationPage, IEditPage
    {


        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnSave", "XMCashBackApplicationdetailsAdd.Save"); //保存

                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目名称绑定
                this.ddlProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                this.ddlProject.DataSource = projectList;
                this.ddlProject.DataTextField = "ProjectName";
                this.ddlProject.DataValueField = "Id";
                this.ddlProject.DataBind();
                this.ddlProject.Items.Insert(0, new ListItem("---所有---", "-1"));

                txtHidden.Style.Add("display", "none");

                LoadDate(sender,e);
            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        private void LoadDate(object sender, EventArgs e)
        {
            if (type == 2 && scid > 0)
            {
                var XMCashBack = XMCashBackApplicationService.GetXMCashBackApplicationById(scid);
                if (XMCashBack != null)
                {
                    this.txtScalpingCode.Value = XMCashBack.OrderCode;//订单号
                    this.wangwang.Value = XMCashBack.WantNo;//旺旺号
                    this.wangwangdd.Value = XMCashBack.WantNo;//旺旺号
                    this.name.Value = XMCashBack.BuyerName; ;//姓名
                    this.ddApplicationTypeId.SelectedValue = XMCashBack.ApplicationTypeId.Value.ToString();//申请类型
                    this.txtApplicationPayee.Value = XMCashBack.BuyerAlipayNo; ;//收款账号
                    this.txtTheAdvanceMoney.Text = XMCashBack.CashBackMoney.ToString(); ;//金额
                    if (XMCashBack.ManagerStatus == Convert.ToInt32(StatusEnum.AlreadyCheck))
                    {
                        this.lblManagerStatus.Checked = true;
                        this.btnSave.Visible = false;
                    }
                    if (XMCashBack.CashBackStatus == Convert.ToInt32(StatusEnum.ChildCashBack))
                    {
                        this.lblCashBackStatus.Checked = true;
                    }

                    if (XMCashBack.ApplicationTypeId == Convert.ToInt32(StatusEnum.ChildPayment) && XMCashBack.ManagerStatus == Convert.ToInt32(StatusEnum.NotCheck))//赔付,未审核
                    {
                        this.ddlPaymentPerson.Enabled = true;
                    }
                    else
                    {
                        this.ddlPaymentPerson.Enabled = false;
                    }

                    if (XMCashBack.PaymentPerson != null)
                    {
                        this.ddlPaymentPerson.SelectedValue = XMCashBack.PaymentPerson.ToString();
                    }

                    if (XMCashBack.ProjectID != null)
                    {
                        ddlProject.SelectedValue = XMCashBack.ProjectID.ToString();
                        ddlProject_SelectedIndexChanged(sender, e);
                        ddlNick.Value = XMCashBack.NickID == null ? "-1" : XMCashBack.NickID.ToString();
                    }
                }
            }
            else 
            {
                this.ddlPaymentPerson.Enabled = false;
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.ddlPaymentPerson.Items.Clear();
            var PaymentPersonList = base.CodeService.GetCodeListInfoByCodeTypeID(222);
            this.ddlPaymentPerson.DataSource = PaymentPersonList;
            this.ddlPaymentPerson.DataTextField = "CodeName";
            this.ddlPaymentPerson.DataValueField = "CodeID";
            this.ddlPaymentPerson.DataBind();
            this.ddlPaymentPerson.Items.Insert(0, new ListItem("", "-1"));
        }

        public void SetTrigger()
        {
            // this.Master.SetTrigger(this.btnSave.UniqueID, this.Page); 
        }
        #endregion

        protected void ddApplicationTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddApplicationTypeId.SelectedValue == "10")
            {
                ddlPaymentPerson.Enabled = true;
            }
            else
            {
                ddlPaymentPerson.Enabled = false;
            }
        }

        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var arg = Request.Form["__EVENTARGUMENT"];

            var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddlProject.SelectedValue));
            this.ddlNick.Items.Clear();
            this.ddlNick.DataSource = nickList;
            this.ddlNick.DataTextField = "nick";
            this.ddlNick.DataValueField = "nick_id";
            this.ddlNick.DataBind();
            this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));

            if (!string.IsNullOrEmpty(txtHidden.Text))
            {
                ddlNick.Value = txtHidden.Text;
            }
        }

        /// <summary>
        /// 保存返现申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string hfScalpingId = this.txtScalpingCode.Value.Trim();//订单号
            string wangwang = this.wangwangdd.Value.Trim();//旺旺号
            string name = this.name.Value.Trim();//姓名
            string ddApplicationTypeId = this.ddApplicationTypeId.SelectedValue;//申请类型
            int nickID =int.Parse(ddlNick.Value) ; //店铺
            int projectID = int.Parse(ddlProject.SelectedValue); //项目
            string txtApplicationPayee = this.txtApplicationPayee.Value;//收款账号
            decimal txtTheAdvanceMoney = decimal.Parse(this.txtTheAdvanceMoney.Text.Trim());//金额
            string PaymentPerson = this.ddlPaymentPerson.SelectedValue;//赔付方
            var xmorderinfo = base.XMOrderInfoService.GetXMOrderByOrderCode(hfScalpingId);//订单号查询订单
            if(xmorderinfo!=null)
            {
                if ((xmorderinfo.PlatformTypeId == 250 || xmorderinfo.PlatformTypeId == 381) && (name == "" || txtApplicationPayee == ""))
                {
                    if (name == "")
                    {

                        if (xmorderinfo != null)
                        {
                            name = xmorderinfo.FullName;
                        }

                    }
                    if (txtApplicationPayee == "")
                    {
                        var XMOrderInfoAppList = IoC.Resolve<IXMOrderInfoAppService>().GetXMOrderInfoAppList();

                        XMOrderInfoApp xMorderInfoAppTMNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == 250).FirstOrDefault();
                        if (xMorderInfoAppTMNew != null)
                        {
                            Trade trade = IoC.Resolve<IXMOrderInfoAPIService>().GetTrade(Convert.ToInt64(hfScalpingId), xMorderInfoAppTMNew);

                            if (trade != null)
                            {
                                txtApplicationPayee = trade.BuyerAlipayNo;
                            }
                        }
                    }
                }
            }
            //财务未审核
            bool FinanceIsAudit = false;
            //项目未审核
            int ManagerStatus = 3;
            if(!string.IsNullOrEmpty(hfScalpingId))
            {
                if (xmorderinfo != null)
                {
                    var XMDeductionSetUp = XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(xmorderinfo.ProjectId, 476, (int)xmorderinfo.PlatformTypeId);
                    if(XMDeductionSetUp!=null)
                    {
                        //根据项目限额，平台限额，自动设置审核进度
                        if (txtTheAdvanceMoney <= XMDeductionSetUp.Deduction)
                        {
                            FinanceIsAudit = true;
                            //项目审核
                            ManagerStatus = 4;
                        }
                        else if (txtTheAdvanceMoney > XMDeductionSetUp.Deduction && txtTheAdvanceMoney <= XMDeductionSetUp.Finance)
                        {
                            FinanceIsAudit = true;
                        }
                    }
                    else
                    {
                        //通用
                        var XMDeductionSetUpUsually = XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(projectID, 476, 508);
                        if (XMDeductionSetUpUsually != null)
                        {
                            //根据项目限额，平台限额，自动设置审核进度
                            if (txtTheAdvanceMoney <= XMDeductionSetUpUsually.Deduction)
                            {
                                FinanceIsAudit = true;
                                //项目审核
                                ManagerStatus = 4;
                            }
                            else if (txtTheAdvanceMoney > XMDeductionSetUpUsually.Deduction && txtTheAdvanceMoney <= XMDeductionSetUpUsually.Finance)
                            {
                                FinanceIsAudit = true;
                            }
                        }
                    }

                }
            }

            if (name != "" && txtApplicationPayee != "")
            {
                //var a = XMOrderInfoService.GetXMOrderInfoByOrderCodeList(hfScalpingId);

                if (type == 1)
                {
                    var XMCashBackApplication = XMCashBackApplicationService.GetXMCashBackApplicationByOrderCode(hfScalpingId,int.Parse(ddApplicationTypeId));
                    XMCashBackApplication XMCashBack = new XMCashBackApplication();
                    XMCashBack.OrderCode = string.IsNullOrEmpty(hfScalpingId) ? "NoOrder" + DateTime.Now.ToString("yyMMddHHmmssfff") : hfScalpingId;//订单号
                    XMCashBack.WantNo = wangwang;//旺旺号
                    XMCashBack.BuyerName = name;//姓名
                    XMCashBack.ApplicationTypeId = int.Parse(ddApplicationTypeId);//申请类型
                    XMCashBack.NickID = nickID;
                    XMCashBack.ProjectID = projectID;
                    XMCashBack.BuyerAlipayNo = txtApplicationPayee;//收款账号
                    XMCashBack.CashBackMoney = txtTheAdvanceMoney;//金额
                    XMCashBack.CreatorID = HozestERPContext.Current.User.CustomerID;
                    XMCashBack.CreateTime = DateTime.Now;
                    XMCashBack.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    XMCashBack.UpdateTime = DateTime.Now;
                    //判断是否是第二次返现
                    if(XMCashBackApplication.Count==0)
                    {
                        XMCashBack.ManagerStatus = ManagerStatus;
                        XMCashBack.FinanceIsAudit = FinanceIsAudit;
                    }
                    //第二次返现都视为未审核
                    else if(XMCashBackApplication.Count>0)
                    {
                        XMCashBack.ManagerStatus = 3;
                        XMCashBack.FinanceIsAudit = false;
                    }
                    XMCashBack.CashBackStatus = Convert.ToInt32(StatusEnum.NotCashBack);
                    XMCashBack.IsEnable = false;

                    base.XMCashBackApplicationService.InsertXMCashBackApplication(XMCashBack);
                    base.ShowMessage("保存成功");
                    this.wangwang.Value = wangwang;

                }
                else if (type == 2)
                {
                    var XMCashBack = XMCashBackApplicationService.GetXMCashBackApplicationById(scid);
                    XMCashBack.OrderCode = hfScalpingId;//订单号
                    XMCashBack.WantNo = wangwang;//旺旺号
                    XMCashBack.BuyerName = name;//姓名
                    XMCashBack.ApplicationTypeId = int.Parse(ddApplicationTypeId);//申请类型
                    XMCashBack.NickID = nickID;
                    XMCashBack.ProjectID = projectID;
                    XMCashBack.BuyerAlipayNo = txtApplicationPayee;//收款账号
                    XMCashBack.CashBackMoney = txtTheAdvanceMoney;//金额
                    if (XMCashBack.ApplicationTypeId == Convert.ToInt32(StatusEnum.ChildPayment))//赔付
                    {
                        XMCashBack.PaymentPerson = int.Parse(PaymentPerson);//赔付方
                    }

                    XMCashBack.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    XMCashBack.UpdateTime = DateTime.Now;
                    XMCashBack.ManagerStatus = ManagerStatus;
                    XMCashBack.FinanceIsAudit = FinanceIsAudit;
                    //XMCashBack.CashBackStatus = Convert.ToInt32(StatusEnum.NotCashBack);
                    base.XMCashBackApplicationService.UpdateXMCashBackApplication(XMCashBack);
                    base.ShowMessage("修改成功");
                    this.wangwang.Value = wangwang;
                }
            }
            else 
            {
                base.ShowMessage("请填写姓名和收款帐号");
            }
        }

        // private int SetScalpingId;

        protected void ddTheAdvanceType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 刷单暂支
        /// </summary>
        public void TheAdvanceTypeSDZZ()
        {
        }

        /// <summary>
        /// 返现id
        /// </summary>
        public int scid
        {
            get
            {
                return CommonHelper.QueryStringInt("scid");
            }
        }

        /// <summary>
        /// 判断返现是添加还是修改
        /// </summary>
        public int type
        {
            get
            {
                return CommonHelper.QueryStringInt("type");
            }
        }
    }

}