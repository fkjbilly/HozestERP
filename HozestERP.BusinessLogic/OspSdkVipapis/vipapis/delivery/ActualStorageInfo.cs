using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class ActualStorageInfo {
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// po号码
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 送货数
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 实际入库数
		///</summary>
		
		private int? actual_amount_;
		
		///<summary>
		/// 一退数量
		///</summary>
		
		private int? return_amount_;
		
		///<summary>
		/// 差异数量:（=送货数-入库数-退数量）
		///</summary>
		
		private int? differ_amount_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public int? GetActual_amount(){
			return this.actual_amount_;
		}
		
		public void SetActual_amount(int? value){
			this.actual_amount_ = value;
		}
		public int? GetReturn_amount(){
			return this.return_amount_;
		}
		
		public void SetReturn_amount(int? value){
			this.return_amount_ = value;
		}
		public int? GetDiffer_amount(){
			return this.differ_amount_;
		}
		
		public void SetDiffer_amount(int? value){
			this.differ_amount_ = value;
		}
		
	}
	
}