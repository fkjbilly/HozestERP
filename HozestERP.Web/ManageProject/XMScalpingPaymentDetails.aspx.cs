using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageProject
{  
    public partial class XMScalpingPaymentDetails : BaseAdministrationPage, ISearchPage
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //根据刷单申请Id查询 刷单申请记录
               var xMScalpingApplication=  base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(this.ScalpingId);
                 
               if (xMScalpingApplication != null) { 
                   this.txtScalpingCode.Text = xMScalpingApplication.ScalpingCode;
               }
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {  
        }

        public void Face_Init()
        { 
            this.Master.SetTitle("刷单单号订单回款明细"); 
        }


        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //根据刷单单号Id查询  刷单记录
            var scalpingList=  base.XMScalpingService.GetXMScalpingByScalpingId(this.ScalpingId);
           //把List转PageLsit
            var pageList = new PagedList<XMScalping>(scalpingList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            //数据源绑定
            this.Master.BindData(this.grdXMScalpingPaymentDetails, pageList, paramPageSize + 1);
             
        }
         
        #endregion

        protected void grdXMScalpingPaymentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var XMScalping = e.Row.DataItem as XMScalping;
                //查看详情 
                if (XMScalping.IsAbnormal != null)
                {
                    if (XMScalping.IsAbnormal.Value == true)
                    {
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[2].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[3].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[4].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[9].BackColor = System.Drawing.Color.Red; 
                    }
                }

            } 

        }  
         
        //刷单单号Id
        public int ScalpingId
        {
            get
            {
                return Convert.ToInt32(Request.Params["ScalpingId"]);
            }
        }  


    }
}