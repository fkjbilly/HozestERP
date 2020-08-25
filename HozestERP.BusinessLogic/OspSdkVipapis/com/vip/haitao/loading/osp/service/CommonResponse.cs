using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.loading.osp.service{
	
	
	
	
	
	public class CommonResponse {
		
		///<summary>
		/// 返回时间
		/// @sampleValue responseTime 2016-11-22 12:01:59
		///</summary>
		
		private string responseTime_;
		
		///<summary>
		/// 返回状态码
		/// @sampleValue sysResponseCode S00
		///</summary>
		
		private string sysResponseCode_;
		
		///<summary>
		/// 返回信息
		/// @sampleValue sysResponseMsg 系统无异常
		///</summary>
		
		private string sysResponseMsg_;
		
		///<summary>
		/// 返回失败订单列表
		/// @sampleValue failOrders []
		///</summary>
		
		private List<com.vip.haitao.loading.osp.service.FailOrders> failOrders_;
		
		public string GetResponseTime(){
			return this.responseTime_;
		}
		
		public void SetResponseTime(string value){
			this.responseTime_ = value;
		}
		public string GetSysResponseCode(){
			return this.sysResponseCode_;
		}
		
		public void SetSysResponseCode(string value){
			this.sysResponseCode_ = value;
		}
		public string GetSysResponseMsg(){
			return this.sysResponseMsg_;
		}
		
		public void SetSysResponseMsg(string value){
			this.sysResponseMsg_ = value;
		}
		public List<com.vip.haitao.loading.osp.service.FailOrders> GetFailOrders(){
			return this.failOrders_;
		}
		
		public void SetFailOrders(List<com.vip.haitao.loading.osp.service.FailOrders> value){
			this.failOrders_ = value;
		}
		
	}
	
}