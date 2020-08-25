using System;

namespace vipapis.common{
	
	
	public enum Warehouse {
		
		
		///<summary>
		/// 华南：南海仓
		///</summary>
		VIP_NH = 1, 
		
		///<summary>
		/// 华东：上海仓
		///</summary>
		VIP_SH = 2, 
		
		///<summary>
		/// 西北：成都仓
		///</summary>
		VIP_CD = 3, 
		
		///<summary>
		/// 北京仓
		///</summary>
		VIP_BJ = 4, 
		
		///<summary>
		/// 华中：鄂州仓
		///</summary>
		VIP_HZ = 5 
	}
	
	public class WarehouseUtil{
		
		private readonly int value;
		private WarehouseUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static Warehouse? FindByValue(int value){
			
			switch(value){
				
				case 1: return Warehouse.VIP_NH; 
				case 2: return Warehouse.VIP_SH; 
				case 3: return Warehouse.VIP_CD; 
				case 4: return Warehouse.VIP_BJ; 
				case 5: return Warehouse.VIP_HZ; 
				
				default: return null; 
				
			}
			
		}
		
		public static Warehouse? FindByName(string name){
			
			if(Warehouse.VIP_NH.ToString().Equals(name)){
				
				return Warehouse.VIP_NH; 
			}
			
			if(Warehouse.VIP_SH.ToString().Equals(name)){
				
				return Warehouse.VIP_SH; 
			}
			
			if(Warehouse.VIP_CD.ToString().Equals(name)){
				
				return Warehouse.VIP_CD; 
			}
			
			if(Warehouse.VIP_BJ.ToString().Equals(name)){
				
				return Warehouse.VIP_BJ; 
			}
			
			if(Warehouse.VIP_HZ.ToString().Equals(name)){
				
				return Warehouse.VIP_HZ; 
			}
			
			
			return null;
			
		}
		
	}
	
}