using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.isv.category{
	
	
	public class VendorCategoryMappingServiceHelper {
		
		
		
		public class findMatchedSuccessfullMapping_args {
			
			///<summary>
			/// 类目匹配关系主键id数组
			///</summary>
			
			private List<int?> id_;
			
			public List<int?> GetId(){
				return this.id_;
			}
			
			public void SetId(List<int?> value){
				this.id_ = value;
			}
			
		}
		
		
		
		
		public class getVendorMappedCategories_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 供应商类目id
			///</summary>
			
			private string vendor_category_id_;
			
			///<summary>
			/// 状态，默认：PASSED_AUDIT
			///</summary>
			
			private com.vip.isv.category.MappedCategoryState? state_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetVendor_category_id(){
				return this.vendor_category_id_;
			}
			
			public void SetVendor_category_id(string value){
				this.vendor_category_id_ = value;
			}
			public com.vip.isv.category.MappedCategoryState? GetState(){
				return this.state_;
			}
			
			public void SetState(com.vip.isv.category.MappedCategoryState? value){
				this.state_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class insertSelective_args {
			
			///<summary>
			/// 增加类目匹配
			///</summary>
			
			private com.vip.isv.category.VendorCategoryMappingDo record_;
			
			public com.vip.isv.category.VendorCategoryMappingDo GetRecord(){
				return this.record_;
			}
			
			public void SetRecord(com.vip.isv.category.VendorCategoryMappingDo value){
				this.record_ = value;
			}
			
		}
		
		
		
		
		public class multiUpdateByPrimaryKeySelective_args {
			
			///<summary>
			/// 待更新的类目匹配列表
			///</summary>
			
			private List<com.vip.isv.category.VendorCategoryMappingDo> records_;
			
			public List<com.vip.isv.category.VendorCategoryMappingDo> GetRecords(){
				return this.records_;
			}
			
			public void SetRecords(List<com.vip.isv.category.VendorCategoryMappingDo> value){
				this.records_ = value;
			}
			
		}
		
		
		
		
		public class selectByCondition_args {
			
			///<summary>
			/// 类目匹配关系
			///</summary>
			
			private com.vip.isv.category.VendorCategoryMappingDo condition_;
			
			public com.vip.isv.category.VendorCategoryMappingDo GetCondition(){
				return this.condition_;
			}
			
			public void SetCondition(com.vip.isv.category.VendorCategoryMappingDo value){
				this.condition_ = value;
			}
			
		}
		
		
		
		
		public class selectByPrimaryKey_args {
			
			///<summary>
			/// 类目匹配关系主键id
			///</summary>
			
			private int? id_;
			
			public int? GetId(){
				return this.id_;
			}
			
			public void SetId(int? value){
				this.id_ = value;
			}
			
		}
		
		
		
		
		public class selectByPrimaryKeys_args {
			
			///<summary>
			/// 类目匹配关系主键id数组
			///</summary>
			
			private List<int?> id_;
			
			public List<int?> GetId(){
				return this.id_;
			}
			
			public void SetId(List<int?> value){
				this.id_ = value;
			}
			
		}
		
		
		
		
		public class updateByPrimaryKeySelective_args {
			
			///<summary>
			/// 待更新的类目匹配
			///</summary>
			
			private com.vip.isv.category.VendorCategoryMappingDo record_;
			
			public com.vip.isv.category.VendorCategoryMappingDo GetRecord(){
				return this.record_;
			}
			
			public void SetRecord(com.vip.isv.category.VendorCategoryMappingDo value){
				this.record_ = value;
			}
			
		}
		
		
		
		
		public class findMatchedSuccessfullMapping_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.isv.category.VendorCategoryMappingDo> success_;
			
			public List<com.vip.isv.category.VendorCategoryMappingDo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.isv.category.VendorCategoryMappingDo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getVendorMappedCategories_result {
			
			///<summary>
			/// 供应商匹配类目
			///</summary>
			
			private List<com.vip.isv.category.MappedCategory> success_;
			
			public List<com.vip.isv.category.MappedCategory> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.isv.category.MappedCategory> value){
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
		
		
		
		
		public class insertSelective_result {
			
			///<summary>
			/// 新增成功记录数
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class multiUpdateByPrimaryKeySelective_result {
			
			///<summary>
			/// 更新成功记录数
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class selectByCondition_result {
			
			///<summary>
			/// 类目匹配列表
			///</summary>
			
			private List<com.vip.isv.category.VendorCategoryMappingDo> success_;
			
			public List<com.vip.isv.category.VendorCategoryMappingDo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.isv.category.VendorCategoryMappingDo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class selectByPrimaryKey_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.category.VendorCategoryMappingDo success_;
			
			public com.vip.isv.category.VendorCategoryMappingDo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.category.VendorCategoryMappingDo value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class selectByPrimaryKeys_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.isv.category.VendorCategoryMappingDo> success_;
			
			public List<com.vip.isv.category.VendorCategoryMappingDo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.isv.category.VendorCategoryMappingDo> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateByPrimaryKeySelective_result {
			
			///<summary>
			/// 更新成功记录数
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class findMatchedSuccessfullMapping_argsHelper : TBeanSerializer<findMatchedSuccessfullMapping_args>
		{
			
			public static findMatchedSuccessfullMapping_argsHelper OBJ = new findMatchedSuccessfullMapping_argsHelper();
			
			public static findMatchedSuccessfullMapping_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findMatchedSuccessfullMapping_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<int?> value;
					
					value = new List<int?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							int elem1;
							elem1 = iprot.ReadI32(); 
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(findMatchedSuccessfullMapping_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetId() != null) {
					
					oprot.WriteFieldBegin("id");
					
					oprot.WriteListBegin();
					foreach(int _item0 in structs.GetId()){
						
						oprot.WriteI32((int)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findMatchedSuccessfullMapping_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getVendorMappedCategories_argsHelper : TBeanSerializer<getVendorMappedCategories_args>
		{
			
			public static getVendorMappedCategories_argsHelper OBJ = new getVendorMappedCategories_argsHelper();
			
			public static getVendorMappedCategories_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getVendorMappedCategories_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetVendor_category_id(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.isv.category.MappedCategoryState? value;
					
					value = com.vip.isv.category.MappedCategoryStateUtil.FindByName(iprot.ReadString());
					
					structs.SetState(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getVendorMappedCategories_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetVendor_category_id() != null) {
					
					oprot.WriteFieldBegin("vendor_category_id");
					oprot.WriteString(structs.GetVendor_category_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_category_id can not be null!");
				}
				
				
				if(structs.GetState() != null) {
					
					oprot.WriteFieldBegin("state");
					oprot.WriteString(structs.GetState().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getVendorMappedCategories_args bean){
				
				
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
		
		
		
		
		public class insertSelective_argsHelper : TBeanSerializer<insertSelective_args>
		{
			
			public static insertSelective_argsHelper OBJ = new insertSelective_argsHelper();
			
			public static insertSelective_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(insertSelective_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.category.VendorCategoryMappingDo value;
					
					value = new com.vip.isv.category.VendorCategoryMappingDo();
					com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Read(value, iprot);
					
					structs.SetRecord(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(insertSelective_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRecord() != null) {
					
					oprot.WriteFieldBegin("record");
					
					com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Write(structs.GetRecord(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("record can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(insertSelective_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class multiUpdateByPrimaryKeySelective_argsHelper : TBeanSerializer<multiUpdateByPrimaryKeySelective_args>
		{
			
			public static multiUpdateByPrimaryKeySelective_argsHelper OBJ = new multiUpdateByPrimaryKeySelective_argsHelper();
			
			public static multiUpdateByPrimaryKeySelective_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(multiUpdateByPrimaryKeySelective_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.category.VendorCategoryMappingDo> value;
					
					value = new List<com.vip.isv.category.VendorCategoryMappingDo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.category.VendorCategoryMappingDo elem0;
							
							elem0 = new com.vip.isv.category.VendorCategoryMappingDo();
							com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetRecords(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(multiUpdateByPrimaryKeySelective_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRecords() != null) {
					
					oprot.WriteFieldBegin("records");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.category.VendorCategoryMappingDo _item0 in structs.GetRecords()){
						
						
						com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("records can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(multiUpdateByPrimaryKeySelective_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectByCondition_argsHelper : TBeanSerializer<selectByCondition_args>
		{
			
			public static selectByCondition_argsHelper OBJ = new selectByCondition_argsHelper();
			
			public static selectByCondition_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectByCondition_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.category.VendorCategoryMappingDo value;
					
					value = new com.vip.isv.category.VendorCategoryMappingDo();
					com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Read(value, iprot);
					
					structs.SetCondition(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(selectByCondition_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCondition() != null) {
					
					oprot.WriteFieldBegin("condition");
					
					com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Write(structs.GetCondition(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("condition can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectByCondition_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectByPrimaryKey_argsHelper : TBeanSerializer<selectByPrimaryKey_args>
		{
			
			public static selectByPrimaryKey_argsHelper OBJ = new selectByPrimaryKey_argsHelper();
			
			public static selectByPrimaryKey_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectByPrimaryKey_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(selectByPrimaryKey_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetId() != null) {
					
					oprot.WriteFieldBegin("id");
					oprot.WriteI32((int)structs.GetId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectByPrimaryKey_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectByPrimaryKeys_argsHelper : TBeanSerializer<selectByPrimaryKeys_args>
		{
			
			public static selectByPrimaryKeys_argsHelper OBJ = new selectByPrimaryKeys_argsHelper();
			
			public static selectByPrimaryKeys_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectByPrimaryKeys_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<int?> value;
					
					value = new List<int?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							int elem0;
							elem0 = iprot.ReadI32(); 
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(selectByPrimaryKeys_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetId() != null) {
					
					oprot.WriteFieldBegin("id");
					
					oprot.WriteListBegin();
					foreach(int _item0 in structs.GetId()){
						
						oprot.WriteI32((int)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectByPrimaryKeys_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateByPrimaryKeySelective_argsHelper : TBeanSerializer<updateByPrimaryKeySelective_args>
		{
			
			public static updateByPrimaryKeySelective_argsHelper OBJ = new updateByPrimaryKeySelective_argsHelper();
			
			public static updateByPrimaryKeySelective_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateByPrimaryKeySelective_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.category.VendorCategoryMappingDo value;
					
					value = new com.vip.isv.category.VendorCategoryMappingDo();
					com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Read(value, iprot);
					
					structs.SetRecord(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateByPrimaryKeySelective_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRecord() != null) {
					
					oprot.WriteFieldBegin("record");
					
					com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Write(structs.GetRecord(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("record can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateByPrimaryKeySelective_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class findMatchedSuccessfullMapping_resultHelper : TBeanSerializer<findMatchedSuccessfullMapping_result>
		{
			
			public static findMatchedSuccessfullMapping_resultHelper OBJ = new findMatchedSuccessfullMapping_resultHelper();
			
			public static findMatchedSuccessfullMapping_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(findMatchedSuccessfullMapping_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.category.VendorCategoryMappingDo> value;
					
					value = new List<com.vip.isv.category.VendorCategoryMappingDo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.category.VendorCategoryMappingDo elem0;
							
							elem0 = new com.vip.isv.category.VendorCategoryMappingDo();
							com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(findMatchedSuccessfullMapping_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.category.VendorCategoryMappingDo _item0 in structs.GetSuccess()){
						
						
						com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(findMatchedSuccessfullMapping_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getVendorMappedCategories_resultHelper : TBeanSerializer<getVendorMappedCategories_result>
		{
			
			public static getVendorMappedCategories_resultHelper OBJ = new getVendorMappedCategories_resultHelper();
			
			public static getVendorMappedCategories_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getVendorMappedCategories_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.category.MappedCategory> value;
					
					value = new List<com.vip.isv.category.MappedCategory>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.category.MappedCategory elem1;
							
							elem1 = new com.vip.isv.category.MappedCategory();
							com.vip.isv.category.MappedCategoryHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getVendorMappedCategories_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.category.MappedCategory _item0 in structs.GetSuccess()){
						
						
						com.vip.isv.category.MappedCategoryHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getVendorMappedCategories_result bean){
				
				
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
		
		
		
		
		public class insertSelective_resultHelper : TBeanSerializer<insertSelective_result>
		{
			
			public static insertSelective_resultHelper OBJ = new insertSelective_resultHelper();
			
			public static insertSelective_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(insertSelective_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(insertSelective_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(insertSelective_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class multiUpdateByPrimaryKeySelective_resultHelper : TBeanSerializer<multiUpdateByPrimaryKeySelective_result>
		{
			
			public static multiUpdateByPrimaryKeySelective_resultHelper OBJ = new multiUpdateByPrimaryKeySelective_resultHelper();
			
			public static multiUpdateByPrimaryKeySelective_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(multiUpdateByPrimaryKeySelective_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(multiUpdateByPrimaryKeySelective_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(multiUpdateByPrimaryKeySelective_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectByCondition_resultHelper : TBeanSerializer<selectByCondition_result>
		{
			
			public static selectByCondition_resultHelper OBJ = new selectByCondition_resultHelper();
			
			public static selectByCondition_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectByCondition_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.category.VendorCategoryMappingDo> value;
					
					value = new List<com.vip.isv.category.VendorCategoryMappingDo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.category.VendorCategoryMappingDo elem0;
							
							elem0 = new com.vip.isv.category.VendorCategoryMappingDo();
							com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(selectByCondition_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.category.VendorCategoryMappingDo _item0 in structs.GetSuccess()){
						
						
						com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectByCondition_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectByPrimaryKey_resultHelper : TBeanSerializer<selectByPrimaryKey_result>
		{
			
			public static selectByPrimaryKey_resultHelper OBJ = new selectByPrimaryKey_resultHelper();
			
			public static selectByPrimaryKey_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectByPrimaryKey_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.category.VendorCategoryMappingDo value;
					
					value = new com.vip.isv.category.VendorCategoryMappingDo();
					com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(selectByPrimaryKey_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectByPrimaryKey_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class selectByPrimaryKeys_resultHelper : TBeanSerializer<selectByPrimaryKeys_result>
		{
			
			public static selectByPrimaryKeys_resultHelper OBJ = new selectByPrimaryKeys_resultHelper();
			
			public static selectByPrimaryKeys_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(selectByPrimaryKeys_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.category.VendorCategoryMappingDo> value;
					
					value = new List<com.vip.isv.category.VendorCategoryMappingDo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.category.VendorCategoryMappingDo elem0;
							
							elem0 = new com.vip.isv.category.VendorCategoryMappingDo();
							com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(selectByPrimaryKeys_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.category.VendorCategoryMappingDo _item0 in structs.GetSuccess()){
						
						
						com.vip.isv.category.VendorCategoryMappingDoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(selectByPrimaryKeys_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateByPrimaryKeySelective_resultHelper : TBeanSerializer<updateByPrimaryKeySelective_result>
		{
			
			public static updateByPrimaryKeySelective_resultHelper OBJ = new updateByPrimaryKeySelective_resultHelper();
			
			public static updateByPrimaryKeySelective_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateByPrimaryKeySelective_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateByPrimaryKeySelective_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateByPrimaryKeySelective_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VendorCategoryMappingServiceClient : OspRestStub , VendorCategoryMappingService  {
			
			
			public VendorCategoryMappingServiceClient():base("vipapis.isv.category.VendorCategoryMappingService","1.0.0") {
				
				
			}
			
			
			
			public List<com.vip.isv.category.VendorCategoryMappingDo> findMatchedSuccessfullMapping(List<int?> id_) {
				
				send_findMatchedSuccessfullMapping(id_);
				return recv_findMatchedSuccessfullMapping(); 
				
			}
			
			
			private void send_findMatchedSuccessfullMapping(List<int?> id_){
				
				InitInvocation("findMatchedSuccessfullMapping");
				
				findMatchedSuccessfullMapping_args args = new findMatchedSuccessfullMapping_args();
				args.SetId(id_);
				
				SendBase(args, findMatchedSuccessfullMapping_argsHelper.getInstance());
			}
			
			
			private List<com.vip.isv.category.VendorCategoryMappingDo> recv_findMatchedSuccessfullMapping(){
				
				findMatchedSuccessfullMapping_result result = new findMatchedSuccessfullMapping_result();
				ReceiveBase(result, findMatchedSuccessfullMapping_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.isv.category.MappedCategory> getVendorMappedCategories(int vendor_id_,string vendor_category_id_,com.vip.isv.category.MappedCategoryState? state_) {
				
				send_getVendorMappedCategories(vendor_id_,vendor_category_id_,state_);
				return recv_getVendorMappedCategories(); 
				
			}
			
			
			private void send_getVendorMappedCategories(int vendor_id_,string vendor_category_id_,com.vip.isv.category.MappedCategoryState? state_){
				
				InitInvocation("getVendorMappedCategories");
				
				getVendorMappedCategories_args args = new getVendorMappedCategories_args();
				args.SetVendor_id(vendor_id_);
				args.SetVendor_category_id(vendor_category_id_);
				args.SetState(state_);
				
				SendBase(args, getVendorMappedCategories_argsHelper.getInstance());
			}
			
			
			private List<com.vip.isv.category.MappedCategory> recv_getVendorMappedCategories(){
				
				getVendorMappedCategories_result result = new getVendorMappedCategories_result();
				ReceiveBase(result, getVendorMappedCategories_resultHelper.getInstance());
				
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
			
			
			public int? insertSelective(com.vip.isv.category.VendorCategoryMappingDo record_) {
				
				send_insertSelective(record_);
				return recv_insertSelective(); 
				
			}
			
			
			private void send_insertSelective(com.vip.isv.category.VendorCategoryMappingDo record_){
				
				InitInvocation("insertSelective");
				
				insertSelective_args args = new insertSelective_args();
				args.SetRecord(record_);
				
				SendBase(args, insertSelective_argsHelper.getInstance());
			}
			
			
			private int? recv_insertSelective(){
				
				insertSelective_result result = new insertSelective_result();
				ReceiveBase(result, insertSelective_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public int? multiUpdateByPrimaryKeySelective(List<com.vip.isv.category.VendorCategoryMappingDo> records_) {
				
				send_multiUpdateByPrimaryKeySelective(records_);
				return recv_multiUpdateByPrimaryKeySelective(); 
				
			}
			
			
			private void send_multiUpdateByPrimaryKeySelective(List<com.vip.isv.category.VendorCategoryMappingDo> records_){
				
				InitInvocation("multiUpdateByPrimaryKeySelective");
				
				multiUpdateByPrimaryKeySelective_args args = new multiUpdateByPrimaryKeySelective_args();
				args.SetRecords(records_);
				
				SendBase(args, multiUpdateByPrimaryKeySelective_argsHelper.getInstance());
			}
			
			
			private int? recv_multiUpdateByPrimaryKeySelective(){
				
				multiUpdateByPrimaryKeySelective_result result = new multiUpdateByPrimaryKeySelective_result();
				ReceiveBase(result, multiUpdateByPrimaryKeySelective_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.isv.category.VendorCategoryMappingDo> selectByCondition(com.vip.isv.category.VendorCategoryMappingDo condition_) {
				
				send_selectByCondition(condition_);
				return recv_selectByCondition(); 
				
			}
			
			
			private void send_selectByCondition(com.vip.isv.category.VendorCategoryMappingDo condition_){
				
				InitInvocation("selectByCondition");
				
				selectByCondition_args args = new selectByCondition_args();
				args.SetCondition(condition_);
				
				SendBase(args, selectByCondition_argsHelper.getInstance());
			}
			
			
			private List<com.vip.isv.category.VendorCategoryMappingDo> recv_selectByCondition(){
				
				selectByCondition_result result = new selectByCondition_result();
				ReceiveBase(result, selectByCondition_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.isv.category.VendorCategoryMappingDo selectByPrimaryKey(int id_) {
				
				send_selectByPrimaryKey(id_);
				return recv_selectByPrimaryKey(); 
				
			}
			
			
			private void send_selectByPrimaryKey(int id_){
				
				InitInvocation("selectByPrimaryKey");
				
				selectByPrimaryKey_args args = new selectByPrimaryKey_args();
				args.SetId(id_);
				
				SendBase(args, selectByPrimaryKey_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.category.VendorCategoryMappingDo recv_selectByPrimaryKey(){
				
				selectByPrimaryKey_result result = new selectByPrimaryKey_result();
				ReceiveBase(result, selectByPrimaryKey_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.isv.category.VendorCategoryMappingDo> selectByPrimaryKeys(List<int?> id_) {
				
				send_selectByPrimaryKeys(id_);
				return recv_selectByPrimaryKeys(); 
				
			}
			
			
			private void send_selectByPrimaryKeys(List<int?> id_){
				
				InitInvocation("selectByPrimaryKeys");
				
				selectByPrimaryKeys_args args = new selectByPrimaryKeys_args();
				args.SetId(id_);
				
				SendBase(args, selectByPrimaryKeys_argsHelper.getInstance());
			}
			
			
			private List<com.vip.isv.category.VendorCategoryMappingDo> recv_selectByPrimaryKeys(){
				
				selectByPrimaryKeys_result result = new selectByPrimaryKeys_result();
				ReceiveBase(result, selectByPrimaryKeys_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public int? updateByPrimaryKeySelective(com.vip.isv.category.VendorCategoryMappingDo record_) {
				
				send_updateByPrimaryKeySelective(record_);
				return recv_updateByPrimaryKeySelective(); 
				
			}
			
			
			private void send_updateByPrimaryKeySelective(com.vip.isv.category.VendorCategoryMappingDo record_){
				
				InitInvocation("updateByPrimaryKeySelective");
				
				updateByPrimaryKeySelective_args args = new updateByPrimaryKeySelective_args();
				args.SetRecord(record_);
				
				SendBase(args, updateByPrimaryKeySelective_argsHelper.getInstance());
			}
			
			
			private int? recv_updateByPrimaryKeySelective(){
				
				updateByPrimaryKeySelective_result result = new updateByPrimaryKeySelective_result();
				ReceiveBase(result, updateByPrimaryKeySelective_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}