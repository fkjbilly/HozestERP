using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.price{
	
	
	
	
	
	public class PriceApplicationDetail {
		
		///<summary>
		/// 价格申请单号
		///</summary>
		
		private string application_id_;
		
		///<summary>
		/// 条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// VIP售价
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
		/// 含税结算价
		///</summary>
		
		private double? bill_tax_price_;
		
		///<summary>
		/// 结算价-币种
		///</summary>
		
		private string bill_currency_;
		
		///<summary>
		/// 是否参加惊喜官特批价
		///</summary>
		
		private string extra_discount_type_;
		
		///<summary>
		/// 原唯品价
		///</summary>
		
		private double? original_sale_price_;
		
		///<summary>
		/// 款号
		///</summary>
		
		private string osn_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 是否不上线
		///</summary>
		
		private string withdraw_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 是否一键同步加入条码
		///</summary>
		
		private string is_manual_;
		
		///<summary>
		/// 异常状态
		///</summary>
		
		private string exception_status_;
		
		///<summary>
		/// 异常描述
		///</summary>
		
		private string exception_description_;
		
		///<summary>
		/// 比价结果信息
		///</summary>
		
		private List<vipapis.price.CompareResult> compareResultList_;
		
		public string GetApplication_id(){
			return this.application_id_;
		}
		
		public void SetApplication_id(string value){
			this.application_id_ = value;
		}
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
		public string GetExtra_discount_type(){
			return this.extra_discount_type_;
		}
		
		public void SetExtra_discount_type(string value){
			this.extra_discount_type_ = value;
		}
		public double? GetOriginal_sale_price(){
			return this.original_sale_price_;
		}
		
		public void SetOriginal_sale_price(double? value){
			this.original_sale_price_ = value;
		}
		public string GetOsn(){
			return this.osn_;
		}
		
		public void SetOsn(string value){
			this.osn_ = value;
		}
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
		}
		public string GetWithdraw(){
			return this.withdraw_;
		}
		
		public void SetWithdraw(string value){
			this.withdraw_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public string GetIs_manual(){
			return this.is_manual_;
		}
		
		public void SetIs_manual(string value){
			this.is_manual_ = value;
		}
		public string GetException_status(){
			return this.exception_status_;
		}
		
		public void SetException_status(string value){
			this.exception_status_ = value;
		}
		public string GetException_description(){
			return this.exception_description_;
		}
		
		public void SetException_description(string value){
			this.exception_description_ = value;
		}
		public List<vipapis.price.CompareResult> GetCompareResultList(){
			return this.compareResultList_;
		}
		
		public void SetCompareResultList(List<vipapis.price.CompareResult> value){
			this.compareResultList_ = value;
		}
		
	}
	
}