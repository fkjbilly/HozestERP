using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.face.service{
	
	
	
	
	
	public class GetSearchWithFeaturesParamResultModel {
		
		///<summary>
		/// 请求唯一token
		///</summary>
		
		private string token_;
		
		public string GetToken(){
			return this.token_;
		}
		
		public void SetToken(string value){
			this.token_ = value;
		}
		
	}
	
}