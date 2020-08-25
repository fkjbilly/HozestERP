using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class SearchOrderDetailReq {
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单sn列表
		///</summary>
		
		private List<string> orderSnList_;
		
		///<summary>
		/// 订单id列表
		///</summary>
		
		private List<long?> idList_;
		
		///<summary>
		/// 订单模式(0:普通，1：预售)
		///</summary>
		
		private int? orderCategory_;
		
		///<summary>
		/// 代金券ID
		///</summary>
		
		private string couponId_;
		
		///<summary>
		/// 特殊条件
		///</summary>
		
		private string specialCondition_;
		
		///<summary>
		/// 返回结果字段
		///</summary>
		
		private Dictionary<string, string> returnFields_;
		
		///<summary>
		/// 查询预付订单方式, 取值为parent_sn或order_code.取parent_sn时,orderSn传入值看做为vip_order_presell.parent_sn进行查询;取order_code时, orderSn传入值看作为vip_order_presell.order_code进行查询;
		///</summary>
		
		private string snType_;
		
		///<summary>
		/// 是否隐藏(0正常，1隐藏)
		///</summary>
		
		private int? isDisplay_;
		
		///<summary>
		/// 来源频道
		///</summary>
		
		private string vipclub_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public List<string> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<string> value){
			this.orderSnList_ = value;
		}
		public List<long?> GetIdList(){
			return this.idList_;
		}
		
		public void SetIdList(List<long?> value){
			this.idList_ = value;
		}
		public int? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(int? value){
			this.orderCategory_ = value;
		}
		public string GetCouponId(){
			return this.couponId_;
		}
		
		public void SetCouponId(string value){
			this.couponId_ = value;
		}
		public string GetSpecialCondition(){
			return this.specialCondition_;
		}
		
		public void SetSpecialCondition(string value){
			this.specialCondition_ = value;
		}
		public Dictionary<string, string> GetReturnFields(){
			return this.returnFields_;
		}
		
		public void SetReturnFields(Dictionary<string, string> value){
			this.returnFields_ = value;
		}
		public string GetSnType(){
			return this.snType_;
		}
		
		public void SetSnType(string value){
			this.snType_ = value;
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
		
	}
	
}