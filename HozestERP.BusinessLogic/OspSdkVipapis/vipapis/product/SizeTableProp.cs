using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class SizeTableProp {
		
		///<summary>
		/// 温馨提示
		/// @sampleValue size_table_tips 
		///</summary>
		
		private string size_table_tips_;
		
		///<summary>
		/// 尺码详情
		/// @sampleValue size_detail_property_values Map<尺码:S,号型:A12>
		///</summary>
		
		private Dictionary<string, string> size_detail_property_values_;
		
		public string GetSize_table_tips(){
			return this.size_table_tips_;
		}
		
		public void SetSize_table_tips(string value){
			this.size_table_tips_ = value;
		}
		public Dictionary<string, string> GetSize_detail_property_values(){
			return this.size_detail_property_values_;
		}
		
		public void SetSize_detail_property_values(Dictionary<string, string> value){
			this.size_detail_property_values_ = value;
		}
		
	}
	
}