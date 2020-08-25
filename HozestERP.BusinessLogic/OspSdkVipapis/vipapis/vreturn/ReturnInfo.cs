using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vreturn{
	
	
	
	
	
	public class ReturnInfo {
		
		///<summary>
		/// 退供单号
		/// @sampleValue return_sn 
		///</summary>
		
		private string return_sn_;
		
		///<summary>
		/// 退供发货仓
		/// @sampleValue warehouse 
		///</summary>
		
		private vipapis.common.Warehouse? warehouse_;
		
		///<summary>
		/// 退供类型：1，一退；2，二退；3，三退；20，VMI二退；21，部分二退；30，无PO退供；40 残次按PO退供；100，VIS二退（VIS使用）101，VIS普通退供（VIS使用）102，VIS残次退供（VIS使用）103，VIS VIP_3PL退品骏普通退供（VIS使用）104，VIS VIP_3PL退品骏残次退供（VIS使用）105，VIS VIP_3PL退供应商（VIS使用）110，门户正常退供（PSP使用）111，门户残次退供（PSP使用）112，门户过期退供（PSP使用）113，门户入库凭证退供（PSP使用）
		/// @sampleValue return_type 
		///</summary>
		
		private int? return_type_;
		
		///<summary>
		/// 支付方式：0，货到付款；1，现付月结；
		/// @sampleValue pay_type 
		///</summary>
		
		private int? pay_type_;
		
		///<summary>
		/// 退供收货人
		/// @sampleValue consignee 
		///</summary>
		
		private string consignee_;
		
		///<summary>
		/// 国家标识
		/// @sampleValue country 
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 省/州
		/// @sampleValue state 
		///</summary>
		
		private string state_;
		
		///<summary>
		/// 城市
		/// @sampleValue city 
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 区/县
		/// @sampleValue region 
		///</summary>
		
		private string region_;
		
		///<summary>
		/// 乡镇/街道
		/// @sampleValue town 
		///</summary>
		
		private string town_;
		
		///<summary>
		/// 收货地址
		/// @sampleValue address 
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 邮政编码
		/// @sampleValue postcode 
		///</summary>
		
		private int? postcode_;
		
		///<summary>
		/// 座机
		/// @sampleValue telephone 
		///</summary>
		
		private string telephone_;
		
		///<summary>
		/// 移动电话
		/// @sampleValue mobile 
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 退供通知email地址
		/// @sampleValue to_email 
		///</summary>
		
		private string to_email_;
		
		///<summary>
		/// 退供抄送email地址
		/// @sampleValue cc_email 
		///</summary>
		
		private string cc_email_;
		
		///<summary>
		/// 是否自提:0，品骏配送；1，供应商自提；
		/// @sampleValue self_reference 
		///</summary>
		
		private int? self_reference_;
		
		public string GetReturn_sn(){
			return this.return_sn_;
		}
		
		public void SetReturn_sn(string value){
			this.return_sn_ = value;
		}
		public vipapis.common.Warehouse? GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(vipapis.common.Warehouse? value){
			this.warehouse_ = value;
		}
		public int? GetReturn_type(){
			return this.return_type_;
		}
		
		public void SetReturn_type(int? value){
			this.return_type_ = value;
		}
		public int? GetPay_type(){
			return this.pay_type_;
		}
		
		public void SetPay_type(int? value){
			this.pay_type_ = value;
		}
		public string GetConsignee(){
			return this.consignee_;
		}
		
		public void SetConsignee(string value){
			this.consignee_ = value;
		}
		public string GetCountry(){
			return this.country_;
		}
		
		public void SetCountry(string value){
			this.country_ = value;
		}
		public string GetState(){
			return this.state_;
		}
		
		public void SetState(string value){
			this.state_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public string GetRegion(){
			return this.region_;
		}
		
		public void SetRegion(string value){
			this.region_ = value;
		}
		public string GetTown(){
			return this.town_;
		}
		
		public void SetTown(string value){
			this.town_ = value;
		}
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public int? GetPostcode(){
			return this.postcode_;
		}
		
		public void SetPostcode(int? value){
			this.postcode_ = value;
		}
		public string GetTelephone(){
			return this.telephone_;
		}
		
		public void SetTelephone(string value){
			this.telephone_ = value;
		}
		public string GetMobile(){
			return this.mobile_;
		}
		
		public void SetMobile(string value){
			this.mobile_ = value;
		}
		public string GetTo_email(){
			return this.to_email_;
		}
		
		public void SetTo_email(string value){
			this.to_email_ = value;
		}
		public string GetCc_email(){
			return this.cc_email_;
		}
		
		public void SetCc_email(string value){
			this.cc_email_ = value;
		}
		public int? GetSelf_reference(){
			return this.self_reference_;
		}
		
		public void SetSelf_reference(int? value){
			this.self_reference_ = value;
		}
		
	}
	
}