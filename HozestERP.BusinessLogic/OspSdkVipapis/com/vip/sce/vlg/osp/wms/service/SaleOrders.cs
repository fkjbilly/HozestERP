using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class SaleOrders {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 订单出库时间(yyyy-MM-dd HH:mm:ss)
		///</summary>
		
		private string out_time_;
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.SaleOrderInfo> order_list_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetOut_time(){
			return this.out_time_;
		}
		
		public void SetOut_time(string value){
			this.out_time_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.SaleOrderInfo> GetOrder_list(){
			return this.order_list_;
		}
		
		public void SetOrder_list(List<com.vip.sce.vlg.osp.wms.service.SaleOrderInfo> value){
			this.order_list_ = value;
		}
		
	}
	
}