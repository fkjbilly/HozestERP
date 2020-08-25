using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageFinance;

namespace HozestERP.Web.ManageFinance
{
    public partial class XMBills :  BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.btnImportBills.OnClientClick = "return ShowWindowDetail('导入账单','" + CommonHelper.GetStoreLocation() +
           "ManageFinance/ImportBills.aspx',600,300, this, '');";
                this.BindGrid(1, Master.PageSize);
            }
        }
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnDelete", "ManageFinance.XMBills.Delete");//删除
                buttons.Add("btnImportBills", "ManageFinance.XMBills.ImportBills"); //导入订单
                buttons.Add("btnVerification", "ManageFinance.XMBills.VerificationBills"); //核销订单
                return buttons;
            }
        }
        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
        }
        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;
            //平台类型动态数据绑定
            this.ddVerification.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(247, false);
            //var newCodeList = new List<string>();
            codeList = codeList.Where(m => m.CodeName != "部分核销").OrderBy(m=>m.CodeNO).ToList();
            // var newList = codeList.Where(p => p.CodeID != 250).ToList();
            this.ddVerification.DataSource = codeList;
            this.ddVerification.DataTextField = "CodeName";
            this.ddVerification.DataValueField = "CodeNO";
            this.ddVerification.DataBind();
            this.ddVerification.Items.Insert(0, new ListItem("---所有---", ""));
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var list = GetXMBillsList();
            //分页
            var PageList = new PagedList<BusinessLogic.ManageFinance.XMBills>(list, paramPageIndex, paramPageSize);
            this.Master.BindData(this.grdvClients, PageList, paramPageSize + 1);
        }

        public List<BusinessLogic.ManageFinance.XMBills> GetXMBillsList()
        {
            string SuppliersID = this.ddSuppliers.Text;
            string VerificationStatus = this.ddVerification.SelectedValue;
            string DeliveryId = this.txtDeliveryId.Text;
            string PlatformMerchantCode = this.txtPlatformMerchantCode.Text;

            string CreateDateEBegin = this.txtCreateDateBegin.Value.Trim();
            string CreateDateEnd = this.txtCreateDateEnd.Value.Trim();
            DateTime CreateDateBeginDate = DateTime.Now.AddMonths(-1);
            DateTime CreateDateEndDate = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(CreateDateEBegin))
            {
                CreateDateBeginDate = DateTime.Parse(CreateDateEBegin);
            }
            if (!string.IsNullOrWhiteSpace(CreateDateEnd))
            {
                CreateDateEndDate = DateTime.Parse(CreateDateEnd);
            }
            if (CreateDateEndDate < CreateDateBeginDate)
                base.ShowMessage("结束时间不能小于开始时间！");

            var list = base.XMBillsservice.GetXMBillsListSearch(SuppliersID, VerificationStatus, DeliveryId, PlatformMerchantCode, CreateDateBeginDate, CreateDateEndDate);
            return list;
        }

        /// <summary>
        /// 查询
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
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBillsExport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Upload\\OrderInfoExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                    var xmBillsList = GetXMBillsList();

                    base.ExportManager.ExportXMBills(filePath, xmBillsList);
                    CommonHelper.WriteResponseXls(filePath, fileName);
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }
        /// <summary>
        /// 核销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVerification_Click(object sender, EventArgs e)
        {
            var billsIdList = new List<int>();
            foreach (GridViewRow row in grdvClients.Rows)
            {
                CheckBox chkSelected = (CheckBox)row.Cells[0].FindControl("chkSelected");
                if (chkSelected.Checked)
                {
                    var billId = int.Parse(this.grdvClients.DataKeys[row.RowIndex].Value.ToString());
                    billsIdList.Add(billId);
                }
            }
            try
            {
                #region 核销账单
                var verificationBillsList = base.XMBillsservice.GetXMBillsList(billsIdList);//查找出选中的要核销的账单的数据
                var deliveryNumberList = verificationBillsList.Select(m => m.DeliveryNumber).ToList();
                var xmDeliveryDetailsList = base.XMDeliveryDetailsService.GetXMDeliveryDetailsList(deliveryNumberList);//选中的账单对应的所有发货单详细信息
                var dic = new Dictionary<string, string>();//存储发货单号和对应的核销状态
                foreach (var element in verificationBillsList)
                {
                    #region 判断账单是否有对应的已发货的发货单信息
                    var xmDeliveryDetails = xmDeliveryDetailsList.Where(m => m.DeliveryNumber == element.DeliveryNumber);//找出对应的数据
                    if (xmDeliveryDetails.Count() == 0)//没有对应的发货单信息，则该账单属于异常账单
                    {
                        element.VerificationStatus = Convert.ToString((int)status.异常);
                        element.ExMessage = "找不到对应的发货单信息";
                        dic.Add(element.DeliveryNumber + "," + element.PlatformMerchantCode, element.VerificationStatus);
                        continue;
                    }
                    xmDeliveryDetails = xmDeliveryDetails.Where(m => m.PlatformMerchantCode == element.PlatformMerchantCode);
                    if (xmDeliveryDetails.Count() == 0)//发货单中的商品信息不对应，则该账单属于异常账单
                    {
                        element.VerificationStatus = Convert.ToString((int)status.异常);
                        element.ExMessage = "商品编码不对应";
                        dic.Add(element.DeliveryNumber + "," + element.PlatformMerchantCode, element.VerificationStatus);
                        continue;
                    }
                    var entity = xmDeliveryDetails.SingleOrDefault();
                    if (!entity.IsDelivery)
                    {
                        element.VerificationStatus = Convert.ToString((int)status.异常);
                        element.ExMessage = "发货单未发货";
                        dic.Add(element.DeliveryNumber + "," + element.PlatformMerchantCode, element.VerificationStatus);
                        continue;
                    }
                    var VerificationStatusArray = new[] {  Convert.ToString((int)status.全部核销),  Convert.ToString((int)status.异常) };
                    if (VerificationStatusArray.Contains(entity.VerificationStatus as string))
                    {
                        element.VerificationStatus = Convert.ToString((int)status.异常);
                        element.ExMessage = "对应的发货单已全部核销";
                        dic.Add(element.DeliveryNumber + "," + element.PlatformMerchantCode, element.VerificationStatus);
                        continue;
                    }
                    if (element.ProductNum != entity.ProductNum)
                    {
                        element.VerificationStatus = Convert.ToString((int)status.异常);
                        element.ExMessage = "商品数量不匹配";
                        dic.Add(element.DeliveryNumber + "," + element.PlatformMerchantCode, element.VerificationStatus);
                        continue;
                    }
                    if (element.Price != entity.FactoryPrice)
                    {
                        element.VerificationStatus = Convert.ToString((int)status.异常);
                        element.ExMessage = "商品价格不匹配";
                        dic.Add(element.DeliveryNumber + "," + element.PlatformMerchantCode, element.VerificationStatus);
                        continue;
                    }
                    element.VerificationStatus = Convert.ToString((int)status.全部核销);
                    dic.Add(element.DeliveryNumber + "," + element.PlatformMerchantCode, element.VerificationStatus);
                    #endregion
                }
                base.XMBillsservice.UpdateXMBills(verificationBillsList, dic);
               // base.XMBillsservice.UpdateXMDelivery(dic);
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
              
                #region 删除
                if (e.CommandName.Equals("XMBillsDelete"))
                {

                    var xMBills = base.XMBillsservice.GetXMBillsByBillID(Convert.ToInt32(e.CommandArgument));
                    if (xMBills.VerificationStatus == "1")//如果账单已核销则不得删除
                    {
                        base.ShowMessage("删除失败，该账单已核销");
                        return;
                    }
                    if (xMBills != null)//删除
                    {
                        base.XMBillsservice.DeleteXMBills(xMBills.BillID);
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                        base.ShowMessage("操作成功.");
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {

                base.ProcessException(ex);
            }

        }
    }
}