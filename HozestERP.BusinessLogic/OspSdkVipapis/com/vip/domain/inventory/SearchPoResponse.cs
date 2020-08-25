using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class SearchPoResponse {
		
		///<summary>
		/// 记录总数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 入库单列表
		///</summary>
		
		private List<com.vip.domain.inventory.PoObject> poList_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<com.vip.domain.inventory.PoObject> GetPoList(){
			return this.poList_;
		}
		
		public void SetPoList(List<com.vip.domain.inventory.PoObject> value){
			this.poList_ = value;
		}
		
	}
	
}