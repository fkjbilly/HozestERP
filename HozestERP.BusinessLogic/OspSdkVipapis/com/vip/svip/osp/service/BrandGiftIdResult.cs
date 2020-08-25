using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class BrandGiftIdResult {
		
		///<summary>
		/// 是否需要开通
		///</summary>
		
		private bool? toOpen_;
		
		///<summary>
		/// sizeId
		///</summary>
		
		private List<com.vip.svip.osp.service.BrandGiftIdItem> brandGiftIdList_;
		
		public bool? GetToOpen(){
			return this.toOpen_;
		}
		
		public void SetToOpen(bool? value){
			this.toOpen_ = value;
		}
		public List<com.vip.svip.osp.service.BrandGiftIdItem> GetBrandGiftIdList(){
			return this.brandGiftIdList_;
		}
		
		public void SetBrandGiftIdList(List<com.vip.svip.osp.service.BrandGiftIdItem> value){
			this.brandGiftIdList_ = value;
		}
		
	}
	
}