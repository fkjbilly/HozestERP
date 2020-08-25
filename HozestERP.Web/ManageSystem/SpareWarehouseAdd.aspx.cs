using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Codes;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class SpareWarehouseAdd : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
            }
        }

        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
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
            var list = base.ProvinceWarehouseSpareService.GetProvinceWarehouseSpareByProvinceWarehouseID(Id);
            var pageList = new PagedList<ProvinceWarehouseSpare>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.grdvClients.EditIndex = pageList.Count();
            pageList.Add(new ProvinceWarehouseSpare());
            this.Master.BindData(this.grdvClients, pageList);
        }

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                #region 修改
                if (e.CommandName.Equals("OrderProductUpdate"))
                {
                    try
                    {
                        var Info = base.ProvinceWarehouseService.GetProvinceWarehouseByID(Id);
                        //订单详细信息
                        var info = base.ProvinceWarehouseSpareService.GetProvinceWarehouseSpareByID(Convert.ToInt32(e.CommandArgument));

                        //编辑行
                        GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                        DropDownList ddlSequence = (DropDownList)gvr.FindControl("ddlSequence");//序号
                        DropDownList ddlSpareWarehouse = (DropDownList)gvr.FindControl("ddlSpareWarehouse");//备用仓库ID

                        if (Info != null)
                        {
                            var ExistSpareWarehouse = base.ProvinceWarehouseSpareService.GetProvinceWarehouseSpareByParm(Id, -1, int.Parse(ddlSpareWarehouse.SelectedValue.Trim()));
                            var ExistSequence = base.ProvinceWarehouseSpareService.GetProvinceWarehouseSpareByParm(Id, int.Parse(ddlSequence.SelectedValue.Trim()), -1);
                            if (ExistSequence != null && ExistSequence.Count > 0)
                            {
                                base.ShowMessage("该序号已存在！");
                                return;
                            }
                            if (ExistSpareWarehouse != null && ExistSpareWarehouse.Count > 0)
                            {
                                base.ShowMessage("该备用仓库已存在！");
                                return;
                            }

                            if (info != null)
                            {
                                info.Sequence = int.Parse(ddlSequence.SelectedValue.Trim());
                                info.SpareWarehouseID = int.Parse(ddlSpareWarehouse.SelectedValue.Trim());
                                info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                info.UpdateTime = DateTime.Now;
                                base.ProvinceWarehouseSpareService.UpdateProvinceWarehouseSpare(info);

                                base.ShowMessage("修改成功！");
                            }
                            else
                            {
                                ProvinceWarehouseSpare Item = new ProvinceWarehouseSpare();
                                Item.ProvinceWarehouseID = Id;
                                Item.Sequence = int.Parse(ddlSequence.SelectedValue.Trim());
                                Item.SpareWarehouseID = int.Parse(ddlSpareWarehouse.SelectedValue.Trim());
                                Item.IsEnabled = false;
                                Item.CreatorID = HozestERPContext.Current.User.CustomerID;
                                Item.CreateTime = DateTime.Now;
                                Item.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                Item.UpdateTime = DateTime.Now;
                                base.ProvinceWarehouseSpareService.InsertProvinceWarehouseSpare(Item);
                                base.ShowMessage("添加成功！");
                            }

                            this.BindGrid(1, Master.PageSize);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }

        }

        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == DataControlRowState.Edit ||
                 e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                var Info = base.ProvinceWarehouseService.GetProvinceWarehouseByID(Id);
                if (Info != null)
                {
                    DropDownList ddlSequence = (DropDownList)e.Row.FindControl("ddlSequence");
                    DropDownList ddlSpareWarehouse = (DropDownList)e.Row.FindControl("ddlSpareWarehouse");

                    var SpareWarehouseList = base.CodeService.GetCodeListInfoByCodeTypeID(227);
                    SpareWarehouseList = SpareWarehouseList.Where(x => x.CodeID != Info.WarehouseID).ToList();
                    ddlSpareWarehouse.Items.Clear();
                    ddlSpareWarehouse.DataSource = SpareWarehouseList;
                    ddlSpareWarehouse.DataTextField = "CodeName";
                    ddlSpareWarehouse.DataValueField = "CodeID";
                    ddlSpareWarehouse.DataBind();

                    if (SpareWarehouseList.Count > 0)
                    {
                        List<CodeList> SequenceList = new List<CodeList>();
                        for (int i = 1; i <= SpareWarehouseList.Count(); i++)
                        {
                            CodeList item = new CodeList();
                            item.CodeID = i;
                            item.CodeName = i.ToString();
                            SequenceList.Add(item);
                        }
                        ddlSequence.Items.Clear();
                        ddlSequence.DataSource = SequenceList;
                        ddlSequence.DataTextField = "CodeName";
                        ddlSequence.DataValueField = "CodeID";
                        ddlSequence.DataBind();
                    }
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            if (int.TryParse(this.grdvClients.DataKeys[e.RowIndex].Value.ToString(), out Id))
            {
                var Info = base.ProvinceWarehouseSpareService.GetProvinceWarehouseSpareByID(Id);
                if (Info != null)
                {
                    Info.IsEnabled = true;
                    Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateTime = DateTime.Now;
                    base.ProvinceWarehouseSpareService.UpdateProvinceWarehouseSpare(Info);
                    BindGrid(1, Master.PageSize);
                }
                base.ShowMessage("删除成功！");
            }
        }
        #endregion
    }
}