using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace HozestERP.Web.ManageFinance
{
    public partial class ImportBills : BaseAdministrationPage, IEditPage
    {
        private object lockobject = new object();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.DIVDataFilePath.Visible = false;
            }
        }
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnImport", "ManageFinance.XMBills.ImportBills");
                return buttons;
            }
        }
        public void Face_Init()
        {
          
        }

        public void SetTrigger()
        {
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                int SuppliersId = int.Parse(this.ddSuppliers.Text); //供应商ID
                string serpath = string.Empty;
                if (this.ddSuppliers.Text == "-1")
                {
                    this.txtResult.Text = "供应商必选";
                    return;
                }
                this.btnImport.Enabled = false;
                if (this.DataFilePath.HasFile)
                {
                    string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    string FileName = DataFilePath.FileName.Substring(0, DataFilePath.FileName.Length - (typ.Length + 1));
                    if (typ == "xls" || typ == "xlsx")
                    {
                        string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                        string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\OrderInfoImporting";
                        if (!Directory.Exists(partpath))
                        {
                            Directory.CreateDirectory(partpath);
                        }
                        serpath = partpath + "\\" + partname;
                        DataFilePath.SaveAs(serpath);
                        string paramMessage = string.Empty;
                        lock (lockobject)
                        {
                            base.ImportManager.ImportBillsXls(serpath, SuppliersId, ref paramMessage);
                        }
                        this.txtResult.Text = paramMessage;
                    }
                }
              
                this.btnImport.Enabled = true;
            }
            catch (Exception err)
            {
                base.ProcessException(err, false);
                this.txtResult.Text = err.Message;
            }
        }
    }
}