using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.category{
	
	
	
	
	
	public class CategoryUpdate {
		
		///<summary>
		/// 更新类型
		///</summary>
		
		private vipapis.category.UpdateType? updateType_;
		
		///<summary>
		/// 变更分类节点
		///</summary>
		
		private vipapis.category.Category category_;
		
		public vipapis.category.UpdateType? GetUpdateType(){
			return this.updateType_;
		}
		
		public void SetUpdateType(vipapis.category.UpdateType? value){
			this.updateType_ = value;
		}
		public vipapis.category.Category GetCategory(){
			return this.category_;
		}
		
		public void SetCategory(vipapis.category.Category value){
			this.category_ = value;
		}
		
	}
	
}