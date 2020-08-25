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
using System.Xml;
using Ext.Net;
using System.Web;

namespace HozestERP.Web.ManageInventory
{
    public partial class AllocateAdd : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfo();
            }
            ProjectOutLoad();
            ProjectInLoad();

        }

        /// <summary>
        /// 调出项目绑定
        /// </summary>
        protected void ProjectOutLoad() 
        {
            List<object> data = new List<object>();
            List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ProjectOut.Items.Clear();
                XMProjectList = base.XMProjectService.GetXMProjectList();
            }
            else 
            {
                this.ProjectOut.Items.Clear();
                XMProjectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
            }
            foreach (var paramXMProject in XMProjectList)
            {
                string id = paramXMProject.Id.ToString();
                string name = paramXMProject.ProjectName;

                Ext.Net.ListItem liSex= new Ext.Net.ListItem();   
            //每次创建一个Ext.Net.ListItem的对象               
                liSex.Value = id;
                liSex.Text = name;
                ProjectOut.Items.Add(liSex);   
            }

            Ext.Net.ListItem liSexall= new Ext.Net.ListItem();   
            //每次创建一个Ext.Net.ListItem的对象               
                liSexall.Value = "-1";
                liSexall.Text = "---所有---";
                ProjectOut.Items.Insert(0,liSexall);
        }

        /// <summary>
        /// 调入项目绑定
        /// </summary>
        protected void ProjectInLoad()
        {
            List<object> data = new List<object>();
            List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ProjectIn.Items.Clear();
                XMProjectList = base.XMProjectService.GetXMProjectList();
            }
            else
            {
                this.ProjectIn.Items.Clear();
                XMProjectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0);
            }
            foreach (var paramXMProject in XMProjectList)
            {
                string id = paramXMProject.Id.ToString();
                string name = paramXMProject.ProjectName;

                Ext.Net.ListItem liSex = new Ext.Net.ListItem();
                //每次创建一个Ext.Net.ListItem的对象               
                liSex.Value = id;
                liSex.Text = name;
                ProjectIn.Items.Add(liSex);
            }
            Ext.Net.ListItem liSexall = new Ext.Net.ListItem();
            //每次创建一个Ext.Net.ListItem的对象               
            liSexall.Value = "-1";
            liSexall.Text = "---所有---";
            ProjectIn.Items.Insert(0,liSexall);
        }

        /// <summary>
        /// 选择项目绑定调出仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void WareHoursesoutRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            BindWareHoursesout();
        }

         /// <summary>
        /// 选择项目绑定调出仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void WareHoursesoutLoad(object sender, DirectEventArgs e) 
        {
            BindWareHoursesout();
        }

        /// <summary>
        /// 选择项目绑定调出仓库方法
        /// </summary>
        public void BindWareHoursesout() 
        {
            if (this.ProjectOut.Value != "" && this.ProjectOut.Value != null)
            {
                int projectID = Convert.ToInt32(this.ProjectOut.Value);
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectId(projectID);
                List<object> data = new List<object>();

                foreach (var paramwareHouse in wareHouses)
                {
                    string id = paramwareHouse.Id.ToString();
                    string name = paramwareHouse.Name;

                    data.Add(new { Id = id, Name = name });
                }
                this.WareHoursesoutStore.DataSource = data;

                this.WareHoursesoutStore.DataBind();
            }
        }

        /// <summary>
        /// 选择项目绑定调入仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void WareHoursesinRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            BindWareHoursesin();
        }

        /// <summary>
        /// 选择项目绑定调出仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void WareHoursesinLoad(object sender, DirectEventArgs e)
        {
            BindWareHoursesin();
        }

        /// <summary>
        /// 选择项目绑定调入仓库方法
        /// </summary>
        public void BindWareHoursesin() 
        {
            if (this.ProjectIn.Value != "" && this.ProjectIn.Value != null)
            {
                int projectID = Convert.ToInt32(this.ProjectIn.Value);
                var wareHouses = base.XMWareHousesService.GetXMWarehouseListByProjectId(projectID);
                List<object> data = new List<object>();

                foreach (var paramwareHouse in wareHouses)
                {
                    string id = paramwareHouse.Id.ToString();
                    string name = paramwareHouse.Name;

                    data.Add(new { Id = id, Name = name });
                }
                this.WareHoursesinStore.DataSource = data;

                this.WareHoursesinStore.DataBind();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindInfo()
        {
            if (this.type == 0)           //新增
            {
                lblTitle.Text = "新建调拨单";
                lblRef.Visible = false;
                btnSingleSubmitAllocate.Visible = false;
                GetAllcateList();
            }
            else if (this.type == 1)   //编辑
            {
                lblTitle.Text = "编辑调拨单";
                lblMessage.Visible = false;
                btnSingleSubmitAllocate.Visible = true;
                BindGrid(this.scid);
            }
            else                               //查看（无法保存）
            {
                lblTitle.Text = "查看调拨单";
                lblMessage.Visible = false;
                btnSingleSubmitAllocate.Visible = false;
                BindGrid(this.scid);
                btnSave.Visible = false;
            }
        }

        private void GetAllcateList()
        {
            //新增
            if (this.type == 0)
            {
                StringBuilder str = new StringBuilder();
                str.Append("<table class='table' id='MyPurchaseProductList' >");
                str.Append("<tr >");
                str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>调拨数量</th><th>单位</th><th>操作</th></tr>");
                str.Append("<tr  id=\"mytr\">");
                str.Append("<td><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value=''  readonly=\"readonly\"/></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" value=''  type=\"text\"/></td><td><input style=\"background: transparent; border: 0; width: 95px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='' readonly=\"readonly\" /></td><td><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                str.Append("</table>");
                TableStr = str.ToString();
            }
        }

        private void BindGrid(int AllcateId)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>调拨数量</th><th>单位</th><th>操作</th></tr>");
            //绑定调拨单主表和产品明细表
            var dbInfo = base.XMAllocateInfoService.GetXMAllocateInfoById(AllcateId);
            if (dbInfo != null)
            {
                lblRef.Text = dbInfo.Ref;
                var dbInfoProductDetail = base.XMAllocateProductDetailsService.GetXMAllocateProductDetailsListByAllcateId(dbInfo.Id);
                txtDeliveryDate.Value = dbInfo.BizDt.ToString() == "" ? DateTime.Now.ToShortDateString() : dbInfo.BizDt.ToString();
                if (!string.IsNullOrEmpty(dbInfo.FromProjectId.ToString()))
                {
                    ProjectOut.SetValue(dbInfo.FromProjectId.ToString());//调出项目选择
                }
                if (!string.IsNullOrEmpty(dbInfo.ToProjectId.ToString()))
                {
                    ProjectIn.SetValue(dbInfo.ToProjectId.ToString());
                }
                WareHoursesout.SetValue(dbInfo.From_WarehouseId.ToString());
                WareHoursesin.SetValue(dbInfo.To_WarehouseId.ToString());
                txtNote.Text = dbInfo.BillMemo;
                if (dbInfoProductDetail != null && dbInfoProductDetail.Count > 0)
                {
                    foreach (XMAllocateProductDetails Info in dbInfoProductDetail)
                    {
                        str.Append("<tr  id=\"mytr\">");
                        str.Append("<td><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.PlatformMerchantCode + "'  readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox ProductName\" type=\"text\" style=\"text-align: left;width: 90%\" value='" + Info.ProductName + "' /></td><td><input style=\"background: transparent; border: 0; width: 95px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + Info.Specifications + "' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + Info.ProductCount.ToString() + "' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='" + Info.ProductUnit + "' readonly=\"readonly\" /></td><td><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
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
        /// 通过json数据绑定产品列表
        /// </summary>
        /// <param name="jsonContent"></param>
        private void BindGrid(string jsonContent)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='table' id='MyPurchaseProductList' >");
            str.Append("<tr >");
            str.Append("<th>厂家编码</th><th>商品名称</th><th>尺寸规格</th><th>调拨数量</th><th>单位</th><th>操作</th></tr>");
            if (jsonContent != "")
            {
                JArray ja_goods = (JArray)JsonConvert.DeserializeObject(jsonContent);
                for (int i = 0; i < ja_goods.Count; i++)
                {
                    string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                    string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                    string specifications = ja_goods[i]["lblSpecifications"].ToString().Replace('\"', ' ').Trim();      //商品规格
                    string productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim();      //调拨数量
                    string unit = ja_goods[i]["txtUnit"].ToString().Replace('\"', ' ').Trim();      //单位
                    str.Append("<tr  id=\"mytr\">");
                    str.Append("<td><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCode + "'  readonly=\"readonly\" /></td><td><input runat=\"server\" id=\"txtProductName\" class=\"TextBox\" style=\"text-align: left;width: 90%\" value='" + productName + "' /></td><td><input style=\"background: transparent; border: 0; width: 95px;\" readonly=\"readonly\" runat=\"server\" id=\"lblSpecifications\" value='" + specifications + "' /></td><td><input runat=\"server\" id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='" + productCount + "' /></td><td><input runat=\"server\" id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='" + unit + "' readonly=\"readonly\" /></td><td><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\"  /></td></tr>");
                }
            }
            str.Append("</table>");
            TableStr = str.ToString();
        }


        /// <summary>
        /// 自动生成调拨单号
        /// </summary>
        /// <returns></returns>
        private string AutodbNumber()
        {
            string dbCode = "";       //自动生成调拨单号
            int number = 1;
            var db = base.XMAllocateInfoService.GetXMAllocateInfoList();
            if (db != null && db.Count > 0)
            {
                number = db[0].Id + 1;
            }
            dbCode = "DB" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return dbCode;
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
                string errMessage = "";
                bool isFalse = false;
                bool isEmpty = false;
                bool isInventLess = false;     //库存是否充足
                string dbCode = AutodbNumber();
                string wfIDFrom = WareHoursesout.Value.ToString();    //调出仓库
                string wfIDTo = WareHoursesin.Value.ToString();             //调入仓库
                string hiddjsonContent = hdfJsonContent.Value;             //产品列表 json
                if (wfIDFrom == null && wfIDFrom == "")
                {
                    base.ShowMessage("请添加调出仓库或未选择调出仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (wfIDTo == null && wfIDTo == "")
                {
                    base.ShowMessage("请添加调入仓库或未选择调入仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                        if (!t)
                        {
                            base.ShowMessage("调拨数量格式不正确！");
                            BindGrid(hiddjsonContent);
                            return;
                        }
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //盘点后库存数量
                        if (productCount == 0)
                        {
                            isFalse = true;
                        }
                        if (productCode == "")
                        {
                            isEmpty = true;
                        }
                        var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(productCode, int.Parse(wfIDFrom));
                        if ((inventInfo != null && inventInfo.StockNumber < productCount) || inventInfo == null)
                        {
                            isInventLess = true;      //库存不足
                            errMessage += "厂家编码为:" + productCode + "的商品库存不足！ ";
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
                    base.ShowMessage("调拨数量不能为0！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (isInventLess)
                {
                    base.ShowMessage(errMessage);
                    BindGrid(hiddjsonContent);
                    return;
                }
                XMAllocateInfo allcateInfo = new XMAllocateInfo();
                allcateInfo.Ref = dbCode;
                allcateInfo.From_WarehouseId = int.Parse(WareHoursesout.Value.ToString());
                allcateInfo.To_WarehouseId = int.Parse(WareHoursesin.Value.ToString());
                allcateInfo.BizUserId = HozestERPContext.Current.User.CustomerID;
                allcateInfo.BizDt = txtDeliveryDate.Value == "" ? DateTime.Now : Convert.ToDateTime(txtDeliveryDate.Value);
                allcateInfo.BillMemo = txtNote.Text.Trim();
                allcateInfo.BillStatus = 0;
                allcateInfo.CreateDate = allcateInfo.UpdateDate = DateTime.Now;
                allcateInfo.CreateID = allcateInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                allcateInfo.IsEnable = false;
                base.XMAllocateInfoService.InsertXMAllocateInfo(allcateInfo);
                int dbId = allcateInfo.Id;
                if (hiddjsonContent != "")
                {
                    JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                    for (int i = 0; i < ja_goods.Count; i++)
                    {
                        string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                        string productName = ja_goods[i]["txtProductName"].ToString().Replace('\"', ' ').Trim();    //商品名称
                        int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //调拨数量

                        XMAllocateProductDetails details = new XMAllocateProductDetails();
                        details.AllocateId = dbId;
                        var product = base.XMProductService.getXMProductByManufacturersCode(productCode);          //根据厂家编码查询产品
                        if (product != null)
                        {
                            details.ProductId = product.Id;
                        }
                        details.PlatformMerchantCode = productCode;
                        details.ProductCount = productCount;
                        details.CreateDate = details.UpdateDate = DateTime.Now;
                        details.CrerateId = details.UpdateID = HozestERPContext.Current.User.CustomerID;
                        details.IsEnable = false;
                        base.XMAllocateProductDetailsService.InsertXMAllocateProductDetails(details);
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(allcateInfo.Id);
            }
            else                       //编辑
            {
                string errMessage = "";
                bool isInventLess = false;   //判断库存是否不足
                bool isEmpty = false;
                bool isFalse = false;
                string hiddjsonContent = hdfJsonContent.Value;             //产品列表 json
                string wfIDFrom = WareHoursesout.Value.ToString();    //调出仓库
                string wfIDTo = WareHoursesin.Value.ToString();             //调入仓库
                if (wfIDFrom == null && wfIDFrom == "")
                {
                    base.ShowMessage("请添加调出仓库或未选择调出仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                if (wfIDTo == null && wfIDTo == "")
                {
                    base.ShowMessage("请添加调入仓库或未选择调入仓库！");
                    BindGrid(hiddjsonContent);
                    return;
                }
                var dbInfo = base.XMAllocateInfoService.GetXMAllocateInfoById(this.scid);
                if (dbInfo != null)
                {
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            bool t = IsNumeric(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? "0" : ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());
                            if (!t)
                            {
                                base.ShowMessage("调拨数量格式不正确！");
                                X.Msg.Alert("Server Time", DateTime.Now.ToLongTimeString()).Show();
                                BindGrid(hiddjsonContent);
                                return;
                            }
                            int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //盘点后库存数量
                            if (productCount == 0)
                            {
                                isFalse = true;
                            }

                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            if (productCode == "")
                            {
                                isEmpty = true;
                            }
                            var inventInfo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(productCode, int.Parse(wfIDFrom));
                            if ((inventInfo != null && inventInfo.StockNumber < productCount) || inventInfo == null)
                            {
                                isInventLess = true;      //库存不足
                                errMessage += "厂家编码为:" + productCode + "的商品库存不足！ ";
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
                        base.ShowMessage("调拨数量不能为0！");
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    if (isInventLess)
                    {
                        base.ShowMessage(errMessage);
                        BindGrid(hiddjsonContent);
                        return;
                    }
                    var dbInfoProductDetails = base.XMAllocateProductDetailsService.GetXMAllocateProductDetailsListByAllcateId(dbInfo.Id);
                    dbInfo.BizDt = Convert.ToDateTime(txtDeliveryDate.Value);
                    dbInfo.From_WarehouseId = int.Parse(WareHoursesout.Value.ToString());
                    dbInfo.To_WarehouseId = int.Parse(WareHoursesin.Value.ToString());
                    dbInfo.BillMemo = txtNote.Text.Trim();
                    dbInfo.UpdateDate = DateTime.Now;
                    dbInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMAllocateInfoService.UpdateXMAllocateInfo(dbInfo);
                    if (hiddjsonContent != "")
                    {
                        JArray ja_goods = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                        for (int i = 0; i < ja_goods.Count; i++)
                        {
                            bool isExsit = false;                //判断厂家编码是否存在
                            string productCode = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                            int productCount = ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim() == "" ? 0 : int.Parse(ja_goods[i]["txtProductCount"].ToString().Replace('\"', ' ').Trim());      //调拨单数量
                            foreach (XMAllocateProductDetails info in dbInfoProductDetails)
                            {
                                if (productCode == info.PlatformMerchantCode)
                                {
                                    isExsit = true;
                                    info.ProductCount = productCount;
                                    info.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    info.UpdateDate = DateTime.Now;
                                    base.XMAllocateProductDetailsService.UpdateXMAllocateProductDetails(info);
                                }
                            }

                            if (ja_goods.Count >= dbInfoProductDetails.Count && isExsit == false)             //不存在新增
                            {
                                XMAllocateProductDetails details = new XMAllocateProductDetails();
                                details.AllocateId = dbInfo.Id;
                                var product = base.XMProductService.getXMProductByManufacturersCode(productCode);
                                if (product != null)
                                {
                                    details.ProductId = product.Id;
                                }
                                details.PlatformMerchantCode = productCode;
                                details.ProductCount = productCount;
                                details.UpdateDate = details.CreateDate = DateTime.Now;
                                details.CrerateId = details.UpdateID = HozestERPContext.Current.User.CustomerID;
                                details.IsEnable = false;
                                base.XMAllocateProductDetailsService.InsertXMAllocateProductDetails(details);
                            }
                        }

                        if (dbInfoProductDetails != null && dbInfoProductDetails.Count > 0)
                        {
                            foreach (XMAllocateProductDetails info in dbInfoProductDetails)
                            {
                                bool isDelete = true;
                                if (hiddjsonContent != "")
                                {
                                    JArray ja_goods2 = (JArray)JsonConvert.DeserializeObject(hiddjsonContent);
                                    for (int i = 0; i < ja_goods.Count; i++)
                                    {
                                        string productCode2 = ja_goods[i]["txtProductCode"].ToString().Replace('\"', ' ').Trim();       //厂家编码
                                        if (productCode2 == info.PlatformMerchantCode)
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
                                    base.XMAllocateProductDetailsService.UpdateXMAllocateProductDetails(info);
                                }
                            }
                        }
                    }
                }
                base.ShowMessage("操作成功!");
                BindGrid(dbInfo.Id);
            }
        }


        /// <summary>
        /// 提交调拨单  更新库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSingleSubmitAllocate_Click(object sender, EventArgs e)
        {
            //提交调拨单
            string errMessage = "";
            bool isInventLess = false;   //判断库存是否不足
            bool isAllocateFail = false;   // 判断调拨是否失败
            var dbInfo = base.XMAllocateInfoService.GetXMAllocateInfoById(this.scid);
            if (dbInfo != null)
            {
                if (dbInfo.BillStatus == 0)      //未调拨
                {
                    var dbProductDetails = base.XMAllocateProductDetailsService.GetXMAllocateProductDetailsListByAllcateId(dbInfo.Id);
                    if (dbProductDetails != null && dbProductDetails.Count > 0)
                    {
                        foreach (XMAllocateProductDetails Info in dbProductDetails)
                        {
                            var inventInfoFrom = base.XMInventoryInfoService.GetXMInventoryInfoByParm(Info.PlatformMerchantCode, dbInfo.From_WarehouseId);
                            if (inventInfoFrom == null || (inventInfoFrom != null && inventInfoFrom.StockNumber < Info.ProductCount))              //库存不足
                            {
                                errMessage += "厂家编码为" + Info.PlatformMerchantCode + "的商品库存不足，";
                                isInventLess = true;
                                break;
                            }
                        }
                    }
                }
                else if (dbInfo.BillStatus == 1000)
                {
                    isAllocateFail = true;
                }
            }
            if (isInventLess)      //库存不足
            {
                base.ShowMessage(errMessage + "无法调拨！");
                return;
            }
            if (isAllocateFail)
            {
                base.ShowMessage("已经调拨的调拨单操作失败！");
                return;
            }
            using (TransactionScope scope = new TransactionScope())
            {
                if (dbInfo != null && dbInfo.BillStatus == 0)
                {
                    dbInfo.BillStatus = 1000;     //更该状态为 已调拨
                    dbInfo.UpdateDate = DateTime.Now;
                    dbInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMAllocateInfoService.UpdateXMAllocateInfo(dbInfo);

                    //更新仓库库存
                    var dbProductDetails = base.XMAllocateProductDetailsService.GetXMAllocateProductDetailsListByAllcateId(dbInfo.Id);
                    if (dbProductDetails != null && dbProductDetails.Count > 0)
                    {
                        foreach (XMAllocateProductDetails Info in dbProductDetails)
                        {
                            //更新出库仓库库存
                            var inventInfoFrom = base.XMInventoryInfoService.GetXMInventoryInfoByParm(Info.PlatformMerchantCode, dbInfo.From_WarehouseId);
                            if ((inventInfoFrom != null && inventInfoFrom.StockNumber >= Info.ProductCount))              //库存充足减库存
                            {
                                inventInfoFrom.StockNumber = inventInfoFrom.StockNumber - Info.ProductCount;
                                inventInfoFrom.CanOrderCount = inventInfoFrom.StockNumber;
                                inventInfoFrom.UpdateDate = DateTime.Now;
                                inventInfoFrom.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMInventoryInfoService.UpdateXMInventoryInfo(inventInfoFrom);
                                //在库存帐查询中添加记录
                                UpdateDeliveryInventoryLederInfo(dbInfo.From_WarehouseId, Info);
                                //更新仓库出库产品条形码
                                UpdateDeliveryBarCodes(inventInfoFrom.Id, Info.Id);

                                //更新入库仓库库存
                                var inventInfoTo = base.XMInventoryInfoService.GetXMInventoryInfoByParm(Info.PlatformMerchantCode, dbInfo.To_WarehouseId);
                                if (inventInfoTo == null)          //新增
                                {
                                    XMInventoryInfo inventory = new XMInventoryInfo();
                                    var product = base.XMProductService.getXMProductByManufacturersCode(Info.PlatformMerchantCode);
                                    if (product != null)
                                    {
                                        inventory.PrductId = product.Id;
                                    }
                                    inventory.PlatformMerchantCode = Info.PlatformMerchantCode;
                                    inventory.WfId = dbInfo.To_WarehouseId;
                                    inventory.StockNumber = Info.ProductCount;
                                    inventory.CanOrderCount = inventory.StockNumber;
                                    inventory.WarningValue = 0;
                                    inventory.CreateDate = inventory.UpdateDate = DateTime.Now;
                                    inventory.CreateID = inventory.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    inventory.IsEnable = false;
                                    base.XMInventoryInfoService.InsertXMInventoryInfo(inventory);
                                    UpdateStorageBarCodes(inventory.Id, Info.Id);
                                }
                                else              //更新库存
                                {
                                    inventInfoTo.StockNumber = inventInfoTo.StockNumber + Info.ProductCount;
                                    inventInfoTo.CanOrderCount = inventInfoTo.StockNumber;
                                    inventInfoTo.UpdateDate = DateTime.Now;
                                    inventInfoTo.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    base.XMInventoryInfoService.UpdateXMInventoryInfo(inventInfoTo);
                                    UpdateStorageBarCodes(inventInfoTo.Id, Info.Id);
                                }
                                UpdateStorageInventoryLederInfo(dbInfo.To_WarehouseId, Info);
                            }
                        }
                    }
                }
                scope.Complete();
            }
            base.ShowMessage("操作成功!");
            BindGrid(this.scid);
        }

        /// <summary>
        /// 调拨出库产品条形更新(删除)
        /// </summary>
        /// <param name="inventInfoFromID"></param>
        /// <param name="allocateDetailID"></param>
        private void UpdateDeliveryBarCodes(int inventInfoFromID, int allocateDetailID)
        {
            //根据调拨产品详情ID 获取调拨产品的条形码列表
            var barCodes = base.XMAllocateProductBarCodeDetailService.GetXMAllocateProductBarCodeDetailListById(allocateDetailID);
            if (barCodes != null && barCodes.Count > 0)                   //存在条形码
            {
                //遍历所有条形码
                foreach (XMAllocateProductBarCodeDetail Info in barCodes)
                {
                    var inventoryBarCodes = base.XMInventoryBarcodeDetailService.GetXMInventoryBarcodeDetailListByInventoryIDAndBarCode(inventInfoFromID, Info.BarCode);
                    if (inventoryBarCodes != null)              //该商品如存在该条形码   出库后删除该条形码
                    {
                        inventoryBarCodes.IsEnable = true;
                        inventoryBarCodes.UpdateDate = DateTime.Now;
                        inventoryBarCodes.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMInventoryBarcodeDetailService.UpdateXMInventoryBarcodeDetail(inventoryBarCodes);
                    }
                }
            }
        }
        /// <summary>
        /// 调拨入库产品条形码更新（新增）
        /// </summary>
        /// <param name="inventInfoToID"></param>
        /// <param name="allocateDetailID"></param>
        private void UpdateStorageBarCodes(int inventInfoToID, int allocateDetailID)
        {
            //根据调拨入库产品详情ID 获取入库产品的条形码列表
            var barCodes = base.XMAllocateProductBarCodeDetailService.GetXMAllocateProductBarCodeDetailListById(allocateDetailID);
            if (barCodes != null && barCodes.Count > 0)                   //存在条形码
            {
                //遍历所有条形码
                foreach (XMAllocateProductBarCodeDetail Info in barCodes)
                {
                    var inventoryBarCodes = base.XMInventoryBarcodeDetailService.GetXMInventoryBarcodeDetailListByInventoryIDAndBarCode(inventInfoToID, Info.BarCode);
                    if (inventoryBarCodes == null)              //该产品条形码不存在  新增
                    {
                        XMInventoryBarcodeDetail inventoryBarCode = new XMInventoryBarcodeDetail();
                        inventoryBarCode.SpdId = inventInfoToID;
                        inventoryBarCode.PrductId = Info.ProductId;
                        inventoryBarCode.PlatformMerchantCode = Info.PlatformMerchantCode;
                        inventoryBarCode.BarCode = Info.BarCode;
                        inventoryBarCode.CreateDate = inventoryBarCode.UpdateDate = DateTime.Now;
                        inventoryBarCode.UpdateID = inventoryBarCode.CreateID = HozestERPContext.Current.User.CustomerID;
                        inventoryBarCode.IsEnable = false;
                        base.XMInventoryBarcodeDetailService.InsertXMInventoryBarcodeDetail(inventoryBarCode);
                    }
                }
            }
        }


        /// <summary>
        /// 更新入库记录
        /// </summary>
        /// <param name="wareHousesId"></param>
        /// <param name="info"></param>
        private void UpdateStorageInventoryLederInfo(int wareHousesId, XMAllocateProductDetails info)
        {
            decimal price = 0;
            decimal money = 0;
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, info.PlatformMerchantCode);
            var productDetail = base.XMProductDetailsService.GetXMProductDetailsListByProductId(info.ProductId.Value);
            if (inventoryLeder != null)     //更新数据
            {
                ////更新入库数量（加上）
                inventoryLeder.InCount = (inventoryLeder.InCount == null ? 0 : inventoryLeder.InCount) + info.ProductCount;
                if (productDetail != null && productDetail.Count > 0)
                {
                    inventoryLeder.InPrice = productDetail[0].Costprice;
                }
                inventoryLeder.InMoney = inventoryLeder.InPrice * inventoryLeder.InCount;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.WarehouseId = wareHousesId;
                inventoryLederInfo.ProductId = info.ProductId.Value;
                inventoryLederInfo.PlatformMerchantCode = info.PlatformMerchantCode;
                inventoryLederInfo.AfloatCount = 0;
                if (productDetail != null && productDetail.Count > 0)
                {
                    inventoryLederInfo.AfloatPrice = productDetail[0].Costprice;
                }
                inventoryLederInfo.AfloatMoney = inventoryLederInfo.AfloatCount * inventoryLederInfo.AfloatPrice;
                inventoryLederInfo.InCount = info.ProductCount;
                if (productDetail != null && productDetail.Count > 0)
                {
                    inventoryLederInfo.InPrice = productDetail[0].Costprice;
                }
                inventoryLederInfo.InMoney = inventoryLederInfo.InPrice * inventoryLederInfo.InCount;
                inventoryLederInfo.OutCount = 0;
                if (productDetail != null && productDetail.Count > 0)
                {
                    inventoryLederInfo.OutPrice = productDetail[0].Costprice;
                }
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(入库)
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, info.PlatformMerchantCode);

            XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
            details.WarehouseId = wareHousesId;
            details.ProductId = info.ProductId;
            details.PlatformMerchantCode = info.PlatformMerchantCode;
            details.InCount = info.ProductCount;                  //入库数量
            if (productDetail != null && productDetail.Count > 0)
            {
                details.InPrice = productDetail[0].Costprice;          //入库单价
            }
            details.InMoney = details.InPrice * details.InCount;
            details.OutCount = 0;
            details.OutPrice = price;
            details.OutMoney = money;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                details.BalanceCount = BalanceCount + info.ProductCount;
            }
            else           //
            {
                details.BalanceCount = info.ProductCount;
            }
            details.BalancePrice = details.InPrice;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            var dbInfo = base.XMAllocateInfoService.GetXMAllocateInfoById(info.AllocateId);
            if (dbInfo != null)
            {
                details.RefNumber = dbInfo.Ref;        //业务单号
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1012;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库  1011 调拨出库  1012 调拨入库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
        }

        /// <summary>
        /// 更新出库记录
        /// </summary>
        /// <param name="wareHousesId"></param>
        /// <param name="info"></param>
        private void UpdateDeliveryInventoryLederInfo(int wareHousesId, XMAllocateProductDetails info)
        {
            var inventoryLeder = base.XMInventoryLedgerService.GetXMInventoryLedgerByParm(wareHousesId, info.PlatformMerchantCode);
            var productDetails = base.XMProductDetailsService.GetXMProductDetailsListByProductId(info.ProductId.Value);
            if (inventoryLeder != null)     //更新数据
            {
                //更新出库数量（加上）
                inventoryLeder.OutCount = (inventoryLeder.OutCount == null ? 0 : inventoryLeder.OutCount) + info.ProductCount;
                if (productDetails != null && productDetails.Count > 0)
                {
                    inventoryLeder.OutPrice = productDetails[0].Costprice;
                }
                inventoryLeder.OutMoney = inventoryLeder.OutPrice * inventoryLeder.OutCount;
                inventoryLeder.UpdateDate = DateTime.Now;
                inventoryLeder.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.UpdateXMInventoryLedger(inventoryLeder);
            }
            else
            {
                XMInventoryLedger inventoryLederInfo = new XMInventoryLedger();
                inventoryLederInfo.OutCount = info.ProductCount;
                inventoryLederInfo.WarehouseId = wareHousesId;
                inventoryLederInfo.ProductId = info.ProductId.Value;
                inventoryLederInfo.PlatformMerchantCode = info.PlatformMerchantCode;
                if (productDetails != null && productDetails.Count > 0)
                {
                    inventoryLederInfo.OutPrice = productDetails[0].Costprice;
                }
                inventoryLederInfo.OutMoney = inventoryLederInfo.OutCount * inventoryLederInfo.OutPrice;
                inventoryLederInfo.CreateDate = DateTime.Now;
                inventoryLederInfo.CreateID = HozestERPContext.Current.User.CustomerID;
                base.XMInventoryLedgerService.InsertXMInventoryLedger(inventoryLederInfo);
            }
            //新增库存总账明细(出库)
            var inventoryLederDetail = base.XMInventoryLedgerDetailService.GetXMInventoryLedgerDetailListByParm(wareHousesId, info.PlatformMerchantCode);
            decimal price = 0;
            decimal money = 0;
            XMInventoryLedgerDetail details = new XMInventoryLedgerDetail();
            details.WarehouseId = wareHousesId;
            details.ProductId = info.ProductId;
            details.PlatformMerchantCode = info.PlatformMerchantCode;
            details.OutCount = info.ProductCount;                  //出库数量
            if (productDetails != null && productDetails.Count > 0)
            {
                details.OutPrice = productDetails[0].Costprice;              //出库单价
            }
            details.OutMoney = details.OutPrice * info.ProductCount;
            details.InCount = 0;
            details.InPrice = price;
            details.InMoney = money;
            if (inventoryLederDetail != null && inventoryLederDetail.Count > 0)
            {
                //默认最后一条（余量）
                int BalanceCount = inventoryLederDetail[0].BalanceCount.Value;
                details.BalanceCount = BalanceCount - info.ProductCount;
            }
            else           //
            {
                details.BalanceCount = info.ProductCount;
            }
            details.BalancePrice = price;
            details.BalanceMoney = details.BalancePrice * details.BalanceCount;
            var dbInfo = base.XMAllocateInfoService.GetXMAllocateInfoById(info.AllocateId);
            if (dbInfo != null)
            {
                details.RefNumber = dbInfo.Ref;        //业务单号
            }
            details.BizDate = DateTime.Now;
            details.BizUserId = HozestERPContext.Current.User.CustomerID;
            int refType = 1011;              //业务类型   1 采购入库 1000 采购退货  1002 销售出库 1004 销售退货入库  1008 库存盘点-盘盈入库  1010 库存盘点-盘亏出库  1011 调拨出库
            details.RefType = refType;
            base.XMInventoryLedgerDetailService.InsertXMInventoryLedgerDetail(details);
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
                return CommonHelper.QueryStringInt("AllocateId");
            }
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