using System;

namespace vipapis.account{
	
	
	public enum ProcStateEnum {
		
		
		///<summary>
		/// 已申请
		///</summary>
		PROC_STATE_APPLY = 0, 
		
		///<summary>
		/// 已拉取
		///</summary>
		PROC_STATE_MARK = 1, 
		
		///<summary>
		/// 已审核
		///</summary>
		PROC_STATE_AUDIT = 2, 
		
		///<summary>
		/// 已执行
		///</summary>
		PROC_STATE_HANDLE = 3 
	}
	
	public class ProcStateEnumUtil{
		
		private readonly int value;
		private ProcStateEnumUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static ProcStateEnum? FindByValue(int value){
			
			switch(value){
				
				case 0: return ProcStateEnum.PROC_STATE_APPLY; 
				case 1: return ProcStateEnum.PROC_STATE_MARK; 
				case 2: return ProcStateEnum.PROC_STATE_AUDIT; 
				case 3: return ProcStateEnum.PROC_STATE_HANDLE; 
				
				default: return null; 
				
			}
			
		}
		
		public static ProcStateEnum? FindByName(string name){
			
			if(ProcStateEnum.PROC_STATE_APPLY.ToString().Equals(name)){
				
				return ProcStateEnum.PROC_STATE_APPLY; 
			}
			
			if(ProcStateEnum.PROC_STATE_MARK.ToString().Equals(name)){
				
				return ProcStateEnum.PROC_STATE_MARK; 
			}
			
			if(ProcStateEnum.PROC_STATE_AUDIT.ToString().Equals(name)){
				
				return ProcStateEnum.PROC_STATE_AUDIT; 
			}
			
			if(ProcStateEnum.PROC_STATE_HANDLE.ToString().Equals(name)){
				
				return ProcStateEnum.PROC_STATE_HANDLE; 
			}
			
			
			return null;
			
		}
		
	}
	
}