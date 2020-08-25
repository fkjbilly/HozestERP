using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderVO {
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 用户名
		///</summary>
		
		private string userName_;
		
		///<summary>
		/// 下单ip
		///</summary>
		
		private string userIp_;
		
		///<summary>
		/// 网盟标识(对应:standby)
		///</summary>
		
		private string unionMark_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 销售模式
		///</summary>
		
		private int? saleType_;
		
		///<summary>
		/// 订单来源
		///</summary>
		
		private string source_;
		
		///<summary>
		/// 分仓代码(对应vip_awh)
		///</summary>
		
		private string addrWarehouse_;
		
		///<summary>
		/// 是否是积分空白单
		///</summary>
		
		private int? isJf_;
		
		///<summary>
		/// 平台标识
		///</summary>
		
		private int? platform_;
		
		///<summary>
		/// 销售地区
		///</summary>
		
		private int? saleArea_;
		
		///<summary>
		/// 身份证或对应公司名
		///</summary>
		
		private string vipCard_;
		
		///<summary>
		/// 订单pos机标志
		///</summary>
		
		private int? isPos_;
		
		///<summary>
		/// 运费（这是一个浮点类型，使用字符串传送是为了避免丢失精度）
		///</summary>
		
		private string carriage_;
		
		///<summary>
		/// 订单来源类型 0:正常下单 1:换货订单 2:修改订单 3:合并订单
		///</summary>
		
		private string orderSourceType_;
		
		///<summary>
		/// 下单时间
		///</summary>
		
		private long? orderDate_;
		
		///<summary>
		/// 订单备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 最后更新时间
		///</summary>
		
		private long? orderUpdateTime_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private int? orderStatus_;
		
		///<summary>
		/// 订单状态更新时间
		///</summary>
		
		private long? orderStatusUpdateTime_;
		
		///<summary>
		/// WMS抓取状态
		///</summary>
		
		private int? wmsFlag_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? goodsAmount_;
		
		///<summary>
		/// 订单类型
		///</summary>
		
		private int? orderType_;
		
		///<summary>
		/// 订单子状态标识 0-无异常 1-身份验证未通过
		///</summary>
		
		private int? orderSubStatus_;
		
		///<summary>
		/// 订单子状态标识 0-无异常 1-身份验证未通过
		///</summary>
		
		private long? orderAddTime_;
		
		///<summary>
		/// 订单模式(0:普通，1：预售)
		///</summary>
		
		private int? orderModel_;
		
		///<summary>
		/// 审核时间
		///</summary>
		
		private long? auditTime_;
		
		///<summary>
		/// 后台订单备注
		///</summary>
		
		private string adminRemark_;
		
		///<summary>
		/// 后台订单备注
		///</summary>
		
		private string adminSms_;
		
		///<summary>
		/// 是否已签收提醒
		///</summary>
		
		private string hasAlert_;
		
		///<summary>
		/// 是否发送了发货短信
		///</summary>
		
		private string smsSended_;
		
		///<summary>
		/// 订单日志操作状态
		///</summary>
		
		private int? opFlag_;
		
		///<summary>
		/// 操作者
		///</summary>
		
		private string operator_;
		
		///<summary>
		/// 拒收物品类型
		///</summary>
		
		private int? refuseGoodsType_;
		
		///<summary>
		/// 订单不合格的原因
		///</summary>
		
		private string unpassReason_;
		
		///<summary>
		/// 商品类型
		///</summary>
		
		private string transportType_;
		
		///<summary>
		/// 发货特殊要求
		///</summary>
		
		private string specialTransportText_;
		
		///<summary>
		/// 退换货标志
		///</summary>
		
		private string orderFlag_;
		
		///<summary>
		/// 是否退回零钱
		///</summary>
		
		private int? isReturnSurplus_;
		
		///<summary>
		/// 退款到零钱的金额
		///</summary>
		
		private string surplusBack_;
		
		///<summary>
		/// 寄托品
		///</summary>
		
		private string transportName_;
		
		///<summary>
		/// 物流号
		///</summary>
		
		private string transportNo_;
		
		///<summary>
		/// 送货方式ID(废弃字段，请勿使用，请使用longTransportId代替)
		///</summary>
		
		private int? transportId_;
		
		///<summary>
		/// 送货方式ID
		///</summary>
		
		private long? longTransportId_;
		
		///<summary>
		/// 赠品信息
		///</summary>
		
		private string presentInfo_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private int? isSpecial_;
		
		///<summary>
		/// 是否拼单
		///</summary>
		
		private int? isLink_;
		
		///<summary>
		/// 是否拆单
		///</summary>
		
		private int? isSplit_;
		
		///<summary>
		/// 保留订单标识
		///</summary>
		
		private int? isHold_;
		
		///<summary>
		/// 是否隐藏订单,0正常1隐藏
		///</summary>
		
		private int? isDisplay_;
		
		///<summary>
		/// 来自频道
		///</summary>
		
		private string vipclub_;
		
		///<summary>
		/// pos时间,单位：秒
		///</summary>
		
		private long? posTime_;
		
		///<summary>
		/// 是否使用礼品或积分
		///</summary>
		
		private bool? giftOrPointFlag_;
		
		///<summary>
		/// orders.allot_time
		///</summary>
		
		private long? allotTime_;
		
		///<summary>
		/// orders.allot_user
		///</summary>
		
		private string allotUser_;
		
		///<summary>
		/// orders.first_flag
		///</summary>
		
		private int? firstFlag_;
		
		///<summary>
		/// orders.status_flagr
		///</summary>
		
		private int? statusFlag_;
		
		///<summary>
		/// orders.create_time
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// pos时间,格式'2016-07-05 09:25:36'
		///</summary>
		
		private string posTimeFormat_;
		
		///<summary>
		/// 订单业务标识映射关系
		///</summary>
		
		private Dictionary<string, int?> orderBizFlagsMap_;
		
		///<summary>
		/// 订单业务标识
		///</summary>
		
		private int? orderBizFlags_;
		
		///<summary>
		/// 快递员Id
		///</summary>
		
		private string deliveryManId_;
		
		///<summary>
		/// 销售区域
		///</summary>
		
		private string saleWarehouse_;
		
		///<summary>
		/// 送货服务类型
		///</summary>
		
		private int? deliveryType_;
		
		///<summary>
		/// 赔付标识 
		///</summary>
		
		private int? compensateFlag_;
		
		///<summary>
		/// 承诺订单送达时间,单位秒
		///</summary>
		
		private long? deliveryPromisedTime_;
		
		///<summary>
		/// 支付人姓名
		///</summary>
		
		private string payer_;
		
		///<summary>
		/// 订单业务类型 1：国内实物订单 2：医药订单 
		///</summary>
		
		private int? orderBizType_;
		
		///<summary>
		/// 运费明细,JSON格式.如:[{"salesNo": 1,"carriage": "1.2"}]
		///</summary>
		
		private string carriageDetail_;
		
		///<summary>
		/// 预购订单预购状态。0:非预购,1:未授权,2:已授权,3:占用库存中,4:占用库存成功,5:自动扣款中,6:自动扣款成功,7:自动扣款失败,9:取消预购订单
		///</summary>
		
		private int? reserveStatus_;
		
		///<summary>
		/// MarketPlace 店铺ID, length不超过16
		///</summary>
		
		private string storeId_;
		
		///<summary>
		/// MarketPlace 店铺来源, 0表示自营, 1表示第三方入驻
		///</summary>
		
		private int? storeSource_;
		
		///<summary>
		/// 品仓-店铺ID
		///</summary>
		
		private string channelStoreId_;
		
		///<summary>
		/// 下单设备信息cid|mid|did的MD5值
		///</summary>
		
		private string deviceKey_;
		
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetUserName(){
			return this.userName_;
		}
		
		public void SetUserName(string value){
			this.userName_ = value;
		}
		public string GetUserIp(){
			return this.userIp_;
		}
		
		public void SetUserIp(string value){
			this.userIp_ = value;
		}
		public string GetUnionMark(){
			return this.unionMark_;
		}
		
		public void SetUnionMark(string value){
			this.unionMark_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public int? GetSaleType(){
			return this.saleType_;
		}
		
		public void SetSaleType(int? value){
			this.saleType_ = value;
		}
		public string GetSource(){
			return this.source_;
		}
		
		public void SetSource(string value){
			this.source_ = value;
		}
		public string GetAddrWarehouse(){
			return this.addrWarehouse_;
		}
		
		public void SetAddrWarehouse(string value){
			this.addrWarehouse_ = value;
		}
		public int? GetIsJf(){
			return this.isJf_;
		}
		
		public void SetIsJf(int? value){
			this.isJf_ = value;
		}
		public int? GetPlatform(){
			return this.platform_;
		}
		
		public void SetPlatform(int? value){
			this.platform_ = value;
		}
		public int? GetSaleArea(){
			return this.saleArea_;
		}
		
		public void SetSaleArea(int? value){
			this.saleArea_ = value;
		}
		public string GetVipCard(){
			return this.vipCard_;
		}
		
		public void SetVipCard(string value){
			this.vipCard_ = value;
		}
		public int? GetIsPos(){
			return this.isPos_;
		}
		
		public void SetIsPos(int? value){
			this.isPos_ = value;
		}
		public string GetCarriage(){
			return this.carriage_;
		}
		
		public void SetCarriage(string value){
			this.carriage_ = value;
		}
		public string GetOrderSourceType(){
			return this.orderSourceType_;
		}
		
		public void SetOrderSourceType(string value){
			this.orderSourceType_ = value;
		}
		public long? GetOrderDate(){
			return this.orderDate_;
		}
		
		public void SetOrderDate(long? value){
			this.orderDate_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public long? GetOrderUpdateTime(){
			return this.orderUpdateTime_;
		}
		
		public void SetOrderUpdateTime(long? value){
			this.orderUpdateTime_ = value;
		}
		public int? GetOrderStatus(){
			return this.orderStatus_;
		}
		
		public void SetOrderStatus(int? value){
			this.orderStatus_ = value;
		}
		public long? GetOrderStatusUpdateTime(){
			return this.orderStatusUpdateTime_;
		}
		
		public void SetOrderStatusUpdateTime(long? value){
			this.orderStatusUpdateTime_ = value;
		}
		public int? GetWmsFlag(){
			return this.wmsFlag_;
		}
		
		public void SetWmsFlag(int? value){
			this.wmsFlag_ = value;
		}
		public int? GetGoodsAmount(){
			return this.goodsAmount_;
		}
		
		public void SetGoodsAmount(int? value){
			this.goodsAmount_ = value;
		}
		public int? GetOrderType(){
			return this.orderType_;
		}
		
		public void SetOrderType(int? value){
			this.orderType_ = value;
		}
		public int? GetOrderSubStatus(){
			return this.orderSubStatus_;
		}
		
		public void SetOrderSubStatus(int? value){
			this.orderSubStatus_ = value;
		}
		public long? GetOrderAddTime(){
			return this.orderAddTime_;
		}
		
		public void SetOrderAddTime(long? value){
			this.orderAddTime_ = value;
		}
		public int? GetOrderModel(){
			return this.orderModel_;
		}
		
		public void SetOrderModel(int? value){
			this.orderModel_ = value;
		}
		public long? GetAuditTime(){
			return this.auditTime_;
		}
		
		public void SetAuditTime(long? value){
			this.auditTime_ = value;
		}
		public string GetAdminRemark(){
			return this.adminRemark_;
		}
		
		public void SetAdminRemark(string value){
			this.adminRemark_ = value;
		}
		public string GetAdminSms(){
			return this.adminSms_;
		}
		
		public void SetAdminSms(string value){
			this.adminSms_ = value;
		}
		public string GetHasAlert(){
			return this.hasAlert_;
		}
		
		public void SetHasAlert(string value){
			this.hasAlert_ = value;
		}
		public string GetSmsSended(){
			return this.smsSended_;
		}
		
		public void SetSmsSended(string value){
			this.smsSended_ = value;
		}
		public int? GetOpFlag(){
			return this.opFlag_;
		}
		
		public void SetOpFlag(int? value){
			this.opFlag_ = value;
		}
		public string GetOperator(){
			return this.operator_;
		}
		
		public void SetOperator(string value){
			this.operator_ = value;
		}
		public int? GetRefuseGoodsType(){
			return this.refuseGoodsType_;
		}
		
		public void SetRefuseGoodsType(int? value){
			this.refuseGoodsType_ = value;
		}
		public string GetUnpassReason(){
			return this.unpassReason_;
		}
		
		public void SetUnpassReason(string value){
			this.unpassReason_ = value;
		}
		public string GetTransportType(){
			return this.transportType_;
		}
		
		public void SetTransportType(string value){
			this.transportType_ = value;
		}
		public string GetSpecialTransportText(){
			return this.specialTransportText_;
		}
		
		public void SetSpecialTransportText(string value){
			this.specialTransportText_ = value;
		}
		public string GetOrderFlag(){
			return this.orderFlag_;
		}
		
		public void SetOrderFlag(string value){
			this.orderFlag_ = value;
		}
		public int? GetIsReturnSurplus(){
			return this.isReturnSurplus_;
		}
		
		public void SetIsReturnSurplus(int? value){
			this.isReturnSurplus_ = value;
		}
		public string GetSurplusBack(){
			return this.surplusBack_;
		}
		
		public void SetSurplusBack(string value){
			this.surplusBack_ = value;
		}
		public string GetTransportName(){
			return this.transportName_;
		}
		
		public void SetTransportName(string value){
			this.transportName_ = value;
		}
		public string GetTransportNo(){
			return this.transportNo_;
		}
		
		public void SetTransportNo(string value){
			this.transportNo_ = value;
		}
		public int? GetTransportId(){
			return this.transportId_;
		}
		
		public void SetTransportId(int? value){
			this.transportId_ = value;
		}
		public long? GetLongTransportId(){
			return this.longTransportId_;
		}
		
		public void SetLongTransportId(long? value){
			this.longTransportId_ = value;
		}
		public string GetPresentInfo(){
			return this.presentInfo_;
		}
		
		public void SetPresentInfo(string value){
			this.presentInfo_ = value;
		}
		public int? GetIsSpecial(){
			return this.isSpecial_;
		}
		
		public void SetIsSpecial(int? value){
			this.isSpecial_ = value;
		}
		public int? GetIsLink(){
			return this.isLink_;
		}
		
		public void SetIsLink(int? value){
			this.isLink_ = value;
		}
		public int? GetIsSplit(){
			return this.isSplit_;
		}
		
		public void SetIsSplit(int? value){
			this.isSplit_ = value;
		}
		public int? GetIsHold(){
			return this.isHold_;
		}
		
		public void SetIsHold(int? value){
			this.isHold_ = value;
		}
		public int? GetIsDisplay(){
			return this.isDisplay_;
		}
		
		public void SetIsDisplay(int? value){
			this.isDisplay_ = value;
		}
		public string GetVipclub(){
			return this.vipclub_;
		}
		
		public void SetVipclub(string value){
			this.vipclub_ = value;
		}
		public long? GetPosTime(){
			return this.posTime_;
		}
		
		public void SetPosTime(long? value){
			this.posTime_ = value;
		}
		public bool? GetGiftOrPointFlag(){
			return this.giftOrPointFlag_;
		}
		
		public void SetGiftOrPointFlag(bool? value){
			this.giftOrPointFlag_ = value;
		}
		public long? GetAllotTime(){
			return this.allotTime_;
		}
		
		public void SetAllotTime(long? value){
			this.allotTime_ = value;
		}
		public string GetAllotUser(){
			return this.allotUser_;
		}
		
		public void SetAllotUser(string value){
			this.allotUser_ = value;
		}
		public int? GetFirstFlag(){
			return this.firstFlag_;
		}
		
		public void SetFirstFlag(int? value){
			this.firstFlag_ = value;
		}
		public int? GetStatusFlag(){
			return this.statusFlag_;
		}
		
		public void SetStatusFlag(int? value){
			this.statusFlag_ = value;
		}
		public long? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(long? value){
			this.createTime_ = value;
		}
		public string GetPosTimeFormat(){
			return this.posTimeFormat_;
		}
		
		public void SetPosTimeFormat(string value){
			this.posTimeFormat_ = value;
		}
		public Dictionary<string, int?> GetOrderBizFlagsMap(){
			return this.orderBizFlagsMap_;
		}
		
		public void SetOrderBizFlagsMap(Dictionary<string, int?> value){
			this.orderBizFlagsMap_ = value;
		}
		public int? GetOrderBizFlags(){
			return this.orderBizFlags_;
		}
		
		public void SetOrderBizFlags(int? value){
			this.orderBizFlags_ = value;
		}
		public string GetDeliveryManId(){
			return this.deliveryManId_;
		}
		
		public void SetDeliveryManId(string value){
			this.deliveryManId_ = value;
		}
		public string GetSaleWarehouse(){
			return this.saleWarehouse_;
		}
		
		public void SetSaleWarehouse(string value){
			this.saleWarehouse_ = value;
		}
		public int? GetDeliveryType(){
			return this.deliveryType_;
		}
		
		public void SetDeliveryType(int? value){
			this.deliveryType_ = value;
		}
		public int? GetCompensateFlag(){
			return this.compensateFlag_;
		}
		
		public void SetCompensateFlag(int? value){
			this.compensateFlag_ = value;
		}
		public long? GetDeliveryPromisedTime(){
			return this.deliveryPromisedTime_;
		}
		
		public void SetDeliveryPromisedTime(long? value){
			this.deliveryPromisedTime_ = value;
		}
		public string GetPayer(){
			return this.payer_;
		}
		
		public void SetPayer(string value){
			this.payer_ = value;
		}
		public int? GetOrderBizType(){
			return this.orderBizType_;
		}
		
		public void SetOrderBizType(int? value){
			this.orderBizType_ = value;
		}
		public string GetCarriageDetail(){
			return this.carriageDetail_;
		}
		
		public void SetCarriageDetail(string value){
			this.carriageDetail_ = value;
		}
		public int? GetReserveStatus(){
			return this.reserveStatus_;
		}
		
		public void SetReserveStatus(int? value){
			this.reserveStatus_ = value;
		}
		public string GetStoreId(){
			return this.storeId_;
		}
		
		public void SetStoreId(string value){
			this.storeId_ = value;
		}
		public int? GetStoreSource(){
			return this.storeSource_;
		}
		
		public void SetStoreSource(int? value){
			this.storeSource_ = value;
		}
		public string GetChannelStoreId(){
			return this.channelStoreId_;
		}
		
		public void SetChannelStoreId(string value){
			this.channelStoreId_ = value;
		}
		public string GetDeviceKey(){
			return this.deviceKey_;
		}
		
		public void SetDeviceKey(string value){
			this.deviceKey_ = value;
		}
		
	}
	
}