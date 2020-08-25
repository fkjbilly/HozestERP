using System;

namespace com.vip.order.biz.request.requirement{
	
	
	public enum GetOrderLogstOrderByField {
		
		
		
		id = 1, 
		
		
		order_id = 2, 
		
		
		user_name = 3, 
		
		
		operate_type = 4, 
		
		
		add_time = 5, 
		
		
		user_id = 6, 
		
		
		order_sn = 7 
	}
	
	public class GetOrderLogstOrderByFieldUtil{
		
		private readonly int value;
		private GetOrderLogstOrderByFieldUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static GetOrderLogstOrderByField? FindByValue(int value){
			
			switch(value){
				
				case 1: return GetOrderLogstOrderByField.id; 
				case 2: return GetOrderLogstOrderByField.order_id; 
				case 3: return GetOrderLogstOrderByField.user_name; 
				case 4: return GetOrderLogstOrderByField.operate_type; 
				case 5: return GetOrderLogstOrderByField.add_time; 
				case 6: return GetOrderLogstOrderByField.user_id; 
				case 7: return GetOrderLogstOrderByField.order_sn; 
				
				default: return null; 
				
			}
			
		}
		
		public static GetOrderLogstOrderByField? FindByName(string name){
			
			if(GetOrderLogstOrderByField.id.ToString().Equals(name)){
				
				return GetOrderLogstOrderByField.id; 
			}
			
			if(GetOrderLogstOrderByField.order_id.ToString().Equals(name)){
				
				return GetOrderLogstOrderByField.order_id; 
			}
			
			if(GetOrderLogstOrderByField.user_name.ToString().Equals(name)){
				
				return GetOrderLogstOrderByField.user_name; 
			}
			
			if(GetOrderLogstOrderByField.operate_type.ToString().Equals(name)){
				
				return GetOrderLogstOrderByField.operate_type; 
			}
			
			if(GetOrderLogstOrderByField.add_time.ToString().Equals(name)){
				
				return GetOrderLogstOrderByField.add_time; 
			}
			
			if(GetOrderLogstOrderByField.user_id.ToString().Equals(name)){
				
				return GetOrderLogstOrderByField.user_id; 
			}
			
			if(GetOrderLogstOrderByField.order_sn.ToString().Equals(name)){
				
				return GetOrderLogstOrderByField.order_sn; 
			}
			
			
			return null;
			
		}
		
	}
	
}