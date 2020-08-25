using System;

namespace vipapis.product{
	
	
	public enum StockShowType {
		
		
		///<summary>
		/// 全部显示
		///</summary>
		SHOW_ALL = 0, 
		
		///<summary>
		/// 只显示有库存的
		///</summary>
		SHOW_STOCK = 1 
	}
	
	public class StockShowTypeUtil{
		
		private readonly int value;
		private StockShowTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static StockShowType? FindByValue(int value){
			
			switch(value){
				
				case 0: return StockShowType.SHOW_ALL; 
				case 1: return StockShowType.SHOW_STOCK; 
				
				default: return null; 
				
			}
			
		}
		
		public static StockShowType? FindByName(string name){
			
			if(StockShowType.SHOW_ALL.ToString().Equals(name)){
				
				return StockShowType.SHOW_ALL; 
			}
			
			if(StockShowType.SHOW_STOCK.ToString().Equals(name)){
				
				return StockShowType.SHOW_STOCK; 
			}
			
			
			return null;
			
		}
		
	}
	
}