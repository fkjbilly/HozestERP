using System;

namespace vipapis.common{
	
	
	public enum OrderStatus {
		
		
		///<summary>
		/// 未支付订单[已弃用]
		///</summary>
		STATUS_0 = 0, 
		
		///<summary>
		/// 待审核订单（已支付/未处理）[已弃用]
		///</summary>
		STATUS_1 = 1, 
		
		///<summary>
		/// 订单已审核
		///</summary>
		STATUS_10 = 10, 
		
		///<summary>
		/// 未处理[已弃用]
		///</summary>
		STATUS_11 = 11, 
		
		///<summary>
		/// 商品调拨中[已弃用]
		///</summary>
		STATUS_12 = 12, 
		
		///<summary>
		/// 缺货[已弃用]
		///</summary>
		STATUS_13 = 13, 
		
		///<summary>
		/// 订单发货失败[已弃用]
		///</summary>
		STATUS_14 = 14, 
		
		///<summary>
		/// 拣货中[已弃用]
		///</summary>
		STATUS_20 = 20, 
		
		///<summary>
		/// 已打包[已弃用]
		///</summary>
		STATUS_21 = 21, 
		
		///<summary>
		/// 已发货
		///</summary>
		STATUS_22 = 22, 
		
		///<summary>
		/// 售后处理[已弃用]
		///</summary>
		STATUS_23 = 23, 
		
		///<summary>
		/// 未处理[已弃用]
		///</summary>
		STATUS_24 = 24, 
		
		///<summary>
		/// 已签收
		///</summary>
		STATUS_25 = 25, 
		
		///<summary>
		/// 订单重发[已弃用]
		///</summary>
		STATUS_28 = 28, 
		
		///<summary>
		/// 未处理[已弃用]
		///</summary>
		STATUS_30 = 30, 
		
		///<summary>
		/// 未处理[已弃用]
		///</summary>
		STATUS_31 = 31, 
		
		///<summary>
		/// 货品回寄中[已弃用]
		///</summary>
		STATUS_40 = 40, 
		
		///<summary>
		/// 退换货服务不受理[已弃用]
		///</summary>
		STATUS_41 = 41, 
		
		///<summary>
		/// 无效换货[已弃用]
		///</summary>
		STATUS_42 = 42, 
		
		///<summary>
		/// 已发货[已弃用]
		///</summary>
		STATUS_44 = 44, 
		
		///<summary>
		/// 退款处理中
		///</summary>
		STATUS_45 = 45, 
		
		///<summary>
		/// 退换货未处理[已弃用]
		///</summary>
		STATUS_46 = 46, 
		
		///<summary>
		/// 修改退款资料[已弃用]
		///</summary>
		STATUS_47 = 47, 
		
		///<summary>
		/// 无效退货[已弃用]
		///</summary>
		STATUS_48 = 48, 
		
		///<summary>
		/// 已退款
		///</summary>
		STATUS_49 = 49, 
		
		///<summary>
		/// 退货异常处理中[已弃用]
		///</summary>
		STATUS_51 = 51, 
		
		///<summary>
		/// 退款异常处理中[已弃用]
		///</summary>
		STATUS_52 = 52, 
		
		///<summary>
		/// 退货未审核
		///</summary>
		STATUS_53 = 53, 
		
		///<summary>
		/// 退货已审核
		///</summary>
		STATUS_54 = 54, 
		
		///<summary>
		/// 拒收回访
		///</summary>
		STATUS_55 = 55, 
		
		///<summary>
		/// 售后异常[已弃用]
		///</summary>
		STATUS_56 = 56, 
		
		///<summary>
		/// 上门取件[已弃用]
		///</summary>
		STATUS_57 = 57, 
		
		///<summary>
		/// 退货已返仓
		///</summary>
		STATUS_58 = 58, 
		
		///<summary>
		/// 已退货[已弃用]
		///</summary>
		STATUS_59 = 59, 
		
		///<summary>
		/// 已完成
		///</summary>
		STATUS_60 = 60, 
		
		///<summary>
		/// 已换货[已弃用]
		///</summary>
		STATUS_61 = 61, 
		
		///<summary>
		/// 用户已拒收
		///</summary>
		STATUS_70 = 70, 
		
		///<summary>
		/// 超区返仓中[已弃用]
		///</summary>
		STATUS_71 = 71, 
		
		///<summary>
		/// 拒收返仓中[已弃用]
		///</summary>
		STATUS_72 = 72, 
		
		///<summary>
		/// 订单已修改[已弃用]
		///</summary>
		STATUS_96 = 96, 
		
		///<summary>
		/// 订单已取消
		///</summary>
		STATUS_97 = 97, 
		
		///<summary>
		/// 已合并[已弃用]
		///</summary>
		STATUS_98 = 98, 
		
		///<summary>
		/// 已删除[已弃用]
		///</summary>
		STATUS_99 = 99, 
		
		///<summary>
		/// 退货失败[已弃用]
		///</summary>
		STATUS_100 = 100, 
		
