using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;

namespace HozestERP.Web.ManageProject
{
    public partial class XMClaimAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate(); 
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool IsReturn = this.chkIsReturn.Checked;
            string ApplicationNo = this.txtApplicationNo.Text.Trim();
            string OrderCode = this.txtOrderCode.Text.Trim();

            int ClaimType = int.Parse(this.ddlClaimType.SelectedValue);
            string Amount = this.txtAmount.Text.Trim();

            string ConsignorName = this.txtConsignorName.Text.Trim();
            string CompanyName = this.txtCompanyName.Text.Trim();
            string BeginDate = this.txtBeginDate.Value.Trim();
            string EndDate = this.txtEndDate.Value.Trim();
            string ReturnTime = this.txtReturnTime.Text.Trim();

            string LogisticsNumber = this.txtLogisticsNumber.Text.Trim();
            string GoodsName = this.txtGoodsName.Text.Trim();
            string Count = this.txtCount.Text.Trim();
            string InsuredAmount = this.txtInsuredAmount.Text.Trim();
            string BeginPlace = this.txtBeginPlace.Text.Trim();
            string EndPlace = this.txtEndPlace.Text.Trim();
            string BrokenPieces = this.txtBrokenPieces.Text.Trim();
            string BrokenStatus = "";
            if (this.CheckBox1.Checked)
            {
                BrokenStatus = BrokenStatus + ",1";
            }
            if (this.CheckBox2.Checked)
            {
                BrokenStatus = BrokenStatus + ",2";
            }
            if (this.CheckBox3.Checked)
            {
                BrokenStatus = BrokenStatus + ",3";
            }
            if (this.CheckBox4.Checked)
            {
                BrokenStatus = BrokenStatus + ",4";
            }
            if (this.CheckBox5.Checked)
            {
                BrokenStatus = BrokenStatus + ",5";
            }
            if (this.CheckBox6.Checked)
            {
                BrokenStatus = BrokenStatus + ",6";
            }
            if (this.CheckBox7.Checked)
            {
                BrokenStatus = BrokenStatus + ",7";
            }

            if (chkIsReturn.Checked && ApplicationNo == "")
            {
                base.ShowMessage("请输入退换货单号！");
                return;
            }

            if (OrderCode == "")
            {
                base.ShowMessage("请输入订单号！");
                return;
            }

            decimal a = 0;
            int b = 0;

            if (Amount == "" || decimal.TryParse(Amount, out a) == false)
            {
                base.ShowMessage("索赔金额输入不正确！");
                return;
            }

            if (InsuredAmount == "" || decimal.TryParse(InsuredAmount, out a) == false)
            {
                base.ShowMessage("保价金额输入不正确！");
                return;
            }

            if (Count == "" || int.TryParse(Count, out b) == false)
            {
                base.ShowMessage("托运数量输入不正确！");
                return;
            }

            if (BrokenPieces == "" || int.TryParse(BrokenPieces, out b) == false)
            {
                base.ShowMessage("受损数量输入不正确！");
                return;
            }

            if (BrokenStatus == "")
            {
                base.ShowMessage("受损状态至少勾选1项！");
                return;
            }

            if (ConsignorName == "")
            {
                base.ShowMessage("请输入发货人！");
                return;
            }

            if (CompanyName == "")
            {
                base.ShowMessage("请输入托运公司！");
                return;
            }

            if (BeginDate == "" || EndDate == "")
            {
                base.ShowMessage("发货时间和到达时间不能为空！");
                return;
            }

            for (int i = 0; i < this.grdvZYNewsList.Rows.Count; i++)
            {
                TextBox ClaimAmount = (TextBox)grdvZYNewsList.Rows[i].Cells[4].FindControl("txtAmount");
                decimal c = 0;
                if (decimal.TryParse(ClaimAmount.Text, out c) == false)
                {
                    base.ShowMessage("受损金额输入错误！");
                    return;
                }
            }

            int PlatformType = int.Parse(this.hidPlatformType.Value.Trim());
            int Nick = int.Parse(this.hidNick.Value.Trim());

            //一个退换货只能有一个索赔单
            if (IsReturn)
            {
                var IsExist = base.XMClaimFormService.GetXMClaimFormListByApplicationNo(ApplicationNo);
                if (IsExist != null && IsExist.Count > 0 && IsExist[0].ID != Id)
                {
                    base.ShowMessage("该退换货单号已有相关联的索赔单！");
                    return;
                }
            }

