using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.sizetable{
	
	
	
	
	
	public class SizeTableTemplate {
		
		///<summary>
		/// 尺码表模板名称
		///</summary>
		
		private string size_table_template_name_;
		
		///<summary>
		/// 对应尺码表ID
		///</summary>
		
		private long? size_table_id_;
		
		///<summary>
		/// 1：标准尺码表，2：自定义
		///</summary>
		
		private short? size_table_type_;
		
		///<summary>
		/// 删除标记(默认0，1已删除)
		///</summary>
		
		private short? del_flag_;
		
		///<summary>
		/// 尺码表模板id
		///</summary>
		
		private int? size_table_template_id_;
		
		public string GetSize_table_template_name(){
			return this.size_table_template_name_;
		}
		
		public void SetSize_table_template_name(string value){
			this.size_table_template_name_ = value;
		}
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
		public short? GetDel_flag(){
			return this.del_flag_;
		}
		
		public void SetDel_flag(short? value){
			this.del_flag_ = value;
		}
		public int? GetSize_table_template_id(){
			return this.size_table_template_id_;
		}
		
		public void SetSize_table_template_id(int? value){
			this.size_table_template_id_ = value;
		}
		
	}
	
}