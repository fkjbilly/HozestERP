using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.loading.osp.service{
	
	
	
	
	
	public class PostResponse {
		
		///<summary>
		/// 返回响应header信息
		///</summary>
		
		private com.vip.haitao.loading.osp.service.PostHeader header_;
		
		///<summary>
		/// 返回响应body信息
		///</summary>
		
		private com.vip.haitao.loading.osp.service.PostBody body_;
		
		public com.vip.haitao.loading.osp.service.PostHeader GetHeader(){
			return this.header_;
		}
		
		public void SetHeader(com.vip.haitao.loading.osp.service.PostHeader value){
			this.header_ = value;
		}
		public com.vip.haitao.loading.osp.service.PostBody GetBody(){
			return this.body_;
		}
		
		public void SetBody(com.vip.haitao.loading.osp.service.PostBody value){
			this.body_ = value;
		}
		
	}
	
}