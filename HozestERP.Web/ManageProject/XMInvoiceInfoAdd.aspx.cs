using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMInvoiceInfoAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["InvoiceInfoDetailList"] = null;
                if (Id != 0)
                {
                    var Info = base.XMInvoiceInfoService.GetXMInvoiceInfoByID(Id);
                    if (Info != null)
                    {
                        InitializationPage(Info);
                    }
                }

                //补开，重开发票
                if (Type != 0)
                {
                    int ID = 0;
                    if (Type == 1)//补开
                    {
                        if (Session["SupplementID"] != null)
                        {
                            ID = int.Parse(Session["SupplementID"].ToString());
                        }
                    }
                    else if (Type == 2)//重开
                    {
                        if (Session["ResumeIDs"] != null)
                        {
                            ID = int.Parse(((string[])Session["ResumeIDs"])[0]);
                        }
                    }

                    var Info = base.XMInvoiceInfoService.GetXMInvoiceInfoByID(ID);
                    if (Info != null)
                    {
                        InitializationPage(Info);
                    }
                    var list = base.XMInvoiceInfoDetailService.GetXMInvoiceInfoDetailListByInvoiceInfoID(ID);
                    if (list != null && list.Count > 0)
                    {
                        Session["InvoiceInfoDetailList"] = InitializationInvoiceInfoDetail(list);
                    }
                }

                //ddlInvoiceType_Changed(sender, e);
                this.BindGrid();
            }
        }

        public List<XMInvoiceInfoDetail> InitializationInvoiceInfoDetail(List<XMInvoiceInfoDetail> list)
        {
            List<XMInvoiceInfoDetail> List = new List<XMInvoiceInfoDetail>();
            for (int i = 0; i < list.Count; i++)
            {
                XMInvoiceInfoDetail one = new XMInvoiceInfoDetail();
                one.ID = i;
                one.ProductName = list[i].ProductName;
                one.ProductUnit = list[i].ProductUnit;
                one.Count = list[i].Count;
                one.UnitPrice = list[i].UnitPrice;
                one.Amount = list[i].Amount;
                one.IsEnable = false;
                one.CreateID = HozestERPContext.Current.User.CustomerID;
                one.CreateDate = DateTime.Now;
                one.UpdateID = HozestERPContext.Current.User.CustomerID;
                one.UpdateDate = DateTime.Now;
                List.Add(one);
            }
            return List;
        }

        public void InitializationPage(XMInvoiceInfo Info)
        {
            this.ddlInvoiceType.SelectedValue = Info.InvoiceType.ToString();
            if (Type == 0)
            {
                this.txtInvoiceNo.Text = Info.InvoiceNo;
            }
            this.txtOrderCode.Text = Info.OrderCode;
            this.txtInvoiceHeader.Text = Info.InvoiceHeader;
            if (Info.InvoiceType == 720 || (Info.DutyParagraph != null && Info.DutyParagraph != ""))//增值税专用发票
            {
                this.txtDutyParagraph.Visible = true;
                this.txtAddress.Visible = true;
                this.txtTel.Visible = true;
                this.txtBankAccount.Visible = true;
                this.txtAccountNumber.Visible = true;
                this.txtDutyParagraph.Text = Info.DutyParagraph;
                this.txtAddress.Text = Info.Address;
                this.txtTel.Text = Info.Tel;
                this.txtBankAccount.Text = Info.BankAccount;
                this.txtAccountNumber.Text = Info.AccountNumber;
            }
            else 
            {
                this.txtDutyParagraph.Visible = false;
                this.txtAddress.Visible = false;
                this.txtTel.Visible = false;
                this.txtBankAccount.Visible = false;
                this.txtAccountNumber.Visible = false;

                this.txtDutyParagraph.Text = "";
                this.txtAddress.Text = "";
                this.txtTel.Text = "";
                this.txtBankAccount.Text = "";
                this.txtAccountNumber.Text = "";
            }
            if(Info.InvoiceType != 720 && Info.DutyParagraph != "" && Info.DutyParagraph != null)
            {
                this.chkcom.Checked = true;
            }
            this.txtOrderCode.Enabled = false;
            if(Info.IsInvoiceOpen!=null&& (bool)Info.IsInvoiceOpen)
            {
                btnSave.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            //控件绑定发票类型
            this.ddlInvoiceType.Items.Clear();
            var InvoiceTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(235, false);
            this.ddlInvoiceType.DataSource = InvoiceTypeList;
            this.ddlInvoiceType.DataTextField = "CodeName";
            this.ddlInvoiceType.DataValueField = "CodeID";
            this.ddlInvoiceType.DataBind();
            this.ddlInvoiceType.Items.Insert(0, new ListItem("--- 所有 ---", "-1"));
        }

        public void SetTrigger()
        {
        }

        #endregion

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                List<XMInvoiceInfoDetail> list = new List<XMInvoiceInfoDetail>();
                if (Session["InvoiceInfoDetailList"] != null)
                {
                    list = ((List<XMInvoiceInfoDetail>)Session["InvoiceInfoDetailList"]);
                }

                if (e.CommandName.Equals("ToDelete"))//删除
                {
                    if (Id != 0)
                    {
                        var Info = base.XMInvoiceInfoDetailService.GetXMInvoiceInfoDetailByID(Convert.ToInt32(e.CommandArgument));
                        if (Info != null)//删除
                        {
                            Info.IsEnable = true;
                            Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            base.XMInvoiceInfoDetailService.UpdateXMInvoiceInfoDetail(Info);
                        }
                    }
                    else
                    {
                        list.RemoveAt(Convert.ToInt32(e.CommandArgument));
                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i].ID = i;
                        }
                        Session["InvoiceInfoDetailList"] = list;
                    }
                    base.ShowMessage("操作成功！");
                    this.BindGrid();
                }
                if (e.CommandName.Equals("ToEdit"))//修改
                {
                    int a = 0;
                    decimal b = 0;
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    HtmlInputText lblProductName = (HtmlInputText)gvr.FindControl("lblProductName");
                    HtmlInputText lblProductUnit = (HtmlInputText)gvr.FindControl("lblProductUnit");
                    HtmlInputText lblCount = (HtmlInputText)gvr.FindControl("lblCount");
                    HtmlInputText lblUnitPrice = (HtmlInputText)gvr.FindControl("lblUnitPrice");
                    HtmlInputText lblAmount = (HtmlInputText)gvr.FindControl("lblAmount");

                    if (lblProductName.Value == "" || lblCount.Value == "" || lblUnitPrice.Value == "" || lblAmount.Value == "")
                    {
                        base.ShowMessage("数据不能为空！");
                        return;
                    }

                    if (!int.TryParse(lblCount.Value, out a))
                    {
                        base.ShowMessage("数量必须为整数！");
                        return;
                    }

                    if (!decimal.TryParse(lblUnitPrice.Value, out b) || !decimal.TryParse(lblAmount.Value, out b))
                    {
                        base.ShowMessage("单价，总价必须为数字！");
                        return;
                    }

                    bool PinPaiCheck = false;
                    var CodeListPinPai= CodeService.GetCodeListInfoByCodeTypeID(187);
                    foreach(var item in CodeListPinPai)
                    {
                        if(lblProductName.Value.Contains(item.CodeName))
                        {
                            PinPaiCheck = true;
                        }
                    }

                    bool ProductTypeCheck = false;
                    var CodeListProductType= CodeService.GetCodeListInfoByCodeTypeID(188);
                    foreach(var item in CodeListProductType)
                    {
                        if (lblProductName.Value.Contains(item.CodeName))
                        {
                            ProductTypeCheck = true;
                        }
                    }

                    if (!PinPaiCheck||!ProductTypeCheck)
                    {
                        base.ShowMessage("产品名称不符合规范，格式应是品牌+产品类型！");
                    }

                    XMInvoiceInfoDetail one = new XMInvoiceInfoDetail();
                    one.ProductName = lblProductName.Value.Trim();
                    one.ProductUnit = lblProductUnit.Value.Trim();
                    one.Count = int.Parse(lblCount.Value.Trim());
                    one.UnitPrice = decimal.Parse(lblUnitPrice.Value.Trim());
                    one.Amount = decimal.Parse(lblAmount.Value.Trim());
                    one.IsEnable = false;
                    one.CreateID = HozestERPContext.Current.User.CustomerID;
                    one.CreateDate = DateTime.Now;
                    one.UpdateID = HozestERPContext.Current.User.CustomerID;
                    one.UpdateDate = DateTime.Now;
                    if (Id != 0)
                    {
                        string OrderCode = this.txtOrderCode.Text.Trim();
                        var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
                        if (OrderInfo != null)
                        {
                            var detaillist = base.XMInvoiceInfoDetailService.GetXMInvoiceInfoDetailListByOrderCode(OrderCode);
                            decimal total = (decimal)detaillist.Sum(x => x.Amount);
                            total += (decimal)one.Amount;
                            if (total > OrderInfo.PayPrice)
                            {
                                base.ShowMessage("该订单发票总金额不能大于订单支付金额！");
                                return;
                            }
                        }

                        one.InvoiceInfoID = Id;
                        base.XMInvoiceInfoDetailService.InsertXMInvoiceInfoDetail(one);
                    }
                    else
                    {
                        one.ID = list.Count;
                        list.Add(one);
                        Session["InvoiceInfoDetailList"] = list;
                    }
                    base.ShowMessage("添加成功！");
                }
                this.BindGrid();
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }
        }

        public void BindGrid()
        {
            List<XMInvoiceInfoDetail> list = new List<XMInvoiceInfoDetail>();
            if (Id != 0)
            {
                list = base.XMInvoiceInfoDetailService.GetXMInvoiceInfoDetailListByInvoiceInfoID(Id);
            }
            else
            {
                if (Session["InvoiceInfoDetailList"] != null)
                {
                    list = ((List<XMInvoiceInfoDetail>)Session["InvoiceInfoDetailList"]).ToList();
                }
            }

            //新增编码行
            this.grdvClients.EditIndex = list.Count();
            list.Add(new XMInvoiceInfoDetail());
            this.grdvClients.DataSource = list;
            this.grdvClients.DataBind();
        }

        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var Info = e.Row.DataItem as XMInvoiceInfoDetail;
                if (Info.ID > 0 || Info.Count != null)
                {
                    ImageButton imgBtnUpdate = (ImageButton)e.Row.FindControl("imgBtnUpdate");
                    imgBtnUpdate.Visible = false;
                }
            }
        }

        protected void ddlInvoiceType_Changed(object sender, EventArgs e)
        {
            int InvoiceType = int.Parse(this.ddlInvoiceType.SelectedValue);
            if (InvoiceType == 720)
            {
                this.txtDutyParagraph.Visible = true;
                this.txtAddress.Visible = true;
                this.txtTel.Visible = true;
                this.txtBankAccount.Visible = true;
                this.txtAccountNumber.Visible = true;
            }
            else
            {
                if (!chkcom.Checked)
                {
                    this.txtDutyParagraph.Visible = false;
                    this.txtAddress.Visible = false;
                    this.txtTel.Visible = false;
                    this.txtBankAccount.Visible = false;
                    this.txtAccountNumber.Visible = false;

                    this.txtDutyParagraph.Text = "";
                    this.txtAddress.Text = "";
                    this.txtTel.Text = "";
                    this.txtBankAccount.Text = "";
                    this.txtAccountNumber.Text = "";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int InvoiceType = int.Parse(this.ddlInvoiceType.SelectedValue);
                string InvoiceNo = this.txtInvoiceNo.Text.Trim();
                string OrderCode = this.txtOrderCode.Text.Trim();
                string InvoiceHeader = this.txtInvoiceHeader.Text.Trim();
                string DutyParagraph = this.txtDutyParagraph.Text.Trim();
                string Address = this.txtAddress.Text.Trim();
                string Tel = this.txtTel.Text.Trim();
                string BankAccount = this.txtBankAccount.Text.Trim();
                string AccountNumber = this.txtAccountNumber.Text.Trim();

                if (InvoiceType == -1)
                {
                    base.ShowMessage("请选择发票类型！");
                    return;
                }

                if (OrderCode == "")
                {
                    base.ShowMessage("订单号不能为空！");
                    return;
                }

                if (InvoiceHeader == "")
                {
                    base.ShowMessage("发票抬头不能为空！");
                    return;
                }

                if (InvoiceType == 720 || chkcom.Checked)//增值税专用发票或公司普票
                {
                    if (DutyParagraph == "" || Address == "" || Tel == "" || BankAccount == "" || AccountNumber == "")
                    {
                        base.ShowMessage("请先填写发票必须数据！");
                        return;
                    }
                }

                if (Id != 0)
                {
                    var Info = base.XMInvoiceInfoService.GetXMInvoiceInfoByID(Id);
                    if (Info != null)
                    {
                        var list = base.XMInvoiceInfoDetailService.GetXMInvoiceInfoDetailListByInvoiceInfoID(Id);
                        if (list == null || list.Count == 0)
                        {
                            base.ShowMessage("产品明细至少必须有一条记录！");
                            return;
                        }

                        Info.InvoiceType = InvoiceType;
                        //Info.InvoiceNo = InvoiceNo;
                        Info.OrderCode = OrderCode;
                        Info.InvoiceHeader = InvoiceHeader;
                        if (InvoiceType == 720 || chkcom.Checked)//增值税专用发票或者公司普票
                        {
                            Info.DutyParagraph = DutyParagraph;
                            Info.Address = Address;
                            Info.Tel = Tel;
                            Info.BankAccount = BankAccount;
                            Info.AccountNumber = AccountNumber;
                        }
                        Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        Info.UpdateDate = DateTime.Now;
                        base.XMInvoiceInfoService.UpdateXMInvoiceInfo(Info);
                    }
                }
                else
                {
                    decimal total = 0;
                    List<XMInvoiceInfo> InvoiceInfoList = new List<XMInvoiceInfo>();
                    List<XMInvoiceInfoDetail> DetailList = ((List<XMInvoiceInfoDetail>)Session["InvoiceInfoDetailList"]);
                    if (DetailList == null || DetailList.Count == 0)
                    {
                        base.ShowMessage("产品明细至少必须有一条记录！");
                        return;
                    }

                    var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
                    if (OrderInfo != null)
                    {
                        //该订单数据库表中已存在的数据
                        var detaillist = base.XMInvoiceInfoDetailService.GetXMInvoiceInfoDetailListByOrderCode(OrderCode);
                        total = (decimal)detaillist.Sum(x => x.Amount);
                    }
                    //新增的发票明细数据
                    total += (decimal)DetailList.Sum(x => x.Amount);

                    XMInvoiceInfo Info = new XMInvoiceInfo();
                    Info.InvoiceType = InvoiceType;
                    Info.InvoiceNo = GetInvoiceNo();
                    Info.OrderCode = OrderCode;
                    Info.InvoiceHeader = InvoiceHeader;
                    if (InvoiceType == 720 || chkcom.Checked)//增值税专用发票或者公司普票
                    {
                        Info.DutyParagraph = DutyParagraph;
                        Info.Address = Address;
                        Info.Tel = Tel;
                        Info.BankAccount = BankAccount;
                        Info.AccountNumber = AccountNumber;
                    }
                    var list = base.CodeService.GetCodeListInfoByCodeTypeID(233);
                    if (list.Count > 0)
                    {
                        foreach (var a in list)
                        {
                            if (a.CodeName.IndexOf("新开") != -1 && Type == 0)
                            {
                                Info.InvoiceStatus = a.CodeID;
                                break;
                            }
                            if (a.CodeName.IndexOf("补开") != -1 && Type == 1)
                            {
                                Info.InvoiceStatus = a.CodeID;
                                break;
                            }
                            if (a.CodeName.IndexOf("重开") != -1 && Type == 2)
                            {
                                Info.InvoiceStatus = a.CodeID;
                                break;
                            }
                        }
                    }

                    if (Type == 1 && Session["SupplementID"] != null)
                    {
                        Info.RelationID = Session["SupplementID"].ToString();
                    }
                    if (Type == 2 && Session["ResumeIDs"] != null)
                    {
                        string[] arr = (string[])Session["ResumeIDs"];
                        foreach (var a in arr)
                        {
                            if (string.IsNullOrEmpty(Info.RelationID))
                            {
                                Info.RelationID = a;
                            }
                            else
                            {
                                Info.RelationID += "," + a;
                            }

                            var item = base.XMInvoiceInfoService.GetXMInvoiceInfoByID(int.Parse(a));
                            if (item != null)
                            {
                                //数据库表中重写的数据
                                total -= (decimal)item.XM_InvoiceInfoDetail.Sum(x => x.Amount);
                                InvoiceInfoList.Add(item);
                            }
                        }
                    }

                    Info.IsSingleRow = false;
                    Info.IsScrap = false;
                    Info.IsEnable = false;
                    Info.CreateID = HozestERPContext.Current.User.CustomerID;
                    Info.CreateDate = DateTime.Now;
                    Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDate = DateTime.Now;

                    if (total > OrderInfo.PayPrice)
                    {
                        base.ShowMessage("该订单发票总金额不能大于订单支付金额！");
                        return;
                    }

                    //重写的发货单，废弃
                    foreach (var item in InvoiceInfoList)
                    {
                        item.IsScrap = true;
                        item.UpdateID = HozestERPContext.Current.User.CustomerID;
                        item.UpdateDate = DateTime.Now;
                        base.XMInvoiceInfoService.UpdateXMInvoiceInfo(item);
                    }

                    Info.XM_InvoiceInfoDetail = new List<XMInvoiceInfoDetail>();
                    foreach (var a in DetailList)
                    {
                        a.InvoiceInfoID = Info.ID;
                        Info.XM_InvoiceInfoDetail.Add(a);
                    }
                    base.XMInvoiceInfoService.InsertXMInvoiceInfo(Info);
                    var orderinfo = base.XMOrderInfoAPIService.GetXMOrderInfoByOrderCode(OrderCode);
                    if (orderinfo != null) 
                    {
                        orderinfo.IsInvoiced = true;//订单信息里是否开票改成true
                        base.XMOrderInfoService.UpdateXMOrderInfo(orderinfo);
                    }
                }

                base.ShowMessage("保存成功！");
            }
            catch (Exception err)
            {
                this.ProcessException(err);
            }
        }

        public string GetInvoiceNo(string InvoiceNo = "")
        {
            Random ran = new Random();
            int RandKey = ran.Next(10000000, 99999999);
            var exist = base.XMInvoiceInfoService.GetXMInvoiceInfoListByInvoiceNo(RandKey.ToString());
            if (exist != null && exist.Count > 0)
            {
                InvoiceNo = GetInvoiceNo();
            }
            else
            {
                return RandKey.ToString();
            }
            return InvoiceNo;
        }

        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        public int Type
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool iscom = this.chkcom.Checked;
            int InvoiceType = int.Parse(this.ddlInvoiceType.SelectedValue);
            if (InvoiceType != 720)
            {
                if (iscom)
                {
                    this.txtDutyParagraph.Visible = true;
                    this.txtAddress.Visible = true;
                    this.txtTel.Visible = true;
                    this.txtBankAccount.Visible = true;
                    this.txtAccountNumber.Visible = true;
                }
                else
                {
                    this.txtDutyParagraph.Visible = false;
                    this.txtAddress.Visible = false;
                    this.txtTel.Visible = false;
                    this.txtBankAccount.Visible = false;
                    this.txtAccountNumber.Visible = false;

                    this.txtDutyParagraph.Text = "";
                    this.txtAddress.Text = "";
                    this.txtTel.Text = "";
                    this.txtBankAccount.Text = "";
                    this.txtAccountNumber.Text = "";
                }
            }
        }
    }
}