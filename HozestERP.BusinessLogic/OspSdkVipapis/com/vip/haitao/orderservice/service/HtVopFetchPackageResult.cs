using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtVopFetchPackageResult {
		
		///<summary>
		/// 请求头
		///</summary>
		
		private com.vip.haitao.orderservice.service.Head head_;
		
		///<summary>
		/// 批次号列表
		///</summary>
		
		private List<com.vip.haitao.orderservice.service.ForwordToHtsOrderVo> interBatchNos_;
		
		public com.vip.haitao.orderservice.service.Head GetHead(){
			return this.head_;
		}
		
		public void SetHead(com.vip.haitao.orderservice.service.Head value){
			this.head_ = value;
		}
		public List<com.vip.haitao.orderservice.service.ForwordToHtsOrderVo> GetInterBatchNos(){
			return this.interBatchNos_;
		}
		
		public void SetInterBatchNos(List<com.vip.haitao.orderservice.service.ForwordToHtsOrderVo> value){
			this.interBatchNos_ = value;
		}
		
	}
	
}