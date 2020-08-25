using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageBulletin;
using HozestERP.BusinessLogic.Profile;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageBulletin
{
    public partial class BulletinDetail : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.uploadfile.TaggantID = Guid.NewGuid();
                var bulletin = base.BulletinService.GetBulletinByBulletinID(this.BulletinID);
                if (bulletin != null)
                {
                    this.txtBulletinTitle.Text = bulletin.BulletinTitle;
                    this.txtBulletinStatus.Text = CommonHelper.GetDescription(typeof(BulletinStatusEnum), bulletin.BulletinStatuss.ToString());
                    this.ddlBulletinType.SelectedValue = bulletin.BulletinTypeID;
                    this.ddlPriorType.SelectedValue = bulletin.PriorTypeID;
                    this.txtEffectiveDate.SelectedDate = DateTimeHelper.ConvertToUserTime(bulletin.EffectiveDate, DateTimeKind.Utc);
                    this.txtInvalidDate.SelectedDate = DateTimeHelper.ConvertToUserTime(bulletin.InvalidDate, DateTimeKind.Utc);
                    this.SelectMapping.SelectCustomers = bulletin.SCustomerInfo.ToList();
                    this.txtRemark.Value = bulletin.Remark;
                    if (bulletin.BulletinStatuss.ToString() == BulletinStatusEnum.Released.ToString() || bulletin.BulletinStatuss.ToString() == BulletinStatusEnum.End.ToString())
                    {
                        this.btnSave.Visible = false;
                        this.uploadfile.ReadOnly = true;
                    }
                    else
                    {
                        this.uploadfile.ReadOnly = false;
                    }
                    this.uploadfile.ObjectID = bulletin.BulletinID;
                }
                else
                {
                    Clear();
                    this.uploadfile.ReadOnly = false;
                }
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "";
        }

        private void Clear()
        {
            this.txtBulletinTitle.Text = string.Empty;
            this.txtBulletinStatus.Text = CommonHelper.GetDescription(typeof(BulletinStatusEnum), BulletinStatusEnum.Found.ToString());
            this.ddlBulletinType.SelectedValue = 0;
            this.ddlPriorType.SelectedValue = 0;
            this.txtEffectiveDate.SelectedDate = DateTime.Now;
            this.txtInvalidDate.SelectedDate = DateTime.Now;
            this.SelectMapping.SelectCustomers = new List<CustomerInfo>();
            this.txtRemark.Value = string.Empty;
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("");
        }

        public void SetTrigger()
        {
            //this.Master.SetTrigger(this.btnSave.UniqueID, this.Page);
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    var bulletin = base.BulletinService.GetBulletinByBulletinID(this.BulletinID);
                    if (bulletin != null)
                    {
                        bulletin.BulletinTitle = this.txtBulletinTitle.Text.Trim();
                        bulletin.BulletinTypeID = this.ddlBulletinType.SelectedValue;
                        bulletin.PriorTypeID = this.ddlPriorType.SelectedValue;
                        bulletin.EffectiveDate = this.txtEffectiveDate.SelectedDate.GetValueOrDefault();
                        bulletin.InvalidDate = this.txtInvalidDate.SelectedDate.GetValueOrDefault();
                        bulletin.Remark = this.txtRemark.Value.Trim();
                        base.BulletinService.UpdateBulletin(bulletin);
                        base.BulletinService.DeleteBulletinCusotmer(this.BulletinID);
                    }
                    else
                    {
                        bulletin = base.BulletinService.InsertBulletin(new Bulletin()
                        {
                            BulletinTitle = this.txtBulletinTitle.Text.Trim()
                            ,
                            BulletinTypeID = this.ddlBulletinType.SelectedValue
                            ,
                            PriorTypeID = this.ddlPriorType.SelectedValue
                            ,
                            EffectiveDate = this.txtEffectiveDate.SelectedDate.GetValueOrDefault()
                            ,
                            InvalidDate = this.txtInvalidDate.SelectedDate.GetValueOrDefault()
                            ,
                            BulletinStatus = (int)BulletinStatusEnum.Found
                            ,
                            Remark = this.txtRemark.Value.Trim()
                            ,
                            Deleted = false
                            ,
                            Published = true
                            ,
                            DisplayOrder = 1
                            ,
                            BulletinCode = "1"
                            ,
                            CreatorID = HozestERPContext.Current.User.CustomerID
                            ,
                            Created = DateTime.Now
                            ,
                            ReleasedDate = DateTime.Now

                        });
                    }
                    foreach (var item in SelectMapping.SelectCustomers)
                    {
                        base.BulletinService.AddBulletinCusotmer(item.CustomerID, bulletin.BulletinID);
                    }
                    // 保存附件
                    this.uploadfile.SaveUpdateFile(bulletin.BulletinID);
                    base.ShowMessage("保存成功.");
                    Response.Redirect("BulletinManager.aspx");
                }
                catch (Exception err)
                {
                    this.ProcessException(err);
                }
            }
        }

        public int BulletinID
        {
            get
            {
                return CommonHelper.QueryStringInt("BulletinID");
            }
        }
    }
}