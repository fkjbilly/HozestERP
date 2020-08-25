using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class OfcEntranceGrayControlReq {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> orderSnAndIdList_;
		
		///<summary>
		/// 0 普通 1预付
		///</summary>
		
		private int? orderCategory_;
		
		///<summary>
		/// 当查询预付单时，指示orderSn 为order_code 或者 parent_sn
		///</summary>
		
		private string snType_;
		
		public List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> GetOrderSnAndIdList(){
			return this.orderSnAndIdList_;
		}
		
		public void SetOrderSnAndIdList(List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value){
			this.orderSnAndIdList_ = value;
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
		
	}
	
}