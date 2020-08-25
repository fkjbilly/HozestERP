using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageTableLog;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageTableUpdateLog
{
    public partial class TableUpdateLogForm : BaseAdministrationPage, ISearchPage
    {
        #region ISearchPage 成员

        public void Face_Init()
        {
            
            this.Master.SetTitle("数据修改历史记录");
        }

        public void SetTrigger()
        {
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
                bindDropFileName();
            }
        }

        public void bindDropFileName()
        {
            Dictionary<String, String> kv = getDropFieldNames(this.tableName);
            dropFieldName.DataSource = kv;
            dropFieldName.DataTextField = "Value";
            dropFieldName.DataValueField = "Key";
            dropFieldName.DataBind();
        }

        public Dictionary<String, String> getDropFieldNames(String tableName)
        {

            Dictionary<String, Dictionary<String, String>> kv = new Dictionary<string, Dictionary<String, String>>();
            Dictionary<String, String> tClientInfos = new Dictionary<string,string>();
            tClientInfos.Add("", "选择字段");
            tClientInfos.Add("ClientTypeID","店铺类型");
            tClientInfos.Add("StoreName","店铺名称");
            tClientInfos.Add("MasterWangNo","主旺旺Id");
            tClientInfos.Add("FavorableRate","收藏数");
            tClientInfos.Add("PersonName","负责人");
            tClientInfos.Add("LinkName","联系人");
            tClientInfos.Add("LinkPhoto","LinkPhoto");
            tClientInfos.Add("LinkWant","LinkWant");
            tClientInfos.Add("QQ","联系QQ");
            tClientInfos.Add("Mailbox","邮箱");
            tClientInfos.Add("CustomerID","客户id");
            tClientInfos.Add("Address","地址");
            tClientInfos.Add("Url","网址");
            tClientInfos.Add("Province","省份");
            tClientInfos.Add("City","城市");
            tClientInfos.Add("GoodsNum","宝贝数量");
            tClientInfos.Add("Rank","信誉等级");
            tClientInfos.Add("isMall","是否商城");
            kv.Add("BU_ClientInFo", tClientInfos);

            Dictionary<String, String> tContract = new Dictionary<string,string>();
            tContract.Add("", "选择字段");
            tContract.Add("ContractCode", "合同编号");
            tContract.Add("ContractDate", "合同日期");
            tContract.Add("BindAccount", "绑定账户");
            tContract.Add("TaobaoSmall", "淘宝小号");
            tContract.Add("PassWord", "密码");
            tContract.Add("ProductCount", "产品数量");
            tContract.Add("BudgetStart", "预算开始");
            tContract.Add("BudgetEnd", "预算结束");
            tContract.Add("ServiceCycle", "服务周期");
            tContract.Add("ServiceStartTime", "服务开始时间");
            tContract.Add("ServiceEndTime", "服务结束时间");
            tContract.Add("Amount", "金额");
            tContract.Add("PayAmount", "实付金额");
            tContract.Add("HavePayAmount", "已付开始");
            tContract.Add("SubmissionTime", "提交时间");
            tContract.Add("ContractTypeID", "合同类型Id");
            tContract.Add("Published", "预算开始");
            tContract.Add("ContractStatusID", "合同状态");
            tContract.Add("PriceAgreed", "点击单价约定");
            tContract.Add("AgreedRateReturn", "投资回报率约定");
            tContract.Add("ResultsAgreed", "效果约定");
            tContract.Add("ActualEndTime", "实际结束时间");
            tContract.Add("Remark", "合同备注");
            tContract.Add("Deleted", "已删除");

            kv.Add("BU_Contract", tContract);
            if (kv.ContainsKey(tableName))
                return kv[tableName];
            else return null;
        }

        public void bindGrid()
        {
            this.BindGrid(1, this.Master.PageSize);
        }


        protected int requestID {get{return CommonHelper.QueryStringInt("requestID");} }
        protected String tableName {get{return "BU_"+CommonHelper.QueryString("tableName");}}

        protected void gridLogs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridLogs.PageIndex = e.NewPageIndex;
            gridLogs.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindGrid();
        }


        #region ISearchPage 成员


        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            var logs = base.TableUpdateLogService.GetTableLogsByConditions(
                this.requestID,
                this.tableName,
                this.dropFieldName.SelectedValue,
                this.dateUpdateDate.SelectedDate,
                this.txtOperator.Text.Trim(),
                paramPageIndex,
                paramPageSize);
            this.Master.BindData(this.gridLogs, logs);
        }

        #endregion


        public string GetColumnsName(TableUpdatedLogFieldNameEnum tableEnum, string paraValue)
        {
            switch (tableEnum)
            {
              
                case TableUpdatedLogFieldNameEnum.CustomerID:
                    {
                        return base.CustomerService.GetCustomerById(int.Parse(paraValue)).SCustomerInfo.FullName;
                    }
               
                case TableUpdatedLogFieldNameEnum.CreditRatingID:
                    {
                        return base.CodeService.GetCodeListInfoByCodeID(int.Parse(paraValue)).CodeName;
                    }
                case TableUpdatedLogFieldNameEnum.SectorID:
                    {
                        return base.CodeService.GetCodeListInfoByCodeID(int.Parse(paraValue)).CodeName;
                    }
                
            }
            return paraValue;
        }

    }
}