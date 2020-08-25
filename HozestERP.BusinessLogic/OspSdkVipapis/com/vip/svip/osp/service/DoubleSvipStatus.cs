using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class DoubleSvipStatus {
		
		///<summary>
		/// 用户能否加入svip的返回码
		///</summary>
		
		private int? code_;
		
		///<summary>
		///</summary>
		
		private string msg_;
		
		///<summary>
		/// 提供给腾讯创建svip的access token，code为能加入时才有效
		///</summary>
		
		private com.vip.svip.osp.service.DoubleSvipToken token_;
		
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
		public com.vip.svip.osp.service.DoubleSvipToken GetToken(){
			return this.token_;
		}
		
		public void SetToken(com.vip.svip.osp.service.DoubleSvipToken value){
			this.token_ = value;
		}
		
	}
	
}