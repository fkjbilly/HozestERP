using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.price{
	
	
	
	
	
	public class UpdatePriceApplicationDetail {
		
		///<summary>
		/// 条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 款号
		///</summary>
		
		private string osn_;
		
		///<summary>
		/// PO号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 销售价
		///</summary>
		
		private double? sale_price_;
		
		///<summary>
		/// 市场价
		///</summary>
		
		private double? market_price_;
		
		///<summary>
		/// 结算价
		///</summary>
		
		private double? bill_tax_price_;
		
		///<summary>
		/// 是否不上线标记，1：是，0或空：否
		///</summary>
		
		private string withdraw_;
		
		///<summary>
		/// 是否参加惊喜官特批价，1：是，0或空：否
		///</summary>
		
		private string extra_discount_type_;
		
		///<summary>
		/// 异常备注
		///</summary>
		
		private string exception_remark_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetOsn(){
			return this.osn_;
		}
		
		public void SetOsn(string value){
			this.osn_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
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
		public double? GetBill_tax_price(){
			return this.bill_tax_price_;
		}
		
		public void SetBill_tax_price(double? value){
			this.bill_tax_price_ = value;
		}
		public string GetWithdraw(){
			return this.withdraw_;
		}
		
		public void SetWithdraw(string value){
			this.withdraw_ = value;
		}
		public string GetExtra_discount_type(){
			return this.extra_discount_type_;
		}
		
		public void SetExtra_discount_type(string value){
			this.extra_discount_type_ = value;
		}
		public string GetException_remark(){
			return this.exception_remark_;
		}
		
		public void SetException_remark(string value){
			this.exception_remark_ = value;
		}
		
	}
	
}