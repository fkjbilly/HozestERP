using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class FreezeTransIdAndInventoryType {
		
		///<summary>
		/// 冻结批次号
		///</summary>
		
		private int? frozen_trans_id_;
		
		///<summary>
		/// 仓库类型,462：JIT 463：OXO
		/// @sampleValue inventory_type 462
		///</summary>
		
		private int? inventory_type_;
		
		public int? GetFrozen_trans_id(){
			return this.frozen_trans_id_;
		}
		
		public void SetFrozen_trans_id(int? value){
			this.frozen_trans_id_ = value;
		}
		public int? GetInventory_type(){
			return this.inventory_type_;
		}
		
		public void SetInventory_type(int? value){
			this.inventory_type_ = value;
		}
		
	}
	
}