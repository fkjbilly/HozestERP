using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class CustomerBackOrderStatusInfo {
		
		///<summary>
		/// 当前记录的序号
		///</summary>
		
		private long? max_id_;
		
		///<summary>
		/// ERP客退单号
		///</summary>
		
		private string erp_back_sn_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 物流状态编码号
		///</summary>
		
		private string transport_code_;
		
		///<summary>
		/// 物流状态信息
		///</summary>
		
		private string transport_detail_;
		
		///<summary>
		/// 异常类型
		///</summary>
		
		private string ab_reason_;
		
		///<summary>
		/// 异常备注
		///</summary>
		
		private string ab_remark_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carriers_code_;
		
		///<summary>
		/// 承运商简称
		///</summary>
		
		private string carriers_shortname_;
		
		///<summary>
		/// 承运商类型
		///</summary>
		
		private string carriers_type_;
		
		///<summary>
		/// 付费方式
		///</summary>
		
		private string play_type_;
		
		///<summary>
		/// 付费金额
		///</summary>
		
		private double? play_money_;
		
		///<summary>
		/// 收货仓
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 状态发生时间(例:2014-07-14 17:18:37)
		///</summary>
		
		private string action_time_;
		
		public long? GetMax_id(){
			return this.max_id_;
		}
		
		public void SetMax_id(long? value){
			this.max_id_ = value;
		}
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
		public string GetTransport_code(){
			return this.transport_code_;
		}
		
		public void SetTransport_code(string value){
			this.transport_code_ = value;
		}
		public string GetTransport_detail(){
			return this.transport_detail_;
		}
		
		public void SetTransport_detail(string value){
			this.transport_detail_ = value;
		}
		public string GetAb_reason(){
			return this.ab_reason_;
		}
		
		public void SetAb_reason(string value){
			this.ab_reason_ = value;
		}
		public string GetAb_remark(){
			return this.ab_remark_;
		}
		
		public void SetAb_remark(string value){
			this.ab_remark_ = value;
		}
		public string GetCarriers_code(){
			return this.carriers_code_;
		}
		
		public void SetCarriers_code(string value){
			this.carriers_code_ = value;
		}
		public string GetCarriers_shortname(){
			return this.carriers_shortname_;
		}
		
		public void SetCarriers_shortname(string value){
			this.carriers_shortname_ = value;
		}
		public string GetCarriers_type(){
			return this.carriers_type_;
		}
		
		public void SetCarriers_type(string value){
			this.carriers_type_ = value;
		}
		public string GetPlay_type(){
			return this.play_type_;
		}
		
		public void SetPlay_type(string value){
			this.play_type_ = value;
		}
		public double? GetPlay_money(){
			return this.play_money_;
		}
		
		public void SetPlay_money(double? value){
			this.play_money_ = value;
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
		
	}
	
}