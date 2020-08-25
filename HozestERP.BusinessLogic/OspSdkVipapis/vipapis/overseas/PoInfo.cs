using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class PoInfo {
		
		///<summary>
		/// 唯一标识
		///</summary>
		
		private string po_id_;
		
		///<summary>
		/// po单号
		/// @sampleValue po_no 48+8位数字组合,如:4800000001
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// po类型
		/// @sampleValue po_type 3PL_HT
		///</summary>
		
		private string po_type_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// 供应商名称
		///</summary>
		
		private string vendor_name_;
		
		///<summary>
		/// 数据状态
		///</summary>
		
		private string data_status_;
		
		///<summary>
		/// 采购人员姓名
		///</summary>
		
		private string buyer_;
		
		///<summary>
		/// 销售区域
		///</summary>
		
		private string sale_area_;
		
		///<summary>
		/// 邮政编码
		///</summary>
		
		private string post_code_;
		
		///<summary>
		/// 收货人
		///</summary>
		
		private string consignee_;
		
		///<summary>
		/// 收货人电话
		///</summary>
		
		private string phone_;
		
		///<summary>
		/// 收货国家
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 收货省
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 收货市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 收货区（县）
		///</summary>
		
		private string district_;
		
		///<summary>
		/// 收货详细地址
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 传送时间
		/// @sampleValue transfer_date yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string transfer_date_;
		
		///<summary>
		/// PO明细列表
		///</summary>
		
		private List<vipapis.overseas.PoDetail> po_detail_list_;
		
		///<summary>
		/// 返回明细数
		///</summary>
		
		private int? total_;
		
		public string GetPo_id(){
			return this.po_id_;
		}
		
		public void SetPo_id(string value){
			this.po_id_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
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
		public string GetVendor_name(){
			return this.vendor_name_;
		}
		
		public void SetVendor_name(string value){
			this.vendor_name_ = value;
		}
		public string GetData_status(){
			return this.data_status_;
		}
		
		public void SetData_status(string value){
			this.data_status_ = value;
		}
		public string GetBuyer(){
			return this.buyer_;
		}
		
		public void SetBuyer(string value){
			this.buyer_ = value;
		}
		public string GetSale_area(){
			return this.sale_area_;
		}
		
		public void SetSale_area(string value){
			this.sale_area_ = value;
		}
		public string GetPost_code(){
			return this.post_code_;
		}
		
		public void SetPost_code(string value){
			this.post_code_ = value;
		}
		public string GetConsignee(){
			return this.consignee_;
		}
		
		public void SetConsignee(string value){
			this.consignee_ = value;
		}
		public string GetPhone(){
			return this.phone_;
		}
		
		public void SetPhone(string value){
			this.phone_ = value;
		}
		public string GetCountry(){
			return this.country_;
		}
		
		public void SetCountry(string value){
			this.country_ = value;
		}
		public string GetProvince(){
			return this.province_;
		}
		
		public void SetProvince(string value){
			this.province_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public string GetDistrict(){
			return this.district_;
		}
		
		public void SetDistrict(string value){
			this.district_ = value;
		}
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public string GetTransfer_date(){
			return this.transfer_date_;
		}
		
		public void SetTransfer_date(string value){
			this.transfer_date_ = value;
		}
		public List<vipapis.overseas.PoDetail> GetPo_detail_list(){
			return this.po_detail_list_;
		}
		
		public void SetPo_detail_list(List<vipapis.overseas.PoDetail> value){
			this.po_detail_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}