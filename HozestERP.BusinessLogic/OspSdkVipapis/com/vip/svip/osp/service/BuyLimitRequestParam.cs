using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class BuyLimitRequestParam {
		
		///<summary>
		/// vendorProductId 虚拟商品id
		///</summary>
		
		private long? productId_;
		
		public long? GetProductId(){
			return this.productId_;
		}
		
		public void SetProductId(long? value){
			this.productId_ = value;
		}
		
	}
	
}