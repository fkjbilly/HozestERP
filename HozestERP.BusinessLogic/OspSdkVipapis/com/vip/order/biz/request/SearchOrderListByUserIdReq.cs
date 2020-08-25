using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class SearchOrderListByUserIdReq {
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 搜索关键字
		///</summary>
		
		private string keyword_;
		
		///<summary>
		/// 售卖频道(vipclub) 订单频道来源
		///</summary>
		
		private List<string> vipclubList_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetKeyword(){
			return this.keyword_;
		}
		
		public void SetKeyword(string value){
			this.keyword_ = value;
		}
		public List<string> GetVipclubList(){
			return this.vipclubList_;
		}
		
		public void SetVipclubList(List<string> value){
			this.vipclubList_ = value;
		}
		
	}
	
}