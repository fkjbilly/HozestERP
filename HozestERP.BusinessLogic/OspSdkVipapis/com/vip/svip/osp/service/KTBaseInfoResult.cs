using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class KTBaseInfoResult {
		
		///<summary>
		/// code
		///</summary>
		
		private int? code_;
		
		///<summary>
		/// msg
		///</summary>
		
		private string msg_;
		
		///<summary>
		/// 数据
		///</summary>
		
		private com.vip.svip.osp.service.KTBaseInfo data_;
		
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
		public com.vip.svip.osp.service.KTBaseInfo GetData(){
			return this.data_;
		}
		
		public void SetData(com.vip.svip.osp.service.KTBaseInfo value){
			this.data_ = value;
		}
		
	}
	
}