using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.request{
	
	
	
	
	
	public class RangeParam {
		
		///<summary>
		/// 包含值	(方案1用)
		///</summary>
		
		private List<string> inclusion_;
		
		///<summary>
		/// 不包含值 (方案2用)
		///</summary>
		
		private List<string> exclusion_;
		
		///<summary>
		/// 开始值 (方案3用)
		///</summary>
		
		private string begin_;
		
		///<summary>
		/// 结束值 (方案3用)
		///</summary>
		
		private string end_;
		
		///<summary>
		/// 开始包含开始值 (方案3用)
		///</summary>
		
		private bool? beginInclusive_;
		
		///<summary>
		/// 结束包含结束值 (方案3用)
		///</summary>
		
		private bool? endInclusive_;
		
		public List<string> GetInclusion(){
			return this.inclusion_;
		}
		
		public void SetInclusion(List<string> value){
			this.inclusion_ = value;
		}
		public List<string> GetExclusion(){
			return this.exclusion_;
		}
		
		public void SetExclusion(List<string> value){
			this.exclusion_ = value;
		}
		public string GetBegin(){
			return this.begin_;
		}
		
		public void SetBegin(string value){
			this.begin_ = value;
		}
		public string GetEnd(){
			return this.end_;
		}
		
		public void SetEnd(string value){
			this.end_ = value;
		}
		public bool? GetBeginInclusive(){
			return this.beginInclusive_;
		}
		
		public void SetBeginInclusive(bool? value){
			this.beginInclusive_ = value;
		}
		public bool? GetEndInclusive(){
			return this.endInclusive_;
		}
		
		public void SetEndInclusive(bool? value){
			this.endInclusive_ = value;
		}
		
	}
	
}