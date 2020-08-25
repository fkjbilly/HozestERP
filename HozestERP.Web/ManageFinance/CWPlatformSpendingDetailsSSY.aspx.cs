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

namespace HozestERP.Web.ManageFinance
{ 
     
    public partial class CWPlatformSpendingDetailsSSY : BaseAdministrationPage, ISearchPage
    {
        //protected override Dictionary<string, string> ButtonSecuritys
        //{
        //    get
        //    {
        //        Dictionary<string, string> buttons = new Dictionary<string, string>();
        //        buttons.Add("imgBtnCountMoneySave", "ManageFinance.CWPlatformSpendingDetails.save");//问题处理 
        //        return buttons;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //未选择平台 提示选平台
                if (PlatformTypeId == -1)
                {
                     
                    this.lblExplanationValue.Text = "请选择平台.";
                }
                else
                {
                     List<CodeList> codeList = base.CodeService.GetCodeList(Convert.ToInt32(this.PlatformTypeId));
                if (codeList.Count > 0)
                {
                    this.lblExplanationValue.Text = codeList[0].CodeName + "平台数据录入.";
                }
                    //如有选平台 异常说明控件
                    
                    this.lblExplanationValue.Visible = true;

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
            this.Master.SetTitleVisible = false;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            //根据平台查询 项目说明
            string year = this.DateTimeYear.ToString();
            string month = this.DateTimeId.ToString();
            List<int> ProjectId= base.CWProjectService.GetCWProjectByParentID(this.PlatformTypeId).Select(p=>p.Id).ToList();

            var CWPlatformSpendingList = base.CWPlatformSpendingService.GetCWPlatformSpendingList(ProjectId, year, month);

            if (CWPlatformSpendingList.Count == 0 && this.DateTimeId == DateTime.Now.Month.ToString() && this.DateTimeYear == DateTime.Now.Year.ToString())
            {
                var projectID = base.CWProjectService.GetCWProjectListByParentID(this.PlatformTypeId);
                if (projectID.Count > 0)
                {
                    foreach (var b in projectID)
                    {
                        var insrlist = base.CWProjectService.GetCWProjectListByParentID(b.Id);
                        if (insrlist.Count > 0)
                        {
                            foreach (var a in insrlist)
                            {
                                CWPlatformSpending ps = new CWPlatformSpending();
                                ps.PlatformTypeId = this.PlatformTypeId;
                                ps.ProfitProjectId = Convert.ToInt32(a.Id);
                                ps.YearStr = DateTime.Now.Year.ToString();
                                ps.MonthStr = DateTime.Now.Month.ToString();
                                ps.CountMoney = 0;
                                ps.Remark = "";
                                ps.IsEnable = false;
                                ps.CreateID = HozestERPContext.Current.User.CustomerID;
                                ps.CreateDateTime = DateTime.Now;
                                ps.UpdateID = HozestERPContext.Current.User.CustomerID;
                                ps.UpdateDateTime = DateTime.Now;
                                base.CWPlatformSpendingService.InsertCWPlatformSpending(ps);
                            }
                        }
                    }
                }

                CWPlatformSpendingList = base.CWPlatformSpendingService.GetCWPlatformSpendingList(ProjectId, year, month);
            }
            var pageList = new PagedList<CWPlatformSpendingMapping>(CWPlatformSpendingList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

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

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ImageButton imgBtnCountMoneySave = e.Row.FindControl("imgBtnCountMoneySave") as ImageButton;
                if (imgBtnCountMoneySave != null)
                {
                    if (this.DateTimeId == DateTime.Now.Month.ToString() && this.DateTimeYear == DateTime.Now.Year.ToString())
                    {
                        //显示保存按钮
                        imgBtnCountMoneySave.Visible = true;
                    }
                    else
                    {
                        //隐藏编辑按钮
                        imgBtnCountMoneySave.Visible = false;
                    }
                }

            }
        }

