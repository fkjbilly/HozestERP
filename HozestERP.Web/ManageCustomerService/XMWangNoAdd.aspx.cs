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
    public partial class XMWangNoAdd : BaseAdministrationPage, IEditPage
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
            string WangNoName = WangNo.Text;
            if (WangNo.ToString() == "")
            {
                base.ShowMessage("旺旺号不能为空!");
                return;
            }
            else
            {
                if (XMWangNoId == -1)//添加
                {
                    XMWangNo orderinfoapp = new XMWangNo();
                    orderinfoapp.NickId = ddlNick;
                    orderinfoapp.PlatfromTypeId = ddlPlatformType;
                    orderinfoapp.WangNo = WangNoName;
                    orderinfoapp.IsEnabled = false;
                    orderinfoapp.CreatorID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.CreateTime = DateTime.Now;
                    orderinfoapp.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.UpdateTime = DateTime.Now;
                    base.XMWangNoService.InsertXMWangNo(orderinfoapp);
                    base.ShowMessage("保存成功!");
                }
                else  //编辑
                {
                    XMWangNo orderinfoapp = base.XMWangNoService.GetXMWangNoByID(XMWangNoId);
                    if (orderinfoapp != null)//判断有没有这条数据
                    {
                        orderinfoapp.NickId = ddlNick;
                        orderinfoapp.PlatfromTypeId = ddlPlatformType;
                        orderinfoapp.WangNo = WangNoName;
                        orderinfoapp.IsEnabled = false;
                        orderinfoapp.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        orderinfoapp.UpdateTime = DateTime.Now;
                        base.XMWangNoService.UpdateXMWangNo(orderinfoapp);
                        base.ShowMessage("保存成功!");
                    }
                }
            }
        }

        public void loadDate() {
            if (XMWangNoId == -1)
            {
                this.Face_Init();
            }
            else
            {
                var XMWangNo = base.XMWangNoService.GetXMWangNoByID(XMWangNoId);
                this.ddlNickId.SelectedValue = XMWangNo.NickId.ToString();
                this.ddlPlatformTypeId.SelectedValue = XMWangNo.PlatfromTypeId.ToString();
                this.WangNo.Text = XMWangNo.WangNo.ToString();
            }
        }
            
        

        /// <summary>
        /// 操作类型
        /// </summary>
        public int XMWangNoId
        {
            get
            {
                return CommonHelper.QueryStringInt("XMWangNoId");
            }
        }

        public void Face_Init()
        {
            this.ddlPlatformTypeId.Items.Clear();
            var codePlatformTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatformTypeId.DataSource = codePlatformTypeList;
            this.ddlPlatformTypeId.DataTextField = "CodeName";
            this.ddlPlatformTypeId.DataValueField = "CodeID";
            this.ddlPlatformTypeId.DataBind();

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