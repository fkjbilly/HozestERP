using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.store{
	
	
	
	
	
	public class StoreQueryResponse {
		
		///<summary>
		/// 总记录条数
		/// @sampleValue total 100
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 查询门店结果信息列表
		///</summary>
		
		private List<vipapis.store.StoreInfo> storeInfos_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.store.StoreInfo> GetStoreInfos(){
			return this.storeInfos_;
		}
		
		public void SetStoreInfos(List<vipapis.store.StoreInfo> value){
			this.storeInfos_ = value;
		}
		
	}
	
}