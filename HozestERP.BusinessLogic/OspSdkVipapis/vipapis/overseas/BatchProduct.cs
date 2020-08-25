using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class BatchProduct {
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 尺码
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string num_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public string GetSize(){
			return this.size_;
		}
		
		public void SetSize(string value){
			this.size_ = value;
		}
		public string GetNum(){
			return this.num_;
		}
		
		public void SetNum(string value){
			this.num_ = value;
		}
		
	}
	
}