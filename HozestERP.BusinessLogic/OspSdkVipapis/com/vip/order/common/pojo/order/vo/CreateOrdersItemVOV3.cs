using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class CreateOrdersItemVOV3 {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单类型
		///</summary>
		
		private int? orderCategory_;
		
		///<summary>
		/// 订单组号
		///</summary>
		
		private string orderGroupSn_;
		
		///<summary>
		/// 返回码
		///</summary>
		
		private string retCode_;
		
		///<summary>
		/// 返回消息
		///</summary>
		
		private string retMessage_;
		
		///<summary>
		/// 订单流水号列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderCodeVO> orderCodeList_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public int? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(int? value){
			this.orderCategory_ = value;
		}
		public string GetOrderGroupSn(){
			return this.orderGroupSn_;
		}
		
		public void SetOrderGroupSn(string value){
			this.orderGroupSn_ = value;
		}
		public string GetRetCode(){
			return this.retCode_;
		}
		
		public void SetRetCode(string value){
			this.retCode_ = value;
		}
		public string GetRetMessage(){
			return this.retMessage_;
		}
		
		public void SetRetMessage(string value){
			this.retMessage_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderCodeVO> GetOrderCodeList(){
			return this.orderCodeList_;
		}
		
		public void SetOrderCodeList(List<com.vip.order.common.pojo.order.vo.OrderCodeVO> value){
			this.orderCodeList_ = value;
		}
		
	}
	
}