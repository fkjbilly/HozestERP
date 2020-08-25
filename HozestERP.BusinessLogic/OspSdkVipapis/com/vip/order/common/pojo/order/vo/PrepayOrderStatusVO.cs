using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class PrepayOrderStatusVO {
		
		///<summary>
		/// 状态码
		///</summary>
		
		private int? statusCode_;
		
		///<summary>
		/// 状态名
		///</summary>
		
		private string statusName_;
		
		public int? GetStatusCode(){
			return this.statusCode_;
		}
		
		public void SetStatusCode(int? value){
			this.statusCode_ = value;
		}
		public string GetStatusName(){
			return this.statusName_;
		}
		
		public void SetStatusName(string value){
			this.statusName_ = value;
		}
		
	}
	
}