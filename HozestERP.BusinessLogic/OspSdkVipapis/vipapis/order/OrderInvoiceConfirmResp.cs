using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderInvoiceConfirmResp {
		
		///<summary>
		/// 成功列表
		///</summary>
		
		private List<string> success_list_;
		
		///<summary>
		/// 失败列表
		///</summary>
		
		private List<vipapis.order.FailConfirmItem> fail_list_;
		
		public List<string> GetSuccess_list(){
			return this.success_list_;
		}
		
		public void SetSuccess_list(List<string> value){
			this.success_list_ = value;
		}
		public List<vipapis.order.FailConfirmItem> GetFail_list(){
			return this.fail_list_;
		}
		
		public void SetFail_list(List<vipapis.order.FailConfirmItem> value){
			this.fail_list_ = value;
		}
		
	}
	
}