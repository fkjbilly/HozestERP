using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace HozestERP.Web.ManageProject
{  
    public partial class ImportScalpingRecord : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnImport", "ImportScalpingRecord.Import");
                return buttons;
            }
        }


        #region IEditPage 成员

        public void Face_Init()
        {
            //this.Master.SettrEditHeadVisible = false; 
        }

        public void SetTrigger()
        {
        }

        #endregion

        protected void btnImport_Click(object sender, EventArgs e)
        {
            string paramMessage = string.Empty;
            this.txtResult.Text = "";
            try
            {
                string serpath = string.Empty;
                if (DataFilePath.HasFile)
                {   
                    string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    string FileName = DataFilePath.FileName.Substring(0, DataFilePath.FileName.Length - (typ.Length + 1));
                    if (typ == "xls" || typ == "xlsx")
                    {
                        string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                        string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\ImportScalpingRecord";
                        if (!Directory.Exists(partpath))
                        {
                            Directory.CreateDirectory(partpath);
                        }
                        serpath = partpath + "\\" + partname;
                        DataFilePath.SaveAs(serpath);
                        base.ImportManager.ImportScalpingRecordXls(serpath, DateTime.Now, FileName, ref paramMessage);
                        this.txtResult.Text = paramMessage;
                    }
                }
            }
            catch (Exception err)
            {
                if (paramMessage == "")
                {
                    base.ProcessException(err, false);
                    this.txtResult.Text = err.Message;
                }
                else
                {
                    base.ProcessException(err, false);
                    this.txtResult.Text = paramMessage;
                }
            }
        }
    }
}