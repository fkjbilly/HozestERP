using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class SizeTable {
		
		///<summary>
		/// 尺码表id
		/// @sampleValue size_table_id 13092
		///</summary>
		
		private long? size_table_id_;
		
		///<summary>
		/// 尺码表类型
		/// @sampleValue size_table_type 类型，1：标准尺码表，2：非标准尺码表
		///</summary>
		
		private short? size_table_type_;
		
		///<summary>
		/// 标准尺码表明细
		/// @sampleValue size_table_detail 格式：<尺码,<属性,值>>(类型为1时取该值)
		///</summary>
		
		private Dictionary<string, Dictionary<string, string>> size_table_detail_;
		
		///<summary>
		/// 非标准尺码表
		/// @sampleValue size_table_html html代码(类型为2时取该值)
		///</summary>
		
		private string size_table_html_;
		
		public long? GetSize_table_id(){
			return this.size_table_id_;
		}
		
		public void SetSize_table_id(long? value){
			this.size_table_id_ = value;
		}
		public short? GetSize_table_type(){
			return this.size_table_type_;
		}
		
		public void SetSize_table_type(short? value){
			this.size_table_type_ = value;
		}
		public Dictionary<string, Dictionary<string, string>> GetSize_table_detail(){
			return this.size_table_detail_;
		}
		
		public void SetSize_table_detail(Dictionary<string, Dictionary<string, string>> value){
			this.size_table_detail_ = value;
		}
		public string GetSize_table_html(){
			return this.size_table_html_;
		}
		
		public void SetSize_table_html(string value){
			this.size_table_html_ = value;
		}
		
	}
	
}