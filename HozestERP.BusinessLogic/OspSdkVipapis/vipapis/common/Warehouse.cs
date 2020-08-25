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
		/// 西南：成都仓
		///</summary>
		VIP_CD = 3, 
		
		///<summary>
		/// 北京仓
		///</summary>
		VIP_BJ = 4, 
		
		///<summary>
		/// 华中：鄂州仓
		///</summary>
		VIP_HZ = 5, 
		
		///<summary>
		/// 花海仓
		///</summary>
		VIP_HH = 7, 
		
		///<summary>
		/// 郑州
		///</summary>
		VIP_ZZ = 8, 
		
		///<summary>
		/// 首尔
		///</summary>
		VIP_SE = 9, 
		
		///<summary>
		/// 白云
		///</summary>
		VIP_JC = 10, 
		
		///<summary>
		/// 唯品团
		///</summary>
		VIP_DA = 11, 
		
		///<summary>
		/// 唯品卡
		///</summary>
		VIP_MRC = 12, 
		
		///<summary>
		/// 郑州空港
		///</summary>
		VIP_ZZKG = 13, 
		
		///<summary>
		/// 广州南沙
		///</summary>
		VIP_GZNS = 14, 
		
		///<summary>
		/// 重庆空港
		///</summary>
		VIP_CQKG = 15, 
		
		///<summary>
		/// 苏州工业
		///</summary>
		VIP_SZGY = 16, 
		
		///<summary>
		/// 福州平潭
		///</summary>
		VIP_FZPT = 17, 
		
		///<summary>
		/// 青岛黄岛
		///</summary>
		VIP_QDHD = 18, 
		
		///<summary>
		/// 广州中远
		///</summary>
		HT_GZZY = 19, 
		
		///<summary>
		/// 富力心怡仓
		///</summary>
		HT_GZFLXY = 20, 
		
		///<summary>
		/// 机场保税仓
		///</summary>
		VIP_NBJCBS = 21, 
		
		///<summary>
		/// 云仓代运营
		///</summary>
		HT_NBYC = 22, 
		
		///<summary>
		/// 杭州航都仓
		///</summary>
		HT_HZHD = 23, 
		
		///<summary>
		/// 日本日通仓
		///</summary>
		HT_JPRT = 24, 
		
		///<summary>
		/// 悉尼心怡仓
		///</summary>
		HT_AUXNXY = 25, 
		
		///<summary>
		/// 洛杉矶天马仓
		///</summary>
		HT_USALATM = 26, 
		
		///<summary>
		/// 纽约天马仓
		///</summary>
		HT_USANYTM = 27, 
		
		///<summary>
		/// 前海保宏仓
		///</summary>
		HT_SZQHBH = 28, 
		
		///<summary>
		/// 福建福州仓
		///</summary>
		FJFZ = 29, 
		
		///<summary>
		/// 杭州仓
		///</summary>
		PJ_ZJHZ = 30, 
		
		///<summary>
		/// 郑州小仓
		///</summary>
		HNZZ = 31, 
		
		///<summary>
		/// 西安小仓
		///</summary>
		SXXA = 32, 
		
		///<summary>
		/// 沈阳小仓
		///</summary>
		LNSY = 33, 
		
		///<summary>
		/// 昆明小仓
		///</summary>
		YNKM = 34, 
		
		///<summary>
		/// 贵阳前置仓
		///</summary>
		GZGY = 35, 
		
		///<summary>
		/// 内蒙古前置仓
		///</summary>
		NMGHHHT = 36, 
		
		///<summary>
		/// 济南前置仓
		///</summary>
		SDJN = 37, 
		
		///<summary>
		/// 新疆前置仓
		///</summary>
		XJWLMQ = 38, 
		
		///<summary>
		/// 黑龙江哈尔滨前置仓
		///</summary>
		HLJHEB = 39, 
		
		///<summary>
		/// 广西南宁前置仓
		///</summary>
		GXNN = 40, 
		
		///<summary>
		/// 山西太原前置仓
		///</summary>
		SXTY = 41, 
		
		///<summary>
		/// 安徽合肥前置仓
		///</summary>
		AHHF = 42, 
		
		///<summary>
		/// 香港自营仓
		///</summary>
		VIP_HK = 43, 
		
		///<summary>
		/// 日本东京自营仓
		///</summary>
		VIP_TYO = 44, 
		
		///<summary>
		/// 美国纽约自营仓
		///</summary>
		VIP_NYC = 45, 
		
		///<summary>
		/// 法国巴黎自营仓
		///</summary>
		VIP_PAR = 46, 
		
		///<summary>
		/// 韩国首尔自营仓
		///</summary>
		VIP_SEL = 47, 
		
		///<summary>
		/// 澳大利亚悉尼运自营仓
		///</summary>
		VIP_SYD = 48, 
		
		///<summary>
		/// 英国伦敦自营仓
		///</summary>
		VIP_LON = 49, 
		
		///<summary>
		/// 德国法兰克福自营仓
		///</summary>
		VIP_FRA = 50, 
		
		///<summary>
		/// 意大利米兰自营仓
		///</summary>
		VIP_MIL = 51, 
		
		///<summary>
		/// 东北仓
		///</summary>
		VIP_SY = 52 
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
				case 7: return Warehouse.VIP_HH; 
				case 8: return Warehouse.VIP_ZZ; 
				case 9: return Warehouse.VIP_SE; 
				case 10: return Warehouse.VIP_JC; 
				case 11: return Warehouse.VIP_DA; 
				case 12: return Warehouse.VIP_MRC; 
				case 13: return Warehouse.VIP_ZZKG; 
				case 14: return Warehouse.VIP_GZNS; 
				case 15: return Warehouse.VIP_CQKG; 
				case 16: return Warehouse.VIP_SZGY; 
				case 17: return Warehouse.VIP_FZPT; 
				case 18: return Warehouse.VIP_QDHD; 
				case 19: return Warehouse.HT_GZZY; 
				case 20: return Warehouse.HT_GZFLXY; 
				case 21: return Warehouse.VIP_NBJCBS; 
				case 22: return Warehouse.HT_NBYC; 
				case 23: return Warehouse.HT_HZHD; 
				case 24: return Warehouse.HT_JPRT; 
				case 25: return Warehouse.HT_AUXNXY; 
				case 26: return Warehouse.HT_USALATM; 
				case 27: return Warehouse.HT_USANYTM; 
				case 28: return Warehouse.HT_SZQHBH; 
				case 29: return Warehouse.FJFZ; 
				case 30: return Warehouse.PJ_ZJHZ; 
				case 31: return Warehouse.HNZZ; 
				case 32: return Warehouse.SXXA; 
				case 33: return Warehouse.LNSY; 
				case 34: return Warehouse.YNKM; 
				case 35: return Warehouse.GZGY; 
				case 36: return Warehouse.NMGHHHT; 
				case 37: return Warehouse.SDJN; 
				case 38: return Warehouse.XJWLMQ; 
				case 39: return Warehouse.HLJHEB; 
				case 40: return Warehouse.GXNN; 
				case 41: return Warehouse.SXTY; 
				case 42: return Warehouse.AHHF; 
				case 43: return Warehouse.VIP_HK; 
				case 44: return Warehouse.VIP_TYO; 
				case 45: return Warehouse.VIP_NYC; 
				case 46: return Warehouse.VIP_PAR; 
				case 47: return Warehouse.VIP_SEL; 
				case 48: return Warehouse.VIP_SYD; 
				case 49: return Warehouse.VIP_LON; 
				case 50: return Warehouse.VIP_FRA; 
				case 51: return Warehouse.VIP_MIL; 
				case 52: return Warehouse.VIP_SY; 
				
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
			
			if(Warehouse.VIP_HH.ToString().Equals(name)){
				
				return Warehouse.VIP_HH; 
			}
			
			if(Warehouse.VIP_ZZ.ToString().Equals(name)){
				
				return Warehouse.VIP_ZZ; 
			}
			
			if(Warehouse.VIP_SE.ToString().Equals(name)){
				
				return Warehouse.VIP_SE; 
			}
			
			if(Warehouse.VIP_JC.ToString().Equals(name)){
				
				return Warehouse.VIP_JC; 
			}
			
			if(Warehouse.VIP_DA.ToString().Equals(name)){
				
				return Warehouse.VIP_DA; 
			}
			
			if(Warehouse.VIP_MRC.ToString().Equals(name)){
				
				return Warehouse.VIP_MRC; 
			}
			
			if(Warehouse.VIP_ZZKG.ToString().Equals(name)){
				
				return Warehouse.VIP_ZZKG; 
			}
			
			if(Warehouse.VIP_GZNS.ToString().Equals(name)){
				
				return Warehouse.VIP_GZNS; 
			}
			
			if(Warehouse.VIP_CQKG.ToString().Equals(name)){
				
				return Warehouse.VIP_CQKG; 
			}
			
			if(Warehouse.VIP_SZGY.ToString().Equals(name)){
				
				return Warehouse.VIP_SZGY; 
			}
			
			if(Warehouse.VIP_FZPT.ToString().Equals(name)){
				
				return Warehouse.VIP_FZPT; 
			}
			
			if(Warehouse.VIP_QDHD.ToString().Equals(name)){
				
				return Warehouse.VIP_QDHD; 
			}
			
			if(Warehouse.HT_GZZY.ToString().Equals(name)){
				
				return Warehouse.HT_GZZY; 
			}
			
			if(Warehouse.HT_GZFLXY.ToString().Equals(name)){
				
				return Warehouse.HT_GZFLXY; 
			}
			
			if(Warehouse.VIP_NBJCBS.ToString().Equals(name)){
				
				return Warehouse.VIP_NBJCBS; 
			}
			
			if(Warehouse.HT_NBYC.ToString().Equals(name)){
				
				return Warehouse.HT_NBYC; 
			}
			
			if(Warehouse.HT_HZHD.ToString().Equals(name)){
				
				return Warehouse.HT_HZHD; 
			}
			
			if(Warehouse.HT_JPRT.ToString().Equals(name)){
				
				return Warehouse.HT_JPRT; 
			}
			
			if(Warehouse.HT_AUXNXY.ToString().Equals(name)){
				
				return Warehouse.HT_AUXNXY; 
			}
			
			if(Warehouse.HT_USALATM.ToString().Equals(name)){
				
				return Warehouse.HT_USALATM; 
			}
			
			if(Warehouse.HT_USANYTM.ToString().Equals(name)){
				
				return Warehouse.HT_USANYTM; 
			}
			
			if(Warehouse.HT_SZQHBH.ToString().Equals(name)){
				
				return Warehouse.HT_SZQHBH; 
			}
			
			if(Warehouse.FJFZ.ToString().Equals(name)){
				
				return Warehouse.FJFZ; 
			}
			
			if(Warehouse.PJ_ZJHZ.ToString().Equals(name)){
				
				return Warehouse.PJ_ZJHZ; 
			}
			
			if(Warehouse.HNZZ.ToString().Equals(name)){
				
				return Warehouse.HNZZ; 
			}
			
			if(Warehouse.SXXA.ToString().Equals(name)){
				
				return Warehouse.SXXA; 
			}
			
			if(Warehouse.LNSY.ToString().Equals(name)){
				
				return Warehouse.LNSY; 
			}
			
			if(Warehouse.YNKM.ToString().Equals(name)){
				
				return Warehouse.YNKM; 
			}
			
			if(Warehouse.GZGY.ToString().Equals(name)){
				
				return Warehouse.GZGY; 
			}
			
			if(Warehouse.NMGHHHT.ToString().Equals(name)){
				
				return Warehouse.NMGHHHT; 
			}
			
			if(Warehouse.SDJN.ToString().Equals(name)){
				
				return Warehouse.SDJN; 
			}
			
			if(Warehouse.XJWLMQ.ToString().Equals(name)){
				
				return Warehouse.XJWLMQ; 
			}
			
			if(Warehouse.HLJHEB.ToString().Equals(name)){
				
				return Warehouse.HLJHEB; 
			}
			
			if(Warehouse.GXNN.ToString().Equals(name)){
				
				return Warehouse.GXNN; 
			}
			
			if(Warehouse.SXTY.ToString().Equals(name)){
				
				return Warehouse.SXTY; 
			}
			
			if(Warehouse.AHHF.ToString().Equals(name)){
				
				return Warehouse.AHHF; 
			}
			
			if(Warehouse.VIP_HK.ToString().Equals(name)){
				
				return Warehouse.VIP_HK; 
			}
			
			if(Warehouse.VIP_TYO.ToString().Equals(name)){
				
				return Warehouse.VIP_TYO; 
			}
			
			if(Warehouse.VIP_NYC.ToString().Equals(name)){
				
				return Warehouse.VIP_NYC; 
			}
			
			if(Warehouse.VIP_PAR.ToString().Equals(name)){
				
				return Warehouse.VIP_PAR; 
			}
			
			if(Warehouse.VIP_SEL.ToString().Equals(name)){
				
				return Warehouse.VIP_SEL; 
			}
			
			if(Warehouse.VIP_SYD.ToString().Equals(name)){
				
				return Warehouse.VIP_SYD; 
			}
			
			if(Warehouse.VIP_LON.ToString().Equals(name)){
				
				return Warehouse.VIP_LON; 
			}
			
			if(Warehouse.VIP_FRA.ToString().Equals(name)){
				
				return Warehouse.VIP_FRA; 
			}
			
			if(Warehouse.VIP_MIL.ToString().Equals(name)){
				
				return Warehouse.VIP_MIL; 
			}
			
			if(Warehouse.VIP_SY.ToString().Equals(name)){
				
				return Warehouse.VIP_SY; 
			}
			
			
			return null;
			
		}
		
	}
	
}