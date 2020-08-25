using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class SaleProps {
		
		///<summary>
		/// 属性id
		/// @sampleValue props_id 134
		///</summary>
		
		private int? props_id_;
		
		///<summary>
		/// 属性名称
		/// @sampleValue props_name 颜色
		///</summary>
		
		private string props_name_;
		
		///<summary>
		/// 属性值
		/// @sampleValue props_value 白色
		///</summary>
		
		private string props_value_;
		
		public int? GetProps_id(){
			return this.props_id_;
		}
		
		public void SetProps_id(int? value){
			this.props_id_ = value;
		}
		public string GetProps_name(){
			return this.props_name_;
		}
		
		public void SetProps_name(string value){
			this.props_name_ = value;
		}
		public string GetProps_value(){
			return this.props_value_;
		}
		
		public void SetProps_value(string value){
			this.props_value_ = value;
		}
		
	}
	
}