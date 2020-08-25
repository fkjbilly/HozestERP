using System;

namespace com.vip.isv.category{
	
	
	public enum MappedCategoryState {
		
		
		///<summary>
		/// 未匹配
		///</summary>
		NON_MAPPING = 0, 
		
		///<summary>
		/// 预匹配
		///</summary>
		PRE_MAPPING = 1, 
		
		///<summary>
		/// 审核中
		///</summary>
		ON_AUDIT = 5, 
		
		///<summary>
		/// 审核通过
		///</summary>
		PASSED_AUDIT = 6, 
		
		///<summary>
		/// 审核不通过
		///</summary>
		REJECTED_AUDIT = 7, 
		
		///<summary>
		/// 已禁用
		///</summary>
		OUTAGE = 9 
	}
	
	public class MappedCategoryStateUtil{
		
		private readonly int value;
		private MappedCategoryStateUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static MappedCategoryState? FindByValue(int value){
			
			switch(value){
				
				case 0: return MappedCategoryState.NON_MAPPING; 
				case 1: return MappedCategoryState.PRE_MAPPING; 
				case 5: return MappedCategoryState.ON_AUDIT; 
				case 6: return MappedCategoryState.PASSED_AUDIT; 
				case 7: return MappedCategoryState.REJECTED_AUDIT; 
				case 9: return MappedCategoryState.OUTAGE; 
				
				default: return null; 
				
			}
			
		}
		
		public static MappedCategoryState? FindByName(string name){
			
			if(MappedCategoryState.NON_MAPPING.ToString().Equals(name)){
				
				return MappedCategoryState.NON_MAPPING; 
			}
			
			if(MappedCategoryState.PRE_MAPPING.ToString().Equals(name)){
				
				return MappedCategoryState.PRE_MAPPING; 
			}
			
			if(MappedCategoryState.ON_AUDIT.ToString().Equals(name)){
				
				return MappedCategoryState.ON_AUDIT; 
			}
			
			if(MappedCategoryState.PASSED_AUDIT.ToString().Equals(name)){
				
				return MappedCategoryState.PASSED_AUDIT; 
			}
			
			if(MappedCategoryState.REJECTED_AUDIT.ToString().Equals(name)){
				
				return MappedCategoryState.REJECTED_AUDIT; 
			}
			
			if(MappedCategoryState.OUTAGE.ToString().Equals(name)){
				
				return MappedCategoryState.OUTAGE; 
			}
			
			
			return null;
			
		}
		
	}
	
}