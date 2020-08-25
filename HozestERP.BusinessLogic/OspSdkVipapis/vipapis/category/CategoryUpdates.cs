using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.category{
	
	
	
	
	
	public class CategoryUpdates {
		
		///<summary>
		/// 变更开始时间
		///</summary>
		
		private long? sinceUpdateTime_;
		
		///<summary>
		/// 变更结束时间
		///</summary>
		
		private long? lastUpdateTime_;
		
		///<summary>
		/// 变更节点集合
		///</summary>
		
		private List<vipapis.category.CategoryUpdate> categories_;
		
		public long? GetSinceUpdateTime(){
			return this.sinceUpdateTime_;
		}
		
		public void SetSinceUpdateTime(long? value){
			this.sinceUpdateTime_ = value;
		}
		public long? GetLastUpdateTime(){
			return this.lastUpdateTime_;
		}
		
		public void SetLastUpdateTime(long? value){
			this.lastUpdateTime_ = value;
		}
		public List<vipapis.category.CategoryUpdate> GetCategories(){
			return this.categories_;
		}
		
		public void SetCategories(List<vipapis.category.CategoryUpdate> value){
			this.categories_ = value;
		}
		
	}
	
}