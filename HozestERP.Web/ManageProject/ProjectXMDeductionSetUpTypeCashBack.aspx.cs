using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Web.Modules;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{ 

    public partial class ProjectXMDeductionSetUpTypeCashBack : BaseAdministrationPage, ISearchPage
    {
        /// <summary>
        /// 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnEdit", "ProjectXMDeductionSetUpTypeCashBack.Edit");//编辑
                buttons.Add("imgBtnDelete", "ProjectXMDeductionSetUpTypeCashBack.Delete");//删除
                buttons.Add("imgBtnUpdate", "ProjectXMDeductionSetUpTypeCashBack.Save");//保存
                buttons.Add("imgBtnCancel", "ProjectXMDeductionSetUpTypeCashBack.Cancel");//取消    
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
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;

            this.txtProjectName.Text = this.ProjectName;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

            var ddPlatformTypeId = this.ddPlatformTypeId.SelectedValue.ToString();


            var XMDeductionSetUpList = base.XMDeductionSetUpService.SearchXMDeductionSetUp(this.ProjectId, this.SpeciesTypeId, Convert.ToInt32(ddPlatformTypeId), paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            if (this.RowEditIndex == -1)
            {
                //新增编码行
                this.gvProjectXMDeductionSetUpTypeCashBack.EditIndex = XMDeductionSetUpList.Count();
                XMDeductionSetUpList.Add(new XMDeductionSetUp());
            }
            else
            {
                this.gvProjectXMDeductionSetUpTypeCashBack.EditIndex = this.RowEditIndex;
            }
            this.Master.BindData(this.gvProjectXMDeductionSetUpTypeCashBack, XMDeductionSetUpList, paramPageSize + 1);
        }

        #endregion

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
        protected void gvProjectXMDeductionSetUpTypeCashBack_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            if (int.TryParse(this.gvProjectXMDeductionSetUpTypeCashBack.DataKeys[e.RowIndex].Value.ToString(), out Id))
            {
                // 产品信息
                var deductionSetUp = base.XMDeductionSetUpService.GetXMDeductionSetUpById(Id);
                if (deductionSetUp != null)
                {
                    deductionSetUp.IsEnable = true;
                    deductionSetUp.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    deductionSetUp.UpdateDate = DateTime.Now;
                    base.XMDeductionSetUpService.UpdateXMDeductionSetUp(deductionSetUp);
                }
                BindGrid(this.Master.PageIndex, this.Master.PageSize);
                base.ShowMessage("删除成功.");
            }
        }

        protected void gvProjectXMDeductionSetUpTypeCashBack_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        protected void gvProjectXMDeductionSetUpTypeCashBack_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);

            int Id = 0;
            int.TryParse(this.gvProjectXMDeductionSetUpTypeCashBack.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
            var row = this.gvProjectXMDeductionSetUpTypeCashBack.Rows[e.NewEditIndex];
            var xMDeductionSetUp = base.XMDeductionSetUpService.GetXMDeductionSetUpById(Id);

            if (xMDeductionSetUp != null)
            {
                //平台类型
                CodeControl ccPlatformTypeId = (CodeControl)row.FindControl("ccPlatformTypeId");
                ccPlatformTypeId.SelectedValue = xMDeductionSetUp.PlatformTypeId.Value;
                //平台负责人 
                SelectSingleCustomerControl txtPlatformTypePersonId = (SelectSingleCustomerControl)row.FindControl("txtPlatformTypePersonId");
                txtPlatformTypePersonId.SelectSingleCustomer = base.CustomerInfoService.GetCustomerInfoByID(xMDeductionSetUp.PlatformTypePersonId.Value);
                if (txtPlatformTypePersonId.SelectSingleCustomer != null)
                    txtPlatformTypePersonId.Value = txtPlatformTypePersonId.SelectSingleCustomer.FullName;
            }

        }


        /// <summary>
        /// 记录行 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProjectXMDeductionSetUpTypeCashBack_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int paramparse = 0;
            //decimal param = 0;
            if (int.TryParse(this.gvProjectXMDeductionSetUpTypeCashBack.DataKeys[e.RowIndex].Value.ToString(), out paramparse))
            {
                var row = this.gvProjectXMDeductionSetUpTypeCashBack.Rows[e.RowIndex];

                #region 字符验证

                decimal paramparseD = 0;
                //平台类型
                CodeControl ccPlatformTypeId = (CodeControl)row.FindControl("ccPlatformTypeId");
                var hfPlatformTypeId = row.FindControl("hfPlatformTypeId") as HiddenField;

                //扣点
                var txtDeduction = row.FindControl("txtDeduction") as TextBox;
                //财务金额
                var txtFinance = row.FindControl("txtFinance") as TextBox;
                var lblMsgDeductionVaule = row.FindControl("lblMsgDeductionVaule") as Label;
                lblMsgDeductionVaule.Text = "";
                if (txtDeduction.Text.Trim() == "")
                {
                    lblMsgDeductionVaule.Text = "不允许为空";
                }
                if (!decimal.TryParse(txtDeduction.Text.Trim(), out paramparseD))
                {
                    if (txtDeduction.Text.Trim() != "")
                        lblMsgDeductionVaule.Text = "请输入正确的数值";
                }

                //平台负责人
                var txtPlatformTypePersonId = row.FindControl("txtPlatformTypePersonId") as SelectSingleCustomerControl;
                var PlatformTypePersonId = txtPlatformTypePersonId.SelectSingleCustomer.CustomerID;

                //备注
                var txtRemarks = row.FindControl("txtRemarks") as TextBox;


                //|| lblMsgProductColorsVaule.Text != ""
                if (lblMsgDeductionVaule.Text != "")
                {
                    return;
                }

                #endregion


                int QID = Convert.ToInt32(this.gvProjectXMDeductionSetUpTypeCashBack.DataKeys[e.RowIndex].Value.ToString());
                XMDeductionSetUp deductionSetUp = base.XMDeductionSetUpService.GetXMDeductionSetUpById(QID);

                XMDeductionSetUp deductionSetUpNew = base.XMDeductionSetUpService.GetXMDeductionSetUpByProjectAndPlatformTypeId(this.ProjectId,this.SpeciesTypeId, ccPlatformTypeId.SelectedValue);

                //修改
                if (deductionSetUp != null)
                {
                    #region
                    if (deductionSetUpNew != null)
                    {
                        if (!ccPlatformTypeId.SelectedValue.Equals(Convert.ToInt32(hfPlatformTypeId.Value)))
                        {
                            base.ShowMessage(ccPlatformTypeId.text + "平台数据已存在请修改!");
                            return;
                        }
                    }

                    deductionSetUp.ProjectId = this.ProjectId;
                    deductionSetUp.SpeciesTypeId = this.SpeciesTypeId;
                    deductionSetUp.PlatformTypeId = ccPlatformTypeId.SelectedValue;
                    deductionSetUp.PlatformTypePersonId = PlatformTypePersonId;
                    deductionSetUp.Remarks = txtRemarks.Text.Trim();
                    decimal paramparse1 = 0;
                    decimal paramparse3 = 0;

                    #region 数据转换  返现

                    if (decimal.TryParse(txtDeduction.Text.Trim(), out paramparse1))
                    {
                        deductionSetUp.Deduction = Convert.ToDecimal(txtDeduction.Text.Trim());
                    }
                    else
                    {
                        deductionSetUp.Deduction = 0;
                    }

                    if (decimal.TryParse(txtFinance.Text.Trim(), out paramparse3))
                    {
                        if(paramparse3<= paramparse1)
                        {
                            ShowMessage("财务限额必须大于项目限额！");
                            return;
                        }
                        deductionSetUp.Finance = paramparse3;
                    }
                    else
                    {
                        deductionSetUp.Finance = 0;
                    }
                    #endregion

                    deductionSetUp.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    deductionSetUp.UpdateDate = DateTime.Now;
                    //修改扣点信息
                    base.XMDeductionSetUpService.UpdateXMDeductionSetUp(deductionSetUp);

                    #endregion
                }
                // 新增
                else
                {
                    if (deductionSetUpNew != null)
                    {
                        base.ShowMessage(ccPlatformTypeId.text + "平台数据已存在请修改!");
                        return;
                    }
                    XMDeductionSetUp XMDeductionSetUpNew = new XMDeductionSetUp();
                    XMDeductionSetUpNew.ProjectId = this.ProjectId;
                    XMDeductionSetUpNew.SpeciesTypeId = this.SpeciesTypeId;
                    XMDeductionSetUpNew.PlatformTypeId = ccPlatformTypeId.SelectedValue;
                    XMDeductionSetUpNew.PlatformTypePersonId = PlatformTypePersonId;
                    XMDeductionSetUpNew.Remarks = txtRemarks.Text.Trim();
                    decimal paramparse2 = 0;
                    decimal paramparse4 = 0;

                    #region 数据转换  返现

                    if (decimal.TryParse(txtDeduction.Text.Trim(), out paramparse2))
                    {
                        XMDeductionSetUpNew.Deduction = Convert.ToDecimal(txtDeduction.Text.Trim());
                    }
                    else
                    {
                        XMDeductionSetUpNew.Deduction = 0;
                    }

                    if (decimal.TryParse(txtFinance.Text.Trim(), out paramparse4))
                    {
                        if (paramparse4 <= paramparse2)
                        {
                            ShowMessage("财务限额必须大于项目限额！");
                            return;
                        }
                        XMDeductionSetUpNew.Finance = paramparse4;
                    }
                    else
                    {
                        XMDeductionSetUpNew.Finance = 0;
                    }
                    #endregion

                    XMDeductionSetUpNew.IsEnable = false;//默认可用
                    XMDeductionSetUpNew.CreateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    XMDeductionSetUpNew.CreateDate = DateTime.Now;
                    XMDeductionSetUpNew.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                    XMDeductionSetUpNew.UpdateDate = DateTime.Now;
                    //新增扣点
                    base.XMDeductionSetUpService.InsertXMDeductionSetUp(XMDeductionSetUpNew);
                }
                this.RowEditIndex = -1;
                this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
            }
        }


        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProjectXMDeductionSetUpTypeCashBack_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == DataControlRowState.Edit ||
                e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                //项目名称
                Label lblProjesctName = e.Row.FindControl("lblProjesctName") as Label;
                if (lblProjesctName != null)
                {
                    lblProjesctName.Text = this.ProjectName;
                }

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var deductionSetUp = (XMDeductionSetUp)e.Row.DataItem;

                //项目名称
                Label lblProjesctNameI = e.Row.FindControl("lblProjesctNameI") as Label;
                if (lblProjesctNameI != null)
                {
                    lblProjesctNameI.Text = this.ProjectName;
                }


            }
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
        /// 项目Id
        /// </summary>
        public int ProjectId
        {
            get
            {
                return CommonHelper.QueryStringInt("ProjectId");
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get
            {
                return CommonHelper.QueryString("ProjectName");
            }
        }


        /// <summary>
        /// 类型  ：476 返现设置
        /// </summary>
        public int SpeciesTypeId
        {
            get
            {
                return CommonHelper.QueryStringInt("SpeciesTypeId");
            }
        }


    }
}