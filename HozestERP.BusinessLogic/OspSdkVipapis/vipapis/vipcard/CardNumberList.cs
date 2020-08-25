using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vipcard{
	
	
	
	
	
	public class CardNumberList {
		
		///<summary>
		/// 批次内唯品卡总数
		/// @sampleValue total 1211
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 唯品卡号列表
		///</summary>
		
		private List<vipapis.vipcard.CardNumber> list_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.vipcard.CardNumber> GetList(){
			return this.list_;
		}
		
		public void SetList(List<vipapis.vipcard.CardNumber> value){
			this.list_ = value;
		}
		
	}
	
}