using System;

namespace vipapis.vreturn{
	
	
	public enum SelfReference {
		
		
		///<summary>
		/// 品骏配送
		///</summary>
		PINJUN = 0, 
		
		///<summary>
		/// 供应商自提
		///</summary>
		VENDOR = 1 
	}
	
	public class SelfReferenceUtil{
		
		private readonly int value;
		private SelfReferenceUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static SelfReference? FindByValue(int value){
			
			switch(value){
				
				case 0: return SelfReference.PINJUN; 
				case 1: return SelfReference.VENDOR; 
				
				default: return null; 
				
			}
			
		}
		
		public static SelfReference? FindByName(string name){
			
			if(SelfReference.PINJUN.ToString().Equals(name)){
				
				return SelfReference.PINJUN; 
			}
			
			if(SelfReference.VENDOR.ToString().Equals(name)){
				
				return SelfReference.VENDOR; 
			}
			
			
			return null;
			
		}
		
	}
	
}