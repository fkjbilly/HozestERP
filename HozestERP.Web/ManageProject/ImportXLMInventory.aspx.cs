using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManageProject
{
    public partial class ImportXLMInventory : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            ////仓库
            //this.ddlWarehouse.Items.Clear();
            //var CodeList = base.CodeService.GetCodeListInfoByCodeTypeID(227, false);
            //this.ddlWarehouse.DataSource = CodeList;
            //this.ddlWarehouse.DataTextField = "CodeName";
            //this.ddlWarehouse.DataValueField = "CodeID";
            //this.ddlWarehouse.DataBind();
            //this.ddlWarehouse.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        public void SetTrigger()
        {
        }

        #endregion

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                //string Warehouse = this.ddlWarehouse.SelectedValue.Trim();
                //if (Warehouse == "-1")
                //{
                //    base.ShowMessage("请先选择仓库！");
                //    return;
                //}

                string serpath = string.Empty;
                if (DataFilePath.HasFile)
                {
                    string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    if (typ == "xls" || typ == "xlsx")
                    {
                        string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                        string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\ImportXLMInventory";
                        if (!Directory.Exists(partpath))
                        {
                            Directory.CreateDirectory(partpath);
                        }
                        serpath = partpath + "\\" + partname;
                        DataFilePath.SaveAs(serpath);
                        string paramMessage = string.Empty;

                        base.ImportManager.ImportXLMInventory(serpath, ref paramMessage);
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