using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class GetOutWmsZcodeApplyBodyResponse {
		
		///<summary>
		/// 出仓批次返回列表信息
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OutWmsZcodeApplyInfo> returnList_;
		
		public List<com.vip.sce.vlg.osp.wms.service.OutWmsZcodeApplyInfo> GetReturnList(){
			return this.returnList_;
		}
		
		public void SetReturnList(List<com.vip.sce.vlg.osp.wms.service.OutWmsZcodeApplyInfo> value){
			this.returnList_ = value;
		}
		
	}
	
}