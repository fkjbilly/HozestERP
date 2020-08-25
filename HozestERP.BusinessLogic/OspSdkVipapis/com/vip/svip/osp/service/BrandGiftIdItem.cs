using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class BrandGiftIdItem {
		
		///<summary>
		/// 专场id
		///</summary>
		
		private string brandId_;
		
		///<summary>
		/// sizeId
		///</summary>
		
		private string sizeId_;
		
		public string GetBrandId(){
			return this.brandId_;
		}
		
		public void SetBrandId(string value){
			this.brandId_ = value;
		}
		public string GetSizeId(){
			return this.sizeId_;
		}
		
		public void SetSizeId(string value){
			this.sizeId_ = value;
		}
		
	}
	
}