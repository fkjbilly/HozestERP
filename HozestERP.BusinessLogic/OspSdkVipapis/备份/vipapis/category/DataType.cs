using System;

namespace vipapis.category{
	
	
	public enum DataType {
		
		
		///<summary>
		/// 文本数据类型（不包含英文标点符号）
		///</summary>
		Text = 0, 
		
		///<summary>
		/// 数值数据类型，有单位Unit字段
		///</summary>
		Numeric = 1, 
		
		///<summary>
		/// 选项数据类型，有选项Option数据记录
		///</summary>
		option = 2 
	}
	
	public class DataTypeUtil{
		
		private readonly int value;
		private DataTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static DataType? FindByValue(int value){
			
			switch(value){
				
				case 0: return DataType.Text; 
				case 1: return DataType.Numeric; 
				case 2: return DataType.option; 
				
				default: return null; 
				
			}
			
		}
		
		public static DataType? FindByName(string name){
			
			if(DataType.Text.ToString().Equals(name)){
				
				return DataType.Text; 
			}
			
			if(DataType.Numeric.ToString().Equals(name)){
				
				return DataType.Numeric; 
			}
			
			if(DataType.option.ToString().Equals(name)){
				
				return DataType.option; 
			}
			
			
			return null;
			
		}
		
	}
	
}