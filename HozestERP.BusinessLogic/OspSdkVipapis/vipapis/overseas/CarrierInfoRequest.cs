using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class CarrierInfoRequest {
		
		///<summary>
		/// 操作时间,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string request_time_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string cust_code_;
		
		///<summary>
		/// 物流状态信息列表
		///</summary>
		
		private List<vipapis.overseas.CarrierInfo> carrier_info_list_;
		
		public string GetRequest_time(){
			return this.request_time_;
		}
		
		public void SetRequest_time(string value){
			this.request_time_ = value;
		}
		public string GetCust_code(){
			return this.cust_code_;
		}
		
		public void SetCust_code(string value){
			this.cust_code_ = value;
		}
		public List<vipapis.overseas.CarrierInfo> GetCarrier_info_list(){
			return this.carrier_info_list_;
		}
		
		public void SetCarrier_info_list(List<vipapis.overseas.CarrierInfo> value){
			this.carrier_info_list_ = value;
		}
		
	}
	
}