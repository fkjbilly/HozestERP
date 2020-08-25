using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.inventory{
	
	
	
	
	
	public class DeductOrder {
		
		///<summary>
		/// 库存占用订单号
		///</summary>
		
		private string occupied_order_sn_;
		
		///<summary>
		/// 订单列表
		///</summary>
		
		private List<vipapis.inventory.DeductOrderDetail> barcodes_;
		
		public string GetOccupied_order_sn(){
			return this.occupied_order_sn_;
		}
		
		public void SetOccupied_order_sn(string value){
			this.occupied_order_sn_ = value;
		}
		public List<vipapis.inventory.DeductOrderDetail> GetBarcodes(){
			return this.barcodes_;
		}
		
		public void SetBarcodes(List<vipapis.inventory.DeductOrderDetail> value){
			this.barcodes_ = value;
		}
		
	}
	
}