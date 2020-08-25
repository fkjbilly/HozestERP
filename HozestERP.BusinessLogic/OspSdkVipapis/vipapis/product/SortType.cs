using System;

namespace vipapis.product{
	
	
	public enum SortType {
		
		
		///<summary>
		/// 默认
		///</summary>
		SORT_DEFAULT = 0, 
		
		///<summary>
		/// 折扣降序
		///</summary>
		DISCOUNT_DOWN = 1, 
		
		///<summary>
		/// 折扣升序
		///</summary>
		DISCOUNT_UP = 2, 
		
		///<summary>
		/// 价格升序
		///</summary>
		PRICE_UP = 3, 
		
		///<summary>
		/// 价格降序
		///</summary>
		PRICE_DOWN = 4, 
		
		///<summary>
		/// 销量降序
		///</summary>
		SALECOUNT_DOWN = 5, 
		
		///<summary>
		/// 销量升序
		///</summary>
		SALECOUNT_UP = 6 
	}
	
	public class SortTypeUtil{
		
		private readonly int value;
		private SortTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static SortType? FindByValue(int value){
			
			switch(value){
				
				case 0: return SortType.SORT_DEFAULT; 
				case 1: return SortType.DISCOUNT_DOWN; 
				case 2: return SortType.DISCOUNT_UP; 
				case 3: return SortType.PRICE_UP; 
				case 4: return SortType.PRICE_DOWN; 
				case 5: return SortType.SALECOUNT_DOWN; 
				case 6: return SortType.SALECOUNT_UP; 
				
				default: return null; 
				
			}
			
		}
		
		public static SortType? FindByName(string name){
			
			if(SortType.SORT_DEFAULT.ToString().Equals(name)){
				
				return SortType.SORT_DEFAULT; 
			}
			
			if(SortType.DISCOUNT_DOWN.ToString().Equals(name)){
				
				return SortType.DISCOUNT_DOWN; 
			}
			
			if(SortType.DISCOUNT_UP.ToString().Equals(name)){
				
				return SortType.DISCOUNT_UP; 
			}
			
			if(SortType.PRICE_UP.ToString().Equals(name)){
				
				return SortType.PRICE_UP; 
			}
			
			if(SortType.PRICE_DOWN.ToString().Equals(name)){
				
				return SortType.PRICE_DOWN; 
			}
			
			if(SortType.SALECOUNT_DOWN.ToString().Equals(name)){
				
				return SortType.SALECOUNT_DOWN; 
			}
			
			if(SortType.SALECOUNT_UP.ToString().Equals(name)){
				
				return SortType.SALECOUNT_UP; 
			}
			
			
			return null;
			
		}
		
	}
	
}