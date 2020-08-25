using System;

namespace com.vip.domain.inventory{
	
	
	public enum PurchaseSalesInventoryQueryType {
		
		
		///<summary>
		/// 商品+入库凭证
		///</summary>
		ITEM_AND_PO = 1, 
		
		///<summary>
		/// 商品
		///</summary>
		ITEM = 2, 
		
		///<summary>
		/// 入库凭证
		///</summary>
		PO = 3, 
		
		///<summary>
		/// 供应商
		///</summary>
		VENDOR = 4 
	}
	
	public class PurchaseSalesInventoryQueryTypeUtil{
		
		private readonly int value;
		private PurchaseSalesInventoryQueryTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static PurchaseSalesInventoryQueryType? FindByValue(int value){
			
			switch(value){
				
				case 1: return PurchaseSalesInventoryQueryType.ITEM_AND_PO; 
				case 2: return PurchaseSalesInventoryQueryType.ITEM; 
				case 3: return PurchaseSalesInventoryQueryType.PO; 
				case 4: return PurchaseSalesInventoryQueryType.VENDOR; 
				
				default: return null; 
				
			}
			
		}
		
		public static PurchaseSalesInventoryQueryType? FindByName(string name){
			
			if(PurchaseSalesInventoryQueryType.ITEM_AND_PO.ToString().Equals(name)){
				
				return PurchaseSalesInventoryQueryType.ITEM_AND_PO; 
			}
			
			if(PurchaseSalesInventoryQueryType.ITEM.ToString().Equals(name)){
				
				return PurchaseSalesInventoryQueryType.ITEM; 
			}
			
			if(PurchaseSalesInventoryQueryType.PO.ToString().Equals(name)){
				
				return PurchaseSalesInventoryQueryType.PO; 
			}
			
			if(PurchaseSalesInventoryQueryType.VENDOR.ToString().Equals(name)){
				
				return PurchaseSalesInventoryQueryType.VENDOR; 
			}
			
			
			return null;
			
		}
		
	}
	
}