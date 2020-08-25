using System;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Text.RegularExpressions;

namespace HozestERP.Web.ManageInventory
{
    public partial class InventoryAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        private void loadData()
        {
            var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(ID);
            if (InventoryInfo != null)
            {
                lbProductName.Text = InventoryInfo.ProductName;
                var warehoures = base.XMWareHousesService.GetXMWareHousesById(InventoryInfo.WfId);
                if (warehoures != null)
                {
                    lbWareHoures.Text = warehoures.Name;
                }
                lbStorageCount.Text = InventoryInfo.StockNumber.ToString();
                txtWarningCount.Text = InventoryInfo.WarningValue.ToString();
            }
        }

        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^[0-9]*[1-9][0-9]*$");
            return reg1.IsMatch(str);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //保存
            string warningCount = txtWarningCount.Text.Trim();
            if (warningCount == "" || !IsNumeric(warningCount))
            {
                base.ShowMessage("警戒值必须填写 或警戒值输入格式不正确！");
                return;
            }
            var InventoryInfo = base.XMInventoryInfoService.GetXMInventoryInfoById(ID);
            if (InventoryInfo != null)
            {
                InventoryInfo.WarningValue = int.Parse(warningCount);
                InventoryInfo.UpdateDate = DateTime.Now;
                InventoryInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryInfoService.UpdateXMInventoryInfo(InventoryInfo);
            }
            base.ShowMessage("操作成功！");
            loadData();
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }
    }
}