using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderInfoRemarkEdit : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var OrderModel = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);

                this.txtRemark.Text = OrderModel.Remark;
                this.txtCustomerRemark.Text = OrderModel.CustomerServiceRemark;
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("订单管理 > 备注");
        }

        public void SetTrigger()
        {
            // this.Master.SetTrigger(this.btnSave.UniqueID, this.Page); 

        }
        #endregion

        /// <summary>
        /// 订单id
        /// </summary>
        public int XMOrderInfoID
        {
            get
            {
                return CommonHelper.QueryStringInt("ID");
            }
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    var OrderModel = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);

                    OrderModel.Remark = this.txtRemark.Text.Trim();
                    OrderModel.CustomerServiceRemark = this.txtCustomerRemark.Text.Trim();

                    base.XMOrderInfoService.UpdateXMOrderInfo(OrderModel);

                    base.ShowMessage("保存成功");
                }
                catch (Exception err)
                {
                    this.ProcessException(err);
                }
            }
        }

    }
}