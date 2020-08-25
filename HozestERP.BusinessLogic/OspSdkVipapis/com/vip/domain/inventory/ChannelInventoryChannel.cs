using System;

namespace com.vip.domain.inventory{
	
	
	public enum ChannelInventoryChannel {
		
		
		///<summary>
		/// 待定
		///</summary>
		CHANNEL_PENDING = 0, 
		
		///<summary>
		/// 唯品会
		///</summary>
		CHANNEL_VIP = 1, 
		
		///<summary>
		/// 非唯品会
		///</summary>
		CHANNEL_NONE_VIP = 2, 
		
		///<summary>
		/// 非唯品会
		///</summary>
		CHANNEL_OTHER = 3 
	}
	
	public class ChannelInventoryChannelUtil{
		
		private readonly int value;
		private ChannelInventoryChannelUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static ChannelInventoryChannel? FindByValue(int value){
			
			switch(value){
				
				case 0: return ChannelInventoryChannel.CHANNEL_PENDING; 
				case 1: return ChannelInventoryChannel.CHANNEL_VIP; 
				case 2: return ChannelInventoryChannel.CHANNEL_NONE_VIP; 
				case 3: return ChannelInventoryChannel.CHANNEL_OTHER; 
				
				default: return null; 
				
			}
			
		}
		
		public static ChannelInventoryChannel? FindByName(string name){
			
			if(ChannelInventoryChannel.CHANNEL_PENDING.ToString().Equals(name)){
				
				return ChannelInventoryChannel.CHANNEL_PENDING; 
			}
			
			if(ChannelInventoryChannel.CHANNEL_VIP.ToString().Equals(name)){
				
				return ChannelInventoryChannel.CHANNEL_VIP; 
			}
			
			if(ChannelInventoryChannel.CHANNEL_NONE_VIP.ToString().Equals(name)){
				
				return ChannelInventoryChannel.CHANNEL_NONE_VIP; 
			}
			
			if(ChannelInventoryChannel.CHANNEL_OTHER.ToString().Equals(name)){
				
				return ChannelInventoryChannel.CHANNEL_OTHER; 
			}
			
			
			return null;
			
		}
		
	}
	
}