using System;

namespace com.vip.domain.inventory{
	
	
	public enum DistributionModel {
		
		
		///<summary>
		/// 大进大出
		///</summary>
		BIBO = 1, 
		
		///<summary>
		/// JIT
		///</summary>
		JIT = 2, 
		
		///<summary>
		/// 3PL
		///</summary>
		THREE_PL = 3 
	}
	
	public class DistributionModelUtil{
		
		private readonly int value;
		private DistributionModelUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static DistributionModel? FindByValue(int value){
			
			switch(value){
				
				case 1: return DistributionModel.BIBO; 
				case 2: return DistributionModel.JIT; 
				case 3: return DistributionModel.THREE_PL; 
				
				default: return null; 
				
			}
			
		}
		
		public static DistributionModel? FindByName(string name){
			
			if(DistributionModel.BIBO.ToString().Equals(name)){
				
				return DistributionModel.BIBO; 
			}
			
			if(DistributionModel.JIT.ToString().Equals(name)){
				
				return DistributionModel.JIT; 
			}
			
			if(DistributionModel.THREE_PL.ToString().Equals(name)){
				
				return DistributionModel.THREE_PL; 
			}
			
			
			return null;
			
		}
		
	}
	
}