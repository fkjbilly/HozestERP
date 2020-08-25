using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class Product {
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 供应商仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 库存审核状态<br>  0:未审核 <br>1:审核中 <br>2:审核失败<br> 3:审核通过
		/// @sampleValue status 3:审核通过
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string sn_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
		}
		
	}
	
}