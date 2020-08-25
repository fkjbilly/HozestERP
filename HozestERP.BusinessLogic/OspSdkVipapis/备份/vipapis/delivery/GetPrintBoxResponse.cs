using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetPrintBoxResponse {
		
		///<summary>
		/// 打印页面信息
		///</summary>
		
		private string template_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public string GetTemplate(){
			return this.template_;
		}
		
		public void SetTemplate(string value){
			this.template_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}