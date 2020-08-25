using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.sizetable{
	
	
	
	
	
	public class GetSizeTableTemplateRequest {
		
		///<summary>
		/// 页码参数
		/// @sampleValue page 1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 返回结果数量(默认为50,最大支持100)
		/// @sampleValue limit 50
		///</summary>
		
		private int? limit_;
		
		///<summary>
		/// 尺码表模板id
		/// @sampleValue size_table_template_id 135644
		///</summary>
		
		private int? size_table_template_id_;
		
		///<summary>
		/// 尺码表模板名称
		/// @sampleValue size_table_template_name 中码
		///</summary>
		
		private string size_table_template_name_;
		
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		public int? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(int? value){
			this.limit_ = value;
		}
		public int? GetSize_table_template_id(){
			return this.size_table_template_id_;
		}
		
		public void SetSize_table_template_id(int? value){
			this.size_table_template_id_ = value;
		}
		public string GetSize_table_template_name(){
			return this.size_table_template_name_;
		}
		
		public void SetSize_table_template_name(string value){
			this.size_table_template_name_ = value;
		}
		
	}
	
}