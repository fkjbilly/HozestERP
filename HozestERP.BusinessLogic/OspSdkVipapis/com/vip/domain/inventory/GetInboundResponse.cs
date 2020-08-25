using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class GetInboundResponse {
		
		///<summary>
		/// 总记录条数
		///</summary>
		
		private int? detail_count_;
		
		///<summary>
		/// 入库可视化信息列表
		///</summary>
		
		private List<com.vip.domain.inventory.InboundItemInfo> items_;
		
		public int? GetDetail_count(){
			return this.detail_count_;
		}
		
		public void SetDetail_count(int? value){
			this.detail_count_ = value;
		}
		public List<com.vip.domain.inventory.InboundItemInfo> GetItems(){
			return this.items_;
		}
		
		public void SetItems(List<com.vip.domain.inventory.InboundItemInfo> value){
			this.items_ = value;
		}
		
	}
	
}