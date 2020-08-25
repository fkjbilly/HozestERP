using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetOrdersBySizeIdReq {
		
		///<summary>
		/// 商品sizeId
		///</summary>
		
		private int? sizeId_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private List<int?> orderStatusSet_;
		
		///<summary>
		/// 订单类型
		///</summary>
		
		private List<int?> orderTypeSet_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private List<int?> payTypeSet_;
		
		public int? GetSizeId(){
			return this.sizeId_;
		}
		
		public void SetSizeId(int? value){
			this.sizeId_ = value;
		}
		public List<int?> GetOrderStatusSet(){
			return this.orderStatusSet_;
		}
		
		public void SetOrderStatusSet(List<int?> value){
			this.orderStatusSet_ = value;
		}
		public List<int?> GetOrderTypeSet(){
			return this.orderTypeSet_;
		}
		
		public void SetOrderTypeSet(List<int?> value){
			this.orderTypeSet_ = value;
		}
		public List<int?> GetPayTypeSet(){
			return this.payTypeSet_;
		}
		
		public void SetPayTypeSet(List<int?> value){
			this.payTypeSet_ = value;
		}
		
	}
	
}