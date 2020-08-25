using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.inventory{
	
	
	
	
	
	public class OccupiedOrder {
		
		///<summary>
		/// 库存占用订单号
		///</summary>
		
		private string occupied_order_sn_;
		
		///<summary>
		/// 商品列表
		///</summary>
		
		private List<vipapis.inventory.OccupiedOrderDetail> barcodes_;
		
		///<summary>
		/// 销售区域
		///</summary>
		
		private string sale_warehouse_;
		
		///<summary>
		/// 订单的四级地址编码,（直发的订单可返回此字段，JIT订单不返回此字段）
		///</summary>
		
		private string address_code_;
		
		public string GetOccupied_order_sn(){
			return this.occupied_order_sn_;
		}
		
		public void SetOccupied_order_sn(string value){
			this.occupied_order_sn_ = value;
		}
		public List<vipapis.inventory.OccupiedOrderDetail> GetBarcodes(){
			return this.barcodes_;
		}
		
		public void SetBarcodes(List<vipapis.inventory.OccupiedOrderDetail> value){
			this.barcodes_ = value;
		}
		public string GetSale_warehouse(){
			return this.sale_warehouse_;
		}
		
		public void SetSale_warehouse(string value){
			this.sale_warehouse_ = value;
		}
		public string GetAddress_code(){
			return this.address_code_;
		}
		
		public void SetAddress_code(string value){
			this.address_code_ = value;
		}
		
	}
	
}