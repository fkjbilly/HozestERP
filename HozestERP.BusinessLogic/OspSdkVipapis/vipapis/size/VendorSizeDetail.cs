using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.size{
	
	
	
	
	
	public class VendorSizeDetail {
		
		///<summary>
		/// 新增时无次字段，其它为必填
		///</summary>
		
		private long? sizedetail_id_;
		
		///<summary>
		/// 尺码表详情名称
		///</summary>
		
		private string sizedetail_name_;
		
		///<summary>
		/// 属性值 （示例：袖长：35，肩宽：36）
		///</summary>
		
		private Dictionary<string, string> sizedetail_propertyvalues_;
		
		public long? GetSizedetail_id(){
			return this.sizedetail_id_;
		}
		
		public void SetSizedetail_id(long? value){
			this.sizedetail_id_ = value;
		}
		public string GetSizedetail_name(){
			return this.sizedetail_name_;
		}
		
		public void SetSizedetail_name(string value){
			this.sizedetail_name_ = value;
		}
		public Dictionary<string, string> GetSizedetail_propertyvalues(){
			return this.sizedetail_propertyvalues_;
		}
		
		public void SetSizedetail_propertyvalues(Dictionary<string, string> value){
			this.sizedetail_propertyvalues_ = value;
		}
		
	}
	
}