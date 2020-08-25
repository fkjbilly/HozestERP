using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class SkuSaleCountInfoDo {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 供应商名称
		///</summary>
		
		private string vendorName_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperationNo_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 销售数量
		///</summary>
		
		private int? saleAmount_;
		
		///<summary>
		/// 取消数量
		///</summary>
		
		private int? cancelAmount_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetVendorName(){
			return this.vendorName_;
		}
		
		public void SetVendorName(string value){
			this.vendorName_ = value;
		}
		public int? GetCooperationNo(){
			return this.cooperationNo_;
		}
		
		public void SetCooperationNo(int? value){
			this.cooperationNo_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetSaleAmount(){
			return this.saleAmount_;
		}
		
		public void SetSaleAmount(int? value){
			this.saleAmount_ = value;
		}
		public int? GetCancelAmount(){
			return this.cancelAmount_;
		}
		
		public void SetCancelAmount(int? value){
			this.cancelAmount_ = value;
		}
		
	}
	
}