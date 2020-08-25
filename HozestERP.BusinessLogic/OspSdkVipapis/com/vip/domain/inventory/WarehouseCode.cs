using System;

namespace com.vip.domain.inventory{
	
	
	public enum WarehouseCode {
		
		
		///<summary>
		/// 华北仓
		///</summary>
		VIP_BJ = 1, 
		
		///<summary>
		/// 西南仓
		///</summary>
		VIP_CD = 2, 
		
		///<summary>
		/// 华中仓
		///</summary>
		VIP_HZ = 3, 
		
		///<summary>
		/// 华南仓
		///</summary>
		VIP_NH = 4, 
		
		///<summary>
		/// 华东仓
		///</summary>
		VIP_SH = 5 
	}
	
	public class WarehouseCodeUtil{
		
		private readonly int value;
		private WarehouseCodeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static WarehouseCode? FindByValue(int value){
			
			switch(value){
				
				case 1: return WarehouseCode.VIP_BJ; 
				case 2: return WarehouseCode.VIP_CD; 
				case 3: return WarehouseCode.VIP_HZ; 
				case 4: return WarehouseCode.VIP_NH; 
				case 5: return WarehouseCode.VIP_SH; 
				
				default: return null; 
				
			}
			
		}
		
		public static WarehouseCode? FindByName(string name){
			
			if(WarehouseCode.VIP_BJ.ToString().Equals(name)){
				
				return WarehouseCode.VIP_BJ; 
			}
			
			if(WarehouseCode.VIP_CD.ToString().Equals(name)){
				
				return WarehouseCode.VIP_CD; 
			}
			
			if(WarehouseCode.VIP_HZ.ToString().Equals(name)){
				
				return WarehouseCode.VIP_HZ; 
			}
			
			if(WarehouseCode.VIP_NH.ToString().Equals(name)){
				
				return WarehouseCode.VIP_NH; 
			}
			
			if(WarehouseCode.VIP_SH.ToString().Equals(name)){
				
				return WarehouseCode.VIP_SH; 
			}
			
			
			return null;
			
		}
		
	}
	
}