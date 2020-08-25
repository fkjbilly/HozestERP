using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.delivery{
	
	
	
	
	
	public class ReceiptDetail {
		
		///<summary>
		/// 主键id
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 采购单号
		///</summary>
		
		private string poNo_;
		
		///<summary>
		/// 仓库标识
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string sku_;
		
		///<summary>
		/// 供应商箱号
		///</summary>
		
		private string purchaseCaseNo_;
		
		///<summary>
		/// 实际入库数量
		///</summary>
		
		private double? stockQty_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetSku(){
			return this.sku_;
		}
		
		public void SetSku(string value){
			this.sku_ = value;
		}
		public string GetPurchaseCaseNo(){
			return this.purchaseCaseNo_;
		}
		
		public void SetPurchaseCaseNo(string value){
			this.purchaseCaseNo_ = value;
		}
		public double? GetStockQty(){
			return this.stockQty_;
		}
		
		public void SetStockQty(double? value){
			this.stockQty_ = value;
		}
		
	}
	
}