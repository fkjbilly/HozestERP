using System;

namespace com.vip.domain.order{
	
	
	public enum OrderExtPayType {
		
		
		///<summary>
		/// 现金
		///</summary>
		EXT_PAY_TYPE_0 = 0, 
		
		///<summary>
		/// POS机
		///</summary>
		EXT_PAY_TYPE_1 = 1, 
		
		///<summary>
		/// 支付宝
		///</summary>
		EXT_PAY_TYPE_2 = 2 
	}
	
	public class OrderExtPayTypeUtil{
		
		private readonly int value;
		private OrderExtPayTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static OrderExtPayType? FindByValue(int value){
			
			switch(value){
				
				case 0: return OrderExtPayType.EXT_PAY_TYPE_0; 
				case 1: return OrderExtPayType.EXT_PAY_TYPE_1; 
				case 2: return OrderExtPayType.EXT_PAY_TYPE_2; 
				
				default: return null; 
				
			}
			
		}
		
		public static OrderExtPayType? FindByName(string name){
			
			if(OrderExtPayType.EXT_PAY_TYPE_0.ToString().Equals(name)){
				
				return OrderExtPayType.EXT_PAY_TYPE_0; 
			}
			
			if(OrderExtPayType.EXT_PAY_TYPE_1.ToString().Equals(name)){
				
				return OrderExtPayType.EXT_PAY_TYPE_1; 
			}
			
			if(OrderExtPayType.EXT_PAY_TYPE_2.ToString().Equals(name)){
				
				return OrderExtPayType.EXT_PAY_TYPE_2; 
			}
			
			
			return null;
			
		}
		
	}
	
}