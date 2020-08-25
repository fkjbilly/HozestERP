using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.user{
	
	
	
	
	
	public class GroupInfo {
		
		///<summary>
		/// 用户群编码
		///</summary>
		
		private string group_code_;
		
		///<summary>
		/// 用户群名称,用于用户界面显示人群名称
		///</summary>
		
		private string group_name_;
		
		///<summary>
		/// 数据类型，3:IMEI/IDFA, 4:ID，IMEI/IDFA用于移动投放，ID用于PC投放，需与DSP做Cookie映射
		///</summary>
		
		private int? data_type_;
		
		///<summary>
		/// 用户人群数据的有效时间
		///</summary>
		
		private long? expire_time_;
		
		///<summary>
		/// 用户人群中的用户数量
		///</summary>
		
		private int? size_;
		
		///<summary>
		/// 用户人群的数据版本，格式：20161206121234（yyyyMMddHHmmss），<br>可读到的dataVer都是最新可用的数据版本，无可用数据时为空字符串。
		///</summary>
		
		private string data_version_;
		
		///<summary>
		/// 用户人群信息上一次更新时间
		///</summary>
		
		private long? last_updated_time_;
		
		public string GetGroup_code(){
			return this.group_code_;
		}
		
		public void SetGroup_code(string value){
			this.group_code_ = value;
		}
		public string GetGroup_name(){
			return this.group_name_;
		}
		
		public void SetGroup_name(string value){
			this.group_name_ = value;
		}
		public int? GetData_type(){
			return this.data_type_;
		}
		
		public void SetData_type(int? value){
			this.data_type_ = value;
		}
		public long? GetExpire_time(){
			return this.expire_time_;
		}
		
		public void SetExpire_time(long? value){
			this.expire_time_ = value;
		}
		public int? GetSize(){
			return this.size_;
		}
		
		public void SetSize(int? value){
			this.size_ = value;
		}
		public string GetData_version(){
			return this.data_version_;
		}
		
		public void SetData_version(string value){
			this.data_version_ = value;
		}
		public long? GetLast_updated_time(){
			return this.last_updated_time_;
		}
		
		public void SetLast_updated_time(long? value){
			this.last_updated_time_ = value;
		}
		
	}
	
}