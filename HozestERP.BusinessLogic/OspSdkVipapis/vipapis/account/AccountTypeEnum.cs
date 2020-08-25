using System;

namespace vipapis.account{
	
	
	public enum AccountTypeEnum {
		
		
		///<summary>
		/// 在职
		///</summary>
		ACCOUNT_ON = 0, 
		
		///<summary>
		/// 离职
		///</summary>
		ACCOUNT_OFF = 1 
	}
	
	public class AccountTypeEnumUtil{
		
		private readonly int value;
		private AccountTypeEnumUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static AccountTypeEnum? FindByValue(int value){
			
			switch(value){
				
				case 0: return AccountTypeEnum.ACCOUNT_ON; 
				case 1: return AccountTypeEnum.ACCOUNT_OFF; 
				
				default: return null; 
				
			}
			
		}
		
		public static AccountTypeEnum? FindByName(string name){
			
			if(AccountTypeEnum.ACCOUNT_ON.ToString().Equals(name)){
				
				return AccountTypeEnum.ACCOUNT_ON; 
			}
			
			if(AccountTypeEnum.ACCOUNT_OFF.ToString().Equals(name)){
				
				return AccountTypeEnum.ACCOUNT_OFF; 
			}
			
			
			return null;
			
		}
		
	}
	
}