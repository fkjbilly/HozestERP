using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.category{
	
	
	
	
	
	public class Option {
		
		///<summary>
		/// 属性ID
		///</summary>
		
		private int? attributeId_;
		
		///<summary>
		/// 选项ID
		///</summary>
		
		private int? optionId_;
		
		///<summary>
		/// 选项名称
		///</summary>
		
		private string name_;
		
		///<summary>
		/// 选项描述
		///</summary>
		
		private string description_;
		
		///<summary>
		/// 选项分组
		///</summary>
		
		private string hierarchyGroup_;
		
		///<summary>
		/// 排序因子
		///</summary>
		
		private int? sort_;
		
		///<summary>
		/// 父选项ID，为0表示都独立选项，否则为依赖选项
		///</summary>
		
		private int? parentOptionId_;
		
		///<summary>
		/// 是否为虚拟选项，虚拟选型是多个其它选型的聚合
		///</summary>
		
		private bool? isVirtual_;
		
		///<summary>
		/// 如果是虚拟选项，这里是其它需要聚合的多个选项
		///</summary>
		
		private List<int?> realOptions_;
		
		///<summary>
		/// 选项名称外国名称，格式为JSON
		/// @sampleValue foreignname {"en":"Model 3"}
		///</summary>
		
		private string foreignname_;
		
		///<summary>
		/// 选项外部信息，格式为JSON
		///</summary>
		
		private string externaldata_;
		
		public int? GetAttributeId(){
			return this.attributeId_;
		}
		
		public void SetAttributeId(int? value){
			this.attributeId_ = value;
		}
		public int? GetOptionId(){
			return this.optionId_;
		}
		
		public void SetOptionId(int? value){
			this.optionId_ = value;
		}
		public string GetName(){
			return this.name_;
		}
		
		public void SetName(string value){
			this.name_ = value;
		}
		public string GetDescription(){
			return this.description_;
		}
		
		public void SetDescription(string value){
			this.description_ = value;
		}
		public string GetHierarchyGroup(){
			return this.hierarchyGroup_;
		}
		
		public void SetHierarchyGroup(string value){
			this.hierarchyGroup_ = value;
		}
		public int? GetSort(){
			return this.sort_;
		}
		
		public void SetSort(int? value){
			this.sort_ = value;
		}
		public int? GetParentOptionId(){
			return this.parentOptionId_;
		}
		
		public void SetParentOptionId(int? value){
			this.parentOptionId_ = value;
		}
		public bool? GetIsVirtual(){
			return this.isVirtual_;
		}
		
		public void SetIsVirtual(bool? value){
			this.isVirtual_ = value;
		}
		public List<int?> GetRealOptions(){
			return this.realOptions_;
		}
		
		public void SetRealOptions(List<int?> value){
			this.realOptions_ = value;
		}
		public string GetForeignname(){
			return this.foreignname_;
		}
		
		public void SetForeignname(string value){
			this.foreignname_ = value;
		}
		public string GetExternaldata(){
			return this.externaldata_;
		}
		
		public void SetExternaldata(string value){
			this.externaldata_ = value;
		}
		
	}
	
}