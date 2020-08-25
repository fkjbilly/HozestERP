using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class ProductImageBindModel {
		
		///<summary>
		/// 商品spu_id
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// 图片对象列表
		///</summary>
		
		private List<vipapis.marketplace.product.Image> images_;
		
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
		}
		public List<vipapis.marketplace.product.Image> GetImages(){
			return this.images_;
		}
		
		public void SetImages(List<vipapis.marketplace.product.Image> value){
			this.images_ = value;
		}
		
	}
	
}