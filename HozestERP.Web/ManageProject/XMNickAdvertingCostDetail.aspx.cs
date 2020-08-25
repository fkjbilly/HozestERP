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
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Enterprises;

namespace HozestERP.Web.ManageProject
{
    public partial class XMNickAdvertingCostDetail : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //判断字段是否设置
                checkSetField();
                //根据Id 查询相应店铺字段明细数据是否存在，不存在自动插入
                autoInsertData();
                //绑定字段列表
                BindFieldList();
            }
        }

        private void checkSetField()
        {
            var advertingFee = base.XMAdvertisingFeeService.GetXMAdvertisingFeeById(this.Id);
            if (advertingFee != null && advertingFee.NickId != null)
            {
                var include = base.XMNickIncludeAdveringFieldService.GetXMNickIncludeAdvertingFieldByNickID(advertingFee.NickId.Value);
                if (include == null || (include != null && include.Fields == null))
                {
                    grdvAdvertingFieldDetails.Visible = false;
                    base.ShowMessage("请先选择字段");
                    return;
                }
            }
        }

        private void autoInsertData()
        {
            var advertingFee = base.XMAdvertisingFeeService.GetXMAdvertisingFeeById(this.Id);
            if (advertingFee == null)
            {
                base.ShowMessage("当前信息不存在");
                return;
            }
            else
            {
                if (advertingFee.NickId != null)
                {
                    var includeNickAd = base.XMNickIncludeAdveringFieldService.GetXMNickIncludeAdvertingFieldByNickID(advertingFee.NickId.Value);
                    if (includeNickAd != null && includeNickAd.Fields != null)
                    {
                        if (includeNickAd.Fields.Split(',').Count() > 0)
                        {
                            //拆分字段ID
                            foreach (string str in includeNickAd.Fields.Split(','))
                            {
                                var advertingFeeDetail = base.XMAdvertisingFeeDetailService.GetXMAdvertisingFeeDetailByAdvertingFeeIdAndFieldID(this.Id, int.Parse(str));
                                //新增数据
                                if (advertingFeeDetail == null)
                                {
                                    XMAdvertisingFeeDetail detail = new XMAdvertisingFeeDetail();
                                    detail.AdvertingFeeId = this.Id;
                                    detail.FieldId = int.Parse(str);                             //字段ID
                                    detail.Cost = 0;
                                    detail.CreateDate = DateTime.Now;
                                    detail.CreateID = HozestERPContext.Current.User.CustomerID;
                                    detail.UpdateDate = DateTime.Now;
                                    detail.UpdateID = HozestERPContext.Current.User.CustomerID;
                                    base.XMAdvertisingFeeDetailService.InsertXMAdvertisingFeeDetail(detail);
                                }
                            }
                        }
                    }
                }
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            //判断字段是否设置
            checkSetField();
            #region 字符验证
            int errorcount = 0;
            //循环所有行
            foreach (GridViewRow msgReach in grdvAdvertingFieldDetails.Rows)
            {
                TextBox txtCost = msgReach.FindControl("txtCost") as TextBox;
                Label lblMsgCountMoneyVaule = msgReach.FindControl("lblMsgCountMoneyVaule") as Label;
                decimal i = 0;
                if (txtCost.Text.Trim() != "")
                {
                    lblMsgCountMoneyVaule.Text = "";
                    if (!decimal.TryParse(txtCost.Text.Trim(), out  i))
                    {
                        lblMsgCountMoneyVaule.Text = "请输入数字类型.";
                        lblMsgCountMoneyVaule.Visible = true;
                        errorcount++;
                    }
                    if (txtCost.Text.Trim().Length > 12)
                    {
                        lblMsgCountMoneyVaule.Text = "输入数字长度太长！.";
                        lblMsgCountMoneyVaule.Visible = true;
                        errorcount++;
                    }
                }
                if (errorcount > 0)
                {
                    return;
                }
            }
            #endregion

            bool isEdit = false;
            decimal totalCost = 0;
            //循环grid 每行 
            foreach (GridViewRow item in grdvAdvertingFieldDetails.Rows)
            {
                TextBox txtCost = item.FindControl("txtCost") as TextBox;
                HiddenField hdfieldID = item.FindControl("hiddFieldID") as HiddenField;
                if (txtCost.Text.Trim() != "")
                {
                    if (hdfieldID != null && hdfieldID.Value != "")
                    {
                        var advertingCostDetail = base.XMAdvertisingFeeDetailService.GetXMAdvertisingFeeDetailByAdvertingFeeIdAndFieldID(this.Id, int.Parse(hdfieldID.Value));
                        //更新广告费明细
                        if (advertingCostDetail != null)
                        {
                            isEdit = true;
                            decimal cost = decimal.Parse(txtCost.Text.Trim());
                            totalCost += cost;
                            advertingCostDetail.Cost = cost;
                            advertingCostDetail.UpdateID = HozestERPContext.Current.User.CustomerID;
                            advertingCostDetail.UpdateDate = DateTime.Now;
                            base.XMAdvertisingFeeDetailService.UpdateXMAdvertisingFeeDetail(advertingCostDetail);
                        }
                    }
                }
            }
            if (isEdit)
            {
                //更新主表信息中fee字段数据
                var advertingFee = base.XMAdvertisingFeeService.GetXMAdvertisingFeeById(this.Id);
                if (advertingFee != null)
                {
                    advertingFee.Fee = totalCost;
                    advertingFee.UpdateTime = DateTime.Now;
                    advertingFee.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    base.XMAdvertisingFeeService.UpdateXMAdvertisingFee(advertingFee);
                }
                base.ShowMessage("保存成功!");
            }
            BindFieldList();
        }

        /// <summary>
        ///  绑定字段列表
        /// </summary>
        private void BindFieldList()
        {
            int nickid = 0;
            List<XMAdvertisingFeeDetail> List = new List<XMAdvertisingFeeDetail>();
            var advertingFee = base.XMAdvertisingFeeService.GetXMAdvertisingFeeById(this.Id);
            if (advertingFee != null && advertingFee.NickId != null)
            {
                nickid = advertingFee.NickId.Value;
            }
            //根据nickID查询店铺所属字段集合
            var inculde = base.XMNickIncludeAdveringFieldService.GetXMNickIncludeAdvertingFieldByNickID(nickid);
            if (inculde != null && inculde.Fields != null)
            {

                foreach (string str in inculde.Fields.Split(','))
                {
                    var advertingFeeDetail = base.XMAdvertisingFeeDetailService.GetXMAdvertisingFeeDetailByAdvertingFeeIdAndFieldID(this.Id, int.Parse(str));
                    if (advertingFeeDetail != null)
                    {
                        List.Add(advertingFeeDetail);
                    }
                }
            }
            grdvAdvertingFieldDetails.DataSource = List;
            grdvAdvertingFieldDetails.DataBind();
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }

        #endregion

        /// <summary>
        ///id
        /// </summary>
        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }
    }
}