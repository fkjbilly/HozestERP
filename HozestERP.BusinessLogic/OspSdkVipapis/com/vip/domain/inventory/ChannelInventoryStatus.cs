using System;

namespace com.vip.domain.inventory{
	
	
	public enum ChannelInventoryStatus {
		
		
		///<summary>
		/// 可售
		///</summary>
		STATUS_SALE = 0, 
		
		///<summary>
		/// 不可售
		///</summary>
		STATUS_CAN_NOT_SELL = 1 
	}
	
	public class ChannelInventoryStatusUtil{
		
		private readonly int value;
		private ChannelInventoryStatusUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static ChannelInventoryStatus? FindByValue(int value){
			
			switch(value){
				
				case 0: return ChannelInventoryStatus.STATUS_SALE; 
				case 1: return ChannelInventoryStatus.STATUS_CAN_NOT_SELL; 
				
				default: return null; 
				
			}
			
		}
		
		public static ChannelInventoryStatus? FindByName(string name){
			
			if(ChannelInventoryStatus.STATUS_SALE.ToString().Equals(name)){
				
				return ChannelInventoryStatus.STATUS_SALE; 
			}
			
			if(ChannelInventoryStatus.STATUS_CAN_NOT_SELL.ToString().Equals(name)){
				
				return ChannelInventoryStatus.STATUS_CAN_NOT_SELL; 
			}
			
			
			return null;
			
		}
		
	}
	
}