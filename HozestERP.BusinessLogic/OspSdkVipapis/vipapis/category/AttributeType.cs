using System;

namespace vipapis.category{
	
	
	public enum AttributeType {
		
		
		///<summary>
		/// 自然属性
		///</summary>
		Normal = 0, 
		
		///<summary>
		/// 标签属性
		///</summary>
		Tag = 1, 
		
		///<summary>
		/// 分类特有属性
		///</summary>
		Special = 2 
	}
	
	public class AttributeTypeUtil{
		
		private readonly int value;
		private AttributeTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static AttributeType? FindByValue(int value){
			
			switch(value){
				
				case 0: return AttributeType.Normal; 
				case 1: return AttributeType.Tag; 
				case 2: return AttributeType.Special; 
				
				default: return null; 
				
			}
			
		}
		
		public static AttributeType? FindByName(string name){
			
			if(AttributeType.Normal.ToString().Equals(name)){
				
				return AttributeType.Normal; 
			}
			
			if(AttributeType.Tag.ToString().Equals(name)){
				
				return AttributeType.Tag; 
			}
			
			if(AttributeType.Special.ToString().Equals(name)){
				
				return AttributeType.Special; 
			}
			
			
			return null;
			
		}
		
	}
	
}