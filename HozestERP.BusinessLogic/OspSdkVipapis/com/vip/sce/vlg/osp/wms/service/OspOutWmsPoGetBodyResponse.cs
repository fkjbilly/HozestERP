using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OspOutWmsPoGetBodyResponse {
		
		///<summary>
		/// PO批次列表
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModel> returnList_;
		
		public List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModel> GetReturnList(){
			return this.returnList_;
		}
		
		public void SetReturnList(List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModel> value){
			this.returnList_ = value;
		}
		
	}
	
}