using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.delivery{
	
	
	
	
	
	public class DefectiveGood {
		
		///<summary>
		/// po号
		///</summary>
		
		private string poNo_;
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string receiptNo_;
		
		///<summary>
		/// 供应商箱号
		///</summary>
		
		private string purchaseCaseNo_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string itemCode_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? qty_;
		
		///<summary>
		/// 残次原因
		///</summary>
		
		private string reasonCode_;
		
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		public string GetReceiptNo(){
			return this.receiptNo_;
		}
		
		public void SetReceiptNo(string value){
			this.receiptNo_ = value;
		}
		public string GetPurchaseCaseNo(){
			return this.purchaseCaseNo_;
		}
		
		public void SetPurchaseCaseNo(string value){
			this.purchaseCaseNo_ = value;
		}
		public string GetItemCode(){
			return this.itemCode_;
		}
		
		public void SetItemCode(string value){
			this.itemCode_ = value;
		}
		public int? GetQty(){
			return this.qty_;
		}
		
		public void SetQty(int? value){
			this.qty_ = value;
		}
		public string GetReasonCode(){
			return this.reasonCode_;
		}
		
		public void SetReasonCode(string value){
			this.reasonCode_ = value;
		}
		
	}
	
}