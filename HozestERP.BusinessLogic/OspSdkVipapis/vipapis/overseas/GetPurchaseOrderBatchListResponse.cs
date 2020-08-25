using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class GetPurchaseOrderBatchListResponse {
		
		///<summary>
		/// 批次记录总条数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// PO批次列表
		///</summary>
		
		private List<vipapis.overseas.PurchaseOrderBatchInfo> po_batch_list_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.overseas.PurchaseOrderBatchInfo> GetPo_batch_list(){
			return this.po_batch_list_;
		}
		
		public void SetPo_batch_list(List<vipapis.overseas.PurchaseOrderBatchInfo> value){
			this.po_batch_list_ = value;
		}
		
	}
	
}