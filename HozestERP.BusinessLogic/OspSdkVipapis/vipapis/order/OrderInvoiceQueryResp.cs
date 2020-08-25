using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderInvoiceQueryResp {
		
		///<summary>
		/// 成功列表
		///</summary>
		
		private List<vipapis.order.OrderInvoiceResp> success_list_;
		
		///<summary>
		/// 失败列表
		///</summary>
		
		private List<vipapis.order.FailQueryItem> fail_list_;
		
		public List<vipapis.order.OrderInvoiceResp> GetSuccess_list(){
			return this.success_list_;
		}
		
		public void SetSuccess_list(List<vipapis.order.OrderInvoiceResp> value){
			this.success_list_ = value;
		}
		public List<vipapis.order.FailQueryItem> GetFail_list(){
			return this.fail_list_;
		}
		
		public void SetFail_list(List<vipapis.order.FailQueryItem> value){
			this.fail_list_ = value;
		}
		
	}
	
}