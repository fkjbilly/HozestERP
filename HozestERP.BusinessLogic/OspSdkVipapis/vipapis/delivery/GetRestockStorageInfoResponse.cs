using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetRestockStorageInfoResponse {
		
		///<summary>
		/// 记录总数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 补货单实际入库明细列表
		///</summary>
		
		private List<vipapis.delivery.RestockStorageInfo> restock_storage_list_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.delivery.RestockStorageInfo> GetRestock_storage_list(){
			return this.restock_storage_list_;
		}
		
		public void SetRestock_storage_list(List<vipapis.delivery.RestockStorageInfo> value){
			this.restock_storage_list_ = value;
		}
		
	}
	
}