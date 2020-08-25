using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.loading.osp.service{
	
	
	
	
	
	public class GetBody {
		
		///<summary>
		/// 请求结果列表
		///</summary>
		
		private List<com.vip.haitao.loading.osp.service.OutRLHandleResultDetail> returnList_;
		
		public List<com.vip.haitao.loading.osp.service.OutRLHandleResultDetail> GetReturnList(){
			return this.returnList_;
		}
		
		public void SetReturnList(List<com.vip.haitao.loading.osp.service.OutRLHandleResultDetail> value){
			this.returnList_ = value;
		}
		
	}
	
}