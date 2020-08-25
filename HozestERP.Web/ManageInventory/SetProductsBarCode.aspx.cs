using System;
using System.Linq;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;
using System.Collections.Generic;
using System.Text;

namespace HozestERP.Web.ManageInventory
{
    public partial class SetProductsBarCode : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBarCodeList();
            }
        }

        private void GetBarCodeList()
        {
            StringBuilder str = new StringBuilder();
            str.Append("条形码&nbsp;<input id=\"txtBarCodes\" name=\"barCodes\" type=\"text\" class=\"TextBox\" style=\"text-align: left;width: 80%\" value='' />");
            str.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td colspan=\"2\" style=\"height: 8px\"></td></tr></table>");
            str.Append("<table class=\"table\" id='MyPurchaseProductList'>");
            str.Append("</table>");
            TableStr = str.ToString();
        }

        private void bindGrid(string hiddjsonContent)
        {
            StringBuilder str = new StringBuilder();
            str.Append("条形码&nbsp;<input id=\"txtBarCodes\" name=\"barCodes\" type=\"text\" class=\"TextBox\" style=\"text-align: left;width: 90%\" value='' />");
            str.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td colspan=\"2\" style=\"height: 8px\"></td></tr></table>");
            str.Append("<table class=\"table\" id='MyPurchaseProductList'>");
            if (hiddjsonContent != "" && hiddjsonContent.Length > 0)
            {
                string[] barCodes = hiddjsonContent.Split(';');
                if (barCodes.Count() > 0)
                {
                    foreach (string barcode in barCodes)
                    {
                        str.Append("<tr id=\"mytr\"><td id=\"barCodes\">" + barcode + "</td><td><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\" onclick=\"DeleteItem(this)\" /></td></tr>");
                    }
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string hiddjsonContent = hdfJsonContent.Value;
            if (hiddjsonContent != "" && hiddjsonContent.Length > 0)
            {
                //拆分条形码
                hiddjsonContent = hiddjsonContent.Substring(0, hiddjsonContent.Length - 1);
                if (Session[this.Status] == null)
                {
                    List<BarCodeInfo> List = new List<BarCodeInfo>();
                    BarCodeInfo info = new BarCodeInfo();
                    info.PID = this.PID;
                    info.BarCodeStr = hiddjsonContent;
                    List.Add(info);
                    Session[this.Status] = List;
                }
                else
                {
                    bool isExsit = false;
                    List<BarCodeInfo> List = Session[this.Status] as List<BarCodeInfo>;
                    if (List != null && List.Count > 0)
                    {
                        foreach (BarCodeInfo q in List)
                        {
                            if (q.PID == this.PID)
                            {
                                q.BarCodeStr = hiddjsonContent;
                                isExsit = true;
                            }
                        }
                        if (!isExsit)    //不存在新增
                        {
                            BarCodeInfo info = new BarCodeInfo();
                            info.PID = this.PID;
                            info.BarCodeStr = hiddjsonContent;
                            List.Add(info);
                        }
                        Session[this.Status] = List;
                    }
                }
            }
            base.ShowMessage("操作成功!");
            bindGrid(hiddjsonContent);
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public int PID
        {
            get
            {
                return CommonHelper.QueryStringInt("ID");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            get { return CommonHelper.QueryString("Status"); }
        }
    }
}