using System;
using System.Linq;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using HozestERP.BusinessLogic.ManageProject;
using System.Web.UI.WebControls;
using System.Transactions;

namespace HozestERP.Web.ManageInventory
{
    public partial class JDSaleRejectedAdd : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBind();
                BindInfo();
            }
        }

        private void BindInfo()
        {
            if (this.type == 0)           //新增
            {
                lblTitle.Text = "新建京东自营退货单";
                lblNumber.Visible = false;
                btnSingleJDIsConfirm.Visible = false;
                //btnSingleXBIsConfirm.Visible = false;
                btnSingleXLMIsConfirm.Visible = false;
                GetJDSaleRejectedList();
            }
            else if (this.type == 1)   //编辑
            {
                lblTitle.Text = "编辑京东自营退货单";

                lblNumber.Visible = true;
                lbl1.Visible = false;
                chkAutoID.Visible = false;
                txtSaleRejectedNumber.Visible = false;
                //lblMessage.Visible = false;
                BindGrid(this.JdSaleRejectID);
            }
            else                               //查看（无法保存）
            {
                lblTitle.Text = "查看采购订单";

                lblNumber.Visible = true;
                lbl1.Visible = false;
                chkAutoID.Visible = false;
                txtSaleRejectedNumber.Visible = false;
                //lblMessage.Visible = false;
                BindGrid2(this.JdSaleRejectID);
                btnSave.Visible = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            hiddType.Value = this.type.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetJDSaleRejectedList()
        {
            //新增
            if (this.type == 0)
            {
                string img1 = "<img src=\"../images/icons/101.png\" title=\"已确认\"  alt=\"已确认\"  />";
                StringBuilder str = new StringBuilder();
                str.Append("<table class='table' id='MyPurchaseProductList' >");
                str.Append("<tr >");
                str.Append("<th></th><th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>退货数量</th><th>退货单价</th><th>退货金额</th><th>操作</th><th>京东</th><th>新邦</th><th>喜临门</th></tr>");
                str.Append("<tr  id=\"mytr\">");
                str.Append("<td id=\"box\"><input id=\"ck\" type=\"checkbox\" runat=\"server\" value=''</td><td><input id=\"hiddProductId\" type=\"hidden\" /><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value=''  readonly=\"readonly\"/></td><td><input  id=\"txtProductName\" class=\"TextBox ProductName\"  type=\"text\" style=\"text-align: left;width: 90%\" value='' /></td><td style=\"width:10%\"><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='' /></td><td style=\"width:5%\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='0' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td style=\"width:5%\"><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td><td>" + img1 + "</td><td>" + img1 + "</td><td>" + img1 + "</td></tr>");
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="JdSaleRejectID"></param>
        private void BindGrid(int JdSaleRejectID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th></th><th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>退货数量</th><th>退货单价</th><th>退货金额</th><th>操作</th><th>京东</th><th>新邦</th><th>喜临门</th></tr>");
            var jdSaleRejects = base.XMJDSaleRejectedService.GetXMJDSaleRejectedById(JdSaleRejectID);
            if (jdSaleRejects != null)
            {              
                var jdSaleRejectedPorductDetail = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(JdSaleRejectID);
                lblNumber.Text = jdSaleRejects.Ref;
                //ddlNick.Value = jdSaleRejects.NickId.ToString();
                if (!string.IsNullOrEmpty(jdSaleRejects.NickId.ToString()))
                {
                    var nick = base.XMNickService.GetXMNickByID(jdSaleRejects.NickId.Value);
                    if (nick != null)
                    {
                        ddXMProject.Value = nick.ProjectId.ToString();
                    }
                }
                var nick2 = base.XMNickService.GetXMNickByID(jdSaleRejects.NickId.Value);
                this.BindddXMProject();//项目
                ddXMProject.Value = nick2.ProjectId.ToString();
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlNick.Value = jdSaleRejects.NickId.ToString();
                DdlFactory.Value = jdSaleRejects.FactoryID.ToString();

                txtStorageDate.Value = jdSaleRejects.BizDt.ToString();
                ddlReturnCategoryList.SelectedValue = jdSaleRejects.ReturnCategoryID.Value.ToString();
                txtNote.Text = jdSaleRejects.Note;
                txtPrepareRef.Text = jdSaleRejects.PrepareRef;
                if (jdSaleRejectedPorductDetail != null && jdSaleRejectedPorductDetail.Count > 0)
                {
                    foreach (XMJDSaleRejectedProductDetail Info in jdSaleRejectedPorductDetail)
                    {
                        string img1 = "";
                        string img2 = "";
                        string img3 = "";
                        if (Info.JDIsConfirm == null)
                            Info.JDIsConfirm = false;
                        if (Info.JDIsConfirm.Value)
                        {
                            img1 = "<img src=\"../images/icons/102.png\" title=\"已确认\"  alt=\"已确认\"  />";
                        }
                        else
                        {
                            img1 = "<img src=\"../images/icons/101.png\" title=\"未确认\"  alt=\"未确认\"  />";
                        }
                        if (Info.XBIsConfirm == null)
                            Info.XBIsConfirm = false;
                        if (Info.XBIsConfirm.Value)
                        {
                            img2 = "<img src=\"../images/icons/102.png\" title=\"已确认\"  alt=\"已确认\"  />";
                        }
                        else
                        {
                            img2 = "<img src=\"../images/icons/101.png\" title=\"未确认\"  alt=\"未确认\"  />";
                        }
                        if (Info.XLMIsConfirm == null)
                            Info.XLMIsConfirm = false;
                        if (Info.XLMIsConfirm.Value)
                        {
                            img3 = "<img src=\"../images/icons/102.png\" title=\"已确认\"  alt=\"已确认\"  />";
                        }
                        else
                        {
                            img3 = "<img src=\"../images/icons/101.png\" title=\"未确认\"  alt=\"未确认\"  />";
                        }
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td id=\"box\"><input id=\"ck\" type=\"checkbox\" runat=\"server\" value='" + Info.Id + "'</td><td><input id=\"hiddProductId\" type=\"hidden\"  value='" + Info.ProductId + "'/><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.PlatformMerchantCode + "'   readonly=\"readonly\"/></td><td><input  id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" value='" + Info.ProductName + "'   type=\"text\"/></td><td style=\"width:10%\"><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + Info.Specifications + "' /></td><td style=\"width:5%\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.RejectionCount.ToString() + "' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.RejectionPrice.ToString() + "' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.RejectionMoney.ToString() + "' /></td><td style=\"width:5%\"><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td><td>" + img1 + "</td><td>" + img2 + "</td><td>" + img3 + "</td></tr>");
                    }
                }
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JdSaleRejectID"></param>
        private void BindGrid2(int JdSaleRejectID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th></th><th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>退货数量</th><th>退货单价</th><th>退货金额</th><th>京东</th><th>新邦</th><th>喜临门</th></tr>");
            var jdSaleRejects = base.XMJDSaleRejectedService.GetXMJDSaleRejectedById(JdSaleRejectID);
            if (jdSaleRejects != null)
            {
                var jdSaleRejectedPorductDetail = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(JdSaleRejectID);
                lblNumber.Text = jdSaleRejects.Ref;
                //ddlNick.Value = jdSaleRejects.NickId.ToString();
                if (!string.IsNullOrEmpty(jdSaleRejects.NickId.ToString()))
                {
                    var nick = base.XMNickService.GetXMNickByID(jdSaleRejects.NickId.Value);
                    if (nick != null)
                    {
                        ddXMProject.Value = nick.ProjectId.ToString();
                    }
                }
                var nick2 = base.XMNickService.GetXMNickByID(jdSaleRejects.NickId.Value);
                this.BindddXMProject();//项目
                ddXMProject.Value = nick2.ProjectId.ToString();
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlNick.Value = jdSaleRejects.NickId.ToString();
                txtStorageDate.Value = jdSaleRejects.BizDt.ToString();
                ddlReturnCategoryList.SelectedValue = jdSaleRejects.ReturnCategoryID.Value.ToString();
                txtNote.Text = jdSaleRejects.Note;
                if (jdSaleRejectedPorductDetail != null && jdSaleRejectedPorductDetail.Count > 0)
                {
                    foreach (XMJDSaleRejectedProductDetail Info in jdSaleRejectedPorductDetail)
                    {
                        string img1 = "";
                        string img2 = "";
                        string img3 = "";
                        if (Info.JDIsConfirm == null)
                            Info.JDIsConfirm = false;
                        if (Info.JDIsConfirm.Value)
                        {
                            img1 = "<img src=\"../images/icons/102.png\" title=\"已确认\"  alt=\"已确认\"  />";
                        }
                        else
                        {
                            img1 = "<img src=\"../images/icons/101.png\" title=\"未确认\"  alt=\"未确认\"  />";
                        }
                        if (Info.XBIsConfirm == null)
                            Info.XBIsConfirm = false;
                        if (Info.XBIsConfirm.Value)
                        {
                            img2 = "<img src=\"../images/icons/102.png\" title=\"已确认\"  alt=\"已确认\"  />";
                        }
                        else
                        {
                            img2 = "<img src=\"../images/icons/101.png\" title=\"未确认\"  alt=\"未确认\"  />";
                        }
                        if (Info.XLMIsConfirm == null)
                            Info.XLMIsConfirm = false;
                        if (Info.XLMIsConfirm.Value)
                        {
                            img3 = "<img src=\"../images/icons/102.png\" title=\"已确认\"  alt=\"已确认\"  />";
                        }
                        else
                        {
                            img3 = "<img src=\"../images/icons/101.png\" title=\"未确认\"  alt=\"未确认\"  />";
                        }
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td id=\"box\"><input id=\"ck\" type=\"checkbox\" runat=\"server\" value='" + Info.Id + "'</td><td><input id=\"hiddProductId\" type=\"hidden\"  value='" + Info.ProductId + "'/><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.PlatformMerchantCode + "'   readonly=\"readonly\"/></td><td><input  id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" value='" + Info.ProductName + "'   type=\"text\"/></td><td style=\"width:10%\"><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + Info.Specifications + "' /></td><td style=\"width:5%\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.RejectionCount.ToString() + "' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.RejectionPrice.ToString() + "' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.RejectionMoney.ToString() + "' /></td><td>" + img1 + "</td><td>" + img2 + "</td><td>" + img3 + "</td></tr>");
                    }
                }
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^[0-9]*[1-9][0-9]*$");
            return reg1.IsMatch(str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonContent"></param>
        public void BindGrid(string jsonContent)
        {
            var jdSaleRejects = base.XMJDSaleRejectedService.GetXMJDSaleRejectedById(JdSaleRejectID);
            
            this.BindddXMProject();//项目
            if (this.type != 0)
            {
                var nick = base.XMNickService.GetXMNickByID(jdSaleRejects.NickId.Value);
                ddXMProject.Value = nick.ProjectId.ToString();
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlNick.Value = jdSaleRejects.NickId.ToString();
            }
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>退货数量</th><th>退货单价</th><th>退货金额</th><th>操作</th></tr>");
            if (jsonContent != "")
            {
                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(jsonContent);
                for (int i = 0; i < ja_goods.Count; i++)
                {
                    int productId = 0;
                    int productCount = 0;
                    string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                    var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                    if (product != null)
                    {
                        productId = product.Id;
                    }
                    string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                    string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                    bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                    if (t)
                    {
                        productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                    }
                    string productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim();      //退货单价
                    string productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim();      //退货金额
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td><input id=\"hiddProductId\" type=\"hidden\" value='" + productId + "'/><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCode + "'  readonly=\"readonly\"/></td><td><input  id=\"txtProductName\" class=\"TextBox ProductName\"  type=\"text\" style=\"text-align: left;width: 90%\" value='" + productName + "' /></td><td style=\"width:10%\"><input style=\"background: transparent; border: 0; width: 55px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + specifications + "' /></td><td style=\"width:5%\"><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCount + "' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductPrice\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productPrice + "' /></td><td style=\"width:8%\"><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productMoney + "' /></td><td style=\"width:5%\"><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");

                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }



        //绑定
        private void loadBind()
        {
              this.BindddXMProject();//项目       
            BindFactory();
        }

        private void BindFactory()
        {
            var CodeList = CodeService.GetCodeListInfoByCodeTypeID(245);
            FactoryStore.DataSource = CodeList;
            FactoryStore.DataBind();
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

            BindFactory();

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 682 || HozestERPContext.Current.User.CustomerID == 670)
            {
                ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                Ext.Net.Store Store = ddXMProject.GetStore();
                projectList.Add(new XMProject()
                {
                    ProjectName = "---所有---",
                    Id = -1,
                });
                Store.DataSource = projectList.OrderBy(a => a.Id);
                Store.DataBind();
                ddXMProject.SelectedIndex = 0;
                ddXMProject.Value = "-1";
            }
            else
            {
                ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    Ext.Net.ListItem liProject = new Ext.Net.ListItem();
                    liProject.Text = "---无项目权限---";
                    liProject.Value = "0";
                    ddXMProject.Items.Add(liProject);
                    ddXMProject.Value = 0;
                }
                else
                {
                    Ext.Net.Store Store = ddXMProject.GetStore();
                    Store.DataSource = projectList;
                    Store.DataBind();
                    ddXMProject.SelectedIndex = 0;
                    ddXMProject.Value = projectList.ToList()[0].Id;
                    Ext.Net.ListItem liProject1 = new Ext.Net.ListItem();
                    liProject1.Text = "---所有---";
                    liProject1.Value = "99";
                    ddXMProject.Items.Add(liProject1);
                    ddXMProject.Value = 99;
                }
            }
            #endregion
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.Value.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.Value)); 
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    int ProjectID = Convert.ToInt32(this.ddXMProject.Value);
                    var Nick = base.XMNickService.GetXMNickListByProjectId(ProjectID);
                    Ext.Net.Store Store = ddlNick.GetStore();
                    Store.DataSource = nickList;
                    Store.DataBind();
                }
                else
                {
                    //其他
                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.Value), HozestERPContext.Current.User.CustomerID, 0);
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    if (nickList.Count() == 0)
                    {
                        Ext.Net.ListItem liProject = new Ext.Net.ListItem();
                        liProject.Text = "---无店铺权限---";
                        liProject.Value = "0";
                        ddXMProject.Items.Add(liProject);
                        ddXMProject.Value = 0;
                    }
                    else
                    {
                        if (nickList.Count() > 0)
                        {
                            int ProjectID = Convert.ToInt32(this.ddXMProject.Value);
                            var Nick = base.XMNickService.GetXMNickListByProjectId(ProjectID);
                            Ext.Net.Store Store = ddlNick.GetStore();
                            Store.DataSource = nickList;
                            Store.DataBind();
                        }
                        //this.ddlNick.Items.Insert(0, new ListItem("---所有---", "99"));
                    }
                }
            }
            //BindInfo();
        }

        public void Face_Init()
        {
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(230, false);
            this.ddlReturnCategoryList.DataSource = codeList;
            this.ddlReturnCategoryList.DataTextField = "CodeName";
            this.ddlReturnCategoryList.DataValueField = "CodeID";
            this.ddlReturnCategoryList.DataBind();
        }

        public void SetTrigger()
        {
        }

        /// <summary>
        /// 自动生成退货单号
        /// </summary>
        /// <returns></returns>
        private string AutoSaleRejectedNumber()
        {
            string saleRejectCode = "";       //自动生成退货单号
            int number = 1;
            var saleRejects = base.XMJDSaleRejectedService.GetXMJDSaleRejectedList();
            if (saleRejects != null && saleRejects.Count > 0)
            {
                number = saleRejects[0].Id + 1;
            }
            saleRejectCode = "TH" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return saleRejectCode;
        }

        public bool IsFloat(string str)
        {
            //
            Regex reg1 = new Regex(@"^[+]?([0-9]*\.?[0-9]+|[0-9]+\.?[0-9]*)([eE][+-]?[0-9]+)?$");
            return reg1.IsMatch(str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal value = 0;
            if (this.type == 0)            //新增
            {
                string saleRejectCode = "";
                bool isEmpty = false;      //判断厂家编码是否填写（厂家编码必填）
                bool isFalse = false;         //判断数量（数量不能为0）
                string hiddjsonContent = hdfJsonContent.Value;             //产品列表 json
                //string saleRejectCode = AutoSaleRejectedNumber();
                string ss = hiddAutoID.Value;
                bool isAuto = bool.Parse(hiddAutoID.Value);
                if (isAuto)              //只读  自动生成采购单号
                {
                    saleRejectCode = AutoSaleRejectedNumber();
                }
                else
                {
                    saleRejectCode = txtSaleRejectedNumber.Text.Trim();
                    if (string.IsNullOrEmpty(saleRejectCode))
                    {
                        base.ShowMessage("采购单号必须填写！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                }
                //var saleRejects = base.XMJDSaleRejectedService.GetXMJDSaleRejectedBySaleRejectCode(saleRejectCode);
                //if (saleRejects != null && saleRejects.Count() > 0)
                //{
                //    base.ShowMessage("采购单号已存在 !");
                //    BindGrid(hiddjsonContent);
                //    return;
                //}
                int BizUserId = HozestERPContext.Current.User.CustomerID;    //采购人
                decimal totalMoney = 0;        //退货单总价
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        if (productCode == "")           //厂家编码存在为空的
                        {
                            isEmpty = true;
                        }

                        string productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim();      //采购单价
                        string productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim();      //采购单价

                        bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                        if (!t || !IsFloat(productPrice) || !IsFloat(productMoney))
                        {
                            base.ShowMessage("输入格式不正确！");
                            BindGrid(hiddjsonContent);
                            return;
                        }
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量
                        if (productCount == 0)
                        {
                            isFalse = true;
                        }
                        totalMoney = totalMoney + decimal.Parse(productMoney);
                    }
                }

                if (ddlNick.Value == "" || ddlNick.Value == null)
                {
                    base.ShowMessage("请添加仓库或未选择仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (isEmpty)
                {
                    base.ShowMessage("厂家编码不能为空！请输入厂家编码");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (isFalse)
                {
                    base.ShowMessage("商品退货数量不能为 0！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (ddlReturnCategoryList.SelectedValue == "")
                {
                    base.ShowMessage("请选择退货类型！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                string note = txtNote.Text.Trim();

                XMJDSaleRejected jdSaleRejected = new XMJDSaleRejected();
                jdSaleRejected.Ref = saleRejectCode;
                jdSaleRejected.PrepareRef = txtPrepareRef.Text.Trim();
                jdSaleRejected.FactoryID = int.Parse(DdlFactory.Value.ToString());
                jdSaleRejected.ReturnMoney = totalMoney;
                jdSaleRejected.ReturnCategoryID = Convert.ToInt16(ddlReturnCategoryList.SelectedValue);
                jdSaleRejected.BizUserId = HozestERPContext.Current.User.CustomerID;
                jdSaleRejected.BizDt = DateTime.Parse(this.txtStorageDate.Value);
                jdSaleRejected.CreateDate = jdSaleRejected.UpdateDate = DateTime.Now;
                jdSaleRejected.CreateID = jdSaleRejected.UpdateID = HozestERPContext.Current.User.CustomerID;
                //jdSaleRejected.JDIsConfirm = jdSaleRejected.XBIsConfirm = jdSaleRejected.XLMIsConfirm = false;
                jdSaleRejected.IsEnable = false;
                if (Convert.ToInt16(ddlNick.Value) != -1 && Convert.ToInt16(ddlNick.Value) != 99)
                {
                    jdSaleRejected.NickId = Convert.ToInt16(ddlNick.Value);
                }
                jdSaleRejected.Note = note;
                base.XMJDSaleRejectedService.InsertXMJDSaleRejected(jdSaleRejected);
                int jdSaleRejectedId = jdSaleRejected.Id;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                        string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                        decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //退货单价
                        decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //退货金额
                        XMJDSaleRejectedProductDetail details = new XMJDSaleRejectedProductDetail();
                        details.JDRejectedID = jdSaleRejectedId;
                        var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                        if (product != null)
                        {
                            details.ProductId = product.Id;
                        }
                        details.PlatformMerchantCode = productCode;
                        details.RejectionCount = productCount;
                        details.RejectionMoney = productMoney;
                        details.RejectionPrice = productPrice;
                        details.JDIsConfirm = false;
                        details.XBIsConfirm = false;
                        details.XLMIsConfirm = false;
                        details.CreateID = details.UpdateID = HozestERPContext.Current.User.CustomerID;
                        details.CreateDate = details.UpdateDate = DateTime.Now;
                        details.IsEnable = false;
                        base.XMJDSaleRejectedProductDetailService.InsertXMJDSaleRejectedProductDetail(details);
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(jdSaleRejectedId);
            }
            else                       //编辑
            {
                bool isEmpty = false;      //判断厂家编码是否填写（厂家编码必填）
                bool isFalse = false;         //判断退货数量（数量不能为0）
                int id = this.JdSaleRejectID;
                decimal totalMoney = 0;        //退货单总价
                string hiddjsonContent = hdfJsonContent.Value;             //产品列表 json
                var jdSaleRejected = base.XMJDSaleRejectedService.GetXMJDSaleRejectedById(id);
                if (jdSaleRejected != null)
                {
                    var jsSaleRejectedDetails = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailListByjdSaleRejectID(jdSaleRejected.Id);
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            if (productCode == "")           //厂家编码存在为空的
                            {
                                isEmpty = true;
                            }
                            bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                            string productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim();      //采购单价

                            string productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim();      //采购单价
                            if (!t || !IsFloat(productPrice) || !IsFloat(productMoney))
                            {
                                base.ShowMessage("输入格式不正确！");
                                BindGrid(hiddjsonContent);
                                return;
                            }
                            int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //采购数量
                            if (productCount == 0)
                            {
                                isFalse = true;
                            }
                            totalMoney = totalMoney + decimal.Parse(productMoney);
                        }
                    }
                    if (isEmpty)
                    {
                        base.ShowMessage("厂家编码不能为空！请输入厂家编码");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    if (isFalse)
                    {
                        base.ShowMessage("退货数量不能为 0  !");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    if (ddlReturnCategoryList.SelectedValue == "")
                    {
                        base.ShowMessage("请选择退货类型！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    jdSaleRejected.PrepareRef = txtPrepareRef.Text.Trim();
                    jdSaleRejected.ReturnMoney = totalMoney;
                    int FactoryID = 0;
                    if(int.TryParse(DdlFactory.Value.ToString(), out FactoryID))
                    {
                        jdSaleRejected.FactoryID = FactoryID;
                    }
                    else
                    {
                        jdSaleRejected.FactoryID = null;
                    }
                    jdSaleRejected.ReturnCategoryID = int.Parse(ddlReturnCategoryList.SelectedValue);
                    jdSaleRejected.Note = txtNote.Text.Trim();
                    jdSaleRejected.BizDt = DateTime.Parse(this.txtStorageDate.Value);
                    jdSaleRejected.UpdateDate = DateTime.Now;
                    jdSaleRejected.UpdateID = HozestERPContext.Current.User.CustomerID;
                    if (Convert.ToInt16(ddlNick.Value) != -1 && Convert.ToInt16(ddlNick.Value) != 99)
                    {
                        jdSaleRejected.NickId = Convert.ToInt16(ddlNick.Value);
                    }
                    base.XMJDSaleRejectedService.UpdateXMJDSaleRejected(jdSaleRejected);
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            bool isExsit = false;                //判断厂家编码是否存在
                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                            string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                            int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //退货数量
                            decimal productPrice = ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductPrice"].ToString().Replace('\"', ' ').Trim());      //退货单价
                            decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //退货金额
                            foreach (XMJDSaleRejectedProductDetail info in jsSaleRejectedDetails)
                            {
                                if (productCode == info.PlatformMerchantCode)
                                {
                                    isExsit = true;
                                    info.RejectionCount = productCount;
                                    info.RejectionMoney = productMoney;
                                    info.RejectionPrice = productPrice;
                                    info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    info.UpdateDate = DateTime.Now;
                                    base.XMJDSaleRejectedProductDetailService.UpdateXMJDSaleRejectedProductDetail(info);
                                }
                            }
                            if (ja_goods.Count > jsSaleRejectedDetails.Count && isExsit == false)             //不存在新增
                            {
                                XMJDSaleRejectedProductDetail detail = new XMJDSaleRejectedProductDetail();
                                detail.JDRejectedID = jdSaleRejected.Id;
                                var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                                if (product != null)
                                {
                                    detail.ProductId = product.Id;
                                }
                                detail.PlatformMerchantCode = productCode;
                                detail.RejectionCount = productCount;
                                detail.RejectionMoney = productMoney;
                                detail.RejectionPrice = productPrice;
                                detail.CreateDate = DateTime.Now;
                                detail.CreateID = detail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                detail.UpdateDate = DateTime.Now;
                                detail.IsEnable = false;
                                base.XMJDSaleRejectedProductDetailService.InsertXMJDSaleRejectedProductDetail(detail);
                            }
                        }
                    }

                    if (jsSaleRejectedDetails != null && jsSaleRejectedDetails.Count > 0)
                    {
                        foreach (XMJDSaleRejectedProductDetail info in jsSaleRejectedDetails)
                        {
                            bool isDelete = true;
                            if (hiddjsonContent != "")
                            {
                                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                                for (int i = 0; i < ja_goods.Count; i++)
                                {
                                    string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                                    if (productCode == info.PlatformMerchantCode)
                                    {
                                        isDelete = false;
                                        break;
                                    }
                                }
                            }
                            if (isDelete)
                            {
                                info.IsEnable = true;
                                info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                info.UpdateDate = DateTime.Now;
                                base.XMJDSaleRejectedProductDetailService.UpdateXMJDSaleRejectedProductDetail(info);
                            }
                        }
                    }

                }
                base.ShowMessage("操作成功!");
                BindGrid(jdSaleRejected.Id);
            }
        }


        /// <summary>
        /// 京东收货确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSingleJDIsConfirm_Click(object sender, EventArgs e)
        {
            bool isSucess = false;
            string xMJdSaleRejecteDetailIDs = hiddIDs.Value;
            if (string.IsNullOrEmpty(xMJdSaleRejecteDetailIDs))
            {
                base.ShowMessage("未选择相应的数据！");
                return;
            }
            else
            {
                string[] Ids = xMJdSaleRejecteDetailIDs.Split(',');
                if (Ids.Length > 0)
                {
                    foreach (string s in Ids)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            var detail = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailById(int.Parse(s));
                            if (detail != null)
                            {
                                isSucess = true;
                                detail.JDIsConfirm = true;
                                detail.JDConfirmDate = DateTime.Now;
                                detail.JDConfirmer = HozestERPContext.Current.User.CustomerID;
                                base.XMJDSaleRejectedProductDetailService.UpdateXMJDSaleRejectedProductDetail(detail);
                            }
                        }
                    }
                }
            }
            if (isSucess)
            {
                base.ShowMessage("操作成功！");
                BindGrid(JdSaleRejectID);
            }
            else
            {
                base.ShowMessage("操作失败！");
                BindGrid(JdSaleRejectID);
            }
        }
        /// <summary>
        /// 推送千胜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnSingleXBIsConfirm_Click(object sender, EventArgs e)
        //{
        //    bool isSucess = false;
        //    string xMJdSaleRejecteDetailIDs = hiddIDs.Value;
        //    if (string.IsNullOrEmpty(xMJdSaleRejecteDetailIDs))
        //    {
        //        base.ShowMessage("未选择相应的数据！");
        //        return;
        //    }
        //    else
        //    {
        //        string[] Ids = xMJdSaleRejecteDetailIDs.Split(',');
        //        if (Ids.Length > 0)
        //        {
        //            foreach (string s in Ids)
        //            {
        //                if (!string.IsNullOrEmpty(s))
        //                {
        //                    var detail = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailById(int.Parse(s));
        //                    if (detail != null)
        //                    {
        //                        if (detail.JDIsConfirm.Value)     //京东确认后 方可兴邦确认
        //                        {
        //                            isSucess = true;
        //                            detail.XBIsConfirm = true;
        //                            detail.XBConfirmDate = DateTime.Now;
        //                            detail.XBConfirmer = HozestERPContext.Current.User.CustomerID;
        //                            base.XMJDSaleRejectedProductDetailService.UpdateXMJDSaleRejectedProductDetail(detail);
        //                        }
        //                        else
        //                        {
        //                            base.ShowMessage("京东还未确认收货，无法执行相关操作！");
        //                            return;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    if (isSucess)
        //    {
        //        base.ShowMessage("操作成功！");
        //        BindGrid(JdSaleRejectID);
        //    }
        //    else
        //    {
        //        base.ShowMessage("操作失败！");
        //        BindGrid(JdSaleRejectID);
        //    }
        //}

        /// <summary>
        /// 喜临门确认收货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSingleXLMIsConfirm_Click(object sender, EventArgs e)
        {
            bool isSucess = false;
            string xMJdSaleRejecteDetailIDs = hiddIDs.Value;
            if (string.IsNullOrEmpty(xMJdSaleRejecteDetailIDs))
            {
                base.ShowMessage("未选择相应的数据！");
                return;
            }
            else
            {
                string[] Ids = xMJdSaleRejecteDetailIDs.Split(',');
                if (Ids.Length > 0)
                {
                    foreach (string s in Ids)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            var detail = base.XMJDSaleRejectedProductDetailService.GetXMJDSaleRejectedProductDetailById(int.Parse(s));
                            if (detail != null)
                            {
                                if (detail.XBIsConfirm.Value)    //新邦确认后  喜临门确认
                                {
                                    isSucess = true;
                                    detail.XLMIsConfirm = true;
                                    detail.XLMConfirmDate = DateTime.Now;
                                    detail.XLMConfirmer = HozestERPContext.Current.User.CustomerID;
                                    base.XMJDSaleRejectedProductDetailService.UpdateXMJDSaleRejectedProductDetail(detail);
                                }
                                else
                                {
                                    base.ShowMessage("新邦还未确认收货，无法执行相关操作！");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            if (isSucess)
            {
                base.ShowMessage("操作成功！");
                BindGrid(JdSaleRejectID);
            }
            else
            {
                base.ShowMessage("操作失败！");
                BindGrid(JdSaleRejectID);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int JdSaleRejectID
        {
            get { return CommonHelper.QueryStringInt("JdSaleRejectID"); }
        }
        /// <summary>
        /// 判断是添加还是修改
        /// </summary>
        public int type
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }
    }
}