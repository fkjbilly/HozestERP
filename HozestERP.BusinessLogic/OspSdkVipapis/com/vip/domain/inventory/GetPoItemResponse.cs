using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class GetPoItemResponse {
		
		///<summary>
		/// 记录总数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 入库单明细列表
		///</summary>
		
		private List<com.vip.domain.inventory.PoItemObject> poItemList_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<com.vip.domain.inventory.PoItemObject> GetPoItemList(){
			return this.poItemList_;
		}
		
		public void SetPoItemList(List<com.vip.domain.inventory.PoItemObject> value){
			this.poItemList_ = value;
		}
		
	}
	
}