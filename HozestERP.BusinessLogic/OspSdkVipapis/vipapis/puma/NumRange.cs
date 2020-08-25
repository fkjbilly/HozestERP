using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class NumRange {
		
		///<summary>
		/// 最小数
		///</summary>
		
		private int? min_num_;
		
		///<summary>
		/// 最大数
		///</summary>
		
		private int? max_num_;
		
		public int? GetMin_num(){
			return this.min_num_;
		}
		
		public void SetMin_num(int? value){
			this.min_num_ = value;
		}
		public int? GetMax_num(){
			return this.max_num_;
		}
		
		public void SetMax_num(int? value){
			this.max_num_ = value;
		}
		
	}
	
}