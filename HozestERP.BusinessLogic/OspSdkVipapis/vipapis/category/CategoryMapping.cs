using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.category{
	
	
	
	
	
	public class CategoryMapping {
		
		///<summary>
		/// 源分类
		///</summary>
		
		private vipapis.category.Category sourcecategory_;
		
		///<summary>
		/// 属性条件, 格式：属性ID1:选项ID1,选项ID2|属性ID2:选项ID1,选项ID2
		///</summary>
		
		private string filter_;
		
		public vipapis.category.Category GetSourcecategory(){
			return this.sourcecategory_;
		}
		
		public void SetSourcecategory(vipapis.category.Category value){
			this.sourcecategory_ = value;
		}
		public string GetFilter(){
			return this.filter_;
		}
		
		public void SetFilter(string value){
			this.filter_ = value;
		}
		
	}
	
}