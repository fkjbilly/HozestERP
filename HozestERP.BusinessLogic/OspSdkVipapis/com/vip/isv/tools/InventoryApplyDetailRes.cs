using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class InventoryApplyDetailRes {
		
		///<summary>
		/// 结果集
		///</summary>
		
		private List<com.vip.isv.tools.InventoryApplyDetailDo> inventoryApplyDetails_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? totalCount_;
		
		public List<com.vip.isv.tools.InventoryApplyDetailDo> GetInventoryApplyDetails(){
			return this.inventoryApplyDetails_;
		}
		
		public void SetInventoryApplyDetails(List<com.vip.isv.tools.InventoryApplyDetailDo> value){
			this.inventoryApplyDetails_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}