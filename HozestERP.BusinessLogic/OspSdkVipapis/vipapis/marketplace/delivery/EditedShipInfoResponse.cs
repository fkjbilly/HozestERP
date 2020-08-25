using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class EditedShipInfoResponse {
		
		///<summary>
		/// 更改结果,Success 表示成功
		///</summary>
		
		private string result_;
		
		public string GetResult(){
			return this.result_;
		}
		
		public void SetResult(string value){
			this.result_ = value;
		}
		
	}
	
}