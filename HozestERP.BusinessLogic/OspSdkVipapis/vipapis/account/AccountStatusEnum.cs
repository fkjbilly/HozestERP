using System;

namespace vipapis.account{
	
	
	public enum AccountStatusEnum {
		
		
		///<summary>
		/// 新客
		///</summary>
		ACCOUNT_STATUS_NEW = 1, 
		
		///<summary>
		/// 老客
		///</summary>
		ACCOUNT_STATUS_OLD = 0 
	}
	
	public class AccountStatusEnumUtil{
		
		private readonly int value;
		private AccountStatusEnumUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static AccountStatusEnum? FindByValue(int value){
			
			switch(value){
				
				case 1: return AccountStatusEnum.ACCOUNT_STATUS_NEW; 
				case 0: return AccountStatusEnum.ACCOUNT_STATUS_OLD; 
				
				default: return null; 
				
			}
			
		}
		
		public static AccountStatusEnum? FindByName(string name){
			
			if(AccountStatusEnum.ACCOUNT_STATUS_NEW.ToString().Equals(name)){
				
				return AccountStatusEnum.ACCOUNT_STATUS_NEW; 
			}
			
			if(AccountStatusEnum.ACCOUNT_STATUS_OLD.ToString().Equals(name)){
				
				return AccountStatusEnum.ACCOUNT_STATUS_OLD; 
			}
			
			
			return null;
			
		}
		
	}
	
}