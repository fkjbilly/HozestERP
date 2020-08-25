using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vsizetable{
	
	
	
	
	
	public class SizeTableInfo {
		
		///<summary>
		/// 新增时为次字段，其它为必填
		///</summary>
		
		private long? sizetable_id_;
		
		///<summary>
		/// 1：标准尺码表，2：自定义
		///</summary>
		
		private short? sizetable_type_;
		
		///<summary>
		/// Html内容，类型为2时有效
		///</summary>
		
		private string sizetable_html_;
		
		///<summary>
		/// 温馨提示，类型为1时有效
		///</summary>
		
		private string sizetable_tips_;
		
		///<summary>
		/// 删除标记(默认0，1已删除)
		///</summary>
		
		private short? delFlag_;
		
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
		public string GetSizetable_html(){
			return this.sizetable_html_;
		}
		
		public void SetSizetable_html(string value){
			this.sizetable_html_ = value;
		}
		public string GetSizetable_tips(){
			return this.sizetable_tips_;
		}
		
		public void SetSizetable_tips(string value){
			this.sizetable_tips_ = value;
		}
		public short? GetDelFlag(){
			return this.delFlag_;
		}
		
		public void SetDelFlag(short? value){
			this.delFlag_ = value;
		}
		
	}
	
}