using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageFinance;

namespace HozestERP.Web.ManageProject
{ 

    public partial class MatchScalpingCode : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hfPlatformTypeIdSet.Value = this.PlatformTypeId.ToString();
                this.hfNickIdSet.Value = this.NickId.ToString();
            }
        }

        #region IEditPage 成员

        public void Face_Init()
        {
            this.Master.SetTitle("匹配刷单单号");

        }

        public void SetTrigger()
        {
            // this.Master.SetTrigger(this.btnSave.UniqueID, this.Page); 

        }
        #endregion


        public string SessionPageID
        {
            get
            {
                return CommonHelper.QueryString("SessionPageID");
            }
        }



        public string ScalpingId
        {
            get
            {
                try
                {
                    return (Session["SessionScalpingId"] as string);
                }
                catch
                {
                }
                return string.Empty;
            }
            set
            {
                Session["SessionScalpingId"] = value;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            { 
                //var hfScalpingId = this.hfScalpingId.Value;
                var hfPlatformTypeId = this.hfPlatformTypeId.Value;
                var hfNickId = this.hfNickId.Value;

                if (this.PlatformTypeId == Convert.ToInt32(hfPlatformTypeId) && this.NickId == Convert.ToInt32(hfNickId))
                {
                    int scalpingId = 0;
                    int.TryParse(this.hfScalpingId.Value, out scalpingId);
                    var scalping = base.XMScalpingApplicationService.GetXMScalpingApplicationByScalpingId(scalpingId);
                    if (scalping == null)
                    {
                        this.hfScalpingId.Value = "";
                        this.txtScalpingCode.Value = "";
                        this.hfNickId.Value = "";
                        this.txtNickName.Text = "";
                        this.hfPlatformTypeId.Value = "";
                        this.txtPlatformType.Text = "";
                        this.Master.ShowMessage("刷单单号有误.");
                        ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "MatchScalpingCode", "autoCompleteBindMatchScalpingCode()", true);
                        return;
                    }
                    //未分配刷单单号的刷单记录
                    //根据输入的刷单单号的刷单Id查询 （统计订单回款、刷单佣金、订单扣点）
                    #region 未分配好刷单单号的刷单记录 刷单订单总金额、总佣金 
                    List<int> IdsI =null;//= new List<int>(); 
                    int[] Ids; 
                    if (this.IDsStr.Length > 0) { 
                        string[]  strArray = this.IDsStr.Split(new char[]{','});
                        Ids = Array.ConvertAll<string, int>(strArray, s => int.Parse(s)); 
                        IdsI = new List<int>(Ids);
                    }
                    List<XMScalping> xmScalpingListNO = base.XMScalpingService.GetXMScalpingByIDs(IdsI);
                    decimal SalePriceSumNO = 0;
                    decimal FeeSumNO = 0;
                    decimal DeductionSumNO = 0; 
                    decimal SalePriceNO = 0;

                    if (xmScalpingListNO.Count > 0)
                    {
                        //订单总销售额 
                        SalePriceSumNO = xmScalpingListNO.Select(p => p.SalePrice == null ? 0 : p.SalePrice.Value).Sum();
                        //订单总佣金
                        FeeSumNO = xmScalpingListNO.Select(p => p.Fee == null ? 0 : p.Fee.Value).Sum();
                        //订单扣点
                        DeductionSumNO = xmScalpingListNO.Select(p => p.Deduction == null ? 0 : p.Deduction.Value).Sum();
                    }
                 
                    #endregion


                    //订单回款=订单销售额-订单扣点 
                    SalePriceNO = SalePriceSumNO - DeductionSumNO;

                    //已分配好刷单单号的刷单记录
                    //根据已选中的复选框的刷单记录 （统计订单回款、刷单佣金、订单扣点）
                    #region 已经分配好刷单单号的刷单记录 刷单订单总金额、总佣金  
                    List<XMScalping> xmScalpingListOk = base.XMScalpingService.GetXMScalpingByScalpingId(scalpingId);

                    decimal SalePriceSumOK = 0;
                    decimal FeeSumOK = 0;
                    decimal DeductionSumOK = 0;

                    decimal SalePriceOK = 0;



                    if (xmScalpingListOk.Count > 0)
                    {
                        //订单总销售额
                        SalePriceSumOK = xmScalpingListOk.Select(p => p.SalePrice == null ? 0 : p.SalePrice.Value).Sum();
                        //订单总佣金
                        FeeSumOK = xmScalpingListOk.Select(p => p.Fee == null ? 0 : p.Fee.Value).Sum();
                        //订单扣点
                        DeductionSumOK = xmScalpingListOk.Select(p => p.Deduction == null ? 0 : p.Deduction.Value).Sum();
                    }


                    //订单回款=订单销售额-订单扣点 
                    SalePriceOK = SalePriceSumOK - DeductionSumOK;

                    #endregion

                    //根据刷单单号Id查询暂支还款记录 （统计已经还款的总金额） 
                    //暂支金额 
                    List<AdvanceApplicationDetail> AdvanceApplicationDetailListC = base.AdvanceApplicationDetailService.GetAdvanceApplicationDetailList(scalpingId, -1, -1, 345);
                    //已暂支总金额 
                    decimal TheAdvanceMoneyC = AdvanceApplicationDetailListC.Select(p => p.TheAdvanceMoney.Value).Sum();

                   //还款金额 
                    List<AdvanceApplicationDetail> AdvanceApplicationDetailListH= base.AdvanceApplicationDetailService.GetAdvanceApplicationDetailList(scalpingId, -1, -1, 346);
                    //已还款总金额
                   decimal TheAdvanceMoneyH= AdvanceApplicationDetailListH.Select(p => p.TheAdvanceMoney.Value).Sum();
                     
                   //未分配刷单单号 (订单总销售额+订单总佣金+订单扣点)
                   decimal sumNo = SalePriceNO + FeeSumNO + DeductionSumNO;
                   //已分配刷单单号 (订单总销售额+订单总佣金+订单扣点)
                   decimal sumOk = SalePriceOK + FeeSumOK + DeductionSumOK; 

                   //计算总金额（未分配总金额+ 已分配总金额+已还款总金额）
                   decimal sumZ = sumNo + sumOk + TheAdvanceMoneyH;

                    //暂支金额与计算总金额比较
                    //1.计算总金额 < 暂支金额

                   if (sumZ < TheAdvanceMoneyC)
                   {

                       this.ScalpingId = scalpingId.ToString();

                       this.JsWrite("closewin();");
                   }
                   //2.计算总金额 > 暂支金额
                   else {

                       decimal D = sumZ - TheAdvanceMoneyC;

                       this.hfScalpingId.Value = "";
                       this.txtScalpingCode.Value = "";
                       this.hfNickId.Value = "";
                       this.txtNickName.Text = "";
                       this.hfPlatformTypeId.Value = "";
                       this.txtPlatformType.Text = "";
                       this.Master.ShowMessage("结算金额已超出暂支金额:"+D.ToString()+"元,请重新分配.");
                       //this.Master.ShowMessage("订单总销售额+订单总佣金+订单扣点+已还款金额大于总暂支金额,请重新输入刷单单号。");
                       ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "MatchScalpingCode", "autoCompleteBindMatchScalpingCode()", true);
                       return;

                   }
                      
                }
                else {
                    this.hfScalpingId.Value = "";
                    this.txtScalpingCode.Value = "";
                    this.hfNickId.Value = "";
                    this.txtNickName.Text = "";
                    this.hfPlatformTypeId.Value = "";
                    this.txtPlatformType.Text = "";
                    base.ShowMessage("请选择"+this.PlatformTypeName+"平台"+this.NickName+"店铺的刷单单号.");
                    ScriptManager.RegisterStartupScript(this.txtScalpingCode, this.Page.GetType(), "MatchScalpingCode", "autoCompleteBindMatchScalpingCode()", true);
                    return; 
                }

               

            }
            catch (Exception err)
            {
                base.ProcessException(err, false);

            }
        }
        #region public void JsWrite(string paramAction)
        /// <summary>
        ///  写入JS脚本
        /// </summary>
        /// <param name="paramAction">内容</param>
        /// <param name="parmaName"></param>
        public void JsWrite(string paramAction)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "JS", paramAction, true);
        }
        #endregion


        /// <summary>
        /// 平台类型id 
        /// </summary>
        public int PlatformTypeId
        {
            get
            {
                return CommonHelper.QueryStringInt("PlatformTypeId");
            }
        }

        /// <summary>
        /// 店铺id 
        /// </summary>
        public int NickId
        {
            get
            {
                return CommonHelper.QueryStringInt("NickId");
            }
        }
        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformTypeName
        {
            get
            {
                return CommonHelper.QueryString("PlatformTypeName");
            }
        }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string NickName
        {
            get
            {
                return CommonHelper.QueryString("NickName");
            }
        }


        public string IDsStr
        { 
            get
            {

                return CommonHelper.QueryString("IDsStr");
            }
        }


    }
}