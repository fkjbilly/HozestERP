using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using System.Transactions;
using System.Web.UI.HtmlControls;
using HozestERP.BusinessLogic.Customers;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageBusiness;

namespace HozestERP.Web.ManageBusiness
{
    public partial class XMNickAchieveValueList : BaseAdministrationPage, ISearchPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //默认查询开始时间
                txtLogStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
                //默认查询结束时间
                txtLogEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                this.BindGrid(1, Master.PageSize);
            }
        }
        /// <summary>
        /// grid 数据绑定
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //开始时间
            string logStartTime = txtLogStartTime.Value.ToString();
            //结束时间
            string logEndTime = txtLogEndTime.Value.ToString();
            XMNick nick = XMNickService.GetXMNickByID(this.NickID);
            //平台类型 
            int PlatformTypeId = 0;
            List<XMNickAchieveValue> newList;
            if (nick != null)
            {
                PlatformTypeId = nick.PlatformTypeId.Value;
                var list = base.XMNickAchieveValueService.GetXMNickAchieveValueList();
                newList = list.Where(p => p.NickId == this.NickID
                && (p.DateTime.Date >= DateTime.Parse(logStartTime) && p.DateTime.Date <= DateTime.Parse(logEndTime))
                ).ToList();
                var pageList = new PagedList<XMNickAchieveValue>(newList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                if (this.RowEditIndex == -1)
                {
                    this.gvNickTitle.EditIndex = pageList.Count();
                    //添加新增行
                    pageList.Add(new XMNickAchieveValue());
                }
                else
                {
                    this.gvNickTitle.EditIndex = this.RowEditIndex;
                }

                this.Master.BindData(this.gvNickTitle, pageList, paramPageSize + 1);
            }

        }


        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvNickTitle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            //获取选中行的Id
            int.TryParse(this.gvNickTitle.DataKeys[e.RowIndex].Value.ToString(), out Id);
            //根据Id查询
            var childTitle = base.XMNickAchieveValueService.GetXMNickAchieveValueById(Id);
            if (childTitle != null)
            {
                childTitle.IsEnable = true;//不可用
                childTitle.Updater = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                childTitle.UpdateDate = DateTime.Now;
                base.XMNickAchieveValueService.UpdateXMNickAchieveValue(childTitle);
            }
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
            base.ShowMessage("删除成功.");
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvNickTitle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }
        }

        protected void gvNickTitle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void gvNickTitle_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        /// <summary>
        /// 记录行 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvNickTitle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id = 0;
            decimal param = 0;
            int Iprmam = 0;
            int.TryParse(this.gvNickTitle.DataKeys[e.RowIndex].Value.ToString(), out Id);
            var row = this.gvNickTitle.Rows[e.RowIndex];

            #region 字符验证
            var txtLogTime = row.FindControl("txtLogTime") as HtmlInputText;
            var hfLogTime = row.FindControl("hfLogTime") as HiddenField;
            var txtArriveSalesNum = row.FindControl("txtArriveSalesNum") as TextBox;
            var lblArriveSalesNum = row.FindControl("lblArriveSalesNum") as Label;
            lblArriveSalesNum.Text = "";
            if (!int.TryParse(txtArriveSalesNum.Text.Trim(), out Iprmam))
            {
                if (txtArriveSalesNum.Text.Trim() != "")
                    lblArriveSalesNum.Text = "请输入正确的数值";
            }
            var txtArriveSalesMoney = row.FindControl("txtArriveSalesMoney") as TextBox;
            var lblArriveSalesMoney = row.FindControl("lblArriveSalesMoney") as Label;
            lblArriveSalesMoney.Text = "";
            if (!decimal.TryParse(txtArriveSalesMoney.Text.Trim(), out param))
            {
                if (txtArriveSalesMoney.Text.Trim() != "")
                    lblArriveSalesMoney.Text = "输入正确的数值";
            }
            var txtNickPerTicketSales = row.FindControl("txtNickPerTicketSales") as TextBox;
            var lblNickPerTicketSales = row.FindControl("lblNickPerTicketSales") as Label;
            lblNickPerTicketSales.Text = "";
            if (!decimal.TryParse(txtNickPerTicketSales.Text.Trim(), out param))
            {
                if (txtNickPerTicketSales.Text.Trim() != "")
                    lblNickPerTicketSales.Text = "请输入正确的数值";
            }

            var txtCost = row.FindControl("txtCost") as TextBox;
            var lblCost = row.FindControl("lblCost") as Label;
            lblCost.Text = "";
            if (!decimal.TryParse(txtCost.Text.Trim(), out param))
            {
                if (txtCost.Text.Trim() != "")
                    lblCost.Text = "请输入正确的数值";
            }

            if (lblArriveSalesNum.Text != "" || lblArriveSalesMoney.Text != "" ||
                  lblNickPerTicketSales.Text != "")
            {
                return;
            }

            if (string.IsNullOrEmpty(txtLogTime.Value.ToString()))
            {
                base.ShowMessage("日期不能为空");
                return;
            }
            #endregion

            XMNickAchieveValue nickAchieveValue = base.XMNickAchieveValueService.GetXMNickAchieveValueById(Id);
            int platformTypeId = 0;
            XMNick nick = base.XMNickService.GetXMNickByID(this.NickID);
            if (nick != null)
            {
                int.TryParse(nick.PlatformTypeId.ToString(), out platformTypeId);
            }


            //int count = base.XMNickAchieveValueService.GetXMNickAchieveValueListAll(this.NickID, Convert.ToDateTime(txtLogTime.Value.ToString()));
            //if (count > 0)
            //{
            //    base.ShowMessage("该日期下的数据已经存在！");
            //    return;
            //}

            //修改 目标设定
            if (nickAchieveValue != null)
            {
                if (txtLogTime.Value.Equals(hfLogTime.Value))
                {
                    nickAchieveValue.DateTime = DateTime.Parse(txtLogTime.Value.ToString());
                    nickAchieveValue.SaleCount = Convert.ToInt32(txtArriveSalesNum.Text.Trim());
                    nickAchieveValue.SalePrice = Convert.ToDecimal(txtArriveSalesMoney.Text.Trim());
                    nickAchieveValue.Cost = Convert.ToDecimal(txtCost.Text.Trim());
                    nickAchieveValue.GuestUnitPrice = Convert.ToDecimal(txtNickPerTicketSales.Text.Trim());
                    nickAchieveValue.Updater = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    nickAchieveValue.UpdateDate = DateTime.Now;
                    base.XMNickAchieveValueService.UpdateXMNickAchieveValue(nickAchieveValue);
                }
                else
                {
                    int count = base.XMNickAchieveValueService.GetXMNickAchieveValueListAll(this.NickID, Convert.ToDateTime(txtLogTime.Value.ToString()));
                    if (count > 0)
                    {
                        base.ShowMessage("该日期下的数据已经存在！");
                        return;
                    }
                    else
                    {
                        nickAchieveValue.DateTime = DateTime.Parse(txtLogTime.Value.ToString());
                        nickAchieveValue.SaleCount = Convert.ToInt32(txtArriveSalesNum.Text.Trim());
                        nickAchieveValue.SalePrice = Convert.ToDecimal(txtArriveSalesMoney.Text.Trim());
                        nickAchieveValue.Cost = Convert.ToDecimal(txtCost.Text.Trim());
                        nickAchieveValue.GuestUnitPrice = Convert.ToDecimal(txtNickPerTicketSales.Text.Trim());
                        nickAchieveValue.Updater = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        nickAchieveValue.UpdateDate = DateTime.Now;
                        base.XMNickAchieveValueService.UpdateXMNickAchieveValue(nickAchieveValue);
                    }
                }

            }
            //新增目标设定
            else
            {
                int count = base.XMNickAchieveValueService.GetXMNickAchieveValueListAll(this.NickID, Convert.ToDateTime(txtLogTime.Value.ToString()));
                if (count > 0)
                {
                    base.ShowMessage("该日期下的数据已经存在！");
                    return;
                }
                else
                {
                    XMNickAchieveValue nickAchieveValueAdd = new XMNickAchieveValue();
                    nickAchieveValueAdd.DateTime = DateTime.Parse(txtLogTime.Value.ToString());
                    nickAchieveValueAdd.NickId = this.NickID;
                    nickAchieveValueAdd.SaleCount = Convert.ToInt32(txtArriveSalesNum.Text.Trim());
                    nickAchieveValueAdd.SalePrice = Convert.ToDecimal(txtArriveSalesMoney.Text.Trim());
                    nickAchieveValueAdd.Cost = Convert.ToDecimal(txtCost.Text.Trim());
                    nickAchieveValueAdd.GuestUnitPrice = Convert.ToDecimal(txtNickPerTicketSales.Text.Trim());
                    nickAchieveValueAdd.IsEnable = false;//默认可用 
                    nickAchieveValueAdd.CreateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    nickAchieveValueAdd.CreateDate = DateTime.Now;
                    nickAchieveValueAdd.Updater = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    nickAchieveValueAdd.UpdateDate = DateTime.Now;
                    base.XMNickAchieveValueService.InsertXMNickAchieveValue(nickAchieveValueAdd);
                }
            }
            this.RowEditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }


        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            List<int> IDs = this.Master.GetSelectedIds(this.gvNickTitle);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录");
                return;
            }
            else
            {
                foreach (int ID in IDs)
                {
                    var Info = base.XMNickAchieveValueService.GetXMNickAchieveValueById(Convert.ToInt32(ID));
                    if (Info != null)
                    {
                        Info.IsEnable = true;
                        Info.Updater = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        Info.UpdateDate = DateTime.Now;
                        base.XMNickAchieveValueService.UpdateXMNickAchieveValue(Info);
                    }

                }

                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功成功.");
            }
        }

        public void SetTrigger()
        {
            //this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnIsAudit.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnIsAuditFalse.UniqueID, this.Page);
        }

        public void Face_Init()
        {

        }

        public int RowEditIndex
        {
            get
            {
                int editIndex = -1;
                try
                {
                    int.TryParse(ViewState["RowEditIndex"].ToString(), out editIndex);
                }
                catch
                {
                }
                return editIndex;
            }
            set
            {
                ViewState["RowEditIndex"] = value;
            }
        }

        /// <summary>
        /// 店铺id
        /// </summary>
        public int NickID
        {
            get
            {
                return CommonHelper.QueryStringInt("NickId");
            }
        }


    }
}