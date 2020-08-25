using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.inventory{
	
	
	
	
	
	public class GetSkuInventoryResult {
		
		///<summary>
		/// 常态合作编号
		///</summary>
		
		private int? cooperation_no_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 剩余库存
		///</summary>
		
		private int? leaving_stock_;
		
		///<summary>
		/// 库存占用，目前为购物车+未支付订单占用的库存值
		///</summary>
		
		private int? current_hold_;
		
		///<summary>
		/// 熔断值
		///</summary>
		
		private int? circuit_break_value_;
		
		///<summary>
		/// 分区仓库代码
		///</summary>
		
		private string area_warehouse_id_;
		
		public int? GetCooperation_no(){
			return this.cooperation_no_;
		}
		
		public void SetCooperation_no(int? value){
			this.cooperation_no_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetLeaving_stock(){
			return this.leaving_stock_;
		}
		
		public void SetLeaving_stock(int? value){
			this.leaving_stock_ = value;
		}
		public int? GetCurrent_hold(){
			return this.current_hold_;
		}
		
		public void SetCurrent_hold(int? value){
			this.current_hold_ = value;
		}
		public int? GetCircuit_break_value(){
			return this.circuit_break_value_;
		}
		
		public void SetCircuit_break_value(int? value){
			this.circuit_break_value_ = value;
		}
		public string GetArea_warehouse_id(){
			return this.area_warehouse_id_;
		}
		
		public void SetArea_warehouse_id(string value){
			this.area_warehouse_id_ = value;
		}
		
	}
	
}