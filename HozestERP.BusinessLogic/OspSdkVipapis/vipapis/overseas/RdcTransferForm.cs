using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class RdcTransferForm {
		
		///<summary>
		/// 流水号（VIP生成的ID，用于保证数据唯一性）
		/// @sampleValue rdc_id 8777285
		///</summary>
		
		private long? rdc_id_;
		
		///<summary>
		/// 商品条形码
		/// @sampleValue barcode ORZ107920
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		/// @sampleValue product_name 春秋季新款粉色外套
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 档期号
		/// @sampleValue schedule_id 243767
		///</summary>
		
		private string schedule_id_;
		
		///<summary>
		/// 商品数量
		/// @sampleValue num 1
		///</summary>
		
		private int? num_;
		
		///<summary>
		/// 调拨收货仓
		/// @sampleValue to_warehouse VIP_CD
		///</summary>
		
		private string to_warehouse_;
		
		///<summary>
		/// 调拨发货仓
		/// @sampleValue from_warehouse HT_JPRT
		///</summary>
		
		private string from_warehouse_;
		
		///<summary>
		/// 订单ID
		/// @sampleValue order_id 14090570262937
		///</summary>
		
		private long? order_id_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_sn_;
		
		///<summary>
		/// 调拨状态(ADD:新增，CANCEL:取消)
		/// @sampleValue status ADD
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 优先级（默认10）
		/// @sampleValue priority 10
		///</summary>
		
		private string priority_;
		
		///<summary>
		/// 调拨来源
		///</summary>
		
		private string data_source_;
		
		///<summary>
		/// 调拨类型(S,single单品；M，multiple多品)
		/// @sampleValue order_type S
		///</summary>
		
		private string order_type_;
		
		///<summary>
		/// P0号
		/// @sampleValue po_no 5000092455
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 明细行ID
		///</summary>
		
		private int? detail_id_;
		
		///<summary>
		/// 销售模式
		///</summary>
		
		private string sale_type_;
		
		///<summary>
		/// 是否绑定PO（0 需要绑定PO；1 不需要绑定PO）
		/// @sampleValue no_po 0
		///</summary>
		
		private string no_po_;
		
		///<summary>
		/// 订单类型
		/// @sampleValue po_type JIT_RDC_HT
		///</summary>
		
		private string po_type_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// 订单创建时间
		/// @sampleValue create_time 2015-10-08 10:00:30
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// 分配数量（JIT预调拨模式特有）
		///</summary>
		
		private int? allocated_num_;
		
		public long? GetRdc_id(){
			return this.rdc_id_;
		}
		
		public void SetRdc_id(long? value){
			this.rdc_id_ = value;
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
		public string GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(string value){
			this.schedule_id_ = value;
		}
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		public string GetTo_warehouse(){
			return this.to_warehouse_;
		}
		
		public void SetTo_warehouse(string value){
			this.to_warehouse_ = value;
		}
		public string GetFrom_warehouse(){
			return this.from_warehouse_;
		}
		
		public void SetFrom_warehouse(string value){
			this.from_warehouse_ = value;
		}
		public long? GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(long? value){
			this.order_id_ = value;
		}
		public string GetOrder_sn(){
			return this.order_sn_;
		}
		
		public void SetOrder_sn(string value){
			this.order_sn_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetPriority(){
			return this.priority_;
		}
		
		public void SetPriority(string value){
			this.priority_ = value;
		}
		public string GetData_source(){
			return this.data_source_;
		}
		
		public void SetData_source(string value){
			this.data_source_ = value;
		}
		public string GetOrder_type(){
			return this.order_type_;
		}
		
		public void SetOrder_type(string value){
			this.order_type_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public int? GetDetail_id(){
			return this.detail_id_;
		}
		
		public void SetDetail_id(int? value){
			this.detail_id_ = value;
		}
		public string GetSale_type(){
			return this.sale_type_;
		}
		
		public void SetSale_type(string value){
			this.sale_type_ = value;
		}
		public string GetNo_po(){
			return this.no_po_;
		}
		
		public void SetNo_po(string value){
			this.no_po_ = value;
		}
		public string GetPo_type(){
			return this.po_type_;
		}
		
		public void SetPo_type(string value){
			this.po_type_ = value;
		}
		public string GetVendor_code(){
			return this.vendor_code_;
		}
		
		public void SetVendor_code(string value){
			this.vendor_code_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		public int? GetAllocated_num(){
			return this.allocated_num_;
		}
		
		public void SetAllocated_num(int? value){
			this.allocated_num_ = value;
		}
		
	}
	
}