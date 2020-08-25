using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class CreateBatchResponse {
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batch_no_;
		
		public string GetBatch_no(){
			return this.batch_no_;
		}
		
		public void SetBatch_no(string value){
			this.batch_no_ = value;
		}
		
	}
	
}