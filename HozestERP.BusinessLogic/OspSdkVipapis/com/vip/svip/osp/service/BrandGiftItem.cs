using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class BrandGiftItem {
		
		///<summary>
		/// 品牌logo
		///</summary>
		
		private string brandLogo_;
		
		///<summary>
		/// 专场ID
		///</summary>
		
		private string salesNo_;
		
		///<summary>
		/// 专场名称
		///</summary>
		
		private string salesName_;
		
		///<summary>
		/// 买赠tips
		///</summary>
		
		private string tips_;
		
		///<summary>
		/// 赠品名称
		///</summary>
		
		private string giftGoodsName_;
		
		///<summary>
		/// 赠品图片
		///</summary>
		
		private string giftGoodsImage_;
		
		public string GetBrandLogo(){
			return this.brandLogo_;
		}
		
		public void SetBrandLogo(string value){
			this.brandLogo_ = value;
		}
		public string GetSalesNo(){
			return this.salesNo_;
		}
		
		public void SetSalesNo(string value){
			this.salesNo_ = value;
		}
		public string GetSalesName(){
			return this.salesName_;
		}
		
		public void SetSalesName(string value){
			this.salesName_ = value;
		}
		public string GetTips(){
			return this.tips_;
		}
		
		public void SetTips(string value){
			this.tips_ = value;
		}
		public string GetGiftGoodsName(){
			return this.giftGoodsName_;
		}
		
		public void SetGiftGoodsName(string value){
			this.giftGoodsName_ = value;
		}
		public string GetGiftGoodsImage(){
			return this.giftGoodsImage_;
		}
		
		public void SetGiftGoodsImage(string value){
			this.giftGoodsImage_ = value;
		}
		
	}
	
}