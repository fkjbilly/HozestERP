using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.face.service{
	
	
	
	
	
	public class CompareResult {
		
		///<summary>
		/// 图片相似度比较结果中对应的url
		///</summary>
		
		private string url_;
		
		///<summary>
		/// 图片相似度比较结果中对应的相似度值
		///</summary>
		
		private double? confidence_;
		
		public string GetUrl(){
			return this.url_;
		}
		
		public void SetUrl(string value){
			this.url_ = value;
		}
		public double? GetConfidence(){
			return this.confidence_;
		}
		
		public void SetConfidence(double? value){
			this.confidence_ = value;
		}
		
	}
	
}