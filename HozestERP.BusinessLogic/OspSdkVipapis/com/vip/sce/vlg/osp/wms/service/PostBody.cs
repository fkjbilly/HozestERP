using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class PostBody {
		
		///<summary>
		/// 返回响应List(处理成功)
		///</summary>
		
		private List<string> returnList_;
		
		///<summary>
		/// 返回响应List(处理失败)
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.PostReturnError> returnErrorList_;
		
		public List<string> GetReturnList(){
			return this.returnList_;
		}
		
		public void SetReturnList(List<string> value){
			this.returnList_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.PostReturnError> GetReturnErrorList(){
			return this.returnErrorList_;
		}
		
		public void SetReturnErrorList(List<com.vip.sce.vlg.osp.wms.service.PostReturnError> value){
			this.returnErrorList_ = value;
		}
		
	}
	
}