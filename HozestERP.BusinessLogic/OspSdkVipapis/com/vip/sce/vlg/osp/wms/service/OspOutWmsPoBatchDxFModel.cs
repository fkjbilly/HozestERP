using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OspOutWmsPoBatchDxFModel {
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string productName_;
		
		///<summary>
		/// 尺码
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? num_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetProductName(){
			return this.productName_;
		}
		
		public void SetProductName(string value){
			this.productName_ = value;
		}
		public string GetSize(){
			return this.size_;
		}
		
		public void SetSize(string value){
			this.size_ = value;
		}
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		
	}
	
}