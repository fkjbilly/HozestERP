using System;

namespace com.vip.domain.order{
	
	
	public enum ResponseCodeStatus {
		
		
		///<summary>
		/// 成功
		///</summary>
		SUCCESS = 1, 
		
		///<summary>
		/// 失败
		///</summary>
		FAIL = 0 
	}
	
	public class ResponseCodeStatusUtil{
		
		private readonly int value;
		private ResponseCodeStatusUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static ResponseCodeStatus? FindByValue(int value){
			
			switch(value){
				
				case 1: return ResponseCodeStatus.SUCCESS; 
				case 0: return ResponseCodeStatus.FAIL; 
				
				default: return null; 
				
			}
			
		}
		
		public static ResponseCodeStatus? FindByName(string name){
			
			if(ResponseCodeStatus.SUCCESS.ToString().Equals(name)){
				
				return ResponseCodeStatus.SUCCESS; 
			}
			
			if(ResponseCodeStatus.FAIL.ToString().Equals(name)){
				
				return ResponseCodeStatus.FAIL; 
			}
			
			
			return null;
			
		}
		
	}
	
}