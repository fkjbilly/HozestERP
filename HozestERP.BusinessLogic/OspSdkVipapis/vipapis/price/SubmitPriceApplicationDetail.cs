using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.price{
	
	
	
	
	
	public class SubmitPriceApplicationDetail {
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 售卖价格
		///</summary>
		
		private double? sale_price_;
		
		///<summary>
		/// 市场价
		///</summary>
		
		private double? market_price_;
		
		///<summary>
		/// 扣点
		///</summary>
		
		private double? gross_margin_;
		
		///<summary>
		/// 结算价
		///</summary>
		
		private double? bill_tax_price_;
		
		///<summary>
		/// 币种
		///</summary>
		
		private string bill_currency_;
		
		///<summary>
		/// 是否参加惊喜官特批价,1:代表是惊喜价，其他不是
		///</summary>
		
		private byte? extra_discount_type_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public double? GetSale_price(){
			return this.sale_price_;
		}
		
		public void SetSale_price(double? value){
			this.sale_price_ = value;
		}
		public double? GetMarket_price(){
			return this.market_price_;
		}
		
		public void SetMarket_price(double? value){
			this.market_price_ = value;
		}
		public double? GetGross_margin(){
			return this.gross_margin_;
		}
		
		public void SetGross_margin(double? value){
			this.gross_margin_ = value;
		}
		public double? GetBill_tax_price(){
			return this.bill_tax_price_;
		}
		
		public void SetBill_tax_price(double? value){
			this.bill_tax_price_ = value;
		}
		public string GetBill_currency(){
			return this.bill_currency_;
		}
		
		public void SetBill_currency(string value){
			this.bill_currency_ = value;
		}
		public byte? GetExtra_discount_type(){
			return this.extra_discount_type_;
		}
		
		public void SetExtra_discount_type(byte? value){
			this.extra_discount_type_ = value;
		}
		
	}
	
}