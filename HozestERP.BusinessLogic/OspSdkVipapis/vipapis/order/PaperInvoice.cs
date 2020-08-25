using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class PaperInvoice {
		
		///<summary>
		/// 发票寄送方式(1-随货寄送,2-委托唯品会集中寄送)当此字段为2时，以下字段必填
		///</summary>
		
		private byte? invoice_delivery_type_;
		
		///<summary>
		/// 发票预约发货时间，精确到秒
		///</summary>
		
		private long? estimate_delivery_time_;
		
		///<summary>
		/// 发票寄送包裹号,应与接口getOrderInvoice出参package_no值保持一致，即使用唯品会下发的包裹号回传;此包裹号不能和订单号重复，需要品牌商将包裹号打印条形码并与对应的发票订到一起，待快递员上门揽收时识别
		///</summary>
		
		private string package_no_;
		
		///<summary>
		/// (纸质发票)寄出省份
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 寄出城市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 寄出区/县
		///</summary>
		
		private string region_;
		
		///<summary>
		/// 寄出乡/镇/街道办事处
		///</summary>
		
		private string town_;
		
		///<summary>
		/// 寄出详细地址
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 寄出联系人
		///</summary>
		
		private string contacts_;
		
		///<summary>
		/// 寄出手机号码;此字段和tel字段，二选一即可
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 寄出联系电话
		///</summary>
		
		private string tel_;
		
		public byte? GetInvoice_delivery_type(){
			return this.invoice_delivery_type_;
		}
		
		public void SetInvoice_delivery_type(byte? value){
			this.invoice_delivery_type_ = value;
		}
		public long? GetEstimate_delivery_time(){
			return this.estimate_delivery_time_;
		}
		
		public void SetEstimate_delivery_time(long? value){
			this.estimate_delivery_time_ = value;
		}
		public string GetPackage_no(){
			return this.package_no_;
		}
		
		public void SetPackage_no(string value){
			this.package_no_ = value;
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
		public string GetContacts(){
			return this.contacts_;
		}
		
		public void SetContacts(string value){
			this.contacts_ = value;
		}
		public string GetMobile(){
			return this.mobile_;
		}
		
		public void SetMobile(string value){
			this.mobile_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		
	}
	
}