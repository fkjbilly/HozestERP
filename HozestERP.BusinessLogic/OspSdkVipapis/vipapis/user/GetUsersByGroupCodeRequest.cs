using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.user{
	
	
	
	
	
	public class GetUsersByGroupCodeRequest {
		
		///<summary>
		/// DSP供应商在DMP系统中的注册码
		///</summary>
		
		private string dsp_code_;
		
		///<summary>
		/// 用户人群编码
		///</summary>
		
		private string group_code_;
		
		///<summary>
		/// 用户人群数据版本
		///</summary>
		
		private string data_version_;
		
		///<summary>
		/// 起始位置，默认从1开始
		///</summary>
		
		private int? start_;
		
		///<summary>
		/// 一次获取数量，最大不可超过1000，默认1000
		///</summary>
		
		private int? offset_;
		
		///<summary>
		/// 加密类型: <br>0:先MD5加密; <br> 1:先转为大写字母，MD5加密;<br> 2:先转为小写字母，MD5加密;<br>3: 先sha1加密 <br> 4: 先转为大写字母，然后sha1加密<br>5: 先转为小写字母，然后sha1加密 
		///</summary>
		
		private int? encrypt_type_;
		
		public string GetDsp_code(){
			return this.dsp_code_;
		}
		
		public void SetDsp_code(string value){
			this.dsp_code_ = value;
		}
		public string GetGroup_code(){
			return this.group_code_;
		}
		
		public void SetGroup_code(string value){
			this.group_code_ = value;
		}
		public string GetData_version(){
			return this.data_version_;
		}
		
		public void SetData_version(string value){
			this.data_version_ = value;
		}
		public int? GetStart(){
			return this.start_;
		}
		
		public void SetStart(int? value){
			this.start_ = value;
		}
		public int? GetOffset(){
			return this.offset_;
		}
		
		public void SetOffset(int? value){
			this.offset_ = value;
		}
		public int? GetEncrypt_type(){
			return this.encrypt_type_;
		}
		
		public void SetEncrypt_type(int? value){
			this.encrypt_type_ = value;
		}
		
	}
	
}