using System;

namespace vipapis.product{
	
	
	public enum Unit {
		
		
		///<summary>
		/// 件/个 (piece/pieces) 
		///</summary>
		PIECE = 1000, 
		
		///<summary>
		/// 双 (pair) 
		///</summary>
		PAIR = 1001, 
		
		///<summary>
		/// 套 (set/sets) 
		///</summary>
		SET = 1002, 
		
		///<summary>
		/// 箱 (carton) 
		///</summary>
		CARTON = 1003, 
		
		///<summary>
		/// 打 (dozen) 
		///</summary>
		DOZEN = 1004, 
		
		///<summary>
		/// 桶 (barrel/barrels) 
		///</summary>
		BARREL = 1005, 
		
		///<summary>
		/// 包 (pack/packs) 
		///</summary>
		PACK = 1006, 
		
		///<summary>
		/// 袋 (bag/bags) 
		///</summary>
		BAG = 1007, 
		
		///<summary>
		/// 克 (gram) 
		///</summary>
		GRAM = 1008, 
		
		///<summary>
		/// 千克 (kilogram) 
		///</summary>
		KILOGRAM = 1009, 
		
		///<summary>
		/// 毫升 (milliliter) 
		///</summary>
		MILLILITER = 1010, 
		
		///<summary>
		/// 盎司 (ounce) 
		///</summary>
		OUNCE = 1011, 
		
		///<summary>
		/// 磅 (pound) 
		///</summary>
		POUND = 1012, 
		
		///<summary>
		/// 美吨 (short ton) 
		///</summary>
		SHORT_TON = 1013, 
		
		///<summary>
		/// 加仑 (gallon) 
		///</summary>
		GALLON = 1014, 
		
		///<summary>
		/// 平方米 (square meter) 
		///</summary>
		SQUARE_METER = 1015, 
		
		///<summary>
		/// 立方米 (cubic meter) 
		///</summary>
		CUBIC_METER = 1016, 
		
		///<summary>
		/// 吨 (ton) 
		///</summary>
		TON = 1017, 
		
		///<summary>
		/// 公吨 (metric ton) 
		///</summary>
		METRIC_TON = 1018, 
		
		///<summary>
		/// 英吨 (long ton) 
		///</summary>
		LONG_TON = 1019, 
		
		///<summary>
		/// 厘米 (centimeter) 
		///</summary>
		CENTIMETER = 1020, 
		
		///<summary>
		/// 米 (meter) 
		///</summary>
		METER = 1021, 
		
		///<summary>
		/// 千米 (kilometer) 
		///</summary>
		KILOMETER = 1022, 
		
		///<summary>
		/// 英尺 (feet) 
		///</summary>
		FEET = 1023, 
		
		///<summary>
		/// 英寸 (inch) 
		///</summary>
		INCH = 1024, 
		
		///<summary>
		/// 千升 (kiloliter) 
		///</summary>
		KILOLITER = 1025, 
		
		///<summary>
		/// 升 (liter/liters) 
		///</summary>
		LITER = 1026, 
		
		///<summary>
		/// 毫克 (milligram) 
		///</summary>
		MILLIGRAM = 1027, 
		
		///<summary>
		/// 毫米 (millimeter) 
		///</summary>
		MILLIMETER = 1028, 
		
		///<summary>
		/// 平方英尺 (square feet) 
		///</summary>
		SQUARE_FEET = 1029, 
		
		///<summary>
		/// 平方英寸 (square inch) 
		///</summary>
		SQUARE_INCH = 1030, 
		
		///<summary>
		/// 平方码 (square yard) 
		///</summary>
		SQUARE_YARD = 1031, 
		
		///<summary>
		/// 码 (yard/yards) 
		///</summary>
		YARD = 1032, 
		
		///<summary>
		/// 把 (ba) 
		///</summary>
		BA = 1033, 
		
		///<summary>
		/// 本 (ben) 
		///</summary>
		BEN = 1034, 
		
		///<summary>
		/// 册 (ce) 
		///</summary>
		CE = 1035, 
		
		///<summary>
		/// 单片 (dan_pian)
		///</summary>
		DAN_PIAN = 1036, 
		
		///<summary>
		/// 对 (dui) 
		///</summary>
		DUI = 1037, 
		
		///<summary>
		/// 封套 (feng_tao) 
		///</summary>
		FENG_TAO = 1038, 
		
		///<summary>
		/// 盒 (box) 
		///</summary>
		BOX = 1039, 
		
		///<summary>
		/// 面 (mian) 
		///</summary>
		MIAN = 1040, 
		
		///<summary>
		/// 片 (pian) 
		///</summary>
		PIAN = 1041, 
		
		///<summary>
		/// 瓶 (bottle) 
		///</summary>
		BOTTLE = 1042, 
		
		///<summary>
		/// 台 (tai) 
		///</summary>
		TAI = 1043, 
		