            if (Id == -1)
            {
                XMClaimForm info = new XMClaimForm();
                info.ClaimNumber = DateTime.Now.ToString("yyMMddHHmmssfff");
                info.ApplicationNo = ApplicationNo;
                info.IsReturn = IsReturn;
                if (IsReturn && !string.IsNullOrEmpty(ReturnTime))
                {
                    info.ReturnTime = DateTime.Parse(ReturnTime);
                }
                info.ClaimDate = DateTime.Now;
                info.OrderCode = OrderCode;
                info.NickId = Nick;
                info.PlatformTypeId = PlatformType;
                info.ClaimType = ClaimType;
                info.Amount = decimal.Parse(Amount);
                info.FinancialStatus = false;
                info.ConsignorName = ConsignorName;
                info.CompanyName = CompanyName;
                info.BeginDate = DateTime.Parse(BeginDate);
                info.EndDate = DateTime.Parse(EndDate);
                info.LogisticsNumber = LogisticsNumber;
                info.GoodsName = GoodsName;
                info.Count = int.Parse(Count);
                info.InsuredAmount = decimal.Parse(InsuredAmount);
                info.BeginPlace = BeginPlace;
                info.EndPlace = EndPlace;
                info.BrokenPieces = int.Parse(BrokenPieces);
                info.BrokenStatus = BrokenStatus;
                info.IsEnable = false;
                info.CreateID = HozestERPContext.Current.User.CustomerID;
                info.CreateDate = DateTime.Now;
                info.UpdateID = HozestERPContext.Current.User.CustomerID;
                info.UpdateDate = DateTime.Now;
                base.XMClaimFormService.InsertXMClaimForm(info);

                for (int i = 0; i < this.grdvZYNewsList.Rows.Count; i++)
                {
                    Label ProductName = (Label)grdvZYNewsList.Rows[i].Cells[0].FindControl("lblProductName");
                    Label Model = (Label)grdvZYNewsList.Rows[i].Cells[1].FindControl("lblModel");
                    TextBox ProductValue = (TextBox)grdvZYNewsList.Rows[i].Cells[2].FindControl("txtProductValue");
                    TextBox Description = (TextBox)grdvZYNewsList.Rows[i].Cells[3].FindControl("txtDescription");
                    TextBox ClaimAmount = (TextBox)grdvZYNewsList.Rows[i].Cells[4].FindControl("txtAmount");

                    XMClaimFormDetail one = new XMClaimFormDetail();
                    one.ClaimFormID = info.ID;
                    one.ProductName = ProductName.Text;
                    one.Model = Model.Text;
                    one.ProductValue = ProductValue.Text;
                    one.Description = Description.Text;
                    one.Amount = decimal.Parse(ClaimAmount.Text);
                    one.IsEnable = false;
                    one.CreateID = HozestERPContext.Current.User.CustomerID;
                    one.CreateDate = DateTime.Now;
                    one.UpdateID = HozestERPContext.Current.User.CustomerID;
                    one.UpdateDate = DateTime.Now;
                    base.XMClaimFormDetailService.InsertXMClaimFormDetail(one);
                }

                base.ShowMessage("保存成功！");
            }
            else
            {
                XMClaimForm info = base.XMClaimFormService.GetXMClaimFormByID(Id);
                info.ApplicationNo = ApplicationNo;
                info.OrderCode = OrderCode;
                info.NickId = Nick;
                info.PlatformTypeId = PlatformType;
                info.ClaimType = ClaimType;
                info.Amount = decimal.Parse(Amount);
                info.ConsignorName = ConsignorName;
                info.CompanyName = CompanyName;
                info.BeginDate = DateTime.Parse(BeginDate);
                info.EndDate = DateTime.Parse(EndDate);
                info.LogisticsNumber = LogisticsNumber;
                info.GoodsName = GoodsName;
                info.Count = int.Parse(Count);
                info.InsuredAmount = decimal.Parse(InsuredAmount);
                info.BeginPlace = BeginPlace;
                info.EndPlace = EndPlace;
                info.BrokenPieces = int.Parse(BrokenPieces);
                info.BrokenStatus = BrokenStatus;
                info.UpdateID = HozestERPContext.Current.User.CustomerID;
                info.UpdateDate = DateTime.Now;
                base.XMClaimFormService.UpdateXMClaimForm(info);

                var list = base.XMClaimFormDetailService.GetXMClaimFormDetailListByClaimFormID(Id);
                if (list != null && list.Count > 0)
                {
                    foreach(XMClaimFormDetail one in list)
                    {
                        base.XMClaimFormDetailService.DeleteXMClaimFormDetail(one.ID);
                    }
                }

                for (int i = 0; i < this.grdvZYNewsList.Rows.Count; i++)
                {
                    Label ProductName = (Label)grdvZYNewsList.Rows[i].Cells[0].FindControl("lblProductName");
                    Label Model = (Label)grdvZYNewsList.Rows[i].Cells[1].FindControl("lblModel");
                    TextBox ProductValue = (TextBox)grdvZYNewsList.Rows[i].Cells[2].FindControl("txtProductValue");
                    TextBox Description = (TextBox)grdvZYNewsList.Rows[i].Cells[3].FindControl("txtDescription");
                    TextBox ClaimAmount = (TextBox)grdvZYNewsList.Rows[i].Cells[4].FindControl("txtAmount");

                    XMClaimFormDetail one = new XMClaimFormDetail();
                    one.ClaimFormID = info.ID;
                    one.ProductName = ProductName.Text;
                    one.Model = Model.Text;
                    one.ProductValue = ProductValue.Text;
                    one.Description = Description.Text;
                    one.Amount = decimal.Parse(ClaimAmount.Text);
                    one.IsEnable = false;
                    one.CreateID = HozestERPContext.Current.User.CustomerID;
                    one.CreateDate = DateTime.Now;
                    one.UpdateID = HozestERPContext.Current.User.CustomerID;
                    one.UpdateDate = DateTime.Now;
                    base.XMClaimFormDetailService.InsertXMClaimFormDetail(one);
                }

                base.ShowMessage("保存成功！");
            }
        }

        public void loadDate() 
        {
            this.Face_Init();
            Session["ClaimFormDetailList"] = null;
            if (Id != -1)
            {
                var info = base.XMClaimFormService.GetXMClaimFormByID(Id);
                this.chkIsReturn.Checked = (bool)info.IsReturn;
                this.txtApplicationNo.Text = info.ApplicationNo;
                this.txtOrderCode.Text = info.OrderCode;
                this.hidPlatformType.Value = info.PlatformTypeId.ToString();
                this.txtPlatformType.Text = info.PlatformType;
                this.hidNick.Value = info.NickId.ToString();
                this.txtNick.Text = info.NickName;
                this.ddlClaimType.SelectedValue = info.ClaimType.ToString();
                this.txtAmount.Text = info.Amount.ToString();
                this.txtConsignorName.Text = info.ConsignorName;
                this.txtCompanyName.Text = info.CompanyName;
                this.txtBeginDate.Value = ((DateTime)info.BeginDate).ToString("yyyy-MM-dd");
                this.txtEndDate.Value = ((DateTime)info.EndDate).ToString("yyyy-MM-dd");
                this.txtLogisticsNumber.Text = info.LogisticsNumber;
                this.txtGoodsName.Text = info.GoodsName;
                this.txtCount.Text = info.Count.ToString();
                this.txtInsuredAmount.Text = info.InsuredAmount.ToString();
                this.txtBeginPlace.Text = info.BeginPlace;
                this.txtEndPlace.Text = info.EndPlace;
                this.txtBrokenPieces.Text = info.BrokenPieces.ToString();
                this.txtReturnTime.Text = info.ReturnTime == null ? "" : info.ReturnTime.ToString();
               
                this.chkIsReturn.Enabled = false;//索赔单是否与退换货关联不能在编辑修改
                if ((bool)info.IsReturn)
                {
                    this.txtOrderCode.Enabled = false;
                }
                else
                {
                    this.txtApplicationNo.Enabled = false;
                }

                string[] list = info.BrokenStatus.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string one in list)
                {
                    if (one == "1")
                    {
                        this.CheckBox1.Checked = true;
                    }
                    if (one == "2")
                    {
                        this.CheckBox2.Checked = true;
                    }
                    if (one == "3")
                    {
                        this.CheckBox3.Checked = true;
                    }
                    if (one == "4")
                    {
                        this.CheckBox4.Checked = true;
                    }
                    if (one == "5")
                    {
                        this.CheckBox5.Checked = true;
                    }
                    if (one == "6")
                    {
                        this.CheckBox6.Checked = true;
                    }
                    if (one == "7")
                    {
                        this.CheckBox7.Checked = true;
                    }
                }

                var LIST = base.XMClaimFormDetailService.GetXMClaimFormDetailListByClaimFormID(Id);
                if (LIST != null && LIST.Count > 0)
                {
                    GridViewDataBind(LIST, true);
                }
            }
            else
            {
                this.txtApplicationNo.Enabled = false;
            }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        public void Face_Init()
        {
            this.ddlClaimType.Items.Clear();
            var ClaimTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(210, false);//210
            this.ddlClaimType.DataSource = ClaimTypeList;
            this.ddlClaimType.DataTextField = "CodeName";
            this.ddlClaimType.DataValueField = "CodeID";
            this.ddlClaimType.DataBind();

            this.txtPlatformType.Enabled = false;
            this.txtNick.Enabled = false;
            this.txtReturnTime.Enabled = false;

            var BrokenStatusList = base.CodeService.GetCodeListInfoByCodeTypeID(211, false);//211
            this.CheckBox1.Text = BrokenStatusList[0].CodeName;
            this.CheckBox2.Text = BrokenStatusList[1].CodeName;
            this.CheckBox3.Text = BrokenStatusList[2].CodeName;
            this.CheckBox4.Text = BrokenStatusList[3].CodeName;
            this.CheckBox5.Text = BrokenStatusList[4].CodeName;
            this.CheckBox6.Text = BrokenStatusList[5].CodeName;
            this.CheckBox7.Text = BrokenStatusList[6].CodeName;
        }

        public void SetTrigger()
        {
            //throw new NotImplementedException();
        }

        protected void chkIsReturn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkIsReturn.Checked)
            {
                this.txtApplicationNo.Enabled = true;
                this.txtOrderCode.Enabled = false;
                this.txtOrderCode.Text = "";
            }
            else
            {
                this.txtApplicationNo.Enabled = false;
                this.txtApplicationNo.Text = "";
                this.txtOrderCode.Enabled = true;
            }
        }

        protected void grdvZYNewsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("ToDelete"))
            {
                if (Session["ClaimFormDetailList"] != null)
                {
                    List<XMClaimFormDetail> ClaimList = (List<XMClaimFormDetail>)Session["ClaimFormDetailList"];
                    for (int i = 0; i < ClaimList.Count();i++ )
                    {
                        if (ClaimList[i].ID == Convert.ToInt32(e.CommandArgument))
                        {
                            ClaimList.Remove(ClaimList[i]);
                            break;
                        }
                    }
                    GridViewDataBind(ClaimList, true);
                    base.ShowMessage("删除成功！");
                }
                else
                {
                    base.ShowMessage("操作超时，请重新打开此索赔单！");
                }
            }
            #endregion
        }

        protected void ApplicationNo_Changed(object sender, EventArgs e)
        {
            string OrderCode = this.txtOrderCode.Text.Trim();
            var list = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsListByOrderCode(OrderCode);
            List<XMClaimFormDetail> ClaimList = new List<XMClaimFormDetail>();
            int no = 0;
            foreach(XMOrderInfoProductDetails info in list)
            {
                no++;
                XMClaimFormDetail one = new XMClaimFormDetail();
                one.ID = no;
                one.ProductName = info.ProductName;
                one.Model = info.Specifications;
                ClaimList.Add(one);
            }
            GridViewDataBind(ClaimList);
        }

        public void GridViewDataBind(List<XMClaimFormDetail> ClaimList, bool DataBindAll=false)
        {
            this.grdvZYNewsList.DataSource = ClaimList;
            //绑定数据源
            this.grdvZYNewsList.DataBind();

            Session["ClaimFormDetailList"] = ClaimList;
            
            for (int i = 0; i < this.grdvZYNewsList.Rows.Count; i++)
            {
                Label ProductName = (Label)grdvZYNewsList.Rows[i].Cells[0].FindControl("lblProductName");
                Label Model = (Label)grdvZYNewsList.Rows[i].Cells[1].FindControl("lblModel");
                ProductName.Text = ClaimList[i].ProductName;
                Model.Text = ClaimList[i].Model;
                if (DataBindAll)
                {
                    TextBox ProductValue = (TextBox)grdvZYNewsList.Rows[i].Cells[2].FindControl("txtProductValue");
                    TextBox Description = (TextBox)grdvZYNewsList.Rows[i].Cells[3].FindControl("txtDescription");
                    TextBox ClaimAmount = (TextBox)grdvZYNewsList.Rows[i].Cells[4].FindControl("txtAmount");
                    ProductValue.Text = ClaimList[i].ProductValue == null ? "" : ClaimList[i].ProductValue;
                    Description.Text = ClaimList[i].Description == null ? "" : ClaimList[i].Description;
                    ClaimAmount.Text = ClaimList[i].Amount == null ? "" : ClaimList[i].Amount.ToString();
                }
            }
        }
    }
}