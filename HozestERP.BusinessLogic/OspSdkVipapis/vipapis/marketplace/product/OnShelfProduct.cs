using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class OnShelfProduct {
		
		///<summary>
		/// 商品编号spu_id列表
		///</summary>
		
		private List<string> spu_ids_;
		
		public List<string> GetSpu_ids(){
			return this.spu_ids_;
		}
		
		public void SetSpu_ids(List<string> value){
			this.spu_ids_ = value;
		}
		
	}
	
}