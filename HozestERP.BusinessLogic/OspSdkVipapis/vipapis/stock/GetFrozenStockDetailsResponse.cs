using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class GetFrozenStockDetailsResponse {
		
		///<summary>
		/// 冻结库存列表
		///</summary>
		
		private List<vipapis.stock.FrozenInventory> forzen_inventory_list_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.stock.FrozenInventory> GetForzen_inventory_list(){
			return this.forzen_inventory_list_;
		}
		
		public void SetForzen_inventory_list(List<vipapis.stock.FrozenInventory> value){
			this.forzen_inventory_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}