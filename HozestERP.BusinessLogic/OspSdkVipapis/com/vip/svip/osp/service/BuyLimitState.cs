using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class BuyLimitState {
		
		///<summary>
		/// true:限购 false:不限购
		///</summary>
		
		private bool? limit_;
		
		///<summary>
		/// 辅助编码
		///</summary>
		
		private int? limitState_;
		
		///<summary>
		/// msg
		///</summary>
		
		private string limitMsg_;
		
		///<summary>
		/// 会员状态
		///</summary>
		
		private int? userStatus_;
		
		public bool? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(bool? value){
			this.limit_ = value;
		}
		public int? GetLimitState(){
			return this.limitState_;
		}
		
		public void SetLimitState(int? value){
			this.limitState_ = value;
		}
		public string GetLimitMsg(){
			return this.limitMsg_;
		}
		
		public void SetLimitMsg(string value){
			this.limitMsg_ = value;
		}
		public int? GetUserStatus(){
			return this.userStatus_;
		}
		
		public void SetUserStatus(int? value){
			this.userStatus_ = value;
		}
		
	}
	
}