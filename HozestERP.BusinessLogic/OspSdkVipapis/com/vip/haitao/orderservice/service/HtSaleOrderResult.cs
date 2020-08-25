using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtSaleOrderResult {
		
		///<summary>
		/// 订单号ID
		///</summary>
		
		private string orderId_;
		
		///<summary>
		/// 订单号与详情里面的orderCode一样
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 销售类型 如:3 海淘直发,17海淘买断,18海淘JIT,20海淘3PL
		///</summary>
		
		private string saleType_;
		
		///<summary>
		/// 是否匹配运单,0由HTS提供运单;1 需要匹配
		///</summary>
		
		private int? isTmsProvideTransportNo_;
		
		///<summary>
		/// 用户下单时间
		///</summary>
		
		private string createTime_;
		
		///<summary>
		/// 发货仓仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 订单备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 送货方式[打印OQC面单使用，枚举值如只双休日/节假日送货(工作日不用送)]
		///</summary>
		
		private string transportDay_;
		
		///<summary>
		/// 报关批次号
		///</summary>
		
		private string batchNumber_;
		
		///<summary>
		/// 提单号
		///</summary>
		
		private string ladingBillNumber_;
		
		///<summary>
		/// 子提单号
		///</summary>
		
		private string subLadingBillNumber_;
		
		///<summary>
		/// 档期号 子信息为多个档期时，此档期号为空
		///</summary>
		
		private int? brandId_;
		
		///<summary>
		/// 收货人[收货人姓名如:张三]
		///</summary>
		
		private string buyer_;
		
		///<summary>
		/// 收货地址[例如：湖北省.武汉市.汉阳区龙江庭院Ｂ区 8栋1单元1002]
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 省
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 区
		///</summary>
		
		private string district_;
		
		///<summary>
		/// 街道
		///</summary>
		
		private string street_;
		
		///<summary>
		/// 身份证
		///</summary>
		
		private string buyerIdcard_;
		
		///<summary>
		/// 联系电话
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 移动电话
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 商品合计金额[整张出库单内所有商品的金额总和（不包含运费）]
		///</summary>
		
		private double? totalMoney_;
		
		///<summary>
		/// 支付货物总值[整张出库单内所有商品的金额总和（不包含运费）扣减各项折扣后金额]
		///</summary>
		
		private double? payMount_;
		
		///<summary>
		/// 折扣总金额
		///</summary>
		
		private double? favourableMoney_;
		
		///<summary>
		/// 实际支付运费[如果是免邮费则下发数字【0.00】]
		///</summary>
		
		private double? carriage_;
		
		///<summary>
		/// 报关运费
		///</summary>
		
		private double? customCarriage_;
		
		///<summary>
		/// 税费
		///</summary>
		
		private double? taxFee_;
		
		///<summary>
		/// 支付币种[如：RMB]
		///</summary>
		
		private string payMoneyType_;
		
		///<summary>
		/// 银行支付流水号[支付成功后，银行返回流水号]
		///</summary>
		
		private string tradeNumber_;
		
		///<summary>
		/// 支付公司[如：支付宝]
		///</summary>
		
		private string payTypeNumber_;
		
		///<summary>
		/// 支付公司备案号
		///</summary>
		
		private string enterpriseCertCode_;
		
		///<summary>
		/// 承运商面单打印名称[例如：广东品骏]
		///</summary>
		
		private string carriersName_;
		
		///<summary>
		/// 站点编码[例如：Z04]
		///</summary>
		
		private string carrierPointCode_;
		
		///<summary>
		/// 站点名称[例如：天河站]
		///</summary>
		
		private string carrierPointName_;
		
		///<summary>
		/// 运单号[例如：15061501654811]
		///</summary>
		
		private string transportNo_;
		
		///<summary>
		/// 始发地编码[非必填项，顺丰快递需要]
		///</summary>
		
		private string originCode_;
		
		///<summary>
		/// 目的地编码
		///</summary>
		
		private string destinationCode_;
		
		///<summary>
		/// 模板编码[normal 默认面单 、SF 顺丰面单、EMS EMS面单]
		///</summary>
		
		private string templateCode_;
		
		///<summary>
		/// 分拣代码[承运商内部的分拣代码，由TMS反馈信息 例如：B40]
		///</summary>
		
		private string pickCode_;
		
		///<summary>
		/// 承运商编码[TMS管理承运商编码，海外仓获取此信息]
		///</summary>
		
		private string custCode_;
		
		///<summary>
		/// 关口[中国关关口代码，gzhg]
		///</summary>
		
		private string customsCode_;
		
		///<summary>
		/// 国内贷代[例如：quansutong 河南全速通供应链管理有限公司]
		///</summary>
		
		private string chinaFreightForwarding_;
		
		///<summary>
		/// 国际货代[传编码 HTS的关口与贷代代码]
		///</summary>
		
		private string globalFreightForwarding_;
		
		///<summary>
		/// 通关模式[BC BBC 快件]
		///</summary>
		
		private string customsClearanceMode_;
		
		///<summary>
		/// 本条订单更新时间
		///</summary>
		
		private string updateTime_;
		
		///<summary>
		/// 订单状态[1.新增,2.修改,9.取消]
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 档期名称
		///</summary>
		
		private string brandName_;
		
		///<summary>
		/// 订单详情信息
		///</summary>
		
		private List<com.vip.haitao.orderservice.service.HtSaleOrderInfoModel> HtSaleOrderInfoVopModelList_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string channel_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDef1_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDef2_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDef3_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDef4_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private long? userDef5_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private long? userDef6_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDef7_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDef8_;
		
		///<summary>
		/// 卸货点编码
		///</summary>
		
		private string unloadPointCode_;
		
		///<summary>
		/// 卸货点名称
		///</summary>
		
		private string unloadPointName_;
		
		///<summary>
		/// 订单配送班次
		///</summary>
		
		private int? orderDeliveryBatch_;
		
		///<summary>
		/// 提货时间点
		///</summary>
		
		private string pickupGoodsTime_;
		
		///<summary>
		/// 运输产品
		///</summary>
		
		private string transportPrd_;
		
		///<summary>
		/// 箱号
		///</summary>
		
		private string boxId_;
		
		///<summary>
		/// 付款方式
		///</summary>
		
		private string payType_;
		
		///<summary>
		/// 承载物类型
		///</summary>
		
		private string transportType_;
		
		public string GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(string value){
			this.orderId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetSaleType(){
			return this.saleType_;
		}
		
		public void SetSaleType(string value){
			this.saleType_ = value;
		}
		public int? GetIsTmsProvideTransportNo(){
			return this.isTmsProvideTransportNo_;
		}
		
		public void SetIsTmsProvideTransportNo(int? value){
			this.isTmsProvideTransportNo_ = value;
		}
		public string GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(string value){
			this.createTime_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public string GetTransportDay(){
			return this.transportDay_;
		}
		
		public void SetTransportDay(string value){
			this.transportDay_ = value;
		}
		public string GetBatchNumber(){
			return this.batchNumber_;
		}
		
		public void SetBatchNumber(string value){
			this.batchNumber_ = value;
		}
		public string GetLadingBillNumber(){
			return this.ladingBillNumber_;
		}
		
		public void SetLadingBillNumber(string value){
			this.ladingBillNumber_ = value;
		}
		public string GetSubLadingBillNumber(){
			return this.subLadingBillNumber_;
		}
		
		public void SetSubLadingBillNumber(string value){
			this.subLadingBillNumber_ = value;
		}
		public int? GetBrandId(){
			return this.brandId_;
		}
		
		public void SetBrandId(int? value){
			this.brandId_ = value;
		}
		public string GetBuyer(){
			return this.buyer_;
		}
		
		public void SetBuyer(string value){
			this.buyer_ = value;
		}
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public string GetProvince(){
			return this.province_;
		}
		
		public void SetProvince(string value){
			this.province_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public string GetDistrict(){
			return this.district_;
		}
		
		public void SetDistrict(string value){
			this.district_ = value;
		}
		public string GetStreet(){
			return this.street_;
		}
		
		public void SetStreet(string value){
			this.street_ = value;
		}
		public string GetBuyerIdcard(){
			return this.buyerIdcard_;
		}
		
		public void SetBuyerIdcard(string value){
			this.buyerIdcard_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		public string GetMobile(){
			return this.mobile_;
		}
		
		public void SetMobile(string value){
			this.mobile_ = value;
		}
		public double? GetTotalMoney(){
			return this.totalMoney_;
		}
		
		public void SetTotalMoney(double? value){
			this.totalMoney_ = value;
		}
		public double? GetPayMount(){
			return this.payMount_;
		}
		
		public void SetPayMount(double? value){
			this.payMount_ = value;
		}
		public double? GetFavourableMoney(){
			return this.favourableMoney_;
		}
		
		public void SetFavourableMoney(double? value){
			this.favourableMoney_ = value;
		}
		public double? GetCarriage(){
			return this.carriage_;
		}
		
		public void SetCarriage(double? value){
			this.carriage_ = value;
		}
		public double? GetCustomCarriage(){
			return this.customCarriage_;
		}
		
		public void SetCustomCarriage(double? value){
			this.customCarriage_ = value;
		}
		public double? GetTaxFee(){
			return this.taxFee_;
		}
		
		public void SetTaxFee(double? value){
			this.taxFee_ = value;
		}
		public string GetPayMoneyType(){
			return this.payMoneyType_;
		}
		
		public void SetPayMoneyType(string value){
			this.payMoneyType_ = value;
		}
		public string GetTradeNumber(){
			return this.tradeNumber_;
		}
		
		public void SetTradeNumber(string value){
			this.tradeNumber_ = value;
		}
		public string GetPayTypeNumber(){
			return this.payTypeNumber_;
		}
		
		public void SetPayTypeNumber(string value){
			this.payTypeNumber_ = value;
		}
		public string GetEnterpriseCertCode(){
			return this.enterpriseCertCode_;
		}
		
		public void SetEnterpriseCertCode(string value){
			this.enterpriseCertCode_ = value;
		}
		public string GetCarriersName(){
			return this.carriersName_;
		}
		
		public void SetCarriersName(string value){
			this.carriersName_ = value;
		}
		public string GetCarrierPointCode(){
			return this.carrierPointCode_;
		}
		
		public void SetCarrierPointCode(string value){
			this.carrierPointCode_ = value;
		}
		public string GetCarrierPointName(){
			return this.carrierPointName_;
		}
		
		public void SetCarrierPointName(string value){
			this.carrierPointName_ = value;
		}
		public string GetTransportNo(){
			return this.transportNo_;
		}
		
		public void SetTransportNo(string value){
			this.transportNo_ = value;
		}
		public string GetOriginCode(){
			return this.originCode_;
		}
		
		public void SetOriginCode(string value){
			this.originCode_ = value;
		}
		public string GetDestinationCode(){
			return this.destinationCode_;
		}
		
		public void SetDestinationCode(string value){
			this.destinationCode_ = value;
		}
		public string GetTemplateCode(){
			return this.templateCode_;
		}
		
		public void SetTemplateCode(string value){
			this.templateCode_ = value;
		}
		public string GetPickCode(){
			return this.pickCode_;
		}
		
		public void SetPickCode(string value){
			this.pickCode_ = value;
		}
		public string GetCustCode(){
			return this.custCode_;
		}
		
		public void SetCustCode(string value){
			this.custCode_ = value;
		}
		public string GetCustomsCode(){
			return this.customsCode_;
		}
		
		public void SetCustomsCode(string value){
			this.customsCode_ = value;
		}
		public string GetChinaFreightForwarding(){
			return this.chinaFreightForwarding_;
		}
		
		public void SetChinaFreightForwarding(string value){
			this.chinaFreightForwarding_ = value;
		}
		public string GetGlobalFreightForwarding(){
			return this.globalFreightForwarding_;
		}
		
		public void SetGlobalFreightForwarding(string value){
			this.globalFreightForwarding_ = value;
		}
		public string GetCustomsClearanceMode(){
			return this.customsClearanceMode_;
		}
		
		public void SetCustomsClearanceMode(string value){
			this.customsClearanceMode_ = value;
		}
		public string GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(string value){
			this.updateTime_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public string GetBrandName(){
			return this.brandName_;
		}
		
		public void SetBrandName(string value){
			this.brandName_ = value;
		}
		public List<com.vip.haitao.orderservice.service.HtSaleOrderInfoModel> GetHtSaleOrderInfoVopModelList(){
			return this.HtSaleOrderInfoVopModelList_;
		}
		
		public void SetHtSaleOrderInfoVopModelList(List<com.vip.haitao.orderservice.service.HtSaleOrderInfoModel> value){
			this.HtSaleOrderInfoVopModelList_ = value;
		}
		public string GetChannel(){
			return this.channel_;
		}
		
		public void SetChannel(string value){
			this.channel_ = value;
		}
		public string GetUserDef1(){
			return this.userDef1_;
		}
		
		public void SetUserDef1(string value){
			this.userDef1_ = value;
		}
		public string GetUserDef2(){
			return this.userDef2_;
		}
		
		public void SetUserDef2(string value){
			this.userDef2_ = value;
		}
		public string GetUserDef3(){
			return this.userDef3_;
		}
		
		public void SetUserDef3(string value){
			this.userDef3_ = value;
		}
		public string GetUserDef4(){
			return this.userDef4_;
		}
		
		public void SetUserDef4(string value){
			this.userDef4_ = value;
		}
		public long? GetUserDef5(){
			return this.userDef5_;
		}
		
		public void SetUserDef5(long? value){
			this.userDef5_ = value;
		}
		public long? GetUserDef6(){
			return this.userDef6_;
		}
		
		public void SetUserDef6(long? value){
			this.userDef6_ = value;
		}
		public string GetUserDef7(){
			return this.userDef7_;
		}
		
		public void SetUserDef7(string value){
			this.userDef7_ = value;
		}
		public string GetUserDef8(){
			return this.userDef8_;
		}
		
		public void SetUserDef8(string value){
			this.userDef8_ = value;
		}
		public string GetUnloadPointCode(){
			return this.unloadPointCode_;
		}
		
		public void SetUnloadPointCode(string value){
			this.unloadPointCode_ = value;
		}
		public string GetUnloadPointName(){
			return this.unloadPointName_;
		}
		
		public void SetUnloadPointName(string value){
			this.unloadPointName_ = value;
		}
		public int? GetOrderDeliveryBatch(){
			return this.orderDeliveryBatch_;
		}
		
		public void SetOrderDeliveryBatch(int? value){
			this.orderDeliveryBatch_ = value;
		}
		public string GetPickupGoodsTime(){
			return this.pickupGoodsTime_;
		}
		
		public void SetPickupGoodsTime(string value){
			this.pickupGoodsTime_ = value;
		}
		public string GetTransportPrd(){
			return this.transportPrd_;
		}
		
		public void SetTransportPrd(string value){
			this.transportPrd_ = value;
		}
		public string GetBoxId(){
			return this.boxId_;
		}
		
		public void SetBoxId(string value){
			this.boxId_ = value;
		}
		public string GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(string value){
			this.payType_ = value;
		}
		public string GetTransportType(){
			return this.transportType_;
		}
		
		public void SetTransportType(string value){
			this.transportType_ = value;
		}
		
	}
	
}