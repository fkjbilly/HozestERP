using System;

namespace vipapis.category{
	
	
	public enum CategoryType {
		
		
		///<summary>
		/// 顶层类目节点
		///</summary>
		TopCategory = 0, 
		
		///<summary>
		/// 中间层类目节点
		///</summary>
		SubCategory = 1, 
		
		///<summary>
		/// 最低层类目节点，商品只能挂载到这个节点上
		///</summary>
		LeafCategory = 2 
	}
	
	public class CategoryTypeUtil{
		
		private readonly int value;
		private CategoryTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static CategoryType? FindByValue(int value){
			
			switch(value){
				
				case 0: return CategoryType.TopCategory; 
				case 1: return CategoryType.SubCategory; 
				case 2: return CategoryType.LeafCategory; 
				
				default: return null; 
				
			}
			
		}
		
		public static CategoryType? FindByName(string name){
			
			if(CategoryType.TopCategory.ToString().Equals(name)){
				
				return CategoryType.TopCategory; 
			}
			
			if(CategoryType.SubCategory.ToString().Equals(name)){
				
				return CategoryType.SubCategory; 
			}
			
			if(CategoryType.LeafCategory.ToString().Equals(name)){
				
				return CategoryType.LeafCategory; 
			}
			
			
			return null;
			
		}
		
	}
	
}