using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageBusiness;

namespace HozestERP.Web.ManageProject
{
    public partial class ImportFinancialCost : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            string templatePath = string.Empty;
            //链接指向项目预算模板
            if (this.ProjectID != 0)
            {
                templatePath = "~/Template/ProjectFieldCost.xls";
                DownTemp.NavigateUrl = templatePath;
            }
            //链接指向B2B预算模板
            if (this.DepartmentID != 0 && this.DepartmentID == 297)
            {
                templatePath = "~/Template/B2BFieldCost.xls";
                DownTemp.NavigateUrl = templatePath;
            }
            //链接指向B2C预算模板
            if (this.DepartmentID != 0 && this.DepartmentID == 63)
            {
                templatePath = "~/Template/B2CFieldCost.xls";
                DownTemp.NavigateUrl = templatePath;
            }
            //链接指向综管部预算模板
            if (this.DepartmentID != 0 && this.DepartmentID == 507)
            {
                templatePath = "~/Template/ManagerFieldCost.xls";
                DownTemp.NavigateUrl = templatePath;
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

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string serpath = string.Empty;
                if (DataFilePath.HasFile)
                {
                    string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    if (typ == "xls" || typ == "xlsx")
                    {
                        string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                        string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"UpLoad\ImportFinancialCost";
                        if (!Directory.Exists(partpath))
                        {
                            Directory.CreateDirectory(partpath);
                        }
                        serpath = partpath + "\\" + partname;
                        DataFilePath.SaveAs(serpath);
                        string paramMessage = string.Empty;

                        //导入数据
                        if (this.ProjectID != 0)
                        {
                            base.ImportManager.ImportFinancialCost(serpath, ref paramMessage, this.ProjectID, 0, this.year);
                            this.txtResult.Text = paramMessage;
                        }
                        if (this.DepartmentID != 0)
                        {
                            base.ImportManager.ImportFinancialCost(serpath, ref paramMessage, 0, this.DepartmentID, this.year);
                            this.txtResult.Text = paramMessage;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                base.ProcessException(err, false);
                this.txtResult.Text = err.Message;
            }
        }

        //项目ID
        public int ProjectID
        {
            get
            {
                return CommonHelper.QueryStringInt("ProjectId");
            }
        }
        //部门ID
        public int DepartmentID
        {
            get
            {
                return CommonHelper.QueryStringInt("DepartmentID");
            }
        }
        //年份 
        public int year
        {
            get
            {
                return CommonHelper.QueryStringInt("year");
            }
        }
    }
}