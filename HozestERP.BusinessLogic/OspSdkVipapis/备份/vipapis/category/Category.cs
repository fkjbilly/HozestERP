using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.category{
	
	
	
	
	
	public class Category {
		
		///<summary>
		/// 分类ID
		///</summary>
		
		private int? category_id_;
		
		///<summary>
		/// 分类名称
		///</summary>
		
		private string category_name_;
		
		///<summary>
		/// 分类名称外国名称，格式为JSON
		/// @sampleValue foreignname {"en":"Anti-fatigue"}
		///</summary>
		
		private string foreignname_;
		
		///<summary>
		/// 分类描述
		///</summary>
		
		private string description_;
		
		///<summary>
		/// 分类类型
		///</summary>
		
		private vipapis.category.CategoryType? category_type_;
		
		///<summary>
		/// 关键字
		///</summary>
		
		private string keywords_;
		
		///<summary>
		/// 标记位，用于后续扩展属性
		///</summary>
		
		private long? flags_;
		
		///<summary>
		/// 展示导航ID
		///</summary>
		
		private int? hierarchy_id_;
		
		///<summary>
		/// 最后变更时间, 获取变更的节点接口使用
		///</summary>
		
		private long? last_updatetime_;
		
		///<summary>
		/// 相关分类
		///</summary>
		
		private List<int?> related_categories_;
		
		///<summary>
		/// 子分类
		///</summary>
		
		private List<vipapis.category.Category> children_;
		
		///<summary>
		/// 分类映射
		///</summary>
		
		private List<vipapis.category.CategoryMapping> mapping_;
		
		///<summary>
		/// 主父分类
		///</summary>
		
		private int? major_parent_category_id_;
		
		///<summary>
		/// 非主父分类
		///</summary>
		
		private List<int?> salve_parent_category_ids_;
		
		///<summary>
		/// 分类属性
		///</summary>
		
		private List<vipapis.category.Attribute> attributes_;
		
		public int? GetCategory_id(){
			return this.category_id_;
		}
		
		public void SetCategory_id(int? value){
			this.category_id_ = value;
		}
		public string GetCategory_name(){
			return this.category_name_;
		}
		
		public void SetCategory_name(string value){
			this.category_name_ = value;
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
		public vipapis.category.CategoryType? GetCategory_type(){
			return this.category_type_;
		}
		
		public void SetCategory_type(vipapis.category.CategoryType? value){
			this.category_type_ = value;
		}
		public string GetKeywords(){
			return this.keywords_;
		}
		
		public void SetKeywords(string value){
			this.keywords_ = value;
		}
		public long? GetFlags(){
			return this.flags_;
		}
		
		public void SetFlags(long? value){
			this.flags_ = value;
		}
		public int? GetHierarchy_id(){
			return this.hierarchy_id_;
		}
		
		public void SetHierarchy_id(int? value){
			this.hierarchy_id_ = value;
		}
		public long? GetLast_updatetime(){
			return this.last_updatetime_;
		}
		
		public void SetLast_updatetime(long? value){
			this.last_updatetime_ = value;
		}
		public List<int?> GetRelated_categories(){
			return this.related_categories_;
		}
		
		public void SetRelated_categories(List<int?> value){
			this.related_categories_ = value;
		}
		public List<vipapis.category.Category> GetChildren(){
			return this.children_;
		}
		
		public void SetChildren(List<vipapis.category.Category> value){
			this.children_ = value;
		}
		public List<vipapis.category.CategoryMapping> GetMapping(){
			return this.mapping_;
		}
		
		public void SetMapping(List<vipapis.category.CategoryMapping> value){
			this.mapping_ = value;
		}
		public int? GetMajor_parent_category_id(){
			return this.major_parent_category_id_;
		}
		
		public void SetMajor_parent_category_id(int? value){
			this.major_parent_category_id_ = value;
		}
		public List<int?> GetSalve_parent_category_ids(){
			return this.salve_parent_category_ids_;
		}
		
		public void SetSalve_parent_category_ids(List<int?> value){
			this.salve_parent_category_ids_ = value;
		}
		public List<vipapis.category.Attribute> GetAttributes(){
			return this.attributes_;
		}
		
		public void SetAttributes(List<vipapis.category.Attribute> value){
			this.attributes_ = value;
		}
		
	}
	
}