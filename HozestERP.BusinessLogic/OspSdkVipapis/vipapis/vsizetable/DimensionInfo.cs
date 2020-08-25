using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vsizetable{
	
	
	
	
	
	public class DimensionInfo {
		
		///<summary>
		/// 尺码表模板类型。例：0：文胸，1：成人上装 等
		///</summary>
		
		private int? template_type_id_;
		
		///<summary>
		/// 尺码表模板类型名称
		///</summary>
		
		private string template_type_name_;
		
		///<summary>
		/// 该尺码表类型的尺码表属性列表：尺码、中国码、欧洲码、脚长等
		///</summary>
		
		private List<string> template_properties_;
		
		public int? GetTemplate_type_id(){
			return this.template_type_id_;
		}
		
		public void SetTemplate_type_id(int? value){
			this.template_type_id_ = value;
		}
		public string GetTemplate_type_name(){
			return this.template_type_name_;
		}
		
		public void SetTemplate_type_name(string value){
			this.template_type_name_ = value;
		}
		public List<string> GetTemplate_properties(){
			return this.template_properties_;
		}
		
		public void SetTemplate_properties(List<string> value){
			this.template_properties_ = value;
		}
		
	}
	
}