using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class PrintInvoiceResp {
		
		///<summary>
		/// 是否处理成功(true:全部成功,false:全部失败)
		///</summary>
		
		private bool? is_success_;
		
		///<summary>
		/// 失败信息
		///</summary>
		
		private string failure_msg_;
		
		public bool? GetIs_success(){
			return this.is_success_;
		}
		
		public void SetIs_success(bool? value){
			this.is_success_ = value;
		}
		public string GetFailure_msg(){
			return this.failure_msg_;
		}
		
		public void SetFailure_msg(string value){
			this.failure_msg_ = value;
		}
		
	}
	
}