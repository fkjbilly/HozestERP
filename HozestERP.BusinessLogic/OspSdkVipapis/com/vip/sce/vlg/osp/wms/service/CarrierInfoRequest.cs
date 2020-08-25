using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class CarrierInfoRequest {
		
		///<summary>
		/// 请求时间 	操作时间,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string request_time_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string cust_code_;
		
		///<summary>
		/// 国外订单物流明细状态
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.CarrierInfo> carrier_info_list_;
		
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
		public List<com.vip.sce.vlg.osp.wms.service.CarrierInfo> GetCarrier_info_list(){
			return this.carrier_info_list_;
		}
		
		public void SetCarrier_info_list(List<com.vip.sce.vlg.osp.wms.service.CarrierInfo> value){
			this.carrier_info_list_ = value;
		}
		
	}
	
}