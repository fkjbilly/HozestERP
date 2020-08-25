using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class ModifyPayTypeReq {
		
		///<summary>
		/// 更新订单支付方式请求
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderInfoForReq> modifyPayTypeReq_;
		
		///<summary>
		/// 订单类别(普通或者预付)
		///</summary>
		
		private int? orderCategory_;
		
		public List<com.vip.order.common.pojo.order.vo.OrderInfoForReq> GetModifyPayTypeReq(){
			return this.modifyPayTypeReq_;
		}
		
		public void SetModifyPayTypeReq(List<com.vip.order.common.pojo.order.vo.OrderInfoForReq> value){
			this.modifyPayTypeReq_ = value;
		}
		public int? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(int? value){
			this.orderCategory_ = value;
		}
		
	}
	
}