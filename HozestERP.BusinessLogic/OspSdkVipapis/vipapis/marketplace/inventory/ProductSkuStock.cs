using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.inventory{
	
	
	
	
	
	public class ProductSkuStock {
		
		///<summary>
		/// sku唯一标识
		///</summary>
		
		private string productSkuId_;
		
		///<summary>
		/// 仓库编码,商品开启分区售卖时，如果要为商家自定义仓设置库存，则必填，不传仓库编码时，库存将默认设置在商家全国仓上
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 库存数量，全量时不能为负数
		///</summary>
		
		private int? quantity_;
		
		public string GetProductSkuId(){
			return this.productSkuId_;
		}
		
		public void SetProductSkuId(string value){
			this.productSkuId_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		
	}
	
}