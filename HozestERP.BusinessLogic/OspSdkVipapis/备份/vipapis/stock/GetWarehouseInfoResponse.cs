using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class GetWarehouseInfoResponse {
		
		///<summary>
		/// 仓库基础信息列表
		///</summary>
		
		private List<vipapis.stock.WarehouseInfoList> warehouse_info_list_;
		
		public List<vipapis.stock.WarehouseInfoList> GetWarehouse_info_list(){
			return this.warehouse_info_list_;
		}
		
		public void SetWarehouse_info_list(List<vipapis.stock.WarehouseInfoList> value){
			this.warehouse_info_list_ = value;
		}
		
	}
	
}