using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.Common.Utils;
using HozestERP.Web.Modules;

namespace HozestERP.Web.ManageSystem
{
    public partial class DemandAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^\d+(\.\d{2})?$");
            return reg1.IsMatch(str);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string requirements = this.txtdemand.Text.Trim();
            var Price = this.txtPrice.Text.Trim();
            int ToInt = 0;
            if (requirements == "" || Price == "" )
            {
                base.ShowMessage("数据不能为空，请先填写数据！");
                return;
            }

            bool t = IsNumeric(Price);
            if (!t)
            {
                base.ShowMessage("金额输入有误，请重新输入！");
                return;
            }

            List<XMZMDemand> list = new List<XMZMDemand>();
            list = base.XMZMDemandService.GetXMZMDemandList();

            if (Id==-1)
            {
                XMZMDemand Info = new XMZMDemand();
                int Type = int.Parse(this.ddlType.SelectedValue);
                Info.requirements = requirements;
                Info.Price = decimal.Parse(Price.ToString());
                Info.IsEnabled = false;
                Info.CreatorID = HozestERPContext.Current.User.CustomerID;
                Info.CreateTime = DateTime.Now;
                Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                Info.UpdateTime = DateTime.Now;
                Info.Tid = Type;
                base.XMZMDemandService.InsertXMZMDemand(Info);
                base.ShowMessage("保存成功！");
            }

            //else//添加
            //{

            //}
            else//编辑
            {
                XMZMDemand Info = base.XMZMDemandService.GetXMZMDemandByID(Id);
                if (Info != null)//判断有没有这条数据
                {
                    int Type = int.Parse(this.ddlType.SelectedValue);
                    Info.Price = decimal.Parse(Price.ToString());
                    Info.requirements = requirements;
                    Info.Tid = Type;
                    Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateTime = DateTime.Now;
                    base.XMZMDemandService.UpdateXMZMDemand(Info);
                    base.ShowMessage("保存成功！");
                }
            }
        }

        public void loadDate()
        {
            if (Id != -1)
            {
                var Info = base.XMZMDemandService.GetXMZMDemandByID(Id);
                this.ddlType.SelectedValue = Info.Tid.ToString();
                this.txtdemand.Text = Info.requirements;
                this.txtPrice.Text = Info.Price.ToString();
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
            this.ddlType.Items.Clear();
            var TypeList = base.XMTypeTestService.GetXMTypeTestList();
            var newTypeList = TypeList.ToList();
            this.ddlType.DataSource = newTypeList;
            this.ddlType.DataTextField = "type";
            this.ddlType.DataValueField = "ID";
            this.ddlType.DataBind();
            this.ddlType.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        public void SetTrigger()
        {
        }
    }
}