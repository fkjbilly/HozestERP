using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetOrderGoodsReq {
		
		///<summary>
		/// 会员id列表
		///</summary>
		
		private List<long?> userIdSet_;
		
		///<summary>
		/// 订单id列表
		///</summary>
		
		private List<long?> orderIdSet_;
		
		///<summary>
		/// 订单序列号列表
		///</summary>
		
		private List<string> orderSnSet_;
		
		///<summary>
		/// 下单时用户名
		///</summary>
		
		private string userName_;
		
		///<summary>
		/// 销售模式
		///</summary>
		
		private List<int?> saleType_;
		
		///<summary>
		/// 订单类型列表
		///</summary>
		
		private List<int?> typeList_;
		
		///<summary>
		/// 售卖频道(vipclub) 订单频道来源(*channel)
		///</summary>
		
		private string vipclub_;
		
		///<summary>
		/// 订单状态order_status
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam statusRange_;
		
		///<summary>
		/// 支付状态
		///</summary>
		
		private int? payStatus_;
		
		///<summary>
		/// 收货人姓名
		///</summary>
		
		private string buyer_;
		
		///<summary>
		/// 物流单号(transport_number)
		///</summary>
		
		private string transportSN_;
		
		///<summary>
		/// 物流公司
		///</summary>
		
		private int? transportId_;
		
		///<summary>
		/// 收货人手机号
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 查询数据范围，0 获取下单时间3个月内订单（默认），1 获取下单时间超过3个月订单
		///</summary>
		
		private int? queryRange_;
		
		///<summary>
		/// 下单时间段(add_time)
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderTimeRange_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam updateTimeRange_;
		
		///<summary>
		/// 支付类型
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam payTypeRange_;
		
		///<summary>
		/// 订单金额
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam moneyRange_;
		
		///<summary>
		/// 合并订单标示
		///</summary>
		
		private string allotTimes_;
		
		///<summary>
		/// 退换货标记
		///</summary>
		
		private int? orderFlag_;
		
		///<summary>
		/// 缺货抓取状态
		///</summary>
		
		private int? statusFlag_;
		
		///<summary>
		/// wms抓取状态
		///</summary>
		
		private int? wmsFlag_;
		
		///<summary>
		/// 保留订单标识
		///</summary>
		
		private int? isHold_;
		
		///<summary>
		/// orders.is_special
		///</summary>
		
		private int? isSpecial_;
		
		///<summary>
		/// 特殊过滤条件
		///</summary>
		
		private com.vip.order.biz.request.SpecialCondition specialCondition_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 查询订单商品子条件入参
		///</summary>
		
		private com.vip.order.biz.request.OrderGoodsCondition orderGoodsCondition_;
		
		///<summary>
		/// 售卖频道(vipclub) 订单频道来源(*channel)：支持多个查询
		///</summary>
		
		private List<string> vipclubList_;
		
		public List<long?> GetUserIdSet(){
			return this.userIdSet_;
		}
		
		public void SetUserIdSet(List<long?> value){
			this.userIdSet_ = value;
		}
		public List<long?> GetOrderIdSet(){
			return this.orderIdSet_;
		}
		
		public void SetOrderIdSet(List<long?> value){
			this.orderIdSet_ = value;
		}
		public List<string> GetOrderSnSet(){
			return this.orderSnSet_;
		}
		
		public void SetOrderSnSet(List<string> value){
			this.orderSnSet_ = value;
		}
		public string GetUserName(){
			return this.userName_;
		}
		
		public void SetUserName(string value){
			this.userName_ = value;
		}
		public List<int?> GetSaleType(){
			return this.saleType_;
		}
		
		public void SetSaleType(List<int?> value){
			this.saleType_ = value;
		}
		public List<int?> GetTypeList(){
			return this.typeList_;
		}
		
		public void SetTypeList(List<int?> value){
			this.typeList_ = value;
		}
		public string GetVipclub(){
			return this.vipclub_;
		}
		
		public void SetVipclub(string value){
			this.vipclub_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetStatusRange(){
			return this.statusRange_;
		}
		
		public void SetStatusRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.statusRange_ = value;
		}
		public int? GetPayStatus(){
			return this.payStatus_;
		}
		
		public void SetPayStatus(int? value){
			this.payStatus_ = value;
		}
		public string GetBuyer(){
			return this.buyer_;
		}
		
		public void SetBuyer(string value){
			this.buyer_ = value;
		}
		public string GetTransportSN(){
			return this.transportSN_;
		}
		
		public void SetTransportSN(string value){
			this.transportSN_ = value;
		}
		public int? GetTransportId(){
			return this.transportId_;
		}
		
		public void SetTransportId(int? value){
			this.transportId_ = value;
		}
		public string GetMobile(){
			return this.mobile_;
		}
		
		public void SetMobile(string value){
			this.mobile_ = value;
		}
		public int? GetQueryRange(){
			return this.queryRange_;
		}
		
		public void SetQueryRange(int? value){
			this.queryRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderTimeRange(){
			return this.orderTimeRange_;
		}
		
		public void SetOrderTimeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderTimeRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetUpdateTimeRange(){
			return this.updateTimeRange_;
		}
		
		public void SetUpdateTimeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.updateTimeRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetPayTypeRange(){
			return this.payTypeRange_;
		}
		
		public void SetPayTypeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.payTypeRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetMoneyRange(){
			return this.moneyRange_;
		}
		
		public void SetMoneyRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.moneyRange_ = value;
		}
		public string GetAllotTimes(){
			return this.allotTimes_;
		}
		
		public void SetAllotTimes(string value){
			this.allotTimes_ = value;
		}
		public int? GetOrderFlag(){
			return this.orderFlag_;
		}
		
		public void SetOrderFlag(int? value){
			this.orderFlag_ = value;
		}
		public int? GetStatusFlag(){
			return this.statusFlag_;
		}
		
		public void SetStatusFlag(int? value){
			this.statusFlag_ = value;
		}
		public int? GetWmsFlag(){
			return this.wmsFlag_;
		}
		
		public void SetWmsFlag(int? value){
			this.wmsFlag_ = value;
		}
		public int? GetIsHold(){
			return this.isHold_;
		}
		
		public void SetIsHold(int? value){
			this.isHold_ = value;
		}
		public int? GetIsSpecial(){
			return this.isSpecial_;
		}
		
		public void SetIsSpecial(int? value){
			this.isSpecial_ = value;
		}
		public com.vip.order.biz.request.SpecialCondition GetSpecialCondition(){
			return this.specialCondition_;
		}
		
		public void SetSpecialCondition(com.vip.order.biz.request.SpecialCondition value){
			this.specialCondition_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public com.vip.order.biz.request.OrderGoodsCondition GetOrderGoodsCondition(){
			return this.orderGoodsCondition_;
		}
		
		public void SetOrderGoodsCondition(com.vip.order.biz.request.OrderGoodsCondition value){
			this.orderGoodsCondition_ = value;
		}
		public List<string> GetVipclubList(){
			return this.vipclubList_;
		}
		
		public void SetVipclubList(List<string> value){
			this.vipclubList_ = value;
		}
		
	}
	
}