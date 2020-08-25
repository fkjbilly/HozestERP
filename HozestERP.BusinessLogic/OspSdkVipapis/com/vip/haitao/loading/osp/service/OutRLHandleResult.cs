using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.loading.osp.service{
	
	
	
	
	
	public class OutRLHandleResult {
		
		///<summary>
		/// 返回消息头
		///</summary>
		
		private com.vip.haitao.loading.osp.service.PostHeader header_;
		
		///<summary>
		/// 返回请求结果列表
		///</summary>
		
		private com.vip.haitao.loading.osp.service.GetBody body_;
		
		public com.vip.haitao.loading.osp.service.PostHeader GetHeader(){
			return this.header_;
		}
		
		public void SetHeader(com.vip.haitao.loading.osp.service.PostHeader value){
			this.header_ = value;
		}
		public com.vip.haitao.loading.osp.service.GetBody GetBody(){
			return this.body_;
		}
		
		public void SetBody(com.vip.haitao.loading.osp.service.GetBody value){
			this.body_ = value;
		}
		
	}
	
}