using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageProject
{
    public partial class ImportExpressListData : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtBeginDate.Value = DateTime.Now.ToString("yyyy-MM");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                int expressID = !string.IsNullOrEmpty(ddlExpress.SelectedValue) ? int.Parse(ddlExpress.SelectedValue) : 0;
                //店铺id
                string Begin = this.txtBeginDate.Value.Trim();
                DateTime date = DateTime.Now;
                if (Begin != "")
                {
                    if (Begin == "" || !DateTime.TryParse(Begin, out date))
                    {
                        base.ShowMessage("日期格式不正确！");
                        return;
                    }
                }
                int year = Convert.ToDateTime(Begin).Year;                      //年份
                int month = Convert.ToDateTime(Begin).Month;              //月份
                string serpath = string.Empty;
                if (DataFilePath.HasFile)
                {
                    string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    if (typ == "xls" || typ == "xlsx")
                    {
                        string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                        string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\XMExpress";
                        if (!Directory.Exists(partpath))
                        {
                            Directory.CreateDirectory(partpath);
                        }
                        serpath = partpath + "\\" + partname;
                        DataFilePath.SaveAs(serpath);
                        string paramMessage = string.Empty;
                        base.ImportManager.ImportExpressList(serpath, ref paramMessage, expressID, year,month);
                        this.txtResult.Text = paramMessage;
                    }
                }
            }
            catch (Exception err)
            {
                base.ProcessException(err, false);
                this.txtResult.Text = err.Message;
            }
        }


        #region IEditPage 成员

        public void Face_Init()
        {
            //快递绑定
            this.ddlExpress.Items.Clear();
            var xMCompanyCustomList = base.XMCompanyCustomService.GetXMCompanyCustomList();
            this.ddlExpress.DataSource = xMCompanyCustomList;
            this.ddlExpress.DataTextField = "LogisticsName";
            this.ddlExpress.DataValueField = "LogisticsId";
            this.ddlExpress.DataBind();
            this.ddlExpress.SelectedValue = "470";
        }

        public void SetTrigger()
        {

        }

        #endregion
    }
}