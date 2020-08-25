using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.face.service{
	
	
	
	
	
	public class CompareResponse {
		
		///<summary>
		/// request/response token
		///</summary>
		
		private string token_;
		
		///<summary>
		/// 相似度比较结果列表
		///</summary>
		
		private List<com.vip.arplatform.face.service.CompareResult> resultList_;
		
		public string GetToken(){
			return this.token_;
		}
		
		public void SetToken(string value){
			this.token_ = value;
		}
		public List<com.vip.arplatform.face.service.CompareResult> GetResultList(){
			return this.resultList_;
		}
		
		public void SetResultList(List<com.vip.arplatform.face.service.CompareResult> value){
			this.resultList_ = value;
		}
		
	}
	
}