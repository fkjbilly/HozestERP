using System;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageInventory
{
    public partial class XMActivtyTypeInfo : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.btnActivityTypeAdd.OnClientClick = "return ShowWindowDetail('新增活动类型','" + CommonHelper.GetStoreLocation() +
"ManageInventory/XMActivityTypeAdd.aspx?Type=0"
+ "',500,300, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                this.BindGrid(1, Master.PageSize);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string activityName = txtActivityType.Text.Trim();
            var list = base.XMActivityTypeService.GetXMActivityTypeInfoByParm(activityName);
            var nickPageList = new PagedList<XMActivityType>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvActivityType, nickPageList, paramPageSize + 1);
        }

        public string CustomerName(string customerID)
        {
            string name = "";
            var customer = base.CustomerInfoService.GetCustomerInfoByID(Convert.ToInt16(customerID));
            if (customer != null)
            {
                name = customer.FullName;
            }
            return name;
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvActivityType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMActivityType;
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('活动类型修改','" + CommonHelper.GetStoreLocation() +
            "ManageInventory/XMActivityTypeAdd.aspx?Id=" + info.Id + "&&Type=1"
            + "',500,300, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
            }
        }

        protected void grdvActivityType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                var id = e.CommandArgument.ToString();
                var info = base.XMActivityTypeService.GetXMActivityTypeById(int.Parse(id));
                if (!string.IsNullOrEmpty(id))//删除
                {
                    //判断活动类型是否在销售活动中已被使用  如已被使用将无法删除
                    var activities = XMActivityService.GetXMActivityListByactivityTypeID(int.Parse(id));
                    if (activities != null && activities.Count > 0)
                    {
                        base.ShowMessage("活动类型[" + info.ActivityName + "] 在销售活动中已经被使用，无法删除！");
                        return;
                    }
                    if (info != null)
                    {
                        info.IsEnale = true;
                        info.UpdateDate = DateTime.Now;
                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMActivityTypeService.UpdateXMActivityType(info);
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
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

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