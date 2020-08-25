using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class OccupiedOrder {
		
		///<summary>
		/// 库存占用订单号
		///</summary>
		
		private string occupied_order_sn_;
		
		///<summary>
		/// 订单状态：0、占用，1、 取消
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 商品列表
		///</summary>
		
		private List<vipapis.normal.OccupiedOrderDetail> barcodes_;
		
		public string GetOccupied_order_sn(){
			return this.occupied_order_sn_;
		}
		
		public void SetOccupied_order_sn(string value){
			this.occupied_order_sn_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public List<vipapis.normal.OccupiedOrderDetail> GetBarcodes(){
			return this.barcodes_;
		}
		
		public void SetBarcodes(List<vipapis.normal.OccupiedOrderDetail> value){
			this.barcodes_ = value;
		}
		
	}
	
}