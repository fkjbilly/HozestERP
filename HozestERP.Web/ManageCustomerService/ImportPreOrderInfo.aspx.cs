using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using HozestERP.Common.Utils;
using HozestERP.Web;
using HozestERP.BusinessLogic;

namespace HozestERP.Web.ManageCustomerService
{
    public partial class ImportPreOrderInfo : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.DIVDataFilePath2.Visible = false;
            }
        }
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnImport", "ImportPreOrderInfo.Import");
                return buttons;
            }
        }

        
        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SettrEditHeadVisible = false;

            #region 店铺名称绑定

            //店铺数据源 
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddlNick.Items.Clear();
                var NickList = base.XMNickService.GetXMNickList();
                var newNickList = NickList.Where(p => p.isEnable == true).ToList();
                this.ddlNick.DataSource = newNickList;
                this.ddlNick.DataTextField = "nick";
                this.ddlNick.DataValueField = "nick_id";
                this.ddlNick.DataBind();
                this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                //其他
                //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                var xMNickList = base.XMNickService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
                if (xMNickList.Count() == 0)
                {
                    this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                }
                if (xMNickList.Count > 0)
                {
                    this.ddlNick.Items.Clear();
                    this.ddlNick.DataSource = xMNickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    //this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
            }

            #endregion
            //this.ddlNick.Items.Clear();
            //var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true),-1);
            //this.ddlNick.DataSource = nickList;
            //this.ddlNick.DataTextField = "nick";
            //this.ddlNick.DataValueField = "nick_id";
            //this.ddlNick.DataBind(); 
        }

        public void SetTrigger()
        {
        }

        #endregion

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                //string serpath = string.Empty;
                //string serpath2 = string.Empty;
                //if (DataFilePath.HasFile && DataFilePath2.HasFile)
                //{
                    ////平台类型 
                    //string PlatformTypeNameId = this.ddPlatformTypeId.SelectedValue.ToString();//平台类型Id
                    //string PlatformTypeName = this.ddPlatformTypeId.SelectedItem.ToString();//平台类型名称 
                    //string NickId = this.ddlNick.SelectedValue.ToString();//平台类型Id 
                    //string NickName = this.ddlNick.SelectedItem.ToString();
                    //string type = this.excelType.SelectedValue.ToString();//excel的类型
                    //string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    //string FileName = DataFilePath.FileName.Substring(0, DataFilePath.FileName.Length - (typ.Length + 1));

                    //string typ2 = DataFilePath2.FileName.Substring(DataFilePath2.FileName.LastIndexOf(".") + 1).ToLower();
                    //string FileName2 = DataFilePath2.FileName.Substring(0, DataFilePath2.FileName.Length - (typ2.Length + 1));

                    //if (typ == "xls" || typ == "xlsx" ||  typ2 == "xls" || typ2 == "xlsx")
                    //{
                    //    string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName; 
                    //    string partname2 = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath2.FileName;

                    //    string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\PreOrderInfoImporting";
                    //    if (!Directory.Exists(partpath))
                    //    {
                    //        Directory.CreateDirectory(partpath);
                    //    }
                    //    serpath = partpath + "\\" + partname;
                    //    serpath2 = partpath + "\\" + partname2;
                    //    DataFilePath.SaveAs(serpath);
                    //    DataFilePath2.SaveAs(serpath2);
                    //    string paramMessage = string.Empty;
                    //    //base.ImportManager.ImportPreOrderFromXlsTM(serpath, serpath2, DateTime.Now, System.Convert.ToInt32(PlatformTypeNameId), System.Convert.ToInt32(NickId), PlatformTypeName, FileName, FileName2, ref paramMessage);
                    //    this.txtResult.Text = paramMessage;
                    //} 
                //}
                string serpath = string.Empty;
                if (DataFilePath.HasFile)
                {
                    //平台类型 
                    string PlatformTypeNameId = this.ddPlatformTypeId.SelectedValue.ToString();//平台类型Id
                    string PlatformTypeName = this.ddPlatformTypeId.SelectedItem.ToString();//平台类型名称 
                    string NickId = this.ddlNick.SelectedValue.ToString();//平台类型Id 
                    string NickName = this.ddlNick.SelectedItem.ToString();//平台名称
                    string type = this.excelType.SelectedValue.ToString();//excel的类型格式
                    if ((type == "1" && PlatformTypeName != "京东") || (type != "1" && PlatformTypeName != "天猫"))
                    {
                        this.txtResult.Text = "平台类型与导入类型不符！";
                        return;
                    }
                    string typ = DataFilePath.FileName.Substring(DataFilePath.FileName.LastIndexOf(".") + 1).ToLower();
                    string FileName = DataFilePath.FileName.Substring(0, DataFilePath.FileName.Length - (typ.Length + 1));
                    if ((FileName.IndexOf("京东") != -1 && type != "1")||(FileName.IndexOf("超级店长") != -1 && type != "2")||(FileName.IndexOf("赤兔") != -1 && type != "3"))
                    {
                        this.txtResult.Text = "导入类型与Excel文件不符！";
                        return;
                    }
                    if (typ == "xls" || typ == "xlsx")
                    {
                        string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                        string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\PreOrderInfoImporting";
                        if (!Directory.Exists(partpath))
                        {
                            Directory.CreateDirectory(partpath);
                        }
                        serpath = partpath + "\\" + partname;
                        DataFilePath.SaveAs(serpath);
                        string paramMessage = string.Empty;
                        paramMessage = base.ImportManager.ImportPreOrderFromXlsTM(serpath, NickName, FileName, type, int.Parse(PlatformTypeNameId), int.Parse(NickId));
                        this.txtResult.Text = paramMessage;
                    }
                    //else if (typ == "csv")
                    //{
                    //    string partname = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + DataFilePath.FileName;
                    //    string partpath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\UpLoad\PreOrderInfoImporting";
                    //    if (!Directory.Exists(partpath))
                    //    {
                    //        Directory.CreateDirectory(partpath);
                    //    }
                    //    serpath = partpath + "\\" + partname;
                    //    DataFilePath.SaveAs(serpath);
                    //    string paramMessage = string.Empty;
                    //    if (PlatformTypeNameId == "376")
                    //    {
                    //        //亚马逊
                    //        base.ImportManager.ImportAmazonOrderDataFromXls(serpath, ref paramMessage);
                    //    }
                    //    this.txtResult.Text = paramMessage;
                    //}
                }
                else 
                {
                    this.txtResult.Text = "请先选择EXCEL文件地址！";
                }
            }
            catch(Exception err)
            {
                base.ProcessException(err, false);
                this.txtResult.Text = err.Message;
            }
        }
    }
}