using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderReceiveAddrVO {
		
		///<summary>
		/// 收货人地址
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 订单地址类型
		///</summary>
		
		private string addressType_;
		
		///<summary>
		/// 区域id
		///</summary>
		
		private string areaId_;
		
		///<summary>
		/// 区域名称
		///</summary>
		
		private string areaName_;
		
		///<summary>
		/// 收货人姓名（对应:buyer）
		///</summary>
		
		private string consignee_;
		
		///<summary>
		/// 收货人手机
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 邮政编码
		///</summary>
		
		private string postcode_;
		
		///<summary>
		/// 收货人电话
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 收货时间类型(如：2-双休日)
		///</summary>
		
		private int? transportDay_;
		
		///<summary>
		/// 配送时间(如：2-只是白天)
		///</summary>
		
		private int? transportTime_;
		
		///<summary>
		/// 国家编号
		///</summary>
		
		private int? countryId_;
		
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public string GetAddressType(){
			return this.addressType_;
		}
		
		public void SetAddressType(string value){
			this.addressType_ = value;
		}
		public string GetAreaId(){
			return this.areaId_;
		}
		
		public void SetAreaId(string value){
			this.areaId_ = value;
		}
		public string GetAreaName(){
			return this.areaName_;
		}
		
		public void SetAreaName(string value){
			this.areaName_ = value;
		}
		public string GetConsignee(){
			return this.consignee_;
		}
		
		public void SetConsignee(string value){
			this.consignee_ = value;
		}
		public string GetMobile(){
			return this.mobile_;
		}
		
		public void SetMobile(string value){
			this.mobile_ = value;
		}
		public string GetPostcode(){
			return this.postcode_;
		}
		
		public void SetPostcode(string value){
			this.postcode_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		public int? GetTransportDay(){
			return this.transportDay_;
		}
		
		public void SetTransportDay(int? value){
			this.transportDay_ = value;
		}
		public int? GetTransportTime(){
			return this.transportTime_;
		}
		
		public void SetTransportTime(int? value){
			this.transportTime_ = value;
		}
		public int? GetCountryId(){
			return this.countryId_;
		}
		
		public void SetCountryId(int? value){
			this.countryId_ = value;
		}
		
	}
	
}