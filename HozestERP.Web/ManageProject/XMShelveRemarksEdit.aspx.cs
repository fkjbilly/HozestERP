using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMShelveRemarksEdit : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Info = base.XMDeliveryService.GetXMDeliveryById(Id);
                if (Info != null)
                {
                    this.txtCustomerRemark.Text = Info.ShelveRemarks;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    //备注
                    string Remark = this.txtCustomerRemark.Text.Trim();
                    var Info = base.XMDeliveryService.GetXMDeliveryById(Id);
                    if (Info != null)
                    {
                        Info.ShelveRemarks = Remark;
                        Info.UpdateId = HozestERPContext.Current.User.CustomerID;
                        Info.UpdateDate = DateTime.Now;
                        base.XMDeliveryService.UpdateXMDelivery(Info);

                    }
                    else
                    {
                        base.ShowMessage("该发货单不存在！");
                        scope.Complete();
                        return;
                    }
                    scope.Complete();
                    base.ShowMessage("保存成功！");
                }
                catch (Exception err)
                {
                    this.ProcessException(err);
                }
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
        }

        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        #endregion
    }
}