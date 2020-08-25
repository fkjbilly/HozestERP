using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CRM.BusinessLogic.ManageContract;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.Web;

namespace HozestERP.Web.ManageProject
{
    public partial class XMLogisticsInfoList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid(1, Master.PageSize);
            }
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var logisticList = base.XMLogisticsInfoService.GetXMLogisticsInfoListByOrderInfoID(this.XMOrderInfoID);
            var logisticPageList = new PagedList<XMLogisticsInfo>(logisticList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            if (this.RowEditIndex == -1)
            {
                this.gvLogistic.EditIndex = logisticPageList.Count();
                logisticPageList.Add(new XMLogisticsInfo());
            }
            else
            {
                this.gvLogistic.EditIndex = this.RowEditIndex;
            }
            this.Master.BindData(this.gvLogistic, logisticPageList, paramPageSize + 1);
        }

        protected void gvLogistic_RowCreated(object sender, GridViewRowEventArgs e)
        {
            var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(XMOrderInfoID);
            if (OrderInfo.PlatformTypeId != 259)
            {
                e.Row.Cells[5].Visible = false;//guid列的隐藏
            }
        }

        protected void gvLogistic_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == DataControlRowState.Edit ||
               e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                TextBox txtLogisticCompanyName = e.Row.FindControl("txtLogisticCompany") as TextBox;
                //如果未填写物流公司名称默认从订单备注中获取
                if (txtLogisticCompanyName.Text == "")
                {
                    var orderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(XMOrderInfoID);
                    if (orderInfo != null && orderInfo.CustomerServiceRemark != null && orderInfo.CustomerServiceRemark != "")
                    {
                        if (orderInfo.CustomerServiceRemark.Length > 0)
                        {
                            int index = orderInfo.CustomerServiceRemark.IndexOf("/");
                            if (index > -1 && index != 0)
                            {
                                txtLogisticCompanyName.Text = orderInfo.CustomerServiceRemark.Substring(0, index);
                            }
                        }
                    }
                }
            }
        }

        protected void gvLogistic_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void gvLogistic_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id = 0;
            int.TryParse(this.gvLogistic.DataKeys[e.RowIndex].Value.ToString(), out Id);
            var row = this.gvLogistic.Rows[e.RowIndex];
            HtmlInputText txtLogisticTime = row.FindControl("txtLogisticTime") as HtmlInputText;
            TextBox txtLogisticNumber = row.FindControl("txtLogisticNumber") as TextBox;
            TextBox txtLogisticCompany = row.FindControl("txtLogisticCompany") as TextBox;
            TextBox txtNote = row.FindControl("txtNote") as TextBox;
            if (txtLogisticTime.Value.ToString() == "")
            {
                base.ShowMessage("必须填写物流时间！");
                return;
            }
            if (txtLogisticNumber.Text.ToString() == "")
            {
                base.ShowMessage("必须填写物流单号!");
                return;
            }
            if (txtLogisticCompany.Text.ToString() == "")
            {
                base.ShowMessage("必须填写物流公司！");
                return;
            }
            var Info = base.XMLogisticsInfoService.GetXMLogisticsInfoById(Id);
            if (Info != null)                                 //更新数据
            {
                Info.LogisticsDate = Convert.ToDateTime(txtLogisticTime.Value.ToString());
                Info.LogisticsNumber = txtLogisticNumber.Text.Trim();
                Info.LogisticsCompany = txtLogisticCompany.Text.Trim();
                Info.Note = txtNote.Text.Trim();
                Info.UpdateTime = DateTime.Now;
                Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMLogisticsInfoService.UpdateXMLogisticsInfo(Info);
            }
            else                                               //新增数据
            {
                XMLogisticsInfo logisticInfo = new XMLogisticsInfo();
                logisticInfo.OrderInfoID = XMOrderInfoID;
                logisticInfo.LogisticsDate = Convert.ToDateTime(txtLogisticTime.Value.ToString());
                logisticInfo.LogisticsNumber = txtLogisticNumber.Text.Trim();
                logisticInfo.LogisticsCompany = txtLogisticCompany.Text.Trim();
                logisticInfo.Note = txtNote.Text.Trim();
                logisticInfo.CreateDate = DateTime.Now;
                logisticInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                logisticInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                logisticInfo.UpdateTime = DateTime.Now;
                logisticInfo.IsEnable = false;
                base.XMLogisticsInfoService.InsertXMLogisticsInfo(logisticInfo);
            }
            this.RowEditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void gvLogistic_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void gvLogistic_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvLogistic.DataKeys[e.RowIndex].Value);//获得要删除行的id
            var xmlogisticInfo = base.XMLogisticsInfoService.GetXMLogisticsInfoById(id);
            if (xmlogisticInfo != null)//删除
            {
                xmlogisticInfo.IsEnable = true;
                xmlogisticInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                xmlogisticInfo.UpdateTime = DateTime.Now;
                base.XMLogisticsInfoService.UpdateXMLogisticsInfo(xmlogisticInfo);
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("操作成功.");
            }
        }

        #region ISearchPage 成员
        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;
        }
        #endregion

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
        /// 订单id
        /// </summary>
        public int XMOrderInfoID
        {
            get
            {
                return CommonHelper.QueryStringInt("ID");
            }
        }
    }
}