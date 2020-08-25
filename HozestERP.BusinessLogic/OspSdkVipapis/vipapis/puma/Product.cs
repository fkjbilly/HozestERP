using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class Product {
		
		///<summary>
		/// 商品库存信息
		///</summary>
		
		private vipapis.puma.Stock stock_;
		
		///<summary>
		/// CPS信息
		///</summary>
		
		private vipapis.puma.Cps cps_;
		
		///<summary>
		/// 价格信息
		///</summary>
		
		private vipapis.puma.Price price_;
		
		///<summary>
		/// 商品运营信息
		///</summary>
		
		private vipapis.puma.Merchandise merchandise_;
		
		///<summary>
		/// 商品 SPU信息
		///</summary>
		
		private vipapis.puma.VendorProduct vendor_product_;
		
		public vipapis.puma.Stock GetStock(){
			return this.stock_;
		}
		
		public void SetStock(vipapis.puma.Stock value){
			this.stock_ = value;
		}
		public vipapis.puma.Cps GetCps(){
			return this.cps_;
		}
		
		public void SetCps(vipapis.puma.Cps value){
			this.cps_ = value;
		}
		public vipapis.puma.Price GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(vipapis.puma.Price value){
			this.price_ = value;
		}
		public vipapis.puma.Merchandise GetMerchandise(){
			return this.merchandise_;
		}
		
		public void SetMerchandise(vipapis.puma.Merchandise value){
			this.merchandise_ = value;
		}
		public vipapis.puma.VendorProduct GetVendor_product(){
			return this.vendor_product_;
		}
		
		public void SetVendor_product(vipapis.puma.VendorProduct value){
			this.vendor_product_ = value;
		}
		
	}
	
}