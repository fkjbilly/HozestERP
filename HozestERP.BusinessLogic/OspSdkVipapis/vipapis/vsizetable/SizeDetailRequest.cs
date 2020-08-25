using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vsizetable{
	
	
	
	
	
	public class SizeDetailRequest {
		
		///<summary>
		/// 新增时无需填此字段，其它为必填
		///</summary>
		
		private long? sizedetail_id_;
		
		///<summary>
		/// 尺码表详情名称
		///</summary>
		
		private string sizedetail_name_;
		
		///<summary>
		/// 对应尺码表ID
		///</summary>
		
		private long? sizetable_id_;
		
		///<summary>
		/// 属性值 
		/// @sampleValue sizedetail_propertyvalues 袖长：35，肩宽：36
		///</summary>
		
		private Dictionary<string, string> sizedetail_propertyvalues_;
		
		///<summary>
		/// 尺码表详情序号，默认从0开始排序，传入此字段可进行尺码表详情的排序 
		///</summary>
		
		private int? size_detail_order_;
		
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
		public long? GetSizetable_id(){
			return this.sizetable_id_;
		}
		
		public void SetSizetable_id(long? value){
			this.sizetable_id_ = value;
		}
		public Dictionary<string, string> GetSizedetail_propertyvalues(){
			return this.sizedetail_propertyvalues_;
		}
		
		public void SetSizedetail_propertyvalues(Dictionary<string, string> value){
			this.sizedetail_propertyvalues_ = value;
		}
		public int? GetSize_detail_order(){
			return this.size_detail_order_;
		}
		
		public void SetSize_detail_order(int? value){
			this.size_detail_order_ = value;
		}
		
	}
	
}