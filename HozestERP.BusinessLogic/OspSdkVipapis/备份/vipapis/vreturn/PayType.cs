using System;

namespace vipapis.vreturn{
	
	
	public enum PayType {
		
		
		///<summary>
		/// 货到付款
		///</summary>
		CASH_ON_DELIVERY = 0, 
		
		///<summary>
		/// 现付月结
		///</summary>
		MONTHLY_STATEMENT = 1 
	}
	
	public class PayTypeUtil{
		
		private readonly int value;
		private PayTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static PayType? FindByValue(int value){
			
			switch(value){
				
				case 0: return PayType.CASH_ON_DELIVERY; 
				case 1: return PayType.MONTHLY_STATEMENT; 
				
				default: return null; 
				
			}
			
		}
		
		public static PayType? FindByName(string name){
			
			if(PayType.CASH_ON_DELIVERY.ToString().Equals(name)){
				
				return PayType.CASH_ON_DELIVERY; 
			}
			
			if(PayType.MONTHLY_STATEMENT.ToString().Equals(name)){
				
				return PayType.MONTHLY_STATEMENT; 
			}
			
			
			return null;
			
		}
		
	}
	
}