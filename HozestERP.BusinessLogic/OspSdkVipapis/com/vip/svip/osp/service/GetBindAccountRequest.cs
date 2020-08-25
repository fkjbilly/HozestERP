using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class GetBindAccountRequest {
		
		///<summary>
		/// 唯品会用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 腾讯侧openId
		///</summary>
		
		private string openId_;
		
		///<summary>
		/// openId类型, 结合openId使用 1:qq类型 2:微信类型
		///</summary>
		
		private int? openIdType_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetOpenId(){
			return this.openId_;
		}
		
		public void SetOpenId(string value){
			this.openId_ = value;
		}
		public int? GetOpenIdType(){
			return this.openIdType_;
		}
		
		public void SetOpenIdType(int? value){
			this.openIdType_ = value;
		}
		
	}
	
}