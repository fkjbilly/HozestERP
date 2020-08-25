using System;

namespace com.vip.domain.inventory{
	
	
	public enum InboundQueryType {
		
		
		///<summary>
		/// 商品+入库凭证
		///</summary>
		ITEM_AND_PO = 1, 
		
		///<summary>
		/// 入库凭证
		///</summary>
		PO = 2 
	}
	
	public class InboundQueryTypeUtil{
		
		private readonly int value;
		private InboundQueryTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static InboundQueryType? FindByValue(int value){
			
			switch(value){
				
				case 1: return InboundQueryType.ITEM_AND_PO; 
				case 2: return InboundQueryType.PO; 
				
				default: return null; 
				
			}
			
		}
		
		public static InboundQueryType? FindByName(string name){
			
			if(InboundQueryType.ITEM_AND_PO.ToString().Equals(name)){
				
				return InboundQueryType.ITEM_AND_PO; 
			}
			
			if(InboundQueryType.PO.ToString().Equals(name)){
				
				return InboundQueryType.PO; 
			}
			
			
			return null;
			
		}
		
	}
	
}