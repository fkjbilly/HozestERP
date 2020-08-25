using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Codes;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageApplication
{
    public partial class XMApplicationAdd : BaseAdministrationPage, IEditPage
    {
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnUpdate", "XMApplicationAdd.Update"); //更换产品保存删除，信息的保存
                buttons.Add("imgBtnDelete", "XMApplicationAdd.Update"); //更换产品保存删除，信息的保存
                buttons.Add("btnSave", "XMApplicationAdd.Update"); //保存
                buttons.Add("Button3", "XMApplicationAdd.Update"); //保存
                buttons.Add("Button2", "XMApplicationAdd.Fin"); //完成
                buttons.Add("btnFinish", "XMApplicationAdd.Fin"); //完成
                return buttons;
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            //this.Master.SetTitle("财务部 > 暂支申请 ");
            //var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(230, false);
            //codeList.Add(new CodeList()
            //{
            //    CodeID = 0,
            //    CodeName = "请选择"
            //});
            //StoreReturnCategory.DataSource = codeList.OrderBy(a => a.CodeID);
            //StoreReturnCategory.DataBind();
            //this.ddlReturnCategoryList.DataSource = codeList;
            //this.ddlReturnCategoryList.DataTextField = "CodeName";
            //this.ddlReturnCategoryList.DataValueField = "CodeID";
            //this.ddlReturnCategoryList.DataBind();
        }

        public void SetTrigger()
        {
            // this.Master.SetTrigger(this.btnSave.UniqueID, this.Page); 
        }

        #endregion

        private void BindFactory()
        {
            var CodeList = CodeService.GetCodeListInfoByCodeTypeID(245);
            CodeList.Add(new CodeList()
            {
                CodeID=0,
                CodeName="请选择"
            });
            FactoryStore.DataSource = CodeList.OrderBy(a=>a.CodeID);
            FactoryStore.DataBind();
        }

        private void BindReturnCategory()
        {
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeIDWithoutCache(230, false);
            codeList.Add(new CodeList()
            {
                CodeID = 0,
                CodeName = "请选择"
            });
            StoreReturnCategory.DataSource = codeList.OrderBy(a => a.CodeID);
            StoreReturnCategory.DataBind();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (type == 2)
                {
                    this.ApplicaType2.Disabled = true;
                }
                Session["sc"] = "0";
                Session["newsc"] = "0";
                Session["newsclj"] = "0";
                Session["a"] = 0;
                DataBd();
                LoadDate(sender,e);
                LoadReceiverInfo();
                BindGrid();
                //BindGridtui();
                BindGridhuan(sender, e);
                //BindGridling();
                BindReturn(0);
                BindFactory();
                BindReturnCategory();
                //if (type == 2 && scid != 0)
                //{
                //    submit1_Click(sender, e);
                //}
                //IsApplication 1为新增类型2为退的，3换过来的零件 4退的零件(旧)
                //IsApplication 1为换货产品 2为退货产品
                //this.txtOrderCode.Attributes.Add("onserverchange", "submit1_Click");

                //退回物流单号能否修改
                //this.txtReturnLogisticsNumber.Enabled = false;
                //this.btnReturnLogisticsNumber.Visible = false;
                //btnReturnLogistics.Visible = false;

                //int[] ApplicationTypeList = { 5, 6, 7 };//申请类型（先退货后退款，换货，先退款后退货）
                var Info = XMApplicationService.GetXMApplicationByID(scid);
                if (Info != null)
                {
                    //if (Info.SupervisorStatus == true && Info.GoodsConfirmReturn != true)
                    //{
                    //    this.txtReturnLogisticsNumber.Enabled = true;
                    //    //this.btnReturnLogisticsNumber.Visible = true;
                    //    //btnReturnLogistics.Visible = true;
                    //}

                    if (!string.IsNullOrEmpty(Info.ReturnLogisticsNumber))
                    {
                        this.txtReturnLogisticsNumber.Text = Info.ReturnLogisticsNumber;
                    }

                    txtLogisticsFee.Text = Info.LogisticsCost == null ? "0" : Info.LogisticsCost.ToString();
                }
            }
        }

        public void LoadReceiverInfo()
        {
            if (type == 2)
            {
                var Info = XMApplicationService.GetXMApplicationByID(scid);
                if(Info.OrderCode.StartsWith("NoOrder"))
                {
                    var entity = XMSpareAddressService.GetXMSpareAddressByParm(scid, 710);
                    if (entity != null)
                    {
                        txtFullName.Text = entity.FullName;
                        txtTel.Text = entity.Tel;
                        txtMobile.Text = entity.Mobile;
                        province.Value = entity.Province;
                        city.Value = entity.City;
                        region.Value = entity.County;
                        txtAddress.Text = entity.DeliveryAddress;
                    }
                }
                else
                {

                    var xmApplicationExchangeList = base.XMApplicationExchangeService.GetXMApplicationExchangeListByApplicationIDType(Info.ID, 1);

                    if(xmApplicationExchangeList.Count>0)
                    {
                        var entity = XMSpareAddressService.GetXMSpareAddressByParm(xmApplicationExchangeList[0].ID, 710);
                        if (entity != null)
                        {
                            txtFullName.Text = entity.FullName;
                            txtTel.Text = entity.Tel;
                            txtMobile.Text = entity.Mobile;
                            province.Value = entity.Province;
                            city.Value = entity.City;
                            region.Value = entity.County;
                            txtAddress.Text = entity.DeliveryAddress;
                        }
                    }

                }
                
            }
        }

        public void DataBd()
        {
            //平台类型动态数据绑定
            this.ddlPlatform.Items.Clear();
            var codeLists = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatform.DataSource = codeLists;
            this.ddlPlatform.DataTextField = "CodeName";
            this.ddlPlatform.DataValueField = "CodeID";
            this.ddlPlatform.DataBind();
            this.ddlPlatform.Items.Insert(0, new ListItem("---所有---", "-1"));

            province.Items.Clear();
            var provinceList = AreaCodeService.GetAreaCodeByRank(2);
            provinceStore.DataSource = provinceList;
            provinceStore.DataBind();
        }

        protected void province_Select(object sender, Ext.Net.DirectEventArgs e)
        {
            string pro = province.Text;
            //城市数据
            var cityList = AreaCodeService.GetAreaCodeByCity(3, pro);
            cityStore.DataSource = cityList;
            cityStore.DataBind();

            city.Clear();
            region.Clear();
        }

        protected void city_Select(object sender, Ext.Net.DirectEventArgs e)
        {
            string cityName = city.Text;
            string pro = province.Text;

            //地区数据
            var areaList = AreaCodeService.GetAreaCodeByCity(4, pro + "/" + cityName);
            regionStore.DataSource = areaList;
            regionStore.DataBind();

            region.Clear();
        }

        protected void addProduct_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            if(TabPanel.ActiveTabIndex==1&& int.Parse(this.ApplicaType2.Value) != Convert.ToInt16(AppStatusEnum.huanhuo))
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "申请类型必须是换货，才能添加换货商品！").Show();
                return;
            }
            window1.Show();
        }

        protected void ddlPlatformTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nickList = XMNickService.GetXMNickListByPlatformType(int.Parse(ddlPlatform.SelectedValue));
            this.ddlNick1.Items.Clear();
            this.ddlNick1.DataSource = nickList;
            this.ddlNick1.DataTextField = "nick";
            this.ddlNick1.DataValueField = "nick_id";
            this.ddlNick1.DataBind();
            this.ddlNick1.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        public void BindReturn(int type)
        {
            if (!string.IsNullOrEmpty(txtOrderCode.Value))
            {
                List<ProductModel> list = new List<ProductModel>();
                var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(this.txtOrderCode.Value);
                if (OrderInfo != null)
                {
                    //订单详情商品
                    var OrderInfoProductDetailsList = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderId(OrderInfo.ID);
                    //退货商品
                    var XMApplicationExchangeList = XMApplicationExchangeService.GetXMApplicationExchangeByOrderCodeAndType(OrderInfo.OrderCode, 2, scid);

                    //加载只显示退货商品
                    if(type==0)
                    {
                        //优先显示订单商品，后显示手动加上去的商品
                        foreach (var item in XMApplicationExchangeList)
                        {
                            var OrderInfoProductDetails = OrderInfoProductDetailsList.Where(a => a.PlatformMerchantCode == item.PlatformMerchantCode).ToList();
                            if (OrderInfoProductDetails.Count > 0)
                            {
                                list.Add(new ProductModel
                                {
                                    PlatformMerchantCode = OrderInfoProductDetails[0].PlatformMerchantCode,
                                    Manufacturers = OrderInfoProductDetails[0].Manufacturers,
                                    ProductName = OrderInfoProductDetails[0].ProductName,
                                    Specifications = OrderInfoProductDetails[0].Specifications,
                                    ProductNum = OrderInfoProductDetails[0].ProductNum == null ? 0 : (int)OrderInfoProductDetails[0].ProductNum,
                                    FactoryPrice = OrderInfoProductDetails[0].FactoryPrice,
                                    SalesPrice = OrderInfoProductDetails[0].SalesPrice,
                                    countNum = item.ProductNum == null ? 0 : (int)item.ProductNum,
                                });
                            }
                            else
                            {
                                list.Add(new ProductModel
                                {
                                    PlatformMerchantCode = item.PlatformMerchantCode,
                                    Manufacturers = item.Manufacturers,
                                    ProductName = item.ProductName,
                                    Specifications = item.Specifications,
                                    ProductNum = 0,
                                    FactoryPrice = item.FactoryPrice,
                                    SalesPrice = item.SalesPrice,
                                    countNum = item.ProductNum == null ? 0 : (int)item.ProductNum,
                                });
                            }
                        }
                    }
                    //查询只显示订单商品
                    else if(type==1)
                    {
                        foreach(var item in OrderInfoProductDetailsList)
                        {
                            list.Add(new ProductModel
                            {
                                PlatformMerchantCode = item.PlatformMerchantCode,
                                Manufacturers = item.Manufacturers,
                                ProductName = item.ProductName,
                                Specifications = item.Specifications,
                                ProductNum = item.ProductNum == null ? 0 : (int)item.ProductNum,
                                FactoryPrice = item.FactoryPrice,
                                SalesPrice = item.SalesPrice,
                                countNum = 0
                            });
                        }
                    }

                    store1.DataSource = list;
                    store1.DataBind();
                }
                else
                {
                    //退货商品
                    var XMApplicationExchangeList = XMApplicationExchangeService.GetXMApplicationExchangeByOrderCodeAndType(txtOrderCode.Value, 2, scid);
                    foreach (var item in XMApplicationExchangeList)
                    {
                        list.Add(new ProductModel
                        {
                            PlatformMerchantCode = item.PlatformMerchantCode,
                            Manufacturers = item.Manufacturers,
                            ProductName = item.ProductName,
                            Specifications = item.Specifications,
                            ProductNum = 0,
                            FactoryPrice = item.FactoryPrice,
                            SalesPrice = item.SalesPrice,
                            countNum = item.ProductNum == null ? 0 : (int)item.ProductNum,
                        });
                    }

                    store1.DataSource = list;
                    store1.DataBind();
                }
            }
        }

        public void BindGridhuan(object sender, EventArgs e)
        {
            if (type == 1 && this.orderid != "0")
            {
                var cx = base.XMOrderInfoService.GetXMOrderByOrderCode(this.orderid);
                if (cx != null)
                {
                    this.txtOrderCode.Value = this.orderid;
                    this.ddlPlatform.SelectedValue= cx.PlatformTypeId.ToString();
                    ddlPlatformTypeId_SelectedIndexChanged(sender, e);
                    //this.PlatformType.Value = cx.PlatformName;
                    //this.PlatformTypeId.Value = cx.PlatformTypeId.ToString();
                    //this.Amount.Value = cx.PayPrice.ToString();
                    backPrice.InnerHtml= "已支付金额："+ cx.PayPrice.ToString();
                    this.ddlNick1.Value= cx.NickID.ToString();
                    txtHidden1.Value= cx.NickID.ToString();
                    //this.Nick.Value = cx.NickName;
                    //this.NickId.Value = cx.NickID.ToString();
                    //BindGridtui();
                    //ScriptManager.RegisterStartupScript(this.GridView1, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
                }
            }
        }

        //退换货零件
        public void BindGridling()
        {
            if (this.txtOrderCode.Value != "")
            {
                List<int> newidpaixu = new List<int>();
                //string[] newid = Session["newsclj"].ToString().Split(',');
                //foreach (var i in newid)
                //{
                //    newidpaixu.Add(int.Parse(i));
                //}
                var a = base.XMApplicationExchangeService.GetXMApplicationExchangeByFinlist(this.txtOrderCode.Value, 3).Where(p => !newidpaixu.Contains(p.ID));
                var b = base.XMApplicationExchangeService.GetXMApplicationExchangeByFinlist(this.txtOrderCode.Value, 5);
                var OrderProductDetails = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(int.Parse(this.ApplicationNo.Value.Substring(6, 9)), 5, 0, 0);
                //if (OrderProductDetails==null)
                //{
                //    OrderProductDetails = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(int.Parse(this.ApplicationNo.Value.Substring(6, 9)), 5, 0, 0);
                //}
                var pageList2 = new List<XMApplicationExchange>(a.Concat(b).Concat(OrderProductDetails));

                //新增编码行
                this.GridView4.EditIndex = pageList2.Count();
                var XMPremiums = base.XMApplicationService.GetXMApplicationByID(scid);
                if (XMPremiums != null)
                {
                    if (XMPremiums.SupervisorStatus == false)
                    {
                        pageList2.Add(new XMApplicationExchange());
                    }
                }

                if (type == 1)
                {
                    pageList2.Add(new XMApplicationExchange());
                }

                if (a != null)
                {
                    this.GridView4.DataSource = pageList2;
                    this.GridView4.DataBind();
                }
                if (type == 2)
                {
                    var order = base.XMApplicationService.GetXMApplicationByID(this.scid);
                    if (order != null && order.FinishTime != null)
                    {
                        var ab = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(scid, 4, 0, 0).Where(p => !newidpaixu.Contains(p.ID));
                        var pageListab = new List<XMApplicationExchange>(ab);
                        this.GridView5.DataSource = pageListab;
                        this.GridView5.DataBind();
                        this.GridView4.DataSource = "";
                        this.GridView4.DataBind();
                        this.GridView4.Visible = false;
                    }
                    else
                    {
                        this.GridView4.DataSource = pageList2;
                        this.GridView4.DataBind();
                    }
                }
            }
        }

        public void BindGridtui()
        {
            if (this.txtOrderCode.Value != "")
            {
                var OrderProduct = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(this.txtOrderCode.Value);
                if (OrderProduct != null)
                {
                    List<int> idpaixu = new List<int>();
                    string[] id = Session["sc"].ToString().Split(',');
                    foreach (var i in id)
                    {
                        idpaixu.Add(int.Parse(i));
                    }
                    List<int> idpaixu2 = new List<int>();
                    var OrderProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderId(OrderProduct.ID).Where(p => !idpaixu.Contains(p.ID));

                    List<int> newidpaixu = new List<int>();
                    string[] newid = Session["newsc"].ToString().Split(',');
                    foreach (var i in newid)
                    {
                        newidpaixu.Add(int.Parse(i));
                    }

                    var add = base.XMApplicationExchangeService.GetXMApplicationExchangeByFinlist(this.txtOrderCode.Value, 1).Where(p => !newidpaixu.Contains(p.ID));
                    var pageList = new List<XMOrderInfoProductDetails>(OrderProductDetails);
                    if (type == 1)
                    {
                        //this.GridView1.EditIndex = pageList.Count();
                        //pageList.Add(new XMOrderInfoProductDetails());
                        this.GridView1.DataSource = pageList;
                        this.GridView1.DataBind();
                        if (add != null)
                        {
                            this.GridView3.DataSource = add;
                            this.GridView3.DataBind();
                        }
                    }
                    if (type == 2)
                    {
                        var order = base.XMApplicationService.GetXMApplicationByID(this.scid);
                        if (order != null && order.FinishTime != null)
                        {
                            var a = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(scid, 2, 0, 0).Where(p => !idpaixu.Contains(p.ID));
                            var pageList2 = new List<XMApplicationExchange>(a);
                            this.GridView2.DataSource = pageList2;
                            this.GridView2.DataBind();
                            this.GridView1.DataSource = "";
                            this.GridView1.DataBind();
                            this.GridView1.Visible = false;
                        }
                        else
                        {
                            var a = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(scid, 2, 0, 0).Where(p => !idpaixu.Contains(p.ID));
                            var pageList2 = new List<XMApplicationExchange>(a);
                            this.GridView6.EditIndex = pageList.Count();
                            pageList2.Add(new XMApplicationExchange());
                            this.GridView6.DataSource = pageList2;
                            this.GridView6.DataBind();
                            if (add != null)
                            {
                                this.GridView3.DataSource = add;
                                this.GridView3.DataBind();
                            }
                        }
                    }
                }
            }
        }

        public void BindGridtui2()
        {
            if (this.txtOrderCode.Value != "")
            {
                var OrderProduct = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(this.txtOrderCode.Value);
                if (OrderProduct != null)
                {
                    List<int> idpaixu = new List<int>();
                    string[] id = Session["sc"].ToString().Split(',');
                    foreach (var i in id)
                    {
                        idpaixu.Add(int.Parse(i));
                    }
                    List<int> idpaixu2 = new List<int>();
                    var OrderProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderId(OrderProduct.ID).Where(p => !idpaixu.Contains(p.ID));

                    List<int> newidpaixu = new List<int>();
                    string[] newid = Session["newsc"].ToString().Split(',');
                    foreach (var i in newid)
                    {
                        newidpaixu.Add(int.Parse(i));
                    }

                    var add = base.XMApplicationExchangeService.GetXMApplicationExchangeByFinlist(this.txtOrderCode.Value, 1).Where(p => !newidpaixu.Contains(p.ID));
                    var pageList = new List<XMOrderInfoProductDetails>(OrderProductDetails);

                    var a = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(scid, 2, 0, 0).Where(p => !idpaixu.Contains(p.ID));
                    var pageList2 = new List<XMApplicationExchange>(a);
                    this.GridView6.EditIndex = pageList2.Count();
                    pageList2.Add(new XMApplicationExchange());
                    this.GridView6.DataSource = pageList2;
                    this.GridView6.DataBind();
                    if (add != null)
                    {
                        this.GridView3.DataSource = add;
                        this.GridView3.DataBind();
                    }
                }
            }
        }

        public void BindGrid()
        {
            //查询要添加的内容
            var OrderProductDetails = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(this.scid, 1, 3, 0);
            int a = int.Parse(Session["a"].ToString());
            if (a != 0 && type == 1)
            {
                OrderProductDetails = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(a, 1, 3, 0);
            }
            if (a == 0 && type == 1)
            {
                OrderProductDetails = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(int.Parse(this.ApplicationNo.Value.Substring(6, 9)), 1, 3, 0);
            }
            var pageList = new List<XMApplicationExchange>(OrderProductDetails);

            //新增编码行
            this.grdvClients.EditIndex = pageList.Count();
            var XMPremiums = base.XMApplicationService.GetXMApplicationByID(scid);
            if (XMPremiums != null)
            {
                if (XMPremiums.SupervisorStatus == false)
                {
                    pageList.Add(new XMApplicationExchange());
                }
            }

            if (type == 1)
            {
                pageList.Add(new XMApplicationExchange());
            }
            this.grdvClients.DataSource = pageList;
            this.grdvClients.DataBind();

            store2.DataSource = new List<XMApplicationExchange>(OrderProductDetails);
            store2.DataBind();
        }

        //退换货零件
        protected void Clients4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                #region 删除
                if (e.CommandName.Equals("XMOrderInfoDelete"))
                {
                    var a = Session["newsclj"].ToString();
                    Session["newsclj"] = a + "," + e.CommandArgument;
                    base.ShowMessage("删除成功！");
                    BindGridling();
                    ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);

                }

                #endregion
                //修改
                if (e.CommandName.Equals("OrderProductUpdate"))
                {
                    try
                    {              //事务
                        //using (TransactionScope scope = new TransactionScope())
                        //{
                        ////查询退换货的信息是否已有
                        //var orderproductInfo = base.XMApplicationExchangeService.GetXMApplicationExchangeByID(Convert.ToInt32(e.CommandArgument));
                        //编辑行
                        GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                        HtmlInputControl lblProductName = (HtmlInputControl)gvr.FindControl("lblProductName");//零件名称
                        HtmlInputText txtProductNum = (HtmlInputText)gvr.FindControl("txtProductNum");
                        TextBox lblFactoryPrice = (TextBox)gvr.FindControl("lblFactoryPrice");
                        TextBox txtSalesPrice = (TextBox)gvr.FindControl("txtSalesPrice");
                        TextBox txtcount = (TextBox)gvr.FindControl("txtcount");//退换货数量
                        XMApplicationExchange orderproduct = new XMApplicationExchange();
                        //if (type == 1 && Session["a"].ToString() != "0")
                        //{
                        //    orderproduct.ApplicationId = int.Parse(Session["a"].ToString());
                        //}
                        //else if (type == 1 && Session["a"].ToString() == "0")
                        //{
                        //    orderproduct.ApplicationId = int.Parse(this.ApplicationNo.Value.Substring(6, 9));
                        //}
                        //else
                        //{
                        if (this.scid != 0)
                        {
                            orderproduct.ApplicationId = this.scid;
                        }
                        else
                        {
                            orderproduct.ApplicationId = int.Parse(this.ApplicationNo.Value.Substring(6, 9));
                        }
                        //}
                        orderproduct.ProductName = lblProductName.Value;
                        orderproduct.ProductNum = int.Parse(txtProductNum.Value.Trim());
                        orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                        orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                        orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                        orderproduct.CreateDate = DateTime.Now;
                        orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                        orderproduct.UpdateDate = DateTime.Now;
                        orderproduct.IsApplication = 5;//1为新增类型
                        base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);

                        if (txtcount.Text.Trim() != "0")
                        {
                            XMApplicationExchange orderproduct1 = new XMApplicationExchange();
                            orderproduct1.ApplicationId = orderproduct.ApplicationId;
                            orderproduct1.ProductName = lblProductName.Value;
                            orderproduct1.ProductNum = int.Parse(txtcount.Text.Trim());
                            orderproduct1.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                            orderproduct1.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                            orderproduct1.IsNewOderDetails = orderproduct.ID;
                            orderproduct1.CreateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct1.CreateDate = DateTime.Now;
                            orderproduct1.UpdateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct1.UpdateDate = DateTime.Now;
                            orderproduct1.IsApplication = 4;//1为新增类型

                            base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct1);
                        }
                        BindGridling();


                        //scope.Complete();
                        //base.ShowMessage("添加成功！");
                        ScriptManager.RegisterStartupScript(this.GridView4, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
                    }
                    //}
                    catch (Exception ex)
                    {
                        base.ShowMessage("请检查数字填写是否正确！");
                        ScriptManager.RegisterStartupScript(this.GridView4, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
                    }


                }
            }
            catch
            {
                base.ShowMessage("操作失败！");
                ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
            }
        }

        //原来数据
        protected void Clients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                #region 删除
                if (e.CommandName.Equals("XMOrderInfoDelete"))
                {
                    var a = Session["sc"].ToString();
                    Session["sc"] = a + "," + e.CommandArgument;
                    base.ShowMessage("删除成功！");
                    BindGridtui();
                    ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);

                }

                #endregion

                //修改
                if (e.CommandName.Equals("OrderProductUpdate"))
                {
                    try
                    {
                        //查询退换货的信息是否已有
                        var orderproductInfo = base.XMApplicationExchangeService.GetXMApplicationExchangeByID(Convert.ToInt32(e.CommandArgument));
                        //编辑行
                        GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                        //HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("txtProductCode");
                        HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("lblManufacturers3");//商品编码
                        HtmlInputControl lblProductName = (HtmlInputControl)gvr.FindControl("lblProductName3");
                        HtmlInputControl lblSpecifications = (HtmlInputControl)gvr.FindControl("lblSpecifications3");
                        HtmlInputText txtCJProductCode = (HtmlInputText)gvr.FindControl("txtProductCode3");//厂家编码

                        HtmlInputText txtProductNum = (HtmlInputText)gvr.FindControl("txtProductNum3");
                        TextBox lblFactoryPrice = (TextBox)gvr.FindControl("lblFactoryPrice3");
                        TextBox txtSalesPrice = (TextBox)gvr.FindControl("txtSalesPrice3");
                        if (orderproductInfo != null)
                        {
                            orderproductInfo.PlatformMerchantCode = txtProductCode.Value;
                            orderproductInfo.ProductName = lblProductName.Value;
                            if (orderproductInfo.IsApplication == 3)
                            {
                                orderproductInfo.ProductName = txtCJProductCode.Value;
                            }
                            orderproductInfo.Specifications = lblSpecifications.Value;
                            orderproductInfo.ProductNum = int.Parse(txtProductNum.Value.Trim());
                            orderproductInfo.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                            orderproductInfo.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                            orderproductInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            orderproductInfo.UpdateDate = DateTime.Now;

                            base.XMApplicationExchangeService.UpdateXMApplicationExchange(orderproductInfo);

                            base.ShowMessage("修改成功！");
                            if (orderproductInfo.IsApplication == 3)
                            {
                                lblProductName.Value = txtCJProductCode.Value;
                                txtCJProductCode.Value = "";

                            }
                            ScriptManager.RegisterStartupScript(this.GridView1, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);

                        }
                        else
                        {
                            XMApplicationExchange orderproduct = new XMApplicationExchange();
                            if (type == 1 && Session["a"].ToString() != "0")
                            {
                                orderproduct.ApplicationId = int.Parse(Session["a"].ToString());
                            }
                            else if (type == 1 && Session["a"].ToString() == "0")
                            {
                                orderproduct.ApplicationId = int.Parse(this.ApplicationNo.Value.Substring(6, 9));
                            }
                            else
                            {
                                orderproduct.ApplicationId = this.scid;
                            }
                            //查询是否存在此产品
                            //var cx = base.XMProductService.getXMProductListByEqusManufacturersCode(txtCJProductCode.Value);

                            orderproduct.PlatformMerchantCode = txtProductCode.Value;
                            orderproduct.ProductName = lblProductName.Value;
                            orderproduct.Specifications = lblSpecifications.Value;
                            orderproduct.ProductNum = int.Parse(txtProductNum.Value.Trim());
                            orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                            orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                            orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.CreateDate = DateTime.Now;
                            orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.UpdateDate = DateTime.Now;
                            orderproduct.IsApplication = 2;//1为新增类型
                            //if (cx.Count == 0)
                            //{
                            //    orderproduct.ProductName = txtCJProductCode.Value;
                            //    orderproduct.IsApplication = 3;//1为新增类型
                            //}

                            base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                            BindGridtui();

                            base.ShowMessage("添加成功！");
                            ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);


                        }
                    }
                    catch (Exception ex)
                    {
                        base.ShowMessage("请检查数字填写是否正确！");
                        ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
                    }


                }
            }
            catch
            {
                base.ShowMessage("操作失败！");
                ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
            }
        }

        //修改退货商品
        protected void Clients2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                #region 删除
                if (e.CommandName.Equals("XMOrderInfoDelete"))
                {
                    var a = Session["sc"].ToString();
                    Session["sc"] = a + "," + e.CommandArgument;
                    base.ShowMessage("删除成功！");
                    BindGridtui();
                    ScriptManager.RegisterStartupScript(this.GridView6, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);

                }

                #endregion

                //修改
                if (e.CommandName.Equals("OrderProductUpdate"))
                {
                    try
                    {
                        //查询退换货的信息是否已有
                        var orderproductInfo = base.XMApplicationExchangeService.GetXMApplicationExchangeByID(Convert.ToInt32(e.CommandArgument));
                        //编辑行
                        GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                        //HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("txtProductCode");
                        HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("lblManufacturers2");//商品编码
                        HtmlInputControl lblProductName = (HtmlInputControl)gvr.FindControl("lblProductName2");
                        HtmlInputControl lblSpecifications = (HtmlInputControl)gvr.FindControl("lblSpecifications2");
                        HtmlInputText txtCJProductCode = (HtmlInputText)gvr.FindControl("txtProductCode2");//厂家编码

                        HtmlInputText txtProductNum = (HtmlInputText)gvr.FindControl("txtProductNum2");
                        TextBox lblFactoryPrice = (TextBox)gvr.FindControl("lblFactoryPrice2");
                        TextBox txtSalesPrice = (TextBox)gvr.FindControl("txtSalesPrice2");
                        if (orderproductInfo != null)
                        {
                            orderproductInfo.PlatformMerchantCode = txtProductCode.Value;
                            orderproductInfo.ProductName = lblProductName.Value;
                            if (orderproductInfo.IsApplication == 3)
                            {
                                orderproductInfo.ProductName = txtCJProductCode.Value;
                            }
                            orderproductInfo.Specifications = lblSpecifications.Value;
                            orderproductInfo.ProductNum = int.Parse(txtProductNum.Value.Trim());
                            orderproductInfo.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                            orderproductInfo.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                            orderproductInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            orderproductInfo.UpdateDate = DateTime.Now;

                            base.XMApplicationExchangeService.UpdateXMApplicationExchange(orderproductInfo);

                            base.ShowMessage("修改成功！");
                            if (orderproductInfo.IsApplication == 3)
                            {
                                lblProductName.Value = txtCJProductCode.Value;
                                txtCJProductCode.Value = "";

                            }
                            ScriptManager.RegisterStartupScript(this.GridView6, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);

                        }
                        else
                        {
                            XMApplicationExchange orderproduct = new XMApplicationExchange();
                            if (type == 1 && Session["a"].ToString() != "0")
                            {
                                orderproduct.ApplicationId = int.Parse(Session["a"].ToString());
                            }
                            else if (type == 1 && Session["a"].ToString() == "0")
                            {
                                orderproduct.ApplicationId = int.Parse(this.ApplicationNo.Value.Substring(6, 9));
                            }
                            else
                            {
                                orderproduct.ApplicationId = this.scid;
                            }
                            //查询是否存在此产品
                            //var cx = base.XMProductService.getXMProductListByEqusManufacturersCode(txtCJProductCode.Value);

                            orderproduct.PlatformMerchantCode = txtProductCode.Value;
                            orderproduct.ProductName = lblProductName.Value;
                            orderproduct.Specifications = lblSpecifications.Value;
                            orderproduct.ProductNum = int.Parse(txtProductNum.Value.Trim());
                            orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                            orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                            orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.CreateDate = DateTime.Now;
                            orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.UpdateDate = DateTime.Now;
                            orderproduct.IsApplication = 2;//1为新增类型
                            //if (cx.Count == 0)
                            //{
                            //    orderproduct.ProductName = txtCJProductCode.Value;
                            //    orderproduct.IsApplication = 3;//1为新增类型
                            //}

                            base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                            BindGridtui();
                            base.ShowMessage("添加成功！");
                            ScriptManager.RegisterStartupScript(this.GridView6, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);


                        }
                    }
                    catch (Exception ex)
                    {
                        base.ShowMessage("请检查数字填写是否正确！");
                        ScriptManager.RegisterStartupScript(this.GridView6, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
                    }


                }
            }
            catch
            {
                base.ShowMessage("操作失败！");
                ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
            }
        }

        //原来数据
        protected void Clientsb_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                #region 删除
                if (e.CommandName.Equals("XMOrderInfoDelete"))
                {
                    var a = Session["newsc"].ToString();
                    Session["newsc"] = a + "," + e.CommandArgument;
                    base.ShowMessage("删除成功！");
                    BindGridtui();
                    ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);

                }

                #endregion

                //修改
                if (e.CommandName.Equals("OrderProductUpdate"))
                {
                    try
                    {
                        ////查询退换货的信息是否已有
                        //var orderproductInfo = base.XMApplicationExchangeService.GetXMApplicationExchangeByID(Convert.ToInt32(e.CommandArgument));
                        ////编辑行
                        //GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                        ////HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("txtProductCode");
                        //HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("lblManufacturers");//商品编码
                        //HtmlInputControl lblProductName = (HtmlInputControl)gvr.FindControl("lblProductName");
                        //HtmlInputControl lblSpecifications = (HtmlInputControl)gvr.FindControl("lblSpecifications");
                        //HtmlInputText txtProductNum = (HtmlInputText)gvr.FindControl("txtProductNum");
                        //TextBox lblFactoryPrice = (TextBox)gvr.FindControl("lblFactoryPrice");
                        //TextBox txtSalesPrice = (TextBox)gvr.FindControl("txtSalesPrice");
                        //if (orderproductInfo != null)
                        //{
                        //    orderproductInfo.PlatformMerchantCode = txtProductCode.Value;
                        //    orderproductInfo.ProductName = lblProductName.Value;
                        //    orderproductInfo.Specifications = lblSpecifications.Value;
                        //    orderproductInfo.ProductNum = int.Parse(txtProductNum.Value.Trim());
                        //    orderproductInfo.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                        //    orderproductInfo.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                        //    orderproductInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                        //    orderproductInfo.UpdateDate = DateTime.Now;

                        //    base.XMApplicationExchangeService.UpdateXMApplicationExchange(orderproductInfo);

                        //    base.ShowMessage("修改成功！");

                        //    ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);

                        //}
                        //else
                        //{
                        //    XMApplicationExchange orderproduct = new XMApplicationExchange();
                        //    if (type == 1 && Session["a"].ToString() != "0")
                        //    {
                        //        orderproduct.ApplicationId = Session["a"].ToString();
                        //    }
                        //    else if (type == 1 && Session["a"].ToString() == "0")
                        //    {
                        //        orderproduct.ApplicationId = this.ApplicationNo.Value;
                        //    }
                        //    else
                        //    {
                        //        orderproduct.ApplicationId = this.scid.ToString();
                        //    }
                        //    orderproduct.PlatformMerchantCode = txtProductCode.Value;
                        //    orderproduct.ProductName = lblProductName.Value;
                        //    orderproduct.Specifications = lblSpecifications.Value;
                        //    orderproduct.ProductNum = int.Parse(txtProductNum.Value.Trim());
                        //    orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                        //    orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                        //    orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                        //    orderproduct.CreateDate = DateTime.Now;
                        //    orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                        //    orderproduct.UpdateDate = DateTime.Now;
                        //    orderproduct.IsApplication = 1;//1为新增类型

                        //    base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                        //    BindGrid();
                        //    //base.ShowMessage("添加成功！");
                        //    ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);


                        //}
                    }
                    catch (Exception ex)
                    {
                        base.ShowMessage("请检查数字填写是否正确！");
                        ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
                    }


                }
            }
            catch
            {
                base.ShowMessage("操作失败！");
                ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        { }

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                #region 删除
                if (e.CommandName.Equals("XMOrderInfoDelete"))
                {

                    var ApplicationExchang = base.XMApplicationExchangeService.GetXMApplicationExchangeByID(Convert.ToInt32(e.CommandArgument));

                    if (ApplicationExchang != null)//删除
                    {
                        base.XMApplicationExchangeService.DeleteXMApplicationExchange(Convert.ToInt32(e.CommandArgument));

                        base.ShowMessage("删除成功.");
                        BindGrid();
                        ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);

                    }

                }

                #endregion

                //修改
                if (e.CommandName.Equals("OrderProductUpdate"))
                {
                    try
                    {
                        //查询退换货的信息是否已有
                        var orderproductInfo = base.XMApplicationExchangeService.GetXMApplicationExchangeByID(Convert.ToInt32(e.CommandArgument));
                        //编辑行
                        GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                        //HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("txtProductCode");
                        HtmlInputText txtProductCode = (HtmlInputText)gvr.FindControl("lblManufacturers");//商品编码
                        HtmlInputControl lblProductName = (HtmlInputControl)gvr.FindControl("lblProductName");
                        HtmlInputControl lblSpecifications = (HtmlInputControl)gvr.FindControl("lblSpecifications");
                        HtmlInputText txtCJProductCode = (HtmlInputText)gvr.FindControl("txtProductCode");//厂家编码

                        HtmlInputText txtProductNum = (HtmlInputText)gvr.FindControl("txtProductNum");
                        TextBox lblFactoryPrice = (TextBox)gvr.FindControl("lblFactoryPrice");
                        TextBox txtSalesPrice = (TextBox)gvr.FindControl("txtSalesPrice");
                        if (orderproductInfo != null)
                        {
                            orderproductInfo.PlatformMerchantCode = txtProductCode.Value;
                            orderproductInfo.ProductName = lblProductName.Value;
                            if (orderproductInfo.IsApplication == 3)
                            {
                                orderproductInfo.ProductName = txtCJProductCode.Value;
                            }
                            orderproductInfo.Specifications = lblSpecifications.Value;
                            orderproductInfo.ProductNum = int.Parse(txtProductNum.Value.Trim());
                            orderproductInfo.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                            orderproductInfo.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                            orderproductInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                            orderproductInfo.UpdateDate = DateTime.Now;

                            base.XMApplicationExchangeService.UpdateXMApplicationExchange(orderproductInfo);

                            base.ShowMessage("修改成功！");
                            if (orderproductInfo.IsApplication == 3)
                            {
                                lblProductName.Value = txtCJProductCode.Value;
                                txtCJProductCode.Value = "";

                            }
                            ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);

                        }
                        else
                        {
                            XMApplicationExchange orderproduct = new XMApplicationExchange();
                            if (type == 1 && Session["a"].ToString() != "0")
                            {
                                orderproduct.ApplicationId = int.Parse(Session["a"].ToString());
                            }
                            else if (type == 1 && Session["a"].ToString() == "0")
                            {
                                orderproduct.ApplicationId = int.Parse(this.ApplicationNo.Value.Substring(6, 9));
                            }
                            else
                            {
                                orderproduct.ApplicationId = this.scid;
                            }
                            //查询是否存在此产品
                            var cx = base.XMProductService.getXMProductListByEqusManufacturersCode(txtCJProductCode.Value);

                            orderproduct.PlatformMerchantCode = txtProductCode.Value;
                            orderproduct.ProductName = lblProductName.Value;
                            orderproduct.Specifications = lblSpecifications.Value;
                            orderproduct.ProductNum = int.Parse(txtProductNum.Value.Trim());
                            orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim());
                            orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                            orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.CreateDate = DateTime.Now;
                            orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.UpdateDate = DateTime.Now;
                            orderproduct.IsApplication = 1;//1为新增类型
                            if (cx.Count == 0)
                            {
                                orderproduct.ProductName = txtCJProductCode.Value;
                                orderproduct.IsApplication = 3;//1为新增类型
                            }

                            base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                            BindGrid();
                            //base.ShowMessage("添加成功！");
                            ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);


                        }
                    }
                    catch (Exception ex)
                    {
                        base.ShowMessage("请检查数字填写是否正确！");
                        ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
                    }


                }
            }
            catch
            {
                base.ShowMessage("操作失败！");
                ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
            }
        }

        //对GridView3绑定值进行操作
        protected void grdCount2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var premiumsDetails = e.Row.DataItem as XMApplicationExchange;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (premiumsDetails != null)
                {
                    TextBox txtcou = e.Row.FindControl("txtcount") as TextBox;
                    HtmlInputText txtProductNum = e.Row.FindControl("txtProductNum") as HtmlInputText;
                    TextBox lblFactoryPrice = e.Row.FindControl("lblFactoryPrice") as TextBox;
                    TextBox txtSalesPrice = e.Row.FindControl("txtSalesPrice") as TextBox;

                    int? cou = 0;
                    decimal? pay = 0;
                    decimal? sale = 0;
                    var jian = base.XMApplicationExchangeService.GetXMApplicationExchangeByIsNewOrIDlist(premiumsDetails.ID, 0, 2).Where(p => p.ApplicationId != scid);
                    if (jian != null)
                    {
                        List<int> idpaixu2 = new List<int>();
                        foreach (var b in jian)
                        {
                            cou = cou + b.ProductNum;
                            pay = pay + b.FactoryPrice;
                            sale = sale + b.SalesPrice;
                        }
                        txtProductNum.Value = (premiumsDetails.ProductNum - cou).ToString();
                        lblFactoryPrice.Text = (premiumsDetails.FactoryPrice - pay).ToString();
                        txtSalesPrice.Text = premiumsDetails.SalesPrice == null ? "0" : (premiumsDetails.SalesPrice - sale).ToString();
                    }
                    if (txtProductNum.Value == "0")
                    {
                        var a = Session["newsc"].ToString();
                        Session["newsc"] = a + "," + premiumsDetails.ID;
                        //BindGridtui();
                        //GridView3.Rows[int.Parse(e.Row.RowIndex.ToString())].Visible = false;
                    }
                    if (type == 2)
                    {
                        var count = base.XMApplicationExchangeService.GetXMApplicationExchangeByIsNewOrID(premiumsDetails.ID, this.scid, 2);
                        if (count != null)
                        {
                            txtcou.Text = count.ProductNum.ToString();
                        }
                    }
                }
                //e.Row.Cells[0].Visible = false; //隐藏对应列
            }
        }

        //对GridView4 换货零件绑定值进行操作
        protected void grdCount4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var premiumsDetails = e.Row.DataItem as XMApplicationExchange;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (premiumsDetails.ID != 0)
                {
                    ImageButton imgBtnUpdate = e.Row.FindControl("imgBtnUpdate") as ImageButton;
                    imgBtnUpdate.Visible = false;
                }
                if (premiumsDetails != null)
                {
                    TextBox txtcou = e.Row.FindControl("txtcount") as TextBox;
                    HtmlInputText txtProductNum = e.Row.FindControl("txtProductNum") as HtmlInputText;
                    TextBox lblFactoryPrice = e.Row.FindControl("lblFactoryPrice") as TextBox;
                    TextBox txtSalesPrice = e.Row.FindControl("txtSalesPrice") as TextBox;

                    int? cou = 0;
                    decimal? pay = 0;
                    decimal? sale = 0;
                    var jian = base.XMApplicationExchangeService.GetXMApplicationExchangeByIsNewOrIDlist(premiumsDetails.ID, 0, 4).Where(p => p.ApplicationId != scid);
                    if (jian != null)
                    {
                        List<int> idpaixu2 = new List<int>();
                        foreach (var b in jian)
                        {
                            cou = cou + b.ProductNum;
                            pay = pay + b.FactoryPrice;
                            sale = sale + b.SalesPrice;
                        }
                        if (premiumsDetails.ApplicationId.ToString().Length == 9)
                        {
                            txtProductNum.Value = premiumsDetails.ProductNum.ToString();
                            lblFactoryPrice.Text = premiumsDetails.FactoryPrice.ToString();
                            txtSalesPrice.Text = premiumsDetails.SalesPrice.ToString();
                        }
                        else
                        {
                            txtProductNum.Value = (premiumsDetails.ProductNum - cou).ToString();
                            lblFactoryPrice.Text = (premiumsDetails.FactoryPrice - pay).ToString();
                            txtSalesPrice.Text = premiumsDetails.SalesPrice == null ? "0" : (premiumsDetails.SalesPrice - sale).ToString();
                        }
                    }
                    if (txtProductNum.Value == "0")
                    {
                        var a = Session["newsclj"].ToString();
                        Session["newsclj"] = a + "," + premiumsDetails.ID;

                        //GridView1.Rows[int.Parse(e.Row.RowIndex.ToString())].Visible = false;
                    }
                    //OrderProductDetails = OrderProductDetails.Where(p => !idpaixu2.Contains(p.ID));
                    if (type == 2)
                    {
                        var count = base.XMApplicationExchangeService.GetXMApplicationExchangeByIsNewOrID(premiumsDetails.ID, this.scid, 4);
                        if (count != null)
                        {
                            txtcou.Text = count.ProductNum.ToString();
                        }
                    }
                    else if (type == 1 && premiumsDetails.ApplicationId.ToString().Length == 9)
                    {
                        var count = base.XMApplicationExchangeService.GetXMApplicationExchangeByIsNewOrID(premiumsDetails.ID, int.Parse(premiumsDetails.ApplicationId.ToString()), 4);
                        if (count != null)
                        {
                            txtcou.Text = count.ProductNum.ToString();
                        }
                    }

                }
            }
        }

        //对GridView1绑定值进行操作
        protected void grdCount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var premiumsDetails = e.Row.DataItem as XMOrderInfoProductDetails;
                TextBox txtcou = e.Row.FindControl("txtcount") as TextBox;
                HtmlInputText txtProductNum = e.Row.FindControl("txtProductNum3") as HtmlInputText;
                TextBox lblFactoryPrice = e.Row.FindControl("lblFactoryPrice3") as TextBox;
                TextBox txtSalesPrice = e.Row.FindControl("txtSalesPrice3") as TextBox;
                if (premiumsDetails != null)
                {
                    int? cou = 0;
                    decimal? pay = 0;
                    decimal? sale = 0;

                    var jian = base.XMApplicationExchangeService.GetXMApplicationExchangeByIsOrIDlist(premiumsDetails.ID, 0, 2).Where(p => p.ApplicationId != scid);
                    if (jian != null)
                    {
                        List<int> idpaixu2 = new List<int>();
                        foreach (var b in jian)
                        {
                            cou = cou + b.ProductNum;
                            pay = pay + b.FactoryPrice;
                            sale = sale + b.SalesPrice;
                        }
                        txtProductNum.Value = (premiumsDetails.ProductNum - cou).ToString();
                        lblFactoryPrice.Text = (premiumsDetails.FactoryPrice - pay).ToString();
                        if (premiumsDetails.SalesPrice == null)
                        {
                            txtSalesPrice.Text = "0";
                        }
                        else
                        {
                            txtSalesPrice.Text = (premiumsDetails.SalesPrice - sale).ToString();
                        }
                    }
                    if (txtProductNum.Value == "0")
                    {
                        var a = Session["sc"].ToString();
                        Session["sc"] = a + "," + premiumsDetails.ID;

                        //GridView1.Rows[int.Parse(e.Row.RowIndex.ToString())].Visible = false;
                    }
                    //OrderProductDetails = OrderProductDetails.Where(p => !idpaixu2.Contains(p.ID));
                    if (type == 2)
                    {
                        var count = base.XMApplicationExchangeService.GetXMApplicationExchangeByIsOrID(premiumsDetails.ID, this.scid, 2);
                        if (count != null)
                        {
                            txtcou.Text = count.ProductNum.ToString();
                        }
                        else
                        {
                            txtcou.Text = "0";
                        }
                    }
                }
            }
        }

        //对绑定值进行操作
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var ApplicationExchange = e.Row.DataItem as XMApplicationExchange;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgBtnSpareAddress = (ImageButton)e.Row.FindControl("imgBtnSpareAddress");
                ImageButton imgBtnUpdate = e.Row.FindControl("imgBtnUpdate") as ImageButton;
                ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;

                if (ApplicationExchange.ID == 0)
                {
                    imgBtnSpareAddress.Visible = false;
                }
                else if (imgBtnSpareAddress != null)
                {
                    imgBtnSpareAddress.OnClientClick = "return ShowWindowDetail('备用地址','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMSpareAddressEdit.aspx?Id=" + ApplicationExchange.ID.ToString() + "&TypeID=710', 400, 420, this, function(){});";
                }

                if (ApplicationExchange.ApplicationId != null)
                {
                    //var product = base.XMProductService.GetXMProductById(premiumsDetails.ProductDetaislId.Value);
                    //if (product != null)
                    //{
                    //    //尺寸
                    //    //TextBox txtSpecifications = e.Row.FindControl("txtSpecifications") as TextBox;
                    //    HtmlInputText lblSpecifications = (HtmlInputText)e.Row.FindControl("lblSpecifications");
                    //    //Label lblSpecifications = e.Row.FindControl("lblSpecifications") as Label;
                    //    if (lblSpecifications != null)
                    //    {
                    //        lblSpecifications.Value = product.Specifications;
                    //    }
                    //}

                    #region 保存按钮
                    var XMApplication = base.XMApplicationService.GetXMApplicationByID(scid);

                    if (XMApplication != null)
                    {
                        if (XMApplication.SupervisorStatus == true)
                        {
                            imgBtnUpdate.Visible = false;
                            imgBtnDelete.Visible = false;
                            imgBtnSpareAddress.Visible = false;
                        }
                    }
                    #endregion
                }
            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        private void LoadDate(object sender, EventArgs e)
        {
            if (type == 2 && scid > 0)
            {
                var XMApplication = XMApplicationService.GetXMApplicationByID(scid);
                if (XMApplication != null)
                {

                    this.ApplicationNo.Value = XMApplication.ApplicationNo;//申请单号
                    this.addtime.Text = XMApplication.CreateDate.ToString();//申请时间
                    this.ApplicaType2.Value = XMApplication.ApplicationType.ToString();//申请类型
                    this.txtOrderCode.Value = XMApplication.OrderCode;//退货订单号
                    this.ddlPlatform.SelectedValue= XMApplication.PlatformTypeId.ToString();//平台id
                    ddlPlatformTypeId_SelectedIndexChanged(sender, e);
                    //this.PlatformTypeId.Value = XMApplication.PlatformTypeId.ToString();//平台id
                    //this.PlatformType.Value = XMApplication.PlatformType;//平台
                    this.ddlNick1.Value= XMApplication.NickId.Value.ToString();//店铺id
                    txtHidden1.Value= XMApplication.NickId.Value.ToString();//店铺id
                    //this.NickId.Value = XMApplication.NickId.Value.ToString();//店铺id
                    //this.Nick.Value = XMApplication.NickName;//店铺
                    this.Amount.Value = XMApplication.Amount.ToString();//金额
                    DdlFactory.Value = XMApplication.FactoryID.ToString();
                    if (XMApplication.ReturnCategoryID != null)
                    {
                        ddlReturnCategoryList.Value = XMApplication.ReturnCategoryID.Value.ToString();
                    }
                    this.ReservepriceOrder2.Value = XMApplication.ReservepriceOrder.ToString();//补价订单
                    //this.ReturnTime.Value = XMApplication.ReturnTime.ToString();//退货入仓时间
                    this.FinishTime.Text = XMApplication.FinishTime.ToString();//完成时间
                    this.LeaderComments.Text = XMApplication.Remarks.ToString();//备注
                    this.SupervisorStatus.Checked = bool.Parse(XMApplication.SupervisorStatus.ToString());//客服主管审核状态
                    //this.FinancialStatus.Checked = bool.Parse(XMApplication.FinancialStatus.ToString());//财务审核状态
                    this.IsSend.Checked = bool.Parse(XMApplication.IsSend.ToString());//是否推送千胜系统
                    //this.Button1.Visible = true;
                    this.Button3.Visible = false;
                    //this.Button2.Visible = false;
                    btnFinish.Visible = false;
                    if (XMApplication.SupervisorStatus == true)//|| XMApplication.FinancialStatus == true
                    {
                        this.txtOrderCode.Disabled = true;
                        this.ApplicaType2.Disabled = true;
                        this.Amount.Disabled = true;
                        this.ReservepriceOrder2.Disabled = true;
                        this.LeaderComments.ReadOnly = true;
                        this.btnSave.Visible = false;
                        this.Button3.Visible = true;
                    }
                    if (XMApplication.SupervisorStatus == true)//&& XMApplication.FinancialStatus == true
                    {
                        btnFinish.Visible = true;
                    }
                    if (XMApplication.FinishTime != null)
                    {
                        //this.ReturnTime.Disabled = true;
                        this.btnSave.Visible = false;
                        this.Button3.Visible = false;
                        //this.Button2.Visible = false;
                        btnFinish.Visible = false;
                       // this.Button1.Visible = false;
                    }

                    //if(XMApplication.IsSingleRow==true)
                    //{
                    //    btSave.Visible = false;
                    //    btnFinish.Visible = false;
                    //}

                    if(!string.IsNullOrEmpty(XMApplication.OrderCode))
                    {
                        var cx = base.XMOrderInfoService.GetXMOrderByOrderCode(XMApplication.OrderCode);
                        if(cx!=null)
                        {
                            backPrice.InnerHtml = "已支付金额：" + cx.PayPrice.ToString();
                        }
                    }
                }
            }
            else
            {
                this.Button3.Visible = false;
                //this.Button2.Visible = false;
                btnFinish.Visible = false;
                var a = DateTime.Now.ToString("yyyyMMddHHmmssf");
                this.ApplicationNo.Value = a;
                this.addtime.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            }
        }

        /// <summary>
        /// 完成进退货申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveSwan_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                int[] ApplicationTypeList = { 5, 6, 7 };//申请类型（先退货后退款，换货，先退款后退货）
                if (type == 2 && scid > 0)
                {
                    //if (this.ApplicaType2.Value == "5" || this.ApplicaType2.Value == "6" || this.ApplicaType2.Value == "7")
                    //{
                    //    if (string.IsNullOrEmpty(this.ReturnTime.Value.Trim()))
                    //    {
                    //        base.ShowMessage("退换货的入仓日期不能为空");
                    //        return;
                    //    }
                    //}
                    // 查询进退货申请
                    var xMQuestion = base.XMApplicationService.GetXMApplicationByID(scid);
                    if (xMQuestion != null)
                    {
                        if (string.IsNullOrEmpty(txtReturnLogisticsNumber.Text.Trim())&& ApplicationTypeList.Contains((int)xMQuestion.ApplicationType))
                        {
                            //base.ShowMessage("申请单号：" + xMQuestion.ApplicationNo + "，退回物流单号为空！");
                            Ext.Net.ExtNet.Msg.Alert("提示", "申请单号：" + xMQuestion.ApplicationNo + "，退回物流单号为空！").Show();
                            return;
                        }

                        xMQuestion.FinishTime = DateTime.Now;
                        //if (this.ApplicaType2.Value == "5" || this.ApplicaType2.Value == "6" || this.ApplicaType2.Value == "7")
                        //{
                        //    xMQuestion.ReturnTime = DateTime.Parse(this.ReturnTime.Value.ToString());
                        //}
                        xMQuestion.UpdateID = HozestERPContext.Current.User.CustomerID;
                        xMQuestion.UpdateDate = DateTime.Now;
                        base.XMApplicationService.UpdateXMApplication(xMQuestion);
                        this.FinishTime.Text = xMQuestion.FinishTime.ToString();
                        //if (xMQuestion.ApplicationType == 4)
                        //{
                        //    var jiu = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(xMQuestion.OrderCode);
                        //    if (jiu != null)
                        //    {
                        //        if (jiu.PayPrice == xMQuestion.Amount)
                        //        {
                        //            jiu.IsEnable = false;
                        //        }
                        //        else
                        //        {
                        //            jiu.PayPrice = jiu.PayPrice - xMQuestion.Amount;
                        //        }
                        //        base.XMOrderInfoService.UpdateXMOrderInfo(jiu);
                        //    }
                        //}
                        //else if (xMQuestion.ApplicationType == 5)
                        //{

                        //}
                    }
                }
                scope.Complete();

            }

            Ext.Net.ExtNet.Msg.Alert("提示", "完成进退货申请成功！").Show();
        }

        protected void submit1_Click(object sender, EventArgs e)
        {
            //base.ShowMessage("完成进退货申请成功");
            BindGridling();
            BindGridtui();
            ScriptManager.RegisterStartupScript(this.GridView1, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
            //ScriptManager.RegisterStartupScript(this.GridView3, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
            //ScriptManager.RegisterStartupScript(this.GridView4, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);

        }

        #region
        protected void btSave_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            
            string data1 = e.ExtraParams["data1"];
            string data2 = e.ExtraParams["data2"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<ProductModel> list1 = Serializer.Deserialize<List<ProductModel>>(data1);
            List<ProductModel> list2 = Serializer.Deserialize<List<ProductModel>>(data2);

            int ApplicaType = int.Parse(this.ApplicaType2.Value);//申请类型

            if(ApplicaType== Convert.ToInt16(AppStatusEnum.tuihuo)|| ApplicaType == Convert.ToInt16(AppStatusEnum.huanhuo)|| ApplicaType == Convert.ToInt16(AppStatusEnum.secondtuihuan))
            {
                if(list1.Count<=0||(list1.Count>0&& list1.Where(a=>a.countNum<=0).Count()>0))
                {
                    Ext.Net.ExtNet.Msg.Alert("提示", "必须有退货商品，退货数量不能为0！").Show();
                    return;
                }
            }

            decimal BackMoney;
            if (!decimal.TryParse(this.Amount.Value.Trim(), out BackMoney))
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "请输入正确的退款金额！").Show();
                return;
            }

            if (ApplicaType == Convert.ToInt16(AppStatusEnum.huanhuo))//换货
            {
                if(list2.Count<=0||(list2.Count>0&&list2.Where(a=>a.ProductNum<=0).Count()>0))
                {
                    Ext.Net.ExtNet.Msg.Alert("提示", "必须有换货商品，换货数量不能为0！").Show();
                    return;
                }
            }

            string ApplicationNo = this.ApplicationNo.Value.Trim();//申请单号
            string OrderCode = this.txtOrderCode.Value.Trim();//退货订单号
            int PlatformTypeId = int.Parse(this.ddlPlatform.SelectedValue);//平台
            int NickId = int.Parse(this.txtHidden1.Value);//店铺
            decimal Amount = decimal.Parse(this.Amount.Value.Trim());//金额
            string ReservepriceOrder = this.ReservepriceOrder2.Value.Trim();//补价订单
            string LeaderComments = this.LeaderComments.Text.Trim();//备注
            int? factoryID = null;
            if(DdlFactory.Value!=null)
            {
                if(!string.IsNullOrEmpty(DdlFactory.Value.ToString()))
                {
                    factoryID = int.Parse(DdlFactory.Value.ToString());
                }
            }
            int? ReturnCategoryID = null;
            if(ddlReturnCategoryList.Value!=null)
            {
                ReturnCategoryID = int.Parse(ddlReturnCategoryList.Value.ToString());
            }

            if (string.IsNullOrEmpty(OrderCode)||OrderCode.IndexOf("NoOrder") >=0)
            {

            }
            else
            {
                var OrderInfoEntity = XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
                if(OrderInfoEntity==null)
                {
                    Ext.Net.ExtNet.Msg.Alert("提示", "订单号不存在！").Show();
                    return;
                }

                var XMApplicationEntity = XMApplicationService.GetXMApplicationListByOrderCode(OrderCode).Where(p => p.ID != scid);
                decimal tuikuan = 0;
                decimal bujia = 0;
                foreach (var list in XMApplicationEntity)
                {
                    tuikuan = tuikuan + decimal.Parse(list.Amount.ToString());
                    if (list.ReservepriceOrder != null)
                    {
                        var bu = XMOrderInfoService.GetXMOrderInfoByOrderCode(list.ReservepriceOrder);
                        if (bu != null)
                        {
                            if (bu.PayPrice != null)
                            {
                                bujia = bujia + decimal.Parse(bu.PayPrice.ToString());
                            }
                        }
                    }
                }
                if ((OrderInfoEntity.PayPrice + bujia) < (Amount + tuikuan))
                {
                    Ext.Net.ExtNet.Msg.Alert("提示", "退款金额不能大于该订单的付款金额！").Show();
                    return;
                }

                if (!string.IsNullOrEmpty(ReservepriceOrder))
                {
                    var b = XMOrderInfoService.GetXMOrderInfoByOrderCode(ReservepriceOrder);
                    if (b == null)
                    {
                        Ext.Net.ExtNet.Msg.Alert("提示", "请先确认该补价订单号是否存在！").Show();
                        return;
                    }
                }

            }

            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                XMApplication XMApplication = new XMApplication();
                if (type == 1)
                {
                    var applicationList = XMApplicationService.GetXMApplicationListByApplicationNo(ApplicationNo);
                    if (applicationList.Count > 0)
                    {
                        Ext.Net.ExtNet.Msg.Alert("提示", "退货单号：" + this.ApplicationNo.Value.Trim() + "已存在！").Show();
                        return;
                    }
                    XMApplication.OrderCode = string.IsNullOrEmpty(OrderCode) ? "NoOrder" + DateTime.Now.ToString("yyMMddHHmmssfff") : OrderCode;//退货订单号
                    XMApplication.ApplicationNo = ApplicationNo;//申请单号
                    XMApplication.ApplicationType = ApplicaType;//申请类型
                    XMApplication.PlatformTypeId = PlatformTypeId;//平台id
                    XMApplication.NickId = NickId;//店铺id
                    XMApplication.Amount = Amount;//金额
                    XMApplication.FactoryID = factoryID;//退回工厂
                    XMApplication.ReturnCategoryID = ReturnCategoryID;//退货原因
                    XMApplication.ReservepriceOrder = ReservepriceOrder;//补价订单
                    XMApplication.Remarks = LeaderComments;//备注
                    XMApplication.IsSend = false;//是否推送千胜系统
                    XMApplication.SupervisorStatus = false;//主管审核状态
                    XMApplication.FinancialStatus = false;//财务审核状态
                    XMApplication.CreateID = HozestERPContext.Current.User.CustomerID;//创建人
                    XMApplication.CreateDate = DateTime.Now;//创建时间
                    XMApplication.UpdateID = HozestERPContext.Current.User.CustomerID;//更新人
                    XMApplication.UpdateDate = DateTime.Now;//更新时间
                    XMApplication.IsEnable = false;//是否删除
                    XMApplication.ReturnLogisticsNumber = txtReturnLogisticsNumber.Text; //退回单号
                    //if (ApplicationNo == "5" || ApplicationNo == "6" || ApplicationNo == "7")
                    //{
                    //    if (DdlFactory.Value != null)
                    //        XMApplication.FactoryID = int.Parse(DdlFactory.Value.ToString());//退回工厂
                    //    XMApplication.ReturnCategoryID = Convert.ToInt16(ddlReturnCategoryList.SelectedValue);//退货原因
                    //}
                    base.XMApplicationService.InsertXMApplication(XMApplication);

                }
                else if (type == 2)
                {
                    XMApplication = XMApplicationService.GetXMApplicationByID(scid);
                    if (XMApplication.SupervisorStatus == true) 
                    {
                        Ext.Net.ExtNet.Msg.Alert("提示", "已审核不允许修改！").Show();
                        return;
                    }
                    XMApplication.OrderCode = OrderCode;//退货订单号
                    XMApplication.ApplicationType = ApplicaType;//申请类型
                    XMApplication.PlatformTypeId = PlatformTypeId;//平台id
                    XMApplication.NickId = NickId;//店铺id
                    XMApplication.Amount = Amount;//金额
                    XMApplication.ReservepriceOrder = ReservepriceOrder;//补价订单
                    XMApplication.Remarks = LeaderComments;//备注
                    XMApplication.UpdateID = HozestERPContext.Current.User.CustomerID;//更新人
                    XMApplication.UpdateDate = DateTime.Now;//更新时间
                    XMApplication.IsEnable = false;//是否删除
                    XMApplication.ReturnLogisticsNumber = txtReturnLogisticsNumber.Text; //退回单号
                    XMApplication.LogisticsCost = string.IsNullOrEmpty(txtLogisticsFee.Text) ? 0 : decimal.Parse(txtLogisticsFee.Text);
                    XMApplication.FactoryID = factoryID;//退回工厂
                    XMApplication.ReturnCategoryID = ReturnCategoryID;//退货原因
                    base.XMApplicationService.UpdateXMApplication(XMApplication);

                }

                int ApplicationId = XMApplication.ID;
                var list = XMApplicationExchangeService.GetXMApplicationExchangeByAppID(ApplicationId);
                foreach (var item in list)
                {
                    XMApplicationExchangeService.DeleteXMApplicationExchange(item.ID);
                }

                foreach (var item in list1)
                {
                    XMApplicationExchange orderproduct = new XMApplicationExchange();
                    orderproduct.ApplicationId = XMApplication.ID;
                    orderproduct.PlatformMerchantCode = item.PlatformMerchantCode;
                    orderproduct.ProductName = item.ProductName.Length >= 25 ? item.ProductName.Substring(0,25).Trim() : item.ProductName;
                    orderproduct.Specifications = item.Specifications;
                    orderproduct.ProductNum = item.countNum;//退换货数量
                    orderproduct.FactoryPrice = item.FactoryPrice;
                    orderproduct.SalesPrice = item.SalesPrice;
                    orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                    orderproduct.CreateDate = DateTime.Now;
                    orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                    orderproduct.UpdateDate = DateTime.Now;
                    orderproduct.IsApplication = 2;//2为退货类型

                    base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                }

                foreach (var item in list2)
                {
                    XMApplicationExchange orderproduct = new XMApplicationExchange();
                    orderproduct.ApplicationId = XMApplication.ID;
                    orderproduct.PlatformMerchantCode = item.PlatformMerchantCode;
                    orderproduct.ProductName = item.ProductName;
                    orderproduct.Specifications = item.Specifications;
                    orderproduct.ProductNum = item.ProductNum;//退换货数量
                    orderproduct.FactoryPrice = item.FactoryPrice;
                    orderproduct.SalesPrice = item.SalesPrice;
                    orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                    orderproduct.CreateDate = DateTime.Now;
                    orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                    orderproduct.UpdateDate = DateTime.Now;
                    orderproduct.IsApplication = 1;//1为换货类型

                    base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                }

                var xmApplicationExchangeList = base.XMApplicationExchangeService.GetXMApplicationExchangeListByApplicationIDType(XMApplication.ID, 1);

                if((type == 1))
                {
                    if (string.IsNullOrEmpty(OrderCode))
                    {
                        if (!string.IsNullOrEmpty(txtAddress.Text))
                        {
                            XMSpareAddress entity = new XMSpareAddress();
                            entity.OtherID = XMApplication.ID;
                            entity.TypeID = 710;//退换货
                            entity.FullName = txtFullName.Text;
                            entity.Mobile = txtMobile.Text;
                            entity.Tel = txtTel.Text;
                            entity.Province = province.Text;
                            entity.City = city.Text;
                            entity.County = region.Text;
                            entity.DeliveryAddress = txtAddress.Text;
                            entity.IsEnable = false;
                            entity.CreateID = HozestERPContext.Current.User.CustomerID;
                            entity.CreateDate = DateTime.Now;
                            entity.UpdateID = HozestERPContext.Current.User.CustomerID;
                            entity.UpdateDate = DateTime.Now;
                            base.XMSpareAddressService.InsertXMSpareAddress(entity);
                        }
                    }
                    else
                    {
                        foreach (var item in xmApplicationExchangeList)
                        {
                            if (!string.IsNullOrEmpty(txtAddress.Text))
                            {
                                XMSpareAddress entity = new XMSpareAddress();
                                entity.OtherID = item.ID;
                                entity.TypeID = 710;//退换货
                                entity.FullName = txtFullName.Text;
                                entity.Mobile = txtMobile.Text;
                                entity.Tel = txtTel.Text;
                                entity.Province = province.Text;
                                entity.City = city.Text;
                                entity.County = region.Text;
                                entity.DeliveryAddress = txtAddress.Text;
                                entity.IsEnable = false;
                                entity.CreateID = HozestERPContext.Current.User.CustomerID;
                                entity.CreateDate = DateTime.Now;
                                entity.UpdateID = HozestERPContext.Current.User.CustomerID;
                                entity.UpdateDate = DateTime.Now;
                                base.XMSpareAddressService.InsertXMSpareAddress(entity);
                            }
                        }
                    }
                }
                else if (type == 2)
                {
                    if (XMApplication.OrderCode.StartsWith("NoOrder"))
                    {
                        XMSpareAddress entity = XMSpareAddressService.GetXMSpareAddressByParm(XMApplication.ID, 710);
                        if (entity == null)
                        {
                            if (!string.IsNullOrEmpty(txtAddress.Text))
                            {
                                XMSpareAddress entity1 = new XMSpareAddress();
                                entity1.OtherID = XMApplication.ID;
                                entity1.TypeID = 710;//退换货
                                entity1.FullName = txtFullName.Text;
                                entity1.Mobile = txtMobile.Text;
                                entity1.Tel = txtTel.Text;
                                entity1.Province = province.Text;
                                entity1.City = city.Text;
                                entity1.County = region.Text;
                                entity1.DeliveryAddress = txtAddress.Text;
                                entity1.IsEnable = false;
                                entity1.CreateID = HozestERPContext.Current.User.CustomerID;
                                entity1.CreateDate = DateTime.Now;
                                entity1.UpdateID = HozestERPContext.Current.User.CustomerID;
                                entity1.UpdateDate = DateTime.Now;
                                base.XMSpareAddressService.InsertXMSpareAddress(entity1);
                            }
                        }
                        else
                        {
                            entity.OtherID = XMApplication.ID;
                            entity.TypeID = 710;//退换货
                            entity.FullName = txtFullName.Text;
                            entity.Mobile = txtMobile.Text;
                            entity.Tel = txtTel.Text;
                            entity.Province = province.Text;
                            entity.City = city.Text;
                            entity.County = region.Text;
                            entity.DeliveryAddress = txtAddress.Text;
                            entity.IsEnable = false;
                            entity.CreateID = HozestERPContext.Current.User.CustomerID;
                            entity.CreateDate = DateTime.Now;
                            entity.UpdateID = HozestERPContext.Current.User.CustomerID;
                            entity.UpdateDate = DateTime.Now;
                            base.XMSpareAddressService.UpdateXMSpareAddress(entity);
                        }
                    }
                    else
                    {
                        foreach (var item in xmApplicationExchangeList)
                        {
                            XMSpareAddressService.DeleteXMSpareAddress(item.ID);
                        }

                        foreach (var item in xmApplicationExchangeList)
                        {
                            XMSpareAddress entity = XMSpareAddressService.GetXMSpareAddressByParm(item.ID, 710);
                            if (entity == null)
                            {
                                if (!string.IsNullOrEmpty(txtAddress.Text))
                                {
                                    XMSpareAddress entity1 = new XMSpareAddress();
                                    entity1.OtherID = item.ID;
                                    entity1.TypeID = 710;//退换货
                                    entity1.FullName = txtFullName.Text;
                                    entity1.Mobile = txtMobile.Text;
                                    entity1.Tel = txtTel.Text;
                                    entity1.Province = province.Text;
                                    entity1.City = city.Text;
                                    entity1.County = region.Text;
                                    entity1.DeliveryAddress = txtAddress.Text;
                                    entity1.IsEnable = false;
                                    entity1.CreateID = HozestERPContext.Current.User.CustomerID;
                                    entity1.CreateDate = DateTime.Now;
                                    entity1.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    entity1.UpdateDate = DateTime.Now;
                                    base.XMSpareAddressService.InsertXMSpareAddress(entity1);
                                }
                            }
                            else
                            {
                                entity.OtherID = item.ID;
                                entity.TypeID = 710;//退换货
                                entity.FullName = txtFullName.Text;
                                entity.Mobile = txtMobile.Text;
                                entity.Tel = txtTel.Text;
                                entity.Province = province.Text;
                                entity.City = city.Text;
                                entity.County = region.Text;
                                entity.DeliveryAddress = txtAddress.Text;
                                entity.IsEnable = false;
                                entity.CreateID = HozestERPContext.Current.User.CustomerID;
                                entity.CreateDate = DateTime.Now;
                                entity.UpdateID = HozestERPContext.Current.User.CustomerID;
                                entity.UpdateDate = DateTime.Now;
                                base.XMSpareAddressService.UpdateXMSpareAddress(entity);
                            }
                        }
                    }
                }

                scope.Complete();
                Session["a"] = ApplicationId;
            }
            Ext.Net.ExtNet.Msg.Alert("提示", "操作成功！").Show();
        }

        private class ProductModel
        {
            /// <summary>
            /// 商品编码
            /// </summary>
            public string PlatformMerchantCode { get; set; }

            /// <summary>
            /// 厂家编码
            /// </summary>
            public string Manufacturers { get; set; }

            /// <summary>
            /// 商品名称
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// 尺寸
            /// </summary>
            public string Specifications { get; set; }

            /// <summary>
            /// 出厂价
            /// </summary>
            public decimal? FactoryPrice { get; set; }

            /// <summary>
            /// 销售价
            /// </summary>
            public decimal? SalesPrice { get; set; }

            public int ProductNum { get; set; }

            public int countNum { get; set; }
        }
        #endregion

        protected void btnOrderSearch_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            BindReturn(1);
        }

        protected void btnAdd_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            string data = e.ExtraParams["data"];
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<BackProduct> list = Serializer.Deserialize<List<BackProduct>>(data);

            int i = TabPanel.ActiveTabIndex;

            if(i==0)
            {
                foreach (var item in list)
                {
                    GridPanel1.InsertRecord(0, new
                    {
                        PlatformMerchantCode = item.PlatformMerchantCode,
                        Manufacturers = item.ManufacturersCode,
                        ProductName = item.ProductName,
                        Specifications = item.Specifications,
                        ProductNum = 0,
                        FactoryPrice = item.Costprice,
                        SalesPrice = item.Saleprice,
                        countNum = 0,
                    }, true);

                }
            }
            else if(i==1)
            {
                foreach (var item in list)
                {
                    GridPanel2.InsertRecord(0, new
                    {
                        PlatformMerchantCode = item.PlatformMerchantCode,
                        Manufacturers = item.ManufacturersCode,
                        ProductName = item.ProductName,
                        Specifications = item.Specifications,
                        ProductNum = 0,
                        FactoryPrice = item.Costprice,
                        SalesPrice = item.Saleprice,
                    }, true);

                }
            }

            window1.Hidden = true;
        }

        private class BackProduct
        {
            /// <summary>
            /// 商品编码
            /// </summary>
            public string PlatformMerchantCode { get; set; }

            /// <summary>
            /// 厂家编码
            /// </summary>
            public string ManufacturersCode { get; set; }

            /// <summary>
            /// 商品名称
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// 尺寸
            /// </summary>
            public string Specifications { get; set; }

            /// <summary>
            /// 出厂价
            /// </summary>
            public decimal? Costprice { get; set; }

            /// <summary>
            /// 销售价
            /// </summary>
            public decimal? Saleprice { get; set; }

            /// <summary>
            /// 数量
            /// </summary>
            public int Num { get; set; }

            /// <summary>
            /// 退货数量
            /// </summary>
            public int BackNum { get; set; }
        }

        /// <summary>
        /// 保存所有数据
        /// </summary>
        private void SaveAllData()
        {
            //判断是否有退换货数量为0情况
            int num = 0;
            int ApplicaType = int.Parse(this.ApplicaType2.Value);//申请类型
            foreach (GridViewRow list in GridView1.Rows)
            {
                TextBox txtcount = list.FindControl("txtcount") as TextBox;
                if (txtcount.Text.Trim() == "0")
                {
                    num++;
                }
            }
            if (num > 0 && (ApplicaType == Convert.ToInt16(AppStatusEnum.tuihuo) || ApplicaType == Convert.ToInt16(AppStatusEnum.huanhuo) || ApplicaType == Convert.ToInt16(AppStatusEnum.secondtuihuan)))
            {
                base.ShowMessage("必须有退换货商品，退换货数量不能为0！");
            }

            if (string.IsNullOrEmpty(this.txtOrderCode.Value.Trim()))
            {
                base.ShowMessage("退换货订单号不能为空.");
                return;
            }
            decimal i;
            if (!decimal.TryParse(this.Amount.Value.Trim(), out i))
            {
                base.ShowMessage("请输入正确的退款金额.");
                return;
            }
            if (ApplicaType == 6)//换货
            {
                HtmlInputControl lblProductName = (this.grdvClients.Rows[0]).FindControl("lblProductName") as HtmlInputControl;
                if (this.grdvClients.Rows.Count == 0 || (this.grdvClients.Rows.Count == 1 && string.IsNullOrEmpty(lblProductName.Value.Trim())))
                {
                    base.ShowMessage("申请类型为换货，必须输入换货商品信息！");
                    return;
                }
            }

            string ApplicationNo = this.ApplicationNo.Value.Trim();//申请单号
            string txtOrderCode = this.txtOrderCode.Value.Trim();//退货订单号
            int PlatformTypeId = int.Parse(this.ddlPlatform.SelectedValue);//平台
            int NickId = int.Parse(this.txtHidden1.Value);//店铺
            decimal Amount = decimal.Parse(this.Amount.Value.Trim());//金额
            string ReservepriceOrder = this.ReservepriceOrder2.Value.Trim();//补价订单
            DateTime ReturnTime;
            //if (this.ReturnTime.Value != "")
            //{
            //    ReturnTime = DateTime.Parse(this.ReturnTime.Value);//退货入仓时间
            //}
            string LeaderComments = this.LeaderComments.Text.Trim();//备注
            var a = XMOrderInfoService.GetXMOrderInfoByOrderCode(txtOrderCode);

            if (a == null || PlatformTypeId == 0 || NickId == 0)
            {
                base.ShowMessage("请先确认该退货订单号是否存在.");
                return;
            }
            else
            {
                var scd = 0;
                if (type == 2 && scid != 0)
                {
                    scd = scid;
                }
                var c = XMApplicationService.GetXMApplicationListByOrderCode(txtOrderCode).Where(p => p.ID != scid);
                decimal tuikuan = 0;
                decimal bujia = 0;
                foreach (var list in c)
                {
                    tuikuan = tuikuan + decimal.Parse(list.Amount.ToString());
                    if (list.ReservepriceOrder != null)
                    {
                        var bu = XMOrderInfoService.GetXMOrderInfoByOrderCode(list.ReservepriceOrder);
                        if (bu != null)
                        {
                            if (bu.PayPrice != null)
                            {
                                bujia = bujia + decimal.Parse(bu.PayPrice.ToString());
                            }
                        }
                    }
                }
                if ((a.PayPrice + bujia) < (Amount + tuikuan))
                {
                    base.ShowMessage("退款金额不能大于该订单的付款金额.");
                    return;
                }
            }
            if (ReservepriceOrder != "")
            {
                var b = XMOrderInfoService.GetXMOrderInfoByOrderCode(ReservepriceOrder);
                if (b == null)
                {
                    base.ShowMessage("请先确认该补价订单号是否存在.");
                    return;
                }
            }
            //事务
            using (TransactionScope scope = new TransactionScope())
            {
                if (type == 1 && a != null)
                {
                    XMApplication XMApplication = new XMApplication();
                    XMApplication.OrderCode = txtOrderCode;//退货订单号
                    XMApplication.ApplicationNo = ApplicationNo;//申请单号
                    XMApplication.ApplicationType = ApplicaType;//申请类型
                    XMApplication.PlatformTypeId = PlatformTypeId;//平台id
                    XMApplication.NickId = NickId;//店铺id
                    XMApplication.Amount = Amount;//金额
                    XMApplication.ReservepriceOrder = ReservepriceOrder;//补价订单
                    //if (this.ReturnTime.Value != "")
                    //{
                    //    ReturnTime = DateTime.Parse(this.ReturnTime.Value);//退货入仓时间
                    //    XMApplication.ReturnTime = ReturnTime;//退货入仓时间
                    //}
                    XMApplication.Remarks = LeaderComments;//备注
                    XMApplication.IsSend = false;//是否已推送千胜系统
                    XMApplication.SupervisorStatus = false;//主管审核状态
                    XMApplication.FinancialStatus = false;//财务审核状态
                    XMApplication.CreateID = HozestERPContext.Current.User.CustomerID;//创建人
                    XMApplication.CreateDate = DateTime.Now;//创建时间
                    XMApplication.UpdateID = HozestERPContext.Current.User.CustomerID;//更新人
                    XMApplication.UpdateDate = DateTime.Now;//更新时间
                    XMApplication.IsEnable = false;//是否删除
                    base.XMApplicationService.InsertXMApplication(XMApplication);
                    base.ShowMessage("保存成功");
                   // this.Button1.Visible = true;
                    Session["a"] = XMApplication.ID;
                    var OrderProductDetails = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(int.Parse(this.ApplicationNo.Value.Substring(6, 9)), 1, 3, 5);
                    var OrderProductDetails2 = base.XMApplicationExchangeService.GetXMApplicationExchangeByAppID(int.Parse(this.ApplicationNo.Value.Substring(6, 9)), 0, 0, 4);
                    if (OrderProductDetails != null)
                    {
                        foreach (var list in OrderProductDetails)
                        {
                            list.ApplicationId = XMApplication.ID;
                            base.XMApplicationExchangeService.UpdateXMApplicationExchange(list);
                        }
                    }
                    if (OrderProductDetails2 != null)
                    {
                        foreach (var list in OrderProductDetails2)
                        {
                            list.ApplicationId = XMApplication.ID;
                            base.XMApplicationExchangeService.UpdateXMApplicationExchange(list);
                        }
                    }

                    //foreach (GridViewRow list in GridView1.Rows)
                    //{
                    //    HtmlInputText lblManufacturers = list.FindControl("lblManufacturers3") as HtmlInputText;
                    //    HtmlInputControl lblProductName = list.FindControl("lblProductName3") as HtmlInputControl;
                    //    HtmlInputControl lblSpecifications = list.FindControl("lblSpecifications3") as HtmlInputControl;
                    //    TextBox txtcount = list.FindControl("txtcount") as TextBox;
                    //    HtmlInputText txtProductNum = list.FindControl("txtProductNum3") as HtmlInputText;
                    //    TextBox lblFactoryPrice = list.FindControl("lblFactoryPrice3") as TextBox;
                    //    TextBox txtSalesPrice = list.FindControl("txtSalesPrice3") as TextBox;
                    //    HiddenField Ids = list.FindControl("Ids") as HiddenField;
                    //    XMApplicationExchange orderproduct = new XMApplicationExchange();
                    //    orderproduct.ApplicationId = XMApplication.ID;
                    //    orderproduct.PlatformMerchantCode = lblManufacturers.Value;
                    //    orderproduct.ProductName = lblProductName.Value;
                    //    orderproduct.Specifications = lblSpecifications.Value;
                    //    int returnCount = int.Parse(txtcount.Text.Trim());            //退换货数量
                    //    orderproduct.ProductNum = returnCount;
                    //    if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                    //    {
                    //        orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                    //    }
                    //    else
                    //    {
                    //        orderproduct.FactoryPrice = 0;
                    //    }
                    //    if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                    //    {
                    //        orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                    //    }
                    //    else
                    //    {
                    //        orderproduct.SalesPrice = 0;
                    //    }
                    //    orderproduct.IsOderDetails = int.Parse(Ids.Value);
                    //    orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                    //    orderproduct.CreateDate = DateTime.Now;
                    //    orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                    //    orderproduct.UpdateDate = DateTime.Now;
                    //    orderproduct.IsApplication = 2;//1为新增类型

                    //    base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);

                    //}
                    foreach (GridViewRow list in GridView3.Rows)
                    {
                        HtmlInputText lblManufacturers = list.FindControl("lblManufacturers") as HtmlInputText;
                        HtmlInputControl lblProductName = list.FindControl("lblProductName") as HtmlInputControl;
                        HtmlInputControl lblSpecifications = list.FindControl("lblSpecifications") as HtmlInputControl;
                        TextBox txtcount = list.FindControl("txtcount") as TextBox;
                        HtmlInputText txtProductNum = list.FindControl("txtProductNum") as HtmlInputText;
                        TextBox lblFactoryPrice = list.FindControl("lblFactoryPrice") as TextBox;
                        TextBox txtSalesPrice = list.FindControl("txtSalesPrice") as TextBox;
                        HiddenField Ids = list.FindControl("Ids") as HiddenField;
                        XMApplicationExchange orderproduct = new XMApplicationExchange();
                        orderproduct.ApplicationId = XMApplication.ID;
                        orderproduct.PlatformMerchantCode = lblManufacturers.Value;
                        orderproduct.ProductName = lblProductName.Value;
                        orderproduct.Specifications = lblSpecifications.Value;
                        int returnCount = int.Parse(txtcount.Text.Trim());            //退换货数量
                        orderproduct.ProductNum = returnCount;
                        if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                        {
                            orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                        }
                        else
                        {
                            orderproduct.FactoryPrice = 0;
                        }
                        if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                        {
                            orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                        }
                        else
                        {
                            orderproduct.SalesPrice = 0;
                        }
                        orderproduct.IsNewOderDetails = int.Parse(Ids.Value);
                        orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                        orderproduct.CreateDate = DateTime.Now;
                        orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                        orderproduct.UpdateDate = DateTime.Now;
                        orderproduct.IsApplication = 2;//1为新增类型

                        base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);

                    }
                    foreach (GridViewRow list in GridView4.Rows)
                    {
                        HtmlInputControl lblProductName = list.FindControl("lblProductName") as HtmlInputControl;
                        TextBox txtcount = list.FindControl("txtcount") as TextBox;
                        HtmlInputText txtProductNum = list.FindControl("txtProductNum") as HtmlInputText;
                        TextBox lblFactoryPrice = list.FindControl("lblFactoryPrice") as TextBox;
                        TextBox txtSalesPrice = list.FindControl("txtSalesPrice") as TextBox;
                        HiddenField Ids = list.FindControl("Ids") as HiddenField;
                        string productName = lblProductName.Value;
                        if (!string.IsNullOrEmpty(productName))
                        {
                            XMApplicationExchange orderproduct = new XMApplicationExchange();
                            orderproduct.ApplicationId = XMApplication.ID;
                            orderproduct.ProductName = lblProductName.Value;
                            int returnCount = int.Parse(txtcount.Text.Trim());            //退换货数量
                            orderproduct.ProductNum = returnCount;
                            if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                            {
                                orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                            }
                            else
                            {
                                orderproduct.FactoryPrice = 0;
                            }
                            if (returnCount != 0 && !string.IsNullOrEmpty(txtSalesPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value.ToString()) && txtProductNum.Value.ToString() != "0")
                            {
                                orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                            }
                            else
                            {
                                orderproduct.SalesPrice = 0;
                            }
                            orderproduct.IsNewOderDetails = int.Parse(Ids.Value);
                            orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.CreateDate = DateTime.Now;
                            orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.UpdateDate = DateTime.Now;
                            orderproduct.IsApplication = 4;//1为新增类型

                            //base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                        }

                    }
                    //BindGrid();
                    //this.btnSave.Visible = false;
                    ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);


                }
                else if (type == 2 && a != null)
                {
                    var XMApplication = XMApplicationService.GetXMApplicationByID(scid);
                    XMApplication.OrderCode = txtOrderCode;//退货订单号
                    XMApplication.ApplicationType = ApplicaType;//申请类型
                    XMApplication.PlatformTypeId = PlatformTypeId;//平台id
                    XMApplication.NickId = NickId;//店铺id
                    XMApplication.Amount = Amount;//金额
                    XMApplication.ReservepriceOrder = ReservepriceOrder;//补价订单
                    //if (this.ReturnTime.Value != "")
                    //{
                    //    ReturnTime = DateTime.Parse(this.ReturnTime.Value);//退货入仓时间
                    //    XMApplication.ReturnTime = ReturnTime;//退货入仓时间
                    //}
                    XMApplication.Remarks = LeaderComments;//备注
                    XMApplication.UpdateID = HozestERPContext.Current.User.CustomerID;//更新人
                    XMApplication.UpdateDate = DateTime.Now;//更新时间
                    XMApplication.IsEnable = false;//是否删除
                    base.XMApplicationService.UpdateXMApplication(XMApplication);
                    base.ShowMessage("修改成功");
                    //foreach (GridViewRow list in GridView1.Rows)
                    //{
                    //    HtmlInputText lblManufacturers = list.FindControl("lblManufacturers2") as HtmlInputText;
                    //    HtmlInputControl lblProductName = list.FindControl("lblProductName2") as HtmlInputControl;
                    //    HtmlInputControl lblSpecifications = list.FindControl("lblSpecifications2") as HtmlInputControl;
                    //    TextBox txtcount = list.FindControl("txtcount") as TextBox;
                    //    HtmlInputText txtProductNum = list.FindControl("txtProductNum2") as HtmlInputText;
                    //    TextBox lblFactoryPrice = list.FindControl("lblFactoryPrice2") as TextBox;
                    //    TextBox txtSalesPrice = list.FindControl("txtSalesPrice2") as TextBox;
                    //    HiddenField Ids = list.FindControl("Ids") as HiddenField;

                    //    var db = base.XMApplicationExchangeService.GetXMApplicationExchangeByIsOrID(int.Parse(Ids.Value), this.scid, 2);
                    //    if (db != null)
                    //    {
                    //        int returnCount = int.Parse(txtcount.Text.Trim());
                    //        db.ProductNum = returnCount;
                    //        if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                    //        {
                    //            db.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                    //        }
                    //        else
                    //        {
                    //            db.FactoryPrice = 0;
                    //        }
                    //        if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                    //        {
                    //            db.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                    //        }
                    //        else
                    //        {
                    //            db.SalesPrice = 0;
                    //        }
                    //        db.UpdateID = HozestERPContext.Current.User.CustomerID;
                    //        db.UpdateDate = DateTime.Now;
                    //        db.PlatformMerchantCode = lblManufacturers.Value;
                    //        db.ProductName = lblProductName.Value;
                    //        db.Specifications = lblSpecifications.Value;
                    //        db.ProductNum = returnCount;

                    //        base.XMApplicationExchangeService.UpdateXMApplicationExchange(db);

                    //    }
                    //    else
                    //    {

                    //        XMApplicationExchange orderproduct = new XMApplicationExchange();
                    //        orderproduct.ApplicationId = XMApplication.ID;
                    //        orderproduct.PlatformMerchantCode = lblManufacturers.Value;
                    //        orderproduct.ProductName = lblProductName.Value;
                    //        orderproduct.Specifications = lblSpecifications.Value;
                    //        int returnCount = int.Parse(txtcount.Text.Trim());
                    //        orderproduct.ProductNum = returnCount;
                    //        if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                    //        {
                    //            orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                    //        }
                    //        else
                    //        {
                    //            orderproduct.FactoryPrice = 0;
                    //        }
                    //        if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                    //        {
                    //            orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                    //        }
                    //        else
                    //        {
                    //            orderproduct.SalesPrice = 0;
                    //        }
                    //        orderproduct.IsOderDetails = int.Parse(Ids.Value);
                    //        orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                    //        orderproduct.CreateDate = DateTime.Now;
                    //        orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                    //        orderproduct.UpdateDate = DateTime.Now;
                    //        orderproduct.IsApplication = 2;//1为新增类型

                    //        base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                    //    }

                    //}
                    //foreach (GridViewRow list in GridView6.Rows)
                    //{
                    //    HtmlInputText lblManufacturers = list.FindControl("lblManufacturers2") as HtmlInputText;
                    //    HtmlInputControl lblProductName = list.FindControl("lblProductName2") as HtmlInputControl;
                    //    HtmlInputControl lblSpecifications = list.FindControl("lblSpecifications2") as HtmlInputControl;
                    //    TextBox txtcount = list.FindControl("txtcount") as TextBox;
                    //    HtmlInputText txtProductNum = list.FindControl("txtProductNum2") as HtmlInputText;
                    //    TextBox lblFactoryPrice = list.FindControl("lblFactoryPrice2") as TextBox;
                    //    TextBox txtSalesPrice = list.FindControl("txtSalesPrice2") as TextBox;
                    //    HiddenField Ids = list.FindControl("Ids") as HiddenField;

                    //    var db = base.XMApplicationExchangeService.GetXMApplicationExchangeByIsOrID(int.Parse(Ids.Value), this.scid, 2);
                    //    if (db != null)
                    //    {
                    //        int returnCount = int.Parse(txtcount.Text.Trim());
                    //        db.ProductNum = returnCount;
                    //        if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                    //        {
                    //            db.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                    //        }
                    //        else
                    //        {
                    //            db.FactoryPrice = 0;
                    //        }
                    //        if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                    //        {
                    //            db.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                    //        }
                    //        else
                    //        {
                    //            db.SalesPrice = 0;
                    //        }
                    //        db.UpdateID = HozestERPContext.Current.User.CustomerID;
                    //        db.UpdateDate = DateTime.Now;
                    //        db.PlatformMerchantCode = lblManufacturers.Value;
                    //        db.ProductName = lblProductName.Value;
                    //        db.Specifications = lblSpecifications.Value;
                    //        db.ProductNum = returnCount;

                    //        base.XMApplicationExchangeService.UpdateXMApplicationExchange(db);

                    //    }
                    //    else
                    //    {

                    //        XMApplicationExchange orderproduct = new XMApplicationExchange();
                    //        orderproduct.ApplicationId = XMApplication.ID;
                    //        orderproduct.PlatformMerchantCode = lblManufacturers.Value;
                    //        orderproduct.ProductName = lblProductName.Value;
                    //        orderproduct.Specifications = lblSpecifications.Value;
                    //        int returnCount = int.Parse(txtcount.Text.Trim());
                    //        orderproduct.ProductNum = returnCount;
                    //        if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                    //        {
                    //            orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                    //        }
                    //        else
                    //        {
                    //            orderproduct.FactoryPrice = 0;
                    //        }
                    //        if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                    //        {
                    //            orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                    //        }
                    //        else
                    //        {
                    //            orderproduct.SalesPrice = 0;
                    //        }
                    //        orderproduct.IsOderDetails = int.Parse(Ids.Value);
                    //        orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                    //        orderproduct.CreateDate = DateTime.Now;
                    //        orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                    //        orderproduct.UpdateDate = DateTime.Now;
                    //        orderproduct.IsApplication = 2;//1为新增类型

                    //        base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                    //    }

                    //}
                    foreach (GridViewRow list in GridView4.Rows)
                    {
                        HtmlInputControl lblProductName = list.FindControl("lblProductName") as HtmlInputControl;
                        TextBox txtcount = list.FindControl("txtcount") as TextBox;
                        HtmlInputText txtProductNum = list.FindControl("txtProductNum") as HtmlInputText;
                        TextBox lblFactoryPrice = list.FindControl("lblFactoryPrice") as TextBox;
                        TextBox txtSalesPrice = list.FindControl("txtSalesPrice") as TextBox;
                        HiddenField Ids = list.FindControl("Ids") as HiddenField;
                        string productName = lblProductName.Value;
                        var db = base.XMApplicationExchangeService.GetXMApplicationExchangeByIsNewOrID(int.Parse(Ids.Value), this.scid, 4);
                        if (db != null)
                        {
                            int returnCount = int.Parse(txtcount.Text.Trim());
                            db.ProductNum = returnCount;
                            if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                            {
                                db.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                            }
                            else
                            {
                                db.FactoryPrice = 0;
                            }
                            if (returnCount != 0 && !string.IsNullOrEmpty(txtSalesPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                            {
                                db.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                            }
                            else
                            {
                                db.SalesPrice = 0;
                            }
                            db.UpdateID = HozestERPContext.Current.User.CustomerID;
                            db.UpdateDate = DateTime.Now;

                            base.XMApplicationExchangeService.UpdateXMApplicationExchange(db);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(productName))
                            {
                                XMApplicationExchange orderproduct = new XMApplicationExchange();
                                orderproduct.ApplicationId = XMApplication.ID;
                                orderproduct.ProductName = lblProductName.Value;
                                int returnCount = int.Parse(txtcount.Text.Trim());
                                orderproduct.ProductNum = returnCount;
                                if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                                {
                                    orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                                }
                                else
                                {
                                    orderproduct.FactoryPrice = 0;
                                }
                                if (returnCount != 0 && !string.IsNullOrEmpty(txtSalesPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                                {
                                    orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                                }
                                else
                                {
                                    orderproduct.SalesPrice = 0;
                                }
                                orderproduct.IsNewOderDetails = int.Parse(Ids.Value);
                                orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                                orderproduct.CreateDate = DateTime.Now;
                                orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                                orderproduct.UpdateDate = DateTime.Now;
                                orderproduct.IsApplication = 4;//1为新增类型

                                base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                            }

                        }
                        //if (txtcount.Text.Trim() != "0")
                        //{
                        //    XMApplicationExchange orderproduct = new XMApplicationExchange();
                        //    orderproduct.ApplicationId = XMApplication.ID;
                        //    orderproduct.ProductName = lblProductName.Value;
                        //    orderproduct.ProductNum = int.Parse(txtcount.Text.Trim());
                        //    orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                        //    orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                        //    orderproduct.IsNewOderDetails = int.Parse(Ids.Value);
                        //    orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                        //    orderproduct.CreateDate = DateTime.Now;
                        //    orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                        //    orderproduct.UpdateDate = DateTime.Now;
                        //    orderproduct.IsApplication = 4;//1为新增类型

                        //    base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                        //}
                    }
                    foreach (GridViewRow list in GridView3.Rows)
                    {
                        HtmlInputText lblManufacturers = list.FindControl("lblManufacturers") as HtmlInputText;
                        HtmlInputControl lblProductName = list.FindControl("lblProductName") as HtmlInputControl;
                        HtmlInputControl lblSpecifications = list.FindControl("lblSpecifications") as HtmlInputControl;
                        TextBox txtcount = list.FindControl("txtcount") as TextBox;
                        HtmlInputText txtProductNum = list.FindControl("txtProductNum") as HtmlInputText;
                        TextBox lblFactoryPrice = list.FindControl("lblFactoryPrice") as TextBox;
                        TextBox txtSalesPrice = list.FindControl("txtSalesPrice") as TextBox;
                        HiddenField Ids = list.FindControl("Ids") as HiddenField;

                        var db = base.XMApplicationExchangeService.GetXMApplicationExchangeByIsNewOrID(int.Parse(Ids.Value), this.scid, 2);
                        if (db != null)
                        {
                            int returnCount = int.Parse(txtcount.Text.Trim()); ;
                            db.ProductNum = returnCount;
                            if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                            {
                                db.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                            }
                            else
                            {
                                db.FactoryPrice = 0;
                            }
                            if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                            {
                                db.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                            }
                            else
                            {
                                db.SalesPrice = 0;
                            }
                            db.UpdateID = HozestERPContext.Current.User.CustomerID;
                            db.UpdateDate = DateTime.Now;

                            base.XMApplicationExchangeService.UpdateXMApplicationExchange(db);
                        }
                        else
                        {

                            XMApplicationExchange orderproduct = new XMApplicationExchange();
                            orderproduct.ApplicationId = XMApplication.ID;
                            orderproduct.PlatformMerchantCode = lblManufacturers.Value;
                            orderproduct.ProductName = lblProductName.Value;
                            orderproduct.Specifications = lblSpecifications.Value;
                            int returnCount = int.Parse(txtcount.Text.Trim());
                            orderproduct.ProductNum = returnCount;
                            if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                            {
                                orderproduct.FactoryPrice = decimal.Parse(lblFactoryPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                            }
                            else
                            {
                                orderproduct.FactoryPrice = 0;
                            }
                            if (returnCount != 0 && !string.IsNullOrEmpty(lblFactoryPrice.Text.Trim()) && !string.IsNullOrEmpty(txtProductNum.Value) && txtProductNum.Value.ToString() != "0")
                            {
                                orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim()) / decimal.Parse(txtProductNum.Value.ToString()) * decimal.Parse(txtcount.Text.ToString());
                            }
                            else
                            {
                                orderproduct.SalesPrice = 0;
                            }
                            orderproduct.IsNewOderDetails = int.Parse(Ids.Value);
                            orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.CreateDate = DateTime.Now;
                            orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                            orderproduct.UpdateDate = DateTime.Now;
                            orderproduct.IsApplication = 2;//1为新增类型

                            base.XMApplicationExchangeService.InsertXMApplicationExchange(orderproduct);
                        }

                    }

                    //BindGrid();
                    ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMApplicationAdd", "autoCompleteBind()", true);
                }
                scope.Complete();

            }
        }

        /// <summary>
        /// 修改添加进退货申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveAllData();
        }

        /// <summary>
        /// 修改添加进退货申请入仓时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave2_Click(object sender, EventArgs e)
        {
            SaveAllData();
            DateTime ReturnTime;
            //if (this.ReturnTime.Value != "")
            //{
            //    ReturnTime = DateTime.Parse(this.ReturnTime.Value);//退货入仓时间
            //}
            if (type == 2)
            {
                var XMApplication = XMApplicationService.GetXMApplicationByID(scid);
                //if (this.ReturnTime.Value != "")
                //{
                //    ReturnTime = DateTime.Parse(this.ReturnTime.Value);//退货入仓时间
                //    XMApplication.ReturnTime = ReturnTime;//退货入仓时间
                //}
                XMApplication.UpdateID = HozestERPContext.Current.User.CustomerID;//更新人
                XMApplication.UpdateDate = DateTime.Now;//更新时间
                XMApplication.IsEnable = false;//是否删除
                base.XMApplicationService.UpdateXMApplication(XMApplication);
                base.ShowMessage("修改成功");
            }
        }

        /// <summary>
        /// 修改退回物流单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReturnLogisticsNumber_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            string ReturnLogisticsNumber = this.txtReturnLogisticsNumber.Text.Trim();
            var Info = XMApplicationService.GetXMApplicationByID(scid);
            if (Info != null)
            {
                Info.ReturnLogisticsNumber = ReturnLogisticsNumber;
                Info.UpdateDate = DateTime.Now;
                Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                base.XMApplicationService.UpdateXMApplication(Info);

                Ext.Net.ExtNet.Msg.Alert("提示", "客户退回物流单号修改成功！").Show();
                //base.ShowMessage("客户退回物流单号修改成功！");
            }
            else
            {
                Ext.Net.ExtNet.Msg.Alert("提示", "退换货记录已不存在！").Show();
                //base.ShowMessage("退换货记录已不存在！");
            }
        }

        protected void ddTheAdvanceType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 刷单暂支
        /// </summary>
        public void TheAdvanceTypeSDZZ()
        {
        }

        /// <summary>
        /// 退换货id
        /// </summary>
        public int scid
        {
            get
            {
                return CommonHelper.QueryStringInt("scid");
            }
        }

        /// <summary>
        /// 判断退换货是添加还是修改
        /// </summary>
        public int type
        {
            get
            {
                return CommonHelper.QueryStringInt("type");
            }
        }

        /// <summary>
        /// 获取要生成的订单id
        /// </summary>
        public string orderid
        {
            get
            {
                return CommonHelper.QueryString("orderid");
            }
        }
    }

}