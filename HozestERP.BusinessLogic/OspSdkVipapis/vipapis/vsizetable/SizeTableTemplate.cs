using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vsizetable{
	
	
	
	
	
	public class SizeTableTemplate {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 尺码表模板名称
		///</summary>
		
		private string sizetable_template_name_;
		
		///<summary>
		/// 对应尺码表ID
		///</summary>
		
		private long? sizetable_id_;
		
		///<summary>
		/// 1：标准尺码表，2：自定义
		///</summary>
		
		private short? sizetable_type_;
		
		///<summary>
		/// 删除标记(默认0，1已删除)
		///</summary>
		
		private short? del_flag_;
		
		///<summary>
		/// 尺码表模板id)
		///</summary>
		
		private int? sizetable_template_id_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetSizetable_template_name(){
			return this.sizetable_template_name_;
		}
		
		public void SetSizetable_template_name(string value){
			this.sizetable_template_name_ = value;
		}
		public long? GetSizetable_id(){
			return this.sizetable_id_;
		}
		
		public void SetSizetable_id(long? value){
			this.sizetable_id_ = value;
		}
		public short? GetSizetable_type(){
			return this.sizetable_type_;
		}
		
		public void SetSizetable_type(short? value){
			this.sizetable_type_ = value;
		}
		public short? GetDel_flag(){
			return this.del_flag_;
		}
		
		public void SetDel_flag(short? value){
			this.del_flag_ = value;
		}
		public int? GetSizetable_template_id(){
			return this.sizetable_template_id_;
		}
		
		public void SetSizetable_template_id(int? value){
			this.sizetable_template_id_ = value;
		}
		
	}
	
}