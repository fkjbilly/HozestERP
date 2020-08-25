using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class OffShelfProduct {
		
		///<summary>
		/// 商品编号spu_id列表
		///</summary>
		
		private List<string> spu_ids_;
		
		///<summary>
		/// 下架原因:1-人工下架,2-自动下架(商品不健康),3-自动下架(店铺状态异常)
		///</summary>
		
		private int? off_shelf_reason_;
		
		public List<string> GetSpu_ids(){
			return this.spu_ids_;
		}
		
		public void SetSpu_ids(List<string> value){
			this.spu_ids_ = value;
		}
		public int? GetOff_shelf_reason(){
			return this.off_shelf_reason_;
		}
		
		public void SetOff_shelf_reason(int? value){
			this.off_shelf_reason_ = value;
		}
		
	}
	
}