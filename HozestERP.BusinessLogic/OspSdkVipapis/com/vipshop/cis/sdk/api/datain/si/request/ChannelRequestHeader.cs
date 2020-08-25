using System;
using System.Collections.Generic;
using System.Text;

namespace com.vipshop.cis.sdk.api.datain.si.request{
	
	
	
	
	
	public class ChannelRequestHeader {
		
		///<summary>
		/// 版本号
		/// @sampleValue version 1.0.2
		///</summary>
		
		private string version_;
		
		///<summary>
		/// 消费者
		///</summary>
		
		private string consumer_;
		
		///<summary>
		/// 消费者密码
		///</summary>
		
		private string token_;
		
		///<summary>
		/// 扩展信息,暂时未用
		///</summary>
		
		private Dictionary<string, string> extension_area_;
		
		///<summary>
		/// 本地信息,暂时未用
		///</summary>
		
		private Dictionary<string, string> local_area_;
		
		public string GetVersion(){
			return this.version_;
		}
		
		public void SetVersion(string value){
			this.version_ = value;
		}
		public string GetConsumer(){
			return this.consumer_;
		}
		
		public void SetConsumer(string value){
			this.consumer_ = value;
		}
		public string GetToken(){
			return this.token_;
		}
		
		public void SetToken(string value){
			this.token_ = value;
		}
		public Dictionary<string, string> GetExtension_area(){
			return this.extension_area_;
		}
		
		public void SetExtension_area(Dictionary<string, string> value){
			this.extension_area_ = value;
		}
		public Dictionary<string, string> GetLocal_area(){
			return this.local_area_;
		}
		
		public void SetLocal_area(Dictionary<string, string> value){
			this.local_area_ = value;
		}
		
	}
	
}