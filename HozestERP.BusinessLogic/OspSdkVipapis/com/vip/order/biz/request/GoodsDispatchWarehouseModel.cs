using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GoodsDispatchWarehouseModel {
		
		///<summary>
		/// 商品sizeId
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 库存占用号
		///</summary>
		
		private string posNo_;
		
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public string GetPosNo(){
			return this.posNo_;
		}
		
		public void SetPosNo(string value){
			this.posNo_ = value;
		}
		
	}
	
}