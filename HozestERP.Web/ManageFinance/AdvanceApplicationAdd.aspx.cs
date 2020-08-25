using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageFinance;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageFinance
{ 

    public partial class AdvanceApplicationAdd : BaseAdministrationPage, IEditPage
    {


        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>(); 
                buttons.Add("btnSave", "ManageFinance.AdvanceApplicationAdd.Save"); //保存

                return buttons;
            }
        }
         
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CommonMethod.DropDownListDepartment(this.ddApplicationDepartment, false);//申请部门

                LoadDate(); 
                 
            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        private void LoadDate()
        {
             
            if (this.ScalpingId ==-1)
            {
                this.DIVLableScalpingNo.Visible = false;
                this.DIVScalpingNo.Visible = true;
                //this.txtScalpingNo.Text = string.Empty;
                this.txtApplicationPayee.Text = string.Empty;
                this.txtTheAdvanceSubject.Text = string.Empty;
                this.txtTheAdvanceMoney.Text = "0";
                //this.txtForecastReturnTime.Value = (DateTime.Now.AddDays(+7)).ToString();
                 var setting = base.SettingManager.GetSettingByName("AdvanceApplication.ForecastReturnTime");

                 if (setting != null)
                 {
                     this.lblForecastReturnTime.Text = DateTime.Now.AddDays(Convert.ToInt32(setting.Value)).ToString("yyyy-MM-dd");
                 }
                this.txtSubject.Text = string.Empty;
                this.txtApplicants.Value = string.Empty;   
            }
            else
            {
                this.DIVLableScalpingNo.Visible = true;
                this.DIVScalpingNo.Visible = false;
                this.hdScalpingId.Value = this.ScalpingId.ToString();
               // this.txtScalpingNo.Text = "";
            }


            if (this.ddTheAdvanceType.SelectedValue.Trim() == "343")
            { 
                this.TheAdvanceTypeSDZZ();
            }
            else
            {
                this.TD2.Visible = false;
            }

        }  
        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("财务部 > 暂支申请 ");
           
            //暂支类型
            this.ddTheAdvanceType.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(184, false);
            ddTheAdvanceType.DataSource = codeList;
            ddTheAdvanceType.DataTextField = "CodeName";
            ddTheAdvanceType.DataValueField = "CodeID";
            ddTheAdvanceType.DataBind();   

        }

        public void SetTrigger()
        {
            // this.Master.SetTrigger(this.btnSave.UniqueID, this.Page); 
            
        }
        #endregion

         
        /// <summary>
        /// 保存暂支申请信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                { 
                    string ddTheAdvanceType = this.ddTheAdvanceType.SelectedValue.Trim();

                    //查询暂支单预计归还日期
                    var setting = base.SettingManager.GetSettingByName("AdvanceApplication.ForecastReturnTime");

                    if (setting != null)
                    {
                        //刷单暂支
                        if (ddTheAdvanceType == "343")
                        {
                            #region 根据店铺Id查询 所对应的项目,并查询出该项目所对应的所有店铺

                            int ProjectId = 0;
                            var NickId = Convert.ToInt32(this.hfNickId.Value);
                            var XMNick = base.XMNickService.GetXMNickByID(NickId);
                            if (XMNick != null)
                            {
                                if (XMNick.ProjectId != null)
                                {
                                    ProjectId = XMNick.ProjectId.Value;
                                }
                            }

                            XMProject xMProject = new XMProject();

                            List<int> ProjectIdList = new List<int>();//项目Id

                            List<int> NickIdList = new List<int>();//项目下所有的 店铺Id
                            if (ProjectId > 0)
                            {
                                ProjectIdList.Add(ProjectId);
                                //所有店铺
                                var XMNickProjectIdList = base.XMNickService.GetXMNickListByProjectId(ProjectIdList);
                                //所有店铺Id
                                NickIdList = XMNickProjectIdList.Select(p => p.nick_id).ToList();

                                xMProject = base.XMProjectService.GetXMProjectById(ProjectId);
                            }
                            #endregion

                            List<AdvanceApplication> AdvanceApplicationList = new List<AdvanceApplication>();
                            if (NickIdList.Count > 0)
                            {
                                var AdvanceApplicationListByNickId = base.AdvanceApplicationService.GetAdvanceApplicationListByNickId(NickIdList);

                                if (AdvanceApplicationListByNickId.Count > 0)
                                {

                                    AdvanceApplicationList = AdvanceApplicationListByNickId.Where(p => p.ForecastReturnTime.Value < DateTime.Now.AddDays(1) && p.AdvanceState==(int)AdvanceStateEnum.TheAdvanceUse).ToList();
                                }
                            }

                            if (AdvanceApplicationList.Count > 0)
                            {
                                string ProjectName = "";

                                if (xMProject != null)
                                {

                                    ProjectName = xMProject.ProjectName;
                                }
                                base.ShowMessage(ProjectName + "项目有其它店铺未在归还日期内还款,请先还款!");
                                return; 
                            }
                            else
                            {
                                #region 新增暂支
                                string ddApplicationDepartment = this.ddApplicationDepartment.SelectedValue.Trim();
                                string txtApplicationPayee = this.txtApplicationPayee.Text;
                                string txtTheAdvanceSubject = this.txtTheAdvanceSubject.Text;
                                string txtTheAdvanceMoney = this.txtTheAdvanceMoney.Text;
                                string lblForecastReturnTime = this.lblForecastReturnTime.Text.Trim();
                                string txtSubject = this.txtSubject.Text;
                                int txtApplicants = this.txtApplicants.SelectSingleCustomer.CustomerID;// this.txtApplicants.Text; 

                                int scalpingId = 0;
                                this.lblMag.Visible = false;
                                if (ddTheAdvanceType == "343")
                                {
                                    int.TryParse(this.hfScalpingId.Value, out scalpingId);
                                    var scalping = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(scalpingId);
                                    if (scalping == null)
                                    {
                                        this.lblMag.Visible = true;
                                        this.lblMag.Text = "刷单单号有误";
                                        this.hfScalpingId.Value = "";
                                        this.txtScalpingCode.Value = "";
                                        this.hfNickId.Value = "";
                                        this.txtNickName.Text = "";
                                        this.hfPlatformTypeId.Value = "";
                                        this.txtPlatformType.Text = "";
                                        ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "advanceApplicationDetailManage", "autoCompleteBindScalpingCodeManag()", true);
                                        return;
                                    }
                                    var AdvanceApplicationListByscalpingId = base.AdvanceApplicationService.GetAdvanceApplicationByScalpingId(scalpingId);
                                    if (AdvanceApplicationListByscalpingId.Count > 0)
                                    {

                                        this.lblMag.Visible = true;
                                        this.lblMag.Text = "刷单单号已存在";
                                        this.hfScalpingId.Value = "";
                                        this.txtScalpingCode.Value = "";
                                        this.hfNickId.Value = "";
                                        this.txtNickName.Text = "";
                                        this.hfPlatformTypeId.Value = "";
                                        this.txtPlatformType.Text = "";
                                        ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "advanceApplicationDetailManage", "autoCompleteBindScalpingCodeManag()", true);
                                        return;
                                    }
                                }

                                if (this.ScalpingId == -1)
                                {

                                    AdvanceApplication advanceApplication = new AdvanceApplication();

                                    if (ddTheAdvanceType == "343")
                                    {
                                        advanceApplication.PlatformTypeId = Convert.ToInt32(this.hfPlatformTypeId.Value);
                                        advanceApplication.NickId = Convert.ToInt32(this.hfNickId.Value);
                                        advanceApplication.ScalpingId = scalpingId;
                                    }
                                    advanceApplication.TheAdvanceType = Convert.ToInt32(ddTheAdvanceType);
                                    advanceApplication.ApplicationDepartment = Convert.ToInt32(ddApplicationDepartment);
                                    advanceApplication.ApplicationPayee = txtApplicationPayee;
                                    advanceApplication.TheAdvanceSubject = txtTheAdvanceSubject;
                                    advanceApplication.TheAdvanceMoney = Convert.ToDecimal(txtTheAdvanceMoney);
                                    if (lblForecastReturnTime != "")
                                    {
                                        advanceApplication.ForecastReturnTime = Convert.ToDateTime(lblForecastReturnTime);
                                    }
                                    advanceApplication.Subject = txtSubject;
                                    advanceApplication.Applicants = txtApplicants;
                                    advanceApplication.ManagerIsAudit = false;//部门审核
                                    advanceApplication.FinanceIsAudit = false;//财务审核
                                    advanceApplication.DirectorIsAudit = false;//总监审核
                                    advanceApplication.FinanceOkIsAudit = false;//财务确认（打款）
                                    advanceApplication.OperationIsAudit = false;//运营确认（运营确认是否收到款）
                                    advanceApplication.FinanceAdvanceEndIsAudit = false;//财务确认（暂支结束）
                                    advanceApplication.AdvanceState = (int)AdvanceStateEnum.TheAdvanceNoneDealWith;
                                    //advanceApplication.FinanceIsConfirm = false;
                                    advanceApplication.IsEnable = false;
                                    advanceApplication.CreatorID = HozestERPContext.Current.User.CustomerID;
                                    advanceApplication.CreateTime = DateTime.Now;
                                    advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    advanceApplication.UpdateTime = DateTime.Now;

                                    base.AdvanceApplicationService.InsertAdvanceApplication(advanceApplication);

                                    base.ShowMessage("保存成功");


                                }
                                else
                                {
                                    AdvanceApplication advanceApplication = new AdvanceApplication();
                                    if (ddTheAdvanceType == "343")
                                    {
                                        advanceApplication.PlatformTypeId = Convert.ToInt32(this.hfPlatformTypeId.Value);
                                        advanceApplication.NickId = Convert.ToInt32(this.hfNickId.Value);
                                        advanceApplication.ScalpingId = Convert.ToInt32(scalpingId);
                                    }
                                    advanceApplication.TheAdvanceType = Convert.ToInt32(ddTheAdvanceType);
                                    advanceApplication.ApplicationDepartment = Convert.ToInt32(ddApplicationDepartment);
                                    advanceApplication.ApplicationPayee = txtApplicationPayee;
                                    advanceApplication.TheAdvanceSubject = txtTheAdvanceSubject;
                                    advanceApplication.TheAdvanceMoney = Convert.ToDecimal(txtTheAdvanceMoney);
                                    if (lblForecastReturnTime != "")
                                    {
                                        advanceApplication.ForecastReturnTime = Convert.ToDateTime(lblForecastReturnTime);
                                    }
                                    advanceApplication.Subject = txtSubject;
                                    advanceApplication.Applicants = txtApplicants;
                                    advanceApplication.ManagerIsAudit = false;//部门审核
                                    advanceApplication.FinanceIsAudit = false;//财务审核
                                    advanceApplication.DirectorIsAudit = false;//总监审核
                                    advanceApplication.FinanceOkIsAudit = false;//财务确认（打款）
                                    advanceApplication.OperationIsAudit = false;//运营确认（运营确认是否收到款）
                                    advanceApplication.FinanceAdvanceEndIsAudit = false;//财务确认（暂支结束）
                                    advanceApplication.AdvanceState = (int)AdvanceStateEnum.TheAdvanceNoneDealWith;
                                    //advanceApplication.FinanceIsConfirm = false;
                                    advanceApplication.IsEnable = false;
                                    advanceApplication.CreatorID = HozestERPContext.Current.User.CustomerID;
                                    advanceApplication.CreateTime = DateTime.Now;
                                    advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                    advanceApplication.UpdateTime = DateTime.Now;

                                    base.AdvanceApplicationService.InsertAdvanceApplication(advanceApplication);

                                    base.ShowMessage("保存成功");
                                }
                                #endregion
                            }
                        }
                        else {//暂支

                            #region 新增暂支
                            string ddApplicationDepartment = this.ddApplicationDepartment.SelectedValue.Trim();
                            string txtApplicationPayee = this.txtApplicationPayee.Text;
                            string txtTheAdvanceSubject = this.txtTheAdvanceSubject.Text;
                            string txtTheAdvanceMoney = this.txtTheAdvanceMoney.Text;
                            string lblForecastReturnTime = this.lblForecastReturnTime.Text.Trim();
                            string txtSubject = this.txtSubject.Text;
                            int txtApplicants = this.txtApplicants.SelectSingleCustomer.CustomerID;// this.txtApplicants.Text; 
                              
                            if (this.ScalpingId == -1)
                            { 
                                AdvanceApplication advanceApplication = new AdvanceApplication(); 
                                advanceApplication.TheAdvanceType = Convert.ToInt32(ddTheAdvanceType);
                                advanceApplication.ApplicationDepartment = Convert.ToInt32(ddApplicationDepartment);
                                advanceApplication.ApplicationPayee = txtApplicationPayee;
                                advanceApplication.TheAdvanceSubject = txtTheAdvanceSubject;
                                advanceApplication.TheAdvanceMoney = Convert.ToDecimal(txtTheAdvanceMoney);
                                if (lblForecastReturnTime != "")
                                {
                                    advanceApplication.ForecastReturnTime = Convert.ToDateTime(lblForecastReturnTime);
                                }
                                advanceApplication.Subject = txtSubject;
                                advanceApplication.Applicants = txtApplicants;
                                advanceApplication.ManagerIsAudit = false;//部门审核
                                advanceApplication.FinanceIsAudit = false;//财务审核
                                advanceApplication.DirectorIsAudit = false;//总监审核
                                advanceApplication.FinanceOkIsAudit = false;//财务确认（打款）
                                advanceApplication.OperationIsAudit = false;//运营确认（运营确认是否收到款）
                                advanceApplication.FinanceAdvanceEndIsAudit = false;//财务确认（暂支结束）
                                advanceApplication.AdvanceState = (int)AdvanceStateEnum.TheAdvanceNoneDealWith;
                                //advanceApplication.FinanceIsConfirm = false;
                                advanceApplication.IsEnable = false;
                                advanceApplication.CreatorID = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.CreateTime = DateTime.Now;
                                advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.UpdateTime = DateTime.Now; 
                                base.AdvanceApplicationService.InsertAdvanceApplication(advanceApplication); 
                                base.ShowMessage("保存成功");


                            }
                            else
                            {
                                AdvanceApplication advanceApplication = new AdvanceApplication();
                               
                                advanceApplication.TheAdvanceType = Convert.ToInt32(ddTheAdvanceType);
                                advanceApplication.ApplicationDepartment = Convert.ToInt32(ddApplicationDepartment);
                                advanceApplication.ApplicationPayee = txtApplicationPayee;
                                advanceApplication.TheAdvanceSubject = txtTheAdvanceSubject;
                                advanceApplication.TheAdvanceMoney = Convert.ToDecimal(txtTheAdvanceMoney);
                                if (lblForecastReturnTime != "")
                                {
                                    advanceApplication.ForecastReturnTime = Convert.ToDateTime(lblForecastReturnTime);
                                }
                                advanceApplication.Subject = txtSubject;
                                advanceApplication.Applicants = txtApplicants;
                                advanceApplication.ManagerIsAudit = false;//部门审核
                                advanceApplication.FinanceIsAudit = false;//财务审核
                                advanceApplication.DirectorIsAudit = false;//总监审核
                                advanceApplication.FinanceOkIsAudit = false;//财务确认（打款）
                                advanceApplication.OperationIsAudit = false;//运营确认（运营确认是否收到款）
                                advanceApplication.FinanceAdvanceEndIsAudit = false;//财务确认（暂支结束）
                                advanceApplication.AdvanceState = (int)AdvanceStateEnum.TheAdvanceNoneDealWith;
                                //advanceApplication.FinanceIsConfirm = false;
                                advanceApplication.IsEnable = false;
                                advanceApplication.CreatorID = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.CreateTime = DateTime.Now;
                                advanceApplication.UpdatorID = HozestERPContext.Current.User.CustomerID;
                                advanceApplication.UpdateTime = DateTime.Now; 
                                base.AdvanceApplicationService.InsertAdvanceApplication(advanceApplication); 
                                base.ShowMessage("保存成功");
                            }
                            #endregion
                        
                        }
                    }
                    else {

                        base.ShowMessage("请联系管理员设置暂支预计归还天数!");
                        return;
                    } 
                    
                }
                catch (Exception err)
                {
                    this.ProcessException(err);
                }
            } 
        }
         
       // private int SetScalpingId;

        protected void ddTheAdvanceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddTheAdvanceType = (DropDownList)sender;
            string projectid = ddTheAdvanceType.SelectedValue.Trim();//暂支类型id

            if (projectid == "343")
            {
                this.TheAdvanceTypeSDZZ();
            }
            else {
                this.TD2.Visible = false; 
            }
               
        }
        //protected void txtScalpingNo_TextChanged(object sender, EventArgs e)
        //{
        //    this.lblMag.Visible = false;
        //    string txtScalpingNo = "";
        //    try
        //    {
        //        txtScalpingNo = this.txtScalpingNo.Text.Trim();
        //    }
        //    catch { }

        //    if (txtScalpingNo != "")
        //    { 
        //        SetScalpingId = 0;
        //        //List<XMProduct> xmProductList = base.ProjectService.GetXMProductListByMerchantcode(txtScalpingNo);

        //        //if (xmProductList.Count > 0)
        //        //{
        //        //    this.lblPrdouctName.Text = xmProductList[0].ProductName;
        //        //    this.lblSpecifications.Text = xmProductList[0].Specifications;
        //        //}
        //        //else
        //        //{
        //        //    this.lblMag.Visible = true;
        //        //    this.lblMag.Text = "商品编码不存在";
        //        //    this.lblPrdouctName.Text = "";
        //        //    this.lblSpecifications.Text = "";
        //        //}
        //    }
        //}

        //protected void txtScalpingCode_Changed(object sender, EventArgs e)
        //{
             
        //    this.lblMag.Visible = false;
        //    string ddTheAdvanceType = this.ddTheAdvanceType.SelectedValue.Trim();
        //    if (ddTheAdvanceType == "343")
        //    {
        //        int scalpingId = 0;
        //        int.TryParse(this.hfScalpingId.Value, out scalpingId);
        //        var scalping = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(scalpingId);
        //        if (scalping == null)
        //        {
        //            this.lblMag.Visible = true;
        //            this.lblMag.Text = "刷单单号有误";
        //            this.hfScalpingId.Value = "";
        //            this.txtScalpingCode.Value = "";
        //            this.hfNickId.Value = "";
        //            this.txtNickName.Text = "";
        //            this.hfPlatformTypeId.Value = "";
        //            this.txtPlatformType.Text = "";
        //            ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "advanceApplicationDetailManage", "autoCompleteBindScalpingCodeManag()", true);
        //            return;
        //        }
        //        var AdvanceApplicationList = base.AdvanceApplicationService.GetAdvanceApplicationByScalpingId(scalpingId);
        //        if (AdvanceApplicationList.Count > 0)
        //        {

        //            this.lblMag.Visible = true;
        //            this.lblMag.Text = "刷单单号已存在";
        //            this.hfScalpingId.Value = "";
        //            this.txtScalpingCode.Value = "";
        //            this.hfNickId.Value = "";
        //            this.txtNickName.Text = "";
        //            this.hfPlatformTypeId.Value = "";
        //            this.txtPlatformType.Text = "";
        //            ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "advanceApplicationDetailManage", "autoCompleteBindScalpingCodeManag()", true);
        //            return;
        //        } 
        //    }

        //}

         
         /// <summary>
        /// 刷单暂支
        /// </summary>
        public void TheAdvanceTypeSDZZ() {

            this.TD2.Visible = true;
            //店铺
            //this.ddNickId.Items.Clear();
            //var NickList = base.XMNickService.GetXMNickList();
            //var newNickList = NickList.Where(p => p.isEnable == true).ToList();
            //ddNickId.DataSource = newNickList;
            //ddNickId.DataTextField = "nick";
            //ddNickId.DataValueField = "nick_id";
            //ddNickId.DataBind();

            ////平台类型
            //this.ddPlatformTypeId.Items.Clear();
            //var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            //ddPlatformTypeId.DataSource = codeList;
            //ddPlatformTypeId.DataTextField = "CodeName";
            //ddPlatformTypeId.DataValueField = "CodeID";
            //ddPlatformTypeId.DataBind();

            if (this.ScalpingId == -1)
            {
                this.DIVLableScalpingNo.Visible = false;
                this.DIVScalpingNo.Visible = true;

            }
            else
            {

                this.DIVLableScalpingNo.Visible = false;
                this.DIVScalpingNo.Visible = true;
            } 
        }


        /// <summary>
        /// 刷单申请Id
        /// </summary>
        public int ScalpingId
        {
            get
            {
                return CommonHelper.QueryStringInt("ScalpingId");
            }
        }
    }

}