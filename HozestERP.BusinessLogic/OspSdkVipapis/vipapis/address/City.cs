using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.address{
	
	
	
	
	
	public class City {
		
		///<summary>
		/// 省/市/区ID
		/// @sampleValue city_id 104104
		///</summary>
		
		private string city_id_;
		
		///<summary>
		/// 省/市/区名称
		/// @sampleValue city_name 广东省
		///</summary>
		
		private string city_name_;
		
		public string GetCity_id(){
			return this.city_id_;
		}
		
		public void SetCity_id(string value){
			this.city_id_ = value;
		}
		public string GetCity_name(){
			return this.city_name_;
		}
		
		public void SetCity_name(string value){
			this.city_name_ = value;
		}
		
	}
	
}