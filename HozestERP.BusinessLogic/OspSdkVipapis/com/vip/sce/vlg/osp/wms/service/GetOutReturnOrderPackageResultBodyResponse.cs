using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class GetOutReturnOrderPackageResultBodyResponse {
		
		///<summary>
		/// 大包扫面结果列表信息
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageResult> returnList_;
		
		public List<com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageResult> GetReturnList(){
			return this.returnList_;
		}
		
		public void SetReturnList(List<com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageResult> value){
			this.returnList_ = value;
		}
		
	}
	
}