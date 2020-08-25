using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class InventoryUpdateResultResponse {
		
		///<summary>
		/// 总记录数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 库存调增调减结果明细
		///</summary>
		
		private List<vipapis.normal.InventoryUpdateResult> inventoryUpdateResultList_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.normal.InventoryUpdateResult> GetInventoryUpdateResultList(){
			return this.inventoryUpdateResultList_;
		}
		
		public void SetInventoryUpdateResultList(List<vipapis.normal.InventoryUpdateResult> value){
			this.inventoryUpdateResultList_ = value;
		}
		
	}
	
}