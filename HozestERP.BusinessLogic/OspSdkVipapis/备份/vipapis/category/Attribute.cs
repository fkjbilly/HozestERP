using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.category{
	
	
	
	
	
	public class Attribute {
		
		///<summary>
		/// 属性Id
		///</summary>
		
		private int? attriute_id_;
		
		///<summary>
		/// 属性名称
		///</summary>
		
		private string attribute_name_;
		
		///<summary>
		/// 属性名称外国名称，格式为JSON
		/// @sampleValue foreignname {"en":"Choice of Model"}
		///</summary>
		
		private string foreignname_;
		
		///<summary>
		/// 属性说明
		///</summary>
		
		private string description_;
		
		///<summary>
		/// 属性类型：自然属性/Tag属性/分类特有属性
		///</summary>
		
		private vipapis.category.AttributeType? attribute_type_;
		
		///<summary>
		/// 数据类型：文本/数值/选项
		///</summary>
		
		private vipapis.category.DataType? data_type_;
		
		///<summary>
		/// 数值单位
		///</summary>
		
		private string unit_;
		
		///<summary>
		/// 排序因子
		///</summary>
		
		private int? sort_;
		
		///<summary>
		/// 属性标记位,条件属性
		///</summary>
		
		private long? flags_;
		
		///<summary>
		/// 父属性ID，为0表示为独立属性，否则为依赖属性
		///</summary>
		
		private int? parent_attribute_id_;
		
		///<summary>
		/// 选项列表
		///</summary>
		
		private List<vipapis.category.Option> options_;
		
		public int? GetAttriute_id(){
			return this.attriute_id_;
		}
		
		public void SetAttriute_id(int? value){
			this.attriute_id_ = value;
		}
		public string GetAttribute_name(){
			return this.attribute_name_;
		}
		
		public void SetAttribute_name(string value){
			this.attribute_name_ = value;
		}
		public string GetForeignname(){
			return this.foreignname_;
		}
		
		public void SetForeignname(string value){
			this.foreignname_ = value;
		}
		public string GetDescription(){
			return this.description_;
		}
		
		public void SetDescription(string value){
			this.description_ = value;
		}
		public vipapis.category.AttributeType? GetAttribute_type(){
			return this.attribute_type_;
		}
		
		public void SetAttribute_type(vipapis.category.AttributeType? value){
			this.attribute_type_ = value;
		}
		public vipapis.category.DataType? GetData_type(){
			return this.data_type_;
		}
		
		public void SetData_type(vipapis.category.DataType? value){
			this.data_type_ = value;
		}
		public string GetUnit(){
			return this.unit_;
		}
		
		public void SetUnit(string value){
			this.unit_ = value;
		}
		public int? GetSort(){
			return this.sort_;
		}
		
		public void SetSort(int? value){
			this.sort_ = value;
		}
		public long? GetFlags(){
			return this.flags_;
		}
		
		public void SetFlags(long? value){
			this.flags_ = value;
		}
		public int? GetParent_attribute_id(){
			return this.parent_attribute_id_;
		}
		
		public void SetParent_attribute_id(int? value){
			this.parent_attribute_id_ = value;
		}
		public List<vipapis.category.Option> GetOptions(){
			return this.options_;
		}
		
		public void SetOptions(List<vipapis.category.Option> value){
			this.options_ = value;
		}
		
	}
	
}