using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class TransportInfo {
		
		///<summary>
		/// 时间(Epoch格式, 精确到秒)
		///</summary>
		
		private int? datetime_;
		
		///<summary>
		/// 操作员
		///</summary>
		
		private string user_;
		
		///<summary>
		/// 状态描述
		///</summary>
		
		private string remark_;
		
		public int? GetDatetime(){
			return this.datetime_;
		}
		
		public void SetDatetime(int? value){
			this.datetime_ = value;
		}
		public string GetUser(){
			return this.user_;
		}
		
		public void SetUser(string value){
			this.user_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}