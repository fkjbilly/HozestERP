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

namespace HozestERP.Web.ManageInventory
{
    public partial class PdAdd : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindddXMProject();//项目
                BindInfo();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void BindInfo()
        {
            if (this.type == 0)           //新增
            {
                lblTitle.Text = "新建盘点单";
                lblRef.Visible = false;
                GetPdList();
            }
            else if (this.type == 1)   //编辑
            {
                lblTitle.Text = "编辑盘点单";
                lblMessage.Visible = false;
                BindGrid(this.scid);
            }
            else                               //查看（无法保存）
            {
                lblTitle.Text = "查看盘点单";
                lblMessage.Visible = false;
                BindGrid(this.scid);
                btnSave.Visible = false;
            }
        }

        private void GetPdList()
        {
            this.BindddXMProject();
            this.ddXMProject_SelectedIndexChanged(null, null);//店铺
            //新增
            if (this.type == 0)
            {
                StringBuilder str = new StringBuilder();
                str.Append("<table class='table' id='MyPurchaseProductList' >");
                str.Append("<tr >");
                str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>盘点后库存数量</th><th>单位</th><th>盘点后库存金额</th><th>操作</th></tr>");
                str.Append("<tr  id=\"mytr\">");
                str.Append("<td><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value=''  readonly=\"readonly\"/></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" value=''  type=\"text\"/></td><td><input style=\"background: transparent; border: 0; width: 95px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='' readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }

        private void BindGrid(int pdID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>盘点后库存数量</th><th>单位</th><th>盘点后库存金额</th><th>操作</th></tr>");
            //绑定盘点单主表和产品明细表
            var pdInfo = base.XMPdInfoService.GetXMPdInfoById(pdID);
            if (pdInfo != null)
            {
                lblRef.Text = pdInfo.Ref;
                if (!string.IsNullOrEmpty(pdInfo.ProjectId.ToString()))
                {
                    if (pdInfo.ProjectId == -1)
                    {
                        ddXMProject.SelectedIndex = 0;
                    }
                    else
                    {
                        ddXMProject.Value = pdInfo.ProjectId.ToString();
                    }
                }
                var pdInfoProductDetail = base.XMPdInfoProductDetailsService.GetXMPdInfoProductDetailsListByPdID(pdInfo.Id);
                txtDeliveryDate.Value = pdInfo.BizDt.ToString() == "" ? DateTime.Now.ToShortDateString() : pdInfo.BizDt.ToString();
                this.BindddXMProject();//项目
                if (pdInfo.ProjectId == -1)
                {
                    ddXMProject.SelectedIndex = 0;
                }
                else
                {
                    ddXMProject.Value = pdInfo.ProjectId.ToString();
                }
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlwareHouses.Value = pdInfo.WarehouseId.ToString();
                txtNote.Text = pdInfo.BillMemo;
                if (pdInfoProductDetail != null && pdInfoProductDetail.Count > 0)
                {
                    foreach (XMPdInfoProductDetails Info in pdInfoProductDetail)
                    {
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.PlatformMerchantCode + "'  readonly=\"readonly\"/></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\" type=\"text\" style=\"text-align: left;width: 90%\" value='" + Info.ProductName + "' /></td><td><input style=\"background: transparent; border: 0; width: 95px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + Info.Specifications + "' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.PCount.ToString() + "' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='" + Info.ProductUnit + "' readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.PMoney.ToString() + "' /></td><td><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                    }
                }
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }
        /// <summary>
        /// 通过json数据绑定产品列表
        /// </summary>
        /// <param name="jsonContent"></param>
        private void BindGrid(string jsonContent)
        {
            var pdInfo = base.XMPdInfoService.GetXMPdInfoById(this.scid);
            this.BindddXMProject();//项目

            
            //新增
            if (this.type != 0)
            {
                ddXMProject.Value = pdInfo.ProjectId.ToString();
                this.ddXMProject_SelectedIndexChanged(null, null);//店铺
                ddlwareHouses.Value = pdInfo.WarehouseId.ToString();
            }
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>盘点后库存数量</th><th>单位</th><th>盘点后库存金额</th><th>操作</th></tr>");
            if (jsonContent != "")
            {
                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(jsonContent);
                for (int i = 0; i < ja_goods.Count; i++)
                {
                    string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                    string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                    string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                    string productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim();      //盘点后库存数量
                    string unit = ja_goods[i]["txtUnit"].ToString().Replace('\"', ' ').Trim();      //单位
                    string productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim();      //盘点后库存金额
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCode + "'  readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox\" style=\"text-align: left;width: 90%\" value='" + productName + "' /></td><td><input style=\"background: transparent; border: 0; width: 95px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + specifications + "' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCount + "' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='" + unit + "' readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductMoney\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productMoney + "' /></td><td><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }



        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddXMProject.Value.ToString().Trim().Length > 0)
            {
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                                         .GroupBy(p => new { p.Id, p.ProjectName })
                                         .Select(p => new
                                         {
                                             Id = p.Key.Id,
                                             ProjectName = p.Key.ProjectName
                                         });
                string paramprojectIDs = "";
                string paramprojectIDSelect = this.ddXMProject.Value.ToString();
                if (paramprojectIDSelect == "-1" || paramprojectIDSelect == "99")
                {
                    for (int i = 0; i < projectList.ToList().Count; i++)
                    {
                        paramprojectIDs = paramprojectIDs + projectList.ToList()[i].Id + ",";
                    }
                    paramprojectIDs = paramprojectIDs.Substring(0, paramprojectIDs.Length - 1) + ",-1";
                }
                else
                {
                    paramprojectIDs = paramprojectIDSelect;
                }
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectIds(paramprojectIDs);
                Ext.Net.Store Store = ddlwareHouses.GetStore();
                Store.DataSource = wareHouses;
                Store.DataBind();
                //ddlwareHouses.SelectedIndex = 0;
            }
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

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

        /// <summary>
        /// 自动生成盘点单号
        /// </summary>
        /// <returns></returns>
        private string AutoPdNumber()
        {
            string PdCode = "";       //自动生成盘点单号
            int number = 1;
            var pd = base.XMPdInfoService.GetXMPdInfoList();
            if (pd != null && pd.Count > 0)
            {
                number = pd[0].Id + 1;
            }
            PdCode = "PD" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return PdCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^[0-9]*[0-9][0-9]*$");
            return reg1.IsMatch(str);
        }

        public bool IsFloat(string str)
        {
            //
            Regex reg1 = new Regex(@"^[+]?([0-9]*\.?[0-9]+|[0-9]+\.?[0-9]*)([eE][+-]?[0-9]+)?$");
            return reg1.IsMatch(str);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal value = 0;
            if (this.type == 0)            //新增
            {
                bool isFalse = false;
                bool isEmpty = false;
                string pdCode = AutoPdNumber();
                string hiddjsonContent = hdfJsonContent.Value;             //产品列表 json
                if (ddlwareHouses.Value == "" || ddlwareHouses.Value == null)
                {
                    base.ShowMessage("请添加仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (int.Parse(ddlwareHouses.Value.ToString()) == -1)
                {
                    base.ShowMessage("请添加仓库或未选择仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                string wfID = ddlwareHouses.Value.ToString();
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        string productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim();      //盘点后库存金额
                        bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                        if (!t || !IsFloat(productMoney))
                        {
                            base.ShowMessage("盘点后库存数量或盘点后库存金额格式不正确！");
                            BindGrid(hiddjsonContent);
                            return;
                        }
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //盘点后库存数量
                        if (productCount < 0)
                        {
                            isFalse = true;
                        }
                        if (productCode == "")
                        {
                            isEmpty = true;
                        }
                    }
                }
                if (isEmpty)
                {
                    base.ShowMessage("厂家编码不能为空！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (isFalse)
                {
                    base.ShowMessage("数量不能小于0！");
                    BindGrid(hiddjsonContent);
                    return;
                }

                XMPdInfo pdInfo = new XMPdInfo();
                pdInfo.Ref = pdCode;
                pdInfo.WarehouseId = int.Parse(ddlwareHouses.Value.ToString());
                pdInfo.BillStatus = 0;    //盘点单状态   （默认为 0 待盘点）
                pdInfo.BillMemo = txtNote.Text.Trim();
                pdInfo.BizUserId = HozestERPContext.Current.User.CustomerID;
                pdInfo.BizDt = txtDeliveryDate.Value == "" ? DateTime.Now : Convert.ToDateTime(txtDeliveryDate.Value);
                pdInfo.CreateID = pdInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                pdInfo.CreateDate = pdInfo.UpdateDate = DateTime.Now;
                pdInfo.IsEnable = false;
                base.XMPdInfoService.InsertXMPdInfo(pdInfo);
                int pdid = pdInfo.Id;

                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                        string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //盘点后库存数量
                        string unit = ja_goods[i]["txtUnit"].ToString().Replace('\"', ' ').Trim();      //单位
                        decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //盘点后库存金额

                        XMPdInfoProductDetails details = new XMPdInfoProductDetails();
                        details.PdId = pdid;
                        var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                        if (product != null)
                        {
                            details.ProductId = product.Id;
                        }
                        details.PlatformMerchantCode = productCode;
                        details.PCount = productCount;
                        details.PMoney = productMoney;
                        details.CreateDate = details.Updatedate = DateTime.Now;
                        details.CreateID = details.UpdateID = HozestERPContext.Current.User.CustomerID;
                        details.IsEnable = false;
                        base.XMPdInfoProductDetailsService.InsertXMPdInfoProductDetails(details);
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(pdInfo.Id);
            }
            else                               //编辑
            {
                bool isEmpty = false;
                bool isFalse = false;
                string hiddjsonContent = hdfJsonContent.Value;             //产品列表 json

                if (ddlwareHouses.Value == "" || ddlwareHouses.Value == null)
                {
                    base.ShowMessage("请添加仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (int.Parse(ddlwareHouses.Value.ToString()) == -1)
                {
                    base.ShowMessage("请添加仓库或未选择仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                string wfID = ddlwareHouses.Value.ToString();
                var pdInfo = base.XMPdInfoService.GetXMPdInfoById(this.scid);
                if (pdInfo != null)
                {
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            string productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value.ToString() : ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim();      //盘点单金额
                            bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                            if (!t || !IsFloat(productMoney))
                            {
                                base.ShowMessage("盘点数量或盘点金额格式不正确！");
                                BindGrid(hiddjsonContent);
                                return;
                            }
                            int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //盘点后库存数量
                            if (productCount < 0)
                            {
                                isFalse = true;
                            }

                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            if (productCode == "")
                            {
                                isEmpty = true;
                            }
                        }
                    }
                    if (isEmpty)
                    {
                        base.ShowMessage("厂家编码不能为空！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    if (isFalse)
                    {
                        base.ShowMessage("商品数量不能小于0！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    var pdInfoProductDetails = base.XMPdInfoProductDetailsService.GetXMPdInfoProductDetailsListByPdID(pdInfo.Id);
                    pdInfo.BizDt = Convert.ToDateTime(txtDeliveryDate.Value);
                    pdInfo.WarehouseId = int.Parse(ddlwareHouses.Value.ToString());
                    pdInfo.BillMemo = txtNote.Text.Trim();
                    pdInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                    pdInfo.UpdateDate = DateTime.Now;
                    base.XMPdInfoService.UpdateXMPdInfo(pdInfo);

                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            bool isExsit = false;                //判断厂家编码是否存在
                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //盘点单数量
                            decimal productMoney = ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim() == "" ? value : decimal.Parse(ja_goods[i]["txtProductMoney"].ToString().Replace('\"', ' ').Trim());      //盘点单金额
                            foreach (XMPdInfoProductDetails info in pdInfoProductDetails)
                            {
                                if (productCode == info.PlatformMerchantCode)
                                {
                                    isExsit = true;
                                    info.PCount = productCount;
                                    info.PMoney = productMoney;
                                    info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    info.Updatedate = DateTime.Now;
                                    base.XMPdInfoProductDetailsService.UpdateXMPdInfoProductDetails(info);
                                }
                            }

                            if (isExsit == false)             //不存在新增
                            {
                                XMPdInfoProductDetails details = new XMPdInfoProductDetails();
                                details.PdId = pdInfo.Id;
                                var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                                if (product != null)
                                {
                                    details.ProductId = product.Id;
                                }
                                details.PlatformMerchantCode = productCode;
                                details.PCount = productCount;
                                details.PMoney = productMoney;
                                details.Updatedate = details.CreateDate = DateTime.Now;
                                details.CreateID = details.UpdateID = HozestERPContext.Current.User.CustomerID;
                                details.IsEnable = false;
                                base.XMPdInfoProductDetailsService.InsertXMPdInfoProductDetails(details);
                            }
                        }
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(pdInfo.Id);
            }
        }


        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        /// <summary>
        /// id
        /// </summary>
        public int scid
        {
            get
            {
                return CommonHelper.QueryStringInt("PdID");
            }
        }

        /// <summary>
        /// 判断是添加还是修改
        /// </summary>
        public int type
        {
            get
            {
                return CommonHelper.QueryStringInt("type");
            }
        }
    }
}