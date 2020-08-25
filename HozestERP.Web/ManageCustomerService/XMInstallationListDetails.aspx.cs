using System;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMInstallationListDetails : BaseAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }

        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        public void BindGrid()
        {
            var List = base.XMTypeTestService.GetXMTypeTestList();

            gvXMProduct.DataSource = List;
            gvXMProduct.DataBind();
        }

        protected void gvXMProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.BindGrid();
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvXMProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var Tid = (XMTypeTest)e.Row.DataItem;
                var product = base.XMZMReservationService.GetXMZMReservationListByInstallationID(Id, Tid.ID);
                RadioButtonList ddlDemand = (RadioButtonList)e.Row.FindControl("ddlDemand");
                var DemandList = base.XMZMDemandService.GetXMZMDemandListByTid(Tid.ID);
                ddlDemand.DataSource = DemandList;
                ddlDemand.DataTextField = "requirements";
                ddlDemand.DataValueField = "ID";
                ddlDemand.DataBind();

                if (product != null)
                {
                    ddlDemand.SelectedValue = product.DemandID.ToString();
                }

                DataControlFieldCell cell = (DataControlFieldCell)ddlDemand.Parent;
                Label lblPrice = (Label)cell.FindControl("lblPrice");

                if (ddlDemand.SelectedValue.ToString().Trim().Length > 0)
                {
                    if (Convert.ToInt16(ddlDemand.SelectedValue.ToString().Trim()) != -1)
                    {
                        int Did = Convert.ToInt32(ddlDemand.SelectedValue);
                        var DemandList2 = base.XMZMDemandService.GetXMZMDemandByID(Did);
                        lblPrice.Text = DemandList2.Price.ToString();
                        lblPrice.DataBind();
                    }
                }
            }
        }

        protected void ddlDemand_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList ddlDemand = (RadioButtonList)sender;
            DataControlFieldCell cell = (DataControlFieldCell)ddlDemand.Parent;
            Label lblPrice = (Label)cell.FindControl("lblPrice");

            if (ddlDemand.SelectedValue.ToString().Trim().Length > 0)
            {
                if (Convert.ToInt16(ddlDemand.SelectedValue.ToString().Trim()) != -1)
                {
                    int Did = Convert.ToInt32(ddlDemand.SelectedValue);
                    var DemandList = base.XMZMDemandService.GetXMZMDemandByID(Did);
                    lblPrice.Text = DemandList.Price.ToString();
                    lblPrice.DataBind();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal sum = 0;
            int Type = 0;
            foreach (GridViewRow row in gvXMProduct.Rows)
            {
                var ddlDemand = row.FindControl("ddlDemand") as RadioButtonList;
                int Demand = int.Parse(ddlDemand.SelectedValue);
                Type = base.XMZMDemandService.GetXMZMDemandTidByID(Demand);
                var product = base.XMZMReservationService.GetXMZMReservationListByInstallationID(Id, Type);
                decimal lblPrice = Convert.ToDecimal(((Label)row.FindControl("lblPrice")).Text.Trim());
                sum += lblPrice;

                XMZMReservation Info2 = new XMZMReservation();
                Info2.Remarks = lblPrice.ToString();
                Info2.DemandID = Demand;
                //Info2.TypeID = Type;

                product.DemandID = Info2.DemandID;
                product.Remarks = Info2.Remarks;

                base.XMZMReservationService.UpdateXMZMReservation(Info2);
            }
            HozestERP.BusinessLogic.ManageCustomerService.XMInstallationList Info = new HozestERP.BusinessLogic.ManageCustomerService.XMInstallationList();
            var product2 = base.XMInstallationListService.GetXMInstallationListByID(Id);

            Info.InstallationFee = sum;
            product2.InstallationFee = Info.InstallationFee;
            base.XMInstallationListService.UpdateXMInstallationList(Info);
            base.ShowMessage("保存成功！");
            this.BindGrid();
        }
    }
}