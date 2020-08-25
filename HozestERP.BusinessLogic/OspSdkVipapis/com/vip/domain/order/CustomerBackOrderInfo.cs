using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class CustomerBackOrderInfo {
		
		///<summary>
		/// 唯一标识
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// ERP订单号
		///</summary>
		
		private string erp_order_sn_;
		
		///<summary>
		/// 创建人
		///</summary>
		
		private string create_user_;
		
		///<summary>
		/// 拒收审核时间/退货单创建时间(例：2014-07-01 10:44:32)
		///</summary>
		
		private string update_date_;
		
		///<summary>
		/// 订单商品明细信息
		///</summary>
		
		private List<com.vip.domain.order.CustomerBackOrderItemInfo> itemList_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetErp_order_sn(){
			return this.erp_order_sn_;
		}
		
		public void SetErp_order_sn(string value){
			this.erp_order_sn_ = value;
		}
		public string GetCreate_user(){
			return this.create_user_;
		}
		
		public void SetCreate_user(string value){
			this.create_user_ = value;
		}
		public string GetUpdate_date(){
			return this.update_date_;
		}
		
		public void SetUpdate_date(string value){
			this.update_date_ = value;
		}
		public List<com.vip.domain.order.CustomerBackOrderItemInfo> GetItemList(){
			return this.itemList_;
		}
		
		public void SetItemList(List<com.vip.domain.order.CustomerBackOrderItemInfo> value){
			this.itemList_ = value;
		}
		
	}
	
}