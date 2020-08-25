using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class ReturnOrderStatus {
		
		///<summary>
		/// 传输ID
		///</summary>
		
		private string id_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 出库单号
		///</summary>
		
		private string shipment_no_;
		
		///<summary>
		/// erp单号
		///</summary>
		
		private string erp_order_no_;
		
		///<summary>
		/// 关联单号
		///</summary>
		
		private string reference_no_;
		
		///<summary>
		/// 出库单类型
		///</summary>
		
		private string order_type_;
		
		///<summary>
		/// 状态码
		///</summary>
		
		private string status_code_;
		
		///<summary>
		/// 业务时间,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string action_time_;
		
		///<summary>
		/// 退供类型
		///</summary>
		
		private string return_type_;
		
		///<summary>
		/// 退供子单号
		///</summary>
		
		private string sub_return_sn_;
		
		///<summary>
		/// 退供子单标识
		///</summary>
		
		private string sub_return_flag_;
		
		///<summary>
		/// 备注信息
		///</summary>
		
		private string memo_;
		
		///<summary>
		/// 操作人
		///</summary>
		
		private string user_;
		
		///<summary>
		/// 创建时间,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string create_time_;
		
		public string GetId(){
			return this.id_;
		}
		
		public void SetId(string value){
			this.id_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetShipment_no(){
			return this.shipment_no_;
		}
		
		public void SetShipment_no(string value){
			this.shipment_no_ = value;
		}
		public string GetErp_order_no(){
			return this.erp_order_no_;
		}
		
		public void SetErp_order_no(string value){
			this.erp_order_no_ = value;
		}
		public string GetReference_no(){
			return this.reference_no_;
		}
		
		public void SetReference_no(string value){
			this.reference_no_ = value;
		}
		public string GetOrder_type(){
			return this.order_type_;
		}
		
		public void SetOrder_type(string value){
			this.order_type_ = value;
		}
		public string GetStatus_code(){
			return this.status_code_;
		}
		
		public void SetStatus_code(string value){
			this.status_code_ = value;
		}
		public string GetAction_time(){
			return this.action_time_;
		}
		
		public void SetAction_time(string value){
			this.action_time_ = value;
		}
		public string GetReturn_type(){
			return this.return_type_;
		}
		
		public void SetReturn_type(string value){
			this.return_type_ = value;
		}
		public string GetSub_return_sn(){
			return this.sub_return_sn_;
		}
		
		public void SetSub_return_sn(string value){
			this.sub_return_sn_ = value;
		}
		public string GetSub_return_flag(){
			return this.sub_return_flag_;
		}
		
		public void SetSub_return_flag(string value){
			this.sub_return_flag_ = value;
		}
		public string GetMemo(){
			return this.memo_;
		}
		
		public void SetMemo(string value){
			this.memo_ = value;
		}
		public string GetUser(){
			return this.user_;
		}
		
		public void SetUser(string value){
			this.user_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		
	}
	
}