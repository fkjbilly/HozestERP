using System;

namespace com.vip.domain.inventory{
	
	
	public enum ChannelInventoryInVipSalesPlan {
		
		
		///<summary>
		/// 占用
		///</summary>
		OCCUPY = 1, 
		
		///<summary>
		/// 不占用
		///</summary>
		DO_NOT_OCCUPY = 2 
	}
	
	public class ChannelInventoryInVipSalesPlanUtil{
		
		private readonly int value;
		private ChannelInventoryInVipSalesPlanUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static ChannelInventoryInVipSalesPlan? FindByValue(int value){
			
			switch(value){
				
				case 1: return ChannelInventoryInVipSalesPlan.OCCUPY; 
				case 2: return ChannelInventoryInVipSalesPlan.DO_NOT_OCCUPY; 
				
				default: return null; 
				
			}
			
		}
		
		public static ChannelInventoryInVipSalesPlan? FindByName(string name){
			
			if(ChannelInventoryInVipSalesPlan.OCCUPY.ToString().Equals(name)){
				
				return ChannelInventoryInVipSalesPlan.OCCUPY; 
			}
			
			if(ChannelInventoryInVipSalesPlan.DO_NOT_OCCUPY.ToString().Equals(name)){
				
				return ChannelInventoryInVipSalesPlan.DO_NOT_OCCUPY; 
			}
			
			
			return null;
			
		}
		
	}
	
}