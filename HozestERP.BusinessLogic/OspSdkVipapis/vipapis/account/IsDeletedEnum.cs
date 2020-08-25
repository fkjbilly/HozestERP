using System;

namespace vipapis.account{
	
	
	public enum IsDeletedEnum {
		
		
		///<summary>
		/// 未删除
		///</summary>
		IS_DELETED_NO = 0, 
		
		///<summary>
		/// 已删除
		///</summary>
		IS_DELETED_YES = 1 
	}
	
	public class IsDeletedEnumUtil{
		
		private readonly int value;
		private IsDeletedEnumUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static IsDeletedEnum? FindByValue(int value){
			
			switch(value){
				
				case 0: return IsDeletedEnum.IS_DELETED_NO; 
				case 1: return IsDeletedEnum.IS_DELETED_YES; 
				
				default: return null; 
				
			}
			
		}
		
		public static IsDeletedEnum? FindByName(string name){
			
			if(IsDeletedEnum.IS_DELETED_NO.ToString().Equals(name)){
				
				return IsDeletedEnum.IS_DELETED_NO; 
			}
			
			if(IsDeletedEnum.IS_DELETED_YES.ToString().Equals(name)){
				
				return IsDeletedEnum.IS_DELETED_YES; 
			}
			
			
			return null;
			
		}
		
	}
	
}