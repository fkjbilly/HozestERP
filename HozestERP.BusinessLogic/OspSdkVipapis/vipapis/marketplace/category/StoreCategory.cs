using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.category{
	
	
	
	
	
	public class StoreCategory {
		
		///<summary>
		/// 三级类目id
		/// @sampleValue category_id 1100
		///</summary>
		
		private int? category_id_;
		
		public int? GetCategory_id(){
			return this.category_id_;
		}
		
		public void SetCategory_id(int? value){
			this.category_id_ = value;
		}
		
	}
	
}