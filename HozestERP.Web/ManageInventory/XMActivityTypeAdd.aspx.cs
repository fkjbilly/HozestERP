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
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageInventory
{
    public partial class XMActivityTypeAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Type == 1)
                {
                    loadData();
                }
            }
        }

        private void loadData()
        {
            var activityType = base.XMActivityTypeService.GetXMActivityTypeById(this.Id);
            if (activityType != null)
            {
                txtActivityTypeName.Text = activityType.ActivityName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            string activityTypeName = txtActivityTypeName.Text.Trim();
            if (this.Type == 0)            //新增
            {
                //判断活动类型名称是否存在
                var activityType = base.XMActivityTypeService.GetXMActivityTypeByActivityTypeName(activityTypeName);
                if (activityType != null)
                {
                    base.ShowMessage("活动类型名称已经存在！");
                    return;
                }
                XMActivityType Info = new XMActivityType();
                Info.ActivityName = activityTypeName;
                Info.CreateDate = Info.UpdateDate = DateTime.Now;
                Info.CreateID = Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                Info.IsEnale = false;
                base.XMActivityTypeService.InsertXMActivityType(Info);
            }
            else             //编辑
            {
                var activityTypes = base.XMActivityTypeService.GetXMActivityTypeById(this.Id);
                if (activityTypes != null)
                {
                    activityTypes.ActivityName = txtActivityTypeName.Text.Trim();
                    activityTypes.UpdateID = HozestERPContext.Current.User.CustomerID;
                    activityTypes.UpdateDate = DateTime.Now;
                    base.XMActivityTypeService.UpdateXMActivityType(activityTypes);
                }
            }
            base.ShowMessage("保存成功！");
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