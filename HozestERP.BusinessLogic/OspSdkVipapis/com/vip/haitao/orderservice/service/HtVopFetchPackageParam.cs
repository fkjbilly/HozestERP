using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtVopFetchPackageParam {
		
		///<summary>
		/// 请求时间
		///</summary>
		
		private string requestTime_;
		
		///<summary>
		/// 用户代码
		///</summary>
		
		private string userId_;
		
		///<summary>
		/// 海关代码
		///</summary>
		
		private string customsCode_;
		
		///<summary>
		/// 子提单号列表
		///</summary>
		
		private List<com.vip.haitao.orderservice.service.VopOrderVo> subBillNumerList_;
		
		public string GetRequestTime(){
			return this.requestTime_;
		}
		
		public void SetRequestTime(string value){
			this.requestTime_ = value;
		}
		public string GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(string value){
			this.userId_ = value;
		}
		public string GetCustomsCode(){
			return this.customsCode_;
		}
		
		public void SetCustomsCode(string value){
			this.customsCode_ = value;
		}
		public List<com.vip.haitao.orderservice.service.VopOrderVo> GetSubBillNumerList(){
			return this.subBillNumerList_;
		}
		
		public void SetSubBillNumerList(List<com.vip.haitao.orderservice.service.VopOrderVo> value){
			this.subBillNumerList_ = value;
		}
		
	}
	
}