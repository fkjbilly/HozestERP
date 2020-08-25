using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class Stock {
		
		///<summary>
		/// 商品库存状态，0: 可购买; 1: 已售完; 2: 有机会
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 商品库存状态描述文字： 可购买; 已售完; 有机会
		///</summary>
		
		private string desc_;
		
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public string GetDesc(){
			return this.desc_;
		}
		
		public void SetDesc(string value){
			this.desc_ = value;
		}
		
	}
	
}