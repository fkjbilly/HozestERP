using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class PostResponse {
		
		///<summary>
		/// 返回响应header信息
		///</summary>
		
		private com.vip.sce.vlg.osp.wms.service.PostHeader header_;
		
		///<summary>
		/// 返回响应body信息
		///</summary>
		
		private com.vip.sce.vlg.osp.wms.service.PostBody body_;
		
		public com.vip.sce.vlg.osp.wms.service.PostHeader GetHeader(){
			return this.header_;
		}
		
		public void SetHeader(com.vip.sce.vlg.osp.wms.service.PostHeader value){
			this.header_ = value;
		}
		public com.vip.sce.vlg.osp.wms.service.PostBody GetBody(){
			return this.body_;
		}
		
		public void SetBody(com.vip.sce.vlg.osp.wms.service.PostBody value){
			this.body_ = value;
		}
		
	}
	
}