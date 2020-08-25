using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.merchModel.service{
	
	
	
	
	
	public class Jd3dModelSyncResponse {
		
		///<summary>
		/// retCode
		///</summary>
		
		private int? retCode_;
		
		///<summary>
		/// errMsg
		///</summary>
		
		private string errMsg_;
		
		///<summary>
		/// 所有同步成功的mid
		///</summary>
		
		private List<string> mids_;
		
		public int? GetRetCode(){
			return this.retCode_;
		}
		
		public void SetRetCode(int? value){
			this.retCode_ = value;
		}
		public string GetErrMsg(){
			return this.errMsg_;
		}
		
		public void SetErrMsg(string value){
			this.errMsg_ = value;
		}
		public List<string> GetMids(){
			return this.mids_;
		}
		
		public void SetMids(List<string> value){
			this.mids_ = value;
		}
		
	}
	
}