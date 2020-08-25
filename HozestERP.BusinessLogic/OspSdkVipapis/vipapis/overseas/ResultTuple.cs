using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class ResultTuple {
		
		///<summary>
		/// id 或者 唯一的key
		/// @sampleValue id 58261111
		///</summary>
		
		private string id_;
		
		///<summary>
		/// 处理结果的message,成功时默认为SUCCESS，其它情况记录错误信息
		///</summary>
		
		private string message_;
		
		public string GetId(){
			return this.id_;
		}
		
		public void SetId(string value){
			this.id_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		
	}
	
}