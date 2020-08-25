using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.Web;

namespace HozestERP.Web.ManageProject
{
    public partial class ImportOrder : BaseAdministrationPage, IEditPage
    {
        private object lockobject = new object();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DIVDataFilePath2.Visible = false;
                ddPlatformTypeId_SelectedIndexChanged(sender, e);
            }
        }

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnImport", "ImportOrder.Import");
                return buttons;
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SettrEditHeadVisible = false;
            this.ddPlatformTypeId.Items.Clear();
            //平台类型动态数据绑定
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            // var newList = codeList.Where(p => p.CodeID != 250).ToList();
            this.ddPlatformTypeId.DataSource = codeList;
            this.ddPlatformTypeId.DataTextField = "CodeName";
            this.ddPlatformTypeId.DataValueField = "CodeID";
            this.ddPlatformTypeId.DataBind();
            //this.ddPlatformTypeId.Items.Insert(2, new ListItem("测试用选项，勿选！！！", "9527"));

            this.ddlNick.Items.Clear();
            var nickList = base.XMOrderInfoAPIService.GetXMNickListbyPlatformId("", Convert.ToInt32(true), int.Parse(this.ddPlatformTypeId.SelectedValue));
            this.ddlNick.DataSource = nickList;
            this.ddlNick.DataTextField = "nick";
            this.ddlNick.DataValueField = "nick_id";
            this.ddlNick.DataBind();
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
                string serpath2 = string.Empty;
                string sourceType = this.ddlSourceType.SelectedValue;
                this.btnImport.Enabled = false;
                if (DataFilePath.HasFile && DataFilePath2.HasFile)
                {
                    //平台类型 
                    // int PlatformTypeId = int.Parse(this.ddPlatformTypeId.SelectedValue); 
                    string PlatformTypeNameId = this.ddPlatformTypeId.SelectedValue.ToString();//平台类型Id
                    string PlatformTypeName = this.ddPlatformTypeId.SelectedItem.ToString();//平台类型名称 
                    string NickId = this.ddlNick.SelectedValue.ToString();//平台类型Id 
                    string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    string FileName = DataFilePath.FileName.Substring(0, DataFilePath.FileName.Length - (typ.Length + 1));

                    string typ2 = DataFilePath2.FileName.Substring(DataFilePath2.FileName.LastIndexOf(".") + 1).ToLower();
                    string FileName2 = DataFilePath2.FileName.Substring(0, DataFilePath2.FileName.Length - (typ2.Length + 1));

                    if (typ == "xls" || typ == "xlsx" || typ2 == "xls" || typ2 == "xlsx")
                    {
                        string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                        string partname2 = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath2.FileName;

                        string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\OrderInfoImporting";
                        if (!Directory.Exists(partpath))
                        {
                            Directory.CreateDirectory(partpath);
                        }
                        serpath = partpath + "\\" + partname;
                        serpath2 = partpath + "\\" + partname2;
                        DataFilePath.SaveAs(serpath);
                        DataFilePath2.SaveAs(serpath2);
                        string paramMessage = string.Empty;
                        lock (lockobject)
                        {
                            base.ImportManager.ImportOrderFromXlsTM(serpath, serpath2, DateTime.Now, System.Convert.ToInt32(PlatformTypeNameId), System.Convert.ToInt32(NickId), PlatformTypeName, FileName, FileName2, ref paramMessage, sourceType);
                        }
                        this.txtResult.Text = paramMessage;
                    }
                }
                else if (DataFilePath.HasFile)
                {
                    //平台类型 
                    // int PlatformTypeId = int.Parse(this.ddPlatformTypeId.SelectedValue); 
                    string PlatformTypeNameId = this.ddPlatformTypeId.SelectedValue.ToString();//平台类型Id
                    string PlatformTypeName = this.ddPlatformTypeId.SelectedItem.ToString();//平台类型名称 
                    string NickId = this.ddlNick.SelectedValue.ToString();//平台类型Id 
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
                        //this.Page;
                        lock (lockobject)
                        {
                            base.ImportManager.ImportOrderFromXls(serpath, DateTime.Now, System.Convert.ToInt32(PlatformTypeNameId), System.Convert.ToInt32(NickId), PlatformTypeName, FileName, ref paramMessage, sourceType);
                        }
                            this.txtResult.Text = paramMessage;
                    }
                    else if (typ == "csv")
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
                        if (PlatformTypeNameId == "376")
                        {
                            lock (lockobject)
                            {
                                //亚马逊
                                base.ImportManager.ImportAmazonOrderDataFromXls(serpath, ref paramMessage, sourceType);
                            }
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

        /// <summary>
        /// 平台类型关联订单状态 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddPlatformTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlNick.Items.Clear();
            var nickList = base.XMOrderInfoAPIService.GetXMNickListbyPlatformId("", Convert.ToInt32(true), int.Parse(this.ddPlatformTypeId.SelectedValue));
            this.ddlNick.DataSource = nickList;
            this.ddlNick.DataTextField = "nick";
            this.ddlNick.DataValueField = "nick_id";
            this.ddlNick.DataBind();

            if (this.ddPlatformTypeId.SelectedValue == "250" || this.ddPlatformTypeId.SelectedValue == "381")
            {
                this.DIVDataFilePath2.Visible = true;
                this.TMModel1.Visible = true;
                this.TMModel2.Visible = true;
                this.YMXMode.Visible = false;
                this.JDZYMode.Visible = false;
                this.JDMode.Visible = false;
                this.SNZYMode.Visible = false;
                this.TYMode.Visible = false;
                this.XHSMode.Visible = false;
                this.PDDMode.Visible = false;
            }
            else if (this.ddPlatformTypeId.SelectedValue == "585")
            {
                this.DIVDataFilePath2.Visible = false;
                this.TMModel1.Visible = true;
                this.TMModel2.Visible = false;
                this.YMXMode.Visible = false;
                this.JDZYMode.Visible = false;
                this.JDMode.Visible = false;
                this.TMModel1.Text = "国美模板";
                this.TMModel1.NavigateUrl = "~/Template/国美.xls";
                this.SNZYMode.Visible = false;
                this.TYMode.Visible = false;
                this.XHSMode.Visible = false;
                this.PDDMode.Visible = false;
            }
            else if (this.ddPlatformTypeId.SelectedValue == "376")
            {
                this.DIVDataFilePath2.Visible = false;
                this.TMModel1.Visible = false;
                this.TMModel2.Visible = false;
                this.YMXMode.Visible = true;
                this.JDZYMode.Visible = false;
                this.JDMode.Visible = false;
                this.SNZYMode.Visible = false;
                this.TYMode.Visible = false;
                this.XHSMode.Visible = false;
                this.PDDMode.Visible = false;
            }
            else if (this.ddPlatformTypeId.SelectedValue == "537")//京东自营
            {
                this.DIVDataFilePath2.Visible = false;
                this.TMModel1.Visible = false;
                this.TMModel2.Visible = false;
                this.YMXMode.Visible = false;
                this.JDZYMode.Visible = true;
                this.JDMode.Visible = false;
                this.SNZYMode.Visible = false;
                this.TYMode.Visible = false;
                this.XHSMode.Visible = false;
                this.PDDMode.Visible = false;
            }
            else if (this.ddPlatformTypeId.SelectedValue == "736")//苏宁自营
            {
                this.DIVDataFilePath2.Visible = false;
                this.TMModel1.Visible = false;
                this.TMModel2.Visible = false;
                this.YMXMode.Visible = false;
                this.JDZYMode.Visible = false;
                this.JDMode.Visible = false;
                this.SNZYMode.Visible = true;
                this.TYMode.Visible = false;
                this.XHSMode.Visible = false;
                this.PDDMode.Visible = false;
            }
            else if (this.ddPlatformTypeId.SelectedValue == "251")
            {
                this.DIVDataFilePath2.Visible = false;
                this.TMModel1.Visible = false;
                this.TMModel2.Visible = false;
                this.YMXMode.Visible = false;
                this.JDZYMode.Visible = false;
                this.JDMode.Visible = true;
                this.SNZYMode.Visible = false;
                this.TYMode.Visible = false;
                this.XHSMode.Visible = false;
                this.PDDMode.Visible = false;
            }
            else if (this.ddPlatformTypeId.SelectedValue == "508") 
            {
                this.DIVDataFilePath2.Visible = false;
                this.TMModel1.Visible = false;
                this.TMModel2.Visible = false;
                this.YMXMode.Visible = false;
                this.JDZYMode.Visible = false;
                this.JDMode.Visible = false;
                this.SNZYMode.Visible = false;
                this.TYMode.Visible = true;
                this.XHSMode.Visible = false;
                this.PDDMode.Visible = false;
            }
            else if(this.ddPlatformTypeId.SelectedValue == "765")
            {
                this.DIVDataFilePath2.Visible = false;
                this.TMModel1.Visible = false;
                this.TMModel2.Visible = false;
                this.YMXMode.Visible = false;
                this.JDZYMode.Visible = false;
                this.JDMode.Visible = false;
                this.SNZYMode.Visible = false;
                this.TYMode.Visible = false;
                this.XHSMode.Visible = true;
                this.PDDMode.Visible = false;
            }
            else if (this.ddPlatformTypeId.SelectedValue == "824")//拼多多
            {
                this.DIVDataFilePath2.Visible = false;
                this.TMModel1.Visible = false;
                this.TMModel2.Visible = false;
                this.YMXMode.Visible = false;
                this.JDZYMode.Visible = false;
                this.JDMode.Visible = false;
                this.SNZYMode.Visible = false;
                this.TYMode.Visible = false;
                this.XHSMode.Visible = false;
                this.PDDMode.Visible = true;
            }
            else
            {
                this.DIVDataFilePath2.Visible = false;
                this.TMModel1.Visible = false;
                this.TMModel2.Visible = false;
                this.YMXMode.Visible = false;
                this.JDZYMode.Visible = false;
                this.JDMode.Visible = false;
                this.SNZYMode.Visible = false;
                this.TYMode.Visible = false;
                this.XHSMode.Visible = false;
                this.PDDMode.Visible = false;
            }
        }
    }
}