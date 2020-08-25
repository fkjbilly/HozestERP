using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Enterprises;

namespace HozestERP.Web.ManageBusiness
{
    public partial class OtherTargeAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                dpLogDate.Value = DateTime.Now.ToString("yyyy-MM");
                var department = EnterpriseService.GetDepartmentById(this.DepartmentId);
                if (department != null)
                {
                    lbDepartmentName.Text = department.DepName;
                }

                loadData(this.Id);
            }
        }

        private void loadData(int id)
        {
            if (id != 0)
            {
                XMOtherMonthlyTarget info = base.XMOtherMonthlyTargetService.GetXMOtherMonthlyTargetByID(id);
                if (info != null)
                {
                    dpLogDate.Value = info.DateTime.ToString("yyyy-MM");
                    OriginalTime = info.DateTime;
                    txtOtherAmount.Text = info.Income.ToString();

                    lbDepartmentName.Text = info.DepartmentName;
                }
                //lbCreateName.Text = base.XMOtherMonthlyTargetService.GetCustomerName(info.Updater.ToString());
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            if (Type == 0)
            {

                DateTime datetime = Convert.ToDateTime(dpLogDate.Value.Trim());   //设定时间

                var list = base.XMOtherMonthlyTargetService.GetXMOtherMonthlyTargetListByParm(this.DepartmentId, datetime.Year);
                list = list.Where(p => p.DateTime.Month == datetime.Month).ToList();
                if (list.Count > 0)
                {
                    base.ShowMessage("该月份数据已存在！");
                    return;
                }
                XMOtherMonthlyTarget info = new XMOtherMonthlyTarget();
                info.DateTime = Convert.ToDateTime(datetime.ToString("yyyy-MM"));
                info.Income = Convert.ToDecimal(txtOtherAmount.Text.Trim());
                info.CreateID = HozestERPContext.Current.User.CustomerID;
                info.CreateDate = DateTime.Now;
                info.Updater = HozestERPContext.Current.User.CustomerID;
                info.UpdateDate = DateTime.Now;
                info.DepartmentID = this.DepartmentId;
                info.IsEnable = false;
                info.IsAudit = false;
                base.XMOtherMonthlyTargetService.InsertXMOtherMonthlyTarget(info);

            }
            else
            {
                if (!string.IsNullOrEmpty(this.Id.ToString()))
                {
                    XMOtherMonthlyTarget Info = base.XMOtherMonthlyTargetService.GetXMOtherMonthlyTargetByID(this.Id);
                    if ((bool)Info.IsAudit)
                    {
                        base.ShowMessage("已审核，不能修改！");
                        return;
                    }
                    DateTime datetime = Convert.ToDateTime(dpLogDate.Value.Trim());   //设定时间
                    if (OriginalTime.Month != datetime.Month)
                    {
                        var list = base.XMOtherMonthlyTargetService.GetXMOtherMonthlyTargetListByParm(this.DepartmentId, datetime.Year);
                        list = list.Where(p => p.DateTime.Month == datetime.Month).ToList();
                        if (list.Count > 0)
                        {
                            base.ShowMessage("该月份数据已存在！");
                            return;
                        }
                    }
                    Info.DateTime = Convert.ToDateTime(datetime.ToString("yyyy-MM"));
                    Info.Income = Convert.ToDecimal(txtOtherAmount.Text.Trim());
                    Info.UpdateDate = DateTime.Now;
                    Info.Updater = HozestERPContext.Current.User.CustomerID;
                    base.XMOtherMonthlyTargetService.UpdateXMOtherMonthlyTarget(Info);

                }
            }
            //base.ShowMessage("保存成功!");

            JsWrite("alert('保存成功.');window.close();");

        }


        #region
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


        public DateTime OriginalTime
        {
            get { return ViewState["OriginalTime"] == null ? DateTime.Now : (DateTime)ViewState["OriginalTime"]; }

            set { ViewState["OriginalTime"] = value; }
        }


        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        public int DepartmentId
        {

            get { return CommonHelper.QueryStringInt("DepId"); }
        }

        public int Type
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }


        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }
    }
}