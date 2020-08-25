using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderSource {
		
		///<summary>
		/// 寻源范围-省份
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 省份编码
		///</summary>
		
		private string province_code_;
		
		public string GetProvince(){
			return this.province_;
		}
		
		public void SetProvince(string value){
			this.province_ = value;
		}
		public string GetProvince_code(){
			return this.province_code_;
		}
		
		public void SetProvince_code(string value){
			this.province_code_ = value;
		}
		
	}
	
}