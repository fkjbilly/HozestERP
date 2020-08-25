using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class TxGetSvipTokenResult {
		
		///<summary>
		/// code
		///</summary>
		
		private int? code_;
		
		///<summary>
		/// msg
		///</summary>
		
		private string msg_;
		
		///<summary>
		/// accessToken
		///</summary>
		
		private string accessToken_;
		
		public int? GetCode(){
			return this.code_;
		}
		
		public void SetCode(int? value){
			this.code_ = value;
		}
		public string GetMsg(){
			return this.msg_;
		}
		
		public void SetMsg(string value){
			this.msg_ = value;
		}
		public string GetAccessToken(){
			return this.accessToken_;
		}
		
		public void SetAccessToken(string value){
			this.accessToken_ = value;
		}
		
	}
	
}