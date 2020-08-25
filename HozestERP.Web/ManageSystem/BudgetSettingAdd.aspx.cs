using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using HozestERP.Web.Modules;

namespace HozestERP.Web.ManageSystem
{
    public partial class BudgetSettingAdd : BaseAdministrationPage, IEditPage
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
            //科目名称
            string Name = this.txtName.Text.Trim();
            //是否为管理费用
            int IsCost = Convert.ToInt32(this.ddlIsCost.SelectedValue);

            if (string.IsNullOrEmpty(Name))
            {
                base.ShowMessage("预算科目名称不能为空！");
                return;
            }
            var list = base.BudgetSettingService.GetBudgetSettingListByData(Name, -1);
            if (list.Count > 0)
            {
                base.ShowMessage("该预算科目名称已存在！");
                return;
            }

            if (Id == -1)
            {
                BudgetSetting one = new BudgetSetting();
                one.Name = Name;
                one.IsCost = IsCost == 1 ? true : false;
                one.IsEnabled = false;
                one.Creator = HozestERPContext.Current.User.CustomerID;
                one.CreateDate = DateTime.Now;
                one.Updater = HozestERPContext.Current.User.CustomerID;
                one.UpdateDate = DateTime.Now;
                base.BudgetSettingService.InsertBudgetSetting(one);
            }
            else
            {
                BudgetSetting one = base.BudgetSettingService.GetBudgetSettingByID(Id);
                one.Name = Name;
                one.IsCost = IsCost == 1 ? true : false;
                one.Updater = HozestERPContext.Current.User.CustomerID;
                one.UpdateDate = DateTime.Now;
                base.BudgetSettingService.UpdateBudgetSetting(one);
            }
            base.ShowMessage("保存成功！");
        }

        public void loadDate()
        {
            this.Face_Init();

            if (Id != -1)
            {
                var Info = base.BudgetSettingService.GetBudgetSettingByID(Id);
                if (Info != null)
                {
                    this.txtName.Text = Info.Name;
                    this.ddlIsCost.SelectedValue = Info.IsCost == true ? "1" : "0";
                }
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