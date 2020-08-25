using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;
using HozestERP.Common;

namespace HozestERP.Web.ManageProject
{
    public partial class XMCombinationManageProductList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员
        public void SetTrigger()
        {
            //this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnSynchronousOrderData.UniqueID, this.Page);
        }

        public void Face_Init()
        {
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //产品名称
            string ProductName = this.ddlProductName.Text.Trim();
            //厂家编码
            string ManufacturersCode = this.ddlManufacturersCode.Text.Trim();

            //根据店铺名称，产品名称，厂家编码查询。
            var xMProjectList = base.XMProductService.GetXMProductListByCondition(ProductName, ManufacturersCode);
            //分页
            var xMProjectPageList = new PagedList<XMProduct>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, xMProjectPageList, paramPageSize + 1);

            GetChecked();
        }

        #endregion

        /// <summary>
        /// 条件查询
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<int> SelectedIds = this.Master.GetSelectedIds(this.grdvClients);
            List<int> NotSelectedIds = GetNotSelectedIds(this.grdvClients);

            if (Session["ProductInfoList"] != null)
            {
                List<int> Ids = (List<int>)Session["ProductInfoList"];
                foreach (int a in SelectedIds)
                {
                    Ids.Add(a);
                }
                Ids = Ids.Distinct().ToList();
                foreach (int a in NotSelectedIds)
                {
                    if (Ids.IndexOf(a) != -1)
                    {
                        Ids.Remove(a);
                    }
                }
                Session["ProductInfoList"] = Ids;
            }
            else
            {
                Session["ProductInfoList"] = SelectedIds;
            }
            base.ShowMessage("保存成功！");

            if (Session["ProductInfoCount"] != null)
            {
                Session["ProductInfoCount"] = null;
            }
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "closewindow", "<script>window.close();</script>");
        }

        public void GetChecked()
        {
            if (Session["ProductInfoList"] != null)
            {
                List<int> ProductInfoIDs = (List<int>)Session["ProductInfoList"];
                for (int i = 0; i < this.grdvClients.Rows.Count; i++)
                {
                    CheckBox myChk = (CheckBox)this.grdvClients.Rows[i].Cells[0].FindControl("chkSelected");
                    if (myChk != null)
                    {
                        if (ProductInfoIDs.IndexOf((int)this.grdvClients.DataKeys[i].Value)!=-1)
                        {
                            myChk.Checked = true;
                        }
                    }
                }
            }
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

        public List<int> GetNotSelectedIds(GridView paramGridView)
        {
            List<int> myIDs = new List<int>();
            for (int i = 0; i < paramGridView.Rows.Count; i++)
            {
                CheckBox myChk = (CheckBox)paramGridView.Rows[i].Cells[0].FindControl("chkSelected");
                if (myChk != null)
                {
                    if (!myChk.Checked)
                    {
                        int keyID = 0;
                        int.TryParse(paramGridView.DataKeys[i].Value.ToString(), out keyID);
                        myIDs.Add(keyID);
                    }
                }
            }
            return myIDs;
        } 

    }

}