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

namespace HozestERP.Web.ManageFinance
{

    public partial class XWAdvertisingSS : BaseAdministrationPage, ISearchPage
    {
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnCountMoneySave", "ManageFinance.CWPlatformSpendingDetails.save2");//问题处理 
                return buttons;
            }
        }
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
        }

        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;
        }

        //根据id查询店铺名称
        protected string selectnick(int nickid)
        {
            string nick = "";
            var nicklist = base.XMNickService.GetXMNickByID(nickid);
            if (nicklist != null)
            {
                nick = nicklist.nick;
            }
            return nick;
        }
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            //根据项目店铺查询广告费用 项目说明
            string min = this.DateTimeMin.ToString();
            string max = DateTime.Parse(this.DateTimeMax).AddDays(1).AddSeconds(-1).ToString();
            string pid = this.ProjectId.ToString();
            string nid = this.NickId.ToString();
            TimeSpan ts = DateTime.Parse(this.DateTimeMax) -  DateTime.Parse(this.DateTimeMin);
            //店铺集合
            List<int> nickIdList = new List<int>();
            #region 店铺条件查询集合 处理
            //选择某项目  
            if (pid != "-1")
            {
                if (nid == "-1")//项目下的所有店铺
                {
                    var nickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(pid), 362);

                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    if (nickList.Count > 0)
                    {
                        nickIdList = nickList.Select(p => p.nick_id).ToList();
                    }
                }
                else
                {

                    nickIdList.Add(Convert.ToInt32(nid));
                }
            }
            else
            {
                if (nid == "-1")
                {
                    var NickList = base.XMNickService.GetXMNickListByProjectId(Convert.ToInt32(pid), 362);

                    //var NickListNew = NickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();

                    nickIdList = NickList.Select(a => a.nick_id).ToList();
                }
                else
                {
                    nickIdList.Add(Convert.ToInt32(nid));
                }

            }
            #endregion
            var XMAdvertisingFeeList = base.XMAdvertisingFeeService.GetXMXMAdvertisingFeeByDetails(nickIdList, DateTime.Parse(min), DateTime.Parse(max));

            if (XMAdvertisingFeeList.Count == 0 || (ts.Days * nickIdList.Count) > XMAdvertisingFeeList.Count)
            {
                foreach (var b in nickIdList)
                {
                    var imin = min;
                    while (DateTime.Parse(imin) <= DateTime.Parse(max))
                    {
                        var tj2 = base.XMAdvertisingFeeService.GetXMByIdmin(0, DateTime.Parse(imin));
                        if (tj2.Count != nickIdList.Count)
                        {
                            var tj = base.XMAdvertisingFeeService.GetXMByIdmin(b, DateTime.Parse(imin));
                            if (tj.Count == 0)
                            {
                                XMAdvertisingFee ps = new XMAdvertisingFee();
                                ps.NickId = Convert.ToInt32(b);
                                ps.Feedate = DateTime.Parse(imin);
                                ps.Fee = 0;
                                ps.CreatorID = HozestERPContext.Current.User.CustomerID;
                                ps.CreatorTime = DateTime.Now;
                                ps.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                ps.UpdateTime = DateTime.Now;
                                base.XMAdvertisingFeeService.InsertXMAdvertisingFee(ps);
                            }
                        }
                        imin = DateTime.Parse(imin).AddDays(1).ToString();
                    }

                }
                XMAdvertisingFeeList = base.XMAdvertisingFeeService.GetXMXMAdvertisingFeeByDetails(nickIdList, DateTime.Parse(min), DateTime.Parse(max));
            }
            var pageList = new PagedList<XMAdvertisingFee>(XMAdvertisingFeeList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            this.Master.BindData(this.grdvCWPlatformSpendingDetails, pageList);
        }

    
        #endregion

         

        protected void grdvCWPlatformSpendingDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
              
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                // #region 平台名称

                //Label lblPlatformName = e.Row.FindControl("lblPlatformName") as Label;
                //List<CodeList> codeList = base.CodeService.GetCodeList(Convert.ToInt32(this.PlatformTypeId));
                //if (codeList.Count > 0)
                //{
                //    if (lblPlatformName != null)
                //    {
                //        lblPlatformName.Text = codeList[0].CodeName;
                //    }
                //}
                //#endregion

                 
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
                        //显示保存按钮
                        //imgBtnCountMoneySave.Visible = true;
                }

            }
        }

        /// <summary>
        /// 保存金额 列 
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
                HiddenField hdPSId = item.FindControl("hdPSId") as HiddenField;
                //平台项目Id
                string Id = grdvCWPlatformSpendingDetails.DataKeys[item.RowIndex].Values[0].ToString();
                if (txtCountMoney.Text.Trim() != "")
                {
                    if (hdPSId != null)
                    {

                        if (hdPSId.Value != "")
                        {
                            var CWps = base.XMAdvertisingFeeService.GetXMAdvertisingFeeById(Convert.ToInt32(hdPSId.Value));
                            if (CWps != null)
                            {
                                isEdit = true;
                                CWps.Fee = Convert.ToDecimal(txtCountMoney.Text);
                                CWps.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                CWps.UpdateTime = DateTime.Now;
                                base.XMAdvertisingFeeService.UpdateXMAdvertisingFee(CWps);
                            }
                        }
                        //else
                        //{
                        //    isEdit = true;
                        //    CWPlatformSpending ps = new CWPlatformSpending();
                        //    ps.PlatformTypeId = this.PlatformTypeId;
                        //    ps.ProfitProjectId = Convert.ToInt32(Id);
                        //    ps.YearStr = DateTime.Now.Year.ToString();
                        //    ps.MonthStr = DateTime.Now.Month.ToString();
                        //    ps.CountMoney = Convert.ToDecimal(txtCountMoney.Text);
                        //    ps.Remark = txtRemark.Text;
                        //    ps.IsEnable = false;
                        //    ps.CreateID = HozestERPContext.Current.User.CustomerID;
                        //    ps.CreateDateTime = DateTime.Now;
                        //    ps.UpdateID = HozestERPContext.Current.User.CustomerID;
                        //    ps.UpdateDateTime = DateTime.Now;
                        //    base.CWPlatformSpendingService.InsertCWPlatformSpending(ps);
                        //}

                    }

                }

            }
            if (isEdit)
                base.ShowMessage("保存成功!");
            BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectId
        {
            get
            {
                return CommonHelper.QueryStringInt("ProjectId");
            }
        }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int NickId
        {
            get
            {
                return CommonHelper.QueryStringInt("NickId");
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string DateTimeMin
        {
            get
            {
                return CommonHelper.QueryString("DateTimeMin");
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string DateTimeMax
        {
            get
            {
                return CommonHelper.QueryString("DateTimeMax");
            }
        }

    }
}