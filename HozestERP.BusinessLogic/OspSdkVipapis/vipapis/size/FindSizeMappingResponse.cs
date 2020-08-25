using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.size{
	
	
	
	
	
	public class FindSizeMappingResponse {
		
		///<summary>
		/// 尺码匹配列表
		///</summary>
		
		private List<vipapis.size.SizeMapping> size_mappings_;
		
		public List<vipapis.size.SizeMapping> GetSize_mappings(){
			return this.size_mappings_;
		}
		
		public void SetSize_mappings(List<vipapis.size.SizeMapping> value){
			this.size_mappings_ = value;
		}
		
	}
	
}