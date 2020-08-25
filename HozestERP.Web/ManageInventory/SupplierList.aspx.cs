using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using System.Transactions;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageInventory
{
    public partial class SupplierList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.btnSupplierAdd.OnClientClick = "return ShowWindowDetail('新增供应商','" + CommonHelper.GetStoreLocation() +
      "ManageInventory/SupplierAdd.aspx?Type=0"
      + "',960,500, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                BindGrid(1, Master.PageSize);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string supplierCode = txtSupplierCode.Text.Trim();
            string supplierName = txtSupplierName.Text.Trim();

            var list = base.XMSuppliersService.GetXMSuppliersListByParm(supplierCode, supplierName);
            var pageList = new PagedList<XMSuppliers>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvSupplier, pageList);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMSuppliers;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('新增供应商','" + CommonHelper.GetStoreLocation() +
        "ManageInventory/SupplierAdd.aspx?Type=1"
          + "&&Id=" + info.Id
        + "',890,500, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
            }
        }

        protected void grdvSupplier_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//删除
                {
                    var Info = base.XMSuppliersService.GetXMSuppliersById(Convert.ToInt16(id));
                    //判断供应商是否在采购单或采购入库单中已经使用，如已经使用将无法删除，如果未使用可以删除
                    //var purchases = base.XMPurchaseService.GetXMPurchaseListBySupplierID(int.Parse(id));
                    //var storagese = base.XMStorageService.GetXMStorageBySupplierId(int.Parse(id));
                    //if (storagese != null && storagese.Count > 0)                //判断供应商在采购入库单中是否已经使用
                    //{
                    //    base.ShowMessage("供应商[" + Info.SupplierName + "] 在采购入库单中已经被使用，不能删除！");
                    //    return;
                    //}
                    //if (purchases != null && purchases.Count > 0)             //判断供应商在采购单中是否已经使用
                    //{
                    //    base.ShowMessage("供应商[" + Info.SupplierName + "] 在采购单中已经被使用，不能删除！");
                    //    return;
                    //}
                    if (Info != null)
                    {
                        Info.IsDeleted = true;
                        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        Info.UpdateDate = DateTime.Now;
                        base.XMSuppliersService.UpdateXMSuppliers(Info);
                        base.ShowMessage("操作成功！");
                    }
                    else
                    {
                        base.ShowMessage("未查到该数据！");
                    }
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                }
            }
            #endregion
        }

        ///// <summary>
        ///// 批量删除
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    List<int> SupplierIDs = this.Master.GetSelectedIds(this.grdvSupplier);
        //    if (SupplierIDs.Count <= 0)
        //    {
        //        base.ShowMessage("你没有选择任何记录！");
        //        return;
        //    }
        //    //事务
        //    using (TransactionScope scope = new TransactionScope())
        //    {
        //        foreach (var item in SupplierIDs)
        //        {
        //            if (!Delete(item))
        //            {
        //                base.ShowMessage("数据库不存在该数据！");
        //            }
        //        }
        //        scope.Complete();
        //    }
        //    base.ShowMessage("操作成功！");
        //    this.BindGrid(Master.PageIndex, Master.PageSize);
        //}
        ///// <summary>
        ///// 删除供应商
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <returns></returns>
        //public bool Delete(int ID)
        //{
        //    var Info = base.XMSuppliersService.GetXMSuppliersById(ID);
        //    if (Info != null)
        //    {
        //        Info.IsDeleted = true;
        //        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
        //        Info.UpdateDate = DateTime.Now;
        //        base.XMSuppliersService.UpdateXMSuppliers(Info);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        #endregion
    }
}