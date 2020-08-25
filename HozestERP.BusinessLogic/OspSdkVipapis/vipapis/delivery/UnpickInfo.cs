using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class UnpickInfo {
		
		///<summary>
		/// 分仓库的未拣货数
		///</summary>
		
		private int? warehouse_not_pick_;
		
		///<summary>
		/// 补货数
		///</summary>
		
		private int? supply_num_;
		
		///<summary>
		/// 分仓库编码
		///</summary>
		
		private string sub_warehouse_;
		
		public int? GetWarehouse_not_pick(){
			return this.warehouse_not_pick_;
		}
		
		public void SetWarehouse_not_pick(int? value){
			this.warehouse_not_pick_ = value;
		}
		public int? GetSupply_num(){
			return this.supply_num_;
		}
		
		public void SetSupply_num(int? value){
			this.supply_num_ = value;
		}
		public string GetSub_warehouse(){
			return this.sub_warehouse_;
		}
		
		public void SetSub_warehouse(string value){
			this.sub_warehouse_ = value;
		}
		
	}
	
}