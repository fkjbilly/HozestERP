using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.idcard.osp.service{
	
	
	
	
	
	public class HtIdCardInfoResponse {
		
		///<summary>
		/// 响应头
		///</summary>
		
		private com.vip.haitao.idcard.osp.service.Head head_;
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.haitao.idcard.osp.service.HtIdCardInfo idCardInfo_;
		
		public com.vip.haitao.idcard.osp.service.Head GetHead(){
			return this.head_;
		}
		
		public void SetHead(com.vip.haitao.idcard.osp.service.Head value){
			this.head_ = value;
		}
		public com.vip.haitao.idcard.osp.service.HtIdCardInfo GetIdCardInfo(){
			return this.idCardInfo_;
		}
		
		public void SetIdCardInfo(com.vip.haitao.idcard.osp.service.HtIdCardInfo value){
			this.idCardInfo_ = value;
		}
		
	}
	
}