		///<summary>
		/// 条 (tiao) 
		///</summary>
		TIAO = 1044, 
		
		///<summary>
		/// 套组 (tao_zu) 
		///</summary>
		TAO_ZU = 1045, 
		
		///<summary>
		/// 张 (zhang) 
		///</summary>
		ZHANG = 1046, 
		
		///<summary>
		/// 支 (zhi_1047) 
		///</summary>
		ZHI_1047 = 1047, 
		
		///<summary>
		/// 只 (zhi_1048) 
		///</summary>
		ZHI_1048 = 1048, 
		
		///<summary>
		/// 组 (zu) 
		///</summary>
		ZU = 1049, 
		
		///<summary>
		/// 单件 (each) 
		///</summary>
		EACH = 1050, 
		
		///<summary>
		/// 整包 (case) 
		///</summary>
		CASE = 1051 
	}
	
	public class UnitUtil{
		
		private readonly int value;
		private UnitUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static Unit? FindByValue(int value){
			
			switch(value){
				
				case 1000: return Unit.PIECE; 
				case 1001: return Unit.PAIR; 
				case 1002: return Unit.SET; 
				case 1003: return Unit.CARTON; 
				case 1004: return Unit.DOZEN; 
				case 1005: return Unit.BARREL; 
				case 1006: return Unit.PACK; 
				case 1007: return Unit.BAG; 
				case 1008: return Unit.GRAM; 
				case 1009: return Unit.KILOGRAM; 
				case 1010: return Unit.MILLILITER; 
				case 1011: return Unit.OUNCE; 
				case 1012: return Unit.POUND; 
				case 1013: return Unit.SHORT_TON; 
				case 1014: return Unit.GALLON; 
				case 1015: return Unit.SQUARE_METER; 
				case 1016: return Unit.CUBIC_METER; 
				case 1017: return Unit.TON; 
				case 1018: return Unit.METRIC_TON; 
				case 1019: return Unit.LONG_TON; 
				case 1020: return Unit.CENTIMETER; 
				case 1021: return Unit.METER; 
				case 1022: return Unit.KILOMETER; 
				case 1023: return Unit.FEET; 
				case 1024: return Unit.INCH; 
				case 1025: return Unit.KILOLITER; 
				case 1026: return Unit.LITER; 
				case 1027: return Unit.MILLIGRAM; 
				case 1028: return Unit.MILLIMETER; 
				case 1029: return Unit.SQUARE_FEET; 
				case 1030: return Unit.SQUARE_INCH; 
				case 1031: return Unit.SQUARE_YARD; 
				case 1032: return Unit.YARD; 
				case 1033: return Unit.BA; 
				case 1034: return Unit.BEN; 
				case 1035: return Unit.CE; 
				case 1036: return Unit.DAN_PIAN; 
				case 1037: return Unit.DUI; 
				case 1038: return Unit.FENG_TAO; 
				case 1039: return Unit.BOX; 
				case 1040: return Unit.MIAN; 
				case 1041: return Unit.PIAN; 
				case 1042: return Unit.BOTTLE; 
				case 1043: return Unit.TAI; 
				case 1044: return Unit.TIAO; 
				case 1045: return Unit.TAO_ZU; 
				case 1046: return Unit.ZHANG; 
				case 1047: return Unit.ZHI_1047; 
				case 1048: return Unit.ZHI_1048; 
				case 1049: return Unit.ZU; 
				case 1050: return Unit.EACH; 
				case 1051: return Unit.CASE; 
				
				default: return null; 
				
			}
			
		}
		
