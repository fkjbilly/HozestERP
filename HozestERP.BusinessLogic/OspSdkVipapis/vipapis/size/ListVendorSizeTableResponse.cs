using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.size{
	
	
	
	
	
	public class ListVendorSizeTableResponse {
		
		///<summary>
		/// 尺码表信息列表
		/// @sampleValue sizetables 
		///</summary>
		
		private List<vipapis.size.VendorSizeTableInfo> sizetables_;
		
		public List<vipapis.size.VendorSizeTableInfo> GetSizetables(){
			return this.sizetables_;
		}
		
		public void SetSizetables(List<vipapis.size.VendorSizeTableInfo> value){
			this.sizetables_ = value;
		}
		
	}
	
}