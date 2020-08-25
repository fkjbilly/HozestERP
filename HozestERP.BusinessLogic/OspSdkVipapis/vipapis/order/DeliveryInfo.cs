using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class DeliveryInfo {
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string delivery_no_;
		
		///<summary>
		/// 箱号
		///</summary>
		
		private string container_no_;
		
		///<summary>
		/// 记录类型, new：新增，add：拆箱，delete：删箱
		///</summary>
		
		private string record_type_;
		
		public string GetDelivery_no(){
			return this.delivery_no_;
		}
		
		public void SetDelivery_no(string value){
			this.delivery_no_ = value;
		}
		public string GetContainer_no(){
			return this.container_no_;
		}
		
		public void SetContainer_no(string value){
			this.container_no_ = value;
		}
		public string GetRecord_type(){
			return this.record_type_;
		}
		
		public void SetRecord_type(string value){
			this.record_type_ = value;
		}
		
	}
	
}