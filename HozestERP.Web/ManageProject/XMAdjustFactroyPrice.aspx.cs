using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using HozestERP.Web.Modules;

namespace HozestERP.Web.ManageProject
{
    public partial class XMAdjustFactroyPrice : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPayDateStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0).ToString();
                txtPayDateEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59, 59).ToString();

                chkByCount_Changed(sender, e);
            }
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

        public void SetTrigger()
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //更新订单成本价
                int PlatformTypeId = Convert.ToInt32(this.ddPlatformTypeId.SelectedValue.ToString());
                //时间类型
                int timetype = this.ddlOrderStatus.SelectedValue.Trim() != "" ? int.Parse(this.ddlOrderStatus.SelectedValue.Trim()) : 1;
                bool ByCount = this.chkByCount.Checked;
                int Count = 0;

                if (ByCount)
                {
                    if (!int.TryParse(this.txtCount.Text, out Count))
                    {
                        base.ShowMessage("数量必须为整数！");
                        return;
                    }
                    else
                    {
                        Count = int.Parse(this.txtCount.Text);
                    }
                }

                if (this.txtPayDateStart.Value.Trim() != "" || this.txtPayDateEnd.Value.Trim() != "")
                {
                    DateTime? DateStart = Convert.ToDateTime(txtPayDateStart.Value.Trim());
                    DateTime? DateEnd = Convert.ToDateTime(txtPayDateEnd.Value.Trim());
                    if (DateStart >= DateEnd)
                    {
                        base.ShowMessage("开始日期不能大于结束日期，请重新选择！");
                        return;
                    }

                    decimal factoryPrice = string.IsNullOrEmpty(txtAdjustFactroyPrice.Text.Trim()) ? 0 : Convert.ToDecimal(txtAdjustFactroyPrice.Text.Trim());
                    //string PlatformMerchantCode = string.Empty;
                    int productId = 0;
                    List<XMProduct> info = base.XMProductService.getXMProductListByEqusManufacturersCode(this.MerchantCode);
                    if (info != null && info.Count() > 0)
                    {
                        productId = info.SingleOrDefault().Id;
                    }

                    if (productId != 0)
                    {
                        List<XMProductDetails> productDetail = base.XMProductDetailsService.GetXMProductDetailsListByProductId(productId).Where(x => PlatformTypeId == -1 || x.PlatformTypeId == PlatformTypeId).ToList();
                        if (productDetail != null)
                        {
                            foreach (XMProductDetails p in productDetail)
                            {
                                if (p.PlatformMerchantCode != null)
                                {
                                    //获得满足条件的订单列表
                                    var list = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductListByParms(p.PlatformMerchantCode, DateStart, DateEnd, timetype, PlatformTypeId);

                                    if (list != null)
                                    {
                                        //if (PlatformTypeId != -1)
                                        //{
                                        //    Info = Info.Where(q => q.PlatFormTypeId == PlatformTypeId.ToString()).ToList();
                                        //}

                                        //循环遍历订单列表更新相关订单的出厂价
                                        foreach (XMOrderInfoProductDetails detail in list)
                                        {
                                            if (ByCount)
                                            {
                                                Count -= (int)detail.ProductNum;
                                                if (Count < 0)
                                                {
                                                    break;
                                                }
                                            }
                                            detail.FactoryPrice = factoryPrice;
                                            detail.UpdateDate = DateTime.Now;
                                            detail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                            base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(detail);
                                        }
                                    }

                                }
                            }
                        }
                    }
                    base.ShowMessage("操作成功！");
                }
            }
        }

        protected void chkByCount_Changed(object sender, EventArgs e)
        {
            if (this.chkByCount.Checked)
            {
                this.txtCount.Enabled = true;
            }
            else
            {
                this.txtCount.Enabled = false;
                this.txtCount.Text = "";
            }
        }

        public string MerchantCode
        {
            get
            {
                return CommonHelper.QueryString("MerchantCode");
            }
        }
    }
}