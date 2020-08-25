using System;
using System.Collections.Generic;
using System.Text;

namespace com.vipshop.cis.sdk.api.datain.si.request{
	
	
	
	
	
	public class SyncVrwIncrInvRequestPayloadItem {
		
		///<summary>
		/// 流水ID,全局唯一
		/// @sampleValue transaction_id VOP_ZY_001_8777285
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 仓库编码,由CIS创建. 不区分大小写
		/// @sampleValue warehouse_code HT_GZZY
		///</summary>
		
		private string warehouse_code_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// 商品SKU编码
		///</summary>
		
		private string item_code_;
		
		///<summary>
		/// 品牌编码
		///</summary>
		
		private string company_code_;
		
		///<summary>
		/// 采购订单号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 库存类型
		/// @sampleValue type SI,VI,Gift,3PL,Normal
		///</summary>
		
		private string type_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? quantity_;
		
		///<summary>
		/// 操作类型
		/// @sampleValue action_type 202_99,202_99...
		///</summary>
		
		private string action_type_;
		
		///<summary>
		/// 操作时间,精确到毫秒
		///</summary>
		
		private long? action_time_;
		
		///<summary>
		/// 数据来源
		///</summary>
		
		private string system_;
		
		///<summary>
		/// 单号,订单号,传输单号..
		///</summary>
		
		private string order_sn_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 货品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string vendor_item_;
		
		///<summary>
		/// 档期号
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 库存等级
		///</summary>
		
		private string grade_;
		
		///<summary>
		/// 库存状态
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 过期日期,精确到毫秒
		///</summary>
		
		private long? expiration_date_;
		
		///<summary>
		/// 生产日期,精确到毫秒
		///</summary>
		
		private long? manufacture_date_;
		
		///<summary>
		/// 原产国
		///</summary>
		
		private string cntry_of_orgn_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetWarehouse_code(){
			return this.warehouse_code_;
		}
		
		public void SetWarehouse_code(string value){
			this.warehouse_code_ = value;
		}
		public string GetVendor_code(){
			return this.vendor_code_;
		}
		
		public void SetVendor_code(string value){
			this.vendor_code_ = value;
		}
		public string GetItem_code(){
			return this.item_code_;
		}
		
		public void SetItem_code(string value){
			this.item_code_ = value;
		}
		public string GetCompany_code(){
			return this.company_code_;
		}
		
		public void SetCompany_code(string value){
			this.company_code_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetType(){
			return this.type_;
		}
		
		public void SetType(string value){
			this.type_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		public string GetAction_type(){
			return this.action_type_;
		}
		
		public void SetAction_type(string value){
			this.action_type_ = value;
		}
		public long? GetAction_time(){
			return this.action_time_;
		}
		
		public void SetAction_time(long? value){
			this.action_time_ = value;
		}
		public string GetSystem(){
			return this.system_;
		}
		
		public void SetSystem(string value){
			this.system_ = value;
		}
		public string GetOrder_sn(){
			return this.order_sn_;
		}
		
		public void SetOrder_sn(string value){
			this.order_sn_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public string GetVendor_item(){
			return this.vendor_item_;
		}
		
		public void SetVendor_item(string value){
			this.vendor_item_ = value;
		}
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
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
		public long? GetExpiration_date(){
			return this.expiration_date_;
		}
		
		public void SetExpiration_date(long? value){
			this.expiration_date_ = value;
		}
		public long? GetManufacture_date(){
			return this.manufacture_date_;
		}
		
		public void SetManufacture_date(long? value){
			this.manufacture_date_ = value;
		}
		public string GetCntry_of_orgn(){
			return this.cntry_of_orgn_;
		}
		
		public void SetCntry_of_orgn(string value){
			this.cntry_of_orgn_ = value;
		}
		
	}
	
}