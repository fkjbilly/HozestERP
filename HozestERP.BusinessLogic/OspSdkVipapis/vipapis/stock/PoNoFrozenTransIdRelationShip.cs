using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class PoNoFrozenTransIdRelationShip {
		
		///<summary>
		/// 采购编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 冻结批次号列表
		/// @sampleValue frozen_trans_id_list 
		///</summary>
		
		private List<int?> frozen_trans_id_list_;
		
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public List<int?> GetFrozen_trans_id_list(){
			return this.frozen_trans_id_list_;
		}
		
		public void SetFrozen_trans_id_list(List<int?> value){
			this.frozen_trans_id_list_ = value;
		}
		
	}
	
}