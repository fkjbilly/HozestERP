using System;

namespace vipapis.order{
	
	
	public enum OrderDateType {
		
		
		///<summary>
		/// 时间区间为下单时间
		///</summary>
		ORDER_DATETIME = 1, 
		
		///<summary>
		/// 时间区间为拣货时间
		///</summary>
		PICKING_DATETIME = 2, 
		
		///<summary>
		/// 时间区间为打包时间
		///</summary>
		PACKAGED_DATETIME = 3, 
		
		///<summary>
		/// 时间区间为发货时间
		///</summary>
		SHIPPED_DATETIME = 4, 
		
		///<summary>
		/// 时间区间为签收时间
		///</summary>
		RECEIVED_DATETIME = 5, 
		
		///<summary>
		/// 时间区间为退货已审核时间
		///</summary>
		RETURN_GOODS_AUDITED_DATETIME = 6, 
		
		///<summary>
		/// 时间区间为退货已返仓时间
		///</summary>
		RETURN_GOODS_STORAGED_DATETIME = 7, 
		
		///<summary>
		/// 时间区间为已退款时间
		///</summary>
		REFUND_DATETIME = 8, 
		
		///<summary>
		/// 时间区间为已拒收时间
		///</summary>
		REJECTED_DATETIME = 9, 
		
		///<summary>
		/// 时间区间为已完成时间
		///</summary>
		COMPLETED_DATETIME = 10 
	}
	
	public class OrderDateTypeUtil{
		
		private readonly int value;
		private OrderDateTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static OrderDateType? FindByValue(int value){
			
			switch(value){
				
				case 1: return OrderDateType.ORDER_DATETIME; 
				case 2: return OrderDateType.PICKING_DATETIME; 
				case 3: return OrderDateType.PACKAGED_DATETIME; 
				case 4: return OrderDateType.SHIPPED_DATETIME; 
				case 5: return OrderDateType.RECEIVED_DATETIME; 
				case 6: return OrderDateType.RETURN_GOODS_AUDITED_DATETIME; 
				case 7: return OrderDateType.RETURN_GOODS_STORAGED_DATETIME; 
				case 8: return OrderDateType.REFUND_DATETIME; 
				case 9: return OrderDateType.REJECTED_DATETIME; 
				case 10: return OrderDateType.COMPLETED_DATETIME; 
				
				default: return null; 
				
			}
			
		}
		
		public static OrderDateType? FindByName(string name){
			
			if(OrderDateType.ORDER_DATETIME.ToString().Equals(name)){
				
				return OrderDateType.ORDER_DATETIME; 
			}
			
			if(OrderDateType.PICKING_DATETIME.ToString().Equals(name)){
				
				return OrderDateType.PICKING_DATETIME; 
			}
			
			if(OrderDateType.PACKAGED_DATETIME.ToString().Equals(name)){
				
				return OrderDateType.PACKAGED_DATETIME; 
			}
			
			if(OrderDateType.SHIPPED_DATETIME.ToString().Equals(name)){
				
				return OrderDateType.SHIPPED_DATETIME; 
			}
			
			if(OrderDateType.RECEIVED_DATETIME.ToString().Equals(name)){
				
				return OrderDateType.RECEIVED_DATETIME; 
			}
			
			if(OrderDateType.RETURN_GOODS_AUDITED_DATETIME.ToString().Equals(name)){
				
				return OrderDateType.RETURN_GOODS_AUDITED_DATETIME; 
			}
			
			if(OrderDateType.RETURN_GOODS_STORAGED_DATETIME.ToString().Equals(name)){
				
				return OrderDateType.RETURN_GOODS_STORAGED_DATETIME; 
			}
			
			if(OrderDateType.REFUND_DATETIME.ToString().Equals(name)){
				
				return OrderDateType.REFUND_DATETIME; 
			}
			
			if(OrderDateType.REJECTED_DATETIME.ToString().Equals(name)){
				
				return OrderDateType.REJECTED_DATETIME; 
			}
			
			if(OrderDateType.COMPLETED_DATETIME.ToString().Equals(name)){
				
				return OrderDateType.COMPLETED_DATETIME; 
			}
			
			
			return null;
			
		}
		
	}
	
}