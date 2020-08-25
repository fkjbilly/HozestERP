using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetOrderPayTypeReq {
		
		///<summary>
		/// 订单号列表
		///</summary>
		
		private List<string> orderSnSet_;
		
		///<summary>
		/// 来源列表
		///</summary>
		
		private List<int?> sourceSet_;
		
		public List<string> GetOrderSnSet(){
			return this.orderSnSet_;
		}
		
		public void SetOrderSnSet(List<string> value){
			this.orderSnSet_ = value;
		}
		public List<int?> GetSourceSet(){
			return this.sourceSet_;
		}
		
		public void SetSourceSet(List<int?> value){
			this.sourceSet_ = value;
		}
		
	}
	
}