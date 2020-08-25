using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class GetOutShipContainerResultBodyResponse {
		
		///<summary>
		/// 出仓批次返回列表信息
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OutShipContainerResult> returnList_;
		
		public List<com.vip.sce.vlg.osp.wms.service.OutShipContainerResult> GetReturnList(){
			return this.returnList_;
		}
		
		public void SetReturnList(List<com.vip.sce.vlg.osp.wms.service.OutShipContainerResult> value){
			this.returnList_ = value;
		}
		
	}
	
}