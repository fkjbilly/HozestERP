using System;

namespace com.vip.domain.inventory{
	
	
	public enum ChannelInventoryGrade {
		
		
		///<summary>
		/// 正常
		///</summary>
		GRADE_100 = 100, 
		
		///<summary>
		/// 正常，已过可上线日期
		///</summary>
		GRADE_101 = 101, 
		
		///<summary>
		/// 正常，已过保险期
		///</summary>
		GRADE_102 = 102, 
		
		///<summary>
		/// 正常，已过失效期
		///</summary>
		GRADE_103 = 103, 
		
		///<summary>
		/// 一级残次
		///</summary>
		GRADE_210 = 210, 
		
		///<summary>
		/// 一级残次，已过可上线日期
		///</summary>
		GRADE_211 = 211, 
		
		///<summary>
		/// 一级残次，已过保险期
		///</summary>
		GRADE_212 = 212, 
		
		///<summary>
		/// 一级残次，已过失效期
		///</summary>
		GRADE_213 = 213, 
		
		///<summary>
		/// 二级残次
		///</summary>
		GRADE_220 = 220, 
		
		///<summary>
		/// 二级残次，已过可上线日期
		///</summary>
		GRADE_221 = 221, 
		
		///<summary>
		/// 二级残次，已过保险期
		///</summary>
		GRADE_222 = 222, 
		
		///<summary>
		/// 二级残次，已过失效期
		///</summary>
		GRADE_223 = 223, 
		
		///<summary>
		/// 三级残次
		///</summary>
		GRADE_230 = 230, 
		
		///<summary>
		/// 三级残次，已过可上线日期
		///</summary>
		GRADE_231 = 231, 
		
		///<summary>
		/// 三级残次，已过保险期
		///</summary>
		GRADE_232 = 232, 
		
		///<summary>
		/// 三级残次，已过失效期
		///</summary>
		GRADE_233 = 233 
	}
	
	public class ChannelInventoryGradeUtil{
		
		private readonly int value;
		private ChannelInventoryGradeUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static ChannelInventoryGrade? FindByValue(int value){
			
			switch(value){
				
				case 100: return ChannelInventoryGrade.GRADE_100; 
				case 101: return ChannelInventoryGrade.GRADE_101; 
				case 102: return ChannelInventoryGrade.GRADE_102; 
				case 103: return ChannelInventoryGrade.GRADE_103; 
				case 210: return ChannelInventoryGrade.GRADE_210; 
				case 211: return ChannelInventoryGrade.GRADE_211; 
				case 212: return ChannelInventoryGrade.GRADE_212; 
				case 213: return ChannelInventoryGrade.GRADE_213; 
				case 220: return ChannelInventoryGrade.GRADE_220; 
				case 221: return ChannelInventoryGrade.GRADE_221; 
				case 222: return ChannelInventoryGrade.GRADE_222; 
				case 223: return ChannelInventoryGrade.GRADE_223; 
				case 230: return ChannelInventoryGrade.GRADE_230; 
				case 231: return ChannelInventoryGrade.GRADE_231; 
				case 232: return ChannelInventoryGrade.GRADE_232; 
				case 233: return ChannelInventoryGrade.GRADE_233; 
				
				default: return null; 
				
			}
			
		}
		
		public static ChannelInventoryGrade? FindByName(string name){
			
			if(ChannelInventoryGrade.GRADE_100.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_100; 
			}
			
			if(ChannelInventoryGrade.GRADE_101.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_101; 
			}
			
			if(ChannelInventoryGrade.GRADE_102.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_102; 
			}
			
			if(ChannelInventoryGrade.GRADE_103.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_103; 
			}
			
			if(ChannelInventoryGrade.GRADE_210.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_210; 
			}
			
			if(ChannelInventoryGrade.GRADE_211.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_211; 
			}
			
			if(ChannelInventoryGrade.GRADE_212.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_212; 
			}
			
			if(ChannelInventoryGrade.GRADE_213.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_213; 
			}
			
			if(ChannelInventoryGrade.GRADE_220.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_220; 
			}
			
			if(ChannelInventoryGrade.GRADE_221.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_221; 
			}
			
			if(ChannelInventoryGrade.GRADE_222.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_222; 
			}
			
			if(ChannelInventoryGrade.GRADE_223.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_223; 
			}
			
			if(ChannelInventoryGrade.GRADE_230.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_230; 
			}
			
			if(ChannelInventoryGrade.GRADE_231.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_231; 
			}
			
			if(ChannelInventoryGrade.GRADE_232.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_232; 
			}
			
			if(ChannelInventoryGrade.GRADE_233.ToString().Equals(name)){
				
				return ChannelInventoryGrade.GRADE_233; 
			}
			
			
			return null;
			
		}
		
	}
	
}