using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.vreceipt{
	
	
	
	
	
	public class RevinfoDetail {
		
		///<summary>
		/// 入库详情唯一标识
		///</summary>
		
		private string transaction_detail_id_;
		
		///<summary>
		/// 仓库标识
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string sku_;
		
		///<summary>
		/// 采购单号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 供应商箱号
		///</summary>
		
		private string purchase_case_no_;
		
		///<summary>
		/// VIS送货单号
		///</summary>
		
		private string vis_receipt_no_;
		
		///<summary>
		/// PO数量
		///</summary>
		
		private double? po_qty_;
		
		///<summary>
		/// 供应商的发货数量
		///</summary>
		
		private double? shipping_qty_;
		
		///<summary>
		/// 实际入库数量
		///</summary>
		
		private double? stock_qty_;
		
		public string GetTransaction_detail_id(){
			return this.transaction_detail_id_;
		}
		
		public void SetTransaction_detail_id(string value){
			this.transaction_detail_id_ = value;
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
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetPurchase_case_no(){
			return this.purchase_case_no_;
		}
		
		public void SetPurchase_case_no(string value){
			this.purchase_case_no_ = value;
		}
		public string GetVis_receipt_no(){
			return this.vis_receipt_no_;
		}
		
		public void SetVis_receipt_no(string value){
			this.vis_receipt_no_ = value;
		}
		public double? GetPo_qty(){
			return this.po_qty_;
		}
		
		public void SetPo_qty(double? value){
			this.po_qty_ = value;
		}
		public double? GetShipping_qty(){
			return this.shipping_qty_;
		}
		
		public void SetShipping_qty(double? value){
			this.shipping_qty_ = value;
		}
		public double? GetStock_qty(){
			return this.stock_qty_;
		}
		
		public void SetStock_qty(double? value){
			this.stock_qty_ = value;
		}
		
	}
	
}