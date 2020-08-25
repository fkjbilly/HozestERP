using System;

namespace com.vip.domain.inventory{
	
	
	public enum RealtimeInventoryLocationParameter {
		
		
		///<summary>
		/// 售卖库位
		///</summary>
		SALE_LOCATION = 1, 
		
		///<summary>
		/// 非售卖库位
		///</summary>
		NONE_SALE_LOCATION = 2 
	}
	
	public class RealtimeInventoryLocationParameterUtil{
		
		private readonly int value;
		private RealtimeInventoryLocationParameterUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static RealtimeInventoryLocationParameter? FindByValue(int value){
			
			switch(value){
				
				case 1: return RealtimeInventoryLocationParameter.SALE_LOCATION; 
				case 2: return RealtimeInventoryLocationParameter.NONE_SALE_LOCATION; 
				
				default: return null; 
				
			}
			
		}
		
		public static RealtimeInventoryLocationParameter? FindByName(string name){
			
			if(RealtimeInventoryLocationParameter.SALE_LOCATION.ToString().Equals(name)){
				
				return RealtimeInventoryLocationParameter.SALE_LOCATION; 
			}
			
			if(RealtimeInventoryLocationParameter.NONE_SALE_LOCATION.ToString().Equals(name)){
				
				return RealtimeInventoryLocationParameter.NONE_SALE_LOCATION; 
			}
			
			
			return null;
			
		}
		
	}
	
}