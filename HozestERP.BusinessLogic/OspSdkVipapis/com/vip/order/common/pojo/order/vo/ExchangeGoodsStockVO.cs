using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class ExchangeGoodsStockVO {
		
		///<summary>
		/// 档期、专场的SKU id(对应：size_id)
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 档期、专场的id(对应：brand_id)
		///</summary>
		
		private long? salesNo_;
		
		///<summary>
		/// 可换货数量
		///</summary>
		
		private int? num_;
		
		///<summary>
		/// PDC商品库规格（对应旧系统的size_name字段）
		///</summary>
		
		private string sizeName_;
		
		///<summary>
		/// PDC商品库SKU ID（对应旧系统的v_sku_id字段）
		///</summary>
		
		private long? vendorSkuId_;
		
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public long? GetSalesNo(){
			return this.salesNo_;
		}
		
		public void SetSalesNo(long? value){
			this.salesNo_ = value;
		}
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		public string GetSizeName(){
			return this.sizeName_;
		}
		
		public void SetSizeName(string value){
			this.sizeName_ = value;
		}
		public long? GetVendorSkuId(){
			return this.vendorSkuId_;
		}
		
		public void SetVendorSkuId(long? value){
			this.vendorSkuId_ = value;
		}
		
	}
	
}