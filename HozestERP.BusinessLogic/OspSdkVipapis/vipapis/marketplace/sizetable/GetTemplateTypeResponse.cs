using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.sizetable{
	
	
	
	
	
	public class GetTemplateTypeResponse {
		
		///<summary>
		/// 店铺尺码表维度信息列表
		///</summary>
		
		private List<vipapis.marketplace.sizetable.TemplateType> template_types_;
		
		public List<vipapis.marketplace.sizetable.TemplateType> GetTemplate_types(){
			return this.template_types_;
		}
		
		public void SetTemplate_types(List<vipapis.marketplace.sizetable.TemplateType> value){
			this.template_types_ = value;
		}
		
	}
	
}