		///<summary>
		/// 退货审核中
		///</summary>
		STATUS_117 = 117, 
		
		///<summary>
		/// 订单申请断货
		///</summary>
		STATUS_118 = 118, 
		
		///<summary>
		/// 断货申请通过
		///</summary>
		STATUS_119 = 119, 
		
		///<summary>
		/// 拒收异常
		///</summary>
		STATUS_300 = 300 
	}
	
	public class OrderStatusUtil{
		
		private readonly int value;
		private OrderStatusUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static OrderStatus? FindByValue(int value){
			
			switch(value){
				
				case 0: return OrderStatus.STATUS_0; 
				case 1: return OrderStatus.STATUS_1; 
				case 10: return OrderStatus.STATUS_10; 
				case 11: return OrderStatus.STATUS_11; 
				case 12: return OrderStatus.STATUS_12; 
				case 13: return OrderStatus.STATUS_13; 
				case 14: return OrderStatus.STATUS_14; 
				case 20: return OrderStatus.STATUS_20; 
				case 21: return OrderStatus.STATUS_21; 
				case 22: return OrderStatus.STATUS_22; 
				case 23: return OrderStatus.STATUS_23; 
				case 24: return OrderStatus.STATUS_24; 
				case 25: return OrderStatus.STATUS_25; 
				case 28: return OrderStatus.STATUS_28; 
				case 30: return OrderStatus.STATUS_30; 
				case 31: return OrderStatus.STATUS_31; 
				case 40: return OrderStatus.STATUS_40; 
				case 41: return OrderStatus.STATUS_41; 
				case 42: return OrderStatus.STATUS_42; 
				case 44: return OrderStatus.STATUS_44; 
				case 45: return OrderStatus.STATUS_45; 
				case 46: return OrderStatus.STATUS_46; 
				case 47: return OrderStatus.STATUS_47; 
				case 48: return OrderStatus.STATUS_48; 
				case 49: return OrderStatus.STATUS_49; 
				case 51: return OrderStatus.STATUS_51; 
				case 52: return OrderStatus.STATUS_52; 
				case 53: return OrderStatus.STATUS_53; 
				case 54: return OrderStatus.STATUS_54; 
				case 55: return OrderStatus.STATUS_55; 
				case 56: return OrderStatus.STATUS_56; 
				case 57: return OrderStatus.STATUS_57; 
				case 58: return OrderStatus.STATUS_58; 
				case 59: return OrderStatus.STATUS_59; 
				case 60: return OrderStatus.STATUS_60; 
				case 61: return OrderStatus.STATUS_61; 
				case 70: return OrderStatus.STATUS_70; 
				case 71: return OrderStatus.STATUS_71; 
				case 72: return OrderStatus.STATUS_72; 
				case 96: return OrderStatus.STATUS_96; 
				case 97: return OrderStatus.STATUS_97; 
				case 98: return OrderStatus.STATUS_98; 
				case 99: return OrderStatus.STATUS_99; 
				case 100: return OrderStatus.STATUS_100; 
				case 117: return OrderStatus.STATUS_117; 
				case 118: return OrderStatus.STATUS_118; 
				case 119: return OrderStatus.STATUS_119; 
				case 300: return OrderStatus.STATUS_300; 
				
				default: return null; 
				
			}
			
		}
		
