using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetUnpayOrderReq {
		
		///<summary>
		/// 用户id列表
		///</summary>
		
		private List<long?> userIdList_;
		
		///<summary>
		/// 渠道列表
		///</summary>
		
		private List<string> vipclubList_;
		
		public List<long?> GetUserIdList(){
			return this.userIdList_;
		}
		
		public void SetUserIdList(List<long?> value){
			this.userIdList_ = value;
		}
		public List<string> GetVipclubList(){
			return this.vipclubList_;
		}
		
		public void SetVipclubList(List<string> value){
			this.vipclubList_ = value;
		}
		
	}
	
}