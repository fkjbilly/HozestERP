using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.size{
	
	
	
	
	
	public class SizeMapping {
		
		///<summary>
		/// 三级类目id
		///</summary>
		
		private int? category_id_;
		
		///<summary>
		/// 三级类目名称
		///</summary>
		
		private string category_name_;
		
		///<summary>
		/// 尺码表属性
		///</summary>
		
		private List<string> size_table_attrs_;
		
		///<summary>
		/// 说明性图片
		///</summary>
		
		private string illustrative_image_;
		
		public int? GetCategory_id(){
			return this.category_id_;
		}
		
		public void SetCategory_id(int? value){
			this.category_id_ = value;
		}
		public string GetCategory_name(){
			return this.category_name_;
		}
		
		public void SetCategory_name(string value){
			this.category_name_ = value;
		}
		public List<string> GetSize_table_attrs(){
			return this.size_table_attrs_;
		}
		
		public void SetSize_table_attrs(List<string> value){
			this.size_table_attrs_ = value;
		}
		public string GetIllustrative_image(){
			return this.illustrative_image_;
		}
		
		public void SetIllustrative_image(string value){
			this.illustrative_image_ = value;
		}
		
	}
	
}