using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.data.compass.service.vop{
	
	
	
	
	
	public class CompassDataResponse {
		
		///<summary>
		/// 请求返回的状态码
		///</summary>
		
		private string code_;
		
		///<summary>
		/// 响应状态信息
		///</summary>
		
		private string msg_;
		
		///<summary>
		/// 数据
		///</summary>
		
		private List<Dictionary<string, string>> data_;
		
		public string GetCode(){
			return this.code_;
		}
		
		public void SetCode(string value){
			this.code_ = value;
		}
		public string GetMsg(){
			return this.msg_;
		}
		
		public void SetMsg(string value){
			this.msg_ = value;
		}
		public List<Dictionary<string, string>> GetData(){
			return this.data_;
		}
		
		public void SetData(List<Dictionary<string, string>> value){
			this.data_ = value;
		}
		
	}
	
}