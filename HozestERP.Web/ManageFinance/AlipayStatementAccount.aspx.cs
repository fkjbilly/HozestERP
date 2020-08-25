using System;
using System.Linq;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageFinance;
using System.Collections.Generic;
using HozestERP.BusinessLogic.ManageProject;
using System.Web;
using System.IO;

namespace HozestERP.Web.ManageFinance
{
    public partial class AlipayStatementAccount : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // loadData();
                this.BindGrid(1, Master.PageSize);
                //支付宝账单导入
                this.btnImportData.OnClientClick = "return ShowWindowDetail('支付宝账单导入','" + CommonHelper.GetStoreLocation() +
            "ManageFinance/ImportAlipayStatementData.aspx',500,300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            int PlatformTypeId = Convert.ToInt16(ddPlatformTypeId.SelectedValue);
            if (PlatformTypeId == -1)
            {
                if (System.Web.HttpContext.Current.Session["AlipaymentData"] != null)
                {
                    var AlipaymentData = Session["AlipaymentData"] as List<XMAlipaymentAccount>;
                    var pageList = new PagedList<XMAlipaymentAccount>(AlipaymentData, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                    this.Master.BindData(this.grdvAlipayStatementAccount, pageList);
                }
            }
            else
            {
                if (System.Web.HttpContext.Current.Session["AlipaymentData"] != null)
                {
                    List<XMAlipaymentAccount> List = new List<XMAlipaymentAccount>();
                    var AlipaymentData = Session["AlipaymentData"] as List<XMAlipaymentAccount>;
                    if (AlipaymentData != null && AlipaymentData.Count > 0)
                    {
                        foreach (XMAlipaymentAccount Info in AlipaymentData)
                        {
                            if (Info.PlatFormTypeId == PlatformTypeId)
                            {
                                List.Add(Info);
                            }
                        }
                    }
                    var pageList = new PagedList<XMAlipaymentAccount>(List, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                    this.Master.BindData(this.grdvAlipayStatementAccount, pageList);
                }
            }
        }

        //导出数据
        protected void btnExportData_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int PlatformTypeId = Convert.ToInt16(ddPlatformTypeId.SelectedValue);
                    List<XMAlipaymentAccount> List = new List<XMAlipaymentAccount>();
                    if (PlatformTypeId == -1)
                    {
                        if (System.Web.HttpContext.Current.Session["AlipaymentData"] != null)
                        {
                            List = Session["AlipaymentData"] as List<XMAlipaymentAccount>;
                        }
                    }
                    else
                    {
                        if (System.Web.HttpContext.Current.Session["AlipaymentData"] != null)
                        {
                            var AlipaymentData = Session["AlipaymentData"] as List<XMAlipaymentAccount>;
                            if (AlipaymentData != null && AlipaymentData.Count > 0)
                            {
                                foreach (XMAlipaymentAccount Info in AlipaymentData)
                                {
                                    if (Info.PlatFormTypeId == PlatformTypeId)
                                    {
                                        List.Add(Info);
                                    }
                                }
                            }
                        }
                    }
                    if (List != null && List.Count > 0)
                    {
                        //导出存放路径
                        string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                        string filePath = string.Format("{0}Upload\\InventoryInfoDetailExport", HttpContext.Current.Request.PhysicalApplicationPath);
                        if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(filePath);
                        }
                        filePath = filePath + "//" + fileName;

                        base.ExportManager.ExportAlipaymentDataToXls(filePath, List);
                        CommonHelper.WriteResponseXls(filePath, fileName);
                    }
                    else
                    {
                        base.ShowMessage("请先导入相关数据，在进行导出操作！");
                        return;
                    }
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

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

        #endregion
    }
}