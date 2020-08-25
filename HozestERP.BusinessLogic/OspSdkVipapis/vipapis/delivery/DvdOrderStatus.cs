using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DvdOrderStatus {
		
		///<summary>
		/// 订单编码
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 旧订单编码
		///</summary>
		
		private string old_order_id_;
		
		///<summary>
		/// 订单状态编码
		///</summary>
		
		private vipapis.common.OrderStatus? order_status_;
		
		///<summary>
		/// 仓库名称
		///</summary>
		
		private string warehouse_name_;
		
		///<summary>
		/// EBS分仓代码
		///</summary>
		
		private string ebs_warehouse_code_;
		
		///<summary>
		/// B2C分仓代码
		///</summary>
		
		private string b2c_warehouse_code_;
		
		///<summary>
		/// 客户类型
		///</summary>
		
		private int? user_type_;
		
		///<summary>
		/// 客户名称
		///</summary>
		
		private string user_name_;
		
		///<summary>
		/// 是否已导出,1：已经导出；0：未导出
		///</summary>
		
		private int? is_export_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetOld_order_id(){
			return this.old_order_id_;
		}
		
		public void SetOld_order_id(string value){
			this.old_order_id_ = value;
		}
		public vipapis.common.OrderStatus? GetOrder_status(){
			return this.order_status_;
		}
		
		public void SetOrder_status(vipapis.common.OrderStatus? value){
			this.order_status_ = value;
		}
		public string GetWarehouse_name(){
			return this.warehouse_name_;
		}
		
		public void SetWarehouse_name(string value){
			this.warehouse_name_ = value;
		}
		public string GetEbs_warehouse_code(){
			return this.ebs_warehouse_code_;
		}
		
		public void SetEbs_warehouse_code(string value){
			this.ebs_warehouse_code_ = value;
		}
		public string GetB2c_warehouse_code(){
			return this.b2c_warehouse_code_;
		}
		
		public void SetB2c_warehouse_code(string value){
			this.b2c_warehouse_code_ = value;
		}
		public int? GetUser_type(){
			return this.user_type_;
		}
		
		public void SetUser_type(int? value){
			this.user_type_ = value;
		}
		public string GetUser_name(){
			return this.user_name_;
		}
		
		public void SetUser_name(string value){
			this.user_name_ = value;
		}
		public int? GetIs_export(){
			return this.is_export_;
		}
		
		public void SetIs_export(int? value){
			this.is_export_ = value;
		}
		
	}
	
}