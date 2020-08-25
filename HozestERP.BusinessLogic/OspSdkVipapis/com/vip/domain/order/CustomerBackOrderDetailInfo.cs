using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class CustomerBackOrderDetailInfo {
		
		///<summary>
		/// ERP客退单号
		///</summary>
		
		private string erp_back_sn_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 运费
		///</summary>
		
		private double? carriage_;
		
		///<summary>
		/// 收货状态
		///</summary>
		
		private string order_status_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string memo_;
		
		///<summary>
		/// 收货仓
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 状态发生时间(例:2014-07-14 17:18:37)
		///</summary>
		
		private string action_time_;
		
		///<summary>
		/// 明细(商品信息)
		///</summary>
		
		private List<com.vip.domain.order.CustomerBackOrderDetailItemInfo> itemList_;
		
		public string GetErp_back_sn(){
			return this.erp_back_sn_;
		}
		
		public void SetErp_back_sn(string value){
			this.erp_back_sn_ = value;
		}
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		public double? GetCarriage(){
			return this.carriage_;
		}
		
		public void SetCarriage(double? value){
			this.carriage_ = value;
		}
		public string GetOrder_status(){
			return this.order_status_;
		}
		
		public void SetOrder_status(string value){
			this.order_status_ = value;
		}
		public string GetMemo(){
			return this.memo_;
		}
		
		public void SetMemo(string value){
			this.memo_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetAction_time(){
			return this.action_time_;
		}
		
		public void SetAction_time(string value){
			this.action_time_ = value;
		}
		public List<com.vip.domain.order.CustomerBackOrderDetailItemInfo> GetItemList(){
			return this.itemList_;
		}
		
		public void SetItemList(List<com.vip.domain.order.CustomerBackOrderDetailItemInfo> value){
			this.itemList_ = value;
		}
		
	}
	
}