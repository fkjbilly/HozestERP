using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class PrintTemplateResponse {
		
		///<summary>
		/// md5加密html代码
		/// @sampleValue partOrderLists 
		///</summary>
		
		private List<string> partOrderLists_;
		
		///<summary>
		/// 内单模板的HTML代码
		/// @sampleValue allPrintHtml 
		///</summary>
		
		private string allPrintHtml_;
		
		public List<string> GetPartOrderLists(){
			return this.partOrderLists_;
		}
		
		public void SetPartOrderLists(List<string> value){
			this.partOrderLists_ = value;
		}
		public string GetAllPrintHtml(){
			return this.allPrintHtml_;
		}
		
		public void SetAllPrintHtml(string value){
			this.allPrintHtml_ = value;
		}
		
	}
	
}