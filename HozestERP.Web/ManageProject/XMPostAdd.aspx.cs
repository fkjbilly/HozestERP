using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using System.Transactions;
using HozestERP.BusinessLogic.Infrastructure;
using JdSdk.Domain;
using Top.Api.Domain;

namespace HozestERP.Web.ManageProject
{

    public partial class XMPostAdd : BaseAdministrationPage, IEditPage
    {


        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("btnSave", "ManageProject.XMPostAdd.Save"); //保存

                return buttons;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDate();

            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        private void LoadDate()
        {

            if (this.PostId == -1)
            {
                this.txtPostCode.Value = "";
                //this.hfPostId.Value = "";
                this.txtOrderType.Text = "";
                //this.hfOrderTypeId.Value = "";
                this.IsEnable.Checked = false;

            }
            else
            {
                var xMPost = base.XMPostService.GetXMPostById(this.PostId);
                if (xMPost != null)
                {
                    this.txtPostCode.Value = xMPost.Post != null ? xMPost.Post.ToString() : "";
                    //this.hfOrderTypeId.Value = xMPost.OrderID != null ? xMPost.OrderID.ToString() : "";
                    this.txtOrderType.Text = xMPost.OrderID != null ? xMPost.OrderID.ToString() : "";
                    if (xMPost.IsEnable != true)
                    {
                        this.IsEnable.Checked = false;
                    }
                    else
                    {
                        this.IsEnable.Checked = true;
                    }

                    // this.txtDeduction.Text = xMScalping.Deduction != null ? xMScalping.Deduction.Value.ToString() : "";
                    //this.ddType.SelectedValue = xMScalping.Type != null ? xMScalping.Type.Value : -1;
                    //this.txtLeader.SelectSingleCustomer = base.CustomerInfoService.GetCustomerInfoByID(xMScalping.Leader.Value);
                    //if (this.txtLeader.SelectSingleCustomer != null)
                    //    this.txtLeader.Value = this.txtLeader.SelectSingleCustomer.FullName;

                }
            }



        }
        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("项目部 > 岗位管理 ");

        }

        public void SetTrigger()
        {
            // this.Master.SetTrigger(this.btnSave.UniqueID, this.Page); 

        }
        #endregion


        /// <summary>
        /// 保存岗位信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        var txtPostCode = this.txtPostCode.Value;
                        var txtOrderType = this.txtOrderType.Text;
                        var IsEnable = this.IsEnable.Checked;
                        var updatorID = HozestERPContext.Current.User.CustomerID;
                        var updateTime = DateTime.Now;

                        var xMPost = base.XMPostService.GetXMPostById(this.PostId);
                        if (xMPost == null)
                        {
                            XMPost xMPostNew = new XMPost();
                            xMPostNew.Post = txtPostCode;
                            xMPostNew.CreatorID = updatorID;
                            xMPostNew.CreatorTime = updateTime;
                            xMPostNew.IsEnable = IsEnable;
                            base.XMPostService.InsertXMPost(xMPostNew);
                            //base.ShowMessage("保存成功");

                            this.Master.JsWrite("alert('保存成功.');window.PopClose();", "");
                            scope.Complete();

                        }
                        else
                        {
                            XMPost xMPostNew = base.XMPostService.GetXMPostById(this.PostId);
                            xMPostNew.Post = txtPostCode;
                            xMPostNew.UpdatorID = updatorID;
                            xMPostNew.UpdateTime = updateTime;
                            xMPostNew.IsEnable = IsEnable;

                            base.XMPostService.UpdateXMPost(xMPostNew);
                            //base.ShowMessage("保存成功");

                            this.Master.JsWrite("alert('保存成功.');window.PopClose();", "");
                            scope.Complete();
                        }
                    }
                    catch (Exception err)
                    {
                        this.ProcessException(err);
                    }
                }
            }
        }

        /// <summary>
        /// 岗位表id 
        /// </summary>
        public int PostId
        {
            get
            {
                return CommonHelper.QueryStringInt("PostId");
            }
        }
    }
}