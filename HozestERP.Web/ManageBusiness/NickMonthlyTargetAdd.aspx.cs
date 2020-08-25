using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.Web.ManageBusiness
{
    public partial class NickMonthlyTargetAdd : BaseAdministrationPage, IEditPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                dpLogDate.Value = DateTime.Now.ToString("yyyy-MM");
                var nickDetail = base.XMNickService.GetXMNickByID(this.NickId);
                lbNickName.Text = nickDetail.nick;
                var platFormTypeList = base.CodeService.GetCodeList(Convert.ToInt32(nickDetail.PlatformTypeId));
                if (platFormTypeList.Count > 0)
                {
                    lbPlatFormName.Text = platFormTypeList[0].CodeName;
                }
                //lbCreateName.Text = HozestERPContext.Current.User.Username;

                loadData(this.Id);
            }
        }

        private void loadData(int id)
        {
            if (id != 0)
            {
                XMNickMonthlyTarget info = base.XMNickMonthlyTargetService.GetXMNickMonthlyTargetByID(id);

                dpLogDate.Value = info.DateTime.ToString();
                OriginalTime = info.DateTime;
                txtBargainAmount.Text = info.TurnoverAmount.ToString();
                txtBargainNum.Text = info.TurnoverNumber.ToString();
                txtNewCustomerOrderNum.Text = info.NewCusOrderCount.ToString();
                txtOldCustomerOrderNum.Text = info.OldCusOrderCount.ToString();
                txtBargainPeopleNum.Text = info.TurnoverPersonCount.ToString();
                txtNickPerTicketSales.Text = info.GuestUnitPrice.ToString();
                var nickDetail = base.XMNickService.GetXMNickByID(this.NickId);
                lbNickName.Text = nickDetail.nick;
                var platFormTypeList = base.CodeService.GetCodeList(Convert.ToInt32(nickDetail.PlatformTypeId));
                if (platFormTypeList.Count > 0)
                {
                    lbPlatFormName.Text = platFormTypeList[0].CodeName;
                }
                //lbCreateName.Text = base.XMOtherMonthlyTargetService.GetCustomerName(info.Updater.ToString());

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            if (Type == 0)
            {
                DateTime datetime = Convert.ToDateTime(dpLogDate.Value);   //设定时间

                var list = base.XMNickMonthlyTargetService.GetXMNickMonthlyTargetListByYear(datetime.Year, this.NickId);
                list = list.Where(p => p.DateTime.Month == datetime.Month).ToList();
                if (list.Count > 0)
                {
                    base.ShowMessage("该月份数据已存在！");
                    return;
                }
                string turnoverAmount = txtBargainAmount.Text.Trim();                        //成交金额
                string turnoverNumber = txtBargainNum.Text.Trim();                            //成交件数
                string NewCusOrderCount = txtNewCustomerOrderNum.Text.Trim();   //新客户订单数
                string OldCusOrderCount = txtOldCustomerOrderNum.Text.Trim();      //老客户订单数
                string TurnoverPersonCount = txtBargainPeopleNum.Text.Trim();          //成交人数
                string GuestUnitPrice = txtNickPerTicketSales.Text.Trim();                     //客单价
                int nickId = this.NickId;                                                                         //店铺ID
                int createID = HozestERPContext.Current.User.CustomerID;                 //创建人ID
                DateTime CreateDate = DateTime.Now;                                                //创建时间
                int Updater = HozestERPContext.Current.User.CustomerID;                  //更新人ID
                DateTime UpdateDate = DateTime.Now;                                               //更新时间

                XMNickMonthlyTarget Info = new XMNickMonthlyTarget();
                Info.DateTime = datetime;
                Info.TurnoverAmount = Convert.ToDecimal(turnoverAmount);
                Info.TurnoverNumber = int.Parse(turnoverNumber);
                Info.NewCusOrderCount = int.Parse(NewCusOrderCount);
                Info.OldCusOrderCount = int.Parse(OldCusOrderCount);
                Info.TurnoverPersonCount = int.Parse(TurnoverPersonCount);
                Info.GuestUnitPrice = Convert.ToDecimal(GuestUnitPrice);
                Info.NickId = nickId;
                Info.CreateDate = CreateDate;
                Info.CreateID = createID;
                Info.Updater = createID;
                Info.UpdateDate = UpdateDate;
                Info.IsEnable = false;
                Info.IsAudit = false;
                base.XMNickMonthlyTargetService.InsertXMNickMonthlyTarget(Info);

            }

            else
            {
                DateTime datetime = Convert.ToDateTime(dpLogDate.Value);   //设定时间
                if (OriginalTime.Month != datetime.Month)
                {
                    var list = base.XMNickMonthlyTargetService.GetXMNickMonthlyTargetListByYear(datetime.Year, this.NickId);
                    list = list.Where(p => p.DateTime.Month == datetime.Month).ToList();
                    if (list.Count > 0)
                    {
                        base.ShowMessage("该月份数据已存在！");
                        return;
                    }
                }

                string turnoverAmount = txtBargainAmount.Text.Trim();                        //成交金额
                string turnoverNumber = txtBargainNum.Text.Trim();                            //成交件数
                string NewCusOrderCount = txtNewCustomerOrderNum.Text.Trim();   //新客户订单数
                string OldCusOrderCount = txtOldCustomerOrderNum.Text.Trim();      //老客户订单数
                string TurnoverPersonCount = txtBargainPeopleNum.Text.Trim();          //成交人数
                string GuestUnitPrice = txtNickPerTicketSales.Text.Trim();                     //客单价
                int nickId = this.NickId;                                                                         //店铺ID
                int createID = HozestERPContext.Current.User.CustomerID;                 //创建人ID
                DateTime CreateDate = DateTime.Now;                                                //创建时间
                int Updater = HozestERPContext.Current.User.CustomerID;                  //更新人ID
                DateTime UpdateDate = DateTime.Now;                                               //更新时间
                XMNickMonthlyTarget Info = base.XMNickMonthlyTargetService.GetXMNickMonthlyTargetByID(Id);
                if ((bool)Info.IsAudit)
                {
                    base.ShowMessage("已审核，不能修改！");
                    return;
                }
                Info.TurnoverAmount = Convert.ToDecimal(turnoverAmount);
                Info.TurnoverNumber = int.Parse(turnoverNumber);
                Info.NewCusOrderCount = int.Parse(NewCusOrderCount);
                Info.OldCusOrderCount = int.Parse(OldCusOrderCount);
                Info.TurnoverPersonCount = int.Parse(TurnoverPersonCount);
                Info.GuestUnitPrice = Convert.ToDecimal(GuestUnitPrice);
                Info.Updater = HozestERPContext.Current.User.CustomerID;
                Info.UpdateDate = UpdateDate;
                Info.DateTime = datetime;
                base.XMNickMonthlyTargetService.UpdateXMNickMonthlyTarget(Info);
            }
            //base.ShowMessage("保存成功!");
            this.Master.JsWrite("alert('保存成功.');window.PopClose();", "");
        }

        public DateTime OriginalTime
        {
            get { return ViewState["OriginalTime"] == null ? DateTime.Now : (DateTime)ViewState["OriginalTime"]; }

            set { ViewState["OriginalTime"] = value; }
        }

        public int NickId
        {
            get
            {
                return CommonHelper.QueryStringInt("NickId");
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
        }

        public void SetTrigger()
        {
        }

    }
}