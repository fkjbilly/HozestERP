using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageFinance
{ 
     
    public partial class CWPlatformSpendingDetailsSS : BaseAdministrationPage, ISearchPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //List<CodeList> codeList = base.CodeService.GetCodeList(Convert.ToInt32(this.PlatformTypeId));
                //if (codeList.Count > 0)
                //{
                //    this.lblExplanationValue.Text = codeList[0].CodeName + "平台数据录入.";
                //}
                //    //如有选平台 异常说明控件
                    
                //    this.lblExplanationValue.Visible = true;

                
                this.BindGrid(1, Master.PageSize);
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

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            #region 时间


            #endregion
            //店铺集合
            List<int> nickIdList = new List<int>();
            if (ProjectTypeId != "-1")
            {
                if (NickId == "-1")//项目下的所有店铺
                {
                    var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ProjectNameId), Convert.ToInt32(this.ProjectTypeId));

                    //var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    if (nickList.Count > 0)
                    {
                        nickIdList = nickList.Select(p => p.nick_id).ToList();
                    }
                }
                else
                {

                    nickIdList.Add(Convert.ToInt32(NickId));
                }
            }
            else
            {
                if (NickId == "-1")
                {
                    var NickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(this.ProjectNameId), Convert.ToInt32(this.ProjectTypeId));

                    // var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    nickIdList = NickList.Select(a => a.nick_id).ToList();
                }
                else
                {
                    nickIdList.Add(Convert.ToInt32(NickId));
                }

            }
            //根据平台查询 项目说明

            //List<int> ProjectId= base.CWProjectService.GetCWProjectByParentID(this.PlatformTypeId).Select(p=>p.Id).ToList();

            //var CWPlatformSpendingList = base.CWPlatformSpendingService.GetCWPlatformSpendingList(ProjectId, min,max);
            string amin = min;
            if (min == "")
            {
                amin = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + "01";
            }
            string amax = max;
            if (max == "")
            {
                amax = DateTime.Now.ToString();
            }
            else 
            {
                amax = DateTime.Parse(max).AddDays(1).AddSeconds(-1).ToString();
            }
            var CWPlatformSpendingList = base.XMOrderInfoService.GetCWPlatformSpendingSearchListSSS2(Convert.ToInt32(PlatformTypeId), nickIdList, DateTime.Parse(amin), DateTime.Parse(amax), Convert.ToInt32(OrderStatusId));
            //List<OrderInfoSalesDetails> CWPlatformSpendingList2 = CWPlatformSpendingList.GroupBy(p => new { p.PlatformTypeId, p.Remarks })
            //    .OrderByDescending(g => g.Sum(t => t.PayPrice))
            //    .Select(p => new { 
            //        Price=p.Sum(t => t.PayPrice),
            //        PlatformTypeId = p.Key.PlatformTypeId,
            //        Remarks = p.Key.Remarks
            //    });

            var pageList = new PagedList<OrderInfoSalesDetails>(CWPlatformSpendingList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            this.Master.BindData(this.grdvCWPlatformSpendingDetails, pageList);
        }

    
        #endregion

         

        protected void grdvCWPlatformSpendingDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
              
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                 #region 平台名称

                Label lblPlatformName = e.Row.FindControl("lblPlatformName") as Label;
                List<CodeList> codeList = base.CodeService.GetCodeList(Convert.ToInt32(this.PlatformTypeId));
                if (codeList.Count > 0)
                {
                    if (lblPlatformName != null)
                    {
                        lblPlatformName.Text = codeList[0].CodeName;
                    }
                }
                #endregion

                 
            }

            if (e.Row.RowState == DataControlRowState.Edit ||
               e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            { 
           
            }

        }
        /// <summary>
        /// 平台类型
        /// </summary>
        public int PlatformTypeId
        {
            get
            {
                return CommonHelper.QueryStringInt("PlatformTypeId");
            }
        }

        /// <summary>
        /// 店铺Id
        /// </summary>
        public string NickId
        {
            get
            {
                return CommonHelper.QueryString("NickId");
            }
        }

        /// <summary>
        /// 时间类型
        /// </summary>
        public string OrderStatusId
        {
            get
            {
                return CommonHelper.QueryString("OrderStatusId");
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string min
        {
            get
            {
                return CommonHelper.QueryString("min");
                //return min;
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string max
        {
            get
            {
                return CommonHelper.QueryString("max");
                //return max;
            }
        }

        /// <summary>
        /// 项目类型
        /// </summary>
        public string ProjectTypeId
        {
            get
            {
                return CommonHelper.QueryString("ProjectTypeId");
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectNameId
        {
            get
            {
                return CommonHelper.QueryString("ProjectNameId");
            }
        }

    }
}