using System;

namespace vipapis.brand{
	
	
	public enum BrandSearchType {
		
		
		///<summary>
		/// 品牌名称
		///</summary>
		brand_name = 0, 
		
		///<summary>
		/// 品牌英文名
		///</summary>
		brand_name_eng = 1 
	}
	
	public class BrandSearchTypeUtil{
		
		private readonly int value;
		private BrandSearchTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static BrandSearchType? FindByValue(int value){
			
			switch(value){
				
				case 0: return BrandSearchType.brand_name; 
				case 1: return BrandSearchType.brand_name_eng; 
				
				default: return null; 
				
			}
			
		}
		
		public static BrandSearchType? FindByName(string name){
			
			if(BrandSearchType.brand_name.ToString().Equals(name)){
				
				return BrandSearchType.brand_name; 
			}
			
			if(BrandSearchType.brand_name_eng.ToString().Equals(name)){
				
				return BrandSearchType.brand_name_eng; 
			}
			
			
			return null;
			
		}
		
	}
	
}