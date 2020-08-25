using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetOrderByUserIdReq {
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单ID列表
		///</summary>
		
		private List<long?> orderIdList_;
		
		///<summary>
		/// 订单序列号列表
		///</summary>
		
		private List<string> orderSnList_;
		
		///<summary>
		/// 订单种类
		///</summary>
		
		private int? orderCategory_;
		
		///<summary>
		/// order_sn类型 
		///</summary>
		
		private string snType_;
		
		///<summary>
		/// 销售模式
		///</summary>
		
		private List<int?> saleType_;
		
		///<summary>
		/// 订单类型范围
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam typeRange_;
		
		///<summary>
		/// 订单模式(0:普通，1：预售)
		///</summary>
		
		private List<int?> orderModelList_;
		
		///<summary>
		/// 售卖频道(vipclub) 订单频道来源
		///</summary>
		
		private List<string> vipclubList_;
		
		///<summary>
		/// 订单状态order_status
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam statusRange_;
		
		///<summary>
		/// 订单子状态0无异常 1海淘身份验证未通过
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam subStatusRange_;
		
		///<summary>
		/// 支付状态
		///</summary>
		
		private int? payStatus_;
		
		///<summary>
		/// 下单时间段(add_time)
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderTimeRange_;
		
		///<summary>
		/// 下单日期(order_date)
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderDateRange_;
		
		///<summary>
		/// 是否被用户隐藏的订单
		///</summary>
		
		private int? isDisplay_;
		
		///<summary>
		/// 订单来源类型 0:正常下单 1:换货订单 2:修改订单 3:合并订单
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderSourceTypeRange_;
		
		///<summary>
		/// is_first(预付中使用)
		///</summary>
		
		private int? isFirst_;
		
		///<summary>
		/// is_lock(预付中使用)
		///</summary>
		
		private int? isLock_;
		
		///<summary>
		/// 赔付类型
		///</summary>
		
		private List<int?> deliveryTypeList_;
		
		///<summary>
		/// 慢必赔标识
		///</summary>
		
		private List<int?> compensateFlagList_;
		
		///<summary>
		/// Marketplace店铺ID
		///</summary>
		
		private string storeId_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public List<long?> GetOrderIdList(){
			return this.orderIdList_;
		}
		
		public void SetOrderIdList(List<long?> value){
			this.orderIdList_ = value;
		}
		public List<string> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<string> value){
			this.orderSnList_ = value;
		}
		public int? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(int? value){
			this.orderCategory_ = value;
		}
		public string GetSnType(){
			return this.snType_;
		}
		
		public void SetSnType(string value){
			this.snType_ = value;
		}
		public List<int?> GetSaleType(){
			return this.saleType_;
		}
		
		public void SetSaleType(List<int?> value){
			this.saleType_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetTypeRange(){
			return this.typeRange_;
		}
		
		public void SetTypeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.typeRange_ = value;
		}
		public List<int?> GetOrderModelList(){
			return this.orderModelList_;
		}
		
		public void SetOrderModelList(List<int?> value){
			this.orderModelList_ = value;
		}
		public List<string> GetVipclubList(){
			return this.vipclubList_;
		}
		
		public void SetVipclubList(List<string> value){
			this.vipclubList_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetStatusRange(){
			return this.statusRange_;
		}
		
		public void SetStatusRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.statusRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetSubStatusRange(){
			return this.subStatusRange_;
		}
		
		public void SetSubStatusRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.subStatusRange_ = value;
		}
		public int? GetPayStatus(){
			return this.payStatus_;
		}
		
		public void SetPayStatus(int? value){
			this.payStatus_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderTimeRange(){
			return this.orderTimeRange_;
		}
		
		public void SetOrderTimeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderTimeRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderDateRange(){
			return this.orderDateRange_;
		}
		
		public void SetOrderDateRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderDateRange_ = value;
		}
		public int? GetIsDisplay(){
			return this.isDisplay_;
		}
		
		public void SetIsDisplay(int? value){
			this.isDisplay_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderSourceTypeRange(){
			return this.orderSourceTypeRange_;
		}
		
		public void SetOrderSourceTypeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderSourceTypeRange_ = value;
		}
		public int? GetIsFirst(){
			return this.isFirst_;
		}
		
		public void SetIsFirst(int? value){
			this.isFirst_ = value;
		}
		public int? GetIsLock(){
			return this.isLock_;
		}
		
		public void SetIsLock(int? value){
			this.isLock_ = value;
		}
		public List<int?> GetDeliveryTypeList(){
			return this.deliveryTypeList_;
		}
		
		public void SetDeliveryTypeList(List<int?> value){
			this.deliveryTypeList_ = value;
		}
		public List<int?> GetCompensateFlagList(){
			return this.compensateFlagList_;
		}
		
		public void SetCompensateFlagList(List<int?> value){
			this.compensateFlagList_ = value;
		}
		public string GetStoreId(){
			return this.storeId_;
		}
		
		public void SetStoreId(string value){
			this.storeId_ = value;
		}
		
	}
	
}