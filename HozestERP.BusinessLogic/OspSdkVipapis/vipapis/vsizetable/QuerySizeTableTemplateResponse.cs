using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vsizetable{
	
	
	
	
	
	public class QuerySizeTableTemplateResponse {
		
		///<summary>
		/// 尺码表模板列表
		///</summary>
		
		private List<vipapis.vsizetable.SizeTableTemplate> sizetable_template_list_;
		
		public List<vipapis.vsizetable.SizeTableTemplate> GetSizetable_template_list(){
			return this.sizetable_template_list_;
		}
		
		public void SetSizetable_template_list(List<vipapis.vsizetable.SizeTableTemplate> value){
			this.sizetable_template_list_ = value;
		}
		
	}
	
}