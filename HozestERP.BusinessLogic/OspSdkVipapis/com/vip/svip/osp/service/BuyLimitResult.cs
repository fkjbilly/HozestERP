using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class BuyLimitResult {
		
		///<summary>
		/// true:限购 false:不限购
		///</summary>
		
		private bool? limit_;
		
		///<summary>
		/// code 辅助编码
		///</summary>
		
		private int? code_;
		
		///<summary>
		/// msg
		///</summary>
		
		private string msg_;
		
		public bool? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(bool? value){
			this.limit_ = value;
		}
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
		
	}
	
}