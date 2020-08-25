using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.category{
	
	
	public class CategoryServiceHelper {
		
		
		
		public class getAttributes_args {
			
			///<summary>
			/// 分类ID
			/// @sampleValue category_id 112
			///</summary>
			
			private int? category_id_;
			
			///<summary>
			/// 属性串
			/// @sampleValue attr_text 1:100;2:200|201
			///</summary>
			
			private string attr_text_;
			
			public int? GetCategory_id(){
				return this.category_id_;
			}
			
			public void SetCategory_id(int? value){
				this.category_id_ = value;
			}
			public string GetAttr_text(){
				return this.attr_text_;
			}
			
			public void SetAttr_text(string value){
				this.attr_text_ = value;
			}
			
		}
		
		
		
		
		public class getCategoryAttributeListById_args {
			
			///<summary>
			/// 分类ID
			///</summary>
			
			private int? category_id_;
			
			///<summary>
			/// 是否包含子级类目，默认为false
			/// @sampleValue is_include_children false
			///</summary>
			
			private bool? is_include_children_;
			
			public int? GetCategory_id(){
				return this.category_id_;
			}
			
			public void SetCategory_id(int? value){
				this.category_id_ = value;
			}
			public bool? GetIs_include_children(){
				return this.is_include_children_;
			}
			
			public void SetIs_include_children(bool? value){
				this.is_include_children_ = value;
			}
			
		}
		
		
		
		
		public class getCategoryById_args {
			
			///<summary>
			/// 分类ID
			///</summary>
			
			private int? category_id_;
			
			public int? GetCategory_id(){
				return this.category_id_;
			}
			
			public void SetCategory_id(int? value){
				this.category_id_ = value;
			}
			
		}
		
		
		
		
		public class getCategoryListByName_args {
			
			///<summary>
			/// 分类名称
			///</summary>
			
			private string category_name_;
			
			///<summary>
			/// 限制最大返回数量,为0,返回所有匹配的记录数;大于0,返回匹配的limit条记录数
			///</summary>
			
			private int? limit_;
			
			///<summary>
			/// 是否只查leaf类目
			///</summary>
			
			private bool? only_leaf_;
			
			public string GetCategory_name(){
				return this.category_name_;
			}
			
			public void SetCategory_name(string value){
				this.category_name_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			public bool? GetOnly_leaf(){
				return this.only_leaf_;
			}
			
			public void SetOnly_leaf(bool? value){
				this.only_leaf_ = value;
			}
			
		}
		
		
		
		
		public class getCategoryTreeById_args {
			
			///<summary>
			/// 分类ID，输入0时返回整棵类目结构
			///</summary>
			
			private int? category_id_;
			
			public int? GetCategory_id(){
				return this.category_id_;
			}
			
			public void SetCategory_id(int? value){
				this.category_id_ = value;
			}
			
		}
		
		
		
		
		public class getUpdatedCategoryList_args {
			
			///<summary>
			/// 变更开始时间
			///</summary>
			
			private long? since_updatetime_;
			
			///<summary>
			/// 导航ID,hierarchyid=0 录入导航 ;hierarchyid>0 展示导航
			/// @sampleValue hierarchyId hierarchyId=0
			///</summary>
			
			private int? hierarchyId_;
			
			public long? GetSince_updatetime(){
				return this.since_updatetime_;
			}
			
			public void SetSince_updatetime(long? value){
				this.since_updatetime_ = value;
			}
			public int? GetHierarchyId(){
				return this.hierarchyId_;
			}
			
			public void SetHierarchyId(int? value){
				this.hierarchyId_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class uploadVendorCategory_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 供应商类目表名称
			///</summary>
			
			private string vendor_category_tree_name_;
			
			///<summary>
			/// 类目属性名称
			///</summary>
			
			private List<vipapis.category.VendorCategory> vendor_categories_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetVendor_category_tree_name(){
				return this.vendor_category_tree_name_;
			}
			
			public void SetVendor_category_tree_name(string value){
				this.vendor_category_tree_name_ = value;
			}
			public List<vipapis.category.VendorCategory> GetVendor_categories(){
				return this.vendor_categories_;
			}
			
			public void SetVendor_categories(List<vipapis.category.VendorCategory> value){
				this.vendor_categories_ = value;
			}
			
		}
		
		
		
		
		public class getAttributes_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.category.Attribute> success_;
			
			public List<vipapis.category.Attribute> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.category.Attribute> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCategoryAttributeListById_result {
			
			///<summary>
			/// 
			///</summary>
			
			private List<vipapis.category.Attribute> success_;
			
			public List<vipapis.category.Attribute> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.category.Attribute> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCategoryById_result {
			
			///<summary>
			///</summary>
			
			private vipapis.category.Category success_;
			
			public vipapis.category.Category GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.category.Category value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCategoryListByName_result {
			
			///<summary>
			/// 
			///</summary>
			
			private List<vipapis.category.Category> success_;
			
			public List<vipapis.category.Category> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.category.Category> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCategoryTreeById_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.category.Category> success_;
			
			public List<vipapis.category.Category> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.category.Category> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getUpdatedCategoryList_result {
			
			///<summary>
			///</summary>
			
			private vipapis.category.CategoryUpdates success_;
			
			public vipapis.category.CategoryUpdates GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.category.CategoryUpdates value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_result {
			
			///<summary>
			///</summary>
			
			private com.vip.hermes.core.health.CheckResult success_;
			
			public com.vip.hermes.core.health.CheckResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.hermes.core.health.CheckResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class uploadVendorCategory_result {
			
			///<summary>
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class getAttributes_argsHelper : TBeanSerializer<getAttributes_args>
		{
			
			public static getAttributes_argsHelper OBJ = new getAttributes_argsHelper();
			
			public static getAttributes_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getAttributes_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetCategory_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetAttr_text(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getAttributes_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCategory_id() != null) {
					
					oprot.WriteFieldBegin("category_id");
					oprot.WriteI32((int)structs.GetCategory_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("category_id can not be null!");
				}
				
				
				if(structs.GetAttr_text() != null) {
					
					oprot.WriteFieldBegin("attr_text");
					oprot.WriteString(structs.GetAttr_text());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("attr_text can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getAttributes_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCategoryAttributeListById_argsHelper : TBeanSerializer<getCategoryAttributeListById_args>
		{
			
			public static getCategoryAttributeListById_argsHelper OBJ = new getCategoryAttributeListById_argsHelper();
			
			public static getCategoryAttributeListById_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCategoryAttributeListById_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetCategory_id(value);
				}
				
				
				
				
				
				if(true){
					
					bool? value;
					value = iprot.ReadBool();
					
					structs.SetIs_include_children(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCategoryAttributeListById_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCategory_id() != null) {
					
					oprot.WriteFieldBegin("category_id");
					oprot.WriteI32((int)structs.GetCategory_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("category_id can not be null!");
				}
				
				
				if(structs.GetIs_include_children() != null) {
					
					oprot.WriteFieldBegin("is_include_children");
					oprot.WriteBool((bool)structs.GetIs_include_children());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCategoryAttributeListById_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCategoryById_argsHelper : TBeanSerializer<getCategoryById_args>
		{
			
			public static getCategoryById_argsHelper OBJ = new getCategoryById_argsHelper();
			
			public static getCategoryById_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCategoryById_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetCategory_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCategoryById_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCategory_id() != null) {
					
					oprot.WriteFieldBegin("category_id");
					oprot.WriteI32((int)structs.GetCategory_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("category_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCategoryById_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCategoryListByName_argsHelper : TBeanSerializer<getCategoryListByName_args>
		{
			
			public static getCategoryListByName_argsHelper OBJ = new getCategoryListByName_argsHelper();
			
			public static getCategoryListByName_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCategoryListByName_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCategory_name(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				
				if(true){
					
					bool? value;
					value = iprot.ReadBool();
					
					structs.SetOnly_leaf(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCategoryListByName_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCategory_name() != null) {
					
					oprot.WriteFieldBegin("category_name");
					oprot.WriteString(structs.GetCategory_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("category_name can not be null!");
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("limit can not be null!");
				}
				
				
				if(structs.GetOnly_leaf() != null) {
					
					oprot.WriteFieldBegin("only_leaf");
					oprot.WriteBool((bool)structs.GetOnly_leaf());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCategoryListByName_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCategoryTreeById_argsHelper : TBeanSerializer<getCategoryTreeById_args>
		{
			
			public static getCategoryTreeById_argsHelper OBJ = new getCategoryTreeById_argsHelper();
			
			public static getCategoryTreeById_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCategoryTreeById_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetCategory_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCategoryTreeById_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCategory_id() != null) {
					
					oprot.WriteFieldBegin("category_id");
					oprot.WriteI32((int)structs.GetCategory_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("category_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCategoryTreeById_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUpdatedCategoryList_argsHelper : TBeanSerializer<getUpdatedCategoryList_args>
		{
			
			public static getUpdatedCategoryList_argsHelper OBJ = new getUpdatedCategoryList_argsHelper();
			
			public static getUpdatedCategoryList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUpdatedCategoryList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSince_updatetime(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetHierarchyId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUpdatedCategoryList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSince_updatetime() != null) {
					
					oprot.WriteFieldBegin("since_updatetime");
					oprot.WriteI64((long)structs.GetSince_updatetime()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("since_updatetime can not be null!");
				}
				
				
				if(structs.GetHierarchyId() != null) {
					
					oprot.WriteFieldBegin("hierarchyId");
					oprot.WriteI32((int)structs.GetHierarchyId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("hierarchyId can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUpdatedCategoryList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_argsHelper : TBeanSerializer<healthCheck_args>
		{
			
			public static healthCheck_argsHelper OBJ = new healthCheck_argsHelper();
			
			public static healthCheck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadVendorCategory_argsHelper : TBeanSerializer<uploadVendorCategory_args>
		{
			
			public static uploadVendorCategory_argsHelper OBJ = new uploadVendorCategory_argsHelper();
			
			public static uploadVendorCategory_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadVendorCategory_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_category_tree_name(value);
				}
				
				
				
				
				
				if(true){
					
					List<vipapis.category.VendorCategory> value;
					
					value = new List<vipapis.category.VendorCategory>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.category.VendorCategory elem0;
							
							elem0 = new vipapis.category.VendorCategory();
							vipapis.category.VendorCategoryHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetVendor_categories(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadVendorCategory_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetVendor_category_tree_name() != null) {
					
					oprot.WriteFieldBegin("vendor_category_tree_name");
					oprot.WriteString(structs.GetVendor_category_tree_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_category_tree_name can not be null!");
				}
				
				
				if(structs.GetVendor_categories() != null) {
					
					oprot.WriteFieldBegin("vendor_categories");
					
					oprot.WriteListBegin();
					foreach(vipapis.category.VendorCategory _item0 in structs.GetVendor_categories()){
						
						
						vipapis.category.VendorCategoryHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_categories can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadVendorCategory_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getAttributes_resultHelper : TBeanSerializer<getAttributes_result>
		{
			
			public static getAttributes_resultHelper OBJ = new getAttributes_resultHelper();
			
			public static getAttributes_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getAttributes_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.category.Attribute> value;
					
					value = new List<vipapis.category.Attribute>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.category.Attribute elem1;
							
							elem1 = new vipapis.category.Attribute();
							vipapis.category.AttributeHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getAttributes_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.category.Attribute _item0 in structs.GetSuccess()){
						
						
						vipapis.category.AttributeHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getAttributes_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCategoryAttributeListById_resultHelper : TBeanSerializer<getCategoryAttributeListById_result>
		{
			
			public static getCategoryAttributeListById_resultHelper OBJ = new getCategoryAttributeListById_resultHelper();
			
			public static getCategoryAttributeListById_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCategoryAttributeListById_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.category.Attribute> value;
					
					value = new List<vipapis.category.Attribute>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.category.Attribute elem1;
							
							elem1 = new vipapis.category.Attribute();
							vipapis.category.AttributeHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCategoryAttributeListById_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.category.Attribute _item0 in structs.GetSuccess()){
						
						
						vipapis.category.AttributeHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCategoryAttributeListById_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCategoryById_resultHelper : TBeanSerializer<getCategoryById_result>
		{
			
			public static getCategoryById_resultHelper OBJ = new getCategoryById_resultHelper();
			
			public static getCategoryById_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCategoryById_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.category.Category value;
					
					value = new vipapis.category.Category();
					vipapis.category.CategoryHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCategoryById_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.category.CategoryHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCategoryById_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCategoryListByName_resultHelper : TBeanSerializer<getCategoryListByName_result>
		{
			
			public static getCategoryListByName_resultHelper OBJ = new getCategoryListByName_resultHelper();
			
			public static getCategoryListByName_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCategoryListByName_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.category.Category> value;
					
					value = new List<vipapis.category.Category>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.category.Category elem0;
							
							elem0 = new vipapis.category.Category();
							vipapis.category.CategoryHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCategoryListByName_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.category.Category _item0 in structs.GetSuccess()){
						
						
						vipapis.category.CategoryHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCategoryListByName_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCategoryTreeById_resultHelper : TBeanSerializer<getCategoryTreeById_result>
		{
			
			public static getCategoryTreeById_resultHelper OBJ = new getCategoryTreeById_resultHelper();
			
			public static getCategoryTreeById_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCategoryTreeById_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.category.Category> value;
					
					value = new List<vipapis.category.Category>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.category.Category elem1;
							
							elem1 = new vipapis.category.Category();
							vipapis.category.CategoryHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCategoryTreeById_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.category.Category _item0 in structs.GetSuccess()){
						
						
						vipapis.category.CategoryHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCategoryTreeById_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getUpdatedCategoryList_resultHelper : TBeanSerializer<getUpdatedCategoryList_result>
		{
			
			public static getUpdatedCategoryList_resultHelper OBJ = new getUpdatedCategoryList_resultHelper();
			
			public static getUpdatedCategoryList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getUpdatedCategoryList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.category.CategoryUpdates value;
					
					value = new vipapis.category.CategoryUpdates();
					vipapis.category.CategoryUpdatesHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getUpdatedCategoryList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.category.CategoryUpdatesHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getUpdatedCategoryList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : TBeanSerializer<healthCheck_result>
		{
			
			public static healthCheck_resultHelper OBJ = new healthCheck_resultHelper();
			
			public static healthCheck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.hermes.core.health.CheckResult value;
					
					value = new com.vip.hermes.core.health.CheckResult();
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class uploadVendorCategory_resultHelper : TBeanSerializer<uploadVendorCategory_result>
		{
			
			public static uploadVendorCategory_resultHelper OBJ = new uploadVendorCategory_resultHelper();
			
			public static uploadVendorCategory_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(uploadVendorCategory_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(uploadVendorCategory_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(uploadVendorCategory_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class CategoryServiceClient : OspRestStub , CategoryService  {
			
			
			public CategoryServiceClient():base("vipapis.category.CategoryService","1.0.0") {
				
				
			}
			
			
			
			public List<vipapis.category.Attribute> getAttributes(int category_id_,string attr_text_) {
				
				send_getAttributes(category_id_,attr_text_);
				return recv_getAttributes(); 
				
			}
			
			
			private void send_getAttributes(int category_id_,string attr_text_){
				
				InitInvocation("getAttributes");
				
				getAttributes_args args = new getAttributes_args();
				args.SetCategory_id(category_id_);
				args.SetAttr_text(attr_text_);
				
				SendBase(args, getAttributes_argsHelper.getInstance());
			}
			
			
			private List<vipapis.category.Attribute> recv_getAttributes(){
				
				getAttributes_result result = new getAttributes_result();
				ReceiveBase(result, getAttributes_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.category.Attribute> getCategoryAttributeListById(int category_id_,bool? is_include_children_) {
				
				send_getCategoryAttributeListById(category_id_,is_include_children_);
				return recv_getCategoryAttributeListById(); 
				
			}
			
			
			private void send_getCategoryAttributeListById(int category_id_,bool? is_include_children_){
				
				InitInvocation("getCategoryAttributeListById");
				
				getCategoryAttributeListById_args args = new getCategoryAttributeListById_args();
				args.SetCategory_id(category_id_);
				args.SetIs_include_children(is_include_children_);
				
				SendBase(args, getCategoryAttributeListById_argsHelper.getInstance());
			}
			
			
			private List<vipapis.category.Attribute> recv_getCategoryAttributeListById(){
				
				getCategoryAttributeListById_result result = new getCategoryAttributeListById_result();
				ReceiveBase(result, getCategoryAttributeListById_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.category.Category getCategoryById(int category_id_) {
				
				send_getCategoryById(category_id_);
				return recv_getCategoryById(); 
				
			}
			
			
			private void send_getCategoryById(int category_id_){
				
				InitInvocation("getCategoryById");
				
				getCategoryById_args args = new getCategoryById_args();
				args.SetCategory_id(category_id_);
				
				SendBase(args, getCategoryById_argsHelper.getInstance());
			}
			
			
			private vipapis.category.Category recv_getCategoryById(){
				
				getCategoryById_result result = new getCategoryById_result();
				ReceiveBase(result, getCategoryById_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.category.Category> getCategoryListByName(string category_name_,int limit_,bool? only_leaf_) {
				
				send_getCategoryListByName(category_name_,limit_,only_leaf_);
				return recv_getCategoryListByName(); 
				
			}
			
			
			private void send_getCategoryListByName(string category_name_,int limit_,bool? only_leaf_){
				
				InitInvocation("getCategoryListByName");
				
				getCategoryListByName_args args = new getCategoryListByName_args();
				args.SetCategory_name(category_name_);
				args.SetLimit(limit_);
				args.SetOnly_leaf(only_leaf_);
				
				SendBase(args, getCategoryListByName_argsHelper.getInstance());
			}
			
			
			private List<vipapis.category.Category> recv_getCategoryListByName(){
				
				getCategoryListByName_result result = new getCategoryListByName_result();
				ReceiveBase(result, getCategoryListByName_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.category.Category> getCategoryTreeById(int category_id_) {
				
				send_getCategoryTreeById(category_id_);
				return recv_getCategoryTreeById(); 
				
			}
			
			
			private void send_getCategoryTreeById(int category_id_){
				
				InitInvocation("getCategoryTreeById");
				
				getCategoryTreeById_args args = new getCategoryTreeById_args();
				args.SetCategory_id(category_id_);
				
				SendBase(args, getCategoryTreeById_argsHelper.getInstance());
			}
			
			
			private List<vipapis.category.Category> recv_getCategoryTreeById(){
				
				getCategoryTreeById_result result = new getCategoryTreeById_result();
				ReceiveBase(result, getCategoryTreeById_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.category.CategoryUpdates getUpdatedCategoryList(long since_updatetime_,int hierarchyId_) {
				
				send_getUpdatedCategoryList(since_updatetime_,hierarchyId_);
				return recv_getUpdatedCategoryList(); 
				
			}
			
			
			private void send_getUpdatedCategoryList(long since_updatetime_,int hierarchyId_){
				
				InitInvocation("getUpdatedCategoryList");
				
				getUpdatedCategoryList_args args = new getUpdatedCategoryList_args();
				args.SetSince_updatetime(since_updatetime_);
				args.SetHierarchyId(hierarchyId_);
				
				SendBase(args, getUpdatedCategoryList_argsHelper.getInstance());
			}
			
			
			private vipapis.category.CategoryUpdates recv_getUpdatedCategoryList(){
				
				getUpdatedCategoryList_result result = new getUpdatedCategoryList_result();
				ReceiveBase(result, getUpdatedCategoryList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.hermes.core.health.CheckResult healthCheck() {
				
				send_healthCheck();
				return recv_healthCheck(); 
				
			}
			
			
			private void send_healthCheck(){
				
				InitInvocation("healthCheck");
				
				healthCheck_args args = new healthCheck_args();
				
				SendBase(args, healthCheck_argsHelper.getInstance());
			}
			
			
			private com.vip.hermes.core.health.CheckResult recv_healthCheck(){
				
				healthCheck_result result = new healthCheck_result();
				ReceiveBase(result, healthCheck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public int? uploadVendorCategory(int vendor_id_,string vendor_category_tree_name_,List<vipapis.category.VendorCategory> vendor_categories_) {
				
				send_uploadVendorCategory(vendor_id_,vendor_category_tree_name_,vendor_categories_);
				return recv_uploadVendorCategory(); 
				
			}
			
			
			private void send_uploadVendorCategory(int vendor_id_,string vendor_category_tree_name_,List<vipapis.category.VendorCategory> vendor_categories_){
				
				InitInvocation("uploadVendorCategory");
				
				uploadVendorCategory_args args = new uploadVendorCategory_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_category_tree_name(vendor_category_tree_name_);
				args.SetVendor_categories(vendor_categories_);
				
				SendBase(args, uploadVendorCategory_argsHelper.getInstance());
			}
			
			
			private int? recv_uploadVendorCategory(){
				
				uploadVendorCategory_result result = new uploadVendorCategory_result();
				ReceiveBase(result, uploadVendorCategory_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}