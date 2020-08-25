using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class Carrier {
		
		///<summary>
		/// tms端承运商ID
		/// @sampleValue tms_carrier_id 
		///</summary>
		
		private string tms_carrier_id_;
		
		///<summary>
		/// 承运商全称
		/// @sampleValue carrier_name 
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 承运商简称
		/// @sampleValue carrier_shortname 
		///</summary>
		
		private string carrier_shortname_;
		
		///<summary>
		/// 承运商编码
		/// @sampleValue carrier_code 
		///</summary>
		
		private string carrier_code_;
		
		///<summary>
		/// 承运商状态 1启用， 0 关闭
		/// @sampleValue carrier_isvalid 
		///</summary>
		
		private int? carrier_isvalid_;
		
		public string GetTms_carrier_id(){
			return this.tms_carrier_id_;
		}
		
		public void SetTms_carrier_id(string value){
			this.tms_carrier_id_ = value;
		}
		public string GetCarrier_name(){
			return this.carrier_name_;
		}
		
		public void SetCarrier_name(string value){
			this.carrier_name_ = value;
		}
		public string GetCarrier_shortname(){
			return this.carrier_shortname_;
		}
		
		public void SetCarrier_shortname(string value){
			this.carrier_shortname_ = value;
		}
		public string GetCarrier_code(){
			return this.carrier_code_;
		}
		
		public void SetCarrier_code(string value){
			this.carrier_code_ = value;
		}
		public int? GetCarrier_isvalid(){
			return this.carrier_isvalid_;
		}
		
		public void SetCarrier_isvalid(int? value){
			this.carrier_isvalid_ = value;
		}
		
	}
	
}