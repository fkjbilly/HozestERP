using System;

namespace com.vip.comment.api.admin.service{
	
	
	public enum Satisfaction {
		
		
		///<summary>
		/// 暂缺
		///</summary>
		NoOPion = 0, 
		
		///<summary>
		/// 满意
		///</summary>
		YES = 1, 
		
		///<summary>
		/// 不满意
		///</summary>
		NO = 2 
	}
	
	public class SatisfactionUtil{
		
		private readonly int value;
		private SatisfactionUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static Satisfaction? FindByValue(int value){
			
			switch(value){
				
				case 0: return Satisfaction.NoOPion; 
				case 1: return Satisfaction.YES; 
				case 2: return Satisfaction.NO; 
				
				default: return null; 
				
			}
			
		}
		
		public static Satisfaction? FindByName(string name){
			
			if(Satisfaction.NoOPion.ToString().Equals(name)){
				
				return Satisfaction.NoOPion; 
			}
			
			if(Satisfaction.YES.ToString().Equals(name)){
				
				return Satisfaction.YES; 
			}
			
			if(Satisfaction.NO.ToString().Equals(name)){
				
				return Satisfaction.NO; 
			}
			
			
			return null;
			
		}
		
	}
	
}