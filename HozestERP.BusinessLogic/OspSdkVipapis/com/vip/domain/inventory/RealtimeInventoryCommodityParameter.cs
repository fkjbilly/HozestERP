using System;

namespace com.vip.domain.inventory{
	
	
	public enum RealtimeInventoryCommodityParameter {
		
		
		///<summary>
		/// 正常
		///</summary>
		NORMAL = 10, 
		
		///<summary>
		/// 一级残次
		///</summary>
		ONE_DEFECTIVE = 21, 
		
		///<summary>
		/// 二级残次
		///</summary>
		TWO_DEFECTIVE = 22, 
		
		///<summary>
		/// 三级残次
		///</summary>
		THREE_DEFECTIVE = 23 
	}
	
	public class RealtimeInventoryCommodityParameterUtil{
		
		private readonly int value;
		private RealtimeInventoryCommodityParameterUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static RealtimeInventoryCommodityParameter? FindByValue(int value){
			
			switch(value){
				
				case 10: return RealtimeInventoryCommodityParameter.NORMAL; 
				case 21: return RealtimeInventoryCommodityParameter.ONE_DEFECTIVE; 
				case 22: return RealtimeInventoryCommodityParameter.TWO_DEFECTIVE; 
				case 23: return RealtimeInventoryCommodityParameter.THREE_DEFECTIVE; 
				
				default: return null; 
				
			}
			
		}
		
		public static RealtimeInventoryCommodityParameter? FindByName(string name){
			
			if(RealtimeInventoryCommodityParameter.NORMAL.ToString().Equals(name)){
				
				return RealtimeInventoryCommodityParameter.NORMAL; 
			}
			
			if(RealtimeInventoryCommodityParameter.ONE_DEFECTIVE.ToString().Equals(name)){
				
				return RealtimeInventoryCommodityParameter.ONE_DEFECTIVE; 
			}
			
			if(RealtimeInventoryCommodityParameter.TWO_DEFECTIVE.ToString().Equals(name)){
				
				return RealtimeInventoryCommodityParameter.TWO_DEFECTIVE; 
			}
			
			if(RealtimeInventoryCommodityParameter.THREE_DEFECTIVE.ToString().Equals(name)){
				
				return RealtimeInventoryCommodityParameter.THREE_DEFECTIVE; 
			}
			
			
			return null;
			
		}
		
	}
	
}