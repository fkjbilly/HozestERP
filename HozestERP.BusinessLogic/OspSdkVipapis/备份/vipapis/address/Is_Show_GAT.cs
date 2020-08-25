using System;

namespace vipapis.address{
	
	
	public enum Is_Show_GAT {
		
		
		///<summary>
		/// 只显示大陆地址
		///</summary>
		SHOW_MAINLAND = 0, 
		
		///<summary>
		/// 只显示港澳台
		///</summary>
		SHOW_GAT = 1, 
		
		///<summary>
		/// 显示全部
		///</summary>
		SHOW_ALL = -1 
	}
	
	public class Is_Show_GATUtil{
		
		private readonly int value;
		private Is_Show_GATUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static Is_Show_GAT? FindByValue(int value){
			
			switch(value){
				
				case 0: return Is_Show_GAT.SHOW_MAINLAND; 
				case 1: return Is_Show_GAT.SHOW_GAT; 
				case -1: return Is_Show_GAT.SHOW_ALL; 
				
				default: return null; 
				
			}
			
		}
		
		public static Is_Show_GAT? FindByName(string name){
			
			if(Is_Show_GAT.SHOW_MAINLAND.ToString().Equals(name)){
				
				return Is_Show_GAT.SHOW_MAINLAND; 
			}
			
			if(Is_Show_GAT.SHOW_GAT.ToString().Equals(name)){
				
				return Is_Show_GAT.SHOW_GAT; 
			}
			
			if(Is_Show_GAT.SHOW_ALL.ToString().Equals(name)){
				
				return Is_Show_GAT.SHOW_ALL; 
			}
			
			
			return null;
			
		}
		
	}
	
}