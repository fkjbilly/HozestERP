using System;

namespace com.vip.domain.inventory{
	
	
	public enum InboundStatus {
		
		
		///<summary>
		/// 未到仓
		///</summary>
		NOT_TO_WAREHOUSE = 0, 
		
		///<summary>
		/// 入仓中
		///</summary>
		IN_RETURN = 1, 
		
		///<summary>
		/// 已入仓
		///</summary>
		IN_WAREHOUSE = 2 
	}
	
	public class InboundStatusUtil{
		
		private readonly int value;
		private InboundStatusUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static InboundStatus? FindByValue(int value){
			
			switch(value){
				
				case 0: return InboundStatus.NOT_TO_WAREHOUSE; 
				case 1: return InboundStatus.IN_RETURN; 
				case 2: return InboundStatus.IN_WAREHOUSE; 
				
				default: return null; 
				
			}
			
		}
		
		public static InboundStatus? FindByName(string name){
			
			if(InboundStatus.NOT_TO_WAREHOUSE.ToString().Equals(name)){
				
				return InboundStatus.NOT_TO_WAREHOUSE; 
			}
			
			if(InboundStatus.IN_RETURN.ToString().Equals(name)){
				
				return InboundStatus.IN_RETURN; 
			}
			
			if(InboundStatus.IN_WAREHOUSE.ToString().Equals(name)){
				
				return InboundStatus.IN_WAREHOUSE; 
			}
			
			
			return null;
			
		}
		
	}
	
}