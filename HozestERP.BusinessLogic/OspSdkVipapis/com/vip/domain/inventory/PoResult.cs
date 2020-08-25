using System;

namespace com.vip.domain.inventory{
	
	
	public enum PoResult {
		
		
		///<summary>
		/// 失败
		///</summary>
		FAIL = 0, 
		
		///<summary>
		/// 成功
		///</summary>
		SUCCESS = 1 
	}
	
	public class PoResultUtil{
		
		private readonly int value;
		private PoResultUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static PoResult? FindByValue(int value){
			
			switch(value){
				
				case 0: return PoResult.FAIL; 
				case 1: return PoResult.SUCCESS; 
				
				default: return null; 
				
			}
			
		}
		
		public static PoResult? FindByName(string name){
			
			if(PoResult.FAIL.ToString().Equals(name)){
				
				return PoResult.FAIL; 
			}
			
			if(PoResult.SUCCESS.ToString().Equals(name)){
				
				return PoResult.SUCCESS; 
			}
			
			
			return null;
			
		}
		
	}
	
}