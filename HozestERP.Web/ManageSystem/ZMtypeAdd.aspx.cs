using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.Common.Utils;
using HozestERP.Web.Modules;

namespace HozestERP.Web.ManageSystem
{
    public partial class ZMtypeAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //string Line = this.txtLine.Text.Trim();
            string Installationtype = this.txtInstallationtype.Text.Trim();
            if (Installationtype == "")
            {
                base.ShowMessage("数据不能为空，请先填写数据！");
                return;
            }

            List<XMTypeTest> list = new List<XMTypeTest>();
            list = base.XMTypeTestService.GetXMTypeTestList();

            if (Id == -1)
            {
                XMTypeTest Info = new XMTypeTest();
                Info.type = Installationtype;
                Info.IsEnabled = false;
                Info.CreatorID = HozestERPContext.Current.User.CustomerID;
                Info.CreateTime = DateTime.Now;
                Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                Info.UpdateTime = DateTime.Now;
                base.XMTypeTestService.InsertXMTypeTest(Info);
                base.ShowMessage("保存成功！");
            }

            //else//添加
            //{

            //}
            else//编辑
            {
                XMTypeTest Info = base.XMTypeTestService.GetXMTypeTestByID(Id);
                if (Info != null)//判断有没有这条数据
                {
                    Info.type = Installationtype;
                    Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateTime = DateTime.Now;
                    base.XMTypeTestService.UpdateXMTypeTest(Info);
                    base.ShowMessage("保存成功！");
                }
            }
        }

        public void loadDate()
        {
            if (Id != -1)
            {
                var Info = base.XMTypeTestService.GetXMTypeTestByID(Id);
                this.txtInstallationtype.Text = Info.type;
            }
        }


        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
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