        /// <summary>
        /// 保存金额、备注 列 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgBtnCountMoneySave_Click(object sender, EventArgs e)
        {
            #region 字符验证
            int errorcount = 0;
            //循环所有行
            foreach (GridViewRow msgReach in grdvCWPlatformSpendingDetails.Rows)
            {

                TextBox txtCountMoney = msgReach.FindControl("txtCountMoney") as TextBox;

                Label lblMsgCountMoneyVaule = msgReach.FindControl("lblMsgCountMoneyVaule") as Label;  

                TextBox txtRemark = msgReach.FindControl("txtRemark") as TextBox; 

                decimal i = 0;  
                if (txtCountMoney.Text.Trim() != "")
                {
                    lblMsgCountMoneyVaule.Text = "";
                    if (!decimal.TryParse(txtCountMoney.Text.Trim(), out  i))
                    {
                        lblMsgCountMoneyVaule.Text = "请输入数字类型.";
                        lblMsgCountMoneyVaule.Visible = true;
                        errorcount++;
                    } 
                }
                 
            }
            if (errorcount > 0)
            {
                return;
            }
            #endregion

            bool isEdit = false;
            //循环grid 每行 
            foreach (GridViewRow item in grdvCWPlatformSpendingDetails.Rows)
            {
                 
                    TextBox txtCountMoney = item.FindControl("txtCountMoney") as TextBox; 
                    TextBox txtRemark = item.FindControl("txtRemark") as TextBox;
                    HiddenField hdPSId = item.FindControl("hdPSId") as HiddenField;
                    //平台项目Id
                    string Id = grdvCWPlatformSpendingDetails.DataKeys[item.RowIndex].Values[0].ToString();
                    if (txtCountMoney.Text.Trim() != "" )
                    {
                        if (hdPSId != null) {

                            if (hdPSId.Value != "")
                            {
                                var CWps = base.CWPlatformSpendingService.GetCWPlatformSpendingById(Convert.ToInt32(hdPSId.Value));
                                if (CWps != null)
                                {
                                    isEdit = true;
                                    CWps.PlatformTypeId = this.PlatformTypeId;
                                    CWps.ProfitProjectId = Convert.ToInt32(Id);
                                    CWps.YearStr = DateTime.Now.Year.ToString();
                                    CWps.MonthStr = DateTime.Now.Month.ToString();
                                    CWps.CountMoney = Convert.ToDecimal(txtCountMoney.Text);
                                    CWps.Remark = txtRemark.Text;
                                    CWps.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    CWps.UpdateDateTime = DateTime.Now;
                                     base.CWPlatformSpendingService.UpdateCWPlatformSpending(CWps); 
                                }  
                            }
                            else {
                                isEdit = true;
                                CWPlatformSpending ps = new CWPlatformSpending();
                                ps.PlatformTypeId = this.PlatformTypeId;
                                ps.ProfitProjectId =Convert.ToInt32( Id);
                                ps.YearStr = DateTime.Now.Year.ToString();
                                ps.MonthStr = DateTime.Now.Month.ToString();
                                ps.CountMoney = Convert.ToDecimal(txtCountMoney.Text);
                                ps.Remark = txtRemark.Text;
                                ps.IsEnable = false;
                                ps.CreateID = HozestERPContext.Current.User.CustomerID;
                                ps.CreateDateTime = DateTime.Now;
                                ps.UpdateID = HozestERPContext.Current.User.CustomerID;
                                ps.UpdateDateTime = DateTime.Now;
                                base.CWPlatformSpendingService.InsertCWPlatformSpending(ps);
                            }
                        
                        } 
                        
                    }
                
            }
            if (isEdit)
                base.ShowMessage("保存成功!");
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
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
        /// 月份
        /// </summary>
        public string DateTimeId
        {
            get
            {
                return CommonHelper.QueryString("DateTimeId");
            }
        }

        /// <summary>
        /// 年份
        /// </summary>
        public string DateTimeYear
        {
            get
            {
                return CommonHelper.QueryString("DateTimeYear");
            }
        }

    }
}