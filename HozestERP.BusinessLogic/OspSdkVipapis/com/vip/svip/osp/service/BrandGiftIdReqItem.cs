using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class BrandGiftIdReqItem {
		
		///<summary>
		/// 专场id
		///</summary>
		
		private long? brandId_;
		
		///<summary>
		/// sizeId
		///</summary>
		
		private long? sizeId_;
		
		public long? GetBrandId(){
			return this.brandId_;
		}
		
		public void SetBrandId(long? value){
			this.brandId_ = value;
		}
		public long? GetSizeId(){
			return this.sizeId_;
		}
		
		public void SetSizeId(long? value){
			this.sizeId_ = value;
		}
		
	}
	
}