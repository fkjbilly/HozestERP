using System;

namespace vipapis.vreturn{
	
	
	public enum Grade {
		
		
		///<summary>
		/// 正常
		///</summary>
		NORMAL_100 = 100, 
		
		///<summary>
		/// 正常，已过可上线日期
		///</summary>
		NORMAL_101 = 101, 
		
		///<summary>
		/// 正常，已过保险期
		///</summary>
		NORMAL_102 = 102, 
		
		///<summary>
		/// 正常，已过失效期
		///</summary>
		NORMAL_103 = 103, 
		
		///<summary>
		/// 一级残次
		///</summary>
		DEFECTIVE_210 = 210, 
		
		///<summary>
		/// 一级残次，已过可上线日期
		///</summary>
		DEFECTIVE_211 = 211, 
		
		///<summary>
		/// 一级残次，已过保险期
		///</summary>
		DEFECTIVE_212 = 212, 
		
		///<summary>
		/// 一级残次，已过失效期
		///</summary>
		DEFECTIVE_213 = 213, 
		
		///<summary>
		/// 二级残次
		///</summary>
		DEFECTIVE_220 = 220, 
		
		///<summary>
		/// 二级残次，已过可上线日期
		///</summary>
		DEFECTIVE_221 = 221, 
		
		///<summary>
		/// 二级残次，已过保险期
		///</summary>
		DEFECTIVE_222 = 222, 
		
		///<summary>
		/// 二级残次，已过失效期
		///</summary>
		DEFECTIVE_223 = 223, 
		
		///<summary>
		/// 三级残次
		///</summary>
		DEFECTIVE_230 = 230, 
		
		///<summary>
		/// 三级残次，已过可上线日期
		///</summary>
		DEFECTIVE_231 = 231, 
		
		///<summary>
		/// 三级残次，已过保险期
		///</summary>
		DEFECTIVE_232 = 232, 
		
		///<summary>
		/// 三级残次，已过失效期
		///</summary>
		DEFECTIVE_233 = 233 
	}
	
	public class GradeUtil{
		
		private readonly int value;
		private GradeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static Grade? FindByValue(int value){
			
			switch(value){
				
				case 100: return Grade.NORMAL_100; 
				case 101: return Grade.NORMAL_101; 
				case 102: return Grade.NORMAL_102; 
				case 103: return Grade.NORMAL_103; 
				case 210: return Grade.DEFECTIVE_210; 
				case 211: return Grade.DEFECTIVE_211; 
				case 212: return Grade.DEFECTIVE_212; 
				case 213: return Grade.DEFECTIVE_213; 
				case 220: return Grade.DEFECTIVE_220; 
				case 221: return Grade.DEFECTIVE_221; 
				case 222: return Grade.DEFECTIVE_222; 
				case 223: return Grade.DEFECTIVE_223; 
				case 230: return Grade.DEFECTIVE_230; 
				case 231: return Grade.DEFECTIVE_231; 
				case 232: return Grade.DEFECTIVE_232; 
				case 233: return Grade.DEFECTIVE_233; 
				
				default: return null; 
				
			}
			
		}
		
		public static Grade? FindByName(string name){
			
			if(Grade.NORMAL_100.ToString().Equals(name)){
				
				return Grade.NORMAL_100; 
			}
			
			if(Grade.NORMAL_101.ToString().Equals(name)){
				
				return Grade.NORMAL_101; 
			}
			
			if(Grade.NORMAL_102.ToString().Equals(name)){
				
				return Grade.NORMAL_102; 
			}
			
			if(Grade.NORMAL_103.ToString().Equals(name)){
				
				return Grade.NORMAL_103; 
			}
			
			if(Grade.DEFECTIVE_210.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_210; 
			}
			
			if(Grade.DEFECTIVE_211.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_211; 
			}
			
			if(Grade.DEFECTIVE_212.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_212; 
			}
			
			if(Grade.DEFECTIVE_213.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_213; 
			}
			
			if(Grade.DEFECTIVE_220.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_220; 
			}
			
			if(Grade.DEFECTIVE_221.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_221; 
			}
			
			if(Grade.DEFECTIVE_222.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_222; 
			}
			
			if(Grade.DEFECTIVE_223.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_223; 
			}
			
			if(Grade.DEFECTIVE_230.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_230; 
			}
			
			if(Grade.DEFECTIVE_231.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_231; 
			}
			
			if(Grade.DEFECTIVE_232.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_232; 
			}
			
			if(Grade.DEFECTIVE_233.ToString().Equals(name)){
				
				return Grade.DEFECTIVE_233; 
			}
			
			
			return null;
			
		}
		
	}
	
}