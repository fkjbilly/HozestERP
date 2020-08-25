using System;

namespace vipapis.common{
	
	
	public enum Currency {
		
		
		///<summary>
		/// 人民币
		///</summary>
		CNY = 0, 
		
		///<summary>
		/// 美元
		///</summary>
		USD = 1, 
		
		///<summary>
		/// 欧元
		///</summary>
		EUR = 2, 
		
		///<summary>
		/// 英镑
		///</summary>
		GBP = 3 
	}
	
	public class CurrencyUtil{
		
		private readonly int value;
		private CurrencyUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static Currency? FindByValue(int value){
			
			switch(value){
				
				case 0: return Currency.CNY; 
				case 1: return Currency.USD; 
				case 2: return Currency.EUR; 
				case 3: return Currency.GBP; 
				
				default: return null; 
				
			}
			
		}
		
		public static Currency? FindByName(string name){
			
			if(Currency.CNY.ToString().Equals(name)){
				
				return Currency.CNY; 
			}
			
			if(Currency.USD.ToString().Equals(name)){
				
				return Currency.USD; 
			}
			
			if(Currency.EUR.ToString().Equals(name)){
				
				return Currency.EUR; 
			}
			
			if(Currency.GBP.ToString().Equals(name)){
				
				return Currency.GBP; 
			}
			
			
			return null;
			
		}
		
	}
	
}