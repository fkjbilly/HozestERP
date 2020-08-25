using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.sizetable{
	
	
	
	
	
	public class GetSizeTableTemplateResponse {
		
		///<summary>
		/// 尺码表模板列表
		///</summary>
		
		private List<vipapis.marketplace.sizetable.SizeTableTemplate> size_table_templates_;
		
		public List<vipapis.marketplace.sizetable.SizeTableTemplate> GetSize_table_templates(){
			return this.size_table_templates_;
		}
		
		public void SetSize_table_templates(List<vipapis.marketplace.sizetable.SizeTableTemplate> value){
			this.size_table_templates_ = value;
		}
		
	}
	
}