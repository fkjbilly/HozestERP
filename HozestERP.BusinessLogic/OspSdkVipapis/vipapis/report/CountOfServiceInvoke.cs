using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.report{
	
	
	
	
	
	public class CountOfServiceInvoke {
		
		///<summary>
		/// 调用时间YYYYMMDD
		/// @sampleValue invoke_date 20160111
		///</summary>
		
		private string invoke_date_;
		
		///<summary>
		/// appKey
		/// @sampleValue app_key qrewrew
		///</summary>
		
		private string app_key_;
		
		///<summary>
		/// 扩展属性名
		/// @sampleValue ext_attr_name vendor_id
		///</summary>
		
		private string ext_attr_name_;
		
		///<summary>
		/// 扩展属性值
		/// @sampleValue ext_attr_value 550
		///</summary>
		
		private string ext_attr_value_;
		
		///<summary>
		/// 服务名称
		/// @sampleValue service_name vipapis.delivery.DvdDeliveryService
		///</summary>
		
		private string service_name_;
		
		///<summary>
		/// 方法名称
		/// @sampleValue method_name ship
		///</summary>
		
		private string method_name_;
		
		///<summary>
		/// 业务调用数量
		/// @sampleValue business_amount 231
		///</summary>
		
		private long? business_amount_;
		
		///<summary>
		/// 接口调用数量
		/// @sampleValue invoke_amount 231
		///</summary>
		
		private long? invoke_amount_;
		
		///<summary>
		/// 接口调用异常数量
		/// @sampleValue exception_amount 231
		///</summary>
		
		private long? exception_amount_;
		
		public string GetInvoke_date(){
			return this.invoke_date_;
		}
		
		public void SetInvoke_date(string value){
			this.invoke_date_ = value;
		}
		public string GetApp_key(){
			return this.app_key_;
		}
		
		public void SetApp_key(string value){
			this.app_key_ = value;
		}
		public string GetExt_attr_name(){
			return this.ext_attr_name_;
		}
		
		public void SetExt_attr_name(string value){
			this.ext_attr_name_ = value;
		}
		public string GetExt_attr_value(){
			return this.ext_attr_value_;
		}
		
		public void SetExt_attr_value(string value){
			this.ext_attr_value_ = value;
		}
		public string GetService_name(){
			return this.service_name_;
		}
		
		public void SetService_name(string value){
			this.service_name_ = value;
		}
		public string GetMethod_name(){
			return this.method_name_;
		}
		
		public void SetMethod_name(string value){
			this.method_name_ = value;
		}
		public long? GetBusiness_amount(){
			return this.business_amount_;
		}
		
		public void SetBusiness_amount(long? value){
			this.business_amount_ = value;
		}
		public long? GetInvoke_amount(){
			return this.invoke_amount_;
		}
		
		public void SetInvoke_amount(long? value){
			this.invoke_amount_ = value;
		}
		public long? GetException_amount(){
			return this.exception_amount_;
		}
		
		public void SetException_amount(long? value){
			this.exception_amount_ = value;
		}
		
	}
	
}