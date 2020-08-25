using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;
namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMDSRAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { loadDate(); }
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ddlNick=Convert.ToInt32(ddlNickId.SelectedValue);
            int ddlPlatformType=Convert.ToInt32(ddlPlatformTypeId.SelectedValue);
            string Month = ddlMonth.Value.ToString();
            string CommodityDesname = CommodityDes.Text;
            string ServiceAttitudename = ServiceAttitude.Text;
            string DeliverySpeedname = DeliverySpeed.Text;
            decimal a = 0.00M;
            if (CommodityDesname.ToString() == "" || ServiceAttitudename.ToString() == "" || DeliverySpeedname.ToString() == "" || ddlMonth.Value.ToString()=="")
            {
                base.ShowMessage("月份、商品描述、服务态度、发货速度不能为空!");
                return;
            }
            else if (Decimal.TryParse(CommodityDesname, out a) == false || Decimal.TryParse(ServiceAttitudename, out a) == false || Decimal.TryParse(DeliverySpeedname, out a) == false)
            {
                base.ShowMessage("商品描述、服务态度、发货速度必须为数字!");
                return;
            }
            else
            {
                if (XMDSRId == -1)//添加
                {
                    XMDSR orderinfoapp = new XMDSR();
                    orderinfoapp.NickId = ddlNick;
                    orderinfoapp.PlatfromTypeId = ddlPlatformType;
                    orderinfoapp.Month = Month;
                    orderinfoapp.CommodityDes = decimal.Parse(CommodityDesname);
                    orderinfoapp.ServiceAttitude = decimal.Parse(ServiceAttitudename);
                    orderinfoapp.DeliverySpeed = decimal.Parse(DeliverySpeedname);
                    orderinfoapp.IsEnabled = false;
                    orderinfoapp.CreatorID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.CreateTime = DateTime.Now;
                    orderinfoapp.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.UpdateTime = DateTime.Now;
                    base.XMDSRService.InsertXMDSR(orderinfoapp);
                    base.ShowMessage("保存成功!");
                }
                else  //编辑
                {
                    XMDSR orderinfoapp = base.XMDSRService.GetXMDSRByID(XMDSRId);
                    if (orderinfoapp != null)//判断有没有这条数据
                    {
                        orderinfoapp.NickId = ddlNick;
                        orderinfoapp.PlatfromTypeId = ddlPlatformType;
                        orderinfoapp.Month = Month;
                        orderinfoapp.CommodityDes = decimal.Parse(CommodityDesname);
                        orderinfoapp.ServiceAttitude = decimal.Parse(ServiceAttitudename);
                        orderinfoapp.DeliverySpeed = decimal.Parse(DeliverySpeedname);
                        orderinfoapp.IsEnabled = false;
                        orderinfoapp.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        orderinfoapp.UpdateTime = DateTime.Now;
                        base.XMDSRService.UpdateXMDSR(orderinfoapp);
                        base.ShowMessage("保存成功!");
                    }
                }
            }
        }

        public void loadDate() {
            if (XMDSRId == -1)
            {
                this.Face_Init();
            }
            else
            {
                var XMDSR = base.XMDSRService.GetXMDSRByID(XMDSRId);
                this.ddlNickId.SelectedValue = XMDSR.NickId.ToString();
                this.ddlPlatformTypeId.SelectedValue = XMDSR.PlatfromTypeId.ToString();
                this.ddlMonth.Value = XMDSR.Month.ToString();
                this.CommodityDes.Text = XMDSR.CommodityDes.ToString();
                this.ServiceAttitude.Text = XMDSR.ServiceAttitude.ToString();
                this.DeliverySpeed.Text = XMDSR.DeliverySpeed.ToString();
            }
        }
            
        

        /// <summary>
        /// 操作类型
        /// </summary>
        public int XMDSRId
        {
            get
            {
                return CommonHelper.QueryStringInt("XMDSRId");
            }
        }

        public void Face_Init()
        {
            this.ddlNickId.Items.Clear();
            var NickList = base.XMNickService.GetXMNickList();
            var newNickList = NickList.Where(p => p.isEnable == true).ToList();
            this.ddlNickId.DataSource = newNickList;
            this.ddlNickId.DataTextField = "nick";
            this.ddlNickId.DataValueField = "nick_id";
            this.ddlNickId.DataBind();

        }

        public void SetTrigger()
        {
            //throw new NotImplementedException();
        }
    }
}