		public static OrderStatus? FindByName(string name){
			
			if(OrderStatus.STATUS_0.ToString().Equals(name)){
				
				return OrderStatus.STATUS_0; 
			}
			
			if(OrderStatus.STATUS_1.ToString().Equals(name)){
				
				return OrderStatus.STATUS_1; 
			}
			
			if(OrderStatus.STATUS_10.ToString().Equals(name)){
				
				return OrderStatus.STATUS_10; 
			}
			
			if(OrderStatus.STATUS_11.ToString().Equals(name)){
				
				return OrderStatus.STATUS_11; 
			}
			
			if(OrderStatus.STATUS_12.ToString().Equals(name)){
				
				return OrderStatus.STATUS_12; 
			}
			
			if(OrderStatus.STATUS_13.ToString().Equals(name)){
				
				return OrderStatus.STATUS_13; 
			}
			
			if(OrderStatus.STATUS_14.ToString().Equals(name)){
				
				return OrderStatus.STATUS_14; 
			}
			
			if(OrderStatus.STATUS_20.ToString().Equals(name)){
				
				return OrderStatus.STATUS_20; 
			}
			
			if(OrderStatus.STATUS_21.ToString().Equals(name)){
				
				return OrderStatus.STATUS_21; 
			}
			
			if(OrderStatus.STATUS_22.ToString().Equals(name)){
				
				return OrderStatus.STATUS_22; 
			}
			
			if(OrderStatus.STATUS_23.ToString().Equals(name)){
				
				return OrderStatus.STATUS_23; 
			}
			
			if(OrderStatus.STATUS_24.ToString().Equals(name)){
				
				return OrderStatus.STATUS_24; 
			}
			
			if(OrderStatus.STATUS_25.ToString().Equals(name)){
				
				return OrderStatus.STATUS_25; 
			}
			
			if(OrderStatus.STATUS_28.ToString().Equals(name)){
				
				return OrderStatus.STATUS_28; 
			}
			
			if(OrderStatus.STATUS_30.ToString().Equals(name)){
				
				return OrderStatus.STATUS_30; 
			}
			
			if(OrderStatus.STATUS_31.ToString().Equals(name)){
				
				return OrderStatus.STATUS_31; 
			}
			
			if(OrderStatus.STATUS_40.ToString().Equals(name)){
				
				return OrderStatus.STATUS_40; 
			}
			
			if(OrderStatus.STATUS_41.ToString().Equals(name)){
				
				return OrderStatus.STATUS_41; 
			}
			
			if(OrderStatus.STATUS_42.ToString().Equals(name)){
				
				return OrderStatus.STATUS_42; 
			}
			
			if(OrderStatus.STATUS_44.ToString().Equals(name)){
				
				return OrderStatus.STATUS_44; 
			}
			
			if(OrderStatus.STATUS_45.ToString().Equals(name)){
				
				return OrderStatus.STATUS_45; 
			}
			
			if(OrderStatus.STATUS_46.ToString().Equals(name)){
				
				return OrderStatus.STATUS_46; 
			}
			
			if(OrderStatus.STATUS_47.ToString().Equals(name)){
				
				return OrderStatus.STATUS_47; 
			}
			
			if(OrderStatus.STATUS_48.ToString().Equals(name)){
				
				return OrderStatus.STATUS_48; 
			}
			
			if(OrderStatus.STATUS_49.ToString().Equals(name)){
				
				return OrderStatus.STATUS_49; 
			}
			
			if(OrderStatus.STATUS_51.ToString().Equals(name)){
				
				return OrderStatus.STATUS_51; 
			}
			
			if(OrderStatus.STATUS_52.ToString().Equals(name)){
				
				return OrderStatus.STATUS_52; 
			}
			
			if(OrderStatus.STATUS_53.ToString().Equals(name)){
				
				return OrderStatus.STATUS_53; 
			}
			
			if(OrderStatus.STATUS_54.ToString().Equals(name)){
				
				return OrderStatus.STATUS_54; 
			}
			
			if(OrderStatus.STATUS_55.ToString().Equals(name)){
				
				return OrderStatus.STATUS_55; 
			}
			
			if(OrderStatus.STATUS_56.ToString().Equals(name)){
				
				return OrderStatus.STATUS_56; 
			}
			
			if(OrderStatus.STATUS_57.ToString().Equals(name)){
				
				return OrderStatus.STATUS_57; 
			}
			
			if(OrderStatus.STATUS_58.ToString().Equals(name)){
				
				return OrderStatus.STATUS_58; 
			}
			
			if(OrderStatus.STATUS_59.ToString().Equals(name)){
				
				return OrderStatus.STATUS_59; 
			}
			
			if(OrderStatus.STATUS_60.ToString().Equals(name)){
				
				return OrderStatus.STATUS_60; 
			}
			
			if(OrderStatus.STATUS_61.ToString().Equals(name)){
				
				return OrderStatus.STATUS_61; 
			}
			
			if(OrderStatus.STATUS_70.ToString().Equals(name)){
				
				return OrderStatus.STATUS_70; 
			}
			
			if(OrderStatus.STATUS_71.ToString().Equals(name)){
				
				return OrderStatus.STATUS_71; 
			}
			
			if(OrderStatus.STATUS_72.ToString().Equals(name)){
				
				return OrderStatus.STATUS_72; 
			}
			
			if(OrderStatus.STATUS_96.ToString().Equals(name)){
				
				return OrderStatus.STATUS_96; 
			}
			
			if(OrderStatus.STATUS_97.ToString().Equals(name)){
				
				return OrderStatus.STATUS_97; 
			}
			
			if(OrderStatus.STATUS_98.ToString().Equals(name)){
				
				return OrderStatus.STATUS_98; 
			}
			
			if(OrderStatus.STATUS_99.ToString().Equals(name)){
				
				return OrderStatus.STATUS_99; 
			}
			
			if(OrderStatus.STATUS_100.ToString().Equals(name)){
				
				return OrderStatus.STATUS_100; 
			}
			
			if(OrderStatus.STATUS_117.ToString().Equals(name)){
				
				return OrderStatus.STATUS_117; 
			}
			
			if(OrderStatus.STATUS_118.ToString().Equals(name)){
				
				return OrderStatus.STATUS_118; 
			}
			
			if(OrderStatus.STATUS_119.ToString().Equals(name)){
				
				return OrderStatus.STATUS_119; 
			}
			
			if(OrderStatus.STATUS_300.ToString().Equals(name)){
				
				return OrderStatus.STATUS_300; 
			}
			
			
			return null;
			
		}
		
	}
	
}