using System;

namespace com.vip.order.biz.request.requirement{
	
	
	public enum OrderByDirection {
		
		
		
		ASC = 1, 
		
		
		DESC = 2 
	}
	
	public class OrderByDirectionUtil{
		
		private readonly int value;
		private OrderByDirectionUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static OrderByDirection? FindByValue(int value){
			
			switch(value){
				
				case 1: return OrderByDirection.ASC; 
				case 2: return OrderByDirection.DESC; 
				
				default: return null; 
				
			}
			
		}
		
		public static OrderByDirection? FindByName(string name){
			
			if(OrderByDirection.ASC.ToString().Equals(name)){
				
				return OrderByDirection.ASC; 
			}
			
			if(OrderByDirection.DESC.ToString().Equals(name)){
				
				return OrderByDirection.DESC; 
			}
			
			
			return null;
			
		}
		
	}
	
}