using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutWmsReturnOrderBodyResponse {
		
		///<summary>
		/// 订单信息列表
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeader> returnList_;
		
		public List<com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeader> GetReturnList(){
			return this.returnList_;
		}
		
		public void SetReturnList(List<com.vip.sce.vlg.osp.wms.service.OutWmsReturnOrderHeader> value){
			this.returnList_ = value;
		}
		
	}
	
}