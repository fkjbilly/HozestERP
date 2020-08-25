using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class CheckDeliveryFetchReturnResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 是否支持上门揽退的标记，0-不支持，1-支持
		///</summary>
		
		private int? canReceiveOnsite_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 不支持上门揽退商品sizeId
		///</summary>
		
		private List<long?> unsupportedMerItemNoSet_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public int? GetCanReceiveOnsite(){
			return this.canReceiveOnsite_;
		}
		
		public void SetCanReceiveOnsite(int? value){
			this.canReceiveOnsite_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public List<long?> GetUnsupportedMerItemNoSet(){
			return this.unsupportedMerItemNoSet_;
		}
		
		public void SetUnsupportedMerItemNoSet(List<long?> value){
			this.unsupportedMerItemNoSet_ = value;
		}
		
	}
	
}