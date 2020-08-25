using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace HozestERP.Web.ManageFinance
{
    public partial class ImportAlipayStatementData : BaseAdministrationPage, IEditPage
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
            //平台类型动态数据绑定
            this.ddPlatformTypeId.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            // var newList = codeList.Where(p => p.CodeID != 250).ToList();
            this.ddPlatformTypeId.DataSource = codeList;
            this.ddPlatformTypeId.DataTextField = "CodeName";
            this.ddPlatformTypeId.DataValueField = "CodeID";
            this.ddPlatformTypeId.DataBind();
            this.ddPlatformTypeId.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        public void SetTrigger()
        {
        }

        #endregion

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                int PlatformTypeId = Convert.ToInt16(ddPlatformTypeId.SelectedValue);
                if (PlatformTypeId == -1)
                {
                    base.ShowMessage("平台必须选择！");
                    return;
                }
                string serpath = string.Empty;
                string fieldName = "";
                switch (PlatformTypeId)
                {
                    case 259:
                        fieldName = "SO";
                        break;
                    case 251:
                        fieldName = "订单编号";
                        break;
                    case 383:
                        fieldName = "订单号";
                        break;
                    case 250:
                        fieldName = "商户订单号";
                        break;
                }
                if (DataFilePath.HasFile)
                {
                    string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    if (typ == "xls" || typ == "xlsx")
                    {
                        string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                        string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\ImportAlipayStatementData";
                        if (!Directory.Exists(partpath))
                        {
                            Directory.CreateDirectory(partpath);
                        }
                        serpath = partpath + "\\" + partname;
                        DataFilePath.SaveAs(serpath);
                        string paramMessage = string.Empty;
                        base.ImportManager.ImportAlipaymentData(serpath, ref paramMessage, PlatformTypeId, fieldName);
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