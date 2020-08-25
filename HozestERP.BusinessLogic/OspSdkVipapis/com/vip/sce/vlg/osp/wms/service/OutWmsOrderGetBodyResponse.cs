using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutWmsOrderGetBodyResponse {
		
		///<summary>
		/// 订单信息列表
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OutWmsOrderInfo> returnList_;
		
		public List<com.vip.sce.vlg.osp.wms.service.OutWmsOrderInfo> GetReturnList(){
			return this.returnList_;
		}
		
		public void SetReturnList(List<com.vip.sce.vlg.osp.wms.service.OutWmsOrderInfo> value){
			this.returnList_ = value;
		}
		
	}
	
}