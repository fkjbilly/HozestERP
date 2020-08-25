using System;

namespace vipapis.vreturn{
	
	
	public enum ReturnType {
		
		
		///<summary>
		/// 一退
		///</summary>
		FIRST = 1, 
		
		///<summary>
		/// 二退
		///</summary>
		SECOND = 2, 
		
		///<summary>
		/// 三退
		///</summary>
		THIRD = 3, 
		
		///<summary>
		/// VMI二退
		///</summary>
		SECOND_VMI = 20, 
		
		///<summary>
		/// 部分二退
		///</summary>
		SECOND_PART = 21, 
		
		///<summary>
		/// 无po退供
		///</summary>
		WITHOUT_PO = 30, 
		
		///<summary>
		/// 残次品按po退供
		///</summary>
		DEFECTIVE_PO = 40, 
		
		///<summary>
		/// VIS二退
		///</summary>
		VIS_SECOND = 100, 
		
		///<summary>
		/// VIS普通退供
		///</summary>
		VIS_NORMAL = 101, 
		
		///<summary>
		/// VIS残次退供
		///</summary>
		VIS_DEFECTIVE = 102, 
		
		///<summary>
		/// VIS VIP_3PL退品骏普通退供
		///</summary>
		VIS_3PL_PJ_NORMAL = 103, 
		
		///<summary>
		/// VIS VIP_3PL退品骏残次退供
		///</summary>
		VIS_3PL_PJ_DEFECTIVE = 104, 
		
		///<summary>
		/// VIS VIP_3PL退供应商
		///</summary>
		VIS_3PL_VENDOR = 105, 
		
		///<summary>
		/// 门户正常退供
		///</summary>
		PORTAL_NOMAL = 110, 
		
		///<summary>
		/// 门户残次退供
		///</summary>
		PORTAL_DEFECTIVE = 111, 
		
		///<summary>
		/// 门户过期退供
		///</summary>
		PORTAL_EXPIRED = 112, 
		
		///<summary>
		/// 门户入库凭证退供
		///</summary>
		PORTAL_WAREHOUSE_RECEIPT = 113 
	}
	
	public class ReturnTypeUtil{
		
		private readonly int value;
		private ReturnTypeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static ReturnType? FindByValue(int value){
			
			switch(value){
				
				case 1: return ReturnType.FIRST; 
				case 2: return ReturnType.SECOND; 
				case 3: return ReturnType.THIRD; 
				case 20: return ReturnType.SECOND_VMI; 
				case 21: return ReturnType.SECOND_PART; 
				case 30: return ReturnType.WITHOUT_PO; 
				case 40: return ReturnType.DEFECTIVE_PO; 
				case 100: return ReturnType.VIS_SECOND; 
				case 101: return ReturnType.VIS_NORMAL; 
				case 102: return ReturnType.VIS_DEFECTIVE; 
				case 103: return ReturnType.VIS_3PL_PJ_NORMAL; 
				case 104: return ReturnType.VIS_3PL_PJ_DEFECTIVE; 
				case 105: return ReturnType.VIS_3PL_VENDOR; 
				case 110: return ReturnType.PORTAL_NOMAL; 
				case 111: return ReturnType.PORTAL_DEFECTIVE; 
				case 112: return ReturnType.PORTAL_EXPIRED; 
				case 113: return ReturnType.PORTAL_WAREHOUSE_RECEIPT; 
				
				default: return null; 
				
			}
			
		}
		
		public static ReturnType? FindByName(string name){
			
			if(ReturnType.FIRST.ToString().Equals(name)){
				
				return ReturnType.FIRST; 
			}
			
			if(ReturnType.SECOND.ToString().Equals(name)){
				
				return ReturnType.SECOND; 
			}
			
			if(ReturnType.THIRD.ToString().Equals(name)){
				
				return ReturnType.THIRD; 
			}
			
			if(ReturnType.SECOND_VMI.ToString().Equals(name)){
				
				return ReturnType.SECOND_VMI; 
			}
			
			if(ReturnType.SECOND_PART.ToString().Equals(name)){
				
				return ReturnType.SECOND_PART; 
			}
			
			if(ReturnType.WITHOUT_PO.ToString().Equals(name)){
				
				return ReturnType.WITHOUT_PO; 
			}
			
			if(ReturnType.DEFECTIVE_PO.ToString().Equals(name)){
				
				return ReturnType.DEFECTIVE_PO; 
			}
			
			if(ReturnType.VIS_SECOND.ToString().Equals(name)){
				
				return ReturnType.VIS_SECOND; 
			}
			
			if(ReturnType.VIS_NORMAL.ToString().Equals(name)){
				
				return ReturnType.VIS_NORMAL; 
			}
			
			if(ReturnType.VIS_DEFECTIVE.ToString().Equals(name)){
				
				return ReturnType.VIS_DEFECTIVE; 
			}
			
			if(ReturnType.VIS_3PL_PJ_NORMAL.ToString().Equals(name)){
				
				return ReturnType.VIS_3PL_PJ_NORMAL; 
			}
			
			if(ReturnType.VIS_3PL_PJ_DEFECTIVE.ToString().Equals(name)){
				
				return ReturnType.VIS_3PL_PJ_DEFECTIVE; 
			}
			
			if(ReturnType.VIS_3PL_VENDOR.ToString().Equals(name)){
				
				return ReturnType.VIS_3PL_VENDOR; 
			}
			
			if(ReturnType.PORTAL_NOMAL.ToString().Equals(name)){
				
				return ReturnType.PORTAL_NOMAL; 
			}
			
			if(ReturnType.PORTAL_DEFECTIVE.ToString().Equals(name)){
				
				return ReturnType.PORTAL_DEFECTIVE; 
			}
			
			if(ReturnType.PORTAL_EXPIRED.ToString().Equals(name)){
				
				return ReturnType.PORTAL_EXPIRED; 
			}
			
			if(ReturnType.PORTAL_WAREHOUSE_RECEIPT.ToString().Equals(name)){
				
				return ReturnType.PORTAL_WAREHOUSE_RECEIPT; 
			}
			
			
			return null;
			
		}
		
	}
	
}