using System;

namespace com.vip.domain.order{
	
	
	public enum OrderPayType {
		
		
		///<summary>
		/// 银行卡支付
		///</summary>
		PAY_TYPE_1 = 1, 
		
		///<summary>
		/// 信用卡支付
		///</summary>
		PAY_TYPE_2 = 2, 
		
		///<summary>
		/// 支付宝支付
		///</summary>
		PAY_TYPE_3 = 3, 
		
		///<summary>
		/// 邮政汇款
		///</summary>
		PAY_TYPE_4 = 4, 
		
		///<summary>
		/// 货到付款
		///</summary>
		PAY_TYPE_5 = 5, 
		
		///<summary>
		/// 财付通支付
		///</summary>
		PAY_TYPE_6 = 6, 
		
		///<summary>
		/// 移动手机支付
		///</summary>
		PAY_TYPE_7 = 7 
	}
	
	public class OrderPayTypeUtil{
		
		private readonly int value;
		private OrderPayTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static OrderPayType? FindByValue(int value){
			
			switch(value){
				
				case 1: return OrderPayType.PAY_TYPE_1; 
				case 2: return OrderPayType.PAY_TYPE_2; 
				case 3: return OrderPayType.PAY_TYPE_3; 
				case 4: return OrderPayType.PAY_TYPE_4; 
				case 5: return OrderPayType.PAY_TYPE_5; 
				case 6: return OrderPayType.PAY_TYPE_6; 
				case 7: return OrderPayType.PAY_TYPE_7; 
				
				default: return null; 
				
			}
			
		}
		
		public static OrderPayType? FindByName(string name){
			
			if(OrderPayType.PAY_TYPE_1.ToString().Equals(name)){
				
				return OrderPayType.PAY_TYPE_1; 
			}
			
			if(OrderPayType.PAY_TYPE_2.ToString().Equals(name)){
				
				return OrderPayType.PAY_TYPE_2; 
			}
			
			if(OrderPayType.PAY_TYPE_3.ToString().Equals(name)){
				
				return OrderPayType.PAY_TYPE_3; 
			}
			
			if(OrderPayType.PAY_TYPE_4.ToString().Equals(name)){
				
				return OrderPayType.PAY_TYPE_4; 
			}
			
			if(OrderPayType.PAY_TYPE_5.ToString().Equals(name)){
				
				return OrderPayType.PAY_TYPE_5; 
			}
			
			if(OrderPayType.PAY_TYPE_6.ToString().Equals(name)){
				
				return OrderPayType.PAY_TYPE_6; 
			}
			
			if(OrderPayType.PAY_TYPE_7.ToString().Equals(name)){
				
				return OrderPayType.PAY_TYPE_7; 
			}
			
			
			return null;
			
		}
		
	}
	
}