		public static Unit? FindByName(string name){
			
			if(Unit.PIECE.ToString().Equals(name)){
				
				return Unit.PIECE; 
			}
			
			if(Unit.PAIR.ToString().Equals(name)){
				
				return Unit.PAIR; 
			}
			
			if(Unit.SET.ToString().Equals(name)){
				
				return Unit.SET; 
			}
			
			if(Unit.CARTON.ToString().Equals(name)){
				
				return Unit.CARTON; 
			}
			
			if(Unit.DOZEN.ToString().Equals(name)){
				
				return Unit.DOZEN; 
			}
			
			if(Unit.BARREL.ToString().Equals(name)){
				
				return Unit.BARREL; 
			}
			
			if(Unit.PACK.ToString().Equals(name)){
				
				return Unit.PACK; 
			}
			
			if(Unit.BAG.ToString().Equals(name)){
				
				return Unit.BAG; 
			}
			
			if(Unit.GRAM.ToString().Equals(name)){
				
				return Unit.GRAM; 
			}
			
			if(Unit.KILOGRAM.ToString().Equals(name)){
				
				return Unit.KILOGRAM; 
			}
			
			if(Unit.MILLILITER.ToString().Equals(name)){
				
				return Unit.MILLILITER; 
			}
			
			if(Unit.OUNCE.ToString().Equals(name)){
				
				return Unit.OUNCE; 
			}
			
			if(Unit.POUND.ToString().Equals(name)){
				
				return Unit.POUND; 
			}
			
			if(Unit.SHORT_TON.ToString().Equals(name)){
				
				return Unit.SHORT_TON; 
			}
			
			if(Unit.GALLON.ToString().Equals(name)){
				
				return Unit.GALLON; 
			}
			
			if(Unit.SQUARE_METER.ToString().Equals(name)){
				
				return Unit.SQUARE_METER; 
			}
			
			if(Unit.CUBIC_METER.ToString().Equals(name)){
				
				return Unit.CUBIC_METER; 
			}
			
			if(Unit.TON.ToString().Equals(name)){
				
				return Unit.TON; 
			}
			
			if(Unit.METRIC_TON.ToString().Equals(name)){
				
				return Unit.METRIC_TON; 
			}
			
			if(Unit.LONG_TON.ToString().Equals(name)){
				
				return Unit.LONG_TON; 
			}
			
			if(Unit.CENTIMETER.ToString().Equals(name)){
				
				return Unit.CENTIMETER; 
			}
			
			if(Unit.METER.ToString().Equals(name)){
				
				return Unit.METER; 
			}
			
			if(Unit.KILOMETER.ToString().Equals(name)){
				
				return Unit.KILOMETER; 
			}
			
			if(Unit.FEET.ToString().Equals(name)){
				
				return Unit.FEET; 
			}
			
			if(Unit.INCH.ToString().Equals(name)){
				
				return Unit.INCH; 
			}
			
			if(Unit.KILOLITER.ToString().Equals(name)){
				
				return Unit.KILOLITER; 
			}
			
			if(Unit.LITER.ToString().Equals(name)){
				
				return Unit.LITER; 
			}
			
			if(Unit.MILLIGRAM.ToString().Equals(name)){
				
				return Unit.MILLIGRAM; 
			}
			
			if(Unit.MILLIMETER.ToString().Equals(name)){
				
				return Unit.MILLIMETER; 
			}
			
			if(Unit.SQUARE_FEET.ToString().Equals(name)){
				
				return Unit.SQUARE_FEET; 
			}
			
			if(Unit.SQUARE_INCH.ToString().Equals(name)){
				
				return Unit.SQUARE_INCH; 
			}
			
			if(Unit.SQUARE_YARD.ToString().Equals(name)){
				
				return Unit.SQUARE_YARD; 
			}
			
			if(Unit.YARD.ToString().Equals(name)){
				
				return Unit.YARD; 
			}
			
			if(Unit.BA.ToString().Equals(name)){
				
				return Unit.BA; 
			}
			
			if(Unit.BEN.ToString().Equals(name)){
				
				return Unit.BEN; 
			}
			
			if(Unit.CE.ToString().Equals(name)){
				
				return Unit.CE; 
			}
			
			if(Unit.DAN_PIAN.ToString().Equals(name)){
				
				return Unit.DAN_PIAN; 
			}
			
			if(Unit.DUI.ToString().Equals(name)){
				
				return Unit.DUI; 
			}
			
			if(Unit.FENG_TAO.ToString().Equals(name)){
				
				return Unit.FENG_TAO; 
			}
			
			if(Unit.BOX.ToString().Equals(name)){
				
				return Unit.BOX; 
			}
			
			if(Unit.MIAN.ToString().Equals(name)){
				
				return Unit.MIAN; 
			}
			
			if(Unit.PIAN.ToString().Equals(name)){
				
				return Unit.PIAN; 
			}
			
			if(Unit.BOTTLE.ToString().Equals(name)){
				
				return Unit.BOTTLE; 
			}
			
			if(Unit.TAI.ToString().Equals(name)){
				
				return Unit.TAI; 
			}
			
			if(Unit.TIAO.ToString().Equals(name)){
				
				return Unit.TIAO; 
			}
			
			if(Unit.TAO_ZU.ToString().Equals(name)){
				
				return Unit.TAO_ZU; 
			}
			
			if(Unit.ZHANG.ToString().Equals(name)){
				
				return Unit.ZHANG; 
			}
			
			if(Unit.ZHI_1047.ToString().Equals(name)){
				
				return Unit.ZHI_1047; 
			}
			
			if(Unit.ZHI_1048.ToString().Equals(name)){
				
				return Unit.ZHI_1048; 
			}
			
			if(Unit.ZU.ToString().Equals(name)){
				
				return Unit.ZU; 
			}
			
			if(Unit.EACH.ToString().Equals(name)){
				
				return Unit.EACH; 
			}
			
			if(Unit.CASE.ToString().Equals(name)){
				
				return Unit.CASE; 
			}
			
			
			return null;
			
		}
		
	}
	
}