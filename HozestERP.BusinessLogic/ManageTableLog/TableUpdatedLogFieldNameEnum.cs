using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageTableLog
{
    public enum TableUpdatedLogFieldNameEnum
    {
        [Description("店铺类型")]
        ClientTypeID,

        [Description("客户")]
        ClientID,

        [Description("店铺名称")]
        StoreName,

        [Description("主旺旺Id")]
        MasterWangNo,

        [Description("收藏数")]
        FavorableRate,

        [Description("负责人")]
        PersonName,

        [Description("联系人")]
        LinkName,

        [Description("联系电话")]
        LinkPhoto,

        [Description("联系旺旺")]
        LinkWant,

        [Description("联系QQ")]
        QQ,

        [Description("邮箱")]
        Mailbox,

        [Description("商务人员")]
        CustomerID,

        [Description("地址")]
        Address,

        [Description("网址")]
        Url,

        [Description("省份")]
        Province,

        [Description("城市")]
        City,

        [Description("宝贝数量")]
        GoodsNum,

        [Description("信誉等级")]
        Rank,

        [Description("是否商城")]
        isMall,

        [Description("合同编号")]
        ContractCode,

        [Description("合同日期")]
        ContractDate,

        [Description("绑定账户")]
        BindAccount,

        [Description("淘宝小号")]
        TaobaoSmall,

        [Description("密码")]
        PassWord,

        [Description("产品数量")]
        ProductCount,

        [Description("预算开始")]
        BudgetStart,

        [Description("预算结束")]
        BudgetEnd,

        [Description("服务周期")]
        ServiceCycle,

        [Description("服务开始时间")]
        ServiceStartTime,

        [Description("服务结束时间")]
        ServiceEndTime,

        [Description("金额")]
        Amount,

        [Description("实付金额")]
        PayAmount,

        [Description("已付开始")]
        HavePayAmount,

        [Description("标题")]
        Title,

        [Description("提交时间")]
        SubmissionTime,

        [Description("合同类型")]
        ContractTypeID,

        [Description("预算开始")]
        Published,

        [Description("合同状态")]
        ContractStatusID,

        [Description("点击单价约定")]
        PriceAgreed,

        [Description("投资回报率约定")]
        AgreedRateReturn,

        [Description("效果约定")]
        ResultsAgreed,

        [Description("实际开始时间")]
        ActualStartTime,

        [Description("实际结束时间")]
        ActualEndTime,

        [Description("合同备注")]
        Remark,

        [Description("已删除")]
        Deleted,

        [Description("客户状态")]
        ClientStatusID,

        [Description("最新修改时间")]
        Updated,

        [Description("服务类型")]
        BusinessTypeID,

        [Description("所属行业")]
        SectorID,

        [Description("店铺性质")]
        CreditRatingID,

        [Description("宝贝与描述相符")]
        DescriptionScore,

        [Description("卖家的服务态度")]
        ServiceAttitudeScore,

        [Description("卖家发货的速度")]
        SpeedOfDeliveryScore,

        [Description("主营")]
        Main ,

        [Description("最后操作时间")]
        LastDate ,
        
        [Description("客户来源")]
        CusSourceID ,
        
        [Description("状态")]
        Enabled ,
        
        [Description("添加人UserID")]
        CreateStaffID ,

        
        [Description("添加时间")]
        CreateDate ,

        [Description("修改人")]
        UpdatorID ,

        [Description("续签的合同ID")]
        RenewalId ,



        [Description("是否提交")]
        IsSubmit ,


        [Description("创建时间")]
        Created ,

        [Description("创建人")]
        CreatorID ,

        [Description("客户业务员变更ID")]
        SalespersonChangesID ,
 
    }
}
