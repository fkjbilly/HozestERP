using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using System.IO;

namespace HozestERP.Web.ManageProject
{
    public partial class XMClaimInfoAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                Session["XMClaimInfoAdd-ProductDetailsList"] = null;
                Session["XMClaimInfoAdd-PictureList"] = null;

                if (type == 0)
                {
                    lblRef.Visible = false;
                    BindClaimType();
                }
                else if (type == 1)
                {
                    lblMessage.Visible = false;
                    BindClaimInfo(this.ClaimInfoID);
                    BindProductDetails();
                    BindPicture();
                    cblClaimType.Enabled = false;
                }
                else
                {
                    lblMessage.Visible = false;
                    BindClaimInfo(this.ClaimInfoID);
                    BindProductDetails();
                    BindPicture();
                    cblClaimType.Enabled = false;
                    btnSave.Visible = false;
                    this.txtLogisticsNumber.Enabled = false;
                    this.grdvClaimProductDetails.Columns[6].Visible = false;
                }
            }
        }

        /// <summary>
        /// 绑定理赔类型复选框 列表
        /// </summary>
        private void BindClaimType()
        {
            ////绑定赔款类型
            var ClaimTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(222, false);
            this.cblClaimType.DataSource = ClaimTypeList;
            this.cblClaimType.DataTextField = "CodeName";
            this.cblClaimType.DataValueField = "CodeID";
            this.cblClaimType.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindClaimInfo(int id)
        {
            grdvClaimType.Visible = false;

            //绑定理赔类型
            var ClaimTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(222, false);//赔付方
            cblClaimType.DataSource = ClaimTypeList;
            cblClaimType.DataTextField = "CodeName";
            cblClaimType.DataValueField = "CodeID";
            cblClaimType.DataBind();
            var calimInfo = base.XMClaimInfoService.GetXMClaimInfoById(id);
            if (calimInfo != null)
            {
                lblRef.Text = calimInfo.ClaimRef;
                txtOrderCode.Text = calimInfo.OrderCode;
                txtRealName.Text = calimInfo.FullName;
                txtTel.Text = calimInfo.Tel;
                txtReturnCode.Text = calimInfo.ReturnRef;
                ckbIsRerturn.Checked = calimInfo.IsReturn.Value;
                Session["XMClaimInfoAdd-LogisticsNumber"] = txtLogisticsNumber.Text = calimInfo.LogisticsNumber == null ? "" : calimInfo.LogisticsNumber;
                if (calimInfo.NickId != null)
                {
                    var nick = base.XMNickService.GetXMNickByID((int)calimInfo.NickId);
                    if (nick != null)
                    {
                        ddXMProject.SelectedValue = nick.ProjectId.ToString();
                        ddlNick.SelectedValue = nick.nick_id.ToString();
                    }
                }
            }


            var list = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(id);
            grdvClaimInfo.DataSource = list;
            grdvClaimInfo.DataBind();

            for (int i = 0; i < cblClaimType.Items.Count; i++)
            {
                foreach (XMClaimInfoDetail info in list)
                {
                    if (cblClaimType.Items[i].Value == info.ClaimTypeID.ToString())
                    {
                        cblClaimType.Items[i].Selected = true;
                    }
                }
            }

        }

        private void BindPicture()
        {
            var list = base.XMClaimInfoPictureService.GetXMClaimInfoPictureListByClaimInfoID(this.ClaimInfoID);
            if (list != null && list.Count > 0)
            {
                Session["XMClaimInfoAdd-PictureList"] = list;
                LoadPicture(list);
            }
        }

        private void BindProductDetails()
        {
            List<XMClaimInfoProductDetails> list = (List<XMClaimInfoProductDetails>)Session["XMClaimInfoAdd-ProductDetailsList"];
            if (list != null && list.Count > 0)
            {
                this.grdvClaimProductDetails.DataSource = list;
                this.grdvClaimProductDetails.DataBind();
            }
            else
            {
                list = base.XMClaimInfoProductDetailsService.GetXMClaimInfoProductDetailsListByClaimInfoID(this.ClaimInfoID);
                if (list != null && list.Count > 0)
                {
                    this.grdvClaimProductDetails.DataSource = list;
                    this.grdvClaimProductDetails.DataBind();
                }
                else
                {
                    this.grdvClaimProductDetails.DataSource = null;
                    this.grdvClaimProductDetails.DataBind();
                }
            }
        }

        public string CustomerName(string customerID)
        {
            string name = "";
            var customer = base.CustomerInfoService.GetCustomerInfoByID(Convert.ToInt16(customerID));
            if (customer != null)
            {
                name = customer.FullName;
            }
            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cblClaimType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ids = "";
            for (int i = 0; i < cblClaimType.Items.Count; i++)
            {
                if (cblClaimType.Items[i].Selected)
                {
                    ids += cblClaimType.Items[i].Value + ",";
                }
            }
            if (ids.Length > 0)
            {
                ids = ids.Substring(0, ids.Length - 1);
                var CodeList = base.CodeService.GetCodeListInfoByCodeIDs(ids);
                grdvClaimType.DataSource = CodeList;
                grdvClaimType.DataBind();
            }
            else
            {
                grdvClaimType.DataSource = null;
                grdvClaimType.DataBind();
            }
        }

        private void loadData()
        {
            //绑定项目店铺
            if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
            {
                List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                if (XMProjectList.Count > 0)
                {
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                }
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
                this.ddXMProject.Items[0].Selected = true;
            }
            else
            {
                this.BindddXMProject();//项目
            }
            this.ddXMProject_SelectedIndexChanged(null, null);//店铺
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定
            string projectids = "";
            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                //.Where(c => c.ProjectTypeId == 362)

                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
                this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            else
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    this.ddXMProject.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                }
                if (projectList.Count() > 0)
                {
                    for (int i = 0; i < projectList.ToList().Count; i++)
                    {
                        projectids = projectids + projectList.ToList()[i].Id + ",";
                    }
                    if (projectids.Length > 0)
                    {
                        projectids = projectids.Substring(0, projectids.Length - 1);
                    }
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                }
            }
            #endregion
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue));
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    this.ddlNick.DataSource = nickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    //其他
                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue), HozestERPContext.Current.User.CustomerID, 0);
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    if (nickList.Count() == 0)
                    {
                        this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                    }
                    else
                    {
                        if (nickList.Count() > 0)
                        {
                            this.ddlNick.DataSource = nickList;
                            this.ddlNick.DataTextField = "nick";
                            this.ddlNick.DataValueField = "nick_id";
                            this.ddlNick.DataBind();
                        }
                        this.ddlNick.Items.Insert(0, new ListItem("---所有---", "99"));
                    }
                }

                int ProjectID = int.Parse(ddXMProject.SelectedValue.ToString());
                var list = XMClaimReasonService.getList(a => a.ProjectID == ProjectID).ToList();
                foreach (GridViewRow item in grdvClaimInfo.Rows)
                {
                    DropDownList ddlReason = item.FindControl("ddlReason") as DropDownList;
                    ddlReason.DataSource = list;
                    ddlReason.DataTextField = "Reason";
                    ddlReason.DataValueField = "Reason";
                    ddlReason.DataBind();
                    ddlReason.Items.Insert(0, new ListItem("---所有---", "-1"));
                    ddlReason.Items[0].Selected = true;
                }
            }
        }

        /// <summary>
        /// 自动生成理赔单号
        /// </summary>
        private string AutoClaimRef()
        {
            string ClaimRef = "";
            int number = 1;
            var claimInfo = base.XMClaimInfoService.GetXMClaimInfoList();
            if (claimInfo != null && claimInfo.Count > 0)
            {
                number = claimInfo[0].Id + 1;
            }
            ClaimRef = "CA" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return ClaimRef;
        }

        protected void grdvClaimInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 确认
            if (e.CommandName.Equals("Comfirm"))
            {
                var id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(id))//确认
                {
                    var claimDetail = base.XMClaimInfoDetailService.GetXMClaimInfoDetailById(int.Parse(id));
                    if (claimDetail != null)
                    {
                        claimDetail.IsConfirm = true;
                        claimDetail.ConfirmPerson = HozestERPContext.Current.User.CustomerID;
                        claimDetail.ConfirmDate = DateTime.Now;
                        base.XMClaimInfoDetailService.UpdateXMClaimInfoDetail(claimDetail);
                        base.ShowMessage("操作成功！");
                    }
                    else
                    {
                        base.ShowMessage("未查到该数据！");
                    }
                    BindClaimInfo(claimDetail.ClaimInfoID);
                    grdvClaimType.Visible = false;
                    cblClaimType.Enabled = false;
                }
            }
            #endregion
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.grdvClaimProductDetails.EditIndex > -1)
            {
                ShowMessage("请先退出商品编辑状态！");
                return;
            }

            int Id = this.ClaimInfoID;
            //自动生成理赔单号
            if (this.type == 0)//新增
            {
                if (grdvClaimType.Rows.Count == 0)
                {
                    ShowMessage("请选择相应的理赔类型！");
                    return;
                }
                bool isRight = false;
                foreach (GridViewRow list in grdvClaimType.Rows)
                {
                    decimal Todecimal = 0;
                    TextBox txtClaimAcount = list.FindControl("txtClaimAcount") as TextBox;
                    if (decimal.TryParse(txtClaimAcount.Text.Trim(), out Todecimal) == false)
                    {
                        isRight = true;
                    }
                }
                if (isRight)
                {
                    BindClaimType();
                    grdvClaimInfo.Visible = false;
                    base.ShowMessage("金额数字类型不正确！");
                    return;
                }
                string claimRef = AutoClaimRef();
                string orderCode = txtOrderCode.Text.Trim();
                string realName = txtRealName.Text.Trim();
                string tel = txtTel.Text.Trim();
                string returnCode = txtReturnCode.Text.Trim();
                string LogisticsNumber = this.txtLogisticsNumber.Text.Trim();
                bool isReturn = ckbIsRerturn.Checked;
                if (ddlNick.SelectedValue == "")
                {
                    base.ShowMessage("请选择店铺！");
                    return;
                }
                int nickID = Convert.ToInt16(ddlNick.SelectedValue);
                if (nickID == -1 || nickID == 99)
                {
                    base.ShowMessage("请选择店铺！");
                    return;
                }
                HozestERP.BusinessLogic.ManageProject.XMClaimInfo Info = new BusinessLogic.ManageProject.XMClaimInfo();
                Info.OrderCode = orderCode;
                Info.FullName = realName;
                Info.Tel = tel;
                Info.ReturnRef = returnCode;
                Info.IsReturn = isReturn;
                Info.ClaimRef = claimRef;
                Info.CreateDate = Info.UpdateDate = DateTime.Now;
                Info.CreateID = Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                Info.NickId = nickID;
                if (LogisticsNumber != "")
                {
                    Info.LogisticsNumber = LogisticsNumber;
                }
                Info.IsEnable = false;
                base.XMClaimInfoService.InsertXMClaimInfo(Info);

                foreach (GridViewRow list in grdvClaimType.Rows)
                {
                    decimal Todecimal = 0;
                    HiddenField hiddCodeID = list.FindControl("hiddCodeID") as HiddenField;
                    TextBox txtClaimAcount = list.FindControl("txtClaimAcount") as TextBox;
                    TextBox txtClaimReason = list.FindControl("txtClaimReason") as TextBox;
                    TextBox txtResponsiblePerson = list.FindControl("txtResponsiblePerson") as TextBox;
                    CheckBox ckbIsComfirm = list.FindControl("cbkIConfirm") as CheckBox;
                    CheckBoxList cblDamagedCondition = list.FindControl("cblDamagedCondition") as CheckBoxList;
                    string DamagedCondition = "";
                    foreach (ListItem li in cblDamagedCondition.Items)
                    {
                        if (li.Selected)
                        {
                            DamagedCondition += DamagedCondition == "" ? li.Value : "," + li.Value;
                        }
                    }

                    if (decimal.TryParse(txtClaimAcount.Text.Trim(), out Todecimal) == false)
                    {
                        base.ShowMessage("金额数字类型不正确！");
                        return;
                    }
                    HozestERP.BusinessLogic.ManageProject.XMClaimInfoDetail claimDetails = new XMClaimInfoDetail();
                    claimDetails.ClaimInfoID = Info.Id;
                    claimDetails.ClaimTypeID = int.Parse(hiddCodeID.Value);
                    claimDetails.ClaimAcount = decimal.Parse(txtClaimAcount.Text.Trim());
                    claimDetails.IsConfirm = ckbIsComfirm.Checked;
                    claimDetails.Reason = txtClaimReason.Text.Trim();
                    claimDetails.DamagedCondition = DamagedCondition;
                    if (!string.IsNullOrEmpty(txtResponsiblePerson.Text.Trim()))
                    {
                        claimDetails.ResponsiblePerson = txtResponsiblePerson.Text.Trim();
                    }
                    claimDetails.CreateDate = claimDetails.UpdateDate = DateTime.Now;
                    claimDetails.CreateID = claimDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                    claimDetails.IsEnable = false;
                    base.XMClaimInfoDetailService.InsertXMClaimInfoDetail(claimDetails);
                }
                List<XMClaimInfoPicture> PictureList = (List<XMClaimInfoPicture>)Session["XMClaimInfoAdd-PictureList"];
                if (PictureList != null && PictureList.Count > 0)
                {
                    foreach (var picture in PictureList)
                    {
                        picture.ClaimInfoID = Info.Id;
                        base.XMClaimInfoPictureService.InsertXMClaimInfoPicture(picture);
                    }
                    Session["XMClaimInfoAdd-PictureList"] = null;
                }

                BindClaimInfo(Info.Id);
                Id = Info.Id;
            }
            else//编辑
            {
                bool isRight = false;
                foreach (GridViewRow list in grdvClaimType.Rows)
                {
                    decimal Todecimal = 0;
                    TextBox txtClaimAcount = list.FindControl("txtClaimAcount") as TextBox;
                    if (decimal.TryParse(txtClaimAcount.Text.Trim(), out Todecimal) == false)
                    {
                        isRight = true;
                    }
                }
                if (isRight)
                {
                    BindClaimInfo(this.ClaimInfoID);
                    grdvClaimType.Visible = false;
                    base.ShowMessage("金额数字类型不正确！");
                    return;
                }
                string orderCode = txtOrderCode.Text.Trim();
                string realName = txtRealName.Text.Trim();
                string tel = txtTel.Text.Trim();
                string returnCode = txtReturnCode.Text.Trim();
                string LogisticsNumber = this.txtLogisticsNumber.Text.Trim();
                bool isReturn = ckbIsRerturn.Checked;
                if (ddlNick.SelectedValue == "")
                {
                    base.ShowMessage("请选择店铺！");
                    return;
                }
                int nickID = Convert.ToInt16(ddlNick.SelectedValue);
                if (nickID == -1 || nickID == 99)
                {
                    base.ShowMessage("请选择店铺！");
                    return;
                }
                var claimInfo = base.XMClaimInfoService.GetXMClaimInfoById(this.ClaimInfoID);
                if (claimInfo != null)
                {
                    claimInfo.OrderCode = orderCode;
                    claimInfo.FullName = realName;
                    claimInfo.Tel = tel;
                    claimInfo.ReturnRef = returnCode;
                    claimInfo.IsReturn = isReturn;
                    claimInfo.NickId = nickID;
                    claimInfo.LogisticsNumber = LogisticsNumber;
                    claimInfo.UpdateID = HozestERPContext.Current.User.CustomerID;
                    claimInfo.UpdateDate = DateTime.Now;
                    base.XMClaimInfoService.UpdateXMClaimInfo(claimInfo);
                }
                foreach (GridViewRow list in grdvClaimInfo.Rows)
                {
                    decimal Todecimal = 0;
                    HiddenField hiddCodeID = list.FindControl("hiddCodeID") as HiddenField;
                    TextBox txtClaimAcount = list.FindControl("txtClaimAcount") as TextBox;
                    //TextBox txtClaimReason = list.FindControl("txtClaimReason") as TextBox;
                    DropDownList ddlReason= list.FindControl("ddlReason") as DropDownList;
                    TextBox txtResponsiblePerson = list.FindControl("txtResponsiblePerson") as TextBox;
                    CheckBox ckbIsComfirm = list.FindControl("cbkIConfirm") as CheckBox;
                    CheckBoxList cblDamagedCondition = list.FindControl("cblDamagedCondition") as CheckBoxList;
                    string DamagedCondition = "";
                    foreach (ListItem li in cblDamagedCondition.Items)
                    {
                        if (li.Selected)
                        {
                            DamagedCondition += DamagedCondition == "" ? li.Value : "," + li.Value;
                        }
                    }

                    if (decimal.TryParse(txtClaimAcount.Text.Trim(), out Todecimal) == false)
                    {
                        base.ShowMessage("金额数字类型不正确！");
                        return;
                    }
                    var claimDetails = base.XMClaimInfoDetailService.GetXMClaimInfoDetailListByClaimInfoID(this.ClaimInfoID);
                    if (claimDetails != null && claimDetails.Count > 0)
                    {
                        foreach (XMClaimInfoDetail detail in claimDetails)
                        {
                            if (hiddCodeID.Value == detail.ClaimTypeID.ToString())//更新
                            {
                                detail.ClaimAcount = decimal.Parse(txtClaimAcount.Text.Trim());
                                //detail.Reason = txtClaimReason.Text.Trim();
                                detail.Reason = ddlReason.SelectedValue.Trim();
                                if (!string.IsNullOrEmpty(txtResponsiblePerson.Text.Trim()))
                                {
                                    detail.ResponsiblePerson = txtResponsiblePerson.Text.Trim();
                                }
                                detail.IsConfirm = ckbIsComfirm.Checked;
                                detail.DamagedCondition = DamagedCondition;
                                detail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                detail.UpdateDate = DateTime.Now;
                                base.XMClaimInfoDetailService.UpdateXMClaimInfoDetail(detail);
                            }
                        }
                    }
                }

                var pictureList = base.XMClaimInfoPictureService.GetXMClaimInfoPictureListByClaimInfoID(this.ClaimInfoID);
                List<XMClaimInfoPicture> PictureList = (List<XMClaimInfoPicture>)Session["XMClaimInfoAdd-PictureList"];
                if (PictureList != null && PictureList.Count > 0)
                {
                    if (pictureList.Count > 0)
                    {
                        var PictureId = PictureList.Select(x => x.ID).ToList();
                        foreach (var picture in pictureList)
                        {
                            if (!PictureId.Contains(picture.ID))
                            {
                                picture.IsEnable = true;
                                picture.UpdateDate = DateTime.Now;
                                picture.UpdateID = HozestERPContext.Current.User.CustomerID;
                                base.XMClaimInfoPictureService.UpdateXMClaimInfoPicture(picture);
                            }
                        }
                    }

                    foreach (var Info in PictureList)
                    {
                        if (Info.ID == 0)
                        {
                            Info.ClaimInfoID = this.ClaimInfoID;
                            base.XMClaimInfoPictureService.InsertXMClaimInfoPicture(Info);
                        }
                    }
                    Session["XMClaimInfoAdd-PictureList"] = null;
                }

                BindClaimInfo(this.ClaimInfoID);
                cblClaimType.Enabled = false;
            }

            List<XMClaimInfoProductDetails> ProductDetails = (List<XMClaimInfoProductDetails>)Session["XMClaimInfoAdd-ProductDetailsList"];
            if (ProductDetails != null && ProductDetails.Count > 0)
            {
                foreach (var Info in ProductDetails)
                {
                    Info.ClaimInfoID = Id;
                    base.XMClaimInfoProductDetailsService.InsertXMClaimInfoProductDetails(Info);
                }
                Session["XMClaimInfoAdd-ProductDetailsList"] = null;
            }

            grdvClaimType.Visible = false;
            base.ShowMessage("操作成功！");
        }

        protected void txtLogisticsNumber_Changed(object sender, EventArgs e)
        {
            if (this.grdvClaimProductDetails.Rows.Count == 0)
            {
                int no = 0;
                string LogisticsNumber = this.txtLogisticsNumber.Text.Trim();
                if (LogisticsNumber != "")
                {
                    var Delivery = base.XMDeliveryService.GetXMDeliveryListByLogisticsNumber(LogisticsNumber);
                    if (Delivery != null && Delivery.Count > 0)
                    {
                        List<XMClaimInfoProductDetails> list = new List<XMClaimInfoProductDetails>();
                        foreach (var Info in Delivery[0].XM_Delivery_Details)
                        {
                            XMClaimInfoProductDetails one = new XMClaimInfoProductDetails();
                            one.ID = no;
                            one.ClaimInfoID = ClaimInfoID;
                            one.PlatformMerchantCode = Info.PlatformMerchantCode;
                            one.PrdouctName = Info.PrdouctName;
                            one.Specifications = Info.Specifications;
                            one.ProductNum = Info.ProductNum;
                            one.IsEnabled = false;
                            Info.CreateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                            Info.CreateDate = DateTime.Now;
                            Info.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            list.Add(one);
                            no++;
                        }
                        Session["XMClaimInfoAdd-ProductDetailsList"] = list;
                        Session["XMClaimInfoAdd-LogisticsNumber"] = LogisticsNumber;
                        BindProductDetails();
                    }
                }
            }
            else
            {
                this.txtLogisticsNumber.Text = (string)Session["XMClaimInfoAdd-LogisticsNumber"];
                base.ShowMessage("已存在商品信息，请先删除所有商品后，再修改物流单号！");
                return;
            }
        }

        protected void grdvClaimProductDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdvClaimProductDetails.EditIndex = e.NewEditIndex;
            BindProductDetails();

            int Id = 0;
            var row = this.grdvClaimProductDetails.Rows[e.NewEditIndex];
            int.TryParse(this.grdvClaimProductDetails.DataKeys[e.NewEditIndex].Value.ToString(), out Id);

            XMClaimInfoProductDetails Info = new XMClaimInfoProductDetails();
            List<XMClaimInfoProductDetails> list = (List<XMClaimInfoProductDetails>)Session["XMClaimInfoAdd-ProductDetailsList"];
            if (list != null && list.Count > 0)
            {
                Info = list[Id];
            }
            else
            {
                var ClaimInfo = base.XMClaimInfoProductDetailsService.GetXMClaimInfoProductDetailsByID(Id);
                if (ClaimInfo != null)
                {
                    Info = ClaimInfo;
                }
            }

            TextBox txtProductNum = (TextBox)row.FindControl("txtProductNum");
            if (txtProductNum != null)
            {
                txtProductNum.Text = Info.ProductNum.ToString();
            }
        }

        protected void grdvClaimProductDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdvClaimProductDetails.EditIndex = -1;
            BindProductDetails();
        }

        protected void grdvClaimProductDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id = 0;
            int ProductNum = 0;
            if (int.TryParse(this.grdvClaimProductDetails.DataKeys[e.RowIndex].Value.ToString(), out Id))
            {
                var row = this.grdvClaimProductDetails.Rows[e.RowIndex];
                var txtProductNum = row.FindControl("txtProductNum") as TextBox;

                if (string.IsNullOrEmpty(txtProductNum.Text.Trim()))
                {
                    base.ShowMessage("数量不能为空！");
                    return;
                }
                else if (!int.TryParse(txtProductNum.Text.Trim(), out ProductNum))
                {
                    base.ShowMessage("数量必须为整数！");
                    return;
                }

                List<XMClaimInfoProductDetails> list = (List<XMClaimInfoProductDetails>)Session["XMClaimInfoAdd-ProductDetailsList"];
                if (list != null && list.Count > 0)
                {
                    //List<XMClaimInfoProductDetails> list = (List<XMClaimInfoProductDetails>)Session["XMClaimInfoAdd-ProductDetailsList"];
                    if (list.Count > Id)
                    {
                        list[Id].ProductNum = ProductNum;
                    }
                    Session["XMClaimInfoAdd-ProductDetailsList"] = list;
                }
                else
                {
                    var Info = base.XMClaimInfoProductDetailsService.GetXMClaimInfoProductDetailsByID(Id);
                    if (Info != null)
                    {
                        Info.ProductNum = ProductNum;
                        Info.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        Info.UpdateDate = DateTime.Now;
                        base.XMClaimInfoProductDetailsService.UpdateXMClaimInfoProductDetails(Info);
                    }
                }

                grdvClaimProductDetails.EditIndex = -1;
                base.ShowMessage("修改成功！");
                BindProductDetails();
            }
        }

        protected void grdvClaimProductDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            if (int.TryParse(this.grdvClaimProductDetails.DataKeys[e.RowIndex].Value.ToString(), out Id))
            {
                List<XMClaimInfoProductDetails> list = (List<XMClaimInfoProductDetails>)Session["XMClaimInfoAdd-ProductDetailsList"];
                if (list != null && list.Count > 0)
                {
                    list.RemoveAt(Id);
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].ID = i;
                    }
                    Session["XMClaimInfoAdd-ProductDetailsList"] = list;
                }
                else
                {
                    var Info = base.XMClaimInfoProductDetailsService.GetXMClaimInfoProductDetailsByID(Id);
                    if (Info != null)
                    {
                        Info.IsEnabled = true;
                        Info.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        Info.UpdateDate = DateTime.Now;
                        base.XMClaimInfoProductDetailsService.UpdateXMClaimInfoProductDetails(Info);
                    }
                }

                base.ShowMessage("删除成功！");
                BindProductDetails();
            }
        }

        protected void grdvClaimProductDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void grdvClaimType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMClaimInfo;

                //查看详情
                CheckBoxList cblDamagedCondition = e.Row.FindControl("cblDamagedCondition") as CheckBoxList;

                if (cblDamagedCondition != null)
                {
                    var List = base.CodeService.GetCodeListInfoByCodeTypeID(242, false);//受损情况
                    cblDamagedCondition.DataSource = List;
                    cblDamagedCondition.DataTextField = "CodeName";
                    cblDamagedCondition.DataValueField = "CodeID";
                    cblDamagedCondition.DataBind();
                }
            }
        }

        protected void grdvClaimInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var info = e.Row.DataItem as XMClaimInfoDetail;

                //查看详情
                CheckBoxList cblDamagedCondition = e.Row.FindControl("cblDamagedCondition") as CheckBoxList;
                DropDownList ddlReason= e.Row.FindControl("ddlReason") as DropDownList;

                if (cblDamagedCondition != null)
                {
                    var List = base.CodeService.GetCodeListInfoByCodeTypeID(242, false);//受损情况
                    cblDamagedCondition.DataSource = List;
                    cblDamagedCondition.DataTextField = "CodeName";
                    cblDamagedCondition.DataValueField = "CodeID";
                    cblDamagedCondition.DataBind();

                    if (info.DamagedCondition != null)
                    {
                        string[] damagedCondition = info.DamagedCondition.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (ListItem li in cblDamagedCondition.Items)
                        {
                            if (damagedCondition.Contains(li.Value))
                            {
                                li.Selected = true;
                            }
                        }
                    }
                }

                if (ddlReason != null)
                {
                    int ProjectID = int.Parse(ddXMProject.SelectedValue);
                    var list = XMClaimReasonService.getList(a => a.ProjectID == ProjectID).ToList();
                    ddlReason.DataSource = list;
                    ddlReason.DataTextField = "Reason";
                    ddlReason.DataValueField = "Reason";
                    ddlReason.DataBind();
                    ddlReason.Items.Insert(0, new ListItem("---所有---", "-1"));
                    if(string.IsNullOrEmpty(info.Reason))
                    {
                        ddlReason.Items[0].Selected = true;
                    }
                    else
                    {
                        ddlReason.SelectedValue = info.Reason;
                    }
                }
            }
        }

        protected void imgFigureMapDel_Click(object sender, EventArgs e)
        {
            string name = (sender as ImageButton).CommandName;
            int id = int.Parse(name);
            MapDelete(id);
        }

        public void MapDelete(int no)
        {
            if (Session["XMClaimInfoAdd-PictureList"] == null)
            {
                base.ShowMessage("您还未上传此图！");
                return;
            }

            List<XMClaimInfoPicture> list = (List<XMClaimInfoPicture>)Session["XMClaimInfoAdd-PictureList"];
            if (list.Count < no)
            {
                base.ShowMessage("您还未上传此图！");
                return;
            }
            list.RemoveAt(no - 1);
            Session["XMClaimInfoAdd-PictureList"] = list;

            LoadPicture(list);
        }

        public void LoadPicture(List<XMClaimInfoPicture> list)
        {
            if (list.Count == 0)
            {
                this.ImgFigure1.Src = this.ImgFigure2.Src = this.ImgFigure3.Src = this.ImgFigure4.Src = this.ImgFigure5.Src = this.ImgFigure6.Src = "";
            }
            else if (list.Count == 1)
            {
                this.ImgFigure1.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[0].PicturePath;
                this.Link1.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[0].PicturePath;
                this.ImgFigure2.Src = this.ImgFigure3.Src = this.ImgFigure4.Src = this.ImgFigure5.Src = this.ImgFigure6.Src = "";
            }
            else if (list.Count == 2)
            {
                this.ImgFigure1.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[0].PicturePath;
                this.ImgFigure2.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[1].PicturePath;
                this.Link1.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[0].PicturePath;
                this.Link2.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[1].PicturePath;
                this.ImgFigure3.Src = this.ImgFigure4.Src = this.ImgFigure5.Src = this.ImgFigure6.Src = "";
            }
            else if (list.Count == 3)
            {
                this.ImgFigure1.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[0].PicturePath;
                this.ImgFigure2.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[1].PicturePath;
                this.ImgFigure3.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[2].PicturePath;
                this.Link1.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[0].PicturePath;
                this.Link2.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[1].PicturePath;
                this.Link3.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[2].PicturePath;
                this.ImgFigure4.Src = this.ImgFigure5.Src = this.ImgFigure6.Src = "";
            }
            else if (list.Count == 4)
            {
                this.ImgFigure1.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[0].PicturePath;
                this.ImgFigure2.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[1].PicturePath;
                this.ImgFigure3.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[2].PicturePath;
                this.ImgFigure4.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[3].PicturePath;
                this.Link1.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[0].PicturePath;
                this.Link2.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[1].PicturePath;
                this.Link3.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[2].PicturePath;
                this.Link4.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[3].PicturePath;
                this.ImgFigure5.Src = this.ImgFigure6.Src = "";
            }
            else if (list.Count == 5)
            {
                this.ImgFigure1.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[0].PicturePath;
                this.ImgFigure2.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[1].PicturePath;
                this.ImgFigure3.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[2].PicturePath;
                this.ImgFigure4.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[3].PicturePath;
                this.ImgFigure5.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[4].PicturePath;
                this.Link1.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[0].PicturePath;
                this.Link2.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[1].PicturePath;
                this.Link3.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[2].PicturePath;
                this.Link4.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[3].PicturePath;
                this.Link5.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[4].PicturePath;
                this.ImgFigure6.Src = "";
            }
            else if (list.Count == 6)
            {
                this.ImgFigure1.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[0].PicturePath;
                this.ImgFigure2.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[1].PicturePath;
                this.ImgFigure3.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[2].PicturePath;
                this.ImgFigure4.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[3].PicturePath;
                this.ImgFigure5.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[4].PicturePath;
                this.ImgFigure6.Src = CommonHelper.GetStoreLocation() + "Upload/SmallClaimInfoPicture/" + list[5].PicturePath;
                this.Link1.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[0].PicturePath;
                this.Link2.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[1].PicturePath;
                this.Link3.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[2].PicturePath;
                this.Link4.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[3].PicturePath;
                this.Link5.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[4].PicturePath;
                this.Link6.NavigateUrl = CommonHelper.GetStoreLocation() + "Upload/BigClaimInfoPicture/" + list[5].PicturePath;
            }
        }

        protected void btnFigureMap_Click(object sender, EventArgs e)
        {
            var fileName = this.FileUpFigureMap.FileName;
            if (string.IsNullOrEmpty(fileName))
            {
                base.ShowMessage("请选择上传图片！");
                return;
            }
            UpPicture(fileName);
        }

        public void UpPicture(string fileName)
        {
            string strFileName = fileName;
            string SmallPath = HttpContext.Current.Server.MapPath("~") + "Upload\\SmallClaimInfoPicture\\";
            string BigPath = HttpContext.Current.Server.MapPath("~") + "Upload\\BigClaimInfoPicture\\";
            Guid TaggantID = Guid.NewGuid();

            List<XMClaimInfoPicture> list = new List<XMClaimInfoPicture>();
            if (Session["XMClaimInfoAdd-PictureList"] != null)
            {
                list = (List<XMClaimInfoPicture>)Session["XMClaimInfoAdd-PictureList"];
                if (list.Count == 6)
                {
                    base.ShowMessage("最多只能上传6张图片！");
                    return;
                }
            }

            //判断上传图片格式
            string fileExtension = System.IO.Path.GetExtension(fileName);

            if (fileExtension.ToLower() != ".png" && fileExtension.ToLower() != ".jpg")
            {
                base.ShowMessage("请上传jpg或png格式的图片！");
                return;
            }
            //判断上传图片大小
            var setting = base.SettingManager.GetSettingByName("IDCard.ImgSiz");//公共参数
            if (setting != null)
            {
                if (FileUpFigureMap.PostedFile.ContentLength > Convert.ToInt32(setting.Value))
                {
                    base.ShowMessage("请选择不大于1M的图片上传！");
                    return;
                }
            }

            if (!Directory.Exists(SmallPath))
            {
                Directory.CreateDirectory(SmallPath);
            }
            if (!Directory.Exists(BigPath))
            {
                Directory.CreateDirectory(BigPath);
            }

            string[] strExtensions = fileName.Split('.');
            string strExtension = string.Empty;
            if (strExtensions.Length > 0)
            {
                Random myRandom = new Random();
                strExtension = strExtensions[strExtensions.Length - 1];
                strFileName = DateTime.Now.ToString("yyMMddHHmmssfff") + myRandom.Next(100, 999).ToString() + "." + strExtension;
            }

            FileUpFigureMap.SaveAs(BigPath + strFileName);
            ZoomPicture.GenerateHighThumbnail(BigPath + strFileName, SmallPath + strFileName, 87, 87);

            XMClaimInfoPicture info = new XMClaimInfoPicture();
            info.ID = 0;
            info.PicturePath = strFileName;
            info.IsEnable = false;
            info.CreateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
            info.CreateDate = DateTime.Now;
            info.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
            info.UpdateDate = DateTime.Now;
            list.Add(info);
            Session["XMClaimInfoAdd-PictureList"] = list;

            LoadPicture(list);
        }

        public void Face_Init()
        {

        }

        public void SetTrigger()
        {

        }

        public int ClaimInfoID
        {
            get
            {
                return CommonHelper.QueryStringInt("ClaimInfoID");
            }
        }

        /// <summary>
        /// 判断返现是添加还是修改
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