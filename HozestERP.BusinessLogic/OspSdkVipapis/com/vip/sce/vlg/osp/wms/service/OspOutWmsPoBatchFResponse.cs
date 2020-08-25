using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OspOutWmsPoBatchFResponse {
		
		///<summary>
		/// 批次记录总条数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// PO批次列表
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModel> po_batch_list_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModel> GetPo_batch_list(){
			return this.po_batch_list_;
		}
		
		public void SetPo_batch_list(List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModel> value){
			this.po_batch_list_ = value;
		}
		
	}
	
}