using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class UpdateStockToWhiResponse {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 合作编码
		///</summary>
		
		private int? cooperationNo_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 库存更新值
		///</summary>
		
		private int? quantity_;
		
		///<summary>
		/// 库存更新时间
		///</summary>
		
		private string updateTime_;
		
		///<summary>
		/// 是否更新成功
		///</summary>
		
		private int? isSuccess_;
		
		///<summary>
		/// 异常消息
		///</summary>
		
		private string message_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
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
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		public string GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(string value){
			this.updateTime_ = value;
		}
		public int? GetIsSuccess(){
			return this.isSuccess_;
		}
		
		public void SetIsSuccess(int? value){
			this.isSuccess_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		
	}
	
}