using System;

namespace com.vip.domain.order{
	
	
	public enum OrderIsPrintingPrice {
		
		
		///<summary>
		/// 要打印金额
		///</summary>
		IS_PRINTING_PRICE_0 = 0, 
		
		///<summary>
		/// 不打印金额
		///</summary>
		IS_PRINTING_PRICE_1 = 1 
	}
	
	public class OrderIsPrintingPriceUtil{
		
		private readonly int value;
		private OrderIsPrintingPriceUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static OrderIsPrintingPrice? FindByValue(int value){
			
			switch(value){
				
				case 0: return OrderIsPrintingPrice.IS_PRINTING_PRICE_0; 
				case 1: return OrderIsPrintingPrice.IS_PRINTING_PRICE_1; 
				
				default: return null; 
				
			}
			
		}
		
		public static OrderIsPrintingPrice? FindByName(string name){
			
			if(OrderIsPrintingPrice.IS_PRINTING_PRICE_0.ToString().Equals(name)){
				
				return OrderIsPrintingPrice.IS_PRINTING_PRICE_0; 
			}
			
			if(OrderIsPrintingPrice.IS_PRINTING_PRICE_1.ToString().Equals(name)){
				
				return OrderIsPrintingPrice.IS_PRINTING_PRICE_1; 
			}
			
			
			return null;
			
		}
		
	}
	
}