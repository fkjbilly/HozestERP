using System;

namespace com.vip.domain.order{
	
	
	public enum OrderTransportDay {
		
		
		///<summary>
		/// 送货时间不限
		///</summary>
		TRANSPORT_DAY_1 = 1, 
		
		///<summary>
		/// 只双休日/节假日送货(工作日不用送)
		///</summary>
		TRANSPORT_DAY_2 = 2, 
		
		///<summary>
		/// 只工作日(双休日/节假日不用送)
		///</summary>
		TRANSPORT_DAY_3 = 3, 
		
		///<summary>
		/// 只晚上送货(白天不用送)
		///</summary>
		TRANSPORT_DAY_4 = 4 
	}
	
	public class OrderTransportDayUtil{
		
		private readonly int value;
		private OrderTransportDayUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static OrderTransportDay? FindByValue(int value){
			
			switch(value){
				
				case 1: return OrderTransportDay.TRANSPORT_DAY_1; 
				case 2: return OrderTransportDay.TRANSPORT_DAY_2; 
				case 3: return OrderTransportDay.TRANSPORT_DAY_3; 
				case 4: return OrderTransportDay.TRANSPORT_DAY_4; 
				
				default: return null; 
				
			}
			
		}
		
		public static OrderTransportDay? FindByName(string name){
			
			if(OrderTransportDay.TRANSPORT_DAY_1.ToString().Equals(name)){
				
				return OrderTransportDay.TRANSPORT_DAY_1; 
			}
			
			if(OrderTransportDay.TRANSPORT_DAY_2.ToString().Equals(name)){
				
				return OrderTransportDay.TRANSPORT_DAY_2; 
			}
			
			if(OrderTransportDay.TRANSPORT_DAY_3.ToString().Equals(name)){
				
				return OrderTransportDay.TRANSPORT_DAY_3; 
			}
			
			if(OrderTransportDay.TRANSPORT_DAY_4.ToString().Equals(name)){
				
				return OrderTransportDay.TRANSPORT_DAY_4; 
			}
			
			
			return null;
			
		}
		
	}
	
}