using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class Carrier {
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carrier_code_;
		
		///<summary>
		/// 承运商简称
		///</summary>
		
		private string carrier_shortname_;
		
		///<summary>
		/// 承运商全称
		///</summary>
		
		private string carrier_name_;
		
		public string GetCarrier_code(){
			return this.carrier_code_;
		}
		
		public void SetCarrier_code(string value){
			this.carrier_code_ = value;
		}
		public string GetCarrier_shortname(){
			return this.carrier_shortname_;
		}
		
		public void SetCarrier_shortname(string value){
			this.carrier_shortname_ = value;
		}
		public string GetCarrier_name(){
			return this.carrier_name_;
		}
		
		public void SetCarrier_name(string value){
			this.carrier_name_ = value;
		}
		
	}
	
}