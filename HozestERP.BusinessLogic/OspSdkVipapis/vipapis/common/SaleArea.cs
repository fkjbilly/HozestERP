using System;

namespace vipapis.common{
	
	
	public enum SaleArea {
		
		
		///<summary>
		/// 出口加工区
		///</summary>
		ZZ = 1, 
		
		///<summary>
		/// 郑州空港保税仓
		///</summary>
		ZZKG = 2, 
		
		///<summary>
		/// 广州南沙保税仓
		///</summary>
		GZNS = 3, 
		
		///<summary>
		/// 重庆空港保税仓
		///</summary>
		CQKG = 4, 
		
		///<summary>
		/// 苏州工业园保税仓
		///</summary>
		SZGY = 5, 
		
		///<summary>
		/// 福州平潭保税仓
		///</summary>
		FZPT = 6, 
		
		///<summary>
		/// 广州机场富力
		///</summary>
		GZJC = 7, 
		
		///<summary>
		/// 青岛黄岛
		///</summary>
		QDHD = 8, 
		
		///<summary>
		/// 首尔仓
		///</summary>
		SE = 9, 
		
		///<summary>
		/// 广州中远
		///</summary>
		GZZY = 10, 
		
		///<summary>
		/// 富力心怡仓
		///</summary>
		GZFLXY = 11, 
		
		///<summary>
		/// 机场保税仓
		///</summary>
		NBJCBS = 12, 
		
		///<summary>
		/// 云仓代运营
		///</summary>
		NBYC = 13, 
		
		///<summary>
		/// 杭州航都仓
		///</summary>
		HZHD = 14, 
		
		///<summary>
		/// 日本日通仓
		///</summary>
		JPRT = 15, 
		
		///<summary>
		/// 悉尼心怡仓
		///</summary>
		AUXNXY = 16, 
		
		///<summary>
		/// 洛杉矶天马仓
		///</summary>
		USALATM = 17, 
		
		///<summary>
		/// 纽约天马仓
		///</summary>
		USANYTM = 18, 
		
		///<summary>
		/// 前海保宏仓
		///</summary>
		SZQHBH = 19 
	}
	
	public class SaleAreaUtil{
		
		private readonly int value;
		private SaleAreaUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static SaleArea? FindByValue(int value){
			
			switch(value){
				
				case 1: return SaleArea.ZZ; 
				case 2: return SaleArea.ZZKG; 
				case 3: return SaleArea.GZNS; 
				case 4: return SaleArea.CQKG; 
				case 5: return SaleArea.SZGY; 
				case 6: return SaleArea.FZPT; 
				case 7: return SaleArea.GZJC; 
				case 8: return SaleArea.QDHD; 
				case 9: return SaleArea.SE; 
				case 10: return SaleArea.GZZY; 
				case 11: return SaleArea.GZFLXY; 
				case 12: return SaleArea.NBJCBS; 
				case 13: return SaleArea.NBYC; 
				case 14: return SaleArea.HZHD; 
				case 15: return SaleArea.JPRT; 
				case 16: return SaleArea.AUXNXY; 
				case 17: return SaleArea.USALATM; 
				case 18: return SaleArea.USANYTM; 
				case 19: return SaleArea.SZQHBH; 
				
				default: return null; 
				
			}
			
		}
		
		public static SaleArea? FindByName(string name){
			
			if(SaleArea.ZZ.ToString().Equals(name)){
				
				return SaleArea.ZZ; 
			}
			
			if(SaleArea.ZZKG.ToString().Equals(name)){
				
				return SaleArea.ZZKG; 
			}
			
			if(SaleArea.GZNS.ToString().Equals(name)){
				
				return SaleArea.GZNS; 
			}
			
			if(SaleArea.CQKG.ToString().Equals(name)){
				
				return SaleArea.CQKG; 
			}
			
			if(SaleArea.SZGY.ToString().Equals(name)){
				
				return SaleArea.SZGY; 
			}
			
			if(SaleArea.FZPT.ToString().Equals(name)){
				
				return SaleArea.FZPT; 
			}
			
			if(SaleArea.GZJC.ToString().Equals(name)){
				
				return SaleArea.GZJC; 
			}
			
			if(SaleArea.QDHD.ToString().Equals(name)){
				
				return SaleArea.QDHD; 
			}
			
			if(SaleArea.SE.ToString().Equals(name)){
				
				return SaleArea.SE; 
			}
			
			if(SaleArea.GZZY.ToString().Equals(name)){
				
				return SaleArea.GZZY; 
			}
			
			if(SaleArea.GZFLXY.ToString().Equals(name)){
				
				return SaleArea.GZFLXY; 
			}
			
			if(SaleArea.NBJCBS.ToString().Equals(name)){
				
				return SaleArea.NBJCBS; 
			}
			
			if(SaleArea.NBYC.ToString().Equals(name)){
				
				return SaleArea.NBYC; 
			}
			
			if(SaleArea.HZHD.ToString().Equals(name)){
				
				return SaleArea.HZHD; 
			}
			
			if(SaleArea.JPRT.ToString().Equals(name)){
				
				return SaleArea.JPRT; 
			}
			
			if(SaleArea.AUXNXY.ToString().Equals(name)){
				
				return SaleArea.AUXNXY; 
			}
			
			if(SaleArea.USALATM.ToString().Equals(name)){
				
				return SaleArea.USALATM; 
			}
			
			if(SaleArea.USANYTM.ToString().Equals(name)){
				
				return SaleArea.USANYTM; 
			}
			
			if(SaleArea.SZQHBH.ToString().Equals(name)){
				
				return SaleArea.SZQHBH; 
			}
			
			
			return null;
			
		}
		
	}
	
}