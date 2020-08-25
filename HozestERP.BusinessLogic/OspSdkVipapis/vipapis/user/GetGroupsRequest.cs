using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.user{
	
	
	
	
	
	public class GetGroupsRequest {
		
		///<summary>
		/// DSP供应商在DMP系统中的注册码
		///</summary>
		
		private string dsp_code_;
		
		///<summary>
		/// 页数，从1开始
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 页大小，最大100
		///</summary>
		
		private int? limit_;
		
		public string GetDsp_code(){
			return this.dsp_code_;
		}
		
		public void SetDsp_code(string value){
			this.dsp_code_ = value;
		}
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		public int? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(int? value){
			this.limit_ = value;
		}
		
	}
	
}