using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageFinance
{
    public partial class OpenProfitOtherDataInput : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string departmentName = "";
                if (DepartmentType == "197")
                {
                    departmentName = "B2C服务部";
                }
                else if (DepartmentType == "6")
                {
                    departmentName = "B2B事业部";
                }
                else if (DepartmentType == "507")
                {
                    departmentName = "综管部";
                }

                if (DepartmentType != "505")
                {
                    this.lblProject.Text = departmentName;
                }
                else
                {
                    var project = base.XMProjectService.GetXMProjectById(int.Parse(ProjectId));
                    if (project != null)
                    {
                        this.lblProject.Text = project.ProjectName;
                    }
                }

                if (NickId != -1 && NickId != 0)
                {
                    var nick = base.XMNickService.GetProjectNameByID(NickId);
                    if (nick != null)
                    {
                        this.lblNick.Text = nick.ProjectName;
                    }
                }

                this.lblYear.Text = Year;
                this.lblMonth.Text = Month;
                var FinancialField = base.XMFinancialFieldService.GetXMFinancialFieldById(FinancialFieldId);
                if (FinancialField != null)
                {
                    this.lblTitle.Text = FinancialField.FieldName;
                }
                var Info = base.CWStaffSpendingService.GetCWStaffSpendingInfo(ProjectId, NickId, Year, Month, FinancialFieldId, int.Parse(DepartmentType));
                if (Info != null)
                {
                    this.txtProjectExplanationValue.Text = Info.CountMoney.ToString();
                }
            }
        }

        #region IEditPage 成员
        public void Face_Init()
        {
        }
        public void SetTrigger()
        {
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var Info = base.CWStaffSpendingService.GetCWStaffSpendingInfo(ProjectId, NickId, Year, Month, FinancialFieldId, int.Parse(DepartmentType));
                if (Info != null)
                {
                    Info.CountMoney = Convert.ToDecimal(this.txtProjectExplanationValue.Text);
                    Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDateTime = DateTime.Now;
                    base.CWStaffSpendingService.UpdateCWStaffSpending(Info);
                    this.Master.JsWrite("alert('保存成功！');window.PopClose();", "");
                }
                else
                {
                    Info = new CWStaffSpending();
                    Info.FinancialFieldId = FinancialFieldId;
                    Info.ProjectId = int.Parse(ProjectId);
                    Info.DepartmentTypeId = int.Parse(DepartmentType);
                    Info.NickId = NickId;
                    Info.YearStr = Year;
                    Info.MonthStr = Month;
                    Info.CountMoney = Convert.ToDecimal(this.txtProjectExplanationValue.Text);
                    Info.IsEnable = false;
                    Info.CreateID = HozestERPContext.Current.User.CustomerID;
                    Info.CreateDateTime = DateTime.Now;
                    Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDateTime = DateTime.Now;
                    base.CWStaffSpendingService.InsertCWStaffSpending(Info);
                    this.Master.JsWrite("alert('保存成功！');window.PopClose();", "");
                }
            }
            catch (Exception err)
            {
                base.ProcessException(err, false);

            }
        }

        #region public void JsWrite(string paramAction)
        /// <summary>
        ///  写入JS脚本
        /// </summary>
        /// <param name="paramAction">内容</param>
        /// <param name="parmaName"></param>
        public void JsWrite(string paramAction)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "JS", paramAction, true);
        }
        #endregion

        public string DepartmentType
        {
            get
            {
                return CommonHelper.QueryString("DepartmentType");
            }
        }

        public string ProjectId
        {
            get
            {
                return CommonHelper.QueryString("ProjectId");
            }
        }

        public string Month
        {
            get
            {
                return CommonHelper.QueryString("Month");
            }
        }

        public string Year
        {
            get
            {
                return CommonHelper.QueryString("Year");
            }
        }

        public int NickId
        {
            get
            {
                return CommonHelper.QueryStringInt("NickId");
            }
        }

        public int FinancialFieldId
        {
            get
            {
                return CommonHelper.QueryStringInt("FinancialFieldId");
            }
        }
    }
}