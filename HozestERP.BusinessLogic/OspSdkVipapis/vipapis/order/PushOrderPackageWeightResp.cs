using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class PushOrderPackageWeightResp {
		
		///<summary>
		/// 成功订单列表
		///</summary>
		
		private List<string> success_list_;
		
		///<summary>
		/// 失败订单列表和失败原因
		///</summary>
		
		private List<vipapis.order.FailItem> fail_list_;
		
		public List<string> GetSuccess_list(){
			return this.success_list_;
		}
		
		public void SetSuccess_list(List<string> value){
			this.success_list_ = value;
		}
		public List<vipapis.order.FailItem> GetFail_list(){
			return this.fail_list_;
		}
		
		public void SetFail_list(List<vipapis.order.FailItem> value){
			this.fail_list_ = value;
		}
		
	}
	
}