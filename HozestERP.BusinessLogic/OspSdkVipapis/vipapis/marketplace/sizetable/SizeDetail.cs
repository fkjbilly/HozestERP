using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.sizetable{
	
	
	
	
	
	public class SizeDetail {
		
		///<summary>
		/// 尺码表ID
		///</summary>
		
		private long? size_table_id_;
		
		///<summary>
		/// 尺码表详情Id
		///</summary>
		
		private long? size_detail_id_;
		
		///<summary>
		/// 尺码表详情名称
		///</summary>
		
		private string size_detail_name_;
		
		///<summary>
		/// 属性值
		/// @sampleValue size_detail_properties 袖长：35，肩宽：36
		///</summary>
		
		private Dictionary<string, string> size_detail_properties_;
		
		///<summary>
		/// 删除标记(默认0，1已删除)
		///</summary>
		
		private short? del_flag_;
		
		public long? GetSize_table_id(){
			return this.size_table_id_;
		}
		
		public void SetSize_table_id(long? value){
			this.size_table_id_ = value;
		}
		public long? GetSize_detail_id(){
			return this.size_detail_id_;
		}
		
		public void SetSize_detail_id(long? value){
			this.size_detail_id_ = value;
		}
		public string GetSize_detail_name(){
			return this.size_detail_name_;
		}
		
		public void SetSize_detail_name(string value){
			this.size_detail_name_ = value;
		}
		public Dictionary<string, string> GetSize_detail_properties(){
			return this.size_detail_properties_;
		}
		
		public void SetSize_detail_properties(Dictionary<string, string> value){
			this.size_detail_properties_ = value;
		}
		public short? GetDel_flag(){
			return this.del_flag_;
		}
		
		public void SetDel_flag(short? value){
			this.del_flag_ = value;
		}
		
	}
	
}