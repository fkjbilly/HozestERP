using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using System.Web.UI.HtmlControls;

namespace HozestERP.Web.ManageProject
{
    public partial class XMNickAdvertisingCost : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["isEdit"] = 0;
                //默认查询开始时间
                txtLogStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
                //默认查询结束时间
                txtLogEndTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                string nickname = string.Empty;
                var nick = base.XMNickService.GetXMNickByID(this.NickID);
                if (nick != null)
                {
                    nickname = nick.nick;
                }
                btnSetAdvertingFields.OnClientClick = "return ShowWindowDetail('" + nickname + "广告费字段设置', '" + CommonHelper.GetStoreLocation()
                               + "ManageProject/XMNickSetAdvertingField.aspx?NickId=" + this.NickID + "&&StartTime=" + txtLogStartTime.Value + "&&EndTime=" + txtLogEndTime.Value
                               + "&rnd=' + Math.round(), 600, 300, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";
                this.BindGrid(1, Master.PageSize);
            }
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            if (string.IsNullOrEmpty(txtLogStartTime.Value) || string.IsNullOrEmpty(txtLogEndTime.Value))
            {
                base.ShowMessage("请选择开始时间和结束时间！");
                return;
            }
            if (Convert.ToDateTime(txtLogStartTime.Value) > Convert.ToDateTime(txtLogEndTime.Value))
            {
                base.ShowMessage("开始日期不能大于结束日期，请重新选择！");
                return;
            }
            var nickField = base.XMNickIncludeAdveringFieldService.GetXMNickIncludeAdvertingFieldByNickID(this.NickID);
            if (nickField == null)
            {
                base.ShowMessage("请先设置广告费字段！");
                return;
            }
            //默认插入相关数据
            string min = txtLogStartTime.Value;
            string max = txtLogEndTime.Value;
            string nid = this.NickID.ToString();
            DateTime minDate = DateTime.Parse(min);
            DateTime maxDate = DateTime.Parse(max);
            TimeSpan ts = maxDate - minDate;
            var XMAdvertisingFeeList = base.XMAdvertisingFeeService.GetXMAdvertisingFeeList();
            if (!string.IsNullOrEmpty(nid))
            {
                XMAdvertisingFeeList = XMAdvertisingFeeList.Where(p => p.NickId == Convert.ToInt16(nid) && p.Feedate >= minDate && p.Feedate <= maxDate).ToList();
            }
            var iminDate = minDate;
            if (XMAdvertisingFeeList.Count < (ts.Days + 1))
            {
                while (iminDate <= maxDate)
                {
                    var tj = base.XMAdvertisingFeeService.GetXMByIdmin(this.NickID, iminDate);
                    if (tj.Count == 0)
                    {
                        XMAdvertisingFee ps = new XMAdvertisingFee();
                        ps.NickId = Convert.ToInt32(nid);
                        ps.Feedate = iminDate;
                        ps.Fee = 0;
                        ps.CreatorID = HozestERPContext.Current.User.CustomerID;
                        ps.CreatorTime = DateTime.Now;
                        ps.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        ps.UpdateTime = DateTime.Now;
                        base.XMAdvertisingFeeService.InsertXMAdvertisingFee(ps);
                        //插入从表数据
                        InsertAdvertingFeeDetailData(ps.Id);
                    }
                    iminDate = iminDate.AddDays(1);
                }
            }
            if ((int)Session["isEdit"] == 1)
            {
                //更新主表fee字段数值
                UpdateAdvertingFieldData(nid);
            }
            var newList = base.XMAdvertisingFeeService.GetXMAdvertisingFeeList().Where(p => p.NickId == Convert.ToInt16(nid) && p.Feedate >= minDate && p.Feedate <= maxDate).ToList();
            var pageList = new PagedList<XMAdvertisingFee>(newList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvCWPlatformSpendingDetails, pageList);
        }
        /// <summary>
        /// 如更新字段后，更新主表fee数据
        /// </summary>
        /// <param name="nickID"></param>
        private void UpdateAdvertingFieldData(string nickID)
        {
            string[] parm = null;
            decimal total = 0;
            var c = base.XMNickIncludeAdveringFieldService.GetXMNickIncludeAdvertingFieldByNickID(int.Parse(nickID));
            if (c != null)
            {
                parm = c.Fields.Split(',');
            }
            if (parm == null)
            {
                return;
            }
            var XMAdvertisingFeeList = base.XMAdvertisingFeeService.GetXMXMAdvertisingFeeByParm(int.Parse(nickID));
            if (XMAdvertisingFeeList != null)
            {
                foreach (XMAdvertisingFee f in XMAdvertisingFeeList)
                {
                    total = 0;
                    foreach (string str in parm)
                    {
                        var detail = base.XMAdvertisingFeeDetailService.GetXMAdvertisingFeeDetailByAdvertingFeeIdAndFieldID(f.Id, int.Parse(str));
                        if (detail != null)
                        {
                            //更新主表fee字段数据
                            total += detail.Cost;
                        }
                    }
                    if (f.Fee != total)
                    {
                        f.Fee = total;
                        f.UpdateTime = DateTime.Now;
                        f.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        base.XMAdvertisingFeeService.UpdateXMAdvertisingFee(f);
                    }
                }
            }
        }

        private void InsertAdvertingFeeDetailData(int advertingFeeId)
        {
            string[] parm = null;
            //获取店铺所属字段字符串
            int nickid = !string.IsNullOrEmpty(this.NickID.ToString()) ? this.NickID : 0;
            if (nickid != 0)
            {
                var field = base.XMNickIncludeAdveringFieldService.GetXMNickIncludeAdvertingFieldByNickID(nickid);
                if (field != null && field.Fields != null)
                {
                    parm = field.Fields.Split(',');
                    foreach (string str in parm)
                    {
                        //新增从表数据
                        XMAdvertisingFeeDetail detail = new XMAdvertisingFeeDetail();
                        detail.AdvertingFeeId = advertingFeeId;
                        detail.FieldId = int.Parse(str);
                        detail.Cost = 0;
                        detail.CreateDate = DateTime.Now;
                        detail.CreateID = HozestERPContext.Current.User.CustomerID;
                        detail.UpdateDate = DateTime.Now;
                        detail.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMAdvertisingFeeDetailService.InsertXMAdvertisingFeeDetail(detail);
                    }
                }
            }
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvCWPlatformSpendingDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //主键值
                int id = Convert.ToInt16(grdvCWPlatformSpendingDetails.DataKeys[e.Row.RowIndex].Value);
                string nickname = string.Empty;
                var nick = base.XMNickService.GetXMNickByID(this.NickID);
                if (nick != null)
                {
                    nickname = nick.nick;
                }
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('" + nickname + "广告费用明细修改','" + CommonHelper.GetStoreLocation() +
      "ManageProject/XMNickAdvertingCostDetail.aspx?Id=" + id
      + "',600,350, this,function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
                }
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
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }




        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        #endregion


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