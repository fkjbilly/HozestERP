using System;

namespace com.vip.domain.inventory{
	
	
	public enum RealtimeInventoryQueryType {
		
		
		///<summary>
		/// 商品+入库凭证
		///</summary>
		ITEM_AND_PO = 1, 
		
		///<summary>
		/// 商品
		///</summary>
		ITEM = 2, 
		
		///<summary>
		/// 入库凭证
		///</summary>
		PO = 3 
	}
	
	public class RealtimeInventoryQueryTypeUtil{
		
		private readonly int value;
		private RealtimeInventoryQueryTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static RealtimeInventoryQueryType? FindByValue(int value){
			
			switch(value){
				
				case 1: return RealtimeInventoryQueryType.ITEM_AND_PO; 
				case 2: return RealtimeInventoryQueryType.ITEM; 
				case 3: return RealtimeInventoryQueryType.PO; 
				
				default: return null; 
				
			}
			
		}
		
		public static RealtimeInventoryQueryType? FindByName(string name){
			
			if(RealtimeInventoryQueryType.ITEM_AND_PO.ToString().Equals(name)){
				
				return RealtimeInventoryQueryType.ITEM_AND_PO; 
			}
			
			if(RealtimeInventoryQueryType.ITEM.ToString().Equals(name)){
				
				return RealtimeInventoryQueryType.ITEM; 
			}
			
			if(RealtimeInventoryQueryType.PO.ToString().Equals(name)){
				
				return RealtimeInventoryQueryType.PO; 
			}
			
			
			return null;
			
		}
		
	}
	
}