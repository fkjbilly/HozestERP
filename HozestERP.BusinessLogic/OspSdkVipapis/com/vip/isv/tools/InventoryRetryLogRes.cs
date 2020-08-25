using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class InventoryRetryLogRes {
		
		///<summary>
		/// 结果集
		///</summary>
		
		private List<com.vip.isv.tools.InventoryRetryLogDo> inventoryRetryLogDos_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? totalCount_;
		
		public List<com.vip.isv.tools.InventoryRetryLogDo> GetInventoryRetryLogDos(){
			return this.inventoryRetryLogDos_;
		}
		
		public void SetInventoryRetryLogDos(List<com.vip.isv.tools.InventoryRetryLogDo> value){
			this.inventoryRetryLogDos_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}