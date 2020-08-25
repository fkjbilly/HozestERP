using System;

namespace vipapis.product{
	
	
	public enum ProductType {
		
		
		///<summary>
		/// 普通商品
		///</summary>
		NORMALGOOD = 0, 
		
		///<summary>
		/// 赠品
		///</summary>
		GIVINGGOOD = 1, 
		
		///<summary>
		/// 自由赠
		///</summary>
		FREEGIFT = 2, 
		
		///<summary>
		/// 换购商品
		///</summary>
		EXCHANGEGOOD = 3, 
		
		///<summary>
		/// 捆绑销售商品
		///</summary>
		BUNDINGGOOD = 4, 
		
		///<summary>
		/// 礼品
		///</summary>
		GIFT = 5 
	}
	
	public class ProductTypeUtil{
		
		private readonly int value;
		private ProductTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static ProductType? FindByValue(int value){
			
			switch(value){
				
				case 0: return ProductType.NORMALGOOD; 
				case 1: return ProductType.GIVINGGOOD; 
				case 2: return ProductType.FREEGIFT; 
				case 3: return ProductType.EXCHANGEGOOD; 
				case 4: return ProductType.BUNDINGGOOD; 
				case 5: return ProductType.GIFT; 
				
				default: return null; 
				
			}
			
		}
		
		public static ProductType? FindByName(string name){
			
			if(ProductType.NORMALGOOD.ToString().Equals(name)){
				
				return ProductType.NORMALGOOD; 
			}
			
			if(ProductType.GIVINGGOOD.ToString().Equals(name)){
				
				return ProductType.GIVINGGOOD; 
			}
			
			if(ProductType.FREEGIFT.ToString().Equals(name)){
				
				return ProductType.FREEGIFT; 
			}
			
			if(ProductType.EXCHANGEGOOD.ToString().Equals(name)){
				
				return ProductType.EXCHANGEGOOD; 
			}
			
			if(ProductType.BUNDINGGOOD.ToString().Equals(name)){
				
				return ProductType.BUNDINGGOOD; 
			}
			
			if(ProductType.GIFT.ToString().Equals(name)){
				
				return ProductType.GIFT; 
			}
			
			
			return null;
			
		}
		
	}
	
}