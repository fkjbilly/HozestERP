using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.merchModel.service{
	
	
	
	
	
	public class Jd3dModelInfo {
		
		///<summary>
		/// url
		///</summary>
		
		private string url_;
		
		///<summary>
		/// cost
		///</summary>
		
		private double? cost_;
		
		public string GetUrl(){
			return this.url_;
		}
		
		public void SetUrl(string value){
			this.url_ = value;
		}
		public double? GetCost(){
			return this.cost_;
		}
		
		public void SetCost(double? value){
			this.cost_ = value;
		}
		
	}
	
}