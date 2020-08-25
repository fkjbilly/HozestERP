using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.account{
	
	
	
	
	
	public class EnterpriseOrderResponse {
		
		///<summary>
		/// 返回查询到订单数的总数量
		/// @sampleValue total 100
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 查询到的订单列表
		///</summary>
		
		private List<vipapis.account.EnterpriseOrderInfo> enterpriseOrders_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.account.EnterpriseOrderInfo> GetEnterpriseOrders(){
			return this.enterpriseOrders_;
		}
		
		public void SetEnterpriseOrders(List<vipapis.account.EnterpriseOrderInfo> value){
			this.enterpriseOrders_ = value;
		}
		
	}
	
}