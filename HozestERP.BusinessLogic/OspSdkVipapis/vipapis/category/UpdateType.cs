using System;

namespace vipapis.category{
	
	
	public enum UpdateType {
		
		
		///<summary>
		/// 添加
		///</summary>
		Insert = 0, 
		
		///<summary>
		/// 更新
		///</summary>
		Update = 1, 
		
		///<summary>
		/// 删除
		///</summary>
		Delete = 2 
	}
	
	public class UpdateTypeUtil{
		
		private readonly int value;
		private UpdateTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static UpdateType? FindByValue(int value){
			
			switch(value){
				
				case 0: return UpdateType.Insert; 
				case 1: return UpdateType.Update; 
				case 2: return UpdateType.Delete; 
				
				default: return null; 
				
			}
			
		}
		
		public static UpdateType? FindByName(string name){
			
			if(UpdateType.Insert.ToString().Equals(name)){
				
				return UpdateType.Insert; 
			}
			
			if(UpdateType.Update.ToString().Equals(name)){
				
				return UpdateType.Update; 
			}
			
			if(UpdateType.Delete.ToString().Equals(name)){
				
				return UpdateType.Delete; 
			}
			
			
			return null;
			
		}
		
	}
	
}