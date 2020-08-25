using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderInfoProductDetailsEdit : BaseAdministrationPage, ISearchPage
    {
        public string ManufacturersCodeRecord = "";
        public List<HozestERP.BusinessLogic.ManageProject.XMDelivery> DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
        public List<XMXLMInventory> XLMInventoryList = new List<XMXLMInventory>();
        public List<XMInventoryInfo> XMInventoryInfoList = new List<XMInventoryInfo>();
        public List<int> InventoryList = new List<int>();

        /// <summary>
        /// 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnUpdate", "ManageProject.XMOrderInfoProductDetailsEdit.ProductUpdate");//编辑
                buttons.Add("imgBtnDelete", "ManageProject.XMOrderInfoProductDetailsEdit.Delete");//删除 
                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var pingtai = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);
                this.pingtai2.Value = pingtai.PlatformTypeId.ToString();
                this.BindGrid(1, Master.PageSize);
            }
        }

        /// <summary>
        /// 订单id
        /// </summary>
        public int XMOrderInfoID
        {
            get
            {
                return CommonHelper.QueryStringInt("ID");
            }
        }

        public bool IsCM
        {
            get
            {
                int cm = CommonHelper.QueryStringInt("IsCM");
                if (cm == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            #region 判断项目是否是喜临门项目
            var order = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);
            var project = base.XMProjectService.GetXMProjectById(order.ProjectId);
            #endregion
            canXMLProject = project.ProjectName.Contains("喜临门");
            if (project.ProjectName.Contains("喜临门"))
            {
                //仓库绑定
                this.ddlWarehouseID.Items.Clear();
                var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(227, false);
                this.ddlWarehouseID.DataSource = codeList;
                this.ddlWarehouseID.DataTextField = "CodeName";
                this.ddlWarehouseID.DataValueField = "CodeID";
                this.ddlWarehouseID.DataBind();
                this.ddlWarehouseID.Items.Insert(0, new ListItem("---所有---", "-1"));
            }else
            {
               var wareHouseList = base.XMWareHousesService.GetXMWarehouseListByProjectId(project.Id);
                this.ddlWarehouseID.DataSource = wareHouseList;
                this.ddlWarehouseID.DataTextField = "Name";
                this.ddlWarehouseID.DataValueField = "Id";
                this.ddlWarehouseID.DataBind();
                this.ddlWarehouseID.Items.Insert(0, new ListItem("---所有---", "-1"));
            }

            this.Master.SetTitleVisible = false;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            List<XMOrderInfoProductDetails> list = new List<XMOrderInfoProductDetails>();
            //var OrderProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsList().Where(p => p.OrderInfoID == this.XMOrderInfoID && p.IsEnable==false).ToList();
            var pingtai = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);
            var OrderProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsList(this.XMOrderInfoID);
            if (pingtai.PlatformTypeId == 259)//判断是否唯品会订单，排除非CM开头的产品
            {
                if (IsCM)
                {
                    if (OrderProductDetails.Count > 0)
                    {
                        foreach (XMOrderInfoProductDetails item in OrderProductDetails)
                        {
                            if (item.PlatformMerchantCode.Length > 2)
                            {
                                var ddh = item.PlatformMerchantCode.Substring(0, 2);
                                if (ddh == "CM"&& pingtai.NickID==32) //nickid为32
                                {
                                    list.Add(item);
                                }
                                else if(pingtai.NickID!=32)
                                {
                                    list.Add(item);
                                }
                            }
                            else
                            {
                                list.Add(item);
                            }
                        }
                    }
                    else
                    {
                        list = OrderProductDetails;
                    }
                }
                else
                {
                    if (OrderProductDetails.Count > 0)
                    {
                        foreach (XMOrderInfoProductDetails item in OrderProductDetails)
                        {
                            if (item.PlatformMerchantCode.Length > 2)
                            {
                                var ddh = item.PlatformMerchantCode.Substring(0, 2);
                                if (ddh != "CM")
                                {
                                    list.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (XMOrderInfoProductDetails item in OrderProductDetails)
                {
                    list.Add(item);
                }
            }

            var pageList = new PagedList<XMOrderInfoProductDetails>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            ////新增编码行
            this.grdvClients.EditIndex = pageList.Count();
            pageList.Add(new XMOrderInfoProductDetails());

            this.Master.BindData(this.grdvClients, pageList);
        }

        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var OrderInfoProductDetail = e.Row.DataItem as XMOrderInfoProductDetails;
                ImageButton imgBtnSpareAddress = (ImageButton)e.Row.FindControl("imgBtnSpareAddress");//备用地址
                ImageButton imgBtnSpareRemarks = (ImageButton)e.Row.FindControl("imgBtnSpareRemarks");//备用备注
                TextBox txtFactoryPrice = (TextBox)e.Row.FindControl("lblFactoryPrice");           //出厂价
                HiddenField hiddFactoryPrice = e.Row.FindControl("hiddFactoryPrice") as HiddenField;
                HiddenField hiddSalesPrice = e.Row.FindControl("hiddSalesPrice") as HiddenField;
                //通过商品库获取商品的出厂价
                string platformMerchantCode = OrderInfoProductDetail.PlatformMerchantCode;    //商品编码
                string PlatFormTypeId = OrderInfoProductDetail.PlatFormTypeId;                                //平台
                if (!string.IsNullOrEmpty(PlatFormTypeId))
                {
                    var productDetails = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(platformMerchantCode, int.Parse(PlatFormTypeId));
                    if (productDetails != null && productDetails.Count > 0)
                    {
                        hiddFactoryPrice.Value = productDetails[0].Costprice.ToString();
                        hiddSalesPrice.Value = productDetails[0].Saleprice.ToString();
                    }
                }
                if (imgBtnSpareAddress != null && OrderInfoProductDetail.ID != 0)
                {
                    imgBtnSpareAddress.OnClientClick = "return ShowWindowDetail('备用地址','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMSpareAddressEdit.aspx?Id=" + OrderInfoProductDetail.ID.ToString() + "&TypeID=709', 400, 420, this, function(){});";
                }

                if (imgBtnSpareRemarks != null && OrderInfoProductDetail.ID != 0)
                {
                    imgBtnSpareRemarks.OnClientClick = "return ShowWindowDetail('备用备注','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMSpareRemarksEdit.aspx?Id=" + OrderInfoProductDetail.ID.ToString() + "', 500, 250, this, function(){});";
                }

                if (OrderInfoProductDetail.ID > 0 && OrderInfoProductDetail != null && OrderInfoProductDetail.IsSingleRow != null && OrderInfoProductDetail.IsSingleRow == true)
                {
                    ImageButton imgBtnUpdate = e.Row.FindControl("imgBtnUpdate") as ImageButton;
                    imgBtnUpdate.Visible = false;
                    ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                    imgBtnDelete.Visible = false;
                    imgBtnSpareAddress.Visible = false;
                    imgBtnSpareRemarks.Visible = false;
                }
            }
        }

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                #region 删除
                //if (e.CommandName.Equals("XMOrderInfoDelete"))
                //{
                //    var xMOrderInfo = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsByID(Convert.ToInt32(e.CommandArgument));

                //    if (xMOrderInfo != null)//删除
                //    {
                //        ToInsertXMOrderInfoOperatingRecord("产品信息删除", "商品编码-" + xMOrderInfo.PlatformMerchantCode, "");

                //        xMOrderInfo.IsEnable = true;
                //        xMOrderInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                //        xMOrderInfo.UpdateDate = DateTime.Now;
                //        base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(xMOrderInfo);
                //        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                //        base.ShowMessage("操作成功！");
                //    }
                //}
                #endregion

                #region 修改
                if (e.CommandName.Equals("OrderProductUpdate"))
                {
                    try
                    {
                        //订单详细信息
                        var orderproductInfo = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsByID(Convert.ToInt32(e.CommandArgument));
                        //编辑行
                        GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                        //HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("txtProductCode");
                        HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("lblManufacturers");//商品编码
                        HtmlInputControl lblProductName = (HtmlInputControl)gvr.FindControl("lblProductName");
                        HtmlInputControl lblSpecifications = (HtmlInputControl)gvr.FindControl("lblSpecifications");
                        HtmlInputText txtProductNum = (HtmlInputText)gvr.FindControl("txtProductNum");
                        TextBox lblFactoryPrice = (TextBox)gvr.FindControl("lblFactoryPrice");
                        TextBox lblTCostprice = (TextBox)gvr.FindControl("lblTCostprice");
                        TextBox txtSalesPrice = (TextBox)gvr.FindControl("txtSalesPrice");
                        HtmlInputText txtManufacturers = (HtmlInputText)gvr.FindControl("txtProductCode");//厂家编码
                        if (orderproductInfo != null)
                        {
                            var pingtai = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);
                            int? a = pingtai.PlatformTypeId;
                            //产品信息
                            var productInfo = base.XMProductService.GetXMProductListByCode(txtProductCode.Value, a);

                            if (productInfo != null)
                            {
                                //订单信息
                                var orderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(int.Parse(orderproductInfo.OrderInfoID.ToString()));
                                orderInfo.IsAbnormal = false;
                                base.XMOrderInfoService.UpdateXMOrderInfo(orderInfo);
                            }

                            if (orderproductInfo.ProductNum != int.Parse(txtProductNum.Value.Trim()))
                            {
                                ToInsertXMOrderInfoOperatingRecord("产品信息编辑-数量", orderproductInfo.ProductNum.ToString(), txtProductNum.Value.Trim());
                            }
                            if (orderproductInfo.FactoryPrice != decimal.Parse(lblFactoryPrice.Text.Trim()))
                            {
                                ToInsertXMOrderInfoOperatingRecord("产品信息编辑-出厂价", orderproductInfo.FactoryPrice.ToString(), lblFactoryPrice.Text.Trim());
                            }
                            if (orderproductInfo.TCostprice != decimal.Parse(lblTCostprice.Text.Trim()))
                            {
                                ToInsertXMOrderInfoOperatingRecord("产品信息编辑-特供价", orderproductInfo.TCostprice.ToString(), lblTCostprice.Text.Trim());
                            }
                            if (orderproductInfo.SalesPrice != decimal.Parse(txtSalesPrice.Text.Trim()))
                            {
                                ToInsertXMOrderInfoOperatingRecord("产品信息编辑-销售价", orderproductInfo.SalesPrice.ToString(), txtSalesPrice.Text.Trim());
                            }
                            if (orderproductInfo.PlatformMerchantCode != txtProductCode.Value.Trim())
                            {
                                ToInsertXMOrderInfoOperatingRecord("产品信息编辑-商品编码", orderproductInfo.PlatformMerchantCode, txtProductCode.Value.Trim());
                            }
                            orderproductInfo.TManufacturersCode = txtManufacturers.Value.Trim();
                            orderproductInfo.PlatformMerchantCode = txtProductCode.Value;
                            orderproductInfo.ProductName = lblProductName.Value;
                            orderproductInfo.Specifications = lblSpecifications.Value;
                            orderproductInfo.ProductNum = int.Parse(txtProductNum.Value.Trim());
                            orderproductInfo.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                            orderproductInfo.TCostprice = decimal.Parse(lblTCostprice.Text.Trim());
                            orderproductInfo.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                            orderproductInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            orderproductInfo.UpdateDate = DateTime.Now;
                            base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(orderproductInfo);

                            base.ShowMessage("操作成功！");
                        }
                        else
                        {
                            XMOrderInfoProductDetails orderproduct = new XMOrderInfoProductDetails();
                            orderproduct.TManufacturersCode = txtManufacturers.Value.Trim();//厂家编码
                            orderproduct.OrderInfoID = Convert.ToInt32(this.XMOrderInfoID);
                            orderproduct.PlatformMerchantCode = txtProductCode.Value;
                            orderproduct.ProductName = lblProductName.Value;
                            orderproduct.Specifications = lblSpecifications.Value;
                            orderproduct.ProductNum = int.Parse(txtProductNum.Value.Trim());
                            orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                            orderproduct.TCostprice = decimal.Parse(lblTCostprice.Text.Trim());
                            orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                            orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.CreateDate = DateTime.Now;
                            orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.UpdateDate = DateTime.Now;
                            orderproduct.IsAudit = false;
                            orderproduct.IsEnable = false;
                            orderproduct.IsExpedited = false;
                            base.XMOrderInfoProductDetailsService.InsertXMOrderInfoProductDetails(orderproduct);

                            ToInsertXMOrderInfoOperatingRecord("产品信息添加", "", "商品编码-" + orderproduct.PlatformMerchantCode);

                            base.ShowMessage("添加成功！");
                            this.BindGrid(1, Master.PageSize);
                            //ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMOrderInfoProductDetailsEdit", "autoCompleteBind()", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        base.ShowMessage("请检查数字填写是否正确！");
                    }
                }
                #endregion

                ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMOrderInfoProductDetailsEdit", "autoCompleteBind()", true);
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }

        }

        public void ToInsertXMOrderInfoOperatingRecord(string PropertyName, string OldValue, string NewValue)
        {
            XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
            record.PropertyName = PropertyName;
            record.OldValue = OldValue;
            record.NewValue = NewValue;
            record.OrderInfoId = XMOrderInfoID;
            record.UpdatorID = HozestERPContext.Current.User.CustomerID;
            record.UpdateTime = DateTime.Now;
            base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            if (int.TryParse(this.grdvClients.DataKeys[e.RowIndex].Value.ToString(), out Id))
            {
                //产品信息
                var XMOrderInfoProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsByID(Id);
                if (XMOrderInfoProductDetails != null)
                {
                    base.XMOrderInfoProductDetailsService.DeleteXMOrderInfoProductDetails(XMOrderInfoProductDetails.ID);
                    ToInsertXMOrderInfoOperatingRecord("产品信息删除", "商品编码-" + XMOrderInfoProductDetails.PlatformMerchantCode, "");
                }
                //GridView绑定
                BindGrid(this.Master.PageIndex, this.Master.PageSize);

                var OrderProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsList(this.XMOrderInfoID);
                if (OrderProductDetails.Count > 0)
                {
                    int paramnum = 0;
                    for (int i = 0; i < OrderProductDetails.Count; i++)//遍历产品明细
                    {
                        string Proname = OrderProductDetails[i].ProductName;
                        if (Proname == "无产品")
                        {
                            paramnum++;
                        }
                    }
                    if (paramnum == 0)
                    {
                        var xMOrderInfo = base.XMOrderInfoService.GetXMOrderInfoByID(this.XMOrderInfoID);
                        xMOrderInfo.IsAbnormal = false;
                        xMOrderInfo.ID = XMOrderInfoID;
                        HozestERP.BusinessLogic.Infrastructure.IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(xMOrderInfo);
                    }
                }
                base.ShowMessage("删除成功！");
            }
        }

        #endregion

        public void btnGetDelivery_Click(object sender, EventArgs e)
        {
            int WarehouseID = int.Parse(this.ddlWarehouseID.SelectedValue.Trim());
            if (WarehouseID == -1)
            {
                base.ShowMessage("你没有选择发货仓库！");
                return;
            }

            List<int> list = this.Master.GetSelectedIds(this.grdvClients);
            list.Remove(0);
            if (list.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                string msg = "";
                var Info = base.XMOrderInfoService.GetXMOrderInfoByID(XMOrderInfoID);
                if (Info != null)
                {
                    int OrderInfoProductCount = 0;//有效的订单产品条数
                    int DeliveryProductCount = 0;//能排单的订单产品条数

                    DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
                    XLMInventoryList = new List<XMXLMInventory>();
                    //XMInventoryInfoList = new 
                    InventoryList = new List<int>();

                    List<XMOrderInfoProductDetails> OrderInfoProductUnSpare = new List<XMOrderInfoProductDetails>();//无备用地址产品
                    List<XMOrderInfoProductDetails> OrderInfoProductSpare = new List<XMOrderInfoProductDetails>();//有备用地址产品
                    List<XMOrderInfoProductDetails> LatexPillowUnSpare = new List<XMOrderInfoProductDetails>();//乳胶枕，U型枕，无备用地址产品
                    List<XMOrderInfoProductDetails> LatexPillowSpare = new List<XMOrderInfoProductDetails>();//乳胶枕，U型枕，有备用地址产品

                    foreach (int OrderInfoProductID in list)
                    {
                        var info = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsByID(OrderInfoProductID);
                        if (info != null)
                        {
                            if (info.ProductName.IndexOf("床笠") != -1 || info.ProductName.IndexOf("运费") != -1 || info.ProductName.IndexOf("邮费") != -1 || info.ProductName.IndexOf("无产品") != -1)
                            {
                                continue;
                            }

                            if ((bool)info.IsAudit && (info.IsSingleRow == null || !(bool)info.IsSingleRow))
                            {
                                OrderInfoProductCount++;
                                var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 709);
                                if (info.ProductName.IndexOf("乳胶枕") != -1 || info.ProductName.IndexOf("U型枕") != -1 || info.ProductName.IndexOf("凝胶枕") != -1)
                                {
                                    if (spareAddress != null)
                                    {
                                        LatexPillowSpare.Add(info);
                                    }
                                    else
                                    {
                                        LatexPillowUnSpare.Add(info);
                                    }
                                }
                                else
                                {
                                    if (spareAddress != null)
                                    {
                                        OrderInfoProductSpare.Add(info);
                                    }
                                    else
                                    {
                                        OrderInfoProductUnSpare.Add(info);
                                    }
                                }
                            }
                            else
                            {
                                msg += "订单:" + Info.OrderCode + "，产品编码：" + info.TManufacturersCode + "的产品未审核或已排单！<br/>";
                            }
                        }
                    }

                    if (OrderInfoProductUnSpare.Count > 0)
                    {
                        msg = ToPlanBill(OrderInfoProductUnSpare, Info, WarehouseID, 1, msg);//无备用地址产品
                    }
                    if (LatexPillowUnSpare.Count > 0)
                    {
                        msg = ToPlanBill(LatexPillowUnSpare, Info, WarehouseID, 3, msg);//乳胶枕，U型枕，无备用地址产品
                    }
                    if (OrderInfoProductSpare.Count > 0)
                    {
                        msg = ToPlanBill(OrderInfoProductSpare, Info, WarehouseID, 2, msg);//有备用地址产品
                    }
                    if (LatexPillowSpare.Count > 0)
                    {
                        msg = ToPlanBill(LatexPillowSpare, Info, WarehouseID, 4, msg);//乳胶枕，U型枕，有备用地址产品
                    }

                    foreach (var item in DeliveryList)
                    {
                        if (item.XM_Delivery_Details != null && item.XM_Delivery_Details.Count > 0)
                        {
                            DeliveryProductCount += item.XM_Delivery_Details.Count;
                        }
                    }

                    if (OrderInfoProductCount > 0 && OrderInfoProductCount == DeliveryProductCount)
                    {
                        foreach (var item in DeliveryList)
                        {
                            base.XMDeliveryService.InsertXMDelivery(item);
                        }
                        //订单产品排单状态变为true
                        foreach (int OrderInfoProductID in list)
                        {
                            //订单信息
                            var info = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsByID(OrderInfoProductID);
                            if (info != null)
                            {
                                info.IsSingleRow = true;
                                info.IsAudit = true;
                                base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(info);
                            }
                        }
                        if (!Info.IsAudit.GetValueOrDefault(false))//订单中审核状态不是已审核的改为已审核
                        {
                            Info.IsAudit = true;
                            base.XMOrderInfoService.UpdateXMOrderInfo(Info);
                        }
                        if (canXMLProject)
                        {
                            //减喜临门当日库存
                            for (int i = 0; i < XLMInventoryList.Count; i++)
                            {
                                XLMInventoryList[i].Inventory = InventoryList[i];
                                base.XMXLMInventoryService.UpdateXMXLMInventory(XLMInventoryList[i]);
                            }
                        }
                        else
                        {//扣减库存管理中的库存数据
                            for (int i = 0; i < XMInventoryInfoList.Count; i++)
                            {
                                XMInventoryInfoList[i].StockNumber = InventoryList[i];
                                base.XMInventoryInfoService.UpdateXMInventoryInfo(XMInventoryInfoList[i]);
                            }
                        }
                        //操作记录
                        XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                        record.PropertyName = "手动排单";
                        record.OldValue = "IsSingleRow - false";
                        record.NewValue = "IsSingleRow - true";
                        record.OrderInfoId = Info.ID;
                        record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        record.UpdateTime = DateTime.Now;
                        base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                    }

                    if (msg != "")
                    {
                        base.ShowMessage(msg);
                        return;
                    }
                    else
                    {
                        BindGrid(this.Master.PageIndex, this.Master.PageSize);
                        base.ShowMessage("排单成功！");
                    }
                }
            }
        }

        public string ToPlanBill(List<XMOrderInfoProductDetails> list, XMOrderInfo Info, int WarehouseID, int type, string msg)
        {
            if (type == 1 || type == 3)
            {
                bool ProductExist = false;
                if (GetPlanBillResult(list, Info, null, WarehouseID, type))//排单成功
                {
                    ProductExist = true;
                }

                if (!ProductExist)
                {
                    msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                }
            }
            else if (type == 2 || type == 4)
            {
                List<int?> Ids = new List<int?>();
                var IDs = list.Select(x => x.ID).ToList();
                var SpareAddressList = base.XMSpareAddressService.GetXMSpareAddressListByIDs(IDs, 709);
                foreach (var info in list)
                {
                    if (Ids.Contains(info.ID))
                    {
                        continue;
                    }
                    var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 709);
                    if (spareAddress != null)
                    {
                        //不同产品，相同地址
                        var SpareAddress = SpareAddressList.Where(x => x.FullName == spareAddress.FullName && x.Mobile == spareAddress.Mobile && x.DeliveryAddress == spareAddress.DeliveryAddress).ToList();
                        var OrderInfoProductIds = SpareAddress.Select(x => x.OtherID).ToList();
                        var List = list.Where(x => OrderInfoProductIds.Contains(x.ID)).ToList();
                        Ids.AddRange(OrderInfoProductIds);

                        bool ProductExist = false;
                        if (GetPlanBillResult(List, Info, spareAddress, WarehouseID, type))//排单成功
                        {
                            ProductExist = true;
                        }

                        if (!ProductExist)
                        {
                            msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                        }
                    }
                }
            }
            return msg;
        }

        public bool GetPlanBillResult(List<XMOrderInfoProductDetails> list, XMOrderInfo Info, XMSpareAddress SpareAddress, int WarehouseID, int type)
        {
            ManufacturersCodeRecord = "";
            bool complete = true;
            HozestERP.BusinessLogic.ManageProject.XMDelivery delivery = ToInsertDelivery(Info, SpareAddress, type);
            delivery.XM_Delivery_Details = new List<XMDeliveryDetails>();

            foreach (var info in list)
            {
                var exist1 = base.XMInventoryInfoService.GetXMInventoryInfoByParm(info.TManufacturersCode, WarehouseID);//库存管理中的数据
                if (type == 1 || type == 2)
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(WarehouseID, info.TManufacturersCode, "");
                    if ((canXMLProject && exist.Count > 0 && exist[0].Inventory >= info.ProductNum) || (!canXMLProject && exist1!= null && exist1.StockNumber >= info.ProductNum))
                    {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.TManufacturersCode);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        if (delivery.OrderRemarks == Info.CustomerServiceRemark && !string.IsNullOrEmpty(info.SpareRemarks))
                        {
                            delivery.OrderRemarks = info.SpareRemarks;
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, WarehouseID));
                        //减喜临门当日库存
                        if (canXMLProject)
                        {
                            InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                            XLMInventoryList.Add(exist[0]);
                        }
                        else
                        {
                            InventoryList.Add((int)exist1.StockNumber - (int)info.ProductNum);
                            XMInventoryInfoList.Add(exist1);
                        }
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.TManufacturersCode + "，";
                    }
                }

                if (type == 3 || type == 4)//乳胶枕，U型枕，无备用地址
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(693, info.TManufacturersCode, "");//南方仓库
                     if ((canXMLProject && exist.Count > 0 && exist[0].Inventory >= info.ProductNum) || (!canXMLProject && exist1 != null && exist1.StockNumber >= info.ProductNum))
                     {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.TManufacturersCode);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        if (delivery.OrderRemarks == Info.CustomerServiceRemark && !string.IsNullOrEmpty(info.SpareRemarks))
                        {
                            delivery.OrderRemarks = info.SpareRemarks;
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, 693));
                        //减喜临门当日库存
                        if (canXMLProject)
                        {
                            InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                            XLMInventoryList.Add(exist[0]);
                        }
                        else
                        {
                            InventoryList.Add((int)exist1.StockNumber - (int)info.ProductNum);
                            XMInventoryInfoList.Add(exist1);
                        }
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.TManufacturersCode + "，";
                    }
                }
            }

            if (complete == true && delivery.XM_Delivery_Details != null && delivery.XM_Delivery_Details.Count > 0)
            {
                DeliveryList.Add(delivery);
            }

            return complete;
        }

        public HozestERP.BusinessLogic.ManageProject.XMDelivery ToInsertDelivery(XMOrderInfo Info, XMSpareAddress SpareAddress, int type)
        {
            HozestERP.BusinessLogic.ManageProject.XMDelivery info = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
            info.DeliveryTypeId = 480;//正常
            info.DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//发货单号;
            info.OrderCode = Info.OrderCode;
            if (type == 1 || type == 3)
            {
                info.FullName = Info.FullName;
                info.Mobile = Info.Mobile;
                info.Tel = Info.Tel;
                info.Province = Info.Province;
                info.City = Info.City;
                info.County = Info.County;
                info.DeliveryAddress = Info.DeliveryAddress;
            }
            else if (type == 2 || type == 4)
            {
                info.FullName = SpareAddress.FullName;
                info.Mobile = SpareAddress.Mobile;
                info.Tel = SpareAddress.Tel;
                info.Province = SpareAddress.Province;
                info.City = SpareAddress.City;
                info.County = SpareAddress.County;
                info.DeliveryAddress = SpareAddress.DeliveryAddress;
            }

            info.OrderRemarks = Info.CustomerServiceRemark;
            info.Shipper = 0;
            info.Price = 0;
            info.PrintBatch = 0;
            info.PrintQuantity = 0;
            info.IsDelivery = false;
            info.IsEnabled = false;
            info.CreateDate = DateTime.Now;
            info.CreateId = HozestERPContext.Current.User.CustomerID;
            info.UpdateDate = DateTime.Now;
            info.UpdateId = HozestERPContext.Current.User.CustomerID;
            //base.XMDeliveryService.InsertXMDelivery(info);
            return info;
        }

        /// <summary>
        /// 是否喜临门项目
        /// </summary>
        private bool canXMLProject
        {
            get;
            set;
        }
        public XMDeliveryDetails GetDeliveryDetails(XMOrderInfoProductDetails ProductDetails, string OrderCode, int WarehouseID)
        {
            string PrdouctName = "";
            string Specifications = "";

            XMDeliveryDetails detail = new XMDeliveryDetails();
            //detail.DeliveryId = DeliveryIDType;
            detail.DetailsTypeId = (int)StatusEnum.NormalOrder;//正常订单
            detail.OrderNo = OrderCode;
            var ProductDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(ProductDetails.PlatformMerchantCode, (int)ProductDetails.XM_OrderInfo.PlatformTypeId);
            if (ProductDetail != null && ProductDetail.Count > 0)
            {
                detail.ProductlId = ProductDetail[0].ProductId;
                var product = base.XMProductService.GetXMProductById((int)detail.ProductlId);
                if (product != null)
                {
                    PrdouctName = product.ProductName;
                    Specifications = product.Specifications;
                }
            }
            detail.PlatformMerchantCode = ProductDetails.PlatformMerchantCode;
            detail.PrdouctName = PrdouctName;
            detail.Specifications = Specifications;
            detail.ProductNum = (int)ProductDetails.ProductNum;
            detail.WarehouseID = WarehouseID;
            detail.IsEnabled = false;
            detail.CreateDate = DateTime.Now;
            detail.CreateID = HozestERPContext.Current.User.CustomerID;
            detail.UpdateDate = DateTime.Now;
            detail.UpdateID = HozestERPContext.Current.User.CustomerID;
            //IoC.Resolve<IXMDeliveryDetailsService>().InsertXMDeliveryDetails(detail);
            return detail;
        }
    }
}