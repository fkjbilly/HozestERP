using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageProject;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using HozestERP.BusinessLogic;
using JdSdk.Domain;
using Top.Api.Domain;
using System.Transactions;

namespace HozestERP.Web.ManageProject
{

    public partial class XMPremiumsDetailsManage : BaseAdministrationPage, IEditPage
    {
        /// <summary>
        /// 按钮 权限控制
        /// </summary>
        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                //buttons.Add("imgBtnEdit", "ManageProject.XMPremiumsDetailsManage.Edit"); //明细编辑
                //buttons.Add("imgBtnDelete", "ManageProject.XMPremiumsDetailsManage.Delete"); //明细删除
                //buttons.Add("imgBtnUpdate", "ManageProject.XMPremiumsDetailsManage.Save"); //明细保存
                //buttons.Add("imgBtnCancel", "ManageProject.XMPremiumsDetailsManage.Cancel"); //明细取消

                return buttons;
            }
        }

        //主表信息
        public XMPremiums PXMPremiums;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        public void loadDate()
        {
            if (this.PremiumsId > 0)
            {
                PXMPremiums = base.XMPremiumsService.GetXMPremiumsById(this.PremiumsId);

                if (PXMPremiums != null)
                {
                    this.lblOrderCode.Text = PXMPremiums.OrderCode;
                    this.lblWantId.Text = PXMPremiums.WantId;
                }
            }

            BindGrid();
        }

        /// <summary>
        /// 从表
        /// </summary> 
        public void BindGrid()
        {
            //刷单申请明细信息

            List<XMPremiumsDetails> XMPremiumsDetailsList = new List<XMPremiumsDetails>();

            if (this.PremiumsId > 0)
            {
                XMPremiumsDetailsList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(this.PremiumsId);
                PXMPremiums = base.XMPremiumsService.GetXMPremiumsById(this.PremiumsId);
            }
            //运营审核通过的赠品申请单 赠品明细不允许新增、修改、删除
            //if (PXMPremiums.ManagerStatus!=null)
            //{
            //    if (PXMPremiums.ManagerStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCheck))|| PXMPremiums.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass)
            //    {
            //        this.grdPremiumsDetailsManage.EditIndex = this.RowEditIndex;
            //    }
            //    else {
            //        if (this.RowEditIndex == -1)
            //        {
            //            this.grdPremiumsDetailsManage.EditIndex = XMPremiumsDetailsList.Count();
            //            XMPremiumsDetailsList.Add(new XMPremiumsDetails()); //新增编辑行
            //        }
            //        else
            //        {
            //            this.grdPremiumsDetailsManage.EditIndex = this.RowEditIndex;
            //        } 
            //    }
            //}
            //else
            //{
            //    if (this.RowEditIndex == -1)
            //    {
            //        this.grdPremiumsDetailsManage.EditIndex = XMPremiumsDetailsList.Count();
            //        XMPremiumsDetailsList.Add(new XMPremiumsDetails()); //新增编辑行
            //    }
            //    else
            //    {
            //        this.grdPremiumsDetailsManage.EditIndex = this.RowEditIndex;
            //    }

            //}

            if (this.RowEditIndex == -1)
            {
                this.grdPremiumsDetailsManage.EditIndex = XMPremiumsDetailsList.Count();
                //XMPremiumsDetailsList.Add(new XMPremiumsDetails()); //新增编辑行
            }
            else
            {
                this.grdPremiumsDetailsManage.EditIndex = this.RowEditIndex;
            }

            this.grdPremiumsDetailsManage.DataSource = XMPremiumsDetailsList;
            this.grdPremiumsDetailsManage.DataBind();
        }


        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitleTabPanelVisible = false;

        }

        public void SetTrigger()
        {
        }

        #endregion

        public int RowEditIndex
        {
            get
            {
                int editIndex = -1;
                try
                {
                    int.TryParse(ViewState["RowEditIndex"].ToString(), out editIndex);
                }
                catch
                {
                }
                return editIndex;
            }
            set
            {
                ViewState["RowEditIndex"] = value;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void grdPremiumsDetailsManage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var premiumsDetails = e.Row.DataItem as XMPremiumsDetails;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (premiumsDetails.ProductDetaislId != null)
                {
                    var product = base.XMProductService.GetXMProductById(premiumsDetails.ProductDetaislId.Value);
                    if (product != null)
                    {
                        //尺寸
                        //TextBox txtSpecifications = e.Row.FindControl("txtSpecifications") as TextBox;
                        Label lblSpecifications = e.Row.FindControl("lblSpecifications") as Label;
                        if (lblSpecifications != null)
                        {
                            lblSpecifications.Text = product.Specifications;
                        }
                    }
                }


                ////编辑按钮
                //ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ////删除按钮
                //ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;

                ////财务审核通过 不显示编辑按钮、删除按钮

                //if (PXMPremiums.ManagerStatus != null)
                //{
                //    if (PXMPremiums.ManagerStatus.Value == Convert.ToInt32(StatusEnum.AlreadyCheck) || PXMPremiums.ManagerStatus.Value == Convert.ToInt32(StatusEnum.DidNotPass))
                //    {
                //        if (imgBtnEdit != null && imgBtnDelete != null)
                //        {
                //            imgBtnEdit.Visible = false;
                //            imgBtnDelete.Visible = false;
                //        }
                //    }
                //    else
                //    {
                //        if (imgBtnEdit != null && imgBtnDelete != null)
                //        {
                //            imgBtnEdit.Visible = true;
                //            imgBtnDelete.Visible = true;
                //        }
                //    }
                //}
                //else
                //{
                //    if (imgBtnEdit != null && imgBtnDelete != null)
                //    {
                //        imgBtnEdit.Visible = false;
                //        imgBtnDelete.Visible = false;
                //    }
                //}
            }


            if (e.Row.RowState == DataControlRowState.Edit ||
                         (e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit)))
            {
                //SimpleTextBox txtProductNum = e.Row.FindControl("txtProductNum") as SimpleTextBox;
                //if (txtProductNum != null)
                //{
                //    if (txtProductNum.Text == "")
                //    {
                //        txtProductNum.Text = "1";
                //    }
                //}

            }
        }

        protected void grdPremiumsDetailsManage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.RowEditIndex = e.NewEditIndex;
            BindGrid();
            int Id = 0;
            int.TryParse(this.grdPremiumsDetailsManage.DataKeys[e.NewEditIndex].Value.ToString(), out Id);
            var row = this.grdPremiumsDetailsManage.Rows[e.NewEditIndex];
            var premiumsDetails = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(Id);
            if (premiumsDetails != null)
            {
                //商品Id
                HtmlInputHidden hfProductId = (HtmlInputHidden)row.FindControl("hfProductId");
                if (hfProductId != null)
                {
                    hfProductId.Value = premiumsDetails.ProductDetaislId != null ? premiumsDetails.ProductDetaislId.Value.ToString() : "-1";
                }

                //尺寸
                TextBox txtEditSpecifications = (TextBox)row.FindControl("txtEditSpecifications");

                if (premiumsDetails.ProductDetaislId != null)
                {
                    var product = base.XMProductService.GetXMProductById(premiumsDetails.ProductDetaislId.Value);
                    if (product != null)
                    {
                        //尺寸 
                        if (txtEditSpecifications != null)
                        {
                            txtEditSpecifications.Text = product.Specifications;
                        }
                    }
                }

                DropDownList ddlShipper = (DropDownList)row.FindControl("ddlShipper");
                //找到DropDownList 控件，然后进行绑定或者追加内容
                var ShipperList = base.CodeService.GetCodeListInfoByCodeTypeID(226);
                ddlShipper.DataSource = ShipperList;
                ddlShipper.DataTextField = "CodeName";
                ddlShipper.DataValueField = "CodeID";
                ddlShipper.DataBind();
                ddlShipper.SelectedValue = premiumsDetails.Shipper == null ? "" : premiumsDetails.Shipper.ToString();//发货方
            }


            //    ScriptManager.RegisterStartupScript(this.grdPremiumsDetailsManage, this.Page.GetType(), "xmpremiumsDetails", "autoCompleteBind()", true);

        }

        protected void grdPremiumsDetailsManage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.RowEditIndex = -1;
            BindGrid();
            // ScriptManager.RegisterStartupScript(this.grdPremiumsDetailsManage, this.Page.GetType(), "xmpremiumsDetails", "autoCompleteBind()", true);
        }

        protected void grdPremiumsDetailsManage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            //商品Id
            var hfProductId = this.grdPremiumsDetailsManage.Rows[e.RowIndex].FindControl("hfProductId") as HtmlInputHidden;
            //商品名称
            var txtProductName = this.grdPremiumsDetailsManage.Rows[e.RowIndex].FindControl("txtProductName") as TextBox;
            //商品编码
            var txtPlatformMerchantCode = this.grdPremiumsDetailsManage.Rows[e.RowIndex].FindControl("txtPlatformMerchantCode") as TextBox;
            //出厂价
            var txtFactoryPrice = this.grdPremiumsDetailsManage.Rows[e.RowIndex].FindControl("txtFactoryPrice") as TextBox;
            //数量
            var txtProductNum = this.grdPremiumsDetailsManage.Rows[e.RowIndex].FindControl("txtProductNum") as TextBox;
            //尺寸
            var txtEditSpecifications = this.grdPremiumsDetailsManage.Rows[e.RowIndex].FindControl("txtEditSpecifications") as TextBox;
            //发货方
            var ddlShipper = this.grdPremiumsDetailsManage.Rows[e.RowIndex].FindControl("ddlShipper") as DropDownList;

            //订单号
            string OrderCode = this.lblOrderCode.Text.Trim();

            //根据订单号查询 订单信息 
            var xmOrderInfoList = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(OrderCode);
            //物流信息
            string wlRemark = "";
            //赠品信息
            string zpRemark = "";
            //其他信息
            string qtRemark = "";
            //新的备注信息
            string NewRemark = "";
            //新的赠品信息
            string CustomerServiceRemark = "";

            int keyID = 0;
            int.TryParse(e.Keys[0].ToString(), out keyID);
            var premiumsDetails = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(keyID);
            if (premiumsDetails == null)
            {
                //#region 赠品明细新增
                //int productId = 0;
                //int.TryParse(hfProductId.Value, out productId);
                //var Product = base.XMProductService.GetXMProductById(productId);
                //if (Product == null)
                //{
                //    hfProductId.Value = "";
                //    txtProductName.Value = "";
                //    txtPlatformMerchantCode.Text = "";
                //    txtFactoryPrice.Text = "";
                //    txtEditSpecifications.Text = "";
                //    this.Master.ShowMessage("商品名称有误.");
                //    ScriptManager.RegisterStartupScript(this.grdPremiumsDetailsManage, this.Page.GetType(), "xmpremiumsDetails", "autoCompleteBind()", true);
                //    return;
                //}
                //premiumsDetails = new XMPremiumsDetails();
                //premiumsDetails.PremiumsId = this.PremiumsId;
                //premiumsDetails.ProductDetaislId = Convert.ToInt32(hfProductId.Value);
                //premiumsDetails.PlatformMerchantCode = txtPlatformMerchantCode.Text;
                //premiumsDetails.PrdouctName = txtProductName.Value;
                //premiumsDetails.FactoryPrice = Convert.ToDecimal(txtFactoryPrice.Text);
                //premiumsDetails.ProductNum = Convert.ToInt32(txtProductNum.Text);
                //premiumsDetails.IsEnable = false;
                //premiumsDetails.CreateID = HozestERPContext.Current.User.CustomerID;
                //premiumsDetails.CreateDate = DateTime.Now;
                //premiumsDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                //premiumsDetails.UpdateDate = DateTime.Now;
                //base.XMPremiumsDetailsService.InsertXMPremiumsDetails(premiumsDetails);

                //#endregion

                //#region 修改平台后台备注信息
                //if (xmOrderInfoList.Count > 0)
                //{
                //    var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();
                //    List<XMOrderInfoApp> xMorderInfoAppNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == xmOrderInfoList[0].PlatformTypeId && q.NickId == xmOrderInfoList[0].NickID).ToList();
                //    for (int i = 0; i < xMorderInfoAppNew.Count; i++)
                //    {
                //        #region  京东、京东闪购
                //        if (xMorderInfoAppNew[i].PlatformTypeId == 251 || xMorderInfoAppNew[i].PlatformTypeId == 309 || xMorderInfoAppNew[i].PlatformTypeId == 310)
                //        {

                //            VenderRemark VResult = new VenderRemark();
                //            string OrderRemark = "";//商家备注
                //            if (OrderCode != "")
                //            {
                //                #region 同步平台备注信息
                //                VResult = base.XMOrderInfoAPIService.GetOrderVenderRemark(OrderCode, xMorderInfoAppNew[i]);// base.ProjectService.GetOrderVenderRemark(OrderId);//,orderInfoApp
                //                if (VResult != null)
                //                {
                //                    OrderRemark = VResult.Remark;
                //                    XMOrderInfo orderInfo = xmOrderInfoList[0];
                //                    if (OrderRemark != "")
                //                    {
                //                        int wlI = OrderRemark.IndexOf("赠品");
                //                        if (wlI > -1)
                //                        {
                //                            wlRemark = OrderRemark.Substring(0, wlI);
                //                        }
                //                        string s = OrderRemark.Substring(OrderRemark.IndexOf("赠品") + 2).Trim();
                //                        int f = s.IndexOf("/");
                //                        if (f > -1)
                //                        {
                //                            zpRemark = s.Substring(0, f);
                //                        }
                //                        if (zpRemark != "")
                //                        {
                //                            物流字符长度+(赠品：)3+（/）1+赠品字符长度
                //                            int length = wlRemark.Length + 3 + 1 + zpRemark.Length;
                //                            qtRemark = OrderRemark.Substring(length).ToLower();

                //                        }
                //                    }
                //                }
                //                #endregion

                //                if (wlRemark != "" && qtRemark != "")
                //                {
                //                    base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(premiumsDetails);

                //                    根据主表id 查询明细数据
                //                    var premiumsDetailsList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(this.PremiumsId);

                //                    #region  赠品信息 累加
                //                    if (premiumsDetailsList.Count > 0)
                //                    {

                //                        for (int j = 0; j < premiumsDetailsList.Count; j++)
                //                        {
                //                            var product = base.XMProductService.GetXMProductById(premiumsDetailsList[j].ProductDetaislId.Value);
                //                            if (product != null)
                //                            {
                //                                CustomerServiceRemark += premiumsDetailsList[j].PrdouctName + "(" + product.Specifications + ")*" + premiumsDetailsList[j].ProductNum;
                //                            }
                //                            if (premiumsDetailsList.Count > 1 && j < premiumsDetailsList.Count - 1)
                //                            {

                //                                CustomerServiceRemark += "+";
                //                            }
                //                        }
                //                    }
                //                    #endregion

                //                    #region 修改主表赠品说明信息
                //                    var xmPremiums = base.XMPremiumsService.GetXMPremiumsById(this.PremiumsId);
                //                    if (xmPremiums != null)
                //                    {
                //                        xmPremiums.ActivityExplanation = CustomerServiceRemark;
                //                        xmPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                //                        xmPremiums.UpdateTime = DateTime.Now;
                //                        base.XMPremiumsService.UpdateXMPremiums(xmPremiums);
                //                    }
                //                    #endregion

                //                    从新拼接 备注信息
                //                    NewRemark = wlRemark + "赠品 " + CustomerServiceRemark + "/" + qtRemark;

                //                    #region 平台后台修改备注
                //                    if (NewRemark != "")
                //                    {
                //                        修改备注
                //                        var orderVenderRemark = base.XMOrderInfoAPIService.SetOrderVenderRemark(OrderCode, NewRemark, "", xMorderInfoAppNew[i]);
                //                        清空属性值  
                //                        物流信息
                //                        wlRemark = "";
                //                        赠品信息
                //                        zpRemark = "";
                //                        其他信息
                //                        qtRemark = "";
                //                        新的备注信息
                //                        NewRemark = "";
                //                        新的赠品信息
                //                        CustomerServiceRemark = "";
                //                    }

                //                    #endregion

                //                }

                //            }
                //        }
                //        #endregion
                //        #region  淘宝、淘宝集市店
                //        else if (xMorderInfoAppNew[i].PlatformTypeId == 250 || xMorderInfoAppNew[i].PlatformTypeId == 381)
                //        {

                //            int TMInsertCount = 0;
                //            int TMUpdateCount = 0;

                //            Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(OrderCode), xMorderInfoAppNew[i]);
                //            if (trade != null)
                //            {
                //                base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoAppNew[i]);

                //                if (TMUpdateCount > 0)
                //                {

                //                    #region 同步最新订单信息 并取备注信息

                //                    var xMOrderInfoTMNew = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(OrderCode);

                //                    if (xMOrderInfoTMNew.Count > 0)
                //                    {
                //                        if (xMOrderInfoTMNew[0].CustomerServiceRemark != "")
                //                        {
                //                            string OrderRemark = xMOrderInfoTMNew[0].CustomerServiceRemark;

                //                            int wlI = OrderRemark.IndexOf("赠品");
                //                            if (wlI > -1)
                //                            {
                //                                wlRemark = OrderRemark.Substring(0, wlI);
                //                            }
                //                            string s = OrderRemark.Substring(OrderRemark.IndexOf("赠品") + 2).Trim();
                //                            int f = s.IndexOf("/");
                //                            if (f > -1)
                //                            {
                //                                zpRemark = s.Substring(0, f);
                //                            }
                //                            if (zpRemark != "")
                //                            {
                //                                物流字符长度+(赠品：)3+（/）1+赠品字符长度
                //                                int length = wlRemark.Length + 3 + 1 + zpRemark.Length;
                //                                qtRemark = OrderRemark.Substring(length).ToLower();

                //                            }
                //                        }
                //                    }
                //                    #endregion

                //                    if (wlRemark != "" && qtRemark != "")
                //                    {
                //                        base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(premiumsDetails);
                //                        根据主表id 查询明细数据
                //                        var premiumsDetailsList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(this.PremiumsId);

                //                        #region  赠品信息 累加
                //                        if (premiumsDetailsList.Count > 0)
                //                        {
                //                            for (int j = 0; j < premiumsDetailsList.Count; j++)
                //                            {
                //                                var product = base.XMProductService.GetXMProductById(premiumsDetailsList[j].ProductDetaislId.Value);
                //                                if (product != null)
                //                                {
                //                                    CustomerServiceRemark += premiumsDetailsList[j].PrdouctName + "(" + product.Specifications + ")*" + premiumsDetailsList[j].ProductNum;
                //                                }
                //                                if (premiumsDetailsList.Count > 1 && j < premiumsDetailsList.Count - 1)
                //                                {

                //                                    CustomerServiceRemark += "+";
                //                                }
                //                            }
                //                        }
                //                        #endregion

                //                        #region 修改主表赠品说明信息
                //                        var xmPremiums = base.XMPremiumsService.GetXMPremiumsById(this.PremiumsId);
                //                        if (xmPremiums != null)
                //                        {
                //                            xmPremiums.ActivityExplanation = CustomerServiceRemark;
                //                            xmPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                //                            xmPremiums.UpdateTime = DateTime.Now;
                //                            base.XMPremiumsService.UpdateXMPremiums(xmPremiums);
                //                        }
                //                        #endregion

                //                        从新拼接 备注信息
                //                        NewRemark = wlRemark + "赠品 " + CustomerServiceRemark + "/" + qtRemark;

                //                        #region 平台后台修改备注
                //                        if (NewRemark != "")
                //                        {
                //                            修改备注
                //                            var tradeMemoUpdate = base.XMOrderInfoAPIService.ReturnTradeMemoUpdate(Convert.ToInt64(OrderCode), NewRemark, xMorderInfoAppNew[i]);
                //                            清空属性值  
                //                            物流信息
                //                            wlRemark = "";
                //                            赠品信息
                //                            zpRemark = "";
                //                            其他信息
                //                            qtRemark = "";
                //                            新的备注信息
                //                            NewRemark = "";
                //                            新的赠品信息
                //                            CustomerServiceRemark = "";
                //                        }

                //                        #endregion
                //                    }
                //                }
                //            }

                //        }
                //        #endregion
                //        #region 一号店
                //        else if (xMorderInfoAppNew[i].PlatformTypeId == 375)
                //        {
                //            int YHDInsertCount = 0;
                //            int YHDUpdateCount = 0; //返回更新的条数

                //            根据订单号获取一号店 订单信息
                //            base.XMOrderInfoAPIService.getOrderYHD(OrderCode, ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoAppNew[i]);

                //            if (YHDUpdateCount > 0)
                //            {

                //                #region 同步最新订单信息 并取备注信息

                //                var xMOrderInfoTMNew = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(OrderCode);

                //                if (xMOrderInfoTMNew.Count > 0)
                //                {
                //                    if (xMOrderInfoTMNew[0].CustomerServiceRemark != "")
                //                    {
                //                        string OrderRemark = xMOrderInfoTMNew[0].CustomerServiceRemark;

                //                        int wlI = OrderRemark.IndexOf("赠品");
                //                        if (wlI > -1)
                //                        {
                //                            wlRemark = OrderRemark.Substring(0, wlI);
                //                        }
                //                        string s = OrderRemark.Substring(OrderRemark.IndexOf("赠品") + 2).Trim();
                //                        int f = s.IndexOf("/");
                //                        if (f > -1)
                //                        {
                //                            zpRemark = s.Substring(0, f);
                //                        }
                //                        if (zpRemark != "")
                //                        {
                //                            物流字符长度+(赠品：)3+（/）1+赠品字符长度
                //                            int length = wlRemark.Length + 3 + 1 + zpRemark.Length;
                //                            qtRemark = OrderRemark.Substring(length).ToLower();

                //                        }
                //                    }
                //                }
                //                #endregion

                //                if (wlRemark != "" && qtRemark != "")
                //                {
                //                    base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(premiumsDetails);
                //                    根据主表id 查询明细数据
                //                    var premiumsDetailsList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(this.PremiumsId);

                //                    #region  赠品信息 累加
                //                    if (premiumsDetailsList.Count > 0)
                //                    {
                //                        for (int j = 0; j < premiumsDetailsList.Count; j++)
                //                        {
                //                            var product = base.XMProductService.GetXMProductById(premiumsDetailsList[j].ProductDetaislId.Value);
                //                            if (product != null)
                //                            {
                //                                CustomerServiceRemark += premiumsDetailsList[j].PrdouctName + "(" + product.Specifications + ")*" + premiumsDetailsList[j].ProductNum;
                //                            }
                //                            if (premiumsDetailsList.Count > 1 && j < premiumsDetailsList.Count - 1)
                //                            {

                //                                CustomerServiceRemark += "+";
                //                            }
                //                        }
                //                    }
                //                    #endregion

                //                    #region 修改主表赠品说明信息
                //                    var xmPremiums = base.XMPremiumsService.GetXMPremiumsById(this.PremiumsId);
                //                    if (xmPremiums != null)
                //                    {
                //                        xmPremiums.ActivityExplanation = CustomerServiceRemark;
                //                        xmPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                //                        xmPremiums.UpdateTime = DateTime.Now;
                //                        base.XMPremiumsService.UpdateXMPremiums(xmPremiums);
                //                    }
                //                    #endregion

                //                    从新拼接 备注信息
                //                    NewRemark = wlRemark + "赠品 " + CustomerServiceRemark + "/" + qtRemark;

                //                    #region 平台后台修改备注
                //                    if (NewRemark != "")
                //                    {
                //                        修改备注 
                //                         base.XMOrderInfoAPIService.OrderMerchantRemarkUpdate(OrderCode, NewRemark, xMorderInfoAppNew[i]);
                //                        清空属性值  
                //                        物流信息
                //                        wlRemark = "";
                //                        赠品信息
                //                        zpRemark = "";
                //                        其他信息
                //                        qtRemark = "";
                //                        新的备注信息
                //                        NewRemark = "";
                //                        新的赠品信息
                //                        CustomerServiceRemark = "";
                //                    }

                //                    #endregion
                //                }
                //            }
                //        }
                //        #endregion
                //        苏宁易购
                //        else if (xMorderInfoAppNew[i].PlatformTypeId == 383)
                //        {

                //        }
                //        唯品会
                //        else if (xMorderInfoAppNew[0].PlatformTypeId == 259)
                //        {


                //        }
                //    }
                //}
                //#endregion
            }
            else
            {

                int productId = 0;
                int.TryParse(hfProductId.Value, out productId);
                var Product = base.XMProductService.GetXMProductById(productId);
                if (Product == null)
                {
                    hfProductId.Value = "";
                    txtProductName.Text = "";
                    txtPlatformMerchantCode.Text = "";
                    txtFactoryPrice.Text = "";
                    txtEditSpecifications.Text = "";
                    this.Master.ShowMessage("商品名称有误.");
                    ScriptManager.RegisterStartupScript(this.grdPremiumsDetailsManage, this.Page.GetType(), "xmpremiumsDetails", "autoCompleteBind()", true);
                    return;
                }

                premiumsDetails.ProductDetaislId = Convert.ToInt32(hfProductId.Value);
                premiumsDetails.PlatformMerchantCode = txtPlatformMerchantCode.Text;
                premiumsDetails.PrdouctName = txtProductName.Text;
                premiumsDetails.FactoryPrice = Convert.ToDecimal(txtFactoryPrice.Text);
                premiumsDetails.ProductNum = Convert.ToInt32(txtProductNum.Text);
                premiumsDetails.Shipper = int.Parse(ddlShipper.SelectedValue.Trim());
                premiumsDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                premiumsDetails.UpdateDate = DateTime.Now;
                base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(premiumsDetails);

                Product.Specifications = txtEditSpecifications.Text;
                base.XMProductService.UpdateXMProduct(Product);

                #region 修改平台后台备注信息
                if (xmOrderInfoList.Count > 0)
                {
                    var XMOrderInfoAppList = base.XMOrderInfoAppService.GetXMOrderInfoAppList();
                    List<XMOrderInfoApp> xMorderInfoAppNew = XMOrderInfoAppList.Where(q => q.PlatformTypeId == xmOrderInfoList[0].PlatformTypeId && q.NickId == xmOrderInfoList[0].NickID).ToList();
                    for (int i = 0; i < xMorderInfoAppNew.Count; i++)
                    {
                        #region  京东、京东闪购
                        if (xMorderInfoAppNew[i].PlatformTypeId == 251 || xMorderInfoAppNew[i].PlatformTypeId == 309 || xMorderInfoAppNew[i].PlatformTypeId == 310)
                        {

                            VenderRemark VResult = new VenderRemark();
                            string OrderRemark = "";//商家备注
                            if (OrderCode != "")
                            {
                                #region 同步平台备注信息
                                VResult = base.XMOrderInfoAPIService.GetOrderVenderRemark(OrderCode, xMorderInfoAppNew[i]);// base.ProjectService.GetOrderVenderRemark(OrderId);//,orderInfoApp
                                if (VResult != null)
                                {
                                    OrderRemark = VResult.Remark;
                                    XMOrderInfo orderInfo = xmOrderInfoList[0];
                                    if (OrderRemark != "")
                                    {
                                        int wlI = OrderRemark.IndexOf("赠品");
                                        if (wlI > -1)
                                        {
                                            wlRemark = OrderRemark.Substring(0, wlI);
                                        }
                                        string s = OrderRemark.Substring(OrderRemark.IndexOf("赠品") + 2).Trim();
                                        int f = s.IndexOf("/");
                                        if (f > -1)
                                        {
                                            zpRemark = s.Substring(0, f);
                                        }
                                        if (zpRemark != "")
                                        {
                                            //物流字符长度+(赠品：)3+（/）1+赠品字符长度
                                            int length = wlRemark.Length + 3 + 1 + zpRemark.Length;
                                            qtRemark = OrderRemark.Substring(length).ToLower();

                                        }
                                    }
                                }
                                #endregion

                                if (wlRemark != "" && qtRemark != "")
                                {
                                    base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(premiumsDetails);

                                    //根据主表id 查询明细数据
                                    var premiumsDetailsList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(this.PremiumsId);

                                    #region  赠品信息 累加
                                    if (premiumsDetailsList.Count > 0)
                                    {

                                        for (int j = 0; j < premiumsDetailsList.Count; j++)
                                        {
                                            var product = base.XMProductService.GetXMProductById(premiumsDetailsList[j].ProductDetaislId.Value);
                                            if (product != null)
                                            {
                                                CustomerServiceRemark += premiumsDetailsList[j].PrdouctName + "(" + product.Specifications + ")*" + premiumsDetailsList[j].ProductNum;
                                            }
                                            if (premiumsDetailsList.Count > 1 && j < premiumsDetailsList.Count - 1)
                                            {

                                                CustomerServiceRemark += "+";
                                            }
                                        }
                                    }
                                    #endregion

                                    #region 修改主表赠品说明信息
                                    var xmPremiums = base.XMPremiumsService.GetXMPremiumsById(this.PremiumsId);
                                    if (xmPremiums != null)
                                    {
                                        xmPremiums.ActivityExplanation = CustomerServiceRemark;
                                        xmPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                        xmPremiums.UpdateTime = DateTime.Now;
                                        base.XMPremiumsService.UpdateXMPremiums(xmPremiums);
                                    }
                                    #endregion

                                    //从新拼接 备注信息
                                    NewRemark = wlRemark + "赠品 " + CustomerServiceRemark + "/" + qtRemark;

                                    #region 平台后台修改备注
                                    if (NewRemark != "")
                                    {
                                        //修改备注
                                        var orderVenderRemark = base.XMOrderInfoAPIService.SetOrderVenderRemark(OrderCode, NewRemark, "", xMorderInfoAppNew[i]);
                                        //清空属性值  
                                        //物流信息
                                        wlRemark = "";
                                        //赠品信息
                                        zpRemark = "";
                                        //其他信息
                                        qtRemark = "";
                                        //新的备注信息
                                        NewRemark = "";
                                        //新的赠品信息
                                        CustomerServiceRemark = "";
                                    }

                                    #endregion

                                }

                            }
                        }
                        #endregion
                        #region  淘宝、淘宝集市店
                        else if (xMorderInfoAppNew[i].PlatformTypeId == 250 || xMorderInfoAppNew[i].PlatformTypeId == 381)
                        {

                            int TMInsertCount = 0;
                            int TMUpdateCount = 0;

                            Trade trade = base.XMOrderInfoAPIService.GetTrade(Convert.ToInt64(OrderCode), xMorderInfoAppNew[i]);
                            if (trade != null)
                            {
                                base.XMOrderInfoAPIService.getTradeTM(trade, ref  TMInsertCount, ref  TMUpdateCount, xMorderInfoAppNew[i]);

                                if (TMUpdateCount > 0)
                                {

                                    #region 同步最新订单信息 并取备注信息

                                    var xMOrderInfoTMNew = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(OrderCode);

                                    if (xMOrderInfoTMNew.Count > 0)
                                    {
                                        if (xMOrderInfoTMNew[0].CustomerServiceRemark != "")
                                        {
                                            string OrderRemark = xMOrderInfoTMNew[0].CustomerServiceRemark;

                                            int wlI = OrderRemark.IndexOf("赠品");
                                            if (wlI > -1)
                                            {
                                                wlRemark = OrderRemark.Substring(0, wlI);
                                            }
                                            string s = OrderRemark.Substring(OrderRemark.IndexOf("赠品") + 2).Trim();
                                            int f = s.IndexOf("/");
                                            if (f > -1)
                                            {
                                                zpRemark = s.Substring(0, f);
                                            }
                                            if (zpRemark != "")
                                            {
                                                //物流字符长度+(赠品：)3+（/）1+赠品字符长度
                                                int length = wlRemark.Length + 3 + 1 + zpRemark.Length;
                                                qtRemark = OrderRemark.Substring(length).ToLower();

                                            }
                                        }
                                    }
                                    #endregion

                                    if (wlRemark != "" && qtRemark != "")
                                    {
                                        base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(premiumsDetails);
                                        //根据主表id 查询明细数据
                                        var premiumsDetailsList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(this.PremiumsId);

                                        #region  赠品信息 累加
                                        if (premiumsDetailsList.Count > 0)
                                        {
                                            for (int j = 0; j < premiumsDetailsList.Count; j++)
                                            {
                                                var product = base.XMProductService.GetXMProductById(premiumsDetailsList[j].ProductDetaislId.Value);
                                                if (product != null)
                                                {
                                                    CustomerServiceRemark += premiumsDetailsList[j].PrdouctName + "(" + product.Specifications + ")*" + premiumsDetailsList[j].ProductNum;
                                                }
                                                if (premiumsDetailsList.Count > 1 && j < premiumsDetailsList.Count - 1)
                                                {

                                                    CustomerServiceRemark += "+";
                                                }
                                            }
                                        }
                                        #endregion

                                        #region 修改主表赠品说明信息
                                        var xmPremiums = base.XMPremiumsService.GetXMPremiumsById(this.PremiumsId);
                                        if (xmPremiums != null)
                                        {
                                            xmPremiums.ActivityExplanation = CustomerServiceRemark;
                                            xmPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                            xmPremiums.UpdateTime = DateTime.Now;
                                            base.XMPremiumsService.UpdateXMPremiums(xmPremiums);
                                        }
                                        #endregion

                                        //从新拼接 备注信息
                                        NewRemark = wlRemark + "赠品 " + CustomerServiceRemark + "/" + qtRemark;

                                        #region 平台后台修改备注
                                        if (NewRemark != "")
                                        {
                                            //修改备注
                                            var tradeMemoUpdate = base.XMOrderInfoAPIService.ReturnTradeMemoUpdate(Convert.ToInt64(OrderCode), NewRemark, xMorderInfoAppNew[i]);
                                            //清空属性值  
                                            //物流信息
                                            wlRemark = "";
                                            //赠品信息
                                            zpRemark = "";
                                            //其他信息
                                            qtRemark = "";
                                            //新的备注信息
                                            NewRemark = "";
                                            //新的赠品信息
                                            CustomerServiceRemark = "";
                                        }

                                        #endregion
                                    }
                                }
                            }

                        }
                        #endregion
                        #region 一号店
                        else if (xMorderInfoAppNew[i].PlatformTypeId == 375)
                        {
                            int YHDInsertCount = 0;
                            int YHDUpdateCount = 0; //返回更新的条数

                            //根据订单号获取一号店 订单信息
                            base.XMOrderInfoAPIService.getOrderYHD(OrderCode, ref YHDInsertCount, ref YHDUpdateCount, xMorderInfoAppNew[i]);

                            if (YHDUpdateCount > 0)
                            {

                                #region 同步最新订单信息 并取备注信息

                                var xMOrderInfoTMNew = base.XMOrderInfoService.GetXMOrderInfoListByOrderEqs(OrderCode);

                                if (xMOrderInfoTMNew.Count > 0)
                                {
                                    if (xMOrderInfoTMNew[0].CustomerServiceRemark != "")
                                    {
                                        string OrderRemark = xMOrderInfoTMNew[0].CustomerServiceRemark;

                                        int wlI = OrderRemark.IndexOf("赠品");
                                        if (wlI > -1)
                                        {
                                            wlRemark = OrderRemark.Substring(0, wlI);
                                        }
                                        string s = OrderRemark.Substring(OrderRemark.IndexOf("赠品") + 2).Trim();
                                        int f = s.IndexOf("/");
                                        if (f > -1)
                                        {
                                            zpRemark = s.Substring(0, f);
                                        }
                                        if (zpRemark != "")
                                        {
                                            //物流字符长度+(赠品：)3+（/）1+赠品字符长度
                                            int length = wlRemark.Length + 3 + 1 + zpRemark.Length;
                                            qtRemark = OrderRemark.Substring(length).ToLower();

                                        }
                                    }
                                }
                                #endregion

                                if (wlRemark != "" && qtRemark != "")
                                {
                                    base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(premiumsDetails);
                                    //根据主表id 查询明细数据
                                    var premiumsDetailsList = base.XMPremiumsDetailsService.GetXMPremiumsDetailsListByPremiumsId(this.PremiumsId);

                                    #region  赠品信息 累加
                                    if (premiumsDetailsList.Count > 0)
                                    {
                                        for (int j = 0; j < premiumsDetailsList.Count; j++)
                                        {
                                            var product = base.XMProductService.GetXMProductById(premiumsDetailsList[j].ProductDetaislId.Value);
                                            if (product != null)
                                            {
                                                CustomerServiceRemark += premiumsDetailsList[j].PrdouctName + "(" + product.Specifications + ")*" + premiumsDetailsList[j].ProductNum;
                                            }
                                            if (premiumsDetailsList.Count > 1 && j < premiumsDetailsList.Count - 1)
                                            {

                                                CustomerServiceRemark += "+";
                                            }
                                        }
                                    }
                                    #endregion

                                    #region 修改主表赠品说明信息
                                    var xmPremiums = base.XMPremiumsService.GetXMPremiumsById(this.PremiumsId);
                                    if (xmPremiums != null)
                                    {
                                        xmPremiums.ActivityExplanation = CustomerServiceRemark;
                                        xmPremiums.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                        xmPremiums.UpdateTime = DateTime.Now;
                                        base.XMPremiumsService.UpdateXMPremiums(xmPremiums);
                                    }
                                    #endregion

                                    //从新拼接 备注信息
                                    NewRemark = wlRemark + "赠品 " + CustomerServiceRemark + "/" + qtRemark;

                                    #region 平台后台修改备注
                                    if (NewRemark != "")
                                    {
                                        //修改备注 
                                        // base.XMOrderInfoAPIService.OrderMerchantRemarkUpdate(OrderCode, NewRemark, xMorderInfoAppNew[i]);
                                        //清空属性值  
                                        //物流信息
                                        wlRemark = "";
                                        //赠品信息
                                        zpRemark = "";
                                        //其他信息
                                        qtRemark = "";
                                        //新的备注信息
                                        NewRemark = "";
                                        //新的赠品信息
                                        CustomerServiceRemark = "";
                                    }

                                    #endregion
                                }
                            }
                        }
                        #endregion
                        //苏宁易购
                        else if (xMorderInfoAppNew[i].PlatformTypeId == 383)
                        {

                        }
                        //唯品会
                        else if (xMorderInfoAppNew[0].PlatformTypeId == 259)
                        {


                        }
                    }

                #endregion

                }
                this.RowEditIndex = -1;
                this.BindGrid();
                //scope.Complete();
                this.Master.JsWrite("alert('保存成功！')", "");
                //   ScriptManager.RegisterStartupScript(this.grdPremiumsDetailsManage, this.Page.GetType(), "xmpremiumsDetails", "autoCompleteBind()", true);
            }
        }

        protected void grdPremiumsDetailsManage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int QID = Convert.ToInt32(grdPremiumsDetailsManage.DataKeys[e.RowIndex].Value.ToString());

            var premiumsDetails = base.XMPremiumsDetailsService.GetXMPremiumsDetailsById(QID);
            if (premiumsDetails != null)
            {
                premiumsDetails.IsEnable = true;
                premiumsDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                premiumsDetails.UpdateDate = DateTime.Now;
                base.XMPremiumsDetailsService.UpdateXMPremiumsDetails(premiumsDetails);
            }

            //重新绑定
            this.RowEditIndex = -1;
            BindGrid();
            //ScriptManager.RegisterStartupScript(this.grdPremiumsDetailsManage, this.Page.GetType(), "xmpremiumsDetails", "autoCompleteBind()", true);
        }


        /// <summary>
        /// 赠品申请Id
        /// </summary>
        public int PremiumsId
        {
            get
            {
                return CommonHelper.QueryStringInt("PremiumsId");
            }
        }

    }
}