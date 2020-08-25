using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class PurchaseOrderBatchInfo {
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 批次id
		///</summary>
		
		private int? batch_id_;
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batch_no_;
		
		///<summary>
		/// PO编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 贸易模式
		///</summary>
		
		private string trade_model_;
		
		///<summary>
		/// 送货时间，格式Y-m-d H:i:s
		/// @sampleValue delivery_time 2015-09-17 00:00:00
		///</summary>
		
		private string delivery_time_;
		
		///<summary>
		/// 预计到货时间
		///</summary>
		
		private string estimate_arrive_time_;
		
		///<summary>
		/// 订单类型
		///</summary>
		
		private string po_type_;
		
		///<summary>
		/// 库存类型
		///</summary>
		
		private string warehouse_type_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 供应商名称
		///</summary>
		
		private string vendor_name_;
		
		///<summary>
		/// 批次商品信息
		///</summary>
		
		private List<vipapis.overseas.BatchProduct> product_List_;
		
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public int? GetBatch_id(){
			return this.batch_id_;
		}
		
		public void SetBatch_id(int? value){
			this.batch_id_ = value;
		}
		public string GetBatch_no(){
			return this.batch_no_;
		}
		
		public void SetBatch_no(string value){
			this.batch_no_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetTrade_model(){
			return this.trade_model_;
		}
		
		public void SetTrade_model(string value){
			this.trade_model_ = value;
		}
		public string GetDelivery_time(){
			return this.delivery_time_;
		}
		
		public void SetDelivery_time(string value){
			this.delivery_time_ = value;
		}
		public string GetEstimate_arrive_time(){
			return this.estimate_arrive_time_;
		}
		
		public void SetEstimate_arrive_time(string value){
			this.estimate_arrive_time_ = value;
		}
		public string GetPo_type(){
			return this.po_type_;
		}
		
		public void SetPo_type(string value){
			this.po_type_ = value;
		}
		public string GetWarehouse_type(){
			return this.warehouse_type_;
		}
		
		public void SetWarehouse_type(string value){
			this.warehouse_type_ = value;
		}
		public string GetVendor_code(){
			return this.vendor_code_;
		}
		
		public void SetVendor_code(string value){
			this.vendor_code_ = value;
		}
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetVendor_name(){
			return this.vendor_name_;
		}
		
		public void SetVendor_name(string value){
			this.vendor_name_ = value;
		}
		public List<vipapis.overseas.BatchProduct> GetProduct_List(){
			return this.product_List_;
		}
		
		public void SetProduct_List(List<vipapis.overseas.BatchProduct> value){
			this.product_List_ = value;
		}
		
	}
	
}