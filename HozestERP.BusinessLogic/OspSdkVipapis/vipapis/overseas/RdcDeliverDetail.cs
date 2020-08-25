using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class RdcDeliverDetail {
		
		///<summary>
		/// 订单的唯一标识（WMS自定义）
		/// @sampleValue id 37064633
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 流水号（仓库编码+id）
		/// @sampleValue source_id HT_JPRT_37064633
		///</summary>
		
		private string source_id_;
		
		///<summary>
		/// 品牌编码
		/// @sampleValue brand_id 10004674
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 订单号
		/// @sampleValue order_sn 15091548419756
		///</summary>
		
		private string order_sn_;
		
		///<summary>
		/// 商品编码
		/// @sampleValue barcode 是不是就是条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		/// @sampleValue product_name 春季新款粉色大衣
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// PO号
		/// @sampleValue po_no 2000410397
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 库存类型
		///</summary>
		
		private string warehouse_type_;
		
		///<summary>
		/// 库存等级
		/// @sampleValue grade 100
		///</summary>
		
		private string grade_;
		
		///<summary>
		/// 库存状态
		/// @sampleValue status 0
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 出仓时间
		/// @sampleValue out_time 2015-09-27 08:41:23
		///</summary>
		
		private string out_time_;
		
		///<summary>
		/// 出仓数量
		/// @sampleValue num 1
		///</summary>
		
		private int? num_;
		
		///<summary>
		/// 档期号
		/// @sampleValue schedule_id 522146
		///</summary>
		
		private string schedule_id_;
		
		///<summary>
		/// 供应商编码
		/// @sampleValue vendor_code 103676
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// RDC调出仓
		/// @sampleValue from_warehouse VIP_JPRT
		///</summary>
		
		private string from_warehouse_;
		
		///<summary>
		/// RDC调入仓
		/// @sampleValue to_warehouse VIP_HZ
		///</summary>
		
		private string to_warehouse_;
		
		///<summary>
		/// 出库单号
		/// @sampleValue shipment_no JITHZTP00031377
		///</summary>
		
		private string shipment_no_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public string GetSource_id(){
			return this.source_id_;
		}
		
		public void SetSource_id(string value){
			this.source_id_ = value;
		}
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetOrder_sn(){
			return this.order_sn_;
		}
		
		public void SetOrder_sn(string value){
			this.order_sn_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetWarehouse_type(){
			return this.warehouse_type_;
		}
		
		public void SetWarehouse_type(string value){
			this.warehouse_type_ = value;
		}
		public string GetGrade(){
			return this.grade_;
		}
		
		public void SetGrade(string value){
			this.grade_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetOut_time(){
			return this.out_time_;
		}
		
		public void SetOut_time(string value){
			this.out_time_ = value;
		}
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		public string GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(string value){
			this.schedule_id_ = value;
		}
		public string GetVendor_code(){
			return this.vendor_code_;
		}
		
		public void SetVendor_code(string value){
			this.vendor_code_ = value;
		}
		public string GetFrom_warehouse(){
			return this.from_warehouse_;
		}
		
		public void SetFrom_warehouse(string value){
			this.from_warehouse_ = value;
		}
		public string GetTo_warehouse(){
			return this.to_warehouse_;
		}
		
		public void SetTo_warehouse(string value){
			this.to_warehouse_ = value;
		}
		public string GetShipment_no(){
			return this.shipment_no_;
		}
		
		public void SetShipment_no(string value){
			this.shipment_no_ = value;
		}
		
	}
	
}