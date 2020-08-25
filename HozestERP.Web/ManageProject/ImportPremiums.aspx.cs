using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace HozestERP.Web.ManageProject
{
    public partial class ImportPremiums : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                string filePath = string.Empty;
                if (DataFilePath.HasFile)
                {
                    string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    if (typ == "xls" || typ == "xlsx")
                    {
                        string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                        string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\ImportPremiums";
                        if (!Directory.Exists(partpath))
                        {
                            Directory.CreateDirectory(partpath);
                        }

                        filePath = partpath + "\\" + partname;
                        DataFilePath.SaveAs(filePath);

                        string paramMessage = string.Empty;
                        base.ImportManager.ImportPremiumsDataFromXls(filePath, ref paramMessage);
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
    }
}